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
        _9_���� = 9
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
                    Call FunGetCodeDataTable(DB, "�@�����", tblKISYU_J)

                    Call FunGetCodeDataTable(DB, "�s�K���敪", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "�s�K����ԋ敪", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "���O�R������敪", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�ĐR�ψ����敪", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "���i�ԍ�", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "���i�ԍ�����", tblBUHIN_J)
                    Call FunGetCodeDataTable(DB, "�Г�CD", tblSYANAI_CD)
                    Call FunGetCodeDataTable(DB, "�Г�CD����", tblSYANAI_CD_J)

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
                    Call FunGetCodeDataTable(DB, "���F����敪", tblSYONIN_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "�p�p���@�敪", tblHAIKYAKU_KB)

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
                 Reflection.BindingFlags.Static)

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        _model(p.Name) = .Item(p.Name)
                    End If
                Next p
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
                         Reflection.BindingFlags.Static)

            Dim entities As New List(Of MODEL.V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New MODEL.V003_SYONIN_J_KANRI
                    For Each p As Reflection.PropertyInfo In properties
                        If IsAutoGenerateField(t, p.Name) = True Then
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
                        End If
                    Next p
                    entities.Add(_model)
                End With
            Next row

            Return entities
        End If
    End Function

    Public Function FunGetV004Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As MODEL.V004_HOKOKU_SOUSA

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V004_HOKOKU_SOUSA) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V004_HOKOKU_SOUSA
            Dim t As Type = GetType(MODEL.V004_HOKOKU_SOUSA)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        _model(p.Name) = .Item(p.Name)
                    End If
                Next p
            End With

            Return _model
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

    ''' <summary>
    ''' ���݂̃X�e�[�W�����擾
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
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

            Dim drList As List(Of DataRow) = tblCAR.AsEnumerable().
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
                    strFromAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
#If DEBUG Then
                    'strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")
                    'DEBUG: mail���M����
                    'strToAddress = "funato@jms-web.co.jp"
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
            'Return True

            ''�F�؂Ȃ�
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
            '               strFromAddress,
            '               "",
            '               strSubject,
            '               strBody,
            '               "",
            '               "�s�K���Ǘ��V�X�e��")

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

#Region "���F�����Ј��擾"
    'TV03_SYONIN_SYAIN

    Public Function FunGetSYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional BUSYO_ID As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV03_SYOZOKU_SYAIN('" & BUMON_KB & "')")
        If BUSYO_ID > 0 Then
            sbSQL.Append(" WHERE BUSYO_ID=" & BUSYO_ID & "")
        End If
        sbSQL.Append(" ORDER BY SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

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

#Region "���|�[�g�o��"

    Public Function FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet


        Try

            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of MODEL.V003_SYONIN_J_KANRI) = FunGetV003Model(ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            '���R�[�h�t���[��������
            'spWork.Range("RECORD_FRAME").ClearContents()
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = "(���̑��̓��e�F" & _V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30) & ")"
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
            If Not _V002_NCR_J.HAIKYAKU_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HAIKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_NAME
            If Not _V002_NCR_J.HASSEI_KOTEI_GL_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HASSEI_KOTEI_GL_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
            If Not _V002_NCR_J.HENKYAKU_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HENKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            If Not _V002_NCR_J.JIZEN_SINSA_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.JIZEN_SINSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU)).Value = _V002_NCR_J.KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
            If Not _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU
            If Not _V002_NCR_J.SAIKAKO_KENSA_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_KENSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
            If Not _V002_NCR_J.SAISIN_HINSYO_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_HINSYO_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            If Not _V002_NCR_J.SAISIN_KAKUNIN_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU)).Value = _V002_NCR_J.TENYO_KISYU
            ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = _V002_NCR_J.TENYO_YMD
            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = "(�}��/�K�i�@�F " & _V002_NCR_J.ZUMEN_KIKAKU.PadRight(50) & ")"

            ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._10_�N������).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).FirstOrDefault?.SYAIN_NAME



            Dim strYMDHNS As String
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._20_�N���m�F����GL).Value = "'" & DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._20_�N���m�F����GL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F���� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._30_�N���m�F����).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._30_�N���m�F����).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F����).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._100_���u���{����_�����ے�).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._100_���u���{����_�����ے�).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے�).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S�� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._110_abcde���u�S��).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._110_abcde���u�S��).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S��).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._120_abcde���u�m�F).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde���u�m�F).FirstOrDefault?.UPD_SYAIN_NAME


            '�摜�\��
            Dim top As Double
            Dim left As Double
            Dim width As Double
            Dim height As Double
            If Not _V002_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Using img = Image.FromFile(_V002_NCR_J.G_FILE_PATH1)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '���s��
                    top = windowInfo.RowToPoints(7.2)
                    '�����
                    left = windowInfo.ColumnToPoints(9.2)

                    width = windowInfo.ColumnToPoints(5.5) 'img.Width * 72 / img.HorizontalResolution
                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                End Using
                ssgSheet1.Shapes.AddPicture(_V002_NCR_J.G_FILE_PATH1, left, top, width, height)
            End If

            If Not _V002_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Using img = Image.FromFile(_V002_NCR_J.G_FILE_PATH2)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '���s��
                    top = windowInfo.RowToPoints(7.2 + 9)
                    '�����
                    left = windowInfo.ColumnToPoints(9.2)

                    width = windowInfo.ColumnToPoints(5.5) 'img.Width * 72 / img.HorizontalResolution
                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                End Using
                ssgSheet1.Shapes.AddPicture(_V002_NCR_J.G_FILE_PATH2, left, top, width, height)
            End If

            '-----�t�@�C���ۑ�
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire�� ����PDF���s����Ȃ炱����
            Dim workbook As New Spire.Xls.Workbook
            workbook.LoadFromFile(strFilePath)
            Dim pdfFilePath As String
            pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''PDF�\��
            System.Diagnostics.Process.Start(pdfFilePath)

            'Excel�N��
            'Return FunOpenExcelApp(strFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                'System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

    Public Function FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim _V005_CAR_J As MODEL.V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3
            If Not _V005_CAR_J.KAITO_4.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_4, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = _V005_CAR_J.KAITO_5
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            If Not _V005_CAR_J.KAITO_8.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_8, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_9.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_9, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = _V005_CAR_J.KAITO_10
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            If Not _V005_CAR_J.KAITO_13.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_13, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_14.IsNullOrWhiteSpace AndAlso CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            If Not _V005_CAR_J.KAITO_16.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_16, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = _V005_CAR_J.KAITO_17
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            If Not _V005_CAR_J.KAITO_20.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_20, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            '���󖢎g�p�̃t�B�[���h
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_23)).Value = _V005_CAR_J.KAITO_23
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_24)).Value = _V005_CAR_J.KAITO_24
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_25)).Value = _V005_CAR_J.KAITO_25

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            If Not _V005_CAR_J.KENSA_GL_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_GL_YMDHNS, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            If Not _V005_CAR_J.KENSA_TOROKU_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_TOROKU_YMDHNS, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU)).Value = _V005_CAR_J.KISYU
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_A_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_A_YMDHNS, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_B_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_B_YMDHNS, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME10)).Value = _V005_CAR_J.SYONIN_NAME10
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME20)).Value = _V005_CAR_J.SYONIN_NAME20
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME30)).Value = _V005_CAR_J.SYONIN_NAME30
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME40)).Value = _V005_CAR_J.SYONIN_NAME40
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME50)).Value = _V005_CAR_J.SYONIN_NAME50
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME60)).Value = _V005_CAR_J.SYONIN_NAME60
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME90)).Value = _V005_CAR_J.SYONIN_NAME90
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME100)).Value = _V005_CAR_J.SYONIN_NAME100
            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME120)).Value = _V005_CAR_J.SYONIN_NAME120

            If Not _V005_CAR_J.SYONIN_YMD20.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD20)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD20, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD30.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD30)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD30, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD40.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD40)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD40, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD50.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD50)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD50, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD60.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD60)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD60, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD90.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD90)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD90, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD100.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD100)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD100, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD120.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD120)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD120, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '-----�t�@�C���ۑ�
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            '-----Spire�� ����PDF���s����Ȃ炱����
            Dim workbook As New Spire.Xls.Workbook
            workbook.LoadFromFile(strFilePath)
            Dim pdfFilePath As String
            pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)

            ''PDF�\��
            System.Diagnostics.Process.Start(pdfFilePath)

            'Excel�N��
            'Return FunOpenExcelApp(strFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                'System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

        End Try
    End Function

#End Region

#End Region





End Module
