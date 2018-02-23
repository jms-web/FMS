Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Partial Friend NotInheritable Class NativeMethods

    <DllImport("user32.dll")>
    Friend Shared Function IsIconic(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    <DllImport("user32.dll")>
    Friend Shared Function ShowWindowAsync(hWnd As IntPtr, nCmdShow As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function GetWindowThreadProcessId(hWnd As IntPtr,
    ProcessId As IntPtr) As UInteger
    End Function

    <DllImport("kernel32.dll")>
    Friend Shared Function GetCurrentThreadId() As UInteger
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function AttachThreadInput(
    idAttach As UInteger, idAttachTo As UInteger, fAttach As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="SystemParametersInfo",
        SetLastError:=True)>
    Friend Shared Function SystemParametersInfoGet(action As UInteger,
    param As UInteger, ByRef vparam As UInteger, init As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="SystemParametersInfo",
        SetLastError:=True)>
    Friend Shared Function SystemParametersInfoSet(action As UInteger,
    param As UInteger, vparam As UInteger, init As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function SetForegroundWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Friend Shared Function BringWindowToTop(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll")>
    Friend Shared Function SetFocus(hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Friend Shared Function SetWindowPos(hWnd As IntPtr,
    hWndInsertAfter As Integer, x As Integer, y As Integer, cx As Integer, cy As Integer,
    uFlags As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

End Class


Public Class ProcessCheck

    ' �A�v���P�[�V�����Œ薼
    Private Shared strAppConstName As String = My.Application.Info.AssemblyName

    ' ��d�N����h�~����~���[�e�b�N�X
    Private Shared objMutex As Mutex

    Public Shared Function FunCheckDupProcess() As Boolean
        Try


            ' Windows 2000�iNT 5.0�j�ȍ~�̂݃O���[�o���E�~���[�e�b�N�X���p��
            Dim os As OperatingSystem = Environment.OSVersion

            'If ((os.Platform = PlatformID.Win32NT) And (os.Version.Major >= 5)) Then
            '    strAppConstName = "Global\" + strAppConstName
            'End If

            Try
                ' �~���[�e�b�N�X�𐶐�����
                objMutex = New Mutex(False, strAppConstName)
            Catch e As ApplicationException
                ' �O���[�o���E�~���[�e�b�N�X�̑��d�N���h�~
                MessageBox.Show("���łɋN�����Ă��܂��B2�����ɂ͋N���ł��܂���B", "���d�N���֎~")
                Application.Exit()
                Return False
            End Try

            ' �~���[�e�b�N�X�𐶐�����
            objMutex = New Mutex(False, strAppConstName)

            ' �~���[�e�b�N�X���擾����
            If (objMutex.WaitOne(0, False)) Then
                ' �A�v���P�[�V���������s
                Return True

                ' �~���[�e�b�N�X���������
                objMutex.ReleaseMutex()
            Else


                ' ���s���̓����A�v���P�[�V�����̃E�B���h�E�E�n���h���̎擾
                Dim prevProcess As Process = GetPreviousProcess()
                'Dim prevProcess As Process = GetProcessesByWindowTitle("�i�����V�X�e��")(0)

                If prevProcess Is Nothing = False AndAlso IntPtr.op_Inequality(prevProcess.MainWindowHandle, IntPtr.Zero) Then
                    ' �N�����̃A�v���P�[�V�������őO�ʂɕ\��
                    WakeupWindow(prevProcess.MainWindowHandle)

                    'Microsoft.VisualBasic.Interaction.AppActivate(prevProcess.Id)
                Else
                    ' �x����\��
                    MessageBox.Show("���łɋN�����Ă��܂��B2�����ɂ͋N���ł��܂���B", "���d�N���֎~")
                    Return False
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        Finally
            ' �~���[�e�b�N�X��j������
            objMutex.Close()
        End Try
    End Function

    ' �O���v���Z�X�̃E�B���h�E���N������
    Public Shared Sub WakeupWindow(ByVal hWnd As IntPtr)
        ' ���C���E�E�B���h�E���ŏ�������Ă���Ό��ɖ߂�
        If NativeMethods.IsIconic(hWnd) Then
            NativeMethods.ShowWindowAsync(hWnd, SW_RESTORE)
        End If

        ' ���C���E�E�B���h�E���őO�ʂɕ\������
        'SetForegroundWindow(hWnd)
        'BringWindowToTop(hWnd)
        ActiveWindow(hWnd)
    End Sub

    ' ShowWindowAsync�֐��̃p�����[�^�ɓn����`�l
    Private Const SW_RESTORE As Integer = 9 ' ��ʂ����̑傫���ɖ߂�

    ' ���s���̓����A�v���P�[�V�����̃v���Z�X���擾����
    Public Shared Function GetPreviousProcess() As Process
        Try

            Dim curProcess As Process = Process.GetCurrentProcess()
            Dim allProcesses() As Process = Process.GetProcessesByName(curProcess.ProcessName)

            Dim checkProcess As Process
            For Each checkProcess In allProcesses
                ' �������g�̃v���Z�XID�͖�������
                If checkProcess.Id <> curProcess.Id Then
                    ' �v���Z�X�̃t���p�X�����r���ē����A�v���P�[�V����������
                    If String.Compare(
                            checkProcess.MainModule.FileName,
                            curProcess.MainModule.FileName, True) = 0 Then
                        ' �����t���p�X���̃v���Z�X���擾
                        Return checkProcess
                    End If
                End If
            Next

            ' �����A�v���P�[�V�����̃v���Z�X��������Ȃ��I  
            Return Nothing

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' �w�肳�ꂽ��������܂ރE�B���h�E�^�C�g�������v���Z�X���擾���܂��B
    ''' </summary>
    ''' <param name="windowTitle">�E�B���h�E�^�C�g���Ɋ܂ޕ�����B</param>
    ''' <returns>�Y������v���Z�X�̔z��B</returns>
    Public Shared Function GetProcessesByWindowTitle(windowTitle As String) As System.Diagnostics.Process()
        Dim list As New System.Collections.ArrayList()

        '���ׂẴv���Z�X��񋓂���
        Dim p As System.Diagnostics.Process
        For Each p In System.Diagnostics.Process.GetProcesses()
            '�w�肳�ꂽ�����񂪃��C���E�B���h�E�̃^�C�g���Ɋ܂܂�Ă��邩���ׂ�
            If 0 <= p.MainWindowTitle.IndexOf(windowTitle) Then
                '�܂܂�Ă�����A�R���N�V�����ɒǉ�
                list.Add(p)
            End If
        Next

        '�R���N�V������z��ɂ��ĕԂ�
        Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)),
            System.Diagnostics.Process())
    End Function


#Region "activewindow"
    'Imports System.Runtime.InteropServices

    ''' <summary>
    ''' �ł��邾���m���Ɏw�肵���E�B���h�E���t�H�A�O���E���h�ɂ���
    ''' </summary>
    ''' <param name="hWnd">�E�B���h�E�n���h��</param>
    Public Shared Sub ActiveWindow(hWnd As IntPtr)
        If hWnd = IntPtr.Zero Then
            Return
        End If

        '�E�B���h�E���ŏ�������Ă���ꍇ�͌��ɖ߂�
        If NativeMethods.IsIconic(hWnd) Then
            NativeMethods.ShowWindowAsync(hWnd, SW_RESTORE)
        End If

        'AttachThreadInput�̏���
        '�t�H�A�O���E���h�E�B���h�E�̃n���h�����擾
        Dim forehWnd As IntPtr = NativeMethods.GetForegroundWindow()
        If forehWnd = hWnd Then
            Return
        End If
        '�t�H�A�O���E���h�̃X���b�hID���擾
        Dim foreThread As UInteger =
            NativeMethods.GetWindowThreadProcessId(forehWnd, IntPtr.Zero)
        '�����̃X���b�hID������
        Dim thisThread As UInteger = NativeMethods.GetCurrentThreadId()

        Dim timeout As UInteger = 200000
        If foreThread <> thisThread Then
            'ForegroundLockTimeout�̌��݂̐ݒ���擾
            'Visual Studio 2010, 2012�N����́A���W�X�g���ƈႤ�l��Ԃ�
            NativeMethods.SystemParametersInfoGet(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0)
            '���W�X�g������擾����ꍇ
            'timeout = CUInt(Microsoft.Win32.Registry.GetValue( _
            '        "HKEY_CURRENT_USER\Control Panel\Desktop", _
            '        "ForegroundLockTimeout", 200000))

            'ForegroundLockTimeout�̒l��0�ɂ���
            '(SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)���g���������A
            '  timeout�����W�X�g���ƈႤ�l���Ɩ߂��Ȃ��Ȃ�̂Ŏg��Ȃ�
            NativeMethods.SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0)

            '���͏����@�\�ɃA�^�b�`����
            NativeMethods.AttachThreadInput(thisThread, foreThread, True)
        End If

        '�E�B���h�E���t�H�A�O���E���h�ɂ��鏈��
        NativeMethods.SetForegroundWindow(hWnd)
        NativeMethods.SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0,
            SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW Or SWP_ASYNCWINDOWPOS)
        NativeMethods.BringWindowToTop(hWnd)
        NativeMethods.ShowWindowAsync(hWnd, SW_SHOW)
        NativeMethods.SetFocus(hWnd)

        If foreThread <> thisThread Then
            'ForegroundLockTimeout�̒l�����ɖ߂�
            '�����ł�(SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)�͎g��Ȃ�
            NativeMethods.SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0)

            '�f�^�b�`
            NativeMethods.AttachThreadInput(thisThread, foreThread, False)
        End If
    End Sub

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2
    Private Const SWP_NOZORDER As Integer = &H4
    Private Const SWP_SHOWWINDOW As Integer = &H40
    Private Const SWP_ASYNCWINDOWPOS As Integer = &H4000
    Private Const HWND_TOP As Integer = 0
    Private Const HWND_BOTTOM As Integer = 1
    Private Const HWND_TOPMOST As Integer = -1
    Private Const HWND_NOTOPMOST As Integer = -2

    Private Const SW_SHOWNORMAL As Integer = 1
    Private Const SW_SHOW As Integer = 5
    'Private Const SW_RESTORE As Integer = 9

    Private Const SPI_GETFOREGROUNDLOCKTIMEOUT As UInteger = &H2000
    Private Const SPI_SETFOREGROUNDLOCKTIMEOUT As UInteger = &H2001
    Private Const SPIF_UPDATEINIFILE As UInteger = &H1
    Private Const SPIF_SENDCHANGE As UInteger = &H2

#End Region


End Class

