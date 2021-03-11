Imports JMS_COMMON
Imports JMS_COMMON.ClsPubMethod

Module mdlU0010

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmU0010

#End Region

#Region "MAIN"

    <STAThread()>
    Public Sub Main()

        Try

            '-----��d�N���}��
            Using objMutex = New System.Threading.Mutex(False, My.Application.Info.AssemblyName)
                If objMutex.WaitOne(0, False) = False Then
                    'MsgBox("���ɋN������Ă��܂�", MsgBoxStyle.Information, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----���ʏ�������
                If FunINTSYR() = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                    Exit Sub
                End If

                ''-----PG�ݒ�t�@�C���Ǎ�����
                'If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                '    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                '    Exit Sub
                'End If

                ''-----�o�͐�ݒ�t�@�C���Ǎ�����
                'If FunGetOutputIniFile() = False Then
                '    MsgBox(My.Resources.ErrLogMsgSetOutput, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
                '    Exit Sub
                'End If

                ''-----Visual�X�^�C���L��
                'Application.EnableVisualStyles()
                ''-----GDI���g�p
                'Application.SetCompatibleTextRenderingDefault(False)

                ''-----�ꗗ��ʕ\��
                'frmLIST = New FrmU0010
                'Application.Run(frmLIST)

                Dim TAIRYU_COUNT As Integer
                TAIRYU_COUNT += SendFUTEKIGOMail()
                TAIRYU_COUNT += SendFCCB_TAIRYU_Mail()
                TAIRYU_COUNT += SendFCCB_KANRYO_Mail()

                If TAIRYU_COUNT > 0 Then
                    WL.WriteLogDat($"{TAIRYU_COUNT:00}���̑ؗ��ʒm���[���𑗐M���܂����B")
                Else
                    WL.WriteLogDat("�ؗ��f�[�^���`�F�b�N���܂������A�Ώۃf�[�^�͂���܂���ł����B")
                End If

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            'MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "   �s�K���ؗ��ʒm"

    Private Function FunGetDtST02_FUTEKIGO_ICHIRAN(ByVal ParamModel As ST02_ParamModel) As DataTable

        Dim sbSQL As New System.Text.StringBuilder
        Dim sbParam As New System.Text.StringBuilder
        Dim dsList As New DataSet

        '����
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
        sbParam.Append(",'1'") '�ؗ��̂�
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
                'If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                '    WL.WriteLogDat($"���[�����M�ݒ肪����(FALSE)�ɐݒ肳��Ă��܂�")
                '    Return 0
                'End If

                strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")
                strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")

                For Each dr As DataRow In dt.Rows
                    Dim ToAddressList As New List(Of String)
                    Try

                        If dr.Item("DEL_YMDHNS").ToString.Trim <> "" Then
                            '�폜�ς݂͏��O
                            Continue For
                        End If

                        '---�\����S���҂̃��[���A�h���X�擾
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

                                '�������ɂ����M
                                If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                                End If

                                '���M�悪���������Ă������ꍇ�A�������̏�ʂ̕����̏������ɂ����M
                                If dsList.Tables(0).Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                                End If

                                strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                            Else
                                WL.WriteLogDat($"�y���[�����M���s�z�S����ID:{dr.Item("GEN_TANTO_ID")}�̃��[���A�h���X���擾�ł��܂���ł���")
                                Continue For
                            End If
                        End With

                        Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("HOKOKU_NO").ToString.Trim}"
                        strSubject = $"�y�s�K���i���u�˗��z[{dr.Item("SYONIN_HOKOKUSYO_R_NAME").ToString.Trim}] {dr.Item("KISYU_NAME").ToString.Trim}�E{dr.Item("BUHIN_BANGO").ToString.Trim}"
                        Dim strBody As String = <body><![CDATA[
                            {0} �a<br />
                            <br />
                                �@�s�K�����i�̏��u�˗�����y�ؗ������z{1}�����o�߂��Ă��܂��B<br />
                                �@���}�ɑΉ������肢���܂��B<br />
                            <br />
                                �@�@�y�� �� ���z{2}<br />
                                �@�@�y�񍐏�No�z{3}<br />
                                �@�@�y�N �� ���z{4}<br />
                                �@�@�y�@�@  ��z{5}<br />
                                �@�@�y���i�ԍ��z{6}<br />
                                �@�@�y�� �� �ҁz{7}<br />
                            <br />
                            <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                            <br />
                            �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                            �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
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
                        "�s�K���Ǘ��V�X�e��",
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
                           strFromName:="�s�K���Ǘ��V�X�e��",
                           isHTML:=True)

                        If blnSend Then
                            WL.WriteLogDat($"�y���[�����M�����zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                            intSendCount += 1
                        Else
                            'MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            WL.WriteLogDat($"�y���[�����M���s�z���M�������s Subject:{strSubject} To:{ToAddressList(0)}")
                            Continue For
                        End If
                        System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        strMsg = $"�y���[�����M���s�zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
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

#Region "FCCB�ؗ��ʒm"

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
            If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                WL.WriteLogDat($"���[�����M�ݒ肪����(FALSE)�ɐݒ肳��Ă��܂�")
                Return 0
            End If

            sbSQL.Append($"SELECT * FROM {NameOf(MODEL.V013_FCCB_ICHIRAN)}")
            sbSQL.Append($"�@WHERE {NameOf(MODEL.V013_FCCB_ICHIRAN.GEN_TANTO_ID)} > 0")
            sbSQL.Append($"�@AND {NameOf(MODEL.V013_FCCB_ICHIRAN.SYONIN_JUN)} <> 20")
            sbSQL.Append($"�@AND RTRIM({NameOf(MODEL.V013_FCCB_ICHIRAN.DEL_YMDHNS)})=''")

            'UNDONE: ST2�̑ؗ��ʒm

            strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
            strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
            strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")
            strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")

            For Each dr As DataRow In dt.Rows
                Dim ToAddressList As New List(Of String)
                Try

                    '---�\����S���҂̃��[���A�h���X�擾
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

                            '�������ɂ����M
                            If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                            End If

                            '���M�悪���������Ă������ꍇ�A�������̏�ʂ̕����̏������ɂ����M
                            If dsList.Tables(0).Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                            End If

                            strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                        Else
                            WL.WriteLogDat($"�y���[�����M���s�z�S����ID:{dr.Item("GEN_TANTO_ID")}�̃��[���A�h���X���擾�ł��܂���ł���")
                            Continue For
                        End If

                    End With
                    Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("FCCB_NO").ToString.Trim}"
                    strSubject = $"�yFCCB���u�˗��zFCCB-NO:{dr.Item("FCCB_NO").ToString.Trim} {dr.Item("KISYU_NAME").ToString.Trim}�E{dr.Item("BUHIN_BANGO").ToString.Trim}"
                    Dim appUrl As String = """http://sv04:8000/CLICKONCE_FMS.application"""
                    Dim strBody As String = $"
                    {dr.Item("GEN_TANTO_NAME").ToString.Trim} �a<br />
                    <br />
                    ���u�˗�����y�ؗ������z{dr.Item("TAIRYU_NISSU").ToString.Trim}�����o�߂��Ă��܂��B<br />
                    ���}�ɑΉ������肢���܂��B<br />
                    <br />
                    �y�� �� ���zFCCB�L�^��<br />
                    �y�񍐏�No�z{dr.Item("FCCB_NO").ToString.Trim}<br />
                    �y�N �� ���z{dr.Item("KISO_YMD").ToString}<br />
                    �y�@�@  ��z{dr.Item("KISYU_NAME").ToString.Trim}<br />
                    �y���i�ԍ��z{dr.Item("BUHIN_BANGO").ToString.Trim}<br />
                    �y�� �� �ҁzFCCB�L�^���Ǘ��V�X�e��<br />
                    <br />
                    <a href = {appUrl}> �V�X�e���N��</a><br />
                    <br />
                    �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                    �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
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
                           strFromName:="FCCB�L�^���Ǘ��V�X�e��",
                           isHTML:=True)

                    If blnSend Then
                        WL.WriteLogDat($"�y���[�����M�����zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                        intSendCount += 1
                    Else
                        'MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        WL.WriteLogDat($"�y���[�����M���s�z���M�������s Subject:{strSubject} To:{ToAddressList(0)}")
                        Continue For
                    End If
                    System.Threading.Thread.Sleep(1000)
                Catch ex As Exception
                    strMsg = $"�y���[�����M���s�zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                    WL.WriteLogDat(strMsg)
                    Continue For
                End Try
            Next dr

            Return intSendCount
        End Using
    End Function

#End Region

#Region "FCCB���u�����ʒm"

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
                If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    WL.WriteLogDat($"���[�����M�ݒ肪����(FALSE)�ɐݒ肳��Ă��܂�")
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

                strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")
                strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")

                For Each dr As DataRow In dt.Rows
                    Dim ToAddressList As New List(Of String)
                    Try

                        '---�\����S���҂̃��[���A�h���X�擾
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

                                '�������ɂ����M
                                If .Rows(0).Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("GL_ADDRESS"))
                                End If

                                '���M�悪���������Ă������ꍇ�A�������̏�ʂ̕����̏������ɂ����M
                                If .Rows(0).Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString = .Rows(0).Item("GL_ADDRESS").ToString AndAlso
                                    .Rows(0).Item("MAIL_ADDRESS").ToString <> .Rows(0).Item("OYA_GL_ADDRESS").ToString Then
                                    ToAddressList.Add(.Rows(0).Item("OYA_GL_ADDRESS"))
                                End If

                                strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI").ToString.Trim
                            Else
                                WL.WriteLogDat($"�y���[�����M���s�z�S����ID:{dr.Item("TANTO_ID")}�̃��[���A�h���X���擾�ł��܂���ł���")
                                Continue For
                            End If
                        End With

                        strSubject = $"�yFCCB���u�˗��zFCCB_NO:{dr.Item("FCCB_NO").ToString.Trim} {dr.Item("KISYU_NAME").ToString.Trim}�E{dr.Item("BUHIN_BANGO").ToString.Trim}"
                        Dim appUrl As String = """http://sv04:8000/CLICKONCE_FMS.application"""
                        Dim dtYOTEI As Date = Date.ParseExact(dr.Item("YOTEI_YMD"), "yyyyMMdd", Nothing)
                        Dim strbodySub As String

                        If dr.Item("TAIRYU_NISSU").ToString.ToVal > -7 Then
                            Continue For
                        End If

                        If (dr.Item("TAIRYU_NISSU").ToString.ToVal < 0) Then

                            strbodySub = $"���u�����\����F{dtYOTEI:yyyy/MM/dd}�܂ł��� {Math.Abs(dr.Item("TAIRYU_NISSU").ToString.ToVal)}���ł��B"
                        Else
                            strbodySub = $"���u�����\����F{dtYOTEI:yyyy/MM/dd}���� {dr.Item("TAIRYU_NISSU").ToString.ToVal}���o�߂��Ă��܂��B"
                        End If

                        Dim strBody As String = $"
                        {dr.Item("TANTO_NAME").ToString.Trim} �a<br />
                        <br />
                        FCCB�L�^����{strbodySub}<br />
                        ���u�������̓��͂����肢���܂��B<br />
                        <br />                                �@�@
                        �y�񍐏�No�z{dr.Item("FCCB_NO").ToString.Trim}<br />
                        �y�N �� ���z{dr.Item("KISO_YMD").ToString}<br />
                        �y�@�@  ��z{dr.Item("KISYU_NAME").ToString.Trim}<br />
                        �y���i�ԍ��z{dr.Item("BUHIN_BANGO").ToString.Trim}<br />
                        <br />
                        <a href = {appUrl}>�V�X�e���N��</a><br />
                        <br />
                        �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                        �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
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
                               strFromName:="FCCB�L�^���Ǘ��V�X�e��",
                               isHTML:=True)

                        If blnSend Then
                            WL.WriteLogDat($"�y���[�����M�����zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}")
                            intSendCount += 1
                        Else
                            'MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            WL.WriteLogDat($"�y���[�����M���s�z���M�������s Subject:{strSubject} To:{ToAddressList(0)}")
                            Continue For
                        End If
                        System.Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        strMsg = $"�y���[�����M���s�zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
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