using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Threading.Tasks;
using FISCA.UDT;

namespace CourseSelection.Forms
{
    public partial class frmFAQ : BaseForm
    {
        private AccessHelper Access;

        public frmFAQ()
        {
            InitializeComponent();

            Access = new AccessHelper();
            this.Load += new EventHandler(frmFAQ_Load);
        }

        private void frmFAQ_Load(object sender, EventArgs e)
        {
            UDT.CSFaq.AfterUpdate += new EventHandler<UDT.DeliverCSFaqEventArgs>(CSFaq_AfterUpdate);
            this.DGV_DataBinding();
        }

        private void CSFaq_AfterUpdate(object sender, UDT.DeliverCSFaqEventArgs e)
        {
            this.DGV_DataBinding();
        }

        private void DGV_DataBinding()
        {
            List<UDT.CSFaq> Faqs = new List<UDT.CSFaq>();
            this.circularProgress.Visible = true;
            this.circularProgress.IsRunning = true;
            this.dgvData.Rows.Clear();
            Task task = Task.Factory.StartNew(() =>
            {
                Faqs = Access.Select<UDT.CSFaq>().OrderBy(x=>x.Category).ThenBy(x=>x.Item).ToList();
            });
            task.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    MessageBox.Show(x.Exception.InnerException.Message);
                    this.circularProgress.IsRunning = false;
                    this.circularProgress.Visible = false;
                    return;
                }
                if (Faqs.Count == 0)
                {
                    this.circularProgress.IsRunning = false;
                    this.circularProgress.Visible = false;
                    return;
                }
                Faqs.ForEach((y) =>
                {
                    List<object> source = new List<object>();

                    source.Add(y.Category);
                    source.Add(y.Item);
                    source.Add(y.Title);
                    source.Add(y.Content);

                    int idx = this.dgvData.Rows.Add(source.ToArray());
                    this.dgvData.Rows[idx].Tag = y;
                });

                this.circularProgress.IsRunning = false;
                this.circularProgress.Visible = false;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            (new Forms.frmFAQ_SingleForm(null)).ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("請單選項目。");
                return;
            }
            if (this.dgvData.SelectedRows.Count > 1)
            {
                MessageBox.Show("僅能單筆修改。");
                return;
            }
            if (this.dgvData.SelectedRows.Count == 1)
            {
                UDT.CSFaq CSFaq = this.dgvData.SelectedRows[0].Tag as UDT.CSFaq;
                (new Forms.frmFAQ_SingleForm(CSFaq)).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("請選取項目(可複選)。");
                return;
            }
            if (MessageBox.Show("確定刪除？", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                return;
            List<UDT.CSFaq> CSFaqs = new List<UDT.CSFaq>();
            foreach (DataGridViewRow row in this.dgvData.SelectedRows)
            {
                UDT.CSFaq CSFaq = row.Tag as UDT.CSFaq;

                CSFaq.Deleted = true;
                CSFaqs.Add(CSFaq);
            }
            CSFaqs.SaveAll();
            this.DGV_DataBinding();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
