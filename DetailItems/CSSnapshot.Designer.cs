namespace CourseSelection.DetailItems
{
    partial class CSSnapshot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CourseName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.SubjectCode = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Category = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Credit2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cboItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseName,
            this.SubjectCode,
            this.Category,
            this.Credit2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(25, 62);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(499, 279);
            this.dgvData.TabIndex = 53;
            // 
            // CourseName
            // 
            this.CourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseName.HeaderText = "開課";
            this.CourseName.Name = "CourseName";
            this.CourseName.ReadOnly = true;
            // 
            // SubjectCode
            // 
            this.SubjectCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubjectCode.HeaderText = "課號";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            this.SubjectCode.Width = 40;
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Category.HeaderText = "類別";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 40;
            // 
            // Credit2
            // 
            this.Credit2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Credit2.HeaderText = "學分數";
            this.Credit2.Name = "Credit2";
            this.Credit2.ReadOnly = true;
            this.Credit2.Width = 53;
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(221, 18);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(89, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 68;
            this.cboSemester.SelectedIndexChanged += new System.EventHandler(this.cboSemester_SelectedIndexChanged);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(185, 19);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(34, 21);
            this.labelX6.TabIndex = 67;
            this.labelX6.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Location = new System.Drawing.Point(74, 18);
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
            this.nudSchoolYear.TabIndex = 66;
            this.nudSchoolYear.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.nudSchoolYear.ValueChanged += new System.EventHandler(this.nudSchoolYear_ValueChanged);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(25, 19);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(47, 21);
            this.labelX7.TabIndex = 65;
            this.labelX7.Text = "學年度";
            // 
            // cboItem
            // 
            this.cboItem.DisplayMember = "Text";
            this.cboItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.ItemHeight = 19;
            this.cboItem.Location = new System.Drawing.Point(382, 18);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(89, 25);
            this.cboItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboItem.TabIndex = 64;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(332, 19);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(47, 21);
            this.labelX8.TabIndex = 63;
            this.labelX8.Text = "階段別";
            // 
            // CSSnapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.nudSchoolYear);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.dgvData);
            this.Name = "CSSnapshot";
            this.Size = new System.Drawing.Size(550, 365);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboItem;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CourseName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SubjectCode;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Category;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Credit2;

    }
}