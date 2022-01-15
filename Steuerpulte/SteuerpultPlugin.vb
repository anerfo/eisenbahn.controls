Public Class SteuerpultPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private theSteuerpulte As New Steuerpulte()

    Public ReadOnly Property beschreibung As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "Stellt Steuerpulte zum Steuern von Loks bereit"
        End Get
    End Property

    Public ReadOnly Property name As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "Steuerpulte"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return Nothing
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim eb As Communication.KernelInterface
        Dim dummystart As V5PluginKompaitibilitaet.DummyStartInterface = Referenz.getReferenceToObject("V5PluginKompaitibilitaet.DummyStartInterface", Me)

        Referenz.registerGUIControl(theSteuerpulte)
        theSteuerpulte.SteuerpulteLaden()
        eb = Referenz.getReferenceToObject("Communication.KernelInterface", Me)
        eb.registriereFuerLokEvents(theSteuerpulte)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen
        theSteuerpulte.SteuerpulteSpeichern()
    End Sub
End Class
