using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Basler.Pylon;

namespace PylonCameraApp
{
    public partial class MainForm : Form
    {
        // Camera info of currently selected camera.
        private ICameraInfo selectedCameraInfo = null;
        private object FileObject = null;


        public MainForm()
        {
            InitializeComponent();

            UpdateDeviceList();

            closeButton1.Enabled = false;
            settingsPanel1.GetGuiCamera().GuiCameraConnectionToCameraLost += OnDeviceRemoval;
            settingsPanel1.GetGuiCamera().GuiCameraOpenedCamera += OnCamera1Opened;
            settingsPanel1.GetGuiCamera().GuiCameraClosedCamera += OnCamera1Closed;
       }

        private void CalibrationUserControl1_OnStatusChange(string Status)
        {
            toolStripStatusLabel1.Text = Status;
        }

        // Update the list of connected cameras.
        public void UpdateDeviceList()
        {
            try
            {
                // Ask the camera finder for a list of cameras.
                List<ICameraInfo> cameraInfos = CameraFinder.Enumerate();

                if (cameraInfos.Count > 0)
                {
                    // Maps the camera name to the camera info for use with the combo box.
                    Dictionary<ICameraInfo, String> foundCameraInfos = new Dictionary<ICameraInfo, String>();
                    foreach (ICameraInfo cameraInfo in cameraInfos)
                    {
                        foundCameraInfos.Add(cameraInfo, cameraInfo[CameraInfoKey.FriendlyName]);
                    }

                    cameraSelectionComboBox.DataSource = new BindingSource(foundCameraInfos, null);

                    cameraSelectionComboBox.DisplayMember = "Value";
                    openSelectedButton1.Enabled = !settingsPanel1.GetGuiCamera().IsCreated;
                }
                else
                {
                    cameraSelectionComboBox.DataSource = null;
                    cameraSelectionComboBox.Text = "No camera connected";
                    cameraSelectionComboBox.SelectedItem = null;
                    openSelectedButton1.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                Helper.ShowException(exception);
            }
        }

        // Change the selectedCameraInfo when the user selects a different camera in the drop-down box.
        private void CameraSelectionSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cameraSelectionComboBox.SelectedItem != null)
            {
                selectedCameraInfo = ((KeyValuePair<ICameraInfo, String>)cameraSelectionComboBox.SelectedItem).Key;
            }
            else
            {
                selectedCameraInfo = null;
            }
        }

        // Stops everything when the application is terminated with an open or grabbing camera.
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Note: Destroying the camera triggers event handlers that update the GUI.
            settingsPanel1.GetGuiCamera().DestroyCamera();
        }

        // Event handler for the Discover Cameras button. Causes an update of the camera list.
        private void ScanButtonClick(object sender, EventArgs e)
        {
            scanButton.Enabled = false;
            try
            {
                UpdateDeviceList();
            }
            finally
            {
                scanButton.Enabled = true;
            }
        }

        // Event handler for device removal. Updates the camera list.
        public void OnDeviceRemoval(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnDeviceRemoval), sender, e);
                return;
            }

            Helper.ShowMessage("A camera has been disconnected.");
            UpdateDeviceList();
        }

        // Open the selected camera on the left side of the dialog when the left Open Selected button is clicked.
        private void OpenSelectedButton1Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel1.GetGuiCamera().CreateByCameraInfo(selectedCameraInfo);
                settingsPanel1.GetGuiCamera().OpenCamera();
                GUICamera g = settingsPanel1.GetGuiCamera();
                CalibrationView.SetCamera(g);
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel1.GetGuiCamera().DestroyCamera();
            }
        }

        // Open a camera by serial number on the left side of the dialog when the left Open By SN button is clicked.
        private void OpenBySerialNumberButton1Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel1.GetGuiCamera().CreateCameraBySerialNumber(serialNumberTextBox1.Text);
                settingsPanel1.GetGuiCamera().OpenCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel1.GetGuiCamera().DestroyCamera();
            }
        }

        // Open a camera by user ID on the left side of the dialog when the left Open By User ID button is clicked.
        private void OpenByUserIDButton1Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel1.GetGuiCamera().CreateCameraByUID(userIDTextBox1.Text);
                settingsPanel1.GetGuiCamera().OpenCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel1.GetGuiCamera().DestroyCamera();
            }
        }

        //Closes the camera open on the left side of the dialog if the left Close button is clicked.
        private void CloseButton1Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel1.GetGuiCamera().CloseCamera();
                // On close, we also destroy the underlying camera object.
                settingsPanel1.GetGuiCamera().DestroyCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
            }
        }
        // Enable controls when the camera is opened.
        private void OnCamera1Opened(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCamera1Opened), sender, e);
                return;
            }
            openSelectedButton1.Enabled = false;
            openBySerialNumberButton1.Enabled = false;
            openByUserIDButton1.Enabled = false;
            closeButton1.Enabled = true;
            serialNumberTextBox1.Enabled = false;
            userIDTextBox1.Enabled = false;
        }

        // Disable controls when the left camera is closed.
        private void OnCamera1Closed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCamera1Closed), sender, e);
                return;
            }
            openSelectedButton1.Enabled = cameraSelectionComboBox.DataSource != null;
            openBySerialNumberButton1.Enabled = serialNumberTextBox1.Text != "";
            openByUserIDButton1.Enabled = userIDTextBox1.Text != "";
            closeButton1.Enabled = false;
            serialNumberTextBox1.Enabled = true;
            userIDTextBox1.Enabled = true;
        }
        private void OnNewCalibrationFile(object sender, EventArgs e)
        {
            //calibrationUserControl2.Clear();
            CalibrationView.Visible = true;
            Text = $"Pylon Camera Application - Calibration [Untitled]";
        }
        private void OnSaveCalibrationToFile(object sender, EventArgs e)
        {
            if (CalibrationView.SaveCalibrationFile())
            {
                Text = $"Pylon Camera Application - Calibration [{CalibrationView.FileName}]";
            };
        }
        private void OnOpenCalibrationFile(object sender, EventArgs e)
        {
            if (CalibrationView.OpenCalibrationFile())
            {
                Text = $"Pylon Camera Application - Calibration [{CalibrationView.FileName}]";
            };

        }
    }
}
