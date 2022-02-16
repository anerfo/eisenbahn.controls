Public Class WeichenStartposition

    Private eb As Communication.KernelInterface

    Public Sub init(ByRef ebRef As Communication.KernelInterface)
        eb = ebRef

        Dim kontakte(,) As Klassen.Kontakt = eb.holeAlleKontakte

        If kontakte(1, 5).status = True Then
            eb.weicheSchalten(9, Klassen.WeichenRichtung.links)
            eb.weicheSchalten(17, Klassen.WeichenRichtung.rechts)
        Else
            eb.weicheSchalten(9, Klassen.WeichenRichtung.rechts)
            eb.weicheSchalten(17, Klassen.WeichenRichtung.links)
        End If
        If kontakte(3, 1).status = False Then
            eb.weicheSchalten(11, Klassen.WeichenRichtung.rechts)
            eb.weicheSchalten(12, Klassen.WeichenRichtung.rechts)
        Else
            If kontakte(3, 2).status = False Then
                eb.weicheSchalten(11, Klassen.WeichenRichtung.rechts)
                eb.weicheSchalten(12, Klassen.WeichenRichtung.links)
            Else
                eb.weicheSchalten(11, Klassen.WeichenRichtung.links)
                eb.weicheSchalten(12, Klassen.WeichenRichtung.links)
            End If
        End If
    End Sub
End Class
