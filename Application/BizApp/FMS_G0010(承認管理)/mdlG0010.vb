Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' �N�����[�h
    ''' </summary>
    Public Enum ENM_OPEN_MODE As Integer

        ''' <summary>
        ''' �ʏ탂�[�h�c������ʂ�\��
        ''' </summary>
        _0_�ʏ� = 0

        ''' <summary>
        ''' �V�K�쐬���[�h�c�V�K�o�^��ʂ𒼐ڕ\���A�o�^�㌟����ʂɖ߂炸
        ''' </summary>
        _1_�V�K�쐬 = 1
    End Enum
    ''' <summary>
    ''' �N�����[�h(0:�ʏ�,1:�V�K�쐬)
    ''' </summary>
    Public pub_intOPEN_MODE As ENM_OPEN_MODE

    ''' <summary>
    ''' ���F�񍐏�ID
    ''' </summary>
    Public Enum ENM_SYONIN_HOKOKU_ID
        _1_NCR = 1
        _2_CAR = 2
    End Enum

    ''' <summary>
    ''' NCR�X�e�[�W
    ''' </summary>
    Public Enum ENM_NCR_STAGE
        _10_�N������ = 10
        _20_�N���m�F����GL = 20
        _30_�N���m�F���� = 30
        _40_���O�R������y��CAR�v�۔��� = 40
        _50_���O�R���m�F = 50
        _60_�ĐR�R������_�Z�p��\ = 60
        _61_�ĐR�R������_�i�ؑ�\ = 61
        _70_�ڋq�ĐR���u_I_tag = 70
        _80_���u���{ = 80
        _81_���u���{_���Z = 81
        _82_���u���{_���� = 82
        _83_���u���{_���� = 83
        _90_���u���{�m�F_�Ǘ�T = 90
        _100_���u���{����_�����ے� = 100
        _110_abcde���u�S�� = 110
        _120_abcde���u�m�F = 120
        _990_Closed = 990
    End Enum

    ''' <summary>
    ''' CAR�X�e�[�W
    ''' </summary>
    Public Enum ENM_CAR_STAGE
        _10_�N������ = 10
        _20_�N���m�F_�N����GL = 20
        _30_�N���m�F_�S���ے� = 30
        _40_�N���m�F_���Y�Z�p = 40
        _50_�N���m�F_�݌v�J�� = 50
        _60_�N���m�F_������ = 60
        _70_�N���m�F_�i�؉ے� = 70
        _80_���u���{�L�^���� = 80
        _90_���u���{�m�F = 90
        _100_�����L�����L�� = 100
        _110_�����L�����m�F_����GL = 110
        _120_�����L�����m�F_�i��TL = 120
        _130_�����L�����m�F_�i�ؒS���ے� = 130
        _990_Closed = 990

    End Enum

    ''' <summary>
    ''' �������͋敪
    ''' </summary>
    Public Enum ENM_GENIN_BUNSEKI_KB
        _0_m_�}�l�W�����g = 0
        _1_S_�\�t�g�E�F�A = 1
        _2_h_�n�[�h�E�F�A = 2
        _3_e_��Ɗ� = 3
        _4_L1_�{�l = 4
        _5_L2_�֌W��_�x���̐� = 5
        _11_�ޗ� = 11
        _12_�ݔ�_���� = 12
        _13_���@ = 13
    End Enum

    ''' <summary>
    ''' ���F����敪
    ''' </summary>
    Public Enum ENM_SYONIN_HANTEI_KB
        _0_�����F = 0
        _1_���F = 1
    End Enum

    ''' <summary>
    ''' �񍐏�����敪
    ''' </summary>
    Public Enum ENM_HOKOKUSYO_SOUSA_KB
        _0_�N�� = 0
        _1_�\�����F�˗� = 1
        _2_�X�V�ۑ� = 2
    End Enum

    ''' <summary>
    ''' ���O�R������敪
    ''' </summary>
    Public Enum ENM_JIZEN_SINSA_HANTEI_KB
        _0_�������� = 0
        _1_���̂܂܎g�p�� = 1
        _2_�ĐR�ψ���� = 2
        _3_�ڋq�ĐR�\�� = 3
        _4_�p�p���� = 4
        _5_�ԋp���� = 5
        _6_�]�p���� = 6
        _7_�ĉ��H���� = 7
    End Enum

    ''' <summary>
    ''' �ĐR�ψ����敪
    ''' </summary>
    Public Enum ENM_SAISIN_IINKAI_HANTEI_KB
        _0_�������� = 0
        _1_���̂܂܎g�p�� = 1
        _2_�ڋq�ĐR�\�� = 2
        _3_�p�p���� = 3
        _4_�ԋp���� = 4
        _5_�]�p���� = 5
        _6_�ĉ��H���� = 6
    End Enum

    Public Enum ENM_FUTEKIGO_JYOTAI_KB
        _0_�ŏI���i = 0
        _1_�d�|�i = 1
        _2_�ޗ� = 2
        _3_�ԋp�i = 3
    End Enum

    'Model
    Public _D003_NCR_J As New MODEL.D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New MODEL.D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New MODEL.D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of MODEL.D006_CAR_GENIN)
    Public _R001_HOKOKU_SOUSA As New MODEL.R001_HOKOKU_SOUSA

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

                '-----PG�ݒ�t�@�C���Ǎ�����
                If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                    Exit Sub
                End If

                '-----�o�͐�ݒ�t�@�C���Ǎ�����
                If FunGetOutputIniFile() = False Then
                    MsgBox(My.Resources.ErrLogMsgSetOutput, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----Visual�X�^�C���L��
                Application.EnableVisualStyles()
                '-----GDI���g�p
                Application.SetCompatibleTextRenderingDefault(False)

                '-----���ʃf�[�^�擾
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "NCR", tblNCR)
                    Call FunGetCodeDataTable(DB, "CAR", tblCAR)
                    'UNDONE: �X�e�[�W�ʂ̒S���Ҏ擾�ɒu������
                    Call FunGetCodeDataTable(DB, "�S��", tblTANTO)
                    Call FunGetCodeDataTable(DB, "����敪", tblBUMON, "DISP_ORDER < 10")
                    Call FunGetCodeDataTable(DB, "�@��", tblKISYU)
                    Call FunGetCodeDataTable(DB, "�s�K���敪", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "�s�K����ԋ敪", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "���O�R������敪", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�ĐR�ψ����敪", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "���i�ԍ�", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "�Г�CD", tblSYANAI_CD)

                    Call FunGetCodeDataTable(DB, "���F�S��", tblTANTO_SYONIN)
                    Call FunGetCodeDataTable(DB, "�ڋq����w���敪", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "�ڋq�ŏI����敪", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�v�ۋ敪", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "�������ʋ敪", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "���{�v���敪", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "�A�ӍH���敪", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "�������͋敪", tblGENIN_BUNSEKI_KB)

                    Call FunGetCodeDataTable(DB, "�ݖ���e", tblSETUMON_NAIYO)
                End Using

                '�N�����p�����[�^���擾
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs
                If cmds.Length = 3 Then
                    pub_intOPEN_MODE = Val(cmds(2))
                Else
                    pub_intOPEN_MODE = ENM_OPEN_MODE._0_�ʏ�
                End If

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmG0010
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        Finally

        End Try
    End Sub
#End Region

#Region "ST02 �s�K���񍐏��ꗗ"

    ''' <summary>
    ''' �����̌����������ꗗ�擾�X�g�A�h�ɓn���Č������ʂ̃e�[�u���f�[�^���擾
    ''' </summary>
    ''' <param name="ParamModel"></param>
    ''' <returns></returns>
    Public Function FunGetDtST02_FUTEKIGO_ICHIRAN(ByVal ParamModel As ST02_ParamModel) As DataTable

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
        sbParam.Append(",'" & ParamModel._VISIBLE_CLOSE & "'")
        sbParam.Append(",'" & ParamModel._VISIBLE_TAIRYU & "'")
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


        sbSQL.Append("EXEC dbo." & NameOf(MODEL.ST02_FUTEKIGO_ICHIRAN) & " " & sbParam.ToString & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList?.Tables(0)
    End Function


    Public Function FunGetV002Model(ByVal strHOKOKU_NO As String) As MODEL.V002_NCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V002_NCR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V002_NCR_J
            With dsList.Tables(0).Rows(0)
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_NAME = .Item(NameOf(_model.BUHIN_NAME))
                _model.FUTEKIGO_JYOTAI_KB = .Item(NameOf(_model.FUTEKIGO_JYOTAI_KB))
                _model.FUTEKIGO_NAIYO = .Item(NameOf(_model.FUTEKIGO_NAIYO))
                _model.GOKI = .Item(NameOf(_model.GOKI))
                _model.HAIKYAKU_HOUHOU = .Item(NameOf(_model.HAIKYAKU_HOUHOU))
                _model.HAIKYAKU_KB_NAME = .Item(NameOf(_model.HAIKYAKU_KB_NAME))
                _model.HAIKYAKU_TANTO_NAME = .Item(NameOf(_model.HAIKYAKU_TANTO_NAME))
                _model.HAIKYAKU_YMD = .Item(NameOf(_model.HAIKYAKU_YMD))
                '_model.HASSEI_KOTEI_GL_NAME = .Item(NameOf(_model.HASSEI_KOTEI_GL_NAME))
                '_model.HASSEI_KOTEI_GL_YMD = .Item(NameOf(_model.HASSEI_KOTEI_GL_YMD))
                _model.HENKYAKU_BIKO = .Item(NameOf(_model.HENKYAKU_BIKO))
                _model.HENKYAKU_TANTO_NAME = .Item(NameOf(_model.HENKYAKU_TANTO_NAME))
                _model.HENKYAKU_YMD = .Item(NameOf(_model.HENKYAKU_YMD))
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                _model.ITAG_NO = .Item(NameOf(_model.ITAG_NO))
                _model.JIZEN_SINSA_HANTEI_KB = .Item(NameOf(_model.JIZEN_SINSA_HANTEI_KB))
                _model.JIZEN_SINSA_SYAIN_NAME = .Item(NameOf(_model.JIZEN_SINSA_SYAIN_NAME))
                _model.JIZEN_SINSA_YMD = .Item(NameOf(_model.JIZEN_SINSA_YMD))
                _model.KANSATU_KEKKA = .Item(NameOf(_model.KANSATU_KEKKA))
                _model.KENSA_KEKKA_NAME = .Item(NameOf(_model.KENSA_KEKKA_NAME))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KISYU = .Item(NameOf(_model.KISYU))
                _model.KOKYAKU_HANTEI_SIJI_NAME = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_NAME))
                _model.KOKYAKU_HANTEI_SIJI_YMD = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_YMD))
                _model.SAIHATU = .Item(NameOf(_model.SAIHATU))
                _model.SAIKAKO_KENSA_YMD = .Item(NameOf(_model.SAIKAKO_KENSA_YMD))
                _model.SAIKAKO_SAGYO_KAN_YMD = .Item(NameOf(_model.SAIKAKO_SAGYO_KAN_YMD))
                _model.SAIKAKO_SIJI_NO = .Item(NameOf(_model.SAIKAKO_SIJI_NO))
                _model.SAISIN_GIJYUTU_SYAIN_NAME = .Item(NameOf(_model.SAISIN_GIJYUTU_SYAIN_NAME))
                _model.SAISIN_HINSYO_SYAIN_NAME = .Item(NameOf(_model.SAISIN_HINSYO_SYAIN_NAME))
                _model.SAISIN_HINSYO_YMD = .Item(NameOf(_model.SAISIN_HINSYO_YMD))
                _model.SAISIN_IINKAI_HANTEI_KB = .Item(NameOf(_model.SAISIN_IINKAI_HANTEI_KB))
                _model.SAISIN_IINKAI_SIRYO_NO = .Item(NameOf(_model.SAISIN_IINKAI_SIRYO_NO))
                _model.SAISIN_KAKUNIN_SYAIN_NAME = .Item(NameOf(_model.SAISIN_KAKUNIN_SYAIN_NAME))
                _model.SAISIN_KAKUNIN_YMD = .Item(NameOf(_model.SAISIN_KAKUNIN_YMD))
                _model.SEIGI_TANTO_NAME = .Item(NameOf(_model.SEIGI_TANTO_NAME))
                _model.SEIZO_TANTO_NAME = .Item(NameOf(_model.SEIZO_TANTO_NAME))
                _model.SURYO = .Item(NameOf(_model.SURYO))
                _model.SYOCHI_D_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_D_SYOCHI_KIROKU))
                _model.SYOCHI_D_UMU_NAME = .Item(NameOf(_model.SYOCHI_D_UMU_NAME))
                _model.SYOCHI_D_YOHI_NAME = .Item(NameOf(_model.SYOCHI_D_YOHI_NAME))
                _model.SYOCHI_E_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_E_SYOCHI_KIROKU))
                _model.SYOCHI_E_UMU_NAME = .Item(NameOf(_model.SYOCHI_E_UMU_NAME))
                _model.SYOCHI_E_YOHI_NAME = .Item(NameOf(_model.SYOCHI_E_YOHI_NAME))
                _model.TENYO_BUHIN_BANGO = .Item(NameOf(_model.TENYO_BUHIN_BANGO))
                _model.TENYO_GOKI = .Item(NameOf(_model.TENYO_GOKI))
                _model.TENYO_KISYU = .Item(NameOf(_model.TENYO_KISYU))
                _model.TENYO_YMD = .Item(NameOf(_model.TENYO_YMD))
                _model.YOKYU_NAIYO = .Item(NameOf(_model.YOKYU_NAIYO))
                _model.ZUMEN_KIKAKU = .Item(NameOf(_model.ZUMEN_KIKAKU))

            End With

            Return _model
        End If




    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As MODEL.V003_SYONIN_J_KANRI

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID = " & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V003_SYONIN_J_KANRI
            With dsList.Tables(0).Rows(0)
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                _model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))


            End With

            Return _model
        End If




    End Function
#End Region

#Region "���[�����M"

    Public Function FunSendMailFutekigo(ByVal strSubject As String, ByVal strBody As String, ByVal ToSYAIN_ID As Integer) As Boolean
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim strToAddress As String
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean

        Using DB As ClsDbUtility = DBOpen()
            strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
            intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
            strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")
            'strUserID = FunGetCodeMastaValue("���[���ݒ�", "SMTP_USER")
            'strPassword = FunGetCodeMastaValue("���[���ݒ�", "SMTP_PASS")


            '---�\����S���҂̃��[���A�h���X�擾
            Dim sbSQL As New System.Text.StringBuilder
            Dim dsList As New DataSet
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT")
            sbSQL.Append(" MAIL_ADDRESS")
            sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
            sbSQL.Append(" WHERE SYAIN_ID=" & ToSYAIN_ID & "")
            Using DBa As ClsDbUtility = DBOpen()
                dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using
            If dsList.Tables(0).Rows.Count > 0 Then
                strToAddress = dsList.Tables(0).Rows(0).Item(0)
            Else
                Return False
            End If

        End Using

        'DEBUG: mail���M����
        Return True


        '�F�؂Ȃ�
        blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                       intSmtpPort,
                       strFromAddress,
                       strToAddress,
                       CCAddress:=strFromAddress,
                       BCCAddress:="",
                       strSubject:=strSubject,
                       strBody:=strBody,
                       strAttachment:="",
                       strFromName:="�s�K���Ǘ��V�X�e��")

        '�F�؂���
        'blnSend = ClsMailSend.FunSendMailoverAUTH(strSmtpServer,
        '               intSmtpPort,
        '               strUserID,
        '               strPassword,
        '               strFromAddress,
        '               strToAddress,
        '               strSubject,
        '               "�^�C���J�[�h�W�v",
        '               strSendFilePath)

        Return blnSend

    End Function

#End Region

End Module
