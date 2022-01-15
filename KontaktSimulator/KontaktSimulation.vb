Imports System.Windows.Forms

Public Class KontaktSimulation

    Implements Communication.KontaktEventUpdateInterface

    Private KontaktSimulatorReference As KontaktSimulator

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Name = "KontaktSimulation"
    End Sub

    Private Sub KontaktDarstellung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Public Sub init(ByRef KontaktSimulatorRef As KontaktSimulator)
        KontaktSimulatorReference = KontaktSimulatorRef
        generiereCheckBoxen()
    End Sub

    Private Sub generiereCheckBoxen()
        FlowLayoutPanel1.Controls.Clear()
        For i As Integer = 0 To Klassen.Konstanten.AnzahlRueckmeldeModule - 1
            For q As Integer = 0 To Klassen.Konstanten.AnzahlAnschluesseProRueckmeldemodul - 1
                Dim cb As New CheckBoxWith2Ints
                cb.Text = i & "," & q
                cb.Name = "M" & i & "A" & q
                cb.modul = i
                cb.addresse = q
                cb.ThreeState = True
                cb.CheckState = CheckState.Indeterminate
                FlowLayoutPanel1.Controls.Add(cb)

                AddHandler cb.Click, AddressOf CheckBoxClick
            Next
        Next
    End Sub

    Private Sub CheckBoxClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cb As CheckBoxWith2Ints = sender
        Dim geaenderterKontakt As New Klassen.Kontakt

        geaenderterKontakt.Modul = cb.modul
        geaenderterKontakt.Adresse = cb.addresse

        For Each cba As CheckBoxWith2Ints In FlowLayoutPanel1.Controls
            cba.setToOldValue()
        Next

        If cb.CheckState = CheckState.Checked Then
            KontaktSimulatorReference.rueckmeldungen.rueckmeldungSetzen(cb.modul, cb.addresse) = True
            geaenderterKontakt.status = True
            cb.setTo(1)
        ElseIf (cb.CheckState = CheckState.Unchecked) Then
            KontaktSimulatorReference.rueckmeldungen.rueckmeldungSetzen(cb.modul, cb.addresse) = False
            geaenderterKontakt.status = False
            cb.setTo(0)
        Else
            KontaktSimulatorReference.rueckmeldungen.simuliereKontakt(cb.modul, cb.addresse) = False
            cb.setTo(KontaktSimulatorReference.rueckmeldung(cb.modul, cb.addresse).status)
        End If

        KontaktSimulatorReference.geaenderteRueckmeldungen = {geaenderterKontakt}
        KontaktSimulatorReference.UpdateKontakte(cb.modul, cb.addresse)
    End Sub

    Public Sub update1(ByVal Kontakte() As Klassen.Kontakt) Implements Communication.KontaktEventUpdateInterface.update
        For Each cb As CheckBoxWith2Ints In FlowLayoutPanel1.Controls
            cb.setToOldValue()
        Next
        For i As Integer = 0 To Kontakte.Length - 1
            Dim cb As CheckBoxWith2Ints = FlowLayoutPanel1.Controls("M" & Kontakte(i).Modul & "A" & Kontakte(i).Adresse)
            If Not KontaktSimulatorReference.rueckmeldungen.simuliereKontakt(Kontakte(i).Modul, Kontakte(i).Adresse) Then
                cb.setTo(Kontakte(i).status)
            End If
        Next
        KontaktSimulatorReference.geaenderteRueckmeldungen = Kontakte
    End Sub

End Class
