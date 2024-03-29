Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0160

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

        'CmbSYAIN_ID.NullValue = 0
        CmbSYONIN_HOKOKUSYO_ID.NullValue = 0
        CmbSYONIN_JUN.NullValue = 0
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
            Call FunInitializeFlexGrid(flxDATA)

            '-----コントロールデータソース設定
            CmbSYONIN_HOKOKUSYO_ID.SetDataSource(tblSYONIN_HOKOKUSYO_ID.LazyLoad("承認報告書ID"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)

            '-----イベントハンドラ設定
            AddHandler CmbSYONIN_HOKOKUSYO_ID.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler CmbSYONIN_JUN.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler cmbBUMON_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler mtxSIMEI.Validated, AddressOf SearchFilterValueChanged
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
    Private Sub FlxDATA_RowColChange(sender As Object, e As EventArgs)
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

#Region "FunctionButton関連"

#Region "ボタンクリックイベント"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click

        Dim intFUNC As Integer
        Dim intCNT As Integer
        '[処理中]
        Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '検索
                    Call FunSetDgvData(flxDATA, FunGetListData())

                Case 2  '追加

                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then
                        FunSetDgvData(flxDATA, FunGetListData())
                    End If

                    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._1_ADD) = True Then

                    '    Call FunSetDgvData(flxDATA, FunGetListData())
                    'End If

                Case 3  '参照追加
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then
                        Call FunSetDgvData(flxDATA, FunGetListData())
                    End If

                    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._2_ADDREF) = True Then

                    '    Call FunSetDgvData(flxDATA, FunGetListData())
                    'End If

                Case 4  '変更
                    If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                        Call FunSetDgvData(flxDATA, FunGetListData())
                    End If

                    'If FunUpdateEntity(ENM_DATA_OPERATION_MODE._3_UPDATE) = True Then
                    '    Call FunSetDgvData(flxDATA, FunGetListData())
                    'End If

                Case 5, 6  '削除/復元/完全削除
                    Dim btn As Button = DirectCast(sender, Button)
                    Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    If FunDEL(ENM_MODE) = True Then
                        Call FunSetDgvData(flxDATA, FunGetListData())
                    End If

                    'Dim btn As Button = DirectCast(sender, Button)
                    'Dim ENM_MODE As ENM_DATA_OPERATION_MODE = DirectCast(btn.Tag, ENM_DATA_OPERATION_MODE)
                    'If FunDEL(ENM_MODE) = True Then
                    '    Call FunSetDgvData(flxDATA, FunGetListData())
                    'End If

                Case 10  'CSV出力

                    Dim strFileName As String = pub_APP_INFO.strTitle & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
                    Call FunCSV_OUT(flxDATA.DataSource, strFileName, pub_APP_INFO.strOUTPUT_PATH)

                Case 12 '閉じる
                    Me.Close()
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
            If intFUNC <> 12 Then Call SubInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

#End Region

#Region "検索"

    Private Function FunGetListData() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder
        Dim dt As New DataTable

        Try

            '----WHERE句作成
            sbSQLWHERE.Append($" WHERE 1 = 1")
            If cmbBUMON_KB.IsSelected Then
                sbSQLWHERE.Append($" AND {NameOf(MODEL.VWM016_SYONIN_TANTO.BUMON_KB)} ='{cmbBUMON_KB.SelectedValue}'")
            End If

            If CmbSYONIN_HOKOKUSYO_ID.IsSelected Then
                sbSQLWHERE.Append($"AND {NameOf(MODEL.VWM016_SYONIN_TANTO.SYONIN_HOKOKUSYO_ID)}={CmbSYONIN_HOKOKUSYO_ID.SelectedValue}")
            End If

            If CmbSYONIN_JUN.IsSelected Then
                sbSQLWHERE.Append($"AND {NameOf(MODEL.VWM016_SYONIN_TANTO.SYONIN_JUN)}={CmbSYONIN_JUN.SelectedValue}")
            End If

            If mtxSIMEI.Text <> "" Then
                sbSQLWHERE.Append($"AND {NameOf(MODEL.VWM016_SYONIN_TANTO.SYAIN_NAME)} like '%{mtxSIMEI.Text}%'")
            End If

            'flxDATA.Cols("DEL_FLG").Visible = chkDeletedRowVisibled.Checked
            'If chkDeletedRowVisibled.Checked = False Then
            '    sbSQLWHERE.Append(" AND DEL_FLG <> 1")
            'End If

            'SQL
            sbSQL.Append("SELECT")
            sbSQL.Append(" DISTINCT *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM016_SYONIN_TANTO) & "")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            Dim t As Type = GetType(MODEL.VWM016_SYONIN_TANTO)
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

#End Region

    Private Function FunSetDgvData(ByVal flx As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dt As DataTable) As Boolean

        Dim intCURROW As Integer
        Try
            If dt Is Nothing Then
                Return False
            End If

            '-----選択行記憶
            If flx.Rows.Count > 0 Then
                intCURROW = flx.RowSel
            End If

            flx.BeginUpdate()
            flx.DataSource = dt

            'Call FunSetGridCellFormat(flx)
            If flx.Rows.Count > 0 Then
                ''-----選択行設定
                '-----選択行設定
                Try
                    flx.RowSel = intCURROW
                Catch dgvEx As Exception
                End Try
                lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, flx.Rows.Count - flx.Rows.Fixed.ToString)
            Else
                lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            flx.EndUpdate()
        End Try
    End Function

