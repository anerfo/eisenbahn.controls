Public Class SteuerpultControl

    Private Iloknummer As Integer = 0
    Private active As Boolean = False
    Private Bilder As LokBilderLoader
    Private MyFunktionenSource As SteuerpultFunktionen
    Private AktuelleFunktionenDerLok As CLASSFunktionen

    Public Sub New(ByRef BildSpeicher As LokBilderLoader, ByRef FunktionenSpeicher As SteuerpultFunktionen)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Bilder = BildSpeicher
        MyFunktionenSource = FunktionenSpeicher
    End Sub

    Public Property Loknummer() As Integer
        Get
            Return Iloknummer
        End Get
        Set(ByVal value As Integer)
            If value > 0 And value < 81 Then
                Iloknummer = value
                Bild.Image = Bilder.LokBild(Iloknummer)
                If Not Bild.Image Is Nothing Then
                    Bild.Height = Bild.Image.Height * Bild.Width / Bild.Image.Width
                End If
                Steuerpult_updaten()
            Else
                Iloknummer = 0
            End If
            If Iloknummer >= 10 Then
                Loknummerbox.Text = Iloknummer
            Else
                Loknummerbox.Text = "0" & Iloknummer
            End If
            Eisenbahn.Variable("LokSteuerpult" & Tag) = Iloknummer
            AktuelleFunktionenDerLok = MyFunktionenSource.FunktionenDerLok(Iloknummer)
            FunktionenSetzten()
        End Set
    End Property

    Private Sub MaskedTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Loknummerbox.TextChanged
        If Loknummerbox.Text <> "" Then
            If CInt(Loknummerbox.Text) > 0 And CInt(Loknummerbox.Text) < 81 Then
                Iloknummer = CInt(Loknummerbox.Text)
                Bild.Image = Bilder.LokBild(Iloknummer)
                If Not Bild.Image Is Nothing Then
                    Bild.Height = Bild.Image.Height * Bild.Width / Bild.Image.Width
                End If
                Steuerpult_updaten()
                Eisenbahn.Variable("LokSteuerpult" & Tag) = Iloknummer
                AktuelleFunktionenDerLok = MyFunktionenSource.FunktionenDerLok(Iloknummer)
                FunktionenSetzten()
            Else
                Loknummerbox.Text = "00"
                Iloknummer = 0
            End If
        Else
            Iloknummer = 0
        End If
    End Sub

    Private Sub Umkehren1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Umkehren1.Click
        Eisenbahn.LokUmdrehen(Iloknummer)
    End Sub

    Private Sub Funktion0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Funktion0.Click, Funktion1.Click, Funktion2.Click, Funktion3.Click, Funktion4.Click
        Eisenbahn.LokFunktion(Iloknummer, DirectCast(sender, CheckBox).Tag) = DirectCast(sender, CheckBox).CheckState
    End Sub

    Private Sub Geschwindigkeit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Geschwindigkeit.MouseDown
        active = True
    End Sub

    Private Sub Geschwindigkeit_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Geschwindigkeit.MouseUp
        active = False
    End Sub

    Private Sub Geschwindigkeit_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Geschwindigkeit.Scroll
        Eisenbahn.LokGeschwindigkeit(Iloknummer) = Geschwindigkeit.Value
    End Sub

    Public Function Steuerpult_updaten() As Integer
        If active = False Then
            Geschwindigkeit.Value = Eisenbahn.LokGeschwindigkeit(Iloknummer)
        End If
        Funktion0.Checked = Eisenbahn.LokFunktion(Iloknummer, 0)
        Funktion1.Checked = Eisenbahn.LokFunktion(Iloknummer, 1)
        Funktion2.Checked = Eisenbahn.LokFunktion(Iloknummer, 2)
        Funktion3.Checked = Eisenbahn.LokFunktion(Iloknummer, 3)
        Funktion4.Checked = Eisenbahn.LokFunktion(Iloknummer, 4)
    End Function

    Public Sub FunktionenSetzten()
        Funktion0.Visible = AktuelleFunktionenDerLok.F_ENABLED(0)
        Funktion1.Visible = AktuelleFunktionenDerLok.F_ENABLED(1)
        Funktion2.Visible = AktuelleFunktionenDerLok.F_ENABLED(2)
        Funktion3.Visible = AktuelleFunktionenDerLok.F_ENABLED(3)
        Funktion4.Visible = AktuelleFunktionenDerLok.F_ENABLED(4)
        Funktion0.BackgroundImage = AktuelleFunktionenDerLok.Picture(0)
        Funktion1.BackgroundImage = AktuelleFunktionenDerLok.Picture(1)
        Funktion2.BackgroundImage = AktuelleFunktionenDerLok.Picture(2)
        Funktion3.BackgroundImage = AktuelleFunktionenDerLok.Picture(3)
        Funktion4.BackgroundImage = AktuelleFunktionenDerLok.Picture(4)
        If Not Funktion0.BackgroundImage Is Nothing Then
            Funktion0.Text = ""
        Else
            Funktion0.Text = "Funktion"
        End If
        If Not Funktion1.BackgroundImage Is Nothing Then
            Funktion1.Text = ""
        Else
            Funktion1.Text = "F1"
        End If
        If Not Funktion2.BackgroundImage Is Nothing Then
            Funktion2.Text = ""
        Else
            Funktion2.Text = "F2"
        End If
        If Not Funktion3.BackgroundImage Is Nothing Then
            Funktion3.Text = ""
        Else
            Funktion3.Text = "F3"
        End If
        If Not Funktion4.BackgroundImage Is Nothing Then
            Funktion4.Text = ""
        Else
            Funktion4.Text = "F4"
        End If
        Funktion0.BackgroundImageLayout = ImageLayout.Zoom
        Funktion1.BackgroundImageLayout = ImageLayout.Zoom
        Funktion2.BackgroundImageLayout = ImageLayout.Zoom
        Funktion3.BackgroundImageLayout = ImageLayout.Zoom
        Funktion4.BackgroundImageLayout = ImageLayout.Zoom
    End Sub

    Private Sub SteuerpultControl_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Dim a As Integer = 0
    End Sub
End Class
