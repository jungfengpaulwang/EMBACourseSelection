using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Threading.Tasks;
using FISCA.Data;
using Aspose.Cells;
using FISCA.UDT;
using System.Dynamic;

namespace CourseSelection.Forms
{
    public partial class ConflictCourseManagement : BaseForm
    {
        private List<dynamic> CourseRowSource;
        private List<dynamic> DateRowSource;
        private DataTable dataTableCourseTimeTable;
        private AccessHelper Access;
        private List<UDT.ConflictCourse> conflict_courses;

        private bool form_loaded;

        public ConflictCourseManagement()
        {
            InitializeComponent();

            this.Access = new AccessHelper();
            conflict_courses = new List<UDT.ConflictCourse>();
            CourseRowSource = new List<dynamic>();
            DateRowSource = new List<dynamic>();
            this.Load += new EventHandler(ConflictCourseManagement_Load);
        }

        private void ConflictCourseManagement_Load(object sender, EventArgs e)
        {
            this.form_loaded = false;

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            this.Check.Enabled = false;
            this.Export.Enabled = false;
            this.cboCourse.Enabled = false;
            this.cboDate.Enabled = false;
            this.InitSchoolYearAndSemester();
            int SchoolYear = int.Parse(this.nudSchoolYear.Value.ToString());
            int Semester = int.Parse(this.cboSemester.SelectedValue + "");
            Task task = Task.Factory.StartNew(() =>
            {
                conflict_courses = this.InitConflictCourse(SchoolYear, Semester);
            });
            task.ContinueWith((x)=>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    goto TheEnd;
                }
                this.InitDataGridView(conflict_courses.ToList());
                this.InitCourseRowSource(conflict_courses);
                this.InitDateRowSource(conflict_courses);

                TheEnd:
                this.form_loaded = true;
                this.circularProgress.Visible = false;
                this.circularProgress.IsRunning = false;
                this.Check.Enabled = true;
                this.Export.Enabled = true;
                this.cboCourse.Enabled = true;
                this.cboDate.Enabled = true;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
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

        private List<UDT.ConflictCourse> InitConflictCourse(int school_year, int semester)
        {
            List<UDT.ConflictCourse> conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));
            return conflict_courses;
        }

        //  衝堂課程資料來源
        private void InitCourseRowSource(List<UDT.ConflictCourse> conflict_courses)
        {
            CourseRowSource.Clear();

            CourseRowSource.Add(new { Name = "全部", ID = 0 });
            List<int> CourseIDs = new List<int>();
            conflict_courses.ForEach((x) =>
            {
                if (!CourseIDs.Contains(x.CourseID_A))
                {
                    CourseIDs.Add(x.CourseID_A);
                    CourseRowSource.Add(new { Name = x.CourseName_A, ID = x.CourseID_A });
                }
            });

            this.cboCourse.DataSource = this.CourseRowSource;
            this.cboCourse.ValueMember = "ID";
            this.cboCourse.DisplayMember = "Name";
        }

        //  衝堂日期資料來源
        private void InitDateRowSource(List<UDT.ConflictCourse> conflict_courses)
        {
            DateRowSource.Clear();

            DateRowSource.Add(new { Name = "全部", ID = "" });
            List<string> CDates = new List<string>(); 
            conflict_courses.OrderBy(x=>DateTime.Parse(string.IsNullOrEmpty(x.ConflictDate) ? "1911/1/1" : x.ConflictDate)).ToList().ForEach((x) =>
            {
                if (!CDates.Contains(x.ConflictDate))
                {
                    CDates.Add(x.ConflictDate);
                    DateRowSource.Add(new { Name = x.ConflictDate, ID = x.ConflictDate });
                }
            });

            this.cboDate.DataSource = this.DateRowSource;
            this.cboDate.ValueMember = "ID";
            this.cboDate.DisplayMember = "Name";
        }

