Imports JMS_COMMON.ClsPubMethod

Module mdlM0000

    ' JumpList�I�u�W�F�N�g�𐶐�����
    Public jumpList = New System.Windows.Shell.JumpList()

    '���j���[�p�ݒ�t�A�C����
    Public Const CON_MENUINI_FILENAME As String = "MENU.INI"
    Public Const CON_TXT_UPDATE_HISTORY As String = "RIREKI.TXT"

    '�^�C�g����
    Public pub_MenuTitle As String

    '���j���[�{�^��
    Public Structure CMDS_TYPE
        Public Title As String      '�v���O�����^�C�g��
        Public Path As String       '���s�t�@�C���̃p�X
    End Structure
    Public arrCMDS_FUNC(11) As CMDS_TYPE        '�t�@���N�V����

    'SUB���j���[�{�^��
    Public Structure SUB_CMDS_TYPE
        Public Category As String       '�J�e�S���[��
        Public MenuTitle As String       '���j���[�^�C�g��
        Public Cmds() As CMDS_TYPE

        Public Sub Initialize()
            Cmds = New CMDS_TYPE(11) {}
        End Sub
    End Structure
    Public arrCMDS_SUBFUNC(11) As SUB_CMDS_TYPE    '�T�u�t�@���N�V����
    Public intCMDS_SUBFUNC As Integer          '�T�u�t�@���N�V��������

    '���[�������N�֘A
    Public pubLinkEXE As String
    Public pubLinkSyainID As String
    Public pubLinkParams As String


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

                arrCMDS_SUBFUNC(0).Category = ""

                '-----���j���[�ݒ�t�@�C���Ǎ�
                If Fun_GetMenuIniFile("MAIN", 0) = False Then
                    WL.WriteLogDat("�v���O�������I�����܂�(���j���[�ݒ�t�@�C���Ǎ��������s)")
                    Exit Sub
                End If

                '-----Visual�X�^�C���L��
                'Application.EnableVisualStyles()
                '-----GDI���g�p
                Application.SetCompatibleTextRenderingDefault(False)

                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "MENU_SECTION", tblMenuSection)
                End Using

                '-----�m�F��ʕ\��
                'INI������̃��O�C�����[�U�[�擾
                Dim strBUFF As String
                Using iniIF As New IniFile(pub_SYSTEM_INI_FILE)
                    strBUFF = iniIF.GetIniString("SYSTEM", "USERID")
                End Using

                'UNDONE: �p�����[�^�擾 ���[�������N�o�R�ł�PG�N���p ���[�U�[ID��PG_PATH ����т���PG�̃p�����[�^���󂯎��
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 4 Then
                    '���[�������N�p 
                    pubLinkSyainID = cmds(1)
                    pubLinkEXE = cmds(2)
                    pubLinkParams = cmds(3)
                End If

                '�O�񃍃O�C�����[�U�[���󗓂̏ꍇ=�o�[�W�����A�b�v�㏉��N����
                If strBUFF.Trim = "" Then
                    Using frmDLG As New FrmM0010
                        frmDLG.ShowDialog()
                    End Using
                End If

                '�W�����v���X�g
                Call FunCreateJumpList()

                '-----�ꗗ��ʕ\��
                Dim frmLIST As New FrmM0000
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

