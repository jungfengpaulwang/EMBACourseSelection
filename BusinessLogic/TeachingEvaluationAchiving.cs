using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using FISCA.Data;
using System.Data;
using System.Dynamic;

namespace CourseSelection.BusinessLogic
{
    public class TeachingEvaluationAchiving
    {
        private static readonly Lazy<TeachingEvaluationAchiving> LazyInstance = new Lazy<TeachingEvaluationAchiving>(() => new TeachingEvaluationAchiving());
        public static TeachingEvaluationAchiving Instance { get { return LazyInstance.Value; } }

        private AccessHelper Access;
        private QueryHelper Query;

        private Dictionary<string, decimal> dicAchiving;
        private Dictionary<string, List<dynamic>> dicAchievingRates;

        private TeachingEvaluationAchiving() 
        {
            Access = new AccessHelper();
            Query = new QueryHelper();

            List<UDT.AchievingRate> AchievingRates = Access.Select<UDT.AchievingRate>();
            dicAchiving = new Dictionary<string, decimal>();
            foreach (UDT.AchievingRate AchievingRate in AchievingRates)
            {
                string key = AchievingRate.SchoolYear + "-" + AchievingRate.Semester;
                if (!dicAchiving.ContainsKey(key))
                    dicAchiving.Add(key, AchievingRate.Rate);
            }

            dicAchievingRates = new Dictionary<string, List<dynamic>>();

            string SQL = string.Format(@"select aCount.school_year, aCount.semester, aCount.id as course_id, aCount.course_name, aCount.survey_count, rCount.answer_count, aCount.ref_student_id from 
    (select course.school_year, course.semester, course.id, course.course_name, count(asurvey.ref_teacher_id) as survey_count, min(end_time) as end_time, se.ref_student_id from $ischool.emba.scattend_ext as se join course on course.id=se.ref_course_id join $ischool.emba.teaching_evaluation.assigned_survey as asurvey on asurvey.ref_course_id=course.id
	where se.is_cancel=false group by course.school_year, course.semester, course.id, course.course_name, se.ref_student_id) as aCount left join 
(select course.school_year, course.semester, course.id, course.course_name, count(reply.ref_teacher_id) as answer_count,  reply.ref_student_id from $ischool.emba.teaching_evaluation.reply as reply join course on course.id=reply.ref_course_id
where status=1 group by course.school_year, course.semester, course.id, course.course_name, reply.ref_student_id) as rCount on aCount.id=rCount.id and aCount.ref_student_id=rCount.ref_student_id 
order by aCount.ref_student_id, aCount.school_year, aCount.semester, course_id");
            DataTable dataTable = Query.Select(SQL);

            foreach (DataRow row in dataTable.Rows)
            {
                string key = row["school_year"] + "-" + row["semester"] + "-" + row["ref_student_id"];

                if (!dicAchievingRates.ContainsKey(key))
                    dicAchievingRates.Add(key, new List<dynamic>());

                dynamic o = new ExpandoObject();

                o.CourseID = row["course_id"] + "";
                o.CourseName = row["course_name"] + "";
                o.SurveyCount = row["survey_count"] + "";
                o.AnswerCount = row["answer_count"] + "";

                dicAchievingRates[key].Add(o);
            }
        }

        private static decimal? GetAchievingRate(int SchoolYear, int Semester)
        {
            string key = SchoolYear + "-" + Semester;

            if (TeachingEvaluationAchiving.Instance.dicAchiving.ContainsKey(key))
                return TeachingEvaluationAchiving.Instance.dicAchiving[key];
            else
                return null;
        }

        public static bool IsAchieving(int SchoolYear, int Semester, string StudentID)
        {
            string key = SchoolYear + "-" + Semester + "-" + StudentID;
            if (!TeachingEvaluationAchiving.Instance.dicAchievingRates.ContainsKey(key))
                return false;

            List<dynamic> AchievingRates = TeachingEvaluationAchiving.Instance.dicAchievingRates[key];
            decimal SumofSurveyCount = 0;
            decimal SumofAnswerCount = 0;
            foreach (dynamic o in AchievingRates)
            {
                decimal SurveyCount = 0;
                decimal AnswerCount = 0;

                decimal.TryParse(o.SurveyCount, out SurveyCount);
                decimal.TryParse(o.AnswerCount, out AnswerCount);

                if (SurveyCount != 0 && AnswerCount == 0)
                    return false;

                SumofSurveyCount += SurveyCount;
                SumofAnswerCount += AnswerCount;
            }
            if (SumofSurveyCount == 0)
                return false;

            decimal achievingRate = Math.Ceiling(SumofAnswerCount * 100 / SumofSurveyCount);
            decimal? _AchievingRate = TeachingEvaluationAchiving.GetAchievingRate(SchoolYear, Semester);

            if (!_AchievingRate.HasValue)
                return false;

            return achievingRate >= _AchievingRate.Value;
        }
    }
}