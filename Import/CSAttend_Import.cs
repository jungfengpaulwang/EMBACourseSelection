using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using EMBA.DocumentValidator;
using EMBA.Import;
using EMBA.Validator;
using FISCA.Data;
using FISCA.UDT;
using K12.Data;
using K12.Data.Configuration;
using System;
using System.Text;

namespace CourseSelection.Import
{
    class CSAttend_Import : ImportWizard
    {
        ImportOption mOption;
        AccessHelper Access;
        QueryHelper queryHelper;
        Dictionary<string, CourseRecord> dicCourses;
        Dictionary<string, StudentRecord> dicStudents;
        Dictionary<string, UDT.CSAttend> dicCSAttends;

        public CSAttend_Import()
        {
            this.IsSplit = false;
            this.ShowAdvancedForm = false;
            this.ValidateRuleFormater = XDocument.Parse(Properties.Resources.format);
            //this.CustomValidate = null;
            //this.SplitThreadCount = 5;
            //this.SplitSize = 3000;

            Access = new AccessHelper();
            queryHelper = new QueryHelper();
            this.dicCourses = new Dictionary<string, CourseRecord>();
            this.dicStudents = new Dictionary<string, StudentRecord>();
            this.dicCSAttends = new Dictionary<string, UDT.CSAttend>();
            
            this.CustomValidate = (Rows, Messages) =>
            {
                CustomValidator(Rows, Messages);
            };
        }

        public void CustomValidator(List<IRowStream> Rows, RowMessages Messages)
        {
            #  region 驗證流程

            List<StudentRecord> Students = Student.SelectAll();
            if (Students.Count > 0)
            {
                Students.ForEach((x) =>
                {
                    if (!dicStudents.ContainsKey(x.StudentNumber.Trim().ToLower()))
                        dicStudents.Add(x.StudentNumber.Trim().ToLower(), x);
                });
            }
            List<CourseRecord> Courses = Course.SelectAll();
            if (Courses.Count > 0)
            {
                Courses.ForEach((x) =>
                {
                    string key = x.SchoolYear + "-" + x.Semester + "-" + x.Name.Trim().ToLower();
                    if (!dicCourses.ContainsKey(key))
                        dicCourses.Add(key, x);
                });
            }
            //  學生修課
            List<UDT.CSAttend> CSAttends = Access.Select<UDT.CSAttend>();
            Dictionary<string, int> dicCSAttendsSingleStudent = new Dictionary<string, int>();
            if (CSAttends.Count > 0)
            {
                CSAttends.ForEach((x) =>
                {
                    string key = x.CourseID + "-" + x.StudentID;
                    if (!dicCSAttends.ContainsKey(key))
                        dicCSAttends.Add(key, x);
                });
            }
            //  衝堂課程
            List<UDT.ConflictCourse> ConflictCourses = Access.Select<UDT.ConflictCourse>();
            Dictionary<string, KeyValuePair<int, int>> dicConflictCourses = new Dictionary<string, KeyValuePair<int, int>>();
            foreach (UDT.ConflictCourse x in ConflictCourses)
            {
                if (!dicConflictCourses.ContainsKey(x.SchoolYear + "-" + x.Semester + "-" + x.CourseID_A + "-" + x.CourseID_B))
                    dicConflictCourses.Add(x.SchoolYear + "-" + x.Semester + "-" + x.CourseID_A + "-" + x.CourseID_B, new KeyValuePair<int, int>(x.CourseID_A, x.CourseID_B));
            }
            Rows.ForEach((x) =>
            {
                string key = x.GetValue("學年度") + "-" + x.GetValue("學期") + "-" + x.GetValue("開課").Trim().ToLower();
                string student_number = x.GetValue("學號").Trim().ToLower();
                //  「開課」必須存在於系統中
                if (!dicCourses.ContainsKey(key))
                {
                    Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "系統無此開課。"));
                }
                //  「學號」必須存在於系統中
                if (!dicStudents.ContainsKey(student_number))
                {
                    Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Error, EMBA.Validator.ValidatorType.Row, "系統無此學號。"));
                }
                //  「選課結果」已存在於系統中，則以「警告」的方式處理，不被匯入
                if (dicCourses.ContainsKey(key) && dicStudents.ContainsKey(student_number))
                {
                    if (this.dicCSAttends.ContainsKey(dicCourses[key].ID + "-" + dicStudents[student_number].ID))
                    {
                        Messages[x.Position].MessageItems.Add(new MessageItem(EMBA.Validator.ErrorType.Warning, EMBA.Validator.ValidatorType.Row, "學生已選本課程，此記錄不被匯入。"));
                    }
                }
            });

            #endregion
        }

        public override XDocument GetValidateRule()
        {
            return XDocument.Parse(Properties.Resources.CSAttend_Import);
        }

        public override ImportAction GetSupportActions()
        {
            return ImportAction.Insert;
        }

        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
        }

        public override string Import(List<IRowStream> Rows)
        {
            List<UDT.CSAttend> CSAttends = new List<UDT.CSAttend>();
            List<UDT.CSAttendLog> CSAttendLogs = new List<UDT.CSAttendLog>();
            foreach (IRowStream row in Rows)
            {
                string student_number = row.GetValue("學號").Trim().ToLower();
                string course_name = row.GetValue("開課").Trim().ToLower();
                string school_year = row.GetValue("學年度").Trim();
                string semester = row.GetValue("學期").Trim();
                string item = row.GetValue("階段別").Trim();

                string key = dicCourses[school_year + "-" + semester + "-" + course_name].ID + "-" + dicStudents[student_number].ID;

                if (dicCSAttends.ContainsKey(key))
                    continue;

                UDT.CSAttend CSAttend = new UDT.CSAttend();

                CSAttend.CourseID = int.Parse(this.dicCourses[school_year + "-" + semester + "-" + course_name].ID);
                CSAttend.StudentID = int.Parse(this.dicStudents[student_number].ID);
                CSAttend.SchoolYear = int.Parse(school_year);
                CSAttend.Semester = int.Parse(semester);
                CSAttend.Item = int.Parse(item);
                CSAttend.Manually = true;

                CSAttends.Add(CSAttend);

                UDT.CSAttendLog CSAttendLog = new UDT.CSAttendLog();

                CSAttendLog.CourseID = int.Parse(this.dicCourses[school_year + "-" + semester + "-" + course_name].ID);
                CSAttendLog.StudentID = int.Parse(this.dicStudents[student_number].ID);
                CSAttendLog.SchoolYear = int.Parse(school_year);
                CSAttendLog.Semester = int.Parse(semester);
                CSAttendLog.Item = int.Parse(item);
                CSAttendLog.Action = "insert";
                CSAttendLog.ActionBy = "staff";

                CSAttendLogs.Add(CSAttendLog);
            }
            CSAttends.SaveAll();
            CSAttendLogs.SaveAll();

            return string.Empty;
        }
    }
}
