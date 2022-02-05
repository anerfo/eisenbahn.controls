Imports System.IO
Imports System.Reflection

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

    Private ImageBasePath As String

    Public Sub New()
        InitializeComponent()
        ImageBasePath = Path.Combine(
            Path.GetDirectoryName(Uri.UnescapeDataString(New UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)),
            "..", "..", "..", "Plugins", "KlausEBspecific", "Das kalte Herz Fotos")
        If Directory.Exists(ImageBasePath) = False Then
            ImageBasePath = MediaProvider.Constants.GetMediaFolder()
        End If
        Dock = Windows.Forms.DockStyle.Fill
        StoryPictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom
    End Sub

    Private Sub DasKalteHerz_Click(sender As Object, e As EventArgs) Handles MyBase.Click, StoryPictureBox.Click, StoryLabel.Click
        RaiseEvent StoryProgress(ProgressEvent.StepForward)
    End Sub

    Public Property StoryText As String
        Get
            Return StoryLabel.Text
        End Get
        Set(value As String)
            StoryLabel.Text = value
        End Set
    End Property

    Public WriteOnly Property StoryImage As String
        Set(value As String)
            Dim file = Path.Combine(ImageBasePath, value)
            If IO.File.Exists(file) Then
                StoryPictureBox.Load(file)
            End If
        End Set
    End Property

    Public WriteOnly Property StoryColor As Drawing.Color
        Set(value As Drawing.Color)
            StoryLabel.BackColor = value
        End Set
    End Property

    Public Property StoryFont As Drawing.Font
        Get
            Return StoryLabel.Font
        End Get
        Set(value As Drawing.Font)
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


    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If AxWindowsMediaPlayer1.playState = WMPPlayState.wmppsStopped Then
            AxWindowsMediaPlayer1.Visible = False
            RaiseEvent VideoFinished()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent StoryProgress(ProgressEvent.StepForward)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToPreviousChapter)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToNextChapter)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpToStart)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RaiseEvent StoryProgress(ProgressEvent.JumpAuto)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RaiseEvent StoryProgress(ProgressEvent.StepBackward)
    End Sub
End Class
