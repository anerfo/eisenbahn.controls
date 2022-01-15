Public Class Weichensteuerung
    Implements Communication.KernelInterface
    Implements Communication.WeichenEventUpdateInterface


    Private eb As Communication.KernelInterface
    Private daten As Daten.DatenInterface

    Public weichen() As WeichenParameter

    Private WeichenEventBeobachter() As Communication.WeichenEventUpdateInterface

    Public Sub init(ByVal Datenspeicher As Daten.DatenInterface, ByVal ebRef As Communication.KernelInterface)
        ReDim weichen(Klassen.Konstanten.AnzahlWeichen - 1)
        For i As Integer = 0 To weichen.Length - 1
            weichen(i) = New WeichenParameter
        Next
        eb = ebRef
        daten = Datenspeicher
        WeichenParameterLaden()
        WeichenInStartzustandSchalten()
    End Sub

    Public Function holeAlleKontakte() As Klassen.Kontakt(,) Implements Communication.KernelInterface.holeAlleKontakte
        Return eb.holeAlleKontakte
    End Function

    Public Function holeAlleLoks() As Klassen.Lok() Implements Communication.KernelInterface.holeAlleLoks
        Return eb.holeAlleLoks()
    End Function

    Public Function holeAlleWeichen() As Klassen.Weiche() Implements Communication.KernelInterface.holeAlleWeichen
        Dim weichenErgebnis() As Klassen.Weiche = eb.holeAlleWeichen

        Dim length As Integer = Math.Min(weichen.Length, weichenErgebnis.Length)

        For i As Integer = 0 To length - 1
            If weichen(i).linksEntspricht = Klassen.WeichenRichtung.rechts Then
                If weichenErgebnis(i).Richtung = Klassen.WeichenRichtung.links Then
                    weichenErgebnis(i).Richtung = Klassen.WeichenRichtung.rechts
                ElseIf weichenErgebnis(i).Richtung = Klassen.WeichenRichtung.rechts Then
                    weichenErgebnis(i).Richtung = Klassen.WeichenRichtung.links
                Else

                End If
            End If
        Next
        Return weichenErgebnis
    End Function

    Public ReadOnly Property lok(ByVal Nummer As Integer) As Klassen.Lok Implements Communication.KernelInterface.lok
        Get
            Return eb.lok(Nummer)
        End Get
    End Property

    Public Sub lokSteuern(ByVal nummer As Integer, ByVal funktion As Klassen.LokEigenschaften, ByVal wert As Integer) Implements Communication.KernelInterface.lokSteuern
        eb.lokSteuern(nummer, funktion, wert)
    End Sub

    Public Sub lokUmdrehen(ByVal nummer As Integer) Implements Communication.KernelInterface.lokUmdrehen
        eb.lokUmdrehen(nummer)
    End Sub

    Public Property nothalt As Boolean Implements Communication.KernelInterface.nothalt
        Get
            Return eb.nothalt
        End Get
        Set(ByVal value As Boolean)
            eb.nothalt = value
        End Set
    End Property

    Public Sub registriereFuerKontaktEvents(ByRef Referenz As Communication.KontaktEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerKontaktEvents
        eb.registriereFuerKontaktEvents(Referenz)
    End Sub

    Public Sub registriereFuerLokEvents(ByRef Referenz As Communication.LokEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerLokEvents
        eb.registriereFuerLokEvents(Referenz)
    End Sub

    Public Sub registriereFuerNothaltEvents(ByRef Referenz As Communication.NothaltEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerNothaltEvents
        eb.registriereFuerNothaltEvents(Referenz)
    End Sub

    Public Sub registriereFuerWeichenEvents(ByRef Referenz As Communication.WeichenEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerWeichenEvents
        If WeichenEventBeobachter Is Nothing Then
            ReDim WeichenEventBeobachter(0)
        Else
            ReDim Preserve WeichenEventBeobachter(WeichenEventBeobachter.Length)
        End If
        WeichenEventBeobachter(WeichenEventBeobachter.Length - 1) = Referenz
    End Sub

    Public ReadOnly Property rueckmeldung(ByVal Modul As Integer, ByVal Nummer As Integer) As Klassen.Kontakt Implements Communication.KernelInterface.rueckmeldung
        Get
            Return eb.rueckmeldung(Modul, Nummer)
        End Get
    End Property

    Public ReadOnly Property weiche(ByVal Nummer As Integer) As Klassen.Weiche Implements Communication.KernelInterface.weiche
        Get
            Dim weichenErgebnis As Klassen.Weiche = eb.weiche(Nummer)
            If weichen(Nummer).linksEntspricht = Klassen.WeichenRichtung.rechts Then
                If weichenErgebnis.Richtung = Klassen.WeichenRichtung.links Then
                    weichenErgebnis.Richtung = Klassen.WeichenRichtung.rechts
                Else
                    weichenErgebnis.Richtung = Klassen.WeichenRichtung.links
                End If
            End If
            Return weichenErgebnis
        End Get
    End Property

    Public Sub weicheSchalten(ByVal nummer As Integer, ByVal Richtung As Klassen.WeichenRichtung) Implements Communication.KernelInterface.weicheSchalten
        Dim result As Klassen.WeichenRichtung = Richtung
        If weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.rechts Then
            If result = Klassen.WeichenRichtung.links Then
                result = Klassen.WeichenRichtung.rechts
            Else
                result = Klassen.WeichenRichtung.links
            End If
        End If
        eb.weicheSchalten(nummer, result)
    End Sub

    Public Sub WeichenInStartzustandSchalten()
        For i As Integer = 0 To weichen.Length - 1
            If weichen(i).startzustand <> Klassen.WeichenRichtung.none Then
                weicheSchalten(i, weichen(i).startzustand)
            End If
        Next
    End Sub

    Public Sub WeichenParameterLaden()
        For i As Integer = 0 To weichen.Length - 1
            If daten.read_from_table("WeichenParameter", i) = 0 Then
                weichen(i).linksEntspricht = Klassen.WeichenRichtung.links
            Else
                weichen(i).linksEntspricht = Klassen.WeichenRichtung.rechts
            End If
            If daten.read_from_table("WeichenStartzustand", i) = 1 Then
                weichen(i).startzustand = Klassen.WeichenRichtung.links
            ElseIf daten.read_from_table("WeichenStartzustand", i) = 2 Then
                weichen(i).startzustand = Klassen.WeichenRichtung.rechts
            Else
                weichen(i).startzustand = Klassen.WeichenRichtung.none
            End If
        Next
    End Sub

    Public Sub WeichenParameterSpeichern()
        For i As Integer = 0 To weichen.Length - 1
            If weichen(i).linksEntspricht = Klassen.WeichenRichtung.links Then
                daten.write_to_table("WeichenParameter", i, 0)
            Else
                daten.write_to_table("WeichenParameter", i, 1)
            End If
            If weichen(i).startzustand = Klassen.WeichenRichtung.links Then
                daten.write_to_table("WeichenStartzustand", i, 1)
            ElseIf weichen(i).startzustand = Klassen.WeichenRichtung.rechts Then
                daten.write_to_table("WeichenStartzustand", i, 2)
            Else
                daten.write_to_table("WeichenStartzustand", i, 0)
            End If
        Next
    End Sub

    Public Sub UpdateWeichen()
        Dim lokaleWeichen() As Klassen.Weiche = holeAlleWeichen()

        If Not WeichenEventBeobachter Is Nothing Then
            For i As Integer = 0 To WeichenEventBeobachter.Length - 1
                WeichenEventBeobachter(i).update(lokaleWeichen)
            Next
        End If
    End Sub

    Public Sub WeicheUmdrehen(ByVal nummer As Integer, ByVal value As Boolean)
        If value = True Then
            weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.rechts
        Else
            weichen(nummer).linksEntspricht = Klassen.WeichenRichtung.links
        End If
        UpdateWeichen()
    End Sub

    Public Sub WeicheStartzustandFestlegen(ByVal nummer As Integer, ByVal richtung As Klassen.WeichenRichtung)
        weichen(nummer).startzustand = richtung
    End Sub

    Public Sub update1(ByVal Weiche() As Klassen.Weiche) Implements Communication.WeichenEventUpdateInterface.update
        UpdateWeichen()
    End Sub

    Public Function holeAlleGeaendertenKontakte() As Klassen.Kontakt() Implements Communication.KernelInterface.holeAlleGeaendertenKontakte
        Return eb.holeAlleGeaendertenKontakte
    End Function
End Class
