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
    public partial class frmCSAttendToSnapshot : BaseForm
    {
        private List<dynamic> ItemRowSource = new List<dynamic>();
        private QueryHelper Query;
        private AccessHelper Access;

        private int SchoolYear;
        private int Semester;

        public frmCSAttendToSnapshot()
        {
            InitializeComponent();

            Query = new QueryHelper();
            Access = new AccessHelper();

            this.Load += new EventHandler(frmCSAttendToSnapshot_Load);
        }

        private void frmCSAttendToSnapshot_Load(object sender, EventArgs e)
        {
            this.circularProgress.IsRunning = false;
            this.circularProgress.Visible = false;
            this.Save.Enabled = false;

            this.ItemRowSource.Clear();

            this.ItemRowSource.Add(new { Name = "", ID = -1 });
            this.ItemRowSource.Add(new { Name = "第一階段", ID = 1 });
            this.ItemRowSource.Add(new { Name = "第二階段", ID = 2 });

            this.cboItem.DataSource = this.ItemRowSource;

            this.cboItem.ValueMember = "ID";
            this.cboItem.DisplayMember = "Name";

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
            try
            {
                if (this.cboItem.SelectedIndex < 1)
                {
                    MessageBox.Show("請選擇階段別。");
                    return;
                }
                if (MessageBox.Show("確定備份？若您選擇「確定」，原有資料將被覆蓋。若不確定，請按「取消」。", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                this.circularProgress.IsRunning = true;
                this.circularProgress.Visible = true;
                int item = int.Parse(this.cboItem.SelectedValue + "");
                Task task = Task.Factory.StartNew(() =>
                {
                    List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("school_year = {0} and semester = {1}", this.SchoolYear, this.Semester));
                    List<UDT.CSAttendSnapshot> CSAttendSnapshots = Access.Select<UDT.CSAttendSnapshot>(string.Format("school_year = {0} and semester = {1} and item = {2}", this.SchoolYear, this.Semester, item));
                    if (CSAttends.Count == 0)
                        throw new Exception("無資料可備份。");
                    CSAttendSnapshots.ForEach(x => x.Deleted = true);
                    CSAttendSnapshots.SaveAll();
                    CSAttendSnapshots.Clear();
                    CSAttends.ForEach((x) =>
                    {
                        UDT.CSAttendSnapshot CSAttendSnapshot = new UDT.CSAttendSnapshot();

                        CSAttendSnapshot.CourseID = x.CourseID;
                        CSAttendSnapshot.StudentID = x.StudentID;
                        CSAttendSnapshot.Item = item;
                        CSAttendSnapshot.SchoolYear = x.SchoolYear;
                        CSAttendSnapshot.Semester = x.Semester;

                        CSAttendSnapshots.Add(CSAttendSnapshot);
                    });
                    CSAttendSnapshots.SaveAll();
                });
                task.ContinueWith((x) =>
                {
                    this.circularProgress.IsRunning = false;
                    this.circularProgress.Visible = false;

                    if (x.Exception != null)
                        MessageBox.Show(x.Exception.InnerException.Message);
                    else
                        MessageBox.Show("備份完成。");
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