Public Class driversCabSim
    Implements Communication.LokEventUpdateInterface

    Private eb As Communication.KernelInterface

    Private speed As Integer = 0
    Private loknummer As Integer = 0
    Private lok As Klassen.Lok

    Private Cap As New Capture
    Private funcPictureBoxes() As Windows.Forms.PictureBox
    Private lokfunc() As Klassen.LokEigenschaften = {Klassen.LokEigenschaften.Hauptfunktion, Klassen.LokEigenschaften.Funktion1, Klassen.LokEigenschaften.Funktion2, Klassen.LokEigenschaften.Funktion3, Klassen.LokEigenschaften.Funktion4}
    Private Funktionen(4) As Boolean
    Private oldDirection As Short

    Public Sub init(ByRef ebRef As Communication.KernelInterface)
        eb = ebRef
        eb.registriereFuerLokEvents(Me)
        funcPictureBoxes = {PictureBox4, PictureBox5, PictureBox6, PictureBox7, PictureBox8}
        oldDirection = TrackBar2.Value
    End Sub

    Private Sub driversCabSim_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        Cap.CloseInterfaces()
    End Sub

    Private Sub driversCabSim_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Dock = Windows.Forms.DockStyle.Fill
        PictureBox1.Height = PictureBox1.Width / 4 * 3
        setPic2Region()
    End Sub

    Private Sub driversCabSim_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        PictureBox1.Height = PictureBox1.Width / 4 * 3
        setPic2Region()
    End Sub

    Private Sub setPic2Region()
        Dim regionD As New System.Drawing.Drawing2D.GraphicsPath
        regionD.AddLine(25, 0, PictureBox2.Width, 0)
        regionD.AddLine(PictureBox2.Width, 0, PictureBox2.Width, PictureBox2.Height)
        regionD.AddLine(PictureBox2.Width, PictureBox2.Height, 0, PictureBox2.Height)
        regionD.AddLine(0, PictureBox2.Height, 25, 0)
        PictureBox2.Region = New System.Drawing.Region(regionD)
    End Sub

    Private Sub SpeedCalc_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedCalc.Tick
        Dim oldspeed As Integer = speed
        speed = speed + TrackBar1.Value
        If speed > 14 Then
            speed = 14
        ElseIf speed < 0 Then
            speed = 0
        End If
        If speed <> oldspeed Then
            eb.lokSteuern(loknummer, Klassen.LokEigenschaften.Geschwindigkeit, speed)
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Panel2.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel2.Visible = False
        Panel2.Update()
        loknummer = Loknummerbox.Text
        lok = eb.lok(loknummer)
        TrackBar1.Value = 0
        Cap.CloseInterfaces()
        Cap.setVideoControl(PictureBox1)
        Cap.CaptureVideo()
    End Sub

    'Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
    '    If lok.Hauptfunktion = True Then
    '        lok.Hauptfunktion = False
    '    Else
    '        lok.Hauptfunktion = True
    '    End If
    '    eb.lokSteuern(loknummer, Klassen.LokEigenschaften.Hauptfunktion, lok.Hauptfunktion)
    'End Sub

    Public Sub update1(ByVal Lok() As Klassen.Lok) Implements Communication.LokEventUpdateInterface.update
        Dim dclok As Klassen.Lok = eb.lok(loknummer)
        Dim func() As Boolean = {dclok.Hauptfunktion, dclok.Funktion1, dclok.Funktion2, dclok.Funktion3, dclok.Funktion4}
        Label1.Text = Int(dclok.Geschwindigkeit / 14 * 150 + Rnd() * dclok.Geschwindigkeit).ToString
        For i As Integer = 0 To 4
            Funktionen(i) = func(i)
            If func(i) Then
                funcPictureBoxes(i).Image = My.Resources.Knopf_an
            Else
                funcPictureBoxes(i).Image = My.Resources.Knopf_aus
            End If
        Next
    End Sub

    Private Sub FuncPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click, PictureBox5.Click, PictureBox6.Click, PictureBox7.Click, PictureBox8.Click
        For i As Integer = 0 To funcPictureBoxes.Length - 1
            If sender Is funcPictureBoxes(i) Then
                eb.lokSteuern(loknummer, lokfunc(i), Not Funktionen(i))
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        eb.lokSteuern(loknummer, Klassen.LokEigenschaften.Geschwindigkeit, 0)
        TrackBar1.Value = 0
        speed = 0
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        If TrackBar2.Value <> oldDirection Then
            If eb.lok(loknummer).Geschwindigkeit = 0 Then
                eb.lokUmdrehen(loknummer)
                oldDirection = TrackBar2.Value
                speed = 0
            Else
                TrackBar2.Value = oldDirection
            End If
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

    End Sub
End Class
