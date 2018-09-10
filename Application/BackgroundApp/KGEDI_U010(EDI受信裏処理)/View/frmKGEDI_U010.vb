Imports KGEDI_COMMON.clsPubMethod

Public Class frmKGEDI_U010

#Region "定数・変数"

    'タイマーオブジェクト    
    Private pri_Thread_MAKE_FILE As System.Threading.Thread
    Private pri_Thread_REMAKE_FILE As System.Threading.Thread

    'データモデル格納コンテキスト
    Private pri_JTB_RECVARG_JO_Entities As New JTB_RECVARG_JO_Entities
    Private pri_JTB_RECVFILE_JO_Entities As New JTB_RECVFILE_JO_Entities
    Private pri_JTB_FILE_ITEMFORMAT_Entities As New JTB_FILE_ITEMFORMAT_Entities
    Private pri_JTB_OUTPUT_ERROR_FILE_Entities As New JTB_OUTPUT_ERROR_FILE_Entities

    '最低受信間隔(分)
    Private pri_intMIN_INTERVAL As Integer

    ''' <summary>
    ''' マルチスレッドファイル受信用デリゲート
    ''' </summary>
    ''' <param name="entity">受信設定データモデル</param>
    ''' <returns>受信バッチログファイルパス</returns>
    Private Delegate Function ThreadMethodDelegate(ByVal entity As JTB_RECVARG_JO_Model) As String

#Region "再受信処理関連"
    ''' <summary>
    ''' 再受信処理 対象ファイルリスト
    ''' </summary>
    Private pri_ReRecvFileList As New List(Of String)

    ''' <summary>
    ''' 再受信処理中 判定フラグ
    ''' </summary>
    Private pri_blnReRecvDownLoading As Boolean

#End Region

#Region "ファイル出力処理関連"
    '出力エラーメールの明細項目リスト構造体
    Private Structure ST_ErrorMailDetailFields
        ''' <summary>
        ''' 出力項目No
        ''' </summary>
        ''' <remarks></remarks>
        Dim No As Integer

        ''' <summary>
        ''' 出力する項目のフィールド名
        ''' </summary>
        Dim field_name As String

        ''' <summary>
        ''' 出力する項目の表示列名
        ''' </summary>
        Dim display_name As String
    End Structure

#End Region

#End Region

#Region "Formイベント"

#Region "FORM_LOAD"
    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DB As clsDbUtility = Nothing

        Try
            '-----起動ログを出力
            WL.WriteLogDat("▼起動▼")

            '-----DB接続
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            '-----DB接続チェック
            If FunCheckDBConnect(DB) = False Then
                Me.Close()
                Exit Sub
            End If

            '最低受信間隔を取得
            pri_intMIN_INTERVAL = Val(FunGetCodeMastaValue(DB, "RECV_SETTING", "MIN_INTERVAL"))
            If pri_intMIN_INTERVAL = 0 Then
                Dim strMsg As String = "EDI最低受信間隔(分)が設定されていません。" & vbCrLf & "コードマスタの設定値を確認して下さい。"
                FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "VALUE:DISP=RECV_SETTING:MIN_INTERVAL ")
                Me.Close()
                Exit Sub
            End If

            'エラーメール送信の対象エラーレベル
            pub_SYSTEM_INFO.SendMailErrorLevel = Val(FunGetCodeMastaValue(DB, "MAIL_SETTING", "SEND_MAIL_ERROR_LEVEL"))

            '-----タイマー間隔設定・開始処理
            If FunSetTIMER_SETTING(blnStartCall:=False) = False Then
                Me.Close()
                Exit Sub
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "起動時初期処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & ErrMsg.FunGetErrMsg(ex))
            Me.Close()
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If
        End Try
    End Sub
#End Region

#Region "FORM_CLOSED"
    Private Sub ENDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENDToolStripMenuItem.Click
        Try
            'UNDONE:出力処理中の場合は、処理終了までプログラムの終了を待機?
            'If pri_Thread_MAKE_FILE.IsAlive = True Then
            '    Exit Sub
            'End If

            'If pri_Thread_REMAKE_FILE.IsAlive = True Then
            '    Exit Sub
            'End If

            Me.Close()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
        End Try
    End Sub

    Private Sub frmClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            '待機
            System.Threading.Thread.Sleep(1000)

            '-----終了ログを出力する
            WL.WriteLogDat("▲終了▲")

            '待機
            System.Threading.Thread.Sleep(1000)

            '-----アイコン削除
            Me.tskIcon.Dispose()


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
        End Try
    End Sub
#End Region

#Region "タイマー間隔設定・開始処理"
    ''' <summary>
    ''' ファイル受信・取込・作成タイマー起動およびタイマー間隔更新
    ''' </summary>
    ''' <param name="blnStartCall">初回起動時フラグ True時のみ各処理を即時実行およびタイマー起動</param>
    ''' <returns>Boolean型 成功・失敗</returns>
    Private Function FunSetTIMER_SETTING(Optional ByVal blnStartCall As Boolean = False) As Boolean

        Try
            ''INIファイル情報を更新
            'If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
            '    Return False
            'End If


            'ファイル受信処理
            With tmrRECV_FILE
                If pub_PGINFO.intFileRecvCheckInterval > 0 Then
                    .Interval = CInt(pub_PGINFO.intFileRecvCheckInterval * 1000)
                    If blnStartCall = True Then
                        tmrRECV_FILE_Tick(Nothing, Nothing)
                    End If
                    .Start()
                Else
                    .Stop()
                End If
            End With

            'ファイル取込処理
            With tmrINPUT_FILE
                If pub_PGINFO.intFileImportCheckInterval > 0 Then
                    .Interval = CInt(pub_PGINFO.intFileImportCheckInterval * 1000)
                    If blnStartCall = True Then
                        Call tmrINPUT_FILE_Tick(Nothing, Nothing)
                    End If
                    .Start()
                Else
                    .Stop()
                End If
            End With

            'ファイル作成処理
            With tmrOUTPUT_FILE
                If pub_PGINFO.intFileMakeCheckInterval > 0 Then
                    .Interval = CInt(pub_PGINFO.intFileMakeCheckInterval * 1000)
                    If blnStartCall = True Then
                        tmrOUTPUT_FILE_Tick(Nothing, Nothing)
                    End If
                    .Start()
                Else
                    .Stop()
                End If
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "起動時初期処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & ErrMsg.FunGetErrMsg(ex))
            Return False
        End Try
    End Function
#End Region

#End Region

#Region "受信バッチ起動処理関連"

#Region "チェックタイマー"
    Private Sub tmrRECV_FILE_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRECV_FILE.Tick
        Dim DB As clsDbUtility = Nothing
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Dim RECV_GROUPList As List(Of Integer)
        Dim dtLastRecvYMDHNS As Nullable(Of DateTime)
        Dim dtNow As DateTime

        Try
            '-----タイマーストップ
            tmrRECV_FILE.Stop()

            '-----DB接続
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)


            'システム日時取得
            dtNow = FunGetSysDate(DB)

            '-----最新のファイル受信設定を取得
            pri_JTB_RECVARG_JO_Entities.Load(DB)

            '-----通信グループNoのリストを取得
            RECV_GROUPList = pri_JTB_RECVARG_JO_Entities.GetRECV_GROUP_List()

            '-----通信グループ単位に処理
            For Each groupNo As Integer In RECV_GROUPList
                '通信グループ内の最終受信日時を取得
                dtLastRecvYMDHNS = pri_JTB_RECVARG_JO_Entities.GetLastRECV_YMDHNS(groupNo)

                For Each entity As JTB_RECVARG_JO_Model In pri_JTB_RECVARG_JO_Entities.GetEntitiesByGroupNo(groupNo)
                    '初回受信時は先頭の受信設定を実行
                    If dtLastRecvYMDHNS.HasValue = False Then
                        '次回受信実行日時(最終受信日時 + 受信間隔) > システム日時の場合
                        If entity.NEXT_RECV_YMDHNS > dtNow Then

                            Dim dlgt As New ThreadMethodDelegate(AddressOf FunExecRECVBAT)
                            Dim asyncStateObject As New Tuple(Of ThreadMethodDelegate, JTB_RECVARG_JO_Model)(dlgt, entity)
                            Dim ar As IAsyncResult = dlgt.BeginInvoke(entity, New AsyncCallback(AddressOf SubRecvFileCallBack), asyncStateObject)

                            ''デリゲートによるスレッド呼び出し
                            'threadMethodDelegateInstance = New ThreadMethodDelegate(AddressOf FunExecRECVBAT)
                            ''デリゲートに渡す引数,コールバック,コールバックに渡す引数
                            'threadMethodDelegateInstance.BeginInvoke(entity, New AsyncCallback(AddressOf SubRecvFileCallBack), threadMethodDelegateInstance)

                            '最終受信日時を更新(受信の成功失敗に関わらず更新する)
                            Call FunUpdateRECV_YMDHNS(entity)

                            'DEBUG:ログ
                            'WL.WriteLogDat(String.Format("受信設定…{0} 実行基準日時…{1} 実行日時…{2}", entity.RECV_SETTING_NM, entity.NEXT_RECV_YMDHNS, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")))

                            '受信バッチ起動処理を実行したら、次の通信グループのチェック処理に進む
                            Exit For
                        Else
                            '同一通信グループの次の受信設定のチェック処理に進む
                            Continue For
                        End If
                    Else
                        '最低受信間隔以上経過している場合
                        If dtLastRecvYMDHNS.Value.AddMinutes(pri_intMIN_INTERVAL) < dtNow Then
                            '次回受信実行日時(最終受信日時 + 受信間隔) < システム日時の場合
                            If entity.NEXT_RECV_YMDHNS <= dtNow Then
                                Dim dlgt As New ThreadMethodDelegate(AddressOf FunExecRECVBAT)
                                Dim asyncStateObject As New Tuple(Of ThreadMethodDelegate, JTB_RECVARG_JO_Model)(dlgt, entity)
                                Dim ar As IAsyncResult = dlgt.BeginInvoke(entity, New AsyncCallback(AddressOf SubRecvFileCallBack), asyncStateObject)

                                ''デリゲートによるスレッド呼び出し
                                'threadMethodDelegateInstance = New ThreadMethodDelegate(AddressOf FunExecRECVBAT)
                                ''デリゲートに渡す引数,コールバック,コールバックに渡す引数
                                'threadMethodDelegateInstance.BeginInvoke(entity, New AsyncCallback(AddressOf SubRecvFileCallBack), threadMethodDelegateInstance)


                                '最終受信日時を更新(受信の成功失敗に関わらず更新する)
                                Call FunUpdateRECV_YMDHNS(entity)

                                'DEBUG:ログ
                                'WL.WriteLogDat(String.Format("受信設定…{0} 実行基準日時…{1} 実行日時…{2}", entity.RECV_SETTING_NM, entity.NEXT_RECV_YMDHNS, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")))

                                '受信バッチ起動処理を実行したら、次の通信グループのチェック処理に進む
                                Exit For
                            Else
                                '同一通信グループの次の受信設定のチェック処理に進む
                                Continue For
                            End If
                        Else
                            '最低受信間隔経過していない場合は、次の通信グループのチェック処理に進む
                            'WL.WriteLogDat("最低受信時間経過していない")
                            Exit For
                        End If
                    End If
                Next entity
            Next groupNo

            'ログファイル・受信ファイルの削除
            Call FunDeleteExpiredlogFiles()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "受信バッチ起動処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & ErrMsg.FunGetErrMsg(ex))
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If


            '-----タイマー始動
            tmrRECV_FILE.Start()
        End Try
    End Sub
#End Region

