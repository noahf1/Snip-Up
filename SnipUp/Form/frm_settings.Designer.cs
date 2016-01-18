namespace SnipUp
{
    partial class frm_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnChoosePath = new System.Windows.Forms.Button();
            this.txtHotkeyDefined = new System.Windows.Forms.TextBox();
            this.lablHotkeyDefined = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHotkeyActive = new System.Windows.Forms.TextBox();
            this.lablHotkeyActive = new System.Windows.Forms.Label();
            this.txtHotkeyFull = new System.Windows.Forms.TextBox();
            this.lablHotkeyFull = new System.Windows.Forms.Label();
            this.chkBxSaveLocal = new System.Windows.Forms.CheckBox();
            this.chkBxAutoStart = new System.Windows.Forms.CheckBox();
            this.chkBxExplorerContextMenu = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBxPopups = new System.Windows.Forms.CheckBox();
            this.listViewData = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnCopyLink = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(18, 137);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(155, 20);
            this.txtSavePath.TabIndex = 0;
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Enabled = false;
            this.btnChoosePath.Location = new System.Drawing.Point(190, 135);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(25, 23);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "...";
            this.btnChoosePath.UseVisualStyleBackColor = true;
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // txtHotkeyDefined
            // 
            this.txtHotkeyDefined.Location = new System.Drawing.Point(25, 42);
            this.txtHotkeyDefined.Name = "txtHotkeyDefined";
            this.txtHotkeyDefined.Size = new System.Drawing.Size(119, 20);
            this.txtHotkeyDefined.TabIndex = 2;
            this.txtHotkeyDefined.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkeyScreen_KeyDown);
            // 
            // lablHotkeyDefined
            // 
            this.lablHotkeyDefined.AutoSize = true;
            this.lablHotkeyDefined.Location = new System.Drawing.Point(22, 26);
            this.lablHotkeyDefined.Name = "lablHotkeyDefined";
            this.lablHotkeyDefined.Size = new System.Drawing.Size(112, 13);
            this.lablHotkeyDefined.TabIndex = 3;
            this.lablHotkeyDefined.Text = "Capture Defined Area:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHotkeyActive);
            this.groupBox1.Controls.Add(this.lablHotkeyActive);
            this.groupBox1.Controls.Add(this.txtHotkeyFull);
            this.groupBox1.Controls.Add(this.lablHotkeyFull);
            this.groupBox1.Controls.Add(this.lablHotkeyDefined);
            this.groupBox1.Controls.Add(this.txtHotkeyDefined);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 174);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtHotkeyActive
            // 
            this.txtHotkeyActive.Location = new System.Drawing.Point(25, 142);
            this.txtHotkeyActive.Name = "txtHotkeyActive";
            this.txtHotkeyActive.Size = new System.Drawing.Size(119, 20);
            this.txtHotkeyActive.TabIndex = 7;
            this.txtHotkeyActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkeyActive_KeyDown);
            // 
            // lablHotkeyActive
            // 
            this.lablHotkeyActive.AutoSize = true;
            this.lablHotkeyActive.Location = new System.Drawing.Point(22, 126);
            this.lablHotkeyActive.Name = "lablHotkeyActive";
            this.lablHotkeyActive.Size = new System.Drawing.Size(122, 13);
            this.lablHotkeyActive.TabIndex = 6;
            this.lablHotkeyActive.Text = "Capture Active Window:";
            // 
            // txtHotkeyFull
            // 
            this.txtHotkeyFull.Location = new System.Drawing.Point(25, 92);
            this.txtHotkeyFull.Name = "txtHotkeyFull";
            this.txtHotkeyFull.Size = new System.Drawing.Size(119, 20);
            this.txtHotkeyFull.TabIndex = 5;
            this.txtHotkeyFull.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkeyFullScreen_KeyDown);
            // 
            // lablHotkeyFull
            // 
            this.lablHotkeyFull.AutoSize = true;
            this.lablHotkeyFull.Location = new System.Drawing.Point(22, 76);
            this.lablHotkeyFull.Name = "lablHotkeyFull";
            this.lablHotkeyFull.Size = new System.Drawing.Size(98, 13);
            this.lablHotkeyFull.TabIndex = 4;
            this.lablHotkeyFull.Text = "Capture Fullscreen:";
            // 
            // chkBxSaveLocal
            // 
            this.chkBxSaveLocal.AutoSize = true;
            this.chkBxSaveLocal.Location = new System.Drawing.Point(18, 111);
            this.chkBxSaveLocal.Name = "chkBxSaveLocal";
            this.chkBxSaveLocal.Size = new System.Drawing.Size(108, 17);
            this.chkBxSaveLocal.TabIndex = 5;
            this.chkBxSaveLocal.Text = "Save Image local";
            this.chkBxSaveLocal.UseVisualStyleBackColor = true;
            this.chkBxSaveLocal.CheckedChanged += new System.EventHandler(this.chkBxSaveLocal_CheckedChanged);
            // 
            // chkBxAutoStart
            // 
            this.chkBxAutoStart.AutoSize = true;
            this.chkBxAutoStart.Enabled = false;
            this.chkBxAutoStart.Location = new System.Drawing.Point(18, 26);
            this.chkBxAutoStart.Name = "chkBxAutoStart";
            this.chkBxAutoStart.Size = new System.Drawing.Size(127, 17);
            this.chkBxAutoStart.TabIndex = 6;
            this.chkBxAutoStart.Text = "Run when PC started";
            this.chkBxAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkBxExplorerContextMenu
            // 
            this.chkBxExplorerContextMenu.AutoSize = true;
            this.chkBxExplorerContextMenu.Enabled = false;
            this.chkBxExplorerContextMenu.Location = new System.Drawing.Point(18, 55);
            this.chkBxExplorerContextMenu.Name = "chkBxExplorerContextMenu";
            this.chkBxExplorerContextMenu.Size = new System.Drawing.Size(155, 17);
            this.chkBxExplorerContextMenu.TabIndex = 7;
            this.chkBxExplorerContextMenu.Text = "Add Explorer Context Menu";
            this.chkBxExplorerContextMenu.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBxPopups);
            this.groupBox2.Controls.Add(this.chkBxExplorerContextMenu);
            this.groupBox2.Controls.Add(this.btnChoosePath);
            this.groupBox2.Controls.Add(this.chkBxSaveLocal);
            this.groupBox2.Controls.Add(this.txtSavePath);
            this.groupBox2.Controls.Add(this.chkBxAutoStart);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 181);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // chkBxPopups
            // 
            this.chkBxPopups.AutoSize = true;
            this.chkBxPopups.Location = new System.Drawing.Point(18, 83);
            this.chkBxPopups.Name = "chkBxPopups";
            this.chkBxPopups.Size = new System.Drawing.Size(62, 17);
            this.chkBxPopups.TabIndex = 8;
            this.chkBxPopups.Text = "Popups";
            this.chkBxPopups.UseVisualStyleBackColor = true;
            // 
            // listViewData
            // 
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colLink});
            this.listViewData.FullRowSelect = true;
            this.listViewData.Location = new System.Drawing.Point(22, 20);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(264, 143);
            this.listViewData.TabIndex = 10;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date:";
            this.colDate.Width = 80;
            // 
            // colLink
            // 
            this.colLink.Text = "Link:";
            this.colLink.Width = 180;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(314, 236);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(306, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(306, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hotkey";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnClearLog);
            this.tabPage3.Controls.Add(this.btnCopyLink);
            this.tabPage3.Controls.Add(this.listViewData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(306, 210);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "UploadLog";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(227, 175);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(59, 23);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnCopyLink
            // 
            this.btnCopyLink.Location = new System.Drawing.Point(22, 175);
            this.btnCopyLink.Name = "btnCopyLink";
            this.btnCopyLink.Size = new System.Drawing.Size(59, 23);
            this.btnCopyLink.TabIndex = 11;
            this.btnCopyLink.Text = "Copy";
            this.btnCopyLink.UseVisualStyleBackColor = true;
            this.btnCopyLink.Click += new System.EventHandler(this.btnCopyLink_Click);
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 260);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_settings";
            this.Text = "SnipUp - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_settings_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnChoosePath;
        private System.Windows.Forms.TextBox txtHotkeyDefined;
        private System.Windows.Forms.Label lablHotkeyDefined;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lablHotkeyFull;
        private System.Windows.Forms.TextBox txtHotkeyFull;
        private System.Windows.Forms.CheckBox chkBxSaveLocal;
        private System.Windows.Forms.CheckBox chkBxAutoStart;
        private System.Windows.Forms.CheckBox chkBxExplorerContextMenu;
        private System.Windows.Forms.TextBox txtHotkeyActive;
        private System.Windows.Forms.Label lablHotkeyActive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkBxPopups;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colLink;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCopyLink;
        private System.Windows.Forms.Button btnClearLog;
    }
}