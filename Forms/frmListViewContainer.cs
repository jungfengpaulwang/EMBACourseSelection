using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Dynamic;

namespace CourseSelection.Forms
{
    public partial class frmListViewContainer : BaseForm
    {
        public List<dynamic> CheckLists;
        public frmListViewContainer(string txtTitle, List<dynamic> dymCheckLists)
        {
            InitializeComponent();

            this.Text = txtTitle;
            this.CheckLists = dymCheckLists;

            this.Load += new EventHandler(frmListViewContainer_Load);
        }

        private void frmListViewContainer_Load(object sender, EventArgs e)
        {
            foreach(dynamic oo in this.CheckLists)
            {
                ListViewItem item = new ListViewItem();

                item.Text = oo.Text;
                item.Checked = oo.Checked;
                item.Tag = oo.ID;

                this.lstCheckLists.Items.Add(item);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            this.CheckLists.Clear();
            foreach (ListViewItem item in this.lstCheckLists.Items)
            {
                dynamic oo = new ExpandoObject();

                oo.Text = item.Text;
                oo.Checked = item.Checked;
                oo.ID = item.Tag + "";

                this.CheckLists.Add(oo);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
