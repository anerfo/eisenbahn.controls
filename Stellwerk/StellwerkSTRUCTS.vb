Imports V5PluginKompaitibilitaet
Imports Newtonsoft.Json

Structure STRUCT_Bilder_in_Richtung     'Struktur: wieviele Bilder in X und Y richtung angezeigt werden sollen
    Public X As Integer                         ' Sozusagen die Auflösung des Stellwerks
    Public Y As Integer
    Public Xdots_per_Pic As Integer
    Public Ydots_per_Pic As Integer
End Structure

Class Skriptbefehl  'stellt die Struktur des ganzen Skriptes dar, das für ein Feld angegeben werden kann
    'Außerdem die nötigen Funktionen, die gebraucht werden
    Private Scripts As List(Of BaseCommand)

    Public Sub New()
        Scripts = New List(Of BaseCommand)
    End Sub

    Public Sub BefehlHinzu(ByVal Weichenadresse As Integer, ByVal Richtung As definitionen.Weichen_Zustaende)
        Me.Scripts.Add(New WeichenCommand(Weichenadresse, Richtung))
    End Sub

    Public Sub MusikBefehlHinzu(ByVal file As String)
        Me.Scripts.Add(New MusicCommand(file))
    End Sub

    Public Sub BefehlLöschen(ByVal Nummer As Integer)
        Try
            Me.Scripts.RemoveAt(Nummer)
        Catch

        End Try
    End Sub

    Public Sub BefehleAusführen()
        For Each script As BaseCommand In Scripts

            If TypeOf script Is WeichenCommand Then
                Dim weichenCommand = DirectCast(script, WeichenCommand)
                If weichenCommand.Direction = definitionen.Weichen_Zustaende.None Then
                    Eisenbahn.WeicheSchalten(weichenCommand.Number, definitionen.Weichen_Zustaende.None)
                Else
                    Eisenbahn.WeicheSchalten(weichenCommand.Number, weichenCommand.Direction)
                End If
            ElseIf TypeOf script Is MusicCommand Then
                Dim musicCommand = DirectCast(script, MusicCommand)
                V5PluginKompatibilitaet.mediaProvider.PlayMusic(musicCommand.File)
            End If
        Next
    End Sub

    Public Sub Gleichsetzen(ByVal OperatorB As Skriptbefehl)
        For Each script As BaseCommand In OperatorB.Scripts
            Scripts.Add(script)
        Next
    End Sub

    Public Function GetBefehlString(ByVal Nummer As Integer) As String
        If Nummer < Me.Scripts.Count Then
            Return Me.Scripts(Nummer).ScriptToString()
        Else
            Return ""
        End If
    End Function

    Public ReadOnly Property BefehlRichtung(ByVal Nummer As Integer)
        Get
            If Nummer < Me.Scripts.Count Then
                If TypeOf Me.Scripts(Nummer) Is WeichenCommand Then
                    Return DirectCast(Me.Scripts(Nummer), WeichenCommand).Direction
                End If
            End If
            Return definitionen.Weichen_Zustaende.None
        End Get
    End Property

    Public ReadOnly Property BefehlAdresse(ByVal Nummer As Integer)
        Get
            If Nummer < Me.Scripts.Count Then
                If TypeOf Me.Scripts(Nummer) Is WeichenCommand Then
                    Return DirectCast(Me.Scripts(Nummer), WeichenCommand).Number
                End If
            End If
            Return 0
        End Get
    End Property

    Public ReadOnly Property GetAnzahl()
        Get
            Return Me.Scripts.Count
        End Get
    End Property

    Public Function Save() As String
        Dim result As String = JsonConvert.SerializeObject(Scripts)
        Return result
    End Function

    Public Sub Load(ByVal json As String)
        If Not json Is Nothing Then
            Try
                Dim scipts = JsonConvert.DeserializeObject(Of List(Of Linq.JObject))(json)

                For Each currentScript In scipts
                    Dim script = currentScript.ToString()
                    Dim command As BaseCommand = Nothing
                    Try
                        If script.Contains("WeichenCommand") Then
                            command = JsonConvert.DeserializeObject(Of WeichenCommand)(script)
                        ElseIf script.Contains("MusicCommand") Then
                            command = JsonConvert.DeserializeObject(Of MusicCommand)(script)
                        End If
                    Catch ex As Exception
                    End Try
                    If Not command Is Nothing Then
                        Me.Scripts.Add(command)
                    End If
                Next
            Catch ex As Exception
                Return
            End Try
        End If
    End Sub
End Class
