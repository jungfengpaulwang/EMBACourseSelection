using System;
using FISCA.UDT;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 選課歷史記錄
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.cs_attend_log")]
    public class CSAttendLog : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSAttendLog.AfterUpdate != null)
        //        CSAttendLog.AfterUpdate(sender, e);
        //}

        //internal static event EventHandler<ParameterEventArgs> AfterUpdate;

        /// <summary>
        /// 課程系統編號
        /// </summary>
        [Field(Field = "ref_course_id", Indexed = true, Caption = "課程系統編號")]
        public int CourseID { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = true, Caption = "學生系統編號")]
        public int StudentID { get; set; }

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
        /// 階段別-->1：第一階段、2：第2階段
        /// </summary>
        [Field(Field = "item", Indexed = true, Caption = "階段別")]
        public int Item { get; set; }

        /// <summary>
        /// 行為-->insert；delete
        /// </summary>
        [Field(Field = "action", Indexed = false, Caption = "行為")]
        public string Action { get; set; }

        /// <summary>
        /// 行為人-->web：student(學生選課、退選)；desktop：staff(行政人員篩汰學生)
        /// </summary>
        [Field(Field = "action_by", Indexed = false, Caption = "行為人")]
        public string ActionBy { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public CSAttendLog Clone()
        {
            return (this.MemberwiseClone() as CSAttendLog);
        }
    }
}