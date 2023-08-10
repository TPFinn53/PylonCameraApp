﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Basler.Pylon;

namespace PylonCameraApp
{
    public class GUICamera : IDisposable
    {
        // Frame rate at which an image is output for rendering.
        // Rendering very large images can cause a high load on the CPU.
        // Because of this, images are rendered at a rate of 10 frames per second.
        // You can adjust this value as required.
        private readonly double RENDERFPS = 10;

        // The pylon camera object.
        private Camera camera;

        // Invert pixels for an example of image processing.
        private bool invertPixels = false;

        // Grab statistical values.
        private int imageAveragingCount = 0;
        private int imageCount = 0;
        private int errorCount = 0;

        // Monitor object for managing concurrent thread access to latestFrame.
        private Object monitor = new Object();

        // Buffer for latest image.
        private Bitmap latestFrame = null;
        private byte[] latestPixelFrame = null;
        //private IGrabResult latestGrabResult = null;
        private SimpleMovingAverage[] movingAverageData = null;

        // The pixel data converter is used for converting grabbed images to a pixel format that can be displayed.
        private PixelDataConverter converter = new PixelDataConverter();

        // Stopwatch to slow down rendering if the camera is grabbing faster than the monitor display rate.
        private System.Diagnostics.Stopwatch stopwatch;
        // Minimum duration between frames in stopwatch ticks.
        private int frameDurationTicks;

        // These events forward the events of the camera object.
        public event EventHandler GuiCameraOpenedCamera;
        public event EventHandler GuiCameraClosedCamera;
        public event EventHandler GuiCameraGrabStarted;
        public event EventHandler GuiCameraGrabStopped;
        public event EventHandler GuiCameraConnectionToCameraLost;
        public event EventHandler GuiCameraFrameReadyForDisplay;
        public event EventHandler GuiCameraRunningFrameAverageForDisplay;

        // Create the GUI camera object.
        public GUICamera()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            // Calculate the number of stopwatch ticks for every frame at the given frame rate.
            double frametime = 1 / RENDERFPS;
            frameDurationTicks = (int)(System.Diagnostics.Stopwatch.Frequency * frametime);
        }

        //Thread-safe getter for latest frame.Returns latest frame to display or null if no frame is present.
        public byte[] LatestFrameBuffer
        {
            get
            {
                lock (monitor)
                {
                    if (latestPixelFrame != null)
                    {
                        byte[] data = latestPixelFrame;
                        latestPixelFrame = null;
                        return data;
                    }
                    return null;
                }
            }
        }

        // Thread-safe getter for latest frame. Returns latest frame to display or null if no frame is present.
        public Bitmap GetLatestFrame()
        {
            lock (monitor)
            {
                if (latestFrame != null)
                {
                    Bitmap returnedBitmap = latestFrame;
                    latestFrame = null;
                    return returnedBitmap;
                }
                return null;
            }
        }

        //public IGrabResult LatestGrabResult
        //{
        //    get
        //    {
        //        lock (monitor)
        //        {
        //            return latestGrabResult;
        //        }
        //    }
        //    set
        //    {
        //        lock (monitor)
        //        {
        //            if (latestGrabResult != null)
        //            {
        //                latestGrabResult.Dispose();
        //                latestGrabResult = value;
        //            }
        //        }
        //    }
        //}



        // Getter-Setter for image width.

        public int ImageWidth { get; set; }

        // Getter for image width.
        public int ImageHeight { get; set; }

        // Getter for image count.
        public int ImageCount
        {
            get
            {
                return imageCount;
            }
        }
        // Getter-Setter for image Running Average count.
        public int ImageRunningAverageCount { get; set; } = 1;

        // Getter-Setter for image Running Average ON-OFF.
        public bool ImageRunningAverage { get; set; } = false;

        // Getter for error count.
        public int ErrorCount
        {
            get
            {
                return errorCount;
            }
        }

        // Invert Pixels control for an example of image processing.
        public bool InvertPixels
        {
            get
            {
                return invertPixels;
            }
            set
            {
                this.invertPixels = value;
            }
        }

        // The parameters of the camera. Returns null if no camera has been opened.
        public IParameterCollection Parameters
        {
            get
            {
                return camera != null ? camera.Parameters : null;
            }
        }

        // Checks whether a camera has been created.
        public bool IsCreated
        {
            get
            {
                return camera != null;
            }
        }

        // Checks whether a camera is open.
        public bool IsOpen
        {
            get
            {
                return IsCreated && camera.IsOpen;
            }
        }

        // Checks whether a camera is grabbing.
        public bool IsGrabbing
        {
            get
            {
                return IsOpen && camera.StreamGrabber.IsGrabbing;
            }
        }

        // Selects a camera by serial number.
        public void CreateCameraBySerialNumber(String serialNumber)
        {
            if (IsCreated)
            {
                DestroyCamera();
            }
            // Try to create the camera by serial number.
            camera = new Camera(serialNumber);
            ConnectToCameraEvents();
        }

