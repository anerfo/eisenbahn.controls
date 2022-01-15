Imports V5PluginKompaitibilitaet
Imports System.Windows.Forms
'
'       Diese Klasse benötigt die Klassen:   TabManager, StellwerkControl, Bilder
'       und den Namespace Eisenbahn
'

Public Class StellwerkMngr

    Private bilder As Bilder = New Bilder

    Public Stellwerk() As StellwerkControl

    Public Anzahl As Integer = 0

    Public mainReference As PluginManagerLibrary.InterfaceFuerPlugins

    Public Sub Stellwerkhinzufügen()
        If Stellwerk Is Nothing Then
            ReDim Stellwerk(0)
        Else
            ReDim Preserve Stellwerk(Stellwerk.Length)
        End If

        Anzahl = Stellwerk.Length
        Stellwerk(Anzahl - 1) = New StellwerkControl(29, 16, bilder)
        Stellwerk(Anzahl - 1).Dock = DockStyle.Fill
        mainReference.registerGUIControl(Stellwerk(Anzahl - 1))
        '        Stellwerk(Anzahl - 1).MyTabReference.Name = "Stellwerk" & Anzahl - 1
        '        Stellwerk(Anzahl - 1).MyTabReference.Delete = AddressOf StellwerkEntfernen
        Stellwerk(Anzahl - 1).LoadfromFile("Stellwerk" & Anzahl - 1)
        '        TabManager.ControlAnmelden(Stellwerk(Anzahl - 1).MyTabReference)
    End Sub

    Public Sub StellwerkEntfernen(ByVal Nummer As Integer)
        If Nummer > 0 And Nummer <= Stellwerk.Length Then
            'For i As Integer = Stellwerk.Length - 1 To Nummer Step -1
            'Stellwerk(i).MyTabReference.Name = Stellwerk(i - 1).MyTabReference.Name
            'Stellwerk(i).MyTabReference.MyParent.Text = Stellwerk(i).MyTabReference.Name
            'Next
            Stellwerk(Nummer - 1).Dispose()
            For i As Integer = Nummer - 1 To Stellwerk.Length - 2
                Stellwerk(i) = Stellwerk(i + 1)
            Next
            Anzahl -= 1
            ReDim Preserve Stellwerk(Stellwerk.Length - 2)
        End If
    End Sub

    'Private Sub StellwerkEntfernen(ByRef Reference As ControlInterface.TabManagerReference)
    '    For i As Integer = 0 To Stellwerk.Length - 1
    '        If Stellwerk(i).MyTabReference.Name = Reference.Name Then
    '            StellwerkEntfernen(i + 1)
    '            Exit For
    '        End If
    '    Next
    'End Sub
    Private Sub StellwerkEntfernen()

    End Sub

    Public Sub StellwerkEntfernen(ByVal parent As Control)
        For i As Integer = 1 To Stellwerk.Length
            If Stellwerk(i - 1).Parent Is parent Then
                StellwerkEntfernen(i)
                Exit For
            End If
        Next
    End Sub

    Public Sub Aktualisieren(ByVal Typ As Definitionen.Typen)
        If Not Stellwerk Is Nothing Then
            For i As Integer = 0 To Anzahl - 1
                Stellwerk(i).Aktualisieren(Typ)
            Next
        End If
    End Sub

    Public Sub Stellwerke_Speichern()
        If Not Stellwerk Is Nothing Then
            For i As Integer = 0 To Stellwerk.Length - 1
                Stellwerk(i).Stellwerk_speichern("Stellwerk" & i)
            Next
        End If
        Eisenbahn.Data("Programmdaten", 50) = Anzahl
    End Sub

    Public Sub Stellwerke_Laden()
        Anzahl = Eisenbahn.Data("Programmdaten", 50)
        For i As Integer = 0 To Anzahl - 1
            Stellwerkhinzufügen()
        Next
    End Sub

    Public Sub Initialize(ByVal BilderPfad As String)
        bilder.Finde_Bilder(BilderPfad)
        Stellwerke_Laden()
    End Sub
End Class
