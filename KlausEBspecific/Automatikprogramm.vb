Public Class Automatikprogramm
    Private _bAktiv As Boolean = False
    Private _eb As Communication.KernelInterface

    Public Sub New(ByRef eb As Communication.KernelInterface)
        _eb = eb
    End Sub

    Public Sub Starten()
        _bAktiv = True
    End Sub

    Public Sub Stoppen()
        _bAktiv = False
    End Sub

    Public Sub KontaktWechsel(ByVal Kontakte() As Klassen.Kontakt)
        If _bAktiv Then
            For Each Kontakt As Klassen.Kontakt In Kontakte
                If Kontakt.Modul = 1 And Kontakt.Adresse = 3 And Kontakt.status = True Then
                    _eb.weicheSchalten(11, Klassen.WeichenRichtung.links)
                End If
                If Kontakt.Modul = 0 And Kontakt.Adresse = 5 And Kontakt.status = True Then
                    _eb.weicheSchalten(9, Klassen.WeichenRichtung.links)
                End If
                If ((Kontakt.Modul = 0 And Kontakt.Adresse = 1) Or
                    (Kontakt.Modul = 0 And Kontakt.Adresse = 3) Or
                    (Kontakt.Modul = 1 And Kontakt.Adresse = 5) Or
                    (Kontakt.Modul = 1 And Kontakt.Adresse = 7)) And Kontakt.status = True Then
                    _eb.weicheSchalten(11, Klassen.WeichenRichtung.rechts)
                    _eb.weicheSchalten(9, Klassen.WeichenRichtung.rechts)
                End If
                If Kontakt.Modul = 0 And Kontakt.Adresse = 3 And Kontakt.status = True Then
                    _eb.lokSteuern(17, Klassen.LokEigenschaften.Funktion1, 1)
                End If
            Next
        End If
    End Sub
End Class
