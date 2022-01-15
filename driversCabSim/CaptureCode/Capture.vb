Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports DirectShowLib
Imports System.Runtime.InteropServices.ComTypes

''' <summary>
''' Renders the analog input of an video device to a control
''' </summary>
''' <remarks></remarks>
Public Class Capture

#Region "Variables"
    Private D As Integer = Convert.ToInt32("0X8000", 16)
    Private WM_GRAPHNOTIFY As Integer = D + 1
    Private LOOK_UPSTREAM_ONLY As Guid = New Guid("AC798BE0-98E3-11d1-B3F1-00AA003761C5")

    Private Enum PlayState
        Stopped = 0
        Paused = 1
        Running = 2
        Init = 3
    End Enum

    Private currentState As PlayState = PlayState.Stopped

    Private videoWindow As IVideoWindow = Nothing
    Private mediaControl As IMediaControl = Nothing
    Private mediaEventEx As IMediaEventEx = Nothing
    Private graphBuilder As IGraphBuilder = Nothing
    Private captureGraphBuilder As ICaptureGraphBuilder2 = Nothing
    Private camControl As IAMCameraControl = Nothing

#If DEBUG Then
    Private rot As DsROTEntry = Nothing
#End If

    Private videoControl As Control

    Private hr As Integer = 0

    Private deviceDialog As New DeviceDialog
    Private PortChooser As New PortChooser

