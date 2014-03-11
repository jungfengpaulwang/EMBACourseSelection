using System;
using FISCA.UDT;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 選課記錄
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.cs_attend")]
    public class CSAttend : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSAttend.AfterUpdate != null)
        //        CSAttend.AfterUpdate(sender, e);
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
        /// 是否為手動加入
        /// </summary>
        [Field(Field = "manually", Indexed = false, Caption = "是否為手動加入")]
        public bool Manually { get; set; }

        /// <summary>
        /// 條件優先
        /// </summary>
        [Field(Field = "is_condition", Indexed = false, Caption = "條件優先")]
        public bool IsCondition { get; set; }

        /// <summary>
        /// 手動優先
        /// </summary>
        [Field(Field = "is_manual", Indexed = false, Caption = "手動優先")]
        public bool IsManual { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public CSAttend Clone()
        {
            return (this.MemberwiseClone() as CSAttend);
        }
    }
}