using System;
using FISCA.UDT;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 選課模組WEB端寄發電子郵件用帳號
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.cs_email_account")]
    public class WebEMailAccount : ActiveRecord
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Field(Field = "account", Indexed = true, Caption = "帳號")]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Field(Field = "password", Indexed = false, Caption = "密碼")]
        public string Password { get; set; }

        ///// <summary>
        ///// SMTP
        ///// </summary>
        //[Field(Field = "smtp", Indexed = false, Caption = "SMTP")]
        //public string SMTP { get; set; }

        ///// <summary>
        ///// PORT
        ///// </summary>
        //[Field(Field = "port", Indexed = false, Caption = "PORT")]
        //public string PORT { get; set; }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public WebEMailAccount Clone()
        {
            return (this.MemberwiseClone() as WebEMailAccount);
        }
    }
}