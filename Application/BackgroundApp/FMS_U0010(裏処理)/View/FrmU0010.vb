Imports JMS_COMMON.ClsPubMethod

Public Class FrmU0010



#Region "Form関連"

    'Loadイベント
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ''-----フォーム初期設定(親フォームから呼び出し)
            'Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            'Using DB As ClsDbUtility = DBOpen()
            '    lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            'End Using

            ''-----DB接続チェック
            'If FunCheckDBConnect(DB) = False Then
            '    Me.Close()
            '    Exit Sub
            'End If
        Finally

        End Try
    End Sub

#End Region

#Region "ローカル関数"

    Private Function FunGetDtST02_FUTEKIGO_ICHIRAN(ByVal ParamModel As ST02_ParamModel) As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbParam As New System.Text.StringBuilder
        Dim dsList As New DataSet

        '共通
        sbParam.Append(" '" & ParamModel.BUMON_KB & "'")
        sbParam.Append("," & ParamModel.SYONIN_HOKOKUSYO_ID & "")
        sbParam.Append("," & ParamModel.KISYU_ID & "")
        sbParam.Append(",'" & ParamModel.BUHIN_BANGO & "'")
        sbParam.Append(",'" & ParamModel.SYANAI_CD & "'")
        sbParam.Append(",'" & ParamModel.BUHIN_NAME & "'")
        sbParam.Append(",'" & ParamModel.GOUKI & "'")
        sbParam.Append("," & ParamModel.SYOCHI_TANTO & "")
        sbParam.Append(",'" & ParamModel.JISI_YMD_FROM & "'")
        sbParam.Append(",'" & ParamModel.JISI_YMD_TO & "'")
        sbParam.Append(",'" & ParamModel.HOKOKU_NO & "'")
        sbParam.Append("," & ParamModel.ADD_TANTO & "")
        sbParam.Append(",'0'")
        sbParam.Append(",'1'") '滞留のみ
        sbParam.Append(",'" & ParamModel.FUTEKIGO_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_S_KB & "'")
        sbParam.Append(",'" & ParamModel.FUTEKIGO_JYOTAI_KB & "'")

        'NCR
        sbParam.Append(",'" & ParamModel.JIZEN_SINSA_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.ZESEI_SYOCHI_YOHI_KB & "'")
        sbParam.Append(",'" & ParamModel.SAISIN_IINKAI_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KENSA_KEKKA_KB & "'")

        'CAR
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB1 & "'")
        sbParam.Append(",'" & ParamModel.KONPON_YOIN_KB2 & "'")
        sbParam.Append(",'" & ParamModel.KISEKI_KOTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_HANTEI_SIJI_KB & "'")
        sbParam.Append(",'" & ParamModel.KOKYAKU_SAISYU_HANTEI_KB & "'")
        sbParam.Append(",'" & ParamModel.GENIN1 & "'")
        sbParam.Append(",'" & ParamModel.GENIN2 & "'")

        sbSQL.Append($"EXEC dbo.{NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN)} {sbParam.ToString}")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function

    Private Function FunMailSending() As Boolean
        Dim strMsg As String
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim strToAddress As String
        Dim strCCAddress As String = ""
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        Dim strSubject As String
        Try

            Dim model As New ST02_ParamModel
            Dim dt As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(model)

            Using DB As ClsDbUtility = DBOpen()
                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    Return True
                End If

                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")
                strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

                Dim blnErr As Boolean
                Try
                    DB.BeginTransaction()

                    For Each dr As DataRow In dt.Rows
                        '---申請先担当者のメールアドレス取得
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As New DataSet
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("SELECT")
                        sbSQL.Append(" SIMEI")
                        sbSQL.Append(" ,MAIL_ADDRESS")
                        sbSQL.Append(" FROM M004_SYAIN ")
                        sbSQL.Append(" WHERE SYAIN_ID=" & dr.Item("GEN_TANTO_ID") & "")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        If dsList.Tables(0).Rows.Count > 0 Then
                            strToAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
                            strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                        Else
                            WL.WriteLogDat($"【メール送信失敗】担当者ID:{dr.Item("GEN_TANTO_ID")}のメールアドレスが取得できませんでした")
                            Continue For
                        End If

                        Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("HOKOKU_NO")}"
                        strSubject = $"【不適合品処置依頼】{dr.Item("KISYU_NAME")}・{dr.Item("BUHIN_BANGO")}"
                        Dim strBody As String = <body><![CDATA[
                            {0} 殿<br />
                            <br />
                                　不適合製品の処置依頼から【滞留日数】{1}日が経過しています。<br />
                                　早急に対応をお願いします。<br />
                            <br />
                                　　【報告書No】{2}<br />
                                　　【起草日　】{3}<br />
                                　　【機種　　】{4}<br />
                                　　【部品番号】{5}<br />
                                　　【依頼者　】{6}<br />
                            <br />
                            <a href = "http://sv116:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                            <br />
                            ※このメールは配信専用です。(返信できません)<br />
                            返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                            ]]></body>.Value.Trim

                        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={7}&EXEPATH={8}&PARAMS={9}

                        strBody = String.Format(strBody,
                        dr.Item("GEN_TANTO_NAME"),
                        dr.Item("TAIRYU_NISSU"),
                        dr.Item("HOKOKU_NO"),
                        IIf(dr.Item("KISO_YMD") <> "", CDate(dr.Item("KISO_YMD")).ToString("yyyy/MM/dd"), ""),
                        dr.Item("KISYU_NAME"),
                        dr.Item("BUHIN_BANGO"),
                        Fun_GetUSER_NAME(pub_SYAIN_INFO.SYAIN_ID),
                        dr.Item("GEN_TANTO_ID"),
                        "FMS_G0010.exe",
                        strEXEParam)


                        blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                           intSmtpPort,
                           strFromAddress,
                           strToAddress,
                           CCAddress:=strCCAddress,
                           BCCAddress:="",
                           strSubject:=strSubject,
                           strBody:=strBody,
                           strAttachment:="",
                           strFromName:="不適合管理システム",
                           isHTML:=True)


                        If blnSend Then
                            WL.WriteLogDat($"【メール送信成功】TO:{strToSyainName}({strToAddress}) SUBJECT:{strSubject}")
                        Else
                            'MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            blnErr = True
                            Return False
                        End If
                    Next dr

                    Return True
                Finally
                    DB.Commit(Not blnErr)
                End Try
            End Using
        Catch ex As Exception
            strMsg = $"【メール送信失敗】TO:{strToSyainName}({strToAddress}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
            WL.WriteLogDat(strMsg)
        Finally

        End Try
    End Function

#End Region

End Class