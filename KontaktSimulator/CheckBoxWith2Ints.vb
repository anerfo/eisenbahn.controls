Public Class CheckBoxWith2Ints
    Inherits System.Windows.Forms.CheckBox

    Public modul As Integer
    Public addresse As Integer

    Private oldValue As Boolean

    Public Sub setTo(ByVal Value As Boolean)
        If oldValue = False And Value = False Then
            BackColor = Drawing.Color.Transparent
        ElseIf oldValue = False And Value <> False Then
            BackColor = Drawing.Color.DarkBlue
        ElseIf oldValue <> False And Value = False Then
            BackColor = Drawing.Color.LightBlue
        Else
            BackColor = Drawing.Color.Blue
        End If
        oldValue = Value
    End Sub

    Public Sub setToOldValue()
        If oldValue = False Then
            BackColor = Drawing.Color.Transparent
        Else
            BackColor = Drawing.Color.Blue
        End If
    End Sub
End Class