#Region "追加・変更"

    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

        Dim frmDLG As New FrmM0161
        Dim dlgRET As DialogResult
        Dim PKeys As (ITEM_NAME As String, ITEM_VALUE As String)

        Try
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

            ''追加したコードの行を選択する
            'For i As Integer = 0 To Me.dgvDATA.RowCount - 1
            '    With Me.dgvDATA.Rows(i)
            '        If .Cells(0).Value = PKeys Then
            '            Me.dgvDATA.CurrentCell = .Cells(0)
            '            Exit For
            '        End If
            '    End With
            'Next i

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
        Dim strMsg As String
        Dim strTitle As String
        Dim blnDeleteSubTable As Boolean
        Try
            '-----SQL
            sbSQL.Remove(0, sbSQL.Length)

            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M016_SYONIN_TANTO) & " SET ")
                    '変更日時
                    sbSQL.Append(" EDIT_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = dbo.GetSysDateString() ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M016_SYONIN_TANTO) & " SET ")
                    '削除日時
                    sbSQL.Append(" DEL_YMDHNS = ' ' ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_TANTO_CD = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.M016_SYONIN_TANTO) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete
                    blnDeleteSubTable = True
                Case Else
                    ' argument null exception
                    Return False
            End Select
            sbSQL.Append($" WHERE SYONIN_HOKOKUSYO_ID = " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("SYONIN_HOKOKUSYO_ID") & " ")
            sbSQL.Append($" AND SYONIN_JUN = " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("SYONIN_JUN") & " ")
            sbSQL.Append($" AND SYAIN_ID = " & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("SYAIN_ID") & " ")

            '確認メッセージ表示
            If MessageBox.Show(strMsg, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                'Me.Close()
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim blnErr As Boolean
                Dim sqlEx As Exception = Nothing
                Try
                    'トランザクション
                    DB.BeginTransaction()
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    '-----トランザクション
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
    Public Function SubInitFuncButtonEnabled() As Boolean
        Try
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
                'If flxDATA(flxDATA.RowSel, "DEL_FLG") = True Then
                '    '削除済データの場合
                '    cmdFunc4.Enabled = False
                '    cmdFunc5.Text = "完全削除(F5)"
                '    cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                '    '復元
                '    cmdFunc6.Text = "復元(F6)"
                '    cmdFunc6.Visible = True
                '    cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                'Else
                cmdFunc5.Text = "完全削除(F5)"
                cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                cmdFunc6.Text = ""
                cmdFunc6.Visible = False
                cmdFunc6.Tag = ""
                'End If
            Else
                cmdFunc6.Visible = False
            End If
            If Not HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then
                cmdFunc2.Enabled = False
                cmdFunc3.Enabled = False
                cmdFunc4.Enabled = False
                cmdFunc5.Enabled = False
                cmdFunc6.Enabled = False
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

    Private Sub CmbSYONIN_HOKOKUSYO_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSYONIN_HOKOKUSYO_ID.SelectedValueChanged
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        Using DB As ClsDbUtility = DBOpen()
            Select Case cmb.SelectedValue
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    Call FunGetCodeDataTable(DB, "NCR", tblNCR)
                    CmbSYONIN_JUN.SetDataSource(tblNCR, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    CmbSYONIN_JUN.ReadOnly = False
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    Call FunGetCodeDataTable(DB, "CAR", tblCAR)
                    CmbSYONIN_JUN.SetDataSource(tblCAR, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    CmbSYONIN_JUN.ReadOnly = False
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    CmbSYONIN_JUN.SetDataSource(tblCTS.LazyLoad("CTS"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    CmbSYONIN_JUN.ReadOnly = False
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB
                    CmbSYONIN_JUN.SetDataSource(tblFCCB.LazyLoad("FCCB"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    CmbSYONIN_JUN.ReadOnly = False
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI
                    CmbSYONIN_JUN.SetDataSource(tblZESEI.LazyLoad("ZESEI"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    CmbSYONIN_JUN.ReadOnly = False
                    'Case Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R
                    '    CmbSYONIN_JUN.SetDataSource(tblZESEI_R.LazyLoad("ZESEI_R"), ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
                    '    CmbSYONIN_JUN.ReadOnly = False
                Case Else
                    'CmbSYONIN_JUN.DataSource = Nothing
                    CmbSYONIN_JUN.ReadOnly = True
            End Select
        End Using
    End Sub

#End Region

End Class