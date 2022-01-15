Public Class StellwerkPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private stellwerkManager As New StellwerkMngr
    Private stellwerk As StellwerkControl
    Private stellwerkKonfig As New StellwerkKonfigurator
    Private stellwerkUpdate As New StellwerkUpdater

    Public ReadOnly Property beschreibung() As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "anpassbares Stellwerk"
        End Get
    End Property

    Public ReadOnly Property name() As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "Stellwerk"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return Nothing
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim eb As Communication.KernelInterface = Referenz.getReferenceToObject("Communication.KernelInterface", Me)
        Dim dummystart As V5PluginKompaitibilitaet.DummyStartInterface = Referenz.getReferenceToObject("V5PluginKompaitibilitaet.DummyStartInterface", Me)

        stellwerkManager.mainReference = Referenz
        'Pics.Finde_Bilder(Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Pics\")

        eb.registriereFuerKontaktEvents(stellwerkUpdate)
        eb.registriereFuerWeichenEvents(stellwerkUpdate)

        stellwerkManager.Initialize(Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Pics\")
        stellwerkKonfig.init(stellwerkManager)
        stellwerkUpdate.init(stellwerkManager)
        Referenz.registerConfigControl(stellwerkKonfig)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen
        stellwerkManager.Stellwerke_Speichern()
    End Sub
End Class
