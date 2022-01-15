Public Class KontaktSpeicher
    Private kontakte(,) As SimulierterKontakt

    Private ebRef As Communication.KernelInterface

    Public ReadOnly Property rueckmeldung(ByVal Modul As Integer, ByVal Nummer As Integer) As Klassen.Kontakt
        Get
            If Modul >= kontakte.GetLength(0) Or Nummer >= kontakte.GetLength(1) Then
                Return Nothing
            End If
            If kontakte(Modul, Nummer).wirdSimuliert Then
                Dim kontakt As New Klassen.Kontakt
                kontakt.Adresse = Nummer
                kontakt.Modul = Modul
                kontakt.status = kontakte(Modul, Nummer).Wert
                Return kontakt
            Else
                Return ebRef.rueckmeldung(Modul, Nummer)
            End If
        End Get
    End Property

    Public WriteOnly Property rueckmeldungSetzen(ByVal Modul As Integer, ByVal Nummer As Integer) As Boolean
        Set(ByVal value As Boolean)
            kontakte(Modul, Nummer).Wert = value
        End Set
    End Property

    Public Property simuliereKontakt(ByVal Modul As Integer, ByVal Nummer As Integer) As Boolean
        Get
            Return kontakte(Modul, Nummer).wirdSimuliert
        End Get
        Set(ByVal value As Boolean)
            If value = False Then
                kontakte(Modul, Nummer).simulationBeenden()
            Else
                kontakte(Modul, Nummer).Wert = kontakte(Modul, Nummer).Wert
            End If
        End Set
    End Property

    Public Sub init(ByRef eb As Communication.KernelInterface)
        ebRef = eb
    End Sub

    Public Sub New()
        ReDim kontakte(Klassen.Konstanten.AnzahlRueckmeldeModule - 1, Klassen.Konstanten.AnzahlAnschluesseProRueckmeldemodul - 1)
        For i As Integer = 0 To Klassen.Konstanten.AnzahlRueckmeldeModule - 1
            For q As Integer = 0 To Klassen.Konstanten.AnzahlAnschluesseProRueckmeldemodul - 1
                kontakte(i, q) = New SimulierterKontakt
            Next
        Next
    End Sub

End Class