#End Region

    ''' <summary>
    ''' set the control in which the video should be rendered
    ''' </summary>
    ''' <param name="iVideoControl">the control to render in</param>
    ''' <remarks></remarks>
    Public Sub setVideoControl(ByVal iVideoControl As Control)
        videoControl = iVideoControl
        AddHandler videoControl.Resize, AddressOf ResizeVideoWindow
    End Sub

    ''' <summary>
    ''' start the playback
    ''' </summary>
    ''' <remarks>execute the setVideoControl function before calling this sub</remarks>
    Public Sub CaptureVideo(Optional ByVal interfaceNumber As Integer = -1)
        If videoControl Is Nothing Or currentState = PlayState.Running Then
            Return
        End If

        Dim waitText As New Label
        waitText.Text = "Lade Video..."
        waitText.Font = New Font("Arial", 25)
        waitText.AutoSize = True
        waitText.BorderStyle = BorderStyle.FixedSingle
        waitText.Left = videoControl.Width / 2 - waitText.Width / 2
        waitText.Top = videoControl.Height / 2 - waitText.Height / 2
        waitText.BackColor = Color.White
        waitText.Parent = videoControl
        waitText.Update()

        Dim sourceFilter As IBaseFilter = Nothing

        Try

            getInterfaces()

            hr = captureGraphBuilder.SetFiltergraph(graphBuilder)
            DsError.ThrowExceptionForHR(hr)

            sourceFilter = FindCaptureDevice(interfaceNumber)

            If sourceFilter Is Nothing Then
                MsgBox("Es wurde kein Videogerät gefunden.")
                waitText.Dispose()
                waitText = Nothing
                Return
            End If

            hr = graphBuilder.AddFilter(sourceFilter, "Video Capture")
            DsError.ThrowExceptionForHR(hr)

            hr = captureGraphBuilder.RenderStream(PinCategory.Capture, MediaType.Video, sourceFilter, Nothing, Nothing)
            DsError.ThrowExceptionForHR(hr)

            selectInOut(sourceFilter)
            DsError.ThrowExceptionForHR(hr)

            camControl = CType(sourceFilter, IAMCameraControl)
            If Not camControl Is Nothing Then
                Dim focusValue As Long = 2
                hr = camControl.Set(CameraControlProperty.Focus, focusValue, DirectShowLib.CameraControlFlags.Manual)
                'hr = camControl.Set(CameraControlProperty.Focus, focusValue, DirectShowLib.CameraControlFlags.Auto)
            End If

            SetupVideoWindow()
#If DEBUG Then
            rot = New DsROTEntry(graphBuilder)
#End If

            hr = Me.mediaControl.Run()
            DsError.ThrowExceptionForHR(hr)

            currentState = PlayState.Running
        Catch ex As Exception
            MessageBox.Show("An unrecoverable error has occurred.With error : " & ex.ToString)
        Finally
            If (Not sourceFilter Is Nothing) Then
                Marshal.ReleaseComObject(sourceFilter)
                sourceFilter = Nothing
            End If
            waitText = Nothing
        End Try
    End Sub

    Private Sub getInterfaces()
        graphBuilder = CType(New FilterGraph, IGraphBuilder)
        captureGraphBuilder = CType(New CaptureGraphBuilder2, ICaptureGraphBuilder2)
        mediaControl = CType(graphBuilder, IMediaControl)
        videoWindow = CType(graphBuilder, IVideoWindow)
        mediaEventEx = CType(graphBuilder, IMediaEventEx)
        hr = mediaEventEx.SetNotifyWindow(videoControl.Handle, WM_GRAPHNOTIFY, IntPtr.Zero)
        DsError.ThrowExceptionForHR(hr)
    End Sub

    ''' <summary>
    ''' Find the device to get the video from
    ''' </summary>
    ''' <param name="interfaceNumber">if not -1 then it will take the device with the number given</param>
    ''' <returns>the device to get the video from</returns>
    ''' <remarks></remarks>
    Private Function FindCaptureDevice(Optional ByVal interfaceNumber As Integer = -1)
        Dim capDevices As DsDevice()

        capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)

        If (capDevices.Length = 0) Then
            Return Nothing
        End If

        Dim selection As Integer = 0

        If interfaceNumber = -1 Then
            If capDevices.Length > 1 Then
                DeviceDialog.setDevices(capDevices)
                DeviceDialog.ShowDialog()
                selection = DeviceDialog.getResult
            End If
        Else
            If selection > capDevices.Length Then
                Throw New IndexOutOfRangeException("The given index is larger than the number of available devices.")
            Else
                selection = interfaceNumber
            End If
        End If

        Dim moniker As IMoniker = capDevices(selection).Mon

        Dim source As Object = Nothing

        Dim iid As Guid = GetType(IBaseFilter).GUID

        moniker.BindToObject(Nothing, Nothing, iid, source)

        Return CType(source, IBaseFilter)
    End Function

    ''' <summary>
    ''' returns possible Video Devices
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDevices() As DsDevice()
        Dim capDevices As DsDevice()

        capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)

        Return capDevices
    End Function

    Private Sub SetupVideoWindow()
        Dim hr As Integer = 0
        hr = videoWindow.put_Owner(videoControl.Handle)
        DsError.ThrowExceptionForHR(hr)

        hr = videoWindow.put_WindowStyle(WindowStyle.Child Or WindowStyle.ClipChildren)
        DsError.ThrowExceptionForHR(hr)

        ResizeVideoWindow()

        hr = videoWindow.put_Visible(OABool.True)
        DsError.ThrowExceptionForHR(hr)
    End Sub

    ''' <summary>
    ''' resizes the video to the size of the videoControl-Element
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResizeVideoWindow()
        If Not (videoWindow Is Nothing) Then

            videoWindow.SetWindowPosition(0, 0, videoControl.Width, videoControl.ClientSize.Height)
        End If
    End Sub

    ''' <summary>
    ''' Stops the rendering
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseInterfaces()
        Dim hr As Integer

        Try
            If (Not mediaControl Is Nothing) Then

                hr = mediaControl.Stop()
                mediaControl = Nothing
                currentState = PlayState.Stopped
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

#If DEBUG Then
        If (Not rot Is Nothing) Then
            rot.Dispose()
            rot = Nothing
        End If
#End If

        If (Not graphBuilder Is Nothing) Then
            Marshal.ReleaseComObject(graphBuilder)
            graphBuilder = Nothing
        End If
        GC.Collect()
    End Sub

    Private Sub selectInOut(ByVal sourceFilter As IBaseFilter)
        Dim crossbar As IAMCrossbar = Nothing

        Try
            Dim iid As Guid = GetType(IAMCrossbar).GUID
            hr = captureGraphBuilder.FindInterface(LOOK_UPSTREAM_ONLY, Nothing, sourceFilter, iid, crossbar)

            If crossbar Is Nothing Then 'Then there is propably no crossbar interface
                hr = 0
                Return
            End If
            DsError.ThrowExceptionForHR(hr)

            Dim inPinCount, outPinCount As Integer
            hr = crossbar.get_PinCounts(outPinCount, inPinCount)
            DsError.ThrowExceptionForHR(hr)

            Dim inNames(inPinCount - 1) As String
            Dim outNames(outPinCount - 1) As String

            For i As Integer = 0 To inPinCount - 1
                Dim phytype As PhysicalConnectorType
                crossbar.get_CrossbarPinInfo(True, i, Nothing, phytype)
                inNames(i) = phytype.ToString
            Next
            For i As Integer = 0 To outPinCount - 1
                Dim phytype As PhysicalConnectorType
                crossbar.get_CrossbarPinInfo(False, i, Nothing, phytype)
                outNames(i) = phytype.ToString
            Next

            PortChooser.clearPorts()

            Dim possiblePorts(outPinCount - 1)() As Integer
            For i As Integer = 0 To outPinCount - 1
                For q As Integer = 0 To inPinCount - 1
                    If crossbar.CanRoute(i, q) = 0 Then
                        If possiblePorts(i) Is Nothing Then
                            ReDim possiblePorts(i)(0)
                        Else
                            ReDim Preserve possiblePorts(i)(possiblePorts(i).Length)
                        End If
                        possiblePorts(i)(possiblePorts(i).Length - 1) = q
                    End If
                Next
                If Not possiblePorts(i) Is Nothing Then
                    Dim possiblePortNames(possiblePorts(i).Length - 1) As String
                    For q As Integer = 0 To possiblePorts(i).Length - 1
                        possiblePortNames(q) = inNames(possiblePorts(i)(q))
                    Next
                    PortChooser.addPort(outNames(i), possiblePortNames)
                End If
            Next

            PortChooser.ShowDialog()

            For i As Integer = 0 To PortChooser.result.Length - 1
                hr = crossbar.Route(i, possiblePorts(i)(PortChooser.result(i)))
            Next

        Finally
            If (Not crossbar Is Nothing) Then
                Marshal.ReleaseComObject(crossbar)
                crossbar = Nothing
            End If
        End Try
    End Sub
End Class
