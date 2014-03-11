using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using DevComponents.Editors;
using FISCA.Data;
using System.Threading.Tasks;

namespace CourseSelection.Forms
{
    public partial class frmAttendNoChange : BaseForm
    {
        private AccessHelper Access;
        private QueryHelper Query;

        private DataTable dataTable_Confirmed;
        private DataTable dataTable_NonConfirmed;

        private bool form_loaded;

        public frmAttendNoChange()
        {
            InitializeComponent();

            dataTable_Confirmed = new DataTable();
            dataTable_NonConfirmed = new DataTable();

            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);
            this.dgvDataNonConfirm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDataNonConfirm_MouseClick);
            this.dgvDataNonConfirm.CurrentCellDirtyStateChanged += new EventHandler(dgvDataNonConfirm_CurrentCellDirtyStateChanged);
            this.dgvDataNonConfirm.CellEnter += new DataGridViewCellEventHandler(dgvDataNonConfirm_CellEnter);
            this.dgvData.SortCompare += new DataGridViewSortCompareEventHandler(DataGridView_SortCompare);
            this.dgvDataNonConfirm.SortCompare += new DataGridViewSortCompareEventHandler(DataGridView_SortCompare);


            this.Load += new EventHandler(frmAttendNoneCourse_Load);
        }

        private void DataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "confirm_date" || e.Column.Name == "print_date_2" || e.Column.Name == "received_date_2")
            {
                DateTime date_time_1 = new DateTime(1, 1, 1);
                DateTime date_time_2 = new DateTime(1, 1, 1);

                DateTime.TryParse(e.CellValue1 + "", out date_time_1);
                DateTime.TryParse(e.CellValue2 + "", out date_time_2);
                e.SortResult = System.DateTime.Compare(date_time_1, date_time_2);
            }
            else
                e.SortResult = System.String.Compare(e.CellValue1 + "", e.CellValue2 + "");
            e.Handled = true;
        }

        private void dgvDataNonConfirm_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDataNonConfirm.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvDataNonConfirm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                dgvDataNonConfirm.BeginEdit(true);
            }
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvData.SelectAll();
            }
        }

        private void dgvDataNonConfirm_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                dgvDataNonConfirm.SelectAll();
            }
        }

        private void frmAttendNoneCourse_Load(object sender, EventArgs e)
        {
            form_loaded = false;

            Access = new AccessHelper();
            Query = new QueryHelper();

            this.InitSchoolYearAndSemester();

            form_loaded = true;
            this.DGV_DataBinding();
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

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.DGV_DataBinding();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.DGV_DataBinding();
        }

        private void DGV_DataBinding(string search_string = "")
        {
            if (!this.form_loaded)
                return;

            this.dgvData.Rows.Clear();
            this.dgvDataNonConfirm.Rows.Clear();

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            Task task = Task.Factory.StartNew(() =>
            {
                if (!string.IsNullOrWhiteSpace(search_string))
                    return;

                #region  已確認學生
                dataTable_Confirmed = Query.Select(string.Format(@"select student.id as student_id, sb.grade_year, sb.enroll_year, dg.name as dept_name, dg.uid as dept_id, class.id as class_id, class_name, student_number, student.name as student_name, confirm_date, print_date, received_date from student join $ischool.emba.registration_confirm as ca on ca.ref_student_id=student.id left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id  left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id left join class on class.id=student.ref_class_id where ca.confirm=true and ca.school_year={0} and ca.semester={1} order by sb.grade_year, sb.enroll_year, dg.name, class_name, student_number", school_year, semester));
                #endregion

                #region 未確認學生
                dataTable_NonConfirmed = Query.Select(string.Format(@"select table_a.student_id, table_a.grade_year, table_a.enroll_year, table_a.name, table_a.dept_name, table_a.dept_id, table_a.class_id, table_a.class_name, table_a.student_number, table_a.student_name, table_b.print_date, table_b.received_date from
(select student.id as student_id, sb.grade_year, sb.enroll_year, dg.name as dept_name, dg.uid as dept_id, class.id as class_id, class_name, student_number,  student.name as student_name from student 
left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id 
left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id 
left join class on class.id=student.ref_class_id where student.status in (1, 4)) as table_a
left join (select ref_student_id as student_id, print_date, received_date from $ischool.emba.registration_confirm as ca where ca.school_year={0} and ca.semester={1} and ca.confirm=false) as table_b
on table_a.student_id = table_b.student_id where table_a.student_id not in (select ref_student_id from $ischool.emba.registration_confirm as ca where ca.school_year={0} and ca.semester={1} and ca.confirm=true)", school_year, semester));
                #endregion
            });

            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    goto TheEnd;
                }
                foreach (DataRow row in dataTable_Confirmed.Rows)
                {
                    if (!(string.IsNullOrWhiteSpace(search_string) || search_string == "!@#$%^&*()_+"))
                    {
                        if (!(row["student_number"] + "").ToLower().Contains(search_string.ToLower()) && !(row["student_name"] + "").ToLower().Contains(search_string.ToLower()))
                            continue;
                    }
                    List<object> source = new List<object>();

                    source.Add(row["grade_year"] + "");
                    source.Add(row["enroll_year"] + "");
                    source.Add(row["dept_name"] + "");
                    source.Add(row["class_name"] + "");
                    source.Add(row["student_number"] + "");
                    source.Add(row["student_name"] + "");
                    DateTime date = DateTime.Now;
                    if (DateTime.TryParse(row["confirm_date"] + "", out date))
                        source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                    else
                        source.Add(string.Empty);
                    source.Add(false);

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                    this.dgvData.Rows[idx].Tag = row["student_id"] + "";
                }

                foreach (DataRow row in dataTable_NonConfirmed.Rows)
                {
                    if (!(string.IsNullOrWhiteSpace(search_string) || search_string == "!@#$%^&*()_+"))
                    {
                        if (!(row["student_number"] + "").ToLower().Contains(search_string.ToLower()) && !(row["student_name"] + "").ToLower().Contains(search_string.ToLower()))
                            continue;
                    }
                    List<object> source = new List<object>();

                    source.Add(row["grade_year"] + "");
                    source.Add(row["enroll_year"] + "");
                    source.Add(row["dept_name"] + "");
                    source.Add(row["class_name"] + "");
                    source.Add(row["student_number"] + "");
                    source.Add(row["student_name"] + "");
                    DateTime date = DateTime.Now;
                    if (DateTime.TryParse(row["print_date"] + "", out date))
                        source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                    else
                        source.Add(string.Empty);
                    if (DateTime.TryParse(row["received_date"] + "", out date))
                        source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                    else
                        source.Add(string.Empty);
                    if (DateTime.TryParse(row["received_date"] + "", out date))
                        source.Add(true);
                    else
                        source.Add(false);
                    int idx = this.dgvDataNonConfirm.Rows.Add(source.ToArray());
                    this.dgvDataNonConfirm.Rows[idx].Tag = row["student_id"] + "";
                    if (DateTime.TryParse(row["received_date"] + "", out date))
                        this.dgvDataNonConfirm.Rows[idx].Cells[7].Tag = date;
                    else
                        this.dgvDataNonConfirm.Rows[idx].Cells[7].Tag = null;
                }
            TheEnd:
                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
                this.dgvData.CurrentCell = null;
                this.dgvDataNonConfirm.CurrentCell = null;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool is_checked()
        {
            bool isChecked = true;

            DateTime date;
            foreach (DataGridViewRow row in this.dgvDataNonConfirm.Rows)
            {
                if (string.IsNullOrWhiteSpace(row.Cells[7].Value + ""))
                {
                    row.Cells[7].ErrorText = "";
                    continue;
                }

                if (DateTime.TryParse(row.Cells[7].Value + "", out date))
                    row.Cells[7].ErrorText = "";
                else
                {
                    row.Cells[7].ErrorText = "請輸入正確的日期格式，範例：2013/8/28 14:56";
                    isChecked = false;
                }
            }
            return isChecked;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.tabItem1.IsSelected)
            {
                int school_year = int.Parse(this.nudSchoolYear.Value + "");
                int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
                List<string> SelectedStudentIDs = new List<string>();
                StringBuilder sb = new StringBuilder("下列學生加退選之確認將被註銷，確定嗎？\n\n");
                foreach (DataGridViewRow row in this.dgvData.Rows)
                {
                    bool bChecked = false;
                    if (bool.TryParse(row.Cells[7].Value + "", out bChecked) && bChecked)
                    {
                        SelectedStudentIDs.Add(row.Tag + "");
                        sb.Append("班次：" + row.Cells[3].Value + "；學號：" + row.Cells[4].Value + "；姓名：" + row.Cells[5].Value + "。" + "\n");
                    }
                }

                if (SelectedStudentIDs.Count == 0)
                {
                    MessageBox.Show("請先勾選「註銷」(可複選)。", "提示");
                    return;
                }
                else
                {
                    if (MessageBox.Show(sb.ToString(), "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    List<UDT.RegistrationConfirm> RC = Access.Select<UDT.RegistrationConfirm>(string.Format("ref_student_id in ({0}) and school_year={1} and semester={2}", string.Join(",", SelectedStudentIDs.Select(x => x)), school_year, semester));
                    RC.ForEach((x) => x.Confirm = false);
                    RC.SaveAll();
                }
            }
            if (this.tabItem2.IsSelected)
            {
                if (!this.is_checked())
                {
                    MessageBox.Show("請先修正錯誤再儲存。");
                    return;
                }
                int school_year = int.Parse(this.nudSchoolYear.Value + "");
                int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
                List<string> ReceivedStudentIDs = new List<string>();
                StringBuilder sb = new StringBuilder("下列學生之「收到加退選單日期」將被更新，確定嗎？\n\n");
                DateTime now = DateTime.Now;
                Dictionary<string, KeyValuePair<string, object>> dicReceivedDates = new Dictionary<string, KeyValuePair<string, object>>();
                foreach (DataGridViewRow row in this.dgvDataNonConfirm.Rows)
                {
                    bool bChecked = false;
                    DateTime a1;
                    DateTime a2;
                    if ((bool.TryParse(row.Cells[8].Value + "", out bChecked) && bChecked && (row.Cells[7].Tag == null)) || (row.Cells[7].Tag != null && string.IsNullOrWhiteSpace(row.Cells[7].Value + "")) || (DateTime.TryParse(row.Cells[7].Tag + "", out a1) && DateTime.TryParse((row.Cells[7].Value + "").Trim(), out a2) && a1.ToString("HH:mm") != a2.ToString("HH:mm")))
                    {
                        ReceivedStudentIDs.Add(row.Tag + "");
                        dicReceivedDates.Add(row.Tag + "", new KeyValuePair<string, object>(row.Cells[7].Value + "", row.Cells[7].Tag));
                        sb.Append("班次：" + row.Cells[3].Value + "；學號：" + row.Cells[4].Value + "；姓名：" + row.Cells[5].Value + "。" + "\n");
                    }
                }

                if (ReceivedStudentIDs.Count == 0)
                {
                    MessageBox.Show("請先勾選「收到加退選單」(可複選)。", "提示");
                    return;
                }
                else
                {
                    if (MessageBox.Show(sb.ToString(), "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    List<UDT.RegistrationConfirm> RCs = Access.Select<UDT.RegistrationConfirm>(string.Format("ref_student_id in ({0}) and school_year={1} and semester={2}", string.Join(",", ReceivedStudentIDs.Select(x => x)), school_year, semester));
                    foreach(string key in dicReceivedDates.Keys)
                    {
                        if (RCs.Where(x=>x.StudentID.ToString() == key).Count() == 0)
                        {
                            UDT.RegistrationConfirm RC = new UDT.RegistrationConfirm();

                            RC.StudentID = int.Parse(key);
                            RC.SchoolYear = school_year;
                            RC.Semester = semester;

                            RCs.Add(RC);
                        }
                    }
                    RCs.ForEach((x) =>
                    {
                        DateTime date;
                        KeyValuePair<string, object> kv = dicReceivedDates[x.StudentID.ToString()];
                        if (kv.Value != null && string.IsNullOrWhiteSpace(kv.Key))
                            x.ReceivedDate = null;
                        if (kv.Value != null && DateTime.TryParse(kv.Key.Trim(), out date) && (kv.Value.ToString() != kv.Key.Trim()))
                            x.ReceivedDate = date;
                        if (kv.Value == null && string.IsNullOrWhiteSpace(kv.Key))
                            x.ReceivedDate = now;

                        RCs.SaveAll();
                    });
                }
            }

            this.DGV_DataBinding();
        }

        private void txtSNum_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSNum.Text))
                this.Search("!@#$%^&*()_+");
            else
                this.Search(this.txtSNum.Text);
        }

        private void Search(string search_string)
        {
            this.dgvData.Rows.Clear();
            this.dgvDataNonConfirm.Rows.Clear();

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;

            foreach (DataRow row in dataTable_Confirmed.Rows)
            {
                if (!(string.IsNullOrWhiteSpace(search_string) || search_string == "!@#$%^&*()_+"))
                {
                    if (!(row["student_number"] + "").ToLower().Contains(search_string.ToLower()) && !(row["student_name"] + "").ToLower().Contains(search_string.ToLower()))
                    continue;
                }
                List<object> source = new List<object>();

                source.Add(row["grade_year"] + "");
                source.Add(row["enroll_year"] + "");
                source.Add(row["dept_name"] + "");
                source.Add(row["class_name"] + "");
                source.Add(row["student_number"] + "");
                source.Add(row["student_name"] + "");
                DateTime date = DateTime.Now;
                if (DateTime.TryParse(row["confirm_date"] + "", out date))
                    source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                else
                    source.Add(string.Empty);
                source.Add(false);

                int idx = this.dgvData.Rows.Add(source.ToArray());
                this.dgvData.Rows[idx].Tag = row["student_id"] + "";
            }

            foreach (DataRow row in dataTable_NonConfirmed.Rows)
            {
                if (!(string.IsNullOrWhiteSpace(search_string) || search_string == "!@#$%^&*()_+"))
                {
                    if (!(row["student_number"] + "").ToLower().Contains(search_string.ToLower()) && !(row["student_name"] + "").ToLower().Contains(search_string.ToLower()))
                        continue;
                }
                List<object> source = new List<object>();

                source.Add(row["grade_year"] + "");
                source.Add(row["enroll_year"] + "");
                source.Add(row["dept_name"] + "");
                source.Add(row["class_name"] + "");
                source.Add(row["student_number"] + "");
                source.Add(row["student_name"] + "");
                DateTime date = DateTime.Now;
                if (DateTime.TryParse(row["print_date"] + "", out date))
                    source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                else
                    source.Add(string.Empty);
                if (DateTime.TryParse(row["received_date"] + "", out date))
                    source.Add(date.ToString("yyyy/MM/dd HH:mm"));
                else
                    source.Add(string.Empty);
                if (DateTime.TryParse(row["received_date"] + "", out date))
                    source.Add(true);
                else
                    source.Add(false);
                int idx = this.dgvDataNonConfirm.Rows.Add(source.ToArray());
                this.dgvDataNonConfirm.Rows[idx].Tag = row["student_id"] + "";
                if (DateTime.TryParse(row["received_date"] + "", out date))
                    this.dgvDataNonConfirm.Rows[idx].Cells[7].Tag = date;
                else
                    this.dgvDataNonConfirm.Rows[idx].Cells[7].Tag = null;
            }
            this.circularProgress.IsRunning = false;
            this.circularProgress.Visible = false;
            this.dgvData.CurrentCell = null;
            this.dgvDataNonConfirm.CurrentCell = null;
        }

        private void dgvDataNonConfirm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 9)
            //    return;

            //if (e.RowIndex == -1)
            //    return;

            //bool bChecked = false;
            //if (bool.TryParse(this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[9].Value + "", out bChecked) && bChecked)
            //    this.dgvDataNonConfirm.Rows[e.RowIndex].Selected = true;
            //else
            //{
            //    if (string.IsNullOrEmpty(this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[7].Value + ""))
            //        this.dgvDataNonConfirm.Rows[e.RowIndex].Selected = false;
            //    else
            //    {
            //        StringBuilder sb = new StringBuilder("「班次：" + this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[3].Value + "；學號：" + this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[4].Value + "；姓名：" + this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[5].Value + "」之收到加退選單日期將被移除，確定嗎？");
            //        if (MessageBox.Show(sb.ToString(), "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            //            return;
            //        int school_year = int.Parse(this.nudSchoolYear.Value + "");
            //        int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
            //        List<UDT.RegistrationConfirm> RC = Access.Select<UDT.RegistrationConfirm>(string.Format("ref_student_id = ({0}) and school_year={1} and semester={2}", this.dgvDataNonConfirm.Rows[e.RowIndex].Tag + "", school_year, semester));
            //        RC.ForEach((x) => x.ReceivedDate = null);
            //        RC.SaveAll();
            //        this.dgvDataNonConfirm.Rows[e.RowIndex].Cells[7].Value = string.Empty;
            //    }
            //}
        }
    }
}