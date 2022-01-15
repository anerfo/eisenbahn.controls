Public Class DeviceDialog

    Private index As Integer = 0

    Public Sub setDevices(ByVal listOfDevices() As DirectShowLib.DsDevice)
        ListBox1.Items.Clear()
        For i As Integer = 0 To listOfDevices.Length - 1
            ListBox1.Items.Add(listOfDevices(i).Name)
        Next
        index = 0
    End Sub

    Public Function getResult()
        Return index
    End Function

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then
            index = 0
        Else
            index = ListBox1.SelectedIndex
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = vbOK
    End Sub
End Class