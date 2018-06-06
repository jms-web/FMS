Imports JMS_COMMON.ClsPubMethod


Public Class FrmG0014

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
        Me.ShowIcon = True
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
    Public Property PrSelectedList As List(Of (ITEM_NAME As String, ITEM_VALUE As String, ITEM_DISP As String))
#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            lblTytle.Text = "原因分析区分の選択(" & PrYOIN.Name & ")"
            Me.Text = lblTytle.Text
            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(Me.dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(Me.dgvDATA)

            '-----コントロールデータソース設定
            mtxYOIN_NAME.Text = PrYOIN.Name

            '検索実行
            Call FunSRCH(dgvDATA, FunGetListData())
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Try
            With dgv
                .AutoGenerateColumns = False
                .ReadOnly = False
                '.RowsDefaultCellStyle.BackColor = Color.White
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.White

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
            End With

            Return True
        Finally

        End Try
    End Function

    'グリッドセル(行)クリック時イベント
    Private Sub DgvDATA_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellContentClick
        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If e.RowIndex >= 0 Then
                Select Case dgv.Columns(e.ColumnIndex).Name
                    Case "SELECTED"
                        dgv.CurrentRow.Cells("SELECTED").Value = Not CBool(dgv.CurrentRow.Cells("SELECTED").Value)
                        If CBool(dgv.CurrentRow.Cells("SELECTED").Value) Then
                            PrSelectedList.Add((dgv.CurrentRow.Cells("ITEM_NAME").Value, dgv.CurrentRow.Cells("ITEM_VALUE").Value, dgv.CurrentRow.Cells("ITEM_DISP").Value))
                        Else
                            PrSelectedList.Remove((dgv.CurrentRow.Cells("ITEM_NAME").Value, dgv.CurrentRow.Cells("ITEM_VALUE").Value, dgv.CurrentRow.Cells("ITEM_DISP").Value))
                        End If
                End Select
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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
                Case 1  'OK
                    Me.DialogResult = DialogResult.OK
                Case 12 '閉じる
                    Me.DialogResult = DialogResult.Cancel
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
            sbSQL.Append(" FROM " & NameOf(MODEL.VWM001_SETTING) & " ")
            sbSQL.Append(" WHERE ITEM_NAME='材料原因区分'")
            sbSQL.Append(" ORDER BY DISP_ORDER ")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            '------DataTableに変換
            Dim dt As New DataTable
            dt.Columns.Add("ITEM_NAME", GetType(String))
            dt.Columns.Add("ITEM_VALUE", GetType(String))
            dt.Columns.Add("ITEM_DISP", GetType(String))
            dt.Columns.Add("DEL_FLG", GetType(Boolean))
            dt.Columns.Add("DEF_FLG", GetType(Boolean))
            dt.Columns.Add("DISP_ORDER", GetType(Integer))
            dt.Columns.Add("SELECTED", GetType(Boolean))

            '主キー設定
            dt.PrimaryKey = {dt.Columns("ITEM_NAME"), dt.Columns("ITEM_VALUE")}

            If dsList IsNot Nothing Then
                For intCNT = 0 To dsList.Tables(0).Rows.Count - 1
                    With dsList.Tables(0).Rows(intCNT)
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("ITEM_NAME") = .Item("ITEM_NAME")
                        Trow("ITEM_DISP") = .Item("ITEM_DISP")
                        Trow("ITEM_VALUE") = .Item("ITEM_VALUE")
                        Trow("DEL_FLG") = CBool(.Item("DEL_FLG"))
                        Trow("DISP_ORDER") = Val(.Item("DISP_ORDER"))
                        Trow("DEF_FLG") = CBool(.Item("DEF_FLG"))
                        If PrSelectedList Is Nothing Then
                            Trow("SELECTED") = False
                        Else
                            Trow("SELECTED") = PrSelectedList.Contains((.Item("ITEM_NAME"), .Item("ITEM_VALUE"), .Item("ITEM_DISP")))
                        End If
                        dt.Rows.Add(Trow)
                    End With
                Next intCNT
            Else
                ' data null exception
                'Throw New ArgumentNullException("", "")
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
            Dim _Model As New MODEL.M001_SETTING
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    'If CBool(Me.dgvDATA.Rows(i).Cells(NameOf(_Model.DEL_FLG)).Value) = True Then
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                    '    Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    'End If
                End With
            Next i
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
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