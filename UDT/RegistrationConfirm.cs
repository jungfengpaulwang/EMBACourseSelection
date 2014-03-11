using System;
using FISCA.UDT;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 選課記錄
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.registration_confirm")]
    public class RegistrationConfirm : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSAttend.AfterUpdate != null)
        //        CSAttend.AfterUpdate(sender, e);
        //}

        //internal static event EventHandler<ParameterEventArgs> AfterUpdate;
        
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
        /// 選課最終確認-->true：已確認；false：未確認或已註銷
        /// </summary>
        [Field(Field = "confirm", Indexed = false, Caption = "選課最終確認")]
        public bool Confirm { get; set; }

        /// <summary>
        /// 選課最終確認日期
        /// </summary>
        [Field(Field = "confirm_date", Indexed = false, Caption = "選課最終確認日期")]
        public DateTime? ConfirmDate { get; set; }

        /// <summary>
        /// 列印加退選單日期
        /// </summary>
        [Field(Field = "print_date", Indexed = false, Caption = "列印加退選單日期")]
        public DateTime? PrintDate { get; set; }

        /// <summary>
        /// 收到加退選單日期
        /// </summary>
        [Field(Field = "received_date", Indexed = false, Caption = "收到加退選單日期")]
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public RegistrationConfirm Clone()
        {
            return (this.MemberwiseClone() as RegistrationConfirm);
        }
    }
}