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
using Basler.Pylon;

namespace PylonCameraApp
{
    public partial class CalibrationUserControl : UserControl
    {

        public delegate void StatusChange(string Status);
        public event StatusChange OnStatusChange;

        private ToolStripNumberControl binCount = new ToolStripNumberControl();
        private ToolStripNumberControl frameCount = new ToolStripNumberControl();
        private GUICamera guiCamera;
        private ArrayList[] arrLineHistogram = null;
        private ArrayList[] arrBarHistogram = null;
        private ListViewItem[] arrLviLine = null;
        private ListViewItem[] arrLviBar = null;
        private PixelDataConverter converter = new PixelDataConverter();


        // Declare a delegate used to communicate with the UI thread
        private delegate void UpdateStatusDelegate(string status);
        private UpdateStatusDelegate updateStatusDelegate = null;

        public CalibrationUserControl()
        {
            InitializeComponent();
            NumericUpDown nupBins = (NumericUpDown)binCount.NumericUpDownControl;
            NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
            nupBins.Value = nupBins.Maximum;
            nupFrames.Value = 1;
            toolStrip1.Items.Insert(5, (ToolStripItem)binCount);
            toolStrip1.Items.Insert(8, (ToolStripItem)frameCount);
            backgroundWorker1.WorkerReportsProgress = true;
            toolStripRadioButtonBarChart.Checked = true;

        }

        public CalibrationData CalibrationDataFile { set; get; }
        // Sets the camera for image buffer access, image display, and frame rate display.
        public void SetCamera(GUICamera cam)
        {
            guiCamera = cam;

            ConnectToCameraEvents();

            // Initialise the delegate
            this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);
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
            int red = (int)((value * Byte.MaxValue)/ UInt16.MaxValue);
            int green = red;
            int blue = red;
            Color c = Color.FromArgb(red, green, blue);
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
                byte[] buffer = guiCamera.LatestFrameBuffer;
                ushort[] source = new ushort[(int)Math.Ceiling((double)buffer.Length / 2)];
                Buffer.BlockCopy(buffer, 0, source, 0, buffer.Length);

                toolStripCaptureButton.Text = "Capture";

                Display16bitGrayScaleImage(source);

                NumericUpDown nupBins = (NumericUpDown)binCount.NumericUpDownControl;
                NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
                nupBins.Enabled = true;
                nupFrames.Enabled = true;


                object paramObj0 = (int)(((NumericUpDown)(binCount.NumericUpDownControl)).Value);
                object paramObj1 = guiCamera.ImageHeight;
                object paramObj2 = guiCamera.ImageWidth;
                object paramObj3 = source;

                // The parameters you want to pass to the do work event of the background worker.
                object[] parameters = new object[] { paramObj0, paramObj1, paramObj2, paramObj3 };

