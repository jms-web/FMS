Imports System.Collections.Generic
Imports JMS_COMMON.ClsPubMethod

Module mdlINTSYR

#Region "定数・変数"

    'ログ
    Public EM As ErrMsg
    Public WL As WriteLog

    'ソリューション識別名
    Public Const CON_SOLUTION_NAME As String = "FMS"

    '設定フアイル名
    Public Const CON_SYSTEM_INI As String = "SYSTEM.INI"
    Public Const CON_OUTPUT_INI As String = "EXCELOUT.INI"
    Public Const CON_TEMPLATE_INI As String = "EXCELTEMPLATE.INI"
    Public Const CON_ERR_LOG As String = CON_SOLUTION_NAME & "_ERROR.LOG"

    Public Const WM_CUT As Integer = &H300
    Public Const WM_COPY As Integer = &H301
    Public Const WM_PASTE As Integer = &H302
    Public Const WM_CONTEXTMENU As Integer = &H7B

    Public pub_SYSTEM_INI_FILE As String

    Public clrControlGotFocusedColor As Color = Color.FromArgb(190, 180, 255) 'フォーカス時の背景色
    Public clrDisableControlGotFocusedColor As Color = SystemColors.Control
    Public clrControlDefaultBackColor As Color = Color.White  'フォーカス喪失時時の背景色
    Public clrControlErrorBackColor As Color = Color.FromArgb(255, 255, 128)  'エラー時の背景色


    '詳細エラーを常に表示
    Public conblnNonMsg As Boolean = False



    ''' <summary>
    ''' システム情報
    ''' </summary>
    Public pub_SYSTEM_INFO As SYSTEM_INFO
    Public Structure SYSTEM_INFO
        ''' <summary>
        ''' 端末名
        ''' </summary>
        Dim strPCNM As String

        ''' <summary>
        ''' 接続文字列
        ''' </summary>
        Dim CONNECTIONSTRING As String

        ''' <summary>
        ''' データベースプロバイダー
        ''' </summary>
        Dim DbProviderFactories As String

        ''' <summary>
        ''' 規定の検索結果最大件数
        ''' </summary>
        Dim SerchMax As Integer

        ''' <summary>
        ''' 規定のフォーム背景色
        ''' </summary>
        Dim clrDefaultFormBack As Color

        ''' <summary>
        ''' 規定のタイトルラベル背景色
        ''' </summary>
        Dim clrDefaultTitleBack As Color


        ''' <summary>
        ''' エラーメール送信の対象エラーレベル
        ''' </summary>
        Dim SendMailErrorLevel As Integer


    End Structure

    ''' <summary>
    ''' ユーザー情報
    ''' </summary>
    Public pub_SYAIN_INFO As SYAIN_INFO
    Public Structure SYAIN_INFO
        ''' <summary>
        ''' 社員ID(システム上のID)
        ''' </summary>
        Dim SYAIN_ID As Integer

        ''' <summary>
        ''' 社員CD(職番)
        ''' </summary>
        Dim SYAIN_CD As String

        ''' <summary>
        ''' 社員名
        ''' </summary>
        Dim SYAIN_NAME As String

        ''' <summary>
        ''' パスワード
        ''' </summary>
        Dim PASSWORD As String

        ''' <summary>
        ''' 権限
        ''' </summary>
        Dim KENGEN_KB As String

        ''' <summary>
        ''' 部門区分
        ''' </summary>
        Dim BUMON_KB As String

        ''' <summary>
        ''' 部門名
        ''' </summary>
        Dim BUMON_NAME As String
    End Structure

    ''' <summary>
    ''' プログラム情報
    ''' </summary>
    Public pub_APP_INFO As APP_INFO
    Public Structure APP_INFO
        ''' <summary>
        ''' タイトル(処理名)
        ''' </summary>
        Dim strTitle As String

        ''' <summary>
        ''' 検索結果最大件数
        ''' </summary>
        Dim intSEARCHMAX As Integer

        ''' <summary>
        ''' フォーム背景色
        ''' </summary>
        Dim clrFORM_BACK As Color

        ''' <summary>
        ''' タイトルラベル背景色
        ''' </summary>
        Dim clrTITLE_LABEL As Color

        ''' <summary>
        ''' データ出力先
        ''' </summary>
        Dim strOUTPUT_PATH As String

    End Structure


    ''' <summary>
    ''' エラー種別
    ''' </summary>
    Public Enum ENM_ERR_KB As Integer
        _9_その他例外エラー = 9
    End Enum

    Public Enum ENM_KENGEN_KB As Integer
        _0_権限なし = 0
        _1_参照権限 = 1
        _2_更新権限 = 2
        _9_システム権限 = 9
    End Enum

    Public Enum ENM_BUMON_KB As Integer
        _1_風防 = 1
        _2_LP = 2
        _3_複合材 = 3
        _8_業務管理 = 8
        _9_経営部 = 9
    End Enum


    ''' <summary>
    ''' データ処理モード
    ''' </summary>
    Public Enum ENM_DATA_OPERATION_MODE
        ''' <summary>
        ''' 追加
        ''' </summary>
        _1_ADD = 1

        ''' <summary>
        ''' 参照追加
        ''' </summary>
        _2_ADDREF = 2

        ''' <summary>
        ''' 更新
        ''' </summary>
        _3_UPDATE = 3

        ''' <summary>
        ''' 非表示(論理削除)
        ''' </summary>
        _4_DISABLE = 4

        ''' <summary>
        ''' 復元
        ''' </summary>
        _5_RESTORE = 5

        ''' <summary>
        ''' 削除(物理削除)
        ''' </summary>
        _6_DELETE = 6
    End Enum