#Region "���j���[�ݒ�t�@�C������`�f�[�^���擾"
    Public Function Fun_GetMenuIniFile(ByVal strSECTION_NAME As String, ByVal intIndex As Integer) As Boolean
        Dim strWork As String
        Dim lngL As Integer
        Dim strPath As String
        Try
            strPath = FunGetRootPath() & "\INI\" & CON_MENUINI_FILENAME

            Using iniIF As New IniFile(strPath)
                If strSECTION_NAME = "MAIN" Then
                    '�^�C�g��
                    pub_MenuTitle = iniIF.GetIniString(strSECTION_NAME, "TITLE").ToString

                    '�t�@���N�V����
                    For lngL = 0 To 11
                        '������
                        arrCMDS_FUNC(lngL).Title = ""
                        arrCMDS_FUNC(lngL).Path = ""

                        strWork = Right("00" & CStr(lngL + 1), 2)

                        '������
                        arrCMDS_FUNC(lngL).Title = iniIF.GetIniString(strSECTION_NAME, "TITLE" & strWork)

                        '�p�X
                        arrCMDS_FUNC(lngL).Path = iniIF.GetIniString(strSECTION_NAME, "PATH" & strWork)
                    Next lngL
                Else
                    '�^�C�g��
                    pub_MenuTitle = iniIF.GetIniString(intIndex, "TITLE").ToString.Replace("[SECTION_NAME]", strSECTION_NAME)

                    '�t�@���N�V����
                    For lngL = 0 To 11
                        '������
                        arrCMDS_FUNC(lngL).Title = ""
                        arrCMDS_FUNC(lngL).Path = ""

                        strWork = Right("00" & CStr(lngL + 1), 2)

                        '������
                        arrCMDS_FUNC(lngL).Title = iniIF.GetIniString(intIndex, "TITLE" & strWork)

                        '�p�X
                        arrCMDS_FUNC(lngL).Path = iniIF.GetIniString(intIndex, "PATH" & strWork)


                        If arrCMDS_FUNC(lngL).Path.Length < 2 Then '�T�u�t�@���N�V����������
                            '���f�[�^��
                            Continue For
                        End If

                        '�T�u�t�@���N�V�����̓ǎ�
                        If arrCMDS_FUNC(lngL).Path.Substring(0, 1) = "[" AndAlso
                           arrCMDS_FUNC(lngL).Path.Substring(arrCMDS_FUNC(lngL).Path.Length - 1, 1) = "]" Then
                            Fun_GetMenuIniFileSub(strSECTION_NAME, arrCMDS_FUNC(lngL).Path)
                        End If

                    Next lngL
                End If
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try

    End Function

    '���j���[�ݒ�t�@�C�����T�u���j���[��`�f�[�^���擾
    Public Function Fun_GetMenuIniFileSub(ByVal strSECTION_NAME As String, ByVal SectionIndex As String) As Boolean
        Dim lngL As Long
        Dim strWork As String
        Dim strWkCat As String
        Dim intNum As Integer

        Dim strPath As String
        Try
            strPath = FunGetRootPath() & "\INI\" & CON_MENUINI_FILENAME

            Using iniIF As New IniFile(strPath)
                '[MAIN]�Ȃ�o�^���Ȃ�
                If UCase(SectionIndex) = "[MAIN]" Then Return True

                '���ɓo�^����Ă����甲����
                strWkCat = SectionIndex.Substring(1, SectionIndex.Length - 2)    '"[]" ����
                For lngL = 1 To intCMDS_SUBFUNC
                    If strWkCat = arrCMDS_SUBFUNC(lngL).Category Then Return True
                Next lngL

                '[�`]���L���ł���
                intCMDS_SUBFUNC = intCMDS_SUBFUNC + 1
                ReDim Preserve arrCMDS_SUBFUNC(intCMDS_SUBFUNC)
                arrCMDS_SUBFUNC(intCMDS_SUBFUNC).Initialize()

                arrCMDS_SUBFUNC(intCMDS_SUBFUNC).Category = strWkCat
                intNum = intCMDS_SUBFUNC

                '���j���[�^�C�g��
                arrCMDS_SUBFUNC(intNum).MenuTitle = iniIF.GetIniString(strWkCat, "TITLE").Replace("[SECTION_NAME]", strSECTION_NAME)

                '�t�@���N�V����
                For lngL = 0 To 11
                    '������
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Title = ""
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path = ""

                    strWork = Right("00" & CStr(lngL + 1), 2)

                    '������
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Title = iniIF.GetIniString(strWkCat, "TITLE" & strWork)

                    '�p�X
                    arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path = iniIF.GetIniString(strWkCat, "PATH" & strWork)

                    If arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Length < 2 Then '�T�u�t�@���N�V����������
                        '���f�[�^��
                        Continue For
                    End If

                    '�T�u�t�@���N�V�����̓ǎ�
                    If arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Substring(0, 1) = "[" AndAlso
                       arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Substring(arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path.Length - 1, 1) = "]" Then
                        Fun_GetMenuIniFileSub(strSECTION_NAME, arrCMDS_SUBFUNC(intNum).Cmds(lngL).Path)
                    End If
                Next lngL
            End Using

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally

        End Try
    End Function

#End Region

#Region "�W�����v���X�g�쐬"
    Private Function FunCreateJumpList() As Boolean

        ' JumpTask�I�u�W�F�N�g�𐶐����AJumpList�I�u�W�F�N�g�Ɋi�[����
        Dim jumpTask1 = New System.Windows.Shell.JumpTask() With {
                  .CustomCategory = "�Ɩ�",
                  .Title = "�^�X�N1",
                  .Description = "run task1",
                  .Arguments = "/msg=task1args"
                }
        jumpList.JumpItems.Add(jumpTask1)
        ' JumpTask�I�u�W�F�N�g�𐶐����AJumpList�I�u�W�F�N�g�Ɋi�[����
        Dim jumpTask2 = New System.Windows.Shell.JumpTask() With {
                  .CustomCategory = "�Ɩ�",
                  .Title = "�^�X�N2",
                  .Description = "run task2",
                  .Arguments = "/msg=task2args"
                }
        jumpList.JumpItems.Add(jumpTask2)
        ' JumpTask�I�u�W�F�N�g�𐶐����AJumpList�I�u�W�F�N�g�Ɋi�[����
        Dim currentDirectory As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim jumpTask3 = New System.Windows.Shell.JumpTask() With
        {
          .Title = "ReadMe��ǂ�",
          .Description = "ReadMe���J���܂��B",
          .ApplicationPath = "%SystemRoot%\System32\notepad.exe",
          .IconResourcePath = "%SystemRoot%\System32\notepad.exe",
          .WorkingDirectory = currentDirectory,
          .Arguments = currentDirectory & "\ReadMe.txt"
        }
        jumpList.JumpItems.Add(jumpTask3)

        ' Apply���\�b�h���Ăяo���āAWindows�ɒʒm����
        jumpList.Apply()

        Dim msgArgment As String = Environment.GetCommandLineArgs().Where(Function(arg) arg.ToUpperInvariant().StartsWith("/msg=")).FirstOrDefault()

        Return True
    End Function

#End Region

End Module