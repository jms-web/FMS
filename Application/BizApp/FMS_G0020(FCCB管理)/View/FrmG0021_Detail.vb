Imports System.Reflection.Emit
Imports System.Security.Policy
Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D010 = MODEL.D010_FCCB_SUB_SYOCHI_KOMOKU
Imports D011 = MODEL.D011_FCCB_SUB_SIKAKE_BUHIN

''' <summary>
''' FCCB登録画面
''' </summary>
Public Class FrmG0021_Detail

#Region "定数・変数"

    Private _D009 As New D009_FCCB_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)
    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        cmbKISYU.NullValue = 0
        dtKISO.Nullable = True


    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Async Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PrRIYU = ""
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

                        Call FunInitializeFlexGrid(flxDATA_2)
                        Call FunInitializeFlexGrid(flxDATA_3)
                        Call FunInitializeFlexGrid(flxDATA_4)
                        Call FunInitializeFlexGrid(flxDATA_5)

                        '--- モデルクリア
                        _D004_SYONIN_J_KANRI.clear()

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

#Region "FlexGrid関連"

    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30
            .AutoGenerateColumns = False
            .AutoResize = False
            .AllowEditing = True
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True
            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell

            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .Styles.Add("delStyle")
            .Styles("delStyle").ForeColor = Color.Red

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver

            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            .Styles.Normal.Border.Color = Color.Black

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Focus.BackColor = clrRowEnterColor

            For i As Integer = 1 To .Cols.Count - 1
                If .Cols(i).Name.Contains("YMD") Then
                    .Cols(i).DataType = GetType(Date)
                    .Cols(i).Format = "yyyy/MM/dd"
                End If
            Next
        End With
    End Function

    Private Sub Flex_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles flxDATA_2.StartEdit,
                                                                                                             flxDATA_3.StartEdit,
                                                                                                             flxDATA_5.StartEdit

        Try

            Dim flx = DirectCast(sender, C1FlexGrid)

            '担当部署→担当者リスト取得
            If flx.Cols(e.Col).Name = NameOf(D010.TANTO_GYOMU_GROUP_ID) Then

                Dim GYOMU_GROUP_ID As ENM_GYOMU_GROUP_ID
                Dim TANTO_COL_INDEX As Integer

                Select Case flx.Name
                    Case NameOf(flxDATA_2)
                        GYOMU_GROUP_ID = flx(e.Row, 4).ToString.ToVal
                        TANTO_COL_INDEX = 6
                    Case NameOf(flxDATA_3)
                        GYOMU_GROUP_ID = flx(e.Row, 2).ToString.ToVal
                        TANTO_COL_INDEX = 4
                    Case NameOf(flxDATA_5)
                        GYOMU_GROUP_ID = flx(e.Row, 2).ToString.ToVal
                        TANTO_COL_INDEX = 3
                    Case Else
                End Select

                flx.SetCellStyle(e.Row, TANTO_COL_INDEX, flx.Styles($"dtTANTO_{GYOMU_GROUP_ID.Value}"))
            End If
        Catch ex As Exception
            Throw
        End Try
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
                        If IsEditingClosed And PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then

                            Call OpenFormEdit()
                            If PrRIYU.IsNulOrWS Then
                                Exit Sub
                            End If
                        Else
                            If MessageBox.Show("入力内容を保存しますか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then Exit Sub
                        End If

                        If FunSAVE(ENM_SAVE_MODE._1_保存) Then
                            Me.DialogResult = DialogResult.OK
                            MessageBox.Show("入力内容を保存しました", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case 2  '承認申請

                    '入力チェック
                    If FunCheckInput(ENM_SAVE_MODE._2_承認申請) Then
                        Dim strMsg As String
                        If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                            strMsg = "承認しますか？"
                        Else
                            strMsg = "承認・申請しますか？"
                        End If

                        If MessageBox.Show(strMsg, "承認・申請処理確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            If FunSAVE(ENM_SAVE_MODE._2_承認申請) Then
                                If PrCurrentStage = ENM_FCCB_STAGE._61_処置事項完了確認_統括 Then
                                    strMsg = "承認しました"
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

                Case 4  '転送
                    Call ShowUnimplemented()
                    'If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                    '    If OpenFormTENSO() Then
                    '        If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    '            Me.DialogResult = DialogResult.OK
                    '        Else
                    '            If FunSAVE(ENM_SAVE_MODE._1_保存, True) Then
                    '                Me.DialogResult = DialogResult.OK
                    '            Else
                    '                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '            End If
                    '        End If
                    '    End If
                    'End If

                Case 5  '差し戻し
                    Call ShowUnimplemented()
                    'Call OpenFormSASIMODOSI()

                Case 10  '印刷
                    Call ShowUnimplemented()
                    'Call FunOpenReportFCCB()

                Case 11 '履歴
                    Call ShowUnimplemented()
                    'Call OpenFormHistory(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009_FCCB_J.HOKOKU_NO)

                Case 12 '閉じる
                    Me.Close()
                Case Else
            End Select
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

                    If FunSAVE_D009(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_D010(DB, enmSAVE_MODE) = False Then blnErr = True : Return False
                    If FunSAVE_D011(DB, enmSAVE_MODE) = False Then blnErr = True : Return False

                    If Not blnTENSO And PrCurrentStage < ENM_FCCB_STAGE._999_Closed Then
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

#Region "   D009"

    ''' <summary>
    ''' FCCB更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <returns></returns>
    Private Function FunSAVE_D009(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

#Region "モデル更新"


        If _D009_FCCB_J.FCCB_NO.IsNulOrWS Or _D009_FCCB_J.FCCB_NO = "<新規>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = NameOf(_D009_FCCB_J.FCCB_NO)
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST05_GET_FCCB_NO", lstParam) = True Then
                _D009_FCCB_J.FCCB_NO = DB.DbCommand.Parameters(NameOf(_D009_FCCB_J.FCCB_NO)).Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D009_FCCB_J._CLOSE_FG = 1
        End If

        _D009_FCCB_J.BUMON_KB = cmbBUMON.SelectedValue
        _D009_FCCB_J.KISYU_ID = cmbKISYU.SelectedValue
        If dtKISO.Text.IsNulOrWS Then
            _D009_FCCB_J.ADD_YMDHNS = strSysDate
        Else
            _D009_FCCB_J.ADD_YMDHNS = dtKISO.ValueDate.ToString("yyyyMMdd") & "000000"
        End If
        _D009_FCCB_J.CM_TANTO = cmbCM_TANTO.SelectedValue
        _D009_FCCB_J.BUHIN_BANGO = cmbBUHIN_BANGO.SelectedValue
        _D009_FCCB_J.SYANAI_CD = cmbSYANAI_CD.SelectedValue
        _D009_FCCB_J.BUHIN_NAME = cmbHINMEI.SelectedValue
        _D009_FCCB_J.INPUT_DOC_NO = mtxINPUT_DOC_NO.Text
        _D009_FCCB_J.SNO_APPLY_PERIOD_KISO = mtxSNO_APPLY_PERIOD_KISO.Text
        _D009_FCCB_J.SNO_APPLY_PERIOD_SINGI = mtxSNO_APPLY_PERIOD_HENKO_SINGI.Text
        _D009_FCCB_J.INPUT_NAIYO = txtINPUT_NAIYO.Text


        If cmbKISO_TANTO.IsSelected Then
            _D009_FCCB_J.ADD_SYAIN_ID = cmbKISO_TANTO.SelectedValue
        Else
            _D009_FCCB_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        End If

        _D009_FCCB_J.UPD_YMDHNS = strSysDate
        _D009_FCCB_J.UPD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _D009_FCCB_J.DEL_YMDHNS = ""
        _D009_FCCB_J.DEL_SYAIN_ID = 0

#End Region

        '-----MERGE
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append($"MERGE INTO {NameOf(D009_FCCB_J)} AS TARGET")
        sbSQL.Append($" USING (")
        sbSQL.Append($"{_D009_FCCB_J.ToSelectSqlString}")
        sbSQL.Append($" ) AS WK")
        sbSQL.Append($" ON (TARGET.{NameOf(_D009_FCCB_J.FCCB_NO)} = WK.{NameOf(_D009_FCCB_J.FCCB_NO)})")
        '---UPDATE
        sbSQL.Append($" WHEN MATCHED THEN")
        sbSQL.Append($" {_D009_FCCB_J.ToUpdateSqlString("TARGET", "WK")}")
        '---INSERT
        sbSQL.Append($" WHEN NOT MATCHED THEN")
        sbSQL.Append($" {_D009_FCCB_J.ToInsertSqlString("WK")}")
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
        WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009_FCCB_J.FCCB_NO}、MERGE D009_FCCB_J")

        Return True
    End Function

#End Region

#Region "   D010"

    Private Function FunSAVE_D010(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString

        Dim _D010 As New D010_FCCB_SUB_SYOCHI_KOMOKU

        For Each dr As DataRow In DirectCast(Flx2_DS.DataSource, DataTable).Rows

#Region "   モデル更新"

            _D010.Clear()
            _D010.FCCB_NO = dr.Item(NameOf(_D010.FCCB_NO))
            _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
            _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
            _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
            _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
            _D010.YOHI_KB = dr.Item(NameOf(_D010.YOHI_KB))
            _D010.TANTO_ID = dr.Item(NameOf(_D010.TANTO_ID))
            _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
            _D010.YOTEI_YMD = dr.Item(NameOf(_D010.YOTEI_YMD))
            _D010.CLOSE_YMD = dr.Item(NameOf(_D010.CLOSE_YMD))

#End Region

            sbSQL.Clear()
            sbSQL.Append($"MERGE INTO {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} AS TARGET")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_D010.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (TARGET.{NameOf(_D010.FCCB_NO)} = WK.{NameOf(_D010.FCCB_NO)}")
            sbSQL.Append($" AND TARGET.{NameOf(_D010.ITEM_NO)} = WK.{NameOf(_D010.ITEM_NO)})")
            '---UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" {_D010.ToUpdateSqlString("TARGET", "WK")}")
            '---INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN")
            sbSQL.Append($" {_D010.ToInsertSqlString("WK")}")
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
        Next

        WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D010.FCCB_NO}、MERGE D010")

        Return True
    End Function

#End Region

#Region "   D011"

    Private Function FunSAVE_D011(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim strSysDate As String = DB.GetSysDateString
        Dim _D011 As New D011_FCCB_SUB_SIKAKE_BUHIN

        Try

            For Each dr As DataRow In DirectCast(Flx2_DS.DataSource, DataTable).Rows

#Region "   モデル更新"

                _D011.Clear()
                _D011.FCCB_NO = dr.Item(NameOf(_D011.FCCB_NO))
                _D011.ITEM_NO = dr.Item(NameOf(_D011.ITEM_NO))
                _D011.BUHIN_HINBAN = dr.Item(NameOf(_D011.BUHIN_HINBAN))
                _D011.MEMO1 = dr.Item(NameOf(_D011.MEMO1))
                _D011.MEMO2 = dr.Item(NameOf(_D011.MEMO2))
                _D011.SURYO = dr.Item(NameOf(_D011.SURYO))
                _D011.SYOCHI_NAIYO = dr.Item(NameOf(_D011.SYOCHI_NAIYO))
                _D011.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D011.TANTO_GYOMU_GROUP_ID))
                _D011.TANTO_ID = dr.Item(NameOf(_D011.TANTO_ID))
                _D011.YOTEI_YMD = dr.Item(NameOf(_D011.YOTEI_YMD))
                _D011.CLOSE_YMD = dr.Item(NameOf(_D011.CLOSE_YMD))

#End Region

                sbSQL.Clear()
                sbSQL.Append($"MERGE INTO {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN)} AS TARGET")
                sbSQL.Append($" USING (")
                sbSQL.Append($"{_D011.ToSelectSqlString}")
                sbSQL.Append($" ) AS WK")
                sbSQL.Append($" ON (TARGET.{NameOf(_D011.FCCB_NO)} = WK.{NameOf(_D011.FCCB_NO)}")
                sbSQL.Append($" AND TARGET.{NameOf(_D011.ITEM_NO)} = WK.{NameOf(_D011.ITEM_NO)})")
                '---UPDATE
                sbSQL.Append($" WHEN MATCHED THEN")
                sbSQL.Append($" {_D011.ToUpdateSqlString("TARGET", "WK")}")
                '---INSERT
                sbSQL.Append($" WHEN NOT MATCHED THEN")
                sbSQL.Append($" {_D011.ToInsertSqlString("WK")}")
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
            Next

            WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D011.FCCB_NO}、MERGE D010")

            Return True
        Catch ex As Exception
            Throw
        End Try

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
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D009_FCCB_J.FCCB_NO
            _D004_SYONIN_J_KANRI.MAIL_SEND_FG = True
            _D004_SYONIN_J_KANRI.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
            _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

            If PrCurrentStage = ENM_FCCB_STAGE._10_起草入力 Then
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
                    _D004_SYONIN_J_KANRI.SYAIN_ID = cmbDestTANTO.SelectedValue
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate
                Case Else
                    'Err
                    Return False
            End Select

            '-----Close処理
            If _D004_SYONIN_J_KANRI.SYONIN_JUN = ENM_FCCB_STAGE._999_Closed Then
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
                    If _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認 Then
                        '承認依頼メール送信
                        If FunSendRequestMail() Then
                            WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009_FCCB_J.FCCB_NO}、Send Request Mail")
                        End If
                    End If

                Case "UPDATE"

                Case Else
                    '-----エラーログ出力
                    Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                    WL.WriteLogDat(strErrMsg)
                    Return False
            End Select

            WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009_FCCB_J.FCCB_NO}、MERGE D004")

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
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = _D009_FCCB_J.KISYU_ID
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("承認判定区分").AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = _D004_SYONIN_J_KANRI.SYAIN_ID & "," & ENM_OPEN_MODE._2_処置画面起動 & "," & Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR & "," & _D004_SYONIN_J_KANRI.HOKOKU_NO
        Dim strSubject As String = $"【不適合品処置依頼】[CTS] {KISYU_NAME}"
        Dim strBody As String = <sql><![CDATA[
        {0} 殿<br />
        <br />
        　FCCB調査書の処置依頼が来ましたので対応をお願いします。<br />
        <br />
        　　【報 告 書】FCCB<br />
        　　【報告書No】{1}<br />
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

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID),
                                _D004_SYONIN_J_KANRI.HOKOKU_NO,
                                CDate(_D009_FCCB_J.ADD_YMDHNS).ToString("yyyy/MM/dd"),
                                KISYU_NAME,
                                "",
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.COMMENT,
                                _D004_SYONIN_J_KANRI.SYAIN_ID,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=_D004_SYONIN_J_KANRI.SYAIN_ID) Then
            Return True
        Else
            MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

#End Region

#Region "SAVE R001"

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
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D009_FCCB_J.FCCB_NO
        _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.RIYU = PrRIYU
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")

        Select Case enmSAVE_MODE
            Case ENM_SAVE_MODE._1_保存

                If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
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

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D009_FCCB_J.FCCB_NO}、INSERT R001")



        Return True
    End Function

#End Region

#End Region

#Region "転送"

    Private Function OpenFormTENSO() As Boolean
        Dim frmDLG As New FrmG0025_Tenso
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
        Dim frmDLG As New FrmG0026_Sasimodosi
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = PrFCCB_NO
            frmDLG.PrBUHIN_BANGO = _D009.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
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
            strOutputFileName = "CTS_" & _D009_FCCB_J.FCCB_NO & "_Work.xls"

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
            'If FunMakeReportFCCB(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, _D009_FCCB_J.HOKOKU_NO) = False Then
            '    Return False
            'End If

            'Excel起動
            'Return FunOpenExcelApp(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName)
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
        Dim frmDLG As New FrmG0022_Rireki
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = SYONIN_HOKOKU_ID
            frmDLG.PrHOKOKU_NO = HOKOKU_NO
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
        Dim frmDLG As New FrmG0024_EditComment
        Dim dlgRET As DialogResult

        Try
            frmDLG.PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
            frmDLG.PrHOKOKU_NO = _D009_FCCB_J.FCCB_NO
            frmDLG.PrBUMON_KB = _D009_FCCB_J.BUMON_KB
            frmDLG.PrBUHIN_BANGO = _D009_FCCB_J.BUHIN_BANGO
            frmDLG.PrKISO_YMD = DateTime.ParseExact(_D009_FCCB_J.ADD_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            frmDLG.PrKISYU_NAME = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D009_FCCB_J.KISYU_ID).FirstOrDefault?.Item("DISP")
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

            If PrMODE = ENM_DATA_OPERATION_MODE._1_ADD Then
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
            Else

                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True


                'カレントステージが自身の担当でない場合は無効
                Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value, _D009.FCCB_NO, PrCurrentStage)
                If IsOwnCreated Then
                    cmdFunc1.Enabled = True
                    cmdFunc2.Enabled = True
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                Else
                    cmdFunc1.Enabled = False
                    cmdFunc2.Enabled = False
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                End If

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_起草入力
                        cmdFunc5.Enabled = False
                    Case Else
                End Select

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If

                If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
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
                End If
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
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
        'tabSTAGE01.AutoScrollControlIntoView = True
        'Select Case intStageID
        '    Case ENM_CAR_STAGE2._1_起草入力 To ENM_CAR_STAGE2._7_起草確認_品証課長
        '        tabSTAGE01.ScrollControlIntoView(lblSETUMON_1)

        '        pnlFCR.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._8_処置実施記録入力, ENM_CAR_STAGE2._9_処置実施確認
        '        tabSTAGE01.ScrollControlIntoView(lblSYOCHI_KIROKUFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.FixedSingle
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._10_是正有効性記入 To ENM_CAR_STAGE2._12_是正有効性確認_品証TL
        '        tabSTAGE01.ScrollControlIntoView(lblZESEI_SYOCHIFlame)

        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.FixedSingle
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.None

        '    Case ENM_CAR_STAGE2._13_是正有効性確認_品証担当課長
        '        tabSTAGE01.ScrollControlIntoView(lblSTAGEFlame13)
        '        pnlFCR.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_KIROKU.BorderStyle = BorderStyle.None
        '        pnlZESEI_SYOCHI.BorderStyle = BorderStyle.None
        '        pnlSYOCHI_JISSI.BorderStyle = BorderStyle.FixedSingle

        'End Select
        'tabSTAGE01.AutoScrollControlIntoView = False

    End Sub
    Private Sub CmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated

        If cmbBUMON.IsSelected Then
            Call SetTantoColumnDataList(cmbBUMON.SelectedValue)

            Dim dt As DataTable
            dt = GetKISO_TANTO(cmbBUMON.SelectedValue)
            cmbKISO_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, FunGetNextSYONIN_JUN(ENM_FCCB_STAGE._10_起草入力))
            cmbCM_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
        End If
    End Sub

#Region "機種"

    Private Async Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Await Task.Run(
            Sub()
                Me.Invoke(
                Sub()
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.DisplayMember = "DISP"

                    '部品番号
                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    If cmb.IsSelected Then
                        Dim drs = tblBUHIN.LazyLoad("部品番号").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue).ToList
                        If drs.Count > 0 Then
                            Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                            cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                            If Not cmbBUHIN_BANGO.NullValue = _selectedValue Then _D009.BUHIN_BANGO = _selectedValue
                        Else
                            drs = tblBUHIN.LazyLoad("部品番号").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                            If drs.Count > 0 Then
                                cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                            End If
                        End If
                    Else
                        Dim drs = tblBUHIN.LazyLoad("部品番号").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                        If drs.Count > 0 Then
                            cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        End If
                    End If
                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                    '社内コード
                    RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                    If cmb.IsSelected Then
                        If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            Dim drs = tblSYANAI_CD.LazyLoad("社内CD").AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D009.KISYU_ID)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then
                                Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                                cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                                If Val(_selectedValue) > 0 Then _D009.SYANAI_CD = _selectedValue
                            End If
                        Else
                            'cmbSYANAI_CD.DataSource = Nothing
                        End If
                        '_D003_NCR_J.SYANAI_CD = ""
                    Else
                        Dim drs = tblSYANAI_CD.LazyLoad("社内CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUMON_KB)) = cmbBUMON.SelectedValue).ToList
                        If drs.Count > 0 Then
                            cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        End If
                    End If
                    AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                End Sub)
            End Sub)
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))
        End If
    End Sub

#End Region

#Region "社内コード"

    Private Async Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSYANAI_CD.SelectedValueChanged
        Try
            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

            Await Task.Run(
                Sub()
                    Me.Invoke(
                    Sub()

                        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                        ''部品番号
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                        If cmb.IsSelected Then
                            Dim drs = tblBUHIN.LazyLoad("部品番号").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.SYANAI_CD)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then
                                cmbBUHIN_BANGO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                                'If drs.Count = 1 Then
                                '    _D003_NCR_J.BUHIN_BANGO = drs(0).Item("DISP")
                                'Else
                                '    _D003_NCR_J.BUHIN_BANGO = ""
                                'End If
                            End If
                        Else
                            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("部品番号").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                        End If

                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

                        ''抽出
                        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                        cmbKISYU.DataBindings.Clear()
                        cmbBUHIN_BANGO.DataBindings.Clear()
                        If cmb.IsSelected Then
                            Dim dr = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).FirstOrDefault
                            If dr IsNot Nothing Then
                                _D009.BUHIN_BANGO = dr.Item(NameOf(D003_NCR_J.BUHIN_BANGO))
                                If _D009.BUHIN_NAME.IsNulOrWS Then _D009.BUHIN_NAME = dr.Item(NameOf(D003_NCR_J.BUHIN_NAME))
                                If dr.Item(NameOf(D003_NCR_J.KISYU_ID)) <> 0 Then _D009.KISYU_ID = dr.Item(NameOf(D003_NCR_J.KISYU_ID))
                            Else
                                _D009.BUHIN_BANGO = " "
                                _D009.BUHIN_NAME = " "
                                _D009.KISYU_ID = 0
                            End If
                        Else
                            _D009.BUHIN_BANGO = " "
                            _D009.BUHIN_NAME = " "
                            _D009.KISYU_ID = 0
                        End If
                        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged


                    End Sub)
                End Sub)
        Finally
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        End Try
    End Sub

    Private Sub CmbSYANAI_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYANAI_CD.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If _D009.BUMON_KB.ToVal = Context.ENM_BUMON_KB._2_LP Then
            If IsCheckRequired Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社内コード"))
            End If
        End If
    End Sub

#End Region

#Region "部品番号"

    Private Async Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUHIN_BANGO.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Await Task.Run(
            Sub()
                Me.Invoke(
                Sub()

                    RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                    RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                    '社内コード
                    If cmb.IsSelected Then

                        If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            Dim drs = tblSYANAI_CD.LazyLoad("社内CD").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                            If drs.Count > 0 Then
                                Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                                cmbSYANAI_CD.DisplayMember = "DISP"
                                cmbSYANAI_CD.ValueMember = "VALUE"
                                cmbSYANAI_CD.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                                If Not cmbSYANAI_CD.NullValue = _selectedValue Then cmbSYANAI_CD.SelectedValue = _selectedValue
                            End If
                        Else
                            cmbSYANAI_CD.SelectedValue = ""
                            'cmbSYANAI_CD.DataSource = Nothing
                        End If

                    Else
                        cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("社内CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
                    End If
                    AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

                    '抽出 判定
                    If cmb.IsSelected Then
                        Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmb.SelectedValue).FirstOrDefault
                        If Val(cmbBUMON.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                            _D009.SYANAI_CD = dr.Item("SYANAI_CD")
                            If dr.Item("BUHIN_NAME").ToString.IsNulOrWS = False Then cmbHINMEI.Text = dr.Item("BUHIN_NAME")
                        Else
                            cmbHINMEI.Text = dr?.Item("BUHIN_NAME")
                        End If

                        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
                        If dr?.Item("KISYU_ID") <> 0 Then _D009.KISYU_ID = dr?.Item("KISYU_ID")
                        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged


                    Else
                        cmbSYANAI_CD.SelectedValue = ""
                        cmbHINMEI.Text = ""
                        cmbKISYU.SelectedValue = 0
                    End If

                    AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
                End Sub)
            End Sub)

    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))
        End If
    End Sub

#End Region

#End Region


#End Region

#Region "ローカル関数"

#Region "処理モード別画面初期化"

    Private Function FunInitializeControls(intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Try
            IsInitializing = True
            'ナビゲートリンク選択
            If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----コントロールデータソース設定
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU.LazyLoad("機種"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("部品番号"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("社内CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'UNDONE: 業務グループリストソース取得関数化
            Dim BUSYOList As New SortedList(Of Integer, String)
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._1_技術.Value, "技術")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._2_製造.Value, "製造")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._3_検査.Value, "検査")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._4_品証.Value, "品証")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._5_設計.Value, "設計")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._6_生技.Value, "生技")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._7_管理.Value, "管理")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._8_営業.Value, "営業")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._9_購買.Value, "購買")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._46_品検.Value, "品/検")
            flxDATA_2.Cols(4).DataMap = BUSYOList
            flxDATA_3.Cols(3).DataMap = BUSYOList
            flxDATA_5.Cols(2).DataMap = BUSYOList


            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    mtxFCCB_NO.Text = "<新規>"
                    _D009_FCCB_J.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D009_FCCB_J.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D009_FCCB_J.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
                    End If

#Region "InitDS"
                    Using DB As ClsDbUtility = DBOpen()
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As DataSet

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" ,'' AS {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,'0' AS {NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" , 0 AS {NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}<100 ")


                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        Dim Sec2 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx2_DS.DataSource = Sec2.Data

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" ,'' AS {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,'0' AS {NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" , 0 AS {NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(M017_FCCB_SUB_SYOCHI_KOMOKU.ITEM_NO)}>100 ")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)


                        Dim Sec3 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx3_DS.DataSource = Sec3.Data

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  '' AS {NameOf(D011.FCCB_NO)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.ITEM_NO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.BUHIN_HINBAN)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.BUHIN_NAME)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.MEMO1)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.MEMO2)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.SURYO)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.SYOCHI_NAIYO)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" , 0 AS {NameOf(D011.TANTO_ID)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.YOTEI_YMD)}")
                        sbSQL.Append($" ,'' AS {NameOf(D011.CLOSE_YMD)}")

                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec4 As New ModelInfo(Of D011)(srcDATA:=dsList.Tables(0))
                        For i As Integer = 1 To 4
                            Dim dr As DataRow = Sec4.Data.NewRow
                            dr.ItemArray = Sec4.Data.Rows(0).ItemArray
                            dr.Item(NameOf(D011.ITEM_NO)) = i
                            Sec4.Data.Rows.Add(dr)
                        Next
                        Sec4.Data.Rows(0).Delete()
                        Sec4.Data.AcceptChanges()
                        Flx4_DS.DataSource = Sec4.Data
                    End Using

#End Region

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)
                    _D009_FCCB_J = FunGetD009Model(PrFCCB_NO)

                    Call SetTantoColumnDataList(_D009_FCCB_J.BUMON_KB)

                    'データソース設定
                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009_FCCB_J.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, FunGetNextSYONIN_JUN(PrCurrentStage))
                    cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

                    dt = tblKISYU.LazyLoad("機種").AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(_D009_FCCB_J.BUMON_KB)) = PrDataRow.Item("BUMON_KB")).CopyToDataTable
                    If _D009_FCCB_J.BUMON_KB = "2" Then 'LP
                        dt = dt.AsEnumerable.Where(Function(r) r.Item("DISP") = "LP").CopyToDataTable
                    End If


            End Select

            If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                '最終ステージの場合、申請先担当者欄は非表示

                lblDestTanto.Visible = False
                cmbDestTANTO.Visible = False
                cmdFunc2.Text = "承認(F2)"
            Else
                cmdFunc2.Text = "承認・申請(F2)"
            End If

            ErrorProvider.ClearError(cmbDestTANTO)

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            IsInitializing = False
        End Try
    End Function

    Private Sub SetTantoColumnDataList(selectedValue As String)

        Try

            Dim grp = [Enum].GetValues(GetType(ENM_GYOMU_GROUP_ID)).Cast(Of ENM_GYOMU_GROUP_ID)().
                             Where(Function(e) e.Value < ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value)

            '所属部署全体の社員を取得
            Dim dt = FunGetSYOZOKU_SYAIN(selectedValue)
            Dim dtTANTO As New SortedList
            dtTANTO.Add(0, "未選択")
            For Each dr In dt.Rows
                If Not dtTANTO.Contains(dr.Item("VALUE").ToString.ToVal) Then
                    dtTANTO.Add(dr.Item("VALUE").ToString.ToVal, dr.Item("DISP"))
                End If
            Next
            flxDATA_2.Cols(6).DataMap = dtTANTO
            flxDATA_3.Cols(4).DataMap = dtTANTO
            flxDATA_5.Cols(3).DataMap = dtTANTO

            For Each GROUP_ID In grp

                '複合業務グループを分割
                Dim ids = GROUP_ID.Value.ToString.ToArray

                '対象業務グループの社員を抽出
                Dim drs = dt.AsEnumerable.
                         Where(Function(r) ids.Contains(r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)).ToString)).
                         GroupBy(Function(r) r.Item("VALUE")).
                         Select(Function(g) g.FirstOrDefault)

                dtTANTO = New SortedList
                For Each dr In drs
                    If Not dtTANTO.Contains(dr.Item("VALUE").ToString.ToVal) Then
                        dtTANTO.Add(dr.Item("VALUE").ToString.ToVal, dr.Item("DISP"))
                    End If
                Next

                If Not flxDATA_2.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_2.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_2.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

                If Not flxDATA_3.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_3.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_2.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

                If Not flxDATA_2.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_2.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_2.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Function GetKISO_TANTO(BUMON_KB As String) As DataTable

        Try
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(BUMON_KB)
            Dim drs As IEnumerable(Of DataRow)
            Dim InList As New List(Of Integer)

            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._4_品証.Value, ENM_GYOMU_GROUP_ID._5_設計.Value, ENM_GYOMU_GROUP_ID._6_生技.Value, ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value})
            drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                  GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function SetTANTO_TooltipInfo() As Boolean

        Call SetInfoLabelFormat(lblKISO_TANTO, $"社員業務グループマスタ{vbCr}以下の業務グループに登録された担当者{vbCrLf}{vbCrLf}QMS管理責任者・設計・品証・生技")
        Call SetInfoLabelFormat(lblCM_TANTO, $"承認担当者マスタ{vbCr}所属部門のST1.に登録された担当者")
        Call SetInfoLabelFormat(lblDestTanto, $"承認担当者マスタ{vbCr}所属部門の当該ステージに登録された担当者")

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
            '-----共通
            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 And FunGetNextSYONIN_JUN(PrCurrentStage) < ENM_FCCB_STAGE._999_Closed Then
                Call CmbDestTANTO_Validating(cmbDestTANTO, Nothing)
            End If

            IsValidated *= ErrorProvider.UpdateErrorInfo(cmbBUMON, cmbBUMON.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKISO_TANTO, cmbKISO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmbCM_TANTO, cmbCM_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))


            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
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
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)} ")
        sbSQL.Append($" WHERE {NameOf(V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKUSYO_ID}")
        sbSQL.Append($" And {NameOf(V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO.Trim}'")
        sbSQL.Append($" ORDER BY {NameOf(V003_SYONIN_J_KANRI.SYONIN_JUN)} DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        With dsList.Tables(0)
            If .Rows.Count = 0 Then
                Return ""
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
            Const stageLength As Integer = 10

            'If KOKYAKU_HANTEI_KB = False Then
            '    'なし時 #256
            '    If CurrentStageID >= ENM_FCCB_STAGE._70_品証課 Then
            '        Return ENM_FCCB_STAGE._999_Closed
            '    Else
            '        Return CurrentStageID + stageLength
            '    End If
            'Else
            '    Select Case CurrentStageID
            '        Case ENM_CTS_STAGE._90_部門長, ENM_CTS_STAGE._999_Closed
            '            Return ENM_CTS_STAGE._999_Closed
            '        Case Else
            Return CurrentStageID + stageLength
            '    End Select
            'End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return 0
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
    Private Sub ShowUnimplemented()
        MessageBox.Show("未実装", "未実装", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region





End Class