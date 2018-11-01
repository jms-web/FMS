Imports JMS_COMMON.ClsPubMethod

Module mdlM00101

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM00101

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
                    Call FunGetCodeDataTable(DB, "����敪", tblBUMON, "ITEM_VALUE<8 ")
                End Using

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmM00101
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        Finally

        End Try
    End Sub
#End Region

    Public Function pub_FUTEKIGO_KB_HENKAN(strSEIHIN_KB As String, strFUTEKIGO_KB As String) As String
        Dim strWork As String
        Try
            Select Case strSEIHIN_KB
                Case "1"    '���h
                    strWork = "���h_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '�O��
                            strWork = strWork & "�s�K���O�ϋ敪"
                        Case "1"    '���@ 
                            strWork = strWork & "�s�K�����@�敪"
                        Case "2"    '�`��
                            strWork = strWork & "�s�K���`��敪"
                        Case "3"    '�@�\�E���\
                            strWork = strWork & "�s�K���@�\���\�敪"
                        Case Else '"9"    '���̑�
                            strWork = strWork & "�s�K�����̑��敪"
                    End Select

                Case "2"    'LP
                    strWork = "LP_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '�O��
                            strWork = strWork & "�s�K���O�ϋ敪"
                        Case "1"    '���@ 
                            strWork = strWork & "�s�K�����@�敪"
                        Case "2"    '�`��
                            strWork = strWork & "�s�K���`��敪"
                        Case "3"    '�@�\�E���\
                            strWork = strWork & "�s�K���@�\���\�敪"
                        Case Else '"9"    '���̑�
                            strWork = strWork & "�s�K�����̑��敪"
                    End Select

                Case "3"    '������
                    strWork = "������_"
                    Select Case strFUTEKIGO_KB
                        Case "0"    '���@
                            strWork = strWork & "�s�K�����@�敪"
                        Case "1"    '�`�� 
                            strWork = strWork & "�s�K���`��敪"
                        Case "2"    '���E
                            strWork = strWork & "�s�K�����E�敪"
                        Case "3"    '�O��
                            strWork = strWork & "�s�K���O�ϋ敪"
                        Case "4"    '��������
                            strWork = strWork & "�s�K���������׋敪"
                        Case "5"
                            strWork = strWork & "�s�K���d�������敪"
                        Case "6"
                            strWork = strWork & "�s�K���v���Z�X�敪"
                        Case Else '"9"    '���̑�
                            strWork = strWork & "�s�K�����̑��敪"
                    End Select
                Case Else
                    strWork = ""
            End Select

            Return strWork

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


End Module
