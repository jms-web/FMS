Imports JMS_COMMON.ClsPubMethod

Module mdlM1060

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM1060

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
                    Call FunGetCodeDataTable(DB, "����敪", tblBUMON, "ITEM_VALUE<'4' ")
                    Call FunGetCodeDataTable(DB, "�����", tblTORIHIKI, "TORI_KB = '0' OR TORI_KB = '3' ")
                    Call FunGetCodeDataTable(DB, "�q��@�_��敪", tblKK_KEIYAKU_KB)
                    Call FunGetCodeDataTable(DB, "LP�_��敪", tblLP_KEIYAKU_KB)
                    Call FunGetCodeDataTable(DB, "���C��敪", tblRIKUKAIKU_KB)
                End Using

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmM1060
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region




End Module
