namespace CourseSelection.Forms
{
    partial class frmAttend_Course
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvData_Log = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewLabelXColumn5 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn6 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn7 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn8 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn9 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn10 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tabLog = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvData_Attend = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SubjectName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Level = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Credit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Type = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ClassName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.StudentName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tabAttend = new DevComponents.DotNetBar.TabItem(this.components);
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboCourse = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_Log)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_Attend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
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
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(625, 18);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(47, 21);
            this.labelX5.TabIndex = 40;
            this.labelX5.Text = "階段別";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Location = new System.Drawing.Point(21, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 439);
            this.tabControl1.TabIndex = 46;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabAttend);
            this.tabControl1.Tabs.Add(this.tabLog);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvData_Log);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(743, 410);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabLog;
            // 
            // dgvData_Log
            // 
            this.dgvData_Log.AllowUserToAddRows = false;
            this.dgvData_Log.AllowUserToDeleteRows = false;
            this.dgvData_Log.AllowUserToOrderColumns = true;
            this.dgvData_Log.BackgroundColor = System.Drawing.Color.White;
            this.dgvData_Log.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData_Log.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData_Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLabelXColumn5,
            this.dataGridViewLabelXColumn6,
            this.dataGridViewLabelXColumn7,
            this.dataGridViewLabelXColumn8,
            this.dataGridViewLabelXColumn9,
            this.dataGridViewLabelXColumn10});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData_Log.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData_Log.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData_Log.Location = new System.Drawing.Point(1, 1);
            this.dgvData_Log.Name = "dgvData_Log";
            this.dgvData_Log.ReadOnly = true;
            this.dgvData_Log.RowHeadersWidth = 25;
            this.dgvData_Log.RowTemplate.Height = 24;
            this.dgvData_Log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData_Log.Size = new System.Drawing.Size(741, 408);
            this.dgvData_Log.TabIndex = 38;
            // 
            // dataGridViewLabelXColumn5
            // 
            this.dataGridViewLabelXColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewLabelXColumn5.HeaderText = "年級";
            this.dataGridViewLabelXColumn5.Name = "dataGridViewLabelXColumn5";
            this.dataGridViewLabelXColumn5.ReadOnly = true;
            this.dataGridViewLabelXColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn5.Width = 59;
            // 
            // dataGridViewLabelXColumn6
            // 
            this.dataGridViewLabelXColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewLabelXColumn6.HeaderText = "入學年度";
            this.dataGridViewLabelXColumn6.Name = "dataGridViewLabelXColumn6";
            this.dataGridViewLabelXColumn6.ReadOnly = true;
            this.dataGridViewLabelXColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn6.Width = 85;
            // 
            // dataGridViewLabelXColumn7
            // 
            this.dataGridViewLabelXColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn7.HeaderText = "組別";
            this.dataGridViewLabelXColumn7.Name = "dataGridViewLabelXColumn7";
            this.dataGridViewLabelXColumn7.ReadOnly = true;
            this.dataGridViewLabelXColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn8
            // 
            this.dataGridViewLabelXColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn8.HeaderText = "班次";
            this.dataGridViewLabelXColumn8.Name = "dataGridViewLabelXColumn8";
            this.dataGridViewLabelXColumn8.ReadOnly = true;
            // 
            // dataGridViewLabelXColumn9
            // 
            this.dataGridViewLabelXColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn9.HeaderText = "學號";
            this.dataGridViewLabelXColumn9.Name = "dataGridViewLabelXColumn9";
            this.dataGridViewLabelXColumn9.ReadOnly = true;
            this.dataGridViewLabelXColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn10
            // 
            this.dataGridViewLabelXColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn10.HeaderText = "姓名";
            this.dataGridViewLabelXColumn10.Name = "dataGridViewLabelXColumn10";
            this.dataGridViewLabelXColumn10.ReadOnly = true;
            this.dataGridViewLabelXColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabLog
            // 
            this.tabLog.AttachedControl = this.tabControlPanel2;
            this.tabLog.Name = "tabLog";
            this.tabLog.Text = "未選上學生";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvData_Attend);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(743, 410);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabAttend;
            // 
            // dgvData_Attend
            // 
            this.dgvData_Attend.AllowUserToAddRows = false;
            this.dgvData_Attend.AllowUserToDeleteRows = false;
            this.dgvData_Attend.AllowUserToOrderColumns = true;
            this.dgvData_Attend.BackgroundColor = System.Drawing.Color.White;
            this.dgvData_Attend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData_Attend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData_Attend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvData_Attend.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData_Attend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData_Attend.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData_Attend.Location = new System.Drawing.Point(1, 1);
            this.dgvData_Attend.Name = "dgvData_Attend";
            this.dgvData_Attend.ReadOnly = true;
            this.dgvData_Attend.RowHeadersWidth = 25;
            this.dgvData_Attend.RowTemplate.Height = 24;
            this.dgvData_Attend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData_Attend.Size = new System.Drawing.Size(741, 408);
            this.dgvData_Attend.TabIndex = 37;
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
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "班次";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClassName.HeaderText = "學號";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentName.HeaderText = "姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabAttend
            // 
            this.tabAttend.AttachedControl = this.tabControlPanel1;
            this.tabAttend.Name = "tabAttend";
            this.tabAttend.Text = "選上學生";
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
            this.labelX3.Location = new System.Drawing.Point(328, 18);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 47;
            this.labelX3.Text = "課程清單";
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(217, 16);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(89, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 58;
            this.cboSemester.SelectedIndexChanged += new System.EventHandler(this.cboSemester_SelectedIndexChanged);
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
            this.labelX1.Location = new System.Drawing.Point(181, 17);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 57;
            this.labelX1.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Location = new System.Drawing.Point(71, 16);
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
            this.nudSchoolYear.TabIndex = 56;
            this.nudSchoolYear.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.nudSchoolYear.ValueChanged += new System.EventHandler(this.nudSchoolYear_ValueChanged);
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
            this.labelX4.Location = new System.Drawing.Point(22, 17);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 21);
            this.labelX4.TabIndex = 55;
            this.labelX4.Text = "學年度";
            // 
            // cboCourse
            // 
            this.cboCourse.DisplayMember = "Text";
            this.cboCourse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.ItemHeight = 19;
            this.cboCourse.Location = new System.Drawing.Point(390, 16);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(213, 25);
            this.cboCourse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCourse.TabIndex = 59;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // cboItem
            // 
            this.cboItem.DisplayMember = "Text";
            this.cboItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.ItemHeight = 19;
            this.cboItem.Location = new System.Drawing.Point(674, 16);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(89, 25);
            this.cboItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboItem.TabIndex = 60;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
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
            this.circularProgress.Location = new System.Drawing.Point(640, 519);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(44, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 64;
            this.circularProgress.Visible = false;
            // 
            // frmAttend_Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.nudSchoolYear);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.Exit);
            this.DoubleBuffered = true;
            this.Name = "frmAttend_Course";
            this.Text = "查詢選課結果";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_Log)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_Attend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabAttend;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabLog;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData_Attend;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData_Log;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCourse;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboItem;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn5;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn6;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn7;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn8;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn9;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn10;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SubjectName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Level;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Credit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Type;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn StudentName;
    }
}