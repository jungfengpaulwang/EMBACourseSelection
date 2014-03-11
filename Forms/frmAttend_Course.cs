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
    public partial class frmAttend_Course : BaseForm
    {
        private AccessHelper Access;
        private QueryHelper Query;

        private bool form_loaded;

        public frmAttend_Course()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmAttend_Course_Load);
        }

        private void frmAttend_Course_Load(object sender, EventArgs e)
        {
            form_loaded = false;

            Access = new AccessHelper();
            Query = new QueryHelper();

            this.InitItem();
            this.InitSchoolYearAndSemester();

            form_loaded = true;

            InitCourse();
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

        private void InitCourse()
        {
            if (!this.form_loaded)
                return;

            this.cboCourse.Items.Clear();

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
            List<K12.Data.CourseRecord> SelectedCourses = K12.Data.Course.SelectBySchoolYearAndSemester(school_year, semester);

            if (SelectedCourses.Count == 0)
                return;

            ComboItem comboItem1 = new ComboItem("");
            comboItem1.Tag = null;
            this.cboCourse.Items.Add(comboItem1);

            //  所有課程
            foreach (K12.Data.CourseRecord course in SelectedCourses)
            {
                ComboItem item = new ComboItem(course.Name);
                item.Tag = course.ID;
                this.cboCourse.Items.Add(item);
            }

            this.cboCourse.SelectedItem = comboItem1;
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

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.InitCourse();
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.InitCourse();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DGV_DataBinding();
        }

        private void DGV_DataBinding()
        {
            this.dgvData_Attend.Rows.Clear();
            this.dgvData_Log.Rows.Clear();

            if (this.cboCourse.SelectedIndex < 1)
                return;

            if (this.cboItem.SelectedIndex < 1)
                return;

            ComboItem combo_course = this.cboCourse.SelectedItem as ComboItem;
            if (combo_course.Tag == null)
                return;
            int CourseID = int.Parse((combo_course).Tag + "");

            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            if (combo_item.Tag == null)
                return;
            int item = int.Parse((combo_item).Tag + "");

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            DataTable dataTable_Attend = new DataTable();
            DataTable dataTable_AttendLog = new DataTable();
            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            Task task = Task.Factory.StartNew(()=>
            {
                #region  選上學生
                dataTable_Attend = Query.Select(string.Format(@"select student.id as student_id, sb.grade_year, sb.enroll_year, dg.name as dept_name, dg.uid as dept_id, class.id as class_id, class_name, student_number, 
    student.name as student_name from student
    join $ischool.emba.cs_attend as ca on ca.ref_student_id=student.id
    join course on course.id=ca.ref_course_id
    left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id
    left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id
    left join class on class.id=student.ref_class_id where course.id={0} {1} order by sb.grade_year, sb.enroll_year, dg.name, class_name, student_number", CourseID, (item == 1 ? " and ca.item=1" : "")));
                #endregion

                #region 未選上學生
                dataTable_AttendLog = Query.Select(string.Format(@"select student.id as student_id, sb.grade_year, sb.enroll_year, dg.name as dept_name, dg.uid as dept_id, class.id as class_id, class_name, student_number, student.name as student_name from student
left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id
left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id
left join class on class.id=student.ref_class_id 
left join $ischool.emba.cs_attend_log as cl on cl.ref_student_id = student.id
left join course on course.id=cl.ref_course_id
where student.id in 
(
select ref_student_id from $ischool.emba.cs_attend_log
where action='delete' and action_by='staff' and ref_course_id = {3} and school_year={0} and semester={1} {2}
) 
and  student.id not in 
(
select ref_student_id from $ischool.emba.cs_attend where school_year={0} and ref_course_id = {3} and semester={1} {2}
)
and student.id in 
(
select ref_student_id from $ischool.emba.cs_attend_log
where action='insert' and action_by='student' and ref_course_id = {3} and school_year={0} and semester={1} {2} 
) 
and course.id={3} and cl.action='delete' and cl.action_by='staff' {2} 
order by sb.grade_year, sb.enroll_year, dg.name, class_name, student_number", school_year, semester, (item == 1 ? " and item=1" : ""), CourseID));
                #endregion
            });

            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    this.circularProgress.IsRunning = false;
                    this.circularProgress.Visible = false;
                    return;
                }
                foreach (DataRow row in dataTable_Attend.Rows)
                {
                    List<object> source = new List<object>();

                    source.Add(row["grade_year"] + "");
                    source.Add(row["enroll_year"] + "");
                    source.Add(row["dept_name"] + "");
                    source.Add(row["class_name"] + "");
                    source.Add(row["student_number"] + "");
                    source.Add(row["student_name"] + "");

                    int idx = this.dgvData_Attend.Rows.Add(source.ToArray());
                    this.dgvData_Attend.Rows[idx].Tag = row;
                }

                foreach (DataRow row in dataTable_AttendLog.Rows)
                {
                    List<object> source = new List<object>();

                    source.Add(row["grade_year"] + "");
                    source.Add(row["enroll_year"] + "");
                    source.Add(row["dept_name"] + "");
                    source.Add(row["class_name"] + "");
                    source.Add(row["student_number"] + "");
                    source.Add(row["student_name"] + "");

                    int idx = this.dgvData_Log.Rows.Add(source.ToArray());
                    this.dgvData_Log.Rows[idx].Tag = row;
                }
                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DGV_DataBinding();
        }
    }
}
