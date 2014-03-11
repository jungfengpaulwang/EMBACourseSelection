using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;

namespace CourseSelection.Forms
{
    public partial class frmFAQ_SingleForm : BaseForm
    {
        private UDT.CSFaq CSFaq;
        private ErrorProvider ErrorProvider;
        private AccessHelper Access;

        public frmFAQ_SingleForm(UDT.CSFaq CSFaq)
        {
            InitializeComponent();
            this.CSFaq = CSFaq;
            Access = new AccessHelper();
            this.ErrorProvider = new ErrorProvider();
            this.Load += new EventHandler(frmFAQ_SingleForm_Load);
        }

        private void frmFAQ_SingleForm_Load(object sender, EventArgs e)
        {
            if (this.CSFaq == null)
            {
                this.cboCategory.SelectedIndex = 0;
                this.txtItem.Text = string.Empty;
                this.txtTitle.Text = string.Empty;
                this.txtContent.Text = string.Empty;
            }
            else
            {
                this.cboCategory.SelectedIndex = (this.CSFaq.Category == "選課注意事項" ? 1 : 2);
                this.txtItem.Text = this.CSFaq.Item.ToString();
                this.txtTitle.Text = this.CSFaq.Title;
                this.txtContent.Text = this.CSFaq.Content.Replace("\r\n", "\n").Replace("\n", "\r\n");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private bool Validated()
        {
            this.ErrorProvider.Clear();
            bool validated = true;

            uint item = 0;
            if (!uint.TryParse(this.txtItem.Text.Trim(), out item) || item == 0)
            {
                validated = false;
                this.ErrorProvider.SetError(this.txtItem, "必須為正整數。");
            }
            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
            {
                validated = false;
                this.ErrorProvider.SetError(this.txtTitle, "必填。");
            }
            if (string.IsNullOrWhiteSpace(this.txtContent.Text))
            {
                validated = false;
                this.ErrorProvider.SetError(this.txtContent, "必填。");
            }
            if (this.cboCategory.SelectedIndex == -1 || this.cboCategory.SelectedIndex == 0)
            {
                validated = false;
                this.ErrorProvider.SetError(this.cboCategory, "必選。");
            }

            return validated;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!this.Validated())
            {
                MessageBox.Show("請修正錯誤再儲存。");
                return;
            }
            if (this.CSFaq == null)
                this.CSFaq = new UDT.CSFaq();

            List<UDT.CSFaq> CSFaqs = Access.Select<UDT.CSFaq>();

            if (string.IsNullOrEmpty(this.CSFaq.UID))
            {
                if (CSFaqs.Where(x => (x.Title.Trim() == this.txtTitle.Text.Trim())).Count() > 0)
                {
                    MessageBox.Show("相同標題之注意事項或問答已存在。");
                    return;
                }
                if (CSFaqs.Where(x => (x.Item.ToString() == this.txtItem.Text.Trim() && x.Category == this.cboCategory.Items[this.cboCategory.SelectedIndex].ToString())).Count() > 0)
                {
                    MessageBox.Show("相同題號之注意事項或問答已存在。");
                    return;
                }
            }
            else
            {
                if (CSFaqs.Where(x => (x.Title.Trim() == this.txtTitle.Text.Trim() && x.UID != this.CSFaq.UID)).Count() > 0)
                {
                    MessageBox.Show("相同標題之注意事項或問答已存在。");
                    return;
                }
                if (CSFaqs.Where(x => (x.Item.ToString() == this.txtItem.Text.Trim() && x.Category == this.cboCategory.Items[this.cboCategory.SelectedIndex].ToString() && x.UID != this.CSFaq.UID)).Count() > 0)
                {
                    MessageBox.Show("相同題號之注意事項或問答已存在。");
                    return;
                }
            }
            this.CSFaq.Category = (this.cboCategory.SelectedIndex == 1 ? "選課注意事項" : "選課問答");
            this.CSFaq.Item = int.Parse(this.txtItem.Text.Trim());
            this.CSFaq.Title = this.txtTitle.Text.Trim();
            this.CSFaq.Content = this.txtContent.Text.Trim();

            this.CSFaq.Save();
            UDT.DeliverCSFaqEventArgs ee = new UDT.DeliverCSFaqEventArgs(new List<UDT.CSFaq>(){ this.CSFaq });
            UDT.CSFaq.RaiseAfterUpdateEvent(this, ee);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
