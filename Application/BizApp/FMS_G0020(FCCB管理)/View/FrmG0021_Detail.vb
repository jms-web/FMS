Imports System.Threading.Tasks
Imports C1.Win.C1FlexGrid
Imports JMS_COMMON.ClsPubMethod
Imports MODEL
Imports D010 = MODEL.D010_FCCB_SUB_SYOCHI_KOMOKU
Imports D011 = MODEL.D011_FCCB_SUB_SIKAKE_BUHIN
Imports D012 = MODEL.D012_FCCB_SUB_SYOCHI_KAKUNIN

''' <summary>
''' FCCB登録画面
''' </summary>
Public Class FrmG0021_Detail

#Region "定数・変数"

    'Private _D009 As New D009_FCCB_J
    Private _V003_SYONIN_J_KANRI_List As New List(Of V003_SYONIN_J_KANRI)

    Private IsEditingClosed As Boolean
    Private IsInitializing As Boolean

    Private USER_GYOMU_KENGEN_LIST As New List(Of ENM_GYOMU_GROUP_ID)

    Private Flx2_DS_DB As DataTable
    Private Flx3_DS_DB As DataTable
    Private Flx4_DS_DB As DataTable

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
        cmbKISO_TANTO.NullValue = 0
        cmbCM_TANTO.NullValue = 0

        dtKISO.Nullable = True
        cmbSYOCHI_GM_TANTO.NullValue = 0
        cmbSYOCHI_SEKKEI_TANTO.NullValue = 0
        cmbSYOCHI_SEIZO_TANTO.NullValue = 0
        cmbSYOCHI_SEIGI_TANTO.NullValue = 0
        cmbSYOCHI_EIGYO_TANTO.NullValue = 0
        cmbSYOCHI_KANRI_TANTO.NullValue = 0
        cmbSYOCHI_HINSYO_TANTO.NullValue = 0
        cmbSYOCHI_KENSA_TANTO.NullValue = 0
        cmbSYOCHI_KOBAI_TANTO.NullValue = 0

        cmbKAKUNIN_CM_TANTO.NullValue = 0
        cmbKAKUNIN_GM_TANTO.NullValue = 0

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

                        Call FunInitializeFlexGrid(flxDATA_2)
                        Call FunInitializeFlexGrid(flxDATA_3)
                        Call FunInitializeFlexGrid(flxDATA_4)
                        Call FunInitializeFlexGrid(flxDATA_5)

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

            .EditOptions = EditFlags.UseNumericEditor

            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Normal.BackColor = clrDeletedRowBackColor
            .Styles.Normal.ForeColor = clrDeletedRowForeColor

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .Styles.Add("TANTO_GROUP")
            .Styles("TANTO_GROUP").BackColor = Color.LemonChiffon
            .Styles("TANTO_GROUP").ForeColor = Color.Blue

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver

            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            .Styles.Normal.Border.Color = Color.Black

            .Rows.DefaultSize = 24

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Focus.BackColor = clrRowEnterColor

            For i As Integer = 1 To .Cols.Count - 1
                If .Cols(i).Name.Contains("YMD") Then
                    .Cols(i).DataType = GetType(Date)
                    '.Cols(i).Format = "yyyy/MM/dd"
                    '.Cols(i).EditMask = "0000/00/00"
                End If
            Next
        End With
    End Function

    Private Sub FlxDATA_AfterAddRow(sender As Object, e As RowColEventArgs) Handles flxDATA_4.AfterAddRow
        Try
            Dim flx = DirectCast(sender, C1FlexGrid)

            flx(e.Row, NameOf(D011.ITEM_NO)) = flx.Rows.Count - 2
            flx(e.Row, NameOf(D011.SURYO)) = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Flex_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles flxDATA_2.StartEdit,
                                                                                                             flxDATA_3.StartEdit,
                                                                                                             flxDATA_5.StartEdit

        Try

            Dim flx = DirectCast(sender, C1FlexGrid)
            Dim GYOMU_GROUP_ID As ENM_GYOMU_GROUP_ID
            Dim TANTO_COL_INDEX As Integer
            Dim ds As DataTable
            Select Case flx.Name
                Case NameOf(flxDATA_2)
                    GYOMU_GROUP_ID = flx(e.Row, 4).ToString.ToVal
                    TANTO_COL_INDEX = 6
                    ds = Flx2_DS.DataSource
                Case NameOf(flxDATA_3)
                    GYOMU_GROUP_ID = flx(e.Row, 3).ToString.ToVal
                    TANTO_COL_INDEX = 5
                    ds = Flx3_DS.DataSource
                Case NameOf(flxDATA_5)
                    GYOMU_GROUP_ID = flx(e.Row, 3).ToString.ToVal
                    TANTO_COL_INDEX = 4
                    ds = Flx4_DS.DataSource
                Case Else
                    Throw New ArgumentException("想定外のデータソースです", flx.Name)
            End Select

            '担当部署→担当者リスト取得
            Select Case flx.Cols(e.Col).Name
                Case NameOf(D010.TANTO_GYOMU_GROUP_ID)
                    If GYOMU_GROUP_ID <> 0 Then
                        flx.SetCellStyle(e.Row, TANTO_COL_INDEX, flx.Styles($"dtTANTO_{GYOMU_GROUP_ID.Value}"))
                    End If
                Case NameOf(D010.TANTO_ID)
                    If GYOMU_GROUP_ID <> 0 Then
                        flx.SetCellStyle(e.Row, TANTO_COL_INDEX, flx.Styles($"dtTANTO_{GYOMU_GROUP_ID.Value}"))
                    End If
                    If flx.Name <> NameOf(flxDATA_5) AndAlso Not flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        e.Cancel = True
                    End If
                Case NameOf(D010.YOHI_KB)
                    If flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        flx(e.Row, NameOf(D010.TANTO_ID)) = 0
                        flx(e.Row, NameOf(D010.NAIYO)) = ""
                        flx(e.Row, NameOf(D010.YOTEI_YMD)) = ""
                    End If
                Case Else
                    If flx.Name <> NameOf(flxDATA_5) AndAlso Not flx(e.Row, NameOf(D010.YOHI_KB)) Then
                        e.Cancel = True
                    End If
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ' 入力チェック
    Private Sub Flx_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles flxDATA_2.ValidateEdit,
                                                                                                                      flxDATA_3.ValidateEdit,
                                                                                                                      flxDATA_5.ValidateEdit

        Dim flx = DirectCast(sender, C1FlexGrid)

        If flx.Cols(e.Col).Name.Contains("YMD") Then
            Dim d As Date
            If Not Date.TryParse(flx.Editor.Text, d) Then
                e.Cancel = True
                MessageBox.Show("無効な日付です")
            End If
        End If
    End Sub

    Private Sub Flx_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles flxDATA_2.AfterEdit,
                                                                                                             flxDATA_3.AfterEdit,
                                                                                                             flxDATA_5.AfterEdit

        Try

            Dim flx = DirectCast(sender, C1FlexGrid)

            Select Case True
                Case flx.Cols(e.Col).Name.Contains("YMD")

                    'flexgrid 2019J以前の不具合対応(令和日付で.formatが無視される)
                    Dim value As String = Nz(flx(e.Row, e.Col), "")
                    If Not value.IsNulOrWS Then
                        flx(e.Row, e.Col) = CDate(value).ToString("yyyy/MM/dd")
                    End If
                Case flx.Cols(e.Col).Name = "YOHI_KB"

                    If flx(e.Row, e.Col) Then
                        flx.Rows(e.Row).Style = flx.Styles("TANTO_GROUP")
                    Else
                        flx.Rows(e.Row).Style = flx.Styles("DeletedRow")
                    End If

                Case Else

            End Select
        Catch ex As Exception
            Throw
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    Private Sub FlxDATA_AfterSort(sender As Object, e As SortColEventArgs) Handles flxDATA_2.AfterSort, flxDATA_3.AfterSort, flxDATA_5.AfterSort
        Call SetFlxDATA_EditStatus(sender)
    End Sub

    Private Sub SetFlxDATA_EditStatus(flx As C1FlexGrid)

        Dim InList As New List(Of Integer)
        Dim HasSIKAKARI_KENGEN As Boolean
        If flx.Name = NameOf(flxDATA_4) Then
            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue)


            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._7_管理.Value, ENM_GYOMU_GROUP_ID._8_営業.Value})
            Dim drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                      GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            HasSIKAKARI_KENGEN = drs.Where(Function(r) r.Item("VALUE") = pub_SYAIN_INFO.SYAIN_ID.ToString).Count > 0
        End If

        '編集権限設定
        For i As Integer = 1 To flx.Rows.Count - 1

            Select Case flx.Name
                Case NameOf(flxDATA_2), NameOf(flxDATA_3)

                    If _D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or
                        _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Or
                        USER_GYOMU_KENGEN_LIST.Contains(flx.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then

                        flx.Rows(i).AllowEditing = True
                        If flx.Rows(i).Item("YOHI_KB") Then
                            flx.Rows(i).Style = flx.Styles("TANTO_GROUP")
                        Else
                            flx.Rows(i).Style = Nothing
                        End If
                    Else

                        '担当業務以外は編集不可
                        flx.Rows(i).Style = flx.Styles("DeletedRow")
                        flx.Rows(i).AllowEditing = False
                    End If

                Case Else
                    flx.Rows(i).Style = flx.Styles("TANTO_GROUP")

                    '管理・営業 + 議長・起草者
                    flx.Rows(i).AllowEditing = (_D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID) Or HasSIKAKARI_KENGEN
            End Select

        Next
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
                            Dim strMsg As String = "入力内容を保存しました。"

                            '他の担当者も含めて必須項目入力済みの場合、FCCB議長への申請処理へ移行
                            Select Case PrCurrentStage
                                Case ENM_FCCB_STAGE._20_処置事項調査等.Value
                                    If IsInputRequired_DB() Then
                                        If FunSendRequestMail(fromUserNAME:="FCCB管理システム", toUserNAME:=cmbCM_TANTO.Text) Then
                                            strMsg &= $"{vbCrLf}また、全ての要入力項目が完了したため、FCCB議長に処置申請を送信しました。"
                                        End If
                                    End If
                            End Select

                            MessageBox.Show(strMsg, "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                                'SPEC: 2.(3).E.④
                                Me.Close()
                            Else
                                MessageBox.Show("保存処理に失敗しました。", "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If

                Case 4  '転送

                    If FunCheckInput(ENM_SAVE_MODE._1_保存) Then
                        If OpenFormTENSO() Then
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
                    If FunSAVE_D012(DB, enmSAVE_MODE) = False Then blnErr = True : Return False

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

        If _D009.FCCB_NO.IsNulOrWS Or _D009.FCCB_NO = "<新規>" Then
            Dim objParam As System.Data.Common.DbParameter = DB.DbCommand.CreateParameter
            Dim lstParam As New List(Of System.Data.Common.DbParameter)
            With objParam
                .ParameterName = "HOKOKU_NO"
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 8
            End With
            lstParam.Add(objParam)
            If DB.Fun_blnExecStored("dbo.ST05_GET_FCCB_NO", lstParam) = True Then
                _D009.FCCB_NO = DB.DbCommand.Parameters("HOKOKU_NO").Value
            Else
                Return False
            End If
        End If

        If (FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed) And enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then
            _D009._CLOSE_FG = 1
        End If

        _D009.BUMON_KB = cmbBUMON.SelectedValue
        _D009.KISYU_ID = cmbKISYU.SelectedValue
        If dtKISO.Text.IsNulOrWS Then
            _D009.ADD_YMDHNS = strSysDate
        Else
            _D009.ADD_YMDHNS = dtKISO.ValueDate.ToString("yyyyMMdd") & "000000"
        End If
        _D009.CM_TANTO = cmbCM_TANTO.SelectedValue
        _D009.BUHIN_BANGO = cmbBUHIN_BANGO.SelectedValue
        _D009.SYANAI_CD = cmbSYANAI_CD.SelectedValue
        _D009.BUHIN_NAME = If(cmbHINMEI.Text <> "(選択)", cmbHINMEI.Text, "")
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

#Region "   D010"

    Private Function FunSAVE_D010(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean

        Try

            Dim sbSQL As New System.Text.StringBuilder
            Dim strRET As String
            Dim sqlEx As New Exception
            Dim strSysDate As String = DB.GetSysDateString
            Dim _D010 As New D010
            Dim groups = GetSYAIN_GYOMUGroups(pub_SYAIN_INFO.SYAIN_ID)

            For Each dr As DataRow In DirectCast(Flx2_DS.DataSource, DataTable).Rows

                If _D009.CM_TANTO = pub_SYAIN_INFO.SYAIN_ID Or _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Then
                    '起草者 or FCCB議長は全部更新可能
                Else
                    If Not groups.Contains(dr.Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then

                        '自身の業務グループ項目以外は更新しない
                        Continue For
                    End If
                End If

                Dim drOrg As DataRow = Flx2_DS_DB?.AsEnumerable.Where(Function(r) r.Item(NameOf(D010.ITEM_NO)) = dr.Item(NameOf(D010.ITEM_NO))).FirstOrDefault
                If drOrg IsNot Nothing AndAlso drOrg.Equals(dr) Then
                    'ロード時以降変更された場合のみ更新
                    Continue For
                End If

#Region "   モデル更新"

                _D010.Clear()
                _D010.FCCB_NO = _D009.FCCB_NO
                _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
                _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
                _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
                _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
                _D010.YOHI_KB = dr.Item(NameOf(_D010.YOHI_KB))
                _D010.TANTO_ID = dr.Item(NameOf(_D010.TANTO_ID))
                _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
                If Not dr.Item(NameOf(_D010.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D010.YOTEI_YMD = CDate(dr.Item(NameOf(_D010.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D010.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D010.CLOSE_YMD = CDate(dr.Item(NameOf(_D010.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

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

            For Each dr As DataRow In DirectCast(Flx3_DS.DataSource, DataTable).Rows

#Region "   モデル更新"

                _D010.Clear()
                _D010.FCCB_NO = _D009.FCCB_NO
                _D010.ITEM_NO = dr.Item(NameOf(_D010.ITEM_NO))
                _D010.ITEM_GROUP_NAME = dr.Item(NameOf(_D010.ITEM_GROUP_NAME))
                _D010.ITEM_NAME = dr.Item(NameOf(_D010.ITEM_NAME))
                _D010.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D010.TANTO_GYOMU_GROUP_ID))
                _D010.YOHI_KB = dr.Item(NameOf(_D010.YOHI_KB))
                _D010.TANTO_ID = dr.Item(NameOf(_D010.TANTO_ID))
                _D010.NAIYO = dr.Item(NameOf(_D010.NAIYO))
                If Not dr.Item(NameOf(_D010.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D010.YOTEI_YMD = CDate(dr.Item(NameOf(_D010.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D010.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D010.CLOSE_YMD = CDate(dr.Item(NameOf(_D010.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

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
        Catch ex As Exception
            Throw ex
        End Try
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

            For Each dr As DataRow In DirectCast(Flx4_DS.DataSource, DataTable).Rows

#Region "   モデル更新"

                _D011.Clear()
                _D011.FCCB_NO = _D009.FCCB_NO
                _D011.ITEM_NO = dr.Item(NameOf(_D011.ITEM_NO))
                _D011.BUHIN_HINBAN = dr.Item(NameOf(_D011.BUHIN_HINBAN))
                _D011.MEMO1 = dr.Item(NameOf(_D011.MEMO1))
                _D011.MEMO2 = dr.Item(NameOf(_D011.MEMO2))
                _D011.SURYO = dr.Item(NameOf(_D011.SURYO))
                _D011.SYOCHI_NAIYO = dr.Item(NameOf(_D011.SYOCHI_NAIYO))
                _D011.TANTO_GYOMU_GROUP_ID = dr.Item(NameOf(_D011.TANTO_GYOMU_GROUP_ID))
                _D011.TANTO_ID = dr.Item(NameOf(_D011.TANTO_ID))
                If Not dr.Item(NameOf(_D011.YOTEI_YMD)).ToString.IsNulOrWS Then
                    _D011.YOTEI_YMD = CDate(dr.Item(NameOf(_D011.YOTEI_YMD))).ToString("yyyyMMdd")
                End If
                If Not dr.Item(NameOf(_D011.CLOSE_YMD)).ToString.IsNulOrWS Then
                    _D011.CLOSE_YMD = CDate(dr.Item(NameOf(_D011.CLOSE_YMD))).ToString("yyyyMMdd")
                End If

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

#Region "   D012"

    Private Function FunSAVE_D012(ByRef DB As ClsDbUtility, ByVal enmSAVE_MODE As ENM_SAVE_MODE) As Boolean

        Dim strSysDate As String = DB.GetSysDateString

        Try

            If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._2_製造, cmbSYOCHI_SEIZO_TANTO.SelectedValue, dtSYOCHI_SEIZO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_KENSA_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._3_検査, cmbSYOCHI_KENSA_TANTO.SelectedValue, dtSYOCHI_KENSA_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._4_品証, cmbSYOCHI_HINSYO_TANTO.SelectedValue, dtSYOCHI_HINSYO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._5_設計, cmbSYOCHI_SEKKEI_TANTO.SelectedValue, dtSYOCHI_SEKKEI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._6_生技, cmbSYOCHI_SEIGI_TANTO.SelectedValue, dtSYOCHI_SEIGI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._7_管理, cmbSYOCHI_KANRI_TANTO.SelectedValue, dtSYOCHI_KANRI_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._8_営業, cmbSYOCHI_EIGYO_TANTO.SelectedValue, dtSYOCHI_EIGYO_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If
            If cmbSYOCHI_GM_TANTO.IsSelected Then
                If FunSAVE_D012_SUB(DB, ENM_GYOMU_GROUP_ID._91_QMS管理責任者, cmbSYOCHI_GM_TANTO.SelectedValue, dtSYOCHI_GM_TANTO.ValueDate) = False Then
                    Return False
                End If
            End If

            '
            If PrCurrentStage = ENM_FCCB_STAGE._60_処置事項完了確認 Then
                If cmbKAKUNIN_CM_TANTO.IsSelected Then
                    If FunSAVE_D012_SUB(DB, "92", cmbKAKUNIN_CM_TANTO.SelectedValue, dtKAKUNIN_CM_TANTO.ValueDate) = False Then
                        Return False
                    End If
                End If
                If cmbKAKUNIN_GM_TANTO.IsSelected Then
                    If FunSAVE_D012_SUB(DB, "93", cmbKAKUNIN_GM_TANTO.SelectedValue, dtKAKUNIN_GM_TANTO.ValueDate) = False Then
                        Return False
                    End If
                End If
            End If

            WL.WriteLogDat($"[DEBUG]FCCB 報告書NO:{_D009.FCCB_NO}、MERGE D012")

            Return True
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function FunSAVE_D012_SUB(ByRef DB As ClsDbUtility, GYOMU_GROUP_ID As Integer, TANTO_ID As Integer, AddDate As Date) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Dim sqlEx As New Exception
        Dim _D012 As New D012

        Try

#Region "   モデル更新"

            _D012.Clear()
            _D012.FCCB_NO = _D009.FCCB_NO
            _D012.GYOMU_GROUP_ID = GYOMU_GROUP_ID
            _D012.TANTO_ID = TANTO_ID
            _D012.ADD_YMDHNS = AddDate.ToString("yyyyMMddHHmmss")
            _D012.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID

#End Region

            sbSQL.Clear()
            sbSQL.Append($"MERGE INTO {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} AS TARGET")
            sbSQL.Append($" USING (")
            sbSQL.Append($"{_D012.ToSelectSqlString}")
            sbSQL.Append($" ) AS WK")
            sbSQL.Append($" ON (TARGET.{NameOf(_D012.FCCB_NO)} = WK.{NameOf(_D012.FCCB_NO)}")
            sbSQL.Append($" AND TARGET.{NameOf(_D012.GYOMU_GROUP_ID)} = WK.{NameOf(_D012.GYOMU_GROUP_ID)})")
            '---UPDATE
            sbSQL.Append($" WHEN MATCHED THEN")
            sbSQL.Append($" {_D012.ToUpdateSqlString("TARGET", "WK")}")
            '---INSERT
            sbSQL.Append($" WHEN NOT MATCHED THEN")
            sbSQL.Append($" {_D012.ToInsertSqlString("WK")}")

            sbSQL.Append(" OUTPUT $action As RESULT;")
            strRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg, sqlEx)
            Select Case strRET
                Case "INSERT", "UPDATE"

                Case Else
                    If sqlEx IsNot Nothing Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        Return False
                    End If
            End Select

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
            _D004_SYONIN_J_KANRI.HOKOKU_NO = _D009.FCCB_NO
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
                    _D004_SYONIN_J_KANRI.SYONIN_YMDHNS = ""
                    _D004_SYONIN_J_KANRI.MAIL_SEND_FG = False
                    _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
                    _D004_SYONIN_J_KANRI.ADD_YMDHNS = strSysDate

                    'ステージ別承認判定
                    Select Case PrCurrentStage
                        Case ENM_FCCB_STAGE._10_起草入力

                        Case ENM_FCCB_STAGE._20_処置事項調査等

                        Case ENM_FCCB_STAGE._30_変更審議

                        Case ENM_FCCB_STAGE._40_処置確認

                        Case ENM_FCCB_STAGE._50_処置事項完了

                        Case ENM_FCCB_STAGE._60_処置事項完了確認

                        Case Else
                            Throw New ArgumentException("想定外の承認ステージです", PrCurrentStage)
                    End Select

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
                    If FunSendRequestMail() Then
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
            Dim strSubject As String = $"【FCCB要処置事項依頼】{KISYU_NAME}"
            Dim strBody As String = <sql><![CDATA[
                {0} 殿<br />
                <br />
        　        FCCB調査書の処置依頼が来ましたので対応をお願いします。<br />
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

            strBody = String.Format(strBody,
                                If(toUserNAME = "", Fun_GetUSER_NAME(_D004_SYONIN_J_KANRI.SYAIN_ID), toUserNAME),
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

            Dim ToUsers As New List(Of Integer)

            Select Case PrCurrentStage
                Case ENM_FCCB_STAGE._10_起草入力
                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_処置事項調査等)
                    ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

                Case ENM_FCCB_STAGE._20_処置事項調査等
                    'FCCB議長のみ
                    ToUsers.Add(_D009.CM_TANTO)

                Case ENM_FCCB_STAGE._30_変更審議
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
                    End If

                Case ENM_FCCB_STAGE._40_処置確認

                    Dim IsAllChecked As Boolean = True
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
                        '全ての担当者のチェックが完了したら統括責任者に依頼送信
                        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                    Else
                        '統括責任者のチェックも完了したら、各要処置事項の担当者に依頼送信
                        Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next
                    End If

                Case ENM_FCCB_STAGE._50_処置事項完了
                    '裏処理にて各要処置事項の完了日の1週間前になっても未処置の場合、処置担当者に滞留通知

                    Dim IsClosed As Boolean = True
                    IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
                                               AsEnumerable.
                                               Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    '全要処置事項の処置完了
                    If IsClosed Then
                        'FCCB議長に依頼通知
                        If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
                            ToUsers.Add(_D009.CM_TANTO)
                        Else
                            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                        End If
                    End If

                Case Else
                    Throw New ArgumentException("想定外の承認ルートです", PrCurrentStage)
            End Select

            If ToUsers.Count = 0 Then
                MessageBox.Show("送信者が見つからないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        _R001_HOKOKU_SOUSA.HOKOKU_NO = _D009.FCCB_NO
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

        WL.WriteLogDat($"[DEBUG]CTS 報告書NO:{_D009.FCCB_NO}、INSERT R001")

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
        Dim frmDLG As New FrmG0022_Rireki
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
        Dim frmDLG As New FrmG0024_EditComment
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
                Dim IsOwnCreated As Boolean = FunblnOwnCreated(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, _D009.FCCB_NO, PrCurrentStage)
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

                Dim blnIsAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
                If blnIsAdmin Then
                    cmdFunc4.Enabled = True
                    cmdFunc5.Enabled = True
                End If

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_起草入力
                        cmdFunc5.Enabled = False

                    Case ENM_FCCB_STAGE._999_Closed
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

#Region "部門"

    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUMON.SelectedValueChanged

        'If IsInitializing Then Exit Sub

        If cmbBUMON.IsSelected Then
            Call SetTantoColumnDataList(cmbBUMON.SelectedValue)

            Dim dt As DataTable = FunGetSYOZOKU_SYAIN(cmbBUMON.SelectedValue)
            Dim drs As IEnumerable(Of DataRow)
            Dim InList As New List(Of Integer)

            InList.Clear() : InList.AddRange({ENM_GYOMU_GROUP_ID._4_品証.Value, ENM_GYOMU_GROUP_ID._5_設計.Value, ENM_GYOMU_GROUP_ID._6_生技.Value, ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value})
            drs = dt.AsEnumerable.Where(Function(r) InList.Contains(r.Field(Of Integer)(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))).
                                  GroupBy(Function(r) r.Item("VALUE")).Select(Function(g) g.FirstOrDefault)

            cmbKISO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._2_製造.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEIZO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._3_検査.Value)
            If drs.Count > 0 Then cmbSYOCHI_KENSA_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._4_品証.Value)
            If drs.Count > 0 Then cmbSYOCHI_HINSYO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._5_設計.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEKKEI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._6_生技.Value)
            If drs.Count > 0 Then cmbSYOCHI_SEIGI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._7_管理.Value)
            If drs.Count > 0 Then cmbSYOCHI_KANRI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._8_営業.Value)
            If drs.Count > 0 Then cmbSYOCHI_EIGYO_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._9_購買.Value)
            If drs.Count > 0 Then cmbSYOCHI_KOBAI_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            drs = dt.AsEnumerable.Where(Function(r) r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)) = ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value)
            If drs.Count > 0 Then cmbSYOCHI_GM_TANTO.SetDataSource(drs.CopyToDataTable, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            dt = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value, ENM_FCCB_STAGE._10_起草入力)
            cmbCM_TANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            tabMain.Visible = True
        Else
            tabMain.Visible = False
        End If
    End Sub

#End Region

#Region "機種"

    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKISYU.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If IsInitializing Then Exit Sub

        Try

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
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CmbKISYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbKISYU.Validating
        If IsInitializing Then Exit Sub

        Try
            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
            If IsCheckRequired Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "機種"))
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "社内コード"

    Private Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSYANAI_CD.SelectedValueChanged
        Try

            If IsInitializing Then Exit Sub

            Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

            If cmbBUMON.SelectedValue.ToString.ToVal <> ENM_BUMON_KB._2_LP Then Exit Sub

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
                    cmbBUHIN_BANGO.SelectedValue = dr.Item(NameOf(D003_NCR_J.BUHIN_BANGO))
                    If cmbHINMEI.IsSelected Then cmbHINMEI.SelectedValue = dr.Item(NameOf(D003_NCR_J.BUHIN_NAME))
                    If dr.Item(NameOf(D003_NCR_J.KISYU_ID)) <> 0 Then cmbKISYU.SelectedValue = dr.Item(NameOf(D003_NCR_J.KISYU_ID))
                Else
                    cmbBUHIN_BANGO.IsSelected = False
                    cmbHINMEI.IsSelected = False
                    cmbKISYU.IsSelected = False
                End If
            Else
                cmbBUHIN_BANGO.IsSelected = False
                cmbHINMEI.IsSelected = False
                cmbKISYU.IsSelected = False
            End If
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        Finally
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        End Try
    End Sub

    Private Sub CmbSYANAI_CD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYANAI_CD.Validating
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If cmbBUMON.SelectedValue.ToString.ToVal = Context.ENM_BUMON_KB._2_LP.Value Then
            If IsCheckRequired Then
                IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "社内コード"))
            End If
        End If
    End Sub

#End Region

#Region "部品番号"

    Private Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBUHIN_BANGO.SelectedValueChanged
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

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
                cmbSYANAI_CD.SelectedValue = dr.Item("SYANAI_CD")
                If dr.Item("BUHIN_NAME").ToString.IsNulOrWS = False Then cmbHINMEI.Text = dr.Item("BUHIN_NAME")
            Else
                cmbHINMEI.Text = dr?.Item("BUHIN_NAME")
            End If

            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            If dr?.Item("KISYU_ID") <> 0 Then cmbKISYU.SelectedValue = dr?.Item("KISYU_ID")
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        Else
            cmbSYANAI_CD.SelectedValue = ""
            cmbHINMEI.Text = ""
            cmbKISYU.SelectedValue = 0
        End If

        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
    End Sub

    Private Sub CmbBUHIN_BANGO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUHIN_BANGO.Validating
        If IsInitializing Then Exit Sub

        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "部品番号"))
        End If
    End Sub

#End Region

    Private Sub cmbBUMON_Validated(sender As Object, e As EventArgs) Handles cmbBUMON.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbBUMON, cmbBUMON.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製品区分"))
    End Sub

    Private Sub cmbKISO_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbKISO_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbKISO_TANTO, cmbKISO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "起草者"))
    End Sub

    Private Sub cmbCM_TANTO_Validated(sender As Object, e As EventArgs) Handles cmbCM_TANTO.Validated
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbCM_TANTO, cmbCM_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "FCCB議長"))
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
            If PrCurrentStage = ENM_FCCB_STAGE._999_Closed Then
                rsbtnST99.Checked = True
            Else
                Dim rbtn As RibbonShapeRadioButton = DirectCast(flpnlStageIndex.Controls("rsbtnST" & (PrCurrentStage / 10).ToString("00")), RibbonShapeRadioButton)
                rbtn.Checked = True
            End If

            Call SetTANTO_TooltipInfo()

            '-----コントロールデータソース設定
            cmbBUMON.SetDataSource(tblBUMON, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISO_TANTO.SetDataSource(tblTANTO, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            cmbKISYU.SetDataSource(tblKISYU.LazyLoad("機種"), ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN.LazyLoad("部品番号"), ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.LazyLoad("社内CD").ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            'UNDONE: 業務グループリストソース取得関数化
            Dim BUSYOList As New SortedList(Of Integer, String)
            BUSYOList.Add(0, "(未選択)")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._1_技術.Value, "技術")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._2_製造.Value, "製造")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._3_検査.Value, "検査")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._4_品証.Value, "品証")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._5_設計.Value, "設計")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._6_生技.Value, "生技")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._7_管理.Value, "管理")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._8_営業.Value, "営業")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._9_購買.Value, "購買")
            BUSYOList.Add(ENM_GYOMU_GROUP_ID._43_品検.Value, "品/検")
            flxDATA_2.Cols(4).DataMap = BUSYOList
            flxDATA_3.Cols(3).DataMap = BUSYOList
            flxDATA_5.Cols(3).DataMap = BUSYOList

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD

#Region "                  ADD"

                    mtxFCCB_NO.Text = "<新規>"
                    _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _D009.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

                    If IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID) Then
                    Else
                        _D009.BUMON_KB = pub_SYAIN_INFO.BUMON_KB
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
                        Flx2_DS_DB = Sec2.Data.Copy

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
                        Flx3_DS_DB = Sec3.Data.Copy

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

#End Region

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

#Region "                   UPDATE"

                    _V003_SYONIN_J_KANRI_List = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, PrFCCB_NO)
                    _D009 = FunGetD009Model(PrFCCB_NO)

                    mtxFCCB_NO.Text = PrFCCB_NO
                    cmbBUMON.SelectedValue = _D009.BUMON_KB
                    Call CmbBUMON_SelectedValueChanged(cmbBUMON, Nothing)
                    cmbKISYU.SelectedValue = _D009.KISYU_ID
                    Call CmbKISYU_SelectedValueChanged(cmbKISYU, Nothing)
                    dtKISO.Value = DateTime.Parse(_D009.ADD_YMDHNS).ToString("yyyy/MM/dd")
                    cmbCM_TANTO.SelectedValue = _D009.CM_TANTO
                    cmbKISO_TANTO.SelectedValue = _D009.ADD_SYAIN_ID
                    cmbBUHIN_BANGO.SelectedValue = _D009.BUHIN_BANGO
                    Call CmbBUHIN_BANGO_SelectedValueChanged(cmbBUHIN_BANGO, Nothing)

                    If _D009.BUMON_KB = ENM_BUMON_KB._2_LP.Value Then
                        cmbSYANAI_CD.SelectedValue = _D009.SYANAI_CD
                    End If

                    cmbHINMEI.Text = _D009.BUHIN_NAME
                    mtxINPUT_DOC_NO.Text = _D009.INPUT_DOC_NO
                    mtxSNO_APPLY_PERIOD_KISO.Text = _D009.SNO_APPLY_PERIOD_KISO
                    mtxSNO_APPLY_PERIOD_HENKO_SINGI.Text = _D009.SNO_APPLY_PERIOD_HENKO_SINGI
                    txtINPUT_NAIYO.Text = _D009.INPUT_NAIYO

                    Call SetTantoColumnDataList(_D009.BUMON_KB)

                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, FunGetNextSYONIN_JUN(PrCurrentStage))
                    cmbDestTANTO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

#Region "InitDS"

                    Using DB As ClsDbUtility = DBOpen()
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As DataSet

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}<100 ")
                        sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        Dim Sec2 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx2_DS.DataSource = Sec2.Data
                        Flx2_DS_DB = Sec2.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                        sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                        sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                        sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}>100 ")
                        sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec3 As New ModelInfo(Of D010)(srcDATA:=dsList.Tables(0))
                        Flx3_DS.DataSource = Sec3.Data
                        Flx3_DS_DB = Sec3.Data.Copy

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($"  {NameOf(D011.FCCB_NO)}")
                        sbSQL.Append($" ,{NameOf(D011.ITEM_NO)}")
                        sbSQL.Append($" ,{NameOf(D011.BUHIN_HINBAN)}")
                        sbSQL.Append($" ,{NameOf(D011.BUHIN_NAME)}")
                        sbSQL.Append($" ,{NameOf(D011.MEMO1)}")
                        sbSQL.Append($" ,{NameOf(D011.MEMO2)}")
                        sbSQL.Append($" ,{NameOf(D011.SURYO)}")
                        sbSQL.Append($" ,{NameOf(D011.SYOCHI_NAIYO)}")
                        sbSQL.Append($" ,{NameOf(D011.TANTO_GYOMU_GROUP_ID)}")
                        sbSQL.Append($" ,{NameOf(D011.TANTO_ID)}")
                        sbSQL.Append($" ,IIF({NameOf(D011.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.YOTEI_YMD)}")
                        sbSQL.Append($" ,IIF({NameOf(D011.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.CLOSE_YMD)}")
                        sbSQL.Append($" FROM {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN)} ")
                        sbSQL.Append($" WHERE {NameOf(D011.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        Dim Sec4 As New ModelInfo(Of D011)(srcDATA:=dsList.Tables(0))
                        Flx4_DS.DataSource = Sec4.Data
                        Flx4_DS_DB = Sec4.Data.Copy

#Region "処置確認担当者"

                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" *")
                        sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
                        sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        If dsList.Tables(0).Rows.Count > 0 Then

                            Dim Sec5 As New ModelInfo(Of D012)(srcDATA:=dsList.Tables(0))

                            For Each dr As DataRow In Sec5.Data.Rows
                                Dim cmb As New ComboboxEx
                                Dim dte As New DateTextBoxEx

                                Select Case dr.Item(NameOf(D012.GYOMU_GROUP_ID))
                                    Case ENM_GYOMU_GROUP_ID._2_製造.Value
                                        cmb = cmbSYOCHI_SEIZO_TANTO
                                        dte = dtSYOCHI_SEIZO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._3_検査.Value
                                        cmb = cmbSYOCHI_KENSA_TANTO
                                        dte = dtSYOCHI_KENSA_TANTO

                                    Case ENM_GYOMU_GROUP_ID._4_品証.Value
                                        cmb = cmbSYOCHI_HINSYO_TANTO
                                        dte = dtSYOCHI_HINSYO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._5_設計.Value
                                        cmb = cmbSYOCHI_SEKKEI_TANTO
                                        dte = dtSYOCHI_SEKKEI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._6_生技.Value
                                        cmb = cmbSYOCHI_SEIGI_TANTO
                                        dte = dtSYOCHI_SEIGI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._7_管理.Value
                                        cmb = cmbSYOCHI_KANRI_TANTO
                                        dte = dtSYOCHI_KANRI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._8_営業.Value
                                        cmb = cmbSYOCHI_EIGYO_TANTO
                                        dte = dtSYOCHI_EIGYO_TANTO

                                    Case ENM_GYOMU_GROUP_ID._9_購買.Value
                                        cmb = cmbSYOCHI_KOBAI_TANTO
                                        dte = dtSYOCHI_KOBAI_TANTO

                                    Case ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value '統括責任者
                                        cmb = cmbSYOCHI_GM_TANTO
                                        dte = dtSYOCHI_GM_TANTO

                                    Case 92
                                        cmb = cmbKAKUNIN_CM_TANTO
                                        dte = dtKAKUNIN_CM_TANTO

                                    Case 93
                                        cmb = cmbKAKUNIN_GM_TANTO
                                        dte = dtKAKUNIN_GM_TANTO

                                End Select

                                cmb.SelectedValue = dr.Item(NameOf(D012.TANTO_ID))
                                If Not dr.Item(NameOf(D012.ADD_YMDHNS)).ToString.IsNulOrWS Then
                                    dte.Value = DateTime.ParseExact(dr.Item(NameOf(D012.ADD_YMDHNS)), "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                                End If
                            Next
                        End If

#End Region

                    End Using

#End Region

                    tabMain.Visible = True

#End Region

                Case Else
                    Throw New ArgumentException("想定外の起動モードです")
            End Select



            '現行ステージ名
            lblCurrentStageName.Text = FunGetLastStageName(Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, _D009.FCCB_NO)

            '処置確認担当者

            Dim groupList = GetRequiredGyomuGroups()
            For Each gg As ENM_GYOMU_GROUP_ID In groupList
                Select Case gg
                    Case ENM_GYOMU_GROUP_ID._1_技術

                    Case ENM_GYOMU_GROUP_ID._2_製造
                        lblSYOCHI_SEIZO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._3_検査
                        lblSYOCHI_KENSA_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._4_品証
                        lblSYOCHI_HINSYO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._5_設計
                        lblSYOCHI_SEKKEI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._6_生技
                        lblSYOCHI_SEIGI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._7_管理
                        lblSYOCHI_KANRI_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._8_営業
                        lblSYOCHI_EIGYO_TANTO.BackColor = Color.LemonChiffon

                    Case ENM_GYOMU_GROUP_ID._9_購買
                        lblSYOCHI_KOBAI_TANTO.BackColor = Color.LemonChiffon

                    Case Else
                End Select
            Next

            '編集権限設定
            If _D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID Then
                '起草者は全編集権限あり
            Else
                USER_GYOMU_KENGEN_LIST = GetSYAIN_GYOMUGroups(pub_SYAIN_INFO.SYAIN_ID)

                '担当業務以外は編集不可
                For i As Integer = 1 To flxDATA_2.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_2.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_2.Rows(i).Style = Nothing
                        flxDATA_2.Rows(i).AllowEditing = True
                    Else
                        flxDATA_2.Rows(i).Style = flxDATA_2.Styles("DeletedRow")
                        flxDATA_2.Rows(i).AllowEditing = False
                    End If
                Next
                For i As Integer = 1 To flxDATA_3.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_3.Rows(i).Item(NameOf(D010.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_3.Rows(i).Style = Nothing
                        flxDATA_3.Rows(i).AllowEditing = True
                    Else
                        flxDATA_3.Rows(i).Style = flxDATA_3.Styles("DeletedRow")
                        flxDATA_3.Rows(i).AllowEditing = False
                    End If
                Next
                For i As Integer = 1 To flxDATA_5.Rows.Count - 1
                    If USER_GYOMU_KENGEN_LIST.Contains(flxDATA_5.Rows(i).Item(NameOf(D011.TANTO_GYOMU_GROUP_ID))) Then
                        flxDATA_5.Rows(i).Style = Nothing
                        flxDATA_5.Rows(i).AllowEditing = True
                    Else
                        flxDATA_5.Rows(i).Style = flxDATA_5.Styles("DeletedRow")
                        flxDATA_5.Rows(i).AllowEditing = False
                    End If
                Next
            End If

            '編集権限
            Call SetFlxDATA_EditStatus(flxDATA_2)
            Call SetFlxDATA_EditStatus(flxDATA_3)
            Call SetFlxDATA_EditStatus(flxDATA_4)
            Call SetFlxDATA_EditStatus(flxDATA_5)

            '完了日表示
            Dim blnCloseColumnVisibled = (PrCurrentStage >= ENM_FCCB_STAGE._40_処置確認.Value)
            flxDATA_2.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled
            flxDATA_3.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled
            flxDATA_5.Cols(NameOf(D010.CLOSE_YMD)).Visible = blnCloseColumnVisibled

            '編集権限
            Select Case PrCurrentStage
                Case ENM_FCCB_STAGE._10_起草入力
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False

                Case ENM_FCCB_STAGE._20_処置事項調査等
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False
                    cmdFunc2.Enabled = False

                Case ENM_FCCB_STAGE._30_変更審議
                    tlpHeader.Enabled = (_D009.ADD_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID)
                    C1SplitterPanel5.Enabled = False

                Case ENM_FCCB_STAGE._40_処置確認, ENM_FCCB_STAGE._41_処置確認_統括
                    tlpHeader.Enabled = False
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True

                Case ENM_FCCB_STAGE._50_処置事項完了
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True
                    tlpHeader.Enabled = False

                Case ENM_FCCB_STAGE._60_処置事項完了確認, ENM_FCCB_STAGE._61_処置事項完了確認_統括
                    C1SplitterPanel1.Enabled = False
                    C1SplitterPanel2.Enabled = False
                    C1SplitterPanel5.Enabled = True
                    tlpHeader.Enabled = False

                Case ENM_FCCB_STAGE._999_Closed
                    tlpHeader.Enabled = False
            End Select

            If FunGetNextSYONIN_JUN(PrCurrentStage) = ENM_FCCB_STAGE._999_Closed Then
                '最終ステージの場合、申請先担当者欄は非表示

                lblDestTanto.Visible = False
                cmbDestTANTO.Visible = False
                cmdFunc2.Text = "承認(F2)"
            Else
                cmdFunc2.Text = "承認・申請(F2)"

                'C1SplitterPanel4.Collapsed = False
                'C1SplitterPanel4.Collapsible = True
                'C1SplitterPanel4.Enabled = False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    '処置一覧 業務グループ別担当者リストの設定
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
            flxDATA_2.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO
            flxDATA_3.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO
            flxDATA_5.Cols(NameOf(D010.TANTO_ID)).DataMap = dtTANTO

            For Each GROUP_ID In grp

                '複合業務グループを分割
                Dim ids = GROUP_ID.Value.ToString.ToArray

                '対象業務グループの社員を抽出
                Dim drs = dt.AsEnumerable.
                         Where(Function(r) ids.Contains(r.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)).ToString)).
                         GroupBy(Function(r) r.Item("VALUE")).
                         Select(Function(g) g.FirstOrDefault)

                dtTANTO = New SortedList
                dtTANTO.Add(0, "未選択")
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
                flxDATA_3.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

                If Not flxDATA_5.Styles.Contains($"dtTANTO_{GROUP_ID.Value}") Then
                    flxDATA_5.Styles.Add($"dtTANTO_{GROUP_ID.Value}")
                End If
                flxDATA_5.Styles($"dtTANTO_{GROUP_ID.Value}").DataMap = dtTANTO

            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 担当者のデータソース情報をラベルに表示
    ''' </summary>
    ''' <returns></returns>
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

            Call cmbBUMON_Validated(cmbBUMON, Nothing)
            Call cmbKISO_TANTO_Validated(cmbKISO_TANTO, Nothing)
            Call cmbCM_TANTO_Validated(cmbCM_TANTO, Nothing)

            If Not IsValidated Then Return False

            If enmSAVE_MODE = ENM_SAVE_MODE._2_承認申請 Then

                Dim groupList = GetRequiredGyomuGroups()

                Select Case PrCurrentStage
                    Case ENM_FCCB_STAGE._10_起草入力.Value
                    Case ENM_FCCB_STAGE._20_処置事項調査等.Value
                        IsValidated = IsInputRequired(DisplayAlart:=True)

                    Case ENM_FCCB_STAGE._30_変更審議.Value
                        'ST2で選択された部署コンボのみ必須

                        For Each gg As ENM_GYOMU_GROUP_ID In groupList

                            Select Case gg
                                Case ENM_GYOMU_GROUP_ID._1_技術

                                Case ENM_GYOMU_GROUP_ID._2_製造
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEIZO_TANTO, cmbSYOCHI_SEIZO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "製造G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._3_検査
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KENSA_TANTO, cmbSYOCHI_KENSA_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "検査G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._4_品証
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_HINSYO_TANTO, cmbSYOCHI_HINSYO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "品証G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._5_設計
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEKKEI_TANTO, cmbSYOCHI_SEKKEI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "設計G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._6_生技
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_SEIGI_TANTO, cmbSYOCHI_SEIGI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "生技G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._7_管理
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KANRI_TANTO, cmbSYOCHI_KANRI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "管理G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._8_営業
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_EIGYO_TANTO, cmbSYOCHI_EIGYO_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "営業G確認担当者"))

                                Case ENM_GYOMU_GROUP_ID._9_購買
                                    IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_KOBAI_TANTO, cmbSYOCHI_KOBAI_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "購買G確認担当者"))

                                Case Else
                            End Select
                        Next

                        '統括責任者は常に必須
                        IsValidated *= ErrorProvider.UpdateErrorInfo(cmbSYOCHI_GM_TANTO, cmbSYOCHI_GM_TANTO.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "統括責任者"))
                End Select
            End If

            '上記各種Validatingイベントでフラグを更新し、全てOKの場合はTrue
            Return IsValidated
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "処置項目入力チェック"

    ''' <summary>
    ''' 要の全項目に担当者、予定日が入力されているかチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function IsInputRequired(Optional DisplayAlart As Boolean = False) As Boolean
        Try

            Dim requiredItems = DirectCast(Flx2_DS.DataSource, DataTable).
                                          AsEnumerable.
                                          Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)))

            For Each r As DataRow In requiredItems
                If r.Item(NameOf(D010.TANTO_ID)) = 0 Then
                    If DisplayAlart Then MessageBox.Show("要項目で担当者未選択の項目があります。", "入力チェック", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False

                End If

                If r.Item(NameOf(D010.YOTEI_YMD)) = "" Then
                    If DisplayAlart Then MessageBox.Show("要項目で完了予定日未入力の項目があります。", "入力チェック", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next

            Dim requiredItems2 = DirectCast(Flx3_DS.DataSource, DataTable).
                                                                AsEnumerable.
                                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)))

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 要の全項目に担当者、予定日が入力されているかチェック
    ''' </summary>
    ''' <returns></returns>
    Private Function IsInputRequired_DB() As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim intRET As Integer

            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT(FCCB_NO)")
            sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
            sbSQL.Append($" WHERE {NameOf(D010.FCCB_NO)}={_D009.FCCB_NO}")
            sbSQL.Append($" AND {NameOf(D010.YOHI_KB)}='1'")
            sbSQL.Append($" AND ({NameOf(D010.TANTO_ID)}=0 OR TRIM({NameOf(D010.YOTEI_YMD)})='')")

            Using DB As ClsDbUtility = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg).ToVal
            End Using

            Return (intRET = 0)
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
                Case ENM_FCCB_STAGE._10_起草入力
                    Return ENM_FCCB_STAGE._20_処置事項調査等
                Case ENM_FCCB_STAGE._20_処置事項調査等
                    Return ENM_FCCB_STAGE._30_変更審議
                Case ENM_FCCB_STAGE._30_変更審議
                    Return ENM_FCCB_STAGE._40_処置確認
                Case ENM_FCCB_STAGE._40_処置確認, ENM_FCCB_STAGE._41_処置確認_統括
                    Return ENM_FCCB_STAGE._50_処置事項完了
                Case ENM_FCCB_STAGE._50_処置事項完了
                    Return ENM_FCCB_STAGE._60_処置事項完了確認
                Case ENM_FCCB_STAGE._60_処置事項完了確認, ENM_FCCB_STAGE._61_処置事項完了確認_統括
                    Return ENM_FCCB_STAGE._999_Closed
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

    Private Function GetRequiredGyomuGroups() As List(Of ENM_GYOMU_GROUP_ID)

        Try
            Dim groups = DirectCast(Flx2_DS.DataSource, DataTable).
                                      AsEnumerable.
                                      Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB))).
                                      Select(Function(r) r.Field(Of ENM_GYOMU_GROUP_ID)(NameOf(D010.TANTO_GYOMU_GROUP_ID))).
                                      Distinct

            Dim groups2 = DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB))).
                                            Select(Function(r) r.Field(Of ENM_GYOMU_GROUP_ID)(NameOf(D010.TANTO_GYOMU_GROUP_ID))).
                                            Distinct

            Dim groupList = groups.Union(groups2).ToList
            If groupList.Contains(ENM_GYOMU_GROUP_ID._43_品検) Then
                '業務グループを展開
                If Not groupList.Contains(ENM_GYOMU_GROUP_ID._4_品証) Then
                    groupList.Add(ENM_GYOMU_GROUP_ID._4_品証)
                End If
                If Not groupList.Contains(ENM_GYOMU_GROUP_ID._3_検査) Then
                    groupList.Add(ENM_GYOMU_GROUP_ID._3_検査)
                End If
            End If

            Return groupList
        Catch ex As Exception
            Throw
        End Try
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

            Select Case intSYONIN_JUN
                Case ENM_FCCB_STAGE._10_起草入力
                    Dim dt = FunGetSYONIN_SYOZOKU_SYAIN(_D009.BUMON_KB, Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB, ENM_FCCB_STAGE._20_処置事項調査等)
                    ToUsers = dt.AsEnumerable.Select(Function(r) r.Field(Of Integer)("VALUE")).ToList

                Case ENM_FCCB_STAGE._20_処置事項調査等
                    'FCCB議長 起草者
                    ToUsers.Add(_D009.CM_TANTO)
                    ToUsers.Add(_D009.ADD_SYAIN_ID)
                    '操作可能
                    ToUsers.Add(pub_SYAIN_INFO.SYAIN_ID)

                Case ENM_FCCB_STAGE._30_変更審議

                    ToUsers.Add(cmbCM_TANTO.SelectedValue)

                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEKKEI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIGI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_EIGYO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_KANRI_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_SEIZO_TANTO.SelectedValue)
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected Then
                        ToUsers.Add(cmbSYOCHI_HINSYO_TANTO.SelectedValue)
                    End If

                Case ENM_FCCB_STAGE._40_処置確認

                    ToUsers.Add(cmbCM_TANTO.SelectedValue)

                    Dim IsAllChecked As Boolean = True
                    If cmbSYOCHI_SEKKEI_TANTO.IsSelected AndAlso dtSYOCHI_SEKKEI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIGI_TANTO.IsSelected AndAlso dtSYOCHI_SEIGI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_EIGYO_TANTO.IsSelected AndAlso dtSYOCHI_EIGYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_KANRI_TANTO.IsSelected AndAlso dtSYOCHI_KANRI_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_SEIZO_TANTO.IsSelected AndAlso dtSYOCHI_SEIZO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If cmbSYOCHI_HINSYO_TANTO.IsSelected AndAlso dtSYOCHI_HINSYO_TANTO.Text.IsNulOrWS Then
                        IsAllChecked *= False
                    End If
                    If IsAllChecked AndAlso dtSYOCHI_GM_TANTO.Text.IsNulOrWS Then
                        '全ての担当者のチェックが完了したら統括責任者に依頼送信
                        ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                    Else
                        '統括責任者のチェックも完了したら、各要処置事項の担当者に依頼送信
                        Dim targetUsers = DirectCast(Flx2_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx3_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And Not r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D010.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next

                        targetUsers = DirectCast(Flx4_DS.DataSource, DataTable).
                                                AsEnumerable.
                                                Where(Function(r) Not r.Item(NameOf(D011.YOTEI_YMD)).ToString.IsNulOrWS).
                                                Select(Function(r) r.Field(Of Integer)(NameOf(D011.TANTO_ID)))

                        For Each usr In targetUsers
                            If Not ToUsers.Contains(usr) Then
                                ToUsers.Add(usr)
                            End If
                        Next
                    End If

                Case ENM_FCCB_STAGE._50_処置事項完了
                    '裏処理にて各要処置事項の完了日の1週間前になっても未処置の場合、処置担当者に滞留通知

                    Dim IsClosed As Boolean = True
                    IsClosed *= DirectCast(Flx2_DS.DataSource, DataTable).
                                               AsEnumerable.
                                               Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx3_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Boolean)(NameOf(D010.YOHI_KB)) And r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    IsClosed *= DirectCast(Flx4_DS.DataSource, DataTable).
                                            AsEnumerable.
                                            Where(Function(r) r.Item(NameOf(D011.CLOSE_YMD)).ToString.IsNulOrWS).Count = 0

                    '全要処置事項の処置完了
                    If IsClosed Then
                        'FCCB議長に依頼通知
                        If dtKAKUNIN_CM_TANTO.Text.IsNulOrWS Then
                            ToUsers.Add(_D009.CM_TANTO)
                        Else
                            ToUsers.Add(cmbSYOCHI_GM_TANTO.SelectedValue)
                        End If
                    End If

                Case Else
                    Throw New ArgumentException("想定外の承認ルートです", PrCurrentStage)
            End Select

            Return ToUsers.Contains(pub_SYAIN_INFO.SYAIN_ID)
        Catch ex As Exception
            Throw
        End Try

    End Function

#End Region

End Class