Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' �N�����[�h(0:�ʏ�,1:�V�K�쐬)
    ''' </summary>
    Public pub_intOPEN_MODE As Integer

    Public pub_PrSYONIN_HOKOKUSYO_ID As Integer
    Public pub_PrHOKOKU_NO As String

#Region "�񋓌^"
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

    Public Enum ENM_SAVE_MODE
        _1_�ۑ� = 1
        _2_���F�\�� = 2
    End Enum


    ''' <summary>
    ''' ���F�񍐏�ID
    ''' </summary>
    Public Enum ENM_SYONIN_HOKOKUSYO_ID
        _1_NCR = 1
        _2_CAR = 2
    End Enum

    ''' <summary>
    ''' �������ʋ敪
    ''' </summary>
    Public Enum ENM_KENSA_KEKKA_KB
        _0_���i = 0
        _1_�s���i = 1
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

    ''' <summary>
    ''' �ڋq�ŏI����敪
    ''' </summary>
    Public Enum ENM_KOKYAKU_SAISYU_HANTEI_KB
        _0_�������� = 0
        _1_���̂܂܎g�p�� = 1
        _2_�ڋq�ĐR�\�� = 2
        _3_�p�p���� = 3
        _4_�ԋp���� = 4
        _5_�]�p���� = 5
        _6_�ĉ��H���� = 6
    End Enum

    ''' <summary>
    ''' �s�K����ԋ敪
    ''' </summary>
    Public Enum ENM_FUTEKIGO_JYOTAI_KB
        _0_�ŏI���i = 0
        _1_�d�|�i = 1
        _2_�ޗ� = 2
        _3_�ԋp�i = 3
    End Enum

    ''' <summary>
    ''' �v�ۋ敪
    ''' </summary>
    Public Enum ENM_YOHI_KB
        _0_�� = 0
        _1_�v = 1
    End Enum

    ''' <summary>
    ''' ���𑀍�敪
    ''' </summary>
    Public Enum ENM_SOUSA_KB
        _0_�V�K�쐬 = 0
        _1_�\���˗� = 1
        _2_�X�V�ۑ� = 2
        _3_���F���� = 3
        _4_���[�����M = 4
        _5_�]�� = 5
    End Enum


    Public Enum ENM_SYOUNIN_HANTEI_KB
        _0_�����F = 0
        _1_���F = 1
        _9_���� = 9
    End Enum

#End Region

#Region "Model"
    Public _D003_NCR_J As New MODEL.D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New MODEL.D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New MODEL.D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of MODEL.D006_CAR_GENIN)
    Public _R001_HOKOKU_SOUSA As New MODEL.R001_HOKOKU_SOUSA
    Public _R002_HOKOKU_TENSO As New MODEL.R002_HOKOKU_TENSO
    Public _R003_NCR_SASIMODOSI As New MODEL.R003_NCR_SASIMODOSI
    Public _R004_CAR_SASIMODOSI As New MODEL.R004_CAR_SASIMODOSI
#End Region

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
                    Call FunGetCodeDataTable(DB, "�S��", tblTANTO)
                    Call FunGetCodeDataTable(DB, "����敪", tblBUMON, "DISP_ORDER < 10") '10�ȍ~�͕s�K��SYS�ł͕s�v
                    Call FunGetCodeDataTable(DB, "�@��", tblKISYU)
                    Call FunGetCodeDataTable(DB, "�s�K���敪", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "�s�K����ԋ敪", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "���O�R������敪", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�ĐR�ψ����敪", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "���i�ԍ�", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "�Г�CD", tblSYANAI_CD)

                    Call FunGetCodeDataTable(DB, "���F�S��", tblTANTO_SYONIN)
                    'Call FunGetCodeDataTable(DB, "���F�S���ꗗ", tblTANTO_SYONINList)
                    Call FunGetCodeDataTable(DB, "�ڋq����w���敪", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "�ڋq�ŏI����敪", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�v�ۋ敪", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "�������ʋ敪", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "���{�v���敪", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "�A�ӍH���敪", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "�������͋敪", tblGENIN_BUNSEKI_KB)

                    Call FunGetCodeDataTable(DB, "�ݖ���e", tblSETUMON_NAIYO)

                    Call FunGetCodeDataTable(DB, "�p�p���@", tblHAIKYAKU_KB)

                    Call FunGetCodeDataTable(DB, "���F����敪", tblSYONIN_HANTEI_KB)

                End Using

                '�N�����p�����[�^���擾
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 5 Then
                    '���[�������N�p 
                    pub_PrHOKOKU_NO = Val(cmds(4))
                    pub_PrSYONIN_HOKOKUSYO_ID = Val(cmds(3))
                ElseIf cmds.Length = 3 Then
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

#Region "���ʊ֐�"

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
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_CLOSE = 1, "", ParamModel._VISIBLE_CLOSE) & "'")
        sbParam.Append(",'" & IIf(ParamModel._VISIBLE_TAIRYU = 1, ParamModel._VISIBLE_TAIRYU, "") & "'")
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
            Dim t As Type = GetType(MODEL.V002_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    _model(p.Name) = .Item(p.Name)
                Next p

                '_model.ADD_SYAIN_ID = .Item(NameOf(_model.ADD_SYAIN_ID))
                '_model.ADD_SYAIN_NAME = .Item(NameOf(_model.ADD_SYAIN_NAME))
                '_model.ADD_YMDHNS = .Item(NameOf(_model.ADD_YMDHNS))
                '_model.BUMON_KB = .Item(NameOf(_model.BUMON_KB))
                '_model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME))
                '_model.BUHIN_BANGO = .Item(NameOf(_model.BUHIN_BANGO))
                '_model.BUHIN_NAME = .Item(NameOf(_model.BUHIN_NAME))
                '_model.FUTEKIGO_JYOTAI_KB = .Item(NameOf(_model.FUTEKIGO_JYOTAI_KB))
                '_model.FUTEKIGO_NAIYO = .Item(NameOf(_model.FUTEKIGO_NAIYO))
                '_model.GOKI = .Item(NameOf(_model.GOKI))
                '_model.HAIKYAKU_HOUHOU = .Item(NameOf(_model.HAIKYAKU_HOUHOU))
                '_model.HAIKYAKU_KB_NAME = .Item(NameOf(_model.HAIKYAKU_KB_NAME))
                '_model.HAIKYAKU_TANTO_NAME = .Item(NameOf(_model.HAIKYAKU_TANTO_NAME))
                '_model.HAIKYAKU_YMD = .Item(NameOf(_model.HAIKYAKU_YMD))
                '_model.HASSEI_KOTEI_GL_NAME = .Item(NameOf(_model.HASSEI_KOTEI_GL_NAME))
                '_model.HASSEI_KOTEI_GL_YMD = .Item(NameOf(_model.HASSEI_KOTEI_GL_YMD))
                '_model.HENKYAKU_BIKO = .Item(NameOf(_model.HENKYAKU_BIKO))
                '_model.HENKYAKU_TANTO_NAME = .Item(NameOf(_model.HENKYAKU_TANTO_NAME))
                '_model.HENKYAKU_YMD = .Item(NameOf(_model.HENKYAKU_YMD))
                '_model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                '_model.ITAG_NO = .Item(NameOf(_model.ITAG_NO))
                '_model.JIZEN_SINSA_HANTEI_KB = .Item(NameOf(_model.JIZEN_SINSA_HANTEI_KB))
                '_model.JIZEN_SINSA_SYAIN_NAME = .Item(NameOf(_model.JIZEN_SINSA_SYAIN_NAME))
                '_model.JIZEN_SINSA_YMD = .Item(NameOf(_model.JIZEN_SINSA_YMD))
                '_model.KANSATU_KEKKA = .Item(NameOf(_model.KANSATU_KEKKA))
                '_model.KENSA_KEKKA_NAME = .Item(NameOf(_model.KENSA_KEKKA_NAME))
                '_model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                '_model.KISYU = .Item(NameOf(_model.KISYU))
                '_model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                '_model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME))
                '_model.KOKYAKU_HANTEI_SIJI_NAME = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_NAME))
                '_model.KOKYAKU_HANTEI_SIJI_YMD = .Item(NameOf(_model.KOKYAKU_HANTEI_SIJI_YMD))
                '_model.SAIHATU = .Item(NameOf(_model.SAIHATU))
                '_model.SAIKAKO_KENSA_YMD = .Item(NameOf(_model.SAIKAKO_KENSA_YMD))
                '_model.SAIKAKO_SAGYO_KAN_YMD = .Item(NameOf(_model.SAIKAKO_SAGYO_KAN_YMD))
                '_model.SAIKAKO_SIJI_NO = .Item(NameOf(_model.SAIKAKO_SIJI_NO))
                '_model.SAISIN_GIJYUTU_SYAIN_NAME = .Item(NameOf(_model.SAISIN_GIJYUTU_SYAIN_NAME))
                '_model.SAISIN_HINSYO_SYAIN_NAME = .Item(NameOf(_model.SAISIN_HINSYO_SYAIN_NAME))
                '_model.SAISIN_HINSYO_YMD = .Item(NameOf(_model.SAISIN_HINSYO_YMD))
                '_model.SAISIN_IINKAI_HANTEI_KB = .Item(NameOf(_model.SAISIN_IINKAI_HANTEI_KB))
                '_model.SAISIN_IINKAI_SIRYO_NO = .Item(NameOf(_model.SAISIN_IINKAI_SIRYO_NO))
                '_model.SAISIN_KAKUNIN_SYAIN_NAME = .Item(NameOf(_model.SAISIN_KAKUNIN_SYAIN_NAME))
                '_model.SAISIN_KAKUNIN_YMD = .Item(NameOf(_model.SAISIN_KAKUNIN_YMD))
                '_model.SEIGI_TANTO_NAME = .Item(NameOf(_model.SEIGI_TANTO_NAME))
                '_model.SEIZO_TANTO_NAME = .Item(NameOf(_model.SEIZO_TANTO_NAME))
                '_model.SURYO = .Item(NameOf(_model.SURYO))
                '_model.SYOCHI_D_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_D_SYOCHI_KIROKU))
                '_model.SYOCHI_D_UMU_NAME = .Item(NameOf(_model.SYOCHI_D_UMU_NAME))
                '_model.SYOCHI_D_YOHI_NAME = .Item(NameOf(_model.SYOCHI_D_YOHI_NAME))
                '_model.SYOCHI_E_SYOCHI_KIROKU = .Item(NameOf(_model.SYOCHI_E_SYOCHI_KIROKU))
                '_model.SYOCHI_E_UMU_NAME = .Item(NameOf(_model.SYOCHI_E_UMU_NAME))
                '_model.SYOCHI_E_YOHI_NAME = .Item(NameOf(_model.SYOCHI_E_YOHI_NAME))
                '_model.TENYO_BUHIN_BANGO = .Item(NameOf(_model.TENYO_BUHIN_BANGO))
                '_model.TENYO_GOKI = .Item(NameOf(_model.TENYO_GOKI))
                '_model.TENYO_KISYU = .Item(NameOf(_model.TENYO_KISYU))
                '_model.TENYO_YMD = .Item(NameOf(_model.TENYO_YMD))
                '_model.YOKYU_NAIYO = .Item(NameOf(_model.YOKYU_NAIYO))
                '_model.ZUMEN_KIKAKU = .Item(NameOf(_model.ZUMEN_KIKAKU))

            End With

            Return _model
        End If




    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As List(Of MODEL.V003_SYONIN_J_KANRI)

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
            Dim t As Type = GetType(MODEL.V003_SYONIN_J_KANRI)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                         Reflection.BindingFlags.Public Or
                         Reflection.BindingFlags.Instance Or
                         Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            Dim entities As New List(Of MODEL.V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New MODEL.V003_SYONIN_J_KANRI
                    For Each p As Reflection.PropertyInfo In properties

                        Select Case p.PropertyType
                            Case GetType(Integer)
                                _model(p.Name) = row.Item(p.Name)
                            Case GetType(Decimal)
                                _model(p.Name) = CDec(row.Item(p.Name))
                            Case GetType(Boolean)
                                _model(p.Name) = CBool(row.Item(p.Name))

                            Case GetType(Date), GetType(DateTime)
                                If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                    Select Case row.Item(p.Name).ToString.Length
                                        Case 8 'yyyyMMdd
                                            _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                        Case 14 'yyyyMMddHHmmss
                                            _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                        Case Else
                                            'Err
                                            _model(p.Name) = Nothing
                                    End Select
                                End If
                            Case Else
                                _model(p.Name) = row.Item(p.Name).ToString.Trim
                        End Select
                    Next p
                    entities.Add(_model)
                End With
            Next row

            Return entities
        End If
    End Function

    Public Function FunGetV005Model(ByVal strHOKOKU_NO As String) As MODEL.V005_CAR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V005_CAR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V005_CAR_J
            With dsList.Tables(0).Rows(0)
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                _model.BUMON_KB = .Item(NameOf(_model.BUMON_KB))
                _model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME))
                _model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                _model.KISYU = .Item(NameOf(_model.KISYU))
                _model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME))
                _model.CLOSE_FG = CBool(.Item(NameOf(_model.CLOSE_FG)))
                _model.KAITO_1 = .Item(NameOf(_model.KAITO_1))
                _model.KAITO_2 = .Item(NameOf(_model.KAITO_2))
                _model.KAITO_3 = .Item(NameOf(_model.KAITO_3))
                _model.KAITO_4 = .Item(NameOf(_model.KAITO_4))
                _model.KAITO_5 = .Item(NameOf(_model.KAITO_5))
                _model.KAITO_6 = .Item(NameOf(_model.KAITO_6))
                _model.KAITO_7 = .Item(NameOf(_model.KAITO_7))
                _model.KAITO_8 = .Item(NameOf(_model.KAITO_8))
                _model.KAITO_9 = .Item(NameOf(_model.KAITO_9))
                _model.KAITO_10 = .Item(NameOf(_model.KAITO_10))
                _model.KAITO_11 = .Item(NameOf(_model.KAITO_11))
                _model.KAITO_12 = .Item(NameOf(_model.KAITO_12))
                _model.KAITO_13 = .Item(NameOf(_model.KAITO_13))
                _model.KAITO_14 = .Item(NameOf(_model.KAITO_14))
                _model.KAITO_15 = .Item(NameOf(_model.KAITO_15))
                _model.KAITO_16 = .Item(NameOf(_model.KAITO_16))
                _model.KAITO_17 = .Item(NameOf(_model.KAITO_17))
                _model.KAITO_18 = .Item(NameOf(_model.KAITO_18))
                _model.KAITO_19 = .Item(NameOf(_model.KAITO_19))
                _model.KAITO_20 = .Item(NameOf(_model.KAITO_20))
                _model.KAITO_21 = .Item(NameOf(_model.KAITO_21))
                _model.KAITO_22 = .Item(NameOf(_model.KAITO_22))
                _model.KAITO_23 = .Item(NameOf(_model.KAITO_23))
                _model.KAITO_24 = .Item(NameOf(_model.KAITO_24))
                _model.KAITO_25 = .Item(NameOf(_model.KAITO_25))
                _model.KONPON_YOIN_KB1 = .Item(NameOf(_model.KONPON_YOIN_KB1))
                _model.KONPON_YOIN_NAME1 = .Item(NameOf(_model.KONPON_YOIN_NAME1))
                _model.KONPON_YOIN_KB2 = .Item(NameOf(_model.KONPON_YOIN_KB2))
                _model.KONPON_YOIN_NAME2 = .Item(NameOf(_model.KONPON_YOIN_NAME2))
                _model.KONPON_YOIN_SYAIN_ID = .Item(NameOf(_model.KONPON_YOIN_SYAIN_ID))
                _model.KONPON_YOIN_SYAIN_NAME = .Item(NameOf(_model.KONPON_YOIN_SYAIN_NAME))
                _model.KISEKI_KOTEI_KB = .Item(NameOf(_model.KISEKI_KOTEI_KB))
                _model.KISEKI_KOTEI_NAME = .Item(NameOf(_model.KISEKI_KOTEI_NAME))
                _model.SYOCHI_A_SYAIN_ID = .Item(NameOf(_model.SYOCHI_A_SYAIN_ID))
                _model.SYOCHI_A_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_A_SYAIN_NAME))
                _model.SYOCHI_A_YMDHNS = .Item(NameOf(_model.SYOCHI_A_YMDHNS))
                _model.SYOCHI_B_SYAIN_ID = .Item(NameOf(_model.SYOCHI_B_SYAIN_ID))
                _model.SYOCHI_B_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_B_SYAIN_NAME))
                _model.SYOCHI_B_YMDHNS = .Item(NameOf(_model.SYOCHI_B_YMDHNS))
                _model.SYOCHI_C_SYAIN_ID = .Item(NameOf(_model.SYOCHI_C_SYAIN_ID))
                _model.SYOCHI_C_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_C_SYAIN_NAME))
                _model.SYOCHI_C_YMDHNS = .Item(NameOf(_model.SYOCHI_C_YMDHNS))
                _model.KYOIKU_FILE_PATH = .Item(NameOf(_model.KYOIKU_FILE_PATH))
                _model.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU))
                _model.ZESEI_SYOCHI_YUKO_UMU_NAME = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU_NAME))
                _model.SYOSAI_FILE_PATH = .Item(NameOf(_model.SYOSAI_FILE_PATH))
                _model.GOKI = .Item(NameOf(_model.GOKI))
                _model.LOT = .Item(NameOf(_model.LOT))
                _model.KENSA_TANTO_ID = .Item(NameOf(_model.KENSA_TANTO_ID))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KENSA_TOROKU_YMDHNS = .Item(NameOf(_model.KENSA_TOROKU_YMDHNS))
                _model.KENSA_GL_SYAIN_ID = .Item(NameOf(_model.KENSA_GL_SYAIN_ID))
                _model.KENSA_GL_SYAIN_NAME = .Item(NameOf(_model.KENSA_GL_SYAIN_NAME))
                _model.KENSA_GL_YMDHNS = .Item(NameOf(_model.KENSA_GL_YMDHNS))
                _model.ADD_SYAIN_ID = .Item(NameOf(_model.ADD_SYAIN_ID))
                _model.ADD_SYAIN_NAME = .Item(NameOf(_model.ADD_SYAIN_NAME))
                _model.ADD_YMDHNS = .Item(NameOf(_model.ADD_YMDHNS))
                _model.UPD_SYAIN_ID = .Item(NameOf(_model.UPD_SYAIN_ID))
                _model.UPD_SYAIN_NAME = .Item(NameOf(_model.UPD_SYAIN_NAME))
                _model.UPD_YMDHNS = .Item(NameOf(_model.UPD_YMDHNS))
                _model.DEL_SYAIN_ID = .Item(NameOf(_model.DEL_SYAIN_ID))
                _model.DEL_SYAIN_NAME = .Item(NameOf(_model.DEL_SYAIN_NAME))
                _model.DEL_YMDHNS = .Item(NameOf(_model.DEL_YMDHNS))

                _model.SYONIN_NAME10 = .Item(NameOf(_model.SYONIN_NAME10))
                _model.SYONIN_YMD10 = .Item(NameOf(_model.SYONIN_YMD10))
                _model.SYONIN_NAME20 = .Item(NameOf(_model.SYONIN_NAME20))
                _model.SYONIN_YMD20 = .Item(NameOf(_model.SYONIN_YMD20))
                _model.SYONIN_NAME30 = .Item(NameOf(_model.SYONIN_NAME30))
                _model.SYONIN_YMD30 = .Item(NameOf(_model.SYONIN_YMD30))
                _model.SYONIN_NAME40 = .Item(NameOf(_model.SYONIN_NAME40))
                _model.SYONIN_YMD40 = .Item(NameOf(_model.SYONIN_YMD40))
                _model.SYONIN_NAME50 = .Item(NameOf(_model.SYONIN_NAME50))
                _model.SYONIN_YMD50 = .Item(NameOf(_model.SYONIN_YMD50))
                _model.SYONIN_NAME60 = .Item(NameOf(_model.SYONIN_NAME60))
                _model.SYONIN_YMD60 = .Item(NameOf(_model.SYONIN_YMD60))
                _model.SYONIN_NAME90 = .Item(NameOf(_model.SYONIN_NAME90))
                _model.SYONIN_YMD90 = .Item(NameOf(_model.SYONIN_YMD90))
                _model.SYONIN_NAME100 = .Item(NameOf(_model.SYONIN_NAME100))
                _model.SYONIN_YMD100 = .Item(NameOf(_model.SYONIN_YMD100))
                _model.SYONIN_NAME120 = .Item(NameOf(_model.SYONIN_NAME120))
                _model.SYONIN_YMD120 = .Item(NameOf(_model.SYONIN_YMD120))

            End With

            Return _model
        End If




    End Function

    '���݂̃X�e�[�W�����擾
    Public Function FunGetCurrentStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' ���X�e�[�W�����擾
    ''' </summary>
    ''' <param name="intCurrentStageID">���X�e�[�WID</param>
    ''' <returns></returns>
    Public Function FunGetNextStageName(ByVal intCurrentStageID As Integer) As String
        Try

            Dim drList As List(Of DataRow) = tblNCR.AsEnumerable().
                                                Where(Function(r) Val(r.Field(Of Integer)("VALUE")) > intCurrentStageID).ToList
            Dim strBUFF As String = ""
            If drList.Count > 0 Then
                strBUFF = drList(0).Item("DISP")
            End If

            Return strBUFF
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' ���O�C�����[�U�[�����For�\�������X�e�[�W������
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">���F�񍐏�ID</param>
    ''' <param name="strHOKOKU_NO">�񍐏�No</param>
    ''' <param name="intSYONIN_JUN">���F��No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

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
        Dim strToSyainName As String
        Dim strFromSyainName As String

        Dim strMsg As String
        Try



            Using DB As ClsDbUtility = DBOpen()
                strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")

                '---�\����S���҂̃��[���A�h���X�擾
                Dim sbSQL As New System.Text.StringBuilder
                Dim dsList As New DataSet
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & ToSYAIN_ID & "")
                Using DBa As ClsDbUtility = DBOpen()
                    dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using
                If dsList.Tables(0).Rows.Count > 0 Then
                    strToAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
                    strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                Else
                    Return False
                End If

                '---�\�����S���҂̃��[���A�h���X�擾
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
                Using DBa As ClsDbUtility = DBOpen()
                    dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using
                If dsList.Tables(0).Rows.Count > 0 Then

