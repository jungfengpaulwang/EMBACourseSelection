namespace CourseSelection.Export
{
    partial class CSNoConfirm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(490, 329);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(575, 329);
            // 
            // chkSelectAll
            // 
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.Class = "";
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // lblExplanation
            // 
            // 
            // 
            // 
            this.lblExplanation.BackgroundStyle.Class = "";
            this.lblExplanation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblExplanation.Size = new System.Drawing.Size(101, 21);
            // 
            // FieldContainer
            // 
            this.FieldContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldContainer.Size = new System.Drawing.Size(616, 260);
            // 
            // circularProgress
            // 
            this.circularProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.circularProgress.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.Class = "";
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.Location = new System.Drawing.Point(440, 331);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(44, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 65;
            this.circularProgress.Visible = false;
            // 
            // cboSemester
            // 
            this.cboSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(404, 15);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(89, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 71;
            this.cboSemester.SelectedIndexChanged += new System.EventHandler(this.cboSemester_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(368, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 70;
            this.labelX1.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSchoolYear.Location = new System.Drawing.Point(258, 15);
            this.nudSchoolYear.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudSchoolYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSchoolYear.Name = "nudSchoolYear";
            this.nudSchoolYear.Size = new System.Drawing.Size(89, 25);
            this.nudSchoolYear.TabIndex = 69;
            this.nudSchoolYear.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.nudSchoolYear.ValueChanged += new System.EventHandler(this.nudSchoolYear_ValueChanged);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(209, 16);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 21);
            this.labelX4.TabIndex = 68;
            this.labelX4.Text = "學年度";
            // 
            // CSAttend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 366);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.nudSchoolYear);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.circularProgress);
            this.DoubleBuffered = true;
            this.Name = "CSAttend";
            this.Text = "CSAttendResult";
            this.Controls.SetChildIndex(this.circularProgress, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.nudSchoolYear, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.cboSemester, 0);
            this.Controls.SetChildIndex(this.chkSelectAll, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.FieldContainer, 0);
            this.Controls.SetChildIndex(this.lblExplanation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX4;

    }
}