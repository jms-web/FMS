Imports JMS_COMMON.ClsPubMethod
Imports MODEL

Namespace Context
    Public Module mdlConst

#Region "PG�A�Z���u���R�[�h"
        ''' <summary>
        ''' �R�[�h�}�X�^
        ''' </summary>
        Public Const CON_PG_M010 As String = "FMS_M010.exe"


#End Region

#Region "�V�X�e���R�[�h"

        ''' <summary>
        ''' ���Ў����CD
        ''' </summary>
        Public Const CON_MYCOMPANY_CODE As Integer = 99999

        ''' <summary>
        ''' �����敪�t���O �r�b�g���Z
        ''' </summary>
        <Flags>
        Public Enum ENM_ZOKUSEI_KB
            _1_���i = 1
            _2_���Ӑ� = 2
            _4_�d���� = 4
        End Enum

        ''' <summary>
        ''' ���Ϗ󋵋敪
        ''' </summary>
        Public Enum ENM_MITU_STATUS
            _0_���� = 0
            _1_��z�� = 1
            _2_����� = 2
            _3_�����J�n = 3
            _4_���� = 4
            _5_�o�� = 5
            _6_����� = 6
            _8_�ۗ� = 8
            _9_���� = 9
        End Enum

        ''' <summary>
        ''' ������
        ''' </summary>
        Public Enum ENM_TORI_SYU
            _0_���p = 0
            _1_���Ӑ� = 1
            _2_�d���� = 2
        End Enum

        ''' <summary>
        ''' �ғ��敪
        ''' </summary>
        Public Enum ENM_KADO
            _0_��ғ� = 0
            _1_�ғ� = 1
            _9_��\�� = 9
        End Enum

        ''' <summary>
        ''' �݌Ɏ��
        ''' </summary>
        Public Enum ENM_ZAIKO_SYUBETU
            _0_�ޗ��݌� = 0
            _1_�w���i�݌� = 1
            _2_�d�|�݌� = 2
            _3_���i�݌� = 3
        End Enum

        ''' <summary>
        ''' �����X�e�[�^�X
        ''' </summary>
        Public Enum ENM_HACCYU_STATUS
            _0_������ = 0
            _1_������ = 1
            _2_���׍� = 2
            _9_��� = 9
        End Enum

        ''' <summary>
        ''' �\���敪
        ''' </summary>
        Public Enum ENM_KOSEI_KB
            _0_�ޗ� = 0
            _1_�w���i = 1
            _2_���i = 2
            _3_���Օi��� = 3
        End Enum
#End Region

    End Module
End Namespace


Public Module mdlDBContext

#Region "�f�[�^�e�[�u���ϐ�"

    ''' <summary>
    ''' ���j���[�Z�N�V����
    ''' </summary>
    Public tblMenuSection As DataTableEx

    ''' <summary>
    ''' �R�[�h�}�X�^���ږ�
    ''' </summary>
    Public tblKOMO_NM As DataTableEx

    '''' <summary>
    '''' �E��
    '''' </summary>
    'Public tblSYOKUBAN As DataTableEx

    '''' <summary>
    '''' ���Ϗ󋵋敪
    '''' </summary>
    'Public tblMITU_KB As DataTableEx

    '''' <summary>
    '''' ���i�敪
    '''' </summary>
    'Public tblSEIHIN_KB As DataTableEx

    '''' <summary>
    '''' ���Ӑ�
    '''' </summary>
    'Public tblTOKUI As DataTableEx

    '''' <summary>
    '''' �S��
    '''' </summary>
    'Public tblTANTO As DataTableEx

    '''' <summary>
    '''' �[�������敪
    '''' </summary>
    'Public tblTAX_HASU_KB As DataTableEx

    '''' <summary>
    '''' ����
    '''' </summary>
    'Public tblZOKUSEI As DataTableEx

    '''' <summary>
    '''' ��������
    '''' </summary>
    'Public tblZOKUSEI_K As DataTableEx

    '''' <summary>
    '''' ����CD
    '''' </summary>
    'Public tblZOKUSEI_CD As DataTableEx

    '''' <summary>
    '''' ������
    '''' </summary>
    'Public tblZOKUSEI_NAME As DataTableEx
    '''' <summary>
    '''' ���x���敪
    '''' </summary>
    'Public tblZISI_KB As DataTableEx

    ''''' <summary>
    ''''' ����Ȃ�
    ''''' </summary>
    ''Public tblToF As DataTableEx

    '''' <summary>
    '''' �P�ʋ敪
    '''' </summary>
    'Public tblTANI_KBN As DataTableEx

    '''' <summary>
    '''' �d���O���敪
    '''' </summary>
    'Public tblNAIGAI_KB As DataTableEx

    '''' <summary>
    '''' ������
    '''' </summary>
    'Public tblTORI_SYU As DataTableEx

    '''' <summary>
    '''' ���ŋ敪
    '''' </summary>
    'Public tblURI_KBN As DataTableEx

    '''' <summary>
    '''' �d�ŋ敪
    '''' </summary>
    'Public tblSHI_KBN As DataTableEx

    '''' <summary>
    '''' ��E�敪
    '''' </summary>
    'Public tblYAKU_KBN As DataTableEx

    '''' <summary>
    '''' ���ԋ敪
    '''' </summary>
    'Public tblCYOKKAN_KBN As DataTableEx

    '''' <summary>
    '''' ��
    '''' </summary>
    'Public tblBU As DataTableEx

    '''' <summary>
    '''' ��
    '''' </summary>
    'Public tblKA As DataTableEx

    '''' <summary>
    '''' �@�B��
    '''' </summary>
    'Public tblKIKAI_NAME As DataTableEx

    '''' <summary>
    '''' �@�B���[�J�[
    '''' </summary>
    'Public tblKIKAI_MAKER As DataTableEx

    '''' <summary>
    '''' �ǉ��H�敪
    '''' </summary>
    'Public tblTUIKAKOU_KBN As DataTableEx

    '''' <summary>
    '''' �\���敪
    '''' </summary>
    'Public tblKOUSEI_KBN As DataTableEx

    '''' <summary>
    '''' �Ǘ��敪
    '''' </summary>
    'Public tblKANRI_KBN As DataTableEx

    '''' <summary>
    '''' �V�x�敪
    '''' </summary>
    'Public tblYUKYU_KBN As DataTableEx

    '''' <summary>
    '''' ����旪��
    '''' </summary>
    'Public tblTORI_SAKI As DataTableEx

    '''' <summary>
    '''' �����CD
    '''' </summary>
    'Public tblTORI_SAKI_CD As DataTableEx

    '''' <summary>
    '''' ���i�i��
    '''' </summary>
    'Public tblHINBAN As DataTableEx

    '''' <summary>
    '''' ���i�i��
    '''' </summary>
    'Public tblHINMEI As DataTableEx

    '''' <summary>
    '''' ������CD
    '''' </summary>
    'Public tblHACYU_CD As DataTableEx

    ''''' <summary>
    ''''' �i��
    ''''' </summary>
    ''Public tblHINBAN As DataTableEx



    '''' <summary>
    '''' ���RCD
    '''' </summary>
    'Public tblRIYU_CD As DataTableEx

    '''' <summary>
    '''' �ގ�
    '''' </summary>
    'Public tblZAISITU As DataTableEx

    '''' <summary>
    '''' �H��
    '''' </summary>
    'Public tblKOTEI As DataTableEx

    '''' <summary>
    '''' �J�����_�[
    '''' </summary>
    'Public tblCALENDAR As DataTableEx

