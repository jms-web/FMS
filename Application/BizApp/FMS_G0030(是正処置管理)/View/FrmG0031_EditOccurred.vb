Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D013 = MODEL.D013_ZESEI_HASSEI_J

''' <summary>
''' FCCB登録画面
''' </summary>
Public Class FrmG0031_EditOccurred

#Region "定数・変数"

    Private _D013 As New D013
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)

    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

    Private USER_GYOMU_KENGEN_LIST As New List(Of ENM_GYOMU_GROUP_ID)

    Private Flx2_DS_DB As DataTable
    Private Flx3_DS_DB As DataTable
    Private Flx4_DS_DB As DataTable

    Private dtBUFF As DateTime

    Private SYOCHI_KAKUNIN_Users As New List(Of (userId As Integer, YOHI_KAITO As String))

#End Region

#Region "プロパティ"

    Public Property PrMODE As Integer

    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

    '現在のステージ 承認順
    Public Property PrCurrentStage As Integer

    '報告書No
    Public Property PrFCCB_NO As String

    'NCR編集画面から開かれているか
    Public Property PrDialog As Boolean

    Public PrRIYU As String = ""

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc1, "操作権限がありません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "操作権限がありません")
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbKISO_TANTO.NullValue = 0

        dtKISO.Nullable = True

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PrRIYU = ""
            IsInitializing = True

            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()
                        Me.Cursor = Cursors.WaitCursor

                        '-----フォーム初期設定(親フォームから呼び出し)
                        Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
                        Using DB As ClsDbUtility = DBOpen()
                            lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
                        End Using

                        '--- モデルクリア
                        _D009.Clear()
                        _D004_SYONIN_J_KANRI.clear()

                        cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                        If blnIsAdmin Then
                            'システム管理者のみ制限解除
                        Else
                            Select Case pub_SYAIN_INFO.BUMON_KB
                                Case Context.ENM_BUMON_KB._1_風防, Context.ENM_BUMON_KB._2_LP
                                    Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                                AsEnumerable.
                                                                Where(Function(r) r.Field(Of String)("VALUE") = "1" Or r.Field(Of String)("VALUE") = "2").
                                                                CopyToDataTable
                                    cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                                    cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                                Case Context.ENM_BUMON_KB._3_複合材
                                    Dim dt As DataTable = DirectCast(cmbBUMON.DataSource, DataTable).
                                                                AsEnumerable.
                                                                Where(Function(r) r.Field(Of String)("VALUE") = pub_SYAIN_INFO.BUMON_KB).
                                                                CopyToDataTable
                                    cmbBUMON.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

                                    cmbBUMON.SelectedValue = pub_SYAIN_INFO.BUMON_KB

                                Case Else
                                    'Err
                            End Select
                        End If

                        IsEditingClosed = HasEditingRight(pub_SYAIN_INFO.SYAIN_ID)

                        '-----画面初期化
                        Call FunInitializeControls(PrMODE)

                    End Sub)
                End Sub)
        Finally
            FunInitFuncButtonEnabled()
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Maximized
            IsInitializing = False
        End Try
    End Sub

    'Shown
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub

    Private Sub Frm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Me.Owner.Visible = True
    End Sub

#End Region

#Region "FunctionButton関連"

#Region "ボタンクリックイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '[処理中]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '保存

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                        If IsEditingClosed And PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then

                            Call OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_保存) Then
                            Me.DialogResult = DialogResult.OK
                            Dim strMsg As String = "入力内容を保存しました。"

                            ''他の担当者も含めて必須項目入力済みの場合、FCCB議長への申請処理へ移行
                            'Select Case PrCurrentStage
                            '    Case ENM_FCCB_STAGE._20_処置事項調査等.Value
                            '        If IsInputRequired_DB() Then
                            '            If FunSendRequestMail(fromUserNAME:="FCCB管理システム", toUserNAME:=cmbCM_TANTO.Text) Then
                            '                strMsg &= $"{vbCrLf}また、全ての要入力項目が完了したため、FCCB議長に処置申請を送信しました。"
                            '            End If
                            '        End If
                            'End Select

                            MessageBox.Show(strMsg, "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '承認申請

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed Then
                            strMsg = "承認・CLOSEしますか？"
                        Else
                            strMsg = "承認・申請しますか？"
                        End If

                        If MessageBox.Show(strMsg, "承認・申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then
                                If PrCurrentStage = ENM_ZESEI_STAGE._60_処置事項完了確認 Then
                                    strMsg = "承認・CLOSEしました"
                                Else
                                    strMsg = "承認・申請しました"
                                End If

                                MessageBox.Show(strMsg, "承認・申請処理完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.DialogResult = DialogResult.OK

                                'SPEC: 2.(3).E.�C
                                Me.Close()
                            Else
                                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 4  '協議要否確認　協議開催通知メール送信

                    If IsNeedMeeting() Then
                        If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                            If OpenFormSendMail() Then
                                If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                                    Me.DialogResult = DialogResult.OK
                                Else
                                    If FunSAVE(ENM_SAVE_MODE._1_保存, True) Then
                                        Me.DialogResult = DialogResult.OK
                                    Else
                                        MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        '協議要否依頼メール
                        If MessageBox.Show("協議要否依頼メールを送信しますか？", "メール送信確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            If FunSendJudgeReplyMail(blnNonMessage:=True) Then
                                Dim imgDlg As New ImageDialog
                                imgDlg.Show("\\sv04\FMS\RESOURCE\sendmail_256.gif", 4000)
                            End If
                        End If
                    End If

                Case 5  '差し戻し

                    Call OpenFormSASIMODOSI()

                Case 10  '印刷

                    Call FunOpenReportFCCB()

                Case 11 '履歴
                    'Call ShowUnimplemented()
                    Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)

                Case 12 '閉じる
                    Me.Close()
                Case Else
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'ボタン可
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            'ファンクションキー有効化初期化
            If intFUNC <> 12 Then Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "保存・承認申請"

#Region "   保存・承認申請処理メイン"

    ''' <summary>
    ''' 保存・承認申請処理メイン
    ''' </summary>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE(ByVal enmSAVE_MODE As ENM_SAVE_MODE, Optional blnTENSO As Boolean = False) As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    If FunSAVE_D013(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_FILE(DB) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_ZESEI_STAGE._999_Closed Then
                        If FunSAVE_D004(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    End If
                    If FunSAVE_R001(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "   ファイル保存"

    ''' <summary>
    ''' NCR添付ファイル保存
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_FILE(ByRef DB As ClsDbUtility) As Boolean

        If _D009.FILE_PATH.IsNulOrWS Then
            Return True
        Else
            'SPEC: 2.(3).D.�A.添付ファイル保存
            Dim strRootDir As String
            Dim strMsg As String
            strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            If strRootDir.IsNulOrWS OrElse Not System.IO.Directory.Exists(strRootDir) Then

                strMsg = "添付ファイル保存先が設定されていないか、アクセス出来ません。" & vbCrLf &
                         "添付ファイルはシステムに保存されませんが、" & vbCrLf &
                         "登録処理を続行しますか？"

                If MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> vbOK Then
                    Me.DialogResult = DialogResult.Abort
                    _D009.FILE_PATH = ""
                    Return True
                Else
                    Me.DialogResult = DialogResult.Abort
                    Return True
                End If
            Else
                Try
                    System.IO.Directory.CreateDirectory(strRootDir & _D009.FCCB_NO)

                    If Not _D009.FILE_PATH.IsNulOrWS AndAlso
                        Not System.IO.File.Exists(strRootDir & _D009.FCCB_NO.Trim & "\" & _D009.FILE_PATH) Then

                        If System.IO.File.Exists(lbltmpFile1.Links.Item(0).LinkData) Then
                            System.IO.File.Copy(lbltmpFile1.Links.Item(0).LinkData, strRootDir & _D009.FCCB_NO.Trim & "\" & _D009.FILE_PATH, True)
                        Else
                            Throw New IO.FileNotFoundException($"添付ファイル:{lbltmpFile1.Links.Item(0).LinkData}が見つかりません。元の場所に戻すか選択し直してください")
                        End If
                    End If

                    Return True
                Catch exNF As IO.FileNotFoundException
                    MessageBox.Show(exNF.Message, "ファイル存在チェック", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch exIO As UnauthorizedAccessException
                    strMsg = "添付ファイル保存先のアクセス権限がありません。" & vbCrLf &
                             "添付ファイル保存先:" & strRootDir
                    MessageBox.Show(strMsg, "ファイル保存先アクセス不可", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Catch ex As Exception
                    Throw
                    Return False
                End Try
            End If
        End If
    End Function

#End Region

#Region "   D013"

    ''' <summary>
    ''' FCCB更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D013(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "モデル更新"

        If _D013.HOKOKU_NO.IsNulOrWS Or _D013.HOKOKU_NO = "<新規>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST06_GET_ZESEI_NO", lstParam) = True Then
                _D013.HOKOKU_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_ZESEI_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D013._CLOSE_FG = 1
        End If

        _D013.BUMON_KB = cmbBUMON.SelectedValue

        If dtKISO.Text.IsNulOrWS Then
            _D013.ADD_YMDHNS = strSysDate
        Else
            _D013.ADD_YMDHNS = dtKISO.ValueDate.ToString("yyyyMMdd") & "000000"
        End If

        _D009.INPUT_DOC_NO = mtxINPUT_DOC_NO.Text
        _D009.SNO_APPLY_PERIOD_KISO = mtxSNO_APPLY_PERIOD_KISO.Text
        _D009.SNO_APPLY_PERIOD_HENKO_SINGI = mtxSNO_APPLY_PERIOD_HENKO_SINGI.Text
        _D009.INPUT_NAIYO = txtINPUT_NAIYO.Text

        If cmbKISO_TANTO.IsSelected Then
            _D009.ADD_SYAIN_ID = cmbKISO_TANTO.SelectedValue
        Else
            _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        End If

        _D009.UPD_YMDHNS = strSysDate
        _D009.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D009.DEL_YMDHNS = ""
        _D009.DEL_SYAIN_ID = 0

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D009_FCCB_J)} AS TARGET")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D009.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (TARGET.{NameOf(_D009.FCCB_NO)} = WK.{NameOf(_D009.FCCB_NO)})")
        '---UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" {_D009.ToUpdateSqlString("TARGET", "WK")}")
        '---INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN")
        sbSQL.Append($" {_D009.ToInsertSqlString("WK")}")
        sbSQL.Append(" OUTPUT $action As RESULT;")
        strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
        Select Case strRET
            Case "INSERT"

            Case "UPDATE"

            Case Else
                '-----エラーログ出力
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
        End Select
        WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009.FCCB_NO}、MERGE D009_FCCB_J")

        Return True
    End Function

#End Region

#Region "   D004 承認実績管理更新"

    ''' <summary>
    ''' 承認実績管理更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D004(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Try

#Region "   CurrentStage"

            '-----データモデル更新
            _D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D009.FCCB_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_ZESEI_STAGE._10_起草入力 Then
                _D004_SYONIN_J_KANRI.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            End If

            '#80 承認申請日は画面で入力
            If _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.IsNulOrWS Then
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
            ElseIf _D004_SYONIN_J_KANRI.SYONIN_YMDHNS.Trim.Length = 8 Then
                'datetextboxにバインド時は時刻情報を結合
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS &= "000000"
            End If
            Select Case enmSAVE_MODE
                Case ENM_SAVE_MODE._1_保存
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

                Case ENM_SAVE_MODE._2_承認申請
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = PrCurrentStage
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                Case Else
                    'Err
                    Return False
            End Select

            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($" SELECT")
            sbSQL.Append($"   {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
            sbSQL.Append($" , {_D004_SYONIN_J_KANRI.UPD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
            'UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)} = WK.{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.RIYU)} = WK.{NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
            'INSERT
            sbSQL.Append(" WHEN NOT MATCHED THEN ")
            sbSQL.Append(" INSERT(")
            sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
            sbSQL.Append(" ) VALUES(")
            sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" )")
            sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
            sbSQL.Append(";")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

#End Region

#Region "   NextStage"

            '-----承認申請
            Select Case enmSAVE_MODE
                Case ENM_SAVE_MODE._1_保存
                    '保存実績のみ
                    Return True
                Case ENM_SAVE_MODE._2_承認申請
                    _D004_SYONIN_J_KANRI.SYONIN_JUN = FunGetNextSYONIN_JUN(PrCurrentStage)
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

                    'ステージ別承認判定
                    Select Case PrCurrentStage
                        Case ENM_ZESEI_STAGE._10_起草入力

                        Case ENM_ZESEI_STAGE._20_処置事項調査等

                        Case ENM_ZESEI_STAGE._30_変更審議

                        Case ENM_ZESEI_STAGE._40_処置確認

                        Case ENM_ZESEI_STAGE._50_処置事項完了

                        Case ENM_ZESEI_STAGE._60_処置事項完了確認

                        Case Else
                            Throw New ArgumentException("想定外の承認ステージです", PrCurrentStage)
                    End Select

                Case Else
                    'Err
                    Return False
            End Select

            '-----Close処理
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_ZESEI_STAGE._999_Closed Then
                _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = strSysDate
            End If

            '-----MERGE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"MERGE INTO {NameOf(D004_SYONIN_J_KANRI)} AS SrcT")
            sbSQL.Append($" USING (")
            sbSQL.Append($" SELECT")
            sbSQL.Append($" {_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.HOKOKU_NO}' AS {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.SYONIN_JUN} AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYAIN_ID}' AS {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB}' AS {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._SASIMODOSI_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.RIYU}' AS {NameOf(_D004_SYONIN_J_KANRI.RIYU)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.COMMENT}' AS {NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI._MAIL_SEND_FG}' AS {NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}")
            sbSQL.Append($" ,{_D004_SYONIN_J_KANRI.ADD_SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.ADD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS)}")
            sbSQL.Append($" ,{pub_SYAIN_INFO.SYAIN_ID} AS {NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}")
            sbSQL.Append($" ,'{_D004_SYONIN_J_KANRI.UPD_YMDHNS}' AS {NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)} = WK.{NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}")
            sbSQL.Append($" AND SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)})")
            'UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" UPDATE SET")
            sbSQL.Append($"  SrcT.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)} = WK.{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)} = WK.{NameOf(_D004_SYONIN_J_KANRI.COMMENT)}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)} = {pub_SYAIN_INFO.SYAIN_ID}")
            sbSQL.Append($" ,SrcT.{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)} = '{strSysDate}'")
            'INSERT
            sbSQL.Append(" WHEN NOT MATCHED THEN ")
            sbSQL.Append(" INSERT(")
            sbSQL.Append("  " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.ADD_YMDHNS))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS))
            sbSQL.Append(" ) VALUES(")
            sbSQL.Append("  WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.RIYU))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.COMMENT))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG))
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.ADD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" ,WK." & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID))
            sbSQL.Append($" ,'{strSysDate}'")
            sbSQL.Append(" )")
            sbSQL.Append("OUTPUT $action AS RESULT") 'INSERT OR UPDATE をncarchar(10)で取得する場合
            sbSQL.Append(";")

            ''-----MERGE実行&実行結果取得
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT"
                    If PrCurrentStage < ENM_ZESEI_STAGE._60_処置事項完了確認 AndAlso FunSendRequestMail() Then
                        WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009.FCCB_NO}、Send Request Mail")
                    End If

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009.FCCB_NO}、MERGE D004")

