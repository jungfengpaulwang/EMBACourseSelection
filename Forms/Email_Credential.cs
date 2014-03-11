using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Text.RegularExpressions;
using FISCA.UDT;

namespace CourseSelection.Forms
{
    /// <summary>
    /// 處理WEB端發送Email 時，系統使用之電子郵件帳號及密碼。
    /// </summary>
    public partial class Email_Credential : BaseForm
    {
        private AccessHelper Access;
        public Email_Credential()
        {
            InitializeComponent();

            Access = new AccessHelper();
        }

        private void Email_Credential_Load(object sender, EventArgs e)
        {
            List<UDT.WebEMailAccount> confs = Access.Select<UDT.WebEMailAccount>();

            if (confs.Count == 0)
                return;

            this.txtUserID.Text = confs[0].Account;
            this.txtPassword.Text = confs[0].Password;
        }

        private bool isValidEmail(string email)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                       + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                       + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                       + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                       + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);

            //                      bool isLenientMatch = reLenient.IsMatch(emailAddress);
            //                      return isLenientMatch;

            bool isStrictMatch = reStrict.IsMatch(email);
            return isStrictMatch;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isOk = true ;

            //Validate UserID
            if (string.IsNullOrWhiteSpace(this.txtUserID.Text))
            {
                this.errorProvider1.SetError(this.txtUserID, "請輸入電子郵件。");
               isOk = false  ;
            }
            else if (!isValidEmail(this.txtUserID.Text.Trim()))
            {
                this.errorProvider1.SetError(this.txtUserID, "電子郵件格式不正確。");
                isOk = false;
            }
            else
                this.errorProvider1.SetError(this.txtUserID, "");

            //Validate Password
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                if (MessageBox.Show("確定密碼是空白嗎？","注意", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes) {
                    isOk = false ;
                }
            }

            if (isOk)
            {
                //  先清空資料
                List<UDT.WebEMailAccount> confs = Access.Select<UDT.WebEMailAccount>();
                confs.ForEach((x) => x.Deleted = true);
                confs.SaveAll();

                //  寫入新資料
                UDT.WebEMailAccount conf = new UDT.WebEMailAccount();
                conf.Account = this.txtUserID.Text.Trim();
                conf.Password = this.txtPassword.Text.Trim();
                conf.Save();

                MessageBox.Show("儲存成功。");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
