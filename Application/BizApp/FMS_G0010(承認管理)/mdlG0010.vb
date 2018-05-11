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

                    Call FunGetCodeDataTable(DB, "���F�S��", tblTANTO_SYONIN)
                    Call FunGetCodeDataTable(DB, "�ڋq����w���敪", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "�ڋq�ŏI����敪", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�v�ۋ敪", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "�������ʋ敪", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "���{�v���敪", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "�A�ӍH���敪", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "�������͋敪", tblGENIN_BUNSEKI_KB)
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

End Module