#End Region

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendJudgeReplyMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "", Optional blnNonMessage As Boolean = False) As Boolean

        Try

            Dim strSubject As String = $"【FCCB記録書-協議要否確認】FCCB-NO:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strBody As String = <sql><![CDATA[
                各位<br />
                <br />
        　      FCCB記録書の協議要否依頼が来ましたので対応をお願いします。<br />
                <br />
        　　        【報 告 書】FCCB<br />
        　　        【FCCB-No】{0}<br />
        　　        【起 草 日】{1}<br />
                <br />        　　
                FCCB議長
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                <br />
                ※このメールは配信専用です。(返信できません)<br />
                返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                ]]></sql>.Value.Trim

            'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

            Dim dt As DateTime
            If DateTime.TryParse(_D009.ADD_YMDHNS, dt) Then
            Else
                dt = DateTime.ParseExact(_D009.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing)
            End If

            strBody = String.Format(strBody,
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                dt.ToString("yyyy/MM/dd"))

            Dim ToUsers As New List(Of Integer)

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            'sbSQL.Clear()
            'sbSQL.Append($"SELECT")
            'sbSQL.Append($" {NameOf(D013.TANTO_ID)}")
            'sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
            'sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
            'sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
            'sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='' ")
            Using DB = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            For Each row As DataRow In dsList.Tables(0).Rows
                If Not ToUsers.Contains(row.Item(0).ToString.ToVal) Then
                    ToUsers.Add(row.Item(0).ToString.ToVal)
                End If
            Next

            If ToUsers.Count = 0 Then
                If Not blnNonMessage Then MessageBox.Show("送信者が見つからないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailFCCB(strSubject, strBody, ToUsers) Then
                    Return True
                Else
                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "承認依頼メール送信"

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim KISYU_NAME As String = tblKISYU.LazyLoad("機種").
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).
                                                FirstOrDefault?.Item("DISP")

            Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("承認判定区分").
                                                                   AsEnumerable.
                                                                   Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).
                                                                   FirstOrDefault?.Item("DISP")

            Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{ENM_OPEN_MODE._2_処置画面起動.Value},{Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value},{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim strSubject As String = $"【FCCB処置依頼】FCCB-NO:{_D004_SYONIN_J_KANRI.HOKOKU_NO}"
            Dim ToUsers As New List(Of Integer)

            'Select Case PrCurrentStage
            '    Case ENM_FCCB_STAGE._10_起草入力
            '        'Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_処置事項調査等)
            '        'ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

            '        '部門の役職区分GL、TL全員へ
            '        ToUsers.AddRange(GetTLGLUsers(_D009.BUMON_KB))
            '    Case ENM_FCCB_STAGE._20_処置事項調査等

            '        ToUsers.Add(_D009.CM_TANTO)

            '    Case ENM_FCCB_STAGE._30_変更審議
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            '        End If

            '    Case ENM_FCCB_STAGE._40_処置確認

            '        Dim IsAllChecked As Boolean = True
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
            '            '全ての担当者のチェックが完了したら統括責任者に依頼送信
            '            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '        Else
            '            '統括責任者のチェックも完了したら、各要処置事項の担当者に依頼送信
            '            Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next
            '        End If

            '    Case ENM_FCCB_STAGE._50_処置事項完了
            '        '裏処理にて各要処置事項の完了日の1週間前になっても未処置の場合、処置担当者に滞留通知

            '        '申請条件のチェック
            '        Dim IsClosed As Boolean = True
            '        IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
            '                                   AsEnumerable.
            '                                   Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS And r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        '全要処置事項の処置完了
            '        If IsClosed Then
            '            'FCCB議長に依頼通知
            '            If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
            '                ToUsers.Add(_D009.CM_TANTO)
            '            Else
            '                ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '            End If
            '        End If

            '    Case Else
            '        Throw New ArgumentException("想定外の承認ルートです", PrCurrentStage)
            'End Select

            Dim strBody As String = <sql><![CDATA[
                {0}<br />
                <br />
        　        FCCB記録書の処置内容の確認と承認をお願いします。<br />
                <br />
        　　        【報 告 書】FCCB<br />
        　　        【FCCB-No】{1}<br />
        　　        【起 草 日】{2}<br />
        　　        【機　  種】{3}<br />
        　　        【依 頼 者】{5}<br />
        　　        【依頼者処置内容】{6}<br />
        　　        【コメント】{7}<br />
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                <br />
                ※このメールは配信専用です。(返信できません)<br />
                返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                ]]></sql>.Value.Trim

            'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

            Dim username As String

            If (ToUsers.Count > 1) Then
                username = "各位"
            Else
                username = If(toUserNAME.IsNulOrWS, $"{Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID)} 殿", toUserNAME)
            End If

            strBody = String.Format(strBody,
                                username,
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                DateTime.ParseExact(_D009.ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                "",
                                If(fromUserNAME = "", Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID), fromUserNAME),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0020.exe",
                                strEXEParam)

            If ToUsers.Count = 0 Then
                MessageBox.Show("送信者が見つからないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailFCCB(strSubject, strBody, ToUsers, blnSendSenior:=False) Then
                    Return True
                Else
                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function GetTLGLUsers(BUMON_KB As String) As IEnumerable(Of Integer)
        Dim retList As New List(Of Integer)
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            If (BUMON_KB = ENM_BUMON_KB._1_風防.Value) Then
                sbSQL.Append($"SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID And M11.GYOMU_GROUP_ID <> '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_風防.Value}') )")
                sbSQL.Append($" AND M04.YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" UNION")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" INNER JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{ENM_BUMON_KB._1_風防.Value}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._1_課長.Value}'")
            Else
                sbSQL.Append($"SELECT SYAIN_ID,SIMEI FROM M004_SYAIN")
                sbSQL.Append($" WHERE SYAIN_ID IN ((SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}') )")
                sbSQL.Append($" AND YAKUSYOKU_KB IN ('{ENM_YAKUSYOKU_KB._2_GL.Value}','{ENM_YAKUSYOKU_KB._5_TL.Value}')")
                sbSQL.Append($" Except")
                sbSQL.Append($" SELECT M04.SYAIN_ID,M04.SIMEI FROM M004_SYAIN M04")
                sbSQL.Append($" LEFT JOIN M011_SYAIN_GYOMU M11")
                sbSQL.Append($" ON M04.SYAIN_ID = M11.SYAIN_ID AND M11.GYOMU_GROUP_ID = '{ENM_GYOMU_GROUP_ID._2_製造.Value}'")
                sbSQL.Append($" WHERE M04.SYAIN_ID IN (SELECT SYOZOKUCYO_ID FROM M002_BUSYO WHERE BUMON_KB='{BUMON_KB}')")
                sbSQL.Append($" AND YAKUSYOKU_KB ='{ENM_YAKUSYOKU_KB._2_GL.Value}'")
            End If

            Using DB = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            For Each r As DataRow In dsList.Tables(0).Rows
                retList.Add(r.Item(0).ToString.ToVal)
            Next

            Return retList
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "R001"

    ''' <summary>
    ''' 報告書操作履歴更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        '---存在確認
        Dim dsList As New DataSet
        Dim blnExist As Boolean
        sbSQL.Append($"SELECT {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} FROM {NameOf(R001_HOKOKU_SOUSA)}")
        sbSQL.Append($" WHERE {NameOf(R001_HOKOKU_SOUSA.HOKOKU_NO)} ='{_R001_HOKOKU_SOUSA.HOKOKU_NO}'")
        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        If dsList.Tables(0).Rows.Count > 0 Then
            blnExist = True
        End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D009.FCCB_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._2_更新保存
                Else
                    Return True
                End If

            Case ENM_SAVE_MODE._2_承認申請
                _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_HOKOKUSYO_SOUSA_KB._1_申請
        End Select

        '-----

        '-----INSERT
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(R001_HOKOKU_SOUSA) & "(")
        sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
        sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
        sbSQL.Append(" ) VALUES(")
        sbSQL.Append("  " & _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.HOKOKU_NO & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.ADD_YMDHNS & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYONIN_JUN)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SOUSA_KB & "'")
        sbSQL.Append(" ," & _R001_HOKOKU_SOUSA.SYAIN_ID)
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB & "'")
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.RIYU & "'")
        sbSQL.Append(")")

        '-----SQL実行
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        End If

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D009.FCCB_NO}、INSERT R001")

        Return True
    End Function

