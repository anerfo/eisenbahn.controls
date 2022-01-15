Public Class PortChooser
    Public result() As Integer

    Public Sub addPort(ByVal name As String, ByVal values() As String)
        Dim port As New EingangAusgang(name, values)
        FlowLayoutPanel1.Controls.Add(port)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReDim result(FlowLayoutPanel1.Controls.Count - 1)

        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            result(i) = DirectCast(FlowLayoutPanel1.Controls(i), EingangAusgang).result
        Next

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Public Sub clearPorts()
        FlowLayoutPanel1.Controls.Clear()
    End Sub

End Class