Imports JMS_COMMON.ClsPubMethod

Module mdlM1010

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM1010

    Public priTableName As String = NameOf(Model.VWM02_TORIHIKI)

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
                    Call FunGetCodeDataTable(DB, "������", tblTORI_SYU)
                    Call FunGetCodeDataTable(DB, "������CD", tblHACYU_CD)
                    Call FunGetCodeDataTable(DB, "�d���O���敪", tblNAIGAI_KB)
                    Call FunGetCodeDataTable(DB, "�ŋ敪", tblURI_KBN)
                    Call FunGetCodeDataTable(DB, "�ŋ敪", tblSHI_KBN)
                    Call FunGetCodeDataTable(DB, "�[�������敪", tblTAX_HASU_KB)
                    Call FunGetCodeDataTable(DB, "����旪��", tblTORI_SAKI)
                    Call FunGetCodeDataTable(DB, "�����CD", tblTORI_SAKI_CD)
                    Call FunGetCodeDataTable(DB, "�S��", tblTANTO)
                    Call FunGetCodeDataTable(DB, "����", tblZOKUSEI, "ZOKUSEI_FLG & " & Context.ENM_ZOKUSEI_FLG._1_���i & "<>0 ")
                    Call FunGetCodeDataTable(DB, "��������", tblZOKUSEI_K)
                End Using

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmM1010
                Application.Run(frmLIST)

            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

End Module