#End Region

#End Region

#Region "転送"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0035_Tenso
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUMON_KB = _D009.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "差戻し"

    Private Function OpenFormSASIMODOSI() As Boolean
        Dim frmDLG As New FrmG0036_Sasimodosi
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = CDate(_D009.ADD_YMDHNS).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "印刷"

    Private Function FunOpenReportFCCB() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            'ファイル名
            strOutputFileName = "CTS_" & _D009.FCCB_NO & "_Work.xls"

            '既存ファイル削除
            If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                Return False
            End If

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                strTEMPFILE = FunConvRootPath(iniIF.GetIniString("FCCB", "FILEPATH"))
            End Using

            'エクセル出力ファイル用意
            If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                Return False
            End If
            '-----書込処理
            If FunMakeReportFCCB(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D009.FCCB_NO) = False Then
                Return False
            End If

            'Excel起動
            Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

#Region "履歴"

    Private Function OpenFormHistory(ByVal SYONIN_HOKOKU_ID As Integer, ByVal HOKOKU_NO As String) As Boolean
        Dim frmDLG As New FrmG0032_Rireki
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
            frmDLG.PrDatarow = PrDataRow
            dlgRET = frmDLG.ShowDialog(Me)
            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If

            Me.Visible = True
        End Try
    End Function

