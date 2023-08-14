namespace PylonCameraApp
{
    partial class SettingsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.softwareTriggerExecuteButton = new System.Windows.Forms.Button();
            this.softwareTriggerLabel = new System.Windows.Forms.Label();
            this.pixelFormatLabel = new System.Windows.Forms.Label();
            this.triggerModeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelGain = new System.Windows.Forms.TableLayoutPanel();
            this.gainValueLabel = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.triggerSourceLabel = new System.Windows.Forms.Label();
            this.invertPixelFormatCheckbox = new System.Windows.Forms.CheckBox();
            this.exposureControl = new PylonCameraApp.ParameterSliderUserControl();
            this.gainControl = new PylonCameraApp.ParameterSliderUserControl();
            this.triggerModeControl = new PylonCameraApp.EnumerationComboBoxUserControl();
            this.triggerSourceControl = new PylonCameraApp.EnumerationComboBoxUserControl();
            this.tableLayoutPanelExposureTime = new System.Windows.Forms.TableLayoutPanel();
            this.exposureTimeValueLabel = new System.Windows.Forms.Label();
            this.exposureTimeLabel = new System.Windows.Forms.Label();
            this.invertPixelLabel = new System.Windows.Forms.Label();
            this.pixelFormatControl = new PylonCameraApp.EnumerationComboBoxUserControl();
            this.panelForButtons = new System.Windows.Forms.Panel();
            this.singleShotButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.continuousShotButton = new System.Windows.Forms.Button();
            this.pictureWindow = new PylonCameraApp.PictureWindow();
            this.label1 = new System.Windows.Forms.Label();
            this.testPatternControl = new PylonCameraApp.EnumerationComboBoxUserControl();
            this.settingsTableLayout.SuspendLayout();
            this.tableLayoutPanelGain.SuspendLayout();
            this.tableLayoutPanelExposureTime.SuspendLayout();
            this.panelForButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTableLayout
            // 
            this.settingsTableLayout.ColumnCount = 2;
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingsTableLayout.Controls.Add(this.softwareTriggerExecuteButton, 1, 6);
            this.settingsTableLayout.Controls.Add(this.softwareTriggerLabel, 0, 6);
            this.settingsTableLayout.Controls.Add(this.pixelFormatLabel, 0, 3);
            this.settingsTableLayout.Controls.Add(this.triggerModeLabel, 0, 4);
            this.settingsTableLayout.Controls.Add(this.tableLayoutPanelGain, 0, 2);
            this.settingsTableLayout.Controls.Add(this.triggerSourceLabel, 0, 5);
            this.settingsTableLayout.Controls.Add(this.invertPixelFormatCheckbox, 1, 7);
            this.settingsTableLayout.Controls.Add(this.exposureControl, 1, 1);
            this.settingsTableLayout.Controls.Add(this.gainControl, 1, 2);
            this.settingsTableLayout.Controls.Add(this.triggerModeControl, 1, 4);
            this.settingsTableLayout.Controls.Add(this.triggerSourceControl, 1, 5);
            this.settingsTableLayout.Controls.Add(this.tableLayoutPanelExposureTime, 0, 1);
            this.settingsTableLayout.Controls.Add(this.invertPixelLabel, 0, 7);
            this.settingsTableLayout.Controls.Add(this.pixelFormatControl, 1, 3);
            this.settingsTableLayout.Controls.Add(this.panelForButtons, 0, 0);
            this.settingsTableLayout.Controls.Add(this.label1, 0, 8);
            this.settingsTableLayout.Controls.Add(this.testPatternControl, 1, 8);
            this.settingsTableLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsTableLayout.Location = new System.Drawing.Point(0, 350);
            this.settingsTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.settingsTableLayout.Name = "settingsTableLayout";
            this.settingsTableLayout.RowCount = 9;
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.settingsTableLayout.Size = new System.Drawing.Size(340, 268);
            this.settingsTableLayout.TabIndex = 28;
            // 
            // softwareTriggerExecuteButton
            // 
            this.softwareTriggerExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.softwareTriggerExecuteButton.Location = new System.Drawing.Point(143, 183);
            this.softwareTriggerExecuteButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.softwareTriggerExecuteButton.Name = "softwareTriggerExecuteButton";
            this.softwareTriggerExecuteButton.Size = new System.Drawing.Size(197, 23);
            this.softwareTriggerExecuteButton.TabIndex = 15;
            this.softwareTriggerExecuteButton.Text = "Execute";
            this.softwareTriggerExecuteButton.UseVisualStyleBackColor = true;
            this.softwareTriggerExecuteButton.Click += new System.EventHandler(this.SoftwareTriggerExecuteClick);
            // 
            // softwareTriggerLabel
            // 
            this.softwareTriggerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.softwareTriggerLabel.AutoSize = true;
            this.softwareTriggerLabel.Location = new System.Drawing.Point(0, 188);
            this.softwareTriggerLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.softwareTriggerLabel.Name = "softwareTriggerLabel";
            this.softwareTriggerLabel.Size = new System.Drawing.Size(85, 13);
            this.softwareTriggerLabel.TabIndex = 9;
            this.softwareTriggerLabel.Text = "Software Trigger";
            // 
            // pixelFormatLabel
            // 
            this.pixelFormatLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pixelFormatLabel.AutoSize = true;
            this.pixelFormatLabel.Location = new System.Drawing.Point(0, 98);
            this.pixelFormatLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pixelFormatLabel.Name = "pixelFormatLabel";
            this.pixelFormatLabel.Size = new System.Drawing.Size(64, 13);
            this.pixelFormatLabel.TabIndex = 10;
            this.pixelFormatLabel.Text = "Pixel Format";
            // 
            // triggerModeLabel
            // 
            this.triggerModeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.triggerModeLabel.AutoSize = true;
            this.triggerModeLabel.Location = new System.Drawing.Point(0, 128);
            this.triggerModeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.triggerModeLabel.Name = "triggerModeLabel";
            this.triggerModeLabel.Size = new System.Drawing.Size(97, 13);
            this.triggerModeLabel.TabIndex = 15;
            this.triggerModeLabel.Text = "Frame Start Trigger\r\n";
            // 
            // tableLayoutPanelGain
            // 
            this.tableLayoutPanelGain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelGain.ColumnCount = 1;
            this.tableLayoutPanelGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGain.Controls.Add(this.gainValueLabel, 0, 1);
            this.tableLayoutPanelGain.Controls.Add(this.gainLabel, 0, 0);
            this.tableLayoutPanelGain.Location = new System.Drawing.Point(0, 63);
            this.tableLayoutPanelGain.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanelGain.Name = "tableLayoutPanelGain";
            this.tableLayoutPanelGain.RowCount = 2;
            this.tableLayoutPanelGain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGain.Size = new System.Drawing.Size(106, 24);
            this.tableLayoutPanelGain.TabIndex = 17;
            // 
            // gainValueLabel
            // 
            this.gainValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gainValueLabel.AutoSize = true;
            this.gainValueLabel.Location = new System.Drawing.Point(3, 12);
            this.gainValueLabel.Name = "gainValueLabel";
            this.gainValueLabel.Size = new System.Drawing.Size(13, 12);
            this.gainValueLabel.TabIndex = 15;
            this.gainValueLabel.Text = "0";
            // 
            // gainLabel
            // 
            this.gainLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(3, 0);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(29, 12);
            this.gainLabel.TabIndex = 15;
            this.gainLabel.Text = "Gain";
            // 
            // triggerSourceLabel
            // 
            this.triggerSourceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.triggerSourceLabel.AutoSize = true;
            this.triggerSourceLabel.Location = new System.Drawing.Point(0, 158);
            this.triggerSourceLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.triggerSourceLabel.Name = "triggerSourceLabel";
            this.triggerSourceLabel.Size = new System.Drawing.Size(77, 13);
            this.triggerSourceLabel.TabIndex = 16;
            this.triggerSourceLabel.Text = "Trigger Source";
            // 
            // invertPixelFormatCheckbox
            // 
            this.invertPixelFormatCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.invertPixelFormatCheckbox.AutoSize = true;
            this.invertPixelFormatCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invertPixelFormatCheckbox.Location = new System.Drawing.Point(143, 216);
            this.invertPixelFormatCheckbox.Name = "invertPixelFormatCheckbox";
            this.invertPixelFormatCheckbox.Size = new System.Drawing.Size(59, 17);
            this.invertPixelFormatCheckbox.TabIndex = 16;
            this.invertPixelFormatCheckbox.Text = "Enable";
            this.invertPixelFormatCheckbox.UseVisualStyleBackColor = true;
            this.invertPixelFormatCheckbox.CheckedChanged += new System.EventHandler(this.InvertPixelCheckBoxChanged);
            // 
            // exposureControl
            // 
            this.exposureControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.exposureControl.Location = new System.Drawing.Point(142, 32);
            this.exposureControl.Logarithmic = false;
            this.exposureControl.Margin = new System.Windows.Forms.Padding(2);
            this.exposureControl.Name = "exposureControl";
            this.exposureControl.Size = new System.Drawing.Size(196, 26);
            this.exposureControl.TabIndex = 10;
            // 
            // gainControl
            // 
            this.gainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gainControl.Location = new System.Drawing.Point(142, 62);
            this.gainControl.Logarithmic = false;
            this.gainControl.Margin = new System.Windows.Forms.Padding(2);
            this.gainControl.Name = "gainControl";
            this.gainControl.Size = new System.Drawing.Size(196, 26);
            this.gainControl.TabIndex = 11;
            // 
            // triggerModeControl
            // 
            this.triggerModeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerModeControl.DefaultName = "N/A";
            this.triggerModeControl.Location = new System.Drawing.Point(142, 124);
            this.triggerModeControl.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.triggerModeControl.Name = "triggerModeControl";
            this.triggerModeControl.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.triggerModeControl.Size = new System.Drawing.Size(198, 21);
            this.triggerModeControl.TabIndex = 13;
            // 
            // triggerSourceControl
            // 
            this.triggerSourceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerSourceControl.DefaultName = "N/A";
            this.triggerSourceControl.Location = new System.Drawing.Point(142, 154);
            this.triggerSourceControl.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.triggerSourceControl.Name = "triggerSourceControl";
            this.triggerSourceControl.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.triggerSourceControl.Size = new System.Drawing.Size(198, 21);
            this.triggerSourceControl.TabIndex = 14;
            // 
            // tableLayoutPanelExposureTime
            // 
            this.tableLayoutPanelExposureTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelExposureTime.ColumnCount = 1;
            this.tableLayoutPanelExposureTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExposureTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExposureTime.Controls.Add(this.exposureTimeValueLabel, 0, 1);
            this.tableLayoutPanelExposureTime.Controls.Add(this.exposureTimeLabel, 0, 0);
            this.tableLayoutPanelExposureTime.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanelExposureTime.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanelExposureTime.Name = "tableLayoutPanelExposureTime";
            this.tableLayoutPanelExposureTime.RowCount = 2;
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelExposureTime.Size = new System.Drawing.Size(106, 24);
            this.tableLayoutPanelExposureTime.TabIndex = 18;
            // 
            // exposureTimeValueLabel
            // 
            this.exposureTimeValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exposureTimeValueLabel.AutoSize = true;
            this.exposureTimeValueLabel.Location = new System.Drawing.Point(3, 12);
            this.exposureTimeValueLabel.Name = "exposureTimeValueLabel";
            this.exposureTimeValueLabel.Size = new System.Drawing.Size(13, 12);
            this.exposureTimeValueLabel.TabIndex = 15;
            this.exposureTimeValueLabel.Text = "0";
            // 
            // exposureTimeLabel
            // 
            this.exposureTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exposureTimeLabel.AutoSize = true;
            this.exposureTimeLabel.Location = new System.Drawing.Point(3, 0);
            this.exposureTimeLabel.Name = "exposureTimeLabel";
            this.exposureTimeLabel.Size = new System.Drawing.Size(77, 12);
            this.exposureTimeLabel.TabIndex = 15;
            this.exposureTimeLabel.Text = "Exposure Time";
            // 
            // invertPixelLabel
            // 
            this.invertPixelLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.invertPixelLabel.AutoSize = true;
            this.invertPixelLabel.Location = new System.Drawing.Point(0, 218);
            this.invertPixelLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.invertPixelLabel.Name = "invertPixelLabel";
            this.invertPixelLabel.Size = new System.Drawing.Size(64, 13);
            this.invertPixelLabel.TabIndex = 8;
            this.invertPixelLabel.Text = "Invert Pixels";
            // 
            // pixelFormatControl
            // 
            this.pixelFormatControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pixelFormatControl.DefaultName = "N/A";
            this.pixelFormatControl.Location = new System.Drawing.Point(142, 94);
            this.pixelFormatControl.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.pixelFormatControl.Name = "pixelFormatControl";
            this.pixelFormatControl.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pixelFormatControl.Size = new System.Drawing.Size(198, 21);
            this.pixelFormatControl.TabIndex = 12;
            // 
            // panelForButtons
            // 
            this.settingsTableLayout.SetColumnSpan(this.panelForButtons, 2);
            this.panelForButtons.Controls.Add(this.singleShotButton);
            this.panelForButtons.Controls.Add(this.stopButton);
            this.panelForButtons.Controls.Add(this.continuousShotButton);
            this.panelForButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForButtons.Location = new System.Drawing.Point(3, 3);
            this.panelForButtons.Name = "panelForButtons";
            this.panelForButtons.Size = new System.Drawing.Size(334, 24);
            this.panelForButtons.TabIndex = 19;
            // 
            // singleShotButton
            // 
            this.singleShotButton.Location = new System.Drawing.Point(0, 0);
            this.singleShotButton.Margin = new System.Windows.Forms.Padding(2);
            this.singleShotButton.Name = "singleShotButton";
            this.singleShotButton.Size = new System.Drawing.Size(109, 22);
            this.singleShotButton.TabIndex = 7;
            this.singleShotButton.Text = "Single Shot";
            this.singleShotButton.UseVisualStyleBackColor = true;
            this.singleShotButton.Click += new System.EventHandler(this.SingleShotButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(225, 0);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(109, 22);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // continuousShotButton
            // 
            this.continuousShotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuousShotButton.Location = new System.Drawing.Point(113, 0);
            this.continuousShotButton.Margin = new System.Windows.Forms.Padding(2);
            this.continuousShotButton.Name = "continuousShotButton";
            this.continuousShotButton.Size = new System.Drawing.Size(109, 22);
            this.continuousShotButton.TabIndex = 8;
            this.continuousShotButton.Text = "Continuous Shot";
            this.continuousShotButton.UseVisualStyleBackColor = true;
            this.continuousShotButton.Click += new System.EventHandler(this.ContinuousShotButtonClick);
            // 
            // pictureWindow
            // 
            this.pictureWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureWindow.Location = new System.Drawing.Point(0, 0);
            this.pictureWindow.Margin = new System.Windows.Forms.Padding(2);
            this.pictureWindow.Name = "pictureWindow";
            this.pictureWindow.Size = new System.Drawing.Size(338, 268);
            this.pictureWindow.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 240);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Test Pattern";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // testPatternControl
            // 
            this.testPatternControl.DefaultName = "N/A";
            this.testPatternControl.Location = new System.Drawing.Point(142, 242);
            this.testPatternControl.Margin = new System.Windows.Forms.Padding(2);
            this.testPatternControl.Name = "testPatternControl";
            this.testPatternControl.Size = new System.Drawing.Size(190, 21);
            this.testPatternControl.TabIndex = 21;
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pictureWindow);
            this.Controls.Add(this.settingsTableLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Size = new System.Drawing.Size(345, 618);
            this.settingsTableLayout.ResumeLayout(false);
            this.settingsTableLayout.PerformLayout();
            this.tableLayoutPanelGain.ResumeLayout(false);
            this.tableLayoutPanelGain.PerformLayout();
            this.tableLayoutPanelExposureTime.ResumeLayout(false);
            this.tableLayoutPanelExposureTime.PerformLayout();
            this.panelForButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel settingsTableLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExposureTime;
        private System.Windows.Forms.Label exposureTimeValueLabel;
        private System.Windows.Forms.Label exposureTimeLabel;
        private System.Windows.Forms.Label invertPixelLabel;
        private System.Windows.Forms.Button softwareTriggerExecuteButton;
        private System.Windows.Forms.Label softwareTriggerLabel;
        private System.Windows.Forms.Label pixelFormatLabel;
        private System.Windows.Forms.Label triggerModeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGain;
        private System.Windows.Forms.Label gainValueLabel;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label triggerSourceLabel;
        private System.Windows.Forms.CheckBox invertPixelFormatCheckbox;
        private System.Windows.Forms.Button singleShotButton;
        private System.Windows.Forms.Button continuousShotButton;
        private System.Windows.Forms.Button stopButton;
        private PictureWindow pictureWindow;
        private ParameterSliderUserControl exposureControl;
        private ParameterSliderUserControl gainControl;
        private EnumerationComboBoxUserControl pixelFormatControl;
        private EnumerationComboBoxUserControl triggerModeControl;
        private EnumerationComboBoxUserControl triggerSourceControl;
        private System.Windows.Forms.Panel panelForButtons;
        private System.Windows.Forms.Label label1;
        private EnumerationComboBoxUserControl testPatternControl;
    }
}
