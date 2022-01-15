Public Class CLASSFunktionen
    Public F_ENABLED(4) As Boolean
    Private F_PICTURE(4) As Image
    Private F_IMAGENAME(4) As String
    Private MyPicSource As SteuerpultFunktionen

    Public Sub New(ByRef PictureSource As SteuerpultFunktionen)
        MyPicSource = PictureSource
    End Sub

    Public ReadOnly Property Picture(ByVal Funktionsnummer As Integer) As Image
        Get
            Return F_PICTURE(Funktionsnummer)
        End Get
    End Property

    Public Property Picturename(ByVal Funktionsnummer As Integer) As String
        Get
            Return F_IMAGENAME(Funktionsnummer)
        End Get
        Set(ByVal value As String)
            F_PICTURE(Funktionsnummer) = MyPicSource.Picture(value)
            F_IMAGENAME(Funktionsnummer) = value
        End Set
    End Property
End Class