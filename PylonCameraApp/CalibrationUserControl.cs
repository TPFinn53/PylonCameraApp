using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;

using Basler.Pylon;
using System.Linq;

namespace PylonCameraApp
{
    public partial class CalibrationUserControl : UserControl
    {
        public delegate void StatusChange(string Status);
        public event StatusChange OnStatusChange;

        private ToolStripNumberControl frameCount = new ToolStripNumberControl();
        private GUICamera guiCamera;
        private ArrayList[] arrLineHistogram = null;
        private ListViewItem[] arrLviLine = null;
        private PixelDataConverter converter = new PixelDataConverter();
        private byte[] latestAveragedFrameBuffer = null;
        private bool[] deadPixelMask = null;
        private int imageHeight = 0;
        private int imageWidth = 0;
        private PixelType imagePixelType;
        private bool isSelectingRange = false;
        private RectangleAnnotation rectAnno = null;


        // Declare a delegate used to communicate with the UI thread
        private delegate void UpdateStatusDelegate(string status);
        private UpdateStatusDelegate updateStatusDelegate = null;

        public CalibrationUserControl()
        {
            InitializeComponent();
            NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
            nupFrames.Value = 10;
            nupFrames.Enabled = false;

            toolStrip1.Items.Insert(1, (ToolStripItem)frameCount);
            backgroundWorker1.WorkerReportsProgress = true;
        }
        public string FileName {set;get;} = "";

