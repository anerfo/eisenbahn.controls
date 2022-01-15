Public Class EingangAusgang
    Public result As String

    Public Sub New(ByVal Name As String, ByVal values() As String)
        InitializeComponent()

        Label1.Text = Name
        For Each text As String In values
            ComboBox1.Items.Add(text)
        Next
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        result = ComboBox1.SelectedIndex
    End Sub
End Class
