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
    Public Property PrPKeys As (ITEM_NAME As String, ITEM_VALUE As String)

    Public Property PrDataRow As C1.Win.C1FlexGrid.Row

#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using

            '-----�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----�ʒu�E�T�C�Y
            Me.Height = 400
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            Me.cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, True)
            Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, True)
            Me.cmbDAIKO.SetDataSource(tblDAIKO_KB.ExcludeDeleted, True)

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
                    lblTytle.Text &= "�i�ǉ��j"
                    Me.cmdFunc1.Text = "�ǉ�(F1)"
                    Me.mtxSIMEI.Enabled = True
                    Me.mtxSYAIN_NO.Enabled = True
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    'Call FunSetEntityValues(PrdgvCellCollection)

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    Me.cmdFunc1.Text = "�ǉ�(F1)"
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    'Call FunSetEntityValues(PrdgvCellCollection)

                    lblTytle.Text &= "�i�ύX�j"
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    Me.mtxSYAIN_ID.Enabled = False
                    Me.mtxSIMEI.Enabled = True
                    Me.mtxSYAIN_NO.Enabled = True

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
                Me.mtxSYAIN_ID.Text = .Item("TANTO_CD").Value.ToString.Trim
                '�E��
                Me.mtxSYAIN_NO.Text = .Item("SYOKUBAN").Value.ToString.Trim
                '�S���Җ�
                Me.mtxSIMEI.Text = .Item("TANTO_NAME").Value.ToString.Trim
                '�S���Җ��J�i
                Me.mtxSIMEI_KANA.Text = .Item("TANTO_NAME_KANA").Value.ToString.Trim
                '���Г�
                Me.dtbNYUSYA_YMD.Text = .Item("NYUSYA_YMD").Value.ToString.Trim
                '�ގГ�
                Me.dtbTAISYA_YMD.Text = .Item("TAISYA_YMD").Value.ToString.Trim
                '��E�敪
                Me.cmbYAKUSYOKU_KB.Text = .Item("YAKUSYOKU_KB_DISP").Value.ToString.Trim
                '���N����
                Me.dtbBIRTHDAY.Text = .Item("BIRTHDAY").Value.ToString.Trim
                '�p�X���[�h
                Me.mtxPASS.Text = .Item("PASS").Value.ToString.Trim
                '�Ј��敪
                Me.cmbSYAIN_KB.SelectedValue = .Item("SYAIN_KB").Value.ToString.Trim
                '��E�敪
                Me.cmbYAKUSYOKU_KB.SelectedValue = .Item("YAKUSYOKU_KB").Value.ToString.Trim
                '��s�敪
                Me.cmbDAIKO.SelectedValue = .Item("DAIKO_KB").Value.ToString.Trim
                '���[���A�h���X
                Me.mtxMAIL_ADD.Text = .Item("MAIL_ADD.").Value.ToString.Trim

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
                        'Me.PrPKeys = Me.mtxTANTO_CD.Text.Trim
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
                    sbSQL.Append("SELECT * FROM M004_SYAIN ")
                    sbSQL.Append(" WHERE SYAIN_NO ='" & Me.mtxSYAIN_NO.Text.Trim & "'")
                    sbSQL.Append(" AND TAISYA_YMD <> ' '")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '���ݎ�
                        If MessageBox.Show(String.Format(My.Resources.infoTilteDuplicateData, "���ސE�̐E��"), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) <> DialogResult.OK Then
                            Return False
                        End If
                    End If

                    ''Dim intNewTANTO_CD As Integer = FunGetNextTANTO_CD()
                    ''Me.mtxTANTO_CD.Text = intNewTANTO_CD

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO M004_SYAIN(")
                    sbSQL.Append("  SYAIN_ID ")
                    sbSQL.Append(" ,SYAIN_NO ")
                    sbSQL.Append(" ,SIMEI")
                    sbSQL.Append(" ,SIMEI_KANA")
                    sbSQL.Append(" ,SYAIN_KB")
                    sbSQL.Append(" ,YAKUSYOKU_KB")
                    sbSQL.Append(" ,DAIKO_KB")
                    sbSQL.Append(" ,BIRTH_YMD")
                    sbSQL.Append(" ,TEL")
                    sbSQL.Append(" ,MAIL_ADDRESS")
                    sbSQL.Append(" ,NYUSYA_YMD")
                    sbSQL.Append(" ,TAISYA_YMD")
                    sbSQL.Append(" ,PASS")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '�Ј�ID
                    sbSQL.Append(" (SELECT MAX(SYAIN_ID)+1 FROM M004_SYAIN)")
                    '�Ј�NO
                    sbSQL.Append(" ,'" & Me.mtxSYAIN_NO.Text.Trim & "'")
                    '����
                    sbSQL.Append(" ,'" & Me.mtxSIMEI.Text.Trim & "'")
                    '�����J�i
                    sbSQL.Append(" ,'" & Me.mtxSIMEI_KANA.Text.Trim & "'")
                    '�Ј��敪
                    sbSQL.Append(" ,'" & Me.cmbSYAIN_KB.SelectedValue & "'")
                    '��E�敪
                    sbSQL.Append(" ,'" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    '���F��s�敪
                    sbSQL.Append(" ,'" & Me.cmbDAIKO.SelectedValue & "'")
                    '���N����
                    sbSQL.Append(" ,'" & Me.dtbBIRTHDAY.ValueNonFormat & "'")
                    'TEL
                    sbSQL.Append(" ,'" & Me.mtxTEL.Text.Trim & "'")
                    '���[���A�h���X
                    sbSQL.Append(" ,'" & Me.mtxMAIL_ADD.Text.Trim & "'")
                    '���ДN����
                    sbSQL.Append(" ,'" & Me.dtbNYUSYA_YMD.ValueNonFormat & "'")
                    '�ގДN����
                    sbSQL.Append(" ,'" & Me.dtbTAISYA_YMD.ValueNonFormat& "'")
                    '�p�X���[�h
                    sbSQL.Append(" ,'" & Me.mtxPASS.Text.Trim & "'")
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
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxSYAIN_ID.Text.Trim & ""))
                    'sbSQL.Append(" AND EDIT_YMDHNS ='" & PrdgvCellCollection.Item("EDIT_YMDHNS").Value.ToString & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M03_TANTO SET")
                    sbSQL.Append(" SYOKUBAN =" & Me.mtxSYAIN_NO.Text.Trim & "")
                    sbSQL.Append(" ,TANTO_NAME ='" & Me.mtxSIMEI.Text.Trim & "'")
                    sbSQL.Append(" ,TANTO_NAME_KANA ='" & Me.mtxSIMEI_KANA.Text.Trim & "'")
                    sbSQL.Append(" ,CYOKKAN_KB ='" & Me.cmbSYAIN_KB.SelectedValue & "'")
                    sbSQL.Append(" ,NYUSYA_YMD ='" & Nz(Me.dtbNYUSYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,TAISYA_YMD ='" & Nz(Me.dtbTAISYA_YMD.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,YAKUSYOKU_KB ='" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    'sbSQL.Append(" ,BU_CD =" & Nz(Me.cmbBUSYO_CD.SelectedValue, " ") & "")
                    'sbSQL.Append(" ,KA_CD =" & Nz(Me.cmbKA_CD.SelectedValue, " ") & "")
                    sbSQL.Append(" ,BIRTHDAY ='" & Nz(Me.dtbBIRTHDAY.Text.Trim.Replace("/", ""), " ") & "'")
                    sbSQL.Append(" ,EDIT_YMDHNS = dbo.GetSysDateString() ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" TANTO_CD =" & Nz(Me.mtxSYAIN_ID.Text.Trim, " "))

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
    Private Function FunInitFuncButtonEnabled() As Boolean
        Try

            For intFunc As Integer = 1 To 12
                Dim cmd As Button = DirectCast(Me.Controls.Find("cmdFunc" & intFunc, True)(0), Button)
                With cmd
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNullOrWhiteSpace Then
                        .Text = ""
                        '.Visible = False
                        .Enabled = False
                    End If
                End With
            Next intFunc


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

            '�E��
            If Me.mtxSYAIN_NO.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�E��"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxSYAIN_NO.Focus()
                Return False
            End If

            '�Ј��敪
            If Me.cmbSYAIN_KB.SelectedValue = 0 Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�Ј��敪"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbSYAIN_KB.Focus()
                Return False
            End If

            '�S���Җ�
            If Me.mtxSIMEI.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "����"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxSIMEI.Focus()
                Return False
            End If

            '�S���Җ��J�i
            If Me.mtxSIMEI_KANA.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�����J�i"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxSIMEI_KANA.Focus()
                Return False
            End If

            '�p�X���[�h
            If Me.mtxPASS.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelect, "�p�X���[�h"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxPASS.Focus()
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
