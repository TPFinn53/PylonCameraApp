namespace PylonCameraApp
{
    partial class CalibrationUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationUserControl));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CalibrationTabs = new System.Windows.Forms.TabControl();
            this.tabCalibrationHistogram = new System.Windows.Forms.TabPage();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.tabCalibrationTable = new System.Windows.Forms.TabPage();
            this.listViewEx1 = new PylonCameraApp.ListViewEx();
            this.columnHeaderBin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripRadioButton1 = new PylonCameraApp.ToolStripRadioButton();
            this.toolStripRadioButton2 = new PylonCameraApp.ToolStripRadioButton();
            this.tabCalibrationMask = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripFramesLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCaptureButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClearSelection = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.CalibrationTabs.SuspendLayout();
            this.tabCalibrationHistogram.SuspendLayout();
            this.tabCalibrationTable.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabCalibrationMask.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnRunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CalibrationTabs);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 300);
            this.panel1.TabIndex = 1;
            // 
            // CalibrationTabs
            // 
            this.CalibrationTabs.Controls.Add(this.tabCalibrationHistogram);
            this.CalibrationTabs.Controls.Add(this.tabCalibrationTable);
            this.CalibrationTabs.Controls.Add(this.tabCalibrationMask);
            this.CalibrationTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalibrationTabs.Location = new System.Drawing.Point(0, 25);
            this.CalibrationTabs.Name = "CalibrationTabs";
            this.CalibrationTabs.SelectedIndex = 0;
            this.CalibrationTabs.Size = new System.Drawing.Size(500, 275);
            this.CalibrationTabs.TabIndex = 2;
            // 
            // tabCalibrationHistogram
            // 
            this.tabCalibrationHistogram.Controls.Add(this.plotView1);
            this.tabCalibrationHistogram.Location = new System.Drawing.Point(4, 22);
            this.tabCalibrationHistogram.Name = "tabCalibrationHistogram";
            this.tabCalibrationHistogram.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalibrationHistogram.Size = new System.Drawing.Size(492, 249);
            this.tabCalibrationHistogram.TabIndex = 0;
            this.tabCalibrationHistogram.Text = "Histogram";
            this.tabCalibrationHistogram.UseVisualStyleBackColor = true;
            // 
            // plotView1
            // 
            this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView1.Location = new System.Drawing.Point(3, 3);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(486, 243);
            this.plotView1.TabIndex = 1;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabCalibrationTable
            // 
            this.tabCalibrationTable.Controls.Add(this.listViewEx1);
            this.tabCalibrationTable.Controls.Add(this.toolStrip2);
            this.tabCalibrationTable.Location = new System.Drawing.Point(4, 22);
            this.tabCalibrationTable.Name = "tabCalibrationTable";
            this.tabCalibrationTable.Size = new System.Drawing.Size(492, 249);
            this.tabCalibrationTable.TabIndex = 1;
            this.tabCalibrationTable.Text = "Data";
            this.tabCalibrationTable.UseVisualStyleBackColor = true;
            // 
            // listViewEx1
            // 
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBin,
            this.columnHeaderCount});
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx1.HideSelection = false;
            this.listViewEx1.Location = new System.Drawing.Point(0, 25);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(492, 224);
            this.listViewEx1.TabIndex = 2;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderBin
            // 
            this.columnHeaderBin.Text = "Bin";
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Count";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRadioButton1,
            this.toolStripRadioButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(492, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripRadioButton1
            // 
            this.toolStripRadioButton1.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton1.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton1.CheckOnClick = true;
            this.toolStripRadioButton1.Enabled = false;
            this.toolStripRadioButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton1.Image")));
            this.toolStripRadioButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton1.Name = "toolStripRadioButton1";
            this.toolStripRadioButton1.RadioButtonGroupId = 0;
            this.toolStripRadioButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripRadioButton1.Text = "Short List";
            this.toolStripRadioButton1.Click += new System.EventHandler(this.OnShortListClick);
            // 
            // toolStripRadioButton2
            // 
            this.toolStripRadioButton2.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton2.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton2.CheckOnClick = true;
            this.toolStripRadioButton2.Enabled = false;
            this.toolStripRadioButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton2.Image")));
            this.toolStripRadioButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton2.Name = "toolStripRadioButton2";
            this.toolStripRadioButton2.RadioButtonGroupId = 0;
            this.toolStripRadioButton2.Size = new System.Drawing.Size(75, 22);
            this.toolStripRadioButton2.Text = "Long List";
            this.toolStripRadioButton2.Click += new System.EventHandler(this.OnLongListClick);
            // 
            // tabCalibrationMask
            // 
            this.tabCalibrationMask.Controls.Add(this.panel2);
            this.tabCalibrationMask.Location = new System.Drawing.Point(4, 22);
            this.tabCalibrationMask.Name = "tabCalibrationMask";
            this.tabCalibrationMask.Size = new System.Drawing.Size(492, 249);
            this.tabCalibrationMask.TabIndex = 2;
            this.tabCalibrationMask.Text = "Mask";
            this.tabCalibrationMask.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 249);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFramesLabel,
            this.toolStripSeparator2,
            this.toolStripCaptureButton,
            this.toolStripProgressBar1,
            this.toolStripSeparator1,
            this.toolStripButtonClearSelection});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(500, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripFramesLabel
            // 
            this.toolStripFramesLabel.Enabled = false;
            this.toolStripFramesLabel.Name = "toolStripFramesLabel";
            this.toolStripFramesLabel.Size = new System.Drawing.Size(48, 22);
            this.toolStripFramesLabel.Text = "Frames:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripCaptureButton
            // 
            this.toolStripCaptureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripCaptureButton.Enabled = false;
            this.toolStripCaptureButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCaptureButton.Image")));
            this.toolStripCaptureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCaptureButton.Name = "toolStripCaptureButton";
            this.toolStripCaptureButton.Size = new System.Drawing.Size(53, 22);
            this.toolStripCaptureButton.Text = "Capture";
            this.toolStripCaptureButton.Click += new System.EventHandler(this.OnClickCapture);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Enabled = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClearSelection
            // 
            this.toolStripButtonClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearSelection.Image")));
            this.toolStripButtonClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSelection.Name = "toolStripButtonClearSelection";
            this.toolStripButtonClearSelection.Size = new System.Drawing.Size(89, 22);
            this.toolStripButtonClearSelection.Text = "Clear Selection";
            this.toolStripButtonClearSelection.Click += new System.EventHandler(this.OnClickClearSelection);
            // 
            // CalibrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CalibrationUserControl";
            this.Size = new System.Drawing.Size(500, 300);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CalibrationTabs.ResumeLayout(false);
            this.tabCalibrationHistogram.ResumeLayout(false);
            this.tabCalibrationTable.ResumeLayout(false);
            this.tabCalibrationTable.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabCalibrationMask.ResumeLayout(false);
            this.tabCalibrationMask.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl CalibrationTabs;
        private System.Windows.Forms.TabPage tabCalibrationHistogram;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripFramesLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCaptureButton;
        private System.Windows.Forms.TabPage tabCalibrationTable;
        private System.Windows.Forms.TabPage tabCalibrationMask;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private ToolStripRadioButton toolStripRadioButton1;
        private ToolStripRadioButton toolStripRadioButton2;
        private ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader columnHeaderBin;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSelection;
    }
}
