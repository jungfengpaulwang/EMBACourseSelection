using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.UDT;
using K12.Data;
using Aspose.Cells;

namespace CourseSelection.Forms
{
    public partial class Form1 : Form
    {
        private AccessHelper ah = new AccessHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            List<UDT.CSAttend> CSAttends = ah.Select<UDT.CSAttend>("school_year =102 and semester=1");
            List<UDT.ConflictCourse> ConflictCourses = ah.Select<UDT.ConflictCourse>();
            Dictionary<int, List<UDT.CSAttend>> dicCSAttends = new Dictionary<int, List<UDT.CSAttend>>();
            Dictionary<string, KeyValuePair<string, string>> dicConflictCourses = new Dictionary<string, KeyValuePair<string, string>>();
            Dictionary<int, List<KeyValuePair<string, string>>> dicChongTongStudents = new Dictionary<int, List<KeyValuePair<string, string>>>();
            List<StudentRecord> Students = Student.SelectAll();
            Dictionary<int, StudentRecord> dicStudents = Students.ToDictionary(x=>int.Parse(x.ID));
            List<CourseRecord> Courses = Course.SelectAll();
            Dictionary<int, CourseRecord> dicCourses = Courses.ToDictionary(x=>int.Parse(x.ID));

            CSAttends.ForEach((x) =>
            {
                if (!dicCSAttends.ContainsKey(x.StudentID))
                    dicCSAttends.Add(x.StudentID, new List<UDT.CSAttend>());

                dicCSAttends[x.StudentID].Add(x);
            });
            ConflictCourses.ForEach((x) =>
            {
                if (!dicConflictCourses.ContainsKey(x.CourseID_A + "-" + x.CourseID_B))
                    dicConflictCourses.Add(x.CourseID_A + "-" + x.CourseID_B, new KeyValuePair<string, string>(x.CourseName_A, x.CourseName_B));
            });

            foreach (int student_id in dicCSAttends.Keys)
            {
                List<UDT.CSAttend> iCSAttends = dicCSAttends[student_id];
                foreach(UDT.CSAttend x in iCSAttends)
                {
                    foreach (UDT.CSAttend y in iCSAttends)
                    {
                        if (x.CourseID == y.CourseID)
                            continue;

                        if (dicConflictCourses.ContainsKey(x.CourseID + "-" + y.CourseID))
                        {
                            if (!dicChongTongStudents.ContainsKey(x.StudentID))
                                dicChongTongStudents.Add(x.StudentID, new List<KeyValuePair<string, string>>());

                            dicChongTongStudents[x.StudentID].Add(new KeyValuePair<string, string>(dicCourses[x.CourseID].Name, dicCourses[y.CourseID].Name));
                        }
                    }
                }
            }
            Workbook wb = new Workbook();
            wb.Worksheets.Add();
            int idx = 0;
            foreach (int student_id in dicChongTongStudents.Keys)
            {
                foreach (KeyValuePair<string, string> kv in dicChongTongStudents[student_id])
                {
                    idx++;
                    wb.Worksheets[0].Cells[idx, 0].PutValue(student_id);
                    wb.Worksheets[0].Cells[idx, 1].PutValue(kv.Key);
                    wb.Worksheets[0].Cells[idx, 2].PutValue(kv.Value);
                }
            } 
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 檔案|*.xls;";
            sd.FileName = wb.Worksheets[0].Name;
            sd.AddExtension = true;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    wb.Save(sd.FileName);
                    System.Diagnostics.Process.Start(sd.FileName);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show(ex.Message);
                }
            }
        }
    }
}
