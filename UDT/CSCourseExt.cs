using FISCA.UDT;

namespace CourseSelection.UDT
{        
    /// <summary>
    /// 紀錄在UDT中的課程額外資訊的Value Object
    /// </summary>
    [TableName("ischool.emba.course_ext")]
    public class CSCourseExt : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSCourseExt.AfterUpdate != null)
        //        CSCourseExt.AfterUpdate(sender, e);
        //}

        //internal static event EventHandler<ParameterEventArgs> AfterUpdate;

        /// <summary>
        /// 開課系統編號
        /// </summary>
        [Field(Field = "ref_course_id", Indexed = true, Caption = "開課系統編號")]
        public int CourseID { get; set; }

        /// <summary>
        /// 修課人數上限
        /// </summary>
        [Field(Field = "capacity", Indexed = false, Caption = "修課人數上限")]
        public int Capacity { get; set; }

        ///// <summary>
        ///// 是否開放給所有人選課？
        ///// </summary>
        //[Field(Field = "opening_global", Indexed = false, Caption = "是否開放給所有人選課")]
        //public bool OpeningGlobal { get; set; }

        /// <summary>
        /// 不開放線上選課
        /// </summary>
        [Field(Field = "not_opening", Indexed = false, Caption = "不開放線上選課")]
        public bool NotOpening { get; set; }

        /// <summary>
        /// 選課條件
        /// <Identities>
        ///     <Allow>
        ///         <Identity ClassGradeYear=”101” ClassID=”” DeptID=”568” />
        ///         <Identity ClassGradeYear=”” ClassID=”587” DeptID=”” />
        ///         <Identity ClassGradeYear=”100” ClassID=”” DeptID=”” />
        ///     </Allow>
        ///     <Deny>
        ///         <Identity ClassGradeYear=”101” ClassID=”” DeptID=”568” />
        ///         <Identity ClassGradeYear=”” ClassID=”587” DeptID=”” />
        ///         <Identity ClassGradeYear=”100” ClassID=”” DeptID=”” />
        ///     </Deny>
        /// </Identities>
        /// </summary>
        [Field(Field = "identity", Indexed = false, Caption = "選課條件")]
        public string Identity { get; set; }
    }
}