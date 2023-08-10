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
            calibrationUserControl1.Visible = false;
            calibrationUserControl1.OnStatusChange += CalibrationUserControl1_OnStatusChange; 
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
                calibrationUserControl1.SetCamera(g);
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

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calibrationUserControl1.Visible = true;
            CalibrationData data = new CalibrationData();
            data.Title = "Untitled";
            calibrationUserControl1.CalibrationDataFile = data;
            Text = $"Pylon Camera Application - Calibration [{data.Title}]";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Calibration Data |*.cal";
            saveFileDialog1.Title = "Save a Calibration File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                WriteToBinaryFile(saveFileDialog1.FileName, calibrationUserControl1.CalibrationDataFile);

                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;
                }

                fs.Close();
            }
        }
        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the binary file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the binary file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
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
