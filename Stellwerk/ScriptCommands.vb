Imports V5PluginKompaitibilitaet
Imports Newtonsoft.Json

Public MustInherit Class BaseCommand
    Public MustOverride Function ScriptToString() As String
    Public Type As String
End Class

Public Class WeichenCommand
    Inherits BaseCommand

    Public Number As Integer
    Public Direction As definitionen.Weichen_Zustaende

    Public Sub New(ByRef number As Integer, ByRef richtung As definitionen.Weichen_Zustaende)
        Me.Number = number
        Me.Direction = richtung
        Type = "WeichenCommand"
    End Sub

    Public Overrides Function ScriptToString() As String
        If Direction = definitionen.Weichen_Zustaende.None Then
            Return Number & ": schalten"
        Else
            Return Number & ": " & Direction.ToString
        End If
    End Function
End Class

Public Class MusicCommand
    Inherits BaseCommand

    Public File As String

    Public Sub New(ByRef file As String)
        Me.File = file
        Type = "MusicCommand"
    End Sub

    Public Overrides Function ScriptToString() As String
        Return "Play " & File
    End Function
End Class

