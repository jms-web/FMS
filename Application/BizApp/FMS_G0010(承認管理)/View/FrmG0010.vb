Imports JMS_COMMON.ClsPubMethod
Imports C1.Win.C1FlexGrid

Public Class FrmG0010

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        'ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc3, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc4, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc7, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc8, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc9, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)
        MyBase.ToolTip.SetToolTip(Me.cmdFunc11, My.Resources.infoToolTipMsgNotFoundData)

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

            '-----コントロールデータソース設定
            'Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            ''-----イベントハンドラ設定
            'AddHandler Me.cmbKOMO_NM.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '検索実行
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
        Try
            With dgv
                .AutoGenerateColumns = False

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = NameOf(_Model.SELECTED),
                .HeaderText = "選択",
                .DataPropertyName = .Name
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).Width = 30

                .Columns.Add(NameOf(_Model.HOKOKUSYO_NO), "報告書No")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SYONIN_NAIYO), "ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_R_NAME), "略名")
                .Columns(.ColumnCount - 1).Width = 70
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SYOCHI_SYAIN_NAME), "処置担当者")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.TAIRYU), "滞留日数")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.KISYU), "機種")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.BUHIN_BANGO), "部品番号")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SYONIN_HOKOKUSYO_NAME), "名称")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.JIZEN_SINSA_HANTEI_KB_DISP), "事前判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SAISIN_IINKAI_HANTEI_KB_DISP), "再審判定区分")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.ADD_YMD), "起草日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.SYOCHI_YMD), "前処理実施日")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_NAIYO), "差戻元ステージ")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add(NameOf(_Model.MODOSI_RIYU), "差戻理由")
                .Columns(.ColumnCount - 1).Width = 180
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name


                .Columns.Add(NameOf(_Model.MODOSI_SYONIN_JUN), "差戻承認順")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                '.Columns(.ColumnCount - 1).DefaultCellStyle.Format = "#,0"
            End With


            Return True
        Finally

        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs)
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
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs)
        Try
        Finally
            Call FunInitFuncButtonEnabled()
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
                Case 1  '検索
                    Call FunSRCH(dgvDATA, FunGetListData())
                Case 2  '追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 3  '参照追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 4  '変更

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If
                Case 5, 6  '削除/復元/完全削除

                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        Call FunSRCH(dgvDATA, FunGetListData())
                    End If

                Case 10  'CSV出力

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    'Call FunCSV_OUT(Me.dgvDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)


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
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim sbSQLWHERE As New System.Text.StringBuilder

            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append("'','',0,'','','','',''")

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.TV01_FUTEKIGO_ICHIRAN) & "(" & sbSQLWHERE.ToString & ")")
            'sbSQL.Append(" ORDER BY KOMO_NM, DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.TV01_FUTEKIGO_ICHIRAN)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
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

            With dsList.Tables(0)
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
                                        Trow(p.Name) = CDate(row.Item(p.Name))
                                    End If
                                Case Else
                                    Trow(p.Name) = row.Item(p.Name)
                            End Select
                        End If
                    Next p
                    dt.Rows.Add(Trow)
                Next row
                dt.AcceptChanges()
            End With

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

            dgv.DataSource = dt

            Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 1 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.Rows.Count - 1)
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

        Try
            'UNDONE: コードマスタより取得
            Dim intWarningNotification As Integer = 3

            Dim _Model As New MODEL.TV01_FUTEKIGO_ICHIRAN
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.TAIRYU)).Value > intWarningNotification Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrWarningCellBackColor
                    End If

                    If Me.dgvDATA.Rows(i).Cells(NameOf(_Model.MODOSI_SYONIN_JUN)).Value > 0 Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrCautionCellBackColor
                    End If
                End With

                '削除
                'Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                'Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                'Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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
        Dim dlgRET As DialogResult
        'Dim PKeys As Tuple(Of String, String)
        Dim strComboVal As String

        Try
            'TODO: 参照型のSystem.Tupleを値型のSystem.ValueTupleに置き換える

            'コンボボックスの選択値を記憶
            If cmbSTAGE_NCR.SelectedValue IsNot Nothing Then
                strComboVal = cmbSTAGE_NCR.SelectedValue
            Else
                strComboVal = ""
            End If

            'frmDLG.PrMODE = intMODE
            'If Me.dgvDATA.CurrentRow IsNot Nothing Then
            '    frmDLG.PrdgvCellCollection = Me.dgvDATA.CurrentRow.Cells
            '    frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            'Else
            '    frmDLG.PrdgvCellCollection = Nothing
            '    frmDLG.PrDataRow = Nothing
            'End If
            dlgRET = frmDLG.ShowDialog(Me)
            'PKeys = frmDLG.PrPKeys

            If dlgRET = Windows.Forms.DialogResult.Cancel Then
                Return False
            Else

                '-----項目名が追加になった場合、検索フィルタのコンボボックスのデータソースを再設定
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "項目名", tblKOMO_NM)
                End Using
                Me.cmbSTAGE_NCR.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)
                Me.cmbSTAGE_NCR.SelectedValue = strComboVal


                '追加したコードの行を選択する
                'For i As Integer = 0 To Me.dgvDATA.RowCount - 1
                '    With Me.dgvDATA.Rows(i)
                '        If .Cells(0).Value = PKeys.Item1 And
                '            .Cells(1).Value = PKeys.Item2 Then

                '            Me.dgvDATA.CurrentCell = .Cells(0)
                '            Exit For
                '        End If
                '    End With
                'Next i
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

