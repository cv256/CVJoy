Imports System.Runtime.InteropServices

''' <summary>
''' I built this class so that this application, even when not with the focus, can have access to a mouse RAW data.
''' If you use regular techniques you tipically get access to the mouse only when your window has the focus; and the mouse data you get has been changed by windows (what they call Balistics, like exponential speed and getting the mouse closer to buttons); and the mouse coordinates are limited to the size of your screen.
''' So, on your application initialization call Register(Me.Handle), and on your Sub WndProc if msg=WM_INPUT call GetMove(m.LParam) and you get all you ever wanted
''' </summary>
Public Class MouseRaw


    <StructLayout(LayoutKind.Sequential)>
    Private Structure RAWINPUTDEVICELIST
        Public hDevice As Int32
        Public dwType As UInt32
    End Structure
    <DllImport("user32.dll", EntryPoint:="GetRawInputDeviceList", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function GetRawInputDeviceList(ByVal pRawInputDeviceList As IntPtr, ByRef puiNumDevices As Int32, ByVal cbSize As Int32) As Int32
    End Function

    'Private Enum DeviceInfoTypes As UInteger
    '    RIDI_PREPARSEDDATA = &H20000005
    '    RIDI_DEVICENAME = &H20000007
    '    RIDI_DEVICEINFO = &H2000000B
    'End Enum
    '<DllImport("user32.dll", EntryPoint:="GetRawInputDeviceInfoW", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    'Private Shared Function GetRawInputDeviceInfo(ByVal hDevice As IntPtr, ByVal uiCommand As DeviceInfoTypes, ByVal pData As String, ByRef pcbSize As UInteger) As Int32
    'End Function

    ''' <summary>
    ''' returns the hDevice of each mouse present on the computer now
    ''' </summary>
    Public Shared Function GetMouses() As List(Of Int32)
        Dim result As New List(Of Int32)
        Dim structSize As Int32 = Marshal.SizeOf(GetType(RAWINPUTDEVICELIST))
        Dim bufferCount As Int32 = 16
        Dim buffer As IntPtr = Marshal.AllocHGlobal(bufferCount * structSize)
        Dim count As UInt32 = GetRawInputDeviceList(buffer, bufferCount, structSize)
        For i As UInt32 = 0 To count - 1
            Dim device As RAWINPUTDEVICELIST = Marshal.PtrToStructure(New IntPtr((buffer.ToInt32() + (structSize * i))), GetType(RAWINPUTDEVICELIST))
            If device.dwType <> 0 Then Continue For '  MOUSE = 0, KEYBOARD = 1, HID = 2
            result.Add(device.hDevice)
            'Dim deviceName As String = New String(" "c, 200)
            'GetRawInputDeviceInfo(device.hDevice, DeviceInfoTypes.RIDI_DEVICENAME, deviceName, deviceName.Length)
            'Debug.Print("device " & i & "  =  " & deviceName)
        Next
        Marshal.FreeHGlobal(buffer)
        Return result
    End Function





    <Flags()>
    Private Enum RawInputDeviceFlags
        None = 0
        ''' <summary>If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from a device which matches the top level collection.</summary>
        Remove = &H1
        ''' <summary>If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC whose usage page is already specified with PageOnly.</summary>
        Exclude = &H10
        ''' <summary>If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that Usage must be zero. To exclude a particular top level collection, use Exclude.</summary>
        PageOnly = &H20
        ''' <summary>If set, this prevents any devices specified by UsagePage or Usage from generating legacy messages. This is only for the mouse and keyboard.</summary>
        NoLegacy = &H30
        ''' <summary>If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that WindowHandle must be specified.</summary>
        InputSink = &H100
        ''' <summary>If set, the mouse button click does not activate the other window.</summary>
        CaptureMouse = &H200
        ''' <summary>If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. NoHotKeys can be specified even if NoLegacy is not specified and WindowHandle is NULL.</summary>
        NoHotKeys = &H200
        ''' <summary>If set, application keys are handled.  NoLegacy must be specified.  Keyboard only.</summary>
        AppKeys = &H400
    End Enum
    <StructLayout(LayoutKind.Sequential)>
    Private Structure RAWINPUTDEVICE
        Public UsagePage As UShort 'HIDUsagePage = 0x01
        Public Usage As UShort 'HIDUsage = 0x02 ' mouse
        Public Flags As RawInputDeviceFlags ' = InputSink
        Public WindowHandle As IntPtr ' Handle to the target device. If NULL, it follows the keyboard focus
    End Structure
    ''' <summary>Function to register a raw input device.</summary>
    ''' <param name="pRawInputDevices">Array of raw input devices.</param>
    ''' <param name="uiNumDevices">Number of devices.</param>
    ''' <param name="cbSize">Size of the RAWINPUTDEVICE structure.</param>
    ''' <returns>True if successful, False if not.</returns>
    <DllImport("user32.dll", EntryPoint:="RegisterRawInputDevices", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function RegisterRawInputDevices(<MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> ByVal pRawInputDevices As RAWINPUTDEVICE(), ByVal uiNumDevices As Integer, ByVal cbSize As Integer) As Boolean
    End Function

    Public Shared Function Register(pWindowHandle As IntPtr) As Boolean
        Dim Rid(1) As RAWINPUTDEVICE
        Rid(0).UsagePage = 1
        Rid(0).Usage = 2
        Rid(0).Flags = RawInputDeviceFlags.InputSink
        Rid(0).WindowHandle = pWindowHandle
        If Not RegisterRawInputDevices(Rid, 1, Marshal.SizeOf(GetType(RAWINPUTDEVICE))) Then
            Debug.Print("RegisterRawInputDevices FAILED !")
            Return False
        End If
        Return True
    End Function






    <StructLayout(LayoutKind.Explicit)>
    Public Structure RAWMOUSE
        <FieldOffset(0)>
        Public Flags As Int32 ' RawMouseFlags
        <FieldOffset(4)>
        Public ButtonFlags As UShort 'RawMouseButtons
        <FieldOffset(6)>
        Public ButtonData As UShort
        <FieldOffset(8)>
        Public RawButtons As Int32
        <FieldOffset(12)>
        Public LastX As Int32
        <FieldOffset(16)>
        Public LastY As Int32
        <FieldOffset(20)>
        Public ExtraInformation As Int32
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Public Structure RawInputHeader
        ''' <summary>Type of device the input is coming from.</summary>
        Public Type As Int32 'RawInputType
        ''' <summary>Size of the packet of data.</summary>
        Public Size As Integer
        ''' <summary>Handle to the device sending the data.</summary>
        Public Device As IntPtr
        ''' <summary>wParam from the window message.</summary>
        Public wParam As IntPtr
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Public Structure RAWINPUT
        Public header As RawInputHeader
        Public data As RAWMOUSE
    End Structure

    Private Const RID_HEADER = &H10000005
    Private Const RID_INPUT = &H10000003

    <DllImport("user32.dll", EntryPoint:="GetRawInputData", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function GetRawInputData(ByVal hRawInput As IntPtr, uiCommand As Int32, pData As IntPtr, ByRef pcbSize As Int32, cbSizeHeader As Int32) As Int32
    End Function

    Public Shared Function GetMove(lParam) As RAWINPUT
        'Dim dwSize As Int32 
        'GetRawInputData(lParam, RID_INPUT, IntPtr.Zero, dwSize, Marshal.SizeOf(GetType(RawInputHeader)))
        'If dwSize < 1 Then
        '    Debug.Print("GetRawInputData 0 failed")
        '    Return Nothing
        'End If
        'Debug.Print(dwSize) ' checked thhat dwSize was allways 40
        'Dim buffer As IntPtr = Marshal.AllocHGlobal(dwSize)
        Dim dwSize As Int32 = 40
        Dim buffer As IntPtr = Marshal.AllocHGlobal(dwSize)
        If GetRawInputData(lParam, RID_INPUT, Buffer, dwSize, Marshal.SizeOf(GetType(RawInputHeader))) <> dwSize Then
            Debug.Print("GetRawInputData 1 does not return correct size !\n")
        End If
        Dim res As RAWINPUT = Marshal.PtrToStructure(New IntPtr(buffer.ToInt32()), GetType(RAWINPUT))
        Marshal.FreeHGlobal(buffer)
        Return res
    End Function

End Class
