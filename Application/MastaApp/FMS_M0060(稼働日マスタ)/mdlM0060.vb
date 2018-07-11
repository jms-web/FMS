Imports JMS_COMMON.ClsPubMethod

Module mdlM0060

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM0060

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

                '-----�ꗗ��ʕ\��
                frmLIST = New FrmM0060
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        End Try
    End Sub
#End Region

#Region "FuncButton�L�������ؑ�"

    ''' <summary>
    ''' �g�p���Ȃ��{�^���̃L���v�V�������Ȃ����A���񊈐��ɂ���B
    ''' �t�@���N�V�����L�[������(F**)�ȊO�̕������Ȃ��ꍇ�́A���g�p�Ƃ݂Ȃ�
    ''' </summary>
    ''' <param name="frm">�Ώۃt�H�[��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunInitFuncButtonEnabled(ByRef frm As FrmM0060) As Boolean
        Try

            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc




            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


    ''' <summary>
    ''' FUNCTION�{�^���̗L��������ݒ肷��
    ''' </summary>
    ''' <param name="frm">�Ώۃt�H�[��</param>
    ''' <param name="blnAryEnabled">�e�{�^���̗L�������ݒ�(�u�[���^)���i�[�����z��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunSetFuncButtonEnabled(ByRef frm As Form, ByVal blnAryEnabled() As Boolean) As Integer
        Try

            For intCNT As Integer = 1 To 12
                '�������ʂɂ��g�p�s�ɂȂ�{�^���̓X�L�b�v����
                If blnAryEnabled(intCNT - 1) = False Then
                    frm.Controls("cmdFunc" & intCNT).Enabled = False
                Else
                    '�@�\�����蓖�Ă��Ă���{�^����������������
                    If frm.Controls("cmdFunc" & intCNT).Text.Length >= 6 Then
                        frm.Controls("cmdFunc" & intCNT).Enabled = True
                    Else
                        frm.Controls("cmdFunc" & intCNT).Enabled = False
                    End If
                End If
            Next intCNT

            Return 0
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        End Try
    End Function
#End Region

End Module
