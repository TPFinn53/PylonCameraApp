namespace PylonCameraApp
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userIDTextBox1 = new System.Windows.Forms.TextBox();
            this.serialNumberTextBox1 = new System.Windows.Forms.TextBox();
            this.closeButton1 = new System.Windows.Forms.Button();
            this.openByUserIDButton1 = new System.Windows.Forms.Button();
            this.openBySerialNumberButton1 = new System.Windows.Forms.Button();
            this.openSelectedButton1 = new System.Windows.Forms.Button();
            this.panelDeviceOpenCloseButtons = new System.Windows.Forms.Panel();
            this.cameraSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquisitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acquisitionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsPanel1 = new PylonCameraApp.SettingsPanel();
            this.calibrationUserControl1 = new PylonCameraApp.CalibrationUserControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDeviceOpenCloseButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.settingsPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panelDeviceOpenCloseButtons);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.calibrationUserControl1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userIDTextBox1);
            this.panel1.Controls.Add(this.serialNumberTextBox1);
            this.panel1.Controls.Add(this.closeButton1);
            this.panel1.Controls.Add(this.openByUserIDButton1);
            this.panel1.Controls.Add(this.openBySerialNumberButton1);
            this.panel1.Controls.Add(this.openSelectedButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 55);
            this.panel1.TabIndex = 1;
            // 
            // userIDTextBox1
            // 
            this.userIDTextBox1.Location = new System.Drawing.Point(226, 29);
            this.userIDTextBox1.Name = "userIDTextBox1";
            this.userIDTextBox1.Size = new System.Drawing.Size(109, 20);
            this.userIDTextBox1.TabIndex = 5;
            // 
            // serialNumberTextBox1
            // 
            this.serialNumberTextBox1.Location = new System.Drawing.Point(116, 29);
            this.serialNumberTextBox1.Name = "serialNumberTextBox1";
            this.serialNumberTextBox1.Size = new System.Drawing.Size(105, 20);
            this.serialNumberTextBox1.TabIndex = 4;
            // 
            // closeButton1
            // 
            this.closeButton1.Location = new System.Drawing.Point(3, 28);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(109, 22);
            this.closeButton1.TabIndex = 3;
            this.closeButton1.Text = "Close";
            this.closeButton1.UseVisualStyleBackColor = true;
            this.closeButton1.Click += new System.EventHandler(this.CloseButton1Click);
            // 
            // openByUserIDButton1
            // 
            this.openByUserIDButton1.Location = new System.Drawing.Point(226, 2);
            this.openByUserIDButton1.Name = "openByUserIDButton1";
            this.openByUserIDButton1.Size = new System.Drawing.Size(109, 22);
            this.openByUserIDButton1.TabIndex = 2;
            this.openByUserIDButton1.Text = "Open By User ID";
            this.openByUserIDButton1.UseVisualStyleBackColor = true;
            this.openByUserIDButton1.Click += new System.EventHandler(this.OpenByUserIDButton1Click);
            // 
            // openBySerialNumberButton1
            // 
            this.openBySerialNumberButton1.Location = new System.Drawing.Point(116, 2);
            this.openBySerialNumberButton1.Name = "openBySerialNumberButton1";
            this.openBySerialNumberButton1.Size = new System.Drawing.Size(106, 22);
            this.openBySerialNumberButton1.TabIndex = 1;
            this.openBySerialNumberButton1.Text = "Open By SN";
            this.openBySerialNumberButton1.UseVisualStyleBackColor = true;
            this.openBySerialNumberButton1.Click += new System.EventHandler(this.OpenBySerialNumberButton1Click);
            // 
            // openSelectedButton1
            // 
            this.openSelectedButton1.Location = new System.Drawing.Point(3, 2);
            this.openSelectedButton1.Name = "openSelectedButton1";
            this.openSelectedButton1.Size = new System.Drawing.Size(109, 22);
            this.openSelectedButton1.TabIndex = 0;
            this.openSelectedButton1.Text = "Open Selected";
            this.openSelectedButton1.UseVisualStyleBackColor = true;
            this.openSelectedButton1.Click += new System.EventHandler(this.OpenSelectedButton1Click);
            // 
            // panelDeviceOpenCloseButtons
            // 
            this.panelDeviceOpenCloseButtons.Controls.Add(this.cameraSelectionComboBox);
            this.panelDeviceOpenCloseButtons.Controls.Add(this.scanButton);
            this.panelDeviceOpenCloseButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDeviceOpenCloseButtons.Location = new System.Drawing.Point(0, 0);
            this.panelDeviceOpenCloseButtons.Name = "panelDeviceOpenCloseButtons";
            this.panelDeviceOpenCloseButtons.Size = new System.Drawing.Size(337, 30);
            this.panelDeviceOpenCloseButtons.TabIndex = 0;
            // 
            // cameraSelectionComboBox
            // 
            this.cameraSelectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraSelectionComboBox.FormattingEnabled = true;
            this.cameraSelectionComboBox.Location = new System.Drawing.Point(115, 5);
            this.cameraSelectionComboBox.Name = "cameraSelectionComboBox";
            this.cameraSelectionComboBox.Size = new System.Drawing.Size(219, 21);
            this.cameraSelectionComboBox.TabIndex = 1;
            this.cameraSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.CameraSelectionSelectedIndexChanged);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(3, 3);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(106, 23);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Discover Cameras";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButtonClick);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrationToolStripMenuItem,
            this.alignmentToolStripMenuItem,
            this.acquisitionToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.calibrationToolStripMenuItem.Text = "Calibration";
            this.calibrationToolStripMenuItem.Click += new System.EventHandler(this.calibrationToolStripMenuItem_Click);
            // 
            // alignmentToolStripMenuItem
            // 
            this.alignmentToolStripMenuItem.Name = "alignmentToolStripMenuItem";
            this.alignmentToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.alignmentToolStripMenuItem.Text = "Alignment";
            // 
            // acquisitionToolStripMenuItem
            // 
            this.acquisitionToolStripMenuItem.Name = "acquisitionToolStripMenuItem";
            this.acquisitionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.acquisitionToolStripMenuItem.Text = "Acquisition";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrationToolStripMenuItem1,
            this.alignmentToolStripMenuItem1,
            this.acquisitionToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // calibrationToolStripMenuItem1
            // 
            this.calibrationToolStripMenuItem1.Name = "calibrationToolStripMenuItem1";
            this.calibrationToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.calibrationToolStripMenuItem1.Text = "Calibration";
            // 
            // alignmentToolStripMenuItem1
            // 
            this.alignmentToolStripMenuItem1.Name = "alignmentToolStripMenuItem1";
            this.alignmentToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.alignmentToolStripMenuItem1.Text = "Alignment";
            // 
            // acquisitionToolStripMenuItem1
            // 
            this.acquisitionToolStripMenuItem1.Name = "acquisitionToolStripMenuItem1";
            this.acquisitionToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.acquisitionToolStripMenuItem1.Text = "Acquisition";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // settingsPanel1
            // 
            this.settingsPanel1.AutoSize = true;
            this.settingsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel1.Location = new System.Drawing.Point(0, 85);
            this.settingsPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPanel1.Name = "settingsPanel1";
            this.settingsPanel1.Size = new System.Drawing.Size(337, 315);
            this.settingsPanel1.TabIndex = 2;
            // 
            // calibrationUserControl1
            // 
            this.calibrationUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationUserControl1.Location = new System.Drawing.Point(0, 0);
            this.calibrationUserControl1.Name = "calibrationUserControl1";
            this.calibrationUserControl1.Size = new System.Drawing.Size(451, 400);
            this.calibrationUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pylon Camera Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDeviceOpenCloseButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelDeviceOpenCloseButtons;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.ComboBox cameraSelectionComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox userIDTextBox1;
        private System.Windows.Forms.TextBox serialNumberTextBox1;
        private System.Windows.Forms.Button closeButton1;
        private System.Windows.Forms.Button openByUserIDButton1;
        private System.Windows.Forms.Button openBySerialNumberButton1;
        private System.Windows.Forms.Button openSelectedButton1;
        private SettingsPanel settingsPanel1;
        private CalibrationUserControl calibrationUserControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acquisitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alignmentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acquisitionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

