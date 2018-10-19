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

                Dim SendCount As Integer = FunMailSending()
                If SendCount > 0 Then
                    WL.WriteLogDat($"{SendCount:00}���̑ؗ��ʒm���[���𑗐M���܂����B")
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
            If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                WL.WriteLogDat($"���[�����M�ݒ肪����(FALSE)�ɐݒ肳��Ă��܂�")
                Return 0
            End If

            strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
            strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
            strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")
            strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")

            For Each dr As DataRow In dt.Rows
                Try
                    If dr.Item("DEL_YMDHNS").ToString.Trim <> "" Then
                        '�폜�ς݂͏��O
                        Continue For
                    End If

                    '---�\����S���҂̃��[���A�h���X�擾
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
                        WL.WriteLogDat($"�y���[�����M���s�z�S����ID:{dr.Item("GEN_TANTO_ID")}�̃��[���A�h���X���擾�ł��܂���ł���")
                        Continue For
                    End If

                    Dim strEXEParam As String = $"{dr.Item("GEN_TANTO_ID")},{2},{dr.Item("SYONIN_HOKOKUSYO_ID")},{dr.Item("HOKOKU_NO").ToString.Trim}"
                    strSubject = $"�y�s�K���i���u�˗��z{dr.Item("KISYU_NAME").ToString.Trim}�E{dr.Item("BUHIN_BANGO").ToString.Trim}"
                    Dim strBody As String = <body><![CDATA[
                            {0} �a<br />
                            <br />
                                �@�s�K�����i�̏��u�˗�����y�ؗ������z{1}�����o�߂��Ă��܂��B<br />
                                �@���}�ɑΉ������肢���܂��B<br />
                            <br />
                                �@�@�y�񍐏�No�z{2}<br />
                                �@�@�y�N�����@�z{3}<br />
                                �@�@�y�@��@�@�z{4}<br />
                                �@�@�y���i�ԍ��z{5}<br />
                                �@�@�y�˗��ҁ@�z{6}<br />
                            <br />
                            <a href = "http://sv116:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                            <br />
                            �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                            �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
                            ]]></body>.Value.Trim

                    'http://sv116:8000/CLICKONCE_FMS.application?SYAIN_ID={7}&EXEPATH={8}&PARAMS={9}


                    strBody = String.Format(strBody,
                        dr.Item("GEN_TANTO_NAME").ToString.Trim,
                        dr.Item("TAIRYU_NISSU").ToString.Trim,
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
                           strToAddress,
                           CCAddress:=strCCAddress,
                           BCCAddress:="",
                           strSubject:=strSubject,
                           strBody:=strBody,
                           strAttachment:="",
                           strFromName:="�s�K���Ǘ��V�X�e��",
                           isHTML:=True)

                    If blnSend Then
                        WL.WriteLogDat($"�y���[�����M�����zTO:{strToSyainName}({strToAddress}) SUBJECT:{strSubject}")
                        intSendCount += 1
                    Else
                        'MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        WL.WriteLogDat($"�y���[�����M���s�z���M�������s Subject:{strSubject} To:{strToAddress}")
                        Continue For
                    End If
                    System.Threading.Thread.Sleep(1000)
                Catch ex As Exception
                    strMsg = $"�y���[�����M���s�zTO:{strToSyainName}({strToAddress}) SUBJECT:{strSubject}{vbCrLf}{Err.Description}"
                    WL.WriteLogDat(strMsg)
                    Continue For
                End Try
            Next dr

            Return intSendCount
        End Using
    End Function

#End Region

End Module