using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Threading.Tasks;
using FISCA.UDT;
using System.Threading;
using System.ComponentModel;

namespace CourseSelection.Forms
{
    partial class frmFilter : Office2007Form
    {
        private FISCA.UDT.AccessHelper Access;
        private FISCA.Data.QueryHelper Query;
        private BackgroundWorker bw;
        private bool padding;
        private List<UDT.CSOpeningInfo> opening_infos;        
        private bool form_loaded;        
        private Random rng;
        private int item;
        private bool Lock;

        public frmFilter()
        {
            InitializeComponent();

            this.opening_infos = new List<UDT.CSOpeningInfo>();
            Access = new FISCA.UDT.AccessHelper();
            Query = new FISCA.Data.QueryHelper();
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            rng = new Random(Guid.NewGuid().GetHashCode());

            this.Load += new EventHandler(frmFilter_Load);
            this.FormClosed += new FormClosedEventHandler(frmFilter_FormClosed);
            this.dgvData.DataError += new DataGridViewDataErrorEventHandler(dgvData_DataError);
            this.dgvData.CurrentCellDirtyStateChanged += new EventHandler(dgvData_CurrentCellDirtyStateChanged);
            
            Event.DeliverActiveRecord.Received += new EventHandler<Event.DeliverCSAttendEventArgs>(ActiveRecord_Received);
            Task task = Task.Factory.StartNew(() =>
            {
                CourseSelection.BusinessLogic.TeachingEvaluationAchiving.IsAchieving(0, 0, "0"); 
            });
        }

        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmFilter_FormClosed(object sender, EventArgs e)
        {
            Event.DeliverActiveRecord.Received -= new EventHandler<Event.DeliverCSAttendEventArgs>(ActiveRecord_Received);
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            this.form_loaded = false;
            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            this.DisableButtons();

            this.item = 1;

            Task<bool> task = Task<bool>.Factory.StartNew(() =>
            {
                this.opening_infos = Access.Select<UDT.CSOpeningInfo>();
                if (this.opening_infos.Count == 0)
                    throw new Exception("未設定「選課開放時間」。");
                if (this.opening_infos.Where(x=>x.Item == 1).Count() == 0)
                    throw new Exception("未設定「第一階段選課開放時間」。");
                if (this.opening_infos.Where(x => x.Item == 2).Count() == 0)
                    throw new Exception("未設定「第二階段選課開放時間」。");
                if (this.opening_infos.Where(x => x.Item == 0).Count() == 0)
                    throw new Exception("未設定「加退選開放時間」。");

                DataTable dataTable_Server_Time = Query.Select("select now()");
                DateTime server_time = DateTime.Parse(dataTable_Server_Time.Rows[0][0] + "");          

                DateTime p1_begin_time = this.opening_infos.Where(x => x.Item == 1).ElementAt(0).BeginTime;
                DateTime p1_end_time = this.opening_infos.Where(x => x.Item == 1).ElementAt(0).EndTime;
                DateTime p2_begin_time = this.opening_infos.Where(x => x.Item == 2).ElementAt(0).BeginTime;
                DateTime p2_end_time = this.opening_infos.Where(x => x.Item == 2).ElementAt(0).EndTime;
                DateTime p0_begin_time = this.opening_infos.Where(x => x.Item == 0).ElementAt(0).BeginTime;
                DateTime p0_end_time = this.opening_infos.Where(x => x.Item == 0).ElementAt(0).EndTime;

                //第一階段開始時間5天前不開放「選課學生調整」功能
                if (server_time < p1_begin_time.AddDays(-5))
                {
                    return false;
                }
                //加退選開始時間：鎖定「選課學生調整」功能
                if (server_time >= p0_begin_time)
                {
                    return false;
                }
                //第一階段:第一階段開始時間前5天~第二階段開始時間
                if (p1_begin_time.AddDays(-5) <= server_time && server_time < p2_begin_time)
                {
                    return true;
                }
                //第二階段：第二階段開始時間~加退選開始時間
                if (p2_begin_time <= server_time && server_time < p0_begin_time)
                {
                    this.item = 2;
                    return true;
                }
                return false;
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    this.Close();
                    goto TheEnd;
                }

                this.InitSchoolYearAndSemester();
                this.InitCourse();

                this.lstCourse.DisplayMember = "Name";
                this.lstCourse.ValueMember = "UID";

                if (this.item == 1)
                    this.lblPeriod.Text = "第一階段";
                if (this.item == 2)
                    this.lblPeriod.Text = "第二階段";
                if (!x.Result)
                    this.lblPeriod.Text = "不允許調整";

                TheEnd:
                this.form_loaded = true;
                this.circularProgress.Visible = false;
                this.circularProgress.IsRunning = false;
                this.EnableButtons();
                this.Lock = !x.Result;
                if (!x.Result)
                {
                    this.btnManualFilter.Enabled = false;
                    this.btnFilter.Enabled = false;
                    this.btnAddManual.Enabled = false;
                    this.btnRecover.Enabled = false;
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DisableButtons()
        {
            this.nudSchoolYear.Enabled = false;
            this.cboSemester.Enabled = false;
            this.lstCourse.Enabled = false;

            this.btnSchoolYear.Enabled = false;
            this.btnDept.Enabled = false;
            this.btnClass.Enabled = false;
            this.btnConfirm.Enabled = false;
            this.btnClear.Enabled = false;

            this.btnFilter.Enabled = false;
            this.btnRecover.Enabled = false;
            this.btnAddManual.Enabled = false;
            this.btnManualFilter.Enabled = false;
        }

        private void EnableButtons()
        {
            this.nudSchoolYear.Enabled = true;
            this.cboSemester.Enabled = true;
            this.lstCourse.Enabled = true;

            this.btnSchoolYear.Enabled = true;
            this.btnDept.Enabled = true;
            this.btnClass.Enabled = true;
            this.btnConfirm.Enabled = true;
            this.btnClear.Enabled = true;

            this.btnFilter.Enabled = true;
            this.btnRecover.Enabled = true;
            this.btnAddManual.Enabled = true;
            this.btnManualFilter.Enabled = true;
        }

        private void ActiveRecord_Received(object sender, Event.DeliverCSAttendEventArgs e)
        {
            IEnumerable<UDT.CSAttend> CSAttends = e.ActiveRecords;
            if (CSAttends.Count() == 0)
                return;

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;

            this.DisableButtons();

            try
            {
                this.InitCSAttend(CSAttends.ElementAt(0).CourseID.ToString());
                if (this.chkShowLog.Checked)
                    this.AppendCSAttendLog(CSAttends.ElementAt(0).CourseID.ToString());
                this.CheckedManualCSAttend(CSAttends.ElementAt(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.EnableButtons();

            this.circularProgress.Visible = false;
            this.circularProgress.IsRunning = false;
        }

        private void CheckedManualCSAttend(UDT.CSAttend CSAttend)
        {
            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                if (row.Cells["lblStudentID"].Value + "" == CSAttend.StudentID.ToString())
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
            }
        }

        private void InitSchoolYearAndSemester()
        {
            this.cboSemester.DataSource = CourseSelection.DataItems.SemesterItem.GetSemesterList();
            this.cboSemester.ValueMember = "Value";
            this.cboSemester.DisplayMember = "Name";

            //if (opening_infos.Count > 0)
            //{
                int school_year = opening_infos.ElementAt(0).SchoolYear;
                int semester = opening_infos.ElementAt(0).Semester;
                this.nudSchoolYear.Value = decimal.Parse(school_year.ToString());
                this.cboSemester.SelectedValue = semester.ToString();
            //}
            //else
            //{
            //    int DefaultSchoolYear;
            //    if (int.TryParse(K12.Data.School.DefaultSchoolYear, out DefaultSchoolYear))
            //    {
            //        this.nudSchoolYear.Value = decimal.Parse(DefaultSchoolYear.ToString());
            //    }
            //    else
            //    {
            //        this.nudSchoolYear.Value = decimal.Parse((DateTime.Today.Year - 1911).ToString());
            //    }

            //    this.cboSemester.SelectedValue = K12.Data.School.DefaultSemester;
            //}
        }

        private void InitCourse()
        {
            this.lstCourse.Items.Clear();

            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as DataItems.SemesterItem).Value;

            DataTable dataTable = Query.Select(string.Format(@"select id, course_name, capacity, memo from course left join $ischool.emba.course_ext as ce on ce.ref_course_id=course.id where school_year={0} and semester={1}", school_year, semester));

            if (dataTable.Rows.Count == 0)
                return;

            foreach (DataRow row in dataTable.Rows)
            {
                dynamic item = new ExpandoObject();

                this.lstCourse.Items.Add(new { ID = row["id"] + "", Name = row["course_name"] + "", Capacity = row["capacity"] + "", Memo = row["memo"] + "" });
            }

            this.lstCourse.DisplayMember = "Name";
            this.lstCourse.ValueMember = "ID";
        }

        private void InitFilter()
        {
            this.btnSchoolYear.Tag = null;
            this.btnClass.Tag = null;
            this.btnDept.Tag = null;
            this.txtFilter.Text = string.Empty;
            this.txtFilter.Tag = null;
            
            List<string> SchoolYears = new List<string>();
            Dictionary<string, string> dicDeptNames = new Dictionary<string, string>();
            Dictionary<string, string> dicClassNames = new Dictionary<string, string>();

            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                SchoolYears.Add(row.Cells[0].Value + "");

                DataRow dataRow = row.Tag as DataRow;
                if (!dicDeptNames.ContainsKey(dataRow["dept_id"] + ""))
                    dicDeptNames.Add(dataRow["dept_id"] + "", row.Cells[1].Value + "");
                if (!dicClassNames.ContainsKey(dataRow["class_id"] + ""))
                    dicClassNames.Add(dataRow["class_id"] + "", row.Cells[2].Value + "");
            }
            if (SchoolYears.Count > 0)
            {
                int school_year = 0;
                List<dynamic> oSchoolYears = new List<dynamic>();
                SchoolYears.OrderBy(x => (int.TryParse(x, out school_year) ? school_year : 0)).Distinct().ToList().ForEach((x) =>
                {
                    dynamic oSchoolYear = new ExpandoObject();

                    oSchoolYear.Text = x;
                    oSchoolYear.ID = x;
                    oSchoolYear.Checked = false;

                    oSchoolYears.Add(oSchoolYear);
                });
                this.btnSchoolYear.Tag = oSchoolYears;
            }
            if (dicDeptNames.Count > 0)
            {
                List<dynamic> oDeptNames = new List<dynamic>();
                foreach(string key in dicDeptNames.OrderBy(x => x.Value).ToDictionary(x => x.Key).Keys)
                {
                    dynamic oDeptName = new ExpandoObject();

                    oDeptName.Text = dicDeptNames[key];
                    oDeptName.ID = key;
                    oDeptName.Checked = false;

                    oDeptNames.Add(oDeptName);
                }
                this.btnDept.Tag = oDeptNames;
            }
            if (dicClassNames.Count > 0)
            {
                List<dynamic> oClassNames = new List<dynamic>();
                foreach (string key in dicClassNames.OrderBy(x => x.Value).ToDictionary(x => x.Key).Keys)
                {
                    dynamic oClassName = new ExpandoObject();

                    oClassName.Text = dicClassNames[key];
                    oClassName.ID = key;
                    oClassName.Checked = false;

                    oClassNames.Add(oClassName);
                }
                this.btnClass.Tag = oClassNames;
            }
        }

        private void lstCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCapacityInfo.Text = string.Format("優先人數：{0}　　選課人數：{1}", 0, 0);
            this.groupPanel1.Text = "課程資訊";
            this.groupPanel1.Tag = null;
            System.Windows.Forms.ListBox lstBox = (sender as System.Windows.Forms.ListBox);
            if (lstBox.SelectedIndex == -1)
                return;

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            this.groupPanel1.Text = ((dynamic)lstBox.SelectedItem).Name;
            this.groupPanel1.Tag = ((dynamic)lstBox.SelectedItem).ID;

            //Form frm = new Agent.Viewer.DoWork();
            //frm.Show();
            //frm.BringToFront();

            this.DisableButtons();

            this.txtCapacity.Text = ((dynamic)lstBox.SelectedItem).Capacity;
            this.txtMemo.Text = ((dynamic)lstBox.SelectedItem).Memo;

            this.InitCSAttend(((dynamic)lstBox.SelectedItem).ID);
            if (this.chkShowLog.Checked)
                this.AppendCSAttendLog(((dynamic)lstBox.SelectedItem).ID);

            this.circularProgress.Visible = false;
            this.circularProgress.IsRunning = false;

            this.EnableButtons();
            if (this.Lock)
            {
                this.btnManualFilter.Enabled = false;
                this.btnFilter.Enabled = false;
                this.btnAddManual.Enabled = false;
                this.btnRecover.Enabled = false;
            }
            else
            {
                this.btnManualFilter.Enabled = true;
                this.btnFilter.Enabled = true;
                this.btnAddManual.Enabled = true;
                this.btnRecover.Enabled = true;
            }
            //frm.Close();
        }

        private void RemoveCSAttendLog()
        {
            this.dgvData.Rows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
            {
                if (x.DefaultCellStyle.BackColor == System.Drawing.Color.Pink)
                    this.dgvData.Rows.RemoveAt(x.Index);
            });
        }

        private void AppendCSAttendLog(string CourseID)
        {
            this.chkShowLog.Enabled = false;
            try
            {
                DataTable dataTable = Query.Select(string.Format(@"select sb.enroll_year as 入學年度, dg.name as 組別, class.class_name as 班級, student.student_number as 學號, student.name as 姓名,  (cl.last_update) as 選課時間, (cl.item) as 選課階段, '' as 優先, student.id as 學生系統編號 from $ischool.emba.cs_attend_log as cl join student on cl.ref_student_id = student.id left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id left join class on class.id=student.ref_class_id where student.id in 
(
select ref_student_id from $ischool.emba.cs_attend_log
where ref_course_id={0} and action='delete' and action_by='staff' 
) 
and student.id not in 
(
select ref_student_id from $ischool.emba.cs_attend where ref_course_id={0}
)
and cl.action='delete' and cl.action_by='staff'
--group by 入學年度, 組別, 班級, 學號, 姓名, 優先, 學生系統編號
order by sb.enroll_year, dg.name, class_name, student_number, cl.uid desc", CourseID));

                if (dataTable.Rows.Count == 0)
                {
                    this.chkShowLog.Enabled = true;
                    return;
                }

                Dictionary<string, DataRow> dicDataRows = new Dictionary<string, DataRow>();
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!dicDataRows.ContainsKey(row["學生系統編號"] + ""))
                        dicDataRows.Add(row["學生系統編號"] + "", row);
                }
                foreach (string key in dicDataRows.Keys)
                {
                    List<object> source = new List<object>();

                    source.Add(dicDataRows[key]["入學年度"] + "");
                    source.Add(dicDataRows[key]["組別"] + "");
                    source.Add(dicDataRows[key]["班級"] + "");
                    source.Add(dicDataRows[key]["學號"] + "");
                    source.Add(dicDataRows[key]["姓名"] + "");
                    source.Add(dicDataRows[key]["選課時間"] + "");
                    source.Add(dicDataRows[key]["選課階段"] + "");

                    source.Add(false);

                    source.Add(dicDataRows[key]["學生系統編號"] + "");

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                    this.dgvData.Rows[idx].Tag = dicDataRows[key];
                    this.dgvData.Rows[idx].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                this.chkShowLog.Enabled = true;
            }
            catch(Exception  ex)
            {
                this.chkShowLog.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void InitCSAttend(string CourseID)
        {
            this.dgvData.Rows.Clear();
            DataTable dataTable = new DataTable();

            int SchoolYear = int.Parse(this.nudSchoolYear.Value.ToString());
            int Semester = int.Parse(this.cboSemester.SelectedValue + "");
            //Task task = Task.Factory.StartNew(() =>
            //{
                List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id = {0}", CourseID));
                if (CSAttends.Count == 0)
                    return;

                dataTable = Query.Select(string.Format(@"select student.id as student_id, sb.enroll_year, dg.name as dept_name, dg.uid as dept_id, class.id as class_id, class_name, student_number, student.name as student_name, ca.last_update, '' as preserved, ca.item, ca.manually, ca.is_condition, ca.is_manual from student join $ischool.emba.cs_attend as ca on ca.ref_student_id=student.id join course on course.id=ca.ref_course_id left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id
left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id left join class on class.id=student.ref_class_id where course.id={0} and student.id in ({1}) order by sb.enroll_year, dept_name, class_name, student_number", CourseID, string.Join(",", CSAttends.Select(x => x.StudentID))));

                if (dataTable.Rows.Count == 0)
                    return;
            //});
            //task.ContinueWith((x)=>
            //{
                foreach (DataRow row in dataTable.Rows)
                {
                    List<object> source = new List<object>();

                    source.Add(row["enroll_year"] + "");
                    source.Add(row["dept_name"] + "");
                    source.Add(row["class_name"] + "");
                    source.Add(row["student_number"] + "");
                    source.Add(row["student_name"] + "");
                    source.Add(row["last_update"] + "");
                    source.Add(row["item"] + "");
                    //  條件優先
                    bool IsCondition = false;
                    bool.TryParse(row["is_condition"] + "", out IsCondition);
                    source.Add(IsCondition);
                    source.Add(row["student_id"] + "");
                    //  選課優先：往前推2個學期的評鑑值
                    source.Add(CourseSelection.BusinessLogic.TeachingEvaluationAchiving.IsAchieving(Semester - 2 >= 0 ? SchoolYear : SchoolYear - 1 , Semester - 2 >= 0 ? Semester - 2 : Semester - 2 + 3, row["student_id"] + ""));
                    //  第一階段選上
                    int intItem = 0;
                    int.TryParse(row["item"] + "", out intItem);
                    if (this.item == 2 && intItem == 1)
                        source.Add(true);
                    else
                        source.Add(false);
                    //  手動優先
                    bool IsManual = false;
                    bool.TryParse(row["is_manual"] + "", out IsManual);
                    source.Add(IsManual);

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                    this.dgvData.Rows[idx].Tag = row;

                    //  手動加入
                    bool manually;
                    if (bool.TryParse(row["manually"] + "", out manually) && manually)
                        this.dgvData.Rows[idx].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
                this.CountDGV();
                this.InitFilter();
            //}, System.Threading.CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
            //task.Wait();
        }

        private void chkAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnAddManual_Click(object sender, EventArgs e)
        {
            if (this.lstCourse.SelectedIndex == -1)
            {
                MessageBox.Show("請先選擇課程。");
                return;
            }
            int SchoolYear = int.Parse(this.nudSchoolYear.Value.ToString());
            int Semester = int.Parse(this.cboSemester.SelectedValue + "");
            string CourseID = this.groupPanel1.Tag + "";
            (new Forms.frmCSAttendManual(CourseID, SchoolYear, Semester, this.item)).ShowDialog();
        }

        private void chkShowLog_Click(object sender, EventArgs e)
        {

        }

        private void lnkReset_Click(object sender, EventArgs e)
        {

        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (form_loaded)
            {
                this.nudSchoolYear.Enabled = false;
                this.InitCourse();
                this.nudSchoolYear.Enabled = true;
            }
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSemester.SelectedIndex == -1)
                return;

            if (form_loaded)
            {
                this.cboSemester.Enabled = false;
                this.InitCourse();
                this.cboSemester.Enabled = true;
            }
        }

        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> StudentIDs = new List<string>();
            string CourseID = this.groupPanel1.Tag + "";
            if (string.IsNullOrEmpty(CourseID) || this.dgvData.Rows.Count == 0)
                return;
            this.dgvData.Rows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
            {
                (x.Cells["chkLock"] as DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXCell).Value = false;
                StudentIDs.Add(x.Cells["lblStudentID"].Value + "");
            });

            Task task = Task.Factory.StartNew(() =>
            {
                List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0} and ref_student_id in ({1})", CourseID, string.Join(",", StudentIDs)));

                CSAttends.ForEach((x) =>
                {
                    x.IsCondition = false;
                });
                CSAttends.SaveAll();
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            this.CountDGV();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.dgvData.Rows.Count == 0)
                return;

            this.DisableButtons();

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            List<string> enroll_years = new List<string>();
            List<string> depts = new List<string>();
            List<string> clazzs = new List<string>();

            if (this.btnSchoolYear.Tag != null)
            {
                (this.btnSchoolYear.Tag as List<dynamic>).ForEach((x) =>
                {
                    if (x.Checked)
                        enroll_years.Add(x.Text);
                });
            }

            if (this.btnDept.Tag != null)
            {
                (this.btnDept.Tag as List<dynamic>).ForEach((x) =>
                {
                    if (x.Checked)
                        depts.Add(x.Text);
                });
            }

            if (this.btnClass.Tag != null)
            {
                (this.btnClass.Tag as List<dynamic>).ForEach((x) =>
                {
                    if (x.Checked)
                        clazzs.Add(x.Text);
                });
            }
            if (enroll_years.Count == 0 && depts.Count == 0 && clazzs.Count == 0)
            {
                goto TheEnd;
            }

            string CourseID = this.groupPanel1.Tag + "";
            if (string.IsNullOrEmpty(CourseID))
                goto TheEnd;

            List<string> StudentIDs = new List<string>();
            this.dgvData.Rows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
            {
                if (x.DefaultCellStyle.BackColor != System.Drawing.Color.Pink)
                {
                    string enroll_year = x.Cells["lblEnrollYear"].Value + "";
                    string dept = x.Cells["lblDeptName"].Value + "";
                    string clazz = x.Cells["lblClassName"].Value + "";

                    if (((enroll_years.Count == 0 ? true : enroll_years.Contains(enroll_year))) && ((depts.Count == 0 ? true : depts.Contains(dept))) && ((clazzs.Count == 0 ? true : clazzs.Contains(clazz))))
                    {
                        (x.Cells["chkLock"] as DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXCell).Value = true;
                        StudentIDs.Add(x.Cells["lblStudentID"].Value + "");
                    }
                }
            });

            Task task = Task.Factory.StartNew(() =>
            {
                List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0} and ref_student_id in ({1})", CourseID, string.Join(",", StudentIDs)));

                CSAttends.ForEach((x) =>
                {
                    x.IsCondition = true;
                });
                CSAttends.SaveAll();
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

            this.CountDGV();

            TheEnd:
            this.EnableButtons();
            this.circularProgress.Visible = false;
            this.circularProgress.IsRunning = false;

            //string StudentID = (this.dgvData.Rows[e.RowIndex].Cells[8]).Value + "";
            //Task task = Task.Factory.StartNew(() =>
            //{
            //    List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0} and ref_student_id={1}", CourseID, StudentID));

            //    CSAttends.ForEach((x) =>
            //    {
            //        x.IsManual = !IsManual;
            //        x.IsCondition = IsCondition;
            //    });
            //    CSAttends.SaveAll();
            //});
            //task.ContinueWith((x) =>
            //{
            //    if (x.Exception != null)
            //    {
            //        MessageBox.Show(x.Exception.InnerException.Message);
            //    }
            //}, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CountDGV()
        {
            int locked_no = 0;
            int total_no = 0;
            if (this.dgvData.Rows.Count == 0)
            {
                lblCapacityInfo.Text = string.Format("優先人數：{0}　　選課人數：{1}", locked_no, total_no);
                return;
            }

            List<DataGridViewRow> DataGridViewRows = this.dgvData.Rows.Cast<DataGridViewRow>().ToList();
            DataGridViewRows.ForEach((x) =>
            {
                if (x.DefaultCellStyle.BackColor != System.Drawing.Color.Pink)
                {
                    total_no += 1;

                    bool is_condition = false;
                    bool is_evaluation = false;
                    bool is_period_1 = false;
                    bool is_manual = false;

                    bool.TryParse(x.Cells["chkLock"].Value + "", out is_condition);
                    bool.TryParse(x.Cells["chkEvaluation"].Value + "", out is_evaluation);
                    bool.TryParse(x.Cells["colPeriod1"].Value + "", out is_period_1);
                    bool.TryParse(x.Cells["colManual"].Value + "", out is_manual);

                    if (is_condition || is_evaluation || is_period_1 || is_manual)
                        locked_no += 1;
                }
            });
            lblCapacityInfo.Text = string.Format("優先人數：{0}　　選課人數：{1}", locked_no, total_no);
        }

        private List<int> RandomOrder(List<int> Source)
        {
            for (int i = 0; i < Source.Count; i++)
            {
                int index = rng.Next(0, Source.Count() - 1 - i);
                int tmp = Source[Source.Count() - 1 - i];
                Source[Source.Count() - 1 - i] = Source.ElementAt(index);
                Source[index] = tmp;
            }

            return Source;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            uint capacity = 0;

            if (uint.TryParse(txtCapacity.Text.Trim(), out capacity))
            {
                if (capacity == 0)
                {
                    MessageBox.Show("人數上限為 0，無法自動篩汰學生。");
                    return;
                }
                else
                {
                    uint locked_no = 0;
                    uint total_no = 0;
                    foreach (DataGridViewRow row in this.dgvData.Rows)
                    {
                        if (row.DefaultCellStyle.BackColor != System.Drawing.Color.Pink)
                        {
                            total_no += 1;

                            bool manual = false;
                            bool period1 = false;
                            if ((bool.TryParse(row.Cells["colManual"].Value + "", out manual) && manual) || (bool.TryParse(row.Cells["colPeriod1"].Value + "", out period1) && period1))
                                locked_no += 1;
                        }
                    }
                    if (capacity >= total_no)
                    {
                        MessageBox.Show("選課人數未超過人數上限，不需篩汰學生。");
                        return;
                    }
                    else
                    {
                        if (locked_no > capacity)
                        {
                            MessageBox.Show("「手動優先人數」+「第一階段選上人數」大於人數上限，無法自動篩汰學生。");
                            return;
                        }
                        else
                        {
                            this.DisableButtons();

                            uint delete_no = total_no - capacity;

                            List<DataGridViewRow> locked_rows_evaluation = new List<DataGridViewRow>();
                            List<DataGridViewRow> locked_rows_condition = new List<DataGridViewRow>();
                            List<DataGridViewRow> locked_rows_condition_evaluation = new List<DataGridViewRow>();
                            List<DataGridViewRow> deleted_rows = new List<DataGridViewRow>();
                            List<DataGridViewRow> locked_rows = new List<DataGridViewRow>();
                            List<DataGridViewRow> no_locked_rows = new List<DataGridViewRow>();
                            foreach (DataGridViewRow row in this.dgvData.Rows)
                            {
                                if (row.DefaultCellStyle.BackColor == System.Drawing.Color.Pink)
                                {
                                    deleted_rows.Add(row);
                                    continue;
                                }
                                bool locked_evaluation = false;
                                bool locked_condition = false;
                                bool manual = false;
                                bool period1 = false;

                                bool.TryParse(row.Cells["colManual"].Value + "", out manual);
                                bool.TryParse(row.Cells["colPeriod1"].Value + "", out period1);
                                bool.TryParse(row.Cells["chkEvaluation"].Value + "", out locked_evaluation);
                                bool.TryParse(row.Cells["chkLock"].Value + "", out locked_condition);

                                if (manual || period1)
                                    continue;

                                if (!locked_evaluation && !locked_condition)
                                    no_locked_rows.Add(row);

                                if (!locked_condition && locked_evaluation)
                                    locked_rows_evaluation.Add(row);

                                if (locked_condition && !locked_evaluation)
                                    locked_rows_condition.Add(row);

                                if (locked_condition && locked_evaluation)
                                    locked_rows_condition_evaluation.Add(row);
                            }
                            //  重排「no_locked_rows」索引號
                            List<int> OrderedArray_no_locked = RandomOrder(Enumerable.Range(0, no_locked_rows.Count).ToList());
                            //  重排「locked_rows_evaluation」索引號
                            List<int> OrderedArray_evaluation = RandomOrder(Enumerable.Range(0, locked_rows_evaluation.Count).ToList());
                            //  重排「locked_rows_condition」索引號
                            List<int> OrderedArray_condition = RandomOrder(Enumerable.Range(0, locked_rows_condition.Count).ToList());
                            //  重排「locked_rows_condition_evaluation」索引號
                            List<int> OrderedArray_condition_evaluation = RandomOrder(Enumerable.Range(0, locked_rows_condition_evaluation.Count).ToList());
                            //  待移除資料
                            List<DataGridViewRow> will_delete_rows = new List<DataGridViewRow>();
                            //  先移除沒有任何勾選
                            for (int i = 0; i < OrderedArray_no_locked.Count; i++)
                            {
                                will_delete_rows.Add(no_locked_rows.ElementAt(OrderedArray_no_locked.ElementAt(i)));
                            }
                            //  再移除選課優先
                            for (int i = 0; i < OrderedArray_evaluation.Count; i++)
                            {
                                will_delete_rows.Add(locked_rows_evaluation.ElementAt(OrderedArray_evaluation.ElementAt(i)));
                            }
                            //  再移除條件優先
                            for (int i = 0; i < OrderedArray_condition.Count; i++)
                            {
                                will_delete_rows.Add(locked_rows_condition.ElementAt(OrderedArray_condition.ElementAt(i)));
                            }
                            //  最後移除選課優先+條件優先
                            for (int i = 0; i < OrderedArray_condition_evaluation.Count; i++)
                            {
                                will_delete_rows.Add(locked_rows_condition_evaluation.ElementAt(OrderedArray_condition_evaluation.ElementAt(i)));
                            }
                            // 寫入自動篩汰資料
                            string CourseID = this.groupPanel1.Tag + "";
                            decimal school_year = this.nudSchoolYear.Value;
                            string semester = (this.cboSemester.SelectedItem as DataItems.SemesterItem).Value;

                            List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0}", CourseID));
                            Dictionary<int, UDT.CSAttend> dicCSAttends = new Dictionary<int, UDT.CSAttend>();
                            if (CSAttends.Count > 0)
                            {
                                CSAttends.ForEach((x) =>
                                {
                                    if (!dicCSAttends.ContainsKey(x.StudentID))
                                        dicCSAttends.Add(x.StudentID, x);
                                });
                            }
                            List<UDT.CSAttend> CSAttend_Deleteds = new List<UDT.CSAttend>();
                            List<UDT.CSAttendLog> CSAttendLogs = new List<UDT.CSAttendLog>();
                            //  開始移除「will_delete_rows」的元素          
                            for (int i = 0; i<delete_no; i++)
                            {
                                DataGridViewRow row = will_delete_rows.ElementAt(i);
                                
                                int StudentID = int.Parse(row.Cells["lblStudentID"].Value + "");
                                if (dicCSAttends.ContainsKey(StudentID))
                                {
                                    UDT.CSAttend CSAttend = dicCSAttends[StudentID];
                                    UDT.CSAttendLog CSAttendLog = new UDT.CSAttendLog();
                                    CSAttend.Deleted = true;

                                    CSAttendLog.StudentID = StudentID;
                                    CSAttendLog.CourseID = int.Parse(CourseID);
                                    CSAttendLog.SchoolYear = int.Parse(school_year.ToString());
                                    CSAttendLog.Semester = int.Parse(semester);
                                    CSAttendLog.Item = this.item;
                                    CSAttendLog.Action = "delete";
                                    CSAttendLog.ActionBy = "staff";

                                    CSAttendLogs.Add(CSAttendLog);
                                    CSAttend_Deleteds.Add(CSAttend);
                                }
                            }
                            CSAttend_Deleteds.SaveAll();
                            CSAttendLogs.SaveAll();

                            this.InitCSAttend(CourseID);
                            if (this.chkShowLog.Checked)
                                this.AppendCSAttendLog(CourseID);

                            this.EnableButtons();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("人數上限必須為正整數。");
                return;
            }
        }

        private void chkShowLog_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lstCourse.SelectedIndex == -1)
                return;

            string CourseID = this.groupPanel1.Tag + "";

            this.DisableButtons();

            this.chkShowLog.Enabled = false;
            if (this.chkShowLog.Checked)
                this.AppendCSAttendLog(CourseID);
            else
                this.RemoveCSAttendLog();

            this.chkShowLog.Enabled = true;

            this.EnableButtons();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (this.lstCourse.SelectedIndex == -1)
                return;

            this.DisableButtons();

            string CourseID = this.groupPanel1.Tag + "";
            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as DataItems.SemesterItem).Value;

            List<UDT.CSAttend> CSAttends = new List<UDT.CSAttend>();
            List<UDT.CSAttendLog> CSAttendLogs = new List<UDT.CSAttendLog>();
            if (this.dgvData.SelectedRows.Count == 0)
                return;

            this.dgvData.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
            {
                if (x.DefaultCellStyle.BackColor == System.Drawing.Color.Pink)
                {
                    UDT.CSAttend CSAttend = new UDT.CSAttend();
                    UDT.CSAttendLog CSAttendLog = new UDT.CSAttendLog();

                    CSAttend.StudentID = int.Parse(x.Cells["lblStudentID"].Value + "");
                    CSAttend.CourseID = int.Parse(CourseID);
                    CSAttend.SchoolYear = int.Parse(school_year.ToString());
                    CSAttend.Semester = int.Parse(semester);
                    CSAttend.Item = this.item;

                    CSAttends.Add(CSAttend);

                    CSAttendLog.StudentID = int.Parse(x.Cells["lblStudentID"].Value + "");
                    CSAttendLog.CourseID = int.Parse(CourseID);
                    CSAttendLog.SchoolYear = int.Parse(school_year.ToString());
                    CSAttendLog.Semester = int.Parse(semester);
                    CSAttendLog.Item = this.item;
                    CSAttendLog.Action = "insert";
                    CSAttendLog.ActionBy = "staff";

                    CSAttendLogs.Add(CSAttendLog);

                    x.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window; 
                }
            });
            CSAttends.SaveAll();
            CSAttendLogs.SaveAll();

            this.InitCSAttend(CourseID);
            if (this.chkShowLog.Checked)
                this.AppendCSAttendLog(CourseID);

            this.EnableButtons();
        }

        private void btnSchoolYear_Click(object sender, EventArgs e)
        {
            if (this.dgvData.Rows.Count == 0)
                return;

            if (this.btnSchoolYear.Tag == null)
                return;

            frmListViewContainer form = new frmListViewContainer("設定「入學年度」優先選取條件", this.btnSchoolYear.Tag as List<dynamic>);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.btnSchoolYear.Tag = form.CheckLists;
                this.RefreshFilterBox();
            }
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            if (this.dgvData.Rows.Count == 0)
                return;

            if (this.btnDept.Tag == null)
                return;

            frmListViewContainer form = new frmListViewContainer("設定「組別」優先選取條件", this.btnDept.Tag as List<dynamic>);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.btnDept.Tag = form.CheckLists;
                this.RefreshFilterBox();
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            if (this.dgvData.Rows.Count == 0)
                return;

            if (this.btnClass.Tag == null)
                return;

            frmListViewContainer form = new frmListViewContainer("設定「班級」優先選取條件", this.btnClass.Tag as List<dynamic>);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.btnClass.Tag = form.CheckLists;
                this.RefreshFilterBox();
            }
        }

        private void RefreshFilterBox()
        {
            this.txtFilter.Text = string.Empty;
            this.txtFilter.Tag = null;
            string FilterBoxText = string.Empty;
            List<dynamic> oSchoolYears = this.btnSchoolYear.Tag as List<dynamic>;
            List<dynamic> oDeptNames = this.btnDept.Tag as List<dynamic>;
            List<dynamic> oClassNames = this.btnClass.Tag as List<dynamic>;

            if (oSchoolYears.Where(x=>x.Checked == true).Count() > 0)
                FilterBoxText = "入學年度：";
            foreach (dynamic oo in oSchoolYears)
            {
                if (oo.Checked)
                    FilterBoxText += oo.Text + "、";
            }
            if (oSchoolYears.Where(x => x.Checked == true).Count() > 0)
            {
                FilterBoxText = FilterBoxText.Substring(0, FilterBoxText.Length - 1);
                FilterBoxText += "\r\n";
            }

            if (oDeptNames.Where(x => x.Checked == true).Count() > 0)
                FilterBoxText += "組別：";
            foreach (dynamic oo in oDeptNames)
            {
                if (oo.Checked)
                    FilterBoxText += oo.Text + "、";
            }
            if (oDeptNames.Where(x => x.Checked == true).Count() > 0)
            {
                FilterBoxText = FilterBoxText.Substring(0, FilterBoxText.Length - 1);
                FilterBoxText += "\r\n";
            }

            if (oClassNames.Where(x => x.Checked == true).Count() > 0)
                FilterBoxText += "班級：";
            foreach (dynamic oo in oClassNames)
            {
                if (oo.Checked)
                    FilterBoxText += oo.Text + "、";
            }
            if (FilterBoxText.EndsWith("、"))
            {
                FilterBoxText = FilterBoxText.Substring(0, FilterBoxText.Length - 1);
            }
            this.txtFilter.Text = FilterBoxText;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtFilter.Text = string.Empty;
            this.txtFilter.Tag = null;
            if (this.btnSchoolYear.Tag != null)
                (this.btnSchoolYear.Tag as List<dynamic>).ForEach(x => x.Checked = false);
            if (this.btnDept.Tag != null)
                (this.btnDept.Tag as List<dynamic>).ForEach(x => x.Checked = false);
            if (this.btnClass.Tag != null)
                (this.btnClass.Tag as List<dynamic>).ForEach(x => x.Checked = false);
        }

        private void btnManualFilter_Click(object sender, EventArgs e)
        {
            this.DisableButtons();

            List<UDT.CSAttend> CSAttend_Deleteds = new List<UDT.CSAttend>();
            List<UDT.CSAttendLog> CSAttendLogs = new List<UDT.CSAttendLog>();
            string CourseID = this.groupPanel1.Tag + "";
            List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0}", CourseID));
            Dictionary<int, UDT.CSAttend> dicCSAttends = new Dictionary<int, UDT.CSAttend>();
            if (CSAttends.Count > 0)
            {
                CSAttends.ForEach((x) =>
                {
                    if (!dicCSAttends.ContainsKey(x.StudentID))
                        dicCSAttends.Add(x.StudentID, x);
                });
            }

            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as DataItems.SemesterItem).Value;
            string error_message = string.Empty;
            List<DataGridViewRow> cantdeletes = new List<DataGridViewRow>();
            foreach(DataGridViewRow row in this.dgvData.SelectedRows)
            {
                int StudentID = int.Parse(row.Cells["lblStudentID"].Value + "");

                bool locked_evaluation = false;
                bool locked_condition = false;
                bool manual = false;
                bool period1 = false;
                if (bool.TryParse(row.Cells["colManual"].Value + "", out manual) && manual)
                    cantdeletes.Add(row);
                if (bool.TryParse(row.Cells["colPeriod1"].Value + "", out period1) && period1)
                    cantdeletes.Add(row);
                if (bool.TryParse(row.Cells["chkEvaluation"].Value + "", out locked_evaluation) && locked_evaluation)
                    cantdeletes.Add(row);
                if (bool.TryParse(row.Cells["chkLock"].Value + "", out locked_condition) && locked_condition)
                    cantdeletes.Add(row);

                cantdeletes = cantdeletes.Distinct().ToList();

                if (dicCSAttends.ContainsKey(StudentID))
                {
                    UDT.CSAttend CSAttend = dicCSAttends[StudentID];
                    UDT.CSAttendLog CSAttendLog = new UDT.CSAttendLog();
                    CSAttend.Deleted = true;

                    CSAttendLog.StudentID = StudentID;
                    CSAttendLog.CourseID = int.Parse(CourseID);
                    CSAttendLog.SchoolYear = int.Parse(school_year.ToString());
                    CSAttendLog.Semester = int.Parse(semester);
                    CSAttendLog.Item = this.item;
                    CSAttendLog.Action = "delete";
                    CSAttendLog.ActionBy = "staff";

                    CSAttendLogs.Add(CSAttendLog);
                    CSAttend_Deleteds.Add(CSAttend);
                }
            }
            if (cantdeletes.Count > 0)
            {
                error_message = "下列學生已勾選「優先」，確定手動篩汰學生？\n\n";
                foreach (DataGridViewRow row in cantdeletes)
                {
                    error_message += string.Format("學號「{0}」，姓名「{1}」。\n", row.Cells[3].Value + "", row.Cells[4].Value + "");
                }
                if (MessageBox.Show(error_message, "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.EnableButtons();
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("確定手動篩汰學生？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.EnableButtons();
                    return;
                }
            }
            CSAttend_Deleteds.SaveAll();
            CSAttendLogs.SaveAll();

            this.InitCSAttend(CourseID);
            if (this.chkShowLog.Checked)
                this.AppendCSAttendLog(CourseID);              

            this.EnableButtons();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string CourseID = this.groupPanel1.Tag + "";
            if (e.ColumnIndex < 0)
                return;
            if (this.dgvData.Columns[e.ColumnIndex] == null)
                return;

            if (e.RowIndex < 0 || this.dgvData.Columns[e.ColumnIndex].Name != "colManual" || string.IsNullOrEmpty(CourseID))
                return;

            if (this.dgvData.Rows[e.RowIndex] == null)
                return;

            if (this.dgvData.Rows[e.RowIndex].Cells["colManual"] == null)
                return;

            if (this.dgvData.Rows[e.RowIndex].Cells["chkLock"] == null)
                return;

            if (this.dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor == System.Drawing.Color.Pink)
                return;

            bool IsManual = false;
            bool IsCondition = false;

            bool.TryParse((this.dgvData.Rows[e.RowIndex].Cells["colManual"] as DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXCell).Value + "", out IsManual);
            bool.TryParse((this.dgvData.Rows[e.RowIndex].Cells["chkLock"] as DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXCell).Value + "", out IsCondition);

            (this.dgvData.Rows[e.RowIndex].Cells["colManual"] as DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXCell).Value = !IsManual;
            
            string StudentID = (this.dgvData.Rows[e.RowIndex].Cells["lblStudentID"]).Value + "";
            Task task = Task.Factory.StartNew(() =>
            {
                List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_course_id={0} and ref_student_id={1}", CourseID, StudentID));

                CSAttends.ForEach((x) => 
                {
                    x.IsManual = !IsManual;
                    x.IsCondition = IsCondition;
                });
                CSAttends.SaveAll();
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        //this.dgvData.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
        //    {
        //        DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();

        //        dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Window; 

        //        x.DefaultCellStyle = dataGridViewCellStyle;
        //    });

        //this.dgvData.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach((x) =>
        //    {
        //        DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();

        //        dataGridViewCellStyle.BackColor = System.Drawing.Color.Pink;

        //        x.DefaultCellStyle = dataGridViewCellStyle;
        //    });
    }
}