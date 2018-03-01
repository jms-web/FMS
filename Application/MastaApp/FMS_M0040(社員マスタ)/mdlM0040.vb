Imports JMS_COMMON.ClsPubMethod

Module mdlM0040

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM0040

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
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetOutput)
                    Exit Sub
                End If

                '-----Visual�X�^�C���L��
                Application.EnableVisualStyles()
                '-----GDI���g�p
                Application.SetCompatibleTextRenderingDefault(False)

                '-----���ʃf�[�^�擾
                Using DB As ClsDbUtility = DBOpen()
                    'Call FunGetCodeDataTable(DB, "��", tblBU)
                    'Call FunGetCodeDataTable(DB, "��", tblKA)
                    'Call FunGetCodeDataTable(DB, "��E�敪", tblYAKU_KBN)
                    'Call FunGetCodeDataTable(DB, "���ԋ敪", tblCYOKKAN_KBN)
                    'Call FunGetCodeDataTable(DB, "�E��", tblSYOKUBAN)
                End Using

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmM0040
                 Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region




End Module
