Imports System.Windows.Forms
Imports OfficeOpenXml.ExcelErrorValue

Public Class Betriebsparameter
    Dim _Betriebsparameter As Dictionary(Of Integer, Dictionary(Of FahrparameterEnum, Integer)) = New Dictionary(Of Integer, Dictionary(Of FahrparameterEnum, Integer))
    Dim _Daten As Daten.DatenInterface

    Public Enum FahrparameterEnum
        T_100 = 0
        T_130
        T_160
        T_180
        T_500
        V_100
        V_130
        V_160
        V_180
        V_500
        G_200
    End Enum

    Public Sub New(ByRef daten As Daten.DatenInterface)
        InitializeComponent()
        _Daten = daten
        For loknummer As Integer = 1 To 80
            _Betriebsparameter.Add(loknummer, New Dictionary(Of FahrparameterEnum, Integer))
            For Each q As FahrparameterEnum In [Enum].GetValues(GetType(FahrparameterEnum))
                Dim value As String = _Daten.read_from_table("Fahrparameter_" & loknummer, q)
                If Not String.IsNullOrEmpty(value) Then
                    _Betriebsparameter(loknummer)(q) = Integer.Parse(value)
                Else
                    _Betriebsparameter(loknummer)(q) = 0
                End If
            Next
        Next
    End Sub

    Public Sub UpdateContent(loknummern() As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("Parameter", GetType(String))

        For Each id In loknummern
            If Not dt.Columns.Contains(id.ToString()) Then
                dt.Columns.Add(id.ToString(), GetType(Integer))
            End If
        Next

        Dim allParameters = (From id In loknummern
                             Where _Betriebsparameter.ContainsKey(id)
                             From param In _Betriebsparameter(id).Keys
                             Select param).Distinct().ToList()

        For Each param In allParameters
            Dim row = dt.NewRow()
            row("Parameter") = param.ToString()

            For Each id In loknummern
                If _Betriebsparameter.ContainsKey(id) AndAlso _Betriebsparameter(id).ContainsKey(param) Then
                    row(id.ToString()) = _Betriebsparameter(id)(param)
                Else
                    row(id.ToString()) = 0
                End If
            Next
            dt.Rows.Add(row)
        Next

        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex <= 0 Then Exit Sub

        Try
            Dim columnName As String = DataGridView1.Columns(e.ColumnIndex).Name
            Dim targetId As Integer
            If Not Integer.TryParse(columnName, targetId) Then Exit Sub

            Dim paramName As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim parameter As FahrparameterEnum
            If Not [Enum].TryParse(Of FahrparameterEnum)(paramName, parameter) Then Exit Sub

            Dim newValueRaw = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim newValue As Integer = If(IsDBNull(newValueRaw), 0, Convert.ToInt32(newValueRaw))

            If _Betriebsparameter.ContainsKey(targetId) Then
                _Betriebsparameter(targetId)(parameter) = newValue
            Else
                Dim innerDict As New Dictionary(Of FahrparameterEnum, Integer)
                innerDict(parameter) = newValue
                _Betriebsparameter.Add(targetId, innerDict)
            End If
            Save()
        Catch ex As Exception
            MessageBox.Show("Error updating parameter: " & ex.Message)
        End Try
    End Sub

    Public Sub Save()
        For loknummer As Integer = 1 To 80
            For Each q As FahrparameterEnum In [Enum].GetValues(GetType(FahrparameterEnum))
                _Daten.write_to_table("Fahrparameter_" & loknummer, q, _Betriebsparameter(loknummer)(q))
            Next
        Next
    End Sub

    Public Function Fahrparameter(loknummer As Integer, parameter As FahrparameterEnum) As Integer
        Return _Betriebsparameter(loknummer)(parameter)
    End Function

    Public Sub SetFahrparameter(loknummer As Integer, parameter As FahrparameterEnum, value As Integer)
        _Betriebsparameter(loknummer)(parameter) = value
    End Sub
End Class
