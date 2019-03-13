Imports System.Collections.Generic
Imports JMS_COMMON.ClsPubMethod

Module mdlINTSYR

#Region "�萔�E�ϐ�"

    '���O
    Public EM As ErrMsg
    Public WL As WriteLog

    '�\�����[�V�������ʖ�
    Public Const CON_SOLUTION_NAME As String = "FMS"

    '�ݒ�t�A�C����
    Public Const CON_SYSTEM_INI As String = "SYSTEM.INI"
    Public Const CON_OUTPUT_INI As String = "EXCELOUT.INI"
    Public Const CON_TEMPLATE_INI As String = "EXCELTEMPLATE.INI"
    Public Const CON_ERR_LOG As String = CON_SOLUTION_NAME & "_ERROR.LOG"

    Public Const WM_CUT As Integer = &H300
    Public Const WM_COPY As Integer = &H301
    Public Const WM_PASTE As Integer = &H302
    Public Const WM_CONTEXTMENU As Integer = &H7B

    Public pub_SYSTEM_INI_FILE As String

    Public clrControlGotFocusedColor As Color = Color.FromArgb(190, 180, 255) '�t�H�[�J�X���̔w�i�F
    Public clrDisableControlGotFocusedColor As Color = SystemColors.Control
    Public clrControlDefaultBackColor As Color = Color.White  '�t�H�[�J�X�r�������̔w�i�F
    Public clrControlErrorBackColor As Color = Color.FromArgb(255, 255, 128)  '�G���[���̔w�i�F


    '�ڍ׃G���[����ɕ\��
    Public conblnNonMsg As Boolean = False



    ''' <summary>
    ''' �V�X�e�����
    ''' </summary>
    Public pub_SYSTEM_INFO As SYSTEM_INFO
    Public Structure SYSTEM_INFO
        ''' <summary>
        ''' �[����
        ''' </summary>
        Dim strPCNM As String

        ''' <summary>
        ''' �ڑ�������
        ''' </summary>
        Dim CONNECTIONSTRING As String

        ''' <summary>
        ''' �f�[�^�x�[�X�v���o�C�_�[
        ''' </summary>
        Dim DbProviderFactories As String

        ''' <summary>
        ''' �K��̌������ʍő匏��
        ''' </summary>
        Dim SerchMax As Integer

        ''' <summary>
        ''' �K��̃t�H�[���w�i�F
        ''' </summary>
        Dim clrDefaultFormBack As Color

        ''' <summary>
        ''' �K��̃^�C�g�����x���w�i�F
        ''' </summary>
        Dim clrDefaultTitleBack As Color


        ''' <summary>
        ''' �G���[���[�����M�̑ΏۃG���[���x��
        ''' </summary>
        Dim SendMailErrorLevel As Integer


    End Structure

    ''' <summary>
    ''' ���[�U�[���
    ''' </summary>
    Public pub_SYAIN_INFO As SYAIN_INFO
    Public Structure SYAIN_INFO
        ''' <summary>
        ''' �Ј�ID(�V�X�e�����ID)
        ''' </summary>
        Dim SYAIN_ID As Integer

        ''' <summary>
        ''' �Ј�CD(�E��)
        ''' </summary>
        Dim SYAIN_CD As String

        ''' <summary>
        ''' �Ј���
        ''' </summary>
        Dim SYAIN_NAME As String

        ''' <summary>
        ''' �p�X���[�h
        ''' </summary>
        Dim PASSWORD As String

        ''' <summary>
        ''' ����
        ''' </summary>
        Dim KENGEN_KB As String

        ''' <summary>
        ''' ����敪
        ''' </summary>
        Dim BUMON_KB As String

        ''' <summary>
        ''' ���喼
        ''' </summary>
        Dim BUMON_NAME As String
    End Structure

    ''' <summary>
    ''' �v���O�������
    ''' </summary>
    Public pub_APP_INFO As APP_INFO
    Public Structure APP_INFO
        ''' <summary>
        ''' �^�C�g��(������)
        ''' </summary>
        Dim strTitle As String

        ''' <summary>
        ''' �������ʍő匏��
        ''' </summary>
        Dim intSEARCHMAX As Integer

        ''' <summary>
        ''' �t�H�[���w�i�F
        ''' </summary>
        Dim clrFORM_BACK As Color

        ''' <summary>
        ''' �^�C�g�����x���w�i�F
        ''' </summary>
        Dim clrTITLE_LABEL As Color

        ''' <summary>
        ''' �f�[�^�o�͐�
        ''' </summary>
        Dim strOUTPUT_PATH As String

    End Structure


    ''' <summary>
    ''' �G���[���
    ''' </summary>
    Public Enum ENM_ERR_KB As Integer
        _9_���̑���O�G���[ = 9
    End Enum

    Public Enum ENM_KENGEN_KB As Integer
        _0_�����Ȃ� = 0
        _1_�Q�ƌ��� = 1
        _2_�X�V���� = 2
        _9_�V�X�e������ = 9
    End Enum

    Public Enum ENM_BUMON_KB As Integer
        _1_���h = 1
        _2_LP = 2
        _3_������ = 3
        _8_�Ɩ��Ǘ� = 8
        _9_�o�c�� = 9
    End Enum


    ''' <summary>
    ''' �f�[�^�������[�h
    ''' </summary>
    Public Enum ENM_DATA_OPERATION_MODE
        ''' <summary>
        ''' �ǉ�
        ''' </summary>
        _1_ADD = 1

        ''' <summary>
        ''' �Q�ƒǉ�
        ''' </summary>
        _2_ADDREF = 2

        ''' <summary>
        ''' �X�V
        ''' </summary>
        _3_UPDATE = 3

        ''' <summary>
        ''' ��\��(�_���폜)
        ''' </summary>
        _4_DISABLE = 4

        ''' <summary>
        ''' ����
        ''' </summary>
        _5_RESTORE = 5

        ''' <summary>
        ''' �폜(�����폜)
        ''' </summary>
        _6_DELETE = 6
    End Enum

#End Region

#Region "��������"
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <returns>0=����I���@1=�ُ�I��</returns>
    ''' <remarks></remarks>
    Public Function FunINTSYR() As Boolean
        Dim cmds() As String

        Try
            '-----���O����
            EM = New ErrMsg(CON_ERR_LOG)
            WL = New WriteLog()

            '-----�V�X�e���ݒ�t�@�C���Ǎ�

            If Fun_GetSystemIniFile() = False Then
                Return False
            End If


            '-----�[�����擾
            pub_SYSTEM_INFO.strPCNM = System.Net.Dns.GetHostName

            '---�����擾
            cmds = System.Environment.GetCommandLineArgs

            '�S���R�[�h
            If cmds.Length >= 2 Then
                Dim tplBUFF As (BUMON_KB As String, BUMON_NAME As String) = FunGetBUMON_INFO(cmds(1))

                pub_SYAIN_INFO = New SYAIN_INFO With {
                .SYAIN_ID = cmds(1),
                .SYAIN_CD = Fun_GetSYAIN_NO(cmds(1)),
                .SYAIN_NAME = Fun_GetUSER_NAME(cmds(1)),
                .BUMON_KB = tplBUFF.BUMON_KB,
                .BUMON_NAME = tplBUFF.BUMON_NAME
                }
                'pub_USER_INFO.KENGEN_KB = Fun_GetUSER_KENGEN(pub_USER_INFO.USER_ID)

                Return True
            Else
                Select Case My.Application.Info.AssemblyName
                    Case "FMS_M0000", "FMS_U0010"
                        Return True
                    Case Else
                        WL.WriteLogDat("���O�C�����[�U�[�R�[�h���擾�o���܂���ł����B")
                        MessageBox.Show("���O�C�����[�U�[�R�[�h���擾�o���܂���ł����B" & vbCrLf & "�v���O�������I�����܂��B", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                End Select
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
        End Try
    End Function

#End Region

#Region "�V�X�e���ݒ�t�@�C���Ǎ�����"
    Public Function Fun_GetSystemIniFile() As Boolean

        Try
            'INI�t�@�C���p�X�̎擾
            pub_SYSTEM_INI_FILE = FunGetRootPath() & "\INI\" & CON_SYSTEM_INI
            Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                'DB�ڑ��ݒ�
                pub_SYSTEM_INFO.CONNECTIONSTRING = iniIF.GetIniString("DB", "CONNECTIONSTRING")
                pub_SYSTEM_INFO.DbProviderFactories = iniIF.GetIniString("DB", "DbProviderFactories")
            End Using

            Using DB As ClsDbUtility = DBOpen()
                '���ʐݒ�
                pub_SYSTEM_INFO.SerchMax = FunGetCodeMastaValue(DB, "SYSTEM_SETTING", "SERACHMAX")
                pub_SYSTEM_INFO.clrDefaultFormBack = ColorTranslator.FromHtml(FunGetCodeMastaValue(DB, "COLOR_SETTING", "FormBackColor"))
                pub_SYSTEM_INFO.clrDefaultTitleBack = ColorTranslator.FromHtml(FunGetCodeMastaValue(DB, "COLOR_SETTING", "TitleLabelColor"))
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "�o�͐�ݒ�t�@�C���Ǎ�"
    ''' <summary>
    ''' �o�͐�ݒ�t�@�C���Ǎ�
    ''' </summary>
    ''' <returns></returns>
    Public Function FunGetOutputIniFile() As Boolean

        Try

            Using iniIF As New IniFile(FunGetRootPath() & "\INI\" & CON_OUTPUT_INI)
                '�o�͐�
                pub_APP_INFO.strOUTPUT_PATH = FunConvPathString(iniIF.GetIniString(My.Application.Info.AssemblyName, "OUT_FOLDER"))

                If pub_APP_INFO.strOUTPUT_PATH.IsNullOrEmpty Then
                    pub_APP_INFO.strOUTPUT_PATH = FunConvPathString(iniIF.GetIniString("DEFAULT", "OUT_FOLDER"))
                End If
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        End Try
    End Function
#End Region

#Region "PG�ݒ�t�@�C���Ǎ�����"
    ''' <summary>
    ''' PG�ݒ�t�@�C���Ǎ�����
    ''' </summary>
    ''' <param name="strFileName">INI�t�@�C����</param>
    ''' <returns></returns>
    <Diagnostics.DebuggerStepThrough()>
    Public Function FunGetPGIniFile(ByVal strFileName As String) As Boolean
        Dim strINIFile As String
        Try

            strINIFile = FunGetRootPath() & "\INI\" & strFileName & ".INI"
            'PG�ŗLINI�t�@�C�������݂��Ȃ��ꍇ�́A�V�X�e������INI�t�@�C������ݒ�l���擾
            If System.IO.File.Exists(strINIFile) = False Then
                strINIFile = FunGetRootPath() & "\INI\" & CON_SYSTEM_INI
            End If

            'PG�ݒ�l�擾
            With pub_APP_INFO

                Using DB As ClsDbUtility = DBOpen()
                    '    '�^�C�g��
                    .strTitle = FunGetCodeMastaValue(DB, "PG_TITLE", strFileName)
                End Using

                Using iniIF As New IniFile(strINIFile)
                    '�������ʍő匏��
                    If Val(iniIF.GetIniString("SYSTEM", "SEARCHMAX")) > 0 Then
                        .intSEARCHMAX = Val(iniIF.GetIniString("SYSTEM", "SEARCHMAX"))
                    Else
                        'SYSTEM.INI�̃f�t�H���g�ݒ���g�p
                        .intSEARCHMAX = pub_SYSTEM_INFO.SerchMax
                    End If

                    '�t�H�[���w�i�F
                    If iniIF.GetIniString("SYSTEM", "FORMBACK_R").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "FORMBACK_G").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "FORMBACK_B").IsNulOrWS Then
                        'SYSTEM.INI�̃f�t�H���g�ݒ���g�p
                        .clrFORM_BACK = pub_SYSTEM_INFO.clrDefaultFormBack
                    Else
                        .clrFORM_BACK = Color.FromArgb(Val(iniIF.GetIniString("SYSTEM", "FORMBACK_R")), Val(iniIF.GetIniString("SYSTEM", "FORMBACK_G")), Val(iniIF.GetIniString("SYSTEM", "FORMBACK_B")))
                    End If

                    '�^�C�g�����x��
                    If iniIF.GetIniString("SYSTEM", "TITLELABEL_R").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "TITLELABEL_G").IsNulOrWS AndAlso iniIF.GetIniString("SYSTEM", "TITLELABEL_B").IsNulOrWS Then
                        'SYSTEM.INI�̃f�t�H���g�ݒ���g�p
                        .clrTITLE_LABEL = pub_SYSTEM_INFO.clrDefaultTitleBack
                    Else
                        .clrTITLE_LABEL = Color.FromArgb(Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_R")), Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_G")), Val(iniIF.GetIniString("SYSTEM", "TITLELABEL_B")))
                    End If
                End Using
            End With

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "�G���[���O�e�[�u���o�͂���у��[�����M"
    Public Function FunErrorSyori(ByVal strErrKB As String, ByVal strErrLevel As String, ByVal strMSG As String, Optional ByVal strBIKO As String = "", Optional ByVal ErrLogList As List(Of String) = Nothing) As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim dtNow As DateTime
        'Dim blnRET As Boolean
        Dim strSubject As String
        Dim sbMessage As New System.Text.StringBuilder
        Dim sendFile As New List(Of String)

        Dim strErrLevel_NM As String
        Dim strErrKB_NM As String
        Dim blnSendFLG As Boolean
        Dim blnAttachmentFLG As Boolean
        Try

            Using DB As ClsDbUtility = DBOpen()

                '�V�X�e�������擾
                dtNow = DateTime.Now 'FunGetSysDate(DB)

                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("INSERT INTO RTB_ERRLOG(SYR_YMDHNS, PC_NM, ERR_KB, ERR_LEVEL, MSG, BIKO) VALUES (")
                sbSQL.Append(" '" & dtNow.ToString("yyyyMMddHHmmss") & "',") '��������
                sbSQL.Append(" '" & pub_SYSTEM_INFO.strPCNM & "',") 'PC��
                sbSQL.Append(" '" & strErrKB & "',") '�G���[�敪
                sbSQL.Append(" '" & strErrLevel & "',") '�G���[���x��
                sbSQL.Append(" '" & strMSG & "',") '���b�Z�[�W
                sbSQL.Append(" '" & strBIKO & "')") '���l

                'SQL���s
                intRET = DB.ExecuteNonQuery(sbSQL.ToString, True)


                If pub_SYSTEM_INFO.SendMailErrorLevel = 0 Then
                    '���M���Ȃ�
                    blnSendFLG = False
                Else
                    If pub_SYSTEM_INFO.SendMailErrorLevel <= Val(strErrLevel) Then
                        '�G���[���[�����M�ΏۃG���[���x���ȏ�̃G���[�̂݃��[�����M���� �ݒ肪=1�c�d�v�G���[�݂̂̏ꍇ�A�G���[���x��2�c�ʒm���x���̃G���[�̓��[�����M���Ȃ�
                        blnSendFLG = True
                    Else
                        strErrLevel = "False"
                    End If
                End If

                '���[�����M���s
                If blnSendFLG = True Then
                    '�Y�t�t�@�C���L��
                    blnAttachmentFLG = CBool(Val(FunGetCodeMastaValue(DB, "MAIL_SETTING", "FILE_ATTACHMENT")))
                    '�G���[���x����
                    strErrLevel_NM = FunGetCodeMastaValue(DB, "ERROR_LEVEL", strErrLevel)
                    '�G���[�敪��
                    strErrKB_NM = FunGetCodeMastaValue(DB, "ERROR_KB", strErrKB)


                    If blnAttachmentFLG = True And ErrLogList IsNot Nothing Then
                        '�Y�t�t�@�C�����X�g��ݒ�
                        sendFile = ErrLogList
                    End If

                    '�����쐬
                    strSubject = "�yEDI��M�V�X�e���G���[�����z" & strErrKB_NM


                    If strErrKB = ENM_ERR_KB._9_���̑���O�G���[.ToString Then
                        If ErrLogList Is Nothing Then
                            '��O�G���[�������œ���̃��O�t�@�C�����Z�b�g����Ă��Ȃ��ꍇ�́A�V�X�e���G���[���O�t�@�C�������X�g�ɒǉ�����
                            ErrLogList = New List(Of String) From {FunGetRootPath() & "\LOG\" & CON_ERR_LOG}
                        End If
                        sendFile = ErrLogList
                    End If

                    '�{���쐬
                    sbMessage.Remove(0, sbMessage.Length)
                    sbMessage.Append("���������@�@�F" & dtNow.ToString("yyyy�NMM��dd�� HH��mm��ss�b") & vbCrLf)
                    sbMessage.Append("��Q���x���@�F" & strErrLevel & " " & strErrLevel_NM & vbCrLf)
                    sbMessage.Append("�G���[�敪�@�F" & strErrKB & " " & strErrKB_NM & vbCrLf)
                    If sendFile.Count > 0 Then
                        sbMessage.Append("�Y�t�t�@�C���F����" & vbCrLf)
                    Else
                        sbMessage.Append("�Y�t�t�@�C���F�Ȃ�" & vbCrLf)
                    End If
                    sbMessage.Append(vbCrLf)
                    sbMessage.Append("<�G���[���e>" & vbCrLf)
                    sbMessage.Append(strMSG & vbCrLf)
                    sbMessage.Append(vbCrLf)
                    sbMessage.Append("<�ڍ׏��>" & vbCrLf)
                    sbMessage.Append(Nz(strBIKO, "�Ȃ�") & vbCrLf)

                    '���[�����M
                    'Call FunSendErrorMail(DB, strSubject, sbMessage.ToString, sendFile)
                End If
            End Using

            Return True
        Catch ex As Exception
            'EM.ErrorSyori(ex, False, True)
            Return False
        Finally


        End Try
    End Function
#End Region

#Region "���[�U�[���擾"

    Public Function Fun_GetUSER_NAME(ByVal SYAIN_ID As Integer) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try


            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT SIMEI FROM " & "M004_SYAIN" & " ")
                sbSQL.Append(" WHERE SYAIN_ID =" & SYAIN_ID & " ")
                dsList = DB.GetDataSet(sbSQL.ToString)
                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        Return .Rows(0).Item(0).ToString.Trim
                    Else
                        '�G���[
                        'Throw New ArgumentOutOfRangeException
                        Return ""
                    End If
                End With
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#Region "�Ј�NO�擾"

    Public Function Fun_GetSYAIN_NO(ByVal SYAIN_ID As Integer) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try


            Using DB As ClsDbUtility = DBOpen()
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT SYAIN_NO FROM " & "M004_SYAIN" & " ")
                sbSQL.Append(" WHERE SYAIN_ID =" & SYAIN_ID & " ")
                dsList = DB.GetDataSet(sbSQL.ToString)
                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        Return .Rows(0).Item(0).ToString.Trim
                    Else
                        '�G���[
                        'Throw New ArgumentOutOfRangeException
                        Return ""
                    End If
                End With
            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        Finally
            dsList.Dispose()
        End Try
    End Function

#End Region

#Region "���[�U�[�����擾"
    Public Function Fun_GetUSER_KENGEN(ByVal SYAIN_ID As String) As String
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            'SQL
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT * FROM " & "M03_TANTO" & " ")
            sbSQL.Append(" WHERE SYAIN_ID ='" & SYAIN_ID & "' ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            With dsList.Tables(0).Rows(0)
                Return .Item("KENGEN_KB").ToString.Trim
            End With

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return ""
        Finally
            '-----�J��
            dsList.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' �V�X�e���Ǘ��Ҍ����擾
    ''' </summary>
    ''' <param name="SYAIN_ID"></param>
    ''' <returns></returns>
    Public Function IsSysAdminUser(SYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Try

            sbSQL.Append("SELECT ADMIN_SYS FROM " & "M004_SYAIN" & " ")
            sbSQL.Append($" WHERE SYAIN_ID ={SYAIN_ID}")
            Using DB As ClsDbUtility = DBOpen()
                strRET = DB.ExecuteScalar(sbSQL.ToString)
            End Using

            Return (strRET = "1")

        Catch ex As Exception
            EM.ErrorSyori(ex, False)
            Return False

        End Try
    End Function

    ''' <summary>
    ''' �^�p�Ǘ��Ҍ����擾
    ''' </summary>
    ''' <param name="SYAIN_ID"></param>
    ''' <returns></returns>
    Public Function IsOPAdminUser(SYAIN_ID As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim strRET As String
        Try

            sbSQL.Append("SELECT ADMIN_OP FROM " & "M004_SYAIN" & " ")
            sbSQL.Append($" WHERE SYAIN_ID ={SYAIN_ID}")
            Using DB As ClsDbUtility = DBOpen()
                strRET = DB.ExecuteScalar(sbSQL.ToString)
            End Using

            Return (strRET = "1")

        Catch ex As Exception
            EM.ErrorSyori(ex, False)
            Return False

        End Try
    End Function

#End Region

#Region "�Ǘ��Ҍ����m�F"

    Public Function HasAdminAuth(ByVal intSYAIN_ID As Integer) As Boolean
        'Dim sbSQL As New System.Text.StringBuilder
        'Dim dsList As New DataSet

        'sbSQL.Remove(0, sbSQL.Length)
        'sbSQL.Append("SELECT")
        'sbSQL.Append(" *")
        'sbSQL.Append(" FROM VWM001_SETTING ")
        'sbSQL.Append(" WHERE ITEM_NAME='�Ǘ��Ҍ���'")
        'sbSQL.Append(" AND ITEM_DISP='" & intSYAIN_ID & "'")
        'Using DB As ClsDbUtility = DBOpen()
        '    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        'End Using

        'If dsList.Tables(0).Rows.Count > 0 Then
        '    Return True
        'Else
        '    Return False
        'End If

        Return IsOPAdminUser(intSYAIN_ID)

    End Function
#End Region

#Region "DB����֘A"
    Public Function DBOpen() As ClsDbUtility
        If pub_SYSTEM_INFO.DbProviderFactories.IsNulOrWS And pub_SYSTEM_INFO.CONNECTIONSTRING.IsNulOrWS Then
            Return Nothing
        Else
            Dim DB As New ClsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
            Return DB
        End If
    End Function

#End Region

End Module
