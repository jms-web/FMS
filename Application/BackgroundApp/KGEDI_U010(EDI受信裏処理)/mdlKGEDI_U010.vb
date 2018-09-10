Imports KGEDI_COMMON.clsPubMethod

Module mdlKGEDI_U010

#Region "変数・定数"

    ''' <summary>
    ''' 画面参照
    ''' </summary>
    Public pub_frmMain As frmKGEDI_U010

    ''' <summary>
    ''' PG設定値
    ''' </summary>
    Public Structure PG_INFO
        ''' <summary>
        ''' タイトル(処理名)
        ''' </summary>
        Dim strTitle As String

     
        'Dim strEDICOM_Path As String

        ''' <summary>
        ''' 共通EDI XML・CSV変換ツールパス
        ''' </summary>
        Dim strEDIXMLConverter_Path As String

        ''' <summary>
        ''' 受信ファイルバックアップパス
        ''' </summary>
        Dim strBackup_Path As String

        ''' <summary>
        ''' 再受信ファイルバックアップパス
        ''' </summary>
        Dim strReRecv_Path As String

        ''' <summary>
        ''' 出力エラーファイル格納パス
        ''' </summary>
        Dim strOUTPUT_NG_File_Path As String

        ''' <summary>
        ''' 再出力実行ファイル格納パス
        ''' </summary>
        Dim strRE_OUTPUT_Exec_Path As String

        ''' <summary>
        ''' バックアップ・再受信ファイルのCSVファイルフォーマット
        ''' </summary>
        Dim intCSVFILE_FORMAT As Integer

        ''' <summary>
        ''' ファイル受信チェック処理間隔(分)
        ''' </summary>
        Dim intFileRecvCheckInterval As Integer

        ''' <summary>
        ''' ファイル取込チェック処理間隔(分)
        ''' </summary>
        Dim intFileImportCheckInterval As Integer

        ''' <summary>
        ''' ファイル作成チェック処理間隔(秒)
        ''' </summary>
        Dim intFileMakeCheckInterval As Integer

    End Structure
    Public pub_PGINFO As PG_INFO

    ''' <summary>
    ''' ファイル情報
    ''' </summary>
    Public Structure FILE_INFO
        ''' <summary>
        ''' ファイル名
        ''' </summary>
        Dim strFileName As String

        ''' <summary>
        ''' ファイル種別
        ''' </summary>
        Dim strFileType As String

        ''' <summary>
        ''' フィールド幅の配列
        ''' </summary>
        Dim intFieldWidths As Integer()

        ''' <summary>
        ''' フィールド名の配列
        ''' </summary>
        Dim strFieldNames As String()

        ''' <summary>
        ''' フィールド数
        ''' </summary>
        Dim intFieldCount As String

        ''' <summary>
        ''' テーブル名
        ''' </summary>
        Dim strTableName As String

        ''' <summary>
        ''' 再受信フラグ
        ''' </summary>
        Dim blnReRecvFLG As Boolean
    End Structure

    ''' <summary>
    ''' ファイルフォーマット
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ENM_FILE_FORMAT As Integer
        _1_固定長 = 1
        _2_CSV_見出し無_クォーテーション無 = 2
        _3_CSV_見出し無_クォーテーション有 = 3
        _4_CSV_見出し有_クォーテーション無 = 4
        _5_CSV_見出し有_クォーテーション有 = 5
        _6_SP_ストアドプロシージャ実行 = 6
    End Enum
#End Region

