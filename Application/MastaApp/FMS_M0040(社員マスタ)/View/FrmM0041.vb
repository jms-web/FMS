Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0041

#Region "�ϐ��E�萔"

#End Region

#Region "�v���p�e�B"
    ''' <summary>
    ''' �������[�h
    ''' </summary>
    Public Property PrMODE As Integer

    ''' <summary>
    ''' �V�K�ǉ����R�[�h�̃L�[
    ''' </summary>
    Public Property PrPKeys As String

    ''' <summary>
    ''' �ꗗ�̑I���s�f�[�^
    ''' </summary>
    Public Property PrdgvCellCollection As DataGridViewCellCollection

#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----�ʒu�E�T�C�Y
            Me.Height = 400
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            'Me.cmbKA_CD.SetDataSource(tblBU.ExcludeDeleted, True)
            'Me.cmbBUSYO_CD.SetDataSource(tblKA.ExcludeDeleted, True)
            'Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKU_KBN.ExcludeDeleted, True)
            'Me.cmbCYOKKAN_KB.SetDataSource(tblCYOKKAN_KBN.ExcludeDeleted, True)

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

        End Try
    End Sub

#End Region
#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean

        Try
            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    Me.Text = pub_APP_INFO.strTitle & "�i�ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

                    ''Me.mtxTANTO_CD.Text = "<�V�K>"
                    Me.mtxTANTO_CD.Enabled = True
                    ' Me.mtxTANTO_CD.ReadOnly = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrdgvCellCollection)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ގ��ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

                    'Me.mtxTANTO_CD.Text = "<�V�K>"
                    'Me.mtxTANTO_CD.ReadOnly = True
                    Me.mtxTANTO_CD.Enabled = True
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrdgvCellCollection)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ύX�j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    Me.mtxTANTO_CD.Enabled = False
                    Me.mtxTANTO_NAME.Enabled = True
                    Me.mtxSYOKUBAN.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True

                Case Else
                    Throw New ArgumentException(My.Resources.ErrMsgException, intMODE.ToString)
            End Select

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' �ꗗ�I���s�̒l���Z�b�g
    ''' </summary>
    ''' <param name="dgvCol"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(dgvCol As DataGridViewCellCollection) As Boolean

        Try
            '-----�R���g���[���ɒl���Z�b�g
            With dgvCol
                '�S����CD
                Me.mtxTANTO_CD.Text = .Item("TANTO_CD").Value.ToString.Trim
                '�E��
                Me.mtxSYOKUBAN.Text = .Item("SYOKUBAN").Value.ToString.Trim
                '�S���Җ�
                Me.mtxTANTO_NAME.Text = .Item("TANTO_NAME").Value.ToString.Trim
                '�S���Җ��J�i
                Me.mtxTANTO_NAME_KANA.Text = .Item("TANTO_NAME_KANA").Value.ToString.Trim
                '���ԋ敪
                Me.cmbCYOKKAN_KB.Text = .Item("CYOKKAN_KB_DISP").Value.ToString.Trim
                '���Г�
                Me.dtbNYUSYA_YMD.Text = .Item("NYUSYA_YMD").Value.ToString.Trim
                '�ގГ�
                Me.dtbTAISYA_YMD.Text = .Item("TAISYA_YMD").Value.ToString.Trim
                '��E�敪
                Me.cmbYAKUSYOKU_KB.Text = .Item("YAKUSYOKU_KB_DISP").Value.ToString.Trim
                '��CD      
                Me.cmbBUSYO_CD.Text = .Item("BU_CD").Value
                '��CD
                Me.cmbKA_CD.Text = .Item("KA_CD").Value
                '���N����
                Me.dtbBIRTHDAY.Text = .Item("BIRTHDAY").Value.ToString.Trim
                '�X�V����
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item("EDIT_YMDHNS").Value.ToString, "yyyyMMddHHmmss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                '�X�V�S����CD
                Me.lblEDIT_SYAIN_ID.Text = .Item("EDIT_TANTO_CD").Value & " " & Fun_GetUSER_NAME(.Item("EDIT_TANTO_CD").Value)

            End With
            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region
#Region "FUNCTION�{�^��CLICK"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click

        Dim intFUNC As Integer
        Dim intCNT As Integer
        Dim blnRET As Boolean
        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '�ǉ�
                    Select Case PrMODE
                        Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                            blnRET = FunINS()
                        Case ENM_DATA_OPERATION_MODE._3_UPDATE
                            blnRET = FunUPD()
                        Case Else
                            Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                    End Select

                    If blnRET = True Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        Me.PrPKeys = Me.mtxTANTO_CD.Text.Trim
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
        End Try
    End Sub

#End Region

#Region "�ǉ�"
    Private Function FunINS() As Boolean

        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try
            '-----���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean
                Try
                    '�g�����U�N�V����
                    DB.BeginTransaction()
                    '-----���݃`�F�b�N
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM M03_TANTO ")
                    sbSQL.Append(" WHERE TANTO_CD ='" & Me.mtxTANTO_CD.Text.Trim & "'")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '���ݎ�
                        If MessageBox.Show(String.Format(My.Resources.infoTilteDuplicateData, "�S��CD"), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> DialogResult.OK Then
                            Return False
                        End If
                    End If

                    ''Dim intNewTANTO_CD As Integer = FunGetNextTANTO_CD()
                    ''Me.mtxTANTO_CD.Text = intNewTANTO_CD

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO M03_TANTO(")
                    sbSQL.Append("  TANTO_CD ")
                    sbSQL.Append(" ,SYOKUBAN")
                    sbSQL.Append(" ,TANTO_NAME")
                    sbSQL.Append(" ,TANTO_NAME_KANA")
                    sbSQL.Append(" ,CYOKKAN_KB")
                    sbSQL.Append(" ,NYUSYA_YMD")
                    sbSQL.Append(" ,TAISYA_YMD")
                    sbSQL.Append(" ,YAKUSYOKU_KB")
                    sbSQL.Append(" ,BU_CD")
                    sbSQL.Append(" ,KA_CD")
                    sbSQL.Append(" ,BIRTHDAY")
                    sbSQL.Append(" ,PASSWORD")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_TANTO_CD")
                    sbSQL.Append(" ,EDIT_YMDHNS")
                    sbSQL.Append(" ,EDIT_TANTO_CD")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_TANTO_CD")
                    sbSQL.Append(" ) VALUES ( ")
                    '�S����CD
                    'sbSQL.Append(" " & intNewTANTO_CD & "")
                    sbSQL.Append(" " & Nz(Me.mtxTANTO_CD.Text.Trim, " ") & "")
                    '�E��
                    sbSQL.Append(" ," & Me.mtxSYOKUBAN.Text.Trim & "")
                    '�S���Җ�
                    sbSQL.Append(" ,'" & Me.mtxTANTO_NAME.Text.Trim & "'")
                    '�S���Җ��J�i
                    sbSQL.Append(" ,'" & Me.mtxTANTO_NAME_KANA.Text.Trim & "'")
                    '���ԋ敪
                    sbSQL.Append(" ,'" & Me.cmbCYOKKAN_KB.SelectedValue & "'")
                    '���Г�
                    sbSQL.Append(" ,'" & Nz(Me.dtbNYUSYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    '�ގГ�
                    sbSQL.Append(" ,'" & Nz(Me.dtbTAISYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    '��E�敪
                    sbSQL.Append(" ,'" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    '��CD
                    sbSQL.Append(" ," & Nz(Me.cmbBUSYO_CD.SelectedValue, " ") & "")
                    '��CD
                    sbSQL.Append(" ," & Nz(Me.cmbKA_CD.SelectedValue, " ") & "")
                    '���N����
                    sbSQL.Append(" ,'" & Nz(Me.dtbBIRTHDAY.Text.Trim.Replace("/", ""), " ") & "'")
                    '�p�X���[�h
                    sbSQL.Append(" ,'" & Me.mtxPASSWORD.Text.Trim & "'")
                    '�ǉ�����
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '�ǉ��S����
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '�X�V����
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '�X�V�S����
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '�폜����
                    sbSQL.Append(" ,''")
                    '�폜�S����
                    sbSQL.Append(" ,0")
                    sbSQL.Append(" )")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O�o��
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If
                Finally
                    '�g�����U�N�V����
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

#Region "�X�V"
    Private Function FunUPD() As Boolean

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Dim intRET As Integer
        Dim sqlEx As Exception = Nothing
        Dim blnErr As Boolean
        Try
            '���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Try
                    '�g�����U�N�V����
                    DB.BeginTransaction()
                    '-----���݃`�F�b�N
                    sbSQL.Append("SELECT * FROM M03_TANTO ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxTANTO_CD.Text.Trim & ""))
                    sbSQL.Append(" AND EDIT_YMDHNS ='" & PrdgvCellCollection.Item("EDIT_YMDHNS").Value.ToString & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M03_TANTO SET")
                    sbSQL.Append(" SYOKUBAN =" & Me.mtxSYOKUBAN.Text.Trim & "")
                    sbSQL.Append(" ,TANTO_NAME ='" & Me.mtxTANTO_NAME.Text.Trim & "'")
                    sbSQL.Append(" ,TANTO_NAME_KANA ='" & Me.mtxTANTO_NAME_KANA.Text.Trim & "'")
                    sbSQL.Append(" ,CYOKKAN_KB ='" & Me.cmbCYOKKAN_KB.SelectedValue & "'")
                    sbSQL.Append(" ,NYUSYA_YMD ='" & Nz(Me.dtbNYUSYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,TAISYA_YMD ='" & Nz(Me.dtbTAISYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,YAKUSYOKU_KB ='" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    sbSQL.Append(" ,BU_CD =" & Nz(Me.cmbBUSYO_CD.SelectedValue, " ") & "")
                    sbSQL.Append(" ,KA_CD =" & Nz(Me.cmbKA_CD.SelectedValue, " ") & "")
                    sbSQL.Append(" ,BIRTHDAY ='" & Nz(Me.dtbBIRTHDAY.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,EDIT_YMDHNS = dbo.GetSysDateString() ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxTANTO_CD.Text.Trim, " "))

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                Finally
                    '�g�����U�N�V����
                    DB.Commit(Not blnErr)
                End Try
            End Using

            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally
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
    Public Function FunInitFuncButtonEnabled(ByRef frm As FrmM0040) As Boolean

        Try
            For intFunc As Integer = 1 To 12
                With frm.Controls("cmdFunc" & intFunc)
                    If .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).Trim = "" Then
                        .Text = ""
                        .Visible = False
                    End If
                End With
            Next intFunc

            If frm.dgvDATA.RowCount > 0 Then
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = True
                frm.cmdFunc4.Enabled = True
                frm.cmdFunc5.Enabled = True
                frm.cmdFunc10.Enabled = True
            Else
                frm.cmdFunc1.Enabled = True
                frm.cmdFunc2.Enabled = True
                frm.cmdFunc3.Enabled = False
                frm.cmdFunc4.Enabled = False
                frm.cmdFunc5.Enabled = False
                frm.cmdFunc10.Enabled = False
            End If

            Dim dgv As DataGridView = DirectCast(frm.Controls("dgvDATA"), DataGridView)
            If dgv.SelectedRows.Count > 0 Then
                If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Cells.Item("DEF_FLG").Value <> "" Then
                    '�폜�σf�[�^�̏ꍇ
                    frm.cmdFunc4.Enabled = False
                    frm.cmdFunc5.Text = "���S�폜(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._6_DELETE

                    '����
                    frm.cmdFunc6.Text = "����(F6)"
                    frm.cmdFunc6.Visible = True
                    frm.cmdFunc6.Tag = ENM_DATA_OPERATION_MODE._5_RESTORE
                Else
                    frm.cmdFunc5.Text = "�폜(F5)"
                    frm.cmdFunc5.Tag = ENM_DATA_OPERATION_MODE._4_DISABLE

                    frm.cmdFunc6.Text = ""
                    frm.cmdFunc6.Visible = False
                    frm.cmdFunc6.Tag = ""
                End If
            Else
                frm.cmdFunc6.Visible = False
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

#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean

        Try
            '�S����CD
            If Me.mtxTANTO_CD.Text.Trim = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�S����CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxTANTO_CD.Focus()
                Return False
            End If

            '�E��
            If Me.mtxSYOKUBAN.Text.Trim = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�E��"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxSYOKUBAN.Focus()
                Return False
            End If

            '�S���Җ�
            If Me.mtxTANTO_NAME.Text = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�S���Җ�"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxTANTO_NAME.Focus()
                Return False
            End If

            '��CD
            If Me.cmbBUSYO_CD.SelectedValue = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "��CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbBUSYO_CD.Focus()
                Return False
            End If

            '��CD
            If Me.cmbKA_CD.SelectedValue = "" Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "��CD"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbKA_CD.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function


#Region "���[�J���֐�"

    Private Function FunGetNextTANTO_CD() As Integer

        Dim dsList As New System.Data.DataSet
        Try
            Dim intRET As Integer
            Dim sbSQL As New System.Text.StringBuilder

            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("SELECT MAX(TANTO_CD) FROM M03_TANTO ")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            intRET = Val(dsList.Tables(0).Rows(0).Item(0)) + 1

            Return intRET
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return -1
        Finally
            dsList.Dispose()
        End Try
    End Function


#End Region
#End Region

End Class
