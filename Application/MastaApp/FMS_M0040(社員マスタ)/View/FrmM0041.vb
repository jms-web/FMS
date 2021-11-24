Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0041

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

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()

        CmbAuth1.NullValue = 0
        CmbAuth2.NullValue = 0
        CmbAuth3.NullValue = 0
        CmbAuth4.NullValue = 0

    End Sub

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
            Me.Height = 530
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 26 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�R���g���[���f�[�^�\�[�X�ݒ�
            Me.cmbSYAIN_KB.SetDataSource(tblSYAIN_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbYAKUSYOKU_KB.SetDataSource(tblYAKUSYOKU_KB.ExcludeDeleted, True)
            Me.cmbDAIKO.SetDataSource(tblDAIKO_KB.ExcludeDeleted, True)

            Me.CmbAuth1.SetDataSource(tblKENGEN, False)
            Me.CmbAuth2.SetDataSource(tblKENGEN2, False)
            Me.CmbAuth3.SetDataSource(tblKENGEN3, False)
            Me.CmbAuth4.SetDataSource(tblKENGEN4, False)

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            Dim blnSysAdmin As Boolean = IsSysAdminUser(pub_SYAIN_INFO.SYAIN_ID)
            chkADMIN_SYS.Enabled = blnSysAdmin
            chkADMIN_OP.Enabled = blnSysAdmin
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

                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    Me.cmdFunc1.Text = "�ǉ�(F1)"
                    Me.mtxSYAIN_ID.Text = ""
                    Me.mtxSYAIN_NO.Text = ""
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE

                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "�i�ύX�j"
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    Me.mtxSYAIN_ID.Enabled = False
                    Me.mtxSYAIN_NO.Enabled = False
                    Me.mtxSIMEI.Enabled = True

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
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.VWM004_SYAIN
        Try
            '-----�R���g���[���ɒl���Z�b�g
            With row

                '�Ј�ID
                Me.mtxSYAIN_ID.Text = .Item(NameOf(_model.SYAIN_ID)) '.Item("SYAIN_ID").Value.ToString.Trim
                '�Ј�NO�i�E�ԁj
                Me.mtxSYAIN_NO.Text = .Item(NameOf(_model.SYAIN_NO))
                '�S���Җ�
                Me.mtxSIMEI.Text = .Item(NameOf(_model.SIMEI))
                '�S���Җ��J�i
                Me.mtxSIMEI_KANA.Text = .Item(NameOf(_model.SIMEI_KANA))
                '���Г�
                Me.dtbNYUSYA_YMD.Text = .Item(NameOf(_model.NYUSYA_YMD))
                '�ގГ�
                Me.dtbTAISYA_YMD.Text = .Item(NameOf(_model.TAISYA_YMD))
                '��E�敪
                Me.cmbYAKUSYOKU_KB.SelectedValue = .Item(NameOf(_model.YAKUSYOKU_KB))
                '���N����
                Me.dtbBIRTHDAY.Text = .Item(NameOf(_model.BIRTH_YMD))
                '�p�X���[�h
                Me.mtxPASS.Text = .Item(NameOf(_model.PASS))
                '�Ј��敪
                Me.cmbSYAIN_KB.SelectedValue = .Item(NameOf(_model.SYAIN_KB))
                '��E�敪
                Me.cmbYAKUSYOKU_KB.SelectedValue = .Item(NameOf(_model.YAKUSYOKU_KB))
                '��s�敪
                Me.cmbDAIKO.SelectedValue = .Item(NameOf(_model.DAIKO_KB))
                '���[���A�h���X
                Me.mtxMAIL_ADD.Text = .Item(NameOf(_model.MAIL_ADDRESS))
                'TEL
                Me.mtxTEL.Text = .Item(NameOf(_model.TEL))

                '�^�p����
                chkADMIN_OP.Checked = .Item(NameOf(_model.ADMIN_OP)) = "1"
                '�V�X�e������
                chkADMIN_SYS.Checked = .Item(NameOf(_model.ADMIN_SYS)) = "1"

                '
                'chkADMIN_AUTH.Checked = .Item(NameOf(_model.ADMIN_AUTH)) = "1"
                ''
                'chkMAILSEND_AUTH.Checked = .Item(NameOf(_model.MAILSEND_AUTH)) = "1"

                Me.mtxCARD_ID.Text = .Item(NameOf(_model.IC_CARD_ID))

                Me.CmbAuth1.SelectedValue = .Item(NameOf(_model.AUTH1)).ToString.ToVal
                Me.CmbAuth2.SelectedValue = .Item(NameOf(_model.AUTH2)).ToString.ToVal
                Me.CmbAuth3.SelectedValue = .Item(NameOf(_model.AUTH3)).ToString.ToVal
                Me.CmbAuth4.SelectedValue = .Item(NameOf(_model.AUTH4)).ToString.ToVal

                '�X�V����
                If Not row.Item(NameOf(_model.UPD_YMDHNS)).ToString.IsNulOrWS Then
                    Dim dt As DateTime
                    dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                    Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")
                End If

                '�X�V�S��
                Me.lblEDIT_SYAIN_ID.Text = .Item(NameOf(_model.UPD_SYAIN_NAME)).ToString

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
                    sbSQL.Append(" ,ADMIN_OP")
                    sbSQL.Append(" ,ADMIN_SYS")
                    sbSQL.Append(" ,IC_CARD_ID")
                    sbSQL.Append(" ,AUTH1")
                    sbSQL.Append(" ,AUTH2")
                    sbSQL.Append(" ,AUTH3")
                    sbSQL.Append(" ,AUTH4")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '�Ј�ID
                    sbSQL.Append(" (SELECT MAX(SYAIN_ID)+1 FROM M004_SYAIN WHERE SYAIN_ID <= 999990)")
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
                    sbSQL.Append(" ,'" & Me.dtbTAISYA_YMD.ValueNonFormat & "'")
                    '�p�X���[�h
                    sbSQL.Append(" ,'" & Me.mtxPASS.Text.Trim & "'")
                    '�^�p����
                    sbSQL.Append(" ,'" & If(chkADMIN_OP.Checked, "1", "0") & "'")
                    '�V�X�e������
                    sbSQL.Append(" ,'" & If(chkADMIN_SYS.Checked, "1", "0") & "'")

                    'IC_CARD_ID
                    sbSQL.Append(" ,'" & Me.mtxCARD_ID.Text.Trim & "'")
                    '����1
                    sbSQL.Append(" ," & 0 & "")
                    '����2
                    sbSQL.Append(" ," & 0 & "")
                    '����3
                    sbSQL.Append(" ," & 0 & "")
                    '����4
                    sbSQL.Append(" ," & 0 & "")

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

            Using DB = DBOpen()
                Try
                    '�g�����U�N�V����
                    DB.BeginTransaction()
                    '-----���݃`�F�b�N
                    sbSQL.Append("SELECT * FROM M004_SYAIN ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" SYAIN_ID =" & Nz(Me.mtxSYAIN_ID.Text.Trim & ""))

                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----UPDATE
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE M004_SYAIN SET")
                    sbSQL.Append("  SIMEI        ='" & Me.mtxSIMEI.Text.Trim & "'")
                    sbSQL.Append(" ,SIMEI_KANA   ='" & Me.mtxSIMEI_KANA.Text.Trim & "'")
                    sbSQL.Append(" ,SYAIN_KB     ='" & Me.cmbSYAIN_KB.SelectedValue & "'")
                    sbSQL.Append(" ,YAKUSYOKU_KB ='" & Me.cmbYAKUSYOKU_KB.SelectedValue & "'")
                    sbSQL.Append(" ,DAIKO_KB     ='" & Me.cmbDAIKO.SelectedValue & "'")
                    sbSQL.Append(" ,BIRTH_YMD    ='" & Me.dtbBIRTHDAY.ValueNonFormat & "'")
                    sbSQL.Append(" ,TEL          ='" & Me.mtxTEL.Text.Trim & "'")
                    sbSQL.Append(" ,MAIL_ADDRESS ='" & Me.mtxMAIL_ADD.Text.Trim & "'")
                    sbSQL.Append(" ,NYUSYA_YMD   ='" & Me.dtbNYUSYA_YMD.ValueNonFormat & "'")
                    sbSQL.Append(" ,TAISYA_YMD   ='" & Me.dtbTAISYA_YMD.ValueNonFormat & "'")
                    sbSQL.Append(" ,PASS         ='" & Me.mtxPASS.Text.Trim & "'")
                    sbSQL.Append(" ,ADMIN_OP     ='" & If(chkADMIN_OP.Checked, "1", "0") & "'")
                    sbSQL.Append(" ,ADMIN_SYS    ='" & If(chkADMIN_SYS.Checked, "1", "0") & "'")

                    sbSQL.Append(" ,IC_CARD_ID   ='" & Me.mtxCARD_ID.Text.Trim & "'")
                    sbSQL.Append(" ,AUTH1   =" & Me.CmbAuth1.SelectedValue & "")
                    sbSQL.Append(" ,AUTH2   =" & Me.CmbAuth2.SelectedValue & "")
                    sbSQL.Append(" ,AUTH3   =" & Me.CmbAuth3.SelectedValue & "")
                    sbSQL.Append(" ,AUTH4   =" & Me.CmbAuth4.SelectedValue & "")

                    sbSQL.Append(" ,UPD_YMDHNS   = dbo.GetSysDateString() ")
                    sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID & " ")
                    sbSQL.Append(" WHERE")
                    sbSQL.Append(" SYAIN_ID =" & Nz(Me.mtxSYAIN_ID.Text.Trim, " "))

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '�G���[���O
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                    '�Ǘ��Ҍ��� �o�^�ő�l�擾

                    '�Ǘ��Ҍ��� �o�^

                    '���[���đ��M���� �o�^�ő�l�擾

                    '���[���đ��M���� �o�^
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
                    If cmd IsNot Nothing AndAlso .Text.Length = 0 OrElse .Text.Substring(0, .Text.IndexOf("(")).IsNulOrWS Then
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

#Region "���̓`�F�b�N"

    Public Function FunCheckInput() As Boolean

        Try
            IsValidated = True
            IsCheckRequired = True

            '�E��
            Call MtxSYAIN_NO_Validating(mtxSYAIN_NO, Nothing)

            '�Ј��敪
            Call CmbSYAIN_KB_Validating(cmbSYAIN_KB, Nothing)

            '�S���Җ�
            Call MtxSIMEI_Validating(mtxSIMEI, Nothing)

            '�S���Җ��J�i
            Call MtxSIMEI_KANA_Validating(mtxSIMEI_KANA, Nothing)

            '�p�X���[�h
            Call MtxPASS_Validating(mtxPASS, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

    Private Sub MtxSYAIN_NO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSYAIN_NO.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�E��"))
        End If
    End Sub

    Private Sub CmbSYAIN_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbSYAIN_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�Ј��敪"))
        End If
    End Sub

    Private Sub MtxSIMEI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����"))
        End If
    End Sub

    Private Sub MtxSIMEI_KANA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxSIMEI_KANA.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����J�i"))
        End If
    End Sub

    Private Sub MtxPASS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxPASS.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        If IsCheckRequired Then
            IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�p�X���[�h"))
        End If
    End Sub

    Private Sub ChkADMIN_SYS_CheckedChanged(sender As Object, e As EventArgs) Handles chkADMIN_SYS.CheckedChanged
        If chkADMIN_SYS.Checked Then chkADMIN_OP.Checked = True
    End Sub

#End Region

    Private Sub btnReadCard_Click(sender As Object, e As EventArgs) Handles btnReadCard.Click
        Dim strCARD_ID As String
        Dim dr As DataRow

        Try
            '�T�E���h�Đ�
            'Call PlaySound(pub_buttonSound)

            '�J�[�hID�ǎ�
            strCARD_ID = FunGET_ID(blnErrDisp:=False)

            If strCARD_ID = "" Then
                MessageBox.Show("�J�[�hID���擾�ł��܂���ł����B")
                Me.mtxCARD_ID.Text = ""
                Exit Sub
            End If

            '�J�[�h�d���`�F�b�N
            Dim syainNo = GetUserNo(strCARD_ID)
            If Not syainNo.IsNulOrWS Then
                '���ɓ����J�[�h���o�^�ς݂̏ꍇ
                MessageBox.Show("���̃J�[�h�͊��ɕʂ̃��[�U�[���g�p���Ă��܂�", "�o�^�ς݃J�[�h", MessageBoxButtons.OK)
                Me.mtxCARD_ID.Text = ""
            Else
                '�J�[�hID���L�^
                Me.mtxCARD_ID.Text = strCARD_ID
                'Me.mtxCARD_ID.Tag = strCARD_ID
            End If
            'dr = FunGetUSER(strCARD_ID)
            'If dr IsNot Nothing Then
            '    '���ɓ����J�[�h���o�^�ς݂̏ꍇ
            '    MessageBox.Show("���̃J�[�h�͊��ɕʂ̃��[�U�[���g�p���Ă��܂��B" & vbCrLf & "�ʂ̃J�[�h���g�p���ĉ������B", "�o�^�ς݃J�[�h", MessageBoxButtons.OK)
            '    Me.mtxCARD_ID.Text = ""
            'Else
            '    '�J�[�hID���L�^
            '    Me.mtxCARD_ID.Text = strCARD_ID
            'End If
        Catch ex As Exception
            EM.ErrorSyori(ex)
        End Try
    End Sub

    Private Function MaskCardNo(CARD_ID As String) As String
        Dim result As String
        If CARD_ID.IsNulOrWS Then
            Return ""
        Else
            result = Strings.Right(Strings.StrDup(CARD_ID.Length, "*") & Strings.Right(CARD_ID, 5), CARD_ID.Length)
        End If

        Return result
    End Function

    Private Sub btnCLEAR_Click(sender As Object, e As EventArgs) Handles btnCLEAR.Click
        Me.mtxCARD_ID.Text = ""
    End Sub

End Class