#End Region

#Region "�f�[�^�e�[�u���擾"
    ''' <summary>
    ''' �R���{�{�b�N�X���Ŏg�p����R�[�h�e�[�u�����擾����
    ''' </summary>
    ''' <param name="strKOMOKU">�R�[�h�}�X�^�̍��ږ��܂��͌ŗL�̃f�[�^�Z�b�g���ޖ�</param>
    ''' <param name="dt">�R�[�h�e�[�u�����Z�b�g����f�[�^�e�[�u��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunGetCodeDataTable(ByVal DB As ClsDbUtility, ByVal strKOMOKU As String, ByRef dt As DataTableEx, Optional ByVal strWhere As String = "", Optional ByVal blnIncludeDeleted As Boolean = True) As Boolean
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intCNT As Integer

        Try
            '������
            dt = New DataTableEx

            Select Case strKOMOKU

                'Case "�S��"
                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM03_TANTO) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY SYOKUBAN")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("SYOKUBAN", GetType(String))
                '    dt.Columns.Add("TANTO_NAME", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            '
                '            Trow("DISP") = .Rows(intCNT).Item("TANTO_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("TANTO_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("SYOKUBAN") = .Rows(intCNT).Item("SYOKUBAN")
                '            Trow("TANTO_NAME") = .Rows(intCNT).Item("TANTO_NAME")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "����旪��"
                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")

                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY TORI_CD")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("SIIRE_GAICYU_KB", GetType(String))
                '    dt.Columns.Add("SYOKUCHI_FLG", GetType(Boolean))
                '    dt.Columns.Add("TORI_TANTO_NAME", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            '
                '            Trow("DISP") = .Rows(intCNT).Item("TORI_R_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("SIIRE_GAICYU_KB") = .Rows(intCNT).Item("SIIRE_GAICYU_KB")
                '            Trow("SYOKUCHI_FLG") = CBool(.Rows(intCNT).Item("SYOKUCHI_FLG"))
                '            Trow("TORI_TANTO_NAME") = .Rows(intCNT).Item("TORI_TANTO_NAME")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "�����CD"
                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY TORI_CD")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("TORI_SYU", GetType(String))
                '    dt.Columns.Add("SIIRE_GAICYU_KB", GetType(String))
                '    dt.Columns.Add("SYOKUCHI_FLG", GetType(Boolean))
                '    dt.Columns.Add("TORI_TANTO_NAME", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            '
                '            Trow("DISP") = .Rows(intCNT).Item("TORI_CD")
                '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("TORI_SYU") = .Rows(intCNT).Item("TORI_SYU")
                '            Trow("SIIRE_GAICYU_KB") = .Rows(intCNT).Item("SIIRE_GAICYU_KB")
                '            Trow("SYOKUCHI_FLG") = CBool(.Rows(intCNT).Item("SYOKUCHI_FLG"))
                '            Trow("TORI_TANTO_NAME") = .Rows(intCNT).Item("TORI_TANTO_NAME")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "������CD"
                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY TORI_CD")
                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("TORI_NAME", GetType(String))
                '    dt.Columns.Add("TORI_CD", GetType(Integer))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("DISP") = .Rows(intCNT).Item("TORI_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "�E��"
                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM03_TANTO) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY TANTO_CD")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("TANTO_CD", GetType(Integer))
                '    dt.Columns.Add("SYOKUBAN", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            '
                '            Trow("DISP") = .Rows(intCNT).Item("SYOKUBAN")
                '            Trow("VALUE") = .Rows(intCNT).Item("SYOKUBAN")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With



                'Case "�J�����_�["

                '    '����
                '    sbSQL.Append("SELECT * FROM " & NameOf(M12_CALENDAR) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & " ")
                '    End If
                '    sbSQL.Append(" ORDER BY YYYYMMDD")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("KADO_KBN", GetType(String))
                '    dt.Columns.Add("H_KANRI_NO", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("DISP") = .Rows(intCNT).Item("YYYYMMDD").ToString
                '            Trow("VALUE") = .Rows(intCNT).Item("YYYYMMDD").ToString
                '            Trow("KADO_KBN") = .Rows(intCNT).Item("KADO_KBN").ToString
                '            Trow("H_KANRI_NO") = .Rows(intCNT).Item("H_KANRI_NO").ToString
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With


                'Case "����"

                '    sbSQL.Append("SELECT *")
                '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    Else
                '        sbSQL.Append("WHERE 0=0")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" And DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY DISP_ORDER")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}
                '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "��", "")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "������"

                '    sbSQL.Append("SELECT *")
                '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    Else
                '        sbSQL.Append("WHERE 0=0")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" And DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY DISP_ORDER")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}
                '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "��", "")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "��������"

                '    sbSQL.Append("SELECT *")
                '    sbSQL.Append(" FROM " & NameOf(VWM16_ZOKUSEI_K) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    Else
                '        sbSQL.Append("WHERE 0=0")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" And DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY ZOKUSEI_CD, DISP_ORDER")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("ZOKUSEI_CD"), dt.Columns("VALUE")}
                '    dt.Columns.Add("ZOKUSEI_CD", GetType(Integer))
                '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                '    dt.Columns.Add("COMP_KEY", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_K_NAME")
                '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_K_NAME")
                '            Trow("COMP_KEY") = .Rows(intCNT).Item("ZOKUSEI_CD") & "," & .Rows(intCNT).Item("ZOKUSEI_K_CD")
                '            Trow("ZOKUSEI_CD") = .Rows(intCNT).Item("ZOKUSEI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "����CD"
                '    sbSQL.Append("SELECT *")
                '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    Else
                '        sbSQL.Append("WHERE 0=0")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" And DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY ZOKUSEI_CD")

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("ZOKUSEI_CD")}
                '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))


                '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_CD")
                '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "��", "")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

                'Case "NullTable"

                '    '��̃R�[�h�e�[�u�����쐬���A�ォ�獀�ڂ�ǉ�����ۂɎg�p����
                '    '�ŗL�̍��ڂŁA�R�[�h�}�X�^�ɓo�^����قǂł��Ȃ��ꍇ�Ɏg���H

                '    '��ǉ�
                '    'dataTable.Columns.Add("DISP", GetType(String))
                '    'dataTable.Columns.Add("VALUE", GetType(String))

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}
                'Case "BlankTable"

                '    '��L�[�ݒ�
                '    dt.PrimaryKey = {dt.Columns("VALUE")}
                '    Dim Trow1 As DataRow = dt.NewRow()
                '    Trow1("VALUE") = " "
                '    Trow1("DISP") = " "
                '    dt.Rows.Add(Trow1)

                Case "���ږ�"
                    '����
                    sbSQL.Append("SELECT DISTINCT ITEM_NAME,DEL_YMDHNS FROM " & NameOf(M001_SETTING) & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere)
                    Else
                        sbSQL.Append("WHERE 0=0")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND RTRIM(DEL_YMDHNS)=''")
                    End If
                    sbSQL.Append(" ORDER BY ITEM_NAME")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            If dt.Rows.Contains(.Rows(intCNT).Item("ITEM_NAME")) = False Then
                                Dim Trow As DataRow = dt.NewRow()
                                Trow("DISP") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("VALUE") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("DEL_FLG") = IIf(.Rows(intCNT).Item("DEL_YMDHNS").ToString.Trim = "", False, True)
                                dt.Rows.Add(Trow)
                            End If
                        Next intCNT
                    End With

                Case Else

                    '����
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM001_SETTING) & " WHERE ITEM_NAME='" & strKOMOKU & "'")
                    If strWhere <> "" Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY DISP_ORDER,DEL_FLG")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    'dt.Columns.Add("DEF_FLG", GetType(Boolean))

                    dsList = DB.GetDataSet(sbSQL.ToString, True)

                    If dsList IsNot Nothing Then
                        For intCNT = 0 To dsList.Tables(0).Rows.Count - 1
                            With dsList.Tables(0).Rows(intCNT)
                                Dim Trow As DataRow = dt.NewRow()
                                'dataTable�Ƀ��R�[�h�f�[�^��ǉ�
                                Trow("DISP") = .Item("ITEM_DISP")
                                Trow("VALUE") = .Item("ITEM_VALUE")
                                Trow("DEL_FLG") = CBool(.Item("DEL_FLG"))
                                Trow("DISP_ORDER") = Val(.Item("DISP_ORDER"))
                                Trow("DEF_FLG") = CBool(.Item("DEF_FLG"))
                                dt.Rows.Add(Trow)
                            End With
                        Next intCNT
                    Else
                        'UNDONE: data null exception
                        'Throw New ArgumentNullException("", "")
                    End If

            End Select

            '�e�[�u���̕ύX���R�~�b�g
            dt.AcceptChanges()

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

End Module







