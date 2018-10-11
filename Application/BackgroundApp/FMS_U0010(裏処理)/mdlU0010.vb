Imports JMS_COMMON.ClsPubMethod

Module mdlU0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmU0010

#End Region

#Region "MAIN"

    <STAThread()>
    Public Sub Main()

        Try

            '-----二重起動抑制
            Using objMutex = New System.Threading.Mutex(False, My.Application.Info.AssemblyName)
                If objMutex.WaitOne(0, False) = False Then
                    'MsgBox("既に起動されています", MsgBoxStyle.Information, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----共通初期処理
                If FunINTSYR() = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                    Exit Sub
                End If

                ''-----PG設定ファイル読込処理
                'If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                '    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                '    Exit Sub
                'End If

                ''-----出力先設定ファイル読込処理
                'If FunGetOutputIniFile() = False Then
                '    MsgBox(My.Resources.ErrLogMsgSetOutput, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
                '    Exit Sub
                'End If

                ''-----Visualスタイル有効
                'Application.EnableVisualStyles()
                ''-----GDIを使用
                'Application.SetCompatibleTextRenderingDefault(False)

                ''-----一覧画面表示
                'frmLIST = New FrmU0010
                'Application.Run(frmLIST)

                Dim SendCount As Integer = FunMailSending()
                If SendCount > 0 Then
                    WL.WriteLogDat($"{SendCount:00}件の滞留通知メールを送信しました。")
                Else
                    WL.WriteLogDat("滞留データをチェックしましたが、対象データはありませんでした。")
                End If

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            'MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
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
        sbParam.Append(",'" & ParamModel.HASSEI_FROM & "'")
        sbParam.Append(",'" & ParamModel.HASSEI_TO & "'")

        sbSQL.Append($"EXEC dbo.{NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN)} {sbParam.ToString}")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function

    Private Function FunMailSending() As Integer
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
        Dim intSendCount As Integer

        Dim dt As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(New ST02_ParamModel)

        Using DB As ClsDbUtility = DBOpen()
            If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                WL.WriteLogDat($"メール送信設定が無効(FALSE)に設定されています")
                Return 0
            End If

            strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
            strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
            strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")
            strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

            For Each dr As DataRow In dt.Rows
                Try
                    If dr.Item("DEL_YMDHNS").ToString.Trim <> "" Then
                        '削除済みは除外
                        Continue For
                    End If

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
                        strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                    Else
                        WL.WriteLogDat($"【メール送信失敗】担当者ID:{dr.Item("GEN_TANTO_ID")}のメールアドレスが取得できませんでした")
                        Continue For
                    End If

                    Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("HOKOKU_NO").ToString.Trim}"
                    strSubject = $"【不適合品処置依頼】{dr.Item("KISYU_NAME").ToString.Trim}・{dr.Item("BUHIN_BANGO").ToString.Trim}"
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
                        dr.Item("GEN_TANTO_NAME").ToString.Trim,
                        dr.Item("TAIRYU_NISSU").ToString.Trim,
                        dr.Item("HOKOKU_NO").ToString.Trim,
                        dr.Item("KISO_YMD").ToString,
                        dr.Item("KISYU_NAME").ToString.Trim,
                        dr.Item("BUHIN_BANGO").ToString.Trim,
                        "不適合管理システム",
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
                        intSendCount += 1
                    Else
                        'MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        WL.WriteLogDat($"【メール送信失敗】送信処理失敗 Subject:{strSubject} To:{strToAddress}")
                        Continue For
                    End If
                    System.Threading.Thread.Sleep(1000)
                Catch ex As Exception
                    strMsg = $"【メール送信失敗】TO:{strToSyainName}({strToAddress}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                    WL.WriteLogDat(strMsg)
                    Continue For
                End Try
            Next dr

            Return intSendCount
        End Using
    End Function

#End Region

End Module