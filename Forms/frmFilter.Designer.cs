namespace CourseSelection.Forms
{
    partial class frmFilter
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
            if ( disposing && ( components != null ) )
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
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.lstCourse = new System.Windows.Forms.ListBox();
            this.panSemester = new DevComponents.DotNetBar.PanelEx();
            this.cboSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.nudSchoolYear = new System.Windows.Forms.NumericUpDown();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem3 = new DevComponents.DotNetBar.CheckBoxItem();
            this.panel2 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblPeriod = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtMemo = new DevComponents.DotNetBar.LabelX();
            this.txtCapacity = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panel3 = new DevComponents.DotNetBar.PanelEx();
            this.panel6 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkReset = new System.Windows.Forms.LinkLabel();
            this.lblCapacityInfo = new DevComponents.DotNetBar.LabelX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblEnrollYear = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblDeptName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblClassName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblStudentNumber = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblCSTime = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lblItem = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.chkLock = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.lblStudentID = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.chkEvaluation = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colPeriod1 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colManual = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.chkShowLog = new System.Windows.Forms.CheckBox();
            this.panel5 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtFilter = new DevComponents.DotNetBar.LabelX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnClass = new DevComponents.DotNetBar.ButtonX();
            this.btnDept = new DevComponents.DotNetBar.ButtonX();
            this.btnSchoolYear = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new DevComponents.DotNetBar.PanelEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnManualFilter = new DevComponents.DotNetBar.ButtonX();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnFilter = new DevComponents.DotNetBar.ButtonX();
            this.btnRecover = new DevComponents.DotNetBar.ButtonX();
            this.btnAddManual = new DevComponents.DotNetBar.ButtonX();
            this.expandablePanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panSemester.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.panel1);
            this.expandablePanel1.Controls.Add(this.panSemester);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel1.ExpandOnTitleClick = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.ShowFocusRectangle = true;
            this.expandablePanel1.Size = new System.Drawing.Size(260, 729);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 1;
            this.expandablePanel1.TabStop = true;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "課程";
            // 
            // panel1
            // 
            this.panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel1.Controls.Add(this.lstCourse);
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 658);
            this.panel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel1.TabIndex = 7;
            // 
            // lstCourse
            // 
            this.lstCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCourse.FormattingEnabled = true;
            this.lstCourse.ItemHeight = 17;
            this.lstCourse.Location = new System.Drawing.Point(0, 0);
            this.lstCourse.Name = "lstCourse";
            this.lstCourse.Size = new System.Drawing.Size(260, 658);
            this.lstCourse.TabIndex = 6;
            this.lstCourse.SelectedIndexChanged += new System.EventHandler(this.lstCourse_SelectedIndexChanged);
            // 
            // panSemester
            // 
            this.panSemester.CanvasColor = System.Drawing.SystemColors.Control;
            this.panSemester.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panSemester.Controls.Add(this.cboSemester);
            this.panSemester.Controls.Add(this.labelX1);
            this.panSemester.Controls.Add(this.nudSchoolYear);
            this.panSemester.Controls.Add(this.labelX2);
            this.panSemester.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSemester.Location = new System.Drawing.Point(0, 26);
            this.panSemester.Name = "panSemester";
            this.panSemester.Size = new System.Drawing.Size(260, 45);
            this.panSemester.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panSemester.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panSemester.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panSemester.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panSemester.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panSemester.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panSemester.Style.GradientAngle = 90;
            this.panSemester.TabIndex = 1;
            // 
            // cboSemester
            // 
            this.cboSemester.DisplayMember = "Text";
            this.cboSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.ItemHeight = 19;
            this.cboSemester.Location = new System.Drawing.Point(157, 10);
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
            this.labelX1.Location = new System.Drawing.Point(121, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 57;
            this.labelX1.Text = "學期";
            // 
            // nudSchoolYear
            // 
            this.nudSchoolYear.Location = new System.Drawing.Point(60, 10);
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
            this.nudSchoolYear.Size = new System.Drawing.Size(50, 25);
            this.nudSchoolYear.TabIndex = 56;
            this.nudSchoolYear.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.nudSchoolYear.ValueChanged += new System.EventHandler(this.nudSchoolYear_ValueChanged);
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
            this.labelX2.Location = new System.Drawing.Point(11, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 21);
            this.labelX2.TabIndex = 55;
            this.labelX2.Text = "學年度";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(260, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 729);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.GlobalItem = false;
            this.checkBoxItem1.Name = "checkBoxItem1";
            this.checkBoxItem1.Text = "請先選擇課程";
            // 
            // checkBoxItem2
            // 
            this.checkBoxItem2.GlobalItem = false;
            this.checkBoxItem2.Name = "checkBoxItem2";
            this.checkBoxItem2.Text = "請先選擇課程";
            // 
            // checkBoxItem3
            // 
            this.checkBoxItem3.GlobalItem = false;
            this.checkBoxItem3.Name = "checkBoxItem3";
            this.checkBoxItem3.Text = "請先選擇課程";
            // 
            // panel2
            // 
            this.panel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(261, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 105);
            this.panel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel2.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblPeriod);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txtMemo);
            this.groupPanel1.Controls.Add(this.txtCapacity);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(852, 105);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 23;
            this.groupPanel1.Text = "課程資訊";
            // 
            // lblPeriod
            // 
            this.lblPeriod.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPeriod.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPeriod.BackgroundStyle.BorderBottomWidth = 1;
            this.lblPeriod.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPeriod.BackgroundStyle.BorderLeftWidth = 1;
            this.lblPeriod.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPeriod.BackgroundStyle.BorderRightWidth = 1;
            this.lblPeriod.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPeriod.BackgroundStyle.BorderTopWidth = 1;
            this.lblPeriod.BackgroundStyle.Class = "";
            this.lblPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPeriod.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblPeriod.Location = new System.Drawing.Point(96, 43);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.SingleLineColor = System.Drawing.SystemColors.Desktop;
            this.lblPeriod.Size = new System.Drawing.Size(121, 20);
            this.lblPeriod.TabIndex = 17;
            this.lblPeriod.TextLineAlignment = System.Drawing.StringAlignment.Near;
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
            this.labelX5.Location = new System.Drawing.Point(30, 43);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 16;
            this.labelX5.Text = "調整階段";
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMemo.BackgroundStyle.Class = "";
            this.txtMemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMemo.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.txtMemo.Location = new System.Drawing.Point(301, 8);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.SingleLineColor = System.Drawing.SystemColors.Desktop;
            this.txtMemo.Size = new System.Drawing.Size(519, 63);
            this.txtMemo.TabIndex = 15;
            this.txtMemo.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.txtMemo.WordWrap = true;
            // 
            // txtCapacity
            // 
            this.txtCapacity.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txtCapacity.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCapacity.BackgroundStyle.BorderBottomWidth = 1;
            this.txtCapacity.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCapacity.BackgroundStyle.BorderLeftWidth = 1;
            this.txtCapacity.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCapacity.BackgroundStyle.BorderRightWidth = 1;
            this.txtCapacity.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCapacity.BackgroundStyle.BorderTopWidth = 1;
            this.txtCapacity.BackgroundStyle.Class = "";
            this.txtCapacity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCapacity.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.txtCapacity.Location = new System.Drawing.Point(96, 8);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.SingleLineColor = System.Drawing.SystemColors.Desktop;
            this.txtCapacity.Size = new System.Drawing.Size(121, 20);
            this.txtCapacity.TabIndex = 14;
            this.txtCapacity.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(235, 8);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 49);
            this.labelX4.TabIndex = 13;
            this.labelX4.Text = "備註";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelX4.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX4.WordWrap = true;
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
            this.labelX3.Location = new System.Drawing.Point(30, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "人數上限";
            // 
            // panel3
            // 
            this.panel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(261, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(852, 624);
            this.panel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel3.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel6.Controls.Add(this.groupPanel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 134);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(852, 490);
            this.panel6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel6.TabIndex = 1;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lnkReset);
            this.groupPanel3.Controls.Add(this.lblCapacityInfo);
            this.groupPanel3.Controls.Add(this.dgvData);
            this.groupPanel3.Controls.Add(this.chkShowLog);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(852, 490);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 9;
            this.groupPanel3.Text = "選課學生";
            // 
            // lnkReset
            // 
            this.lnkReset.AutoSize = true;
            this.lnkReset.Location = new System.Drawing.Point(30, 6);
            this.lnkReset.Name = "lnkReset";
            this.lnkReset.Size = new System.Drawing.Size(112, 17);
            this.lnkReset.TabIndex = 15;
            this.lnkReset.TabStop = true;
            this.lnkReset.Text = "重新設定條件優先";
            this.lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReset_LinkClicked);
            // 
            // lblCapacityInfo
            // 
            this.lblCapacityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapacityInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCapacityInfo.BackgroundStyle.Class = "";
            this.lblCapacityInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCapacityInfo.Location = new System.Drawing.Point(215, 4);
            this.lblCapacityInfo.Name = "lblCapacityInfo";
            this.lblCapacityInfo.Size = new System.Drawing.Size(416, 21);
            this.lblCapacityInfo.TabIndex = 14;
            this.lblCapacityInfo.Text = "優先人數：0　　選課人數：0";
            this.lblCapacityInfo.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lblEnrollYear,
            this.lblDeptName,
            this.lblClassName,
            this.lblStudentNumber,
            this.lblName,
            this.lblCSTime,
            this.lblItem,
            this.chkLock,
            this.lblStudentID,
            this.chkEvaluation,
            this.colPeriod1,
            this.colManual});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(30, 29);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(790, 383);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // lblEnrollYear
            // 
            this.lblEnrollYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblEnrollYear.HeaderText = "入學年度";
            this.lblEnrollYear.Name = "lblEnrollYear";
            this.lblEnrollYear.ReadOnly = true;
            this.lblEnrollYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblEnrollYear.Width = 85;
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblDeptName.HeaderText = "組別";
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.ReadOnly = true;
            this.lblDeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblDeptName.Width = 59;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblClassName.HeaderText = "班級";
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.ReadOnly = true;
            this.lblClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblClassName.Width = 59;
            // 
            // lblStudentNumber
            // 
            this.lblStudentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblStudentNumber.HeaderText = "學號";
            this.lblStudentNumber.Name = "lblStudentNumber";
            this.lblStudentNumber.ReadOnly = true;
            this.lblStudentNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblStudentNumber.Width = 59;
            // 
            // lblName
            // 
            this.lblName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblName.HeaderText = "姓名";
            this.lblName.Name = "lblName";
            this.lblName.ReadOnly = true;
            this.lblName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblName.Width = 59;
            // 
            // lblCSTime
            // 
            this.lblCSTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblCSTime.HeaderText = "選課時間";
            this.lblCSTime.MinimumWidth = 100;
            this.lblCSTime.Name = "lblCSTime";
            this.lblCSTime.ReadOnly = true;
            this.lblCSTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblItem
            // 
            this.lblItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lblItem.HeaderText = "選課階段";
            this.lblItem.Name = "lblItem";
            this.lblItem.ReadOnly = true;
            this.lblItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblItem.Width = 85;
            // 
            // chkLock
            // 
            this.chkLock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkLock.CheckValue = "N";
            this.chkLock.Enabled = false;
            this.chkLock.HeaderText = "條件優先";
            this.chkLock.Name = "chkLock";
            this.chkLock.ReadOnly = true;
            this.chkLock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkLock.Width = 85;
            // 
            // lblStudentID
            // 
            this.lblStudentID.HeaderText = "學生系統編號";
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.ReadOnly = true;
            this.lblStudentID.Visible = false;
            // 
            // chkEvaluation
            // 
            this.chkEvaluation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chkEvaluation.Checked = true;
            this.chkEvaluation.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkEvaluation.CheckValue = "N";
            this.chkEvaluation.Enabled = false;
            this.chkEvaluation.HeaderText = "選課優先";
            this.chkEvaluation.Name = "chkEvaluation";
            this.chkEvaluation.ReadOnly = true;
            this.chkEvaluation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkEvaluation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkEvaluation.Width = 85;
            // 
            // colPeriod1
            // 
            this.colPeriod1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPeriod1.Checked = true;
            this.colPeriod1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colPeriod1.CheckValue = "N";
            this.colPeriod1.Enabled = false;
            this.colPeriod1.HeaderText = "第一階段選上";
            this.colPeriod1.Name = "colPeriod1";
            this.colPeriod1.ReadOnly = true;
            this.colPeriod1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPeriod1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPeriod1.Width = 111;
            // 
            // colManual
            // 
            this.colManual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colManual.Checked = true;
            this.colManual.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colManual.CheckValue = "N";
            this.colManual.HeaderText = "手動優先";
            this.colManual.Name = "colManual";
            this.colManual.ReadOnly = true;
            this.colManual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colManual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colManual.Width = 85;
            // 
            // chkShowLog
            // 
            this.chkShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowLog.AutoSize = true;
            this.chkShowLog.BackColor = System.Drawing.Color.Transparent;
            this.chkShowLog.Location = new System.Drawing.Point(723, 4);
            this.chkShowLog.Name = "chkShowLog";
            this.chkShowLog.Size = new System.Drawing.Size(105, 21);
            this.chkShowLog.TabIndex = 0;
            this.chkShowLog.Text = "包含篩汰學生";
            this.chkShowLog.UseVisualStyleBackColor = false;
            this.chkShowLog.CheckedChanged += new System.EventHandler(this.chkShowLog_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel5.Controls.Add(this.groupPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(852, 134);
            this.panel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel5.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtFilter);
            this.groupPanel2.Controls.Add(this.btnConfirm);
            this.groupPanel2.Controls.Add(this.btnClear);
            this.groupPanel2.Controls.Add(this.btnClass);
            this.groupPanel2.Controls.Add(this.btnDept);
            this.groupPanel2.Controls.Add(this.btnSchoolYear);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(852, 134);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 22;
            this.groupPanel2.Text = "優先選取條件";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFilter.BackgroundStyle.Class = "";
            this.txtFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFilter.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.txtFilter.Location = new System.Drawing.Point(96, 4);
            this.txtFilter.MinimumSize = new System.Drawing.Size(500, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.SingleLineColor = System.Drawing.SystemColors.Desktop;
            this.txtFilter.Size = new System.Drawing.Size(654, 87);
            this.txtFilter.TabIndex = 44;
            this.txtFilter.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.txtFilter.WordWrap = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(756, 66);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(64, 25);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 43;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(756, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 25);
            this.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClass
            // 
            this.btnClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClass.AutoSize = true;
            this.btnClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClass.Location = new System.Drawing.Point(26, 66);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(64, 25);
            this.btnClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClass.TabIndex = 38;
            this.btnClass.Text = "班　　級";
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnDept
            // 
            this.btnDept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDept.AutoSize = true;
            this.btnDept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDept.Location = new System.Drawing.Point(26, 35);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(64, 25);
            this.btnDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDept.TabIndex = 37;
            this.btnDept.Text = "組　　別";
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // btnSchoolYear
            // 
            this.btnSchoolYear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchoolYear.AutoSize = true;
            this.btnSchoolYear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSchoolYear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSchoolYear.Location = new System.Drawing.Point(26, 4);
            this.btnSchoolYear.Name = "btnSchoolYear";
            this.btnSchoolYear.Size = new System.Drawing.Size(64, 25);
            this.btnSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSchoolYear.TabIndex = 36;
            this.btnSchoolYear.Text = "入學年度";
            this.btnSchoolYear.Click += new System.EventHandler(this.btnSchoolYear_Click);
            // 
            // panel4
            // 
            this.panel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel4.Controls.Add(this.labelX9);
            this.panel4.Controls.Add(this.labelX8);
            this.panel4.Controls.Add(this.labelX7);
            this.panel4.Controls.Add(this.labelX6);
            this.panel4.Controls.Add(this.btnManualFilter);
            this.panel4.Controls.Add(this.circularProgress);
            this.panel4.Controls.Add(this.btnFilter);
            this.panel4.Controls.Add(this.btnRecover);
            this.panel4.Controls.Add(this.btnAddManual);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(261, 681);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(852, 48);
            this.panel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel4.TabIndex = 5;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(59, 24);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(239, 20);
            this.labelX9.TabIndex = 29;
            this.labelX9.Text = "背景色為黃色者代表「手動加入學生」";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(59, 0);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(239, 20);
            this.labelX8.TabIndex = 28;
            this.labelX8.Text = "背景色為粉紅色者代表「篩汰學生」";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Yellow;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(33, 26);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(20, 20);
            this.labelX7.TabIndex = 27;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(33, 2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(20, 20);
            this.labelX6.TabIndex = 26;
            // 
            // btnManualFilter
            // 
            this.btnManualFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnManualFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualFilter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnManualFilter.Location = new System.Drawing.Point(337, 13);
            this.btnManualFilter.Name = "btnManualFilter";
            this.btnManualFilter.Size = new System.Drawing.Size(105, 23);
            this.btnManualFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnManualFilter.TabIndex = 25;
            this.btnManualFilter.Text = "手動篩汰學生";
            this.btnManualFilter.Click += new System.EventHandler(this.btnManualFilter_Click);
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
            this.circularProgress.Location = new System.Drawing.Point(285, 13);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(44, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 24;
            this.circularProgress.Visible = false;
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFilter.Location = new System.Drawing.Point(465, 13);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(105, 23);
            this.btnFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFilter.TabIndex = 23;
            this.btnFilter.Text = "自動篩汰學生";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecover.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRecover.Location = new System.Drawing.Point(592, 13);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(105, 23);
            this.btnRecover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRecover.TabIndex = 22;
            this.btnRecover.Text = "回復篩汰學生";
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnAddManual
            // 
            this.btnAddManual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddManual.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddManual.Location = new System.Drawing.Point(718, 13);
            this.btnAddManual.Name = "btnAddManual";
            this.btnAddManual.Size = new System.Drawing.Size(105, 23);
            this.btnAddManual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddManual.TabIndex = 21;
            this.btnAddManual.Text = "手動加入學生";
            this.btnAddManual.Click += new System.EventHandler(this.btnAddManual_Click);
            // 
            // frmFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1113, 729);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.expandablePanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HelpButton = true;
            this.Name = "frmFilter";
            this.Text = "選課學生調整";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.expandablePanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panSemester.ResumeLayout(false);
            this.panSemester.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchoolYear)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.PanelEx panSemester;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.PanelEx panel1;
        private System.Windows.Forms.ListBox lstCourse;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSemester;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.NumericUpDown nudSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem2;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem3;
        private DevComponents.DotNetBar.PanelEx panel2;
        private DevComponents.DotNetBar.PanelEx panel3;
        private DevComponents.DotNetBar.PanelEx panel4;
        private DevComponents.DotNetBar.PanelEx panel6;
        private DevComponents.DotNetBar.PanelEx panel5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX btnClass;
        private DevComponents.DotNetBar.ButtonX btnDept;
        private DevComponents.DotNetBar.ButtonX btnSchoolYear;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.ButtonX btnFilter;
        private DevComponents.DotNetBar.ButtonX btnRecover;
        private DevComponents.DotNetBar.ButtonX btnAddManual;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.LinkLabel lnkReset;
        private DevComponents.DotNetBar.LabelX lblCapacityInfo;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private System.Windows.Forms.CheckBox chkShowLog;
        private DevComponents.DotNetBar.LabelX txtCapacity;
        private DevComponents.DotNetBar.LabelX txtMemo;
        private DevComponents.DotNetBar.LabelX txtFilter;
        private DevComponents.DotNetBar.ButtonX btnManualFilter;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX lblPeriod;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblEnrollYear;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblDeptName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblStudentNumber;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblCSTime;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblItem;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn chkLock;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lblStudentID;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn chkEvaluation;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colPeriod1;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colManual;



    }
}