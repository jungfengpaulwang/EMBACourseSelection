using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Campus.Windows;
using DevComponents.Editors;
using FISCA.Data;
using FISCA.Permission;
using FISCA.UDT;

namespace CourseSelection.DetailItems
{
    [AccessControl("ischool.EMBA.DetailContent.Student_CSSnapshot", "各階段選課結果", "學生>資料項目")]
    public partial class CSSnapshot : DetailContentImproved
    {
        private AccessHelper Access;
        private QueryHelper Query;
        private DataTable Record = null;
        private ErrorProvider error_privider = new ErrorProvider();
        private bool form_loaded = false;

        public CSSnapshot()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form_Load);
            this.Group = "各階段選課結果";
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //  DataGridView 事件
            this.dgvData.DataError += new DataGridViewDataErrorEventHandler(dgvData_DataError);
            //this.dgvData.CurrentCellDirtyStateChanged += new EventHandler(dgvData_CurrentCellDirtyStateChanged);
            //this.dgvData.CellEnter += new DataGridViewCellEventHandler(dgvData_CellEnter);
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
            this.dgvData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_RowHeaderMouseClick);
            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);

            //this.WatchChange(new DataGridViewSource(this.dgvData));

            Access = new AccessHelper();
            Query = new QueryHelper();

            //  事件監聽
            //  1、班級異動
            //  2、組別異動
            //Course.AfterChange += (x, y) => ReInitialize();
        }

        protected override void OnInitializeAsync()
        {          
        }

        private void InitSchoolYearAndSemester()
        {
            this.cboSemester.DataSource = CourseSelection.DataItems.SemesterItem.GetSemesterList();
            this.cboSemester.ValueMember = "Value";
            this.cboSemester.DisplayMember = "Name";

            List<UDT.CSOpeningInfo> opening_infos = Access.Select<UDT.CSOpeningInfo>();
            if (opening_infos.Count > 0)
            {
                int school_year = opening_infos.ElementAt(0).SchoolYear;
                int semester = opening_infos.ElementAt(0).Semester;
                this.nudSchoolYear.Value = decimal.Parse(school_year.ToString());
                this.cboSemester.SelectedValue = semester.ToString();
            }
            else
            {
                int DefaultSchoolYear;
                if (int.TryParse(K12.Data.School.DefaultSchoolYear, out DefaultSchoolYear))
                {
                    this.nudSchoolYear.Value = decimal.Parse(DefaultSchoolYear.ToString());
                }
                else
                {
                    this.nudSchoolYear.Value = decimal.Parse((DateTime.Today.Year - 1911).ToString());
                }

                this.cboSemester.SelectedValue = K12.Data.School.DefaultSemester;
            }
        }

        private void InitItem()
        {
            ComboItem comboItem1 = new ComboItem("");
            comboItem1.Tag = null;
            this.cboItem.Items.Add(comboItem1);

            ComboItem comboItem2 = new ComboItem("第一階段");
            comboItem2.Tag = 1;
            this.cboItem.Items.Add(comboItem2);

            ComboItem comboItem3 = new ComboItem("第二階段");
            comboItem3.Tag = 2;
            this.cboItem.Items.Add(comboItem3);
        }

        protected override void OnInitializeComplete(Exception error)
        {
            if (error != null) //有錯就直接丟出去吧。
                throw error;

            this.InitSchoolYearAndSemester();
            this.InitItem();

            this.form_loaded = true;
        }

        protected override void OnPrimaryKeyChangedAsync()
        {
        }

        private void GridViewDataBinding()
        {
            if (!this.form_loaded)
                return; 
            
            this.dgvData.Rows.Clear();

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            if (this.cboItem.SelectedIndex < 1)
                return;

            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            if (combo_item.Tag == null)
                return;
            int item = int.Parse((combo_item).Tag + "");

            List<UDT.CSAttendSnapshot> CSAttendSnapshots = Access.Select<UDT.CSAttendSnapshot>(string.Format("ref_student_id={0} and school_year={1} and semester={2} and item={3}", PrimaryKey, school_year, semester, item));

            if (CSAttendSnapshots.Count == 0)
                return;

            DataTable dataTable = Query.Select(string.Format(@"select course.course_name, ce.new_subject_code, ce.course_type, course.credit from course
left join $ischool.emba.course_ext as ce on ce.ref_course_id=course.id where course.id in ({0})", string.Join(",", CSAttendSnapshots.Select(x => x.CourseID))));

            if (dataTable == null || dataTable.Rows.Count == 0)
                return;
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    List<object> source = new List<object>();

                    source.Add(row[0] + "");
                    source.Add(row[1] + "");
                    source.Add(row[2] + "");
                    source.Add(row[3] + "");

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                }
                this.dgvData.CurrentCell = null;
            }
        }

        protected override void OnPrimaryKeyChangedComplete(Exception error)
        {
            this.dgvData.Rows.Clear();

            if (error != null) //有錯就直接丟出去吧。
                throw error;

            ErrorTip.Clear();

            this.GridViewDataBinding();

            /* log */
            //this.logAgent.Clear();
            //this.AddLog(this.Record, _StudentBrief2);
            //this.logAgent.ActionType = Log.LogActionType.Update;

            ResetDirtyStatus();            
        }

        private void GridViewDataBinding(DataTable dataTable)
        {
            
            
        }
        
        protected override void OnCancelButtonClick(EventArgs e)
        {
            this.error_privider.Clear();
            base.OnCancelButtonClick(e);
        }

        protected override void OnSaveData()
        {            
            //if (!string.IsNullOrEmpty(error_privider.GetError(this.dgvData)))
            //{
            //    MessageBox.Show("請修正錯誤再儲存。");
            //    return;
            //}
            //ResetDirtyStatus();
        }

        protected override void OnDirtyStatusChanged(ChangeEventArgs e)
        {
            if (UserAcl.Current[this.GetType()].Editable)
                SaveButtonVisible = e.Status == ValueStatus.Dirty;
            else
                this.SaveButtonVisible = false;

            CancelButtonVisible = e.Status == ValueStatus.Dirty;
        }

        //private void Varify(DataGridView dgv)
        //{
        //    dgv.EndEdit();
        //    error_privider.Clear();
        //    string error_message = string.Empty;
        //    Dictionary<string, List<DataGridViewRow>> dicCells = new Dictionary<string, List<DataGridViewRow>>();
        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        if (row.IsNewRow)
        //            continue;

        //        row.ErrorText = string.Empty;
                
        //        string key = (row.Cells[0].Value + "") + "-" + (row.Cells[1].Value + "") + "-" + (row.Cells[2].Value + "");
        //        if (key == "--")
        //        {
        //            error_message = "至少要有一個條件。\n";

        //            continue;
        //        }
        //        if (!dicCells.ContainsKey(key))
        //            dicCells.Add(key, new List<DataGridViewRow>());

        //        dicCells[key].Add(row);
        //    }
        //    foreach (string key in dicCells.Keys)
        //    {
        //        if (dicCells[key].Count > 1)
        //        {
        //            error_message += "條件的組合重覆。";
        //        }
        //    }

        //    error_privider.SetError(dgv, error_message);
        //}

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //this.Varify(sender as DataGridView);
        }
        
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvData.SelectedCells.Count == 1)
            //{
            //    dgvData.BeginEdit(true);
            //    if (dgvData.CurrentCell != null && dgvData.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewComboBoxCell")
            //        (dgvData.EditingControl as ComboBox).DroppedDown = true;  //自動拉下清單
            //}
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
            dgvData.Rows[e.RowIndex].Selected = true;
        }

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvData.CurrentCell = null;
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvData.CurrentCell = null;
                dgvData.SelectAll();
            }
        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            this.GridViewDataBinding();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewDataBinding();
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewDataBinding();
        }
    }
}
