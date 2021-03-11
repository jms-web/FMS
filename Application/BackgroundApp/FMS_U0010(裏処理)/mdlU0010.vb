Imports JMS_COMMON
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

                Dim TAIRYU_COUNT As Integer
                TAIRYU_COUNT += SendFUTEKIGOMail()
                TAIRYU_COUNT += SendFCCB_TAIRYU_Mail()
                TAIRYU_COUNT += SendFCCB_KANRYO_Mail()

                If TAIRYU_COUNT > 0 Then
                    WL.WriteLogDat($"{TAIRYU_COUNT:00}件の滞留通知メールを送信しました。")
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

#Region "   不適合滞留通知"

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

    Private Function SendFUTEKIGOMail() As Integer
        Dim strMsg As String
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim CCAddressList As New List(Of String)
        Dim BCCAddressList As New List(Of String)
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        Dim strSubject As String
        Dim intSendCount As Integer

        Try

            Dim dt As DataTable = FunGetDtST02_FUTEKIGO_ICHIRAN(New ST02_ParamModel)

            Using DB As ClsDbUtility = DBOpen()
                'If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                '    WL.WriteLogDat($"メール送信設定が無効(FALSE)に設定されています")
                '    Return 0
                'End If

                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")
                strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

                For Each dr As DataRow In dt.Rows
                    Dim ToAddressList As New List(Of String)
                    Try

                        If dr.Item("DEL_YMDHNS").ToString.Trim <> "" Then
                            '削除済みは除外
                            Continue For
                        End If

                        '---申請先担当者のメールアドレス取得
                        Dim sbSQL As New System.Text.StringBuilder
                        Dim dsList As New DataSet
                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" M4.SIMEI")
                        sbSQL.Append($",M4.MAIL_ADDRESS")
                        sbSQL.Append($",M5.BUSYO_ID")
                        sbSQL.Append($",M2.BUSYO_NAME")
                        sbSQL.Append($",ISNULL(OYA_M2.BUSYO_NAME,'') AS OYA_BUYSYO_NAME")
                        sbSQL.Append($",ISNULL(GL.SIMEI,'') AS GL_SIMEI")
                        sbSQL.Append($",ISNULL(GL.MAIL_ADDRESS,'') AS GL_ADDRESS")
                        sbSQL.Append($",ISNULL(OYA_GL.SIMEI,'') AS OYA_GL_SIMEI")
                        sbSQL.Append($",ISNULL(OYA_GL.MAIL_ADDRESS,'') AS OYA_GL_ADDRESS")
                        sbSQL.Append($" FROM M004_SYAIN AS M4")
                        sbSQL.Append($" LEFT JOIN dbo.M005_SYOZOKU_BUSYO AS M5 ON (M4.SYAIN_ID = M5.SYAIN_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS M2 ON (M2.BUSYO_ID = M5.BUSYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS GL ON (GL.SYAIN_ID = M2.SYOZOKUCYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS OYA_M2 ON (OYA_M2.BUSYO_ID = M2.OYA_BUSYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS OYA_GL ON (OYA_GL.SYAIN_ID = OYA_M2.SYOZOKUCYO_ID)")
                        sbSQL.Append($" WHERE M4.SYAIN_ID={dr.Item("GEN_TANTO_ID")}")
                        sbSQL.Append($" AND M5.KENMU_FLG='0'")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                        With dsList.Tables(0)
                            If .Rows.Count > 0 Then
                                ToAddressList.Add(.Rows(0).Item("MAIL_ADDRESS"))

                                '所属長にも送信
                                If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                                End If

                                '送信先が所属長宛てだった場合、所属長の上位の部署の所属長にも送信
                                If dsList.Tables(0).Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                                End If

                                strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                            Else
                                WL.WriteLogDat($"【メール送信失敗】担当者ID:{dr.Item("GEN_TANTO_ID")}のメールアドレスが取得できませんでした")
                                Continue For
                            End If
                        End With

                        Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("HOKOKU_NO").ToString.Trim}"
                        strSubject = $"【不適合品処置依頼】[{dr.Item("SYONIN_HOKOKUSYO_R_NAME").ToString.Trim}] {dr.Item("KISYU_NAME").ToString.Trim}・{dr.Item("BUHIN_BANGO").ToString.Trim}"
                        Dim strBody As String = <body><![CDATA[
                            {0} 殿<br />
                            <br />
                                　不適合製品の処置依頼から【滞留日数】{1}日が経過しています。<br />
                                　早急に対応をお願いします。<br />
                            <br />
                                　　【報 告 書】{2}<br />
                                　　【報告書No】{3}<br />
                                　　【起 草 日】{4}<br />
                                　　【機　  種】{5}<br />
                                　　【部品番号】{6}<br />
                                　　【依 頼 者】{7}<br />
                            <br />
                            <a href = "http://sv04:8000/CLICKONCE_FMS.application" > システム起動</a><br />
                            <br />
                            ※このメールは配信専用です。(返信できません)<br />
                            返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                            ]]></body>.Value.Trim

                        'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={7}&EXEPATH={8}&PARAMS={9}

                        strBody = String.Format(strBody,
                        dr.Item("GEN_TANTO_NAME").ToString.Trim,
                        dr.Item("TAIRYU_NISSU").ToString.Trim,
                        dr.Item("SYONIN_HOKOKUSYO_R_NAME").ToString.Trim,
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
                           ToAddressList,
                           CCAddress:=CCAddressList,
                           BCCAddress:=BCCAddressList,
                           strSubject:=strSubject,
                           strBody:=strBody,
                           AttachmentList:=New List(Of String),
                           strFromName:="不適合管理システム",
                           isHTML:=True)

                        If blnSend Then
                            WL.WriteLogDat($"【メール送信成功】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                            intSendCount += 1
                        Else
                            'MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            WL.WriteLogDat($"【メール送信失敗】送信処理失敗 Subject:{strSubject} To:{ToAddressList(0)}")
                            Continue For
                        End If
                        System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        strMsg = $"【メール送信失敗】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                        WL.WriteLogDat(strMsg)
                        Continue For
                    End Try
                Next dr
            End Using

            Return intSendCount
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try

    End Function

#End Region

#Region "FCCB滞留通知"

    Private Function SendFCCB_TAIRYU_Mail() As Integer
        Dim strMsg As String
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim CCAddressList As New List(Of String)
        Dim BCCAddressList As New List(Of String)
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        Dim strSubject As String
        Dim intSendCount As Integer

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim dt As DataTable

        Using DB As ClsDbUtility = DBOpen()
            If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                WL.WriteLogDat($"メール送信設定が無効(FALSE)に設定されています")
                Return 0
            End If

            sbSQL.Append($"SELECT * FROM {NameOf(MODEL.V013_FCCB_ICHIRAN)}")
            sbSQL.Append($"　WHERE {NameOf(MODEL.V013_FCCB_ICHIRAN.GEN_TANTO_ID)} > 0")
            sbSQL.Append($"　AND {NameOf(MODEL.V013_FCCB_ICHIRAN.SYONIN_JUN)} <> 20")
            sbSQL.Append($"　AND RTRIM({NameOf(MODEL.V013_FCCB_ICHIRAN.DEL_YMDHNS)})=''")

            'UNDONE: ST2の滞留通知

            strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
            strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
            strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")
            strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

            For Each dr As DataRow In dt.Rows
                Dim ToAddressList As New List(Of String)
                Try

                    '---申請先担当者のメールアドレス取得
                    sbSQL.Clear()
                    sbSQL.Append($"SELECT")
                    sbSQL.Append($" M4.SIMEI")
                    sbSQL.Append($",M4.MAIL_ADDRESS")
                    sbSQL.Append($",M5.BUSYO_ID")
                    sbSQL.Append($",M2.BUSYO_NAME")
                    sbSQL.Append($",ISNULL(OYA_M2.BUSYO_NAME,'') AS OYA_BUYSYO_NAME")
                    sbSQL.Append($",ISNULL(GL.SIMEI,'') AS GL_SIMEI")
                    sbSQL.Append($",ISNULL(GL.MAIL_ADDRESS,'') AS GL_ADDRESS")
                    sbSQL.Append($",ISNULL(OYA_GL.SIMEI,'') AS OYA_GL_SIMEI")
                    sbSQL.Append($",ISNULL(OYA_GL.MAIL_ADDRESS,'') AS OYA_GL_ADDRESS")
                    sbSQL.Append($" FROM M004_SYAIN AS M4")
                    sbSQL.Append($" LEFT JOIN dbo.M005_SYOZOKU_BUSYO AS M5 ON (M4.SYAIN_ID = M5.SYAIN_ID)")
                    sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS M2 ON (M2.BUSYO_ID = M5.BUSYO_ID)")
                    sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS GL ON (GL.SYAIN_ID = M2.SYOZOKUCYO_ID)")
                    sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS OYA_M2 ON (OYA_M2.BUSYO_ID = M2.OYA_BUSYO_ID)")
                    sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS OYA_GL ON (OYA_GL.SYAIN_ID = OYA_M2.SYOZOKUCYO_ID)")
                    sbSQL.Append($" WHERE M4.SYAIN_ID={dr.Item("GEN_TANTO_ID")}")
                    sbSQL.Append($" AND M5.KENMU_FLG='0'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    With dsList.Tables(0)
                        If .Rows.Count > 0 Then
                            ToAddressList.Add(.Rows(0).Item("MAIL_ADDRESS"))

                            '所属長にも送信
                            If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                            End If

                            '送信先が所属長宛てだった場合、所属長の上位の部署の所属長にも送信
                            If dsList.Tables(0).Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                            End If

                            strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                        Else
                            WL.WriteLogDat($"【メール送信失敗】担当者ID:{dr.Item("GEN_TANTO_ID")}のメールアドレスが取得できませんでした")
                            Continue For
                        End If

                    End With
                    Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("FCCB_NO").ToString.Trim}"
                    strSubject = $"【FCCB処置依頼】FCCB-NO:{dr.Item("FCCB_NO").ToString.Trim} {dr.Item("KISYU_NAME").ToString.Trim}・{dr.Item("BUHIN_BANGO").ToString.Trim}"
                    Dim appUrl As String = """http://sv04:8000/CLICKONCE_FMS.application"""
                    Dim strBody As String = $"
                    {dr.Item("GEN_TANTO_NAME").ToString.Trim} 殿<br />
                    <br />
                    処置依頼から【滞留日数】{dr.Item("TAIRYU_NISSU").ToString.Trim}日が経過しています。<br />
                    早急に対応をお願いします。<br />
                    <br />
                    【報 告 書】FCCB記録書<br />
                    【報告書No】{dr.Item("FCCB_NO").ToString.Trim}<br />
                    【起 草 日】{dr.Item("KISO_YMD").ToString}<br />
                    【機　  種】{dr.Item("KISYU_NAME").ToString.Trim}<br />
                    【部品番号】{dr.Item("BUHIN_BANGO").ToString.Trim}<br />
                    【依 頼 者】FCCB記録書管理システム<br />
                    <br />
                    <a href = {appUrl}> システム起動</a><br />
                    <br />
                    ※このメールは配信専用です。(返信できません)<br />
                    返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                    "

                    blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                           intSmtpPort,
                           strFromAddress,
                           ToAddressList,
                           CCAddress:=CCAddressList,
                           BCCAddress:=BCCAddressList,
                           strSubject:=strSubject,
                           strBody:=strBody.Trim,
                           AttachmentList:=New List(Of String),
                           strFromName:="FCCB記録書管理システム",
                           isHTML:=True)

                    If blnSend Then
                        WL.WriteLogDat($"【メール送信成功】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                        intSendCount += 1
                    Else
                        'MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        WL.WriteLogDat($"【メール送信失敗】送信処理失敗 Subject:{strSubject} To:{ToAddressList(0)}")
                        Continue For
                    End If
                    System.Threading.Thread.Sleep(1000)
                Catch ex As Exception
                    strMsg = $"【メール送信失敗】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                    WL.WriteLogDat(strMsg)
                    Continue For
                End Try
            Next dr

            Return intSendCount
        End Using
    End Function

#End Region

#Region "FCCB処置完了通知"

    Private Function SendFCCB_KANRYO_Mail() As Integer

        Try
            Dim strMsg As String
            Dim strSmtpServer As String
            Dim intSmtpPort As Integer
            Dim strFromAddress As String
            Dim CCAddressList As New List(Of String)
            Dim BCCAddressList As New List(Of String)
            Dim strUserID As String
            Dim strPassword As String
            Dim blnSend As Boolean
            Dim strToSyainName As String
            Dim strSubject As String
            Dim intSendCount As Integer
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            Dim dt As DataTable

            Using DB As ClsDbUtility = DBOpen()
                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    WL.WriteLogDat($"メール送信設定が無効(FALSE)に設定されています")
                    Return 0
                End If

                sbSQL.Append($"SELECT FCCB_NO")
                sbSQL.Append($",TANTO_ID")
                sbSQL.Append($",TANTO_NAME")
                sbSQL.Append($",KISO_YMD")
                sbSQL.Append($",DATEDIFF(day,CONVERT(datetime,MIN(YOTEI_YMD)),GETDATE()) TAIRYU_NISSU")
                sbSQL.Append($",KISYU_NAME")
                sbSQL.Append($",BUHIN_BANGO")
                sbSQL.Append($" FROM V014_FCCB_SYOCHI_YOTEI_ICHIRAN")
                sbSQL.Append($" WHERE TANTO_ID >0")
                'sbSQL.Append($" AND DATEDIFF(day,CONVERT(datetime,YOTEI_YMD),GETDATE()) > 7")
                sbSQL.Append($" GROUP BY")
                sbSQL.Append($" FCCB_NO,TANTO_ID,TANTO_NAME,KISO_YMD,KISYU_NAME,BUHIN_BANGO")
                sbSQL.Append($"")

                dt = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)?.Tables(0)

                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")
                strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

                For Each dr As DataRow In dt.Rows
                    Dim ToAddressList As New List(Of String)
                    Try

                        '---申請先担当者のメールアドレス取得
                        sbSQL.Clear()
                        sbSQL.Append($"SELECT")
                        sbSQL.Append($" M4.SIMEI")
                        sbSQL.Append($",M4.MAIL_ADDRESS")
                        sbSQL.Append($",M5.BUSYO_ID")
                        sbSQL.Append($",M2.BUSYO_NAME")
                        sbSQL.Append($",ISNULL(OYA_M2.BUSYO_NAME,'') AS OYA_BUYSYO_NAME")
                        sbSQL.Append($",ISNULL(GL.SIMEI,'') AS GL_SIMEI")
                        sbSQL.Append($",ISNULL(GL.MAIL_ADDRESS,'') AS GL_ADDRESS")
                        sbSQL.Append($",ISNULL(OYA_GL.SIMEI,'') AS OYA_GL_SIMEI")
                        sbSQL.Append($",ISNULL(OYA_GL.MAIL_ADDRESS,'') AS OYA_GL_ADDRESS")
                        sbSQL.Append($" FROM M004_SYAIN AS M4")
                        sbSQL.Append($" LEFT JOIN dbo.M005_SYOZOKU_BUSYO AS M5 ON (M4.SYAIN_ID = M5.SYAIN_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS M2 ON (M2.BUSYO_ID = M5.BUSYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS GL ON (GL.SYAIN_ID = M2.SYOZOKUCYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS OYA_M2 ON (OYA_M2.BUSYO_ID = M2.OYA_BUSYO_ID)")
                        sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS OYA_GL ON (OYA_GL.SYAIN_ID = OYA_M2.SYOZOKUCYO_ID)")
                        sbSQL.Append($" WHERE M4.SYAIN_ID={dr.Item("TANTO_ID")}")
                        sbSQL.Append($" AND M5.KENMU_FLG='0'")
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                        With dsList.Tables(0)
                            If .Rows.Count > 0 Then
                                ToAddressList.Add(dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS"))

                                '所属長にも送信
                                If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                                End If

                                '送信先が所属長宛てだった場合、所属長の上位の部署の所属長にも送信
                                If .Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                                End If

                                strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                            Else
                                WL.WriteLogDat($"【メール送信失敗】担当者ID:{dr.Item("TANTO_ID")}のメールアドレスが取得できませんでした")
                                Continue For
                            End If
                        End With

                        strSubject = $"【FCCB処置依頼】FCCB_NO:{dr.Item("FCCB_NO").ToString.Trim} {dr.Item("KISYU_NAME").ToString.Trim}・{dr.Item("BUHIN_BANGO").ToString.Trim}"
                        Dim appUrl As String = """http://sv04:8000/CLICKONCE_FMS.application"""
                        Dim dtYOTEI As Date = Date.ParseExact(dr.Item("YOTEI_YMD"), "yyyyMMdd", Nothing)
                        Dim strbodySub As String

                        If dr.Item("TAIRYU_NISSU").ToString.ToVal > -7 Then
                            Continue For
                        End If

                        If (dr.Item("TAIRYU_NISSU").ToString.ToVal < 0) Then

                            strbodySub = $"処置完了予定日：{dtYOTEI:yyyy/MM/dd}まであと {Math.Abs(dr.Item("TAIRYU_NISSU").ToString.ToVal)}日です。"
                        Else
                            strbodySub = $"処置完了予定日：{dtYOTEI:yyyy/MM/dd}から {dr.Item("TAIRYU_NISSU").ToString.ToVal}日経過しています。"
                        End If

                        Dim strBody As String = $"
                        {dr.Item("TANTO_NAME").ToString.Trim} 殿<br />
                        <br />
                        FCCB記録書の{strbodySub}<br />
                        処置完了日の入力をお願いします。<br />
                        <br />                                　　
                        【報告書No】{dr.Item("FCCB_NO").ToString.Trim}<br />
                        【起 草 日】{dr.Item("KISO_YMD").ToString}<br />
                        【機　  種】{dr.Item("KISYU_NAME").ToString.Trim}<br />
                        【部品番号】{dr.Item("BUHIN_BANGO").ToString.Trim}<br />
                        <br />
                        <a href = {appUrl}>システム起動</a><br />
                        <br />
                        ※このメールは配信専用です。(返信できません)<br />
                        返信する場合は、各担当者のメールアドレスを使用して下さい。<br />
                        "

                        blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                               intSmtpPort,
                               strFromAddress,
                               ToAddressList,
                               CCAddress:=CCAddressList,
                               BCCAddress:=BCCAddressList,
                               strSubject:=strSubject,
                               strBody:=strBody.Trim,
                               AttachmentList:=New List(Of String),
                               strFromName:="FCCB記録書管理システム",
                               isHTML:=True)

                        If blnSend Then
                            WL.WriteLogDat($"【メール送信成功】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                            intSendCount += 1
                        Else
                            'MessageBox.Show("メール送信に失敗しました。", "メール送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            WL.WriteLogDat($"【メール送信失敗】送信処理失敗 Subject:{strSubject} To:{ToAddressList(0)}")
                            Continue For
                        End If
                        System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        strMsg = $"【メール送信失敗】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                        WL.WriteLogDat(strMsg)
                        Continue For
                    End Try
                Next dr

                Return intSendCount
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#End Region

End Module