#If DEBUG Then
                    strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")
                    'DEBUG: mail���M����
                    strToAddress = "funato@jms-web.co.jp"
                    'strToAddress = "i2u5r6p1d7l9o6s3@jms-web.slack.com"
#Else
                    strFromAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
#End If

                    strFromSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                Else
                    Return False
                End If
            End Using


            strMsg = String.Format("�y���[�����M�����zTO:{0}({1}) SUBJECT:{2}", strToSyainName, strToAddress, strSubject)
            WL.WriteLogDat(strMsg)

            'DEBUG:
            Return True


            ''�F�؂Ȃ�
            'blnSend = ClsMailSend.FunSendMail(strSmtpServer,
            '               intSmtpPort,
            '               strFromAddress,
            '               strToAddress,
            '               CCAddress:=strFromAddress,
            '               BCCAddress:="",
            '               strSubject:=strSubject,
            '               strBody:=strBody,
            '               strAttachment:="",
            '               strFromName:="�s�K���Ǘ��V�X�e��")

            '�F�؂���
            blnSend = ClsMailSend.FunSendMailoverAUTH(strSmtpServer,
                           intSmtpPort,
                           strUserID,
                           strPassword,
                           strFromAddress,
                           strToAddress,
                           strFromAddress,
                           "",
                           strSubject,
                           strBody,
                           "",
                           "�s�K���Ǘ��V�X�e��")

            Return blnSend
        Catch ex As Exception
            Throw
            strMsg = String.Format("�y���[�����M���s�zTO:{0}({1}) SUBJECT:{2}" & vbCrLf & Err.Description, strToSyainName, strToAddress, strSubject)
            WL.WriteLogDat(strMsg)
        End Try
    End Function

