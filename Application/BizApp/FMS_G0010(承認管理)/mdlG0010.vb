Imports JMS_COMMON.ClsPubMethod
Imports MODEL

Module mdlG0010

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' �N�����[�h
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

        ''' <summary>
        ''' ���[�������N���ŏ��u��ʂ֒��ڑJ��
        ''' </summary>
        _2_���u��ʋN�� = 2

        ''' <summary>
        ''' ���͏W�v(�̂��߂̌���)��ʂ�\��
        ''' </summary>
        _3_���͏W�v = 3

    End Enum

    Public Enum ENM_SAVE_MODE
        _1_�ۑ� = 1
        _2_���F�\�� = 2
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
        _999_Closed = 999
    End Enum

    ''' <summary>
    ''' NCR�X�e�[�Wrev2
    ''' </summary>
    Public Enum ENM_NCR_STAGE2
        _1_�N������ = 1
        _2_�N���m�F����GL = 2
        _3_�N���m�F���� = 3
        _4_���O�R������y��CAR�v�۔��� = 4
        _5_���O�R���m�F = 5
        _6_�ĐR�R������_�Z�p��\ = 6
        _7_�ĐR�R������_�i�ؑ�\ = 7
        _8_�ڋq�ĐR���u_I_tag = 8
        _9_���u���{ = 9
        _10_���u���{_���Z = 10
        _11_���u���{_���� = 11
        _12_���u���{_���� = 12
        _13_���u���{�m�F_�Ǘ�T = 13
        _14_���u���{����_�����ے� = 14
        _15_abcde���u�S�� = 15
        _16_abcde���u�m�F = 16
        _99_Closed = 99
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
        _999_Closed = 999
    End Enum

    ''' <summary>
    ''' �s�K���������ߒ����� �X�e�[�W
    ''' </summary>
    Public Enum ENM_CTS_STAGE
        _10_�N������ = 10
        _20_�N����GL = 20
        _30_�i��_����GL = 30
        _40_�Ǘ�TL = 40
        _50_���ZTL = 50
        _60_�c��TL = 60
        _70_�i�؉ے� = 70
        _80_�����ے� = 80
        _90_���咷 = 90
        _999_Closed = 999
    End Enum

    ''' <summary>
    ''' �s�K���������ߒ����� �X�e�[�W �{�^�����X�g�p
    ''' </summary>
    Public Enum ENM_CTS_STAGE2
        _1_�N������ = 1
        _2_�N����GL = 2
        _3_�i��_����GL = 3
        _4_�Ǘ�TL = 4
        _5_���ZTL = 5
        _6_�c��TL = 6
        _7_�i�؉ے� = 7
        _8_�����ے� = 8
        _9_���咷 = 9
        _99_Closed = 99
    End Enum

    ''' <summary>
    ''' CAR�X�e�[�Wrev2
    ''' </summary>
    Public Enum ENM_CAR_STAGE2
        _1_�N������ = 1
        _2_�N���m�F_�N����GL = 2
        _3_�N���m�F_�S���ے� = 3
        _4_�N���m�F_���Y�Z�p = 4
        _5_�N���m�F_�݌v�J�� = 5
        _6_�N���m�F_������ = 6
        _7_�N���m�F_�i�؉ے� = 7
        _8_���u���{�L�^���� = 8
        _9_���u���{�m�F = 9
        _10_�����L�����L�� = 10
        _11_�����L�����m�F_����GL = 11
        _12_�����L�����m�F_�i��TL = 12
        _13_�����L�����m�F_�i�ؒS���ے� = 13
        _99_Closed = 99
    End Enum

    '80 NCR���u���{ �^�u�y�[�W
    Public Enum ENM_NCR_STAGE80_TABPAGES
        _1_�p�p���{�L�^ = 1
        _2_�ĉ��H�w��_�L�^ = 2
        _3_�ԋp���{�L�^ = 3
        _4_�]�p��L�^ = 4
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
    ''' ���{�v���敪
    ''' </summary>
    Public Enum ENM_KONPON_YOIN_KB
        _0_�l = 0
        _1_�ޗ� = 1
        _2_�ݔ����� = 2
        _3_���@ = 3
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
        _0_�V�K�쐬 = 0
        _1_�\�� = 1
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
        _9_��� = 9
    End Enum

#End Region

#Region "Model"

    Public _D003_NCR_J As New D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of D006_CAR_GENIN)
    Public _D007 As New D007_FCR_J
    Public _D008_List As New List(Of D008_FCR_J_SUB)
    Public _R001_HOKOKU_SOUSA As New R001_HOKOKU_SOUSA
    Public _R002_HOKOKU_TENSO As New R002_HOKOKU_TENSO
    Public _R003_NCR_SASIMODOSI As New R003_NCR_SASIMODOSI
    Public _R004 As New R004_CAR_SASIMODOSI
    Public _R005 As New R005_FCR_SASIMODOSI
    Public _R006_List As New List(Of R006_FCR_J_SUB_SASIMODOSI)
    Public _V011_FCR_J As New V011_FCR_J

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

                '----���ʏ�������
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

                    'Call FunGetCodeDataTable(DB, "�s�K���敪", tblFUTEKIGO_KB)
                    'Call FunGetCodeDataTable(DB, "���F�S��", tblTANTO_SYONIN)
                    'Call FunGetCodeDataTable(DB, "���F�S���ꗗ", tblTANTO_SYONINList)
                    'Call FunGetCodeDataTable(DB, "�������͋敪", tblGENIN_BUNSEKI_KB)

                End Using

                '�N�����p�����[�^���擾
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 5 Then
                    '���[�������N�p
                    pub_PrHOKOKU_NO = Val(cmds(4))
                    pub_PrSYONIN_HOKOKUSYO_ID = Val(cmds(3))
                    pub_intOPEN_MODE = Val(cmds(2))
                ElseIf cmds.Length = 3 Then
                    pub_intOPEN_MODE = Val(cmds(2))
                Else
                    pub_intOPEN_MODE = ENM_OPEN_MODE._0_�ʏ�
                End If

                Parameter.Init(cmds(1))

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

#Region "�l�擾��"

    ''' <summary>
    ''' �����̌����������ꗗ�擾�X�g�A�h�ɓn���Č������ʂ̃e�[�u���f�[�^���擾
    ''' </summary>
    ''' <param name="ParamModel"></param>
    ''' <returns></returns>

    Public Function FunGetV002Model(ByVal strHOKOKU_NO As String) As V002_NCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V002_NCR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V002_NCR_J
            Dim t As Type = GetType(V002_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        If p.PropertyType Is GetType(String) Then
                            _model(p.Name) = .Item(p.Name).ToString.Trim
                        Else
                            _model(p.Name) = .Item(p.Name)
                        End If

                    End If
                Next p
            End With
            Return _model
        End If
    End Function

    Public Function IsMatchRevision(strRevisionName As String, intSYONIN_HOKOKUSYO_ID As Integer, strHOKOKU_NO As String) As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim intRET As Integer

            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT(HOKOKU_NO)")
            sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)}")
            sbSQL.Append($" WHERE SYONIN_HOKOKUSYO_ID ={intSYONIN_HOKOKUSYO_ID}")
            sbSQL.Append($" AND HOKOKU_NO='{strHOKOKU_NO}'")
            Select Case strRevisionName
                Case "P"
                    sbSQL.Append($" AND SYONIN_JUN={ENM_NCR_STAGE._10_�N������.Value}")
                    sbSQL.Append($" AND ADD_YMDHNS>='202002130000'")
                Case Else

            End Select
            Using DB = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg).ToVal
            End Using

            Return intRET > 0
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As List(Of V003_SYONIN_J_KANRI)

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID = " & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Dim t As Type = GetType(V003_SYONIN_J_KANRI)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                         Reflection.BindingFlags.Public Or
                         Reflection.BindingFlags.Instance Or
                         Reflection.BindingFlags.Static)

            Dim entities As New List(Of V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New V003_SYONIN_J_KANRI
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
                                    If row.Item(p.Name).ToString.IsNulOrWS = False Then
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

    Public Function FunGetV004Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As V004_HOKOKU_SOUSA

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V004_HOKOKU_SOUSA) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V004_HOKOKU_SOUSA
            Dim t As Type = GetType(V004_HOKOKU_SOUSA)
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

    Public Function FunGetV005Model(ByVal strHOKOKU_NO As String) As V005_CAR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V005_CAR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V005_CAR_J

            With dsList.Tables(0).Rows(0)
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO)).ToString.Trim
                _model.BUMON_KB = .Item(NameOf(_model.BUMON_KB)).ToString.Trim
                _model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME)).ToString.Trim
                _model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                _model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME)).ToString.Trim
                _model.CLOSE_FG = CBool(Val(.Item(NameOf(_model.CLOSE_FG))))
                _model.SETUMON_1 = .Item(NameOf(_model.SETUMON_1)).ToString.Trim
                _model.SETUMON_2 = .Item(NameOf(_model.SETUMON_2)).ToString.Trim
                _model.SETUMON_3 = .Item(NameOf(_model.SETUMON_3)).ToString.Trim
                _model.SETUMON_4 = .Item(NameOf(_model.SETUMON_4)).ToString.Trim
                _model.SETUMON_5 = .Item(NameOf(_model.SETUMON_5)).ToString.Trim
                _model.SETUMON_6 = .Item(NameOf(_model.SETUMON_6)).ToString.Trim
                _model.SETUMON_7 = .Item(NameOf(_model.SETUMON_7)).ToString.Trim
                _model.SETUMON_8 = .Item(NameOf(_model.SETUMON_8)).ToString.Trim
                _model.SETUMON_9 = .Item(NameOf(_model.SETUMON_9)).ToString.Trim
                _model.SETUMON_10 = .Item(NameOf(_model.SETUMON_10)).ToString.Trim
                _model.SETUMON_11 = .Item(NameOf(_model.SETUMON_11)).ToString.Trim
                _model.SETUMON_12 = .Item(NameOf(_model.SETUMON_12)).ToString.Trim
                _model.SETUMON_13 = .Item(NameOf(_model.SETUMON_13)).ToString.Trim
                _model.SETUMON_14 = .Item(NameOf(_model.SETUMON_14)).ToString.Trim
                _model.SETUMON_15 = .Item(NameOf(_model.SETUMON_15)).ToString.Trim
                _model.SETUMON_16 = .Item(NameOf(_model.SETUMON_16)).ToString.Trim
                _model.SETUMON_17 = .Item(NameOf(_model.SETUMON_17)).ToString.Trim
                _model.SETUMON_18 = .Item(NameOf(_model.SETUMON_18)).ToString.Trim
                _model.SETUMON_19 = .Item(NameOf(_model.SETUMON_19)).ToString.Trim
                _model.SETUMON_20 = .Item(NameOf(_model.SETUMON_20)).ToString.Trim
                _model.SETUMON_21 = .Item(NameOf(_model.SETUMON_21)).ToString.Trim
                _model.SETUMON_22 = .Item(NameOf(_model.SETUMON_22)).ToString.Trim
                _model.SETUMON_23 = .Item(NameOf(_model.SETUMON_23)).ToString.Trim
                _model.SETUMON_24 = .Item(NameOf(_model.SETUMON_24)).ToString.Trim

                _model.KAITO_1 = .Item(NameOf(_model.KAITO_1)).ToString.Trim
                _model.KAITO_2 = .Item(NameOf(_model.KAITO_2)).ToString.Trim
                _model.KAITO_3 = .Item(NameOf(_model.KAITO_3)).ToString.Trim
                _model.KAITO_4 = .Item(NameOf(_model.KAITO_4)).ToString.Trim
                _model.KAITO_5 = .Item(NameOf(_model.KAITO_5)).ToString.Trim
                _model.KAITO_6 = .Item(NameOf(_model.KAITO_6)).ToString.Trim
                _model.KAITO_7 = .Item(NameOf(_model.KAITO_7)).ToString.Trim
                _model.KAITO_8 = .Item(NameOf(_model.KAITO_8)).ToString.Trim
                _model.KAITO_9 = .Item(NameOf(_model.KAITO_9)).ToString.Trim
                _model.KAITO_10 = .Item(NameOf(_model.KAITO_10)).ToString.Trim
                _model.KAITO_11 = .Item(NameOf(_model.KAITO_11)).ToString.Trim
                _model.KAITO_12 = .Item(NameOf(_model.KAITO_12)).ToString.Trim
                _model.KAITO_13 = .Item(NameOf(_model.KAITO_13)).ToString.Trim
                _model.KAITO_14 = .Item(NameOf(_model.KAITO_14)).ToString.Trim
                _model.KAITO_15 = .Item(NameOf(_model.KAITO_15)).ToString.Trim
                _model.KAITO_16 = .Item(NameOf(_model.KAITO_16)).ToString.Trim
                _model.KAITO_17 = .Item(NameOf(_model.KAITO_17)).ToString.Trim
                _model.KAITO_18 = .Item(NameOf(_model.KAITO_18)).ToString.Trim
                _model.KAITO_19 = .Item(NameOf(_model.KAITO_19)).ToString.Trim
                _model.KAITO_20 = .Item(NameOf(_model.KAITO_20)).ToString.Trim
                _model.KAITO_21 = .Item(NameOf(_model.KAITO_21)).ToString.Trim
                _model.KAITO_22 = .Item(NameOf(_model.KAITO_22)).ToString.Trim
                _model.KAITO_23 = .Item(NameOf(_model.KAITO_23)).ToString.Trim
                _model.KAITO_24 = .Item(NameOf(_model.KAITO_24)).ToString.Trim
                _model.KAITO_25 = .Item(NameOf(_model.KAITO_25)).ToString.Trim
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
                _model.KYOIKU_FILE_PATH = .Item(NameOf(_model.KYOIKU_FILE_PATH)).ToString.Trim
                _model.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU)).ToString.Trim
                _model.ZESEI_SYOCHI_YUKO_UMU_NAME = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU_NAME)).ToString.Trim
                _model.SYOSAI_FILE_PATH = .Item(NameOf(_model.SYOSAI_FILE_PATH)).ToString.Trim
                _model.GOKI = .Item(NameOf(_model.GOKI)).ToString.Trim
                _model.LOT = .Item(NameOf(_model.LOT)).ToString.Trim
                _model.KENSA_TANTO_ID = .Item(NameOf(_model.KENSA_TANTO_ID))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KENSA_TOROKU_YMDHNS = .Item(NameOf(_model.KENSA_TOROKU_YMDHNS))
                _model.KENSA_GL_SYAIN_ID = .Item(NameOf(_model.KENSA_GL_SYAIN_ID))
                _model.KENSA_GL_SYAIN_NAME = .Item(NameOf(_model.KENSA_GL_SYAIN_NAME))
                _model.KENSA_GL_YMDHNS = .Item(NameOf(_model.KENSA_GL_YMDHNS))
                _model.FILE_PATH1 = .Item(NameOf(_model.FILE_PATH1)).ToString.Trim
                _model.FILE_PATH2 = .Item(NameOf(_model.FILE_PATH2)).ToString.Trim
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
                _model.SYONIN_NAME70 = .Item(NameOf(_model.SYONIN_NAME70))
                _model.SYONIN_YMD70 = .Item(NameOf(_model.SYONIN_YMD70))
                _model.SYONIN_NAME90 = .Item(NameOf(_model.SYONIN_NAME90))
                _model.SYONIN_YMD90 = .Item(NameOf(_model.SYONIN_YMD90))
                _model.SYONIN_NAME100 = .Item(NameOf(_model.SYONIN_NAME100))
                _model.SYONIN_YMD100 = .Item(NameOf(_model.SYONIN_YMD100))
                _model.SYONIN_NAME120 = .Item(NameOf(_model.SYONIN_NAME120))
                _model.SYONIN_YMD120 = .Item(NameOf(_model.SYONIN_YMD120))
                _model.SYONIN_NAME130 = .Item(NameOf(_model.SYONIN_NAME130))
                _model.SYONIN_YMD130 = .Item(NameOf(_model.SYONIN_YMD130))

                _model.FUTEKIGO_HASSEI_YMD = .Item(NameOf(_model.FUTEKIGO_HASSEI_YMD))
                _model.SYOCHI_YOTEI_YMD = .Item(NameOf(_model.SYOCHI_YOTEI_YMD))
            End With

            Return _model
        End If
    End Function

    Public Function FunGetV011Model(ByVal strHOKOKU_NO As String) As V011_FCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT")
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(V011_FCR_J)}")
        sbSQL.Append($" WHERE HOKOKU_NO='{strHOKOKU_NO}'")
        Using DB = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList IsNot Nothing AndAlso dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Dim _Model As New ModelInfo(Of V011_FCR_J)(srcDATA:=dsList.Tables(0))
            Return _Model.Entity
        End If
    End Function

    ''' <summary>
    ''' ���݂̃X�e�[�W�����擾
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Public Function FunGetStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal intCurrentStageID As Integer) As String
        Try
            Dim drList As List(Of DataRow)

            Select Case intSYONIN_HOKOKUSYO_ID
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    drList = tblNCR.AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    drList = tblCAR.AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    drList = tblCTS.LazyLoad("CTS").AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Else
                    Return vbEmpty
            End Select

            Return drList(0)?.Item("DISP")
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
        sbSQL.Append(" FROM " & NameOf(D004_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

    End Function

    Private Function FunGetCurrentSYONIN_JUN(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal HOKOKU_NO As String) As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" SYONIN_JUN")
        sbSQL.Append(" FROM " & NameOf(V007_NCR_CAR) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & HOKOKU_NO & "'")
        sbSQL.Append(" ORDER BY SYONIN_JUN DESC")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return If(dsList.Tables(0).Rows(0).Item(0).ToString.ToVal = 0, 999, dsList.Tables(0).Rows(0).Item(0).ToString.ToVal)
        Else
            Return 0
        End If
    End Function

#End Region

#Region "���[�����M"

    Public Function FunSendMailFutekigo(ByVal strSubject As String, ByVal strBody As String, ByVal ToSYAIN_ID As Integer) As Boolean
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim ToAddressList As New List(Of String)
        Dim CCAddressList As New List(Of String)
        Dim BCCAddressList As New List(Of String)
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        'Dim strFromSyainName As String

        Dim strMsg As String
        Try

            Using DB As ClsDbUtility = DBOpen()

                If FunGetCodeMastaValue(DB, "���[���ݒ�", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    MessageBox.Show("���[�����M�������ɐݒ肳��Ă��邽�߁A�˗����[���͑��M����܂���ł����B", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If

                strSmtpServer = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "���[���ݒ�", "SMTP_PASS")

                '---�\����S���҂̃��[���A�h���X�Ȃǎ擾
                Dim sbSQL As New System.Text.StringBuilder
                Dim dsList As New DataSet
                sbSQL.Remove(0, sbSQL.Length)
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
                sbSQL.Append($" WHERE M4.SYAIN_ID={ToSYAIN_ID}")
                sbSQL.Append($" AND M5.KENMU_FLG='0'")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        If Not .Rows(0).Item("MAIL_ADDRESS").ToString.IsNulOrWS Then
                            ToAddressList.Add(.Rows(0).Item("MAIL_ADDRESS"))
                        End If

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

                        strToSyainName = .Rows(0).Item("SIMEI")
                    Else
                        Return False
                    End If
                End With

                '---�V�X�e�����M���A�h���X�擾
                strFromAddress = FunGetCodeMastaValue(DB, "���[���ݒ�", "FROM")

                '---�\�����S���҂̃��[���A�h���X�擾
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                '���g�ɐ\�����[���𑗂�ꍇ��CC�ɒǉ����Ȃ�
                If dsList.Tables(0).Rows.Count > 0 AndAlso Not dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS").ToString.IsNulOrWS AndAlso Not ToAddressList.Contains(dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")) Then
                    CCAddressList.Add(dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS"))
                End If

                If ToAddressList.Count = 0 Then
                    MessageBox.Show("�˗���S���҂̃��[���A�h���X���ݒ肳��Ă��Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                strMsg = $"�y���[�����M�����zTO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}"
                WL.WriteLogDat(strMsg)

            End Using

            '#If DEBUG Then
            '            Return True
            '#End If

            ''�F�؂Ȃ� �t�W����
            blnSend = ClsMailSend.FunSendMail(strSmtpServer:=strSmtpServer,
                           intSmtpPort:=intSmtpPort,
                           FromAddress:=strFromAddress,
                           ToAddress:=ToAddressList,
                           CCAddress:=CCAddressList,
                           BCCAddress:=BCCAddressList,
                           strSubject:=strSubject,
                           strBody:=strBody,
                           AttachmentList:=New List(Of String),
                           strFromName:="�s�K���Ǘ��V�X�e��",
                           isHTML:=True)

            '�F�؂��� JMS
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
            strMsg = String.Format("�y���[�����M���s�zTO:{0}({1}) SUBJECT:{2}" & vbCrLf & Err.Description, strToSyainName, ToAddressList(0), strSubject)
            WL.WriteLogDat(strMsg)
        End Try
    End Function

#End Region

#Region "���F�����Ј��擾"

    'TV02_SYONIN_SYOZOKU_SYAIN

    Public Function FunGetSYONIN_SYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional SYONIN_HOUKOKUSYO_ID As Integer = 0, ByVal Optional SYONIN_JUN As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV02_SYONIN_SYOZOKU_SYAIN('" & BUMON_KB.Trim & "')")
        If SYONIN_HOUKOKUSYO_ID > 0 Then
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & SYONIN_HOUKOKUSYO_ID & "")
            '���F���P�ƂŌ�������邱�Ƃ͂Ȃ�
            sbSQL.Append(" AND SYONIN_JUN=" & SYONIN_JUN & "")
        End If
        sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        'dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        'dt.Columns.Add("SYONIN_JUN", GetType(Integer))

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        '���F�����w��=�񍐏�ID���w�� or ���F��=ST1 �N���o�^���̓��O�C�����[�U�[��ǉ�
        Select Case SYONIN_JUN
            Case 0, 10
                '#109 ���O�C�����[�U�[�����u�S�����X�g�ɒǉ�
                Dim Trow2 As DataRow = dt.NewRow()
                If Not dt.Rows.Contains(pub_SYAIN_INFO.SYAIN_ID) Then
                    Trow2("VALUE") = pub_SYAIN_INFO.SYAIN_ID
                    Trow2("DISP") = pub_SYAIN_INFO.SYAIN_NAME
                    dt.Rows.Add(Trow2)
                End If
        End Select

        '�V�X�e�����[�U�[���O�C�����̓V�X�e�����[�U�[��ǉ�
        If pub_SYAIN_INFO.SYAIN_ID = 999999 Then
            Dim Trow3 As DataRow = dt.NewRow()
            If Not dt.Rows.Contains(pub_SYAIN_INFO.SYAIN_ID) Then
                Trow3("VALUE") = pub_SYAIN_INFO.SYAIN_ID
                Trow3("DISP") = pub_SYAIN_INFO.SYAIN_NAME
                dt.Rows.Add(Trow3)
            End If
        End If

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

#Region "�����Ј��擾"

    'TV03_SYONIN_SYAIN

    Public Function FunGetSYOZOKU_SYAIN(Optional BUMON_KB As String = "", Optional BUSYO_ID As Integer = 0, Optional GYOMU_GROUP_ID As Integer = 0) As DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM TV03_SYOZOKU_SYAIN('{BUMON_KB}')")
        sbSQL.Append(" WHERE 1=1")
        If GYOMU_GROUP_ID > 0 Then
            sbSQL.Append(" AND GYOMU_GROUP_ID=" & GYOMU_GROUP_ID & "")
        End If
        If BUSYO_ID > 0 Then
            sbSQL.Append(" AND BUSYO_ID=" & BUSYO_ID & "")
        End If
        sbSQL.Append(" ORDER BY SYAIN_ID, IS_LEADER DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        Dim dt As DataTableEx = New DataTableEx("System.Int32")
        dt.Columns.Add("BUMON_KB", GetType(String))
        dt.Columns.Add("BUSYO_ID", GetType(Integer))
        dt.Columns.Add("GYOMU_GROUP_ID", GetType(Integer))
        dt.Columns.Add("IS_LEADER", GetType(Boolean))

        dt.PrimaryKey = {dt.Columns("VALUE"), dt.Columns("GYOMU_GROUP_ID")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        For Each row As DataRow In dsList.Tables(0).Rows
            Dim Trow As DataRow = dt.NewRow()
            If Not dt.Rows.Contains({row.Item("SYAIN_ID"), row.Item("GYOMU_GROUP_ID")}) Then
                Trow("VALUE") = row.Item("SYAIN_ID")
                Trow("DISP") = row.Item("SIMEI")
                Trow("BUMON_KB") = row.Item("BUMON_KB")
                Trow("BUSYO_ID") = row.Item("BUSYO_ID")
                Trow("GYOMU_GROUP_ID") = row.Item("GYOMU_GROUP_ID")
                Trow("IS_LEADER") = CBool(row.Item("IS_LEADER").ToString.ToVal)
                dt.Rows.Add(Trow)
            End If
        Next row

        Return dt
    End Function

#End Region

#Region "����ʕs�K���敪�擾"

    Public Function FunGetFUTEKIGO_KB(BUMON_KB As String) As DataTableEx
        Dim dt As New DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Try

            If Not BUMON_KB.IsNulOrWS Then
                '�ʏ�
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME")
                sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{BUMON_KB}') ")
                sbSQL.Append($" ORDER BY FUTEKIGO_KB")
                Using DB As ClsDbUtility = DBOpen()
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                '��L�[�ݒ�
                dt.PrimaryKey = {dt.Columns("VALUE")}

                For Each row In dsList.Tables(0).Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = row.Item("FUTEKIGO_KB_NAME").ToString.Trim
                    Trow("VALUE") = row.Item("FUTEKIGO_KB").ToString.Trim
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next
            Else
                '�W�v���͎��A�敪���œ���

                '��L�[�ݒ�
                dt.PrimaryKey = {dt.Columns("DISP")}

                For iBUMON_KB As Integer = 1 To 3
                    sbSQL.Clear()
                    sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME")
                    sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{iBUMON_KB}') ")
                    sbSQL.Append($" ORDER BY FUTEKIGO_KB")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    For Each row In dsList.Tables(0).Rows
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("DISP") = row.Item("FUTEKIGO_KB_NAME").ToString.Trim
                        Trow("VALUE") = row.Item("FUTEKIGO_KB").ToString.Trim
                        Trow("DEL_FLG") = False
                        If Not dt.Rows.Contains(Trow("DISP")) Then
                            dt.Rows.Add(Trow)
                        End If
                    Next
                Next
            End If

            Return dt
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

#End Region

#Region "����ʕs�K���ڍ׋敪�擾"

    Public Function FunGetFUTEKIGO_S_KB(BUMON_KB As String, FUTEKIGO_KB As String) As DataTableEx
        Dim dt As New DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Try

            If Not BUMON_KB.IsNulOrWS Then
                '�ʏ�
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME,FUTEKIGO_S_KB,FUTEKIGO_S_KB_NAME")
                sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{BUMON_KB}') ")
                sbSQL.Append($" WHERE FUTEKIGO_KB='{FUTEKIGO_KB}'")
                sbSQL.Append($" ORDER BY FUTEKIGO_S_KB")
                Using DB As ClsDbUtility = DBOpen()
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                '��L�[�ݒ�
                dt.PrimaryKey = {dt.Columns("VALUE")}

                For Each row In dsList.Tables(0).Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = row.Item("FUTEKIGO_S_KB_NAME").ToString.Trim
                    Trow("VALUE") = row.Item("FUTEKIGO_S_KB").ToString.Trim
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next
            Else
                '�W�v���͎��A�敪���œ���
                '��L�[�ݒ�
                dt.PrimaryKey = {dt.Columns("DISP")}

                For iBUMON_KB As Integer = 1 To 3
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME,FUTEKIGO_S_KB,FUTEKIGO_S_KB_NAME")
                    sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{iBUMON_KB}') ")
                    sbSQL.Append($" WHERE FUTEKIGO_KB_NAME='{FUTEKIGO_KB}'")
                    sbSQL.Append($" ORDER BY FUTEKIGO_S_KB")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    For Each row In dsList.Tables(0).Rows
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("DISP") = row.Item("FUTEKIGO_S_KB_NAME").ToString.Trim
                        Trow("VALUE") = row.Item("FUTEKIGO_S_KB").ToString.Trim
                        Trow("DEL_FLG") = False
                        If Not dt.Rows.Contains(Trow("DISP")) Then
                            dt.Rows.Add(Trow)
                        End If
                    Next
                Next
            End If

            Return dt
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

#End Region

#Region "�񍐏��o�^���e�ύX����"

    Public Function FunChangedRecord(ByVal intHOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, strTargetYMDHNS As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try

            sbSQL.Append("SELECT * FROM " & NameOf(ST01_GET_HOKOKU_NO) & "")
            sbSQL.Append("")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "���|�[�g�o��"

    Public Function FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet
        Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
        Dim strYMDHNS As String
        Try

            Dim _V002_NCR_J As V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            '---�}�`�擾
            Dim shapeLINE_SAISIN_IINKAI As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_KOKYAKU_SAISIN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_HAIKYAKU As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SAIKAKO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_HENKYAKU As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_TENYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_D As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_E As SpreadsheetGear.Shapes.IShape = Nothing

            Dim shapeLINE_CAR_HOKOKU_NO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_HASSEI_KOTEI_GL As SpreadsheetGear.Shapes.IShape = Nothing

            ssgShapes = ssgSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_SAISIN_IINKAI"
                        shapeLINE_SAISIN_IINKAI = shape
                    Case "LINE_KOKYAKU_SAISIN"
                        shapeLINE_KOKYAKU_SAISIN = shape
                    Case "LINE_HAIKYAKU"
                        shapeLINE_HAIKYAKU = shape
                    Case "LINE_SAIKAKO"
                        shapeLINE_SAIKAKO = shape
                    Case "LINE_HENKYAKU"
                        shapeLINE_HENKYAKU = shape
                    Case "LINE_TENYO"
                        shapeLINE_TENYO = shape
                    Case "LINE_SYOCHI_C"
                        shapeLINE_SYOCHI_C = shape
                    Case "LINE_SYOCHI_D"
                        shapeLINE_SYOCHI_D = shape
                    Case "LINE_SYOCHI_E"
                        shapeLINE_SYOCHI_E = shape
                    Case "LINE_CAR_HOKOKU_NO"
                        shapeLINE_CAR_HOKOKU_NO = shape
                    Case "LINE_HASSEI_KOTEI_GL"
                        shapeLINE_HASSEI_KOTEI_GL = shape
                End Select
            Next shape

            Select Case _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
                Case ENM_JIZEN_SINSA_HANTEI_KB._2_�ĐR�ψ����
                    shapeLINE_SAISIN_IINKAI.Visible = False
                    If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
                    End If

                    strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._60_�ĐR�R������_�Z�p��\ And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
                    If Not strYMDHNS.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
                    End If

                    strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._61_�ĐR�R������_�i�ؑ�\ And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
                    If Not strYMDHNS.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
                        If Not _V002_NCR_J.SAISIN_HINSYO_YMD.IsNulOrWS Then
                            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_HINSYO_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                        End If
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                Case ENM_JIZEN_SINSA_HANTEI_KB._3_�ڋq�ĐR�\��
                    shapeLINE_KOKYAKU_SAISIN.Visible = False

                    strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._70_�ڋq�ĐR���u_I_tag And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
                    If Not strYMDHNS.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISIN_TANTO_NAME)).Value = _V002_NCR_J.KOKYAKU_SAISIN_TANTO_NAME
                        If Not _V002_NCR_J.KOKYAKU_SAISIN_YMD.IsNulOrWS Then
                            ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_SAISIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                        End If
                    End If

                    ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO

                    ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
                    If Not _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_NAME)).Value = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_NAME
                    If Not _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case Else
                    shapeLINE_KOKYAKU_SAISIN.Visible = True
                    shapeLINE_SAISIN_IINKAI.Visible = True
            End Select

            Dim SYOCHI_KB As ENM_NCR_STAGE80_TABPAGES

            SYOCHI_KB = FunGetST08SubPageName(_V002_NCR_J)
            Select Case SYOCHI_KB
                Case ENM_NCR_STAGE80_TABPAGES._1_�p�p���{�L�^
                    If Not _V002_NCR_J.HAIKYAKU_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HAIKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = $"���̑��̓��e�F{_V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30)}"
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
                Case ENM_NCR_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                    If Not _V002_NCR_J.SAIKAKO_KENSA_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_KENSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
                    If _V002_NCR_J.KENSA_KEKKA_KB.ToVal = ENM_KENSA_KEKKA_KB._1_�s���i Then
                        ssgSheet1.Range("SAI_FUTEKIGO_LABEL").Value = "�ĕs�K�����u �񍐏�No"
                        ssgSheet1.Range("SAI_FUTEKIGO_HOKOKU_NO").Value = _V002_NCR_J.HOKOKU_NO + 1
                    Else
                        ssgSheet1.Range("SAI_FUTEKIGO_LABEL").Value = ""
                        ssgSheet1.Range("SAI_FUTEKIGO_HOKOKU_NO").Value = ""
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
                    If Not _V002_NCR_J.SEIGI_KAKUNIN_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SEIGI_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.SEIZO_KAKUNIN_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SEIZO_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.KENSA_KAKUNIN_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KENSA_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case ENM_NCR_STAGE80_TABPAGES._3_�ԋp���{�L�^
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
                    If Not _V002_NCR_J.HENKYAKU_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HENKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case ENM_NCR_STAGE80_TABPAGES._4_�]�p��L�^
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_LOT)).Value = _V002_NCR_J.TENYO_LOT
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU_NAME)).Value = _V002_NCR_J.TENYO_KISYU_NAME
                    If Not _V002_NCR_J.TENYO_YMD.IsNulOrWS Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.TENYO_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case Else
            End Select
            shapeLINE_HAIKYAKU.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._1_�p�p���{�L�^)
            shapeLINE_SAIKAKO.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^)
            shapeLINE_HENKYAKU.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._3_�ԋp���{�L�^)
            shapeLINE_TENYO.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._4_�]�p��L�^)

            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNulOrWS Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            If Not _V002_NCR_J.SAISIN_KAKUNIN_YMD.IsNulOrWS Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If

            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNulOrWS Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI

            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO

            If _V002_NCR_J.ZESEI_SYOCHI_YOHI_KB.ToVal = ENM_YOHI_KB._1_�v Then
                ssgSheet1.Range("CAR_HOKOKU_NO").Value = _V002_NCR_J.HOKOKU_NO
                ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME
                If Not _V002_NCR_J.HASSEI_KOTEI_GL_YMD.IsNulOrWS Then
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HASSEI_KOTEI_GL_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                End If
                shapeLINE_CAR_HOKOKU_NO.Visible = False
                shapeLINE_HASSEI_KOTEI_GL.Visible = False
            Else
                shapeLINE_CAR_HOKOKU_NO.Visible = True
                shapeLINE_HASSEI_KOTEI_GL.Visible = True
            End If

            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA.Replace(Environment.NewLine, "")
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU_NAME)).Value = _V002_NCR_J.KISYU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU

            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO

            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME

            If _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.ToVal = ENM_JIZEN_SINSA_HANTEI_KB._4_�p�p����.Value Then
                shapeLINE_SYOCHI_C.Visible = False
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME
            Else
                shapeLINE_SYOCHI_C.Visible = True
            End If

            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO.Replace(Environment.NewLine, "")
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = $"(�}��/�K�i�F {If(_V002_NCR_J.ZUMEN_KIKAKU.IsNulOrWS, Space(38), _V002_NCR_J.ZUMEN_KIKAKU.Trim)} )"

            Dim kiso_tanto As String = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).FirstOrDefault?.UPD_SYAIN_NAME
            If kiso_tanto.IsNulOrWS Then kiso_tanto = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).FirstOrDefault?.ADD_SYAIN_NAME
            ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._10_�N������).Value = kiso_tanto

            Dim intCurrentStage As Integer = FunGetCurrentSYONIN_JUN(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _V002_NCR_J.HOKOKU_NO)

            If _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).Select(Function(r) r.ADD_YMDHNS).First < "202002140000" Then
                ssgSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iO�j�@�ʎ��|�R"
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
                If intCurrentStage >= ENM_NCR_STAGE._110_abcde���u�S�� Then
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
                    If _V002_NCR_J.SYOCHI_D_UMU_KB = "1" Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
                    If _V002_NCR_J.SYOCHI_E_UMU_KB = "1" Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
                    End If
                End If
                shapeLINE_SYOCHI_D.Visible = (_V002_NCR_J.SYOCHI_D_UMU_KB = "0")
                shapeLINE_SYOCHI_E.Visible = (_V002_NCR_J.SYOCHI_E_UMU_KB = "0")
            Else
                ssgSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iP�j�@�ʎ��|�R"
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������ And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._10_�N������).Value = "'" & DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                If strYMDHNS.Substring(0, 8) >= "20200512" Then
                    ssgSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iQ�j�@ �ʎ��|�R"
                End If
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._20_�N���m�F����GL).Value = "'" & DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._20_�N���m�F����GL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_�N���m�F����GL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F���� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._30_�N���m�F����).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._30_�N���m�F����).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_�N���m�F����).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._40_���O�R������y��CAR�v�۔��� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.JIZEN_SINSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._50_���O�R���m�F And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_���u���{�m�F_�Ǘ�T).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._100_���u���{����_�����ے�).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._100_���u���{����_�����ے�).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_���u���{����_�����ے�).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S�� And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNulOrWS Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._110_abcde���u�S��).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._110_abcde���u�S��).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde���u�S��).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            If intCurrentStage > ENM_NCR_STAGE._120_abcde���u�m�F Then
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._120_abcde���u�m�F).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde���u�m�F).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "�Y�t�t�@�C���ۑ���", My.Application.Info.AssemblyName))
            End Using

            '�摜�\��
            Dim top As Double
            Dim left As Double
            Dim width As Double
            Dim height As Double
            Dim aspectRatio As Double
            If Not _V002_NCR_J.G_FILE_PATH1.IsNulOrWS Then
                Using img = Image.FromFile(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH1)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '���s��
                    top = windowInfo.RowToPoints(7.2)
                    '�����
                    left = windowInfo.ColumnToPoints(9.2)

                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                    aspectRatio = img.Width / img.Height
                    width = height * aspectRatio 'windowInfo.ColumnToPoints(5.5) * Magnification 'img.Width * 72 / img.HorizontalResolution

                End Using
                ssgSheet1.Shapes.AddPicture(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH1, left, top, width, height)
            End If

            If Not _V002_NCR_J.G_FILE_PATH2.IsNulOrWS Then
                Using img = Image.FromFile(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH2)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '���s��
                    top = windowInfo.RowToPoints(7.2 + 9)
                    '�����
                    left = windowInfo.ColumnToPoints(9.2)

                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                    aspectRatio = img.Width / img.Height
                    width = height * aspectRatio 'windowInfo.ColumnToPoints(5.5) * Magnification 'img.Width * 72 / img.HorizontalResolution
                End Using
                ssgSheet1.Shapes.AddPicture(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH2, left, top, width, height)
            End If

            '-----�t�@�C���ۑ�
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire�� ����PDF���s����Ȃ炱����
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            '''PDF�\��
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Call FunOpenWorkbook(strFilePath)
            Call OpenExcelPrintPreview(strFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                System.IO.File.Delete(strFilePath)
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

            '---�}�`�擾
            Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
            Dim shapeLINE_SYOCHI_A1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_A2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_A3 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_B1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_B2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_B3 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C3 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C4 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_C5 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SEKKEI_TANTO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_KOUKA_KAKUNIN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeSCR_FUTEKIGO_YOUIN_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeSCR_FUTEKIGO_YOUIN_F As SpreadsheetGear.Shapes.IShape = Nothing

            ssgShapes = spSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_SYOCHI_A1"
                        shapeLINE_SYOCHI_A1 = shape
                    Case "LINE_SYOCHI_A2"
                        shapeLINE_SYOCHI_A2 = shape
                    Case "LINE_SYOCHI_A3"
                        shapeLINE_SYOCHI_A3 = shape
                    Case "LINE_SYOCHI_B1"
                        shapeLINE_SYOCHI_B1 = shape
                    Case "LINE_SYOCHI_B2"
                        shapeLINE_SYOCHI_B2 = shape
                    Case "LINE_SYOCHI_B3"
                        shapeLINE_SYOCHI_B3 = shape
                    Case "LINE_SYOCHI_C1"
                        shapeLINE_SYOCHI_C1 = shape
                    Case "LINE_SYOCHI_C2"
                        shapeLINE_SYOCHI_C2 = shape
                    Case "LINE_SYOCHI_C3"
                        shapeLINE_SYOCHI_C3 = shape
                    Case "LINE_SYOCHI_C4"
                        shapeLINE_SYOCHI_C4 = shape
                    Case "LINE_SYOCHI_C5"
                        shapeLINE_SYOCHI_C5 = shape
                    Case "LINE_SEKKEI_TANTO"
                        shapeLINE_SEKKEI_TANTO = shape
                    Case "LINE_KOUKA_KAKUNIN"
                        shapeLINE_KOUKA_KAKUNIN = shape
                    Case "SCR_FUTEKIGO_YOUIN_T"
                        shapeSCR_FUTEKIGO_YOUIN_T = shape
                    Case "SCR_FUTEKIGO_YOUIN_F"
                        shapeSCR_FUTEKIGO_YOUIN_F = shape
                End Select
            Next shape
            '---

            Dim _V005_CAR_J As V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            If Not _V005_CAR_J.GOKI.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
                shapeLINE_KOUKA_KAKUNIN.Visible = False
            End If

            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1.Replace(Environment.NewLine, "")
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2.Replace(Environment.NewLine, "")
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3.Replace(Environment.NewLine, "")
            If Not _V005_CAR_J.KAITO_4.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_4.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                shapeLINE_SYOCHI_A1.Visible = False
                shapeLINE_SYOCHI_A1.PrintObject = False
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_5)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            If Not _V005_CAR_J.KAITO_6.IsNulOrWS Then
                shapeLINE_SYOCHI_A2.Visible = False
                shapeLINE_SYOCHI_A2.PrintObject = False
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            If Not _V005_CAR_J.KAITO_7.IsNulOrWS Then
                shapeLINE_SYOCHI_A3.Visible = False
                shapeLINE_SYOCHI_A3.PrintObject = False
            End If
            If Not _V005_CAR_J.KAITO_8.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_8.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_9.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_9.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                shapeLINE_SYOCHI_B1.Visible = False
                shapeLINE_SYOCHI_B1.PrintObject = False
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_10)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            If Not _V005_CAR_J.KAITO_11.IsNulOrWS Then
                shapeLINE_SYOCHI_B2.Visible = False
                shapeLINE_SYOCHI_B2.PrintObject = False
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            If Not _V005_CAR_J.KAITO_12.IsNulOrWS Then
                shapeLINE_SYOCHI_B3.Visible = False
                shapeLINE_SYOCHI_B3.PrintObject = False
            End If
            If Not _V005_CAR_J.KAITO_13.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_13.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_14.IsNulOrWS AndAlso CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"

                shapeLINE_SYOCHI_C1.Visible = False
                shapeLINE_SYOCHI_C1.PrintObject = False
                shapeLINE_SYOCHI_C2.Visible = False
                shapeLINE_SYOCHI_C2.PrintObject = False
                shapeLINE_SYOCHI_C3.Visible = False
                shapeLINE_SYOCHI_C3.PrintObject = False
                shapeLINE_SYOCHI_C4.Visible = False
                shapeLINE_SYOCHI_C4.PrintObject = False
                shapeLINE_SYOCHI_C5.Visible = False
                shapeLINE_SYOCHI_C5.PrintObject = False
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If

            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            If Not _V005_CAR_J.KAITO_16.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_16.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_17)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            If Not _V005_CAR_J.KAITO_20.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_20.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If

            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21.Replace(Environment.NewLine, "")
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22.Replace(Environment.NewLine, "")

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            If Not _V005_CAR_J.KENSA_GL_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_GL_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            If Not _V005_CAR_J.KENSA_TOROKU_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_TOROKU_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU_NAME)).Value = _V005_CAR_J.KISYU_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_A_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_A_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_B_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_B_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_C_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_C_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If

            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME10)).Value = _V005_CAR_J.SYONIN_NAME10

            If Not _V005_CAR_J.SYONIN_YMD10.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD10)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD10.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD20.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD20)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD20.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME20)).Value = _V005_CAR_J.SYONIN_NAME20
            End If
            If Not _V005_CAR_J.SYONIN_YMD30.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD30)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD30.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME30)).Value = _V005_CAR_J.SYONIN_NAME30
            End If
            If Not _V005_CAR_J.SYONIN_YMD40.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD40)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD40.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME40)).Value = _V005_CAR_J.SYONIN_NAME40
            End If

            If CBool(Val(_V005_CAR_J.KAITO_23)) Then
                If Not _V005_CAR_J.SYONIN_YMD50.IsNulOrWS Then
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD50)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD50.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME50)).Value = _V005_CAR_J.SYONIN_NAME50
                End If

                shapeLINE_SEKKEI_TANTO.Visible = False
                shapeLINE_SEKKEI_TANTO.PrintObject = False
            End If

            If Not _V005_CAR_J.SYONIN_YMD60.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD60)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD60.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME60)).Value = _V005_CAR_J.SYONIN_NAME60
            End If
            If Not _V005_CAR_J.SYONIN_YMD90.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD90)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD90.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME90)).Value = _V005_CAR_J.SYONIN_NAME90
            End If
            If Not _V005_CAR_J.SYONIN_YMD100.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD100)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD100.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME100)).Value = _V005_CAR_J.SYONIN_NAME100
            End If

            If Not _V005_CAR_J.SYONIN_YMD130.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD130)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD130.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME130)).Value = _V005_CAR_J.SYONIN_NAME130
            End If
            If Not _V005_CAR_J.SYONIN_YMD120.IsNulOrWS Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD120)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD120.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME120)).Value = _V005_CAR_J.SYONIN_NAME120
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '#244
            If _V005_CAR_J.SYONIN_YMD10 >= "20200213" Then
                spSheet1.Range("FUTEKIGO_YOIN_CAP").Value = "�s�K���v��(�֌W����v��(4M�Ȃ�)�̒���) �l�I�v�� ���E�L(�L�̏ꍇ�͈ȉ��ɓ��e���L��)"
                If Not _V005_CAR_J.SYONIN_YMD70.IsNulOrWS Then
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD70)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD70.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME70)).Value = _V005_CAR_J.SYONIN_NAME70
                End If

                '#248 -> ���|�[�g�C�����Ƀt�B�[���h������
                'If Not _V005_CAR_J.SYONIN_YMD100.IsNulOrWS Then
                '    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD130)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD100.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                '    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME130)).Value = _V005_CAR_J.SYONIN_NAME100
                'End If
                'If Not _V005_CAR_J.SYONIN_YMD130.IsNulOrWS Then
                '    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD120)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD130.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                '    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME120)).Value = _V005_CAR_J.SYONIN_NAME130
                'End If
                shapeSCR_FUTEKIGO_YOUIN_T.Visible = (_V005_CAR_J.KAITO_25 = "1")
                shapeSCR_FUTEKIGO_YOUIN_F.Visible = (_V005_CAR_J.KAITO_25 = "0")

                Dim border_SYOCHI_KIROKU As SpreadsheetGear.IBorder = spSheet1.Range("A56:Q56").Borders(SpreadsheetGear.BordersIndex.EdgeBottom)
                border_SYOCHI_KIROKU.LineStyle = SpreadsheetGear.LineStyle.Continuous
                border_SYOCHI_KIROKU.Weight = SpreadsheetGear.BorderWeight.Thin
                border_SYOCHI_KIROKU.Color = SpreadsheetGear.Colors.Black

                Dim border_ZESEI_SYOCHI As SpreadsheetGear.IBorder = spSheet1.Range("A60:Q60").Borders(SpreadsheetGear.BordersIndex.EdgeBottom)
                border_ZESEI_SYOCHI.LineStyle = SpreadsheetGear.LineStyle.Continuous
                border_ZESEI_SYOCHI.Weight = SpreadsheetGear.BorderWeight.Thick
                border_ZESEI_SYOCHI.Color = SpreadsheetGear.Colors.Black

                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iP�j�@�ʎ��|�T"
                spSheet1.Range("P53").Value = "�S���ے�"
                spSheet1.Range("P57").Value = "�S���ے�"
                spSheet1.Range("P61").Value = "�i�؉ے�"
            Else
                spSheet1.Range("FUTEKIGO_YOIN_CAP").Value = "�s�K���v���i�֌W����v���i�l�A�ݔ��E���H��A�ޗ��A���@�A�Ȃǁj�̒����j"
                spSheet1.Range("ST7_FLAME").Clear()
                Dim borderRePaint As SpreadsheetGear.IBorder = spSheet1.Range("R31:R35").Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                borderRePaint.LineStyle = SpreadsheetGear.LineStyle.Continuous
                borderRePaint.Weight = SpreadsheetGear.BorderWeight.Thin
                borderRePaint.Color = SpreadsheetGear.Colors.Black

                shapeSCR_FUTEKIGO_YOUIN_T.Visible = False
                shapeSCR_FUTEKIGO_YOUIN_F.Visible = False

                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iO�j�@�ʎ��|�T"
                spSheet1.Range("P53").Value = "�S���ے���"
                spSheet1.Range("P53").Value = "�S���ے���"
                spSheet1.Range("P57").Value = "�S���ے���"
                spSheet1.Range("P61").Value = "�i��TL"

                If Not _V005_CAR_J.SYONIN_YMD120.IsNulOrWS Then
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD130)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD120.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME130)).Value = _V005_CAR_J.SYONIN_NAME120
                End If
                If Not _V005_CAR_J.SYONIN_YMD130.IsNulOrWS Then
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD100)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD130.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME100)).Value = _V005_CAR_J.SYONIN_NAME130
                End If
            End If
            If _V005_CAR_J.SYONIN_YMD10 >= "20200512" Then
                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iQ�j�@�ʎ��|�T"
            End If

            Dim rev_str = spSheet1.Range("A1").GetCharacters(9, 3)
            rev_str.Font.Color = SpreadsheetGear.Colors.Red

            '-----�t�@�C���ۑ�
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire�� ����PDF���s����Ȃ炱����
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            ''PDF�\��
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Call FunOpenWorkbook(strFilePath)
            Call OpenExcelPrintPreview(strFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                System.IO.File.Delete(strFilePath)
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

    Public Function FunMakeReportCTS(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet
        Dim spRangeFrom As SpreadsheetGear.IRange
        Dim spRangeTo As SpreadsheetGear.IRange
        Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim spprint As SpreadsheetGear.Printing.PrintWhat = SpreadsheetGear.Printing.PrintWhat.Sheet

            Dim shLINE_KOKYAKU_EIKYO_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KAKUNIN_SYUDAN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_TUCHI As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KOKYAKU_EIKYO_ETC_COMMENT As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE1 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_KISYU2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_RANGE2 As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_NAIYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_YMD As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shLINE_SYONIN_SECTION As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_OTHER_PROCESS_INFLUENCE_KB_F As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F As SpreadsheetGear.Shapes.IShape = Nothing

            Dim strYMDHNS As String
            ssgShapes = spSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_KOKYAKU_EIKYO_NAIYO"
                        shLINE_KOKYAKU_EIKYO_NAIYO = shape
                    Case "LINE_KAKUNIN_SYUDAN"
                        shLINE_KAKUNIN_SYUDAN = shape
                    Case "LINE_TUCHI"
                        shLINE_TUCHI = shape
                    Case "LINE_KOKYAKU_EIKYO_ETC_COMMENT"
                        shLINE_KOKYAKU_EIKYO_ETC_COMMENT = shape
                    Case "LINE_KISYU1"
                        shLINE_KISYU1 = shape
                    Case "LINE_RANGE1"
                        shLINE_RANGE1 = shape
                    Case "LINE_KISYU2"
                        shLINE_KISYU2 = shape
                    Case "LINE_RANGE2"
                        shLINE_RANGE2 = shape
                    Case "LINE_NAIYO"
                        shLINE_NAIYO = shape
                    Case "LINE_YMD"
                        shLINE_YMD = shape
                    Case "LINE_SYONIN_SECTION"
                        shLINE_SYONIN_SECTION = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_HANTEI_KB_F = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T = shape
                    Case "SCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F"
                        shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_T"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_T = shape
                    Case "SCR_OTHER_PROCESS_INFLUENCE_KB_F"
                        shSCR_OTHER_PROCESS_INFLUENCE_KB_F = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_T"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T = shape
                    Case "SCR_FOLLOW_PROCESS_OUTFLOW_KB_F"
                        shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F = shape
                End Select
            Next shape

            '���R�[�h�t���[��������

            Dim _V11 As V011_FCR_J = FunGetV011Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS, strHOKOKU_NO)

            spSheet1.Range(NameOf(V011_FCR_J.HOKOKU_NO)).Value = _V11.HOKOKU_NO
            spSheet1.Range(NameOf(V011_FCR_J.TAISYOU_KOKYAKU)).Value = _V11.TAISYOU_KOKYAKU
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_HANTEI_COMMENT)).Value = _V11.KOKYAKU_EIKYO_HANTEI_COMMENT
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_NAIYO)).Value = _V11.KOKYAKU_EIKYO_NAIYO
            spSheet1.Range(NameOf(V011_FCR_J.KAKUNIN_SYUDAN)).Value = _V11.KAKUNIN_SYUDAN
            spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_ETC_COMMENT)).Value = _V11.KOKYAKU_EIKYO_ETC_COMMENT

            spSheet1.Range(NameOf(V011_FCR_J.TUCHI_YMD)).Value = _V11.TUCHI_YMD
            spSheet1.Range(NameOf(V011_FCR_J.TUCHI_SYUDAN)).Value = _V11.TUCHI_SYUDAN
            spSheet1.Range(NameOf(V011_FCR_J.HITUYO_TETUDUKI_ZIKO)).Value = _V11.HITUYO_TETUDUKI_ZIKO

            Dim blnHANTEI As Boolean

            blnHANTEI = _V11.KOKYAKU_EIKYO_TUCHI_HANTEI_KB
            shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_T.Visible = blnHANTEI
            shSCR_KOKYAKU_EIKYO_TUCHI_HANTEI_KB_F.Visible = Not blnHANTEI

            blnHANTEI = _V11.OTHER_PROCESS_INFLUENCE_KB
            shSCR_OTHER_PROCESS_INFLUENCE_KB_T.Visible = blnHANTEI
            shSCR_OTHER_PROCESS_INFLUENCE_KB_F.Visible = Not blnHANTEI
            If blnHANTEI Then
                spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_INFLUENCE_MEMO)).Value = _V11.OTHER_PROCESS_INFLUENCE_MEMO
            End If

            blnHANTEI = _V11.FOLLOW_PROCESS_OUTFLOW_KB
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_T.Visible = blnHANTEI
            shSCR_FOLLOW_PROCESS_OUTFLOW_KB_F.Visible = Not blnHANTEI
            If blnHANTEI Then
                spSheet1.Range(NameOf(V011_FCR_J.FOLLOW_PROCESS_OUTFLOW_MEMO)).Value = _V11.FOLLOW_PROCESS_OUTFLOW_MEMO
            End If

            blnHANTEI = _V11.KOKYAKU_EIKYO_HANTEI_KB
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_T.Visible = blnHANTEI
            shSCR_KOKYAKU_EIKYO_HANTEI_KB_F.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_NAIYO.Visible = Not blnHANTEI
            shLINE_KAKUNIN_SYUDAN.Visible = Not blnHANTEI
            shLINE_TUCHI.Visible = Not blnHANTEI
            shLINE_KOKYAKU_EIKYO_ETC_COMMENT.Visible = Not blnHANTEI

            shLINE_SYONIN_SECTION.Visible = Not blnHANTEI
            shLINE_NAIYO.Visible = Not blnHANTEI
            shLINE_YMD.Visible = Not blnHANTEI

            If blnHANTEI Then
                '
                If (_V11.OTHER_PROCESS_INFLUENCE_KB = False) And (_V11.FOLLOW_PROCESS_OUTFLOW_KB = False) Then
                    shLINE_NAIYO.Visible = True
                    shLINE_YMD.Visible = True
                    '5-3�Ɏΐ�
                    shLINE_NAIYO.Top = 804
                    shLINE_YMD.Top = 804
                    shLINE_NAIYO.Height = 15
                    shLINE_YMD.Height = 15
                End If
            Else
                '�ڋq�ւ̉e���Ȃ�
                If (_V11.OTHER_PROCESS_INFLUENCE_KB = False) And (_V11.FOLLOW_PROCESS_OUTFLOW_KB = False) Then
                    '�S�ĂɎΐ�
                Else
                    '5-1,5-2�Ɏΐ�
                    shLINE_NAIYO.Height = 29
                    shLINE_YMD.Height = 29
                End If
            End If

            shLINE_KISYU1.Visible = (Not blnHANTEI) Or (Not _V11.FUTEKIGO_SEIHIN_MEMO.IsNulOrWS)
            shLINE_RANGE1.Visible = (Not blnHANTEI) Or (Not _V11.FUTEKIGO_SEIHIN_MEMO.IsNulOrWS)
            shLINE_KISYU2.Visible = (Not blnHANTEI) Or (Not _V11.KOKYAKU_EIKYO_MEMO.IsNulOrWS)
            shLINE_RANGE2.Visible = (Not blnHANTEI) Or (Not _V11.KOKYAKU_EIKYO_MEMO.IsNulOrWS)

            If blnHANTEI Then

                If (_V11.FUTEKIGO_SEIHIN_MEMO.IsNulOrWS) Then
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU1_NAME)).Value = _V11.KISYU1_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU2_NAME)).Value = _V11.KISYU2_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU3_NAME)).Value = _V11.KISYU3_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO1)).Value = _V11.BUHIN_INFO1
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO2)).Value = _V11.BUHIN_INFO2
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO3)).Value = _V11.BUHIN_INFO3
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO1)).Value = If(_V11.KISYU1_NAME.IsNulOrWS, "", _V11.SURYO1)
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO2)).Value = If(_V11.KISYU2_NAME.IsNulOrWS, "", _V11.SURYO2)
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO3)).Value = If(_V11.KISYU3_NAME.IsNulOrWS, "", _V11.SURYO3)
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM1)).Value = _V11.RANGE_FROM1
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM2)).Value = _V11.RANGE_FROM2
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM3)).Value = _V11.RANGE_FROM3
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO1)).Value = _V11.RANGE_TO1
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO2)).Value = _V11.RANGE_TO2
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO3)).Value = _V11.RANGE_TO3
                End If

                If (_V11.KOKYAKU_EIKYO_MEMO.IsNulOrWS) Then
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU4_NAME)).Value = _V11.KISYU4_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU5_NAME)).Value = _V11.KISYU5_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.KISYU6_NAME)).Value = _V11.KISYU6_NAME
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO4)).Value = _V11.BUHIN_INFO4
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO5)).Value = _V11.BUHIN_INFO5
                    spSheet1.Range(NameOf(V011_FCR_J.BUHIN_INFO6)).Value = _V11.BUHIN_INFO6
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO4)).Value = If(_V11.KISYU4_NAME.IsNulOrWS, "", _V11.SURYO4)
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO5)).Value = If(_V11.KISYU5_NAME.IsNulOrWS, "", _V11.SURYO5)
                    spSheet1.Range(NameOf(V011_FCR_J.SURYO6)).Value = If(_V11.KISYU6_NAME.IsNulOrWS, "", _V11.SURYO6)
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM4)).Value = _V11.RANGE_FROM4
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM5)).Value = _V11.RANGE_FROM5
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_FROM6)).Value = _V11.RANGE_FROM6
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO4)).Value = _V11.RANGE_TO4
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO5)).Value = _V11.RANGE_TO5
                    spSheet1.Range(NameOf(V011_FCR_J.RANGE_TO6)).Value = _V11.RANGE_TO6
                End If

                spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_NAIYOU)).Value = _V11.KOKYAKU_NOUNYU_NAIYOU
                spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_NOUNYU_YMD)).Value = _V11.KOKYAKU_NOUNYU_YMD
                spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_NAIYOU)).Value = _V11.ZAIKO_SIKAKE_NAIYOU
                spSheet1.Range(NameOf(V011_FCR_J.ZAIKO_SIKAKE_YMD)).Value = _V11.ZAIKO_SIKAKE_YMD

                spSheet1.Range(NameOf(V011_FCR_J.FUTEKIGO_SEIHIN_MEMO)).Value = _V11.FUTEKIGO_SEIHIN_MEMO
                spSheet1.Range(NameOf(V011_FCR_J.KOKYAKU_EIKYO_MEMO)).Value = _V11.KOKYAKU_EIKYO_MEMO
                spSheet1.Range(NameOf(V011_FCR_J.SYOCHI_MEMO)).Value = _V11.SYOCHI_MEMO
            End If

            If _V11.OTHER_PROCESS_INFLUENCE_KB Or _V11.FOLLOW_PROCESS_OUTFLOW_KB Then
                spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_NAIYOU)).Value = _V11.OTHER_PROCESS_NAIYOU
                spSheet1.Range(NameOf(V011_FCR_J.OTHER_PROCESS_YMD)).Value = _V11.OTHER_PROCESS_YMD
            End If

            If _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).Select(Function(r) r.ADD_YMDHNS).First < "202002140000" Then
                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iO�j�@�ʎ��|8"
            Else
                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iP�j�@�ʎ��|8"
            End If
            If _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_�N������).Select(Function(r) r.ADD_YMDHNS).First > "202005120000" Then
                spSheet1.Range("A1").Value = "�e�o�|�O�X�|�P�Q�iQ�j�@�ʎ��|8"
            End If

            For Each stage As ENM_CTS_STAGE In [Enum].GetValues(GetType(ENM_CTS_STAGE))
                If stage < ENM_CTS_STAGE._999_Closed Then
                    strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = stage And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_���F).FirstOrDefault?.SYONIN_YMDHNS
                    If Not strYMDHNS.IsNulOrWS Then
                        spSheet1.Range($"SYONIN_YMD{stage.Value}").Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                        spSheet1.Range($"SYONIN_NAME{stage.Value}").Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = stage).FirstOrDefault?.UPD_SYAIN_NAME
                    End If
                End If
            Next
            '-----�t�@�C���ۑ�
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire�� ����PDF���s����Ȃ炱����
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            '''PDF�\��
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Call FunOpenWorkbook(strFilePath)
            Call OpenExcelPrintPreview(strFilePath)

            'Excel��ƃt�@�C�����폜
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spRangeFrom = Nothing
            spRangeTo = Nothing
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

        End Try
    End Function

    Public Function FunOpenWorkbook(filePath As String) As Boolean
        Dim workbookView As New SpreadsheetGear.Windows.Forms.WorkbookView
        Try
            workbookView.GetLock()
            Dim workbookSet As SpreadsheetGear.IWorkbookSet = SpreadsheetGear.Factory.GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            Dim workbook As SpreadsheetGear.IWorkbook = workbookSet.Workbooks.Open(filePath)
            Dim worksheet As SpreadsheetGear.IWorksheet = workbook.Worksheets(0)

            'worksheet.ProtectContents = True
            'worksheet.WindowInfo.DisplayGridlines = False
            'worksheet.WindowInfo.DisplayHeadings = False
            'worksheet.WindowInfo.DisplayOutline = False
            'worksheet.WindowInfo.DisplayZeros = False

            workbookView.ActiveWorkbook = workbook
            workbookView.PrintPreview()

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            workbookView.ReleaseLock()
        End Try
    End Function

    ''' <summary>
    ''' NCR �X�e�[�W80 ���u����
    ''' </summary>
    ''' <returns></returns>
    Private Function FunGetST08SubPageName(entity As MODEL.V002_NCR_J) As ENM_NCR_STAGE80_TABPAGES
        Select Case entity.KOKYAKU_SAISYU_HANTEI_KB
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_�p�p����
                Return ENM_NCR_STAGE80_TABPAGES._1_�p�p���{�L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_�ԋp����
                Return ENM_NCR_STAGE80_TABPAGES._3_�ԋp���{�L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_�]�p����
                Return ENM_NCR_STAGE80_TABPAGES._4_�]�p��L�^
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_�ĉ��H����
                Return ENM_NCR_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
            Case Else
                Select Case entity.SAISIN_IINKAI_HANTEI_KB
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_�p�p����
                        Return ENM_NCR_STAGE80_TABPAGES._1_�p�p���{�L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_�ԋp����
                        Return ENM_NCR_STAGE80_TABPAGES._3_�ԋp���{�L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_�]�p����
                        Return ENM_NCR_STAGE80_TABPAGES._4_�]�p��L�^
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_�ĉ��H����
                        Return ENM_NCR_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                    Case Else
                        Select Case entity.JIZEN_SINSA_HANTEI_KB
                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_�p�p����
                                Return ENM_NCR_STAGE80_TABPAGES._1_�p�p���{�L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_�ԋp����
                                Return ENM_NCR_STAGE80_TABPAGES._3_�ԋp���{�L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_�]�p����
                                Return ENM_NCR_STAGE80_TABPAGES._4_�]�p��L�^
                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_�ĉ��H����
                                Return ENM_NCR_STAGE80_TABPAGES._2_�ĉ��H�w��_�L�^
                            Case Else
                                'Err
                        End Select
                End Select
        End Select
    End Function

#End Region

#Region "�Ɩ��O���[�v�����m�F"

    Public Function HasGYOMUGroupAuth(SYAIN_ID As Integer, GROUP_IDs As ENM_GYOMU_GROUP_ID())
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try
            Using DB As ClsDbUtility = DBOpen()
                For Each id In GROUP_IDs
                    sbSQL.Clear()
                    sbSQL.Append($"SELECT {NameOf(M011_SYAIN_GYOMU.SYAIN_ID)} FROM {NameOf(M011_SYAIN_GYOMU)}")
                    sbSQL.Append($" WHERE {NameOf(M011_SYAIN_GYOMU.SYAIN_ID)}={SYAIN_ID}")
                    sbSQL.Append($" AND {NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)}={id.Value}")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then Return True
                Next
            End Using

            Return False
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

#End Region

#Region "�񍐏��N���Ҕ���"

    Public Function IsIssuedUser(SYAIN_ID As Integer, SYONIN_HOKOKUSYO_ID As Integer, HOKOKU_NO As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try

            sbSQL.Append($"SELECT *")
            sbSQL.Append($" FROM {NameOf(V004_HOKOKU_SOUSA)}")
            sbSQL.Append($" WHERE (SELECT CASE {NameOf(V004_HOKOKU_SOUSA.SOUSA_KB)} WHEN '{ENM_SOUSA_KB._5_�]��.Value}'")
            sbSQL.Append($"     THEN {NameOf(V004_HOKOKU_SOUSA.MODOSI_SAKI_SYAIN_ID)} ELSE {NameOf(V004_HOKOKU_SOUSA.SYAIN_ID)} END)={SYAIN_ID}")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)}={SYONIN_HOKOKUSYO_ID}")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.HOKOKU_NO)}='{HOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.SYONIN_JUN)}={ENM_NCR_STAGE._10_�N������.Value}")

            'sbSQL.Append($"SELECT {NameOf(V007_NCR_CAR.KISO_TANTO_ID)} FROM {NameOf(V007_NCR_CAR)}")
            'sbSQL.Append($" WHERE {NameOf(V007_NCR_CAR.KISO_TANTO_ID)}={SYAIN_ID}")
            'sbSQL.Append($" AND {NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={SYONIN_HOKOKUSYO_ID}")
            'sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{HOKOKU_NO}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#End Region

End Module