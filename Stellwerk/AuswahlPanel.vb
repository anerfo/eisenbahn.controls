Imports System.Windows.Forms
Imports System.Drawing

Public Class AuswahlPanel
    Inherits Panel

    Sub New()
        MyBase.ResizeRedraw = True
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim blueBrush As New System.Drawing.Drawing2D.HatchBrush(Drawing2D.HatchStyle.Percent25, Color.Blue, Color.Transparent)
        Dim rect As New Rectangle(0, 0, Width, Height)
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
        e.Graphics.FillRectangle(blueBrush, rect)
    End Sub
End Class
