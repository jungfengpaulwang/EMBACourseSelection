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

namespace CourseSelection.Forms
{
    public partial class frmCSAttendManual : BaseForm
    {
        private QueryHelper queryHelper;
        private AccessHelper Access;

        private string CourseID;
        private int SchoolYear;
        private int Semester;
        private int item;

        public frmCSAttendManual(string course_id, int school_year, int semester, int item)
        {
            this.CourseID = course_id;
            this.SchoolYear = school_year;
            this.Semester = semester;
            this.item = item;

            queryHelper = new QueryHelper();
            Access = new AccessHelper();

            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = queryHelper.Select(string.Format("select class_name, student.name as student_name, student.id as id, student_number from student left join class on class.id=student.ref_class_id where student.status in (1, 4) and student_number ilike ('{0}')", this.txtStudentNumber.Text.Trim()));

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("查無此人。");
                    return;
                }
                else
                {
                    List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>(string.Format("ref_student_id={0} and ref_course_id={1}", dataTable.Rows[0]["id"] + "", CourseID));

                    if (CSAttends.Count > 0)
                    {
                        MessageBox.Show(string.Format("已加入學生「班級：{0}，學號：{1}，姓名：{2}」。", dataTable.Rows[0]["class_name"] + "", dataTable.Rows[0]["student_number"] + "", dataTable.Rows[0]["student_name"] + ""));
                        return;
                    }
                    UDT.CSAttend CSAttend = new UDT.CSAttend();
                    UDT.CSAttendLog CSAttendLog = new UDT.CSAttendLog();

                    CSAttend.CourseID = int.Parse(CourseID);
                    CSAttend.StudentID = int.Parse(dataTable.Rows[0]["id"] + "");
                    CSAttend.SchoolYear = this.SchoolYear;
                    CSAttend.Semester = this.Semester;
                    CSAttend.Item = this.item;
                    CSAttend.Manually = true;
                    CSAttend.IsManual = true;

                    CSAttendLog.CourseID = int.Parse(CourseID);
                    CSAttendLog.StudentID = int.Parse(dataTable.Rows[0]["id"] + "");
                    CSAttendLog.SchoolYear = this.SchoolYear;
                    CSAttendLog.Semester = this.Semester;
                    CSAttendLog.Action = "insert_manually";
                    CSAttendLog.ActionBy = "staff";
                    CSAttendLog.Item = this.item;

                    CSAttend.Save();
                    CSAttendLog.Save();
                    Event.DeliverCSAttendEventArgs ee = new Event.DeliverCSAttendEventArgs(new List<UDT.CSAttend> { CSAttend });
                    Event.DeliverActiveRecord.RaiseSendingEvent(this, ee);
                    MessageBox.Show(string.Format("已加入學生「班級：{0}，學號：{1}，姓名：{2}」", dataTable.Rows[0]["class_name"] + "", dataTable.Rows[0]["student_number"] + "", dataTable.Rows[0]["student_name"] + ""));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
