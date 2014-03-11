using System;
using FISCA.UDT;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 衝堂課程資訊
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.conflict_course")]
    public class ConflictCourse : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSOpeningInfo.AfterUpdate != null)
        //        CSOpeningInfo.AfterUpdate(sender, e);
        //}

        //internal static event EventHandler<ParameterEventArgs> AfterUpdate;

        /// <summary>
        /// 學年度
        /// </summary>
        [Field(Field = "school_year", Indexed = true, Caption = "學年度")]
        public int SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        [Field(Field = "semester", Indexed = true, Caption = "學期")]
        public int Semester { get; set; }

        /// <summary>
        /// 課程A系統編號
        /// </summary>
        [Field(Field = "ref_course_id_a", Indexed = true, Caption = "課程A系統編號")]
        public int CourseID_A { get; set; }

        /// <summary>
        /// 課程B系統編號
        /// </summary>
        [Field(Field = "ref_course_id_b", Indexed = true, Caption = "課程B系統編號")]
        public int CourseID_B { get; set; }

        /// <summary>
        /// 課程A名稱
        /// </summary>
        [Field(Field = "course_name_a", Indexed = false, Caption = "課程A名稱")]
        public string CourseName_A { get; set; }

        /// <summary>
        /// 課程B名稱
        /// </summary>
        [Field(Field = "course_name_b", Indexed = false, Caption = "課程B名稱")]
        public string CourseName_B { get; set; }

        /// <summary>
        /// 衝堂日期
        /// </summary>
        [Field(Field = "conflict_date", Indexed = false, Caption = "衝堂日期")]
        public string ConflictDate { get; set; }

        /// <summary>
        /// 衝堂星期
        /// </summary>
        [Field(Field = "conflict_week", Indexed = false, Caption = "衝堂星期")]
        public string ConflictWeek { get; set; }

        /// <summary>
        /// 衝堂時間
        /// </summary>
        [Field(Field = "conflict_time", Indexed = false, Caption = "衝堂時間")]
        public string ConflictTime { get; set; }

        /// <summary>
        /// 是否為不同時段之相同課程
        /// </summary>
        [Field(Field = "is_same_subject", Indexed = false, Caption = "是否為不同時段之相同課程")]
        public bool IsSameSubject { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public ConflictCourse Clone()
        {
            return (this.MemberwiseClone() as ConflictCourse);
        }
    }
}