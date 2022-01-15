Public Class LokBild
    Inherits PictureBox

    Public Sub New(ByVal Bild As Image, ByVal Loknummer As Integer)
        Image = Bild
        ILoknummer = Loknummer
        'Anchor = AnchorStyles.Left And AnchorStyles.Right
        SizeMode = PictureBoxSizeMode.StretchImage
        BackColor = Color.White
        BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private ILoknummer As Integer

    Public Property Loknummer() As Integer
        Get
            Return ILoknummer
        End Get
        Set(ByVal value As Integer)
            ILoknummer = value
        End Set
    End Property

    Private Sub LokBild_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

    End Sub
End Class
