Imports OfficeOpenXml
Imports System.IO

Public Class ExcelDocument
    Dim _Excel As ExcelPackage

    Public Sub New(ByRef file As String)
        Dim fileInfo As FileInfo = New FileInfo(file)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        _Excel = New ExcelPackage(fileInfo)
    End Sub

    Public Function GetValue(ByRef table As String, ByRef cell As String) As String
        Return _Excel.Workbook.Worksheets.Item(table).Cells(cell).Value
    End Function

    Public Function GetValue(ByRef table As String, ByRef column As Integer, ByRef row As Integer) As String
        Return _Excel.Workbook.Worksheets.Item(table).Cells(row, column).Value
    End Function

    Public Sub SetValue(ByRef table As String, ByRef cell As String, ByRef value As String)
        _Excel.Workbook.Worksheets.Item(table).Cells(cell).Value = value
        _Excel.Save()
    End Sub

    Public Sub SetValue(ByRef table As String, ByRef column As Integer, ByRef row As Integer, ByRef value As String)
        _Excel.Workbook.Worksheets.Item(table).Cells(row, column).Value = value
        _Excel.Save()
    End Sub
End Class
