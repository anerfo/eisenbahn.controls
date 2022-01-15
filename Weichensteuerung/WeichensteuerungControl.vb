Public Class WeichensteuerungControl
    Implements Communication.WeichenEventUpdateInterface

    Private dieWeichensteuerung As Weichensteuerung

    Public Sub init(ByVal weichensteuerungRef As Weichensteuerung)
        dieWeichensteuerung = weichensteuerungRef
        dieWeichensteuerung.registriereFuerWeichenEvents(Me)
        For i As Integer = 0 To dieWeichensteuerung.weichen.Length - 1
            Dim con As New WeichenparameterDarstellung(dieWeichensteuerung)
            con.nummer = i
            con.Label1.Text = "Weiche " & i
            If dieWeichensteuerung.weichen(i).startzustand = Klassen.WeichenRichtung.links Then
                con.ComboBox1.SelectedIndex = 1
            ElseIf dieWeichensteuerung.weichen(i).startzustand = Klassen.WeichenRichtung.rechts Then
                con.ComboBox1.SelectedIndex = 2
            Else
                con.ComboBox1.SelectedIndex = 0
            End If



            If dieWeichensteuerung.weichen(i).linksEntspricht = Klassen.WeichenRichtung.rechts Then
                con.CheckBox1.Checked = True
            Else
                con.CheckBox1.Checked = False
            End If

            FlowLayoutPanel1.Controls.Add(con)
        Next
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Public Sub update1(ByVal Weiche() As Klassen.Weiche) Implements Communication.WeichenEventUpdateInterface.update
        For Each wpd As WeichenparameterDarstellung In FlowLayoutPanel1.Controls
            If wpd.nummer < Weiche.Length Then
                wpd.Weichenrichtung(Weiche(wpd.nummer).Richtung)
            Else
                wpd.Weichenrichtung(Klassen.WeichenRichtung.none)
            End If
        Next
    End Sub
End Class