        // Selects the camera selected in the check box in the main form.
        public void CreateByCameraInfo(ICameraInfo info)
        {
            if (IsCreated)
            {
                DestroyCamera();
            }
            // Try to open a camera with the camera info provided.
            camera = new Camera(info);
            ConnectToCameraEvents();
        }

        // Selects a camera by the ID set by the user.
        public void CreateCameraByUID(String UID)
        {
            if (IsCreated)
            {
                DestroyCamera();
            }
            // Try to open the camera by user ID.
            var cameraInfoFilter = new Dictionary<string, string>
            {
                {CameraInfoKey.UserDefinedName, UID},
            };
            camera = new Camera(cameraInfoFilter, CameraSelectionStrategy.Unambiguous);
            ConnectToCameraEvents();
        }

        // Clean up everything.
        public void DestroyCamera()
        {
            if (IsGrabbing)
            {
                StopGrabbing(); //Does not throw exceptions.
            }
            if (IsOpen)
            {
                CloseCamera(); //Does not throw exceptions.
            }
            if (IsCreated)
            {
                DisconnectFromCameraEvents();
                camera.Dispose(); //Does not throw exceptions.
                camera = null;
            }
        }

        // Connect to the events of the member object camera.
        protected void ConnectToCameraEvents()
        {
            if (IsCreated)
            {
                // These events forward the events of the camera object.
                camera.ConnectionLost += OnConnectionLost;
                camera.CameraOpened += OnCameraOpened;
                camera.CameraClosed += OnCameraClosed;
                camera.StreamGrabber.GrabStarted += OnGrabStarted;
                camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                camera.StreamGrabber.GrabStopped += OnGrabStopped;
            }
        }

        // Disconnect from the events of the member object camera.
        protected void DisconnectFromCameraEvents()
        {
            if (IsCreated)
            {
                camera.ConnectionLost -= OnConnectionLost;
                camera.CameraOpened -= OnCameraOpened;
                camera.CameraClosed -= OnCameraClosed;
                camera.StreamGrabber.GrabStarted -= OnGrabStarted;
                camera.StreamGrabber.ImageGrabbed -= OnImageGrabbed;
                camera.StreamGrabber.GrabStopped -= OnGrabStopped;
            }
        }

        // Opens the camera and sets up event handlers for image grabbing and device removal.
        public void OpenCamera()
        {
            if (!IsCreated)
            {
                throw new InvalidOperationException("Cannot open camera. No camera has been created.");
            }

            //If not already open, open the camera.
            if (!IsOpen)
            {
                // Open the camera.
                camera.Open();
            }
        }


        // Closes the camera and destroys the camera object.
        public void CloseCamera()
        {
            if (IsOpen)
            {
                ResetGrabStatistics();
                ClearLatestFrame();
                camera.Close();
            }
        }


        // Resets the grab statistics counter.
        protected void ResetGrabStatistics()
        {
            Interlocked.Exchange(ref imageCount, 0);
            Interlocked.Exchange(ref errorCount, 0);
        }

        // Clear the last frame displayed in the GUI.
        protected void ClearLatestFrame()
        {
            ResetGrabStatistics();
            lock (monitor)
            {
                if (latestFrame != null)
                {
                    latestFrame.Dispose();
                    latestFrame = null;
                }
            }
        }

        // Configures the camera for continuous shot and starts grabbing.
        public void StartContinuousShotGrabbing()
        {
            // Start grabbing images until grabbing is stopped.
            ResetGrabStatistics();
            Configuration.AcquireContinuous(camera, null);
            camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
        }

        // Executes a single shot on the camera.
        public void StartSingleShotGrabbing()
        {
            ResetGrabStatistics();
            Configuration.AcquireSingleFrame(camera, null);
            camera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
        }

        // Checks if single shot is supported by the camera.
        public bool IsSingleShotSupported()
        {
            // Camera can be null if not yet opened
            if (camera == null)
            {
                return false;
            }

            // Camera can be closed
            if (!camera.IsOpen)
            {
                return false;
            }

            bool canSet = camera.Parameters[PLCamera.AcquisitionMode].CanSetValue("SingleFrame");
            return canSet;
        }