#Region "受信バッチ起動処理"
    ''' <summary>
    ''' 受信バッチ起動処理(ファイル種別ごとのパラメータの設定と受信バッチの起動)
    ''' </summary>
    ''' <param name="parameters">ファイル受信設定情報</param>
    ''' <returns>ログファイル</returns>
    Private Function FunExecRECVBAT(ByVal parameters As JTB_RECVARG_JO_Model) As String
        Dim strProc As String
        Dim strCritteria As String
        Dim strPara As String
        Dim blnRET As Boolean
        Dim dtNow As DateTime = DateTime.Now

        Dim strLogFile As String
        Dim strStsFile As String

        Try
            Select Case parameters.FILE_KB
                Case "DELFOR"
                    '内示…受注者企業コード:受注者事業所コード:発注者企業コード:発注者事業所コード:処理年月

                    'バッチファイル
                    strProc = parameters.EDICOM_PATH & "App\" & parameters.BAT_NM

                    '検索条件
                    With parameters
                        strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}", _
                                                     .JUCHU_TKS_CD,
                                                     .JUCHU_KOU_CD,
                                                     .HACHU_TKS_CD,
                                                     .HACHU_KOU_CD,
                                                     .SYR_YM)
                    End With

                Case "DELJIT"
                    '納入指示…出荷元企業コード:出荷元工区コード:出荷場所:納入先企業コード:納入先工区コード:処理日From:処理日To

                    'バッチファイル
                    strProc = parameters.EDICOM_PATH & "App\" & parameters.BAT_NM

                    '検索条件
                    With parameters
                        strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                     .SYUKKA_TKS_CD,
                                                     .SYUKKA_KOU_CD,
                                                     .SYUKKA_BA,
                                                     .NOU_TKS_CD,
                                                     .NOU_KOU_CD,
                                                     .DATE_FROM,
                                                     .DATE_TO)
                    End With

                Case "DESADV" '出荷実績
                    'バッチファイル
                    strProc = parameters.EDICOM_PATH & "App\" & parameters.BAT_NM


                    Select Case True
                        Case parameters.BAT_NM.Contains("Upper")
                            '商流上中継となる場合の実績抽出

                            '発注者企業コード:発注者事業所コード:受注者企業コード:受注者事業所コード:出荷場所:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .HACHU_TKS_CD,
                                                             .HACHU_KOU_CD,
                                                             .JUCHU_TKS_CD,
                                                             .JUCHU_KOU_CD,
                                                             .UKEIRE,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                        Case parameters.BAT_NM.Contains("Own")
                            '自社発行データの受信

                            '出荷元企業コード:出荷元工区コード:出荷場所:納入先企業コード:納入先工区コード:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .SYUKKA_TKS_CD,
                                                             .SYUKKA_KOU_CD,
                                                             .SYUKKA_BA,
                                                             .NOU_TKS_CD,
                                                             .NOU_KOU_CD,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                        Case Else
                            '他社発行データの受信(通常の受信処理)

                            '納入先企業コード:納入先事業所コード:受入場所:出荷元企業コード:出荷元事業所コード:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .NOU_TKS_CD,
                                                             .NOU_KOU_CD,
                                                             .UKEIRE,
                                                             .SYUKKA_TKS_CD,
                                                             .SYUKKA_KOU_CD,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                    End Select

                Case "RECADV" '受領実績

                    'バッチファイル
                    strProc = parameters.EDICOM_PATH & "App\" & parameters.BAT_NM

                    Select Case True
                        Case parameters.BAT_NM.Contains("Upper")
                            '商流上中継となる場合の実績抽出

                            '受注者企業コード:受注者事業所コード:発注者企業コード:発注者事業所コード:受入場所:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .JUCHU_TKS_CD,
                                                             .JUCHU_KOU_CD,
                                                             .HACHU_TKS_CD,
                                                             .HACHU_KOU_CD,
                                                             .UKEIRE,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                        Case parameters.BAT_NM.Contains("Own")
                            '自社発行データの受信

                            '納入先企業コード:納入先工区コード:受入場所:出荷元企業コード:出荷元工区コード:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .NOU_TKS_CD,
                                                             .NOU_KOU_CD,
                                                             .UKEIRE,
                                                             .SYUKKA_TKS_CD,
                                                             .SYUKKA_KOU_CD,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                        Case Else
                            '他社発行データの受信(通常の受信処理)

                            '出荷元企業コード:出荷元工区コード:出荷場所:納入先企業コード:納入先工区コード:処理日From:処理日To
                            With parameters
                                strCritteria = String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", _
                                                             .SYUKKA_TKS_CD,
                                                             .SYUKKA_KOU_CD,
                                                             .SYUKKA_BA,
                                                             .NOU_TKS_CD,
                                                             .NOU_KOU_CD,
                                                             .DATE_FROM,
                                                             .DATE_TO)
                            End With
                    End Select

                Case Else
                    Dim strMsg As String = "受信バッチ起動処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
                    FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & "引数:ファイルIDが取得出来ませんでした。")
                    Return -1
            End Select

            'フォルダ作成
            If System.IO.Directory.Exists(parameters.EDICOM_PATH & "Log\" & parameters.FILE_KB & "\") = False Then
                System.IO.Directory.CreateDirectory(parameters.EDICOM_PATH & "Log\" & parameters.FILE_KB & "\")
            End If

            'ファイル名作成
            strStsFile = parameters.EDICOM_PATH & "Log\" & parameters.FILE_KB & "\" & parameters.FILE_KB & Format(dtNow, "yyyyMMddHHmmss") & ".sts"
            strLogFile = parameters.EDICOM_PATH & "Log\" & parameters.FILE_KB & "\" & parameters.FILE_KB & Format(dtNow, "yyyyMMddHHmmss") & ".log"


            '受信済みファイル再受信パラメータ付与
            If parameters.RE_RECV_FLG = True Then
                strPara = "-fe "
                pri_blnReRecvDownLoading = True
            Else
                strPara = ""
            End If

            'パラメータ文字列作成
            strPara &= "-sts """ & strStsFile & """" & _
                      " -log """ & strLogFile & """" & _
                      " -find " & strCritteria

            'DEBUG: 動作ログ
            WL.WriteLogDat(String.Format("受信バッチ実行:{0}…{1} {2}", parameters.RECV_SETTING_NM, strProc, strPara))

            '受信コマンド実行
            blnRET = FunProcExec(strProc, strPara, ENM_EXECMODE._0_Sync, ENM_WINDOWMODE._1_SW_SHOWNORMAL, 180)


            Return strLogFile

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "受信バッチ起動処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & ErrMsg.FunGetErrMsg(ex))
            Return ""
        End Try
    End Function
#End Region

#Region "ファイル受信処理終了後のコールバック"

    'ファイル受信処理終了後のコールバック
    Private Sub SubRecvFileCallBack(ByVal ar As IAsyncResult)
        Dim dlgt As ThreadMethodDelegate
        Dim entity As JTB_RECVARG_JO_Model
        Dim strStsFile As String
        Dim strLogFile As String

        Try
            Dim result As Tuple(Of ThreadMethodDelegate, JTB_RECVARG_JO_Model) = DirectCast(ar.AsyncState, Tuple(Of ThreadMethodDelegate, JTB_RECVARG_JO_Model))
            'デリゲート取得
            dlgt = result.Item1
            '受信設定情報
            entity = result.Item2
            '受信ログファイル
            strLogFile = dlgt.EndInvoke(ar)

            'ログファイル名からステータスファイル名を生成(拡張子のみ違う)
            strStsFile = strLogFile.Substring(0, strLogFile.Length - 4) & ".sts"

            WL.WriteLogDat(String.Format("受信処理完了 受信設定ID:{0}、受信設定名:{1}、ログファイル：{2}", entity.RECV_SETTING_ID, entity.RECV_SETTING_NM, strLogFile))

            'DEBUG:RE_RECV
            'strStsFile = "C:\EDIComPackage_2\Log\DELFOR20161020121258.sts"


            If FunCheckRecvStatus(strStsFile) = False Then
                'ログファイルの内容をエラーログテーブルに出力 +メール送信
                Call FunRegistErrLog(strLogFile, entity)

                '受信設定の有効フラグを無効に更新
                Call FunUpdateENABLE_FLG(entity)
            Else
                '再受信時にステータスファイル内の受信ファイル一覧を取得
                If entity.RE_RECV_FLG = True Then

                    '再受信対象ファイルリストに追加(ファイル取込処理にて使用)
                    pri_ReRecvFileList = FunGetRecvFileList(strStsFile)

                    '再受信ファイルの受信終了
                    pri_blnReRecvDownLoading = False

                    '受信設定の再受信フラグを更新
                    FunUpdateRE_RECV_FLG(entity)
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "ステータスファイルから受信ファイル一覧を取得"
    Private Function FunGetRecvFileList(ByVal strStsFile As String) As List(Of String)
        Dim list As New List(Of String)
        Dim strBUFF As String
        Dim strCAUSE As String
        Dim strDIAG As String

        Try
            Using cReader As New System.IO.StreamReader(strStsFile, System.Text.Encoding.GetEncoding("shift-jis"))
                With cReader
                    While (.Peek() >= 0)
                        'ファイル名を切り出して格納
                        strBUFF = .ReadLine()
                        strCAUSE = strBUFF.Substring(19, 2)
                        strDIAG = strBUFF.Substring(21, 4)
                        If strCAUSE = "00" Then
                            '正常終了時のみリストに追加
                            list.Add(strBUFF.Substring(0, 19) & ".xml")
                        Else
                            'エラー発生ファイルはそもそも受信されていないのでスキップ

                        End If
                    End While

                    .Close()
                End With
            End Using

            Return list
        Catch ex As System.IO.FileNotFoundException
            'ファイルが存在しない場合=未受信
            Return Nothing
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function
#End Region

#Region "ステータスファイルより受信の成功失敗を判定"
    Private Function FunCheckRecvStatus(ByVal strStsFile As String) As Boolean
        Dim strBUFF As String
        Dim strCAUSE As String
        Dim strDIAG As String

        Try
            If System.IO.File.Exists(strStsFile) = False Then
                Threading.Thread.Sleep(3000)
            End If

            Using cReader As New System.IO.StreamReader(strStsFile, System.Text.Encoding.GetEncoding("shift-jis"))
                With cReader
                    While (.Peek() >= 0)
                        strBUFF = .ReadLine()
                        strCAUSE = strBUFF.Substring(19, 2)
                        strDIAG = strBUFF.Substring(21, 4)
                        If strCAUSE = "00" Then
                            '正常終了
                        Else
                            '失敗
                            Return False
                        End If
                    End While

                    .Close()
                End With
            End Using

            Return True

        Catch ex As IO.FileNotFoundException
            Return False
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "ログファイルの内容をエラーログテーブルに出力"
    Private Function FunRegistErrLog(ByVal strLogFile As String, ByVal entity As JTB_RECVARG_JO_Model) As Boolean
        Dim list As New List(Of String)
        '14 5
        Dim strStsFile As String
        Try

            'ログファイルは受信失敗時のみ出力される
            If System.IO.File.Exists(strLogFile) = True Then
                strStsFile = strLogFile.Substring(0, strLogFile.Length - 4) & ".sts"

                'ログファイルとステータスファイルを添付
                list.Add(strLogFile)
                list.Add(strStsFile)

                Using sr As New System.IO.StreamReader(strLogFile, System.Text.Encoding.GetEncoding("utf-8"))
                    '内容をすべて読み込む
                    Dim strLog As String = sr.ReadToEnd()
                    Dim strMsg As String = "EDIデータ受信に失敗しました。" & vbCrLf &
                                           "ファイル受信設定(JTB_RECVARG_JO)を確認して下さい。" & vbCrLf &
                                           vbCrLf &
                                           "受信設定ID：" & entity.RECV_SETTING_ID & vbCrLf &
                                           "受信設定名：" & entity.RECV_SETTING_NM & vbCrLf &
                                           ""
                    FunErrorSyori(ENM_ERR_KB._1_EDI通信エラー, ENM_ERR_LEVEL._1_重要, strMsg, strLog, list)
                End Using
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "ファイル最終受信処理日時更新"
    Private Function FunUpdateRECV_YMDHNS(ByVal entity As JTB_RECVARG_JO_Model) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim DB As clsDbUtility = Nothing
        Dim intRET As Integer

        Try
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE JTB_RECVARG_JO SET ")
            sbSQL.Append(" RECV_YMDHNS =[dbo].[GetSysDateString]()")
            sbSQL.Append(" WHERE RECV_SETTING_ID=" & entity.RECV_SETTING_ID & " ")
            'SQL実行
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
            If intRET = 0 Then
                'UNDONE: エラーログ出力
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If

        End Try
    End Function
#End Region

#Region "再受信処理終了後ステータス更新"
    Private Function FunUpdateRE_RECV_FLG(ByVal entity As JTB_RECVARG_JO_Model) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim DB As clsDbUtility = Nothing
        Dim intRET As Integer

        Try
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE JTB_RECVARG_JO SET ")
            sbSQL.Append(" RE_RECV_FLG ='0'")
            sbSQL.Append(" WHERE RECV_SETTING_ID=" & entity.RECV_SETTING_ID & " ")
            'SQL実行
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
            If intRET = 0 Then
                'UNDONE: エラーログ出力
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If

        End Try
    End Function
#End Region

#Region "ファイル受信設定有効フラグ更新"
    Private Function FunUpdateENABLE_FLG(ByVal entity As JTB_RECVARG_JO_Model) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim DB As clsDbUtility = Nothing
        Dim intRET As Integer

        Try
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE JTB_RECVARG_JO SET ")
            sbSQL.Append(" ENABLE_FLG ='0'")
            sbSQL.Append(" WHERE RECV_SETTING_ID=" & entity.RECV_SETTING_ID & " ")
            'SQL実行
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
            If intRET = 0 Then
                'UNDONE: エラーログ出力
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If

        End Try
    End Function
#End Region

#Region "期限切れログファイルの削除"
    Private Function FunDeleteExpiredlogFiles() As Boolean
        Dim intBackupDays As Integer
        Dim DB As clsDbUtility = Nothing
        Dim dtNow As DateTime
        Dim strEDICOM_PATH1 As String
        Dim strEDICOM_PATH2 As String

        Try
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
            strEDICOM_PATH1 = FunGetCodeMastaValue(DB, "EDICOM_PATH", "1")
            strEDICOM_PATH2 = FunGetCodeMastaValue(DB, "EDICOM_PATH", "2")


            If System.IO.Directory.Exists(pub_PGINFO.strBackup_Path) = False Then
                'バックアップファイルがまだ存在しない…インストール直後データ未受信
                Return True
            End If

            Dim wkfiles As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                               pub_PGINFO.strBackup_Path, "*.xml", System.IO.SearchOption.AllDirectories).Concat(
                                               System.IO.Directory.EnumerateFiles( _
                                               pub_PGINFO.strBackup_Path, "*.csv", System.IO.SearchOption.AllDirectories))


            'システム日時取得
            dtNow = FunGetSysDate(DB)

            intBackupDays = Val(FunGetCodeMastaValue(DB, "RECV_SETTING", "RECVFILE_BACKUP_DAYS"))

            For Each file As String In wkfiles
                Dim f As New System.IO.FileInfo(file)
                If intBackupDays = 0 Then
                    '無期限に設定されているため、削除しない
                    Return True
                Else
                    '設定されたバックアップ日数以上経過したファイルは削除する
                    If dtNow.Subtract(f.CreationTime).Days > intBackupDays Then
                        Try
                            f.Delete()

                        Catch ex As System.IO.IOException
                            '対象ファイルを開いている
                        Catch ex As System.Security.SecurityException
                            'アクセス権限がない(作成時にはあった権限が失われた)
                        Catch ex As System.UnauthorizedAccessException
                            'フォルダパスを変更された…あり得ない
                        End Try
                    End If
                End If
            Next file

            Return True

        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If
        End Try
    End Function

#End Region
#End Region

#Region "受信ファイル取込処理関連"

#Region "チェックタイマー"
    Private Sub tmrINPUT_FILE_Tick(sender As System.Object, e As System.EventArgs) Handles tmrINPUT_FILE.Tick
        Dim strTMP_FILE As String
        Dim DB As clsDbUtility = Nothing
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet

        Try
            'タイマーストップ
            tmrINPUT_FILE.Stop()

            '-----DB接続
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            '再受信データ取得中の場合は取込処理をスキップ
            If pri_blnReRecvDownLoading = True Then
                WL.WriteLogDat("受信ファイル取込処理 再受信データ取得中につき、DBへの取込を保留中")
                Exit Sub
            End If

            '2016.11.22 
            If FunGetCodeMastaValue(DB, "RECV_SETTING", "AUTO_IMPORT_FLG") <> "1" Then
                '自動取込フラグが無効のため処理を中止
                Exit Sub
            End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * ")
            sbSQL.Append(" FROM MTB_CODE ")
            sbSQL.Append(" WHERE KOMO_NM='EDICOM_PATH' ")
            sbSQL.Append(" ORDER BY CONVERT(int,[VALUE]) ")

            '①通信モジュールルートパス一覧を取得
            dsList = DB.GetDataSet(sbSQL.ToString, True)

            With dsList.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    '通信モジュールルートパスを取得
                    Dim strEDICOM_Path As String = FunConvPathString(.Rows(i).Item("DISP").ToString.Trim)

                    '②通信モジュールの受信ファイル一覧を取得
                    Dim files As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                                        strEDICOM_Path & "Receive\", "*.xml", System.IO.SearchOption.TopDirectoryOnly)

                    For Each file As String In files
                        '③書込中ファイル読込防止のため、ファイル名を*_TMPにリネーム
                        Dim xmlfile As New System.IO.FileInfo(file)
                        'strTMP_FILE = FunGetRootPath() & "\RECV\" & System.IO.Path.GetFileNameWithoutExtension(file) & "_TMP" & xmlfile.Extension
                        strTMP_FILE = strEDICOM_Path & "Receive\" & System.IO.Path.GetFileNameWithoutExtension(file) & "_TMP" & xmlfile.Extension

                        System.IO.File.Delete(strTMP_FILE) '念のため同名TMPファイルを削除(IOExceptionの原因を絞り込むため)
                        Try
                            xmlfile.MoveTo(strTMP_FILE)

                        Catch ex As System.IO.FileNotFoundException
                            '元ファイルが存在しない場合は取込処理をスキップ
                            Continue For
                        Catch ex As System.IO.DirectoryNotFoundException
                            '一覧取得後通信パッケージ(の受信)フォルダが消えた場合 ほぼあり得ないが万が一発生した場合は、処理中断
                            'UNDONE:エラーログ出力
                            Exit Sub
                        Catch ex As System.IO.IOException
                            '同名ファイルが存在する場合以外の例外が発生した場合 念のためエラーログを出力して取込処理をスキップ
                            'UNDONE:エラーログ出力
                            Continue For
                        Catch ex As UnauthorizedAccessException
                            'ファイル書込中等の理由でアクセスが拒否された場合は取込処理をスキップ
                            Continue For
                        End Try
                    Next file

                    'TMPファイルを取り込み
                    Call FunINPUT_FILES(strEDICOM_Path, Val(.Rows(i).Item("VALUE").ToString))
                Next i
            End With

            'バックアップ保存期間を過ぎた受信済みファイル(元データのXMLおよびDB取込前変換後のCSV)を削除
            Call FunDeleteExpiredBackupFiles()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "ファイル取込処理に失敗しました。" & vbCrLf & "エラー内容を控えた上で、システム開発元へご連絡下さい。"
            FunErrorSyori(ENM_ERR_KB._2_受信ファイル取込時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & ErrMsg.FunGetErrMsg(ex))

            '自動取込フラグを無効
            FunSetCodeMastaValue(DB, "RECV_SETTING", "AUTO_IMPORT_FLG", "0")
        Finally
            dsList.Dispose()
            If DB IsNot Nothing Then
                DB.Close()
            End If


            'タイマー始動
            tmrINPUT_FILE.Start()
        End Try
    End Sub
#End Region

#Region "ファイル取込処理"
    ''' <summary>
    ''' ファイル取込処理
    ''' </summary>
    ''' <param name="strEDICOM_Path">通信モジュールルートパス</param>
    ''' <param name="strCOMPATH_NO">通信モジュール(通信アドレス)識別NO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunINPUT_FILES(ByVal strEDICOM_Path As String, ByVal strCOMPATH_NO As Integer) As Boolean
        Dim strTXT_FILE As String
        Dim strTMP_FILE As String
        Dim fileInfo As New FILE_INFO

        Try
            '取込ファイル(TMPファイル)の一覧を取得
            Dim wkfiles As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                                 strEDICOM_Path & "Receive\", "*TMP.xml", System.IO.SearchOption.TopDirectoryOnly)

            For Each file As String In wkfiles
                'ファイル情報を取得
                Select Case True
                    Case file.Contains("DELFOR")
                        With fileInfo
                            .strFileName = System.IO.Path.GetFileName(file).Replace("_TMP", "")
                            .strFileType = "DELFOR"
                            .intFieldCount = RTB_DELFOR_Model.FieldsCount
                            .intFieldWidths = RTB_DELFOR_Model.FieldWidths
                            .strFieldNames = RTB_DELFOR_Model.FieldNames
                            .strTableName = RTB_DELFOR_Model.SourceTableName
                        End With
                    Case file.Contains("DELJIT")
                        With fileInfo
                            .strFileName = System.IO.Path.GetFileName(file).Replace("_TMP", "")
                            .strFileType = "DELJIT"
                            .intFieldCount = RTB_DELJIT_Model.FieldsCount
                            .intFieldWidths = RTB_DELJIT_Model.FieldWidths
                            .strFieldNames = RTB_DELJIT_Model.FieldNames
                            .strTableName = RTB_DELJIT_Model.SourceTableName
                        End With
                    Case file.Contains("RECADV")
                        With fileInfo
                            .strFileName = System.IO.Path.GetFileName(file).Replace("_TMP", "")
                            .strFileType = "RECADV"
                            .intFieldCount = RTB_RECADV_Model.FieldsCount
                            .intFieldWidths = RTB_RECADV_Model.FieldWidths
                            .strFieldNames = RTB_RECADV_Model.FieldNames
                            .strTableName = RTB_RECADV_Model.SourceTableName
                        End With
                    Case file.Contains("DESADV")
                        With fileInfo
                            .strFileName = System.IO.Path.GetFileName(file).Replace("_TMP", "")
                            .strFileType = "DESADV"
                            .intFieldCount = RTB_DESADV_Model.FieldsCount
                            .intFieldWidths = RTB_DESADV_Model.FieldWidths
                            .strFieldNames = RTB_DESADV_Model.FieldNames
                            .strTableName = RTB_DESADV_Model.SourceTableName
                        End With
                    Case file.Contains("OSTRPT"), file.Contains("MASTER"), file.Contains("BUYMST"), file.Contains("SELMST")
                        '取り込み処理未実装のEDI受信ファイル
                        'WL.WriteLogDat("取込処理未実装の受信バッチです")
                        Continue For
                    Case Else
                        '取込対象のファイルではない
                        Continue For
                End Select

                '再受信時
                If pri_ReRecvFileList.Contains(fileInfo.strFileName) = True Then
                    fileInfo.blnReRecvFLG = True
                    'リストから除外
                    pri_ReRecvFileList.Remove(fileInfo.strFileName)
                Else
                    fileInfo.blnReRecvFLG = False
                End If

                '
                Dim wkfile As New System.IO.FileInfo(file)

                '③固定長ファイルの削除
                strTXT_FILE = FunGetRootPath() & "\RECV\" & fileInfo.strFileType & ".txt"
                System.IO.File.Delete(strTXT_FILE)

                '④TEMPファイルを変換ツールで固定長に変換
                If FunConvertXMLtoTXT(file, strTXT_FILE, fileInfo.strFileType) = False Then
                    '変換に失敗した場合は処理スキップ

                    'TEMPファイルのファイル名を元に戻す
                    strTMP_FILE = (wkfile.FullName).Replace("_TMP", "")
                    System.IO.File.Delete(strTMP_FILE)
                    Try
                        wkfile.MoveTo(strTMP_FILE)
                    Catch ex As System.IO.FileNotFoundException
                    End Try
                    Continue For
                End If

                '⑤固定長ファイルを読み込んでDBに書き込み
                If FunTXTtoTable(strTXT_FILE, fileInfo, strCOMPATH_NO) = False Then
                    'TEMPファイルのファイル名を元に戻す
                    strTMP_FILE = (wkfile.FullName).Replace("_TMP", "")
                    System.IO.File.Delete(strTMP_FILE)
                    Try
                        wkfile.MoveTo(strTMP_FILE)
                    Catch ex As System.IO.FileNotFoundException
                    End Try
                    Continue For
                End If

                'TEMPファイルをバックアップフォルダに移動
                Dim strBackupPath As String = pub_PGINFO.strBackup_Path & "XML\" & strCOMPATH_NO & "\"
                If System.IO.Directory.Exists(strBackupPath) = False Then
                    System.IO.Directory.CreateDirectory(strBackupPath)
                End If
                'TEMPファイルのファイル名を元に戻す
                strTMP_FILE = (strBackupPath & wkfile.Name).Replace("_TMP", "")

                System.IO.File.Delete(strTMP_FILE) '念のため同名TMPファイルを削除(IOExceptionの原因を絞り込むため)
                Try
                    wkfile.MoveTo(strTMP_FILE)

                Catch ex As System.IO.FileNotFoundException
                    '元ファイルが存在しない場合は取込処理をスキップ
                    Continue For
                End Try

                '③固定長ファイルの削除
                strTXT_FILE = FunGetRootPath() & "\RECV\" & fileInfo.strFileType & ".txt"
                System.IO.File.Delete(strTXT_FILE)
            Next file

            Return True
        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        End Try
    End Function
