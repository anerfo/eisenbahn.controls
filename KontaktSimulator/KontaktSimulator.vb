Public Class KontaktSimulator
    Implements Communication.KernelInterface

    Private eb As Communication.KernelInterface = New Communication.DummyKernelIFClass
    Public rueckmeldungen As New KontaktSpeicher
    Public geaenderteRueckmeldungen() As Klassen.Kontakt

    Private KontaktEventBeobachter() As Communication.KontaktEventUpdateInterface

    Public Sub init(ByRef ebRef As Communication.KernelInterface)
        eb = ebRef
        rueckmeldungen.init(ebRef)
    End Sub

    Public Function holeAlleKontakte() As Klassen.Kontakt(,) Implements Communication.KernelInterface.holeAlleKontakte
        Dim result(,) As Klassen.Kontakt = eb.holeAlleKontakte
        For i As Integer = 0 To Klassen.Konstanten.AnzahlRueckmeldeModule - 1
            For q As Integer = 0 To Klassen.Konstanten.AnzahlAnschluesseProRueckmeldemodul - 1
                If rueckmeldungen.simuliereKontakt(i, q) Then
                    result(i, q) = rueckmeldungen.rueckmeldung(i, q)
                End If
            Next
        Next
        Return result
    End Function

    Public Function holeAlleLoks() As Klassen.Lok() Implements Communication.KernelInterface.holeAlleLoks
        Return eb.holeAlleLoks
    End Function

    Public Function holeAlleWeichen() As Klassen.Weiche() Implements Communication.KernelInterface.holeAlleWeichen
        Return eb.holeAlleWeichen
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

        If KontaktEventBeobachter Is Nothing Then
            ReDim KontaktEventBeobachter(0)
        Else
            ReDim Preserve KontaktEventBeobachter(KontaktEventBeobachter.Length)
        End If
        KontaktEventBeobachter(KontaktEventBeobachter.Length - 1) = Referenz
    End Sub

    Public Sub registriereFuerLokEvents(ByRef Referenz As Communication.LokEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerLokEvents
        eb.registriereFuerLokEvents(Referenz)
    End Sub

    Public Sub registriereFuerNothaltEvents(ByRef Referenz As Communication.NothaltEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerNothaltEvents
        eb.registriereFuerNothaltEvents(Referenz)
    End Sub

    Public Sub registriereFuerWeichenEvents(ByRef Referenz As Communication.WeichenEventUpdateInterface) Implements Communication.KernelInterface.registriereFuerWeichenEvents
        eb.registriereFuerWeichenEvents(Referenz)
    End Sub

    Public ReadOnly Property rueckmeldung(ByVal Modul As Integer, ByVal Nummer As Integer) As Klassen.Kontakt Implements Communication.KernelInterface.rueckmeldung
        Get
            Return rueckmeldungen.rueckmeldung(Modul, Nummer)
        End Get
    End Property

    Public ReadOnly Property weiche(ByVal Nummer As Integer) As Klassen.Weiche Implements Communication.KernelInterface.weiche
        Get
            Return eb.weiche(Nummer)
        End Get
    End Property

    Public Sub weicheSchalten(ByVal nummer As Integer, ByVal Richtung As Klassen.WeichenRichtung) Implements Communication.KernelInterface.weicheSchalten
        eb.weicheSchalten(nummer, Richtung)
    End Sub

    Public Sub UpdateKontakte(ByVal modul As Integer, ByVal adresse As Integer)
        Dim geaendert(0) As Klassen.Kontakt '= {New Klassen.Kontakt}
        'geaendert(0).Modul = modul
        'geaendert(0).Adresse = adresse
        geaendert(0) = rueckmeldungen.rueckmeldung(modul, adresse)
        'Alle geänderten Kontakte updaten
        If Not KontaktEventBeobachter Is Nothing And Not geaendert Is Nothing Then
            For i As Integer = 0 To KontaktEventBeobachter.Length - 1
                KontaktEventBeobachter(i).update(geaendert)
            Next
        End If
    End Sub

    Public Function holeAlleGeaendertenKontakte() As Klassen.Kontakt() Implements Communication.KernelInterface.holeAlleGeaendertenKontakte
        Return geaenderteRueckmeldungen
    End Function
End Class
