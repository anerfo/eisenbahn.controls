using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webcams
{
    public interface IWebcamController
    {
        void SetWebcam(int webcamDisplay, int number);
    }
}
