using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webcams
{
    public class WebcamPlugin : PluginManagerLibrary.PluginInterface
    {
        WebcamController _webCamController;
        WebcamPluginController _webcamPluginController = new WebcamPluginController();

        public string beschreibung
        {
            get { return "Zeigt das Bild einer angeschlossenen Webcam."; }
        }

        public string name
        {
            get { return "Webcams"; }
        }

        public object[] pluginInitalisieren()
        {
            return new object[] { _webcamPluginController};
        }

        public void pluginStarten(PluginManagerLibrary.InterfaceFuerPlugins Referenz)
        {
            Daten.DatenInterface dataStorage = Referenz.getReferenceToObject("Daten.DatenInterface", this) as Daten.DatenInterface;
            _webCamController = new WebcamController(Referenz, dataStorage);
            _webCamController.LoadConfiguration();
            _webcamPluginController.WebcamController = _webCamController;
            Referenz.registerConfigControl(_webCamController);
        }

        public void pluginStoppen()
        {
            _webCamController.SaveConfiguration();
        }
    }
}
