Public Class DriversCabSimPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private theDriversCabSim As New driversCabSim

    Public ReadOnly Property beschreibung As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "Simuliert einen Führerstand"
        End Get
    End Property

    Public ReadOnly Property name As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "Führerstandsimulation"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return Nothing
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim ebRef As Communication.KernelInterface = Referenz.getReferenceToObject("Communication.KernelInterface", Me)

        Referenz.registerGUIControl(theDriversCabSim)

        theDriversCabSim.init(ebRef)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen

    End Sub
End Class
