Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0030

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
        MyBase.ToolTip.SetToolTip(Me.cmdFunc10, My.Resources.infoToolTipMsgNotFoundData)

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            ''-----グリッド初期設定
            FunInitializeFlexGrid(flxDATA)

            '-----コントロールデータソース設定
            'Me.cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            'Me.cmbBUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            ''-----イベントハンドラ設定
            'AddHandler Me.cmbBUMON_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            'AddHandler Me.cmbBUSYO_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '検索実行
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    '初期化
    Private Function FunInitializeFlexGrid(ByVal flxgrd As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        With flxgrd
            .Rows(0).Height = 30

            .AutoGenerateColumns = False
            .AutoResize = True
            .AllowEditing = False
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .AllowDelete = False
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
            '.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows
            .AllowFiltering = True

            .ShowCellLabels = True
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None

            .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

            .Styles.Add("DeletedRow")
            .Styles("DeletedRow").BackColor = clrDeletedRowBackColor
            .Styles("DeletedRow").ForeColor = clrDeletedRowForeColor

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Silver 'Custom

            '以下を適用するにはVisualStyleをCustomにする
            .Styles.Alternate.BackColor = clrRowEvenColor
            .Styles.Normal.BackColor = clrRowOddColor
            .Styles.Focus.BackColor = clrRowEnterColor
        End With
    End Function

    '行選択時イベント
    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs) Handles flxDATA.RowColChange
        Call SubInitFuncButtonEnabled()
    End Sub

    '列フィルタ適用
    Private Sub FlxDATA_AfterFilter(sender As Object, e As EventArgs)
        Dim flx As C1.Win.C1FlexGrid.C1FlexGrid = DirectCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        Dim intCNT As Integer

        For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
            If r.Visible = True Then
                intCNT += 1
            End If
        Next
        intCNT -= flx.Rows.Fixed

        If intCNT > 0 Then
            Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, intCNT)
        Else
            Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
        End If
    End Sub

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub FlxDATA_DoubleClick(sender As Object, e As EventArgs)
        If flxDATA.RowSel > 0 Then
            Me.cmdFunc4.PerformClick()
        End If
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
                    Call FunSRCH(Me.flxDATA, FunGetListData())
                Case 2  '追加
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 3  '参照追加
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 4  '変更

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If
                Case 5, 6  '削除/復元/完全削除

                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        Call FunSRCH(Me.flxDATA, FunGetListData())
                    End If

                Case 10  'CSV出力

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    Call FunCSV_OUT(Me.flxDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

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
            If intFUNC <> 12 Then Call SubInitFuncButtonEnabled()

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

            ''----DBデータ取得
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append(" WHERE 1 = 1 ")

            'If Me.cmbBUMON_KB.SelectedIndex <> 0 Then
            '    sbSQLWHERE.Append(" AND BUMON_KB ='" & Me.cmbBUMON_KB.SelectedValue & "' ")
            'End If

            'If Me.cmbBUSYO_KB.SelectedIndex <> 0 Then
            '    sbSQLWHERE.Append(" AND BUSYO_KB = '" & Me.cmbBUSYO_KB.SelectedValue & "' ")
            'End If

            'If Me.datYUKO_YMD.ValueNonFormat.Trim <> "" Then
            '    sbSQLWHERE.Append(" AND YUKO_YMD >= '" & Me.datYUKO_YMD.ValueNonFormat & "' ")
            'End If

            'If Me.txtOYA_BUSYO_NAME.Text.Trim <> "" Then
            '    sbSQLWHERE.Append(" AND OYA_BUSYO_NAME like '%" & Me.txtOYA_BUSYO_NAME.Text & "%' ")
            'End If

            'If Me.txtBUSYO_NAME.Text.Trim <> "" Then
            '    sbSQLWHERE.Append(" AND BUSYO_NAME like '%" & Me.txtBUSYO_NAME.Text.Trim & "%' ")
            'End If

            If Me.chkDeletedRowVisibled.Checked = False Then
                sbSQLWHERE.Append(" AND DEL_YMDHNS = ' ' ")
                'flxDATA.Cols("DEL_FLG").Visible = False
            Else
                'flxDATA.Cols("DEL_FLG").Visible = True
            End If

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" * ")
            sbSQL.Append(",(CASE WHEN DEL_YMDHNS='' THEN '0' ELSE '1' END) DEL_FLG ")
            sbSQL.Append(" FROM " & NameOf(MODEL.M003_GYOMU_GROUP) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append($" ORDER BY {NameOf(MODEL.M003_GYOMU_GROUP.GYOMU_GROUP_ID)} ")
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

            Dim t As Type = GetType(MODEL.M003_GYOMU_GROUP)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                'If IsAutoGenerateField(t, p.Name) = True Then
                dt.Columns.Add(p.Name, p.PropertyType)
                'End If
            Next p

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    For Each p As Reflection.PropertyInfo In properties

                        Debug.Print(p.Name)

                        'If IsAutoGenerateField(t, p.Name) = True Then
                        Select Case p.PropertyType
                            Case GetType(Integer)
                                Trow(p.Name) = Val(row.Item(p.Name))
                            Case GetType(Decimal)
                                Trow(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                Trow(p.Name) = CBool(row.Item(p.Name))
                            Case Else
                                Select Case p.Name
                                    Case "YUKO_YMD"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2)
                                    Case "UPD_YMDHNS", "ADD_YMDHNS"
                                        Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2) & " " & Mid(row.Item(p.Name), 9, 2) & ":" & Mid(row.Item(p.Name), 11, 2) & ":" & Mid(row.Item(p.Name), 13, 2)
                                    Case "DEL_FLG"
                                        Trow(p.Name) = CBool(row.Item(p.Name))
                                    Case "Item", "Properties"

                                    Case Else
                                        Trow(p.Name) = row.Item(p.Name)
                                End Select
                        End Select
                        'End If
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

    Private Function FunSRCH(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean
        Dim intCURROW As Integer
        Try

            '-----選択行記憶
            If flx.Rows.Count > 1 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()

            If dt IsNot Nothing Then
                flx.DataSource = dt
            End If

            Call FunSetGridCellFormat(flx)

            If flx.Rows.Count > 0 Then
                '-----選択行設定
                Try

                    flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            '-----一覧可視
            'dgv.Visible = True
            flx.EndUpdate()
        End Try
    End Function

    Private Function FunSetGridCellFormat(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean

        Try

            For Each r As C1.Win.C1FlexGrid.Row In flx.Rows
                If r.Index > 0 AndAlso CBool(r.Item("DEL_FLG")) = True Then
                    r.Style = flx.Styles("DeletedRow")
                End If
            Next
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
        Dim frmDLG As New FrmM0031
        Dim dlgRET As DialogResult
        Dim PKeys As (ITEM_NAME As String, ITEM_VALUE As String)
        Dim strComboVal As String

        Try

            'コンボボックスの選択値を記憶
            'If cmbBUMON_KB.SelectedValue IsNot Nothing Then
            '    strComboVal = cmbBUMON_KB.SelectedValue
            'Else
            '    strComboVal = ""
            'End If

            frmDLG.PrMODE = intMODE
            If flxDATA.RowSel > 0 Then
                frmDLG.PrDataRow = flxDATA.Rows(flxDATA.RowSel)
            Else
                frmDLG.PrDataRow = Nothing
            End If

            dlgRET = frmDLG.ShowDialog(Me)
            PKeys = frmDLG.PrPKeys

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

#Region "削除"

    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strComboVal As String
        Dim strMsg As String
        Dim strTitle As String

        Try

            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    '-----更新
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M003_GYOMU_GROUP) & " SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = dbo.GetSysDateString(), ")
                    '削除担当者
                    sbSQL.Append(" DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    '-----更新
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M003_GYOMU_GROUP) & " SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = ' ', ")
                    '削除担当者
                    sbSQL.Append(" DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    '-----削除
                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.M003_GYOMU_GROUP) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    ' argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" GYOMU_GROUP_ID = '" & flxDATA.Rows(flxDATA.RowSel).Item("GYOMU_GROUP_ID").ToString & "' ")

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

            End Using

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
    Private Function SubInitFuncButtonEnabled() As Boolean

        For intFunc As Integer = 1 To 12
            With Me.Controls("cmdFunc" & intFunc)
                If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
                    .Text = ""
                    .Visible = False
                End If
            End With
        Next intFunc

        If flxDATA.Rows.Count > 0 Then
            cmdFunc3.Enabled = True
            cmdFunc4.Enabled = True
            cmdFunc5.Enabled = True
            cmdFunc10.Enabled = True
        Else
            cmdFunc3.Enabled = False
            cmdFunc4.Enabled = False
            cmdFunc5.Enabled = False
            cmdFunc10.Enabled = False
        End If

        If flxDATA.RowSel > 0 Then
            If flxDATA(flxDATA.RowSel, "DEL_FLG") = True Then
                '削除済データの場合
                cmdFunc4.Enabled = False
                cmdFunc5.Text = "完全削除(F5)"
                cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '復元
                cmdFunc6.Text = "復元(F6)"
                cmdFunc6.Visible = True
                cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
            Else
                cmdFunc5.Text = "削除(F5)"
                cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                cmdFunc6.Text = ""
                cmdFunc6.Visible = False
                cmdFunc6.Tag = ""
            End If
        Else
            cmdFunc6.Visible = False
        End If

        If Not HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then
            cmdFunc2.Enabled = False
            cmdFunc3.Enabled = False
            cmdFunc4.Enabled = False
            cmdFunc5.Enabled = False
            cmdFunc6.Enabled = False
            MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "管理者権限が必要です")
            MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "管理者権限が必要です")
            MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "管理者権限が必要です")
            MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "管理者権限が必要です")
            MyBase.ToolTip.SetToolTip(Me.cmdFunc6, "管理者権限が必要です")
        End If

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