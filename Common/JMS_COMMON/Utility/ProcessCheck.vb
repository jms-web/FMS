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

    ' アプリケーション固定名
    Private Shared strAppConstName As String = My.Application.Info.AssemblyName

    ' 二重起動を防止するミューテックス
    Private Shared objMutex As Mutex

    Public Shared Function FunCheckDupProcess() As Boolean
        Try


            ' Windows 2000（NT 5.0）以降のみグローバル・ミューテックス利用可
            Dim os As OperatingSystem = Environment.OSVersion

            'If ((os.Platform = PlatformID.Win32NT) And (os.Version.Major >= 5)) Then
            '    strAppConstName = "Global\" + strAppConstName
            'End If

            Try
                ' ミューテックスを生成する
                objMutex = New Mutex(False, strAppConstName)
            Catch e As ApplicationException
                ' グローバル・ミューテックスの多重起動防止
                MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止")
                Application.Exit()
                Return False
            End Try

            ' ミューテックスを生成する
            objMutex = New Mutex(False, strAppConstName)

            ' ミューテックスを取得する
            If (objMutex.WaitOne(0, False)) Then
                ' アプリケーションを実行
                Return True

                ' ミューテックスを解放する
                objMutex.ReleaseMutex()
            Else


                ' 実行中の同じアプリケーションのウィンドウ・ハンドルの取得
                Dim prevProcess As Process = GetPreviousProcess()
                'Dim prevProcess As Process = GetProcessesByWindowTitle("品質情報システム")(0)

                If prevProcess Is Nothing = False AndAlso IntPtr.op_Inequality(prevProcess.MainWindowHandle, IntPtr.Zero) Then
                    ' 起動中のアプリケーションを最前面に表示
                    WakeupWindow(prevProcess.MainWindowHandle)

                    'Microsoft.VisualBasic.Interaction.AppActivate(prevProcess.Id)
                Else
                    ' 警告を表示
                    MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止")
                    Return False
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        Finally
            ' ミューテックスを破棄する
            objMutex.Close()
        End Try
    End Function

    ' 外部プロセスのウィンドウを起動する
    Public Shared Sub WakeupWindow(ByVal hWnd As IntPtr)
        ' メイン・ウィンドウが最小化されていれば元に戻す
        If NativeMethods.IsIconic(hWnd) Then
            NativeMethods.ShowWindowAsync(hWnd, SW_RESTORE)
        End If

        ' メイン・ウィンドウを最前面に表示する
        'SetForegroundWindow(hWnd)
        'BringWindowToTop(hWnd)
        ActiveWindow(hWnd)
    End Sub

    ' ShowWindowAsync関数のパラメータに渡す定義値
    Private Const SW_RESTORE As Integer = 9 ' 画面を元の大きさに戻す

    ' 実行中の同じアプリケーションのプロセスを取得する
    Public Shared Function GetPreviousProcess() As Process
        Try

            Dim curProcess As Process = Process.GetCurrentProcess()
            Dim allProcesses() As Process = Process.GetProcessesByName(curProcess.ProcessName)

            Dim checkProcess As Process
            For Each checkProcess In allProcesses
                ' 自分自身のプロセスIDは無視する
                If checkProcess.Id <> curProcess.Id Then
                    ' プロセスのフルパス名を比較して同じアプリケーションか検証
                    If String.Compare(
                            checkProcess.MainModule.FileName,
                            curProcess.MainModule.FileName, True) = 0 Then
                        ' 同じフルパス名のプロセスを取得
                        Return checkProcess
                    End If
                End If
            Next

            ' 同じアプリケーションのプロセスが見つからない！  
            Return Nothing

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 指定された文字列を含むウィンドウタイトルを持つプロセスを取得します。
    ''' </summary>
    ''' <param name="windowTitle">ウィンドウタイトルに含む文字列。</param>
    ''' <returns>該当するプロセスの配列。</returns>
    Public Shared Function GetProcessesByWindowTitle(windowTitle As String) As System.Diagnostics.Process()
        Dim list As New System.Collections.ArrayList()

        'すべてのプロセスを列挙する
        Dim p As System.Diagnostics.Process
        For Each p In System.Diagnostics.Process.GetProcesses()
            '指定された文字列がメインウィンドウのタイトルに含まれているか調べる
            If 0 <= p.MainWindowTitle.IndexOf(windowTitle) Then
                '含まれていたら、コレクションに追加
                list.Add(p)
            End If
        Next

        'コレクションを配列にして返す
        Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)),
            System.Diagnostics.Process())
    End Function


#Region "activewindow"
    'Imports System.Runtime.InteropServices

    ''' <summary>
    ''' できるだけ確実に指定したウィンドウをフォアグラウンドにする
    ''' </summary>
    ''' <param name="hWnd">ウィンドウハンドル</param>
    Public Shared Sub ActiveWindow(hWnd As IntPtr)
        If hWnd = IntPtr.Zero Then
            Return
        End If

        'ウィンドウが最小化されている場合は元に戻す
        If NativeMethods.IsIconic(hWnd) Then
            NativeMethods.ShowWindowAsync(hWnd, SW_RESTORE)
        End If

        'AttachThreadInputの準備
        'フォアグラウンドウィンドウのハンドルを取得
        Dim forehWnd As IntPtr = NativeMethods.GetForegroundWindow()
        If forehWnd = hWnd Then
            Return
        End If
        'フォアグラウンドのスレッドIDを取得
        Dim foreThread As UInteger =
            NativeMethods.GetWindowThreadProcessId(forehWnd, IntPtr.Zero)
        '自分のスレッドIDを収得
        Dim thisThread As UInteger = NativeMethods.GetCurrentThreadId()

        Dim timeout As UInteger = 200000
        If foreThread <> thisThread Then
            'ForegroundLockTimeoutの現在の設定を取得
            'Visual Studio 2010, 2012起動後は、レジストリと違う値を返す
            NativeMethods.SystemParametersInfoGet(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0)
            'レジストリから取得する場合
            'timeout = CUInt(Microsoft.Win32.Registry.GetValue( _
            '        "HKEY_CURRENT_USER\Control Panel\Desktop", _
            '        "ForegroundLockTimeout", 200000))

            'ForegroundLockTimeoutの値を0にする
            '(SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)を使いたいが、
            '  timeoutがレジストリと違う値だと戻せなくなるので使わない
            NativeMethods.SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0)

            '入力処理機構にアタッチする
            NativeMethods.AttachThreadInput(thisThread, foreThread, True)
        End If

        'ウィンドウをフォアグラウンドにする処理
        NativeMethods.SetForegroundWindow(hWnd)
        NativeMethods.SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0,
            SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW Or SWP_ASYNCWINDOWPOS)
        NativeMethods.BringWindowToTop(hWnd)
        NativeMethods.ShowWindowAsync(hWnd, SW_SHOW)
        NativeMethods.SetFocus(hWnd)

        If foreThread <> thisThread Then
            'ForegroundLockTimeoutの値を元に戻す
            'ここでも(SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)は使わない
            NativeMethods.SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0)

            'デタッチ
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

