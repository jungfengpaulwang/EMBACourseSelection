namespace CourseSelection.Forms
{
    partial class frmCSAttendToSnapshot
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
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.Save = new DevComponents.DotNetBar.ButtonX();
            this.lblSemesterInfo = new DevComponents.DotNetBar.LabelX();
            this.cboItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(247, 45);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(54, 23);
            this.Exit.TabIndex = 29;
            this.Exit.Text = "離開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Save
            // 
            this.Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save.Location = new System.Drawing.Point(178, 45);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(54, 23);
            this.Save.TabIndex = 28;
            this.Save.Text = "備份";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // lblSemesterInfo
            // 
            this.lblSemesterInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSemesterInfo.BackgroundStyle.Class = "";
            this.lblSemesterInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSemesterInfo.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSemesterInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblSemesterInfo.Location = new System.Drawing.Point(12, 12);
            this.lblSemesterInfo.Name = "lblSemesterInfo";
            this.lblSemesterInfo.Size = new System.Drawing.Size(220, 21);
            this.lblSemesterInfo.TabIndex = 36;
            this.lblSemesterInfo.Text = "尚未設定選課開放時間";
            // 
            // cboItem
            // 
            this.cboItem.DisplayMember = "Text";
            this.cboItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.ItemHeight = 19;
            this.cboItem.Location = new System.Drawing.Point(74, 44);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(89, 25);
            this.cboItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboItem.TabIndex = 62;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(25, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 21);
            this.labelX2.TabIndex = 61;
            this.labelX2.Text = "階段別";
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
            this.circularProgress.Location = new System.Drawing.Point(257, 12);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(44, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 63;
            this.circularProgress.Visible = false;
            // 
            // frmCSAttendToSnapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 76);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblSemesterInfo);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.DoubleBuffered = true;
            this.Name = "frmCSAttendToSnapshot";
            this.Text = "備份選課結果";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.ButtonX Save;
        private DevComponents.DotNetBar.LabelX lblSemesterInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboItem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
    }
}