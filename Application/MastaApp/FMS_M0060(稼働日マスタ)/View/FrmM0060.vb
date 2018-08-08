Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0060

#Region "�萔�E�ϐ�"
    Public lblDAY() As System.Windows.Forms.Label '���t���x���z��
    Public lblWEEK() As System.Windows.Forms.Label '�j�����x���z��
    Private dtym_Changed As String

#End Region

#Region "Form�֘A"

    'Load�C�x���g
    Private Sub FrmLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Application.DoEvents()

            '-----�t�H�[�������ݒ�(�e�t�H�[������Ăяo��)
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO, My.Application.Info.Version.ToString)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----���t���x���z��
            '���t���x���̍쐬
            Me.lblDAY = New System.Windows.Forms.Label(42) {}
            '���t���x���z��ɉ�ʂɒu�������t���x������
            Me.lblDAY(1) = Me.lblDAY1
            Me.lblDAY(2) = Me.lblDAY2
            Me.lblDAY(3) = Me.lblDAY3
            Me.lblDAY(4) = Me.lblDAY4
            Me.lblDAY(5) = Me.lblDAY5
            Me.lblDAY(6) = Me.lblDAY6
            Me.lblDAY(7) = Me.lblDAY7
            Me.lblDAY(8) = Me.lblDAY8
            Me.lblDAY(9) = Me.lblDAY9
            Me.lblDAY(10) = Me.lblDAY10
            Me.lblDAY(11) = Me.lblDAY11
            Me.lblDAY(12) = Me.lblDAY12
            Me.lblDAY(13) = Me.lblDAY13
            Me.lblDAY(14) = Me.lblDAY14
            Me.lblDAY(15) = Me.lblDAY15
            Me.lblDAY(16) = Me.lblDAY16
            Me.lblDAY(17) = Me.lblDAY17
            Me.lblDAY(18) = Me.lblDAY18
            Me.lblDAY(19) = Me.lblDAY19
            Me.lblDAY(20) = Me.lblDAY20
            Me.lblDAY(21) = Me.lblDAY21
            Me.lblDAY(22) = Me.lblDAY22
            Me.lblDAY(23) = Me.lblDAY23
            Me.lblDAY(24) = Me.lblDAY24
            Me.lblDAY(25) = Me.lblDAY25
            Me.lblDAY(26) = Me.lblDAY26
            Me.lblDAY(27) = Me.lblDAY27
            Me.lblDAY(28) = Me.lblDAY28
            Me.lblDAY(29) = Me.lblDAY29
            Me.lblDAY(30) = Me.lblDAY30
            Me.lblDAY(31) = Me.lblDAY31
            Me.lblDAY(32) = Me.lblDAY32
            Me.lblDAY(33) = Me.lblDAY33
            Me.lblDAY(34) = Me.lblDAY34
            Me.lblDAY(35) = Me.lblDAY35
            Me.lblDAY(36) = Me.lblDAY36
            Me.lblDAY(37) = Me.lblDAY37
            Me.lblDAY(38) = Me.lblDAY38
            Me.lblDAY(39) = Me.lblDAY39
            Me.lblDAY(40) = Me.lblDAY40
            Me.lblDAY(41) = Me.lblDAY41
            Me.lblDAY(42) = Me.lblDAY42


            '-----�j�����x���z��
            '�j�����x���̍쐬
            Me.lblWEEK = New System.Windows.Forms.Label(7) {}
            '�j�����x���z��ɉ�ʂɒu�����j�����x������
            Me.lblWEEK(1) = Me.lblWEEK1
            Me.lblWEEK(2) = Me.lblWEEK2
            Me.lblWEEK(3) = Me.lblWEEK3
            Me.lblWEEK(4) = Me.lblWEEK4
            Me.lblWEEK(5) = Me.lblWEEK5
            Me.lblWEEK(6) = Me.lblWEEK6
            Me.lblWEEK(7) = Me.lblWEEK7

            '-----�\��
            Me.dtYM.Value = Today.ToString("yyyy/MM")

        Finally
            '�t�@���N�V�����L�[�L����������
            Call FunInitFuncButtonEnabled(Me)
        End Try
    End Sub

