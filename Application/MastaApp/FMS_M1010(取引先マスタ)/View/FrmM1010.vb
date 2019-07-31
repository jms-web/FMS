Imports JMS_COMMON.ClsPubMethod

Public Class FrmM1010

#Region "定数・変数"
    Private pri_objPrevCellValue As Object
#End Region

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

        Me.Icon = My.Resources._icoBase_cog32x32
        Me.ShowIcon = True
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
            cmbTORI_KB.SetDataSource(tblTORI_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._1_Filter)
            '-----コンボボックス既定値の設定
            'cmbTORI_KBN.SetDefaultValue()
            '-----イベントハンドラ設定
            AddHandler cmbTORI_KB.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged


            '検索実行
            Me.cmdFunc1.PerformClick()

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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

#Region "DataGridView関連"

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
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

#End Region

#Region "編集可能セルOnMouse時カーソル変更"
    Private Sub Dgv_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 AndAlso dgv(e.ColumnIndex, e.RowIndex).ReadOnly = False Then
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case "ZOKUSEI_K_CD"
                    dgv.Cursor = Cursors.Hand
                Case Else
                    dgv.Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub Dgv_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.Cursor = Cursors.Default
    End Sub
#End Region

#Region "FunctionButton関連"

#Region "FUNCTIONボタンCLICKイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
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
                    Dim strFileName As String = lblTytle.Text & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"
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

#Region "追加・変更"
    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <returns></returns>
    Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim frmDLG As New FrmM1011
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

