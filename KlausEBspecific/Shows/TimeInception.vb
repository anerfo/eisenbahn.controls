Public Class TimeInception
    Inherits ShowBase

    Public Sub New(ByVal dmxServer As DMXServer.IDMXServer, ByVal eb As Communication.KernelInterface)
        MyBase.New(dmxServer, eb)
    End Sub

    Public Overrides Sub RunShow()

        Dim startedAt As Long
        LoadMusic("Hans Zimmer - Time (Inception).wav")

        For i As Integer = 1 To 8
            _dmxServer.SetData(i, 0)
        Next


        PlayMusic(False)
        startedAt = GetTimeInMS(DateTime.Now)

        SleepUntil(3000, startedAt)
        PerformFades({New FadeInformation(1, 0, 130)}, 3000)
        SleepUntil(9000, startedAt)
        PerformFades({New FadeInformation(1, 130, 0), New FadeInformation(2, 0, 130)}, 6000)
        SleepUntil(15000, startedAt)
        PerformFades({New FadeInformation(2, 130, 0), New FadeInformation(3, 0, 130)}, 6000)
        SleepUntil(21000, startedAt)
        PerformFades({New FadeInformation(3, 130, 0), New FadeInformation(4, 0, 130)}, 6000)
        SleepUntil(27000, startedAt)
        PerformFades({New FadeInformation(4, 130, 0), New FadeInformation(5, 0, 130)}, 6000)
        SleepUntil(33000, startedAt)
        PerformFades({New FadeInformation(5, 130, 0), New FadeInformation(6, 0, 130)}, 6000)
        SleepUntil(39000, startedAt)
        PerformFades({New FadeInformation(6, 130, 0), New FadeInformation(7, 0, 130)}, 6000)
        SleepUntil(42000, startedAt)
        PerformFades({New FadeInformation(7, 130, 0), New FadeInformation(4, 0, 130)}, 11000)
        SleepUntil(50000, startedAt)
        PerformFades({New FadeInformation(4, 130, 180)}, 10000)
        SleepUntil(61000, startedAt)
        PerformFades({New FadeInformation(4, 180, 130), New FadeInformation(3, 0, 180), New FadeInformation(5, 0, 180)}, 10000)
        SleepUntil(84000, startedAt)
        PerformFades({New FadeInformation(4, 130, 0), New FadeInformation(3, 180, 0), New FadeInformation(5, 180, 0)}, 20000)
        SleepUntil(123000, startedAt)
        PerformFades({New FadeInformation(7, 30, 180), New FadeInformation(6, 30, 180)}, 6000)
        SleepUntil(129000, startedAt)
        PerformFades({New FadeInformation(5, 30, 180)}, 6000)
        SleepUntil(135000, startedAt)
        PerformFades({New FadeInformation(4, 30, 180)}, 6000)
        SleepUntil(141000, startedAt)
        PerformFades({New FadeInformation(3, 30, 180)}, 6000)
        SleepUntil(144000, startedAt)
        PerformFades({New FadeInformation(2, 30, 180)}, 6000)
        SleepUntil(147000, startedAt)
        PerformFades({New FadeInformation(1, 30, 180)}, 6000)
        SleepUntil(176000, startedAt)
        SleepUntil(212000, startedAt)
        PerformFades({New FadeInformation(7, 180, 40),
                      New FadeInformation(6, 180, 40),
                      New FadeInformation(5, 180, 40),
                      New FadeInformation(4, 180, 60),
                      New FadeInformation(3, 180, 60),
                      New FadeInformation(2, 180, 60),
                      New FadeInformation(1, 180, 60)}, 3000)
        SleepUntil(248000, startedAt)
        PerformFades({New FadeInformation(7, 40, 0),
                      New FadeInformation(6, 40, 0),
                      New FadeInformation(5, 40, 0),
                      New FadeInformation(4, 60, 0),
                      New FadeInformation(3, 60, 0),
                      New FadeInformation(2, 60, 0),
                      New FadeInformation(1, 60, 0)}, 3000)
        PerformFades({New FadeInformation(6, 0, 130)}, 3700)
        SleepUntil(275000, startedAt)
        PerformFades({New FadeInformation(6, 130, 0)}, 100)
        PerformFades({New FadeInformation(7, 0, 255)}, 100)
        PerformFades({New FadeInformation(7, 255, 0)}, 10000)

        StopMusic()
    End Sub
End Class
