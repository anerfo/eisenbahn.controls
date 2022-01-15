Imports System.IO

Public Class LokBilderLoader

    Private LokBilder() As LokBild

    Public Sub New(ByVal Pfad As String)
        Dim endungen() As String = {"*.jpg", "*.gif", "*.bmp"}
        Dim foundpics() As String

        If Not System.IO.Directory.Exists(Pfad) Then
            System.IO.Directory.CreateDirectory(Pfad)
        End If

        For Each pattern As String In endungen
            foundpics = Directory.GetFileSystemEntries(Pfad, pattern)
            If foundpics.Length <> 0 Then
                For i As Integer = 0 To foundpics.Length - 1
                    Dim Loknummer As Integer = Integer.Parse(Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), "\") + 1, Strings.InStrRev(foundpics(i), ".") - Strings.InStrRev(foundpics(i), "\") - 1))
                    If LokBilder Is Nothing Then
                        ReDim LokBilder(0)
                    Else
                        ReDim Preserve LokBilder(LokBilder.Length)
                    End If
                    Try
                        LokBilder(LokBilder.Length - 1) = New LokBild(Image.FromFile(foundpics(i)), Loknummer)
                    Catch ex As Exception
                        Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Konnte Bilder nicht laden: " & ex.Message, True)
                    End Try
                Next
                End If
        Next
    End Sub

    Public ReadOnly Property AnzahlBilder() As Integer
        Get
            Return LokBilder.Length - 1
        End Get
    End Property

    Default Public ReadOnly Property LokBild(ByVal Loknummer As Integer) As Image
        Get
            If Not LokBilder Is Nothing Then
                For i As Integer = 0 To LokBilder.Length - 1
                    If LokBilder(i).Loknummer = Loknummer Then
                        Return LokBilder(i).Image
                    End If
                Next
            End If
            Return Nothing
        End Get
    End Property

End Class
