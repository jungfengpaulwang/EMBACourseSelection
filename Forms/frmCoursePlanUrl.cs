using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Data;
using FISCA.UDT;

namespace CourseSelection.Forms
{
    public partial class frmCoursePlanUrl : BaseForm
    {
        private QueryHelper queryHelper;
        private AccessHelper Access;

        public frmCoursePlanUrl()
        {
            queryHelper = new QueryHelper();
            Access = new AccessHelper();

            InitializeComponent();
            this.Load += new EventHandler(frmCoursePlanUrl_Load);
        }

        private void frmCoursePlanUrl_Load(object sender, EventArgs e)
        {
            UDT.WebUrls web_url = UDT.WebUrls.GetWebUrl(UDT.WebUrls.UrlName.課程計劃);

            this.txtStudentNumber.Text = web_url.Url.Trim();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UDT.WebUrls web_url = UDT.WebUrls.GetWebUrl(UDT.WebUrls.UrlName.課程計劃);
                web_url.Url = this.txtStudentNumber.Text.Trim();
                web_url.Save();
                MessageBox.Show("設定成功。");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
