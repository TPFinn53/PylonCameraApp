using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PylonCameraApp
{
    // Image window containing a live view and counters for images, errors, and frame rate.
    public partial class PictureWindow : UserControl
    {
        // Members to calculate frame rate.
        private int FPS_AGGREGATION_TIME_S = 5;
        private int imageCountOld = 0;
        private List<int> imageCounts = new List<int>();

        private GUICamera guiCamera;
        private Bitmap image;

        public PictureWindow()
        {
            InitializeComponent();
            // Enable double buffering of the form to avoid flickering.
            this.DoubleBuffered = true;
        }

        // Sets the camera for image buffer access, image display, and frame rate display.
        public void SetCamera(GUICamera cam)
        {
            guiCamera = cam;
            guiCamera.GuiCameraFrameReadyForDisplay += OnImageReady;
        }

        // Clear the image. Reset the counters and corresponding labels.
        public void Clear()
        {
            fpsLabel.Text = "";
            ErrorsCount.Text = "";
            ImagesCount.Text = "";
            imageCountOld = 0;
            imageCounts.Clear();
            if (this.image != null)
            {
                image.Dispose();
            }
            this.image = null;
            // Make sure the image window is updated.
            Invalidate();
        }

        // Set the counters to 0.
        public void InitCounters()
        {
            imageCountOld = 0;
            imageCounts.Clear();
            ImagesCount.Text = "Images: 0";
            ErrorsCount.Text = "Errors: 0";
            fpsLabel.Text = "Frame rate: 0.0";
        }

        // Starts the frame rate counter if a camera is opened.
        public void StartFpsCounter()
        {
            InitCounters();
            fpsTimer.Start();
        }

        // Stops the frame rate counter thread if the camera is closed.
        public void StopFpsCounter()
        {
            fpsTimer.Stop();
        }

        // Calculates the frame rate every second.
        private void FpsTimerTick(object sender, EventArgs e)
        {
            int imageCount = guiCamera.ImageCount;
            int errorCount = guiCamera.ErrorCount;

            double fpsApproximation = 0.0;
            if (guiCamera.IsGrabbing)
            {
                // If previous values are available, e.g., for continuous grab, ...
                if (imageCounts.Count > 0)
                {
                    int imageCountCurrent = imageCount - imageCountOld;
                    imageCounts.Add(imageCountCurrent);
                    // Count for about x seconds. Remove older values.
                    while (imageCounts.Count > FPS_AGGREGATION_TIME_S)
                    {
                        imageCounts.RemoveAt(0);
                    }

                    //... sum up all values and calculate the average for the 1 s FpsTickTimer duration.
                    int sum = imageCounts.Sum();
                    fpsApproximation = (double)sum / (double)imageCounts.Count;
                }
                else
                {
                    int imageCountCurrent = imageCount - imageCountOld;
                    // First count of images for 1 second timer.
                    // The timer is not synchronized with the grabbing, so we start aggregating values with
                    // the second tick of the timer where we get the first images.
                    if (imageCountOld != 0)
                    {
                        imageCounts.Add(imageCountCurrent);
                    }
                    fpsApproximation = (double)imageCountCurrent;
                }
            }

            // Update the GUI.
            fpsLabel.Text = String.Format("Frame rate: {0:0.0}", fpsApproximation);
            ImagesCount.Text = "Images: " + imageCount;
            ErrorsCount.Text = "Errors: " + errorCount;
            // Remember the last image count for the next processing tick.
            imageCountOld = imageCount;
        }

        // Renders the image every time the image window is invalidated.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (image != null)
            {
                double aspectRatioImage = (double)(image.Width) / (double)(image.Height);
                int availableDisplayWidth = this.Width;
                int availableDisplayHeight = this.Height - streamDataBox.Height - streamDataBox.Margin.Top - streamDataBox.Margin.Bottom;
                int requiredDisplayHeight = (int)((double)(this.Width) / aspectRatioImage);
                int drawingAreaWidth = availableDisplayWidth;
                int drawingAreaHeight = requiredDisplayHeight;
                // If height is exceeded, correct the width and height.
                if (availableDisplayHeight < requiredDisplayHeight)
                {
                    drawingAreaWidth = (int)(availableDisplayHeight * aspectRatioImage);
                    drawingAreaHeight = availableDisplayHeight;
                }
                Point drawingPosition = new Point(0, 0);
                Size drawingSize = new Size(drawingAreaWidth, drawingAreaHeight);
                Rectangle drawingArea = new Rectangle(drawingPosition, drawingSize);
                e.Graphics.DrawImage(image, drawingArea, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.Clear(this.BackColor);
            }
        }

        // Invalidate the image window every time the GuiCamera has supplied a new image.
        // This causes a repaint of the image.
        private void OnImageReady(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnImageReady), sender, e);
                return;
            }

            if (guiCamera != null)
            {
                Bitmap newImage = guiCamera.GetLatestFrame();
                if (newImage != null)
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                    image = newImage;
                }
            }

            // Tell Windows to repaint the control.
            this.Invalidate();
            this.Update();
        }

        // Invalidate the form on resize to scale the image.
        private void PictureWindowResize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