        private void InitDataGridView(List<UDT.ConflictCourse> conflict_courses)
        {
            this.dgvData.Rows.Clear();
            conflict_courses.OrderBy(x=>!x.IsSameSubject).ThenBy(x => x.CourseID_A).ThenBy(x => x.CourseID_B).ThenBy(x => DateTime.Parse(string.IsNullOrEmpty(x.ConflictDate) ? "1911/1/1" : x.ConflictDate)).ThenBy(x => x.ConflictWeek).ThenBy(x => x.ConflictTime).ToList().ForEach((x) =>
            {
                List<object> source = new List<object>();

                source.Add(x.CourseName_A);
                source.Add(x.CourseName_B);
                source.Add(x.ConflictDate);
                source.Add(x.ConflictWeek);
                source.Add(x.ConflictTime);
                source.Add(x.IsSameSubject);

                int idx = this.dgvData.Rows.Add(source.ToArray());
            });
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Workbook wb = new Workbook();
            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;
            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            Task task = Task.Factory.StartNew(() =>
            {
                //List<UDT.ConflictCourse> conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));

                if (conflict_courses.Count == 0)
                    throw new Exception("無資料可匯出。");

                wb.Worksheets[0].Name = conflict_courses.ElementAt(0).SchoolYear + "學年度" + CourseSelection.DataItems.SemesterItem.GetSemesterByCode(conflict_courses.ElementAt(0).Semester.ToString()) + "衝堂課程";
                wb.Worksheets[0].Cells[0, 0].PutValue("課程A");
                wb.Worksheets[0].Cells[0, 1].PutValue("課程B");
                wb.Worksheets[0].Cells[0, 2].PutValue("日期");
                wb.Worksheets[0].Cells[0, 3].PutValue("星期");
                wb.Worksheets[0].Cells[0, 4].PutValue("時間");
                wb.Worksheets[0].Cells[0, 5].PutValue("重複課程");
                int i = 1;
                conflict_courses.ForEach((x) =>
                {
                    wb.Worksheets[0].Cells[i, 0].PutValue(x.CourseName_A);
                    wb.Worksheets[0].Cells[i, 1].PutValue(x.CourseName_B);
                    wb.Worksheets[0].Cells[i, 2].PutValue(x.ConflictDate);
                    wb.Worksheets[0].Cells[i, 3].PutValue(x.ConflictWeek);
                    wb.Worksheets[0].Cells[i, 4].PutValue(x.ConflictTime);
                    wb.Worksheets[0].Cells[i, 5].PutValue(x.IsSameSubject ? "是" : string.Empty);

                    i++;
                });

                wb.Worksheets[0].AutoFitColumns();                
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
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        //public DataTable GetContentAsDataTable(bool IgnoreHideColumns = false)
        //{
        //    try
        //    {
        //        if (this.dgvData.ColumnCount == 0) return null;
        //        DataTable dtSource = new DataTable();
        //        foreach (DataGridViewColumn col in this.dgvData.Columns)
        //        {
        //            if (IgnoreHideColumns & !col.Visible) continue;
        //            if (col.Name == string.Empty) continue;
        //            dtSource.Columns.Add(col.Name);
        //            dtSource.Columns[col.Name].Caption = col.HeaderText;
        //        }
        //        if (dtSource.Columns.Count == 0) return null;
        //        foreach (DataGridViewRow row in this.dgvData.Rows)
        //        {
        //            DataRow drNewRow = dtSource.NewRow();
        //            foreach (DataColumn col in dtSource.Columns)
        //            {
        //                drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
        //            }
        //            dtSource.Rows.Add(drNewRow);
        //        }
        //        return dtSource;
        //    }
        //    catch { return null; }
        //}

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCourse.SelectedIndex == -1)
                return;
            if (!this.form_loaded)
                return;
            string CDate = (this.cboDate.SelectedItem == null ? string.Empty : (this.cboDate.SelectedItem as dynamic).ID);
            int CourseID = (this.cboCourse.SelectedItem == null ? 0 : (this.cboCourse.SelectedItem as dynamic).ID);
            string CourseName = this.cboCourse.Text;

            if (CourseName == "全部")
            {
                this.InitDataGridView(this.conflict_courses);
                return;
            }

            //decimal school_year = this.nudSchoolYear.Value;
            //string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;

            List<UDT.ConflictCourse> filter_conflict_courses = new List<UDT.ConflictCourse>();

            ////  所有課程、所有日期
            //if (string.IsNullOrEmpty(CDate) && CourseID == 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));

            ////  單一課程、所有日期
            //if (string.IsNullOrEmpty(CDate) && CourseID > 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and ref_course_id_a={2}", school_year, semester, CourseID));

            ////  所有課程、單一日期
            //if (!string.IsNullOrEmpty(CDate) && CourseID == 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and conflict_date='{2}'", school_year, semester, CDate));

            ////  單一課程、單一日期
            //if (!string.IsNullOrEmpty(CDate) && CourseID > 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and ref_course_id_a={2} and conflict_date='{3}'", school_year, semester, CourseID, CDate));

            foreach (UDT.ConflictCourse conflictCourse in this.conflict_courses)
            {
                if (conflictCourse.CourseID_A == CourseID)
                {
                    filter_conflict_courses.Add(conflictCourse);
                }
            }

            this.InitDataGridView(filter_conflict_courses);
        }

        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboDate.SelectedIndex == -1)
                return;
            if (!this.form_loaded)
                return;