#End Region

#Region "   ④ 固定長ファイル変換"

    ''' <summary>
    ''' XMLファイルを変換ツールを使用して固定長ファイルに変換する
    ''' </summary>
    ''' <param name="strConvFromPath">変換元ファイル</param>
    ''' <param name="strConvToPath">変換後ファイル</param>
    ''' <param name="strConvType">変換ファイルタイプ(DELFOR,DELJIT,DESADV)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunConvertXMLtoTXT(ByVal strConvFromPath As String, ByVal strConvToPath As String, ByVal strConvType As String) As Boolean

        Dim strProc As String
        Dim strPara As String
        Dim blnRET As Boolean
        Dim strOUTPUT_PATH As String
        Const strConvDirection As String = "XtoT" 'XMLから固定長ファイルに変換

        Try
            strOUTPUT_PATH = FunGetRootPath() & "\LOG\XMLConvert\"
            If System.IO.Directory.Exists(strOUTPUT_PATH) = False Then
                System.IO.Directory.CreateDirectory(strOUTPUT_PATH)
            End If

            strProc = pub_PGINFO.strEDIXMLConverter_Path & "App\Bat\XmlConvert.bat"
            strPara = "-" & strConvDirection & _
                        " -" & strConvType & _
                        " " & strConvFromPath & _
                        " " & strConvToPath & _
                        " " & strOUTPUT_PATH & strConvType & "ConvXML" & ".log"

            blnRET = FunProcExec(strProc, strPara, ENM_EXECMODE._0_Sync, ENM_WINDOWMODE._0_SW_HIDE)
            Return blnRET
        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return ""
        End Try
    End Function

#End Region

#Region "   ⑤ 固定長ファイルを読み込んでDBに書込"
    Private Function FunTXTtoTable(ByVal strTXT_FILE As String, ByVal fileInfo As FILE_INFO, ByVal strCOMPATH_NO As Integer) As Boolean
        Dim data() As String
        Dim blnRET As Boolean
        Dim dataList As New List(Of String())

        Try
            Using reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strTXT_FILE, System.Text.Encoding.GetEncoding("shift_jis"))
                reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited

                While Not reader.EndOfData
                    Try
                        'データを1行取得
                        data = GetFieldString(reader.ReadLine, "shift_jis", fileInfo.intFieldWidths)

                        '列数が一致しているかチェック
                        If data.Length <> fileInfo.intFieldCount Then
                            Dim strMsg As String = "取込ファイルの列数と取込先テーブルの列数が一致しません。" & vbCrLf & String.Format("ファイル列数:{0} テーブル列数:{1}", data.Length, fileInfo.intFieldCount)
                            FunErrorSyori(ENM_ERR_KB._2_受信ファイル取込時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "")
                            Return False
                        End If

                        'リストに追加
                        dataList.Add(data)
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        Throw ex
                    End Try
                End While
            End Using

            If fileInfo.blnReRecvFLG = True Then
                '再受信処理時はCSVファイルの出力のみ行う
                blnRET = FunConvertTXTtoCSV(dataList, fileInfo, strCOMPATH_NO)
            Else
                'リストをDBに書き込み
                blnRET = FunblnTableInsert(dataList, fileInfo)
                If blnRET = True Then
                    'DB書き込み成功時にCSVファイルを作成
                    blnRET = FunConvertTXTtoCSV(dataList, fileInfo, strCOMPATH_NO)
                End If
            End If

            Return blnRET
        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        End Try
    End Function

    Function GetFieldString(ByRef Str As String, ByRef strEncode As String, ByVal Prams() As Integer) As String()
        Dim iPram As Integer
        Dim iIndex As Integer = 0
        Dim iStrP As Integer = 0
        Dim strArray As String() = {""}
        'バイト配列に変換
        Dim ByteArray As Byte() = System.Text.Encoding.GetEncoding(strEncode).GetBytes(Str)

        For Each iPram In Prams
            '文字列に変換して文字列の配列に格納
            strArray(iStrP) = System.Text.Encoding.GetEncoding(strEncode).GetString(ByteArray, iIndex, iPram)
            iStrP = iStrP + 1
            ReDim Preserve strArray(iStrP)
            iIndex = iIndex + iPram
        Next
        '余分な配列を除く
        ReDim Preserve strArray(iStrP - 1)
        Return strArray
    End Function
#End Region

