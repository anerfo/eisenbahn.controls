using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using driversCabSim;
using System.IO;

namespace Webcams
{
    public partial class WebcamDisplay : UserControl
    {
        Capture _webcamCapturer;
        Vlc.DotNet.Forms.VlcControl _vlcControl;

        public WebcamDisplay()
        {
            InitializeComponent();
            _webcamCapturer = new driversCabSim.Capture();
            this.Dock = DockStyle.Fill;

            _vlcControl = new Vlc.DotNet.Forms.VlcControl();
            _vlcControl.BeginInit();
            _vlcControl.VlcLibDirectory = new DirectoryInfo(@"C:\Program Files (x86)\VideoLAN\VLC");
            _vlcControl.VlcMediaplayerOptions = new[] { "--network-caching=50" };
            _vlcControl.EndInit();
            _vlcControl.Dock = DockStyle.Fill;
            _vlcControl.Visible = false;
            panel1.Controls.Add(_vlcControl);
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

        public void Initialize(Uri url)
        {
            _vlcControl.Visible = true;
            _vlcControl.SetMedia(url);
            _vlcControl.Play();
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