#Region "Main"

    ''' <summary>
    ''' 起動時処理
    ''' </summary>
    <STAThread()>
    Public Sub Main()
        Dim blnResult As Boolean
        Dim intRET As Integer
        'Dim tblBUFF As New DataTableEx

        Try
            '-----多重起動禁止
            Dim security As New System.Security.AccessControl.MutexSecurity
            '端末内で1プロセスのみ起動可のルールを追加
            Dim rule As System.Security.AccessControl.MutexAccessRule = New System.Security.AccessControl.MutexAccessRule( _
                                          New System.Security.Principal.SecurityIdentifier( _
                                          System.Security.Principal.WellKnownSidType.WorldSid, Nothing), _
                                          System.Security.AccessControl.MutexRights.Synchronize + System.Security.AccessControl.MutexRights.Modify, _
                                          System.Security.AccessControl.AccessControlType.Allow)
            security.AddAccessRule(rule)

            Using mutex As System.Threading.Mutex = New System.Threading.Mutex(True, "Global\" + My.Application.Info.AssemblyName, blnResult, security)
                If mutex.WaitOne(0, False) = False Then
                    '既にプロセスが起動している場合は、新規プロセスを終了する
                    Exit Sub
                Else
                    'プロセスが存在しない場合は、新規プロセスの処理を継続する
                    Application.EnableVisualStyles()
                    Application.SetCompatibleTextRenderingDefault(False)

                    '-----共通初期処理
                    intRET = funINTSYR()
                    If intRET <> 0 Then
                        WL.WriteLogDat("起動時エラー プログラムを終了します(共通初期処理)") '動作ログを出力
                        Exit Sub
                    End If

                    '-----PG設定ファイル読込処理
                    If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                        WL.WriteLogDat("起動時エラー プログラムを終了します(PG設定ファイル読込処理)") '動作ログを出力
                        Exit Sub
                    End If

                    '-----画面表示
                    pub_frmMain = New frmKGEDI_U010
                    Application.Run(pub_frmMain)
                    mutex.ReleaseMutex()
                End If
            End Using

        Catch unAuthEx As UnauthorizedAccessException
            'UAC不許可時は終了する
            Exit Sub
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            WL.WriteLogDat("例外エラー発生 処理を終了します")
            Dim strMsg As String = "プログラム初期処理に失敗しました。" & vbCrLf & "処理を終了します。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]")
        End Try
    End Sub
#End Region

#Region "PG設定ファイル読込処理"
    ''' <summary>
    ''' PG設定ファイル読込処理
    ''' </summary>
    ''' <param name="strFileName">INIファイル名</param>
    ''' <returns></returns>
    Public Function FunGetPGIniFile(ByVal strFileName As String) As Boolean
        Dim iniIF As IniFile = Nothing

        Try
            pub_INI_FILE = FunGetRootPath()
            pub_INI_FILE = pub_INI_FILE & "\INI\" & strFileName & ".INI"
            iniIF = New IniFile(pub_INI_FILE)

            'PG設定値取得
            With pub_PGINFO
                'タイトル
                .strTitle = iniIF.GetIniString("SYSTEM", "TITLE")

                'XML・固定長(CSV)変換ツールフォルダ
                .strEDIXMLConverter_Path = FunConvPathString(iniIF.GetIniString("SYSTEM", "EDIXMLCONVERTER_PATH"))

                'バックアップフォルダ
                .strBackup_Path = FunConvPathString(iniIF.GetIniString("SYSTEM", "BACKUP_PATH"))

                '再受信ファイル出力フォルダ
                .strReRecv_Path = FunConvPathString(iniIF.GetIniString("SYSTEM", "RE_RECV_PATH"))

                'バックアップ・再受信ファイルフォーマット
                .intCSVFILE_FORMAT = FunConvPathString(iniIF.GetIniString("SYSTEM", "CSVFILE_FORMAT"))

                '出力エラーファイル格納パス
                .strOUTPUT_NG_File_Path = FunConvPathString(iniIF.GetIniString("SYSTEM", "OUTPUT_NG_PATH"))

                '再出力実行ファイル格納パス
                .strRE_OUTPUT_Exec_Path = FunConvPathString(iniIF.GetIniString("SYSTEM", "RE_OUTPUT_EXEC_PATH"))

                'ファイル受信処理監視間隔(秒)
                .intFileRecvCheckInterval = Val(iniIF.GetIniString("SYSTEM", "FILE_RECV_CHECK_INTERVAL"))

                'ファイル取込処理監視間隔(秒)
                .intFileImportCheckInterval = Val(iniIF.GetIniString("SYSTEM", "FILE_IMPORT_CHECK_INTERVAL"))

                'ファイル作成処理監視間隔(秒)
                .intFileMakeCheckInterval = Val(iniIF.GetIniString("SYSTEM", "FILE_MAKE_CHECK_INTERVAL"))

                '設定値チェック
                If FunPGINICheck(pub_PGINFO) = False Then
                    Return False
                End If
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "システム設定値・PG設定値の取得に失敗しました。" & vbCrLf & "処理を終了します。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]")
            Return False
        Finally
            If iniIF IsNot Nothing Then
                iniIF.Close()
            End If
        End Try
    End Function

    '設定値チェック
    Private Function FunPGINICheck(ByVal PGINFO As PG_INFO) As Boolean
        Dim strMsg As String
        Dim strDetail As String = ""

        Try
            With PGINFO

                If .strEDIXMLConverter_Path = "" Then
                    strDetail &= "XML・固定長変換ツールのパスの取得に失敗しました。" & vbCrLf
                End If

                If .strBackup_Path = "" Then
                    strDetail &= "バックアップパスの取得に失敗しました。" & vbCrLf
                End If

                If .strReRecv_Path = "" Then
                    strDetail &= "再受信ファイル出力パスの取得に失敗しました。" & vbCrLf
                End If

                If .intCSVFILE_FORMAT = 0 Then
                    strDetail &= "出力ファイルフォーマットの取得に失敗しました。" & vbCrLf
                End If

                If .strOUTPUT_NG_File_Path = "" Then
                    strDetail &= "出力エラーファイル格納パスの取得に失敗しました。" & vbCrLf
                End If

                If .strRE_OUTPUT_Exec_Path = "" Then
                    strDetail &= "再出力実行ファイル格納パスの取得に失敗しました。" & vbCrLf
                End If

                If .intFileRecvCheckInterval = 0 Then
                    strDetail &= "ファイル受信処理監視間隔(秒)の取得に失敗しました。" & vbCrLf
                End If

                If .intFileMakeCheckInterval = 0 Then
                    strDetail &= "ファイル取込処理監視間隔(秒)の取得に失敗しました。" & vbCrLf
                End If

                If .intFileImportCheckInterval = 0 Then
                    strDetail &= "ファイル作成処理監視間隔(秒)の取得に失敗しました。" & vbCrLf
                End If

            End With

            If strDetail <> "" Then
                strMsg = "システム設定値・PG設定値の取得に失敗しました。" & vbCrLf & "処理を終了します。"
                FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, strDetail)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#End Region

