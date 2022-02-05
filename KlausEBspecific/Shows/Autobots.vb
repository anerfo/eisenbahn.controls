Public Class Autobots
    Inherits ShowBase

    Public Sub New(ByVal dmxServer As DMXServer.IDMXServer, ByVal eb As Communication.KernelInterface)
        MyBase.New(dmxServer, eb)
    End Sub

    Public Overrides Sub RunShow()
        Dim startedAt As Long

        LoadMusic("Transformers - Autobots.wav")

        For i As Integer = 1 To 8
            _dmxServer.SetData(i, 0)
        Next

        _eb.weicheSchalten(4, Klassen.WeichenRichtung.rechts)
        System.Threading.Thread.Sleep(500)
        _eb.weicheSchalten(9, Klassen.WeichenRichtung.rechts)
        System.Threading.Thread.Sleep(500)
        _eb.weicheSchalten(11, Klassen.WeichenRichtung.rechts)
        System.Threading.Thread.Sleep(500)
        _eb.weicheSchalten(7, Klassen.WeichenRichtung.links)
        System.Threading.Thread.Sleep(30000)
        _eb.weicheSchalten(7, Klassen.WeichenRichtung.rechts)

        PlayMusic(False)

        startedAt = GetTimeInMS(DateTime.Now)

        SleepUntil(6500, startedAt)
        PerformFades({New FadeInformation(11, 30, 120)}, 13000)
        SleepUntil(19500, startedAt)
        _eb.weicheSchalten(4, Klassen.WeichenRichtung.links)
        PerformFades({New FadeInformation(4, 40, 120), New FadeInformation(11, 120, 0)}, 20000)
        _eb.weicheSchalten(4, Klassen.WeichenRichtung.rechts)
        PerformFades({New FadeInformation(4, 120, 160)}, 13500)
        PerformFades({New FadeInformation(1, 0, 160), New FadeInformation(4, 160, 0)}, 6500)
        SleepUntil(60500, startedAt)
        _eb.weicheSchalten(9, Klassen.WeichenRichtung.links)
        _eb.weicheSchalten(11, Klassen.WeichenRichtung.links)
        PerformFades({New FadeInformation(1, 160, 200)}, 1500)
        PerformFades({New FadeInformation(1, 200, 240), New FadeInformation(7, 40, 120)}, 1500)
        PerformFades({New FadeInformation(7, 120, 200)}, 1500)
        SleepUntil(70500, startedAt)
        PerformFades({New FadeInformation(1, 200, 120)}, 1500)
        PerformFades({New FadeInformation(1, 120, 0), New FadeInformation(7, 200, 120)}, 1500)
        PerformFades({New FadeInformation(7, 120, 0)}, 1500)
        SleepUntil(75000, startedAt)
        SleepUntil(80500, startedAt)
        '      PerformFades({New FadeInformation(7, 200, 0)}, 3000)
        SleepUntil(84000, startedAt)
        _eb.weicheSchalten(4, Klassen.WeichenRichtung.links)
        _eb.weicheSchalten(7, Klassen.WeichenRichtung.links)
        _eb.weicheSchalten(11, Klassen.WeichenRichtung.rechts)
        _eb.weicheSchalten(9, Klassen.WeichenRichtung.rechts)
        PerformFades({New FadeInformation(1, 0, 255), New FadeInformation(7, 0, 255), New FadeInformation(4, 0, 255)}, 3000)
        PerformFades({New FadeInformation(3, 0, 255), New FadeInformation(5, 0, 255)}, 3000)
        SleepUntil(94000, startedAt)
        _eb.weicheSchalten(9, Klassen.WeichenRichtung.rechts)
        _eb.weicheSchalten(4, Klassen.WeichenRichtung.rechts)
        _eb.weicheSchalten(7, Klassen.WeichenRichtung.rechts)
        PerformFades({New FadeInformation(2, 0, 255), New FadeInformation(6, 0, 255)}, 3000)
        SleepUntil(108000, startedAt)
        PerformFades({New FadeInformation(1, 255, 0), New FadeInformation(7, 255, 0)}, 3000)
        PerformFades({New FadeInformation(3, 255, 0), New FadeInformation(5, 255, 0)}, 3000)
        PerformFades({New FadeInformation(2, 255, 0), New FadeInformation(6, 255, 0)}, 3000)
        SleepUntil(115000, startedAt)
        _eb.weicheSchalten(9, Klassen.WeichenRichtung.links)
        _eb.weicheSchalten(11, Klassen.WeichenRichtung.links)
        PerformFades({New FadeInformation(1, 0, 255), New FadeInformation(7, 0, 255)}, 2000)
        SleepUntil(122000, startedAt)
        PerformFades({New FadeInformation(1, 255, 0), New FadeInformation(7, 255, 0)}, 6000)
        SleepUntil(132000, startedAt)
        PerformFades({New FadeInformation(4, 255, 50)}, 7000)
        SleepUntil(140700, startedAt)
        PerformFades({New FadeInformation(4, 50, 0)}, 100)
        PerformFades({New FadeInformation(11, 0, 255)}, 100)
        PerformFades({New FadeInformation(11, 255, 0)}, 10000)

        For i As Integer = 1 To 8
            _dmxServer.SetData(i, 0)
        Next
        StopMusic()
    End Sub
End Class