#End Region

#Region "修正"

    Private Function OpenFormEdit() As Boolean
        Dim frmDLG As New FrmG0034_EditComment
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = _D009.FCCB_NO
            frmDLG.PrBUMON_KB = _D009.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).FirstOrDefault?.Item("DISP")
            frmDLG.PrCurrentStage = Me.PrCurrentStage

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.OK Then
                PrRIYU = frmDLG.PrRIYU
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "メール送信"

    Private Function OpenFormSendMail() As Boolean
        Dim frmDLG As New FrmG0037_MailForm
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrSYORI_NAME = "協議確認依頼メール送信"

            Dim userlist As New List(Of Integer)

            'userlist.Add(cmbCM_TANTO.SelectedValue)
            'If cmbSYOCHI_GM_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_GM_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIZO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KENSA_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KENSA_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KENSA_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_HINSYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEKKEI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_SEIGI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_KANRI_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            'End If
            'If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso Not userlist.Contains(cmbSYOCHI_EIGYO_TANTO.SelectedValue) Then
            '    userlist.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            'End If

            If userlist.Count > 1 Then
                frmDLG.PrToUsers = userlist
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.OK Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Return True
                Else
                    Return False
                End If
            Else
                MessageBox.Show($"確認依頼担当者が選択されていません{vbCrLf}先に、�D変更審議 各部門の担当者を選択して下さい", "協議確認依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Function

#End Region

#Region "FuncButton有効無効切替"

    ''' <summary>
    ''' 使用しないボタンのキャプションをなくす、かつ非活性にする。
    ''' ファンクションキーを示す(F**)以外の文字がない場合は、未使用とみなす
    ''' </summary>
    ''' <param name="frm">対象フォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            'カレントステージが自身の担当でない場合は無効
            Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, _D009.FCCB_NO, PrCurrentStage)

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc4.Enabled = False
                cmdFunc4.Visible = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc1.Enabled = IsOwnCreated
                cmdFunc2.Enabled = IsOwnCreated

                cmdFunc5.Enabled = IsOwnCreated

                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                cmdFunc5.Enabled = blnIsAdmin

                cmdFunc4.Visible = False

                Select Case PrCurrentStage
                    Case ENM_ZESEI_STAGE._10_起草入力
                        cmdFunc5.Enabled = False
                    Case ENM_ZESEI_STAGE._20_処置事項調査等
                        cmdFunc2.Enabled = pub_SYAIN_INFO.SYAIN_ID = _D009.CM_TANTO
                    Case ENM_ZESEI_STAGE._30_変更審議

                        cmdFunc4.Visible = True

                        cmdFunc4.Enabled = pub_SYAIN_INFO.SYAIN_ID = _D009.CM_TANTO

                        If IsNeedMeeting() Then
                            cmdFunc4.Text = $"協議開催{vbCrLf}メール送信(F4)"
                        Else
                            cmdFunc4.Text = $"協議要否確認{vbCrLf}メール送信(F4)"
                        End If

                    Case ENM_ZESEI_STAGE._50_処置事項完了

                    Case ENM_ZESEI_STAGE._999_Closed
                        If IsEditingClosed Then
                            cmdFunc1.Enabled = True
                            cmdFunc1.Text = "保存(F1)"
                        Else
                            cmdFunc1.Enabled = False
                            cmdFunc1.Text = "保存(F1)"
                        End If

                        cmdFunc2.Enabled = False
                        cmdFunc4.Enabled = False
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(cmdFunc1, "Close済みのため使用出来ません")
                        MyBase.ToolTip.SetToolTip(cmdFunc2, "Close済みのため使用出来ません")
                        MyBase.ToolTip.SetToolTip(cmdFunc4, "Close済みのため使用出来ません")
                        MyBase.ToolTip.SetToolTip(cmdFunc5, "Close済みのため使用出来ません")
                    Case Else
                End Select

            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#Region "申請先社員"

    Private Sub CmbDestTANTO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

#End Region

#Region "ヘッダ"

    Private Sub RsbtnST_CheckedChanged(sender As Object, e As EventArgs)

        Dim btn As RibbonShapeRadioButton = DirectCast(sender, RibbonShapeRadioButton)
        Dim intStageID As Integer = Val(btn.Name.Substring(7))

    End Sub

#Region "部門"

    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged

    End Sub

#End Region

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbBUMON, cmbBUMON.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbKISO_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKISO_TANTO, cmbKISO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "起草者"))
    End Sub

#End Region

#End Region

#Region "ローカル関数"

#Region "処理モード別画面初期化"

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <param name="intMODE"></param>
    ''' <returns></returns>
    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try

            'ナビゲートリンク選択
            If PrCurrentStage = ENM_ZESEI_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----コントロールデータソース設定
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            '現行ステージ名
            lblCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009.FCCB_NO)

            '処置確認担当者

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    ''' <summary>
    ''' 担当者のデータソース情報をラベルに表示
    ''' </summary>
    ''' <returns></returns>
    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblKISO_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・設計・品証・生技")
        'Call SetInfoLabelFormat(lblCM_TANTO, $"承認担当者マスタ{vbCr}所属部門のST1.に登録された担当者")
        'Call SetInfoLabelFormat(lblDestTanto, $"承認担当者マスタ{vbCr}所属部門の当該ステージに登録された担当者")

    End Function

    Private Function SetInfoLabelFormat(lbl As System.Windows.Forms.Label, caption As String) As Boolean
        lbl.ForeColor = Color.Blue
        'lbl.Cursor = Cursors.Hand
        lbl.Font = New Font("Meiryo UI", 9, FontStyle.Bold + FontStyle.Underline, lbl.Font.Unit, CType(128, Byte))
        InfoToolTip.SetToolTip(lbl, caption)
    End Function

