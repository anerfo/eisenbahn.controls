Public MustInherit Class ShowBase

    Protected _dmxServer As DMXServer.IDMXServer
    Protected _eb As Communication.KernelInterface
    Protected _musicplayer As System.Media.SoundPlayer

#Region "Public Methods"
    Public Sub New(ByVal dmxServer As DMXServer.IDMXServer, ByVal eb As Communication.KernelInterface)
        _dmxServer = dmxServer
        _eb = eb
    End Sub

    Public MustOverride Sub RunShow()

    Public Sub StopShow()
        StopMusic()
    End Sub
#End Region

#Region "Protected Methods"
    Protected Sub SleepUntil(ByVal timeInMS As Long, ByVal startedAt As Long)
        Dim now As Long = GetTimeInMS(DateTime.Now)
        Dim wait As Integer = startedAt + timeInMS - now
        If (wait > 0) Then
            System.Threading.Thread.Sleep(wait)
        End If
    End Sub

    Protected Function GetTimeInMS(ByVal time As DateTime) As Long
        Dim diff As TimeSpan = time - DateTime.FromBinary(0)
        Return diff.TotalMilliseconds
    End Function

    Protected Class FadeInformation
        Public address As Integer
        Public fromValue As Integer
        Public toValue As Integer

        Public Sub New(ByVal addressVal As Integer, ByVal fromVal As Integer, ByVal ToVal As Integer)
            address = addressVal
            fromValue = fromVal
            toValue = ToVal
        End Sub
    End Class

    Protected Sub PerformFades(ByVal fades() As FadeInformation, ByVal duration As UInteger)
        Const stepTime As Integer = 10

        Dim stepCount = duration / stepTime
        Dim currentValues(fades.Count - 1) As Double
        Dim steps(fades.Count - 1) As Double
        For q As Integer = 0 To fades.Count - 1
            currentValues(q) = fades(q).fromValue
            steps(q) = (fades(q).toValue - fades(q).fromValue) / stepCount
        Next
        For i As Integer = 0 To stepCount - 1
            For q As Integer = 0 To fades.Count - 1
                currentValues(q) += steps(q)
                If (currentValues(q) > 0) Then
                    _dmxServer.SetData(fades(q).address, currentValues(q))
                Else
                    _dmxServer.SetData(fades(q).address, 0)
                End If
            Next
            System.Threading.Thread.Sleep(stepTime)
        Next
        System.Threading.Thread.Sleep(stepTime)
        For q As Integer = 0 To fades.Count - 1
            _dmxServer.SetData(fades(q).address, fades(q).toValue)
        Next
    End Sub

    Protected Function LoadMusic(ByVal filename As String) As Boolean
        Dim result As Boolean = False
        Dim filePath As String = Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location,
            Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Media\" + filename

        If (Not System.IO.File.Exists(filePath)) Then
            result = False
        Else
            StopMusic()
            _musicplayer = New System.Media.SoundPlayer(filePath)
            _musicplayer.LoadAsync()
            result = True
        End If

        Return result
    End Function

    Protected Sub PlayMusic(ByVal playLooping As Boolean)
        If Not (_musicplayer Is Nothing) Then
            While (Not _musicplayer.IsLoadCompleted)
                System.Threading.Thread.Sleep(100)
            End While
            If playLooping Then
                _musicplayer.PlayLooping()
            Else
                _musicplayer.Play()
            End If
        End If
    End Sub

    Protected Sub StopMusic()
        If Not (_musicplayer Is Nothing) Then
            _musicplayer.Stop()
        End If
    End Sub

#End Region
End Class


