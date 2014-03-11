namespace CourseSelection.Forms
{
    partial class frmAttendNoChange
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvDataNonConfirm = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.Confirm = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtSNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridViewLabelXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn3 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn4 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn5 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn6 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.print_date_2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.received_date_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.received = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.SubjectName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Level = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Credit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Type = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ClassName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.StudentName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.confirm_date = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataNonConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(992, 517);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 28);
            this.Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exit.TabIndex = 37;
            this.Exit.Text = "離  開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Location = new System.Drawing.Point(21, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 439);
            this.tabControl1.TabIndex = 47;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvData);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1043, 410);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
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
            this.StudentName,
            this.confirm_date,
            this.Cancel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(1, 1);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1041, 408);
            this.dgvData.TabIndex = 37;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "已確認學生";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvDataNonConfirm);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1043, 410);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dgvDataNonConfirm
            // 
            this.dgvDataNonConfirm.AllowUserToAddRows = false;
            this.dgvDataNonConfirm.AllowUserToDeleteRows = false;
            this.dgvDataNonConfirm.AllowUserToOrderColumns = true;
            this.dgvDataNonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataNonConfirm.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataNonConfirm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataNonConfirm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDataNonConfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLabelXColumn1,
            this.dataGridViewLabelXColumn2,
            this.dataGridViewLabelXColumn3,
            this.dataGridViewLabelXColumn4,
            this.dataGridViewLabelXColumn5,
            this.dataGridViewLabelXColumn6,
            this.print_date_2,
            this.received_date_2,
            this.received});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataNonConfirm.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDataNonConfirm.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDataNonConfirm.Location = new System.Drawing.Point(1, 1);
            this.dgvDataNonConfirm.Name = "dgvDataNonConfirm";
            this.dgvDataNonConfirm.RowHeadersWidth = 25;
            this.dgvDataNonConfirm.RowTemplate.Height = 24;
            this.dgvDataNonConfirm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataNonConfirm.Size = new System.Drawing.Size(1041, 408);
            this.dgvDataNonConfirm.TabIndex = 38;
            this.dgvDataNonConfirm.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataNonConfirm_CellValueChanged);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "未確認學生";
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(218, 18);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(89, 25);
            this.cboSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboSemester.TabIndex = 74;
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
            this.labelX6.Location = new System.Drawing.Point(182, 19);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(34, 21);
            this.labelX6.TabIndex = 73;
            this.labelX6.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Location = new System.Drawing.Point(71, 18);
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
            this.nudSchoolYear.TabIndex = 72;
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
            this.labelX7.Location = new System.Drawing.Point(22, 19);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(47, 21);
            this.labelX7.TabIndex = 71;
            this.labelX7.Text = "學年度";
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
            this.circularProgress.Location = new System.Drawing.Point(849, 520);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(44, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 75;
            this.circularProgress.Visible = false;
            // 
            // Confirm
            // 
            this.Confirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Confirm.BackColor = System.Drawing.Color.Transparent;
            this.Confirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Confirm.Location = new System.Drawing.Point(899, 517);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(72, 28);
            this.Confirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Confirm.TabIndex = 76;
            this.Confirm.Text = "確  認";
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(22, 517);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 21);
            this.labelX1.TabIndex = 77;
            this.labelX1.Text = "學號或姓名";
            // 
            // txtSNum
            // 
            this.txtSNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.txtSNum.Border.Class = "TextBoxBorder";
            this.txtSNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSNum.Location = new System.Drawing.Point(100, 515);
            this.txtSNum.Name = "txtSNum";
            this.txtSNum.Size = new System.Drawing.Size(164, 25);
            this.txtSNum.TabIndex = 78;
            this.txtSNum.TextChanged += new System.EventHandler(this.txtSNum_TextChanged);
            // 
            // dataGridViewLabelXColumn1
            // 
            this.dataGridViewLabelXColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewLabelXColumn1.HeaderText = "年級";
            this.dataGridViewLabelXColumn1.Name = "dataGridViewLabelXColumn1";
            this.dataGridViewLabelXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn1.Width = 59;
            // 
            // dataGridViewLabelXColumn2
            // 
            this.dataGridViewLabelXColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewLabelXColumn2.HeaderText = "入學年度";
            this.dataGridViewLabelXColumn2.Name = "dataGridViewLabelXColumn2";
            this.dataGridViewLabelXColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLabelXColumn2.Width = 85;
            // 
            // dataGridViewLabelXColumn3
            // 
            this.dataGridViewLabelXColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn3.HeaderText = "組別";
            this.dataGridViewLabelXColumn3.Name = "dataGridViewLabelXColumn3";
            this.dataGridViewLabelXColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn4
            // 
            this.dataGridViewLabelXColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn4.HeaderText = "班次";
            this.dataGridViewLabelXColumn4.Name = "dataGridViewLabelXColumn4";
            this.dataGridViewLabelXColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn5
            // 
            this.dataGridViewLabelXColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn5.HeaderText = "學號";
            this.dataGridViewLabelXColumn5.Name = "dataGridViewLabelXColumn5";
            this.dataGridViewLabelXColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn6
            // 
            this.dataGridViewLabelXColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLabelXColumn6.HeaderText = "姓名";
            this.dataGridViewLabelXColumn6.Name = "dataGridViewLabelXColumn6";
            this.dataGridViewLabelXColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // print_date_2
            // 
            this.print_date_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.print_date_2.HeaderText = "列印加退選單日期";
            this.print_date_2.Name = "print_date_2";
            this.print_date_2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.print_date_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.print_date_2.Width = 137;
            // 
            // received_date_2
            // 
            this.received_date_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.received_date_2.HeaderText = "收到加退選單日期";
            this.received_date_2.Name = "received_date_2";
            this.received_date_2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.received_date_2.Width = 137;
            // 
            // received
            // 
            this.received.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.received.Checked = true;
            this.received.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.received.CheckValue = "N";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.received.DefaultCellStyle = dataGridViewCellStyle4;
            this.received.HeaderText = "收到加退選單";
            this.received.Name = "received";
            this.received.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.received.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.received.Width = 111;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SubjectName.HeaderText = "年級";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubjectName.Width = 59;
            // 
            // Level
            // 
            this.Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Level.HeaderText = "入學年度";
            this.Level.Name = "Level";
            this.Level.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Level.Width = 85;
            // 
            // Credit
            // 
            this.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Credit.HeaderText = "組別";
            this.Credit.Name = "Credit";
            this.Credit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "班次";
            this.Type.Name = "Type";
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClassName.HeaderText = "學號";
            this.ClassName.Name = "ClassName";
            this.ClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentName.HeaderText = "姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // confirm_date
            // 
            this.confirm_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.confirm_date.HeaderText = "選課最終確認日期";
            this.confirm_date.Name = "confirm_date";
            this.confirm_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Cancel
            // 
            this.Cancel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Cancel.HeaderText = "註銷";
            this.Cancel.Name = "Cancel";
            this.Cancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cancel.Width = 59;
            // 
            // frmAttendNoChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.txtSNum);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.nudSchoolYear);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Exit);
            this.DoubleBuffered = true;
            this.Name = "frmAttendNoChange";
            this.Text = "加退選確認查詢";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataNonConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX Exit;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDataNonConfirm;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.ButtonX Confirm;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSNum;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SubjectName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Level;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Credit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Type;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn StudentName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn confirm_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancel;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn4;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn5;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn6;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn print_date_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn received_date_2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn received;
    }
}