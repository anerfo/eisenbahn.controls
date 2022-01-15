Public Class WeichensteuerungPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private dieWeichensteuerung As New Weichensteuerung
    Private dasWeichensteuerungsControl As New WeichensteuerungControl

    Public ReadOnly Property beschreibung As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "Schaltet die Weichen in die korrekte Richtung und in einen Startzustand"
        End Get
    End Property

    Public ReadOnly Property name As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "Weichensteuerung"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return {dieWeichensteuerung}
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim eb As Communication.KernelInterface = Referenz.getReferenceToObject("Communication.KernelInterface", Me)
        Referenz.registerGUIControl(dasWeichensteuerungsControl)
        dieWeichensteuerung.init(Referenz.getReferenceToObject("Daten.DatenInterface", Me), eb)
        dasWeichensteuerungsControl.init(dieWeichensteuerung)
        eb.registriereFuerWeichenEvents(dieWeichensteuerung)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen
        dieWeichensteuerung.WeichenParameterSpeichern()
    End Sub
End Class
