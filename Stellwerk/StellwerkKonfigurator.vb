Public Class StellwerkKonfigurator

    Private stellwerkMan As StellwerkMngr

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        stellwerkMan.Stellwerkhinzufügen()
    End Sub

    Public Sub init(ByRef StellwerkManager As StellwerkMngr)
        stellwerkMan = StellwerkManager
    End Sub
End Class