#Region "検索"
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

    'Private Function FunGetListData() As DataTable
    '    Dim dsList As New System.Data.DataSet
    '    Dim sbSQL As New System.Text.StringBuilder
    '    Dim sbSQLWHERE As New System.Text.StringBuilder

    '    Try

    '        '----WHERE句作成
    '        sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

    '        sbSQLWHERE.Append(" WHERE 0 = 0 ")

    '        '---職番
    '        If Not (Me.mtxSYAIN_NO.Text.IsNullOrWhiteSpace) Then
    '            sbSQLWHERE.Append(" AND SYAIN_NO = " & Me.mtxSYAIN_NO.Text.Trim & " ")
    '        End If

    '        '---担当者名検索
    '        If Not (Me.mtxSIMEI.Text.IsNullOrWhiteSpace) Then
    '            sbSQLWHERE.Append(" AND SIMEI LIKE '%" & Me.mtxSIMEI.Text.Trim & "%'")
    '        End If

    '        '---担当者名カナ検索
    '        If Not (Me.mtxSIMEI_KANA.Text.IsNullOrWhiteSpace) Then
    '            sbSQLWHERE.Append(" AND SIMEI_KANA LIKE '%" & Me.mtxSIMEI_KANA.Text.Trim & "%'")
    '        End If

    '        '---役職区分
    '        If Me.cmbYAKUSYOKU_KB.SelectedIndex <> 0 Then
    '            sbSQLWHERE.Append(" AND YAKUSYOKU_KB = '" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
    '        End If

    '        '---社員区分
    '        If Me.cmbSYAIN_KB.SelectedIndex <> 0 Then
    '            sbSQLWHERE.Append(" AND SYAIN_KB LIKE '%" & Me.cmbSYAIN_KB.SelectedValue & "%'")
    '        End If

    '        '---入社年月日（カラ）
    '        If Me.dtbNYUSYA_YMD_FROM.ValueNonFormat.Trim <> "" Then
    '            sbSQLWHERE.Append(" AND NYUSYA_YMD >= '" & Me.dtbNYUSYA_YMD_FROM.ValueNonFormat & "' ")
    '        End If

    '        '---入社年月日（マデ）
    '        If Me.dtbNYUSYA_YMD_To.ValueNonFormat.Trim <> "" Then
    '            sbSQLWHERE.Append(" AND NYUSYA_YMD <= '" & Me.dtbNYUSYA_YMD_To.ValueNonFormat & "' ")
    '        End If

    '        '---退職者
    '        If Me.chkTaisyokuRowVisibled.Checked = False Then
    '            'sbSQLWHERE.Append(" AND TAISYA_YMD = ' ' ")
    '            sbSQLWHERE.Append(" AND (TAISYA_YMD >= '" & DateTime.Now.ToString("yyyyMMdd") & "' OR TAISYA_YMD = '')")
    '        End If

    '        If Me.chkDeletedRowVisibled.Checked = False Then
    '            sbSQLWHERE.Append(" AND DEL_YMDHNS = ' ' ")
    '            flxDATA.Cols("DEL_FLG").Visible = False
    '        Else
    '            flxDATA.Cols("DEL_FLG").Visible = True
    '        End If

    '        'SQL
    '        sbSQL.Remove(0, sbSQL.Length)
    '        sbSQL.Append("SELECT")
    '        sbSQL.Append(" *")
    '        sbSQL.Append(" FROM " & NameOf(MODEL.VWM004_SYAIN) & " ")
    '        sbSQL.Append(sbSQLWHERE)
    '        sbSQL.Append(" ORDER BY SIMEI_KANA ")

    '        Using DBa As ClsDbUtility = DBOpen()
    '            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
    '        End Using

    '        If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
    '            If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
    '                Return Nothing
    '            End If
    '        End If

    '        '------DataTableに変換
    '        Dim dt As New DataTable

    '        Dim t As Type = GetType(MODEL.VWM004_SYAIN)
    '        Dim properties As Reflection.PropertyInfo() = t.GetProperties(
    '             Reflection.BindingFlags.Public Or
    '             Reflection.BindingFlags.NonPublic Or
    '             Reflection.BindingFlags.Instance Or
    '             Reflection.BindingFlags.Static)

    '        For Each p As Reflection.PropertyInfo In properties
    '            'If IsAutoGenerateField(t, p.Name) = True Then
    '            dt.Columns.Add(p.Name, p.PropertyType)
    '            'End If
    '        Next p

    '        With dsList.Tables(0)
    '            For Each row As DataRow In .Rows
    '                Dim Trow As DataRow = dt.NewRow()
    '                For Each p As Reflection.PropertyInfo In properties

    '                    'If IsAutoGenerateField(t, p.Name) = True Then
    '                    Select Case p.PropertyType
    '                        Case GetType(Integer)
    '                            Trow(p.Name) = Val(row.Item(p.Name))
    '                        Case GetType(Decimal)
    '                            Trow(p.Name) = CDec(row.Item(p.Name))
    '                        Case GetType(Boolean)
    '                            Trow(p.Name) = CBool(row.Item(p.Name))
    '                        Case Else
    '                            Select Case p.Name
    '                                Case "YUKO_YMD", "BIRTH_YMD", "NYUSYA_YMD", "TAISYA_YMD"
    '                                    Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2)
    '                                Case "UPD_YMDHNS", "ADD_YMDHNS"
    '                                    Trow(p.Name) = Mid(row.Item(p.Name), 1, 4) & "/" & Mid(row.Item(p.Name), 5, 2) & "/" & Mid(row.Item(p.Name), 7, 2) & " " & Mid(row.Item(p.Name), 9, 2) & ":" & Mid(row.Item(p.Name), 11, 2) & ":" & Mid(row.Item(p.Name), 13, 2)
    '                                Case "DEL_FLG"
    '                                    Trow(p.Name) = CBool(row.Item(p.Name))
    '                                Case "Item", "Properties"

    '                                Case Else
    '                                    Trow(p.Name) = row.Item(p.Name)
    '                            End Select
    '                    End Select
    '                    'End If
    '                Next p
    '                dt.Rows.Add(Trow)
    '            Next row
    '            dt.AcceptChanges()
    '        End With

    '        Return dt
    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '        Return Nothing
    '    End Try
    'End Function

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


    Private Function FunGetListData() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder

        Try

            '----WHERE句作成
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append(" WHERE 0 = 0 ")

            '---取引区分
            If Me.cmbTORI_KB.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND TORI_KB = '" & Me.cmbTORI_KB.SelectedValue & "'")
            End If

            '---社員区分
            If Me.mtxTORI_NAME.Text <> "" Then
                sbSQLWHERE.Append(" AND TORI_NAME LIKE '%" & Me.mtxTORI_NAME.Text & "%'")
            End If

            If Me.chkDeletedRowVisibled.Checked = False Then
                sbSQLWHERE.Append(" AND DEL_YMDHNS = ' ' ")
                flxDATA.Cols("DEL_FLG").Visible = False
            Else
                flxDATA.Cols("DEL_FLG").Visible = True
            End If

            'SQL
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM101_TORIHIKI) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY TORI_NAME ")

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

            Dim t As Type = GetType(MODEL.VWM101_TORIHIKI)
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
                                    Case "YUKO_YMD", "BIRTH_YMD", "NYUSYA_YMD", "TAISYA_YMD"
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


