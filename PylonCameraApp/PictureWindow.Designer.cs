namespace PylonCameraApp
{
    partial class PictureWindow
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
            this.components = new System.ComponentModel.Container();
            this.streamDataBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutStatusLine = new System.Windows.Forms.TableLayoutPanel();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.ImagesCount = new System.Windows.Forms.Label();
            this.ErrorsCount = new System.Windows.Forms.Label();
            this.fpsTimer = new System.Windows.Forms.Timer(this.components);
            this.streamDataBox.SuspendLayout();
            this.tableLayoutStatusLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // streamDataBox
            // 
            this.streamDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.streamDataBox.Controls.Add(this.tableLayoutStatusLine);
            this.streamDataBox.Location = new System.Drawing.Point(2, 293);
            this.streamDataBox.Margin = new System.Windows.Forms.Padding(2);
            this.streamDataBox.Name = "streamDataBox";
            this.streamDataBox.Padding = new System.Windows.Forms.Padding(2);
            this.streamDataBox.Size = new System.Drawing.Size(325, 34);
            this.streamDataBox.TabIndex = 24;
            this.streamDataBox.TabStop = false;
            // 
            // tableLayoutStatusLine
            // 
            this.tableLayoutStatusLine.ColumnCount = 3;
            this.tableLayoutStatusLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutStatusLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutStatusLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutStatusLine.Controls.Add(this.fpsLabel, 0, 0);
            this.tableLayoutStatusLine.Controls.Add(this.ImagesCount, 1, 0);
            this.tableLayoutStatusLine.Controls.Add(this.ErrorsCount, 2, 0);
            this.tableLayoutStatusLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStatusLine.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutStatusLine.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutStatusLine.Name = "tableLayoutStatusLine";
            this.tableLayoutStatusLine.RowCount = 1;
            this.tableLayoutStatusLine.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStatusLine.Size = new System.Drawing.Size(321, 17);
            this.tableLayoutStatusLine.TabIndex = 0;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(2, 0);
            this.fpsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(0, 13);
            this.fpsLabel.TabIndex = 0;
            // 
            // ImagesCount
            // 
            this.ImagesCount.AutoSize = true;
            this.ImagesCount.Location = new System.Drawing.Point(109, 0);
            this.ImagesCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImagesCount.Name = "ImagesCount";
            this.ImagesCount.Size = new System.Drawing.Size(0, 13);
            this.ImagesCount.TabIndex = 1;
            // 
            // ErrorsCount
            // 
            this.ErrorsCount.AutoSize = true;
            this.ErrorsCount.Location = new System.Drawing.Point(216, 0);
            this.ErrorsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorsCount.Name = "ErrorsCount";
            this.ErrorsCount.Size = new System.Drawing.Size(0, 13);
            this.ErrorsCount.TabIndex = 2;
            // 
            // fpsTimer
            // 
            this.fpsTimer.Interval = 1000;
            this.fpsTimer.Tick += new System.EventHandler(this.FpsTimerTick);
            // 
            // PictureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.streamDataBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PictureWindow";
            this.Size = new System.Drawing.Size(329, 329);
            this.Resize += new System.EventHandler(this.PictureWindowResize);
            this.streamDataBox.ResumeLayout(false);
            this.tableLayoutStatusLine.ResumeLayout(false);
            this.tableLayoutStatusLine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox streamDataBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStatusLine;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Label ImagesCount;
        private System.Windows.Forms.Label ErrorsCount;
        private System.Windows.Forms.Timer fpsTimer;
    }
}
