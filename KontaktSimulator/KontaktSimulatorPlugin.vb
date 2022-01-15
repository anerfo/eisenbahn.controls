Public Class KontaktSimulatorPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private theKontaktSimulator As New KontaktSimulator
    Private theKontaktDarsteller As New KontaktSimulation

    Public ReadOnly Property beschreibung As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "ermöglicht das Simulieren von Rückmeldemodulen von der Anlage"
        End Get
    End Property

    Public ReadOnly Property name As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "KontaktSimulation"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return {theKontaktSimulator}
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim eb As Communication.KernelInterface = Referenz.getReferenceToObject("Communication.KernelInterface", Me)
        theKontaktSimulator.init(eb)
        theKontaktDarsteller.init(theKontaktSimulator)
        Referenz.registerGUIControl(theKontaktDarsteller)
        eb.registriereFuerKontaktEvents(theKontaktDarsteller)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen

    End Sub
End Class
