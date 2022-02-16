Imports System.Text.RegularExpressions

Public Class DasKalteHerz
    Enum ProgressEvent
        StepForward
        StepBackward
        JumpToNextChapter
        JumpToPreviousChapter
        JumpToStart
        JumpAuto
    End Enum

    Public Event StoryProgress(ByVal progressEvent As ProgressEvent)
    Public Event VideoFinished()

    Private ImageBasePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase),
                                                   "..", "..", "..", "Plugins", "KlausEBspecific", "Das kalte Herz Fotos")
    Private _eb As Communication.KernelInterface
    Private _daten As Daten.DatenInterface
    Private _dmxServer As DMXServer.IDMXServer

    Public Sub New(ByRef eb As Communication.KernelInterface, ByRef daten As Daten.DatenInterface, ByRef dmxServer As DMXServer.IDMXServer)
        InitializeComponent()
        _eb = eb
        _daten = daten
        _dmxServer = dmxServer
        Dock = Windows.Forms.DockStyle.Fill
        StoryPictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom
        'AxWindowsMediaPlayer1.uiMode = "none"
    End Sub

    Private Sub DasKalteHerz_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click, StoryPictureBox.Click, StoryLabel.Click
        RaiseEvent StoryProgress(ProgressEvent.StepForward)
    End Sub

    Public Property StoryText As String
        Get
            Return StoryLabel.Text
        End Get
        Set(value As String)
            Dim regex As Regex = New Regex("(\d+-\d+):(.*)")
            Dim matches = regex.Matches(value)
            Dim displayed = False
            If matches.Count > 0 Then
                If matches.Item(0).Groups.Count >= 2 Then
                    KapitelLabel.Text = matches.Item(0).Groups.Item(1).Value
                    StoryLabel.Text = matches.Item(0).Groups.Item(2).Value
                    displayed = True
                End If
            End If
            If displayed = False Then
                KapitelLabel.Text = ""
                StoryLabel.Text = value
            End If
        End Set
    End Property

    Public WriteOnly Property StoryImage As String
        Set(value As String)
            StoryPictureBox.Load(System.IO.Path.Combine(ImageBasePath, value))
        End Set
    End Property

    Public WriteOnly Property StoryColor As System.Drawing.Color
        Set(value As System.Drawing.Color)
            StoryLabel.BackColor = value
        End Set
    End Property

    Public Property StoryFont As System.Drawing.Font
        Get
            Return StoryLabel.Font
        End Get
        Set(value As System.Drawing.Font)
            StoryLabel.Font = value
        End Set
    End Property

    Public Sub StartVideo(ByVal path As String)
        AxWindowsMediaPlayer1.Visible = True
        AxWindowsMediaPlayer1.URL = path
    End Sub

    Public Sub StopVideo()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub


    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As System.Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If AxWindowsMediaPlayer1.playState = WMPPlayState.wmppsStopped Then
            AxWindowsMediaPlayer1.Visible = False
            RaiseEvent VideoFinished()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        RaiseEvent StoryProgress(ProgressEvent.StepForward)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToPreviousChapter)
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToNextChapter)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToStart)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpAuto)
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        RaiseEvent StoryProgress(ProgressEvent.StepBackward)
    End Sub

End Class
