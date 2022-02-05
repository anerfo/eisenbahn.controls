Public Class InTheBeginning
    Inherits ShowBase

    Declare Function waveOutSetVolume Lib "winmm.dll" (ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As Integer

    Dim controlTrains As Boolean

    Public Sub New(ByVal dmxServer As DMXServer.IDMXServer, ByVal eb As Communication.KernelInterface)
        MyBase.New(dmxServer, eb)
    End Sub

    Public Overrides Sub RunShow()
        controlTrains = False

        If (controlTrains) Then
            _eb.nothalt = True
        End If

        Dim musicplayer As System.Media.SoundPlayer
        waveOutSetVolume(IntPtr.Zero, &HFFFF)

        Dim startedAt As Long
        Dim filePath As String = Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Media\Glocken.wav"
        If (Not System.IO.File.Exists(filePath)) Then
            Return
        End If

        For i As Integer = 1 To 8
            _dmxServer.SetData(i, 0)
        Next

        startedAt = GetTimeInMS(DateTime.Now)

        musicplayer = New System.Media.SoundPlayer(filePath)

        PerformFades({New FadeInformation(8, 0, 150)}, 500)
        PerformFades({New FadeInformation(8, 150, 0)}, 20000)

        '_eb.weicheSchalten(7, Klassen.WeichenRichtung.rechts)

        Threading.Thread.Sleep(5000)
        musicplayer.PlayLooping()
        startedAt = GetTimeInMS(DateTime.Now)
        Threading.Thread.Sleep(8000)

        PerformFades({New FadeInformation(2, 40, 60)}, 10000)
        SleepUntil(30300, startedAt)
        PerformFades({New FadeInformation(2, 60, 0)}, 10000)

        SleepUntil(50000, startedAt)

        For i As Integer = &HFFFF To 0 Step -&HF
            waveOutSetVolume(IntPtr.Zero, i)
            System.Threading.Thread.Sleep(10)
        Next
        musicplayer.Stop()
        waveOutSetVolume(IntPtr.Zero, &HFFFF)

        filePath = Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Media\In the beginning.wav"
        If (Not System.IO.File.Exists(filePath)) Then
            Return
        End If


        musicplayer = New System.Media.SoundPlayer(filePath)

        SleepUntil(60000, startedAt)
        musicplayer.Play()
        startedAt = GetTimeInMS(DateTime.Now)

        SleepUntil(49500, startedAt)

        PerformFades({New FadeInformation(4, 0, 60)}, 100)

        SleepUntil(57500, startedAt)

        PerformFades({New FadeInformation(3, 0, 60), New FadeInformation(5, 0, 60)}, 100)

        SleepUntil(63000, startedAt)

        PerformFades({New FadeInformation(2, 0, 60), New FadeInformation(6, 0, 60)}, 100)

        SleepUntil(68000, startedAt)

        PerformFades({New FadeInformation(1, 0, 60), New FadeInformation(7, 0, 60)}, 100)

        filePath = Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Media\Let there be light.wav"
        If (Not System.IO.File.Exists(filePath)) Then
            Return
        End If

        musicplayer = New System.Media.SoundPlayer(filePath)

        SleepUntil(84600, startedAt)
        musicplayer.Play()
        startedAt = GetTimeInMS(DateTime.Now)

        SleepUntil(11000, startedAt)

        PerformFades({New FadeInformation(1, 60, 80), New FadeInformation(2, 60, 80)}, 2000)

        SleepUntil(26500, startedAt)

        PerformFades({New FadeInformation(1, 80, 60), New FadeInformation(2, 80, 60), New FadeInformation(6, 60, 80), New FadeInformation(7, 60, 80)}, 2000)

        SleepUntil(44000, startedAt)
        PerformFades({New FadeInformation(6, 80, 60), New FadeInformation(7, 80, 60), New FadeInformation(3, 60, 80)}, 10000)

        SleepUntil(66000, startedAt)
        PerformFades({New FadeInformation(4, 60, 80)}, 10000)

        SleepUntil(99000, startedAt)
        PerformFades({New FadeInformation(5, 60, 80), New FadeInformation(3, 80, 70), New FadeInformation(4, 80, 70)}, 1000)
        PerformFades({New FadeInformation(4, 70, 90)}, 22000)

        SleepUntil(132500, startedAt)
        PerformFades({New FadeInformation(8, 40, 80)}, 8000)

        SleepUntil(176900, startedAt)
        PerformFades({New FadeInformation(1, 60, 0),
                      New FadeInformation(2, 60, 0),
                      New FadeInformation(3, 70, 0),
                      New FadeInformation(4, 90, 0),
                      New FadeInformation(5, 80, 0),
                      New FadeInformation(6, 60, 0),
                      New FadeInformation(7, 60, 0),
                      New FadeInformation(8, 80, 0)}, 100)

        SleepUntil(186400, startedAt)
        PerformFades({New FadeInformation(3, 40, 80), New FadeInformation(4, 40, 80), New FadeInformation(5, 40, 80)}, 100)

        SleepUntil(199000, startedAt)

        SleepUntil(223000, startedAt)
        PerformFades({New FadeInformation(1, 0, 80), New FadeInformation(2, 0, 80)}, 1000)
        PerformFades({New FadeInformation(4, 90, 100)}, 1000)

        SleepUntil(248000, startedAt)
        PerformFades({New FadeInformation(6, 0, 80), New FadeInformation(7, 0, 80), New FadeInformation(4, 100, 80)}, 5000)

        SleepUntil(267000, startedAt)
        PerformFades({New FadeInformation(1, 80, 100),
                      New FadeInformation(2, 80, 100),
                      New FadeInformation(3, 80, 100),
                      New FadeInformation(4, 80, 100),
                      New FadeInformation(5, 80, 100),
                      New FadeInformation(6, 80, 100),
                      New FadeInformation(7, 80, 100)}, 6000)

        SleepUntil(281000, startedAt)
        PerformFades({New FadeInformation(1, 100, 0), New FadeInformation(7, 100, 0)}, 2000)
        SleepUntil(284000, startedAt)
        PerformFades({New FadeInformation(2, 100, 0), New FadeInformation(6, 100, 0)}, 2000)
        SleepUntil(287000, startedAt)
        PerformFades({New FadeInformation(3, 100, 0), New FadeInformation(5, 100, 0)}, 2000)
        SleepUntil(290000, startedAt)
        PerformFades({New FadeInformation(4, 100, 0)}, 2000)
        'SleepUntil(297000, startedAt)
        'PerformFades({New FadeInformation(1, 100, 0),
        '              New FadeInformation(2, 100, 0),
        '              New FadeInformation(3, 100, 0),
        '              New FadeInformation(4, 100, 0),
        '              New FadeInformation(5, 100, 0),
        '              New FadeInformation(6, 100, 0),
        '              New FadeInformation(7, 100, 0)}, 10000)



        SleepUntil(297300, startedAt)

        Supernova()

    End Sub

    Private Sub Supernova()
        If (controlTrains) Then
            _eb.nothalt = True
        End If


        Dim musicplayer As System.Media.SoundPlayer
        waveOutSetVolume(IntPtr.Zero, &HFFFF)

        Dim startedAt As Long
        Dim filePath As String = Strings.Left(System.Reflection.Assembly.GetEntryAssembly.Location, Strings.InStrRev(System.Reflection.Assembly.GetEntryAssembly.Location, "\")) & "Media\Supernova.wav"
        If (Not System.IO.File.Exists(filePath)) Then
            Return
        End If

        For i As Integer = 1 To 8
            _dmxServer.SetData(i, 0)
        Next

        startedAt = GetTimeInMS(DateTime.Now)

        musicplayer = New System.Media.SoundPlayer(filePath)
        musicplayer.Play()
        startedAt = GetTimeInMS(DateTime.Now)

        'Hier loslegen
        SleepUntil(30000, startedAt)
        If (controlTrains) Then
            _eb.nothalt = False
        End If
        SleepUntil(50000, startedAt)
        PerformFades({New FadeInformation(4, 0, 50)}, 30000)

        PerformFades({New FadeInformation(4, 50, 100),
                      New FadeInformation(3, 0, 50)}, 20000)

        PerformFades({New FadeInformation(4, 100, 125),
                      New FadeInformation(3, 50, 100),
                      New FadeInformation(5, 0, 100)}, 20000)



        PerformFades({New FadeInformation(1, 0, 100),
                      New FadeInformation(2, 0, 100),
                      New FadeInformation(3, 100, 125),
                      New FadeInformation(4, 125, 150),
                      New FadeInformation(5, 100, 125),
                      New FadeInformation(6, 0, 100),
                      New FadeInformation(7, 0, 100)}, 10000)
        SleepUntil(135000, startedAt)

        If (controlTrains) Then
            _eb.weicheSchalten(4, Klassen.WeichenRichtung.links)
        End If

        SleepUntil(140000, startedAt)
        If (controlTrains) Then
            _eb.weicheSchalten(4, Klassen.WeichenRichtung.rechts)
        End If

        SleepUntil(160000, startedAt)

        If (controlTrains) Then
            _eb.weicheSchalten(7, Klassen.WeichenRichtung.links)
        End If

        SleepUntil(170000, startedAt)
        If (controlTrains) Then
            _eb.weicheSchalten(7, Klassen.WeichenRichtung.rechts)
        End If

        SleepUntil(200000, startedAt)

        PerformFades({New FadeInformation(1, 100, 0),
                      New FadeInformation(2, 100, 0),
                      New FadeInformation(3, 125, 0),
                      New FadeInformation(4, 150, 0),
                      New FadeInformation(5, 125, 0),
                      New FadeInformation(6, 100, 0),
                      New FadeInformation(7, 100, 0)}, 3000)
        SleepUntil(210000, startedAt)
        If (controlTrains) Then
            _eb.nothalt = True
        End If
    End Sub
End Class
