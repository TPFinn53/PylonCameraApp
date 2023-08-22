namespace PylonMultiCameraApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cameraSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.openSelectedButton1 = new System.Windows.Forms.Button();
            this.openBySerialNumberButton1 = new System.Windows.Forms.Button();
            this.openByUserIDButton1 = new System.Windows.Forms.Button();
            this.openByUserIDButton2 = new System.Windows.Forms.Button();
            this.openBySerialNumberButton2 = new System.Windows.Forms.Button();
            this.openSelectedButton2 = new System.Windows.Forms.Button();
            this.closeButton2 = new System.Windows.Forms.Button();
            this.closeButton1 = new System.Windows.Forms.Button();
            this.userIDTextBox1 = new System.Windows.Forms.TextBox();
            this.serialNumberTextBox2 = new System.Windows.Forms.TextBox();
            this.userIDTextBox2 = new System.Windows.Forms.TextBox();
            this.serialNumberTextBox1 = new System.Windows.Forms.TextBox();
            this.panelDeviceOpenCloseButtons = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.settingsPanel1 = new SettingsPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsPanel2 = new SettingsPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDeviceOpenCloseButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraSelectionComboBox
            // 
            this.cameraSelectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraSelectionComboBox.DropDownWidth = 556;
            this.cameraSelectionComboBox.FormattingEnabled = true;
            this.cameraSelectionComboBox.Location = new System.Drawing.Point(116, 3);
            this.cameraSelectionComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.cameraSelectionComboBox.MaxDropDownItems = 100;
            this.cameraSelectionComboBox.Name = "cameraSelectionComboBox";
            this.cameraSelectionComboBox.Size = new System.Drawing.Size(564, 21);
            this.cameraSelectionComboBox.TabIndex = 2;
            this.cameraSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.CameraSelectionSelectedIndexChanged);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(3, 2);
            this.scanButton.Margin = new System.Windows.Forms.Padding(2);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(109, 22);
            this.scanButton.TabIndex = 1;
            this.scanButton.Text = "Discover Cameras";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButtonClick);
            // 
            // openSelectedButton1
            // 
            this.openSelectedButton1.Location = new System.Drawing.Point(3, 2);
            this.openSelectedButton1.Margin = new System.Windows.Forms.Padding(2);
            this.openSelectedButton1.Name = "openSelectedButton1";
            this.openSelectedButton1.Size = new System.Drawing.Size(109, 22);
            this.openSelectedButton1.TabIndex = 3;
            this.openSelectedButton1.Text = "Open Selected";
            this.openSelectedButton1.UseVisualStyleBackColor = true;
            this.openSelectedButton1.Click += new System.EventHandler(this.OpenSelectedButton1Click);
            // 
            // openBySerialNumberButton1
            // 
            this.openBySerialNumberButton1.Enabled = false;
            this.openBySerialNumberButton1.Location = new System.Drawing.Point(116, 2);
            this.openBySerialNumberButton1.Margin = new System.Windows.Forms.Padding(2);
            this.openBySerialNumberButton1.Name = "openBySerialNumberButton1";
            this.openBySerialNumberButton1.Size = new System.Drawing.Size(106, 22);
            this.openBySerialNumberButton1.TabIndex = 4;
            this.openBySerialNumberButton1.Text = "Open By SN";
            this.openBySerialNumberButton1.UseVisualStyleBackColor = true;
            this.openBySerialNumberButton1.Click += new System.EventHandler(this.OpenBySerialNumberButton1Click);
            // 
            // openByUserIDButton1
            // 
            this.openByUserIDButton1.Enabled = false;
            this.openByUserIDButton1.Location = new System.Drawing.Point(226, 2);
            this.openByUserIDButton1.Margin = new System.Windows.Forms.Padding(2);
            this.openByUserIDButton1.Name = "openByUserIDButton1";
            this.openByUserIDButton1.Size = new System.Drawing.Size(109, 22);
            this.openByUserIDButton1.TabIndex = 5;
            this.openByUserIDButton1.Text = "Open By User ID";
            this.openByUserIDButton1.UseVisualStyleBackColor = true;
            this.openByUserIDButton1.Click += new System.EventHandler(this.OpenByUserIDButton1Click);
            // 
            // openByUserIDButton2
            // 
            this.openByUserIDButton2.Enabled = false;
            this.openByUserIDButton2.Location = new System.Drawing.Point(228, 2);
            this.openByUserIDButton2.Margin = new System.Windows.Forms.Padding(2);
            this.openByUserIDButton2.Name = "openByUserIDButton2";
            this.openByUserIDButton2.Size = new System.Drawing.Size(109, 22);
            this.openByUserIDButton2.TabIndex = 12;
            this.openByUserIDButton2.Text = "Open By User ID";
            this.openByUserIDButton2.UseVisualStyleBackColor = true;
            this.openByUserIDButton2.Click += new System.EventHandler(this.OpenByUserIDButton2Click);
            // 
            // openBySerialNumberButton2
            // 
            this.openBySerialNumberButton2.Enabled = false;
            this.openBySerialNumberButton2.Location = new System.Drawing.Point(116, 2);
            this.openBySerialNumberButton2.Margin = new System.Windows.Forms.Padding(2);
            this.openBySerialNumberButton2.Name = "openBySerialNumberButton2";
            this.openBySerialNumberButton2.Size = new System.Drawing.Size(109, 22);
            this.openBySerialNumberButton2.TabIndex = 11;
            this.openBySerialNumberButton2.Text = "Open By SN";
            this.openBySerialNumberButton2.UseVisualStyleBackColor = true;
            this.openBySerialNumberButton2.Click += new System.EventHandler(this.OpenBySerialNumberButton2Click);
            // 
            // openSelectedButton2
            // 
            this.openSelectedButton2.Location = new System.Drawing.Point(3, 2);
            this.openSelectedButton2.Margin = new System.Windows.Forms.Padding(2);
            this.openSelectedButton2.Name = "openSelectedButton2";
            this.openSelectedButton2.Size = new System.Drawing.Size(109, 22);
            this.openSelectedButton2.TabIndex = 10;
            this.openSelectedButton2.Text = "Open Selected";
            this.openSelectedButton2.UseVisualStyleBackColor = true;
            this.openSelectedButton2.Click += new System.EventHandler(this.OpenSelectedButton2Click);
            // 
            // closeButton2
            // 
            this.closeButton2.Location = new System.Drawing.Point(3, 28);
            this.closeButton2.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton2.Name = "closeButton2";
            this.closeButton2.Size = new System.Drawing.Size(109, 22);
            this.closeButton2.TabIndex = 13;
            this.closeButton2.Text = "Close";
            this.closeButton2.UseVisualStyleBackColor = true;
            this.closeButton2.Click += new System.EventHandler(this.CloseButton2Click);
            // 
            // closeButton1
            // 
            this.closeButton1.Location = new System.Drawing.Point(3, 28);
            this.closeButton1.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(109, 22);
            this.closeButton1.TabIndex = 6;
            this.closeButton1.Text = "Close";
            this.closeButton1.UseVisualStyleBackColor = true;
            this.closeButton1.Click += new System.EventHandler(this.CloseButton1Click);
            // 
            // userIDTextBox1
            // 
            this.userIDTextBox1.Location = new System.Drawing.Point(226, 29);
            this.userIDTextBox1.Name = "userIDTextBox1";
            this.userIDTextBox1.Size = new System.Drawing.Size(109, 20);
            this.userIDTextBox1.TabIndex = 8;
            this.userIDTextBox1.TextChanged += new System.EventHandler(this.UserIDTextBox1TextChanged);
            // 
            // serialNumberTextBox2
            // 
            this.serialNumberTextBox2.Location = new System.Drawing.Point(117, 29);
            this.serialNumberTextBox2.Name = "serialNumberTextBox2";
            this.serialNumberTextBox2.Size = new System.Drawing.Size(107, 20);
            this.serialNumberTextBox2.TabIndex = 14;
            this.serialNumberTextBox2.TextChanged += new System.EventHandler(this.SerialNumberTextBox2TextChanged);
            // 
            // userIDTextBox2
            // 
            this.userIDTextBox2.Location = new System.Drawing.Point(229, 29);
            this.userIDTextBox2.Name = "userIDTextBox2";
            this.userIDTextBox2.Size = new System.Drawing.Size(107, 20);
            this.userIDTextBox2.TabIndex = 15;
            this.userIDTextBox2.TextChanged += new System.EventHandler(this.UserIDTextBox2TextChanged);
            // 
            // serialNumberTextBox1
            // 
            this.serialNumberTextBox1.Location = new System.Drawing.Point(116, 29);
            this.serialNumberTextBox1.Name = "serialNumberTextBox1";
            this.serialNumberTextBox1.Size = new System.Drawing.Size(105, 20);
            this.serialNumberTextBox1.TabIndex = 7;
            this.serialNumberTextBox1.TextChanged += new System.EventHandler(this.SerialNumberTextBox1TextChanged);
            // 
            // panelDeviceOpenCloseButtons
            // 
            this.panelDeviceOpenCloseButtons.Controls.Add(this.scanButton);
            this.panelDeviceOpenCloseButtons.Controls.Add(this.cameraSelectionComboBox);
            this.panelDeviceOpenCloseButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDeviceOpenCloseButtons.Location = new System.Drawing.Point(0, 0);
            this.panelDeviceOpenCloseButtons.Name = "panelDeviceOpenCloseButtons";
            this.panelDeviceOpenCloseButtons.Size = new System.Drawing.Size(684, 29);
            this.panelDeviceOpenCloseButtons.TabIndex = 17;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 29);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.settingsPanel1);
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.settingsPanel2);
            this.splitContainer.Panel2.Controls.Add(this.panel2);
            this.splitContainer.Size = new System.Drawing.Size(684, 682);
            this.splitContainer.SplitterDistance = 340;
            this.splitContainer.TabIndex = 18;
            // 
            // settingsPanel1
            // 
            this.settingsPanel1.AutoSize = true;
            this.settingsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel1.Location = new System.Drawing.Point(0, 55);
            this.settingsPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPanel1.Name = "settingsPanel1";
            this.settingsPanel1.Size = new System.Drawing.Size(340, 627);
            this.settingsPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openBySerialNumberButton1);
            this.panel1.Controls.Add(this.serialNumberTextBox1);
            this.panel1.Controls.Add(this.closeButton1);
            this.panel1.Controls.Add(this.openByUserIDButton1);
            this.panel1.Controls.Add(this.userIDTextBox1);
            this.panel1.Controls.Add(this.openSelectedButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 55);
            this.panel1.TabIndex = 0;
            // 
            // settingsPanel2
            // 
            this.settingsPanel2.AutoSize = true;
            this.settingsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel2.Location = new System.Drawing.Point(0, 55);
            this.settingsPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPanel2.Name = "settingsPanel2";
            this.settingsPanel2.Size = new System.Drawing.Size(340, 627);
            this.settingsPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.openBySerialNumberButton2);
            this.panel2.Controls.Add(this.openSelectedButton2);
            this.panel2.Controls.Add(this.userIDTextBox2);
            this.panel2.Controls.Add(this.closeButton2);
            this.panel2.Controls.Add(this.serialNumberTextBox2);
            this.panel2.Controls.Add(this.openByUserIDButton2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 55);
            this.panel2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 711);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelDeviceOpenCloseButtons);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "MainForm";
            this.Text = "Pylon Multiple Camera Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.panelDeviceOpenCloseButtons.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cameraSelectionComboBox;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button openSelectedButton1;
        private System.Windows.Forms.Button openBySerialNumberButton1;
        private System.Windows.Forms.Button openByUserIDButton1;
        private System.Windows.Forms.Button openByUserIDButton2;
        private System.Windows.Forms.Button openBySerialNumberButton2;
        private System.Windows.Forms.Button openSelectedButton2;
        private System.Windows.Forms.Button closeButton2;
        private System.Windows.Forms.Button closeButton1;
        private System.Windows.Forms.TextBox userIDTextBox1;
        private System.Windows.Forms.TextBox serialNumberTextBox2;
        private System.Windows.Forms.TextBox userIDTextBox2;
        private System.Windows.Forms.TextBox serialNumberTextBox1;
        private System.Windows.Forms.Panel panelDeviceOpenCloseButtons;
        private System.Windows.Forms.SplitContainer splitContainer;
        private SettingsPanel settingsPanel1;
        private System.Windows.Forms.Panel panel1;
        private SettingsPanel settingsPanel2;
        private System.Windows.Forms.Panel panel2;
    }
}