#End Region

#Region "�Ǘ��Ҍ����m�F"

    Public Function HasAdminAuth(ByVal intSYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.VWM001_SETTING) & " ")
        sbSQL.Append(" WHERE ITEM_NAME='�Ǘ��Ҍ���'")
        sbSQL.Append(" AND ITEM_DISP='" & intSYAIN_ID & "'")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "���F�����Ј��擾"
    'TV02_SYONIN_SYOZOKU_SYAIN

    Public Function FunGetSYONIN_SYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional SYONIN_HOUKOKUSYO_ID As Integer = 0, ByVal Optional SYONIN_JUN As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV02_SYONIN_SYOZOKU_SYAIN('" & BUMON_KB & "')")
        If SYONIN_HOUKOKUSYO_ID > 0 Then
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & SYONIN_HOUKOKUSYO_ID & "")
            sbSQL.Append(" AND SYONIN_JUN=" & SYONIN_JUN & "")
        End If
        sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        'dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        'dt.Columns.Add("SYONIN_JUN", GetType(Integer))

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                If Not dt.Rows.Contains(.Rows(intCNT).Item("SYAIN_ID")) Then
                    Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                    'Trow("DEF_FLG") = False
                    'Trow("DEL_FLG") = False
                    'Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    'Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                    dt.Rows.Add(Trow)
                End If
            Next intCNT
        End With

        Return dt
    End Function

#End Region




End Module
