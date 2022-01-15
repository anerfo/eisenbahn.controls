Public Class StellwerkUpdater
    Implements Communication.WeichenEventUpdateInterface
    Implements Communication.KontaktEventUpdateInterface

    Private stellwerkman As StellwerkMngr

    Public Sub init(ByRef StellwerkManager As StellwerkMngr)
        stellwerkman = StellwerkManager
    End Sub

    Public Sub update(ByVal Weiche() As Klassen.Weiche) Implements Communication.WeichenEventUpdateInterface.update
        stellwerkman.Aktualisieren(V5PluginKompaitibilitaet.definitionen.Typen.Weiche)
    End Sub

    Public Sub update1(ByVal Kontakte() As Klassen.Kontakt) Implements Communication.KontaktEventUpdateInterface.update
        stellwerkman.Aktualisieren(V5PluginKompaitibilitaet.definitionen.Typen.Kontakt)
    End Sub
End Class
