namespace CourseSelection.DetailItems
{
    partial class Course_CSIdentity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkNotOpening = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvDataAllow = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboClassGradeYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboDept = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvDataDeny = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboClassGradeYearDeny = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboDeptDeny = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboClassDeny = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chkAllow = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkDeny = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAllow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDeny)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNotOpening
            // 
            this.chkNotOpening.AutoSize = true;
            // 
            // 
            // 
            this.chkNotOpening.BackgroundStyle.Class = "";
            this.chkNotOpening.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkNotOpening.Location = new System.Drawing.Point(20, 22);
            this.chkNotOpening.Name = "chkNotOpening";
            this.chkNotOpening.Size = new System.Drawing.Size(121, 21);
            this.chkNotOpening.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkNotOpening.TabIndex = 4;
            this.chkNotOpening.Text = "不開放線上選課";
            this.chkNotOpening.CheckedChanged += new System.EventHandler(this.chkOpeningGlobal_CheckedChanged);
            // 
            // dgvDataAllow
            // 
            this.dgvDataAllow.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataAllow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataAllow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataAllow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataAllow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboClassGradeYear,
            this.cboDept,
            this.cboClass});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataAllow.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDataAllow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDataAllow.Location = new System.Drawing.Point(20, 304);
            this.dgvDataAllow.Name = "dgvDataAllow";
            this.dgvDataAllow.RowHeadersWidth = 25;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDataAllow.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDataAllow.RowTemplate.Height = 24;
            this.dgvDataAllow.Size = new System.Drawing.Size(508, 188);
            this.dgvDataAllow.TabIndex = 6;
            // 
            // cboClassGradeYear
            // 
            this.cboClassGradeYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboClassGradeYear.DefaultCellStyle = dataGridViewCellStyle2;
            this.cboClassGradeYear.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboClassGradeYear.HeaderText = "入學年度";
            this.cboClassGradeYear.Name = "cboClassGradeYear";
            this.cboClassGradeYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboClassGradeYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboDept
            // 
            this.cboDept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cboDept.DefaultCellStyle = dataGridViewCellStyle3;
            this.cboDept.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboDept.HeaderText = "組別";
            this.cboDept.Name = "cboDept";
            this.cboDept.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboClass
            // 
            this.cboClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboClass.DefaultCellStyle = dataGridViewCellStyle4;
            this.cboClass.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboClass.HeaderText = "班級";
            this.cboClass.Name = "cboClass";
            this.cboClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvDataDeny
            // 
            this.dgvDataDeny.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataDeny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataDeny.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDataDeny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDeny.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboClassGradeYearDeny,
            this.cboDeptDeny,
            this.cboClassDeny});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataDeny.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDataDeny.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDataDeny.Location = new System.Drawing.Point(20, 83);
            this.dgvDataDeny.Name = "dgvDataDeny";
            this.dgvDataDeny.RowHeadersWidth = 25;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDataDeny.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDataDeny.RowTemplate.Height = 24;
            this.dgvDataDeny.Size = new System.Drawing.Size(508, 188);
            this.dgvDataDeny.TabIndex = 8;
            // 
            // cboClassGradeYearDeny
            // 
            this.cboClassGradeYearDeny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboClassGradeYearDeny.DefaultCellStyle = dataGridViewCellStyle8;
            this.cboClassGradeYearDeny.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboClassGradeYearDeny.HeaderText = "入學年度";
            this.cboClassGradeYearDeny.Name = "cboClassGradeYearDeny";
            this.cboClassGradeYearDeny.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboClassGradeYearDeny.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboDeptDeny
            // 
            this.cboDeptDeny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cboDeptDeny.DefaultCellStyle = dataGridViewCellStyle9;
            this.cboDeptDeny.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboDeptDeny.HeaderText = "組別";
            this.cboDeptDeny.Name = "cboDeptDeny";
            this.cboDeptDeny.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDeptDeny.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboClassDeny
            // 
            this.cboClassDeny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboClassDeny.DefaultCellStyle = dataGridViewCellStyle10;
            this.cboClassDeny.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboClassDeny.HeaderText = "班級";
            this.cboClassDeny.Name = "cboClassDeny";
            this.cboClassDeny.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboClassDeny.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chkAllow
            // 
            // 
            // 
            // 
            this.chkAllow.BackgroundStyle.Class = "";
            this.chkAllow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllow.Location = new System.Drawing.Point(20, 276);
            this.chkAllow.Name = "chkAllow";
            this.chkAllow.Size = new System.Drawing.Size(128, 23);
            this.chkAllow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllow.TabIndex = 11;
            this.chkAllow.Text = "允許選課條件";
            this.chkAllow.CheckedChanged += new System.EventHandler(this.chkAllow_CheckedChanged);
            // 
            // chkDeny
            // 
            // 
            // 
            // 
            this.chkDeny.BackgroundStyle.Class = "";
            this.chkDeny.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDeny.Location = new System.Drawing.Point(20, 55);
            this.chkDeny.Name = "chkDeny";
            this.chkDeny.Size = new System.Drawing.Size(128, 23);
            this.chkDeny.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDeny.TabIndex = 12;
            this.chkDeny.Text = "不允許選課條件";
            this.chkDeny.CheckedChanged += new System.EventHandler(this.chkDeny_CheckedChanged);
            // 
            // Course_CSIdentity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkDeny);
            this.Controls.Add(this.chkAllow);
            this.Controls.Add(this.dgvDataDeny);
            this.Controls.Add(this.dgvDataAllow);
            this.Controls.Add(this.chkNotOpening);
            this.Name = "Course_CSIdentity";
            this.Size = new System.Drawing.Size(550, 510);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataAllow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDeny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX chkNotOpening;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDataAllow;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboClassGradeYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDept;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboClass;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDataDeny;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboClassGradeYearDeny;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDeptDeny;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboClassDeny;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllow;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDeny;
    }
}