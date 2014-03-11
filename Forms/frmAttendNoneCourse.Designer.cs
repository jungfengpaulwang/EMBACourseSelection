namespace SelectCourse.Forms
{
    partial class frmAttendNoneCourse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.Export = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SubjectName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Level = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Credit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Type = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ClassName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.StudentName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(692, 517);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 28);
            this.Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exit.TabIndex = 37;
            this.Exit.Text = "離  開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Export
            // 
            this.Export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Export.AutoSize = true;
            this.Export.BackColor = System.Drawing.Color.Transparent;
            this.Export.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Export.Location = new System.Drawing.Point(568, 517);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(99, 28);
            this.Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Export.TabIndex = 38;
            this.Export.Text = "寄發email通知";
            this.Export.Visible = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.Level,
            this.Credit,
            this.Type,
            this.ClassName,
            this.StudentName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(21, 57);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(743, 442);
            this.dgvData.TabIndex = 36;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SubjectName.HeaderText = "年級";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            this.SubjectName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubjectName.Width = 59;
            // 
            // Level
            // 
            this.Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Level.HeaderText = "入學年度";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Level.Width = 85;
            // 
            // Credit
            // 
            this.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Credit.HeaderText = "組別";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Type.HeaderText = "班次";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 40;
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClassName.HeaderText = "學號";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClassName.Width = 59;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentName.HeaderText = "姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StudentName.Width = 59;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(329, 18);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(47, 21);
            this.labelX5.TabIndex = 40;
            this.labelX5.Text = "階段別";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 19;
            this.comboBoxEx1.Location = new System.Drawing.Point(379, 17);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(89, 25);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 50;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 19;
            this.comboBoxEx2.Location = new System.Drawing.Point(218, 17);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(89, 25);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 54;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(182, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 53;
            this.labelX3.Text = "學期";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(71, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 25);
            this.numericUpDown1.TabIndex = 52;
            this.numericUpDown1.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(22, 18);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 21);
            this.labelX4.TabIndex = 51;
            this.labelX4.Text = "學年度";
            // 
            // frmAttendNoneCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.comboBoxEx2);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.dgvData);
            this.DoubleBuffered = true;
            this.Name = "frmAttendNoneCourse";
            this.Text = "查詢尚未選課學生";
            this.Load += new System.EventHandler(this.frmSnapshot_Course_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.ButtonX Export;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SubjectName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Level;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Credit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Type;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn StudentName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}