#End Region

#Region "FunctionButton�֘A"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFunc7.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc1.Click, cmdFunc3.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim intRET As Integer

        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '�m��

                    intRET = FunUPDATE()
                    If intRET = 0 Then
                        Call FunSRCH()

                    End If

                Case 2  '�O��

                    Call FunZENJIGETU(-1)
                Case 3  '����

                    Call FunZENJIGETU(1)

                Case 12 '����
                    'End
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex)

        Finally
            '�{�^����
            System.Windows.Forms.Application.DoEvents()
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = True
            Next

            '�t�@���N�V�����L�[�L����������
            Call FunInitFuncButtonEnabled(Me)

        End Try

    End Sub

#End Region

#Region "�m��"
    Private Function FunUPDATE() As Integer
        Dim dsList As New System.Data.DataSet
        Dim dsListWK As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim sbSQLWHERE As New System.Text.StringBuilder
        Dim intTRNFLG As Integer = 0
        Dim intCNT As Integer

        Try
            Using DB As New ClsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                ''-----���t�\���̏����l(TAG)���Z�b�g
                For intCNT = 1 To Me.lblDAY.Length - 1
                    '���t������
                    If lblDAY(intCNT).Visible = False Then
                        '���̓���
                        Continue For

                    End If

                    If lblDAY(intCNT).ForeColor = System.Drawing.Color.Red Then '��ғ���
                        lblDAY(intCNT).Tag = "0"
                    ElseIf lblDAY(intCNT).ForeColor = System.Drawing.Color.Black Then '�ғ���
                        lblDAY(intCNT).Tag = "1"
                    End If

                    '-----BEGINTRANS

                    '----�f�[�^����
                    'SQL
                    '-----�����m�F
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT COUNT(*) FROM M006_CALENDAR ")
                    sbSQL.Append(" WHERE YMD =  '" & Me.dtYM.ValueNonFormat & Val(lblDAY(intCNT).Text).ToString("00") & "'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                    If dsList.Tables(0).Rows(0).Item(0).ToString.TrimEnd() <= 0 Then

                        '----�f�[�^�����݂��Ȃ������ꍇ
                        'SQL
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("INSERT INTO M006_CALENDAR (")
                        sbSQL.Append("  YMD,")
                        sbSQL.Append("  KADO_KB,")
                        sbSQL.Append("  ADD_YMDHNS,")
                        sbSQL.Append("  ADD_SYAIN_ID,")
                        sbSQL.Append("  UPD_YMDHNS")
                        sbSQL.Append("  UPD_SYAIN_ID")
                        sbSQL.Append(" ) VALUES (")
                        sbSQL.Append(" '" & Me.dtYM.ValueNonFormat & Val(lblDAY(intCNT).Text).ToString("00") & "',")
                        If lblDAY(intCNT).ForeColor = System.Drawing.Color.Red Then
                            '��ғ���
                            sbSQL.Append(" '0',")
                        Else
                            '�ғ���
                            sbSQL.Append(" '1',")
                        End If
                        sbSQL.Append(" dbo.GetSysDateString(), ")
                        sbSQL.Append(" " & pub_SYAIN_INFO.SYAIN_ID & "")
                        sbSQL.Append(" dbo.GetSysDateString() ")
                        sbSQL.Append(" " & pub_SYAIN_INFO.SYAIN_ID & "")
                        sbSQL.Append(" )")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)

                        If intRET <> 1 Then
                            '�G���[���O�o��
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If

                        '----�f�[�^�����݂����ꍇ
                    Else
                        'SQL
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("UPDATE M006_CALENDAR")
                        sbSQL.Append(" SET  KADO_KB = ")
                        If lblDAY(intCNT).ForeColor = System.Drawing.Color.Red Then '��ғ���
                            sbSQL.Append(" '0',")
                        Else '�ғ���
                            sbSQL.Append(" '1',")
                        End If
                        sbSQL.Append("  UPD_YMDHNS  = dbo.GetSysDateString() ")
                        sbSQL.Append(" WHERE YMD = '" & Me.dtYM.ValueNonFormat & Val(lblDAY(intCNT).Text).ToString("00") & "'")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    End If

                Next
            End Using

            '-----���o�^�\��
            If FunCHECK() = 1 Then '�ύX�L�莞
                Me.lblTOUROKU.Text = "���o�^"
            Else '�ύX������
                Me.lblTOUROKU.Text = ""
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False

        Finally
            '-----ROLLBACK
            '-----COMMIT
            '-----�J��
            dsList.Dispose()

        End Try
    End Function
