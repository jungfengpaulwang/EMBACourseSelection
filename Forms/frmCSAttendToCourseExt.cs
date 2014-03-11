using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Data;
using FISCA.UDT;
using System.Threading.Tasks;

namespace CourseSelection.Forms
{
    public partial class frmCSAttendToCourseExt : BaseForm
    {
        private QueryHelper Query;
        private AccessHelper Access;

        private int SchoolYear;
        private int Semester;

        public frmCSAttendToCourseExt()
        {
            InitializeComponent();

            Query = new QueryHelper();
            Access = new AccessHelper();

            this.Load += new EventHandler(frmCSAttendToCourseExt_Load);
        }

        private void frmCSAttendToCourseExt_Load(object sender, EventArgs e)
        {
            this.circularProgress.IsRunning = false;
            this.circularProgress.Visible = false;
            this.Save.Enabled = false;

            this.InitSemesterInfo();
        }

        private void InitSemesterInfo()
        {
            DataTable dataTable_Server_Time = Query.Select("select now()");
            DateTime server_time = DateTime.Parse(dataTable_Server_Time.Rows[0][0] + "");

            List<UDT.CSOpeningInfo> opening_infos = Access.Select<UDT.CSOpeningInfo>();
            if (opening_infos.Count > 0)
            {
                int school_year = opening_infos.ElementAt(0).SchoolYear;
                int semester = opening_infos.ElementAt(0).Semester;
                this.SchoolYear = school_year;
                this.Semester = semester;

                this.lblSemesterInfo.Text = school_year + "學年度" + DataItems.SemesterItem.GetSemesterByCode(semester.ToString()).Name;
                this.Save.Enabled = true;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定發佈？若您選擇「確定」，「選課結果」將加入至「學生修課」。若不確定，請按「取消」。", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                return;
            this.circularProgress.IsRunning = true;
            this.circularProgress.Visible = true;
            int item = 2;
            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    List<UDT.CSAttendSnapshot> CSAttendSnapshots = Access.Select<UDT.CSAttendSnapshot>(string.Format("school_year = {0} and semester = {1} and item = {2}", this.SchoolYear, this.Semester, item));
                    if (CSAttendSnapshots.Count == 0)
                        throw new Exception("無資料可發佈。");

                    List<UDT.SCAttendExt> SCAttendExts = new List<UDT.SCAttendExt>();
                    DataTable dataTable = Query.Select(string.Format("select se.uid, se.ref_student_id, se.ref_course_id, se.report_group, se.is_cancel, se.seat_x, se.seat_y from $ischool.emba.scattend_ext as se join course on course.id=se.ref_course_id where course.school_year={0} and course.semester={1}", this.SchoolYear, this.Semester));
                    List<string> oSCAttendExts = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string key = row["ref_student_id"] + "-" + row["ref_course_id"];
                        oSCAttendExts.Add(key);
                    }
                    Dictionary<string, UDT.CSAttendSnapshot> dicCSAttendSnapshots = new Dictionary<string, UDT.CSAttendSnapshot>();
                    foreach(UDT.CSAttendSnapshot CSAttendSnapshot in CSAttendSnapshots)
                    {
                        string key = CSAttendSnapshot.StudentID + "-" + CSAttendSnapshot.CourseID;

                        if (!oSCAttendExts.Contains(key))
                        {
                            UDT.SCAttendExt SCAttendExt = new UDT.SCAttendExt();

                            SCAttendExt.CourseID = CSAttendSnapshot.CourseID;
                            SCAttendExt.StudentID = CSAttendSnapshot.StudentID;

                            SCAttendExts.Add(SCAttendExt);
                        }
                    }
                    SCAttendExts.SaveAll();
                });
                task.ContinueWith((x) =>
                {
                    this.circularProgress.IsRunning = false;
                    this.circularProgress.Visible = false;

                    if (x.Exception != null)
                        MessageBox.Show(x.Exception.InnerException.Message);
                    else
                        MessageBox.Show("發佈完成。");
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
