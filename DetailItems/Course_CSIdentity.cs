using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Campus.Windows;
using FISCA.Data;
using FISCA.Permission;
using FISCA.UDT;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CourseSelection.DetailItems
{
    [AccessControl("ischool.EMBA.DetailContent.Course_CSIdentity", "選課條件管理", "課程>資料項目")]
    public partial class Course_CSIdentity : DetailContentImproved
    {
        private AccessHelper Access;
        private QueryHelper Query;
        private List<dynamic> ClassRowSource = new List<dynamic>();
        private List<dynamic> ClassGradeYearRowSource = new List<dynamic>();
        private List<dynamic> DeptRowSource = new List<dynamic>();
        private UDT.CSCourseExt Record = null;
        private ErrorProvider error_privider = new ErrorProvider();
        private bool AllowChanged = false;

        public Course_CSIdentity()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form_Load);
            this.Group = "選課條件管理";
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //  DataGridView 事件
            this.dgvDataAllow.DataError += new DataGridViewDataErrorEventHandler(dgvDataAllow_DataError);
            this.dgvDataAllow.CurrentCellDirtyStateChanged += new EventHandler(dgvDataAllow_CurrentCellDirtyStateChanged);
            this.dgvDataAllow.CellEnter += new DataGridViewCellEventHandler(dgvDataAllow_CellEnter);
            this.dgvDataAllow.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDataAllow_ColumnHeaderMouseClick);
            this.dgvDataAllow.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDataAllow_RowHeaderMouseClick);
            this.dgvDataAllow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDataAllow_MouseClick);

            this.dgvDataDeny.DataError += new DataGridViewDataErrorEventHandler(dgvDataDeny_DataError);
            this.dgvDataDeny.CurrentCellDirtyStateChanged += new EventHandler(dgvDataDeny_CurrentCellDirtyStateChanged);
            this.dgvDataDeny.CellEnter += new DataGridViewCellEventHandler(dgvDataDeny_CellEnter);
            this.dgvDataDeny.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDataDeny_ColumnHeaderMouseClick);
            this.dgvDataDeny.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDataDeny_RowHeaderMouseClick);
            this.dgvDataDeny.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDataDeny_MouseClick);


            this.WatchChange(new DataGridViewSource(this.dgvDataAllow));
            this.WatchChange(new DataGridViewSource(this.dgvDataDeny));
            this.WatchChange(new CheckBoxXSource(this.chkNotOpening));
            this.WatchChange(new CheckBoxXSource(this.chkAllow));
            this.WatchChange(new CheckBoxXSource(this.chkDeny));

            Access = new AccessHelper();
            Query = new QueryHelper();

            //  事件監聽
            //  1、班級異動
            //  2、組別異動
            //Course.AfterChange += (x, y) => ReInitialize();
        }

        protected override void OnInitializeAsync()
        {
            LoadClassRowSource();
            LoadClassYearRowSource();
            LoadDeptRowSource();
        }

        protected override void OnInitializeComplete(Exception error)
        {
            if (error != null) //有錯就直接丟出去吧。
                throw error;

            //  入學年度
            this.cboClassGradeYear.DataSource = this.ClassGradeYearRowSource;
            this.cboClassGradeYear.ValueMember = "ID";
            this.cboClassGradeYear.DisplayMember = "Name";

            this.cboClassGradeYearDeny.DataSource = this.ClassGradeYearRowSource;
            this.cboClassGradeYearDeny.ValueMember = "ID";
            this.cboClassGradeYearDeny.DisplayMember = "Name";

            //  組別
            this.cboDept.DataSource = this.DeptRowSource;
            this.cboDept.ValueMember = "ID";
            this.cboDept.DisplayMember = "Name";

            this.cboDeptDeny.DataSource = this.DeptRowSource;
            this.cboDeptDeny.ValueMember = "ID";
            this.cboDeptDeny.DisplayMember = "Name";

            //  班級
            this.cboClass.DataSource = this.ClassRowSource;
            this.cboClass.ValueMember = "ID";
            this.cboClass.DisplayMember = "Name";

            this.cboClassDeny.DataSource = this.ClassRowSource;
            this.cboClassDeny.ValueMember = "ID";
            this.cboClassDeny.DisplayMember = "Name";
        }

        protected override void OnPrimaryKeyChangedAsync()
        {
            List<UDT.CSCourseExt> course_exts = Access.Select<UDT.CSCourseExt>(string.Format("ref_course_id={0}", PrimaryKey));

            if (course_exts.Count > 0)
                Record = course_exts[0];
            else
                Record = null;
        }

        protected override void OnPrimaryKeyChangedComplete(Exception error)
        {
            this.AllowChanged = false;
            this.chkNotOpening.Checked = false;
            this.chkAllow.Checked = false;
            this.chkDeny.Checked = false;
            this.dgvDataAllow.Enabled = false;
            this.dgvDataDeny.Enabled = false;
            this.dgvDataAllow.Rows.Clear();
            this.dgvDataDeny.Rows.Clear();

            if (error != null) //有錯就直接丟出去吧。
                throw error;

            ErrorTip.Clear();

            if (this.Record != null)
            {
                this.chkNotOpening.Checked = this.Record.NotOpening;

                this.GridViewDataBinding(this.Record.Identity);
            }

            /* log */
            //this.logAgent.Clear();
            //this.AddLog(this.Record, _StudentBrief2);
            //this.logAgent.ActionType = Log.LogActionType.Update;
            if (this.chkAllow.Checked == true)
            {
                this.dgvDataAllow.Enabled = true;
                this.dgvDataAllow.CurrentCell = null;
            }
            else
                this.dgvDataAllow.Enabled = false;

            if (this.chkDeny.Checked == true)
            {
                this.dgvDataDeny.Enabled = true;
                this.dgvDataDeny.CurrentCell = null;
            }
            else
                this.dgvDataDeny.Enabled = false;

            this.AllowChanged = true;
            ResetDirtyStatus();            
        }

        private void GridViewDataBinding(string identity)
        {
            XDocument xDocument;
            if (string.IsNullOrWhiteSpace(identity))
            {
                return;
            }
            else
            {
                /// 選課條件-Allow與Deny擇一儲存
                /// <Identities>
                ///     <Allow>
                ///         <Identity EnrollYear="101" DeptID=”568” ClassID=”” />
                ///         <Identity EnrollYear=”” DeptID=”” ClassID=”587” />
                ///         <Identity EnrollYear=”100” DeptID=”” ClassID=”” />
                ///     </Allow>
                ///     <Deny>
                ///         <Identity EnrollYear=”101” DeptID=”568” ClassID=”” />
                ///         <Identity EnrollYear=”” DeptID=”” ClassID=”587” />
                ///         <Identity EnrollYear=”100” DeptID=”” ClassID=”” />
                ///     </Deny>
                /// </Identities>
                try
                {
                    xDocument = XDocument.Parse(identity, LoadOptions.None);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                if (xDocument.Document.Element("Identities").Descendants("Allow").Count() > 0)
                {
                    this.chkAllow.Checked = true;
                    foreach (XElement xElement in xDocument.Document.Element("Identities").Descendants("Allow").Descendants("Identity"))
                    {
                        List<object> source = new List<object>();
                        if (xElement.Attribute("EnrollYear") != null)
                        {
                            if (!string.IsNullOrWhiteSpace(xElement.Attribute("EnrollYear").Value))
                                source.Add(xElement.Attribute("EnrollYear").Value);
                            else
                                source.Add("");
                        }
                        else
                            source.Add("");
                        if (!string.IsNullOrWhiteSpace(xElement.Attribute("DeptID").Value))
                            source.Add(xElement.Attribute("DeptID").Value);
                        else
                            source.Add("");
                        if (!string.IsNullOrWhiteSpace(xElement.Attribute("ClassID").Value))
                            source.Add(xElement.Attribute("ClassID").Value);
                        else
                            source.Add("");

                        int idx = this.dgvDataAllow.Rows.Add(source.ToArray());
                    }
                    this.dgvDataDeny.CurrentCell = null;
                    return;
                }
                if (xDocument.Document.Element("Identities").Descendants("Deny").Count() > 0)
                {
                    this.chkDeny.Checked = true;
                    foreach (XElement xElement in xDocument.Document.Element("Identities").Descendants("Deny").Descendants("Identity"))
                    {
                        List<object> source = new List<object>();
                        if (xElement.Attribute("EnrollYear") != null)
                        {
                            if (!string.IsNullOrWhiteSpace(xElement.Attribute("EnrollYear").Value))
                                source.Add(xElement.Attribute("EnrollYear").Value);
                            else
                                source.Add("");
                        }
                        else
                            source.Add("");
                        if (!string.IsNullOrWhiteSpace(xElement.Attribute("DeptID").Value))
                            source.Add(xElement.Attribute("DeptID").Value);
                        else
                            source.Add("");
                        if (!string.IsNullOrWhiteSpace(xElement.Attribute("ClassID").Value))
                            source.Add(xElement.Attribute("ClassID").Value);
                        else
                            source.Add("");

                        int idx = this.dgvDataDeny.Rows.Add(source.ToArray());
                    }
                    this.dgvDataDeny.CurrentCell = null;
                }
            }
        }
        
        protected override void OnCancelButtonClick(EventArgs e)
        {
            this.error_privider.Clear();
            base.OnCancelButtonClick(e);
        }

        protected override void OnSaveData()
        {            
            if (!string.IsNullOrEmpty(error_privider.GetError(this.dgvDataAllow)))
            {
                MessageBox.Show("請修正錯誤再儲存。");
                return;
            }

            if (this.Record == null)
                this.Record = new UDT.CSCourseExt();

            this.Record.CourseID = int.Parse(PrimaryKey);

            this.Record.NotOpening = this.chkNotOpening.Checked;

            /// 選課條件-Allow與Deny擇一儲存
            /// <Identities>
            ///     <Allow>
            ///         <Identity EnrollYear=”101” DeptID=”568” ClassID=”” />
            ///         <Identity EnrollYear=”” DeptID=”” ClassID=”587” />
            ///         <Identity EnrollYear=”100” DeptID=”” ClassID=”” />
            ///     </Allow>
            ///     <Deny>
            ///         <Identity EnrollYear=”101” DeptID=”568” ClassID=”” />
            ///         <Identity EnrollYear=”” DeptID=”” ClassID=”587” />
            ///         <Identity EnrollYear=”100” DeptID=”” ClassID=”” />
            ///     </Deny>
            /// </Identities>
            StringBuilder identity_allow = new StringBuilder();
            StringBuilder identity_deny = new StringBuilder();
            if (this.chkAllow.Checked)
            {
                foreach (DataGridViewRow row in this.dgvDataAllow.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    identity_allow.Append(string.Format("<Identity EnrollYear=\"{0}\" DeptID=\"{1}\" ClassID=\"{2}\" />", row.Cells[0].Value + "", row.Cells[1].Value + "", row.Cells[2].Value + ""));
                }
            }
            if (this.chkDeny.Checked)
            {
                foreach (DataGridViewRow row in this.dgvDataDeny.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    identity_deny.Append(string.Format("<Identity EnrollYear=\"{0}\" DeptID=\"{1}\" ClassID=\"{2}\" />", row.Cells[0].Value + "", row.Cells[1].Value + "", row.Cells[2].Value + ""));
                }
            }
            string identity = string.Empty;
            if (identity_allow.Length > 0)
                identity = "<Allow>" + identity_allow.ToString() + "</Allow>";
            if (identity_deny.Length > 0)
                identity += "<Deny>" + identity_deny.ToString() + "</Deny>";

            this.Record.Identity = "<Identities>" + identity + "</Identities>";

            this.Record.Save();
            ResetDirtyStatus();
        }

        private void LoadClassRowSource()
        {
            ClassRowSource.Clear();
            ClassRowSource.Add(new { Name = "", ID = "" });

            DataTable dataTable = Query.Select(string.Format(@"select class.id as class_id, class.class_name as class_name from class join student on class.id=student.ref_class_id
where student.status in (1, 4)
group by class_id, class_name, class.grade_year
order by class.grade_year, class_name"));

            if (dataTable.Rows.Count == 0)
                return;

            dataTable.Rows.Cast<DataRow>().ToList().ForEach(x => ClassRowSource.Add(new { Name = x["class_name"] + "", ID = x["class_id"] + "" }));
        }

        private void LoadClassYearRowSource()
        {
            ClassGradeYearRowSource.Clear();
            ClassGradeYearRowSource.Add(new { Name = "", ID = "" });

//            DataTable dataTable = Query.Select(string.Format(@"select class.grade_year as class_year from class join student on class.id=student.ref_class_id
//where student.status in (1)
//group by class.grade_year
//order by class.grade_year"));
            DataTable dataTable = Query.Select(string.Format(@"select class.grade_year as grade_year from class join student on class.id=student.ref_class_id
where student.status in (1, 4)
group by class.grade_year
order by class.grade_year"));

            if (dataTable.Rows.Count == 0)
                return;

            dataTable.Rows.Cast<DataRow>().ToList().ForEach(x => ClassGradeYearRowSource.Add(new { Name = x["grade_year"] + "", ID = x["grade_year"] + "" }));
            ClassGradeYearRowSource = ClassGradeYearRowSource.Distinct().ToList();
        }

        private void LoadDeptRowSource()
        {
            DeptRowSource.Clear();
            DeptRowSource.Add(new { Name = "", ID = "" });

            DataTable dataTable = Query.Select(string.Format(@"select dg.uid as dept_id, dg.name as dept_name from student join $ischool.emba.student_brief2 as sb on student.id=sb.ref_student_id join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id
where student.status in (1, 4)
group by dg.name, dg.uid
order by dg.name"));

            if (dataTable.Rows.Count == 0)
                return;

            dataTable.Rows.Cast<DataRow>().ToList().ForEach(x => DeptRowSource.Add(new { Name = x["dept_name"] + "", ID = x["dept_id"] + "" }));
        }

        private void chkOpeningGlobal_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.chkOpeningGlobal.Checked)
            //    this.dgvData.Enabled = false;
            //else
            //    this.dgvData.Enabled = true;
        }

        protected override void OnDirtyStatusChanged(ChangeEventArgs e)
        {
            if (UserAcl.Current[this.GetType()].Editable)
                SaveButtonVisible = e.Status == ValueStatus.Dirty;
            else
                this.SaveButtonVisible = false;

            CancelButtonVisible = e.Status == ValueStatus.Dirty;
        }

        private void dgvDataDeny_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvDataDeny_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDataDeny.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.Varify(sender as DataGridView);
        }

        private void Varify(DataGridView dgv)
        {
            dgv.EndEdit();
            error_privider.Clear();
            string error_message = string.Empty;
            Dictionary<string, List<DataGridViewRow>> dicCells = new Dictionary<string, List<DataGridViewRow>>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                row.ErrorText = string.Empty;
                
                string key = (row.Cells[0].Value + "") + "-" + (row.Cells[1].Value + "") + "-" + (row.Cells[2].Value + "");
                if (key == "--")
                {
                    error_message = "至少要有一個條件。\n";

                    continue;
                }
                if (!dicCells.ContainsKey(key))
                    dicCells.Add(key, new List<DataGridViewRow>());

                dicCells[key].Add(row);
            }
            foreach (string key in dicCells.Keys)
            {
                if (dicCells[key].Count > 1)
                {
                    error_message += "條件的組合重覆。";
                }
            }

            error_privider.SetError(dgv, error_message);
        }

        private void dgvDataAllow_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvDataAllow_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDataAllow.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.Varify(sender as DataGridView);
        }
        
        private void dgvDataAllow_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDataAllow.SelectedCells.Count == 1)
            {
                dgvDataAllow.BeginEdit(true);
                if (dgvDataAllow.CurrentCell != null && dgvDataAllow.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
                    (dgvDataAllow.EditingControl as ComboBox).DroppedDown = true;  //自動拉下清單
            }
        }

        private void dgvDataAllow_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDataAllow.CurrentCell = null;
            dgvDataAllow.Rows[e.RowIndex].Selected = true;
        }

        private void dgvDataAllow_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDataAllow.CurrentCell = null;
        }

        private void dgvDataAllow_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvDataAllow.CurrentCell = null;
                dgvDataAllow.SelectAll();
            }
        }

        private void dgvDataDeny_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDataDeny.SelectedCells.Count == 1)
            {
                dgvDataDeny.BeginEdit(true);
                if (dgvDataDeny.CurrentCell != null && dgvDataDeny.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
                    (dgvDataDeny.EditingControl as ComboBox).DroppedDown = true;  //自動拉下清單
            }
        }

        private void dgvDataDeny_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDataDeny.CurrentCell = null;
            dgvDataDeny.Rows[e.RowIndex].Selected = true;
        }

        private void dgvDataDeny_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDataDeny.CurrentCell = null;
        }

        private void dgvDataDeny_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvDataDeny.CurrentCell = null;
                dgvDataDeny.SelectAll();
                return;
            }
            if (hit.Type == DataGridViewHitTestType.RowHeader)
            {
                return;
            }
            dgvDataDeny.CurrentCell = null;
        }

        private void chkAllow_CheckedChanged(object sender, EventArgs e)
        {
            if (!AllowChanged)
                return;
            this.chkDeny.Checked = !this.chkAllow.Checked;
            this.dgvDataAllow.Enabled = this.chkAllow.Checked;
        }

        private void chkDeny_CheckedChanged(object sender, EventArgs e)
        {
            if (!AllowChanged)
                return;
            this.chkAllow.Checked = !this.chkDeny.Checked;
            this.dgvDataDeny.Enabled = this.chkDeny.Checked;
        }
    }
}
