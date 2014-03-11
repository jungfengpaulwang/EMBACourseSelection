namespace CourseSelection.Forms
{
    partial class frmOpeningInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.Save = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(408, 188);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(54, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "離開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Save
            // 
            this.Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save.Location = new System.Drawing.Point(341, 188);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(54, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "儲存";
            this.Save.Click += new System.EventHandler(this.Save_Click);
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
            this.labelX2.Location = new System.Drawing.Point(173, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Location = new System.Drawing.Point(62, 11);
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
            this.nudSchoolYear.TabIndex = 7;
            this.nudSchoolYear.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "學年度";
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(209, 11);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(89, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 10;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboItem,
            this.BeginTime,
            this.EndTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(13, 47);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(449, 127);
            this.dgvData.TabIndex = 11;
            // 
            // cboItem
            // 
            this.cboItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cboItem.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboItem.HeaderText = "階段別";
            this.cboItem.Name = "cboItem";
            this.cboItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BeginTime
            // 
            this.BeginTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BeginTime.HeaderText = "開始時間";
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BeginTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BeginTime.ToolTipText = "範例：2013/6/22 00:01";
            // 
            // EndTime
            // 
            this.EndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndTime.HeaderText = "結束時間";
            this.EndTime.Name = "EndTime";
            this.EndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndTime.ToolTipText = "範例：2013/7/31 23:59";
            // 
            // frmOpeningInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 218);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.nudSchoolYear);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.DoubleBuffered = true;
            this.Name = "frmOpeningInfo";
            this.Text = "選課開放時間設定";
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.ButtonX Save;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;

    }
}