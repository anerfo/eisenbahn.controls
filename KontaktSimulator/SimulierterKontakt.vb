Public Class SimulierterKontakt
    Private intWirdSimuliert As Boolean
    Private simulationsWert As Boolean

    Public Sub simulationBeenden()
        intWirdSimuliert = False
    End Sub

    Public Property Wert As Boolean
        Get
            Return simulationsWert
        End Get
        Set(ByVal value As Boolean)
            intWirdSimuliert = True
            simulationsWert = value
        End Set
    End Property

    Public ReadOnly Property wirdSimuliert As Boolean
        Get
            Return intWirdSimuliert
        End Get
    End Property
End Class