#Region "DB接続チェック"
    ''' <summary>
    ''' DB接続チェック
    ''' </summary>
    ''' <param name="DB">接続DB</param>
    ''' <returns></returns>
    Public Function FunCheckDBConnect(ByVal DB As clsDbUtility) As Boolean

        Try
            If DB IsNot Nothing Then
                For intCNT As Integer = 1 To conDBCONNECT_RETRY_COUNT
                    If DB.ConnectCheck() = True Then
                        '接続成功
                        Exit For
                    End If

                    If intCNT = conDBCONNECT_RETRY_COUNT Then
                        '接続失敗のため終了
                        Return False
                    End If

                    '待機
                    System.Threading.Thread.Sleep(conDBCONNECT_RETRY_TERM * 1000)
                Next intCNT

                Return True
            Else
                Return False
            End If

        Catch exAccess As AccessViolationException
            Return False
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "DB接続に失敗しました。" & vbCrLf & "設定ファイル:" & FunGetRootPath() & "\INI\" & conSYSTEM_INI_FILENAME & "やDB接続状況を確認して下さい。"
            Dim list As New List(Of String)
            list.Add(FunGetRootPath() & "\INI\" & conSYSTEM_INI_FILENAME)
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "", list)
            Return False
        End Try
    End Function

#End Region


End Module