            //string CDate = (this.cboDate.SelectedItem == null ? string.Empty : (this.cboDate.SelectedItem as dynamic).ID);
            string CDate = this.cboDate.Text;
            if (CDate == "全部")
            {
                this.InitDataGridView(this.conflict_courses);
                return;
            }

            //decimal school_year = this.nudSchoolYear.Value;
            //string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;

            List<UDT.ConflictCourse> filter_conflict_courses = new List<UDT.ConflictCourse>();

            ////  所有課程、所有日期
            //if (string.IsNullOrEmpty(CDate) && CourseID == 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));

            ////  單一課程、所有日期
            //if (string.IsNullOrEmpty(CDate) && CourseID > 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and ref_course_id_a={2}", school_year, semester, CourseID));

            ////  所有課程、單一日期
            //if (!string.IsNullOrEmpty(CDate) && CourseID == 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and conflict_date='{2}'", school_year, semester, CDate));

            ////  單一課程、單一日期
            //if (!string.IsNullOrEmpty(CDate) && CourseID > 0)
            //    conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1} and ref_course_id_a={2} and conflict_date='{3}'", school_year, semester, CourseID, CDate));

            foreach (UDT.ConflictCourse conflictCourse in this.conflict_courses)
            {
                if (conflictCourse.ConflictDate == CDate)
                {
                    filter_conflict_courses.Add(conflictCourse);
                }
            }

