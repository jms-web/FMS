Imports JMS_COMMON.ClsPubMethod


''' <summary>
''' 差し戻し前後での変更項目の比較
''' </summary>
Public Class FrmG0018

#Region "プロパティ"
    ''' <summary>
    ''' 一覧の選択行データ
    ''' </summary>
    Public Property PrDataRow As DataRow

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

    End Sub

#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = "変更内容比較"
            Me.Text = lblTytle.Text

            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(Me.dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(Me.dgvDATA)

            Call FunInitFuncButtonEnabled()


            'ヘッダ項目セット
            mtxCurrentStageName.Text = PrDataRow.Item("SYONIN_NAIYO")
            mtxSYOCHI.Text = PrDataRow.Item("SOUSA_NAME")
            mtxADD_SYAIN_NAME.Text = PrDataRow.Item("SYAIN_NAME")

            '検索実行
            Call FunSRCH(dgvDATA, FunGetListData)
        Finally

        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Try
            With dgv
                .AutoGenerateColumns = False
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                ''表示列の幅を取得する
                'Dim allWidth As Integer = .Columns.GetColumnsWidth(DataGridViewElementStates.Visible)

                'If allWidth <= .Width - SystemInformation.VerticalScrollBarWidth Then
                '    '表示されているすべての列幅がデータグリッドビュー幅より狭い場合、最後の列幅を広げる
                '    .Columns.GetLastColumn(DataGridViewElementStates.Visible, Nothing).Width = .Width - (allWidth - .Columns.GetLastColumn(DataGridViewElementStates.Visible, Nothing).Width + SystemInformation.VerticalScrollBarWidth)
                'End If

                .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))

                .Columns.Add("KOMOKU_NAME", "変更項目名")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("ATO_NAIYO", "変更前内容")
                .Columns(.ColumnCount - 1).Width = 535
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Add("MAE_NAIYO", "変更後内容")
                .Columns(.ColumnCount - 1).Width = 535
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c
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
                'Me.cmdFunc4.PerformClick()
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs)
        Try
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

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM TV01_HENKO_HIKAKU(")
            sbSQL.Append("'" & PrDataRow.Item("SASIMODOSI_YMDHNS") & "'")
            sbSQL.Append("," & PrDataRow.Item("SYONIN_HOKOKUSYO_ID") & "")
            sbSQL.Append(",'" & PrDataRow.Item("HOKOKU_NO") & "'")
            sbSQL.Append(")")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            If dsList.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("差戻し後変更されていません。", "変更データなし", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            dt.Columns.Add("KOMOKU_NAME", GetType(String))
            dt.Columns.Add("MAE_NAIYO", GetType(String))
            dt.Columns.Add("ATO_NAIYO", GetType(String))

            '主キー設定
            dt.PrimaryKey = {dt.Columns("KOMOKU_NAME")}

            With dsList.Tables(0)
                For intCNT = 0 To .Rows.Count - 1
                    Dim Trow As DataRow = dt.NewRow()
                    '
                    Trow("KOMOKU_NAME") = .Rows(intCNT).Item("KOMOKU_NAME")
                    Trow("MAE_NAIYO") = .Rows(intCNT).Item("MAE_NAIYO")
                    Trow("ATO_NAIYO") = .Rows(intCNT).Item("ATO_NAIYO")
                    dt.Rows.Add(Trow)
                Next intCNT
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

            Dim tgtList As New List(Of String) From {"要求内容", "観察結果", "是正処置無理由", "廃却方法内容",
                                       "返却実施備考", "処置d処置記録", "処置e処置記録", "", "",
                                       "不適合発生状況（誰が、いつ、何をしていて、どうなったか）",
                                       "不適合要因（関係する要因（人、設備・治工具、材料、方法、など）の調査）",
                                       "根本原因（不適合の発生に至った根本原因をなぜなぜ分析により究明）"}

            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    'If CBool(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_FLG)).Value) = True Then
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    'End If
                    If tgtList.Contains(dgvDATA.Rows(i).Cells("KOMOKU_NAME").Value) Then
                        dgvDATA.Rows(i).Height = 70
                        'dgvDATA.Rows(i).Cells(0).Style.Alignment = DataGridViewContentAlignment.TopCenter
                        dgvDATA.Rows(i).Cells(1).Style.Alignment = DataGridViewContentAlignment.TopLeft
                        dgvDATA.Rows(i).Cells(2).Style.Alignment = DataGridViewContentAlignment.TopLeft
                    End If
                End With
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Function

#End Region

#Region "FuncButton有効無効切替"


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

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "コントロールイベント"

#End Region



End Class