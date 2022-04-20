Imports JMS_COMMON.ClsPubMethod
Imports Microsoft.VisualBasic.ApplicationServices
Imports MODEL

''' <summary>
''' 差戻し画面
''' </summary>
Public Class FrmG0036_Sasimodosi

#Region "変数・定数"

#End Region

#Region "プロパティ"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrCurrentStage As Integer

    Public Property PrHOKOKU_NO As String

    Public Property PrBUHIN_BANGO As String

    Public Property PrKISYU_NAME As String

    Public Property PrKISO_YMD As String

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
        cmbMODOSI_SAKI.NullValue = 0
    End Sub

#End Region

#Region "FORMイベント"

    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----フォーム共通設定
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

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

            cmbMODOSI_SAKI.SetDataSource(FunGetMODISI_SAKI(PrSYONIN_HOKOKUSYO_ID, PrHOKOKU_NO, PrCurrentStage), ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            'バインディング
            Call FunSetBinding()
            _D004_SYONIN_J_KANRI.RIYU = ""
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

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '
                    If FunSAVE() Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '戻る
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
                Dim strSysDate As String = DB.GetSysDateString

                Try
                    '-----トランザクション
                    DB.BeginTransaction()

                    '-----UPDATE
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D004_SYONIN_J_KANRI)} SET")
                    sbSQL.Append($" {NameOf(_D004_SYONIN_J_KANRI.SYONIN_YMDHNS)}=' '")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}='{ENM_SYONIN_HANTEI_KB._0_未承認.Value}'") '
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}='1'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.RIYU)}='{_D004_SYONIN_J_KANRI.RIYU}'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.MAIL_SEND_FG)}='0'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}={mtxTANTO_ID.Text}")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}") '
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}='{strSysDate}'")
                    sbSQL.Append($" WHERE {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={PrSYONIN_HOKOKUSYO_ID}")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}='{PrHOKOKU_NO}'")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}={cmbMODOSI_SAKI.SelectedValue}")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----差し戻されたステージ以降の承認済み実績を削除
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"DELETE FROM {NameOf(MODEL.D004_SYONIN_J_KANRI)}")
                    sbSQL.Append($" WHERE {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={PrSYONIN_HOKOKUSYO_ID}")
                    sbSQL.Append($" AND RTRIM({NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)})='{PrHOKOKU_NO}'")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}>{cmbMODOSI_SAKI.SelectedValue};")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If sqlEx.Source IsNot Nothing Then

                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '-----データモデル更新
                    _R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID = PrSYONIN_HOKOKUSYO_ID
                    _R001_HOKOKU_SOUSA.HOKOKU_NO = PrHOKOKU_NO
                    _R001_HOKOKU_SOUSA.SYONIN_JUN = PrCurrentStage
                    _R001_HOKOKU_SOUSA.SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._3_承認差戻
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ""
                    _R001_HOKOKU_SOUSA.RIYU = mtxMODOSI_RIYU.Text
                    _R001_HOKOKU_SOUSA.ADD_YMDHNS = strSysDate 'Now.ToString("yyyyMMddHHmmss")
                    '-----INSERT R001
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(R001_HOKOKU_SOUSA) & "(")
                    sbSQL.Append("  " & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.HOKOKU_NO))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.ADD_YMDHNS))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SOUSA_KB))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB))
                    sbSQL.Append(" ," & NameOf(_R001_HOKOKU_SOUSA.RIYU))
                    sbSQL.Append(" ) VALUES(")
                    sbSQL.Append("  " & (_R001_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.HOKOKU_NO) & "'")
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYONIN_JUN))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SOUSA_KB) & "'")
                    sbSQL.Append(" ," & (_R001_HOKOKU_SOUSA.SYAIN_ID))
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB) & "'")
                    sbSQL.Append(" ,'" & (_R001_HOKOKU_SOUSA.RIYU) & "'")
                    sbSQL.Append(")")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '差し戻し時履歴
                    'Select Case PrSYONIN_HOKOKUSYO_ID
                    '    Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    '        If FunSAVE_R003(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                    '        Else
                    '            blnErr = True
                    '            Return False
                    '        End If
                    '    Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR

                    '        If FunSAVE_R004(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                    '        Else
                    '            blnErr = True
                    '            Return False
                    '        End If
                    '    Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS

                    '        If FunSAVE_R005(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                    '        Else
                    '            blnErr = True
                    '            Return False
                    '        End If
                    '        If FunSAVE_R006(DB, _R001_HOKOKU_SOUSA.ADD_YMDHNS) Then
                    '        Else
                    '            blnErr = True
                    '            Return False
                    '        End If
                    '    Case Else
                    '        Throw New ArgumentException()
                    'End Select

                    '通知メール送信
                    If blnErr = False Then Call FunSendRequestMail()
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
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
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
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        'SPEC: 20-5.②
        If cmb.IsSelected Then
            mtxTANTO_NAME.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_NAME")
            mtxTANTO_ID.Text = DirectCast(cmbMODOSI_SAKI.DataSource, DataTable).AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = cmb.SelectedValue).First.Item("SYAIN_ID")
        Else
            mtxTANTO_ID.Text = ""
            mtxTANTO_NAME.Text = ""
        End If

    End Sub

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMODOSI_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し先"))
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxMODOSI_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "差戻し理由"))
        End If
    End Sub

#End Region

#Region "入力チェック"

    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            IsCheckRequired = True
            Call CmbMODOSI_SAKI_Validating(cmbMODOSI_SAKI, Nothing)
            Call MtxMODOSI_RIYU_Validating(mtxMODOSI_RIYU, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

#End Region

#Region "ローカル関数"

    Private Function FunSetBinding() As Boolean

        mtxMODOSI_RIYU.DataBindings.Add(New Binding(NameOf(mtxMODOSI_RIYU.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Function

    Private Function FunGetMODISI_SAKI(ByVal intSYONIN_HOKOKU_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intCurrentStage As Integer) As DataTable
        Dim dt As New DataTableEx("System.Int32")
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} MAIN")
        sbSQL.Append($" WHERE {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKU_ID}")
        sbSQL.Append($" AND {NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'")
        sbSQL.Append($" AND ({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=(SELECT MAX({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}) FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} AS SUB WHERE SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}<{intCurrentStage}))")

        'Select Case intCurrentStage
        '    Case 20

        '    Case Else
        '        'カレントステージが20以外の場合は差し戻し先として20も追加
        '        sbSQL.Append($" AND ({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=20")
        '        sbSQL.Append($" OR {NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}=(SELECT MAX({NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)})")
        '        sbSQL.Append($" FROM {NameOf(MODEL.V003_SYONIN_J_KANRI)} AS SUB")
        '        sbSQL.Append($" WHERE SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_JUN)}<{intCurrentStage}")
        '        sbSQL.Append($" AND SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={intSYONIN_HOKOKU_ID}")
        '        sbSQL.Append($" AND SUB.{NameOf(MODEL.V003_SYONIN_J_KANRI.HOKOKU_NO)}='{strHOKOKU_NO}'))")
        'End Select

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_ID", GetType(Integer))
        dt.Columns.Add("SYAIN_NAME", GetType(String))
        dt.Columns.Add("HOKOKU_NO", GetType(String))

        '主キー設定
        dt.PrimaryKey = {dt.Columns("SYONIN_JUN"), dt.Columns("HOKOKU_NO")}

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()

                If .Rows(intCNT).Item("SYONIN_JUN") = ENM_ZESEI_STAGE._10_起草入力 Then
                    Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME")
                    Trow("SYAIN_ID") = .Rows(intCNT).Item("UPD_SYAIN_ID")
                    Trow("SYAIN_NAME") = .Rows(intCNT).Item("UPD_SYAIN_NAME")
                Else
                    Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("UPD_SYAIN_NAME")
                    Trow("SYAIN_ID") = .Rows(intCNT).Item("UPD_SYAIN_ID")
                    Trow("SYAIN_NAME") = .Rows(intCNT).Item("UPD_SYAIN_NAME")
                End If

                Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                Trow("HOKOKU_NO") = .Rows(intCNT).Item("HOKOKU_NO")

                dt.Rows.Add(Trow)
            Next intCNT
        End With

        Return dt
    End Function

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = PrKISYU_NAME 'tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.LazyLoad("承認判定区分").AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HOKOKUSYO_NAME As String

        Select Case PrSYONIN_HOKOKUSYO_ID
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR.Value
                SYONIN_HOKOKUSYO_NAME = "NCR"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR.Value
                SYONIN_HOKOKUSYO_NAME = "CAR"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS.Value
                SYONIN_HOKOKUSYO_NAME = "CTS"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._4_FCCB.Value
                SYONIN_HOKOKUSYO_NAME = "FCCB"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._5_ZESEI.Value
                SYONIN_HOKOKUSYO_NAME = "ZESEI"
            Case Context.ENM_SYONIN_HOKOKUSYO_ID._6_ZESEI_R.Value
                SYONIN_HOKOKUSYO_NAME = "ZESEI_R"
        End Select

        Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{Val(ENM_OPEN_MODE._2_処置画面起動)},{PrSYONIN_HOKOKUSYO_ID},{PrHOKOKU_NO}"
        Dim strSubject As String = $"【是正処置依頼】"
        Dim strBody As String = <html><![CDATA[
        {0} 殿<br />
        <br />
        　是正処置要求書の差戻依頼が来ましたので対応をお願いします。<br />
        <br />        　　
        　　【報告書No】{2}<br />
        　　【起 草 日】{3}<br />        　　
        　　【依 頼 者】{6}<br />
        　　【依頼者処置内容】{7}<br />
        　　【コメント】{8}<br />
        <br />
        <a href = "http://sv04:8000/CLICKONCE_FMS.application" >システム起動</a><br />
        <br />
        ※このメールは配信専用です。(返信できません)<br />
        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
        ]]></html>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(mtxTANTO_ID.Text),
                                SYONIN_HOKOKUSYO_NAME,
                                PrHOKOKU_NO,
                                PrKISO_YMD,
                                KISYU_NAME,
                                PrBUHIN_BANGO,
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.RIYU,
                                mtxTANTO_ID.Text,
                                "FMS_G0030.exe",
                                strEXEParam)

        Dim users As New List(Of Integer)
        users.Add(mtxTANTO_ID.Text)

        If FunSendMailZESEI(strSubject, strBody, users) Then
            Using DB As ClsDbUtility = DBOpen()
                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper <> "TRUE" Then
                Else
                    MessageBox.Show("処置依頼メールを送信しました。", "メール送信完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

            Return True
        Else
            MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

#End Region

End Class