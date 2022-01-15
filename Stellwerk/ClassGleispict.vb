Imports System.Windows.Forms
Imports System.Drawing
Imports V5PluginKompaitibilitaet

Class CLASS_Gleisbild                      'die Klasse eines Bildes im Stellwerk
    Inherits PictureBox                             'das Gleisbild
    Public Label As Label
    Public X As Integer
    Public Y As Integer
    Public Typ As Definitionen.Typen
    Public Bildnummer() As Integer
    Public Adresse() As Integer
    Public Skript As Skriptbefehl = New Skriptbefehl()


    Public Sub gleichsetzten(ByVal OperandB As CLASS_Gleisbild)     'wenn mal zwei Bilder Gleichgesetzt werden sollen, z.B. beim verschieben von einem zum anderen Feld
        If Not OperandB Is Nothing Then
            If OperandB.Typ <> definitionen.Typen.None Then
                Typ = OperandB.Typ
                Visible = True
                Image = OperandB.Image
                ReDim Bildnummer(OperandB.Bildnummer.Length - 1)
                For i As Integer = 0 To OperandB.Bildnummer.Length - 1
                    Bildnummer(i) = OperandB.Bildnummer(i)
                Next
                ReDim Adresse(OperandB.Adresse.Length - 1)
                For i As Integer = 0 To OperandB.Adresse.Length - 1
                    Adresse(i) = OperandB.Adresse(i)
                Next
                Skript.Gleichsetzen(OperandB.Skript)
                If Label Is Nothing Then
                    Label = New Label
                End If
                If Typ = definitionen.Typen.Kontakt Then
                    Label.Text = Adresse(0) & "," & Adresse(1)
                    Label.ForeColor = Color.Gray
                ElseIf Typ = definitionen.Typen.Strecke Then
                    Label.Text = ""
                Else : Typ = definitionen.Typen.Weiche
                    Label.Text = Adresse(0)
                    Label.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Public Sub SetToContact(ByVal XValue As Integer, ByVal YValue As Integer, ByVal Bildnummer0Value As Integer, ByVal Bildnummer1Value As Integer, ByVal ModulValue As Integer, ByVal AdresseValue As Integer)
        X = XValue
        Y = YValue
        ReDim Bildnummer(2)
        Bildnummer(0) = Bildnummer0Value
        Bildnummer(1) = Bildnummer1Value
        Typ = Definitionen.Typen.Kontakt
        ReDim Adresse(1)
        Adresse(0) = ModulValue
        Adresse(1) = AdresseValue
        Label.Text = ModulValue & "," & AdresseValue
        Label.ForeColor = Color.Gray
    End Sub

    Public Sub SetToWeiche(ByVal XValue As Integer, ByVal YValue As Integer, ByVal Bildnummer0Value As Integer, ByVal Bildnummer1Value As Integer, ByVal AdresseValue As Integer)
        X = XValue
        Y = YValue
        ReDim Bildnummer(2)
        Bildnummer(0) = Bildnummer0Value
        Bildnummer(1) = Bildnummer1Value
        Typ = Definitionen.Typen.Weiche
        ReDim Adresse(1)
        Adresse(0) = AdresseValue
        For i As Integer = 0 To Skript.GetAnzahl
            Skript.BefehlLöschen(0)
        Next
        Skript.BefehlHinzu(AdresseValue, Definitionen.Weichen_Zustaende.None)
        Label.Text = AdresseValue
        Label.ForeColor = Color.Red
    End Sub

    Public Sub SetToStrecke(ByVal XValue As Integer, ByVal YValue As Integer, ByVal Bildnummer0Value As Integer)
        X = XValue
        Y = YValue
        ReDim Bildnummer(1)
        Bildnummer(0) = Bildnummer0Value
        Typ = Definitionen.Typen.Strecke
        ReDim Adresse(1)
        Label.Text = ""
    End Sub

    Public Sub SetAtLoad(ByVal TypValue As Definitionen.Typen, ByVal Bildnummer0Value As Integer, ByVal Bildnummer1Value As Integer, ByVal ModulValue As Integer, ByVal AdresseValue As Integer)
        Typ = TypValue
        Visible = True
        ReDim Bildnummer(2)
        Bildnummer(0) = Bildnummer0Value
        Bildnummer(1) = Bildnummer1Value
        ReDim Adresse(2)
        Adresse(0) = ModulValue
        Adresse(1) = AdresseValue
        If Typ = Definitionen.Typen.Kontakt Then
            Label.Text = Adresse(0) & "," & Adresse(1)
            Label.ForeColor = Color.Gray
        ElseIf Typ = Definitionen.Typen.Strecke Then
            Label.Text = ""
        Else : Typ = Definitionen.Typen.Weiche
            Label.Text = Adresse(0)
            Label.ForeColor = Color.Red
        End If
    End Sub

    Public Sub New()
        ReDim Bildnummer(2)
        ReDim Adresse(2)
        Visible = False
        Label = New Label
    End Sub

    Public Sub delete()
        Typ = Definitionen.Typen.None
        ReDim Bildnummer(2)
        Bildnummer(0) = 0
        Bildnummer(1) = 0
        ReDim Adresse(2)
        Adresse(0) = 0
        Adresse(1) = 0
        For i As Integer = 0 To Skript.GetAnzahl
            Skript.BefehlLöschen(i)
        Next
        Label.Text = ""
        Image = Nothing
        Visible = False
    End Sub
End Class
