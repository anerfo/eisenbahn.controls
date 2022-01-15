Imports System.Windows.Forms
Imports System.Drawing
Imports V5PluginKompaitibilitaet

'--------------------------------------------------------------------------
'   Diese Klasse stellt die Bilder für das Stellwerk bereit
'   benötigte Dateien: Definitionen.vb -> wegen Typen
'--------------------------------------------------------------------------

Imports System.IO

Public Class Bilder

    Structure STRUCT_PICS
        Public image As Image               'Hier wird das Bild gespeichert
        Public official_number As Integer   'Hier wird die in dem Dateiname gespeicherte Nummer gespeichert 
        Public isLeftOff As Boolean         'ist wahr, wenn das Bild ein Weiche nach links geschaltet enthält, oder ein Kontakt der eine 0 zurückmeldet
    End Structure

    Private Weichen() As STRUCT_PICS        'Speichert die Weichenbilder
    Private Kontakte() As STRUCT_PICS       'Speichert die Kontaktbilder
    Private Strecken() As STRUCT_PICS       'Speichert die Streckenbilder

    Public Sub New()                        'Konstruktor für Bilder
        '   Finde_Bilder(Application.StartupPath & "\Symbole\")
    End Sub

    Public Sub Finde_Bilder(ByVal Path As String)      'Durchsucht 'Path', bzw. die Unterordner 'Pfade' nach Bilder mit den Endungen die in 'Endungen' angegeben sind
        Dim endungen() As String = {"*.jpg", "*.gif", "*.bmp"}
        Dim Pfade() As String = {"weichen\", "Strecken\", "Kontakte\"}
        Dim foundpics() As String = Nothing

        For Each Ordner As String In Pfade
            If Not System.IO.Directory.Exists(Path & Ordner) Then
                System.IO.Directory.CreateDirectory(Path & Ordner)
            End If
        Next

        For Each Ordner As String In Pfade
            Dim Count As Integer = 0
            For Each pattern As String In endungen
                Try
                    foundpics = Directory.GetFileSystemEntries(Path & Ordner, pattern)
                Catch ex As Exception
                    'Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Konnte Bilder nicht laden: " & ex.Message, True)
                End Try
                If foundpics.Length <> 0 Then
                    If Ordner = "weichen\" Then
                        If Weichen Is Nothing Then
                            ReDim Preserve Weichen(foundpics.Length - 1)
                        Else
                            ReDim Preserve Weichen(Weichen.Length + foundpics.Length - 1)
                        End If
                    ElseIf Ordner = "Strecken\" Then
                        If Strecken Is Nothing Then
                            ReDim Preserve Strecken(foundpics.Length - 1)
                        Else
                            ReDim Preserve Strecken(Strecken.Length + foundpics.Length - 1)
                        End If
                    Else
                        If Kontakte Is Nothing Then
                            ReDim Preserve Kontakte(foundpics.Length - 1)
                        Else
                            ReDim Preserve Kontakte(Kontakte.Length + foundpics.Length - 1)
                        End If
                    End If
                    For i As Integer = 0 To foundpics.Length - 1
                        If Ordner = "weichen\" Then
                            If Strings.UCase(foundpics(i)) Like "*\*[LRG]." & Strings.UCase(Strings.Right(pattern, 3)) Then

                                Weichen(Count).image = Image.FromFile(foundpics(i))
                                Try
                                    Weichen(Count).official_number = Integer.Parse(Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), "\") + 1, Strings.InStrRev(foundpics(i), ".") - Strings.InStrRev(foundpics(i), "\") - 2))
                                Catch
                                    Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Fehler beim Laden von Bildern: '" & foundpics(i) & "' falsch benannt. Weichen müssen z.B. '123L.jpg' und entsprechend '123R.jpg' benannt sein. ", True)
                                    ReDim Preserve Weichen(Weichen.Length - 2)
                                    Count -= 1
                                End Try

                                Weichen(Count).isLeftOff = True


                                If Strings.UCase(Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), ".") - 1, 1)) = "R" Then
                                    Weichen(Count).isLeftOff = False
                                Else
                                    Weichen(Count).isLeftOff = True
                                End If
                            Else
                                Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Fehler beim Laden von Bildern: '" & foundpics(i) & "' falsch benannt. Weichen müssen z.B. '123L.jpg' und entsprechend '123R.jpg' benannt sein. Es kommt aber kein, oder zu viele, L,R oder G vor.", True)
                                ReDim Preserve Weichen(Weichen.Length - 2)
                                Count -= 1
                            End If
                        ElseIf Ordner = "Strecken\" Then
                            Strecken(Count).image = Image.FromFile(foundpics(i))
                            Try
                                Strecken(Count).official_number = Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), "\") + 1, Strings.InStrRev(foundpics(i), ".") - Strings.InStrRev(foundpics(i), "\") - 1)
                            Catch
                                Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Fehler beim Laden von Bildern: '" & foundpics(i) & "' falsch benannt. Streckenbilder müssen z.B. '123.jpg' heißen!", True)
                                ReDim Preserve Strecken(Strecken.Length - 2)
                                Count -= 1
                            End Try
                        ElseIf Ordner = "Kontakte\" Then
                            If Strings.UCase(foundpics(i)) Like "*\*[A-Z]." & Strings.UCase(Strings.Right(pattern, 3)) Then
                                Kontakte(Count).image = Image.FromFile(foundpics(i))
                                Try
                                    Kontakte(Count).official_number = Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), "\") + 1, Strings.InStrRev(foundpics(i), ".") - Strings.InStrRev(foundpics(i), "\") - 2)
                                Catch
                                    Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Fehler beim Laden von Bildern: '" & foundpics(i) & "' falsch benannt. Kontaktbilder müssen z.B. '123O.jpg' und entsprechend '123I.jpg' benannt sein. ", True)
                                    ReDim Preserve Kontakte(Kontakte.Length - 2)
                                    Count -= 1
                                End Try
                                If Strings.UCase(Strings.Mid(foundpics(i), Strings.InStrRev(foundpics(i), ".") - 1, 1)) = "O" Then
                                    Kontakte(Count).isLeftOff = True
                                Else
                                    Kontakte(Count).isLeftOff = False
                                End If
                            Else
                                Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Warnung, "Fehler beim Laden von Bildern: '" & foundpics(i) & "' falsch benannt. Kontaktbilder müssen z.B. '123O.jpg' und entsprechend '123I.jpg' benannt sein.", True)
                                ReDim Preserve Weichen(Weichen.Length - 2)
                                Count -= 1
                            End If
                        End If
                        Count += 1
                    Next
                End If

            Next
        Next
        'Dim test As Integer
        'Try
        '    test = Kontakte.Length
        'Catch ex As Exception
        '    ReDim Kontakte(0)
        'End Try
        'Try
        '    test = Weichen.Length
        'Catch ex As Exception
        '    ReDim Weichen(0)
        'End Try
        'Try
        '    test = Strecken.Length
        'Catch ex As Exception
        '    ReDim Strecken(0)
        'End Try
        If Kontakte Is Nothing Then
            ReDim Kontakte(0)
        End If
        If Weichen Is Nothing Then
            ReDim Weichen(0)
        End If
        If Strecken Is Nothing Then
            ReDim Strecken(0)
        End If
    End Sub

    'Diese Funktion sucht das Bild mit einem bestimmten Typ und der Nummer aus dem Dateiname und gibt ihn zuück
    'IsLeftOff gibt dabei an ob ein ausgeschalteter kontakt oder eine nach links geschaltete Weiche gesucht wird => dann ist IsLeftOff = true
    Public Function Bild(ByVal typ As Definitionen.Typen, ByVal number As Integer, Optional ByVal IsLeftOff As Boolean = False) As Image
        Select Case typ
            Case Definitionen.Typen.Kontakt
                For i As Integer = 0 To Kontakte.Length - 1
                    If Kontakte(i).official_number = number And IsLeftOff = Kontakte(i).isLeftOff Then
                        Return Kontakte(i).image
                    End If
                Next
            Case Definitionen.Typen.Strecke
                For i As Integer = 0 To Strecken.Length - 1
                    If Strecken(i).official_number = number Then
                        Return Strecken(i).image
                    End If
                Next
            Case Definitionen.Typen.Weiche
                For i As Integer = 0 To Weichen.Length - 1
                    If Weichen(i).official_number = number And IsLeftOff = Weichen(i).isLeftOff Then
                        Return Weichen(i).image
                    End If
                Next
            Case Else
                Return Nothing
        End Select
        Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Nachricht, "Bild " & number & " konnte nicht geladen werden", True)
        Return Nothing
    End Function

    Public Function Bild_mitNummer(ByVal typ As Definitionen.Typen, ByVal number As Integer) As Image
        Select Case typ
            Case Definitionen.Typen.Kontakt
                If number < Kontakte.Length Then
                    Return Kontakte(number).image
                End If
            Case definitionen.Typen.Strecke
                If number < Strecken.Length Then
                    Return Strecken(number).image
                End If
            Case definitionen.Typen.Weiche
                If number < Weichen.Length Then
                    Return Weichen(number).image
                End If
        End Select
        Return Nothing
    End Function

    'Gibt die Nr des Bildes im jeweiligen Array zurück
    Public Function Bildnr(ByVal typ As Definitionen.Typen, ByVal number As Integer, Optional ByVal IsLeftOff As Boolean = False) As Integer
        Select Case typ
            Case Definitionen.Typen.Kontakt
                For i As Integer = 0 To Kontakte.Length - 1
                    If Kontakte(i).official_number = number And IsLeftOff = Kontakte(i).isLeftOff Then
                        Return i
                    End If
                Next
            Case Definitionen.Typen.Strecke
                For i As Integer = 0 To Strecken.Length - 1
                    If Strecken(i).official_number = number Then
                        Return i
                    End If
                Next
            Case Definitionen.Typen.Weiche
                For i As Integer = 0 To Weichen.Length - 1
                    If Weichen(i).official_number = number And IsLeftOff = Weichen(i).isLeftOff Then
                        Return i
                    End If
                Next
            Case Else
                Return Nothing
        End Select
        Eisenbahn.Meldung(Me, Definitionen.MeldungTyp.Nachricht, "Bild " & number & " konnte nicht geladen werden", True)
        Return 0
    End Function

    'gibt die Anzahl der vorhandenen Klasse zurück; bei typ = none die Summe aller Bilder
    Public ReadOnly Property number_of(Optional ByVal typ As Definitionen.Typen = Definitionen.Typen.None)
        Get
            Select Case typ
                Case Definitionen.Typen.Kontakt
                    Return Kontakte.Length - 1
                Case Definitionen.Typen.Strecke
                    Return Strecken.Length - 1
                Case Definitionen.Typen.Weiche
                    Return Weichen.Length - 1
                Case Else
                    Return Weichen.Length + Strecken.Length + Kontakte.Length - 3
            End Select
        End Get
    End Property

    Public ReadOnly Property OfficialNumberOf(ByVal Typ As Definitionen.Typen, ByVal NumberInString As Integer) As Integer
        Get
            If Typ = Definitionen.Typen.Kontakt Then
                Return Kontakte(NumberInString).official_number
            ElseIf Typ = Definitionen.Typen.Strecke Then
                Return Strecken(NumberInString).official_number
            Else
                Return Weichen(NumberInString).official_number
            End If
        End Get
    End Property


End Class
