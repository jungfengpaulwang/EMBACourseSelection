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
    public partial class CSNoConfirm : EMBA.Export.ExportProxyForm
    {
        private AccessHelper Access;
        private QueryHelper Query;

        private bool form_loaded;

        public CSNoConfirm()
        {
            InitializeComponent();

            base.TitleText = "匯出資料至Excel-未確認加退選學生";
            base.Text = "匯出資料至Excel-未確認加退選學生";
            this.Text = "匯出資料至Excel-未確認加退選學生";
            this.TitleText = "匯出資料至Excel-未確認加退選學生";

            this.Access = new AccessHelper();
            this.Query = new QueryHelper();

            InitializeData();

            this.Load += new EventHandler(CSAttendResult_Load);
        }

        private void CSAttendResult_Load(object sender, EventArgs e)
        {
            form_loaded = false;

            //base.OnLoad(e);
            Access = new AccessHelper();

            this.InitSchoolYearAndSemester();

            this.ResolveField();
            form_loaded = true;
            base.TitleText = "匯出資料至Excel-未確認加退選學生";
            base.Text = "匯出資料至Excel-未確認加退選學生";
            this.Text = "匯出資料至Excel-未確認加退選學生";
            this.TitleText = "匯出資料至Excel-未確認加退選學生";
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

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.QuerySQL = this.SetQueryString(school_year, semester);
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);

            this.QuerySQL = this.SetQueryString(school_year, semester);
        }

        private void InitializeData()
        {
            this.AutoSaveFile = false;
            this.AutoSaveLog = false;   //  Log 要用新的寫法
            this.KeyField = "學生系統編號";
            this.InvisibleFields = new List<string>() { "學生系統編號" };

            this.ReplaceFields = null;
            this.QuerySQL = SetQueryString(-1, -1);
        }

        private string SetQueryString(int school_year, int semester)
        {
            string querySQL = string.Format(@"select student.id as 學生系統編號, sb.grade_year as 年級, sb.enroll_year as 入學年度, dg.name as 組別, class_name as 教學分班, student_number as 學號,  student.name as 姓名,
(xpath_string('<root>' || sb.email_list || '</root>','email1')) as 電子郵件一, 
(xpath_string('<root>' || sb.email_list || '</root>','email2')) as 電子郵件二, 
(xpath_string('<root>' || sb.email_list || '</root>','email3')) as 電子郵件三, 
(xpath_string('<root>' || sb.email_list || '</root>','email4')) as 電子郵件四, 
(xpath_string('<root>' || sb.email_list || '</root>','email5')) as 電子郵件五,
student.permanent_phone as 戶籍電話, student.contact_phone as 聯絡電話, student.sms_phone as 行動電話1,
(xpath_string(student.other_phones,'PhoneNumber[2]')) as 行動電話2,
(xpath_string(student.other_phones,'PhoneNumber[1]')) as 公司電話,
(xpath_string(student.other_phones,'PhoneNumber[3]')) as 秘書電話
from student left join $ischool.emba.student_brief2 as sb on sb.ref_student_id=student.id 
left join $ischool.emba.department_group as dg on dg.uid=sb.ref_department_group_id 
left join class on class.id=student.ref_class_id 
where student.status in (1, 4) and student.id not in (select ref_student_id from $ischool.emba.registration_confirm as rc	where rc.school_year={0} and rc.semester={1} and rc.confirm=true) order by sb.grade_year, sb.enroll_year, dg.name, class.class_name, student.student_number", school_year, semester);

            return querySQL;
        }

        protected override void OnExportButtonClick(object sender, EventArgs e)
        {
            int school_year = int.Parse(this.nudSchoolYear.Value + "");
            int semester = int.Parse((this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value);
            
            this.btnExport.Enabled = false;
            this.circularProgress.IsRunning = true;
            this.circularProgress.Visible = true;
            Workbook wb = new Workbook();
            Task task = Task.Factory.StartNew(() =>
            {
                this.QuerySQL = this.SetQueryString(school_year, semester);
                DataTable dataTable = Query.Select(this.QuerySQL);
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
                sfd.FileName = school_year + "學年度" + DataItems.SemesterItem.GetSemesterByCode(semester.ToString()).Name + "未確認加退選學生名單.xls";
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
