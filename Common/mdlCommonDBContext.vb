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

#Region "����"
        Public Enum ENM_BUMON_KB
            _1_���h = 1
            _2_LP = 2
            _3_������ = 3
        End Enum

        ''' <summary>
        ''' ���F�񍐏�ID
        ''' </summary>
        Public Enum ENM_SYONIN_HOKOKUSYO_ID
            _1_NCR = 1
            _2_CAR = 2
        End Enum
#End Region

    End Module
End Namespace


Public Module mdlDBContext

#Region "�f�[�^�e�[�u���ϐ�"

#Region "�V�X�e��"
    ''' <summary>
    ''' ���j���[�Z�N�V����
    ''' </summary>
    Public tblMenuSection As DataTableEx

    ''' <summary>
    ''' �R�[�h�}�X�^���ږ�
    ''' </summary>
    Public tblKOMO_NM As DataTableEx

    ''' <summary>
    ''' �S��
    ''' </summary>
    Public tblTANTO As DataTableEx

    ''' <summary>
    ''' �v�ۋ敪
    ''' </summary>
    Public tblYOHI_KB As DataTableEx

    ''' <summary>
    ''' �����
    ''' </summary>
    Public tblTORIHIKI As DataTableEx

#End Region

#Region "����"

    ''' <summary>
    ''' ����
    ''' </summary>
    Public tblBUMON As DataTableEx

    ''' <summary>
    ''' �@��
    ''' </summary>
    Public tblKISYU As DataTableEx

    ''' <summary>
    ''' ���i�ԍ�
    ''' </summary>
    Public tblBUHIN As DataTableEx

    ''' <summary>
    ''' �Г�CD
    ''' </summary>
    Public tblSYANAI_CD As DataTableEx

    ''' <summary>
    '''�����敪
    ''' </summary>
    Public tblBUSYO_KB As DataTableEx

    ''' <summary>
    '''����
    ''' </summary>
    Public tblBUSYO As DataTableEx

    ''' <summary>
    '''�Ј��敪
    ''' </summary>
    Public tblSYAIN_KB As DataTableEx

    ''' <summary>
    '''��E�敪
    ''' </summary>
    Public tblYAKUSYOKU_KB As DataTableEx

    ''' <summary>
    '''��s�敪
    ''' </summary>
    Public tblDAIKO_KB As DataTableEx

    ''' <summary>
    '''�q��@�_��敪
    ''' </summary>
    Public tblKK_KEIYAKU_KB As DataTableEx

    ''' <summary>
    '''LP�_��敪
    ''' </summary>
    Public tblLP_KEIYAKU_KB As DataTableEx

    ''' <summary>
    '''�����ތ_��敪
    ''' </summary>
    Public tblFK_KEIYAKU_KB As DataTableEx

    ''' <summary>
    '''���C��敪
    ''' </summary>
    Public tblRIKUKAIKU_KB As DataTableEx

#End Region

#Region "�s�K���֘A"

    ''' <summary>
    ''' 
    ''' </summary>
    Public tblSYONIN_HOKOKUSYO_ID As DataTableEx


    ''' <summary>
    ''' ���i���u(NCR �X�e�[�W
    ''' </summary>
    Public tblNCR As DataTableEx

    ''' <summary>
    ''' �������u(CAR �X�e�[�W
    ''' </summary>
    Public tblCAR As DataTableEx

    ''' <summary>
    ''' ���O�R������敪
    ''' </summary>
    Public tblJIZEN_SINSA_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' �ĐR�ψ����敪
    ''' </summary>
    Public tblSAISIN_IINKAI_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' �s�K���敪
    ''' </summary>
    Public tblFUTEKIGO_KB As DataTableEx

    ''' <summary>
    ''' �s�K�����׋敪
    ''' </summary>
    Public tblFUTEKIGO_S_KB As DataTableEx

    ''' <summary>
    ''' �s�K����ԋ敪
    ''' </summary>
    Public tblFUTEKIGO_STATUS_KB As DataTableEx

    ''' <summary>
    ''' �ڋq����w���敪
    ''' </summary>
    Public tblKOKYAKU_HANTEI_SIJI_KB As DataTableEx

    ''' <summary>
    ''' �ڋq�ŏI����敪
    ''' </summary>
    Public tblKOKYAKU_SAISYU_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' ���{�v���敪
    ''' </summary>
    Public tblKONPON_YOIN_KB As DataTableEx

    ''' <summary>
    ''' �A�ӍH���敪
    ''' </summary>
    Public tblKISEKI_KOUTEI_KB As DataTableEx

    ''' <summary>
    ''' �������ʋ敪 ���i�A�s���i
    ''' </summary>
    Public tblKENSA_KEKKA_KB As DataTableEx

    ''' <summary>
    ''' �������͋敪
    ''' </summary>
    Public tblGENIN_BUNSEKI_KB As DataTableEx

    ''' <summary>
    ''' ���F�S��
    ''' </summary>
    Public tblTANTO_SYONIN As DataTableEx
    ''' <summary>
    ''' ���F�S���ꗗ
    ''' </summary>
    Public tblTANTO_SYONINList As DataTableEx

    ''' <summary>
    ''' �ݖ���e
    ''' </summary>
    Public tblSETUMON_NAIYO As DataTableEx

    ''' <summary>
    ''' �p�p���@
    ''' </summary>
    Public tblHAIKYAKU_KB As DataTableEx

    ''' <summary>
    ''' ���F����敪
    ''' </summary>
    Public tblSYONIN_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' �@�����
    ''' </summary>
    Public tblKISYU_J As DataTableEx

    ''' <summary>
    ''' ���i�ԍ�����
    ''' </summary>
    Public tblBUHIN_J As DataTableEx

    ''' <summary>
    ''' �Г�CD����
    ''' </summary>
    Public tblSYANAI_CD_J As DataTableEx

    ''' <summary>
    ''' �Ј�
    ''' </summary>
    Public tblSYAIN As DataTableEx



#End Region

#End Region

#Region "�f�[�^�擾�֐�"

#Region "������"
    Public Function FunGetBUMON_INFO(ByVal intSyainID As Integer) As (BUMON_KB As String, BUMON_NAME As String)
        Dim dsList As New System.Data.DataSet

        Dim strSQL As String = <sql><![CDATA[
            SELECT
                  M004.SYAIN_ID
                , M004.SYAIN_NO
                , M005.BUSYO_ID
                , M002.BUMON_KB
                ,(SELECT ITEM_DISP FROM M001_SETTING AS M001 WHERE M001.ITEM_NAME='����敪' AND M001.ITEM_VALUE=M002.BUMON_KB) AS BUMON_NAME
            FROM
                M004_SYAIN AS M004
                LEFT JOIN M005_SYOZOKU_BUSYO AS M005
                    ON M004.SYAIN_ID = M005.SYAIN_ID 
                LEFT JOIN M002_BUSYO AS M002
                    ON M005.BUSYO_ID = M002.BUSYO_ID 
            WHERE M005.KENMU_FLG = '0' AND M004.SYAIN_ID = {0}
            ]]></sql>.Value.Trim

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(String.Format(strSQL, intSyainID), False)
        End Using
        With dsList.Tables(0)
            If .Rows.Count > 0 Then
                Return (.Rows(0).Item("BUMON_KB"), .Rows(0).Item("BUMON_NAME"))
            Else
                Return ("", "")
            End If
        End With
    End Function


#End Region



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
            'CHECK: �� VALUE�����l�ł��R���{�{�b�N�X�Ƀo�C���h�����ꍇ��DataTableEx�̏������p�����[�^��"Integer"���w�肷�邱��

            dt = New DataTableEx

            Select Case strKOMOKU

#Region "               ���F�񍐏�ID"
                Case "���F�񍐏�ID"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & "M013_SYONIN_HOKOKU" & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        'sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID")


                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_R_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               NCR"
                Case "NCR"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM014_SYONIN_ROUT) & " ")
                    sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=1")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_JUN")

                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") '.Rows(intCNT).Item("SYONIN_JUN") & " " & .Rows(intCNT).Item("SYONIN_NAIYO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               CAR"
                Case "CAR"
                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM014_SYONIN_ROUT) & " ")
                    sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=2")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID, SYONIN_JUN")

                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") '.Rows(intCNT).Item("SYONIN_JUN") & " " & .Rows(intCNT).Item("SYONIN_NAIYO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �S��"
                Case "�S��"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM004_SYAIN) & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYAIN_ID")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYOKUBAN", GetType(String))
                    dt.Columns.Add("SYAIN_NO", GetType(String))
                    dt.Columns.Add("SYAIN_KB", GetType(String))
                    dt.Columns.Add("YAKUSYOKU_KB", GetType(String))
                    dt.Columns.Add("DAIKO_KB", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYAIN_NO") = .Rows(intCNT).Item("SYAIN_NO")
                            Trow("SYAIN_KB") = .Rows(intCNT).Item("SYAIN_KB")
                            Trow("YAKUSYOKU_KB") = .Rows(intCNT).Item("YAKUSYOKU_KB")
                            Trow("DAIKO_KB") = .Rows(intCNT).Item("DAIKO_KB")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               ���F�S��"
                Case "���F�S��"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & "V001_SYONIN_TANTO" & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
                    dt.Columns.Add("SYONIN_JUN", GetType(Integer))

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("SYONIN_HOKOKUSYO_ID"), dt.Columns("SYONIN_JUN"), dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")

                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               ���F�S���ꗗ"
                Case "���F�S���ꗗ"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT DISTINCT SYAIN_ID,SIMEI,DEL_FLG FROM " & "V001_SYONIN_TANTO" & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            If dt.Rows.Contains(.Rows(intCNT).Item("SYAIN_ID")) = False Then
                                Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                                Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                                Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                                dt.Rows.Add(Trow)
                            End If
                        Next intCNT
                    End With
#End Region

#Region "               ���߂���"
                Case "���߂���"
                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & "V003_SYONIN_J_KANRI" & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    'If blnIncludeDeleted = False Then
                    '    sbSQL.Append(" AND DEL_FLG='0'")
                    'End If

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
                    dt.Columns.Add("SYONIN_JUN", GetType(Integer))
                    dt.Columns.Add("SYAIN_NAME", GetType(String))
                    dt.Columns.Add("HOKOKU_NO", GetType(String))

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("SYONIN_HOKOKUSYO_ID"), dt.Columns("SYONIN_JUN"), dt.Columns("HOKOKU_NO")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_NAIYO") & " " & .Rows(intCNT).Item("SYAIN_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("SYAIN_NAME") = .Rows(intCNT).Item("SYAIN_NAME")
                            'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                            Trow("HOKOKU_NO") = .Rows(intCNT).Item("HOKOKU_NO")

                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �@��"
                Case "�@��"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM105_KISYU) & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY KISYU_ID")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    'dt.Columns.Add("KISYU", GetType(String))
                    dt.Columns.Add("BUMON_KB", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("DISP") = .Rows(intCNT).Item("KISYU_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("KISYU_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            'Trow("KISYU") = .Rows(intCNT).Item("KISYU")
                            Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               ����"
                Case "����"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM002_BUSYO) & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY BUSYO_ID")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("BUSYO_ID", GetType(String))
                    dt.Columns.Add("BUSYO_NAME", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("DISP") = .Rows(intCNT).Item("BUSYO_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("BUSYO_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �Г�CD"
                Case "�Г�CD"
                    '����
                    sbSQL.Append("SELECT DISTINCT BUMON_KB,SYANAI_CD,BUHIN_BANGO,BUHIN_NAME,KISYU_ID,TOKUI_ID,DEL_FLG FROM " & "VWM107_BUHIN_KISYU" & " ")
                    sbSQL.Append("WHERE BUMON_KB='2'")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYANAI_CD")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("BUMON_KB"), dt.Columns("TOKUI_ID"), dt.Columns("VALUE")}

                    dt.Columns.Add("BUMON_KB", GetType(String))
                    dt.Columns.Add("BUHIN_BANGO", GetType(String))
                    dt.Columns.Add("BUHIN_NAME", GetType(String))
                    dt.Columns.Add("KISYU_ID", GetType(Integer))
                    dt.Columns.Add("TOKUI_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("VALUE") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                            Trow("BUHIN_BANGO") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                            Trow("KISYU_ID") = .Rows(intCNT).Item("KISYU_ID")
                            Trow("TOKUI_ID") = .Rows(intCNT).Item("TOKUI_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �Г�CD����"
                Case "�Г�CD����"
                    '����
                    sbSQL.Append("SELECT DISTINCT")
                    sbSQL.Append("  V007.BUHIN_BANGO")
                    sbSQL.Append(" ,V106.BUMON_KB")
                    sbSQL.Append(" ,V106.BUHIN_NAME")
                    sbSQL.Append(" ,V106.SYANAI_CD")
                    sbSQL.Append(" ,V106.KISYU_ID")
                    sbSQL.Append(" ,V106.TOKUI_ID")
                    sbSQL.Append(" FROM V007_NCR_CAR V007")
                    sbSQL.Append(" LEFT JOIN VWM107_BUHIN_KISYU V106")
                    sbSQL.Append(" ON V007.SYANAI_CD = V106.SYANAI_CD")
                    sbSQL.Append("�@WHERE V007.BUMON_KB='2'")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYANAI_CD")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("BUMON_KB"), dt.Columns("TOKUI_ID"), dt.Columns("VALUE")}

                    dt.Columns.Add("BUMON_KB", GetType(String))
                    dt.Columns.Add("BUHIN_BANGO", GetType(String))
                    dt.Columns.Add("BUHIN_NAME", GetType(String))
                    dt.Columns.Add("KISYU_ID", GetType(Integer))
                    dt.Columns.Add("TOKUI_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            If Not .Rows(intCNT).Item("SYANAI_CD").ToString.IsNullOrWhiteSpace Then
                                Trow("DISP") = .Rows(intCNT).Item("SYANAI_CD")
                                Trow("VALUE") = .Rows(intCNT).Item("SYANAI_CD")
                                'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                                Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                                Trow("BUHIN_BANGO") = .Rows(intCNT).Item("BUHIN_BANGO")
                                Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                                Trow("KISYU_ID") = .Rows(intCNT).Item("KISYU_ID")
                                Trow("TOKUI_ID") = .Rows(intCNT).Item("TOKUI_ID")
                                dt.Rows.Add(Trow)
                            End If
                        Next intCNT
                    End With
#End Region

#Region "               ���i�ԍ�"
                Case "���i�ԍ�"
                    '����
                    sbSQL.Append("SELECT DISTINCT BUMON_KB,BUHIN_BANGO,BUHIN_NAME,SYANAI_CD,KISYU_ID,TOKUI_ID,DEL_FLG FROM " & "VWM107_BUHIN_KISYU" & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY BUHIN_BANGO")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("BUMON_KB"), dt.Columns("TOKUI_ID"), dt.Columns("VALUE")}

                    dt.Columns.Add("BUMON_KB", GetType(String))
                    dt.Columns.Add("BUHIN_NAME", GetType(String))
                    dt.Columns.Add("SYANAI_CD", GetType(String))
                    dt.Columns.Add("KISYU_ID", GetType(Integer))
                    dt.Columns.Add("TOKUI_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("VALUE") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                            Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                            Trow("SYANAI_CD") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("KISYU_ID") = .Rows(intCNT).Item("KISYU_ID")
                            Trow("TOKUI_ID") = .Rows(intCNT).Item("TOKUI_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               ���i�ԍ�����"
                Case "���i�ԍ�����"
                    '����
                    sbSQL.Append("SELECT DISTINCT")
                    sbSQL.Append("  V007.BUHIN_BANGO")
                    sbSQL.Append(" ,V106.BUMON_KB")
                    sbSQL.Append(" ,V106.BUHIN_NAME")
                    sbSQL.Append(" ,V106.SYANAI_CD")
                    sbSQL.Append(" ,V106.KISYU_ID")
                    sbSQL.Append(" ,V106.TOKUI_ID")
                    sbSQL.Append(" FROM V007_NCR_CAR V007")
                    sbSQL.Append(" LEFT JOIN VWM107_BUHIN_KISYU V106")
                    sbSQL.Append(" ON V007.BUHIN_BANGO = V106.BUHIN_BANGO")

                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY BUHIN_BANGO")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("BUMON_KB"), dt.Columns("TOKUI_ID"), dt.Columns("VALUE")}

                    dt.Columns.Add("BUMON_KB", GetType(String))
                    dt.Columns.Add("BUHIN_NAME", GetType(String))
                    dt.Columns.Add("SYANAI_CD", GetType(String))
                    dt.Columns.Add("KISYU_ID", GetType(Integer))
                    dt.Columns.Add("TOKUI_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            'If dt.Rows.Contains(.Rows(intCNT).Item("BUHIN_BANGO")) = False Then
                            Trow("DISP") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("VALUE") = .Rows(intCNT).Item("BUHIN_BANGO")
                            'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                            Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                            Trow("SYANAI_CD") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("KISYU_ID") = .Rows(intCNT).Item("KISYU_ID")
                            Trow("TOKUI_ID") = .Rows(intCNT).Item("TOKUI_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �@�����"
                Case "�@�����"

                    dt = New DataTableEx("System.Int32")

                    sbSQL.Append("SELECT DISTINCT ")
                    sbSQL.Append(" V007.KISYU_ID")
                    sbSQL.Append(" ,M105.BUMON_KB")
                    'sbSQL.Append(" ,M105.KISYU")
                    sbSQL.Append(" ,M105.KISYU_NAME")
                    sbSQL.Append(" FROM V007_NCR_CAR V007")
                    sbSQL.Append(" LEFT JOIN M105_KISYU M105")
                    sbSQL.Append(" ON V007.KISYU_ID = M105.KISYU_ID")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY KISYU_ID")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    'dt.Columns.Add("KISYU", GetType(String))
                    dt.Columns.Add("BUMON_KB", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("DISP") = .Rows(intCNT).Item("KISYU_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("KISYU_ID")
                            'Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            'Trow("KISYU") = .Rows(intCNT).Item("KISYU")
                            Trow("BUMON_KB") = .Rows(intCNT).Item("BUMON_KB")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               �����"
                Case "�����"
                    '����
                    sbSQL.Append("SELECT ")
                    sbSQL.Append("TORI_ID")
                    sbSQL.Append(",TORI_NAME")
                    sbSQL.Append(",TORI_KB")
                    sbSQL.Append(",POST")
                    sbSQL.Append(",ADD1")
                    sbSQL.Append(",ADD2")
                    sbSQL.Append(",ADD3")
                    sbSQL.Append(",TEL")
                    sbSQL.Append(",FAX")
                    sbSQL.Append(",DEL_YMDHNS")
                    sbSQL.Append(",CASE DEL_YMDHNS ")
                    sbSQL.Append(" WHEN '' THEN '0' ")
                    sbSQL.Append(" ELSE '1' ")
                    sbSQL.Append(" END AS DEL_FLG ")
                    sbSQL.Append(" FROM M101_TORIHIKI ")

                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_YMDHNS=' ' ")
                    End If
                    sbSQL.Append(" ORDER BY TORI_NAME")

                    '��L�[�ݒ�
                    dt.PrimaryKey = {dt.Columns("TORI_CD")}

                    dt.Columns.Add("TORI_ID", GetType(Integer))
                    dt.Columns.Add("TORI_NAME", GetType(String))
                    dt.Columns.Add("TORI_KB", GetType(String))
                    dt.Columns.Add("POST", GetType(String))
                    dt.Columns.Add("ADD1", GetType(String))
                    dt.Columns.Add("ADD2", GetType(String))
                    dt.Columns.Add("ADD3", GetType(String))
                    dt.Columns.Add("TEL", GetType(String))
                    dt.Columns.Add("FAX", GetType(String))
                    'dt.Columns.Add("DEL_FLG", GetType(Boolean))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("TORI_NAME").ToString
                            Trow("VALUE") = .Rows(intCNT).Item("TORI_ID").ToString
                            Trow("TORI_KB") = .Rows(intCNT).Item("TORI_KB")
                            Trow("POST") = .Rows(intCNT).Item("POST")
                            Trow("ADD1") = .Rows(intCNT).Item("ADD1")
                            Trow("ADD2") = .Rows(intCNT).Item("ADD2")
                            Trow("ADD3") = .Rows(intCNT).Item("ADD3")
                            Trow("TEL") = .Rows(intCNT).Item("TEL")
                            Trow("FAX") = .Rows(intCNT).Item("FAX")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_YMDHNS").trim <> "")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region

#Region "               temp"
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

#End Region

#Region "               ���ږ�"
                Case "���ږ�"
                    '����
                    sbSQL.Append("SELECT DISTINCT ITEM_NAME,DEL_YMDHNS FROM " & NameOf(M001_SETTING) & " ")
                    If strWhere.IsNullOrWhiteSpace = False Then
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

                    dsList =
                        DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            If dt.Rows.Contains(.Rows(intCNT).Item("ITEM_NAME")) = False Then
                                Dim Trow As DataRow = dt.NewRow()
                                Trow("DISP") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("VALUE") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("DEL_FLG") = IIf(.Rows(intCNT).Item("DEL_YMDHNS").ToString.IsNullOrWhiteSpace, False, True)
                                dt.Rows.Add(Trow)
                            End If
                        Next intCNT
                    End With
#End Region

#Region "               Else"
                Case Else

                    '����
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM001_SETTING) & " WHERE ITEM_NAME='" & strKOMOKU & "'")
                    If strWhere.IsNullOrWhiteSpace = False Then
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
                        ' data null exception
                        'Throw New ArgumentNullException("", "")
                    End If
#End Region

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







