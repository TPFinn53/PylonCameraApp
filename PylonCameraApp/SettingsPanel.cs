using System;
using System.Windows.Forms;
using Basler.Pylon;

namespace PylonCameraApp
{
    public partial class SettingsPanel : UserControl
    {
        private GUICamera guiCamera = new GUICamera();
        private EnumerationComboBoxUserControl testImageControl;
        private Label testImageLabel;

        // Create and set up the pane.
        public SettingsPanel()
        {
            InitializeComponent();

            //
            // testImageControl
            //
            this.testImageControl = new EnumerationComboBoxUserControl();
            this.testImageControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testImageControl.Location = new System.Drawing.Point(12, 0);
            this.testImageControl.Name = "testImageControl";
            this.testImageControl.Size = new System.Drawing.Size(201, 57);
            this.testImageControl.TabIndex = 0;
            this.testImageControl.DefaultName = "Test Image Selector";

            this.testImageLabel = new System.Windows.Forms.Label();
            this.testImageLabel.Text = "Test Pattern";
            this.settingsTableLayout.Controls.Add(this.testImageLabel, 0, 8);
            this.settingsTableLayout.Controls.Add(this.testImageControl, 1, 8);

            pictureWindow.SetCamera(guiCamera);

            // Subscribe to GUI camera events.
            guiCamera.GuiCameraConnectionToCameraLost += OnDeviceRemoved;
            guiCamera.GuiCameraOpenedCamera += OnCameraOpened;
            guiCamera.GuiCameraClosedCamera += OnCameraClosed;
            guiCamera.GuiCameraGrabStarted += OnGrabStarted;
            guiCamera.GuiCameraGrabStopped += OnGrabStopped;

            // Assign value labels to controls.
            exposureControl.SetLabel(exposureTimeValueLabel);
            gainControl.SetLabel(gainValueLabel);

            // Set accessibility for the controls.
            EnableControls(false, false);
        }

        // Returns the pylon camera object.
        public GUICamera GetGuiCamera()
        {
            return guiCamera;
        }

        // Attach camera parameters to GUI elements.
        private void BindParametersToControls()
        {
            IParameterCollection parameters = guiCamera.Parameters;
            try
            {
                pixelFormatControl.Parameter = parameters[PLCamera.PixelFormat];
                triggerModeControl.Parameter = parameters[PLCamera.TriggerMode];
                triggerSourceControl.Parameter = parameters[PLCamera.TriggerSource];
                testImageControl.Parameter = parameters[PLCamera.TestImageSelector];

                // If a control is not present in the current camera, use a different control. 
                if (parameters.Contains(PLCamera.Gain))
                {
                    gainControl.Parameter = parameters[PLCamera.Gain];
                }
                else
                {
                    gainControl.Parameter = parameters[PLCamera.GainRaw];
                }
                if (parameters.Contains(PLCamera.ExposureTimeAbs))
                {
                    exposureControl.Logarithmic = true;
                    exposureControl.Parameter = parameters[PLCamera.ExposureTimeAbs];
                }
                else
                {
                    exposureControl.Logarithmic = true;
                    exposureControl.Parameter = parameters[PLCamera.ExposureTime];
                }
            }
            catch (Exception e)
            {
                Helper.ShowException(e);
            }
        }

        // Detach the controls from the camera.
        public void UnbindParametersFromControls()
        {
            pixelFormatControl.Parameter = null;
            gainControl.Parameter = null;
            exposureControl.Parameter = null;
            testImageControl.Parameter = null;
        }

        // Event handler for the Continuous Shot button.
        private void ContinuousShotButtonClick(object sender, EventArgs e)
        {
            try
            {
                guiCamera.StartContinuousShotGrabbing();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                pictureWindow.Clear();
            }
        }

        // Event handler for the Single Shot button.
        private void SingleShotButtonClick(object sender, EventArgs e)
        {
            try
            {
                guiCamera.StartSingleShotGrabbing();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                pictureWindow.Clear();
            }
        }

        // Event handler for the Stop button.
        private void StopButtonClick(object sender, EventArgs e)
        {
            try
            {
                guiCamera.StopGrabbing();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
            }
        }

        // Event handler for software trigger Execute button.
        private void SoftwareTriggerExecuteClick(object sender, EventArgs e)
        {
            try
            {
                guiCamera.SoftwareTrigger();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
            }
        }

        // Enable/disable controls.
        public void EnableControls(bool opened, bool grabbing)
        {
            bool isSupported = guiCamera.IsSingleShotSupported();
            singleShotButton.Enabled = !grabbing && opened && isSupported;
            continuousShotButton.Enabled = !grabbing && opened;
            stopButton.Enabled = grabbing;
            exposureControl.Enabled = opened;
            gainControl.Enabled = opened;
            triggerSourceControl.Enabled = opened;
            triggerModeControl.Enabled = opened;
            pixelFormatControl.Enabled = !grabbing && opened;
            testImageControl.Enabled = !grabbing && opened;

            invertPixelFormatCheckbox.Enabled = opened;
            softwareTriggerExecuteButton.Enabled = grabbing;
        }

        // Event handler for Invert Pixels check box.
        private void InvertPixelCheckBoxChanged(object sender, EventArgs e)
        {
            guiCamera.InvertPixels = invertPixelFormatCheckbox.Checked;
        }

        // Update controls when grabbing is started.
        public void OnGrabStarted(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnGrabStarted), sender, e);
                return;
            }
            pictureWindow.InitCounters();
            EnableControls(true, true);
        }

        // Update controls when grabbing is stopped.
        public void OnGrabStopped(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnGrabStopped), sender, e);
                return;
            }
            EnableControls(true, false);
        }

        // Update controls when a camera is opened.
        public void OnCameraOpened(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraOpened), sender, e);
                return;
            }
            BindParametersToControls();
            pictureWindow.StartFpsCounter();
            EnableControls(true, false);
        }

        // Update controls when a camera is closed.
        public void OnCameraClosed(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraClosed), sender, e);
                return;
            }
            pictureWindow.StopFpsCounter();
            pictureWindow.Clear();
            UnbindParametersFromControls();
            EnableControls(false, false);
        }

        // Event handler for device removal.
        public void OnDeviceRemoved(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnDeviceRemoved), sender, e);
                return;
            }
            //Note: The following call triggers event handlers that update the GUI.
            //Close and destroy the underlying camera object.
            guiCamera.DestroyCamera();
        }
    }
}
