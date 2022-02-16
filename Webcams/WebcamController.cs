using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Webcams
{
    public partial class WebcamController : UserControl
    {
        private class WebcamProperties
        {
            private string _name;
            private int _captureDeviceIndex;
            private WebcamDisplay _webcamDisplayControl;

            public WebcamProperties()
            {
                _webcamDisplayControl = new WebcamDisplay();
            }

            public string Name
            {
                get { return _name; }
                set { 
                    _name = value;
                    _webcamDisplayControl.WebcamName = value;
                }
            }

            public int CaptureDeviceIndex
            {
                get { return _captureDeviceIndex; }
                set { 
                    _captureDeviceIndex = value;
                    _webcamDisplayControl.Initialize(value);
                }
            }

            public ListBox.ObjectCollection AvailableWebcams
            {
                set
                {
                    _webcamDisplayControl.AvailableWebcams = value;
                }
            }

            public override string ToString()
            {
                return _name;
            }

            public Control WebcamDisplayControl
            { 
                get { return _webcamDisplayControl; }
            }

        }

        List<WebcamProperties> _webcamProperies;
        private driversCabSim.Capture _capture;
        PluginManagerLibrary.InterfaceFuerPlugins _pluginHost;
        Daten.DatenInterface _dataStorage;
        DirectShowLib.DsDevice[] _inputDevices;

        public WebcamController(PluginManagerLibrary.InterfaceFuerPlugins pluginHost, Daten.DatenInterface dataStorage)
        {
            InitializeComponent();
            _pluginHost = pluginHost;
            _webcamProperies = new System.Collections.Generic.List<WebcamProperties>();
            _capture = new driversCabSim.Capture();
            _dataStorage = dataStorage;
            FillDevicesList();
        }

        public void SaveConfiguration()
        {
            _dataStorage.write_to_table("Webcams", 0, _webcamProperies.Count);
            if (_inputDevices.Length > 0)
            {
                for (int i = 0; i < _webcamProperies.Count; i++)
                {
                    _dataStorage.write_to_table("Webcams", i * 2 + 1, _webcamProperies[i].Name);
                    _dataStorage.write_to_table("Webcams", i * 2 + 2, _inputDevices[_webcamProperies[i].CaptureDeviceIndex].DevicePath);
                }
            }
        }

        public void LoadConfiguration()
        {
            int numberOfWebcams = Convert.ToInt32(_dataStorage.read_from_table("Webcams", 0));
            for (int i = 0; i < numberOfWebcams; i++)
            {
                WebcamProperties webcamProps = new WebcamProperties();
                AddWebcam(_dataStorage.read_from_table("Webcams", i * 2 + 1), ResolveDevicePath(_dataStorage.read_from_table("Webcams", i * 2 + 2)));
            }
        }

        private int ResolveDevicePath(string devicePath)
        {
            int result = -1;
            for(int i = 0; i < _inputDevices.Length; i++)
            {
                if (_inputDevices[i].DevicePath == devicePath)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        private void AddWebcam_Click(object sender, EventArgs e)
        {
            AddWebcam("New Webcam", -1);
        }

        private void AddWebcam(string name, int deviceIndex)
        {
            WebcamProperties webcam = new WebcamProperties();
            webcam.Name = name;
            _webcamProperies.Add(webcam);
            RebuildWebcamList();
            _pluginHost.registerGUIControl(webcam.WebcamDisplayControl);
            if (deviceIndex >= 0)
            {
                webcam.CaptureDeviceIndex = deviceIndex;
            }

            webcam.AvailableWebcams = listBox2.Items;
        }

        private void RebuildWebcamList()
        {
            listBox1.Items.Clear();
            foreach (WebcamProperties properties in _webcamProperies)
            {
                listBox1.Items.Add(properties);
            }
        }
        
        private void SetProperties()
        {
            if (listBox1.SelectedItem == null)
            {
                textBox1.Text = string.Empty;
                PropertiesGroup.Enabled = false;
            }
            else
            {
                textBox1.Text = (listBox1.SelectedItem as WebcamProperties).Name;
                PropertiesGroup.Enabled = true;
            }
        }

        private void RemoveWebcam_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                _webcamProperies.Remove(listBox1.SelectedItem as WebcamProperties);
                RebuildWebcamList();
                SetProperties();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (listBox1.SelectedItem != null)
            {
                (listBox1.SelectedItem as WebcamProperties).Name = textBox1.Text;
                RebuildWebcamList();
                listBox1.SelectedIndex = selectedIndex;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void FillDevicesList()
        {
            _inputDevices = _capture.getDevices();
            foreach (DirectShowLib.DsDevice dev in _inputDevices)
            {
                listBox2.Items.Add(dev.Name);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (listBox1.SelectedItem as WebcamProperties).CaptureDeviceIndex = listBox2.SelectedIndex;
        }


        public void SetWebcam(int webcamDisplay, int number)
        {
            try
            {
                (listBox1.Items[webcamDisplay] as WebcamProperties).CaptureDeviceIndex = number;
            }
            catch (Exception)
            {}
        }
    }
}