        // Sets the camera for image buffer access, image display, and frame rate display.
        public void SetCamera(GUICamera cam)
        {
            guiCamera = cam;

            ConnectToCameraEvents();

            // Initialise the delegate
            this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);
        }
        private void RestoreCalibration(CalibrationData data)
        {
            imageHeight = data.Rows;
            imageWidth = data.Columns;
            latestAveragedFrameBuffer = data.Raster;
            deadPixelMask = data.Mask;
            imagePixelType = data.PixelType;
            SelectionAnnotation rect = data.Selection;
            rectAnno = new RectangleAnnotation
            {
                MinimumX = rect.MinimumX,
                MaximumX = rect.MaximumX,
                MinimumY = rect.MinimumY,
                MaximumY = rect.MaximumY,
                TextRotation = 0,
                Text = "Valid Pixels",
                Fill = OxyColor.FromAColor(99, 
                OxyColors.Blue),
                Stroke = OxyColors.Black,
                StrokeThickness = 1
            };
            ushort[] source = new ushort[(int)Math.Ceiling((double)latestAveragedFrameBuffer.Length / 2)];
            Buffer.BlockCopy(latestAveragedFrameBuffer, 0, source, 0, latestAveragedFrameBuffer.Length);
            int bins = GetMaxValue(imagePixelType);
            arrLineHistogram = GenerateHistogram(imageHeight, imageWidth, bins, source);
            arrLviLine = new ListViewItem[arrLineHistogram.Length];
            for (int i = 0; i < arrLviLine.Length; ++i) { arrLviLine[i] = new ListViewItem(new string[] { i.ToString(), i.ToString(), arrLineHistogram[i].Count.ToString() }); }

            PlotChart();
            PlotChartData();

            Visible = true;
        }
        public bool OpenCalibrationFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CAL Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "cal",
                Filter = "CAL files (*.cal)|*.cal",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CalibrationData data = ReadFromBinaryFile<CalibrationData>(openFileDialog1.FileName);
                RestoreCalibration(data);
                FileName = openFileDialog1.FileName;
                return true;
            }
            return false;
        }
        public bool SaveCalibrationFile()
        {
            if(FileName != "")
            {
                MessageBox.Show("Calibration data has already been committed file. No overwrite available");
                return false;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Calibration Data |*.cal";
            saveFileDialog1.Title = "Save a Calibration File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                CalibrationData data = new CalibrationData();
                data.Rows = imageHeight;
                data.Columns = imageWidth;
                data.Raster = latestAveragedFrameBuffer;
                data.Mask = deadPixelMask;
                data.Bins = arrLineHistogram.Length;
                data.PixelType = imagePixelType;

                SelectionAnnotation sel = new SelectionAnnotation();
                sel.MaximumX = rectAnno.MaximumX;
                sel.MaximumY = rectAnno.MaximumY;
                sel.MinimumX = rectAnno.MinimumX;
                sel.MinimumY = rectAnno.MinimumY;
                data.Selection = sel;

                WriteToBinaryFile(saveFileDialog1.FileName, data);

                Text = $"Pylon Camera Application - Calibration [{saveFileDialog1.FileName}]";
                FileName = saveFileDialog1.FileName;

                //FileAttributes yourFile = File.GetAttributes(saveFileDialog1.FileName);
                //File.SetAttributes(saveFileDialog1.FileName, FileAttributes.ReadOnly);
                return true;
            }
            return false;
        }
        private void UpdateStatus(string status)
        {
            if (OnStatusChange != null)
            {
                OnStatusChange(status);
            }
        }
       private Color ConvertPixelColor(ushort value)
        {
            int max = GetMaxValue(imagePixelType);
            int grey = (int)((value * Byte.MaxValue)/ max);
            Color c = Color.FromArgb(grey, grey, grey);
            return c;
        }
        public void Display16bitGrayScaleImage(ushort[] source)
        {
            int cols = guiCamera.ImageWidth;
            int rows = guiCamera.ImageHeight;

            Bitmap bitmap = new Bitmap(cols, rows);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int index = row * cols + col;
                    ushort v = source[index];
                    Color c = ConvertPixelColor(v);
                    bitmap.SetPixel(col, row, c);
                }
            }
            // Assign a temporary variable to dispose the bitmap after assigning the new bitmap to the display control.
            Bitmap bitmapOld = pictureBox1.Image as Bitmap;
            // Provide the display control with the new bitmap. This action automatically updates the display.
            pictureBox1.Image = bitmap;
            if (bitmapOld != null)
            {
                // Dispose the bitmap.
                bitmapOld.Dispose();
            }
        }
        
        private void OnRunningAverageImageReady(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnRunningAverageImageReady), sender, e);
                return;
            }

            if (guiCamera != null)
            {
                imageHeight = guiCamera.ImageHeight;
                imageWidth = guiCamera.ImageWidth;
                imagePixelType = guiCamera.ImagePixelType;
                latestAveragedFrameBuffer = guiCamera.LatestAveragedFrameBuffer;

                ushort[] source = new ushort[(int)Math.Ceiling((double)latestAveragedFrameBuffer.Length / 2)];
                Buffer.BlockCopy(latestAveragedFrameBuffer, 0, source, 0, latestAveragedFrameBuffer.Length);

                deadPixelMask = new bool[source.Length];
                for (int i = 0; i < deadPixelMask.Length; i++) deadPixelMask[i] = false;

                Display16bitGrayScaleImage(source);

                object paramObj0 = imagePixelType;
                object paramObj1 = imageHeight;
                object paramObj2 = imageWidth;
                object paramObj3 = source;

                // The parameters you want to pass to the do work event of the background worker.
                object[] parameters = new object[] { paramObj0, paramObj1, paramObj2, paramObj3 };

                this.backgroundWorker1.RunWorkerAsync(parameters);
            }
        }
        protected void ConnectToCameraEvents()
        {
            // These events forward the events of the camera object.
            guiCamera.GuiCameraOpenedCamera += GuiCamera_GuiCameraOpenedCamera;
            guiCamera.GuiCameraClosedCamera += GuiCamera_GuiCameraClosedCamera;
            guiCamera.GuiCameraGrabStarted += GuiCamera_GuiCameraGrabStarted;
            guiCamera.GuiCameraGrabStopped += GuiCamera_GuiCameraGrabStopped;
            guiCamera.GuiCameraConnectionToCameraLost += GuiCamera_GuiCameraConnectionToCameraLost;
            guiCamera.GuiCameraRunningFrameAverageForDisplay += OnRunningAverageImageReady;
        }

        private void GuiCamera_GuiCameraConnectionToCameraLost(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GuiCamera_GuiCameraGrabStopped(object sender, EventArgs e)
        {
            toolStripCaptureButton.Enabled = false;
        }

        private void GuiCamera_GuiCameraGrabStarted(object sender, EventArgs e)
        {
            toolStripCaptureButton.Enabled = true;
            toolStripFramesLabel.Enabled = true;
            NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
            nupFrames.Enabled = true;
        }

        private void GuiCamera_GuiCameraClosedCamera(object sender, EventArgs e)
        {
            toolStripCaptureButton.Enabled = false;
        }

        private void GuiCamera_GuiCameraOpenedCamera(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnClickCapture(object sender, EventArgs e)
        {
            NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
            guiCamera.ImageRunningAverageCount = (int)nupFrames.Value;
            nupFrames.Enabled = false;
            toolStripCaptureButton.Enabled = false;
            guiCamera.ImageRunningAverage = true;
        }

        public LineSeries CreateLineSeries(ArrayList[] arr)
        {
            LineSeries lineSeries = new LineSeries()
            {
                Title = "Ideal Distribution",
                Color = OxyColors.Black
            };

            for (int i = 0; i<arr.Length; i++)
            {
                DataPoint pt = new DataPoint(i, arr[i].Count);
                lineSeries.Points.Add(pt);
            }
            return lineSeries;
        }
        private int GetMaxValue(PixelType imagePixelType)
        {
            uint bitDepth = imagePixelType.BitDepth();
            int maxRange = (int)Math.Pow(2, (double)bitDepth);
            return maxRange;
        }

        private ArrayList[] GenerateHistogram(int rows, int cols, int bins, ushort[] data )
        {
            if (data == null || rows == 0 || cols == 0) return null;
            int range = GetMaxValue(imagePixelType) / bins;

            ArrayList[] arr = new ArrayList[bins];
            for (int x = 0; x < arr.Length; x++)
            {
                arr[x] = new ArrayList();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int pos = col * rows + col;
                    ushort val = data[pos];
                    int bin = val / range;
                    Pixel pix = new Pixel();
                    pix.Column = col;
                    pix.Row = row;
                    pix.Value = val;
                    arr[bin].Add(pix);
                }
            }
            return arr;
        }
        private void OnDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            PixelType pix_type = (PixelType)parameters[0];
            int bins = GetMaxValue(pix_type);
            int rows = (int)parameters[1];
            int cols = (int)parameters[2];
            ushort[] data = (ushort[])parameters[3];

            arrLineHistogram = GenerateHistogram(rows, cols, bins, data);

            arrLviLine = new ListViewItem[arrLineHistogram.Length];


            for (int i = 0; i < arrLviLine.Length; ++i)
            {
                arrLviLine[i] = new ListViewItem(new string[] { i.ToString(), i.ToString(), arrLineHistogram[i].Count.ToString() });
            }
        }
        private void PlotChartData()
        {
            if (arrLineHistogram == null) return;
            listView1.Items.Clear();
            listView1.Items.AddRange(arrLviLine);
        }

        private void PlotChart()
        {
            if (arrLineHistogram == null) return;

            var model = new PlotModel();
            model.MouseDown += Model_MouseDown;
            model.MouseMove += Model_MouseMove;
            model.MouseUp += Model_MouseUp;

            // add two linear axes
            model.Axes.Add(new LinearAxis() { Title = "Value", Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis() { Title = "Count", Position = AxisPosition.Left });

            if(rectAnno != null) model.Annotations.Add(rectAnno);

            LineSeries lineseries = CreateLineSeries(arrLineHistogram);
            model.Series.Add(lineseries);

            plotView1.Model = model;
        }
        private void Model_MouseUp(object sender, OxyMouseEventArgs e)
        {
            if (FileName != String.Empty) return;

            isSelectingRange = false;
            for (int i = 0; i < deadPixelMask.Length; i++) deadPixelMask[i] = false;
            for (int i = (int)rectAnno.MinimumX; i <= (int)rectAnno.MaximumX; i++)
            {
                foreach(Pixel pix in arrLineHistogram[i])
                {
                    int index = pix.Row * imageWidth + pix.Column;
                    deadPixelMask[index] = true;
                }
            }
        }
        private void Model_MouseMove(object sender, OxyMouseEventArgs e)
        {
            if (FileName != String.Empty) return;

            if (!isSelectingRange) return;
            PlotController controller = sender as PlotController;
            ScreenPoint pt = e.Position;
            ElementCollection<OxyPlot.Axes.Axis> axisList = plotView1.Model.Axes;

            Axis xAxis = axisList.FirstOrDefault(ax => ax.Position == AxisPosition.Bottom);
            Axis yAxis = axisList.FirstOrDefault(ax => ax.Position == AxisPosition.Left);

            DataPoint dataPointp = OxyPlot.Axes.Axis.InverseTransform(e.Position, xAxis, yAxis);

            rectAnno.MaximumX = dataPointp.X;

            if (plotView1.Model != null)
            {
                plotView1.InvalidatePlot(true);
                plotView1.Update();
            }
        }
        private void Model_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            if (FileName != String.Empty) return;
            PlotController controller = sender as PlotController;
            ScreenPoint pt = e.Position;
            ElementCollection<OxyPlot.Axes.Axis> axisList = plotView1.Model.Axes;

            Axis xAxis = axisList.FirstOrDefault(ax => ax.Position == AxisPosition.Bottom);
            Axis yAxis = axisList.FirstOrDefault(ax => ax.Position == AxisPosition.Left);

            DataPoint dataPointp = OxyPlot.Axes.Axis.InverseTransform(e.Position, xAxis, yAxis);

            // Do stuff with dataPointp ... 
            rectAnno = new RectangleAnnotation
            {
                MinimumX = dataPointp.X,
                MaximumX = dataPointp.X,
                MinimumY = yAxis.Minimum,
                MaximumY = yAxis.Maximum,
                TextRotation = 0,
                Text = "Valid Pixels",
                Fill = OxyColor.FromAColor(99, OxyColors.Blue),
                Stroke = OxyColors.Black, StrokeThickness = 1
            };

            isSelectingRange = true;

            if (plotView1.Model != null)
            {
                plotView1.Model.Annotations.Clear();
                plotView1.Model.Annotations.Add(rectAnno);
                plotView1.InvalidatePlot(true);
                plotView1.Update();
            }

        }
        private void OnRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PlotChart();
            PlotChartData();
            ((NumericUpDown)frameCount.NumericUpDownControl).Enabled = true;
            toolStripCaptureButton.Enabled = true;
        }

        private void OnProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void OnClick_BarChartSelection(object sender, EventArgs e)
        {
            PlotChart();
            PlotChartData();
        }

        private void OnClick_LineChartSelection(object sender, EventArgs e)
        {
            PlotChart();
            PlotChartData();
        }

        private void OnClick_ScatterChartSelection(object sender, EventArgs e)
        {
            PlotChart();
            PlotChartData();
        }
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the binary file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