#Region "検索"
    'Private Function FunSRCH() As DataTable
    '    Dim dsList As New System.Data.DataSet
    '    Dim sbSQL As New System.Text.StringBuilder
    '    Dim sbSQLWHERE As New System.Text.StringBuilder
    '    Dim waitDlg As WaitDialog = Nothing
    '    'Dim lngCURROW As Long = 0
    '    '-----件数確認
    '    sbSQL.Remove(0, sbSQL.Length)
    '    sbSQL.Append("SELECT COUNT(*) FROM " & NameOf(MODEL.VWM101_TORIHIKI) & "")
    '    sbSQL.Append(sbSQLWHERE)
    '    '----WHERE句作成
    '    sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

    '    '取引区分
    '    If Me.cmbTORI_KB.Selected Then
    '        If sbSQLWHERE.Length = 0 Then
    '            sbSQLWHERE.Append(" WHERE TORI_KB = '" & Me.cmbTORI_KB.SelectedValue & "' ")
    '        Else
    '            sbSQLWHERE.Append(" AND TORI_KB =  '" & Me.cmbTORI_KB.SelectedValue & "' ")

    '        End If
    '    Else

    '    End If

    '    '取引先名検索
    '    If mtxTORI_NAME.Text.IsNullOrWhiteSpace = False Then

    '        If sbSQLWHERE.Length = 0 Then
    '            sbSQLWHERE.Append(" WHERE TORI_NAME LIKE '%" & Me.mtxTORI_NAME.Text.Trim & "%' ")
    '        Else
    '            sbSQLWHERE.Append(" AND TORI_NAME LIKE '%" & Me.mtxTORI_NAME.Text.Trim & "%' ")

    '        End If
    '    End If

    '    If Me.chkDeletedRowVisibled.Checked = False Then
    '        If sbSQLWHERE.Length = 0 Then
    '            sbSQLWHERE.Append(" WHERE DEL_FLG <> 1 ")
    '        Else
    '            sbSQLWHERE.Append(" AND DEL_FLG <> 1 ")
    '        End If
    '        dgvDATA.Columns("DEL_FLG").Visible = False
    '    Else
    '        dgvDATA.Columns("DEL_FLG").Visible = True
    '    End If

    '    'SQL
    '    sbSQL.Remove(0, sbSQL.Length)
    '    sbSQL.Append("SELECT")
    '    sbSQL.Append(" *")
    '    sbSQL.Append(" FROM " & priTableName & " ")
    '    sbSQL.Append(sbSQLWHERE)
    '    sbSQL.Append(" ORDER BY TORI_ID ")

    '    Using DB As ClsDbUtility = DBOpen()
    '        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
    '    End Using

    '    If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
    '        If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
    '            Return Nothing
    '        End If
    '    End If


    '    '------DataTableに変換
    '    Dim _Model As New MODEL.ModelInfo(Of MODEL.VWM101_TORIHIKI)(srcDATA:=dsList.Tables(0))
    '    Return _Model.Data

    'End Function

    'Private Function FunSetDgvData(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean

    '    Dim waitDlg As WaitDialog = Nothing
    '    Dim lngCURROW As Long = 0
    '    Try
    '        If dt Is Nothing Then
    '            Return False
    '        End If

    '        '-----選択行記憶
    '        If dgv.RowCount > 0 Then
    '            lngCURROW = dgv.CurrentRow.Index
    '        End If

    '        '-----進行状況ダイアログ
    '        waitDlg = New WaitDialog()
    '        With waitDlg
    '            .Owner = Me
    '            .MainMsg = My.Resources.infoMsgProgressStatus
    '            .ProgressMax = 0  ' 全体の処理件数
    '            .ProgressMin = 0 ' 処理件数の最小値（0件から開始）
    '            .ProgressStep = 1 ' 何件ごとにメーターを進めるか
    '            .ProgressValue = 0 ' 最初の件数
    '            .SubMsg = ""
    '            .ProgressMsg = My.Resources.infoToolTipMsgSearching
    '            '表示
    '            waitDlg.Show()
    '        End With

    '        Me.dgvDATA.DataSource = dt

    '        ' Call DgvDATA_SelectionChanged(Me.dgvDATA, Nothing)
    '        Call FunSetDgvCellFormat(Me.dgvDATA)
    '        If dgv.RowCount > 0 Then
    '            '-----選択行設定
    '            Try
    '                dgv.CurrentCell = dgv.Rows(lngCURROW).Cells(0)
    '            Catch dgvEx As Exception
    '            End Try

    '            Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString) '.PadLeft(5)
    '        Else
    '            Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '        Return False

    '    Finally
    '        '-----開放
    '        If waitDlg IsNot Nothing Then
    '            waitDlg.Close()
    '        End If

    '        '-----一覧可視
    '        dgv.Visible = True
    '    End Try
    'End Function

    'Private Function FunGetZOKUSEI_ConditionString(ByVal dgv As DataGridView) As String
    '    Dim strRET As String = ""
    '    Dim sbSQL As New System.Text.StringBuilder

    '    Dim ar = [Enum].GetValues(GetType(Context.ENM_ZOKUSEI_KB))


    '    For Each row As DataGridViewRow In dgv.Rows
    '        If row.Cells("ZOKUSEI_K_CD").Value <> "" Then
    '            If sbSQL.Length > 0 Then
    '                sbSQL.Append(" OR ")
    '            End If
    '            sbSQL.Append(String.Format("(ZOKUSEI_CD={0} AND ZOKUSEI_K_CD={1})",
    '                            row.Cells("ZOKUSEI_CD").Value,
    '                            row.Cells("ZOKUSEI_K_CD").Value.ToString.Split(",")(1)))
    '        End If
    '    Next row

    '    If sbSQL.Length > 0 Then
    '        strRET = " AND (" & sbSQL.ToString & ")"
    '    End If
    '    Return strRET
    'End Function

    'Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean
    '    Try
    '        Dim strFieldList As New List(Of String)
    '        strFieldList.AddRange(New String() {"DEL_FLG"})

    '        For i As Integer = 0 To dgv.Rows.Count - 1
    '            With dgv.Rows(i)
    '                For Each field As String In strFieldList

    '                    If Me.dgvDATA.Rows(i).Cells("DEL_FLG").Value = True Then
    '                        Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
    '                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
    '                        Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
    '                    Else
    '                    End If
    '                Next
    '            End With
    '        Next i
    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '    End Try
    'End Function

