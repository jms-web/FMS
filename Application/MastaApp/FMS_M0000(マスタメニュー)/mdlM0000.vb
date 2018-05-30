Imports JMS_COMMON.ClsPubMethod

Module mdlM0000

    ' JumpListオブジェクトを生成する
    Public jumpList = New System.Windows.Shell.JumpList()

    'メニュー用設定フアイル名
    Public Const CON_MENUINI_FILENAME As String = "MENU.INI"
    Public Const CON_TXT_UPDATE_HISTORY As String = "RIREKI.TXT"

    'タイトル名
    Public pub_MenuTitle As String

    'メニューボタン
    Public Structure CMDS_TYPE
        Public Title As String      'プログラムタイトル
        Public Path As String       '実行ファイルのパス
    End Structure
    Public arrCMDS_FUNC(11) As CMDS_TYPE        'ファンクション

    'SUBメニューボタン
    Public Structure SUB_CMDS_TYPE
        Public Category As String       'カテゴリー名
        Public MenuTitle As String       'メニュータイトル
        Public Cmds() As CMDS_TYPE

        Public Sub Initialize()
            Cmds = New CMDS_TYPE(11) {}
        End Sub
    End Structure
    Public arrCMDS_SUBFUNC(11) As SUB_CMDS_TYPE    'サブファンクション
    Public intCMDS_SUBFUNC As Integer          'サブファンクション件数

    'メールリンク関連
    Public pubLinkEXE As String
    Public pubLinkSyainID As String
    Public pubLinkParams As String


#Region "MAIN"
    <STAThread()>
    Public Sub Main()
        Try
            '-----二重起動抑制
            Using objMutex = New System.Threading.Mutex(False, My.Application.Info.AssemblyName)
                If objMutex.WaitOne(0, False) = False Then
                    'MsgBox("既に起動されています", MsgBoxStyle.Information, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----共通初期処理
                If FunINTSYR() = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                    Exit Sub
                End If

                '-----PG設定ファイル読込処理
                If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                    Exit Sub
                End If

                arrCMDS_SUBFUNC(0).Category = ""

                '-----メニュー設定ファイル読込
                If Fun_GetMenuIniFile("MAIN", 0) = False Then
                    WL.WriteLogDat("プログラムを終了します(メニュー設定ファイル読込処理失敗)")
                    Exit Sub
                End If

                '-----Visualスタイル有効
                'Application.EnableVisualStyles()
                '-----GDIを使用
                Application.SetCompatibleTextRenderingDefault(False)

                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "MENU_SECTION", tblMenuSection)
                End Using

                '-----確認画面表示
                'INIから先回のログインユーザー取得
                Dim strBUFF As String
                Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                    strBUFF = iniIF.GetIniString("SYSTEM", "USERID")
                End Using

                'UNDONE: パラメータ取得 メールリンク経由でのPG起動用 ユーザーIDとPG_PATH およびそのPGのパラメータを受け取る
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 4 Then
                    'メールリンク用 
                    pubLinkSyainID = cmds(1)
                    pubLinkEXE = cmds(2)
                    pubLinkParams = cmds(3)
                End If

                '前回ログインユーザーが空欄の場合=バージョンアップ後初回起動時
                If strBUFF.Trim = "" Then
                    Using frmDLG As New FrmM0010
                        frmDLG.ShowDialog()
                    End Using
                End If

                'ジャンプリスト
                Call FunCreateJumpList()

                '-----一覧画面表示
                Dim frmLIST As New FrmM0000
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

