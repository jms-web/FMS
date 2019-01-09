Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0051

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

            ''-----グリッド列作成
            'Call FunSetDgvCulumns(Me.dgvDATA)

            '-----コントロールデータソース設定
            cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, True)
            cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, True)
            cmbBumon.SetDataSource(tblBUMON.ExcludeDeleted, True)

            '-----イベントハンドラ設定
            'AddHandler cmbSYOKUBAN.SelectedValueChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged
            AddHandler Me.chkTaisyokuRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

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

                Case 3  '参照追加

                Case 4  '変更

                Case 5, 6  '削除/復元/完全削除

                Case 10  'CSV出力
                    Dim strFileName As String = lblTytle.Text & "_" & DateTime.Today.ToString("yyyyMMdd") & ".CSV"

                    Dim dtWork As DataTable = DirectCast(flxDATA.DataSource, DataTable).Copy
                    'dtWork.Columns.Remove(NameOf(MODEL.M004_SYAIN.PASS))
                    Call FunCSV_OUT(dtWork, strFileName, pub_APP_INFO.strOUTPUT_PATH)

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
            Call SubInitFuncButtonEnabled()

            '[アクティブ]
            Me.PrPG_STATUS = ENM_PG_STATUS._2_ACTIVE
        End Try

    End Sub

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


    Private Function FunGetListData() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder

        Try

            '----WHERE句作成
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)

            sbSQLWHERE.Append(" WHERE 0 = 0 ")

            '---職番
            If Not (Me.mtxSYAIN_NO.Text.IsNulOrWS) Then
                sbSQLWHERE.Append(" AND SYAIN_NO = " & Me.mtxSYAIN_NO.Text.Trim & " ")
            End If

            '---担当者名検索
            If Not (Me.mtxSIMEI.Text.IsNulOrWS) Then
                sbSQLWHERE.Append(" AND SIMEI LIKE '%" & Me.mtxSIMEI.Text.Trim & "%'")
            End If

            '---担当者名カナ検索
            If Not (Me.mtxSIMEI_KANA.Text.IsNulOrWS) Then
                sbSQLWHERE.Append(" AND SIMEI_KANA LIKE '%" & Me.mtxSIMEI_KANA.Text.Trim & "%'")
            End If

            '---役職区分
            If Me.cmbYAKUSYOKU_KB.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND YAKUSYOKU_KB = '" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
            End If

            '---社員区分
            If Me.cmbSYAIN_KB.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND SYAIN_KB LIKE '%" & Me.cmbSYAIN_KB.SelectedValue & "%'")
            End If

            '---退職者
            If Me.chkTaisyokuRowVisibled.Checked = False Then
                'sbSQLWHERE.Append(" AND TAISYA_YMD = ' ' ")
                sbSQLWHERE.Append(" AND (TAISYA_YMD >= '" & DateTime.Now.ToString("yyyyMMdd") & "' OR TAISYA_YMD = '')")
            End If

            '---部門区分
            If Me.cmbBumon.SelectedIndex <> 0 Then
                sbSQLWHERE.Append(" AND BUMON_KB = '" & Me.cmbBumon.SelectedValue & "'")
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
            sbSQL.Append(" FROM " & NameOf(MODEL.V010_SYAIN_SYOZOKU_BUSYO) & " ")
            sbSQL.Append(sbSQLWHERE)
            sbSQL.Append(" ORDER BY SIMEI_KANA ")

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

            Dim t As Type = GetType(MODEL.V010_SYAIN_SYOZOKU_BUSYO)
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

        'If flxDATA.Rows.Count > 0 Then
        '    cmdFunc3.Enabled = True
        '    cmdFunc4.Enabled = True
        '    cmdFunc5.Enabled = True
        '    cmdFunc10.Enabled = True
        'Else
        '    cmdFunc3.Enabled = False
        '    cmdFunc4.Enabled = False
        '    cmdFunc5.Enabled = False
        '    cmdFunc10.Enabled = False
        'End If

        'If flxDATA.RowSel > 0 Then
        '    If flxDATA(flxDATA.RowSel, "DEL_FLG") = True Then
        '        '削除済データの場合
        '        cmdFunc4.Enabled = False
        '        cmdFunc5.Text = "完全削除(F5)"
        '        cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

        '        '復元
        '        cmdFunc6.Text = "復元(F6)"
        '        cmdFunc6.Visible = True
        '        cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
        '    Else
        '        cmdFunc5.Text = "削除(F5)"
        '        cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

        '        cmdFunc6.Text = ""
        '        cmdFunc6.Visible = False
        '        cmdFunc6.Tag = ""
        '    End If
        'Else
        '    cmdFunc6.Visible = False
        'End If
        'If Not HasAdminAuth(pub_SYAIN_INFO.SYAIN_ID) Then
        '    cmdFunc2.Enabled = False
        '    cmdFunc3.Enabled = False
        '    cmdFunc4.Enabled = False
        '    cmdFunc5.Enabled = False
        '    cmdFunc6.Enabled = False
        '    MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "管理者権限が必要です")
        '    MyBase.ToolTip.SetToolTip(Me.cmdFunc3, "管理者権限が必要です")
        '    MyBase.ToolTip.SetToolTip(Me.cmdFunc4, "管理者権限が必要です")
        '    MyBase.ToolTip.SetToolTip(Me.cmdFunc5, "管理者権限が必要です")
        '    MyBase.ToolTip.SetToolTip(Me.cmdFunc6, "管理者権限が必要です")
        'End If
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
