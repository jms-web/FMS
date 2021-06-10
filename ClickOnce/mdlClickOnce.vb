Imports System.Diagnostics
Imports System.Reflection

Module mdlClickOnce
    Private Const CON_ROOTDIR As String = "C:\FMS"
    Private Const CON_STARTUP_EXE As String = "FMS_M0000.exe"

#If DEBUG Then
    Private Const EXE_PATH As String = "EXE_DEBUG"
#Else
    Private Const EXE_PATH As String = "EXE"
#End If

    Public Sub MAIN()
        Dim intCNT As Integer
        Dim strBUFF As String = String.Empty
        Dim files() As String
        'Dim strSTARTMENU_FILE As String
        'Dim strDESKTOP_FOLDER As String
        'Dim strSTARTUP_FOLDER As String

        'Dim asbAssembly As Assembly
        'Dim AssemblyVersionValue As Version
        'Dim hVerInfo As System.Diagnostics.FileVersionInfo
        'Dim strFILEVersionORG As String
        'Dim strFILEVersionNEW As String

        Try
            Dim strParams As String = GetUriParameters()

#If DEBUG = False Then
            Dim strFILEPATHNEW As String

            ''-----Appliation Refarenceをデスクトップにコピー
            ''.appref-ms取得
            'strSTARTMENU_FILE = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
            'strSTARTMENU_FILE = strSTARTMENU_FILE & "\プログラム\三品松菱\生産管理システム.appref-ms"

            ''コピー先のデスクトップ取得
            'strDESKTOP_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            ''同名ファイル無し時
            'If System.IO.File.Exists(strDESKTOP_FOLDER & "\生産管理システム.appref-ms") = False Then
            '    '既存のゴミファイル削除
            '    For Each FileName As String In System.IO.Directory.GetFiles(strDESKTOP_FOLDER, "生産管理システム*.appref-ms")
            '        System.IO.File.Delete(FileName)
            '    Next

            '    '.appref-msをデスクトップへコピー
            '    System.IO.File.Copy(strSTARTMENU_FILE, strDESKTOP_FOLDER & "\生産管理システム.appref-ms")
            'End If

            ''-----VBSをスタートアップに登録(Appliation Refarenceをデスクトップにコピー)
            ''スタートアップフォルダ取得
            'strSTARTUP_FOLDER = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup)
            ''同名ファイル無し時
            'If System.IO.File.Exists(strSTARTUP_FOLDER & "\STARTUP.VBS") = False Then
            '    'VBSをスタートアップへコピー
            '    System.IO.File.Copy(".\EXE\STARTUP.VBS", strSTARTUP_FOLDER & "\STARTUP.VBS")
            'End If

            '-----EXE
            'フォルダ作成
            System.IO.Directory.CreateDirectory(CON_ROOTDIR & "\" & EXE_PATH)

            'ファイル一覧作成
            files = System.IO.Directory.GetFiles(".\" & EXE_PATH, "*", IO.SearchOption.TopDirectoryOnly)

            'ファイルコピー
            For intCNT = 0 To files.Length - 1
                'ファイル名取得
                strBUFF = System.IO.Path.GetFileName(files(intCNT))

                'ファイル名(フルパス)取得
                strFILEPATHNEW = System.IO.Path.GetFullPath(files(intCNT))

                '同名ファイル無し時
                If System.IO.File.Exists(CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF) = False Then
                    'コピー
                    System.IO.File.Copy(".\" & EXE_PATH & "\" & strBUFF, CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF)

                    '日時が古すぎ時
                ElseIf System.IO.File.GetLastWriteTime(CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF) < System.IO.File.GetLastWriteTime(".\" & EXE_PATH & "\" & strBUFF) Then
                    If strBUFF.Contains(".exe") = True Or strBUFF.Contains(".EXE") = True Then
                        '''''''''''''パス'c:\ADCM\exe\mbcj010juchu.exe'へのアクセスが拒否されました。
                        ''新ファイルVERSION取得
                        'hVerInfo = (System.Diagnostics.FileVersionInfo.GetVersionInfo(strFILEPATHNEW))
                        'strFILEVersionNEW = hVerInfo.FileMajorPart & "." & _
                        '                    hVerInfo.FileMinorPart & "." & _
                        '                    hVerInfo.FileBuildPart & "." & _
                        '                    hVerInfo.FilePrivatePart

                        ''旧ファイルVERSION取得
                        'hVerInfo = (System.Diagnostics.FileVersionInfo.GetVersionInfo("C:\ADCM\EXE\" & strBUFF))
                        'strFILEVersionORG = hVerInfo.FileMajorPart & "." & _
                        '                    hVerInfo.FileMinorPart & "." & _
                        '                    hVerInfo.FileBuildPart & "." & _
                        '                    hVerInfo.FilePrivatePart

                        ''新旧ファイルでVERSION違い時
                        'If strFILEVersionNEW <> strFILEVersionORG Then
                        '    '旧ファイル削除
                        '    System.IO.File.Delete("C:\ADCM\EXE\" & strBUFF)
                        '    'コピー
                        '    System.IO.File.Copy(".\EXE\" & strBUFF, "C:\ADCM\EXE\" & strBUFF)
                        'End If

                        '旧ファイル削除
                        System.IO.File.Delete(CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF)
                        'コピー
                        System.IO.File.Copy(".\" & EXE_PATH & "\" & strBUFF, CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF)

                    ElseIf strBUFF.Contains(".exe") = False And strBUFF.Contains(".EXE") = False Then
                        '旧ファイル削除
                        System.IO.File.Delete(CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF)
                        'コピー
                        System.IO.File.Copy(".\" & EXE_PATH & "\" & strBUFF, CON_ROOTDIR & "\" & EXE_PATH & "\" & strBUFF)
                    End If

                End If
            Next

            '-----INI
            'フォルダ作成
            System.IO.Directory.CreateDirectory(CON_ROOTDIR & "\INI")

            'ファイル一覧作成
            files = System.IO.Directory.GetFiles(".\INI", "*", IO.SearchOption.TopDirectoryOnly)

            'ファイルコピー
            For intCNT = 0 To files.Length - 1
                'ファイル名(フルパス)取得
                strBUFF = System.IO.Path.GetFileName(files(intCNT))

                '同名ファイル無し時
                If System.IO.File.Exists(CON_ROOTDIR & "\INI\" & strBUFF) = False Then
                    'コピー
                    System.IO.File.Copy(".\INI\" & strBUFF, CON_ROOTDIR & "\INI\" & strBUFF)

                    'ElseIf strBUFF.ToUpper = "HANYO.INI" Then

                    '日時が古すぎ時
                ElseIf System.IO.File.GetLastWriteTime(CON_ROOTDIR & "\INI\" & strBUFF) < System.IO.File.GetLastWriteTime(".\INI\" & strBUFF) _
                    And Not strBUFF.Contains("SYSTEM.INI") Then
                    '    '旧ファイル削除
                    System.IO.File.Delete(CON_ROOTDIR & "\INI\" & strBUFF)
                    '    'コピー
                    System.IO.File.Copy(".\INI\" & strBUFF, CON_ROOTDIR & "\INI\" & strBUFF)
                End If
            Next

            '-----TEMPLATE
            'フォルダ作成
            System.IO.Directory.CreateDirectory(CON_ROOTDIR & "\TEMPLATE")

            'ファイル一覧作成
            files = System.IO.Directory.GetFiles(".\TEMPLATE", "*", IO.SearchOption.TopDirectoryOnly)

            'ファイルコピー
            For intCNT = 0 To files.Length - 1
                'ファイル名(フルパス)取得
                strBUFF = System.IO.Path.GetFileName(files(intCNT))

                '同名ファイル無し時
                If System.IO.File.Exists(CON_ROOTDIR & "\TEMPLATE\" & strBUFF) = False Then
                    'コピー
                    System.IO.File.Copy(".\TEMPLATE\" & strBUFF, CON_ROOTDIR & "\TEMPLATE\" & strBUFF)

                    'ElseIf strBUFF.ToUpper = "HANYO.INI" Then

                    '日時が古すぎ時
                ElseIf System.IO.File.GetLastWriteTime(CON_ROOTDIR & "\TEMPLATE\" & strBUFF) < System.IO.File.GetLastWriteTime(".\TEMPLATE\" & strBUFF) Then
                    '旧ファイル削除
                    System.IO.File.Delete(CON_ROOTDIR & "\TEMPLATE\" & strBUFF)
                    'コピー
                    System.IO.File.Copy(".\TEMPLATE\" & strBUFF, CON_ROOTDIR & "\TEMPLATE\" & strBUFF)
                End If
            Next

            ''-----フォントインストールVBS起動
            'Shell("C:\ADCM\EXE\FONTINSTALL.VBS", AppWinStyle.NormalFocus)

            ''---サーバ移転用
            ''System.IO.File.Copy(".\INI" & "\フジワラシステム_インストール", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) & "\フジワラシステム_インストール")
            'Dim strMsg As String
            'strMsg = "サーバーの入れ替えに伴いプログラムの再インストールが必要です" & vbCrLf &
            '          "既存の「フジワラシステム」をアンインストールした上で、" & vbCrLf &
            '          "下記の配信アドレスにアクセスして更新プログラムをインストールして下さい" & vbCrLf & vbCrLf &
            '          "http://SV04:8000/"

            'MessageBox.Show(strMsg, "システム更新のお願い")
            ''---

#End If

            '-----メニュー起動
            If Not String.IsNullOrWhiteSpace(strParams) Then
                Shell(CON_ROOTDIR & "\" & EXE_PATH & "\" & strParams, AppWinStyle.NormalFocus)
            Else
                Shell(CON_ROOTDIR & "\" & EXE_PATH & "\" & CON_STARTUP_EXE, AppWinStyle.NormalFocus)
            End If
        Catch ex As Exception
            'コピー失敗時
            MsgBox("起動中のシステムを全て終了後、再度システムを開始して下さい。(" & strBUFF & ")" & vbCrLf & ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Function GetUriParameters() As String
        Try
            Dim url As String

#If DEBUG Then
            url = "http://sv91:8000/CLICKONCE_FMS.application?SYAIN_ID=999999&EXEPATH=FMS_G0010.exe&PARAMS=999999,2,1,20181180"
#Else
            ' ClickOnceアプリの場合のときのみ以下のコードを実行
            If Deployment.Application.ApplicationDeployment.IsNetworkDeployed = False Then
                Return ""
            End If

            ' 起動URLを取得
            url = Deployment.Application.ApplicationDeployment.CurrentDeployment.ActivationUri.AbsoluteUri
#End If

            ' クエリ部分を抽出
            Dim myUri As Uri = New Uri(url)
            Dim queryString As String = myUri.Query
            If String.IsNullOrEmpty(queryString) Then
                Return vbNullString
            End If

            ' 各パラメータを分離して抽出
            Dim SYAIN_ID As Integer
            Dim PG_PATH As String = ""
            Dim PARAMS As String = ""
            Dim nameValuePairs() As String = queryString.Split("&"c)
            For Each pair As String In nameValuePairs
                Dim vars() As String = pair.Split("="c)
                If vars.Length <> 2 Then
                    Continue For
                End If
                vars(0) = vars(0).Replace("?", "")  ' “?”は削る

                Select Case vars(0)
                    Case "SYAIN_ID"
                        SYAIN_ID = CInt(Web.HttpUtility.UrlDecode(vars(1)))
                    Case "EXEPATH"
                        PG_PATH = Web.HttpUtility.UrlDecode(vars(1))
                    Case "PARAMS"
                        Dim strList As List(Of String) = Web.HttpUtility.UrlDecode(vars(1)).Split(",").ToList
                        For Each param As String In strList
                            PARAMS &= param & Space(1)
                        Next
                End Select
            Next pair

            Return PG_PATH & Space(1) & PARAMS
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Module