            this.InitDataGridView(filter_conflict_courses);
        }

        private void WriteChongTongCourse(decimal school_year, string semester, List<CourseSection> CourseSections)
        {
            if (CourseSections.Count == 0)
                return;

            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            List<UDT.ConflictCourse> conflict_courses = new List<UDT.ConflictCourse>();
            Dictionary<int, Dictionary<string, List<CourseSection>>> dicCourseSections = new Dictionary<int, Dictionary<string, List<CourseSection>>>();
            Dictionary<int, CourseSection> dicCourseIDs = new Dictionary<int, CourseSection>();
            CourseSections.ForEach((x) =>
            {
                if (!dicCourseIDs.ContainsKey(x.CourseID))
                    dicCourseIDs.Add(x.CourseID, x);
            });
            CourseSections.ForEach((x) =>
            {
                if (!dicCourseSections.ContainsKey(x.CourseID))
                    dicCourseSections.Add(x.CourseID, new Dictionary<string,List<CourseSection>>());

                if (!dicCourseSections[x.CourseID].ContainsKey(x.BeginTime.ToShortDateString()))
                    dicCourseSections[x.CourseID].Add(x.BeginTime.ToShortDateString(), new List<CourseSection>());

                dicCourseSections[x.CourseID][x.BeginTime.ToShortDateString()].Add(x);
            });
            foreach (int CourseID in dicCourseSections.Keys)
            {
                foreach (string date in dicCourseSections[CourseID].Keys)
                {
                    CourseSection A = dicCourseIDs[CourseID];
                    Dictionary<int, List<CourseSection>> dicBs = new Dictionary<int, List<CourseSection>>();
                    foreach (CourseSection x in dicCourseSections[CourseID][date])
                    {
                        List<CourseSection> ChongTongCourseSections = CourseSections.Where(y => (y.SubjectID != x.SubjectID && y.CourseID != x.CourseID && x.BeginTime.ToShortDateString() == y.BeginTime.ToShortDateString())).Where(y => ((x.BeginTime <= y.BeginTime && x.EndTime >= y.EndTime) || (x.BeginTime >= y.BeginTime && x.BeginTime <= y.EndTime) || (x.EndTime >= y.BeginTime && x.EndTime <= y.EndTime))).ToList();

                        foreach (CourseSection cs in ChongTongCourseSections)
                        {
                            if (!dicBs.ContainsKey(cs.CourseID))
                                dicBs.Add(cs.CourseID, new List<CourseSection>());

                            dicBs[cs.CourseID].Add(cs);
                        }
                    }
                    foreach (int course_id in dicBs.Keys)
                    {
                        UDT.ConflictCourse conflict_course = new UDT.ConflictCourse();

                        CourseSection B = dicBs[course_id].ElementAt(0);

                        DateTime begin_time = DateTime.MaxValue;
                        DateTime end_time = DateTime.MinValue;

                        if (dicBs[course_id].Min(y => y.BeginTime) < begin_time)
                            begin_time = dicBs[course_id].Min(y => y.BeginTime);
                        if (dicBs[course_id].Max(y => y.EndTime) > end_time)
                            end_time = dicBs[course_id].Max(y => y.EndTime);

                        //if (A.CourseID != 649)
                        //    continue;

                        conflict_course.SchoolYear = A.SchoolYear;
                        conflict_course.Semester = A.Semester;
                        conflict_course.CourseID_A = A.CourseID;
                        conflict_course.CourseName_A = A.CourseName;
                        conflict_course.CourseID_B = B.CourseID;
                        conflict_course.CourseName_B = B.CourseName;
                        conflict_course.ConflictDate = date;
                        conflict_course.ConflictWeek = Day[Convert.ToInt16(DateTime.Parse(date).DayOfWeek)];
                        conflict_course.IsSameSubject = false;
                        conflict_course.ConflictTime = begin_time.ToString("HH:mm") + "~" + end_time.ToString("HH:mm");

                        conflict_courses.Add(conflict_course);
                    }
                }
            }
            conflict_courses.SaveAll();
        }

        private void WriteDuplicateCourse(decimal school_year, string semester, List<CourseSection> CourseSections)
        {
            List<KeyValuePair<CourseSection, CourseSection>> ChongTongCourseSections = new List<KeyValuePair<CourseSection, CourseSection>>();
            List<int> CourseIDs = new List<int>();
            CourseSections.ForEach((x) =>
            {
                if (!CourseIDs.Contains(x.CourseID))
                {
                    List<CourseSection> SameSubjectSections = CourseSections.Where(y => (y.SubjectID == x.SubjectID && y.CourseID != x.CourseID)).GroupBy(y => y.CourseID).Select(y => y.First()).ToList();
                    SameSubjectSections.ForEach((y) =>
                    {
                        ChongTongCourseSections.Add(new KeyValuePair<CourseSection, CourseSection>(x, y));
                    });
                    CourseIDs.Add(x.CourseID);
                }
            });
            List<UDT.ConflictCourse> conflict_courses = new List<UDT.ConflictCourse>();
            ChongTongCourseSections.ForEach((x) =>
            {
                UDT.ConflictCourse conflict_course = new UDT.ConflictCourse();

                conflict_course.SchoolYear = x.Key.SchoolYear;
                conflict_course.Semester = x.Key.Semester;
                conflict_course.CourseID_A = x.Key.CourseID;
                conflict_course.CourseID_B = x.Value.CourseID;
                conflict_course.CourseName_A = x.Key.CourseName;
                conflict_course.CourseName_B = x.Value.CourseName;
                conflict_course.ConflictDate = string.Empty;
                conflict_course.ConflictWeek = string.Empty;
                conflict_course.ConflictTime = string.Empty;
                conflict_course.IsSameSubject = true;

                conflict_courses.Add(conflict_course);
            });
            conflict_courses.SaveAll();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            this.Check.Enabled = false;
            this.Export.Enabled = false;
            this.cboCourse.Enabled = false;
            this.cboDate.Enabled = false;
            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;
            List<KeyValuePair<CourseSection, CourseSection>> ChongTongCourseSections = new List<KeyValuePair<CourseSection,CourseSection>>();
            Task<List<UDT.ConflictCourse>> task = Task<List<UDT.ConflictCourse>>.Factory.StartNew(() =>
            {
                string strQryCourseTimeTable = string.Format(@"select course.id as course_id, course.course_name as course_name, section.starttime, section.endtime, course.school_year, course.semester, name, ce.ref_subject_id as subject_id from course left join $ischool.course_calendar.section as section on CAST(section.refcourseid AS integer)=course.id left join $ischool.emba.course_ext as ce on ce.ref_course_id=course.id left join $ischool.emba.subject as subject on subject.uid=ce.ref_subject_id where course.school_year in ({0}) and course.semester={1} and removed=false order by course.id, section.starttime", school_year, semester);
                dataTableCourseTimeTable = (new QueryHelper()).Select(strQryCourseTimeTable);
                List<CourseSection> CourseSections = new List<CourseSection>();
                foreach (DataRow row in dataTableCourseTimeTable.Rows)
                {
                    CourseSection course_section = new CourseSection();

                    course_section.CourseID = int.Parse(row["course_id"] + "");
                    course_section.CourseName = row["course_name"] + "";
                    course_section.BeginTime = DateTime.Parse(row["starttime"] + "");
                    course_section.EndTime = DateTime.Parse(row["endtime"] + "");
                    course_section.SchoolYear = int.Parse(row["school_year"] + "");
                    course_section.Semester = int.Parse(row["semester"] + "");
                    course_section.SubjectName = row["name"] + "";
                    course_section.SubjectID = int.Parse(row["subject_id"] + "");

                    CourseSections.Add(course_section);
                } 
                List<UDT.ConflictCourse> conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));
                conflict_courses.ForEach(x => x.Deleted = true);
                conflict_courses.SaveAll();
                this.WriteDuplicateCourse(school_year, semester, CourseSections);
                this.WriteChongTongCourse(school_year, semester, CourseSections); 
                conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));
                return conflict_courses;
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    goto TheEnd;
                }
                this.conflict_courses = x.Result;
                this.InitCourseRowSource(this.conflict_courses);
                this.InitDateRowSource(this.conflict_courses);
                this.InitDataGridView(this.conflict_courses);
                TheEnd:
                this.circularProgress.Visible = false;
                this.circularProgress.IsRunning = false;
                this.Check.Enabled = true;
                this.Export.Enabled = true;
                this.cboCourse.Enabled = true;
                this.cboDate.Enabled = true;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void nudSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;
            Task<List<UDT.ConflictCourse>> task = Task<List<UDT.ConflictCourse>>.Factory.StartNew(() =>
            {
                List<UDT.ConflictCourse> conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));

                return conflict_courses;
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
                this.conflict_courses = x.Result;
                this.InitCourseRowSource(this.conflict_courses);
                this.InitDateRowSource(this.conflict_courses);
                this.InitDataGridView(this.conflict_courses);
                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.form_loaded)
                return;

            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            decimal school_year = this.nudSchoolYear.Value;
            string semester = (this.cboSemester.SelectedItem as CourseSelection.DataItems.SemesterItem).Value;
            Task<List<UDT.ConflictCourse>> task = Task<List<UDT.ConflictCourse>>.Factory.StartNew(() =>
            {
                List<UDT.ConflictCourse> conflict_courses = Access.Select<UDT.ConflictCourse>(string.Format("school_year={0} and semester={1}", school_year, semester));

                return conflict_courses;
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
                this.conflict_courses = x.Result;
                this.InitCourseRowSource(this.conflict_courses);
                this.InitDateRowSource(this.conflict_courses);
                this.InitDataGridView(this.conflict_courses);
                this.circularProgress.Visible = false;
                this.circularProgress.IsRunning = false;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

    public class CourseSection
    {
        public CourseSection() {}

        public int CourseID { get; set; }
        public int SchoolYear { get; set; }
        public int Semester { get; set; }
        public string CourseName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SubjectName { get; set; }
        public bool IsSameSubject { get; set; }
        public int SubjectID { get; set; }
    }
}