#End Region

#Region "入力チェック"

    Private Function FunCheckInput(ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Try
            'フラグリセット
            IsValidated = True

            Call cmbBUMON_Validated(cmbBUMON, Nothing)
            Call cmbKISO_TANTO_Validated(cmbKISO_TANTO, Nothing)

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then

            End If

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 該当報告書Noの現在のステージ名を取得
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID"></param>
    ''' <param name="strHOKOKU_NO"></param>
    ''' <returns></returns>
    Private Function FunGetLastStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"SELECT")
        sbSQL.Append($" {NameOf(V003_SYONIN_J_KANRI)}.*")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" And {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return "ST01.起草"
            Else
                Return .Rows(0).Item(NameOf(V003_SYONIN_J_KANRI.SYONIN_NAIYO)) '.Rows(0).Item("SYONIN_JUN") & "." & .Rows(0).Item("SYONIN_NAIYO")
            End If
        End With
    End Function

    ''' <summary>
    ''' 次ステージの承認順Noを取得
    ''' </summary>
    ''' <param name="CurrentStageID">現ステージID</param>
    ''' <returns></returns>
    Private Function FunGetNextSYONIN_JUN(CurrentStageID As Integer) As Integer
        Try

            Select Case CurrentStageID
                Case ENM_ZESEI_STAGE._10_起草入力
                    Return ENM_ZESEI_STAGE._20_処置事項調査等
                Case ENM_ZESEI_STAGE._20_処置事項調査等
                    Return ENM_ZESEI_STAGE._30_変更審議
                Case ENM_ZESEI_STAGE._30_変更審議
                    Return ENM_ZESEI_STAGE._40_処置確認
                Case ENM_ZESEI_STAGE._40_処置確認, ENM_ZESEI_STAGE._41_処置確認_統括
                    Return ENM_ZESEI_STAGE._50_処置事項完了
                Case ENM_ZESEI_STAGE._50_処置事項完了
                    Return ENM_ZESEI_STAGE._60_処置事項完了確認
                Case ENM_ZESEI_STAGE._60_処置事項完了確認, ENM_ZESEI_STAGE._61_処置事項完了確認_統括
                    Return ENM_ZESEI_STAGE._999_Closed
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function IsRemanded(strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer

        If strHOKOKU_NO.IsNulOrWS Then
            Return False
        Else
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT({NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)})")
            sbSQL.Append($" FROM {NameOf(R005_FCR_SASIMODOSI)} ")
            sbSQL.Append($" WHERE {NameOf(R005_FCR_SASIMODOSI.HOKOKU_NO)}='{strHOKOKU_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg)
            End Using

            Return intRET > 0
        End If
    End Function

    ''' <summary>
    ''' ログインユーザーが承認or申請したステージか判定
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">承認報告書ID</param>
    ''' <param name="strHOKOKU_NO">報告書No</param>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean

        Try
            Dim ToUsers As New List(Of Integer)

            'Select Case intSYONIN_JUN
            '    Case ENM_FCCB_STAGE._10_起草入力
            '        Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._10_起草入力)
            '        ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

            '    Case ENM_FCCB_STAGE._20_処置事項調査等
            '        'FCCB議長 起草者
            '        ToUsers.Add(_D009.CM_TANTO)
            '        ToUsers.Add(_D009.ADD_SYAIN_ID)
            '        '操作可能
            '        ToUsers.Add(pub_SYAIN_INFO.SYAIN_ID)

            '    Case ENM_FCCB_STAGE._30_変更審議

            '        ToUsers.Add(cmbCM_TANTO.SelectedValue)

            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
            '            ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
            '        End If

            '    Case ENM_FCCB_STAGE._40_処置確認

            '        ToUsers.Add(cmbCM_TANTO.SelectedValue)

            '        Dim IsAllChecked As Boolean = True
            '        If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
            '            IsAllChecked *= False
            '        End If
            '        If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
            '            '全ての担当者のチェックが完了したら統括責任者に依頼送信
            '            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '        Else
            '            '統括責任者のチェックも完了したら、各要処置事項の担当者に依頼送信
            '            Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next

            '            targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
            '                                    AsEnumerable.
            '                                    Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
            '                                    Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

            '            For Each usr In targetUsers
            '                If Not ToUsers.Contains(usr) Then
            '                    ToUsers.Add(usr)
            '                End If
            '            Next
            '        End If

            '    Case ENM_FCCB_STAGE._50_処置事項完了
            '        '裏処理にて各要処置事項の完了日の1週間前になっても未処置の場合、処置担当者に滞留通知

            '        '申請条件のチェック
            '        Dim IsClosed As Boolean = True
            '        IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
            '                                   AsEnumerable.
            '                                   Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
            '                                AsEnumerable.
            '                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS And r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

            '        '全要処置事項の処置完了
            '        If IsClosed Then
            '            'FCCB議長に依頼通知
            '            'If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
            '            ToUsers.Add(_D009.CM_TANTO)
            '            'Else
            '            '    ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
            '            'End If
            '        End If
            '    Case ENM_FCCB_STAGE._60_処置事項完了確認
            '        'ToUsers.Add(_D009.CM_TANTO)
            '        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)

            '    Case Else
            '        Throw New ArgumentException("想定外の承認ルートです", PrCurrentStage)
            'End Select

            Return ToUsers.Contains(pub_SYAIN_INFO.SYAIN_ID)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function IsNeedMeeting() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim sqlEx As New Exception
        Dim intRET As Integer

        'sbSQL.Append($"SELECT")
        'sbSQL.Append($" COUNT({NameOf(D012.TANTO_ID)})")
        'sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
        'sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
        'sbSQL.Append($" AND {NameOf(D012.TANTO_ID)}<>0 ")
        'sbSQL.Append($" AND RTRIM({NameOf(D012.KYOGI_YOHI_KAITO)})='1' ")
        Using DB = DBOpen()
            intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx).ToVal()
        End Using

        Return intRET > 0
    End Function

