using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Basler.Pylon;

namespace PylonMultiCameraApp
{
    public partial class MainForm : Form
    {
        // Camera info of currently selected camera.
        private ICameraInfo selectedCameraInfo = null;

        // Create the main form.
        public MainForm()
        {
            InitializeComponent();
            UpdateDeviceList();

            closeButton1.Enabled = false;
            settingsPanel1.GetGuiCamera().GuiCameraConnectionToCameraLost += OnDeviceRemoval;
            settingsPanel1.GetGuiCamera().GuiCameraOpenedCamera += OnCamera1Opened;
            settingsPanel1.GetGuiCamera().GuiCameraClosedCamera += OnCamera1Closed;

            closeButton2.Enabled = false;
            settingsPanel2.GetGuiCamera().GuiCameraConnectionToCameraLost += OnDeviceRemoval;
            settingsPanel2.GetGuiCamera().GuiCameraOpenedCamera += OnCamera2Opened;
            settingsPanel2.GetGuiCamera().GuiCameraClosedCamera += OnCamera2Closed;
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
                    openSelectedButton2.Enabled = !settingsPanel1.GetGuiCamera().IsCreated;
                }
                else
                {
                    cameraSelectionComboBox.DataSource = null;
                    cameraSelectionComboBox.Text = "No camera connected";
                    cameraSelectionComboBox.SelectedItem = null;
                    openSelectedButton1.Enabled = false;
                    openSelectedButton2.Enabled = false;
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
            settingsPanel2.GetGuiCamera().DestroyCamera();
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

        // Open the selected camera on the right side of the dialog when the right Open Selected button is clicked.
        private void OpenSelectedButton2Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel2.GetGuiCamera().CreateByCameraInfo(selectedCameraInfo);
                settingsPanel2.GetGuiCamera().OpenCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel2.GetGuiCamera().DestroyCamera();
            }
        }

        // Open a camera by serial number on the right side of the dialog when the right Open By SN button is clicked.
        private void OpenBySerialNumberButton2Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel2.GetGuiCamera().CreateCameraBySerialNumber(serialNumberTextBox2.Text);
                settingsPanel2.GetGuiCamera().OpenCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel2.GetGuiCamera().DestroyCamera();
            }
        }

        // Open a camera by user ID on the right side of the dialog when the right Open By User ID button is clicked.
        private void OpenByUserIDButton2Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel2.GetGuiCamera().CreateCameraByUID(userIDTextBox2.Text);
                settingsPanel2.GetGuiCamera().OpenCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
                settingsPanel2.GetGuiCamera().DestroyCamera();
            }
        }

        // Closes the camera open on the right side of the dialog if the right Close button is clicked.
        private void CloseButton2Click(object sender, EventArgs e)
        {
            try
            {
                //Note: The following calls trigger event handlers that update the GUI.
                settingsPanel2.GetGuiCamera().CloseCamera();
                // On close, we also destroy the underlying camera object.
                settingsPanel2.GetGuiCamera().DestroyCamera();
            }
            catch (Exception ex)
            {
                Helper.ShowException(ex);
            }
        }

        // Enable controls when the left camera is opened.
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

        // Enable controls when the right camera is opened.
        private void OnCamera2Opened(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCamera2Opened), sender, e);
                return;
            }
            openSelectedButton2.Enabled = false;
            openBySerialNumberButton2.Enabled = false;
            openByUserIDButton2.Enabled = false;
            closeButton2.Enabled = true;
            serialNumberTextBox2.Enabled = false;
            userIDTextBox2.Enabled = false;
        }

        // Disable controls when the right camera is closed.
        private void OnCamera2Closed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCamera2Closed), sender, e);
                return;
            }
            openSelectedButton2.Enabled = cameraSelectionComboBox.DataSource != null;
            openBySerialNumberButton2.Enabled = serialNumberTextBox2.Text != "";
            openByUserIDButton2.Enabled = userIDTextBox2.Text != "";
            closeButton2.Enabled = false;
            serialNumberTextBox2.Enabled = true;
            userIDTextBox2.Enabled = true;
        }

        // Changes the status of the left Open By User ID button if the text in the left user ID text box changes.
        private void UserIDTextBox1TextChanged(object sender, EventArgs e)
        {
            openByUserIDButton1.Enabled = userIDTextBox1.Text != "";
        }

        // Changes the status of the left Open By SN button if the text in the left serial number text box changes.
        private void SerialNumberTextBox2TextChanged(object sender, EventArgs e)
        {
            openBySerialNumberButton2.Enabled = serialNumberTextBox2.Text != "";
        }

        // Changes the status of the right Open By UserID button if the text in the right user ID text box changes.
        private void UserIDTextBox2TextChanged(object sender, EventArgs e)
        {
            openByUserIDButton2.Enabled = userIDTextBox2.Text != "";
        }

        // Changes the status of the right Open By SN button if the text in the right serial number text box changes.
        private void SerialNumberTextBox1TextChanged(object sender, EventArgs e)
        {
            openBySerialNumberButton1.Enabled = serialNumberTextBox1.Text != "";
        }
    }
}
