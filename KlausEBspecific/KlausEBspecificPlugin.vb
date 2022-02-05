Imports Daten

Public Class KlausEBspecificPlugin
    Implements PluginManagerLibrary.PluginInterface

    Private automatiken As Automatikprogramme = Nothing

    Public ReadOnly Property beschreibung As String Implements PluginManagerLibrary.PluginInterface.beschreibung
        Get
            Return "Implementiert einige Funktionen die für Klaus Eisenbahn spezifisch sind"
        End Get
    End Property

    Public ReadOnly Property name As String Implements PluginManagerLibrary.PluginInterface.name
        Get
            Return "Klaus EB spezifisch"
        End Get
    End Property

    Public Function pluginInitalisieren() As Object() Implements PluginManagerLibrary.PluginInterface.pluginInitalisieren
        Return Nothing
    End Function

    Public Sub pluginStarten(ByVal Referenz As PluginManagerLibrary.InterfaceFuerPlugins) Implements PluginManagerLibrary.PluginInterface.pluginStarten
        Dim ebRef As Communication.KernelInterface = Referenz.getReferenceToObject("Communication.KernelInterface", Me)
        Dim dmxServer As DMXServer.IDMXServer = Referenz.getReferenceToObject("DMXServer.IDMXServer", Me)
        Dim dataStorage As Daten.DatenInterface = Referenz.getReferenceToObject("Daten.DatenInterface", Me)
        Dim webcams As Webcams.IWebcamController = Referenz.getReferenceToObject("Webcams.IWebcamController", Me)
        Dim mediaProvider As MediaProvider.IMediaProvider = Referenz.getReferenceToObject("MediaProvider.IMediaProvider", Me)

        automatiken = New Automatikprogramme(ebRef, dataStorage, dmxServer, webcams, mediaProvider)

        Referenz.registerGUIControl(automatiken)
        Referenz.registerGUIControl(automatiken._kalteHerz)

        'startpos.init(ebRef)
        REM lokFolgen.init(ebRef)
    End Sub

    Public Sub pluginStoppen() Implements PluginManagerLibrary.PluginInterface.pluginStoppen
    End Sub
End Class
