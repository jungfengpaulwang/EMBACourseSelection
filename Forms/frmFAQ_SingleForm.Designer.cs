namespace CourseSelection.Forms
{
    partial class frmFAQ_SingleForm
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
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtItem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.Save = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cboCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(16, 170);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(43, 24);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "內容";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtContent.Border.Class = "TextBoxBorder";
            this.txtContent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContent.Location = new System.Drawing.Point(61, 170);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(692, 341);
            this.txtContent.TabIndex = 4;
            // 
            // txtItem
            // 
            // 
            // 
            // 
            this.txtItem.Border.Class = "TextBoxBorder";
            this.txtItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtItem.Location = new System.Drawing.Point(308, 23);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(55, 25);
            this.txtItem.TabIndex = 2;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(272, 25);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "題號";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(25, 73);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "標題";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTitle.Border.Class = "TextBoxBorder";
            this.txtTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTitle.Location = new System.Drawing.Point(61, 73);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTitle.Size = new System.Drawing.Size(692, 72);
            this.txtTitle.TabIndex = 3;
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(699, 526);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(54, 23);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "離開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Save
            // 
            this.Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save.Location = new System.Drawing.Point(632, 526);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(54, 23);
            this.Save.TabIndex = 5;
            this.Save.Text = "儲存";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(16, 25);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(43, 21);
            this.labelX7.TabIndex = 22;
            this.labelX7.Text = "類別";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCategory
            // 
            this.cboCategory.DisplayMember = "Text";
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 19;
            this.cboCategory.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cboCategory.Location = new System.Drawing.Point(61, 23);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(171, 25);
            this.cboCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCategory.TabIndex = 1;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "選課注意事項";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "選課問答";
            // 
            // frmFAQ_SingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.labelX3);
            this.DoubleBuffered = true;
            this.Name = "frmFAQ_SingleForm";
            this.Text = "選課注意事項及問答輸入";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContent;
        private DevComponents.DotNetBar.Controls.TextBoxX txtItem;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTitle;
        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.ButtonX Save;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCategory;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
    }
}