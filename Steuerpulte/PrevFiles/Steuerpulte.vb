Imports System.Drawing
Imports V5PluginKompaitibilitaet
Imports System.Windows.Forms

Public Class Steuerpulte
    Implements Communication.LokEventUpdateInterface

    'Public MyTabReference As ControlInterface.TabManagerReference = New ControlInterface.TabManagerReference("Steuerpulte", Me)

    Private WithEvents Funktionen As SteuerpultFunktionen = New SteuerpultFunktionen

    Private AnzahlSteuerpulte As Integer
    Dim steuerpult() As SteuerpultControl

    Private LokAnzeige() As LokBild
    Private Bilder As LokBilderLoader = New LokBilderLoader(Application.StartupPath & "\Symbole\Lokbilder")

    Private LayoutPanels(1) As FlowLayoutPanel
    Private LokauswahlPanel As FlowLayoutPanel

    Private RechtsKlickAufControl As SteuerpultControl

    Public Sub ShowMe() 'ByRef ParentControl As Control)
        For i = 0 To AnzahlSteuerpulte - 1
            AddSteuerpult()
        Next
        LokbilderAnzeigen()

        'Parent = ParentControl

        Rearrange()

    End Sub

    Private Sub LokbilderAnzeigen()
        'Load_LoksAufAnlage()

        For i As Integer = 0 To LayoutPanels.Length - 1
            LayoutPanels(i) = New FlowLayoutPanel
            LayoutPanels(i).Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top
            LayoutPanels(i).Parent = Me
            LayoutPanels(i).BackColor = Color.White
            LayoutPanels(i).FlowDirection = FlowDirection.LeftToRight
            LayoutPanels(i).AutoScroll = True
        Next

        LokbilderInPanelsLaden()
    End Sub

    Private Sub LokbilderInPanelsLaden()
        Dim count As Integer = 0
        For i As Integer = 0 To LayoutPanels.Length - 1
            LayoutPanels(i).Controls.Clear()
        Next
        For i As Integer = 0 To 80
            If Not Bilder.LokBild(i) Is Nothing Then 'And LokStehtAufAnlage(i) = True Then
                ReDim Preserve LokAnzeige(count)
                LokAnzeige(count) = New LokBild(Bilder.LokBild(i), i)
                LokAnzeige(count).MaximumSize = New Size(0, 50)
                LokAnzeige(count).Height = LokAnzeige(count).Image.Height / 2
                LokAnzeige(count).Width = LokAnzeige(count).Image.Width * LokAnzeige(count).Height / LokAnzeige(count).Image.Height
                LokAnzeige(count).Parent = LayoutPanels(count Mod 2)
                AddHandler LokAnzeige(count).MouseDown, AddressOf LokAnzeigeMousedown
                AddHandler LokAnzeige(count).MouseMove, AddressOf LokAnzeigeMouseMove
                AddHandler LokAnzeige(count).MouseUp, AddressOf LokAnzeigeMouseUp
                count += 1
            End If
        Next
    End Sub

    '-------------------------------------Drag&Drop Code für die LokBilder--------------------------------------
    Private DragObj As Object = Nothing
    Private DragMouseclicked As Point = New Point(0, 0)
    Private DragParent As Object

    Private Sub LokAnzeigeMousedown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DragParent = DirectCast(sender, LokBild).Parent
        DirectCast(sender, LokBild).Parent = Me
        DirectCast(sender, LokBild).BringToFront()
        DragMouseclicked = e.Location
        DragObj = sender
    End Sub

    Private Sub LokAnzeigeMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not DragObj Is Nothing Then
            DirectCast(DragObj, LokBild).Location = Me.PointToClient(MousePosition) - DragMouseclicked
        End If
    End Sub

    Private Sub LokAnzeigeMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim dropped As Boolean = False
        If Funktionen.Visible = True Then
            If DirectCast(DragObj, LokBild).Left >= Funktionen.Left And DirectCast(DragObj, LokBild).Left < Funktionen.Left + Funktionen.Width Then
                Funktionen.Loknummer.Text = DirectCast(DragObj, LokBild).Loknummer
                dropped = True
            End If
        End If
        If dropped = False Then
            For i As Integer = 0 To steuerpult.Length - 1
                If DirectCast(DragObj, LokBild).Left >= steuerpult(i).Left And DirectCast(DragObj, LokBild).Left < steuerpult(i).Left + steuerpult(i).Width Then
                    steuerpult(i).Loknummer = DirectCast(DragObj, LokBild).Loknummer
                End If
            Next
        End If

        DirectCast(sender, LokBild).Parent = DragParent
        DragObj = Nothing
        DragParent = Nothing
    End Sub
    '---------------------------------------------Ende Drag&Drop Code--------------------------------------------

    Private Sub Rearrange()
        'wenn die Steuerpulte neu sortiert werden müssen
        Dim i As Integer = 0
        For Each con As Control In Panel1.Controls
            If TypeOf con Is SteuerpultControl Then
                con.Left = Me.Width / 2 - (steuerpult.Length - 2 * i) / 2 * con.Width
                i += 1
            End If
        Next
        ResizeMe()
    End Sub

    Private Sub AddSteuerpult()
        If steuerpult Is Nothing Then
            ReDim steuerpult(0)
        Else
            ReDim Preserve steuerpult(steuerpult.Length)
        End If
        steuerpult(steuerpult.Length - 1) = New SteuerpultControl(Bilder, Funktionen)
        steuerpult(steuerpult.Length - 1).Name = "steuerpult(" & steuerpult.Length - 1 & ")"
        steuerpult(steuerpult.Length - 1).Tag = steuerpult.Length - 1
        steuerpult(steuerpult.Length - 1).Top = 0
        steuerpult(steuerpult.Length - 1).Loknummerbox.ContextMenuStrip = Me.ContextMenuStrip1
        ResizeControls()
        steuerpult(steuerpult.Length - 1).Anchor = AnchorStyles.Bottom And AnchorStyles.Top
        Try
            steuerpult(steuerpult.Length - 1).Loknummer = Integer.Parse(Eisenbahn.Data("Programmdaten", steuerpult.Length - 1))
        Catch ex As Exception
            steuerpult(steuerpult.Length - 1).Loknummer = 0
        End Try
        Panel1.Controls.Add(steuerpult(steuerpult.Length - 1))
    End Sub

    Private Sub ResizeMe() Handles Me.Resize
        If Me.Created = True And Not steuerpult Is Nothing Then
            Dim RightPos As Integer = 0
            Dim LeftPos As Integer = 0
            For i As Integer = 0 To steuerpult.Length - 1
                steuerpult(i).Left = Me.Width / 2 - (steuerpult.Length - 2 * i) / 2 * steuerpult(i).Width
            Next
            For Each con As Control In Panel1.Controls
                '                con.Height = Panel1.Height - 7
                ResizeControls()

                con.Top = 0
                'Position für das 2. Layout Panel finden
                If TypeOf con Is SteuerpultControl And con.Left + con.Width > RightPos Then
                    RightPos = con.Left + con.Width
                End If
                If LeftPos = 0 And TypeOf con Is SteuerpultControl Then
                    LeftPos = con.Left
                End If
            Next
            'LayoutPanels(0).Left = 0
            'LayoutPanels(0).Width = LeftPos
            'LayoutPanels(1).Left = RightPos
            'LayoutPanels(1).Width = Me.Width - RightPos
        End If
    End Sub

    Public Sub Aktualisieren()
        If Not steuerpult Is Nothing Then
            For i As Integer = 0 To steuerpult.Length - 1
                steuerpult(i).Steuerpult_updaten()
            Next
        End If
    End Sub

    Public Sub SteuerpulteSpeichern()
        Funktionen.Speichern()
        If AnzahlSteuerpulte > 14 Then
            AnzahlSteuerpulte = 14
        End If
        Eisenbahn.Data("Programmdaten", 15) = steuerpult.Length
        If Not Me Is Nothing Then
            For i As Integer = 0 To steuerpult.Length - 1
                Eisenbahn.Data("Programmdaten", i) = steuerpult(i).Loknummer
            Next
        End If
    End Sub

    Public Sub SteuerpulteLaden()
        Funktionen.laden()
        Try
            AnzahlSteuerpulte = Integer.Parse(Eisenbahn.Data("Programmdaten", 15))
        Catch ex As Exception
            AnzahlSteuerpulte = 2
        End Try
        ShowMe()
    End Sub

    Public Sub SteuerpultDazu()
        AnzahlSteuerpulte += 1
        AddSteuerpult()
        Rearrange()
    End Sub

    Public Sub SteuerpultEntfernen()
        If AnzahlSteuerpulte > 1 Then
            AnzahlSteuerpulte -= 1

            steuerpult(AnzahlSteuerpulte).Parent = Nothing
            steuerpult(AnzahlSteuerpulte) = Nothing

            ReDim Preserve steuerpult(AnzahlSteuerpulte - 1)
            Rearrange()
        End If
    End Sub

    Private Sub Steuerpulte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill

        Me.Controls.Add(Funktionen)
        Funktionen.Left = Me.Width / 2 - Funktionen.Width / 2
        Funktionen.Top = 0
        Funktionen.Height = Me.Height
        Funktionen.Anchor = AnchorStyles.Top And AnchorStyles.Bottom
        Funktionen.Hide()

        ResizeControls()
    End Sub

    'Code der die Loks auf der Bahn verwaltet

    Private LokCheckBox() As CheckBox
    'Private LokStehtAufAnlage() As Boolean

    Private Sub LoksAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoksAuswählenToolStripMenuItem.Click
        If LokauswahlPanel Is Nothing Then
            LokauswahlPanel = New FlowLayoutPanel
            With LokauswahlPanel
                .Parent = Me
                .Dock = DockStyle.Fill
                .Visible = False
                .AutoScroll = True
            End With

            ReDim LokCheckBox(definitionen.Constants.AnzahlLoks)

            For i As Integer = 1 To LokCheckBox.Length - 1
                LokCheckBox(i) = New CheckBox
                With LokCheckBox(i)
                    .Appearance = Appearance.Button
                    .BackgroundImage = Bilder.LokBild(i)
                    .BackgroundImageLayout = ImageLayout.Zoom
                    '.Checked = LokStehtAufAnlage(i)
                    .Text = i
                    .Tag = i
                    If Bilder.LokBild(i) Is Nothing Then
                        .TextAlign = ContentAlignment.MiddleCenter
                    Else
                        .TextAlign = ContentAlignment.TopLeft
                    End If
                    .Parent = LokauswahlPanel
                    .MinimumSize = New Size(100, 50)
                    AddHandler LokCheckBox(i).Click, AddressOf LokCheckBox_Click
                    'If LokStehtAufAnlage(i) = True Then
                    '    .BackColor = Color.FromArgb(50, Color.Blue)
                    'Else
                    '    .BackColor = Color.White
                    'End If
                End With
            Next
        End If

        If LokauswahlPanel.Visible = False Then
            LokauswahlPanel.BringToFront()
            LokauswahlPanel.Visible = True
            LokauswahlPanel.Focus()
            LoksAuswählenToolStripMenuItem.Text = "Lok auswählen beenden"
        Else
            LokauswahlPanel.Visible = False
            LokbilderInPanelsLaden()
            LoksAuswählenToolStripMenuItem.Text = "Lok auswählen"
        End If
    End Sub

    Private Sub LokCheckBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LokauswahlPanel.Visible = False
        RechtsKlickAufControl.Loknummer = DirectCast(sender, CheckBox).Tag
        LoksAuswählenToolStripMenuItem.Text = "Lok auswählen"

        'LokStehtAufAnlage(DirectCast(sender, CheckBox).Tag) = DirectCast(sender, CheckBox).Checked
        'If LokStehtAufAnlage(DirectCast(sender, CheckBox).Tag) = True Then
        '    DirectCast(sender, CheckBox).BackColor = Color.FromArgb(50, Color.Blue)
        'Else
        '    DirectCast(sender, CheckBox).BackColor = Color.White
        'End If
        'Save_LoksAufAnlage()
    End Sub

    'Private Sub Load_LoksAufAnlage()
    '    ReDim LokStehtAufAnlage(81)
    '    For i As Integer = 0 To LokStehtAufAnlage.Length - 1
    '        LokStehtAufAnlage(i) = Eisenbahn.Data("LoksAufAnlage", i)
    '    Next
    'End Sub

    'Private Sub Save_LoksAufAnlage()
    '    For i As Integer = 0 To LokStehtAufAnlage.Length - 1
    '        Eisenbahn.Data("LoksAufAnlage", i) = LokStehtAufAnlage(i)
    '    Next
    'End Sub

    Private Sub HinzuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HinzuToolStripMenuItem1.Click
        SteuerpultDazu()
    End Sub

    Private Sub EntfernenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntfernenToolStripMenuItem1.Click
        SteuerpultEntfernen()
    End Sub

    Public Sub Lok1Beschleunigen(ByVal Wert As Integer)
        Eisenbahn.LokGeschwindigkeit(steuerpult(0).Loknummer) += Wert
    End Sub

    Private Sub FunktionenDefinierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunktionenDefinierenToolStripMenuItem.Click
        If Funktionen.Visible = True Then
            If ContextMenuStrip1.Left - 20 >= Funktionen.Left And ContextMenuStrip1.Left - 20 <= Funktionen.Left + Funktionen.Width Then
                Funktionen.Hide()
            Else
                Funktionen.Loknummer.Text = RechtsKlickAufControl.Loknummer
                Funktionen.Height = RechtsKlickAufControl.Height
                Funktionen.Top = 0
                Funktionen.Width = RechtsKlickAufControl.Width
                Funktionen.Left = RechtsKlickAufControl.Left
            End If
        Else
            Funktionen.Show()
            Funktionen.Loknummer.Text = RechtsKlickAufControl.Loknummer
            Funktionen.Height = RechtsKlickAufControl.Height
            Funktionen.Top = 0
            Funktionen.Width = RechtsKlickAufControl.Width
            Funktionen.Left = RechtsKlickAufControl.Left
            Funktionen.BringToFront()
        End If
    End Sub

    Private Sub Panel1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Panel1.ControlAdded, Panel1.ControlRemoved
        ResizeControls()
    End Sub

    Private Sub ResizeControls()
        If Panel1.HorizontalScroll.Visible = True Then
            For Each Con As Control In Panel1.Controls
                Con.Height = Panel1.Height - Panel1.AutoScrollMinSize.Height - 2
            Next
        Else
            For Each Con As Control In Panel1.Controls
                Con.Height = Panel1.Height
            Next
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim i As Integer = 0
        If Not steuerpult Is Nothing Then
            While steuerpult(i).Left + steuerpult(i).Width < Panel1.PointToClient(MousePosition).X
                If i < steuerpult.Length - 1 Then
                    i += 1
                Else
                    Exit While
                End If

            End While
        End If
        RechtsKlickAufControl = steuerpult(i)
    End Sub

    Private Sub Funktionen_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Funktionen.VisibleChanged
        If Funktionen.Visible = False And Not steuerpult Is Nothing Then
            For i As Integer = 0 To steuerpult.Length - 1
                steuerpult(i).FunktionenSetzten()
            Next
        End If
    End Sub

    Public Sub update1(ByVal Lok() As Klassen.Lok) Implements Communication.LokEventUpdateInterface.update
        Aktualisieren()
    End Sub
End Class
