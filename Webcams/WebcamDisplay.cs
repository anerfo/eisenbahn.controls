using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using driversCabSim;

namespace Webcams
{
    public partial class WebcamDisplay : UserControl
    {
        Capture _webcamCapturer;
        
        public WebcamDisplay()
        {
            InitializeComponent();
            _webcamCapturer = new driversCabSim.Capture();
            this.Dock = DockStyle.Fill;
        }

        private void WebcamDisplay_Load(object sender, EventArgs e)
        {

        }

        public void Initialize(int sourceIndex)
        {
            _webcamCapturer.CloseInterfaces();
            _webcamCapturer.setVideoControl(panel1);
            _webcamCapturer.CaptureVideo(sourceIndex);
        }

        public string WebcamName
        {
            set { WebcamNameControl.Text = value; }
        }

        public ListBox.ObjectCollection AvailableWebcams
        {
            set
            {
                listBox1.Items.Clear();
                foreach (var item in value)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialize(listBox1.SelectedIndex);
        }

        private void WebcamDisplay_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.Width * 3 / 4;
        }
    }
}
