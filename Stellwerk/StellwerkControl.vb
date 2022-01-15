Imports System.Windows.Forms
Imports System.Drawing
Imports V5PluginKompaitibilitaet

Public Class StellwerkControl

    '---------------------------------------------------------------------
    '   mit dem StellwerkControl wird ein Gleisbild dargestellt
    '
    ' benötigt die folgenden Dateien im Projekt:
    '   Definitionen.vb; EbIO.vb
    '   
    '   öffentliche Funktionen und Variablen:
    '---------------------------------------------------------------------

    Public Bilder As Bilder

    Public Sub New(ByVal Bilder_horizontal As Integer, ByVal bilder_vertikal As Integer, ByRef BilderSource As Bilder)    'Konstruktor der Klasse StellwerkControl

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Bilder_in_Richtung.X = Bilder_horizontal - 1
        Bilder_in_Richtung.Y = bilder_vertikal - 1

        ReDim Element(Bilder_in_Richtung.X, Bilder_in_Richtung.Y)
        WirdBearbeitet = New Point(-1, -1)

        For i As Integer = 0 To Element.GetLength(0) - 1
            For q As Integer = 0 To Element.GetLength(1) - 1
                Element(i, q) = New CLASS_Gleisbild()
            Next
        Next

        Bilder = BilderSource


        StellwerkBearbeitenBilderLaden()

        SelectModul.Maximum = definitionen.Constants.Angeschlossene_Rueckmeldemodule * 2 - 1
        SelectWeiche.Maximum = definitionen.Constants.anzahl_weichen - 1
        S_weichenadresse.Maximum = definitionen.Constants.anzahl_weichen - 1


        'auswahl.BackColor = Color.FromArgb(100, Color.White) 'Color.White
        auswahl.BackColor = Color.White
        auswahl.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        auswahl.Parent = Me
        auswahl.Visible = False
        auswahl.Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top
        AddHandler auswahl.MouseMove, AddressOf AuswahlMouseMove
        AddHandler auswahl.MouseDown, AddressOf AuswahlMouseDown
        AddHandler auswahl.MouseUp, AddressOf AuswahlMouseup
    End Sub



    'Die Listen dienen dazu das Update schneller durchzuführen. 
    Dim Strecken() As Point
    Dim Weichen() As Point
    Dim Kontakte() As Point

    Public Sub Aktualisieren(ByVal typ As Definitionen.Typen)
        If Not Kontakte Is Nothing Then
            If typ = Definitionen.Typen.Kontakt Or typ = Definitionen.Typen.None Then
                For i As Integer = 0 To Kontakte.Length - 1
                    'Die If-Abfrage beschleunigt den Update-Vorgang
                    If Not Element(Kontakte(i).X, Kontakte(i).Y).Image Is Bilder.Bild_mitNummer(Definitionen.Typen.Kontakt, Element(Kontakte(i).X, Kontakte(i).Y).Bildnummer(Eisenbahn.kontakt(Element(Kontakte(i).X, Kontakte(i).Y).Adresse(0), Element(Kontakte(i).X, Kontakte(i).Y).Adresse(1)))) Then
                        Element(Kontakte(i).X, Kontakte(i).Y).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Kontakt, Element(Kontakte(i).X, Kontakte(i).Y).Bildnummer(Eisenbahn.kontakt(Element(Kontakte(i).X, Kontakte(i).Y).Adresse(0), Element(Kontakte(i).X, Kontakte(i).Y).Adresse(1))))
                    End If
                Next
            End If
        End If
        If Not Strecken Is Nothing Then
            If typ = Definitionen.Typen.Strecke Or typ = Definitionen.Typen.None Then
                For i As Integer = 0 To Strecken.Length - 1
                    'Die If-Abfrage beschleunigt den Update-Vorgang
                    If Not Element(Strecken(i).X, Strecken(i).Y).Image Is Bilder.Bild_mitNummer(Definitionen.Typen.Strecke, Element(Strecken(i).X, Strecken(i).Y).Bildnummer(0)) Then
                        Element(Strecken(i).X, Strecken(i).Y).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Strecke, Element(Strecken(i).X, Strecken(i).Y).Bildnummer(0))
                    End If
                Next
            End If
        End If
        If Not Weichen Is Nothing Then
            If typ = Definitionen.Typen.Weiche Or typ = Definitionen.Typen.None Then
                For i As Integer = 0 To Weichen.Length - 1
                    If Eisenbahn.Weiche(Element(Weichen(i).X, Weichen(i).Y).Adresse(0)) = Definitionen.Weichen_Zustaende.Links Then
                        'Die If-Abfrage beschleunigt den Update-Vorgang
                        If Not Element(Weichen(i).X, Weichen(i).Y).Image Is Bilder.Bild_mitNummer(Definitionen.Typen.Weiche, Element(Weichen(i).X, Weichen(i).Y).Bildnummer(0)) Then
                            Element(Weichen(i).X, Weichen(i).Y).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Weiche, Element(Weichen(i).X, Weichen(i).Y).Bildnummer(0))
                        End If
                    Else
                        'Die If-Abfrage beschleunigt den Update-Vorgang
                        If Not Element(Weichen(i).X, Weichen(i).Y).Image Is Bilder.Bild_mitNummer(Definitionen.Typen.Weiche, Element(Weichen(i).X, Weichen(i).Y).Bildnummer(1)) Then
                            Element(Weichen(i).X, Weichen(i).Y).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Weiche, Element(Weichen(i).X, Weichen(i).Y).Bildnummer(1))
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    'sucht alle Kontakte/weichen/strecken im Stellwerk und schreibt sie in den entsprechenden Array
    Private Sub StreckentypenInListen()
        Kontakte = Nothing
        Strecken = Nothing
        Weichen = Nothing
        For x As Integer = 0 To Bilder_in_Richtung.X
            For y As Integer = 0 To Bilder_in_Richtung.Y
                If Element(x, y).Typ = Definitionen.Typen.Kontakt Then
                    If Kontakte Is Nothing Then
                        ReDim Kontakte(0)
                    Else
                        ReDim Preserve Kontakte(Kontakte.Length)
                    End If
                    Kontakte(Kontakte.Length - 1) = New Point(x, y)
                ElseIf Element(x, y).Typ = Definitionen.Typen.Strecke Then
                    If Strecken Is Nothing Then
                        ReDim Strecken(0)
                    Else
                        ReDim Preserve Strecken(Strecken.Length)
                    End If
                    Strecken(Strecken.Length - 1) = New Point(x, y)
                ElseIf Element(x, y).Typ = Definitionen.Typen.Weiche Then
                    If Weichen Is Nothing Then
                        ReDim Weichen(0)
                    Else
                        ReDim Preserve Weichen(Weichen.Length)
                    End If
                    Weichen(Weichen.Length - 1) = New Point(x, y)
                End If
            Next
        Next

    End Sub


    '---------------------------------------------------------------------
    'Private:
    '---------------------------------------------------------------------
    Private Bilder_in_Richtung As STRUCT_Bilder_in_Richtung 'Enthält die Dimensionen eines Bildes und des gesamten Stellwerkes

    Private Element(,) As CLASS_Gleisbild          'Beinhaltet die Bilder des Stellwerks
    Private BearbeitenElemente(,) As CLASS_Gleisbild    'Die Bilder die verfügbar sind und ins Stellwerk eingefügt weden können

    Private WithEvents ResizeTimer As Timer = New Timer 'ein Timer, dass beim Resize nicht dauernd neu gezeichnet wird
    Private resizing As Boolean = False             'eine Hilfsvariable, dass beim Resize nicht dauernd neu gezeichnet wird
    'mit wndProc geht es wohl bei einem Control nicht WM_EXITSIZEMOVE auszulösen

    Private dragobj As Object = Nothing             'Beinhaltet das Object das gerade bewegt wird
    Private MouseClickPos As Point = New Point      'Speichert die Position auf dem Objekt, wo geklickt wurde
    Private Bearbeiten As Boolean = False            'Ob das Stellwerk gerade bearbeitet wird oder nicht
    Private OldParent As Object                     'Speichert das Parent-Object des gezogenen Objects
    Private OldPosition As Point                    'speichert die alte Position des gezogenen Objects
    Private WirdBearbeitet As Point                 'speichert das aktuell bearbeitete Element

    Private Bildbreite As Integer = 30              'Die Breite der Bilder im Menü
    Private Abstand As Integer = 10                 'der Abstand der Bilder im Menü
    Private KeineAuswertung As Boolean = False       'Variable, dass Änderungen in Eingabefeldern nicht ausgewertet werden sollen

    Private WithEvents auswahl As AuswahlPanel = New AuswahlPanel  'markiert die ausgewählten Elemente
    Dim dragAuswahl As Boolean = False      'Wenn True dann wird die Auswahl gerade gezogen
    Private selecting As Boolean = False    'Ist True, wenn das Auswahlform gerade gezogen wird
    Private pt As Point = New Point         'Beinhaltet das ausgewählte Feld links unten - wird bearbeitet das rechts oben

    Private DataToCopy As Skriptbefehl = New Skriptbefehl   'Zwischenspeicher um die Skripts zu kopieren


    'Lädt die Bilder in das Menü zum Bearbeiten
    Private Sub StellwerkBearbeitenBilderLaden()
        ReDim BearbeitenElemente(Bilder.number_of + 2, 0)
        Dim count As Integer = 0
        Dim BilderInReihe As Integer = TabControlStellwerk.Width / (Bildbreite + Abstand)   'Wieviele Bilder in eine Reihe passen

        For i As Integer = 0 To Bilder.number_of + 2
            BearbeitenElemente(i, 0) = New CLASS_Gleisbild
            BearbeitenElemente(i, 0).SizeMode = PictureBoxSizeMode.StretchImage
            BearbeitenElemente(i, 0).Height = Bildbreite
            BearbeitenElemente(i, 0).Width = Bildbreite
            BearbeitenElemente(i, 0).Name = "Vorgabe" & i
            BearbeitenElemente(i, 0).Visible = True
            BearbeitenElemente(i, 0).BorderStyle = Windows.Forms.BorderStyle.FixedSingle

            AddHandler BearbeitenElemente(i, 0).MouseDown, AddressOf BeginDrag
            AddHandler BearbeitenElemente(i, 0).MouseUp, AddressOf EndDrag
            AddHandler BearbeitenElemente(i, 0).MouseMove, AddressOf StellwerkControl_MouseMove
        Next

        For i As Integer = 0 To Bilder.number_of(Definitionen.Typen.Kontakt)
            BearbeitenElemente(count, 0).Parent = TabPageKontakte
            BearbeitenElemente(count, 0).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Kontakt, i)
            BearbeitenElemente(count, 0).Typ = Definitionen.Typen.Kontakt
            If i Mod 2 = 0 Then
                BearbeitenElemente(count, 0).Bildnummer(0) = i
                BearbeitenElemente(count, 0).Bildnummer(1) = i + 1
            Else
                BearbeitenElemente(count, 0).Bildnummer(0) = i - 1
                BearbeitenElemente(count, 0).Bildnummer(1) = i
            End If

            TabPageKontakte.Controls.Add(BearbeitenElemente(count, 0))
            BearbeitenElemente(count, 0).Location = New Point(Int((i / 2) Mod BilderInReihe) * (Bildbreite + Abstand), Int(i / BilderInReihe / 2) * (Bildbreite + Abstand))
            count += 1
        Next
        For i As Integer = 0 To Bilder.number_of(Definitionen.Typen.Strecke)
            BearbeitenElemente(count, 0).Parent = TabPageStrecken
            BearbeitenElemente(count, 0).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Strecke, i)
            BearbeitenElemente(count, 0).Typ = Definitionen.Typen.Strecke
            BearbeitenElemente(count, 0).Bildnummer(0) = i

            TabPageStrecken.Controls.Add(BearbeitenElemente(count, 0))
            BearbeitenElemente(count, 0).Location = New Point(Int((i) Mod BilderInReihe) * (Bildbreite + Abstand), Int(i / BilderInReihe) * (Bildbreite + Abstand))
            count += 1
        Next
        For i As Integer = 0 To Bilder.number_of(Definitionen.Typen.Weiche)
            BearbeitenElemente(count, 0).Parent = TabPageWeichen
            BearbeitenElemente(count, 0).Image = Bilder.Bild_mitNummer(Definitionen.Typen.Weiche, i)
            BearbeitenElemente(count, 0).Typ = Definitionen.Typen.Weiche
            BearbeitenElemente(count, 0).Bildnummer(0) = i
            If i Mod 2 = 0 Then
                BearbeitenElemente(count, 0).Bildnummer(0) = i
                BearbeitenElemente(count, 0).Bildnummer(1) = i + 1
            Else
                BearbeitenElemente(count, 0).Bildnummer(0) = i - 1
                BearbeitenElemente(count, 0).Bildnummer(1) = i
            End If

            TabPageWeichen.Controls.Add(BearbeitenElemente(count, 0))
            BearbeitenElemente(count, 0).Location = New Point(Int((i / 2) Mod BilderInReihe) * (Bildbreite + Abstand), Int(i / BilderInReihe / 2) * (Bildbreite + Abstand))
            count += 1
        Next
    End Sub


    'Verhindert, dass bei einem Resize ständig alle Bilder neu gezeichnet werden
    Private Sub StellwerkControl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        resizing = True
        ResizeTimer.Enabled = True
        Me.SuspendLayout()
    End Sub

    'Verhindert, dass bei einem Resize ständig alle Bilder neu gezeichnet werden
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResizeTimer.Tick
        Dim offset_h, offset_v As Integer
        If Bilder_in_Richtung.X <> 0 And Bilder_in_Richtung.Y <> 0 And resizing = False And Me.Created = True Then
            Me.SuspendLayout()
            Bilder_in_Richtung.Xdots_per_Pic = Me.Size.Width / (Bilder_in_Richtung.X + 1)
            Bilder_in_Richtung.Ydots_per_Pic = Me.Size.Height / (Bilder_in_Richtung.Y + 1)
            If Bilder_in_Richtung.Xdots_per_Pic > Bilder_in_Richtung.Ydots_per_Pic Then
                Bilder_in_Richtung.Xdots_per_Pic = Bilder_in_Richtung.Ydots_per_Pic
            Else
                Bilder_in_Richtung.Ydots_per_Pic = Bilder_in_Richtung.Xdots_per_Pic
            End If
            offset_v = (Me.Width - (Bilder_in_Richtung.X + 1) * Bilder_in_Richtung.Xdots_per_Pic) / 2
            offset_h = (Me.Height - (Bilder_in_Richtung.Y + 1) * Bilder_in_Richtung.Ydots_per_Pic) / 2
            For i As Integer = 0 To Bilder_in_Richtung.X
                For q As Integer = 0 To Bilder_in_Richtung.Y
                    If Not Element(i, q) Is Nothing Then
                        Element(i, q).Width = Bilder_in_Richtung.Xdots_per_Pic
                        Element(i, q).Height = Bilder_in_Richtung.Ydots_per_Pic

                        Element(i, q).Left = i * Bilder_in_Richtung.Xdots_per_Pic + offset_v
                        Element(i, q).Top = q * Bilder_in_Richtung.Ydots_per_Pic + offset_h
                    End If
                Next
            Next
            ResizeTimer.Enabled = False
            If Bearbeiten = True And auswahl.Visible = True And WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
                auswahl.Location = Element(WirdBearbeitet.X, WirdBearbeitet.Y).Location
                auswahl.Width = (pt.X + 1) * Bilder_in_Richtung.Xdots_per_Pic - WirdBearbeitet.X * Bilder_in_Richtung.Xdots_per_Pic + 4
                auswahl.Height = (pt.Y + 1) * Bilder_in_Richtung.Ydots_per_Pic - WirdBearbeitet.Y * Bilder_in_Richtung.Ydots_per_Pic + 4
            End If
            Me.ResumeLayout()
        End If

        resizing = False
    End Sub

    'schreibt die Optionen eines des Elements mit den Koordianten von Obj in die Optionen zum Bearbeiten
    Private Sub OptionenAnzeigen(ByVal obj As Point)
        KeineAuswertung = True
        BefehleInSkriptliste(Element(obj.X, obj.Y))
        'wenn gerade ein Kontakt angeklickt wurde, soll auch die Optionen für ein Kontakt angezeigt werden
        If Element(obj.X, obj.Y).Typ = Definitionen.Typen.Kontakt Then
            Weicheneinstellungen.Visible = False
            KontaktEinstellungen.Visible = True
            If Element(obj.X, obj.Y).Adresse(0) > 0 Then
                SelectModul.Value = Element(obj.X, obj.Y).Adresse(0)
            Else
                SelectModul.Value = 1
            End If
            If Element(obj.X, obj.Y).Adresse(0) > 0 Then
                SelectAdress.Value = Element(obj.X, obj.Y).Adresse(1)
            Else
                SelectAdress.Value = 1
            End If
        ElseIf Element(obj.X, obj.Y).Typ = Definitionen.Typen.Weiche Then
            'wenn gerade eine Weiche angeklickt wurde, soll auch die Optionen für ein Kontakt angezeigt werden
            KontaktEinstellungen.Visible = False
            Weicheneinstellungen.Visible = True
            If Element(obj.X, obj.Y).Adresse(0) > 0 Then
                SelectWeiche.Value = Element(obj.X, obj.Y).Adresse(0)
            Else
                SelectWeiche.Value = 1
            End If
        Else
            KontaktEinstellungen.Visible = False
            Weicheneinstellungen.Visible = False
        End If
        KeineAuswertung = False
    End Sub

    'startet ein Objekt mit einem Klick der Maus zu bewegen
    Private Sub BeginDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown, EditText.MouseDown
        dragobj = sender
        MouseClickPos = e.Location
        If TypeOf sender Is CLASS_Gleisbild Then
            If WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
                Element(WirdBearbeitet.X, WirdBearbeitet.Y).BorderStyle = Windows.Forms.BorderStyle.None
                WirdBearbeitet = New Point(-1, -1)
            End If
            OldPosition = DirectCast(sender, CLASS_Gleisbild).Location
            OldParent = DirectCast(sender, CLASS_Gleisbild).Parent
            DirectCast(sender, CLASS_Gleisbild).Parent = Me
            DirectCast(sender, CLASS_Gleisbild).BringToFront()
            DirectCast(sender, CLASS_Gleisbild).Width = Bilder_in_Richtung.Xdots_per_Pic
            DirectCast(sender, CLASS_Gleisbild).Height = Bilder_in_Richtung.Ydots_per_Pic
        ElseIf TypeOf sender Is Label Then
            DirectCast(sender, Label).Parent.BringToFront()
        End If
    End Sub

    'beendet den Drag, sobald die Maustaste losgelassen wird
    Private Sub EndDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp, EditText.MouseUp
        If TypeOf sender Is CLASS_Gleisbild And Not dragobj Is Nothing Then
            Dim x As Integer = 0
            Dim y As Integer = 0

            While Element(x, 0).Left < MyBase.PointToClient(MousePosition).X - DirectCast(dragobj, CLASS_Gleisbild).Width
                x += 1
                If x >= Element.GetLength(0) Then
                    x = -1
                    Exit While
                End If
            End While
            While Element(0, y).Top < MyBase.PointToClient(MousePosition).Y - DirectCast(dragobj, CLASS_Gleisbild).Height
                y += 1
                If y >= Element.GetLength(1) Then
                    y = -1
                    Exit While
                End If
            End While
            If MyBase.PointToClient(MousePosition).X + DirectCast(dragobj, CLASS_Gleisbild).Width / 2 > Panel1.Left And MyBase.PointToClient(MousePosition).Y + DirectCast(dragobj, CLASS_Gleisbild).Height / 2 > Panel1.Top _
                And MyBase.PointToClient(MousePosition).X < Panel1.Left + Panel1.Width And MyBase.PointToClient(MousePosition).Y < Panel1.Top + Panel1.Height Then
                x = -1
                y = -1
            End If
            If x <> -1 And y <> -1 Then
                Element(x, y).Visible = True
                'hier wird das Bild ins Stellwerk eingefügt
                If DirectCast(sender, CLASS_Gleisbild).Typ = Definitionen.Typen.Kontakt Then
                    Element(x, y).SetToContact(x, y, DirectCast(sender, CLASS_Gleisbild).Bildnummer(1), DirectCast(sender, CLASS_Gleisbild).Bildnummer(0), SelectModul.Value, SelectAdress.Value)
                    StreckentypenInListen()
                    Aktualisieren(Definitionen.Typen.Kontakt)
                ElseIf DirectCast(sender, CLASS_Gleisbild).Typ = Definitionen.Typen.Weiche Then
                    Element(x, y).SetToWeiche(x, y, DirectCast(sender, CLASS_Gleisbild).Bildnummer(0), DirectCast(sender, CLASS_Gleisbild).Bildnummer(1), SelectWeiche.Value)
                    StreckentypenInListen()
                    Aktualisieren(Definitionen.Typen.Weiche)
                Else
                    Element(x, y).SetToStrecke(x, y, DirectCast(sender, CLASS_Gleisbild).Bildnummer(0))
                    StreckentypenInListen()
                    Aktualisieren(Definitionen.Typen.Strecke)
                End If
                OptionenAnzeigen(New Point(x, y))
                'Element_Click(Element(x, y), e)
            End If

            DirectCast(sender, CLASS_Gleisbild).Location = OldPosition
            DirectCast(sender, CLASS_Gleisbild).Parent = OldParent
            DirectCast(sender, CLASS_Gleisbild).Width = Bildbreite
            DirectCast(sender, CLASS_Gleisbild).Height = Bildbreite
            OldParent = Nothing
            OldPosition = Point.Empty
        End If
        dragobj = Nothing
        MouseClickPos = Point.Empty

        Me.Focus()
    End Sub

    'Natürlich soll er auch auf das Bild klicken, wenn darüber eine Beschriftung liegt
    Private Sub Element_Click_label(ByVal sender As Object, ByVal e As System.EventArgs)
        Element_Click(DirectCast(sender, Label).Parent, e)
    End Sub

    Private Sub Element_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'wird aufgerufen, sobald ein Gleisbild im Stellwerk angeklickt wird
        Dim obj As CLASS_Gleisbild = sender

        If Bearbeiten = True Then
            WirdBearbeitet = New Point(obj.X, obj.Y)

            auswahl.Visible = True
            selecting = True
            auswahl.Location = New Point(obj.Left - 2, obj.Top - 2)
            auswahl.BringToFront()
            Panel1.BringToFront()
            EditElement.BringToFront()

            'Wenn das Stellwerk gerade bearbeitet wird, werden die Daten in das ElementBearbeitenPanel geladen
            ' If WirdBearbeitet <> New Point(obj.X, obj.Y) Then
            'obj.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            'If WirdBearbeitet <> New Point(-1, -1) Then
            '    'Falls gerade ein neues Bild erstellt wurde
            '    Element(WirdBearbeitet.X, WirdBearbeitet.Y).BorderStyle = Windows.Forms.BorderStyle.None
            'End If
            OptionenAnzeigen(New Point(obj.X, obj.Y))
            'End If
        Else
            'wenn normal in das Stellwerk geklickt wird, sollen die Skriptbefehle ausgeführt werden
            obj.Skript.BefehleAusführen()
        End If
        Me.Focus()

    End Sub

    Private Sub StellwerkControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If Bearbeiten = True And Not Element Is Nothing Then
            Dim x As Integer = WirdBearbeitet.X
            Dim y As Integer = WirdBearbeitet.Y

            If WirdBearbeitet.X < 0 Then
                x = 0
            End If
            If WirdBearbeitet.Y < 0 Then
                y = 0
            End If

            While Element(x, 0).Left + Bilder_in_Richtung.Xdots_per_Pic * 1.5 < MyBase.PointToClient(MousePosition).X
                x += 1
                If x >= Element.GetLength(0) Then
                    x = -1
                    Exit While
                End If
            End While
            While Element(0, y).Top + Bilder_in_Richtung.Ydots_per_Pic * 1.5 < MyBase.PointToClient(MousePosition).Y
                y += 1
                If y >= Element.GetLength(1) Then
                    y = -1
                    Exit While
                End If
            End While

            pt.X = x
            pt.Y = y
            If WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
                If pt.X >= WirdBearbeitet.X And pt.Y >= WirdBearbeitet.Y Then
                    auswahl.Width = (pt.X + 1) * Bilder_in_Richtung.Xdots_per_Pic - WirdBearbeitet.X * Bilder_in_Richtung.Xdots_per_Pic + 4
                    auswahl.Height = (pt.Y + 1) * Bilder_in_Richtung.Ydots_per_Pic - WirdBearbeitet.Y * Bilder_in_Richtung.Ydots_per_Pic + 4
                    If pt.X = WirdBearbeitet.X And pt.Y = WirdBearbeitet.Y Then
                        If Element(pt.X, pt.Y).Typ = Definitionen.Typen.None Then
                            auswahl.Visible = False
                            WirdBearbeitet = New Point(-1, -1)
                            selecting = False
                        End If
                    End If
                Else
                    WirdBearbeitet = New Point(-1, -1)
                    auswahl.Visible = False
                    selecting = False
                End If
            End If

            selecting = False
        End If
    End Sub

    'wenn gerade ein Objekt gezogen wird wird hier die Position neu gesetzt
    Private Sub StellwerkControl_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, Label1.MouseMove, Panel1.MouseMove, EditText.MouseMove
        'Das AuswahlForm entsprechend vergrößern
        ElementMove(sender, e)

        If dragobj Is Nothing Or Bearbeiten = False Or TypeOf sender Is StellwerkControl Then
        Else
            If TypeOf dragobj Is Label And TypeOf sender Is Label Then
                'Hier wird ein Bearbeitungs-Fenster im Stellwerk gezogen.
                'Die if begrenzen die Positionen, damit die Fenster nicht aus dem Bild heraus gezogen werden können
                If MyBase.PointToClient(MousePosition).Y - MouseClickPos.Y < 0 Or MyBase.PointToClient(MousePosition).X - MouseClickPos.X < 0 Then
                    If MyBase.PointToClient(MousePosition).Y - MouseClickPos.Y < 0 Then
                        DirectCast(dragobj, Label).Parent.Top = 0
                    End If
                    If MyBase.PointToClient(MousePosition).X - MouseClickPos.X < 0 Then
                        DirectCast(dragobj, Label).Parent.Left = 0
                    End If
                ElseIf MyBase.PointToClient(MousePosition).Y - MouseClickPos.Y + DirectCast(sender, Label).Height > Me.Height Or MyBase.PointToClient(MousePosition).X - MouseClickPos.X + DirectCast(sender, Label).Width > Me.Width Then
                    If MyBase.PointToClient(MousePosition).Y - MouseClickPos.Y + DirectCast(sender, Label).Height > Me.Height Then
                        DirectCast(dragobj, Label).Parent.Top = Me.Height - DirectCast(sender, Label).Height
                    End If
                    If MyBase.PointToClient(MousePosition).X - MouseClickPos.X + DirectCast(sender, Label).Width > Me.Width Then
                        DirectCast(dragobj, Label).Parent.Left = Me.Width - DirectCast(sender, Label).Width
                    End If
                Else
                    DirectCast(dragobj, Label).Parent.Location = MyBase.PointToClient(MousePosition) - MouseClickPos
                End If
            ElseIf TypeOf dragobj Is CLASS_Gleisbild Then
                'Wenn ein Gleisbild aus der Auswahl gezogen wird
                DirectCast(dragobj, CLASS_Gleisbild).Location = MyBase.PointToClient(MousePosition) - New Point(DirectCast(dragobj, CLASS_Gleisbild).Width / 2, DirectCast(dragobj, CLASS_Gleisbild).Height / 2)
            ElseIf TypeOf dragobj Is Panel Then
                DirectCast(dragobj, Panel).Location = MyBase.PointToClient(MousePosition) - New Point(DirectCast(dragobj, Panel).Width / 2, DirectCast(dragobj, Panel).Height / 2)
            End If
        End If
    End Sub

    Private Sub StellwerkControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'auswahl.Visible = False
        'WirdBearbeitet = New Point(-1, -1)
        If Bearbeiten = True Then
            Dim x As Integer = 0
            Dim y As Integer = 0

            While Element(x, 0).Left < MyBase.PointToClient(MousePosition).X
                x += 1
                If x >= Element.GetLength(0) Then
                    x = -1
                    Exit While
                End If
            End While
            While Element(0, y).Top < MyBase.PointToClient(MousePosition).Y
                y += 1
                If y >= Element.GetLength(1) Then
                    y = -1
                    Exit While
                End If
            End While
            x -= 1
            y -= 1
            WirdBearbeitet = New Point(x, y)

            If x >= 0 And y >= 0 Then
                auswahl.Visible = True
                selecting = True
                auswahl.Location = New Point(Element(x, y).Left - 2, Element(x, y).Top - 2)
                auswahl.BringToFront()
                Panel1.BringToFront()
                EditElement.BringToFront()
            End If
        End If
    End Sub

    'Wenn die Auswahl gezogen wird
    Private Sub ElementMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If auswahl.Visible And selecting = True Then
            auswahl.Height = MyBase.PointToClient(MousePosition).Y - auswahl.Top - 2
            auswahl.Width = MyBase.PointToClient(MousePosition).X - auswahl.Left - 2
        End If
    End Sub

    Private Sub AuswahlMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If selecting = True Then
            ElementMove(sender, e)
        Else
            If dragAuswahl = True Then
                auswahl.Location = MyBase.PointToClient(MousePosition - MouseClickPos)
                If (auswahl.Location + auswahl.Size).X > Element(Element.GetLength(0) - 1, Element.GetLength(1) - 1).Left + Bilder_in_Richtung.Xdots_per_Pic Then
                    auswahl.Left = Element(Element.GetLength(0) - 1, Element.GetLength(1) - 1).Left + Bilder_in_Richtung.Xdots_per_Pic - auswahl.Width
                ElseIf auswahl.Left < Element(0, 0).Left Then
                    auswahl.Left = 0
                End If
                If (auswahl.Location + auswahl.Size).Y > Element(Element.GetLength(0) - 1, Element.GetLength(1) - 1).Top + Bilder_in_Richtung.Ydots_per_Pic Then
                    auswahl.Top = Element(Element.GetLength(0) - 1, Element.GetLength(1) - 1).Top + Bilder_in_Richtung.Ydots_per_Pic - auswahl.Height
                ElseIf auswahl.Top < Element(0, 0).Top Then
                    auswahl.Top = 0
                End If
            End If
        End If
    End Sub

    Private Sub AuswahlMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        dragAuswahl = True
        MouseClickPos = e.Location
    End Sub

    Private Sub AuswahlMouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim target As Point
        If dragAuswahl = True Then
            'Hier müssen dann die ausgewählten Felder versetzt werden
            While Element(target.X, 0).Left + Bilder_in_Richtung.Xdots_per_Pic - Bilder_in_Richtung.Xdots_per_Pic / 2 < auswahl.Left
                target.X += 1
                If target.X >= Element.GetLength(0) Then
                    target.X = -1
                    Exit While
                End If
            End While
            While Element(0, target.Y).Top + Bilder_in_Richtung.Ydots_per_Pic - Bilder_in_Richtung.Ydots_per_Pic / 2 < auswahl.Top
                target.Y += 1
                If target.Y >= Element.GetLength(1) Then
                    target.Y = -1
                    Exit While
                End If
            End While

            If WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
                'Hier werden die Elemente tatsächlich verschoben...
                Dim Clipboard(0 To (pt.X - WirdBearbeitet.X), 0 To (pt.Y - WirdBearbeitet.Y)) As CLASS_Gleisbild

                For i As Integer = 0 To pt.X - WirdBearbeitet.X
                    For q As Integer = 0 To pt.Y - WirdBearbeitet.Y
                        If WirdBearbeitet.X + i < Element.GetLength(0) And WirdBearbeitet.Y + q < Element.GetLength(1) Then
                            Clipboard(i, q) = New CLASS_Gleisbild
                            Clipboard(i, q).gleichsetzten(Element(WirdBearbeitet.X + i, WirdBearbeitet.Y + q))
                            Element(WirdBearbeitet.X + i, WirdBearbeitet.Y + q).delete()
                        End If
                    Next
                Next
                For i As Integer = 0 To pt.X - WirdBearbeitet.X
                    For q As Integer = 0 To pt.Y - WirdBearbeitet.Y
                        If target.X + i <= Bilder_in_Richtung.X And target.Y + q <= Bilder_in_Richtung.Y Then
                            Element(target.X + i, target.Y + q).gleichsetzten(Clipboard(i, q))
                        End If
                    Next
                Next
            End If

            'Hier wird das Auswahlfenster verschoben
            auswahl.Location = Element(target.X, target.Y).Location
            pt = pt - WirdBearbeitet + target
            WirdBearbeitet = target
            StreckentypenInListen()
        End If
        dragAuswahl = False
    End Sub

    Private Sub BefehleInSkriptliste(ByVal obj As CLASS_Gleisbild)
        'schreibt die Befehle aus der Skriptlist in die Listbox in dem ElementBearbeitenPanel
        Liste_Skriptbefehle.Items.Clear()
        Liste_Skriptbefehle.SelectedIndex = -1
        For i As Integer = 0 To obj.Skript.GetAnzahl - 1
            Liste_Skriptbefehle.Items.Add(obj.Skript.GetBefehlString(i))
        Next
    End Sub




    '----------------------------------------------------------Stellerk bearbeiten Menü-----------------------------------
    Private Sub StellwerkBearbeitenAnfangen()
        Panel1.Visible = True
        EditElement.Visible = True
        Bearbeiten = True
        GrößeÄndernToolStripMenuItem.Visible = True
    End Sub

    Private Sub StellwerkBearbeitenBeenden()
        Panel1.Visible = False
        EditElement.Visible = False
        Bearbeiten = False
        auswahl.Visible = False
        GrößeÄndernToolStripMenuItem.Visible = False
        SizeDialog.Visible = False
        StreckentypenInListen()
    End Sub


    'Stellwerk bearbeiten beginnen
    Private Sub BearbeitenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BearbeitenToolStripMenuItem.Click
        If Bearbeiten = False Then
            StellwerkBearbeitenAnfangen()
            'Dim border As New Panel
            'border.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            'border.Location = Element(0, 0).Location - New Point(1, 1)
            'border.Size = Element(Element.GetLength(0) - 1, Element.GetLength(1) - 1).Location - Element(0, 0).Location + New Point(Bilder_in_Richtung.Xdots_per_Pic, Bilder_in_Richtung.Ydots_per_Pic) + New Point(1, 1)
            'border.Parent = Me
            'border.SendToBack()
        Else
            StellwerkBearbeitenBeenden()
        End If
    End Sub

    'Beenden vom Bearbeiten des Stellwerkes
    Private Sub EditSchließen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSchließen.Click
        EditElement.Visible = False
        If Panel1.Visible = False Then
            StellwerkBearbeitenBeenden()
        End If
    End Sub

    Private Sub StellwerkBearbeitenSchließen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StellwerkBearbeitenSchließen.Click
        Panel1.Visible = False
        If EditElement.Visible = False Then
            StellwerkBearbeitenBeenden()
            'Element(WirdBearbeitet.X, WirdBearbeitet.Y).BorderStyle = Windows.Forms.BorderStyle.None
        End If
    End Sub

    'wenn ein Kontakt ausgewählt wurde, wird ihm hier eine Adress zugeordnet
    Private Sub SelectModul_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectModul.ValueChanged, SelectAdress.ValueChanged
        If Me.Created = True And DirectCast(sender, NumericUpDown).Focused And WirdBearbeitet.X <> -1 And WirdBearbeitet.Y <> -1 Then
            Element(WirdBearbeitet.X, WirdBearbeitet.Y).Adresse(0) = SelectModul.Value
            Element(WirdBearbeitet.X, WirdBearbeitet.Y).Adresse(1) = SelectAdress.Value
        End If
    End Sub

    'Fügt einem Bild ein Skript hinzu 
    Private Sub Skript_hinzu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Skript_hinzu.Click
        If WirdBearbeitet <> New Point(-1, -1) Then
            If (S_Richtung.Text = "Musik") Then
                Dim fileChooser = New OpenFileDialog()
                fileChooser.Title = "Wähle eine Media Datei zum Abspielen"
                fileChooser.ShowDialog()
                If fileChooser.CheckFileExists Then
                    Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.MusikBefehlHinzu(fileChooser.FileName)
                End If
            Else
                Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlHinzu(S_weichenadresse.Value, definitionen.StringToWeichenZustände(S_Richtung.Text))
            End If
            BefehleInSkriptliste(Element(WirdBearbeitet.X, WirdBearbeitet.Y))
        End If
    End Sub

    'wenn eine Weiche ausgewählt wurde, wird ihm hier eine Adresse zugeordnet
    Private Sub SelectWeiche_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectWeiche.ValueChanged
        If Me.Created = True And WirdBearbeitet <> New Point(-1, -1) And KeineAuswertung = False Then
            If Element(WirdBearbeitet.X, WirdBearbeitet.Y).Typ = Definitionen.Typen.Weiche Then
                Element(WirdBearbeitet.X, WirdBearbeitet.Y).Adresse(0) = SelectWeiche.Value
            End If
        End If
    End Sub

    Private Sub Skript_entfernen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Skript_entfernen.Click
        If Liste_Skriptbefehle.SelectedIndex >= 0 And WirdBearbeitet <> New Point(-1, -1) Then
            Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlLöschen(Liste_Skriptbefehle.SelectedIndex)
            BefehleInSkriptliste(Element(WirdBearbeitet.X, WirdBearbeitet.Y))
        End If
    End Sub

    'Beim Click in die Skriptlist, soll der Befehl in die Eingabe kopiert werden
    Private Sub Liste_Skriptbefehle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Liste_Skriptbefehle.SelectedIndexChanged
        If Me.Created = True And WirdBearbeitet.X > 0 And WirdBearbeitet.Y > 0 Then
            If Liste_Skriptbefehle.SelectedIndex < Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.GetAnzahl And Liste_Skriptbefehle.SelectedIndex >= 0 Then
                KeineAuswertung = True
                S_weichenadresse.Value = Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlAdresse(Liste_Skriptbefehle.SelectedIndex)
                If Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlRichtung(Liste_Skriptbefehle.SelectedIndex) = Definitionen.Weichen_Zustaende.None Then
                    S_Richtung.Text = "schalten"
                Else
                    S_Richtung.Text = Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlRichtung(Liste_Skriptbefehle.SelectedIndex).ToString
                End If
                KeineAuswertung = False
            End If
        End If
    End Sub

    Private Sub S_weichenadresse_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S_weichenadresse.ValueChanged, S_Richtung.SelectedIndexChanged
        If Liste_Skriptbefehle.SelectedIndex <> -1 And WirdBearbeitet <> New Point(-1, -1) And KeineAuswertung = False Then
            Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlLöschen(Liste_Skriptbefehle.SelectedIndex)
            Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript.BefehlHinzu(S_weichenadresse.Value, Definitionen.StringToWeichenZustände(S_Richtung.Text))
            BefehleInSkriptliste(Element(WirdBearbeitet.X, WirdBearbeitet.Y))
            Liste_Skriptbefehle.SelectedIndex = Liste_Skriptbefehle.Items.Count - 1
        End If
    End Sub

    '---------------------------------Verarbeiten von Tastaturbefehlen für das Control---------------------------

    'Hier werden die Tastaturbefehle für das Control selber abgefangen
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        'Hauptform.GiveMeYourFocus.Focus()
        MyBase.OnKeyDown(e)
        HandleKeyEvent(e)
    End Sub

    Protected Overrides Function ProcessKeyPreview(ByRef m As System.Windows.Forms.Message) As Boolean
        Dim e As KeyEventArgs = New KeyEventArgs(m.WParam)
        HandleKeyEvent(e)
        Return MyBase.ProcessKeyPreview(m)
    End Function

    'Routine zum Verarbeiten der Tastaturbefehle
    Private Sub HandleKeyEvent(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Bearbeiten = True Then
            Select Case e.KeyData
                Case Keys.Delete
                    If WirdBearbeitet <> New Point(-1, -1) Then
                        For i As Integer = WirdBearbeitet.X To pt.X
                            For q As Integer = WirdBearbeitet.Y To pt.Y
                                Element(i, q).delete()
                            Next
                        Next
                    End If
                    auswahl.Visible = False
                Case Keys.Escape
                    auswahl.Visible = False
                    selecting = False
                    dragAuswahl = False
                Case Else
            End Select
        End If
    End Sub

    '----------------------------------------------------------Script kopieren-----------------------------------

    Private Sub Kopieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kopieren.Click
        If WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
            DataToCopy.Gleichsetzen(Element(WirdBearbeitet.X, WirdBearbeitet.Y).Skript)
            Einfügen.Enabled = True
        End If
    End Sub

    Private Sub Einfügen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Einfügen.Click
        If WirdBearbeitet.X >= 0 And WirdBearbeitet.Y >= 0 Then
            For r As Integer = WirdBearbeitet.X To pt.X
                For q As Integer = WirdBearbeitet.Y To pt.Y
                    Element(r, q).Skript.Gleichsetzen(DataToCopy)
                Next
            Next
            BefehleInSkriptliste(Element(WirdBearbeitet.X, WirdBearbeitet.Y))
        End If
    End Sub

    Private Sub TabControlStellwerk_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlStellwerk.SelectedIndexChanged
        Select Case TabControlStellwerk.SelectedIndex
            Case 0
                KontaktEinstellungen.Visible = False
                Weicheneinstellungen.Visible = True
            Case 1
                KontaktEinstellungen.Visible = True
                Weicheneinstellungen.Visible = False
            Case 2
                KontaktEinstellungen.Visible = False
                Weicheneinstellungen.Visible = False
        End Select
        auswahl.Visible = False
    End Sub

    Private Sub GrößeÄndernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrößeÄndernToolStripMenuItem.Click
        If SizeDialog.Visible = False Then
            SizeDialog.Visible = True
            SizeX.Value = Bilder_in_Richtung.X
            SizeY.Value = Bilder_in_Richtung.Y
            SizeDialog.Left = (Me.Width - SizeDialog.Width) / 2
            SizeDialog.Top = (Me.Height - SizeDialog.Height) / 2
            SizeDialog.BringToFront()
        Else
            SizeDialog.Visible = False
        End If
    End Sub

    Private Sub SizeOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeOK.Click
        SizeDialog.Visible = False

        Dim FoundOutside As Boolean = False
        For i As Integer = 0 To Bilder_in_Richtung.X
            For q As Integer = 0 To Bilder_in_Richtung.Y
                If i > SizeX.Value Or q > SizeY.Value Then
                    If Element(i, q).Typ <> Definitionen.Typen.None Then
                        FoundOutside = True
                        Exit For
                    End If
                End If
            Next
            If FoundOutside = True Then
                Exit For
            End If
        Next

        Dim Fortsetzten As MsgBoxResult = MsgBoxResult.Ok

        If FoundOutside = True Then
            Fortsetzten = MsgBox("Es gehen Elemente verloren wenn sie jetzt auf OK drücken, da sie sich außerhalb der neuen Grenzen befinden.", MsgBoxStyle.OkCancel, "Warnung")
        End If


        If Fortsetzten = MsgBoxResult.Ok Then
            '            Stellwerk_speichern(MyTabReference.Name)

            Bilder_in_Richtung.X = SizeX.Value
            Bilder_in_Richtung.Y = SizeY.Value

            StellwerkControl_Load()

            '           LadeStellwerk(MyTabReference.Name)
        End If
    End Sub

    Public Sub LoadfromFile(ByVal Name As String)
        If Eisenbahn.Data(Name & " Konfig", 2) <> Nothing Then
            Bilder_in_Richtung.X = Eisenbahn.Data(Name & " Konfig", 0)
            Bilder_in_Richtung.Y = Eisenbahn.Data(Name & " Konfig", 1)

            StellwerkControl_Load()

            LadeStellwerk(Name)
        Else
            Bilder_in_Richtung.X = 28
            Bilder_in_Richtung.Y = 15

            StellwerkControl_Load()
        End If
    End Sub

    'Diese Funktion lädt alte Stellwerke
    Public Sub LadeStellwerk(ByVal Name As String)


        For count As Integer = 0 To Eisenbahn.Data(Name & " Konfig", 2)
            Dim LoadElement As Point = New Point(Eisenbahn.Data(Name & " PosX", count), Eisenbahn.Data(Name & " PosY", count))
            If LoadElement.X <= Bilder_in_Richtung.X And LoadElement.Y <= Bilder_in_Richtung.Y Then
                With Element(LoadElement.X, LoadElement.Y)
                    Dim Bildnr As Integer
                    Try
                        Bildnr = Integer.Parse(Eisenbahn.Data(Name & " Bildnummer", count))
                    Catch ex As Exception
                        Bildnr = 0
                    End Try

                    Dim Gleistyp As Definitionen.Typen = Definitionen.StringToTypen(Strings.UCase(Eisenbahn.Data(Name & " Gleistyp", count)))
                    .SetAtLoad(Gleistyp, Bilder.Bildnr(Gleistyp, Bildnr, True), Bilder.Bildnr(Gleistyp, Bildnr), _
                            Eisenbahn.Data(Name & " Adresse1", count), Eisenbahn.Data(Name & " Adresse2", count))

                    Dim script = Eisenbahn.Data(Name & " Script", count)
                    If (String.IsNullOrEmpty(script)) Then
                        'Restore legacy saves
                        Dim skriptDirection As definitionen.Weichen_Zustaende = definitionen.StringToWeichenZustände(Eisenbahn.Data(Name & " Skript0 direction", count))
                        Dim skriptAdresse As Integer = Eisenbahn.Data(Name & " Skript0 adresse", count)
                        Dim counter As Integer = 0
                        While skriptAdresse <> 0
                            .Skript.BefehlHinzu(skriptAdresse, skriptDirection)
                            counter += 1
                            skriptDirection = definitionen.StringToWeichenZustände(Eisenbahn.Data(Name & " Skript" & counter & " direction", count))
                            skriptAdresse = Eisenbahn.Data(Name & " Skript" & counter & " adresse", count)
                        End While
                    Else
                        .Skript.Load(script)
                    End If


                End With
            End If
        Next
        Beschreibungen(False)
        StreckentypenInListen()
        Aktualisieren(Definitionen.Typen.None)
    End Sub


    'speichert das Stellwerk
    Public Sub Stellwerk_speichern(ByVal Name As String)
        If Me.Created Then
            Dim count As Integer = 0
            Eisenbahn.Data(Name & " Konfig", 0) = Bilder_in_Richtung.X
            Eisenbahn.Data(Name & " Konfig", 1) = Bilder_in_Richtung.Y
            For i As Integer = 0 To Bilder_in_Richtung.X
                For q As Integer = 0 To Bilder_in_Richtung.Y
                    If Element(i, q).Typ <> Definitionen.Typen.None Then
                        Eisenbahn.Data(Name & " PosX", count) = i
                        Eisenbahn.Data(Name & " PosY", count) = q
                        Eisenbahn.Data(Name & " Gleistyp", count) = Element(i, q).Typ.ToString
                        Eisenbahn.Data(Name & " Bildnummer", count) = Bilder.OfficialNumberOf(Element(i, q).Typ, Element(i, q).Bildnummer(0))
                        Eisenbahn.Data(Name & " Adresse1", count) = Element(i, q).Adresse(0)
                        Eisenbahn.Data(Name & " Adresse2", count) = Element(i, q).Adresse(1)
                        Eisenbahn.Data(Name & " Script", count) = Element(i, q).Skript.Save()
                        count += 1
                    End If
                Next
            Next
            Eisenbahn.Data(Name & " Konfig", 2) = count - 1
        End If
    End Sub


    Private Sub StellwerkControl_Load()
        'Erstellt die einzelnen Bilder im Stellwerk
        '        If Element(0, 0) Is Nothing Then    'Falls die Load funktion zum 2.mal aufgerufen wird

        If Not Element Is Nothing Then
            For i As Integer = 0 To Element.GetLength(0) - 1
                For q As Integer = 0 To Element.GetLength(1) - 1
                    If Not Element(i, q) Is Nothing Then
                        Element(i, q).Parent = Nothing
                        Element(i, q).Dispose()
                        Element(i, q) = Nothing
                    End If
                Next
            Next
        End If

        ReDim Element(Bilder_in_Richtung.X, Bilder_in_Richtung.Y)

        For i As Integer = 0 To Bilder_in_Richtung.X
            For q As Integer = 0 To Bilder_in_Richtung.Y
                If Element(i, q) Is Nothing Then
                    Element(i, q) = New CLASS_Gleisbild
                    Element(i, q).SizeMode = PictureBoxSizeMode.StretchImage
                    Element(i, q).Parent = Me
                    Element(i, q).Visible = False
                    Element(i, q).X = i
                    Element(i, q).Y = q
                    Element(i, q).Label = New Label
                    Element(i, q).Label.Parent = Element(i, q)
                    Element(i, q).Label.BackColor = Color.Transparent
                    Element(i, q).Label.Show()
                    Element(i, q).Name = "Bild" & Bilder_in_Richtung.X * i + q
                    'wenn die Backcolor auf transparent gestellt wird ist das Programm langsam
                    Element(i, q).BackColor = Color.White
                    'Element(i, q).BackColor = Color.Transparent

                    AddHandler Element(i, q).MouseDown, AddressOf Element_Click
                    AddHandler Element(i, q).MouseUp, AddressOf StellwerkControl_MouseUp
                    AddHandler Element(i, q).MouseMove, AddressOf ElementMove
                    AddHandler Element(i, q).Label.MouseDown, AddressOf Element_Click_label
                    AddHandler Element(i, q).Label.MouseUp, AddressOf StellwerkControl_MouseUp
                    AddHandler Element(i, q).Label.MouseMove, AddressOf ElementMove
                    'Element(i, q).Show()
                End If
            Next
        Next

        ResizeTimer.Interval = 100
        ResizeTimer.Enabled = True
        resizing = True

        'End If
    End Sub

    Private Sub SizeX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeX.ValueChanged, SizeY.ValueChanged
        If SizeX.Value * SizeY.Value > 700 Then
            SizeWarnung.Text = "Bei so vielen Bildern kann das Programm sehr langsam werden!"
        Else
            SizeWarnung.Text = "Verhältnis: " & SizeX.Value / SizeY.Value
        End If
    End Sub

    Private Sub SizeOptimum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeOptimum.Click
        SizeX.Value = Int(Me.Width / 40)
        SizeY.Value = Int(Me.Height / 40)
    End Sub

    Private Sub BeschreibungenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeschreibungenToolStripMenuItem.Click
        If BeschreibungenToolStripMenuItem.Checked = True Then
            BeschreibungenToolStripMenuItem.Checked = False
        Else
            BeschreibungenToolStripMenuItem.Checked = True
        End If
        Beschreibungen(BeschreibungenToolStripMenuItem.Checked)
    End Sub

    Private Sub Beschreibungen(ByVal Sichtbar As Boolean)
        For i As Integer = 0 To Element.GetLength(0) - 1
            For q As Integer = 0 To Element.GetLength(1) - 1
                Element(i, q).Label.Visible = Sichtbar
            Next
        Next
    End Sub

    Private Sub SizeAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeAbbrechen.Click
        SizeDialog.Visible = False
    End Sub


End Class