#Region "削除"

    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strComboVal As String
        Dim strMsg As String
        Dim strTitle As String

        Try

            'コンボボックスの選択値
            strComboVal = Me.cmbSTAGE_NCR.Text.Trim

            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    '-----更新
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
                    '削除担当者
                    sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")



                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    '-----更新
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = ' ', ")
                    '削除担当者
                    sbSQL.Append(" DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    '-----削除
                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.M001_SETTING) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    'UNDONE: argument null exception
                    Return False
            End Select
            sbSQL.Append("WHERE")
            'sbSQL.Append(" KOMO_NM = '" & Me.dgvDATA.CurrentRow.Cells.Item("KOMO_NM").Value.ToString & "' ")
            'sbSQL.Append(" AND VALUE = '" & Me.dgvDATA.CurrentRow.Cells.Item("VALUE").Value.ToString & "' ")

            '確認メッセージ表示
            If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                'Me.Close()
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim blnErr As Boolean
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing

                Try
                    DB.BeginTransaction()

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & "|" & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    DB.Commit(Not blnErr)
                End Try

                '検索フィルタデータソース更新
                Call FunGetCodeDataTable(DB, "項目名", tblKOMO_NM)
            End Using
            Me.cmbSTAGE_NCR.SetDataSource(tblKOMO_NM.ExcludeDeleted, True)

            If strComboVal <> "" Then
                Me.cmbSTAGE_NCR.Text = strComboVal
            End If
            If Me.cmbSTAGE_NCR.SelectedIndex <= 0 Then
                Me.cmbSTAGE_NCR.Text = ""
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
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
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If dgvDATA.RowCount > 0 Then
                cmdFunc3.Enabled = True
                cmdFunc4.Enabled = True
                cmdFunc5.Enabled = True
                'cmdFunc6.Enabled = True
                cmdFunc7.Enabled = True
                cmdFunc8.Enabled = True
                cmdFunc9.Enabled = True
                cmdFunc10.Enabled = True
                cmdFunc11.Enabled = True

                'If dgvDATA.CurrentRow IsNot Nothing AndAlso dgvDATA.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
                '    '削除済データの場合
                '    cmdFunc4.Enabled = False
                '    cmdFunc5.Text = "完全削除(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '    '復元
                '    cmdFunc6.Text = "復元(F6)"
                '    cmdFunc6.Visible = True
                '    cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                'Else
                '    cmdFunc5.Text = "削除(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                '    cmdFunc6.Text = ""
                '    cmdFunc6.Visible = False
                '    cmdFunc6.Tag = ""
                'End If

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

    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()

    End Sub

#End Region


End Class