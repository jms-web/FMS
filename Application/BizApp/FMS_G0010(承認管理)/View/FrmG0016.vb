Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 差戻し画面
''' </summary>
Public Class FrmG0016

#Region "変数・定数"

#End Region

#Region "プロパティ"
    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

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
    End Sub

#End Region

#Region "FORMイベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Me.Text = "差戻し登録"
            Me.lblTytle.Text = Me.Text

            '-----位置・サイズ
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----ダイアログウィンドウ設定
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----各コントロールのデータソースを設定
            Dim tbl As New DataTable
            Using DB As ClsDbUtility = DBOpen()
                Dim strWhere As String
                strWhere = "SYONIN_HOKOKUSYO_ID=" & PrSYONIN_HOKOKUSYO_ID & " AND HOKOKU_NO='" & _D003_NCR_J.HOKOKU_NO & "' AND (SYONIN_JUN=20 AND SYONIN_JUN<" & PrCurrentStage & ")"
                Call FunGetCodeDataTable(DB, "差戻し先", tbl, strWhere)
            End Using
            cmbMODOSI_SAKI.SetDataSource(tbl, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)

            'バインディング
            Call FunSetBinding()
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTIONボタン関連"

#Region "FUNCTIONボタンCLICKイベント"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim blnRET As Boolean

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '
                    blnRET = FunSAVE()

                    If blnRET Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '戻る
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
        End Try
    End Sub

#End Region

#Region "更新"
    Private Function FunSAVE() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----入力チェック
            If FunCheckInput() = False Then
                Return False
            End If

            'SPEC: 20-5.③.レコード更新
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    '-----トランザクション
                    DB.BeginTransaction()

                    '-----UPDATE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " SET")
                    sbSQL.Append(" " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS) & "=' '")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB) & "='" & 0 & "'") '未承認
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG) & "='" & 1 & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU) & "='" & _D004_SYONIN_J_KANRI.RIYU & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG) & "='" & 0 & "'")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID) & "=" & pub_SYAIN_INFO.SYAIN_ID & "")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS) & "=dbo.GetSysDateString()")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "='" & _D003_NCR_J.HOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & "=" & cmbMODOSI_SAKI.SelectedValue & "")
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----差し戻されたステージ以降の承認済み実績を削除
                    sbSQL.Append("DELETE FROM" & NameOf(MODEL.D004_SYONIN_J_KANRI) & "")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & ">" & cmbMODOSI_SAKI.SelectedValue & "")
                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
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
            Throw
            Return False
        Finally

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
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
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

    '差し戻し先
    Private Sub CmbMODOSI_SAKI_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMODOSI_SAKI.SelectedValueChanged

        'SPEC: 20-5.②
        If cmbMODOSI_SAKI.SelectedValue Is Nothing Then
            mtxTANTO_NAME.Text = ""
        Else
            mtxTANTO_NAME.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = cmbMODOSI_SAKI.SelectedValue).First.Item("SYAIN_NAME")
        End If

    End Sub

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMODOSI_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue Is Nothing And cmb.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し先"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
        Else
            ErrorProvider.ClearError(cmb)
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxMODOSI_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し理由"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
        Else
            ErrorProvider.ClearError(mtx)
        End If
    End Sub

#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try

            '差戻し先
            If cmbMODOSI_SAKI.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し先"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbMODOSI_SAKI.Focus()
                Return False
            End If

            '理由
            If Me.mtxMODOSI_RIYU.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "差戻し理由"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxMODOSI_RIYU.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "ローカル関数"
    Private Function FunSetBinding() As Boolean
        'cmbMODOSI_SAKI.DataBindings.Add(New Binding(NameOf(cmbMODOSI_SAKI.SelectedValue), _D003_NCR_J, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)))
        mtxMODOSI_RIYU.DataBindings.Add(New Binding(NameOf(mtxMODOSI_RIYU.Text), _D003_NCR_J, NameOf(_D004_SYONIN_J_KANRI.RIYU)))
    End Function




#End Region


End Class
