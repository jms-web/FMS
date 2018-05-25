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
        Dim strFILEPATHNEW As String

        Try
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
                ElseIf System.IO.File.GetLastWriteTime(CON_ROOTDIR & "\INI\" & strBUFF) < System.IO.File.GetLastWriteTime(".\INI\" & strBUFF) Then
                    '旧ファイル削除
                    System.IO.File.Delete(CON_ROOTDIR & "\INI\" & strBUFF)
                    'コピー
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


            '-----メニュー起動
            Shell(CON_ROOTDIR & "\" & EXE_PATH & "\" & CON_STARTUP_EXE, AppWinStyle.NormalFocus)



        Catch ex As Exception
            'コピー失敗時
            MsgBox("起動中のシステムを全て終了後、再度システムを開始して下さい。(" & strBUFF & ")" & vbCrLf & ex.Message, MsgBoxStyle.Information)
        End Try


    End Sub

End Module
