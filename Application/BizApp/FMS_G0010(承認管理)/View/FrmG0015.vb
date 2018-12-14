Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' 転送画面
''' </summary>
Public Class FrmG0015

#Region "変数・定数"
    '入力必須コントロール検証判定
    Private IsValidated As Boolean
#End Region

#Region "プロパティ"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKU_NO As String

    Public Property PrCurrentStage As Integer

    Public Property PrBUMON_KB As String

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
        cmbTENSO_SAKI.NullValue = 0
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
            Dim drs As List(Of DataRow)
            If PrSYONIN_HOKOKUSYO_ID = Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR And PrCurrentStage = ENM_CAR_STAGE._10_起草入力 Then
                drs = FunGetSYOZOKU_SYAIN(PrBUMON_KB).AsEnumerable.
                        Where(Function(r) r.Field(Of Integer)("VALUE") <> pub_SYAIN_INFO.SYAIN_ID).
                        ToList
            Else
                drs = FunGetSYONIN_SYOZOKU_SYAIN(PrBUMON_KB, PrSYONIN_HOKOKUSYO_ID, PrCurrentStage).AsEnumerable.
                        Where(Function(r) r.Field(Of Integer)("VALUE") <> pub_SYAIN_INFO.SYAIN_ID).
                        ToList
            End If


            If drs.Count > 0 Then
                Dim tbl As DataTable = drs.CopyToDataTable
                Me.cmbTENSO_SAKI.SetDataSource(tbl, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Else
                MessageBox.Show("当該ステージの承認担当者がログインユーザー以外に登録されていないため、転送処理は出来ません。", "承認担当者マスタ登録不備", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

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
        'Dim blnRET As Boolean

        Try
            'ボタン不可/ボタンINDEX取得
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            'ボタンINDEX毎の処理
            Select Case intFUNC
                Case 1  '追加
                    If FunCheckInput() Then
                        If FunSAVE() Then
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
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

            'SPEC: 2.(3).D.①.レコード更新
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    Dim strSysDate As String = DB.GetSysDateString

                    '-----トランザクション
                    DB.BeginTransaction()

                    '-----UPDATE D004
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"UPDATE {NameOf(MODEL.D004_SYONIN_J_KANRI)} SET")
                    sbSQL.Append($" {NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)}={cmbTENSO_SAKI.SelectedValue}")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.RIYU)}='{_D004_SYONIN_J_KANRI.RIYU}'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_SYAIN_ID)}={pub_SYAIN_INFO.SYAIN_ID}")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB)}='{ENM_SYONIN_HANTEI_KB._0_未承認.Value}'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.SASIMODOSI_FG)}='0'")
                    sbSQL.Append($" ,{NameOf(_D004_SYONIN_J_KANRI.UPD_YMDHNS)}='{strSysDate}'")
                    sbSQL.Append($" WHERE {NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID)}={PrSYONIN_HOKOKUSYO_ID}")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO)}='{PrHOKOKU_NO}'")
                    sbSQL.Append($" AND {NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN)}={PrCurrentStage}")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
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
                    _R001_HOKOKU_SOUSA.SOUSA_KB = ENM_SOUSA_KB._5_転送
                    _R001_HOKOKU_SOUSA.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認
                    _R001_HOKOKU_SOUSA.RIYU = _D004_SYONIN_J_KANRI.RIYU
                    '-----INSERT R001
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.R001_HOKOKU_SOUSA) & "(")
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
                    sbSQL.Append($" ,'{strSysDate}'") 'ADD_YMDHNS
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
                        Return False
                    End If

                    '-----データモデル更新
                    _R002_HOKOKU_TENSO.SYONIN_HOKOKUSYO_ID = PrSYONIN_HOKOKUSYO_ID
                    _R002_HOKOKU_TENSO.HOKOKU_NO = PrHOKOKU_NO
                    _R002_HOKOKU_TENSO.SYONIN_JUN = PrCurrentStage
                    _R002_HOKOKU_TENSO.TENSO_M_SYAIN_ID = pub_SYAIN_INFO.SYAIN_ID
                    _R002_HOKOKU_TENSO.TENSO_S_SYAIN_ID = cmbTENSO_SAKI.SelectedValue '_D004_SYONIN_J_KANRI.SYAIN_ID
                    _R002_HOKOKU_TENSO.RIYU = _D004_SYONIN_J_KANRI.RIYU

                    '-----INSERT R002
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append(" INSERT INTO " & NameOf(MODEL.R002_HOKOKU_TENSO) & "(")
                    sbSQL.Append("  " & NameOf(_R002_HOKOKU_TENSO.SYONIN_HOKOKUSYO_ID))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.HOKOKU_NO))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.SYONIN_JUN))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.RENBAN))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.TENSO_M_SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.TENSO_S_SYAIN_ID))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.RIYU))
                    sbSQL.Append(" ," & NameOf(_R002_HOKOKU_TENSO.ADD_YMDHNS))
                    sbSQL.Append(" ) VALUES(")
                    sbSQL.Append("  " & _R002_HOKOKU_TENSO.SYONIN_HOKOKUSYO_ID)
                    sbSQL.Append(" ,'" & _R002_HOKOKU_TENSO.HOKOKU_NO & "'")
                    sbSQL.Append(" ," & _R002_HOKOKU_TENSO.SYONIN_JUN)
                    sbSQL.Append(" ,(SELECT ISNULL(MAX(RENBAN),0) FROM R002_HOKOKU_TENSO S ")
                    sbSQL.Append("      WHERE(S.SYONIN_HOKOKUSYO_ID = " & _R002_HOKOKU_TENSO.SYONIN_HOKOKUSYO_ID)
                    sbSQL.Append("      And S.HOKOKU_NO = '" & _R002_HOKOKU_TENSO.HOKOKU_NO & "'")
                    sbSQL.Append("      And S.SYONIN_JUN =" & _R002_HOKOKU_TENSO.SYONIN_JUN & ")) + 1")
                    sbSQL.Append(" ," & (_R002_HOKOKU_TENSO.TENSO_M_SYAIN_ID))
                    sbSQL.Append(" ," & (_R002_HOKOKU_TENSO.TENSO_S_SYAIN_ID))
                    sbSQL.Append(" ,'" & (_R002_HOKOKU_TENSO.RIYU) & "'")
                    sbSQL.Append($" ,'{strSysDate}'") 'ADD_YMDHNS
                    sbSQL.Append(" )")

                    '-----SQL実行
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----エラーログ出力
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

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

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTENSO_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "転送先"))


    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTENSO_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "転送理由"))


    End Sub
#End Region

#Region "入力チェック"
    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            Call CmbMODOSI_SAKI_Validating(cmbTENSO_SAKI, Nothing)
            Call MtxMODOSI_RIYU_Validating(mtxTENSO_RIYU, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "ローカル関数"
    Private Function FunSetBinding() As Boolean
        'cmbTENSO_SAKI.DataBindings.Add(New Binding(NameOf(cmbTENSO_SAKI.SelectedValue), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID), False, DataSourceUpdateMode.OnPropertyChanged, 0))
        mtxTENSO_RIYU.DataBindings.Add(New Binding(NameOf(mtxTENSO_RIYU.Text), _D004_SYONIN_J_KANRI, NameOf(_D004_SYONIN_J_KANRI.RIYU), False, DataSourceUpdateMode.OnPropertyChanged, ""))
    End Function

    ''' <summary>
    ''' 承認依頼メール送信
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendRequestMail()
        Dim KISYU_NAME As String = PrKISYU_NAME 'tblKISYU.AsEnumerable.Where(Function(r) r.Field(Of Integer)("VALUE") = _D003_NCR_J.KISYU_ID).FirstOrDefault?.Item("DISP")
        Dim SYONIN_HANTEI_NAME As String = tblSYONIN_HANTEI_KB.AsEnumerable.Where(Function(r) r.Field(Of String)("VALUE") = _D004_SYONIN_J_KANRI.SYONIN_HANTEI_KB).FirstOrDefault?.Item("DISP")
        Dim strEXEParam As String = $"{_D004_SYONIN_J_KANRI.SYAIN_ID},{Val(ENM_OPEN_MODE._2_処置画面起動)},{PrSYONIN_HOKOKUSYO_ID},{PrHOKOKU_NO}"
        Dim strSubject As String = $"【不適合品処置依頼】{KISYU_NAME}・{PrBUHIN_BANGO}"
        Dim strBody As String = <html><![CDATA[
        {0} 殿<br />
        <br />
        　不適合製品の転送依頼が来ましたので対応をお願いします。<br />
        <br />
        　　【報告書No】{1}<br />
        　　【起草日　】{2}<br />
        　　【機種　　】{3}<br />
        　　【部品番号】{4}<br />
        　　【依頼者　】{5}<br />
        　　【依頼者処置内容】{6}<br />
        　　【コメント】{7}<br />
        <br />
        <a href = "http://sv04:8000/CLICKONCE_FMS.application" >システム起動</a><br />
        <br />
        ※このメールは配信専用です。(返信できません)<br />
        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
        ]]></html>.Value.Trim

        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={8}&EXEPATH={9}&PARAMS={10}

        strBody = String.Format(strBody,
                                Fun_GetUSER_NAME(cmbTENSO_SAKI.SelectedValue),
                                PrHOKOKU_NO,
                                PrKISO_YMD,
                                KISYU_NAME,
                                PrBUHIN_BANGO,
                                Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                                SYONIN_HANTEI_NAME,
                                _D004_SYONIN_J_KANRI.RIYU,
                                cmbTENSO_SAKI.SelectedValue,
                                "FMS_G0010.exe",
                                strEXEParam)

        If FunSendMailFutekigo(strSubject, strBody, ToSYAIN_ID:=cmbTENSO_SAKI.SelectedValue) Then
            Using DB As ClsDbUtility = DBOpen()
                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
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

    Private Function FunGetKISYU_NAME() As String
        'Dim dsList As New DataSet
        'Dim sbSQL As New System.Text.StringBuilder
        'Dim sbParam As New System.Text.StringBuilder

        ''共通
        'sbParam.Append($" '{PrBUMON_KB}'")
        'sbParam.Append($",{PrSYONIN_HOKOKUSYO_ID}")
        'sbParam.Append(",0")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",0")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append($",'{PrHOKOKU_NO}'")
        'sbParam.Append(",0")
        'sbParam.Append(",'0'")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        ''NCR
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        'sbParam.Append(",''")
        ''CAR
        'sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB1 & "'")
        'sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB2 & "'")
        'sbParam.Append(",'" & ParamModel.KISEKI_KOTEI_KB & "'")
        'sbParam.Append(",'" & ParamModel.KOKYAKU_HANTEI_SIJI_KB & "'")
        'sbParam.Append(",'" & ParamModel.KOKYAKU_SAISYU_HANTEI_KB & "'")
        'sbParam.Append(",'" & ParamModel.GENIN1 & "'")
        'sbParam.Append(",'" & ParamModel.GENIN2 & "'")

        'sbSQL.Append("EXEC dbo." & NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN) & " " & sbParam.ToString & "")
        'Using DB As ClsDbUtility = DBOpen()
        '    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        'End Using

        'Return dsList?.Tables(0)
    End Function
#End Region


End Class
