Imports JMS_COMMON.ClsPubMethod

Public Class FrmD030

#Region "プロパティ"

    ''' <summary>
    ''' 新規追加レコードのキー
    ''' </summary>
    Public Property PrPKeys As String

#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        'システム設定読み込み
        Call Initialize()

        ''ツールチップメッセージ
        MyBase.ToolTip.SetToolTip(Me.cmdFunc2, "削除済み担当者は選択出来ません")

    End Sub
#End Region

#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム初期設定(親フォームから呼び出し)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Me.ShowStatusBar = False
            Me.lblTytle.Text = "社員検索"
            Me.Text = Me.lblTytle.Text
            Me.Height = Owner.Height - 26
            Me.Top = Owner.Top + (Owner.Height - Me.Height) '- 26
            Me.Left = Owner.Left + (Owner.Width - Me.Width) / 2


            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(dgvDATA)

            '-----ウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----グリッド列作成
            Call FunSetDgvCulumns(dgvDATA)

            '-----イベントハンドラ設定
            AddHandler Me.mtxTANTO_CD.Validated, AddressOf SearchFilterValueChanged
            AddHandler Me.mtxTANTO_NAME.Validated, AddressOf SearchFilterValueChanged
            AddHandler Me.mtxTANTO_NAME_KANA.Validated, AddressOf SearchFilterValueChanged
            AddHandler Me.chkDeletedRowVisibled.CheckedChanged, AddressOf SearchFilterValueChanged

            '検索実行
            Me.cmdFunc1.PerformClick()

        Finally

        End Try
    End Sub

    Shadows Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   ボタン位置、サイズ設定
        ''===================================
        'Call SetButtonSize(Me.Width, cmdFunc)

    End Sub

#End Region

#Region "DataGridView関連"

    'フィールド定義
    Private Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean
        Try

            With dgv
                .AutoGenerateColumns = False

                .Columns.Add("TANTO_CD", "担当者CD")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("SYOKUBAN", "職番")
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("TANTO_NAME", "担当者名")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("TANTO_NAME_KANA", "担当者名カナ")
                .Columns(.ColumnCount - 1).Width = 100
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("CYOKKAN_KB", "直間区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("NYUSYA_YMD", "入社日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("TAISYA_YMD", "退社日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("YAKUSYOKU_KB", "役職区分")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("BU_CD", "部CD")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("KA_CD", "課CD")
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("BIRTHDAY", "生年月日")
                .Columns(.ColumnCount - 1).Width = 90
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("PASSWORD", "パスワード")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("ADD_YMDHNS", "追加日時")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("ADD_TANTO_CD", "追加担当者CD")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("EDIT_YMDHNS", "更新日時")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("EDIT_TANTO_CD", "更新担当者CD")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                Dim cmbclmn1 As New DataGridViewCheckBoxColumn With {
                .Name = "DEL_FLG",
                .HeaderText = "削除済",
                .Width = 30
                }
                cmbclmn1.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns.Add(cmbclmn1)
                .Columns(.ColumnCount - 1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("DEL_YMDHNS", "削除日時")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("DEL_TANTO_CD", "削除担当者CD")
                .Columns(.ColumnCount - 1).Visible = False
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    'グリッドセル(行)ダブルクリック時イベント
    Private Sub DgvDATA_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDATA.CellDoubleClick
        Try
            'ヘッダ以外のセルダブルクリック時
            If e.RowIndex >= 0 Then
                '該当行の選択処理を実行する
                Me.cmdFunc2.PerformClick()
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    '行選択時イベント
    Private Overloads Sub DgvDATA_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvDATA.SelectionChanged
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
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '検索
                    Call FunSetDgvData(Me.dgvDATA, FunSRCH())
                Case 2  '選択
                    'プロパティに対象レコードのキーを設定
                    Me.PrPKeys = dgvDATA.CurrentRow.Cells("TANTO_CD").Value

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Case 12 '閉じる
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
    Private Function FunSRCH() As DataTable
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder


        '----WHERE句作成
        sbSQLWHERE.Remove(0, sbSQLWHERE.Length)
        If Me.mtxTANTO_CD.Text <> "" Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE SYOKUBAN LIKE '%" & Me.mtxTANTO_CD.Text.Trim & "%'")
            End If
        End If
        If Me.mtxTANTO_NAME.Text <> "" Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TANTO_NAME LIKE '%" & Me.mtxTANTO_NAME.Text.Trim & "%'")
            End If
        End If
        If Me.mtxTANTO_NAME_KANA.Text <> "" Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE TANTO_NAME_KANA LIKE '%" & Me.mtxTANTO_NAME_KANA.Text.Trim & "%'")
            End If
        End If

        If Me.chkDeletedRowVisibled.Checked = False Then
            If sbSQLWHERE.Length = 0 Then
                sbSQLWHERE.Append(" WHERE DEL_FLG <> '1' ")
            Else
                sbSQLWHERE.Append(" AND DEL_FLG <> '1' ")
            End If
            dgvDATA.Columns("DEL_FLG").Visible = False
        Else
            dgvDATA.Columns("DEL_FLG").Visible = True
        End If


        'SQL
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT *")
        sbSQL.Append(" FROM " & NameOf(Model.VWM03_TANTO) & " ")
        sbSQL.Append(sbSQLWHERE)
        sbSQL.Append(" ORDER BY SYOKUBAN ")

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
            If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Return Nothing
            End If
        End If

        Dim tplModelInfo As (dt As DataTable, properties As Reflection.PropertyInfo()) = FunGetTableFromModel(GetType(Model.VWM03_TANTO))

        For intCNT As Integer = 0 To dsList.Tables(0).Rows.Count - 1
            Dim Trow As DataRow = tplModelInfo.dt.NewRow()
            For Each p As Reflection.PropertyInfo In tplModelInfo.properties
                Select Case p.Name
                    Case "DEL_FLG"
                        Trow(p.Name) = CBool(dsList.Tables(0).Rows(intCNT).Item(p.Name))
                    Case Else
                        Trow(p.Name) = dsList.Tables(0).Rows(intCNT).Item(p.Name)
                End Select
            Next p
            tplModelInfo.dt.Rows.Add(Trow)
        Next intCNT
        tplModelInfo.dt.AcceptChanges()

        Return tplModelInfo.dt
    End Function

    Private Function FunSetDgvData(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean
        Dim waitDlg As WaitDialog = Nothing
        Try
            If dt Is Nothing Then
                Return False
            End If

            Me.dgvDATA.DataSource = dt

            Call FunSetDgvCellFormat(dgvDATA)

            If dgv.RowCount > 0 Then
                MyBase.lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount)
            Else
                MyBase.lblRecordCount.Text = My.Resources.infoSearchResultNotFound
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
            For i As Integer = 0 To dgv.Rows.Count - 1
                With dgv.Rows(i)
                    If Me.dgvDATA.Rows(i).Cells("DEL_FLG").Value = True Then
                        Me.dgvDATA.Rows(i).DefaultCellStyle.ForeColor = clrDeletedRowForeColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.BackColor = clrDeletedRowBackColor
                        Me.dgvDATA.Rows(i).DefaultCellStyle.SelectionForeColor = clrDeletedRowForeColor
                    End If
                End With
            Next i

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
    Public Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With Me.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            Dim dgv As DataGridView = DirectCast(Me.dgvDATA, DataGridView)
            If dgv.SelectedRows.Count > 0 Then
                If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEL_FLG").Value = True Then
                    Me.cmdFunc2.Enabled = False
                Else
                    Me.cmdFunc2.Enabled = True
                End If
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