#Region "   固定長ファイルをCSVに変換してバックアップフォルダに移動"
    Private Function FunConvertTXTtoCSV(ByVal datalist As List(Of String()), ByVal fileInfo As FILE_INFO, ByVal strCOMPATH_NO As Integer) As Boolean
        Dim strCSVFile As String
        Dim strPATH As String
        Dim strDATA As String()
        Dim strBUFF As String
        Dim str As String

        Dim blnHeader As Boolean
        Dim blnQuotation As Boolean
        Dim intBUFF As Integer
        Try
            Select Case pub_PGINFO.intCSVFILE_FORMAT
                Case ENM_FILE_FORMAT._2_CSV_見出し無_クォーテーション無
                    blnHeader = False
                    blnQuotation = False
                Case ENM_FILE_FORMAT._3_CSV_見出し無_クォーテーション有
                    blnHeader = False
                    blnQuotation = True
                Case ENM_FILE_FORMAT._4_CSV_見出し有_クォーテーション無
                    blnHeader = True
                    blnQuotation = False
                Case ENM_FILE_FORMAT._5_CSV_見出し有_クォーテーション有
                    blnHeader = True
                    blnQuotation = True
                Case Else
                    blnHeader = False
                    blnQuotation = False
            End Select


            '配列用意
            ReDim strDATA(0 To datalist.Count)

            'ヘッダ書込み
            If blnHeader = True Then
                strBUFF = ""
                For Each COL As String In fileInfo.strFieldNames
                    If blnQuotation = True Then
                        strBUFF = strBUFF & """" & COL & ""","
                    Else
                        strBUFF = strBUFF & COL & ","
                    End If
                Next
                'レコード末尾のカンマを取り除く
                strBUFF = strBUFF.Remove(strBUFF.Length - 1)

                'ヘッダ行をセット
                strDATA(0) = strBUFF
                intBUFF = 1
            End If


            'データ書込み
            For intRow As Integer = intBUFF To datalist.Count - 1
                strBUFF = ""
                For intCol As Integer = 0 To datalist(0).Length - 1
                    'レコード値に"が含まれている場合はエスケープ文字を追加する
                    str = datalist(intRow)(intCol).ToString
                    If str.Contains("""") = True Then
                        str = str.Replace("""", """""")
                    End If
                    If blnQuotation = True Then
                        strBUFF &= """" & str & """," 'クォーテーション括り有
                    Else
                        strBUFF &= str & "," 'クォーテーション括り無
                    End If
                Next intCol

                'レコード末尾
                strBUFF = strBUFF.Remove(strBUFF.Length - 1)

                strDATA(intRow) = strBUFF
            Next intRow

            If pub_PGINFO.strBackup_Path <> "" Then
                If fileInfo.blnReRecvFLG = True Then
                    '再受信ファイル出力先を指定
                    If pub_PGINFO.strReRecv_Path <> "" Then
                        strPATH = FunConvPathString(System.IO.Path.GetDirectoryName(pub_PGINFO.strReRecv_Path))
                    Else
                        'UNDONE: エラー 出力先未設定
                        Return False
                    End If
                Else
                    '設定ファイルの受信ファイルバックアップ先を指定
                    strPATH = FunConvPathString(System.IO.Path.GetDirectoryName(pub_PGINFO.strBackup_Path & "TXT\" & strCOMPATH_NO & "\"))
                End If

                'フォルダ存在チェックと作成
                If System.IO.Directory.Exists(strPATH) = False Then
                    System.IO.Directory.CreateDirectory(strPATH)
                End If

                '文字コード指定
                Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

                '出力ファイル名
                strCSVFile = System.IO.Path.GetFileNameWithoutExtension(fileInfo.strFileName) & ".csv"

                '-----書き込み-----
                System.IO.File.WriteAllLines(strPATH & strCSVFile, strDATA, enc)

                Return True
            Else
                'UNDONE: エラー出力 設定値が存在しない
                Return False
            End If

        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        Finally

        End Try

    End Function

#End Region

#Region "   DB書込処理"
    Private Function FunblnTableInsert(ByVal datalist As List(Of String()), ByVal fileInfo As FILE_INFO) As Boolean
        Dim strSQL As String
        Dim DB As clsDbUtility = Nothing
        Dim intRET As Integer
        Dim blnRET As Boolean
        Dim intRENBAN As Integer = 1
        Dim strNow As String
        Dim sqlEx As Exception

        Try
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
            strNow = FunGetSysDateString(DB)

            'トランザクション
            DB.BeginTransaction()

            blnRET = True
            For Each data As String() In datalist
                strSQL = FunMake_InsSQL(data, fileInfo, intRENBAN, strNow) 'INSERT文生成
                sqlEx = Nothing
                intRET = DB.ExecuteNonQuery(strSQL, True, sqlEx) 'SQL実行
                If sqlEx IsNot Nothing Then
                    If sqlEx.Message.Contains("PRIMARY KEY") = True Then
                        'キー制約エラー=重複データが存在した場合は、エラーとせずスキップする
                        Continue For
                    Else
                        'エラーメール送信
                        Dim strMsg As String = "ファイル取込処理に失敗しました。"
                        FunErrorSyori(ENM_ERR_KB._2_受信ファイル取込時エラー, ENM_ERR_LEVEL._2_連絡, strMsg, ErrMsg.FunGetErrMsg(sqlEx))
                        blnRET = False
                        Exit For
                    End If
                End If
            Next data

            'コミット
            DB.Commit(blnRET)

            Return blnRET
        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If

        End Try
    End Function

#End Region

#Region "   INSERT文生成"
    Private Function FunMake_InsSQL(ByVal data() As String, ByVal fileinfo As FILE_INFO, ByRef intRENBAN As Integer, ByVal strDatetime As String) As String
        Dim iCol As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbCol As New System.Text.StringBuilder
        Dim sbVal As New System.Text.StringBuilder
        Dim strColName As String
        Dim intLCnt As Integer

        Dim strTableName As String
        Dim strColNames As String()
        Try
            sbSQL.Remove(0, sbSQL.Length)
            sbCol.Remove(0, sbCol.Length)
            sbVal.Remove(0, sbVal.Length)

            intLCnt = 0

            strTableName = fileinfo.strTableName
            strColNames = fileinfo.strFieldNames

            '---SQL生成
            For iCol = 0 To data.Length - 1
                strColName = strColNames(iCol)

                'INSERT文のフィールドに追加
                intLCnt = intLCnt + 1

                If intLCnt > 1 Then
                    sbCol.Append(",")
                    sbVal.Append(",")
                End If

                'Column
                sbCol.Append(strColName)
                'Values
                sbVal.Append("'" & data(iCol).ToString & "'")
            Next


            'ファイル名・連番・処理日時項目を追加
            'UNDONE: データ取込時の追加列(ファイル名・連番・処理日時)の物理名をどこかに格納する constでもいい
            sbCol.Append(",FILE_NM,RENBAN,RECV_YMDHNS")
            sbVal.Append(String.Format(",'{0}',{1},'{2}'", fileinfo.strFileName, intRENBAN, strDatetime))
            intRENBAN += 1


            '---INSERT文をセット
            sbSQL.Append("INSERT INTO " & strTableName)
            sbSQL.Append(" (" & sbCol.ToString & ") VALUES(" & sbVal.ToString & ")")

            Return sbSQL.ToString
        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理する
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return ""
        End Try
    End Function
#End Region

#Region "期限切れバックアップファイルの削除"
    Private Function FunDeleteExpiredBackupFiles() As Boolean
        Dim intBackupDays As Integer
        Dim DB As clsDbUtility = Nothing
        Dim dtNow As DateTime
        Try

            If System.IO.Directory.Exists(pub_PGINFO.strBackup_Path) = False Then
                'バックアップファイルがまだ存在しない…インストール直後データ未受信
                Return True
            End If

            Dim wkfiles As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                               pub_PGINFO.strBackup_Path, "*.xml", System.IO.SearchOption.AllDirectories).Concat(
                                               System.IO.Directory.EnumerateFiles( _
                                               pub_PGINFO.strBackup_Path, "*.csv", System.IO.SearchOption.AllDirectories))

            

            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
            'システム日時取得
            dtNow = FunGetSysDate(DB)

            intBackupDays = Val(FunGetCodeMastaValue(DB, "RECV_SETTING", "RECVFILE_BACKUP_DAYS"))

            For Each file As String In wkfiles
                Dim f As New System.IO.FileInfo(file)
                If intBackupDays = 0 Then
                    '無期限に設定されているため、削除しない
                    Return True
                Else
                    '設定されたバックアップ日数以上経過したファイルは削除する
                    If dtNow.Subtract(f.CreationTime).Days > intBackupDays Then
                        Try
                            f.Delete()

                        Catch ex As System.IO.IOException
                            '対象ファイルを開いている
                        Catch ex As System.Security.SecurityException
                            'アクセス権限がない(作成時にはあった権限が失われた)
                        Catch ex As System.UnauthorizedAccessException
                            'フォルダパスを変更された…あり得ない
                        End Try
                    End If
                End If
            Next file

            Return True

        Catch ex As Exception
            '例外はおおもとのタイマーイベントにて処理
            'EM.ErrorSyori(ex, False, conblnNonMsg)
            Throw
            Return False
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If
        End Try
    End Function

#End Region
#End Region

#Region "ファイル作成処理関連"

#Region "チェックタイマー"
    'ファイル作成処理チェックタイマー
    Private Sub tmrOUTPUT_FILE_Tick(sender As System.Object, e As System.EventArgs) Handles tmrOUTPUT_FILE.Tick
        Dim dt As DateTime
        Dim dtNow As DateTime
        Dim make_targetEntities As New List(Of JTB_RECVFILE_JO_Model)
        Dim re_make_targetEntities As New List(Of JTB_RECVFILE_JO_Model)
        Dim DB As clsDbUtility = Nothing
        Dim targetEntities_work As New List(Of JTB_RECVFILE_JO_Model)

        Dim reMakeFileList As New List(Of String)
        Try
            'タイマーストップ
            tmrOUTPUT_FILE.Stop()

            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            dtNow = FunGetSysDate(DB)

            '-----最新の受信データ編成情報・ファイル出力編成情報を取得
            pri_JTB_RECVFILE_JO_Entities = New JTB_RECVFILE_JO_Entities
            pri_JTB_RECVFILE_JO_Entities.Load(DB)
            pri_JTB_FILE_ITEMFORMAT_Entities = New JTB_FILE_ITEMFORMAT_Entities
            pri_JTB_FILE_ITEMFORMAT_Entities.Load(DB)

            For Each entity As JTB_RECVFILE_JO_Model In pri_JTB_RECVFILE_JO_Entities.prEntities.Values
                With entity
                    If DateTime.TryParseExact(.LASTIMP_YMDHNS, "yyyyMMddHHmmss", Nothing, Globalization.DateTimeStyles.None, dt) = False Then
                        dt = dtNow
                    Else
                        dt = dt.AddMinutes(pub_PGINFO.intFileMakeCheckInterval)
                    End If

                    ''バックアップ期限切れファイル削除
                    Call FunDeleteBackupFile(dtNow, entity)

                    '自動作成フラグが有効で前回作成日時から監視間隔(作成間隔)分以上経過している場合
                    If .AUTOMAKE_FLG = "1" Then
                        If dt <= dtNow Then
                            'ファイル作成対象リストに追加
                            make_targetEntities.Add(entity)
                        End If

                        '2017.07.12 Mod 再作成対象のファイル出力編成IDのみを追加
                        'ファイル再作成対象リストに追加
                        're_make_targetEntities.Add(entity)
                        If FunGetReMakeTargetFileList(DB, entity.FILE_ID).Count > 0 Then
                            re_make_targetEntities.Add(entity)
                        End If
                        'Mod End
                    Else
                        Continue For
                    End If

                End With
            Next entity

            '再作成ファイルリスト取得
            reMakeFileList = FunGetReMakeTargetFileList(DB)
            If reMakeFileList.Count > 0 And re_make_targetEntities.Count > 0 Then
                '2016.10.24 Add 出力エラーファイル再作成処理
                If pri_Thread_REMAKE_FILE Is Nothing OrElse pri_Thread_REMAKE_FILE.IsAlive = False Then
                    'スレッドが存在しないか、完了している場合は新規スレッド作成
                    pri_Thread_REMAKE_FILE = New System.Threading.Thread(
                        New System.Threading.ParameterizedThreadStart(AddressOf FunReMakeFile))

                    'スレッド開始
                    pri_Thread_REMAKE_FILE.Start(re_make_targetEntities)
                    '
                    pri_Thread_REMAKE_FILE.Join()
                End If
            End If

            '1件以上作成対象が存在する場合は、ファイル作成処理を実行
            If make_targetEntities.Count > 0 Then
                'スレッドチェック
                If pri_Thread_MAKE_FILE Is Nothing OrElse pri_Thread_MAKE_FILE.IsAlive = False Then
                    'スレッドが存在しないか、完了している場合は新規スレッド作成
                    pri_Thread_MAKE_FILE = New System.Threading.Thread(
                        New System.Threading.ParameterizedThreadStart(AddressOf FunMakeFile))

                    'スレッド開始
                    pri_Thread_MAKE_FILE.Start(make_targetEntities)
                    '
                    pri_Thread_MAKE_FILE.Join()
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If DB IsNot Nothing Then
                DB.Close()
            End If

            'タイマー始動
            tmrOUTPUT_FILE.Start()
        End Try
    End Sub
#End Region

#Region "バックアップ期限切れファイル削除"
    Private Function FunDeleteBackupFile(ByVal dtNow As DateTime, ByVal entity As JTB_RECVFILE_JO_Model) As Boolean
        Dim strPath As String
        Dim strExtension As String
        Dim intCount As Integer
        Try
            With entity
                Select Case .FILE_FORMAT
                    Case ENM_FILE_FORMAT._1_固定長
                        strExtension = ".txt"
                    Case 2, 3, 4, 5 'CSV
                        strExtension = ".csv"
                    Case ENM_FILE_FORMAT._6_SP_ストアドプロシージャ実行

                        strExtension = ""
                    Case Else
                        'UNODNE:エラー
                        strExtension = ""
                End Select

                strPath = ""

                'バックアップ期限切れのファイル(XMLとCSV)を削除
                If strExtension <> "" Then
                    'バックアップフォルダが存在しない場合は処理を抜ける
                    If System.IO.Directory.Exists(.OUTPUT_PATH) = False Then
                        Return False
                    End If

                    '通信モジュールの受信フォルダ以下の対象ファイル一覧を取得
                    Dim files As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                            .OUTPUT_PATH, "*" & strExtension, System.IO.SearchOption.AllDirectories)

                    For Each file In files
                        Dim f As New System.IO.FileInfo(file)
                        If Val(.BACKUP_TERM) = 0 Then
                            '無期限に設定されているため、削除しない
                        Else
                            '設定されたバックアップ日数以上経過したファイルは削除する
                            If dtNow.Subtract(f.CreationTime).Days > .BACKUP_TERM Then
                                Try
                                    f.Delete()
                                    intCount += 1
                                Catch ex As System.IO.IOException
                                    '対象ファイルを開いている
                                Catch ex As System.Security.SecurityException
                                    'アクセス権限がない(作成時にはあった権限が失われた)
                                Catch ex As System.UnauthorizedAccessException
                                    'フォルダパスを指定された…あり得ない
                                End Try
                            End If
                        End If
                    Next file

                    If intCount > 0 Then
                        WL.WriteLogDat(String.Format("バックアップ期限切れ受信ファイルを{0}件削除しました。", intCount))
                    End If
                End If
            End With

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        End Try
    End Function
#End Region

#Region "   ファイル作成処理"
    ''' <summary>
    ''' ファイル作成処理
    ''' </summary>
    ''' <param name="entities">ファイル出力編成情報</param>
    ''' <returns></returns>
    Private Function FunMakeFile(ByVal entities As List(Of JTB_RECVFILE_JO_Model)) As Boolean
        Dim DB As clsDbUtility = Nothing
        Dim sbSQL As New System.Text.StringBuilder
        Dim ITEMFORMAT As List(Of JTB_FILE_ITEMFORMAT_Model)
        Dim dsList As New System.Data.DataSet
        Dim HISSU_KM_List As New List(Of Integer)
        Dim ngcolList As New List(Of String)
        Dim strOutputErrorRecvFileList As New List(Of String)
        Dim ErrorMailDetailFieldList As New List(Of ST_ErrorMailDetailFields)
        Dim strErrorDetail As String = ""
        Dim strLASTIMP_YMDHNS As String = ""
        Dim strRefObject_Name As String = "" '参照オブジェクト名(ビュー、テーブル値関数…実パラメータ含む)

        Dim strExtension As String
        Dim intRET As Integer
        Dim strFileName As String
        Dim dtNow As DateTime
        Dim tblBUFF As DataTable = Nothing

        Dim strLAST_RECV_YMDHNS As String


        Try
            'DBに接続
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

            'エラーメール用項目リストを取得
            ErrorMailDetailFieldList = FunGetOutputErrorMail_DetailFieldList(DB)

            For Each entity In entities
                'テキストデータ格納用配列
                Dim strDATA As String()

                Try
                    '----------初期化----------
                    'トランザクションフラグ
                    intRET = ENM_TRANSACTION_STATUS._1_COMMIT

                    'トランザクション開始
                    DB.BeginTransaction()

                    'システム日時を取得
                    dtNow = FunGetSysDate(DB)

                    '
                    strLASTIMP_YMDHNS = dtNow.ToString("yyyyMMddHHmmss")

                    '
                    strLAST_RECV_YMDHNS = ""

                    '必須項目チェック用
                    HISSU_KM_List.Clear()

                    dsList = Nothing

                    'エラーメール詳細
                    strErrorDetail = ""
                    strRefObject_Name = ""
                    '----------初期化----------


                    'ファイル編成項目設定情報を抽出
                    ITEMFORMAT = pri_JTB_FILE_ITEMFORMAT_Entities.ToList(DB, entity.FILE_ID)


                    If ITEMFORMAT.Count = 0 Then
                        'エラーログ マスタ未登録
                        Dim strMsg As String = "ファイル編成項目設定情報が未登録です。" & vbCrLf & "自動作成処理を停止します。"
                        FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "ファイルID=" & entity.FILE_ID & " " & "ファイル名=" & entity.FILE_NM)
                        Call FunUpdateAutoMakeFlg(DB, entity.FILE_ID)
                        intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                        Continue For
                    End If

                    '必須項目のインデックスリストを作成
                    For i As Integer = 0 To ITEMFORMAT.Count - 1
                        If ITEMFORMAT(i).HISSU_FLG = "1" Then '
                            HISSU_KM_List.Add(ITEMFORMAT(i).ITEM_RENBAN)
                        End If
                    Next i
                    HISSU_KM_List.Sort()

                    'エラーメール用 参照オブジェクト名(パラメータ)
                    strRefObject_Name = entity.REF_OBJECT_NM.Replace("LASTIMP_YMDHNS", "'" & Nz(entity.LASTIMP_YMDHNS.Trim, "00000000000000") & "'")

                    'データ抽出SQLを作成
                    Dim strSQL As String = FunMakeSELECT_SQL(DB, entity, ITEMFORMAT, ErrorMailDetailFieldList)

                    '出力データの検索
                    Dim SQLEx As New Exception
                    dsList = DB.GetDataSet(strSQL, True, SQLEx)

                    'SQLが不正な場合　エラーメールを送信し、自動作成を停止する(停止しないと10秒ごとにメールが…)
                    If dsList Is Nothing Then
                        '自動作成フラグを無効=0に更新
                        Call FunUpdateAutoMakeFlg(DB, entity.FILE_ID)
                        Dim sbMsg As New System.Text.StringBuilder
                        Dim sbMsgDetail As New System.Text.StringBuilder

                        sbMsg.Remove(0, sbMsg.Length)
                        sbMsg.Append("参照オブジェクトからデータの取得に失敗しました。" & vbCrLf)
                        sbMsg.Append("該当ファイルIDのファイル自動作成処理を停止しました。" & vbCrLf)
                        sbMsg.Append("ファイル出力編成情報(JTB_RECVFILE_JO)および、" & vbCrLf)
                        sbMsg.Append("ファイル編成項目設定情報(JTB_FILE_ITEMFORMAT)を確認して下さい。" & vbCrLf)
                        sbMsg.Append(vbCrLf)
                        sbMsg.Append("ファイルID：" & entity.FILE_ID & vbCrLf)
                        sbMsg.Append("ファイル出力編成名：" & entity.FILE_NM & vbCrLf)
                        sbMsg.Append("参照オブジェクト名：" & strRefObject_Name & vbCrLf)
                        If entity.WHERE_EXPRESSION.Trim <> "" Then
                            sbMsg.Append("Where条件：" & entity.WHERE_EXPRESSION & vbCrLf)
                        Else
                            sbMsg.Append("Where条件：なし" & vbCrLf)
                        End If

                        sbMsgDetail.Remove(0, sbMsgDetail.Length)
                        If SQLEx IsNot Nothing Then
                            sbMsgDetail.Append(SQLEx.Message & vbCrLf & vbCrLf)
                        End If
                        sbMsgDetail.Append(strSQL)

                        'エラーメール送信
                        Call FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, sbMsg.ToString, sbMsgDetail.ToString)
                        intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                        Continue For
                    Else
                        With dsList.Tables(0)
                            If .Rows.Count > 0 Then
                                '-----必須項目のチェック
                                Dim sbErrorDetail As New System.Text.StringBuilder
                                For row As Integer = 0 To .Rows.Count - 1
                                    '必須項目のうち、存在しない項目の一覧を取得
                                    ngcolList.Clear()
                                    For Each RENBAN As Integer In HISSU_KM_List
                                        If dsList.Tables(0).Rows(row).Item(RENBAN - 1).ToString.Trim = "" Then
                                            ngcolList.Add(ITEMFORMAT(RENBAN - 1).ITEM_NM)
                                        End If
                                    Next RENBAN

                                    '必須項目が存在しないデータについて、エラーメール用詳細情報の項目値を取得
                                    If ngcolList.Count > 0 Then
                                        'エラーメール詳細項目に追加
                                        Dim strFieldValues As String = ""
                                        For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                            If strFieldValues = "" Then
                                                strFieldValues &= .Rows(row).Item("EM" & ele.No.ToString("00")).ToString.Trim
                                            Else
                                                strFieldValues &= "," & .Rows(row).Item("EM" & ele.No.ToString("00")).ToString.Trim
                                            End If
                                        Next ele
                                        If strFieldValues <> "" Then
                                            sbErrorDetail.Append(strFieldValues & vbCrLf)
                                        Else
                                            'エラーメール詳細情報出力項目が登録されていない
                                        End If

                                        '出力エラーデータが格納された受信ファイルの一覧を取得(OUTPUTERRORFILE_JOの追加処理にて使用 再出力処理用)
                                        If strOutputErrorRecvFileList.Contains(.Rows(row).Item("WK_FILE_NM").ToString.Trim) = False Then
                                            strOutputErrorRecvFileList.Add(.Rows(row).Item("WK_FILE_NM").ToString.Trim)
                                        End If

                                        '今回の処理でファイル出力に失敗したデータ中で最も古い受信処理日時を記憶(OUTPUTERRORFILE_JOの追加処理にて使用 再出力処理用)
                                        'ファイル再作成処理のデータ抽出条件にて使用する WHERE RECV_YMDHNS <= strLASTIMP_YMDHNS
                                        If strLASTIMP_YMDHNS > .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim Then
                                            strLASTIMP_YMDHNS = .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim
                                        End If
                                    Else
                                        '必須項目が全て存在する = チェックOK
                                    End If

                                    '今回の処理でファイル出力されるデータ中で最後に受信された処理日時を記憶(RECVFILE_JOの更新処理にて使用 次回のファイル作成処理にて使用)
                                    If strLAST_RECV_YMDHNS < .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim Then
                                        strLAST_RECV_YMDHNS = .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim
                                    End If
                                Next row


                                'エラーメール詳細情報用のフィールドを削除
                                tblBUFF = dsList.Tables(0)
                                For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                    tblBUFF.Columns.Remove("EM" & ele.No.ToString("00"))
                                Next ele
                                'プログラム内部処理用フィールドを削除
                                tblBUFF.Columns.Remove("WK_FILE_NM")
                                tblBUFF.Columns.Remove("WK_RENBAN")
                                tblBUFF.Columns.Remove("WK_RECV_YMDHNS")

                                If sbErrorDetail.Length > 0 Then
                                    'エラーメール詳細情報ヘッダ作成
                                    Dim sbErrorDetailHeadder As New System.Text.StringBuilder
                                    For Each detailField As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                        If sbErrorDetailHeadder.Length = 0 Then
                                            sbErrorDetailHeadder.Append(detailField.display_name)
                                        Else
                                            sbErrorDetailHeadder.Append("," & detailField.display_name)
                                        End If
                                    Next detailField

                                    '詳細情報作成
                                    strErrorDetail = sbErrorDetailHeadder.ToString & vbCrLf & sbErrorDetail.ToString

                                    'エラー発生時は次のファイルを処理
                                    intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                                    Continue For
                                End If
                            Else
                                '出力データが存在しない場合
                                intRET = ENM_TRANSACTION_STATUS._0_ROLLBACK
                                Continue For
                            End If
                        End With
                    End If


                    If entity.FILE_FORMAT = ENM_FILE_FORMAT._6_SP_ストアドプロシージャ実行 Then
                        'FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, ex.Message)
                        'ストアド実行処理
                        intRET = FunExecStoredFunction(DB, entity, ITEMFORMAT, dsList)
                        strFileName = " "
                    Else

                        '項目見出し作成
                        Dim sbHeader As New System.Text.StringBuilder
                        sbHeader.Remove(0, sbHeader.Length)
                        For i As Integer = 0 To ITEMFORMAT.Count - 2
                            sbHeader.Append(ITEMFORMAT(i).ITEM_NM & ",")
                        Next i
                        sbHeader.Append(ITEMFORMAT(ITEMFORMAT.Count - 1).ITEM_NM)

                        Select Case entity.FILE_FORMAT
                            Case "1" '固定長
                                strExtension = ".txt"

                                '固定長データ作成
                                strDATA = FunMakeTXTDATA(tblBUFF, ITEMFORMAT)

                            Case "2", "3", "4", "5"
                                strExtension = ".csv"

                                'CSVデータ作成
                                strDATA = FunMakeCSVDATA(tblBUFF, entity.FILE_FORMAT)

                            Case Else
                                'UNDONE: エラーログ出力
                                intRET = ENM_TRANSACTION_STATUS._0_ROLLBACK
                                Continue For
                        End Select

                        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

                        '-----ファイル出力-----
                        System.IO.Directory.CreateDirectory(entity.OUTPUT_PATH)
                        Do
                            '同名ファイルが存在する場合 別のファイルIDと出力ファイル名フォーマットが重複しており、同一処理日時で出力された場合
                            'システム処理日時の+1秒してファイル名を生成

                            'ファイル名作成
                            dtNow = dtNow.AddSeconds(1)
                            If entity.FILE_NM_FORMAT.Contains("[FILE_KB]") = True Then
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT.Replace("[FILE_KB]", ""))
                                strFileName = entity.FILE_KB & strFileName & strExtension
                            ElseIf entity.FILE_NM_FORMAT.Contains("[FILE_NM]") = True Then
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT.Replace("[FILE_NM]", ""))
                                strFileName = entity.FILE_NM & strFileName & strExtension
                            Else
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT) & strExtension
                            End If

                        Loop While System.IO.File.Exists(pub_PGINFO.strBackup_Path & strFileName)
                        System.IO.File.WriteAllLines(entity.OUTPUT_PATH & strFileName, strDATA, enc)
                    End If


                    'ファイル編成情報の最終作成ファイル名と処理日時を更新
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & JTB_RECVFILE_JO_Model.SourceTableName & " SET ")
                    sbSQL.Append(" LASTIMP_FILE_NM ='" & strFileName & "', ")
                    sbSQL.Append(" LASTIMP_YMDHNS ='" & strLAST_RECV_YMDHNS & "'") '今回の処理で出力したデータ中で最も新しい受信日時で更新する
                    sbSQL.Append(" WHERE FILE_ID=" & entity.FILE_ID & " ")
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)

                    'DEBUG: 動作ログ
                    WL.WriteLogDat(String.Format("ファイル出力完了:{0} {1} データ件数:{2}", entity.FILE_ID, entity.FILE_NM, dsList.Tables(0).Rows.Count))

                Finally
                    If strErrorDetail.Length > 0 Then
                        '出力エラーファイル格納テーブルにレコード追加
                        Call FunRegistErrorFile(DB, entity.FILE_ID, strOutputErrorRecvFileList, strLASTIMP_YMDHNS)
                        '出力エラーファイル格納フォルダに出力エラーデータの受信ファイルを出力
                        Call FunMoveOUTPUT_ERROR_FILE(strOutputErrorRecvFileList)
                        'Mod End

                        'エラーメール送信
                        Call FunSendErrorMailofFileMake(entity, strRefObject_Name, strErrorDetail, tblBUFF)

                        'DEBUG: 動作ログ
                        WL.WriteLogDat(String.Format("ファイル出力失敗:{0} {1} データ件数:{2}", entity.FILE_ID, entity.FILE_NM, dsList.Tables(0).Rows.Count))
                    End If

                    If intRET > 0 Then
                        'コミット
                        DB.Commit(True)
                    Else
                        'ロールバック
                        DB.Commit(False)
                    End If
                End Try
            Next entity

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "ファイルの作成処理に失敗しました。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, ex.Message)
            Return False
        Finally
            If dsList IsNot Nothing Then
                dsList.Dispose()
            End If

            If DB IsNot Nothing Then
                DB.Close()
            End If
        End Try
    End Function


    ''' <summary>
    ''' データ抽出SQL作成
    ''' </summary>
    ''' <param name="DB">DB接続</param>
    ''' <param name="entity">ファイル出力編成情報</param>
    ''' <param name="ITEMFORMAT">ファイル出力編成項目情報</param>
    ''' <param name="ErrorMailDetailFieldList">エラーメール用出力項目リスト</param>
    ''' <returns>SQL文字列</returns>
    Private Function FunMakeSELECT_SQL(ByRef DB As clsDbUtility,
                                       ByVal entity As JTB_RECVFILE_JO_Model,
                                       ByVal ITEMFORMAT As List(Of JTB_FILE_ITEMFORMAT_Model),
                                       ByVal ErrorMailDetailFieldList As List(Of ST_ErrorMailDetailFields)) As String

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbFields As New System.Text.StringBuilder
        Dim sbWhere As New System.Text.StringBuilder

        Dim strSkipFileList As List(Of String)

        Try
            sbSQL.Remove(0, sbSQL.Length)
            sbFields.Remove(0, sbFields.Length)
            sbWhere.Remove(0, sbWhere.Length)


            '最新の出力エラーファイルリスト取得
            pri_JTB_OUTPUT_ERROR_FILE_Entities.Load(DB)

            'ファイル出力項目を追加
            For i As Integer = 0 To ITEMFORMAT.Count - 1
                If sbFields.Length = 0 Then
                    sbFields.Append(String.Format("{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                Else
                    sbFields.Append(String.Format(",{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                End If
            Next i

            'エラーメールの明細情報用の項目を追加
            For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                sbFields.Append(String.Format(", {0} AS 'EM{1}'", ele.field_name, ele.No.ToString("00")))
            Next ele

            'プログラム内部処理用項目(受信ファイル名、連番、受信処理日時)を追加
            sbFields.Append(", FILE_NM AS WK_FILE_NM, RENBAN AS WK_RENBAN, RECV_YMDHNS AS WK_RECV_YMDHNS")

            With entity
                '前回最終作成日以降を対象とする条件を追加
                If .LASTIMP_YMDHNS.Trim <> "" Then
                    If sbWhere.Length = 0 Then
                        sbWhere.Append(" WHERE RECV_YMDHNS > '" & .LASTIMP_YMDHNS & "' ")
                    Else
                        sbWhere.Append(" AND RECV_YMDHNS > '" & .LASTIMP_YMDHNS & "' ")
                    End If
                End If

                'Where条件を追加
                If .WHERE_EXPRESSION <> "" Then
                    If sbWhere.Length = 0 Then
                        sbWhere.Append(" WHERE " & .WHERE_EXPRESSION)
                    Else
                        sbWhere.Append(" AND " & .WHERE_EXPRESSION)
                    End If
                End If

                '出力エラー受信ファイル一覧を取得
                strSkipFileList = pri_JTB_OUTPUT_ERROR_FILE_Entities.GetFILE_NMs(entity.FILE_ID)

                '出力エラー受信ファイル存在時　該当ファイルのデータを出力対象から除外
                For Each file As String In strSkipFileList
                    If sbWhere.Length = 0 Then
                        sbWhere.Append(" WHERE FILE_NM <> '" & file & "' ")
                    Else
                        sbWhere.Append(" AND FILE_NM <> '" & file & "' ")
                    End If
                Next file

                'SELECT SQLを作成
                sbSQL.Append("SELECT ")
                sbSQL.Append(sbFields)
                sbSQL.Append(" FROM " & .REF_OBJECT_NM.Replace("LASTIMP_YMDHNS", "'" & Nz(.LASTIMP_YMDHNS.Trim, "00000000000000") & "'") & "")
                sbSQL.Append(sbWhere)
                sbSQL.Append(" ORDER BY WK_FILE_NM, WK_RENBAN, WK_RECV_YMDHNS")
            End With

            Return sbSQL.ToString

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        End Try
    End Function

#End Region

#Region "   出力エラーファイル再作成処理"
    Private Function FunReMakeFile(ByVal entities As List(Of JTB_RECVFILE_JO_Model)) As Boolean
        Dim DB As clsDbUtility = Nothing
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbWhere As New System.Text.StringBuilder
        Dim sbWhereFile As New System.Text.StringBuilder
        Dim ITEMFORMAT As List(Of JTB_FILE_ITEMFORMAT_Model)
        Dim sbFields As New System.Text.StringBuilder
        Dim sbHeader As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet
        Dim HISSU_KMList As New List(Of Integer)
        Dim strErrorDetail As String = ""
        Dim strExtension As String

        Dim intRET As Integer

        Dim strFileName As String
        Dim dtNow As DateTime

        Dim ngcolList As List(Of String)
        Dim strDetail As String = ""

        Dim strReMakeFileList As New List(Of String)
        Dim strOutputErrorRecvFileList As New List(Of String)

        Dim ErrorMailDetailFieldList As New List(Of ST_ErrorMailDetailFields)
        Dim tblBUFF As DataTable = Nothing
        Dim strLASTIMP_YMDHNS_RE_INPUT As String = ""
        Dim strLAST_RECV_YMDHNS As String

        Dim strRefObject_Name As String = ""
        Try
            'DBに接続
            DB = New clsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)


            '2016.10.24 Add 最新の出力エラーファイルリスト取得
            pri_JTB_OUTPUT_ERROR_FILE_Entities.Load(DB)

            'エラーメール明細項目リストを取得
            ErrorMailDetailFieldList = FunGetOutputErrorMail_DetailFieldList(DB)

            For Each entity In entities
                'テキストデータ格納用配列
                Dim strDATA As String()

                Try
                    '----------初期化----------
                    'トランザクションフラグ
                    intRET = ENM_TRANSACTION_STATUS._1_COMMIT

                    'トランザクション開始
                    DB.BeginTransaction()

                    'システム日時を取得
                    dtNow = FunGetSysDate(DB)

                    '必須項目チェック用
                    HISSU_KMList.Clear()

                    dsList = Nothing
                    strDetail = ""
                    strLAST_RECV_YMDHNS = ""
                    '----------初期化----------


                    'ファイル編成項目設定情報を抽出
                    ITEMFORMAT = pri_JTB_FILE_ITEMFORMAT_Entities.ToList(DB, entity.FILE_ID)


                    If ITEMFORMAT.Count = 0 Then
                        'エラーログ マスタ未登録
                        Dim strMsg As String = "ファイル編成項目設定情報が未登録です。" & vbCrLf & "自動作成処理を停止します。"
                        FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "ファイルID=" & entity.FILE_ID & " " & "ファイル名=" & entity.FILE_NM)
                        Call FunUpdateAutoMakeFlg(DB, entity.FILE_ID)
                        intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                        Continue For
                    End If

                    '必須項目のインデックスリストを作成
                    For i As Integer = 0 To ITEMFORMAT.Count - 1
                        If ITEMFORMAT(i).HISSU_FLG = "1" Then '
                            HISSU_KMList.Add(ITEMFORMAT(i).ITEM_RENBAN)
                        End If
                    Next i
                    HISSU_KMList.Sort()


                    'エラーメール用 参照オブジェクト名(パラメータ)
                    strRefObject_Name = entity.REF_OBJECT_NM.Replace("LASTIMP_YMDHNS", "'" & Nz(entity.LASTIMP_YMDHNS.Trim, "00000000000000") & "'")


                    '-----データ抽出文を生成
                    sbFields.Remove(0, sbFields.Length)
                    For i As Integer = 0 To ITEMFORMAT.Count - 1
                        If sbFields.Length = 0 Then
                            sbFields.Append(String.Format("{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                        Else
                            sbFields.Append(String.Format(",{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                        End If
                    Next i


                    '2016.10.26 Add エラー通知メールの追加情報用の項目を追加
                    For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                        sbFields.Append(String.Format(", {0} AS 'EM{1}'", ele.field_name, ele.No.ToString("00")))
                    Next ele

                    sbFields.Append(", FILE_NM AS WK_FILE_NM, RENBAN AS WK_RENBAN, RECV_YMDHNS AS WK_RECV_YMDHNS ")

                    With entity

                        '未処理エラーファイルリストの出力時刻を取得
                        strLASTIMP_YMDHNS_RE_INPUT = pri_JTB_OUTPUT_ERROR_FILE_Entities.GetLASTIMP_YMDHNS(entity.FILE_ID)

                        '2017.07.12 Add 対象ファイル編成IDの未処理エラーファイルリストが存在しない
                        If strLASTIMP_YMDHNS_RE_INPUT = "" Then
                            '次のファイル編成IDへ
                            Continue For
                        End If

                        sbSQL.Remove(0, sbSQL.Length)
                        sbWhere.Remove(0, sbWhere.Length)
                        sbSQL.Append("SELECT ")
                        sbSQL.Append(sbFields)
                        sbSQL.Append(" FROM " & strRefObject_Name & "")

                        '最終出力日時条件は除外
                        'If .LASTIMP_YMDHNS.Trim <> "" Then
                        '    sbWhere.Append(" WHERE RECV_YMDHNS > '" & .LASTIMP_YMDHNS & "' ")
                        'End If
                        If .WHERE_EXPRESSION <> "" Then
                            If sbWhere.Length = 0 Then
                                sbWhere.Append(" WHERE " & .WHERE_EXPRESSION)
                            Else
                                sbWhere.Append(" AND " & .WHERE_EXPRESSION)
                            End If
                        End If

                        '2017.07.12 Mod 引数追加 対象ファイルIDの受信ファイル名のみ条件に追加
                        '2016.10.24 Add 出力エラーファイル存在時　出力処理に該当受信ファイル名のデータを出力対象データから除外
                        'strReMakeFileList = pri_OUTPUT_ERROR_FILE_DataContext.GetFILE_NMs(entity.FILE_ID)
                        strReMakeFileList = FunGetReMakeTargetFileList(DB, entity.FILE_ID)
                        If strReMakeFileList.Count > 0 Then
                            If sbWhere.Length = 0 Then
                                sbWhere.Append("WHERE (")
                            Else
                                sbWhere.Append("AND (")
                            End If
                            sbWhereFile.Remove(0, sbWhereFile.Length)
                            For Each file As String In strReMakeFileList
                                If sbWhereFile.Length > 0 Then
                                    sbWhereFile.Append("OR FILE_NM = '" & file & "' ")
                                Else
                                    sbWhereFile.Append(" FILE_NM = '" & file & "' ")
                                End If
                            Next file

                            sbSQL.Append(sbWhere)
                            sbSQL.Append(sbWhereFile)
                            sbSQL.Append(")")
                            sbSQL.Append(" ORDER BY WK_FILE_NM, WK_RENBAN")
                        Else
                            '再作成実行対象ファイルが存在しない場合 再作成全体の処理を中断する
                            Return False
                        End If
                    End With
                    '-----データ抽出文を生成

                    Dim SQLEx As New Exception
                    dsList = DB.GetDataSet(sbSQL.ToString, True, SQLEx)

                    If dsList Is Nothing Then
                        'SQLが不正な場合　通知メールを送信し、自動作成を停止する(停止しないと10秒ごとにメールが…)
                        Call FunUpdateAutoMakeFlg(DB, entity.FILE_ID)
                        Dim sbMsg As New System.Text.StringBuilder
                        Dim sbMsgDetail As New System.Text.StringBuilder

                        sbMsg.Remove(0, sbMsg.Length)
                        sbMsg.Append("参照オブジェクトからデータの取得に失敗しました。" & vbCrLf)
                        sbMsg.Append("該当ファイルIDのファイル自動作成処理を停止しました。" & vbCrLf)
                        sbMsg.Append("ファイル出力編成情報(JTB_RECVFILE_JO)および、" & vbCrLf)
                        sbMsg.Append("ファイル編成項目設定情報(JTB_FILE_ITEMFORMAT)を確認して下さい。" & vbCrLf)
                        sbMsg.Append(vbCrLf)
                        sbMsg.Append("ファイルID：" & entity.FILE_ID & vbCrLf)
                        sbMsg.Append("ファイル出力編成名：" & entity.FILE_NM & vbCrLf)
                        sbMsg.Append("参照オブジェクト名：" & strRefObject_Name & vbCrLf)
                        If entity.WHERE_EXPRESSION.Trim <> "" Then
                            sbMsg.Append("Where条件：" & entity.WHERE_EXPRESSION & vbCrLf)
                        Else
                            sbMsg.Append("Where条件：なし" & vbCrLf)
                        End If

                        sbMsgDetail.Remove(0, sbMsgDetail.Length)
                        If SQLEx IsNot Nothing Then
                            sbMsgDetail.Append(SQLEx.Message & vbCrLf & vbCrLf)
                        End If
                        sbMsgDetail.Append(sbSQL.ToString)

                        'エラーメール送信
                        Call FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, sbMsg.ToString, sbMsgDetail.ToString)
                        intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                        Continue For
                    End If


                    '必須項目のチェック
                    With dsList.Tables(0)
                        If .Rows.Count > 0 Then
                            '-----必須項目のチェック
                            Dim sbErrorDetail As New System.Text.StringBuilder
                            For row As Integer = 0 To .Rows.Count - 1
                                ngcolList = New List(Of String)
                                For Each RENBAN As Integer In HISSU_KMList
                                    If dsList.Tables(0).Rows(row).Item(RENBAN - 1).ToString.Trim = "" Then
                                        '必須項目のうち、存在しない項目がある場合
                                        ngcolList.Add(ITEMFORMAT(RENBAN - 1).ITEM_NM)
                                    End If
                                Next RENBAN

                                '必須項目が存在しないデータについて、エラーメール用詳細情報の項目値を取得
                                If ngcolList.Count > 0 Then
                                    'エラーメール詳細項目に追加
                                    Dim strFieldValues As String = ""
                                    For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                        If strFieldValues = "" Then
                                            strFieldValues &= .Rows(row).Item("EM" & ele.No.ToString("00")).ToString.Trim
                                        Else
                                            strFieldValues &= "," & .Rows(row).Item("EM" & ele.No.ToString("00")).ToString.Trim
                                        End If
                                    Next ele
                                    If strFieldValues <> "" Then
                                        sbErrorDetail.Append(strFieldValues & vbCrLf)
                                    Else
                                        'エラーメール詳細情報出力項目が登録されていない
                                    End If

                                    '再出力処理用に、エラーデータ受信ファイル
                                    If strOutputErrorRecvFileList.Contains(.Rows(row).Item("WK_FILE_NM").ToString.Trim) = False Then
                                        strOutputErrorRecvFileList.Add(.Rows(row).Item("WK_FILE_NM").ToString.Trim)
                                    End If
                                End If

                                '今回の処理でファイル出力されるデータ中で最後に受信された処理日時を記憶(RECVFILE_JOの更新処理にて使用 次回のファイル作成処理にて使用)
                                If strLAST_RECV_YMDHNS < .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim Then
                                    strLAST_RECV_YMDHNS = .Rows(row).Item("WK_RECV_YMDHNS").ToString.Trim
                                End If

                            Next row


                            '2016.10.26 Add エラーメール用の列を削除
                            tblBUFF = dsList.Tables(0)
                            For Each ele As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                tblBUFF.Columns.Remove("EM" & ele.No.ToString("00"))
                            Next ele
                            'プログラム内部処理用フィールドを削除
                            tblBUFF.Columns.Remove("WK_FILE_NM")
                            tblBUFF.Columns.Remove("WK_RENBAN")
                            tblBUFF.Columns.Remove("WK_RECV_YMDHNS")

                            If sbErrorDetail.Length > 0 Then
                                'エラーメール詳細情報ヘッダ作成
                                Dim sbErrorDetailHeadder As New System.Text.StringBuilder
                                For Each detailField As ST_ErrorMailDetailFields In ErrorMailDetailFieldList.OrderBy(Function(p) p.No)
                                    If sbErrorDetailHeadder.Length = 0 Then
                                        sbErrorDetailHeadder.Append(detailField.display_name)
                                    Else
                                        sbErrorDetailHeadder.Append("," & detailField.display_name)
                                    End If
                                Next detailField

                                '詳細情報作成
                                strErrorDetail = sbErrorDetailHeadder.ToString & vbCrLf & sbErrorDetail.ToString

                                'エラー発生時は次のファイルを処理
                                intRET = ENM_TRANSACTION_STATUS._1_COMMIT
                                Continue For
                            End If
                        Else
                            '出力データが存在しない場合
                            intRET = ENM_TRANSACTION_STATUS._0_ROLLBACK
                            Continue For
                        End If
                    End With

                    If entity.FILE_FORMAT = ENM_FILE_FORMAT._6_SP_ストアドプロシージャ実行 Then

                        'ストアド実行処理
                        intRET = FunExecStoredFunction(DB, entity, ITEMFORMAT, dsList)
                    Else

                        '項目見出し作成
                        sbHeader.Remove(0, sbHeader.Length)
                        For i As Integer = 0 To ITEMFORMAT.Count - 2
                            sbHeader.Append(ITEMFORMAT(i).ITEM_NM & ",")
                        Next i
                        sbHeader.Append(ITEMFORMAT(ITEMFORMAT.Count - 1).ITEM_NM)

                        Select Case entity.FILE_FORMAT
                            Case "1" '固定長
                                strExtension = ".txt"

                                '固定長データ作成
                                strDATA = FunMakeTXTDATA(tblBUFF, ITEMFORMAT)

                            Case "2", "3", "4", "5"
                                strExtension = ".csv"

                                'CSVデータ作成
                                strDATA = FunMakeCSVDATA(tblBUFF, entity.FILE_FORMAT)

                            Case Else
                                'UNDONE: エラーログ出力
                                intRET = -1
                                Continue For
                        End Select

                        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

                        '-----ファイル出力-----
                        System.IO.Directory.CreateDirectory(entity.OUTPUT_PATH)
                        Do
                            '同名ファイルが存在する場合 別のファイルIDと出力ファイル名フォーマットが重複しており、同一処理日時で出力された場合
                            'システム処理日時の+1秒してファイル名を生成

                            'ファイル名作成
                            dtNow = dtNow.AddSeconds(1)
                            If entity.FILE_NM_FORMAT.Contains("[FILE_KB]") = True Then
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT.Replace("[FILE_KB]", ""))
                                strFileName = entity.FILE_KB & strFileName & strExtension
                            ElseIf entity.FILE_NM_FORMAT.Contains("[FILE_NM]") = True Then
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT.Replace("[FILE_NM]", ""))
                                strFileName = entity.FILE_NM & strFileName & strExtension
                            Else
                                strFileName = dtNow.ToString(entity.FILE_NM_FORMAT) & strExtension
                            End If

                        Loop While System.IO.File.Exists(pub_PGINFO.strBackup_Path & strFileName)
                        System.IO.File.WriteAllLines(entity.OUTPUT_PATH & strFileName, strDATA, enc)

                        '出力エラーファイル情報から出力成功したファイルを削除
                        sbSQL.Remove(0, sbSQL.Length)
                        sbWhereFile.Remove(0, sbWhereFile.Length)
                        sbSQL.Append("DELETE FROM " & JTB_OUTPUT_ERROR_FILE_Model.SourceTableName & " ")
                        For Each file As String In strReMakeFileList
                            If sbWhereFile.Length = 0 Then
                                sbWhereFile.Append(" WHERE FILE_NM ='" & file & "' ")
                            Else
                                sbWhereFile.Append(" OR FILE_NM ='" & file & "' ")
                            End If

                            'ファイル削除
                            'System.IO.File.Delete(pub_PGINFO.strRE_OUTPUT_Exec_Path & file)
                        Next
                        sbSQL.Append(sbWhereFile)

                        'SQL実行
                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
                        If intRET = 0 Then
                            'UNDONE: エラーログ出力
                        End If

                        '2016.11.03 
                        Dim dsList2 As DataSet
                        Dim strYMDHNS As String
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("SELECT LASTIMP_YMDHNS FROM " & JTB_RECVFILE_JO_Model.SourceTableName & " ")
                        sbSQL.Append(" WHERE FILE_ID=" & entity.FILE_ID & " ")
                        dsList2 = DB.GetDataSet(sbSQL.ToString, True, SQLEx)
                        If dsList2.Tables(0).Rows.Count > 0 Then
                            strYMDHNS = dsList2.Tables(0).Rows(0).Item(0).ToString
                        Else
                            'UNDONE: エラー
                            'ブランクはありえない
                            strYMDHNS = ""
                        End If
                        If strYMDHNS < strLAST_RECV_YMDHNS Then
                            '再出力対象データの最新受信日時<出力済みの最新受信日時…エラー発生後、一度も出力していない場合
                            '出力設定の最新受信日時を更新
                            sbSQL.Remove(0, sbSQL.Length)
                            sbSQL.Append("UPDATE " & JTB_RECVFILE_JO_Model.SourceTableName & " SET ")
                            sbSQL.Append(" LASTIMP_FILE_NM ='" & strFileName & "', ")
                            'sbSQL.Append(" LASTIMP_YMDHNS ='" & dtNow.ToString("yyyyMMddHHmmss") & "'")
                            sbSQL.Append(" LASTIMP_YMDHNS ='" & strLAST_RECV_YMDHNS & "'") '2016.11.02
                            sbSQL.Append(" WHERE FILE_ID=" & entity.FILE_ID & " ")
                            'SQL実行
                            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
                        End If
                    End If

                Finally
                    '出力エラーが発生していた場合、エラーログテーブルに出力
                    If strErrorDetail.Length > 0 Then
                        '出力エラーファイル格納テーブルにレコード追加
                        Call FunRegistErrorFile(DB, entity.FILE_ID, strOutputErrorRecvFileList, strLASTIMP_YMDHNS_RE_INPUT)
                        '出力エラーファイル格納フォルダに出力エラーデータの受信ファイルを出力
                        Call FunMoveOUTPUT_ERROR_FILE(strOutputErrorRecvFileList)
                        'Mod End

                        'エラーメール送信
                        Call FunSendErrorMailofFileMake(entity, strRefObject_Name, strErrorDetail, tblBUFF)
                        WL.WriteLogDat(String.Format("ファイル再出力失敗:{0} {1} データ件数:{2}", entity.FILE_ID, entity.FILE_NM, dsList.Tables(0).Rows.Count))
                    End If

                    For Each file As String In strReMakeFileList
                        '再作成実行フォルダのファイル削除
                        System.IO.File.Delete(pub_PGINFO.strRE_OUTPUT_Exec_Path & file)
                    Next

                    If intRET > 0 Then
                        'コミット
                        DB.Commit(True)
                    Else
                        'ロールバック
                        DB.Commit(False)
                    End If
                End Try
            Next entity

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Dim strMsg As String = "ファイル再作成に失敗しました。"
            FunErrorSyori(ENM_ERR_KB._9_その他例外エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]")
            Return False
        Finally
            If dsList IsNot Nothing Then
                dsList.Dispose()
            End If

            If DB IsNot Nothing Then
                DB.Close()
            End If
        End Try
    End Function
#End Region

#Region "   出力エラーファイル再作成対象出力設定取得"
    Private Function FunGetFileRemakeTargetEntities() As List(Of JTB_RECVFILE_JO_Model)
        Dim _entities As New List(Of JTB_RECVFILE_JO_Model)

        Try


            Return _entities
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function
#End Region

#Region "エラー通知メール送信"

    ''' <summary>
    ''' エラー通信メール送信(ファイル出力処理)
    ''' </summary>
    ''' <param name="entity">ファイル出力設定</param>
    ''' <param name="strDetail">エラー明細</param>
    ''' <param name="dsList">エラー発生時データリスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunSendErrorMailofFileMake(ByVal entity As JTB_RECVFILE_JO_Model, ByVal strRefObject_Name As String, ByVal strDetail As String, ByVal dsList As DataTable) As Boolean
        Dim sbMsg As New System.Text.StringBuilder
        Dim strDATA As String()
        Dim strFileName As String

        Try
            sbMsg.Remove(0, sbMsg.Length)
            sbMsg.Append("必須項目が不足しているデータが存在します。" & vbCrLf)
            sbMsg.Append("ファイル出力編成情報(JTB_RECVFILE_JO)および、" & vbCrLf)
            sbMsg.Append("ファイル出力編成項目情報(JTB_FILE_ITEMFORMAT)を確認して下さい。" & vbCrLf)
            sbMsg.Append(vbCrLf)
            sbMsg.Append("ファイルID：" & entity.FILE_ID & vbCrLf)
            sbMsg.Append("ファイル出力編成名：" & entity.FILE_NM & vbCrLf)
            sbMsg.Append("参照オブジェクト名：" & strRefObject_Name & vbCrLf)
            If entity.WHERE_EXPRESSION.Trim <> "" Then
                sbMsg.Append("Where条件：" & entity.WHERE_EXPRESSION & vbCrLf)
            Else
                sbMsg.Append("Where条件：なし" & vbCrLf)
            End If
            sbMsg.Append(vbCrLf)

            '読み込みデータをCSVファイルに変換
            strDATA = FunMakeCSVDATA(dsList, pub_PGINFO.intCSVFILE_FORMAT)
            'ファイル出力
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            strFileName = entity.FILE_NM & ".csv"

            If System.IO.Directory.Exists(pub_PGINFO.strReRecv_Path) = False Then
                System.IO.Directory.CreateDirectory(pub_PGINFO.strReRecv_Path)
            End If

            System.IO.File.WriteAllLines(pub_PGINFO.strReRecv_Path & strFileName, strDATA, enc)

            Dim list As New List(Of String)
            list.Add(pub_PGINFO.strReRecv_Path & strFileName)

            'エラーログ出力とエラーメール送信
            FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, sbMsg.ToString, strDetail, list)

            Try
                System.IO.File.Delete(pub_PGINFO.strReRecv_Path & strFileName)
            Catch ex As System.IO.IOException
            Catch ex As Exception
                '    Throw
            End Try

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "   固定長ファイル作成"
    Private Function FunMakeTXTDATA(ByVal dt As DataTable, ByVal ITEM_FORMAT As List(Of JTB_FILE_ITEMFORMAT_Model)) As String()
        Dim strDATA As String()
        Dim strBUFF As String
        Dim str As String

        Dim intBUFF As Integer

        Try

            '配列用意
            ReDim strDATA(0 To dt.Rows.Count - 1)

            'データ書込み
            For intRow As Integer = 0 To dt.Rows.Count - 1
                strBUFF = ""
                For intCol As Integer = 0 To dt.Columns.Count - 1
                    str = dt.Rows(intRow).Item(intCol).ToString

                    intBUFF = ITEM_FORMAT(intCol).ITEM_LEN - System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str)
                    strBUFF &= str & Space(intBUFF)

                    'strBUFF &= str.PadRight(ITEM_FORMAT(intCol).ITEM_LEN)
                Next intCol

                strDATA(intRow) = strBUFF
            Next intRow

            Return strDATA
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        Finally

        End Try

    End Function

#End Region

#Region "   CSVファイル作成"
    Private Function FunMakeCSVDATA(ByVal dt As DataTable, ByVal intFILE_FORMAT As Integer) As String()
        Dim strDATA As String()
        Dim strBUFF As String
        Dim str As String

        Dim blnHeader As Boolean
        Dim blnQuotation As Boolean
        Dim intBUFF As Integer
        Try
            Select Case intFILE_FORMAT
                Case ENM_FILE_FORMAT._2_CSV_見出し無_クォーテーション無
                    blnHeader = False
                    blnQuotation = False
                Case ENM_FILE_FORMAT._3_CSV_見出し無_クォーテーション有
                    blnHeader = False
                    blnQuotation = True
                Case ENM_FILE_FORMAT._4_CSV_見出し有_クォーテーション無
                    blnHeader = True
                    blnQuotation = False
                Case ENM_FILE_FORMAT._5_CSV_見出し有_クォーテーション有
                    blnHeader = True
                    blnQuotation = True
                Case Else
                    blnHeader = False
                    blnQuotation = False
            End Select

            'ヘッダ書込み
            If blnHeader = True Then
                '配列用意
                ReDim strDATA(0 To dt.Rows.Count)

                strBUFF = ""
                For intCOL = 0 To dt.Columns.Count - 1
                    If blnQuotation = True Then
                        strBUFF = strBUFF & """" & dt.Columns(intCOL).ColumnName.ToString.Replace(vbCrLf, "") & ""","
                    Else
                        strBUFF = strBUFF & dt.Columns(intCOL).ColumnName.ToString.Replace(vbCrLf, "") & ","
                    End If
                Next
                'レコード末尾のカンマを取り除く
                strBUFF = strBUFF.Remove(strBUFF.Length - 1)

                'ヘッダ行をセット
                strDATA(0) = strBUFF
                intBUFF = 1
            Else
                '配列用意
                ReDim strDATA(0 To dt.Rows.Count - 1)
            End If

            'データ書込み
            For intRow As Integer = 0 To dt.Rows.Count - 1
                strBUFF = ""
                For intCol As Integer = 0 To dt.Columns.Count - 1
                    'レコード値に"が含まれている場合はエスケープ文字を追加する
                    str = dt.Rows(intRow).Item(intCol).ToString
                    If str.Contains("""") = True Then
                        str = str.Replace("""", """""")
                    End If
                    If blnQuotation = True Then
                        strBUFF &= """" & str & """," 'クォーテーション括り有
                    Else
                        strBUFF &= "" & str & "," 'クォーテーション括り無
                    End If
                Next intCol

                'レコード末尾
                strBUFF = strBUFF.Remove(strBUFF.Length - 1)

                strDATA(intRow + intBUFF) = strBUFF '項目見出し有時は2番目のインデックスからセット
            Next intRow

            Return strDATA
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        Finally

        End Try

    End Function

#End Region

#Region "   受注実績データ転送ストアド実行"
    Private Function FunExecStoredFunction(ByRef DB As clsDbUtility, ByVal entity As JTB_RECVFILE_JO_Model, ByVal ITEMFORMAT As List(Of JTB_FILE_ITEMFORMAT_Model), ByVal dsList As DataSet) As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbFields As New System.Text.StringBuilder
        'Dim intRET As Integer
        Dim blnRET As Boolean

        Try
            Dim dbTypeDictionary As New Dictionary(Of String, DbType)

            'データ抽出文およびデータ型リストを生成
            sbFields.Remove(0, sbFields.Length)
            For i As Integer = 0 To ITEMFORMAT.Count - 1

                If sbFields.Length = 0 Then
                    sbFields.Append(String.Format("{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                Else
                    sbFields.Append(String.Format(",{0} AS '{1}'", ITEMFORMAT(i).ITEM_FORMAT, ITEMFORMAT(i).ITEM_NM))
                End If

                If ITEMFORMAT(i).ITEM_LEN = 0 Then
                    '数値型
                    dbTypeDictionary(ITEMFORMAT(i).ITEM_NM) = DbType.Int32
                Else
                    '文字列型
                    dbTypeDictionary(ITEMFORMAT(i).ITEM_NM) = DbType.String
                End If
            Next i
            'sbFields.Append(ITEMFORMAT(ITEMFORMAT.Count - 1).ITEM_FORMAT)

            'まとめて
            blnRET = Fun_blnStoredProc(DB, entity.OUTPUT_PATH.Replace("\", ""), dsList, dbTypeDictionary)
            Return ENM_TRANSACTION_STATUS._1_COMMIT

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        End Try
    End Function

    Private Function Fun_blnStoredProc(ByRef DB As clsDbUtility, ByVal strStoredProcName As String, ByVal datarow As DataRow, ByVal dbTypeDictionary As Dictionary(Of String, DbType)) As Boolean

        Dim command As System.Data.Common.DbCommand
        Dim sr As System.Data.Common.DbDataReader = Nothing
        'Dim intRet As Integer

        Try
            '---SQLSERVERのストアドプロシージャを実行する
            command = DB.DbCommand()

            'トランザクション
            command.Transaction = DB.DbTransaction

            'コマンドの種類をストアドに変更
            command.CommandType = CommandType.StoredProcedure

            '実行するストアドプロシージャ名を指定
            'command.CommandText = "[loopback].[NTZ].[dbo].[Fun_GET_NEXT_KOUTEI]"     '[loopback] -- ﾄﾗﾝｻﾞｸｼｮﾝに関係するらしいので、付けておかないといけないみたい
            command.CommandText = strStoredProcName 'pub_STORED_PROC_INFO.PROCEDURE_NM

            'commandオブジェクトのパラメータを初期化する
            command.Parameters.Clear()

            'ストアドプロシージャのパラメータに値を設定する
            For Each col As DataColumn In datarow.Table.Columns
                Dim p As System.Data.Common.DbParameter = command.CreateParameter
                p.ParameterName = col.ColumnName
                p.DbType = dbTypeDictionary(col.ColumnName)
                p.Value = datarow.Item(col.ColumnName)
                p.Direction = ParameterDirection.Input
                'p.Size =
                command.Parameters.Add(p)
            Next col


            'ストアドプロシージャの結果を取得する
            sr = command.ExecuteReader()
            sr.Close()

            Return True

            'ストアド側のエラーは受け取らない
            'If intRet = 0 Then
            '    Return True
            'Else
            '    Return False
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            'Dim strMsg As String = "ストアドプロシージャのパラメータ取得に失敗しました。" & "PG設定ファイルの受注実績登録パラメータ設定を確認して下さい。"
            'FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & "")
            'UNDONE: ストアド実行時のエラーログ出力
            Return False

        End Try
    End Function

    Private Function Fun_blnStoredProc(ByRef DB As clsDbUtility, ByVal strStoredProcName As String, ByVal dsList As DataSet, ByVal dbTypeDictionary As Dictionary(Of String, DbType)) As Boolean

        Dim command As System.Data.Common.DbCommand
        Dim sr As System.Data.Common.DbDataReader = Nothing
        'Dim intRet As Integer

        Try
            '---SQLSERVERのストアドプロシージャを実行する
            command = DB.DbCommand()

            'トランザクション
            command.Transaction = DB.DbTransaction

            'コマンドの種類をストアドに変更
            command.CommandType = CommandType.StoredProcedure

            '実行するストアドプロシージャ名を指定
            'command.CommandText = "[loopback].[NTZ].[dbo].[Fun_GET_NEXT_KOUTEI]"     '[loopback] -- ﾄﾗﾝｻﾞｸｼｮﾝに関係するらしいので、付けておかないといけないみたい
            command.CommandText = strStoredProcName 'pub_STORED_PROC_INFO.PROCEDURE_NM


            '1行ずつストアド実行
            For Each row As DataRow In dsList.Tables(0).Rows
                'commandオブジェクトのパラメータを初期化する
                command.Parameters.Clear()

                'ストアドプロシージャのパラメータに値を設定する
                For Each col As DataColumn In row.Table.Columns
                    Dim p As System.Data.Common.DbParameter = command.CreateParameter
                    p.ParameterName = col.ColumnName

                    Select Case col.ColumnName
                        Case "FILE_NM", "RENBAN", "RECV_YMDHNS"
                            Continue For
                        Case Else
                    End Select
                    p.DbType = dbTypeDictionary(col.ColumnName)
                    p.Value = row.Item(col.ColumnName)
                    p.Direction = ParameterDirection.Input
                    'p.Size =
                    command.Parameters.Add(p)
                Next col

                'ストアドプロシージャの結果を取得する
                sr = command.ExecuteReader()
                sr.Close()
            Next


            Return True

            'ストアド側のエラーは受け取らない
            'If intRet = 0 Then
            '    Return True
            'Else
            '    Return False
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            'Dim strMsg As String = "ストアドプロシージャのパラメータ取得に失敗しました。" & "PG設定ファイルの受注実績登録パラメータ設定を確認して下さい。"
            'FunErrorSyori(ENM_ERR_KB._3_ファイル作成時エラー, ENM_ERR_LEVEL._1_重要, strMsg, "エラー発生箇所:[" & System.Reflection.MethodBase.GetCurrentMethod.Name & "]" & vbCrLf & "")
            'UNDONE: ストアド実行時のエラーログ出力
            Return False

        End Try
    End Function
#End Region

#Region "   出力エラー発生時、自動出力処理を停止"
    Private Function FunUpdateAutoMakeFlg(ByRef DB As clsDbUtility, ByVal fileID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim SQLex As Exception = Nothing
        Dim strMsg As String
        Try
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE JTB_RECVFILE_JO SET ")
            sbSQL.Append(" AUTOMAKE_FLG ='" & 0 & "'") '0=無効
            sbSQL.Append(" WHERE FILE_ID=" & fileID & "")

            'SQL実行
            intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
            If SQLex IsNot Nothing Then
                strMsg = "ファイル取込処理に失敗しました。"
                FunErrorSyori(ENM_ERR_KB._2_受信ファイル取込時エラー, ENM_ERR_LEVEL._2_連絡, strMsg, ErrMsg.FunGetErrMsg(SQLex))
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "   出力エラー発生時、出力エラーファイル情報にレコード登録"

    Private Function FunRegistErrorFile(ByRef DB As clsDbUtility, ByVal intFileID As Integer, ByVal strErrorFileList As List(Of String), strLastImpYMDHNS As String) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim SQLex As Exception = Nothing
        Dim strMsg As String

        Try

            For Each file As String In strErrorFileList
                'INSERT
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("INSERT INTO " & JTB_OUTPUT_ERROR_FILE_Model.SourceTableName & " (")
                sbSQL.Append(" FILE_ID,")
                sbSQL.Append(" FILE_NM,")
                sbSQL.Append(" SYR_YMDHNS")
                sbSQL.Append(" ) VALUES (")
                sbSQL.Append(" " & intFileID & ",")
                sbSQL.Append(" '" & file & "',")
                sbSQL.Append(" '" & strLastImpYMDHNS & "') ")

                intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)
                If intRET = 0 Then
                    'UPDATE

                    '同じファイルID、受信ファイル名で取込日時が前回エラー時よりも古い場合、処理日時を最も古い日時で更新する
                    '↑のようにしないと、次回のファイル再作成処理にて、出力するデータの抽出条件が該当エラーファイルの受信処理日時より後をスキャンしてしまう
                    '(抽出結果に肝心のエラーファイルのデータが含まれない)
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & JTB_OUTPUT_ERROR_FILE_Model.SourceTableName & " SET")
                    sbSQL.Append(" SYR_YMDHNS='" & strLastImpYMDHNS & "'")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" FILE_ID=" & intFileID & ",")
                    sbSQL.Append(" AND FILE_NM='" & file & "',")
                    sbSQL.Append(" AND SYR_YMDHNS > '" & strLastImpYMDHNS & "'")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, True, SQLex)
                    If SQLex IsNot Nothing Then
                        strMsg = "SQLの実行に失敗しました。"
                        'FunErrorSyori(ENM_ERR_KB._2_受信ファイル取込時エラー, ENM_ERR_LEVEL._2_連絡, strMsg, ErrMsg.FunGetErrMsg(SQLex))
                        Return False
                        Exit For
                    End If
                Else
                    '
                End If
            Next file

            If System.IO.Directory.Exists(pub_PGINFO.strRE_OUTPUT_Exec_Path) = False Then
                'ファイル再作成処理実行フォルダを作成
                System.IO.Directory.CreateDirectory(pub_PGINFO.strRE_OUTPUT_Exec_Path)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "   出力エラー発生データの該当受信ファイルを出力エラーファイル格納フォルダに出力"

    'UNDONE:エラーファイル作成
    Private Function FunMoveOUTPUT_ERROR_FILE(ByVal strErrorFileList As List(Of String)) As Boolean
        Dim strDATA() As String = {""}
        Try
            'フォルダ存在チェックと作成
            If System.IO.Directory.Exists(pub_PGINFO.strOUTPUT_NG_File_Path) = False Then
                System.IO.Directory.CreateDirectory(pub_PGINFO.strOUTPUT_NG_File_Path)
            End If

            '文字コード指定
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

            For Each file As String In strErrorFileList
                strDATA(0) = file
                '----ファイル作成 念のため中身にもファイル名を記録
                System.IO.File.WriteAllLines(pub_PGINFO.strOUTPUT_NG_File_Path & file, strDATA, enc)
            Next file

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try

    End Function

#End Region

#Region "再作成実行フォルダに格納されたファイル一覧を取得"

    Private Function FunGetReMakeTargetFileList(ByRef DB As clsDbUtility, Optional ByVal intFileID As Integer = 0) As List(Of String)
        Dim list As New List(Of String)
        Try

            If System.IO.Directory.Exists(pub_PGINFO.strRE_OUTPUT_Exec_Path) = False Then
                System.IO.Directory.CreateDirectory(pub_PGINFO.strRE_OUTPUT_Exec_Path)
            End If

            '取込ファイル(TMPファイル)の一覧を取得
            Dim wkfiles As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles( _
                                                 pub_PGINFO.strRE_OUTPUT_Exec_Path, "*.xml", System.IO.SearchOption.TopDirectoryOnly)

            For Each file As String In wkfiles
                If FunCheckErrorFileExist(DB, file, intFileID) = True Then
                    '未再作成エラーファイルリストに存在する項目のみ
                    list.Add(System.IO.Path.GetFileName(file))
                Else
                    'UNDONE: 再作成実行フォルダに無関係のxmlファイルは除外
                End If
            Next file

            Return list

            'Catch ex As System.IO.DirectoryNotFoundException
            '    WL.WriteLogDat("再作成実行フォルダが存在しません")
            '    Return Nothing
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        Finally

        End Try
    End Function

    '再作成実行フォルダに格納されたファイルが未再作成エラーファイルリストに存在するかチェック
    Private Function FunCheckErrorFileExist(ByRef DB As clsDbUtility, ByVal strFileName As String, Optional ByVal intFileID As Integer = 0) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New System.Data.DataSet
        Try
            '2017.07.12 Delete 中身は確認しない
            'Using sr As New System.IO.StreamReader(strFileName, System.Text.Encoding.GetEncoding("shift_jis"))
            '    'ファイル名と内部テキストのファイル名が一致することを確認
            '    Dim s As String = sr.ReadToEnd().Replace(vbCrLf, "")
            '    If s <> System.IO.Path.GetFileName(strFileName) Then
            '        Return False
            '    End If
            '    '閉じる
            '    sr.Close()
            'End Using

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * ")
            sbSQL.Append(" FROM " & JTB_OUTPUT_ERROR_FILE_Model.SourceTableName & " ")
            sbSQL.Append(" WHERE FILE_NM ='" & System.IO.Path.GetFileName(strFileName) & "' ")
            If intFileID > 0 Then
                sbSQL.Append(" AND FILE_ID =" & intFileID & " ")
            End If

            dsList = DB.GetDataSet(sbSQL.ToString, True)

            '出力データが存在しない場合
            If dsList.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region


#Region "出力エラー通知メールに追記する明細項目のリストをコードマスタより取得"
    Private Function FunGetOutputErrorMail_DetailFieldList(ByRef DB As clsDbUtility) As List(Of ST_ErrorMailDetailFields)
        Dim list As New List(Of ST_ErrorMailDetailFields)
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim dt As New DataTableEx
        Dim intNo As Integer
        Dim strKOM As String = ""

        Dim entity As New ST_ErrorMailDetailFields
        Try

            sbSQL.Append("SELECT KOMO_NM, VALUE, DISP FROM MTB_CODE WHERE KOMO_NM Like 'OUTPUT/_ERROR/_DETAIL/___' ESCAPE '/' ")
            sbSQL.Append(" ORDER BY KOMO_NM,VALUE")
            dsList = DB.GetDataSet(sbSQL.ToString, True)

            For intCNT = 0 To dsList.Tables(0).Rows.Count - 1
                With dsList.Tables(0).Rows(intCNT)
                    If strKOM <> .Item("KOMO_NM").ToString.TrimEnd Then
                        If entity.No > 0 Then
                            'リストに追加
                            list.Add(entity)
                        End If
                        entity = New ST_ErrorMailDetailFields
                        strKOM = .Item("KOMO_NM").ToString.TrimEnd
                        intNo += 1
                    End If
                    entity.No = intNo
                    Select Case .Item("VALUE").ToString.TrimEnd
                        Case "DISP_NM"
                            entity.display_name = .Item("DISP").ToString.TrimEnd
                        Case "FIELD_NM"
                            entity.field_name = .Item("DISP").ToString.TrimEnd
                        Case Else
                    End Select
                End With
            Next intCNT
            '最終項目をリストに追加
            list.Add(entity)

            Return list
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#End Region

#Region "未使用"

#Region "⑤ CSVファイルを読み込んでDBに書込"
    Private Function FunCSVtoTable(ByVal strCSV_FILE As String, ByVal fileInfo As FILE_INFO) As Boolean
        Dim data() As String
        Dim blnRET As Boolean
        Dim dataList As New List(Of String())

        Try
            Using parser As Microsoft.VisualBasic.FileIO.TextFieldParser = New Microsoft.VisualBasic.FileIO.TextFieldParser(strCSV_FILE, System.Text.Encoding.GetEncoding("shift_jis"))
                With parser
                    .TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited 'CSV
                    .SetDelimiters(",") '区切り文字の指定
                    .HasFieldsEnclosedInQuotes = False '引用符なし


                    While .EndOfData = False
                        'データを1行取得
                        data = .ReadFields()

                        '列数が一致しているかチェック
                        If data.Length <> fileInfo.intFieldCount = False Then
                            'UNDONE:エラーログ出力
                            Return False
                        End If

                        ''データ配列をエンティティにセット
                        'Dim entity As New RTB_DELFOR_Model
                        'entity.SetFields(data)

                        ''リストに追加
                        'rTB_DELFOR.Add(entity)

                        'リストに追加
                        dataList.Add(data)

                    End While

                    'テキストパーサを閉じる
                    .Close()
                End With
            End Using

            'リストをDBに書き込み
            blnRET = FunblnTableInsert(dataList, fileInfo)

            Return blnRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#End Region

End Class
