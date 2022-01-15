Public Class WeichenparameterDarstellung
    Private dieWeichensteuerung As Weichensteuerung

    Public nummer As Integer

    Public Sub Weichenrichtung(ByVal richtung As Klassen.WeichenRichtung)
        If richtung = Klassen.WeichenRichtung.links And dieWeichensteuerung.weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.links Then
            Button1.BackColor = Drawing.Color.Green
            Button2.BackColor = Drawing.Color.White
        ElseIf richtung = Klassen.WeichenRichtung.rechts And dieWeichensteuerung.weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.links Then
            Button1.BackColor = Drawing.Color.White
            Button2.BackColor = Drawing.Color.Red
        ElseIf richtung = Klassen.WeichenRichtung.links And dieWeichensteuerung.weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.rechts Then
            Button1.BackColor = Drawing.Color.Red
            Button2.BackColor = Drawing.Color.White
        ElseIf richtung = Klassen.WeichenRichtung.rechts And dieWeichensteuerung.weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.rechts Then
            Button1.BackColor = Drawing.Color.White
            Button2.BackColor = Drawing.Color.Green
        Else
            Button1.BackColor = Drawing.Color.White
            Button2.BackColor = Drawing.Color.White
        End If
    End Sub

    Public Sub New(ByVal WeichensteuerungRef As Weichensteuerung)
        InitializeComponent()

        dieWeichensteuerung = WeichensteuerungRef
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dieWeichensteuerung.weicheSchalten(nummer, Klassen.WeichenRichtung.links)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dieWeichensteuerung.weicheSchalten(nummer, Klassen.WeichenRichtung.rechts)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox1.BackColor = Drawing.Color.Gray
        Else
            CheckBox1.BackColor = Drawing.Color.White
        End If
        dieWeichensteuerung.WeicheUmdrehen(nummer, CheckBox1.Checked)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            dieWeichensteuerung.WeicheStartzustandFestlegen(nummer, Klassen.WeichenRichtung.links)
        ElseIf ComboBox1.SelectedIndex = 2 Then
            dieWeichensteuerung.WeicheStartzustandFestlegen(nummer, Klassen.WeichenRichtung.rechts)
        Else
            dieWeichensteuerung.WeicheStartzustandFestlegen(nummer, Klassen.WeichenRichtung.none)
        End If
    End Sub
End Class