        // Stops grabbing.
        public void StopGrabbing()
        {
            // Stop grabbing.
            camera.StreamGrabber.Stop();
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        // Executes a software trigger.
        public void SoftwareTrigger()
        {
            if (camera.Parameters[PLCamera.TriggerMode].GetValueOrDefault(PLCamera.TriggerMode.Off) == PLCamera.TriggerMode.Off)
            {
                return; // Do nothing if the trigger is disabled.
            }

            // Some camera models don't signal their FrameTriggerReady state.
            if (camera.CanWaitForFrameTriggerReady)
            {
                camera.WaitForFrameTriggerReady(1000, TimeoutHandling.ThrowException);
            }

            camera.ExecuteSoftwareTrigger();
        }

        // Image event handler. Shows the captured frame in the image window.
        public void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            // Acquire the image from the camera. Only show the latest image.
            // The camera may acquire images faster than the images can be displayed.
            try
            {
                Interlocked.Increment(ref imageCount);

                // Get the grab result.
                IGrabResult grabResult = e.GrabResult;


                // Check whether the image can be displayed.
                if (grabResult.GrabSucceeded)
                {
                    // Example of image processing.
                    if (grabResult.PixelTypeValue.BitDepth() == 8 && invertPixels)
                    {
                        InvertColors(grabResult);
                    }
                    // Limit the number of frames passed to the image window to the display frame rate specified.
                    if (!stopwatch.IsRunning || stopwatch.ElapsedTicks >= frameDurationTicks)
                    {
                        stopwatch.Restart();

                        ImageWidth = grabResult.Width;
                        ImageHeight = grabResult.Height;

                        byte[] buffer = grabResult.PixelData as byte[];

                        lock (monitor)
                        {
                            if (latestPixelFrame != null)
                            {
                                latestPixelFrame = null;
                            }
                            latestPixelFrame = new byte[buffer.Length];
                            Buffer.BlockCopy(buffer, 0, latestPixelFrame, 0, buffer.Length);
                        }
                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        
                        // Lock the bits of the bitmap.
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        
                        // Place the pointer to the buffer of the bitmap.
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                        bitmap.UnlockBits(bmpData);

                        // Resize the bitmap according to screen size and write it in the image buffer.
                        lock (monitor)
                        {
                            if (latestFrame != null)
                            {
                                latestFrame.Dispose();
                            }
                            latestFrame = bitmap;
                        }

                        if (ImageRunningAverage)
                        {
                            if(movingAverageData == null)
                            {
                                movingAverageData = new SimpleMovingAverage[ImageWidth* ImageHeight];
                                for(int i = 0; i < movingAverageData.Length; i++)
                                {
                                    movingAverageData[i] = new SimpleMovingAverage(ImageRunningAverageCount);
                                }
                            }
                            ushort[] sdata = new ushort[(int)Math.Ceiling((double)buffer.Length / 2)];
                            Buffer.BlockCopy(buffer, 0, sdata, 0, buffer.Length);
                            for (int i = 0; i < movingAverageData.Length; i++)
                            {
                                movingAverageData[i].Update(sdata[i]);
                            }
                            imageAveragingCount++;
                            if (imageAveragingCount == ImageRunningAverageCount)
                            {
                                imageAveragingCount = 0;
                                ImageRunningAverage = false;

                                // Trigger the RunningFrameAverageCompleteEvent.
                                RaiseEventRunningFrameAverageComplete(EventArgs.Empty);
                            }
                        }

                        // Trigger the FrameCapturedEvent.
                        RaiseEventFrameCaptured(EventArgs.Empty);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.Print(grabResult.ErrorDescription);
                    Interlocked.Increment(ref errorCount);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Print(exception.ToString());
            }
        }

        // Inverts the pixels of an 8-bit grab result.
        private void InvertColors(IGrabResult result)
        {
            byte pixelSize = 255;
            byte[] data = (byte[])result.PixelData;
            for (long i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)pixelSize - (int)data[i]);
            }
        }

        // Device removal event handler triggers the CameraDisconnectedEvent. This is used by the GUI to update its controls.
        // This event is raised by the member object camera.
        public void OnConnectionLost(Object sender, EventArgs e)
        {
            EventHandler handler = GuiCameraConnectionToCameraLost;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        // Invoke event handlers when a camera has been opened.
        // This event is raised by the member object camera.
        protected virtual void OnCameraOpened(Object sender, EventArgs e)
        {
            EventHandler handler = GuiCameraOpenedCamera;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        // Invoke event handlers when a camera has been closed.
        // This event is raised by the member object camera.
        protected virtual void OnCameraClosed(Object sender, EventArgs e)
        {
            EventHandler handler = GuiCameraClosedCamera;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        // Invoke event handlers when a grab has been started.
        // This event is raised by the member object camera.
        protected virtual void OnGrabStarted(Object sender, EventArgs e)
        {
            EventHandler handler = GuiCameraGrabStarted;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        // Invoke event handlers when a grab has been stopped.
        // This event is raised by the member object camera.
        protected virtual void OnGrabStopped(Object sender, GrabStopEventArgs e)
        {
            EventHandler handler = GuiCameraGrabStopped;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        // A displayable frame is ready.
        protected virtual void RaiseEventFrameCaptured(EventArgs e)
        {
            EventHandler handler = GuiCameraFrameReadyForDisplay;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }
        // A displayable frame is ready.
        protected virtual void RaiseEventRunningFrameAverageComplete(EventArgs e)
        {
            EventHandler handler = GuiCameraRunningFrameAverageForDisplay;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }


        // Methods for disposing the GUI Camera with its dependencies.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DestroyCamera();
                if (latestFrame != null)
                {
                    latestFrame.Dispose();
                }
                converter.Dispose();
            }
        }

        // Dispose the GUICamera object.
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