#End Region

#Region "初期処理"
    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <returns>0=正常終了　1=異常終了</returns>
    ''' <remarks></remarks>
    Public Function FunINTSYR() As Boolean
        Dim cmds() As String

        Try
            '-----ログ準備
            EM = New ErrMsg(CON_ERR_LOG)
            WL = New WriteLog()

            '-----システム設定ファイル読込

            If Fun_GetSystemIniFile() = False Then
                Return False
            End If


            '-----端末名取得
            pub_SYSTEM_INFO.strPCNM = System.Net.Dns.GetHostName

            '---引数取得
            cmds = System.Environment.GetCommandLineArgs

            '担当コード
            If cmds.Length >= 2 Then
                Dim tplBUFF As (BUMON_KB As String, BUMON_NAME As String) = FunGetBUMON_INFO(cmds(1))

                pub_SYAIN_INFO = New SYAIN_INFO With {
                .SYAIN_ID = cmds(1),
                .SYAIN_CD = Fun_GetSYAIN_NO(cmds(1)),
                .SYAIN_NAME = Fun_GetUSER_NAME(cmds(1)),
                .BUMON_KB = tplBUFF.BUMON_KB,
                .BUMON_NAME = tplBUFF.BUMON_NAME
                }
                'pub_USER_INFO.KENGEN_KB = Fun_GetUSER_KENGEN(pub_USER_INFO.USER_ID)

                Return True
            Else
                Select Case My.Application.Info.AssemblyName
                    Case "FMS_M0000", "FMS_U0010"
                        Return True
                    Case Else
                        WL.WriteLogDat("ログインユーザーコードが取得出来ませんでした。")
                        MessageBox.Show("ログインユーザーコードが取得出来ませんでした。" & vbCrLf & "プログラムを終了します。", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                End Select
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "システム設定ファイル読込処理"
    Public Function Fun_GetSystemIniFile() As Boolean

        Try
            'INIファイルパスの取得
            pub_SYSTEM_INI_FILE = FunGetRootPath() & "\INI\" & CON_SYSTEM_INI
            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                'DB接続設定
                pub_SYSTEM_INFO.CONNECTIONSTRING = iniIF.GetIniString("DB", "CONNECTIONSTRING")
                pub_SYSTEM_INFO.DbProviderFactories = iniIF.GetIniString("DB", "DbProviderFactories")
            End Using

            Using DB As ClsDbUtility = DBOpen()
                '共通設定
                pub_SYSTEM_INFO.SerchMax = FunGetCodeMastaValue(DB, "SYSTEM_SETTING", "SERACHMAX")
                pub_SYSTEM_INFO.clrDefaultFormBack = ColorTranslator.FromHtml(FunGetCodeMastaValue(DB, "COLOR_SETTING", "FormBackColor"))
                pub_SYSTEM_INFO.clrDefaultTitleBack = ColorTranslator.FromHtml(FunGetCodeMastaValue(DB, "COLOR_SETTING", "TitleLabelColor"))
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "出力先設定ファイル読込"
    ''' <summary>
    ''' 出力先設定ファイル読込
    ''' </summary>
    ''' <returns></returns>
    Public Function FunGetOutputIniFile() As Boolean

        Try

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_OUTPUT_INI)
                '出力先
                pub_APP_INFO.strOUTPUT_PATH = FunConvPathString(iniIF.GetIniString(My.Application.Info.AssemblyName, "OUT_FOLDER"))

                If pub_APP_INFO.strOUTPUT_PATH.IsNullOrEmpty Then
                    pub_APP_INFO.strOUTPUT_PATH = FunConvPathString(iniIF.GetIniString("DEFAULT", "OUT_FOLDER"))
                End If
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        End Try
    End Function
#End Region

#Region "PG設定ファイル読込処理"
    ''' <summary>
    ''' PG設定ファイル読込処理
    ''' </summary>
    ''' <param name="strFileName">INIファイル名</param>
    ''' <returns></returns>
    <Diagnostics.DebuggerStepThrough()>
    Public Function FunGetPGIniFile(ByVal strFileName As String) As Boolean
        Dim strINIFile As String
        Try

            strINIFile = FunGetRootPath() & "\INI\" & strFileName & ".INI"
            'PG固有INIファイルが存在しない場合は、システム共通INIファイルから設定値を取得
            If System.IO.File.Exists(strINIFile) = False Then
                strINIFile = FunGetRootPath() & "\INI\" & CON_SYSTEM_INI
            End If

            'PG設定値取得
            With pub_APP_INFO

                Using DB As ClsDbUtility = DBOpen()
                    '    'タイトル
                    .strTitle = FunGetCodeMastaValue(DB, "PG_TITLE", strFileName)
                End Using

                Using iniIF As New IniFile(strINIFile)
                    '検索結果最大件数
                    If Val(iniIF.GetIniString("SYSTEM", "SEARCHMAX")) > 0 Then
                        .intSEARCHMAX = Val(iniIF.GetIniString("SYSTEM", "SEARCHMAX"))
                    Else
                        'SYSTEM.INIのデフォルト設定を使用
                        .intSEARCHMAX = pub_SYSTEM_INFO.SerchMax
                    End If

                    'フォーム背景色
                    If iniIF.GetIniString("SYSTEM", "FORMBACK_R").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "FORMBACK_G").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "FORMBACK_B").IsNulOrWS Then
                        'SYSTEM.INIのデフォルト設定を使用
                        .clrFORM_BACK = pub_SYSTEM_INFO.clrDefaultFormBack
                    Else
                        .clrFORM_BACK = Color.FromArgb(Val(iniIF.GetIniString("SYSTEM", "FORMBACK_R")), Val(iniIF.GetIniString("SYSTEM", "FORMBACK_G")), Val(iniIF.GetIniString("SYSTEM", "FORMBACK_B")))
                    End If

                    'タイトルラベル
                    If iniIF.GetIniString("SYSTEM", "TITLELABEL_R").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "TITLELABEL_G").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "TITLELABEL_B").IsNulOrWS Then
                        'SYSTEM.INIのデフォルト設定を使用
                        .clrTITLE_LABEL = pub_SYSTEM_INFO.clrDefaultTitleBack
                    Else
                        .clrTITLE_LABEL = Color.FromArgb(Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_R")), Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_G")), Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_B")))
                    End If
                End Using
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "エラーログテーブル出力およびメール送信"
    Public Function FunErrorSyori(ByVal strErrKB As String, ByVal strErrLevel As String, ByVal strMSG As String, Optional ByVal strBIKO As String = "", Optional ByVal ErrLogList As List(Of String) = Nothing) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim dtNow As DateTime
        'Dim blnRET As Boolean
        Dim strSubject As String
        Dim sbMessage As New System.Text.StringBuilder
        Dim sendFile As New List(Of String)

        Dim strErrLevel_NM As String
        Dim strErrKB_NM As String
        Dim blnSendFLG As Boolean
        Dim blnAttachmentFLG As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()

                'システム日時取得
                dtNow = DateTime.Now 'FunGetSysDate(DB)

                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("INSERT INTO RTB_ERRLOG(SYR_YMDHNS, PC_NM, ERR_KB, ERR_LEVEL, MSG, BIKO) VALUES (")
                sbSQL.Append(" '" & dtNow.ToString("yyyyMMddHHmmss") & "',") '処理日時
                sbSQL.Append(" '" & pub_SYSTEM_INFO.strPCNM & "',") 'PC名
                sbSQL.Append(" '" & strErrKB & "',") 'エラー区分
                sbSQL.Append(" '" & strErrLevel & "',") 'エラーレベル
                sbSQL.Append(" '" & strMSG & "',") 'メッセージ
                sbSQL.Append(" '" & strBIKO & "')") '備考

                'SQL実行
                intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)


                If pub_SYSTEM_INFO.SendMailErrorLevel = 0 Then
                    '送信しない
                    blnSendFLG = False
                Else
                    If pub_SYSTEM_INFO.SendMailErrorLevel <= Val(strErrLevel) Then
                        'エラーメール送信対象エラーレベル以上のエラーのみメール送信する 設定が=1…重要エラーのみの場合、エラーレベル2…通知レベルのエラーはメール送信しない
                        blnSendFLG = True
                    Else
                        strErrLevel = "False"
                    End If
                End If

                'メール送信実行
                If blnSendFLG = True Then
                    '添付ファイル有無
                    blnAttachmentFLG = CBool(Val(FunGetCodeMastaValue(DB, "MAIL_SETTING", "FILE_ATTACHMENT")))
                    'エラーレベル名
                    strErrLevel_NM = FunGetCodeMastaValue(DB, "ERROR_LEVEL", strErrLevel)
                    'エラー区分名
                    strErrKB_NM = FunGetCodeMastaValue(DB, "ERROR_KB", strErrKB)


                    If blnAttachmentFLG = True And ErrLogList IsNot Nothing Then
                        '添付ファイルリストを設定
                        sendFile = ErrLogList
                    End If

                    '件名作成
                    strSubject = "【EDI受信システムエラー発生】" & strErrKB_NM


                    If strErrKB = ENM_ERR_KB._9_その他例外エラー.ToString Then
                        If ErrLogList Is Nothing Then
                            '例外エラー発生時で特定のログファイルがセットされていない場合は、システムエラーログファイルをリストに追加する
                            ErrLogList = New List(Of String) From {FunGetRootPath() & "\LOG\" & CON_ERR_LOG}
                        End If
                        sendFile = ErrLogList
                    End If

                    '本文作成
                    sbMessage.Remove(0, sbMessage.Length)
                    sbMessage.Append("発生日時　　：" & dtNow.ToString("yyyy年MM月dd日 HH時mm分ss秒") & vbCrLf)
                    sbMessage.Append("障害レベル　：" & strErrLevel & " " & strErrLevel_NM & vbCrLf)
                    sbMessage.Append("エラー区分　：" & strErrKB & " " & strErrKB_NM & vbCrLf)
                    If sendFile.Count > 0 Then
                        sbMessage.Append("添付ファイル：あり" & vbCrLf)
                    Else
                        sbMessage.Append("添付ファイル：なし" & vbCrLf)
                    End If
                    sbMessage.Append(vbCrLf)
                    sbMessage.Append("<エラー内容>" & vbCrLf)
                    sbMessage.Append(strMSG & vbCrLf)
                    sbMessage.Append(vbCrLf)
                    sbMessage.Append("<詳細情報>" & vbCrLf)
                    sbMessage.Append(Nz(strBIKO, "なし") & vbCrLf)

                    'メール送信
                    'Call FunSendErrorMail(DB, strSubject, sbMessage.ToString, sendFile)
                End If
            End Using

            Return True
        Catch ex As Exception
            'EM.ErrorSyori(ex, False, True)
            Return False
        Finally


        End Try
    End Function
#End Region

#Region "ユーザー名取得"

    Public Function Fun_GetUSER_NAME(ByVal SYAIN_ID As Integer) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try


            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT SIMEI FROM " & "M004_SYAIN" & " ")
                sbSQL.Append(" WHERE SYAIN_ID =" & SYAIN_ID & " ")
                dsList = DB.GetDataSet(sbSQL.ToString)
                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        Return .Rows(0).Item(0).ToString.Trim
                    Else
                        'エラー
                        'Throw New ArgumentOutOfRangeException
                        Return ""
                    End If
                End With
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#Region "社員NO取得"

    Public Function Fun_GetSYAIN_NO(ByVal SYAIN_ID As Integer) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try


            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT SYAIN_NO FROM " & "M004_SYAIN" & " ")
                sbSQL.Append(" WHERE SYAIN_ID =" & SYAIN_ID & " ")
                dsList = DB.GetDataSet(sbSQL.ToString)
                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        Return .Rows(0).Item(0).ToString.Trim
                    Else
                        'エラー
                        'Throw New ArgumentOutOfRangeException
                        Return ""
                    End If
                End With
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#Region "ユーザー権限取得"
    Public Function Fun_GetUSER_KENGEN(ByVal SYAIN_ID As String) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            'SQL
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * FROM " & "M03_TANTO" & " ")
            sbSQL.Append(" WHERE SYAIN_ID ='" & SYAIN_ID & "' ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            With dsList.Tables(0).Rows(0)
                Return .Item("KENGEN_KB").ToString.Trim
            End With

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        Finally
            '-----開放
            dsList.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' システム管理者権限取得
    ''' </summary>
    ''' <param name="SYAIN_ID"></param>
    ''' <returns></returns>
    Public Function IsSysAdminUser(SYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Try

            sbSQL.Append("SELECT ADMIN_SYS FROM " & "M004_SYAIN" & " ")
            sbSQL.Append($" WHERE SYAIN_ID ={SYAIN_ID}")
            Using DB As ClsDbUtility = DBOpen()
                strRET = DB.ExecuteScalar(sbSQL.ToString)
            End Using

            Return (strRET = "1")

        Catch ex As Exception
            EM.ErrorSyori(ex, False)
            Return False

        End Try
    End Function

    ''' <summary>
    ''' 運用管理者権限取得
    ''' </summary>
    ''' <param name="SYAIN_ID"></param>
    ''' <returns></returns>
    Public Function IsOPAdminUser(SYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Try

            sbSQL.Append("SELECT ADMIN_OP FROM " & "M004_SYAIN" & " ")
            sbSQL.Append($" WHERE SYAIN_ID ={SYAIN_ID}")
            Using DB As ClsDbUtility = DBOpen()
                strRET = DB.ExecuteScalar(sbSQL.ToString)
            End Using

            Return (strRET = "1")

        Catch ex As Exception
            EM.ErrorSyori(ex, False)
            Return False

        End Try
    End Function

#End Region

#Region "管理者権限確認"

    Public Function HasAdminAuth(ByVal intSYAIN_ID As Integer) As Boolean
        'Dim sbSQL As New System.Text.StringBuilder
        'Dim dsList As New DataSet

        'sbSQL.Remove(0, sbSQL.Length)
        'sbSQL.Append("SELECT")
        'sbSQL.Append(" *")
        'sbSQL.Append(" FROM VWM001_SETTING ")
        'sbSQL.Append(" WHERE ITEM_NAME='管理者権限'")
        'sbSQL.Append(" AND ITEM_DISP='" & intSYAIN_ID & "'")
        'Using DB As ClsDbUtility = DBOpen()
        '    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        'End Using

        'If dsList.Tables(0).Rows.Count > 0 Then
        '    Return True
        'Else
        '    Return False
        'End If

        Return IsOPAdminUser(intSYAIN_ID)

    End Function
#End Region

#Region "DB操作関連"
    Public Function DBOpen() As ClsDbUtility
        If pub_SYSTEM_INFO.DbProviderFactories.IsNulOrWS And pub_SYSTEM_INFO.CONNECTIONSTRING.IsNulOrWS Then
            Return Nothing
        Else
            Dim DB As New ClsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
            Return DB
        End If
    End Function

#End Region

End Module