                this.backgroundWorker1.RunWorkerAsync(parameters);
            }
        }


        // Invalidate the image window every time the GuiCamera has supplied a new image.
        // This causes a repaint of the image.
        //private void OnImageReady(Object sender, EventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
        //        BeginInvoke(new EventHandler<EventArgs>(OnImageReady), sender, e);
        //        return;
        //    }

        //    if (guiCamera != null && IsRunning == true)
        //    {
        //        frames++;
        //        string status = "Processing Frame:" + frames.ToString();
        //        UpdateStatus(status);

        //        IGrabResult grabResult = guiCamera.LatestGrabResult;

        //        byte[] buffer = grabResult.PixelData as byte[];
        //        ushort[] source = new ushort[(int)Math.Ceiling((double)buffer.Length / 2)];
        //        Buffer.BlockCopy(buffer, 0, source, 0, buffer.Length);


        //        if (simpleMovingAverageArray == null)
        //            simpleMovingAverageArray = new SimpleMovingAverage[source.Length];

        //        if (frames == ((NumericUpDown)(frameCount.NumericUpDownControl)).Value)
        //        {
        //            IsRunning = false;
        //            toolStripCaptureButton.Text = "Capture";

        //            Display16bitGrayScaleImage(grabResult);

        //            for (int i = 0; i < source.Length; i++)
        //            {
        //                SimpleMovingAverage sma = simpleMovingAverageArray[i];
        //                if (sma == null) simpleMovingAverageArray[i] = new SimpleMovingAverage(10);
        //                simpleMovingAverageArray[i].Update(source[i]);
        //            }
        //            for (int i = 0; i < source.Length; i++)
        //            {
        //                SimpleMovingAverage sma = simpleMovingAverageArray[i];
        //                source[i] = (ushort)sma.Average;
        //            }

        //            object paramObj0 = (int)(((NumericUpDown)(binCount.NumericUpDownControl)).Value);
        //            object paramObj1 = guiCamera.ImageHeight;
        //            object paramObj2 = guiCamera.ImageWidth;
        //            object paramObj3 = source;


        //            // The parameters you want to pass to the do work event of the background worker.
        //            object[] parameters = new object[] { paramObj0, paramObj1, paramObj2, paramObj3 };

        //            this.backgroundWorker1.RunWorkerAsync(parameters);
        //        }
        //        else
        //        {
        //            for (int i = 0; i < source.Length; i++)
        //            {
        //                SimpleMovingAverage sma = simpleMovingAverageArray[i];
        //                if (sma == null) simpleMovingAverageArray[i] = new SimpleMovingAverage(10);
        //                simpleMovingAverageArray[i].Update(source[i]);
        //            }
        //        }
        //    }
        //}
        protected void ConnectToCameraEvents()
        {
            // These events forward the events of the camera object.
            guiCamera.GuiCameraOpenedCamera += GuiCamera_GuiCameraOpenedCamera;
            guiCamera.GuiCameraClosedCamera += GuiCamera_GuiCameraClosedCamera;
            guiCamera.GuiCameraGrabStarted += GuiCamera_GuiCameraGrabStarted;
            guiCamera.GuiCameraGrabStopped += GuiCamera_GuiCameraGrabStopped;
            guiCamera.GuiCameraConnectionToCameraLost += GuiCamera_GuiCameraConnectionToCameraLost;
            //guiCamera.GuiCameraFrameReadyForDisplay += OnImageReady;
            guiCamera.GuiCameraRunningFrameAverageForDisplay += OnRunningAverageImageReady;
        }

        private void GuiCamera_GuiCameraConnectionToCameraLost(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GuiCamera_GuiCameraGrabStopped(object sender, EventArgs e)
        {
            toolStripCaptureButton.Enabled = false;
            toolStripCaptureButton.Text = "Capture";
        }

        private void GuiCamera_GuiCameraGrabStarted(object sender, EventArgs e)
        {
            toolStripCaptureButton.Enabled = true;
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
            toolStripCaptureButton.Text = "Stop";
            NumericUpDown nupFrames = (NumericUpDown)frameCount.NumericUpDownControl;
            NumericUpDown nupBins = (NumericUpDown)binCount.NumericUpDownControl;
            guiCamera.ImageRunningAverageCount = (int)nupFrames.Value;
            nupBins.Enabled = false;
            nupFrames.Enabled = false;
            guiCamera.ImageRunningAverage = true;
        }
        public ScatterSeries CreateScatterSeries(ArrayList[] arr)
        {
            ScatterSeries scatterSeries = new ScatterSeries()
            {
                Title = "Ideal Distribution"
            };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Count != 0)
                {
                    ScatterPoint pt = new ScatterPoint(i, arr[i].Count);
                    scatterSeries.Points.Add(pt);
                }
            }
            return scatterSeries;
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
        private int GetMaxValue()
        {
            IParameter parm = guiCamera.Parameters[PLCamera.PixelFormat];

            string str = parm.ToString();
            switch (str)
            {
                case "Mono8":
                    return 0xFF;
                case "Mono12":
                    return 0xFFF;
                case "Mono16":
                    return 0xFFFF;
            }

            return UInt16.MaxValue;
        }
        public HistogramSeries CreateHistogramSeries(ArrayList[] arr)
        {
            HistogramSeries series = new HistogramSeries()
            {
                Title = "Empirical Distribution",
                FillColor = OxyColors.Yellow,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 2
            };
            int width = GetMaxValue() / arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                double rangeStart = i * width;
                double rangeEnd = rangeStart + width;
                double area = arr[i].Count*width;
                int count = arr[i].Count;
                OxyColor color = OxyColors.Yellow;
                HistogramItem item = new HistogramItem(rangeStart, rangeEnd, area, count, color);
                series.Items.Add(item);
            }
            return series;
        }

        private ArrayList[] GenerateHistogram(int rows, int cols, int bins, ushort[] data )
        {
            if (data == null || rows == 0 || cols == 0) return null;

            ArrayList[] arr = new ArrayList[bins];
            for (int x = 0; x < arr.Length; x++)
            {
                arr[x] = new ArrayList();
            }

            //Creating 2d Array
            int index = 0;
            ushort[,] twoDimensionalArray = new ushort[rows, cols];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    twoDimensionalArray[x, y] = data[index];
                    index++;
                }
            }
            //sorting 2d Array into bins
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    ushort val = twoDimensionalArray[x, y];
                    int range = GetMaxValue() / bins;
                    int i = val / range;
                    Pixel pix = new Pixel();
                    pix.Columns = y;
                    pix.Rows = x;
                    pix.Value = val;
                    arr[i].Add(pix);
                }
            }
            return arr;
        }
        private void OnDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            int bins = (int)parameters[0];
            int rows = (int)parameters[1];
            int cols = (int)parameters[2];
            ushort[] data = (ushort[])parameters[3];

            arrLineHistogram = GenerateHistogram(rows, cols, GetMaxValue(), data);
            arrBarHistogram = GenerateHistogram(rows, cols, bins, data);

            arrLviLine = new ListViewItem[arrLineHistogram.Length];
            arrLviBar = new ListViewItem[arrBarHistogram.Length];


            for (int i = 0; i < arrLviLine.Length; ++i)
            {
                arrLviLine[i] = new ListViewItem(new string[] { i.ToString(), i.ToString(), arrLineHistogram[i].Count.ToString() });
            }

            int interval = GetMaxValue() / arrBarHistogram.Length;

            for (int i = 0; i < arrBarHistogram.Length; i++)
            {
                int startpos = interval * i;
                arrLviBar[i] = new ListViewItem(new string[] { i.ToString(), startpos.ToString(), arrBarHistogram[i].Count.ToString() });
            }
        }
        private void PlotChartData()
        {
            if (arrLineHistogram == null) return;
            if (arrBarHistogram == null) return;

            if (toolStripRadioButtonBarChart.Checked)
            {
                listView1.Items.Clear();
                listView1.Items.AddRange(arrLviBar);
            }
            else if (toolStripRadioButtonLineChart.Checked)
            {
                listView1.Items.Clear();
                listView1.Items.AddRange(arrLviLine);
            }
        }

        private void PlotChart()
        {
            if (arrLineHistogram == null) return;
            if (arrBarHistogram == null) return;

            var model = new PlotModel();
            model.MouseDown += Model_MouseDown;

            // add two linear axes
            model.Axes.Add(new LinearAxis() { Title = "Value", Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis() { Title = "Count", Position = AxisPosition.Left });

            if (toolStripRadioButtonBarChart.Checked)
            {
                HistogramSeries barseries = CreateHistogramSeries(arrBarHistogram);
                barseries.MouseDown += HistogramSeries_MouseDown;
                model.Series.Add(barseries);
            }
            else if (toolStripRadioButtonLineChart.Checked)
            {
                LineSeries lineseries = CreateLineSeries(arrLineHistogram);
                model.Series.Add(lineseries);

            }
            plotView1.Model = model;
            //plotView1.ActualController.UnbindMouseDown(OxyMouseButton.Left);

        }
        private static void HistogramSeries_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            HistogramSeries series = sender as HistogramSeries;
            if (series != null)
            {
                var nearest = series.GetNearestPoint(e.Position, false);
                HistogramItem column = nearest.Item as HistogramItem;
                if (column != null)
                {
                    if (column.Color == OxyColors.Yellow)
                    {
                        column.Color = OxyColors.Green;
                    }
                    else
                    {
                        column.Color = OxyColors.Yellow;
                    }
                    series.PlotModel.InvalidatePlot(true);
                }
            }
        }

        private void Model_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            PlotController controller = sender as PlotController;
        }
        private void OnRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PlotChart();
            PlotChartData();


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
    }
}
