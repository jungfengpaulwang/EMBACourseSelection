namespace CourseSelection.Forms
{
    partial class frmListViewContainer
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
            this.lstCheckLists = new System.Windows.Forms.ListView();
            this.Sure = new DevComponents.DotNetBar.ButtonX();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lstCheckLists
            // 
            this.lstCheckLists.CheckBoxes = true;
            this.lstCheckLists.Location = new System.Drawing.Point(30, 25);
            this.lstCheckLists.Name = "lstCheckLists";
            this.lstCheckLists.Size = new System.Drawing.Size(344, 192);
            this.lstCheckLists.TabIndex = 0;
            this.lstCheckLists.UseCompatibleStateImageBehavior = false;
            this.lstCheckLists.View = System.Windows.Forms.View.List;
            // 
            // Sure
            // 
            this.Sure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Sure.BackColor = System.Drawing.Color.Transparent;
            this.Sure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Sure.Location = new System.Drawing.Point(245, 227);
            this.Sure.Name = "Sure";
            this.Sure.Size = new System.Drawing.Size(54, 23);
            this.Sure.TabIndex = 70;
            this.Sure.Text = "確定";
            this.Sure.Click += new System.EventHandler(this.Sure_Click);
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(320, 227);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(54, 23);
            this.Exit.TabIndex = 69;
            this.Exit.Text = "離開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // frmListViewContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 257);
            this.Controls.Add(this.Sure);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.lstCheckLists);
            this.DoubleBuffered = true;
            this.Name = "frmListViewContainer";
            this.Text = "frmListViewContainer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstCheckLists;
        private DevComponents.DotNetBar.ButtonX Sure;
        private DevComponents.DotNetBar.ButtonX Exit;
    }
}