Imports JMS_COMMON.ClsPubMethod
Imports Spire.Xls
Imports Spire.Pdf
Imports Spire.Xls.Converter

''' <summary>
''' 不適合検索画面
''' </summary>
Public Class FrmG0010

#Region "定数・変数"

    Private ParamModel As New ST02_ParamModel
#End Region

#Region "プロパティ"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PrDt As DataTable

    ''' <summary>
    ''' CAR検索条件 原因1
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin1 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

    ''' <summary>
    ''' CAR検索条件 原因2
    ''' </summary>
    ''' <returns></returns>
    Public Property PrGenin2 As New List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

        '日付空欄許可
        dtJisiFrom.Nullable = True
        dtJisiTo.Nullable = True

        '先頭ウォーターマーク+バインドが必要なコンボボックスのための設定
        cmbADD_TANTO.NullValue = 0
        cmbKISYU.NullValue = 0
        cmbGEN_TANTO.NullValue = 0

        Select Case pub_intOPEN_MODE
            Case ENM_OPEN_MODE._1_新規作成
                Me.WindowState = FormWindowState.Minimized
        End Select

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(dgvDATA)

            'SPEC: PF01.2-(1) A データソース

            '-----コントロールソース設定
            '共通
            cmbBUMON.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            Dim dtAddTANTO As DataTable = tblTANTO_SYONIN.
                                            ExcludeDeleted.
                                            AsEnumerable.
                                            Where(Function(r) r.Field(Of Integer)("SYONIN_JUN") = ENM_NCR_STAGE._10_起草入力 And r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = ENM_SYONIN_HOKOKUSYO_ID._1_NCR).
                                            CopyToDataTable

            cmbADD_TANTO.SetDataSource(dtAddTANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISYU.SetDataSource(tblKISYU_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbFUTEKIGO_KB.SetDataSource(tblFUTEKIGO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbFUTEKIGO_JYOTAI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'NCR
            cmbJIZEN_SINSA_HANTEI_KB.SetDataSource(tblJIZEN_SINSA_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbSAISIN_IINKAI_HANTEI_KB.SetDataSource(tblSAISIN_IINKAI_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbZESEI_SYOCHI_YOHI_KB.SetDataSource(tblYOHI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKOKYAKU_HANTEI_SIJI_KB.SetDataSource(tblKOKYAKU_HANTEI_SIJI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKOKYAKU_SAISYU_HANTEI_KB.SetDataSource(tblKOKYAKU_SAISYU_HANTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKENSA_KEKKA_KB.SetDataSource(tblKENSA_KEKKA_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'CAR
            cmbYOIN1.SetDataSource(tblKONPON_YOIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbYOIN2.SetDataSource(tblKONPON_YOIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbKISEKI_KOTEI_KB.SetDataSource(tblKISEKI_KOUTEI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '-----バインディング
            Call FunSetBinding()

            '----コントロールイベントハンドラ
            AddHandler cmbBUMON.SelectedValueChanged, AddressOf CmbBUMON_SelectedValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged


            '-----既定値設定
            Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
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

                End Select
            End If
            Dim dtGEN_TANTO As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
            cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbGEN_TANTO.SelectedValue = pub_SYAIN_INFO.SYAIN_ID

            ''-----イベントハンドラ設定
            AddHandler cmbBUMON.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_JYOTAI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged

            AddHandler mtxHOKUKO_NO.Validated, AddressOf SearchFilterValueChanged
            AddHandler mtxGOKI.Validated, AddressOf SearchFilterValueChanged
            AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler dtJisiFrom.TxtChanged, AddressOf SearchFilterValueChanged
            AddHandler dtJisiTo.TxtChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbFUTEKIGO_S_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxHINMEI.Validated, AddressOf SearchFilterValueChanged
            AddHandler chkDleteRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkClosedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler chkTairyu.CheckedChanged, AddressOf SearchFilterValueChanged

            AddHandler cmbJIZEN_SINSA_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbZESEI_SYOCHI_YOHI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbSAISIN_IINKAI_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbKENSA_KEKKA_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged

            '起動モード別処理
            Select Case pub_intOPEN_MODE
                Case ENM_OPEN_MODE._0_通常
                    Me.cmdFunc1.PerformClick()
                Case ENM_OPEN_MODE._1_新規作成
                    Me.cmdFunc2.PerformClick()
                    Me.WindowState = FormWindowState.Normal
                Case Else
                    Me.cmdFunc1.PerformClick()
            End Select
        Finally
            'ファンクションボタンステータス更新
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False

                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = NameOf(_Model.SELECTED),
                .HeaderText = "選択",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30


                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_ID), "承認報告書ID")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.BUMON_NAME), "製品" & vbCrLf & "区分")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.HOKOKU_NO), "報告書No")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.CLOSE_FG), "Closed")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_JUN), "承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "ステージ")
                .Columns(.ColumnCount - 1).Width = 210
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "略名")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.GEN_TANTO_NAME), "処置担当者")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.TAIRYU_FG), "滞留フラグ")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add(NameOf(_Model.TAIRYU_NISSU), "滞留" & vbCrLf & "日数")
                .Columns(.ColumnCount - 1).Width = 60
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISYU_NAME), "機種")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_BANGO), "部品番号")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Frozen = True
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.BUHIN_NAME), "部品名")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.GOKI), "号機")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "報告書名称")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_NAME), "事前判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_NAME), "再審判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.KISO_YMD), "起草日")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SYONIN_YMDHNS), "前処理" & vbCrLf & "実施日")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "差戻承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False


                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_NAIYO), "差戻元ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.RIYU), "差戻理由")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True

                .Columns.Add(NameOf(_Model.SASIMOTO_SYONIN_JUN), "差戻承認順")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ReadOnly = True


                .Columns.Add(NameOf(_Model.DEL_YMDHNS), "削除日時")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                '.Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
            End With

            Return True
        Finally
        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
        Try
            'ヘッダ以外のセルダブルクリック時
            If e.RowIndex >= 0 Then
                '該当行の変更処理を実行する
                Me.cmdFunc4.PerformClick()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
            If Me.dgvDATA.CurrentRow IsNot Nothing Then
                If Me.dgvDATA.CurrentRow.Cells("CLOSE_FG").Value = "1" Or Me.dgvDATA.CurrentRow.Cells("DEL_YMDHNS").Value.ToString.Trim <> "" Then
                    Me.dgvDATA.CurrentRow.ReadOnly = True
                Else
                    Me.dgvDATA.CurrentRow.ReadOnly = False
                End If
            End If

        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    'ソート時イベント
    Private Sub DgvDATA_Sorted(sender As Object, e As EventArgs) Handles dgvDATA.Sorted
        Call FunSetDgvCellFormat(sender)
    End Sub

#Region "　グリッド編集関連"

    ''' <summary>
    ''' グリッド編集前処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>グリッド編集前処理</remarks>
    Private Sub DgvDATA_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDATA.CellBeginEdit

        ' 編集前の値を待避しておく
        'pri_intPrevCellValue = Val(Me.dgvDATA.CurrentCell.Value)
    End Sub

    'セル編集完了イベント
    Private Sub DgvDATA_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellEndEdit
        Try

            'Dim intEditedCellValue As Integer
            'intEditedCellValue = Val(Me.dgvDATA.CurrentCell.Value)

            'If pri_intPrevCellValue <> intEditedCellValue Then
            '    'カレントセル書式変更
            '    Me.dgvDATA.CurrentCell.Style.ForeColor = clrEditedCellForeColor
            '    Me.dgvDATA.CurrentCell.Style.SelectionForeColor = clrEditedCellForeColor

            '    If Me.dgvDATA.Columns(e.ColumnIndex).Name = "SELECTROW" Then
            '    Else
            '        Me.dgvDATA.CurrentRow.Cells("MODIFIED_STATUS").Value = True
            '        Me.pri_blnUpdateCellValue = True
            '    End If
            'End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            'FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

    'セルクリック時イベント
    Private Sub DgvDATA_CellClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellClick

        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            'If e.RowIndex >= 0 Then
            '    Select Case dgv.Columns(e.ColumnIndex).Name
            '        Case "SELECTED"
            '            If Me.dgvDATA.CurrentRow.Cells("CLOSE_FG").Value = "1" Or Me.dgvDATA.CurrentRow.Cells("DEL_YMDHNS").Value.ToString.Trim <> "" Then
            '                Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False 'Not CBool(Me.dgvDATA.CurrentRow.Cells("SELECTED").Value)
            '            Else
            '                '    '選択不可
            '                '    Me.dgvDATA.CurrentRow.Cells("SELECTED").Value = False
            '                '    MessageBox.Show("未発注データ以外は選択出来ません。", "選択不可", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            End If

            '    End Select

            'End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            FunInitFuncButtonEnabled()
        End Try
    End Sub


#Region "編集可能セルOnMouse時カーソル変更"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDATA.CellMouseMove
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "SELECTED"
                    dgv.Cursor = Cursors.Hand
                    'Case "TANKA", "HACYU_SU"
                    '    If dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
                    '        dgv.Cursor = Cursors.IBeam
                    '    Else
                    '        dgv.Cursor = Cursors.No
                    '    End If
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellMouseLeave
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub

#End Region

#Region "入力制限"
    'EditingControlShowingイベント
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvDATA.EditingControlShowing
        '表示されているコントロールがDataGridViewTextBoxEditingControlか調べる
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            '編集のために表示されているコントロールを取得
            Dim tb As DataGridViewTextBoxEditingControl =
                CType(e.Control, DataGridViewTextBoxEditingControl)

            'イベントハンドラを削除
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress

            '該当する列か調べる
            Select Case dgv.CurrentCell.OwningColumn.Name
                Case "TANKA", "HACYU_SU"
                    'KeyPressイベントハンドラを追加
                    AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
                Case Else
                    '
            End Select
        End If
    End Sub

    'DataGridViewに表示されているテキストボックスのKeyPressイベントハンドラ
    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '数字(+BACKSPACE)しか入力できないようにする
        Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) _
            AndAlso e.KeyChar <> ControlChars.Back _
            AndAlso e.KeyChar <> "."c _
            AndAlso (e.KeyChar = "."c And tb.Text.Contains("."c)) Then
            e.Handled = True
        End If
    End Sub

#End Region

#End Region

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
                Case 1  '検索
                    Call FunSRCH(dgvDATA, FunGetListData())
                Case 2  '追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 4  '変更

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 5, 6  '削除/復元/完全削除

                    If dgvDATA.CurrentRow IsNot Nothing Then
                        If MessageBox.Show("選択されたデータを削除しますか?", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Dim dr As DataRow = dgvDATA.GetDataRow()
                            If FunDEL(dr.Item("SYONIN_HOKOKUSYO_ID"), dr.Item("HOKOKU_NO")) = True Then
                                Call FunSRCH(dgvDATA, FunGetListData())
                            End If
                        End If
                    Else
                        MessageBox.Show("該当データが選択されていません。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case 7 '全選択

                    Call FunSelectAll()

                Case 8 '全選択解除

                    Call FunUnSelectAll()

                Case 9 'メール送信

                    Call FunMailSending()

                Case 10  '印刷
                    Call FunOpenReport()

                    'Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 11 '履歴表示
                    Call OpenFormRIREKI()

                Case 12 '閉じる
                    Me.Close()
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
            Call FunInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "検索"

    Private Function FunGetListData() As DataTable
        Try

            'SPEC: PF01.2-(1) A 検索条件

            Dim dtBUFF As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(ParamModel)
            If dtBUFF Is Nothing Then Return Nothing
            If dtBUFF.Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            'UNDONE: 削除済み表示切替 可能ならストアドパラメータに条件設定を移行したい
            If chkDleteRowVisibled.Checked Then
            Else
                Dim drs As List(Of DataRow) = dtBUFF.AsEnumerable.Where(Function(r) r.Field(Of String)("DEL_YMDHNS").Trim = "").ToList
                If drs.Count > 0 Then
                    dtBUFF = drs.CopyToDataTable
                Else
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.ST02_FUTEKIGO_ICHIRAN)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                If IsAutoGenerateField(t, p.Name) = True Then
                    Dim dc As New DataColumn With {.ColumnName = p.Name,
                                                   .DataType = p.PropertyType,
                                                   .Caption = p.DisplayName}
                    dt.Columns.Add(dc)
                End If
            Next p

            With dtBUFF
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties
                        If IsAutoGenerateField(t, p.Name) = True Then
                            Select Case p.PropertyType
                                Case GetType(Integer)
                                    Trow(p.Name) = Val(row.Item(p.Name))
                                Case GetType(Decimal)
                                    Trow(p.Name) = CDec(row.Item(p.Name))
                                Case GetType(Boolean)
                                    If p.Name = "SELECTED" Then
                                        Trow(p.Name) = False
                                    Else
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    End If

                                Case GetType(Date), GetType(DateTime)
                                    If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                        Select Case row.Item(p.Name).ToString.Length
                                            Case 8 'yyyyMMdd
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                            Case 14 'yyyyMMddHHmmss
                                                Trow(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                            Case Else
                                                'Err
                                                Trow(p.Name) = Nothing
                                        End Select
                                    End If
                                Case Else
                                    '特定列のみ加工
                                    Select Case p.Name
                                        Case "SYONIN_NAIYO"
                                            Trow(p.Name) = row.Item("SYONIN_JUN") & "." & row.Item(p.Name).ToString.Trim
                                        Case "SASIMOTO_SYONIN_NAIYO"
                                            If row.Item("SASIMOTO_SYONIN_JUN") = "0" Then
                                                Trow(p.Name) = ""
                                            Else
                                                Trow(p.Name) = row.Item("SASIMOTO_SYONIN_JUN") & "." & row.Item(p.Name).ToString.Trim
                                            End If
                                        Case Else
                                            Trow(p.Name) = row.Item(p.Name).ToString.Trim
                                    End Select
                            End Select
                        End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

            'CHECK: 部門抽出条件適用 ログインユーザーの所属と異なる部門条件の場合・・・(すべて)を含む
            Dim blnIsAdmin As Boolean = HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID)
            If blnIsAdmin Then
                'システム管理者のみ制限解除
            Else
                If pub_SYAIN_INFO.BUMON_KB <> ParamModel.BUMON_KB Then
                    Select Case pub_SYAIN_INFO.BUMON_KB
                        Case Context.ENM_BUMON_KB._1_風防, Context.ENM_BUMON_KB._2_LP
                            Dim qdt = dt.AsEnumerable.Where(Function(r) r.Field(Of String)("BUMON_KB") = 1 Or r.Field(Of String)("BUMON_KB") = 2).ToList
                            If qdt.Count > 0 Then
                                dt = qdt.CopyToDataTable
                            End If

                        Case Context.ENM_BUMON_KB._3_複合材
                            Dim qdt = dt.AsEnumerable.Where(Function(r) r.Field(Of String)("BUMON_KB") = 3).ToList
                            If qdt.Count > 0 Then
                                dt = qdt.CopyToDataTable
                            End If
                    End Select
                End If
            End If

            Return dt
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Private Function FunSRCH(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try
            '-----選択行記憶
            If dgv.RowCount > 0 Then
                intCURROW = dgv.CurrentRow.Index
            End If
            PrDt = dt
            dgv.DataSource = dt

            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 0 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.Rows.Count)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.ST02_FUTEKIGO_ICHIRAN
        Try
            For i As Integer = 0 To dgv.Rows.Count - 1
                '差し戻し
                If dgvDATA.Rows(i).Cells(NameOf(_Model.SASIMOTO_SYONIN_JUN)).Value > 0 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                End If

                '滞留
                If dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU_FG)).Value = 1 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                End If

                'Closed
                If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.CLOSE_FG)).Value > 0 Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                End If

                'Deleted
                If dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_YMDHNS)).Value <> "" Then
                    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                End If
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
        End Try
    End Function

#End Region

#Region "追加・変更"

    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <param name="intMODE">処理モード</param>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim frmDLG As New FrmG0011
        Dim frmCAR As New FrmG0012
        Dim dlgRET As DialogResult

        Try
            If intMODE = ENM_DATA_OPERATION_MODE._3_UPDATE AndAlso dgvDATA.CurrentRow.Cells("SYONIN_HOKOKUSYO_ID").Value = ENM_SYONIN_HOKOKUSYO_ID._2_CAR Then

                frmCAR.PrDataRow = dgvDATA.GetDataRow()
                frmCAR.PrHOKOKU_NO = dgvDATA.GetDataRow().Item("HOKOKU_NO")
                frmCAR.PrCurrentStage = dgvDATA.GetDataRow().Item("SYONIN_JUN")
                dlgRET = frmCAR.ShowDialog(Me)
                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    Return True
                End If
            Else
                frmDLG.PrMODE = intMODE
                If dgvDATA.CurrentRow IsNot Nothing Then
                    frmDLG.PrDataRow = dgvDATA.GetDataRow()
                Else
                    frmDLG.PrDataRow = Nothing
                End If
                dlgRET = frmDLG.ShowDialog(Me)

                If dlgRET = Windows.Forms.DialogResult.Cancel Then
                    Return False
                Else
                    Return True
                End If
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

#Region "削除"

    Private Function FunDEL(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As Boolean
        Dim sbSQL As New System.Text.StringBuilder

        Try

            '-----UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            Select Case intSYONIN_HOKOKUSYO_ID
                Case ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D003_NCR_J) & " SET")
                Case ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D005_CAR_J) & " SET")
            End Select
            sbSQL.Append(" DEL_SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
            sbSQL.Append(" ,DEL_YMDHNS=dbo.GetSysDateString()")
            sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO.ParseSqlEscape & "'")

            'CHECK: 一覧削除ボタン D004やR001等の編集履歴はどうするか

            '-----SQL実行
            Using DB As ClsDbUtility = DBOpen()
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Dim intRET As Integer
                Try
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "全選択"

    Private Function FunSelectAll() As Boolean

        Try
            Dim rows = DirectCast(Me.dgvDATA.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("CLOSE_FG") = "0" And r.Field(Of String)("DEL_YMDHNS").Trim = "").ToList
            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = True '"●"
                Next row

                '表示更新
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "全選択解除"

    Private Function FunUnSelectAll() As Boolean

        Try

            Dim dt As DataTable = DirectCast(Me.dgvDATA.DataSource, DataTable)
            Dim rows = dt.Rows 'AsEnumerable().Where(Function(r) r.Field(Of String)("STA") = Context.ENM_HACCYU_STATUS._0_未発注)

            If rows.Count > 0 Then
                For Each row As DataRow In rows
                    row.Item("SELECTED") = False '"●"
                Next row

                '表示更新
                FunSetDgvCellFormat(Me.dgvDATA)
            Else
                'MessageBox.Show("未発注データはありません。", "全選択", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "メール送信"
    Private Function FunMailSending() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dt = DirectCast(dgvDATA.DataSource, DataTable).AsEnumerable.
                                    Where(Function(r) r.Field(Of Boolean)("SELECTED") = True)
            Dim strTantoNameList As String = ""

            If dt.Count > 0 Then
                For Each dr As DataRow In dt.CopyToDataTable.Rows
                    If strTantoNameList = "" Then
                        strTantoNameList = dr.Item("GEN_TANTO_NAME")
                    Else
                        strTantoNameList &= vbCrLf & dr.Item("GEN_TANTO_NAME")
                    End If
                Next dr

                'UNDONE: 同一担当者のデータが複数件ある場合に、確認メッセージに同一担当者名が複数表示されてしまう

                Using DB As ClsDbUtility = DBOpen()
                    Dim blnErr As Boolean
                    Try
                        DB.BeginTransaction()

                        Dim strMsg As String = "以下の担当者に処置滞留通知メールを送信します。" & vbCrLf &
                                                   "よろしいですか？" & vbCrLf &
                                                   vbCrLf &
                                                   strTantoNameList
                        If MessageBox.Show(strMsg, "処置滞留通知メール送信", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            For Each dr As DataRow In dt.CopyToDataTable.Rows
                                Dim strSubject As String = "【不適合品処置依頼】{0}・{1}"
                                Dim strBody As String = <sql><![CDATA[
                    {0} 殿
                    不適合製品の処置依頼から【滞留日数】{1}日が経過しています。
                    早急に対応をお願いします。
        
                    【報告書No】{2}
                    【承認内容(ステージ)】{3}
                    【機種】{4}
                    【部品番号】{5}
                    【依頼者】{6}                    
                    ]]></sql>.Value.Trim

                                strSubject = String.Format(strSubject, dr.Item("KISYU_NAME"), dr.Item("BUHIN_BANGO"))
                                strBody = String.Format(strBody,
                                        dr.Item("GEN_TANTO_NAME"),
                                        dr.Item("TAIRYU_NISSU"),
                                        dr.Item("HOKOKU_NO"),
                                        dr.Item("SYONIN_NAIYO"),
                                        dr.Item("KISYU_NAME"),
                                        dr.Item("BUHIN_BANGO"),
                                        Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID))

                                If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=dr.Item("GEN_TANTO_ID")) Then
                                    If FunSAVE_R001(DB, dr) Then
                                    Else
                                        blnErr = True
                                        Return False
                                    End If
                                Else
                                    MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    blnErr = True
                                    Return False
                                End If
                            Next dr

                            '全選択解除
                            Call FunUnSelectAll()

                            Return True
                        End If
                    Finally
                        DB.Commit(Not blnErr)
                    End Try
                End Using
            Else
                Dim dr As DataRow = dgvDATA.GetDataRow

                '選択チェックは入っていない場合、選択行のみ
                Dim strMsg As String = "以下の担当者に処置滞留通知メールを送信します。" & vbCrLf &
                                    "よろしいですか？" & vbCrLf &
                                    vbCrLf &
                                    dr.Item("GEN_TANTO_NAME")

                If MessageBox.Show(strMsg, "処置滞留通知メール送信", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then

                    Dim strSubject As String = "【不適合品処置依頼】{0}・{1}"
                    Dim strBody As String = <sql><![CDATA[
                    {0} 殿
                    不適合製品の処置依頼から{1}日が経過しています。
                    早急に対応をお願いします。
        
                    【報告書No】{2}
                    【承認内容(ステージ)】{3}
                    【機種】{4}
                    【部品番号】{5}
                    【依頼者】{6}                    
                    ]]></sql>.Value.Trim

                    strSubject = String.Format(strSubject, dr.Item("KISYU_NAME"), dr.Item("BUHIN_BANGO"))
                    strBody = String.Format(strBody,
                                dr.Item("GEN_TANTO_NAME"),
                                dr.Item("TAIRYU_NISSU"),
                                dr.Item("HOKOKU_NO"),
                                dr.Item("SYONIN_NAIYO"),
                                dr.Item("KISYU_NAME"),
                                dr.Item("BUHIN_BANGO"),
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID))

                    If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=dr.Item("GEN_TANTO_ID")) Then

                        Using DB As ClsDbUtility = DBOpen()
                            Dim blnErr As Boolean
                            Try
                                DB.BeginTransaction()

                                If FunSAVE_R001(DB, dr) Then
                                    Return True
                                Else
                                    blnErr = True
                                    Return False
                                End If
                            Finally
                                DB.Commit(Not blnErr)
                            End Try
                        End Using
                    Else
                        MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    ''' <summary>
    ''' 報告書操作履歴更新
    ''' </summary>
    ''' <param name="DB"></param>
    ''' <param name="enmSAVE_MODE"></param>
    ''' <returns></returns>
    Private Function FunSAVE_R001(ByRef DB As ClsDbUtility, ByVal dr As DataRow) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim sqlEx As New Exception

        'UNDONE: MERGE INTO に変更

        '---存在確認
        'Dim dsList As New DataSet
        'Dim blnExist As Boolean
        'sbSQL.Append("SELECT HOKOKU_NO FROM " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "")
        'sbSQL.Append(" WHERE HOKOKU_NO ='" & dr.Item("HOKOKU_NO") & "'")
        'dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        'If dsList.Tables(0).Rows.Count > 0 Then
        '    blnExist = True
        'End If

        '-----データモデル更新
        _R001_HOKOKU_SOUSA.clear()
        _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = dr.Item("SYONIN_HOKOKUSYO_ID")
        _R001_HOKOKU_SOUSA.HOKOKU_NO = dr.Item("HOKOKU_NO")
        _R001_HOKOKU_SOUSA.SYONIN_JUN = dr.Item("SYONIN_JUN")
        _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
        _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._4_メール送信
        _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._0_未承認
        _R001_HOKOKU_SOUSA.RIYU = "処置滞留通知送信"
        _R001_HOKOKU_SOUSA.ADD_YMDHNS = Now.ToString("yyyyMMddHHmmss")

        '-----INSERT R001
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
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
        sbSQL.Append(" ,'" & _R001_HOKOKU_SOUSA.RIYU.ParseSqlEscape & "'")
        sbSQL.Append(")")

        '-----SQL実行
        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
        If intRET <> 1 Then
            '-----エラーログ出力
            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
            WL.WriteLogDat(strErrMsg)
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "印刷"
    Private Function FunOpenReport() As Boolean
        Dim strOutputFileName As String
        Dim strTEMPFILE As String
        'Dim intRET As Integer
        Try
            Dim strHOKOKU_NO As String = dgvDATA.GetDataRow().Item("HOKOKU_NO")
            Me.Cursor = Cursors.WaitCursor
            Select Case dgvDATA.GetDataRow().Item("SYONIN_HOKOKUSYO_ID")
                Case ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    'ファイル名
                    strOutputFileName = "NCR_" & strHOKOKU_NO & "_Work.xls"

                    '既存ファイル削除
                    If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                        Return False
                    End If

                    Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                        strTEMPFILE = FunConvRootPath(iniIF.GetIniString("NCR", "FILEPATH"))
                    End Using

                    'エクセル出力ファイル用意
                    If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                        Return False
                    End If
                    '-----書込処理
                    If FunMakeReportNCR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                        Return False
                    End If
                Case ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    'ファイル名
                    strOutputFileName = "CAR_" & strHOKOKU_NO & "_Work.xls"

                    '既存ファイル削除
                    If FunDELETE_FILE(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName) = False Then
                        Return False
                    End If

                    Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_TEMPLATE_INI)
                        strTEMPFILE = FunConvRootPath(iniIF.GetIniString("CAR", "FILEPATH"))
                    End Using

                    'エクセル出力ファイル用意
                    If OUT_EXCEL_READY(strTEMPFILE, pub_APP_INFO.strOUTPUT_PATH, strOutputFileName) = False Then
                        Return False
                    End If
                    '-----書込処理
                    If FunMakeReportCAR(pub_APP_INFO.strOUTPUT_PATH & strOutputFileName, strHOKOKU_NO) = False Then
                        Return False
                    End If
                Case Else
                    'err
                    Return False
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function FunMakeReportNCR_SP(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim Workbook As New Spire.Xls.Workbook
        Dim Sheet As Spire.Xls.Worksheet

        Try

            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of MODEL.V003_SYONIN_J_KANRI) = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

            Workbook.LoadFromFile(strFilePath)
            Sheet = Workbook.Worksheets(0)


            'レコードフレーム初期化
            'spWork.Range("RECORD_FRAME").ClearContents()
            Sheet.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            Sheet.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
                Sheet.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            Sheet.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            Sheet.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(その他の内容：" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            Sheet.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = _V002_NCR_J.HAIKYAKU_YMD
            Sheet.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_NAME
            Sheet.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_YMD
            Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            Sheet.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = _V002_NCR_J.HENKYAKU_YMD
            Sheet.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            Sheet.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
                Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            Sheet.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = _V002_NCR_J.JIZEN_SINSA_YMD
            Sheet.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            Sheet.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            Sheet.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            Sheet.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            Sheet.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            Sheet.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD
            Sheet.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = _V002_NCR_J.SAIKAKO_KENSA_YMD
            Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD
            Sheet.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = _V002_NCR_J.SAISIN_HINSYO_YMD
            If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
                Sheet.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
            End If
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = _V002_NCR_J.SAISIN_KAKUNIN_YMD
            Sheet.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            Sheet.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            Sheet.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
            Sheet.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
            Sheet.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
            Sheet.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
            Sheet.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            Sheet.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(図面/規格　： " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

            Sheet.Range("SYONIN_NAME10").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_NAME120").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde処置確認).FirstOrDefault?.SYAIN_NAME
            Sheet.Range("SYONIN_YMD20").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            Sheet.Range("SYONIN_YMD30").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            Sheet.Range("SYONIN_YMD90").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            Sheet.Range("SYONIN_YMD100").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            Sheet.Range("SYONIN_YMD110").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS

            Dim pd As New System.Drawing.Printing.PrintDocument
            'プリンタ名の取得
            Dim defaultPrinterName As String = pd.PrinterSettings.PrinterName

            '-----ファイル保存
            Dim pdfDocument As New PdfDocument
            pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape
            Dim pdfConverter As New PdfConverter(Workbook)
            Dim settings As New PdfConverterSettings With {
                .TemplateDocument = pdfDocument
            }

            Dim pdfFilePath As String
            pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            Workbook.SaveToPdf(pdfFilePath, settings)

            ''PDF表示
            System.Diagnostics.Process.Start(pdfFilePath)

            'Excel作業ファイルを削除
            Try
                'System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            Sheet = Nothing
            Workbook = Nothing
        End Try
    End Function

#End Region

#Region "履歴"
    Private Function OpenFormRIREKI() As Boolean
        Dim frmDLG As New FrmG0017
        Dim dlgRET As DialogResult

        Try

            If dgvDATA.CurrentRow IsNot Nothing Then
                frmDLG.PrSYONIN_HOKOKUSYO_ID = dgvDATA.GetDataRow().Item("SYONIN_HOKOKUSYO_ID")
                frmDLG.PrHOKOKU_NO = dgvDATA.GetDataRow().Item("HOKOKU_NO")
            Else
                'parameter error
                Return False
            End If
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If FunblnAllowKIHYO() Then
                cmdFunc2.Enabled = True
            Else
                cmdFunc2.Enabled = False
                MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "起票権限がありません")
            End If

            If dgvDATA.RowCount > 0 Then
                cmdFunc3.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                cmdFunc7.Enabled = True
                cmdFunc8.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True


                '選択行がClosedの場合
                If dgvDATA.CurrentRow.Cells.Item(NameOf(_D003_NCR_J.CLOSE_FG)).Value = 1 Then
                    cmdFunc4.Enabled = False
                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "クローズ済のため変更出来ません")
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "クローズ済のため削除出来ません")
                Else
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)


                    If FunblnAllowSyonin() Then
                        cmdFunc4.Enabled = True
                    Else
                        cmdFunc4.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "変更承認権限がありません")
                    End If
                End If

                If HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then

                    If dgvDATA.CurrentRow.Cells.Item(NameOf(_D003_NCR_J.DEL_YMDHNS)).Value <> "" Then
                        '削除済み
                        cmdFunc4.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "削除済みデータです")
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "削除済みデータです")
                        dgvDATA.CurrentRow.Cells.Item("SELECTED").ReadOnly = True
                    End If

                Else

                    If dgvDATA.CurrentRow.Cells.Item(NameOf(_D003_NCR_J.DEL_YMDHNS)).Value <> "" Then
                        '削除済み
                        cmdFunc4.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "削除済みデータです")
                        cmdFunc5.Enabled = False
                        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "削除済みデータです")
                        dgvDATA.CurrentRow.Cells.Item("SELECTED").ReadOnly = True
                    End If

                    cmdFunc5.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "削除権限の使用には管理者権限が必要です")
                End If

                If FunblnAllowTairyuMailSend() Then
                    cmdFunc9.Enabled = True
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
                Else
                    cmdFunc9.Enabled = False
                    MyBase.ToolTip.SetToolTip(Me.cmdFunc9, "滞留通知メール送信権限がありません")
                End If

            Else
                cmdFunc3.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc7.Enabled = False
                cmdFunc6.Enabled = False
                cmdFunc6.Visible = False
                cmdFunc8.Enabled = False
                cmdFunc9.Enabled = False
                cmdFunc10.Enabled = False
                cmdFunc11.Enabled = False
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

    '検索フィルタ変更時
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()
    End Sub

#Region "検索条件クリア"
    Private Sub btnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click, btnClearSrchFilter2.Click, btnClearSrchFilter3.Click
        ParamModel.Clear()
        chkDleteRowVisibled.Checked = False
    End Sub
#End Region

#Region "共通検索条件"

#Region "製品区分(部門区分)"
    Private Sub CmbBUMON_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Select Case cmb.SelectedValue?.ToString.Trim
            Case ""
            Case Context.ENM_BUMON_KB._2_LP
                lblSyanaiCD.Visible = True
                cmbSYANAI_CD.Visible = True
            Case Else
                lblSyanaiCD.Visible = False
                cmbSYANAI_CD.Visible = False
        End Select

        Dim intBUFF As Integer
        intBUFF = cmbADD_TANTO.SelectedValue
        RemoveHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
        Dim dtADD_TANTO As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue, ENM_SYONIN_HOKOKUSYO_ID._1_NCR, ENM_NCR_STAGE._10_起草入力)
        cmbADD_TANTO.SetDataSource(dtADD_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        cmbADD_TANTO.SelectedValue = intBUFF
        AddHandler cmbADD_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged

        intBUFF = cmbGEN_TANTO.SelectedValue
        RemoveHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged
        Dim dtGEN_TANTO As DataTable = FunGetSYONIN_SYOZOKU_SYAIN(cmbBUMON.SelectedValue)
        cmbGEN_TANTO.SetDataSource(dtGEN_TANTO, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        cmbGEN_TANTO.SelectedValue = intBUFF
        AddHandler cmbGEN_TANTO.SelectedValueChanged, AddressOf SearchFilterValueChanged


        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        '機種
        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblKISYU_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbKISYU.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                ParamModel.KISYU_ID = 0
            End If
        Else
            cmbKISYU.SetDataSource(tblKISYU_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

        '部品番号
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblBUHIN_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                ParamModel.BUHIN_BANGO = ""
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

        '社内コード
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Clear()
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD_J.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUMON_KB)) = cmb.SelectedValue)
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                Else
                    cmbSYANAI_CD.DataSource = Nothing
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            ParamModel.SYANAI_CD = ""
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Sub

#End Region

#Region "機種"
    Private Sub CmbKISYU_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        '部品番号
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblBUHIN_J.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue)
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                Dim _selectedValue As String = cmbBUHIN_BANGO.SelectedValue

                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                If Not cmbBUHIN_BANGO.NullValue = cmbBUHIN_BANGO.SelectedValue Then
                    ParamModel.BUHIN_BANGO = _selectedValue
                End If
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged

        '社内コード
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        If blnSelected Then
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD_J.AsEnumerable.Where(Function(r) r.Field(Of Integer)(NameOf(_D003_NCR_J.KISYU_ID)) = cmb.SelectedValue)
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue

                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    If Not cmbSYANAI_CD.NullValue = _selectedValue Then
                        ParamModel.SYANAI_CD = _selectedValue
                    End If
                End If
            Else
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            ParamModel.SYANAI_CD = ""
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
    End Sub

#End Region

#Region "社内コード"
    Private Sub CmbSYANAI_CD_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '部品番号
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        If blnSelected Then
            Dim drs = tblBUHIN.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.SYANAI_CD)) = cmb.SelectedValue).ToList
            If drs.Count > 0 Then
                Dim dt As DataTable = drs.CopyToDataTable
                cmbBUHIN_BANGO.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                'ParamModel.BUHIN_BANGO = ""
            End If
        Else
            cmbBUHIN_BANGO.SetDataSource(tblBUHIN_J, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged


        '抽出
        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Clear()
        If blnSelected Then
            Dim dr As DataRow = DirectCast(cmbSYANAI_CD.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbSYANAI_CD.SelectedValue).FirstOrDefault
            ParamModel.BUHIN_BANGO = dr.Item("BUHIN_BANGO")
            ParamModel.BUHIN_NAME = dr.Item("BUHIN_NAME")
            ParamModel.KISYU_ID = dr.Item("KISYU_ID")

        Else
            ParamModel.BUHIN_BANGO = ""
            ParamModel.BUHIN_NAME = ""
            ParamModel.KISYU_ID = 0
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Sub

#End Region

#Region "部品番号"
    Private Sub CmbBUHIN_BANGO_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        Dim blnSelected As Boolean = (cmb.SelectedValue IsNot Nothing AndAlso Not cmb.SelectedValue.ToString.IsNullOrWhiteSpace)

        RemoveHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
        RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '社内コード
        If blnSelected Then
            cmbSYANAI_CD.DataBindings.Clear()
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                Dim drs = tblSYANAI_CD.AsEnumerable.Where(Function(r) r.Field(Of String)(NameOf(ParamModel.BUHIN_BANGO)) = cmb.SelectedValue).ToList
                If drs.Count > 0 Then
                    Dim dt As DataTable = drs.CopyToDataTable
                    Dim _selectedValue As String = cmbSYANAI_CD.SelectedValue
                    cmbSYANAI_CD.DisplayMember = "DISP"
                    cmbSYANAI_CD.ValueMember = "VALUE"
                    cmbSYANAI_CD.SetDataSource(dt, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    ParamModel.SYANAI_CD = _selectedValue
                End If
            Else
                ParamModel.SYANAI_CD = ""
                'cmbSYANAI_CD.DataSource = Nothing
            End If
            cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        Else
            cmbSYANAI_CD.SetDataSource(tblSYANAI_CD.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        End If
        AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged

        '抽出
        If blnSelected Then
            Dim dr As DataRow = DirectCast(cmbBUHIN_BANGO.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbBUHIN_BANGO.SelectedValue).FirstOrDefault
            If Val(cmb.SelectedValue) = Context.ENM_BUMON_KB._2_LP Then
                RemoveHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
                ParamModel.SYANAI_CD = dr.Item("SYANAI_CD")
                AddHandler cmbSYANAI_CD.SelectedValueChanged, AddressOf CmbSYANAI_CD_SelectedValueChanged
            End If
            ParamModel.BUHIN_NAME = dr.Item("BUHIN_NAME")

            RemoveHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged
            If dr.Item("KISYU_ID") <> 0 Then
                ParamModel.KISYU_ID = dr.Item("KISYU_ID")
            End If
            AddHandler cmbKISYU.SelectedValueChanged, AddressOf CmbKISYU_SelectedValueChanged

        Else
            ParamModel.SYANAI_CD = ""
            ParamModel.BUHIN_NAME = ""
            ParamModel.KISYU_ID = 0
        End If
        AddHandler cmbBUHIN_BANGO.SelectedValueChanged, AddressOf CmbBUHIN_BANGO_SelectedValueChanged
    End Sub

#End Region

#End Region

#Region "CAR検索条件"

    Private Sub CmbYOIN1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbYOIN1.SelectedValueChanged
        If cmbYOIN1.SelectedIndex > 0 Then
            mtxGENIN1_DISP.Enabled = True
            btnClearGenin1.Enabled = True
            btnSelectGenin1.Enabled = True
        Else
            mtxGENIN1_DISP.Enabled = False
            btnClearGenin1.Enabled = False
            btnSelectGenin1.Enabled = False
        End If
        PrGenin1.Clear()
        mtxGENIN1.Text = ""
        mtxGENIN1_DISP.Text = ""
    End Sub

    Private Sub CmbYOIN2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbYOIN2.SelectedValueChanged
        If cmbYOIN2.SelectedIndex > 0 Then
            mtxGENIN2_DISP.Enabled = True
            btnClearGenin2.Enabled = True
            btnSelectGenin2.Enabled = True
        Else
            mtxGENIN2_DISP.Enabled = False
            btnClearGenin2.Enabled = False
            btnSelectGenin2.Enabled = False
        End If
        PrGenin2.Clear()
        mtxGENIN2.Text = ""
        mtxGENIN2_DISP.Text = ""
    End Sub

    '原因1クリア
    Private Sub BtnClearGenin1_Click(sender As Object, e As EventArgs) Handles btnClearGenin1.Click
        mtxGENIN1.Text = ""
        mtxGENIN1_DISP.Text = ""
        PrGenin1.Clear()
    End Sub

    '原因2クリア
    Private Sub BtnClearGenin2_Click(sender As Object, e As EventArgs) Handles btnClearGenin2.Click
        mtxGENIN2.Text = ""
        mtxGENIN2_DISP.Text = ""
        PrGenin2.Clear()
    End Sub

    '原因1区分選択画面呼び出し
    Private Sub BtnSelectGenin1_Click(sender As Object, e As EventArgs) Handles btnSelectGenin1.Click

        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try
            If cmbYOIN1.SelectedValue = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrMODE = 0
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbYOIN1.SelectedValue, cmbYOIN1.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin1
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrMODE = 0
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbYOIN1.SelectedValue, cmbYOIN1.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin1
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                '検索条件文字列作成
                Dim sbWhere As New System.Text.StringBuilder
                Dim strWhereBase As String = <sql><![CDATA[
                        EXISTS
                        (
                        SELECT HOKOKU_NO FROM D006_CAR_GENIN WHERE 
                        V007_NCR_CAR.HOKOKU_NO = D006_CAR_GENIN.HOKOKU_NO
                        {0}
                        )                            
                        ]]></sql>.Value.Trim


                mtxGENIN1_DISP.Text = ""
                If PrGenin1.Count > 0 Then
                    For Each item In PrGenin1
                        If mtxGENIN1_DISP.Text.IsNullOrWhiteSpace Then
                            mtxGENIN1_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN1_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append(" AND (GENIN_BUNSEKI_KB='" & item.ITEM_NAME & "' AND GENIN_BUNSEKI_S_KB='" & item.ITEM_VALUE & "')")

                    Next item
                    ParamModel.GENIN1 = String.Format(strWhereBase, sbWhere.ToString)
                Else
                    ParamModel.GENIN1 = ""
                End If
            End If


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

    '原因2区分選択画面呼び出し
    Private Sub BtnSelectGenin2_Click(sender As Object, e As EventArgs) Handles btnSelectGenin2.Click
        Dim frmDLG As New Form
        Dim dlgRET As DialogResult
        Try
            If cmbYOIN2.SelectedValue = 0 Then
                frmDLG = New FrmG0013
                DirectCast(frmDLG, FrmG0013).PrYOIN = (cmbYOIN2.SelectedValue, cmbYOIN2.Text)
                DirectCast(frmDLG, FrmG0013).PrSelectedList = PrGenin2
            Else
                frmDLG = New FrmG0014
                DirectCast(frmDLG, FrmG0014).PrYOIN = (cmbYOIN2.SelectedValue, cmbYOIN2.Text)
                DirectCast(frmDLG, FrmG0014).PrSelectedList = PrGenin2
            End If

            dlgRET = frmDLG.ShowDialog(Me)

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                '検索条件文字列作成
                Dim sbWhere As New System.Text.StringBuilder
                Dim strWhereBase As String = <sql><![CDATA[
                    EXISTS
                    (
                    SELECT HOKOKU_NO FROM D006_CAR_GENIN WHERE 
                    V007_NCR_CAR.HOKOKU_NO = D006_CAR_GENIN.HOKOKU_NO
                    {0}
                    )
                    ]]></sql>.Value.Trim

                mtxGENIN2_DISP.Text = ""
                If PrGenin2.Count > 0 Then
                    For Each item In PrGenin2
                        If mtxGENIN2_DISP.Text.IsNullOrWhiteSpace Then
                            mtxGENIN2_DISP.Text = item.ITEM_DISP
                        Else
                            mtxGENIN2_DISP.Text &= ", " & item.ITEM_DISP
                        End If

                        sbWhere.Append(" AND (GENIN_BUNSEKI_KB='" & item.ITEM_NAME & "' AND GENIN_BUNSEKI_S_KB='" & item.ITEM_VALUE & "')")
                    Next item
                    ParamModel.GENIN2 = String.Format(strWhereBase, sbWhere.ToString)
                Else
                    ParamModel.GENIN2 = ""
                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If frmDLG IsNot Nothing Then
                frmDLG.Dispose()
            End If
        End Try
    End Sub

    '不適合区分
    Private Sub CmbFUTEKIGO_KB_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFUTEKIGO_KB.SelectedValueChanged

        If cmbFUTEKIGO_KB.SelectedValue <> "" Then
            Dim dt As New DataTableEx
            Using DB As ClsDbUtility = DBOpen()
                FunGetCodeDataTable(DB, "不適合" & cmbFUTEKIGO_KB.Text.Replace("・", "") & "区分", dt)
            End Using
            cmbFUTEKIGO_S_KB.SetDataSource(dt.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
        Else
            cmbFUTEKIGO_S_KB.DataSource = Nothing
        End If

    End Sub
#End Region

#End Region

#Region "ローカル関数"

    Private Function FunSetBinding() As Boolean

        '共通
        cmbBUMON.DataBindings.Add(New Binding(NameOf(cmbBUMON.SelectedValue), ParamModel, NameOf(ParamModel.BUMON_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHOKUKO_NO.DataBindings.Add(New Binding(NameOf(mtxHOKUKO_NO.Text), ParamModel, NameOf(ParamModel.HOKOKU_NO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbADD_TANTO.DataBindings.Add(New Binding(NameOf(cmbADD_TANTO.SelectedValue), ParamModel, NameOf(ParamModel.ADD_TANTO), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        cmbKISYU.DataBindings.Add(New Binding(NameOf(cmbKISYU.SelectedValue), ParamModel, NameOf(ParamModel.KISYU_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxGOKI.DataBindings.Add(New Binding(NameOf(mtxGOKI.Text), ParamModel, NameOf(ParamModel.GOUKI), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSYANAI_CD.DataBindings.Add(New Binding(NameOf(cmbSYANAI_CD.SelectedValue), ParamModel, NameOf(ParamModel.SYANAI_CD), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbBUHIN_BANGO.DataBindings.Add(New Binding(NameOf(cmbBUHIN_BANGO.SelectedValue), ParamModel, NameOf(ParamModel.BUHIN_BANGO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxHINMEI.DataBindings.Add(New Binding(NameOf(mtxHINMEI.Text), ParamModel, NameOf(ParamModel.BUHIN_NAME), False, DataSourceUpdateMode.OnPropertyChanged, ""))

        cmbGEN_TANTO.DataBindings.Add(New Binding(NameOf(cmbGEN_TANTO.SelectedValue), ParamModel, NameOf(ParamModel.SYOCHI_TANTO), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        dtJisiFrom.DataBindings.Add(New Binding(NameOf(dtJisiFrom.ValueNonFormat), ParamModel, NameOf(ParamModel.JISI_YMD_FROM), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        dtJisiTo.DataBindings.Add(New Binding(NameOf(dtJisiTo.ValueNonFormat), ParamModel, NameOf(ParamModel.JISI_YMD_TO), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_S_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_S_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_S_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbFUTEKIGO_JYOTAI_KB.DataBindings.Add(New Binding(NameOf(cmbFUTEKIGO_JYOTAI_KB.SelectedValue), ParamModel, NameOf(ParamModel.FUTEKIGO_JYOTAI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        chkClosedRowVisibled.DataBindings.Add(New Binding(NameOf(chkClosedRowVisibled.Checked), ParamModel, NameOf(ParamModel.VISIBLE_CLOSE), False, DataSourceUpdateMode.OnPropertyChanged, False))
        chkTairyu.DataBindings.Add(New Binding(NameOf(chkTairyu.Checked), ParamModel, NameOf(ParamModel.VISIBLE_TAIRYU), False, DataSourceUpdateMode.OnPropertyChanged, False))
        'NCR
        cmbJIZEN_SINSA_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbJIZEN_SINSA_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.JIZEN_SINSA_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbZESEI_SYOCHI_YOHI_KB.DataBindings.Add(New Binding(NameOf(cmbZESEI_SYOCHI_YOHI_KB.SelectedValue), ParamModel, NameOf(ParamModel.ZESEI_SYOCHI_YOHI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbSAISIN_IINKAI_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbSAISIN_IINKAI_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.SAISIN_IINKAI_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKOKYAKU_HANTEI_SIJI_KB.DataBindings.Add(New Binding(NameOf(cmbKOKYAKU_HANTEI_SIJI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KOKYAKU_HANTEI_SIJI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKOKYAKU_SAISYU_HANTEI_KB.DataBindings.Add(New Binding(NameOf(cmbKOKYAKU_SAISYU_HANTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KOKYAKU_SAISYU_HANTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKENSA_KEKKA_KB.DataBindings.Add(New Binding(NameOf(cmbKENSA_KEKKA_KB.SelectedValue), ParamModel, NameOf(ParamModel.KENSA_KEKKA_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        'CAR
        mtxGENIN1.DataBindings.Add(New Binding(NameOf(mtxGENIN1.Text), ParamModel, NameOf(ParamModel.GENIN1), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        mtxGENIN2.DataBindings.Add(New Binding(NameOf(mtxGENIN2.Text), ParamModel, NameOf(ParamModel.GENIN2), False, DataSourceUpdateMode.OnPropertyChanged, ""))
        cmbKISEKI_KOTEI_KB.DataBindings.Add(New Binding(NameOf(cmbKISEKI_KOTEI_KB.SelectedValue), ParamModel, NameOf(ParamModel.KISEKI_KOTEI_KB), False, DataSourceUpdateMode.OnPropertyChanged, ""))

    End Function


    Public Function FunGetDtST02_FUTEKIGO_ICHIRAN(ByVal ParamModel As ST02_ParamModel) As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbParam As New System.Text.StringBuilder
        Dim dsList As New DataSet

        '共通
        sbParam.Append(" '" & ParamModel.BUMON_KB & "'")
        sbParam.Append("," & ParamModel.SYONIN_HOKOKUSYO_ID & "")
        sbParam.Append("," & ParamModel.KISYU_ID & "")

        If ParamModel.BUHIN_BANGO <> "" Then
            sbParam.Append(",'" & ParamModel.BUHIN_BANGO & "'")
        ElseIf Not cmbBUHIN_BANGO.Text.IsNullOrWhiteSpace Then
            sbParam.Append(",'" & cmbBUHIN_BANGO.Text.Trim & "'")
        Else
            sbParam.Append(",'" & ParamModel.BUHIN_BANGO & "'")
        End If

        sbParam.Append(",'" & ParamModel.SYANAI_CD & "'")
        sbParam.Append(",'" & ParamModel.BUHIN_NAME & "'")
        sbParam.Append(",'" & ParamModel.GOUKI & "'")
        sbParam.Append("," & ParamModel.SYOCHI_TANTO & "")
        sbParam.Append(",'" & ParamModel.JISI_YMD_FROM & "'")
        sbParam.Append(",'" & ParamModel.JISI_YMD_TO & "'")
        sbParam.Append(",'" & ParamModel.HOKOKU_NO & "'")
        sbParam.Append("," & ParamModel.ADD_TANTO & "")
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_CLOSE = 1, "", ParamModel._VISIBLE_CLOSE) & "'")
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_TAIRYU = 1, ParamModel._VISIBLE_TAIRYU, "") & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_S_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_JYOTAI_KB & "'")

        'NCR
        sbParam.Append(",'" & ParamModel.JIZEN_SINSA_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.ZESEI_SYOCHI_YOHI_KB & "'")
        sbParam.Append(",'" & ParamModel.SAISIN_IINKAI_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KENSA_KEKKA_KB & "'")

        'CAR
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB1 & "'")
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB2 & "'")
        sbParam.Append(",'" & ParamModel.KISEKI_KOTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.GENIN1 & "'")
        sbParam.Append(",'" & ParamModel.GENIN2 & "'")

        sbSQL.Append("EXEC dbo." & NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN) & " " & sbParam.ToString & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function


    Private Function FunblnAllowKIHYO() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.M016_SYONIN_TANTO) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID IN(1,2)")
        sbSQL.Append(" AND SYONIN_JUN=10")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID)
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function FunblnAllowSyonin() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.M016_SYONIN_TANTO) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID IN(1,2)")
        sbSQL.Append(" AND SYONIN_JUN>10")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID)
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function FunblnAllowTairyuMailSend() As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.VWM001_SETTING) & " ")
        sbSQL.Append(" WHERE ITEM_NAME='滞留メール送信権限'")
        sbSQL.Append(" AND ITEM_DISP='" & pub_SYAIN_INFO.SYAIN_ID & "'")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region


End Class