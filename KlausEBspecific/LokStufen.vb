Public Class LokStufen
    Private Const LokStufenTableName = "LokStufen"
    Private Const LokTimerTableName = "LokTimer"

    Dim _LokStufen(,) As Integer
    Dim _LokTimer(,) As Integer
    Dim _Lichter() As Integer = {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 23, 24, 25, 26, 28, 29, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 42, 43, 44, 45, 46, 47, 48, 49, 65, 73}
    Dim _Dampf As System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) = New System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) From {
        {77, Klassen.LokEigenschaften.Funktion1},
        {76, Klassen.LokEigenschaften.Funktion1}}
    Dim _Motor As System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) = New System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) From {
        {40, Klassen.LokEigenschaften.Funktion2},
        {42, Klassen.LokEigenschaften.Funktion3},
        {77, Klassen.LokEigenschaften.Funktion1},
        {76, Klassen.LokEigenschaften.Funktion1}}
    Dim _Ansage As System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) = New System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) From {
        {29, Klassen.LokEigenschaften.Funktion2},
        {76, Klassen.LokEigenschaften.Funktion1}}
    Dim _Pfeifen As System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) = New System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) From {
        {40, Klassen.LokEigenschaften.Funktion2},
        {29, Klassen.LokEigenschaften.Funktion3},
        {76, Klassen.LokEigenschaften.Funktion1}}
    Dim _Innenbeleuchtung As System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) = New System.Collections.Generic.Dictionary(Of Integer, Klassen.LokEigenschaften) From {
        {29, Klassen.LokEigenschaften.Funktion1},
        {40, Klassen.LokEigenschaften.Funktion1},
        {76, Klassen.LokEigenschaften.Funktion1}}

    Private _eb As Communication.KernelInterface
    Private _daten As Daten.DatenInterface

    Dim _aktiveLoks(4) As Integer

    Public Sub New(ByRef eb As Communication.KernelInterface, ByRef daten As Daten.DatenInterface)
        _eb = eb
        _daten = daten
        _LokStufen = New Integer(80, 4) {}
        _LokTimer = New Integer(80, 2) {}
        Laden()
    End Sub

    Public Sub Setzten(ByVal loknummer As Integer, ByVal stufe As Integer, ByVal geschwindigkeit As Integer)
        _LokStufen(loknummer, stufe) = geschwindigkeit
        Speichern()
    End Sub

    Public Sub TimerSetzten(ByVal loknummer As Integer, ByVal timerNummer As Integer, ByVal time As Integer)
        _LokTimer(loknummer,timerNummer) = time
        Speichern()
    End Sub

    Public Function Timer(ByVal loknummer As Integer, ByVal timerNummer As Integer) As Integer
        Dim result As Integer = 5000
        If (_LokTimer(loknummer, timerNummer) > 0) Then
            result = _LokTimer(loknummer, timerNummer)
        End If
        Return result
    End Function

    Public Function TimerAktiveLok(ByVal lok As Integer, ByVal timerNummer As Integer) As Integer
        Return Timer(_aktiveLoks(lok), timerNummer)
    End Function

    Public Sub AktiveSetzten(ByVal lok1 As Integer, ByVal lok2 As Integer, ByVal lok3 As Integer, ByVal lok4 As Integer)
        _aktiveLoks(1) = lok1
        _aktiveLoks(2) = lok2
        _aktiveLoks(3) = lok3
        _aktiveLoks(4) = lok4
        Speichern()
    End Sub


    Public Function AktiveHolen(ByVal nummer As Integer) As Integer
        Return _aktiveLoks(nummer)
    End Function

    Public Sub EinzelLokSenden(ByVal lok As Integer, ByVal stufe As Integer)
        _eb.lokSteuern(_aktiveLoks(lok), Klassen.LokEigenschaften.Geschwindigkeit, _LokStufen(_aktiveLoks(lok), stufe))
    End Sub

    Public Sub Senden(ByVal stufe As Integer)
        For lok As Integer = 1 To 4
            _eb.lokSteuern(_aktiveLoks(lok), Klassen.LokEigenschaften.Geschwindigkeit, _LokStufen(_aktiveLoks(lok), stufe))
        Next
    End Sub

    Private Sub Laden()
        For lok As Integer = 1 To 4
            Dim wert As Integer = _daten.read_from_table(LokStufenTableName + "Aktive", lok)
            If wert = 0 Then
                wert = lok
            End If
            _aktiveLoks(lok) = wert
        Next
        For lok As Integer = 1 To 80
            For stufe As Integer = 1 To 4
                Dim wert As Integer = _daten.read_from_table(LokStufenTableName + lok.ToString(), stufe)
                If (wert = 0) Then
                    wert = stufe * 3
                End If
                _LokStufen(lok, stufe) = wert
            Next
        Next
        For timerNummer As Integer = 1 To 2
            For lok As Integer = 1 To 80
                Dim wert As Integer = _daten.read_from_table(LokTimerTableName, (timerNummer - 1) * 80 + lok)
                If (wert = 0) Then
                    wert = 5000
                End If
                _LokTimer(lok, timerNummer) = wert
            Next
        Next
    End Sub

    Private Sub Speichern()
        For lok As Integer = 1 To 4
            _daten.write_to_table(LokStufenTableName + "Aktive", lok, _aktiveLoks(lok))
        Next
        For lok As Integer = 1 To 80
            For stufe As Integer = 1 To 4
                _daten.write_to_table(LokStufenTableName + lok.ToString(), stufe, _LokStufen(lok, stufe))
            Next
        Next
        For timerNummer As Integer = 1 To 2
            For lok As Integer = 1 To 80
                _daten.write_to_table(LokTimerTableName, (timerNummer - 1) * 80 + lok, _LokTimer(lok, timerNummer))
            Next
        Next
    End Sub

    Public Function Holen(ByVal lok As Integer, ByVal stufe As Integer) As Integer
        Dim result = _LokStufen(lok, stufe)
        If result > 14 Then
            result = 14
        End If
        Return result
    End Function

    Public Sub Lichter(ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        For lok As Integer = 1 To 4
            If _Lichter.Contains(_aktiveLoks(lok)) Then
                _eb.lokSteuern(_aktiveLoks(lok), Klassen.LokEigenschaften.Hauptfunktion, value)
            End If
        Next
    End Sub

    Public Sub Dampf(ByVal lok As Integer, ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        If _Dampf.ContainsKey(_aktiveLoks(lok)) Then
            _eb.lokSteuern(_aktiveLoks(lok), _Dampf(_aktiveLoks(lok)), value)
        End If
    End Sub

    Public Sub Motor(ByVal lok As Integer, ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        If _Motor.ContainsKey(_aktiveLoks(lok)) Then
            _eb.lokSteuern(_aktiveLoks(lok), _Motor(_aktiveLoks(lok)), value)
        End If
    End Sub

    Public Sub Ansage(ByVal lok As Integer, ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        If _Ansage.ContainsKey(_aktiveLoks(lok)) Then
            _eb.lokSteuern(_aktiveLoks(lok), _Ansage(_aktiveLoks(lok)), value)
        End If
    End Sub

    Public Sub Pfeifen(ByVal lok As Integer, ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        If _Pfeifen.ContainsKey(_aktiveLoks(lok)) Then
            _eb.lokSteuern(_aktiveLoks(lok), _Pfeifen(_aktiveLoks(lok)), value)
        End If
    End Sub

    Public Sub Innenbeleuchtung(ByVal lok As Integer, ByVal zustand As Boolean)
        Dim value As Integer = 0
        If (zustand) Then
            value = 1
        End If

        If _Innenbeleuchtung.ContainsKey(_aktiveLoks(lok)) Then
            _eb.lokSteuern(_aktiveLoks(lok), _Innenbeleuchtung(_aktiveLoks(lok)), value)
        End If
    End Sub
End Class
