Imports JMS_COMMON.ClsPubMethod

Module mdlM0040

#Region "�萔�E�ϐ�"

    ''' <summary>
    ''' �ꗗ���
    ''' </summary>
    Public frmLIST As FrmM0040

    Public player As System.Media.SoundPlayer = Nothing
    Public pub_buttonSound As String

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
                    Call FunGetCodeDataTable(DB, "�Ј��敪", tblSYAIN_KB, "ITEM_NAME = '�Ј��敪'")
                    Call FunGetCodeDataTable(DB, "��E�敪", tblYAKUSYOKU_KB)
                    Call FunGetCodeDataTable(DB, "���F��s�敪", tblDAIKO_KB)
                End Using
                pub_buttonSound = FunGetRootPath() & "\buttonSound.wav"
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

#Region "�T�E���h�Đ�"

    'WAVE�t�@�C�����Đ�����
    Public Sub PlaySound(ByVal waveFile As String)
        '�Đ�����Ă���Ƃ��͎~�߂�
        If Not (player Is Nothing) Then
            StopSound()
        End If

        '�ǂݍ���
        player = New System.Media.SoundPlayer(waveFile)
        '�񓯊��Đ�����
        player.Play()

        '���̂悤�ɂ���ƁA���[�v�Đ������
        'player.PlayLooping()

        '���̂悤�ɂ���ƁA�Ō�܂ōĐ����I����܂őҋ@����
        'player.PlaySync()
    End Sub

    '�Đ�����Ă��鉹���~�߂�
    Public Sub StopSound()
        If Not (player Is Nothing) Then
            player.Stop()
            player.Dispose()
            player = Nothing
        End If
    End Sub

#End Region

#Region "���[�U�[ID����"

    Public Function FunGetUSER(ByVal strCARD_ID As String) As DataRow
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As System.Data.DataSet = Nothing

        Try
            '����
            sbSQL.Append("SELECT IC_CARD_ID")
            sbSQL.Append(" FROM M004_SYAIN")
            sbSQL.Append($" WHERE IC_CARD_ID = '{strCARD_ID}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                Return dsList.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

    Public Function FunGetUSER_byUSERID(ByVal SYAIN_NO As String) As DataRow
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As System.Data.DataSet = Nothing

        Try
            sbSQL.Append("SELECT IC_CARD_ID")
            sbSQL.Append(" FROM M004_SYAIN")
            sbSQL.Append($" WHERE SYAIN_NO = '{SYAIN_NO}'")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString)
            End Using

            If dsList.Tables(0).Rows.Count > 0 Then
                Return dsList.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Module