#End Region

#Region "添付ファイル"

    '添付ファイル選択
    Private Sub BtnOpenTempFileDialog_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog With {
            .Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Word(*.doc;*.docx)|*.doc;*.docx|すべてのファイル(*.*)|*.*",
            .FilterIndex = 1,
            .Title = "添付するファイルを選択してください",
            .RestoreDirectory = True
        }
        If lbltmpFile1.Links.Count = 0 Then
        Else
            ofd.InitialDirectory = IO.Path.GetDirectoryName(lbltmpFile1.Links(0).ToString)
        End If
        If ofd.ShowDialog() = DialogResult.OK Then
            lbltmpFile1.Text = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile1.Links.Clear()
            lbltmpFile1.Links.Add(0, lbltmpFile1.Text.Length, ofd.FileName)

            _D009.FILE_PATH = IO.Path.GetFileName(ofd.FileName)
            lbltmpFile1.Visible = True
            lbltmpFile1_Clear.Visible = True
        End If
    End Sub

    'リンククリック
    Private Sub LbltmpFile1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim hProcess As New System.Diagnostics.Process
        Dim strEXE As String
        'Dim strARG As String
        Try

            strEXE = lbltmpFile1.Links(0).LinkData
            If strEXE.IsNulOrWS Then
            Else
                If System.IO.File.Exists(strEXE) = True Then
                    hProcess.StartInfo.FileName = strEXE
                    'hProcess.StartInfo.Arguments = strARG
                    hProcess.SynchronizingObject = Me
                    'AddHandler hProcess.Exited, AddressOf ProcessExited
                    hProcess.EnableRaisingEvents = True
                    hProcess.Start()

                    '最前面
                    Call SetForegroundWindow(hProcess.Handle)

                    'Call SetTaskbarInfo(ENM_TASKBAR_STATE._2_Normal, 100)
                    'Call SetTaskbarOverlayIcon(System.Drawing.SystemIcons.Application)

                    'Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)
                    '    Call SetTaskbarOverlayIcon(Nothing)
                    '    Call SetTaskbarInfo(ENM_TASKBAR_STATE._0_NoProgress)
                    'End Sub
                Else
                    Dim strMsg As String
                    strMsg = "ファイルが見つかりません。" & vbCrLf & "システム管理者にご連絡下さい。" &
                                vbCrLf & vbCrLf & strEXE
                    MessageBox.Show(strMsg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch exInvalid As InvalidOperationException
            'EM.ErrorSyori(exInvalid, False, conblnNonMsg)
        Finally
            'プロセス終了を待機しない------------------------------------
            ''-----自分表示
            'Me.Show()
            'Me.lstGYOMU.Focus()
            'Me.Activate()
            'Me.BringToFront()
            '------------------------------------------------------------

            '-----開放
            If hProcess IsNot Nothing Then
                hProcess.Close()
            End If
        End Try
    End Sub

    'リンククリア
    Private Sub LbltmpFile1_Clear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        lbltmpFile1.Text = ""
        _D009.FILE_PATH = ""
        lbltmpFile1.Links.Clear()
        lbltmpFile1.Visible = False
        lbltmpFile1_Clear.Visible = False
    End Sub

#End Region

End Class