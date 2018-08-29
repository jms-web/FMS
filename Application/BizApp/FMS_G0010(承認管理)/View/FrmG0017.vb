Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 処置履歴
''' </summary>
Public Class FrmG0017

#Region "定数・変数"
    '入力必須コントロール検証判定
    Private pri_blnValidated As Boolean

    Private _V002_NCR_J As New MODEL.V002_NCR_J
#End Region

#Region "プロパティ"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKU_NO As String

    Public Property PrCurrentStage As Integer
#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>コンストラクタ</remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        MyBase.ToolTip.SetToolTip(cmdFunc1, "差戻し以外の処置の変更内容の比較はできません")
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
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using


            '-----グリッド初期設定(親フォームから呼び出し)
            Call FunInitializeDataGridView(Me.dgvDATA)

            '-----グリッド列作成
            Call FunSetDgvCulumns(Me.dgvDATA)

            Call FunSetModel()

            '検索実行
            Call FunSRCH(Me.dgvDATA, FunGetListData())
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Owner.Visible = False
    End Sub
#End Region

#Region "DataGridView関連"

    'フィールド定義()
    Private Shared Function FunSetDgvCulumns(ByVal dgv As DataGridView) As Boolean

        Try
            With dgv
                .AutoGenerateColumns = False
                .Font = New Font("Meiryo UI", 9, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))
                .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte))

                .Columns.Add("ADD_YMDHNS", "処理日時")
                .Columns(.ColumnCount - 1).Width = 140
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).ValueType = GetType(DateTime)
                .Columns(.ColumnCount - 1).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm"

                .Columns.Add("SYONIN_JUN", "承認順")
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("SYONIN_NAIYO", "ステージ")
                .Columns(.ColumnCount - 1).Width = 220
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("SOUSA_NAME", "処置")
                .Columns(.ColumnCount - 1).Width = 120
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("SYAIN_NAME", "処置担当者")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                .Columns.Add("MODOSI_SAKI_SYAIN_NAME", "差戻先・転送先")
                .Columns(.ColumnCount - 1).Width = 150
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name
                .Columns(.ColumnCount - 1).Visible = False

                .Columns.Add("RIYU", "内容・理由")
                .Columns(.ColumnCount - 1).Width = 300
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

                Dim linkColumn As New DataGridViewLinkColumn
                linkColumn.Name = "CHANGE"
                linkColumn.HeaderText = " "
                linkColumn.LinkBehavior = LinkBehavior.HoverUnderline
                linkColumn.TrackVisitedState = False
                .Columns.Add(linkColumn)
                .Columns(.ColumnCount - 1).Width = 80
                .Columns(.ColumnCount - 1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                .Columns(.ColumnCount - 1).DataPropertyName = .Columns(.ColumnCount - 1).Name

            End With

            Return True
        Finally

        End Try
    End Function

    Private Sub DgvDATA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDATA.CellContentClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If dgv.Columns(e.ColumnIndex).Name = "CHANGE" And dgv(e.ColumnIndex, e.RowIndex).Value = "変更あり" Then
            Call FunOpenCompare()
        End If
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
            '[処理中]
            Me.PrPG_STATUS = ENM_PG_STATUS._3_PROCESSING

            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '変更内容比較
                    Call FunOpenCompare()

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
            'Call FunInitFuncButtonEnabled(Me)

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

            'SPEC: 20-7.①
            sbSQL.Append("SELECT")
            sbSQL.Append(" *")
            sbSQL.Append(" FROM " & NameOf(MODEL.V004_HOKOKU_SOUSA) & "")
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & PrSYONIN_HOKOKUSYO_ID & "")
            sbSQL.Append(" AND HOKOKU_NO='" & PrHOKOKU_NO & "'")
            sbSQL.Append(" ORDER BY SASIMODOSI_YMDHNS")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            If dsList.Tables(0).Rows.Count > pub_APP_INFO.intSEARCHMAX Then
                If MessageBox.Show(My.Resources.infoSearchCountOver, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Return Nothing
                End If
            End If

            '------DataTableに変換
            Dim dt As New DataTable

            dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
            dt.Columns.Add("HOKOKU_NO", GetType(String))
            dt.Columns.Add("ADD_YMDHNS", GetType(DateTime))
            dt.Columns.Add("SYONIN_JUN", GetType(Integer))
            dt.Columns.Add("SYONIN_NAIYO", GetType(String))
            dt.Columns.Add("SOUSA_KB", GetType(String))
            dt.Columns.Add("SOUSA_NAME", GetType(String))
            dt.Columns.Add("SYAIN_ID", GetType(Integer))
            dt.Columns.Add("SYAIN_NAME", GetType(String))
            dt.Columns.Add("SYONIN_HANTEI_KB", GetType(String))
            dt.Columns.Add("SYONIN_HANTEI_NAME", GetType(String))
            dt.Columns.Add("RIYU", GetType(String))
            dt.Columns.Add("SASIMODOSI_YMDHNS", GetType(String))
            dt.Columns.Add("CHANGE", GetType(String))
            dt.Columns.Add("HENKOU_KENSU", GetType(Integer))
            dt.Columns.Add("MODOSI_SAKI_SYAIN_NAME", GetType(String))

            '主キー設定
            dt.PrimaryKey = {dt.Columns("SYONIN_HOKOKUSYO_ID"), dt.Columns("HOKOKU_NO"), dt.Columns("ADD_YMDHNS")}

            With dsList.Tables(0)
                For intCNT = 0 To .Rows.Count - 1
                    Dim Trow As DataRow = dt.NewRow()
                    '
                    Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    Trow("HOKOKU_NO") = .Rows(intCNT).Item("HOKOKU_NO")
                    Trow("ADD_YMDHNS") = DateTime.ParseExact(.Rows(intCNT).Item("ADD_YMDHNS"), "yyyyMMddHHmmss", Nothing)
                    Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                    Trow("SOUSA_KB") = .Rows(intCNT).Item("SOUSA_KB")
                    Trow("SOUSA_NAME") = .Rows(intCNT).Item("SOUSA_NAME")
                    Trow("SYAIN_ID") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("SYONIN_NAIYO") = .Rows(intCNT).Item("SYONIN_NAIYO") '.Rows(intCNT).Item("SYONIN_JUN") & "." & .Rows(intCNT).Item("SYONIN_NAIYO")
                    Trow("SYAIN_NAME") = .Rows(intCNT).Item("SYAIN_NAME")
                    Trow("SYONIN_HANTEI_KB") = .Rows(intCNT).Item("SYONIN_HANTEI_KB")
                    Trow("SYONIN_HANTEI_NAME") = .Rows(intCNT).Item("SYONIN_HANTEI_NAME")
                    Trow("RIYU") = .Rows(intCNT).Item("RIYU")
                    Trow("SASIMODOSI_YMDHNS") = .Rows(intCNT).Item("SASIMODOSI_YMDHNS")

                    Select Case .Rows(intCNT).Item("SOUSA_KB")
                        Case ENM_SOUSA_KB._3_承認差戻
                            Trow("MODOSI_SAKI_SYAIN_NAME") = "⇒" & .Rows(intCNT).Item("MODOSI_SAKI_SYAIN_NAME")
                        Case ENM_SOUSA_KB._5_転送
                            Trow("MODOSI_SAKI_SYAIN_NAME") = "⇒" & .Rows(intCNT).Item("MODOSI_SAKI_SYAIN_NAME")
                        Case Else
                            'Err
                    End Select

                    If .Rows(intCNT).Item("HENKOU_KENSU") > 0 Then 'If .Rows(intCNT).Item("SOUSA_KB") = ENM_SOUSA_KB._3_承認差戻 Then
                        Trow("CHANGE") = "変更あり"
                    Else
                        Trow("CHANGE") = ""
                    End If

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

        Try
            If dt.Rows.Count > 0 Then
                dgv.DataSource = dt
                Call FunSetDgvCellFormat(dgv)
            End If

            If dgv.RowCount > 0 Then
                '-----選択行設定
                Try
                    dgv.CurrentCell = dgv.Rows(intDgvCurrentRow).Cells(0)
                Catch dgvEx As Exception
                End Try
                lblRecordCount.Text = String.Format(My.Resources.infoToolTipMsgFoundData, dgv.RowCount.ToString)
            Else
                lblRecordCount.Text = My.Resources.infoSearchResultNotFound
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

#Region "追加・変更"

    ''' <summary>
    ''' 変更内容比較画面を開く
    ''' </summary>
    ''' <returns></returns>
    Private Function FunOpenCompare() As Boolean
        Dim frmDLG As New FrmG0018
        Dim dlgRET As DialogResult

        Try

            If dgvDATA.CurrentRow IsNot Nothing Then
                frmDLG.PrDataRow = Me.dgvDATA.GetDataRow()
            Else
                frmDLG.PrDataRow = Nothing
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

#Region "ローカル関数"
    Private Function FunSetModel() As Boolean

        _V002_NCR_J = FunGetV002Model(PrHOKOKU_NO)
        Select Case PrSYONIN_HOKOKUSYO_ID
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                mtxSYONIN_HOKOKUSYO_NAME.Text = "不適合製品処置報告書(Non-Conformance Report)"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                mtxSYONIN_HOKOKUSYO_NAME.Text = "不適合是正処置報告書(Corrective Action Report)"
        End Select

        mtxHOKUKO_NO.Text = _V002_NCR_J.HOKOKU_NO
        mtxBUMON_KB.Text = _V002_NCR_J.BUMON_NAME
        mtxKISOU_TANTO.Text = _V002_NCR_J.ADD_SYAIN_NAME
        dtDraft.ValueNonFormat = _V002_NCR_J.ADD_YMD
        mtxKISYU.Text = _V002_NCR_J.KISYU_NAME
        mtxBUHIN_BANGO.Text = _V002_NCR_J.BUHIN_BANGO
        mtxHINMEI.Text = _V002_NCR_J.BUHIN_NAME
        mtxGOUKI.Text = _V002_NCR_J.GOKI
        If _V002_NCR_J.BUMON_KB = Context.ENM_BUMON_KB._2_LP Then
            lblSYANAI_CD.Visible = True
            mtxSYANAI_CD.Visible = True
            mtxSYANAI_CD.Text = _V002_NCR_J.SYANAI_CD
        Else
            lblSYANAI_CD.Visible = False
            mtxSYANAI_CD.Visible = False
        End If
        numSU.Value = _V002_NCR_J.SURYO
        If _V002_NCR_J.FUTEKIGO_JYOTAI_KB = ENM_FUTEKIGO_JYOTAI_KB._3_返却品 Then
            mtxHENKYAKU_RIYU.Visible = True
            mtxHENKYAKU_RIYU.Text = _V002_NCR_J.FUTEKIGO_NAIYO
        Else
            mtxHENKYAKU_RIYU.Visible = False
        End If
        mtxFUTEKIGO_JYOTAI.Text = _V002_NCR_J.FUTEKIGO_JYOTAI_NAME
        mtxFUTEKIGO_KB.Text = _V002_NCR_J.FUTEKIGO_NAME
        mtxFUTEKIGO_S_KB.Text = _V002_NCR_J.FUTEKIGO_S_NAME
        mtxZUBAN_KIKAKU.Text = _V002_NCR_J.ZUMEN_KIKAKU
        chkSAIHATU.Checked = _V002_NCR_J.SAIHATU
        Return True
    End Function


#End Region

End Class