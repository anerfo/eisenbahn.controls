Public Class ShowRunner
    ''' <summary>
    ''' Stores the currently executed show
    ''' </summary>
    ''' <remarks></remarks>
    Private _thread As System.Threading.Thread

    ''' <summary>
    ''' Stores a reference to the show that is currently executed
    ''' </summary>
    ''' <remarks></remarks>
    Private _currentShow As ShowBase

    ''' <summary>
    ''' Runs a show
    ''' </summary>
    ''' <param name="show">The show that shall be executed</param>
    ''' <remarks></remarks>
    Public Sub RunShow(ByVal show As ShowBase)
        If Not _currentShow Is Nothing Then
            StopCurrentShow()
        End If

        _currentShow = show
        _thread = New Threading.Thread(AddressOf show.RunShow)
        _thread.Start()
    End Sub

    ''' <summary>
    ''' Stops the currently executed show.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopCurrentShow()
        If Not _thread Is Nothing Then
            _thread.Abort()
        End If
        If (Not _currentShow Is Nothing) Then
            _currentShow.StopShow()
            _currentShow = Nothing
        End If
    End Sub
End Class
