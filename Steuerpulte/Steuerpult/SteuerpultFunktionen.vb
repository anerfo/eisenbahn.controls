Public Class SteuerpultFunktionen
    'Private Funktion(0 To Definitionen.Constants.AnzahlLoks, 0 To 4) As Boolean 'Ob die Funktionen überhaupt aktiviert sind
    'Private FunktionsBild(0 To Definitionen.Constants.AnzahlLoks, 0 To 4) As Image  'Die Bilder für die Loks
    'Private FunktionsBildName(0 To Definitionen.Constants.AnzahlLoks, 0 To 4) As String  'Die Bildnamen für die Loks
    Private Funktionen(0 To Definitionen.Constants.AnzahlLoks) As CLASSFunktionen
    Private FunktionsBilder() As PictureBox                 'Die PictureBoxen um die Funktionen zu definieren

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not System.IO.Directory.Exists(Application.StartupPath & "\Symbole\Funktionsbilder\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Symbole\Funktionsbilder\")
        End If
        LoadImages(Application.StartupPath & "\Symbole\Funktionsbilder\")

        For i As Integer = 0 To Definitionen.Constants.AnzahlLoks
            Funktionen(i) = New CLASSFunktionen(Me)
        Next
    End Sub

    Private Sub LoadImages(ByVal Path As String)
        'Lädt die Bilder für die Anzeige der Funktionen und lädt auch gleich die PictureBoxen für die Definition
        Dim filelist As ArrayList = New ArrayList
        Dim BilderProZeile As Integer = Int(Me.Width / (30 + 5))
        filelist.AddRange(System.IO.Directory.GetFiles(Path, "*.jpg"))
        filelist.AddRange(System.IO.Directory.GetFiles(Path, "*.gif"))
        filelist.AddRange(System.IO.Directory.GetFiles(Path, "*.bmp"))
        filelist.AddRange(System.IO.Directory.GetFiles(Path, "*.png"))
        ReDim FunktionsBilder(filelist.Count + 1)
        'Das Bild das dafür steht, dass nichts angezeigt wird, uach nicht nur die Checkbox
        FunktionsBilder(0) = New PictureBox
        FunktionsBilder(0).Image = My.Resources.None
        FunktionsBilder(0).Parent = Panel1
        FunktionsBilder(0).Width = 30
        FunktionsBilder(0).Height = 30
        FunktionsBilder(0).SizeMode = PictureBoxSizeMode.StretchImage
        FunktionsBilder(0).Left = 5
        FunktionsBilder(0).Top = 5
        FunktionsBilder(0).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        FunktionsBilder(0).Tag = "None"
        AddHandler FunktionsBilder(0).MouseDown, AddressOf StartDrag
        AddHandler FunktionsBilder(0).MouseMove, AddressOf Drag
        AddHandler FunktionsBilder(0).MouseUp, AddressOf EndDrag
        FunktionsBilder(0).Show()

        'das Bild welches für einfach Beschriftung steht
        FunktionsBilder(1) = New PictureBox
        FunktionsBilder(1).Image = Nothing
        FunktionsBilder(1).Parent = Panel1
        FunktionsBilder(1).Width = 30
        FunktionsBilder(1).Height = 30
        FunktionsBilder(1).SizeMode = PictureBoxSizeMode.StretchImage
        FunktionsBilder(1).Left = 40
        FunktionsBilder(1).Top = 5
        FunktionsBilder(1).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        FunktionsBilder(1).Tag = ""
        AddHandler FunktionsBilder(1).MouseDown, AddressOf StartDrag
        AddHandler FunktionsBilder(1).MouseMove, AddressOf Drag
        AddHandler FunktionsBilder(1).MouseUp, AddressOf EndDrag
        FunktionsBilder(1).Show()

        For i As Integer = 2 To filelist.Count + 1
            FunktionsBilder(i) = New PictureBox
            FunktionsBilder(i).Image = Image.FromFile(filelist(i - 2))
            FunktionsBilder(i).Parent = Panel1
            FunktionsBilder(i).Width = 30
            FunktionsBilder(i).Height = 30
            FunktionsBilder(i).SizeMode = PictureBoxSizeMode.StretchImage
            FunktionsBilder(i).Left = Int(i Mod BilderProZeile) * FunktionsBilder(i).Width + 5 * (i Mod BilderProZeile) + 5
            FunktionsBilder(i).Top = Int(i / BilderProZeile) * FunktionsBilder(i).Height + 5 * Int(i / BilderProZeile) + 5
            FunktionsBilder(i).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            FunktionsBilder(i).Tag = Strings.Right(filelist.Item(i - 2), Strings.Len(filelist(i - 2)) - Strings.InStrRev(filelist.Item(i - 2), "\"))
            AddHandler FunktionsBilder(i).MouseDown, AddressOf StartDrag
            AddHandler FunktionsBilder(i).MouseMove, AddressOf Drag
            AddHandler FunktionsBilder(i).MouseUp, AddressOf EndDrag
            FunktionsBilder(i).Show()
        Next
    End Sub

    'Code für den Drag der Bilder----------------
    Dim origin As Point
    Dim ClickPosition As Point
    Dim Draging

    Private Sub StartDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim SenderObject As PictureBox = sender
        origin = SenderObject.Location
        SenderObject.Parent = Me
        SenderObject.BringToFront()
        ClickPosition = e.Location
        Draging = True
    End Sub

    Private Sub Drag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Draging = True Then
            Dim SenderObject As PictureBox = sender

            SenderObject.Location = MyBase.PointToClient(MousePosition) - ClickPosition
        End If
    End Sub

    Private Sub EndDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Draging = True Then
            Dim SenderObject As PictureBox = sender

            Draging = False
            Dim ControlBelow As PictureBox
            ControlBelow = LocationFeststellen(SenderObject.Location, SenderObject.Size)
            If Not ControlBelow Is Nothing Then
                If Loknummer.Text <> "" Then
                    ControlBelow.Image = SenderObject.Image
                    If Loknummer.Text > 0 And Loknummer.Text <= Definitionen.Constants.AnzahlLoks Then
                        Funktionen(Loknummer.Text).Picturename(ControlBelow.Tag) = SenderObject.Tag
                        If SenderObject.Tag = "None" Then
                            Funktionen(Loknummer.Text).F_ENABLED(ControlBelow.Tag) = False
                        Else
                            Funktionen(Loknummer.Text).F_ENABLED(ControlBelow.Tag) = True
                        End If
                    End If
                End If
            End If
            SenderObject.Parent = Panel1
            SenderObject.Location = origin
        End If
    End Sub

    Private Function LocationFeststellen(ByVal Location As Point, ByVal Size As Size) As PictureBox
        Dim ControlsBelow() As PictureBox = {Hauptfunktion, F1, F2, F3, F4}

        For Each Con As PictureBox In ControlsBelow
            If Location.X + Size.Width / 2 > Con.Left And Location.X - Size.Width / 2 < Con.Left And _
                Location.Y + Size.Height / 2 > Con.Top And Location.Y - Size.Height / 2 < Con.Height Then
                Return Con
            End If
        Next

        Return Nothing
    End Function

    'Public Sub FunktionSetzen(ByVal Loknummer As Integer, ByVal Number As Integer, ByRef CheckBox As CheckBox)
    '    If Funktion(Loknummer, Number) = True Then
    '        CheckBox.Visible = True
    '        Dim a As Integer = Bild(FunktionsBildName(Loknummer, Number))
    '        If a = -2 Then
    '            CheckBox.BackgroundImage = Nothing
    '        Else
    '            CheckBox.BackgroundImage = FunktionsBilder(a).Image
    '        End If
    '    Else
    '        CheckBox.Visible = False
    '        CheckBox.BackgroundImage = Nothing
    '    End If
    'End Sub

    'Public ReadOnly Property Bild(ByVal Name As String) As Integer
    '    Get
    '        For i As Integer = 0 To FunktionsBilder.Length - 1
    '            If Name = "None" Then
    '                Return -2
    '            End If
    '            If Name = FunktionsBilder(i).Tag Then
    '                Return i
    '            End If
    '        Next
    '        Return -1
    '    End Get
    'End Property

    Public ReadOnly Property Picture(ByVal Name As String) As Image
        Get
            For i As Integer = 0 To FunktionsBilder.Length - 1
                If Strings.UCase(FunktionsBilder(i).Tag) = Strings.UCase(Name) Then
                    Return FunktionsBilder(i).Image
                End If
            Next
            If Strings.UCase(Name) <> "NONE" And Name <> "" Then
                Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Fehler, "Das Bild: " & Name & " konnte nicht gefunden werden. (Für die Anzeige der Funktionen von Loks)", True)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property FunktionenDerLok(ByVal Loknummer As Integer) As CLASSFunktionen
        Get
            Return Funktionen(Loknummer)
        End Get
    End Property

    Public Sub Speichern()
        For i As Integer = 0 To Definitionen.Constants.AnzahlLoks
            For q = 0 To 4
                If Funktionen(i).Picturename(q) Is Nothing Then
                    Eisenbahn.Data("Funktionen" & q, i) = ""
                Else
                    Eisenbahn.Data("Funktionen" & q, i) = Funktionen(i).Picturename(q)
                End If
            Next
        Next
    End Sub

    Public Sub laden()
        For i As Integer = 0 To Definitionen.Constants.AnzahlLoks
            For q = 0 To 4
                Dim data As String = Eisenbahn.Data("Funktionen" & q, i)
                Funktionen(i).Picturename(q) = data
                If Not data Is Nothing Then
                    data = data
                End If
                If Strings.UCase(data) = "NONE" Then
                    Funktionen(i).F_ENABLED(q) = False
                Else
                    Funktionen(i).F_ENABLED(q) = True
                End If
            Next
        Next
    End Sub

    Private Sub Loknummer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Loknummer.TextChanged
        If Loknummer.Text <> "" Then
            Hauptfunktion.Image = Funktionen(Loknummer.Text).Picture(0)
            F1.Image = Funktionen(Loknummer.Text).Picture(1)
            F2.Image = Funktionen(Loknummer.Text).Picture(2)
            F3.Image = Funktionen(Loknummer.Text).Picture(3)
            F4.Image = Funktionen(Loknummer.Text).Picture(4)
        End If
    End Sub

    Private Sub FunktionenBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunktionenBeenden.Click
        Me.Hide()
    End Sub
End Class