#End Region

#Region "FuncButton�L�������ؑ�"

    ''' <summary>
    ''' �g�p���Ȃ��{�^���̃L���v�V�������Ȃ����A���񊈐��ɂ���B
    ''' �t�@���N�V�����L�[������(F**)�ȊO�̕������Ȃ��ꍇ�́A���g�p�Ƃ݂Ȃ�
    ''' </summary>
    ''' <param name="frm">�Ώۃt�H�[��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunInitFuncButtonEnabled(ByVal frm As FrmM0060) As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If Me.lblTOUROKU.Text = "���o�^" Then
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc12.Enabled = True
            Else
                frm.cmdFunc1.Enabled = False
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc12.Enabled = True
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#End Region
#End Region

#Region "�R���g���[���C�x���g"

    '�����t�B���^�ύX
    Private Sub SearchFilterValueChanged(sender As System.Object, e As System.EventArgs)
        '����
        Me.cmdFunc1.PerformClick()

    End Sub

#Region "MouseClick"
    Private Sub LblDAY_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDAY9.MouseClick, lblDAY8.MouseClick, lblDAY7.MouseClick, lblDAY6.MouseClick, lblDAY5.MouseClick, lblDAY42.MouseClick, lblDAY41.MouseClick, lblDAY40.MouseClick, lblDAY4.MouseClick, lblDAY39.MouseClick, lblDAY38.MouseClick, lblDAY37.MouseClick, lblDAY36.MouseClick, lblDAY35.MouseClick, lblDAY34.MouseClick, lblDAY33.MouseClick, lblDAY32.MouseClick, lblDAY31.MouseClick, lblDAY30.MouseClick, lblDAY3.MouseClick, lblDAY29.MouseClick, lblDAY28.MouseClick, lblDAY27.MouseClick, lblDAY26.MouseClick, lblDAY25.MouseClick, lblDAY24.MouseClick, lblDAY23.MouseClick, lblDAY22.MouseClick, lblDAY21.MouseClick, lblDAY20.MouseClick, lblDAY2.MouseClick, lblDAY19.MouseClick, lblDAY18.MouseClick, lblDAY17.MouseClick, lblDAY16.MouseClick, lblDAY15.MouseClick, lblDAY14.MouseClick, lblDAY13.MouseClick, lblDAY12.MouseClick, lblDAY11.MouseClick, lblDAY10.MouseClick, lblDAY1.MouseClick

        Try
            '�E�N���b�N��
            If e.Button = Windows.Forms.MouseButtons.Right Then
                '�_�u���N���b�N��CALL
                LblDAY_DoubleClick(sender, Nothing)
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex)
        Finally
        End Try
    End Sub
#End Region

#Region "���t�_�u���N���b�N"
    '���t�_�u���N���b�N
    Private Sub LblDAY_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDAY9.DoubleClick, lblDAY8.DoubleClick, lblDAY6.DoubleClick, lblDAY5.DoubleClick, lblDAY42.DoubleClick, lblDAY41.DoubleClick, lblDAY40.DoubleClick, lblDAY4.DoubleClick, lblDAY39.DoubleClick, lblDAY38.DoubleClick, lblDAY37.DoubleClick, lblDAY36.DoubleClick, lblDAY35.DoubleClick, lblDAY34.DoubleClick, lblDAY33.DoubleClick, lblDAY32.DoubleClick, lblDAY31.DoubleClick, lblDAY30.DoubleClick, lblDAY3.DoubleClick, lblDAY29.DoubleClick, lblDAY28.DoubleClick, lblDAY27.DoubleClick, lblDAY26.DoubleClick, lblDAY25.DoubleClick, lblDAY24.DoubleClick, lblDAY23.DoubleClick, lblDAY22.DoubleClick, lblDAY21.DoubleClick, lblDAY20.DoubleClick, lblDAY2.DoubleClick, lblDAY19.DoubleClick, lblDAY18.DoubleClick, lblDAY17.DoubleClick, lblDAY16.DoubleClick, lblDAY15.DoubleClick, lblDAY14.DoubleClick, lblDAY13.DoubleClick, lblDAY12.DoubleClick, lblDAY11.DoubleClick, lblDAY10.DoubleClick, lblDAY1.DoubleClick, lblDAY7.DoubleClick

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Dim intINDEX As Integer
        Dim intCNT As Integer

        Try
            '���t���x��INDEX�擾
            For intCNT = 1 To Me.lblDAY.Length - 1
                If lblDAY(intCNT) Is sender Then
                    intINDEX = intCNT
                End If
            Next

            '���t�\��������������
            If lblDAY(intINDEX).Text.IsNullOrWhiteSpace Then
                Exit Sub
            End If

            '-----�F���]
            If lblDAY(intINDEX).ForeColor = System.Drawing.Color.Red Then '��ғ���
                '�ғ��F��
                lblDAY(intINDEX).ForeColor = System.Drawing.Color.Black
            Else                     '�ғ���
                '��ғ��F��
                lblDAY(intINDEX).ForeColor = System.Drawing.Color.Red
            End If

            Using DB As New ClsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

                '-----�����m�F
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT COUNT(*) FROM M006_CALENDAR")
                sbSQL.Append(" WHERE YMD LIKE  '" & Me.dtYM.ValueNonFormat & "__'")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                ''-----���o�^�\��
                If dsList.Tables(0).Rows(0).Item(0).ToString.TrimEnd() <= 0 Then  '�f�[�^�o�^��������
                    Me.lblTOUROKU.Text = "���o�^"
                ElseIf FunCHECK() = 1 Then�@�@�@�@'�ύX�L�莞
                    Me.lblTOUROKU.Text = "���o�^"
                ElseIf FunCHECK() = 0 Then�@�@�@�@'�ύX������
                    lblTOUROKU.Text = ""

                End If

            End Using

            Exit Sub

        Catch ex As Exception
            EM.ErrorSyori(ex)

        Finally

            '-----�J��
            dsList.Dispose()

        End Try
    End Sub

#End Region

#Region "dtYM�őI��������"

    Private Sub DtYM_TxtChanged(sender As Object, e As EventArgs) Handles dtYM.TxtChanged

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '�C�x���g�n���h�����폜
            RemoveHandler dtYM.TxtChanged, AddressOf DtYM_TxtChanged

            '-----�f�[�^�ύX�`�F�b�N
            If lblTOUROKU.Text = "���o�^" Then '�ύX�L�莞
                If MessageBox.Show(My.Resources.infoSearchUnsettledData, My.Resources.infoTitleResetChange, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    dtYM.Value = dtym_Changed

                    Exit Sub
                End If
            End If

            If dtYM.ValueNonFormat.IsNullOrWhiteSpace Then
                Exit Sub
            End If

            Dim intRET As Integer

            '-----�J�����_�[�N���A
            FunCLEAR()

            '-----����
            intRET = FunSRCH()
            dtym_Changed = dtYM.Text

            Using DB As New ClsDbUtility(pub_SYSTEM_INFO.DbProviderFactories, pub_SYSTEM_INFO.CONNECTIONSTRING)

                '-----�����m�F
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT COUNT(*) FROM M006_CALENDAR")
                sbSQL.Append(" WHERE YMD LIKE  '" & Me.dtYM.ValueNonFormat & "__'")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                If dsList.Tables(0).Rows(0).Item(0).ToString.TrimEnd() <= 0 Then
                    Me.lblTOUROKU.Text = "���o�^"

                Else
                    Me.lblTOUROKU.Text = ""

                End If

            End Using

        Catch ex As Exception
            EM.ErrorSyori(ex)

        Finally
            ' KeyPress�C�x���g�n���h����ǉ�
            AddHandler dtYM.TxtChanged, AddressOf DtYM_TxtChanged
        End Try
    End Sub

#End Region

    Private Sub LblTOUROKU_TextChanged(sender As Object, e As EventArgs) Handles lblTOUROKU.TextChanged
        '���o�^�f�[�^������ꍇ�̂݊m��{�^����\������
        If Me.lblTOUROKU.Text = "���o�^" Then
            cmdFunc1.Enabled = True
        ElseIf Me.lblTOUROKU.Text.IsNullOrWhiteSpace Then
            cmdFunc1.Enabled = False
        End If
    End Sub

#End Region

#Region "���[�J���֐�"

#Region "����"
    '����
    Private Function FunSRCH() As Integer
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim lngCNT As Long
        Dim lngCURROW As Long = 0
        Dim strBUFF As String
        Dim sbSQLWHERE As New System.Text.StringBuilder

        Dim intSTARTWEEKDAY As Integer
        Dim intLASTDAY As Integer
        Dim dteBUFF As DateTime
        Dim intCNT As Integer

        Try
            '----WHERE��쐬
            sbSQLWHERE.Remove(0, sbSQLWHERE.Length)
            '-----�����̗j���擾
            intSTARTWEEKDAY = Me.dtYM.ValueDate.DayOfWeek
            If intSTARTWEEKDAY = 0 Then '��:0�`�y:6
                '��:1�`�y:6�A��:7
                intSTARTWEEKDAY = 7
            End If

            Using DB As ClsDbUtility = DBOpen()

                '-----�����̓��t�擾
                dteBUFF = Me.dtYM.ValueDate.AddMonths(1)
                dteBUFF = dteBUFF.AddDays(-1)
                intLASTDAY = dteBUFF.Day

                ''-----���t�\��
                For intCNT = 1 To lblDAY.Length - 1

                    '���t�\��
                    '���j�����ғ����ɐݒ�
                    If intCNT >= intSTARTWEEKDAY And intCNT <= intLASTDAY + intSTARTWEEKDAY - 1 Then
                        '----���������t�^�ɕϊ�����
                        Dim str As String = dtYM.ValueNonFormat & (intCNT - intSTARTWEEKDAY + 1).ToString("00")
                        Dim dt As DateTime = DateTime.ParseExact(str, "yyyyMMdd", Nothing)

                        '----�j�����擾����
                        Dim weekNumber As Integer = CInt(dt.DayOfWeek)
                        Dim strWeek1 As String = dt.ToString("ddd")

                        If strWeek1 = "��" Then
                            lblDAY(intCNT).ForeColor = Color.Red
                        Else
                        End If

                        lblDAY(intCNT).Text = intCNT - intSTARTWEEKDAY + 1
                        lblDAY(intCNT).Tag = "1"
                        lblDAY(intCNT).Visible = True

                    End If

                    '���t�\��
                    '�y�j�����ғ����ɐݒ�
                    If intCNT >= intSTARTWEEKDAY And intCNT <= intLASTDAY + intSTARTWEEKDAY - 1 Then
                        '----���������t�^�ɕϊ�����
                        Dim str2 As String = dtYM.ValueNonFormat & (intCNT - intSTARTWEEKDAY + 1).ToString("00")
                        Dim dt2 As DateTime = DateTime.ParseExact(str2, "yyyyMMdd", Nothing)

                        '----�j�����擾����
                        Dim weekNumber2 As Integer = CInt(dt2.DayOfWeek)
                        Dim strWeek2 As String = dt2.ToString("ddd")

                        If strWeek2 = "�y" Then
                            lblDAY(intCNT).ForeColor = Color.Red
                        Else
                        End If

                        lblDAY(intCNT).Text = intCNT - intSTARTWEEKDAY + 1
                        lblDAY(intCNT).Tag = "1"
                        lblDAY(intCNT).Visible = True

                    End If

                Next

                '-----�ғ��J�����_�[�����ғ�����\��
                'SQL
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SUBSTRING(YMD,7,2) AS DT,")
                sbSQL.Append(" KADO_KB,")
                sbSQL.Append(" ADD_YMDHNS,")
                sbSQL.Append(" UPD_YMDHNS")
                sbSQL.Append(" FROM M006_CALENDAR ")
                sbSQL.Append(" WHERE YMD LIKE  '" & Me.dtYM.ValueNonFormat & "__'")
                sbSQL.Append(" AND KADO_KB='0'") '0:��ғ�
                sbSQL.Append(sbSQLWHERE)
                sbSQL.Append(" ORDER BY YMD")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            '�\��
            With dsList.Tables(0)
                For lngCNT = 0 To .Rows.Count - 1
                    '���t
                    strBUFF = .Rows(lngCNT).Item("DT").ToString.TrimEnd()
                    lblDAY(intSTARTWEEKDAY + Val(strBUFF) - 1).ForeColor = System.Drawing.Color.Red
                    lblDAY(intSTARTWEEKDAY + Val(strBUFF) - 1).Tag = "0"
                Next
            End With

            '-----���o�^�\��
            If FunCHECK() = 1 Then '�ύX�L�莞
                Me.lblTOUROKU.Text = "���o�^"
            Else '�ύX������
                Me.lblTOUROKU.Text = ""
            End If

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False

        Finally
            '-----�J��
            dsList.Dispose()
        End Try

    End Function

#End Region

#Region "�J�����_�[�N���A"
    Private Function FunCLEAR() As Integer
        Dim intCNT As Integer

        Try
            '-----�J�����_�[�N���A
            For intCNT = 1 To lblDAY.Length - 1
                lblDAY(intCNT).Text = ""
                lblDAY(intCNT).Tag = ""
                lblDAY(intCNT).ForeColor = System.Drawing.Color.Black
                lblDAY(intCNT).Visible = False
            Next
            '-----���o�^�\��
            Me.lblTOUROKU.Text = ""

            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return False
        Finally
        End Try
    End Function
#End Region

#Region "�`�F�b�N"
    Private Function FunCHECK() As Integer
        Dim intCNT As Integer
        Try
            For intCNT = 1 To lblDAY.Length - 1
                '�\��������
                If lblDAY(intCNT).Visible = False Then
                    '���̓���
                    Continue For
                End If

                '�ғ��J�����_�[����\���݂̂ŁA�ݔ��J�����_�[�͖��o�^��
                If lblDAY(intCNT).Tag = "" Then
                    '������
                    Return 1
                End If

                '�����l���ғ��ŁA��ʏ�͔�ғ���
                If lblDAY(intCNT).Tag = "1" And lblDAY(intCNT).ForeColor = System.Drawing.Color.Red Then
                    '������
                    Return 1
                End If

                '�����l����ғ��ŁA��ʏ�͉ғ���
                If lblDAY(intCNT).Tag = "0" And lblDAY(intCNT).ForeColor = System.Drawing.Color.Black Then
                    '������
                    Return 1
                End If

            Next

            Return 0

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return -1
        Finally
        End Try
    End Function
#End Region

#Region "�O���E����"

    Private Function FunZENJIGETU(intprm As Integer) As Integer

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            Me.dtYM.Text = DateTime.ParseExact(Me.dtYM.Text, "yyyy/MM", Nothing).AddMonths(intprm).ToString("yyyy/MM")

        Catch ex As Exception
            EM.ErrorSyori(ex)
            Return True
        Finally
        End Try

    End Function
#End Region

#End Region

End Class
