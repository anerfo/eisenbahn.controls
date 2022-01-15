using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webcams
{
    class WebcamPluginController : IWebcamController
    {
        public WebcamController WebcamController { get; set; }

        private delegate void WebcamSetter(int webcamDisplay, int number);
        private WebcamSetter WebcamSetterDelegate;

        public WebcamPluginController()
        {
            WebcamSetterDelegate = new WebcamSetter(SetWebcam);
        }

        public void SetWebcam(int webcamDisplay, int number)
        {
            if (WebcamController.InvokeRequired)
            {
                WebcamController.Invoke(WebcamSetterDelegate, new object[] { webcamDisplay, number });
            }
            else
            {
                if (WebcamController != null)
                {
                    WebcamController.SetWebcam(webcamDisplay, number);
                }
            }
        }
    }
}