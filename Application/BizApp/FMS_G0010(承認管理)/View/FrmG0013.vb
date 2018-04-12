Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0013

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

#Region "プロパティ"

    ''' <summary>
    ''' 要因
    ''' </summary>
    Public Property PrYOIN As (Value As String, Name As String)

    ''' <summary>
    ''' 選択した原因の値リスト
    ''' </summary>
    ''' <returns></returns>
    Public Property PrSelectedList As List(Of (ITEM_NAME As String, ITEM_VALUE As String))

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = "原因分析区分の選択(" & PrYOIN.Name & ")"
            Me.Text = lblTytle.Text
            Me.Width = 1024
            Me.Height = 570

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(Me.dgvDATA)
            Call FunInitializeDataGridView(Me.dgvDetail)

            '-----グリッド列作成
            Call FunSetDgvCulumns(Me.dgvDATA)
            Call FunSetDgvCulumns(Me.dgvDetail)

            '-----コントロールデータソース設定

            '検索実行
            Me.cmdFunc1.PerformClick()
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Try
            With dgv
                Select Case dgv.Name
                    Case "dgvDATA"
                        .AutoGenerateColumns = False
                        .ReadOnly = False

                        .RowsDefaultCellStyle.BackColor = Color.White
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                        .Columns.Add("ITEM_VALUE", "ITEM_VALUE")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_DISP", "項目名")
                        .Columns(.ColumnCount - 1).Width = 280
                        .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).ReadOnly = True

                        Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                        .Name = "SELECT_COUNT",
                        .HeaderText = "選択件数",
                        .DataPropertyName = .Name
                        }
                        cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                        .Columns.Add(cmbclmn1)
                        .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                        .Columns(.ColumnCount - 1).Width = 30

                    Case "dgvDetail"
                        .AutoGenerateColumns = False
                        .ReadOnly = False

                        .RowsDefaultCellStyle.BackColor = Color.White
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.White

                        Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                        .Name = "SELECTED",
                        .HeaderText = "選択",
                        .DataPropertyName = .Name
                        }
                        cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                        .Columns.Add(cmbclmn1)
                        .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                        .Columns(.ColumnCount - 1).Width = 30

                        .Columns.Add("ITEM_NAME", "ITEM_NAME")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_VALUE", "ITEM_VALUE")
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).Visible = False

                        .Columns.Add("ITEM_DISP", "項目名")
                        .Columns(.ColumnCount - 1).Width = 280
                        .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                        .Columns(.ColumnCount - 1).ReadOnly = True
                End Select
            End With

            Return True
        Finally

        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As DataGridViewCellEventArgs)

    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
        Try
            If dgvDATA.CurrentRow IsNot Nothing Then
                Call FunSRCH(dgvDetail, FunGetDgvDetail(dgvDATA.CurrentRow.Cells("ITEM_VALUE").Value))
            End If
        Finally
            'Call FunInitFuncButtonEnabled(Me)
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
                Case 1  '
                    Call FunSRCH(dgvDATA, FunGetListData())
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

    'メイン(分析区分)グリッドのデータソー取得
    Private Function FunGetListData() As DataTable
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & " ")
            sbSQL.Append(" WHERE ITEM_NAME='原因分析区分'")
            sbSQL.Append(" ORDER BY DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            'If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            '    If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            '        Return Nothing
            '    End If
            'End If

            '------DataTableに変換
            Dim dt As New DataTable
            dt.Columns.Add("ITEM_NAME", GetType(String))
            dt.Columns.Add("ITEM_VALUE", GetType(String))
            dt.Columns.Add("ITEM_DISP", GetType(String))
            dt.Columns.Add("SELECT_COUNT", GetType(Integer))
            dt.PrimaryKey = {dt.Columns("ITEM_NAME"), dt.Columns("ITEM_VALUE")}

            With dsList.Tables(0)
                For Each row As DataRow In .Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("ITEM_NAME") = row.Item("ITEM_NAME")
                    Trow("ITEM_VALUE") = row.Item("ITEM_VALUE")
                    Trow("ITEM_DISP") = row.Item("ITEM_DISP")
                    Trow("SELECT_COUNT") = 0
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

            'Call FunSetDgvCellFormat(dgv)

            If dgv.RowCount > 0 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(intCURROW).Cells(0)
                Catch dgvEx As Exception
                End Try
                Me.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString)
            Else
                Me.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            '-----一覧可視
            dgv.Visible = True
        End Try
    End Function

    Private Function FunSetDgvCellFormat(ByVal dgv As DataGridView) As Boolean

        Try
            'Dim _Model As New MODEL.M001_SETTING
            'For i As Integer = 0 To dgv.Rows.Count - 1
            '    With dgv.Rows(i)
            '        'If CBool(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_FLG)).Value) = True Then
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
            '        '    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
            '        'End If
            '    End With
            'Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

    '詳細グリッドのデータソース取得
    Private Function FunGetDgvDetail(ByVal strValue As String) As DataTable
        Try

            Dim strItemName As String
            Select Case strValue
                Case ENM_GENIN_BUNSEKI_KB._0_m_マネジメント
                    strItemName = "m-マネジメント"
                Case ENM_GENIN_BUNSEKI_KB._1_S_ソフトウェア
                    strItemName = "S-ソフトウェア"
                Case ENM_GENIN_BUNSEKI_KB._2_h_ハードウェア
                    strItemName = "h-ハードウェア"
                Case ENM_GENIN_BUNSEKI_KB._3_e_作業環境
                    strItemName = "e-作業環境"
                Case ENM_GENIN_BUNSEKI_KB._4_L1_本人
                    strItemName = "L1-本人"
                Case ENM_GENIN_BUNSEKI_KB._5_L2_関係者_支援体制
                    strItemName = "L2-関係者・支援体制"
                Case Else
                    strItemName = ""
                    'err
            End Select

            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & " ")
            sbSQL.Append(" WHERE ITEM_NAME='" & strItemName & "'")
            sbSQL.Append(" ORDER BY DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            'If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            '    If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            '        Return Nothing
            '    End If
            'End If

            '------DataTableに変換
            Dim dt As New DataTable

            Dim t As Type = GetType(MODEL.M001_SETTING)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.NonPublic Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            For Each p As Reflection.PropertyInfo In properties
                dt.Columns.Add(p.Name, p.PropertyType)
            Next p

            dt.Columns.Add("SELECTED", GetType(Boolean))

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
                                Trow(p.Name) = row.Item(p.Name)
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

            'Dim dgv As DataGridView = DirectCast(Controls("dgvDATA"), DataGridView)

            'If dgv.RowCount > 0 Then
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

            'If dgv.SelectedRows.Count > 0 Then
            '    If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
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