#Region "メニュー設定ファイルより定義データを取得"
    Public Function Fun_GetMenuIniFile(ByVal strSECTION_NAME As String, ByVal intIndex As Integer) As Boolean
        Dim strWork As String
        Dim lngL As Integer
        Dim strPath As String
        Try
            strPath = FunGetRootPath() & "\INI\" & CON_MENUINI_FILENAME

            Using iniIF As New IniFile(strPath)
                If strSECTION_NAME = "MAIN" Then
                    'タイトル
                    pub_MenuTitle = iniIF.GetIniString(strSECTION_NAME, "TITLE").ToString

                    'ファンクション
                    For lngL = 0 To 11
                        '初期化
                        arrCMDS_FUNC(lngL).Title = ""
                        arrCMDS_FUNC(lngL).Path = ""

                        strWork = Right("00" & CStr(lngL + 1), 2)

                        '処理名
                        arrCMDS_FUNC(lngL).Title = iniIF.GetIniString(strSECTION_NAME, "TITLE" & strWork)

                        'パス
                        arrCMDS_FUNC(lngL).Path = iniIF.GetIniString(strSECTION_NAME, "PATH" & strWork)
                    Next lngL
                Else
                    'タイトル
                    pub_MenuTitle = iniIF.GetIniString(intIndex, "TITLE").ToString.Replace("[SECTION_NAME]", strSECTION_NAME)

                    'ファンクション
                    For lngL = 0 To 11
                        '初期化
                        arrCMDS_FUNC(lngL).Title = ""
                        arrCMDS_FUNC(lngL).Path = ""

                        strWork = Right("00" & CStr(lngL + 1), 2)

                        '処理名
                        arrCMDS_FUNC(lngL).Title = iniIF.GetIniString(intIndex, "TITLE" & strWork)

                        'パス
                        arrCMDS_FUNC(lngL).Path = iniIF.GetIniString(intIndex, "PATH" & strWork)


                        If arrCMDS_FUNC(lngL).Path.Length < 2 Then 'サブファンクション無し時
                            '次データへ
                            Continue For
                        End If

                        'サブファンクションの読取
                        If arrCMDS_FUNC(lngL).Path.Substring(0, 1) = "[" AndAlso
                           arrCMDS_FUNC(lngL).Path.Substring(arrCMDS_FUNC(lngL).Path.Length - 1, 1) = "]" Then
                            Fun_GetMenuIniFileSub(strSECTION_NAME, arrCMDS_FUNC(lngL).Path)
                        End If

                    Next lngL
                End If
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try

    End Function

    'メニュー設定ファイルよりサブメニュー定義データを取得
    Public Function Fun_GetMenuIniFileSub(ByVal strSECTION_NAME As String, ByVal SectionIndex As String) As Boolean
        Dim lngL As Long
        Dim strWork As String
        Dim strWkCat As String
        Dim intNum As Integer

        Dim strPath As String
        Try
            strPath = FunGetRootPath() & "\INI\" & CON_MENUINI_FILENAME

            Using iniIF As New IniFile(strPath)
                '[MAIN]なら登録しない
                If UCase(SectionIndex) = "[MAIN]" Then Return True

                '既に登録されていたら抜ける
                strWkCat = SectionIndex.Substring(1, SectionIndex.Length - 2)    '"[]" 抜き
                For lngL = 1 To intCMDS_SUBFUNC
                    If strWkCat = arrCMDS_SUBFUNC(lngL).Category Then Return True
                Next lngL

                '[～]を記憶ですか
                intCMDS_SUBFUNC = intCMDS_SUBFUNC + 1
                ReDim Preserve arrCMDS_SUBFUNC(intCMDS_SUBFUNC)
                arrCMDS_SUBFUNC(intCMDS_SUBFUNC).Initialize()

                arrCMDS_SUBFUNC(intCMDS_SUBFUNC).Category = strWkCat
                intNum = intCMDS_SUBFUNC

                'メニュータイトル
                arrCMDS_SUBFUNC(intNum).MenuTitle = iniIF.GetIniString(strWkCat, "TITLE").Replace("[SECTION_NAME]", strSECTION_NAME)

                'ファンクション
                For lngL = 0 To 11
                    '初期化
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Title = ""
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path = ""

                    strWork = Right("00" & CStr(lngL + 1), 2)

                    '処理名
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Title = iniIF.GetIniString(strWkCat, "TITLE" & strWork)

                    'パス
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path = iniIF.GetIniString(strWkCat, "PATH" & strWork)

                    If arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Length < 2 Then 'サブファンクション無し時
                        '次データへ
                        Continue For
                    End If

                    'サブファンクションの読取
                    If arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Substring(0, 1) = "[" AndAlso
                       arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Substring(arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Length - 1, 1) = "]" Then
                        Fun_GetMenuIniFileSub(strSECTION_NAME, arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path)
                    End If
                Next lngL
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally

        End Try
    End Function

#End Region

#Region "ジャンプリスト作成"
    Private Function FunCreateJumpList() As Boolean

        ' JumpTaskオブジェクトを生成し、JumpListオブジェクトに格納する
        Dim jumpTask1 = New System.Windows.Shell.JumpTask() With {
                  .CustomCategory = "業務",
                  .Title = "タスク1",
                  .Description = "run task1",
                  .Arguments = "/msg=task1args"
                }
        jumpList.JumpItems.Add(jumpTask1)
        ' JumpTaskオブジェクトを生成し、JumpListオブジェクトに格納する
        Dim jumpTask2 = New System.Windows.Shell.JumpTask() With {
                  .CustomCategory = "業務",
                  .Title = "タスク2",
                  .Description = "run task2",
                  .Arguments = "/msg=task2args"
                }
        jumpList.JumpItems.Add(jumpTask2)
        ' JumpTaskオブジェクトを生成し、JumpListオブジェクトに格納する
        Dim currentDirectory As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim jumpTask3 = New System.Windows.Shell.JumpTask() With
        {
          .Title = "ReadMeを読む",
          .Description = "ReadMeを開きます。",
          .ApplicationPath = "%SystemRoot%\System32\notepad.exe",
          .IconResourcePath = "%SystemRoot%\System32\notepad.exe",
          .WorkingDirectory = currentDirectory,
          .Arguments = currentDirectory & "\ReadMe.txt"
        }
        jumpList.JumpItems.Add(jumpTask3)

        ' Applyメソッドを呼び出して、Windowsに通知する
        jumpList.Apply()

        Dim msgArgment As String = Environment.GetCommandLineArgs().Where(Function(arg) arg.ToUpperInvariant().StartsWith("/msg=")).FirstOrDefault()

        Return True
    End Function

#End Region

End Module