using System;
using FISCA.UDT;
using System.Collections.Generic;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 選課說明
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.cs_faq")]
    public class CSFaq : ActiveRecord
    {
        internal static void RaiseAfterUpdateEvent(object sender, DeliverCSFaqEventArgs e)
        {
            if (CSFaq.AfterUpdate != null)
                CSFaq.AfterUpdate(sender, e);
        }

        internal static event EventHandler<DeliverCSFaqEventArgs> AfterUpdate;

        /// <summary>
        /// 題號
        /// </summary>
        [Field(Field = "display_order", Indexed = true, Caption = "題號")]
        public int Item { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        [Field(Field = "category", Indexed = false, Caption = "類別")]
        public string Category { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        [Field(Field = "title", Indexed = false, Caption = "標題")]
        public string Title { get; set; }

        /// <summary>
        /// 內容
        /// </summary>
        [Field(Field = "content", Indexed = false, Caption = "內容")]
        public string Content { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public CSFaq Clone()
        {
            return (this.MemberwiseClone() as CSFaq);
        }
    }
    /// <summary>
    /// 將自已當參數傳送出去
    /// </summary>
    public class DeliverCSFaqEventArgs : EventArgs
    {
        private List<UDT.CSFaq> records;
        public List<UDT.CSFaq> ActiveRecords
        {
            get
            {
                return records;
            }
        }
        public DeliverCSFaqEventArgs(List<UDT.CSFaq> records)
        {
            this.records = records;
        }
    }
}