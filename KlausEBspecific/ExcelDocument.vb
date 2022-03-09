Imports OfficeOpenXml
Imports System.IO

Public Class ExcelDocument
    Dim _Excel As ExcelPackage
    Dim _FileWatcher As FileSystemWatcher

    Public Sub New(ByRef file As String)
        Dim directory = Path.GetDirectoryName(file)
        Dim filename = Path.GetFileName(file)
        _FileWatcher = New FileSystemWatcher(directory) With {
            .Filter = "*.*",
            .EnableRaisingEvents = True,
            .NotifyFilter = NotifyFilters.LastWrite
        }
        AddHandler _FileWatcher.Changed, AddressOf OnExcelChanged
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        OpenExcel(file)
    End Sub

    Private Sub OpenExcel(ByRef file As String)
        Dim FileInfo As FileInfo = New FileInfo(file)
        _Excel = New ExcelPackage(FileInfo)
    End Sub

    Private Sub OnExcelChanged(sender As Object, e As FileSystemEventArgs)
        OpenExcel(e.FullPath)
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
