using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.UDT;
using FISCA.Data;
using DevComponents.Editors;
using System.Threading.Tasks;
using EMBA.Export;
using Aspose.Cells;

namespace CourseSelection.Export
{
    public partial class CSAttend : EMBA.Export.ExportProxyForm
    {
        private AccessHelper Access;
        private QueryHelper Query;

        private bool form_loaded;

        public CSAttend()
        {
            InitializeComponent();
            base.Text = "匯出資料至Excel-選上學生";
            base.TitleText = "匯出資料至Excel-選上學生";
            this.Text = "匯出資料至Excel-選上學生";
            this.TitleText = "匯出資料至Excel-選上學生";

            this.Access = new AccessHelper();
            this.Query = new QueryHelper();

            InitializeData();

            this.Load += new EventHandler(CSAttendResult_Load);
        }

        private void CSAttendResult_Load(object sender, EventArgs e)
        {
            form_loaded = false;

            Access = new AccessHelper();

            this.InitItem();
            this.InitSchoolYearAndSemester();

            this.ResolveField();
            form_loaded = true;
            base.TitleText = "匯出資料至Excel-選上學生";
            base.Text = "匯出資料至Excel-選上學生";
            this.Text = "匯出資料至Excel-選上學生";
            this.TitleText = "匯出資料至Excel-選上學生";
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

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            if (this.cboItem.SelectedIndex == -1)
                return;

            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            int item = -1;
            int.TryParse((combo_item).Tag + "", out item);
            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.QuerySQL = this.SetQueryString(school_year, semester, item);
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            if (this.cboItem.SelectedIndex == -1)
                return;

            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            int item = -1;
            int.TryParse((combo_item).Tag + "", out item);
            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.QuerySQL = this.SetQueryString(school_year, semester, item);
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboItem.SelectedIndex == -1)
                return;

            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            int item = -1;
            int.TryParse((combo_item).Tag + "", out item);
            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.QuerySQL = this.SetQueryString(school_year, semester, item);
        }

        private void InitializeData()
        {
            this.AutoSaveFile = false;
            this.AutoSaveLog = false;   //  Log 要用新的寫法
            this.KeyField = "學生系統編號";
            this.InvisibleFields = new List<string>() { "學生系統編號", "課程系統編號" };

            this.ReplaceFields = null;
            this.QuerySQL = SetQueryString(-1, -1, -1);
        }

        private string SetQueryString(int school_year, int semester, int item)
        {
            string querySQL = string.Format(@"select student.id as 學生系統編號, course.id as 課程系統編號, course.school_year as 學年度, course.semester as 學期, course.course_name as 開課, course.credit as 學分, '' as 授課教師, sb.grade_year as 年級, sb.enroll_year as 入學年度, dg.name as 組別, class.class_name as 班次, student.student_number as 學號, student.name as 學生姓名 from student
join $ischool.emba.cs_attend as ca on ca.ref_student_id=student.id
join course on course.id=ca.ref_course_id
left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id
left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id
left join class on class.id=student.ref_class_id
left join $ischool.emba.course_ext as ce on ce.ref_course_id=course.id where course.school_year={0} and course.semester={1} and ca.item={2} order by sb.grade_year, sb.enroll_year, dg.name, class.class_name, student.student_number", school_year, semester, item);

            return querySQL;
        }

        private Dictionary<string, string> GetCourseTeachers(DataTable dataTable)
        {
            Dictionary<string, string> dicCourseTeachers = new Dictionary<string, string>();

            if (dataTable.Rows.Count == 0)
                return dicCourseTeachers;

            DataTable dataTable_CourseTeachers = Query.Select(string.Format(@"select course.id as course_id, teacher.id, teacher.teacher_name from course left join $ischool.emba.course_instructor as ci on ci.ref_course_id = course.id left join teacher on teacher.id = ci.ref_teacher_id left join tag_teacher on tag_teacher.ref_teacher_id = teacher.id left join tag on tag.id = tag_teacher.ref_tag_id
where tag.category = 'Teacher' and tag.prefix = '教師' and course.id in ({0}) 
group by teacher.id, teacher.teacher_name, course.id
order by course.id", String.Join(",", dataTable.Rows.Cast<DataRow>().Select(x => x["課程系統編號"] + ""))));

            if (dataTable_CourseTeachers.Rows.Count == 0)
                return dicCourseTeachers;

            foreach (DataRow row in dataTable_CourseTeachers.Rows)
            {
                if (!dicCourseTeachers.ContainsKey(row["course_id"] + ""))
                    dicCourseTeachers.Add(row["course_id"] + "", row["teacher_name"] + "");
                else
                    dicCourseTeachers[row["course_id"] + ""] += ";" + row["teacher_name"] + "";
            }

            return dicCourseTeachers;
        }

        protected override void OnExportButtonClick(object sender, EventArgs e)
        {
            if (this.cboItem.SelectedIndex < 1)
            {
                MessageBox.Show("請選擇階段別。");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
                
            ComboItem combo_item = this.cboItem.SelectedItem as ComboItem;
            int item = -1;
            int.TryParse((combo_item).Tag + "", out item);

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
            
            this.btnExport.Enabled = false;
            this.circularProgress.IsRunning = true;
            this.circularProgress.Visible = true;
            Workbook wb = new Workbook();
            Task task = Task.Factory.StartNew(() =>
            {
                DataTable dataTable = Query.Select(this.QuerySQL);
                Dictionary<string, string> dicCourseTeachers = this.GetCourseTeachers(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["授課教師"] = (dicCourseTeachers.ContainsKey(row["課程系統編號"] + "") ? dicCourseTeachers[row["課程系統編號"] + ""] : "");
                }
                wb = dataTable.ToWorkbook(true, this.SelectedFields);
            });
            task.ContinueWith((x) =>
            {
                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    return;
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "另存新檔";
                sfd.FileName = school_year + "學年度" + DataItems.SemesterItem.GetSemesterByCode(semester.ToString()).Name + (item == 1 ? "第一階段" : "第二階段") + "選上學生名單.xls";
                sfd.Filter = "Excel 2003 相容檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
                DialogResult dr = sfd.ShowDialog();
                if (dr != System.Windows.Forms.DialogResult.OK)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

                try
                {
                    wb.Save(sfd.FileName);
                    if (System.IO.File.Exists(sfd.FileName))
                        System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "錯誤");
                }

            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