#Region "追加・変更"
    ''' <summary>
    ''' レコード追加変更処理
    ''' </summary>
    ''' <param name="intMODE">処理モード</param>
    ''' <returns></returns>
    'Private Function FunUpdateEntity(ByVal intMODE As ENM_DATA_OPERATION_MODE) As Boolean

    '    Dim dlgRET As DialogResult
    '    Dim PKeys As Integer
    '    Try
    '        Using frmDLG As New FrmM1011
    '            frmDLG.PrMODE = intMODE
    '            If Me.dgvDATA.CurrentRow IsNot Nothing Then
    '                frmDLG.PrDataRow = dgvDATA.GetDataRow
    '            Else
    '                frmDLG.PrDataRow = Nothing
    '            End If
    '            dlgRET = frmDLG.ShowDialog(Me)
    '            PKeys = frmDLG.PrPKeys
    '        End Using

    '        If dlgRET = Windows.Forms.DialogResult.Cancel Then
    '            Return False
    '        Else

    '            '追加したコードの行を選択する
    '            For i As Integer = 0 To Me.dgvDATA.RowCount - 1
    '                With Me.dgvDATA.Rows(i)
    '                    If .Cells(0).Value = PKeys Then
    '                        Me.dgvDATA.CurrentCell = .Cells(0)
    '                        Exit For
    '                    End If
    '                End With
    '            Next i

    '        End If

    '        Return True
    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '        Return False
    '    End Try
    'End Function
#End Region

#End Region

#Region "削除"
    Private Function FunDEL(ByVal ENM_MODE As ENM_DATA_OPERATION_MODE) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strMsg As String
        Dim strTitle As String
        Try
            sbSQL.Remove(0, sbSQL.Length)
            Select Case ENM_MODE
                Case ENM_DATA_OPERATION_MODE._4_DISABLE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.VWM101_TORIHIKI) & " SET ")
                    '変更日時
                    sbSQL.Append(" UPD_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = dbo.GetSysDateString() ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationDisable
                    strTitle = My.Resources.infoTitleDeleteOperationDisable

                Case ENM_DATA_OPERATION_MODE._5_RESTORE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.VWM101_TORIHIKI) & " SET ")
                    '変更日時
                    sbSQL.Append(" UPD_YMDHNS = dbo.GetSysDateString() ")
                    '削除日時
                    sbSQL.Append(" ,DEL_YMDHNS = ' ' ")
                    '更新社員ID
                    sbSQL.Append(" ,DEL_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & "")

                    strMsg = My.Resources.infoMsgDeleteOperationRestore
                    strTitle = My.Resources.infoTitleDeleteOperationRestore

                Case ENM_DATA_OPERATION_MODE._6_DELETE

                    sbSQL.Append("DELETE FROM " & NameOf(MODEL.VWM101_TORIHIKI) & " ")

                    strMsg = My.Resources.infoMsgDeleteOperationDelete
                    strTitle = My.Resources.infoTitleDeleteOperationDelete

                Case Else
                    'UNDONE: argument null exception
                    Return False
            End Select
            sbSQL.Append(" WHERE")
            sbSQL.Append(" TORI_ID = '" & Me.flxDATA.Rows(Me.flxDATA.RowSel).Item("TORI_ID") & "' ")

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
                    '-----トランザクション開始
                    DB.BeginTransaction()

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        'エラーログ
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
            Throw
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
    'Public Function FunInitFuncButtonEnabled(ByVal frm As FrmM1010) As Boolean

    '    Try
    '        For intFunc As Integer = 1 To 12
    '            With frm.Controls("cmdFunc" & intFunc)
    '                If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim.IsNullOrWhiteSpace = True Then
    '                    .Text = ""
    '                    .Visible = False
    '                End If
    '            End With
    '        Next intFunc

    '        If frm.dgvDATA.RowCount > 0 Then
    '            frm.cmdFunc1.Enabled = True
    '            frm.cmdFunc2.Enabled = True
    '            frm.cmdFunc3.Enabled = True
    '            frm.cmdFunc4.Enabled = True
    '            frm.cmdFunc5.Enabled = True
    '            frm.cmdFunc10.Enabled = True
    '        Else
    '            frm.cmdFunc1.Enabled = True
    '            frm.cmdFunc2.Enabled = True
    '            frm.cmdFunc3.Enabled = False
    '            frm.cmdFunc4.Enabled = False
    '            frm.cmdFunc5.Enabled = False
    '            frm.cmdFunc10.Enabled = False
    '        End If

    '        'MyBase.ToolTip.SetToolTip(Me.cmdFunc5, My.Resources.infoToolTipMsgNotFoundData)

    '        Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)

    '        If dgv.SelectedRows.Count > 0 Then
    '            If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
    '                '削除済データの場合
    '                frm.cmdFunc4.Enabled = False
    '                frm.cmdFunc5.Text = "完全削除(F5)"
    '                frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

    '                '復元
    '                frm.cmdFunc6.Text = "復元(F6)"
    '                frm.cmdFunc6.Visible = True
    '                frm.cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
    '            Else
    '                frm.cmdFunc5.Text = "削除(F5)"
    '                frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

    '                frm.cmdFunc6.Text = ""
    '                frm.cmdFunc6.Visible = False
    '                frm.cmdFunc6.Tag = ""

    '            End If
    '        Else
    '            frm.cmdFunc6.Visible = False
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        EM.ErrorSyori(ex, False, conblnNonMsg)
    '        Return False
    '    End Try
    'End Function
#End Region

#Region "コントロールイベント"
    '検索フィルタ変更
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '検索
        Me.cmdFunc1.PerformClick()
    End Sub
    '検索フィルタクリア
    Private Sub BtnClearSrchFilter_Click(sender As Object, e As EventArgs) Handles btnClearSrchFilter.Click

        mtxTORI_NAME.Clear()
        chkDeletedRowVisibled.Checked = False
        Me.cmdFunc1.PerformClick()
    End Sub

#End Region

End Class
