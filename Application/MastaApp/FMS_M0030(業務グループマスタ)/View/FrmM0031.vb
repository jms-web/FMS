Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0031

#Region "�ϐ��E�萔"
    Private IsValidated As Boolean
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
    'Public Property PrDataRow As DataRow

#End Region

#Region "�R���X�g���N�^"
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()


    End Sub
#End Region

#Region "FORM�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '-----�t�H�[�����ʐݒ�
            Call FunFormCommonSetting(pub_APP_INFO, pub_SYAIN_INFO)

            '-----�ʒu�E�T�C�Y
            Me.Height = 400
            Me.MinimumSize = New Size(1280, 360)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 30 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2


            '-----�e�R���g���[���̃f�[�^�\�[�X��ݒ�
            Me.cmbBUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbBUMON_KB.SetDataSource(tblBUMON.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._0_Required)
            Me.cmbOYA_BUSYO_KB.SetDataSource(tblBUSYO_KB.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)
            Me.cmbSYOZOKUCYO.SetDataSource(tblSYAIN.ExcludeDeleted, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            '�C�x���g�n���h���ݒ�
            AddHandler cmbOYA_BUSYO_KB.TextChanged, AddressOf CmbOYA_BUSYO_KB_TextChanged
            'AddHandler chkYUKO_YMD.CheckedChanged, AddressOf chkYUKO_YMD_CheckedChanged

            '-----�������[�h�ʉ�ʏ�����
            Call FunInitializeControls(PrMODE)

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

#End Region

#Region "FUNCTION�{�^���֘A"

#Region "FUNCTION�{�^��CLICK�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
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
                        Case ENM_DATA_OPERATION_MODE._6_DELETE

                        Case Else
                            Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                    End Select

                    If blnRET = True Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        'Me.PrPKeys = (Me.cmbBUSYO_KB.Text.Trim, Me.mtxYUKO_YMD.Text.Trim)

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)

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
        Dim dsList As New DataSet
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
                    DB.BeginTransaction()

                    '-----���݃`�F�b�N
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M002_BUSYO) & "")
                    sbSQL.Append(" WHERE BUSYO_NAME ='" & Me.mtxBUSYO_NAME.Text.Trim & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '���ݎ�
                        MessageBox.Show("���ɓo�^�ς݂̃f�[�^�ł��B" & vbCrLf & "���̓f�[�^���m�F���ĉ������B", "���݃`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.M002_BUSYO) & " (")
                    sbSQL.Append("  BUSYO_ID")
                    sbSQL.Append(" ,YUKO_YMD")
                    sbSQL.Append(" ,BUSYO_KB")
                    sbSQL.Append(" ,BUSYO_NAME")
                    sbSQL.Append(" ,OYA_BUSYO_ID")
                    sbSQL.Append(" ,SYOZOKUCYO_ID")
                    sbSQL.Append(" ,TEL")
                    sbSQL.Append(" ,BUMON_KB")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '����ID
                    sbSQL.Append(" �@(SELECT isnull(MAX(BUSYO_ID),0) + 1 FROM M002_BUSYO)")
                    '�L������
                    If chkYUKO_YMD.Checked = True Then
                        sbSQL.Append(" ,'99999999'")
                    Else
                        sbSQL.Append(" ,'" & datYUKO_YMD.ValueNonFormat & "'")
                    End If

                    '�����敪
                    sbSQL.Append(" ,'" & Me.cmbOYA_BUSYO_KB.SelectedValue & "'")
                    '������
                    sbSQL.Append(" ,'" & Me.mtxBUSYO_NAME.Text.Trim & "'")
                    '�e����ID
                    sbSQL.Append(" ," & Me.cmbOYA_BUSYO.SelectedValue & "")
                    '�������Ј�ID
                    sbSQL.Append(" ,'" & Me.cmbSYOZOKUCYO.SelectedValue & "'")
                    'TEL
                    sbSQL.Append(" ,'" & Me.mtxTEL.Text & "'")
                    '����敪
                    sbSQL.Append(" ,'" & Me.cmbBUMON_KB.SelectedValue & "'")
                    '�ǉ�����
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '�ǉ��S����
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '�X�V����
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '�X�V�S����
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '�폜����
                    sbSQL.Append(" ,' '")
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
        Dim dsList As New System.Data.DataSet

        Try
            '���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As Exception = Nothing
                Dim blnErr As Boolean

                Try
                    '�g�����U�N�V����
                    DB.BeginTransaction()

                    '-----���݃`�F�b�N
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M002_BUSYO) & " ")
                    sbSQL.Append("WHERE")
                    sbSQL.Append(" BUSYO_ID ='" & PrDataRow.Item("BUSYO_ID").ToString & "' ")
                    sbSQL.Append(" AND UPD_YMDHNS ='" & Replace(Replace(Replace(PrDataRow.Item("UPD_YMDHNS").ToString, "/", ""), ":", ""), " ", "") & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----���ꍀ�ږ��̊���l������
                    'If Me.chkDefaultVaue.Checked = True Then
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M002_BUSYO) & " SET")
                    If Me.chkYUKO_YMD.Checked = True Then
                        sbSQL.Append(" YUKO_YMD ='99999999' ")
                    Else
                        sbSQL.Append(" YUKO_YMD ='" & datYUKO_YMD.ValueNonFormat & "' ")
                    End If

                    sbSQL.Append(",BUMON_KB ='" & cmbBUMON_KB.SelectedValue & "' ")
                    sbSQL.Append(",BUSYO_KB ='" & cmbBUSYO_KB.SelectedValue & "' ")
                    sbSQL.Append(",BUSYO_NAME ='" & Me.mtxBUSYO_NAME.Text.Trim & "' ")

                    If Me.cmbOYA_BUSYO.SelectedIndex <= 0 Then
                        sbSQL.Append(",OYA_BUSYO_ID = 0 ")
                    Else
                        sbSQL.Append(",OYA_BUSYO_ID = " & Me.cmbOYA_BUSYO.SelectedValue & " ")
                    End If


                    sbSQL.Append(",SYOZOKUCYO_ID = " & Me.cmbSYOZOKUCYO.SelectedValue & " ")
                    sbSQL.Append(",TEL ='" & Me.mtxTEL.Text & "' ")
                    sbSQL.Append(",UPD_YMDHNS = dbo.GetSysDateString() ")
                    sbSQL.Append(",UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID)
                    sbSQL.Append(" WHERE BUSYO_ID = " & PrDataRow.Item("BUSYO_ID").ToString & " ")

                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If sqlEx IsNot Nothing Then
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

    '���ږ��R���{�{�b�N�X�ύX���C�x���g
    Private Sub CmbOYA_BUSYO_KB_TextChanged(sender As Object, e As EventArgs)
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        'Dim intMaxOrder As Integer

        Try

            If cmbOYA_BUSYO_KB.SelectedIndex <> 0 Then

                'Me.cmbOYA_BUSYO.DataSource = Nothing

                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "����", tblBUSYO, " BUSYO_KB = '" & cmbOYA_BUSYO_KB.SelectedValue & "' AND YUKO_YMD >= '" & Replace(Now.ToShortDateString, "/", "") & "'")
                End Using

                Me.cmbOYA_BUSYO.SetDataSource(tblBUSYO, ENM_COMBO_SELECT_VALUE_TYPE._2_Option)

            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub


#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True

            Call cmbBUMON_KB_Validating(cmbBUMON_KB, Nothing)
            Call cmbBUSYO_KB_Validating(cmbBUSYO_KB, Nothing)

            If chkYUKO_YMD.Checked = False Then
                Call datYUKO_YMD_Validating(datYUKO_YMD, Nothing)
            End If

            Call mtxBUSYO_NAME_Validating(mtxBUSYO_NAME, Nothing)

            Return IsValidated
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try

    End Function

    Private Sub cmbBUMON_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUMON_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����敪"))
    End Sub

    Private Sub cmbBUSYO_KB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBUSYO_KB.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(cmb, cmb.IsSelected, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�����敪"))
    End Sub

    Private Sub datYUKO_YMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles datYUKO_YMD.Validating
        Dim dtx As DateTextBoxEx = DirectCast(sender, DateTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(dtx, Not dtx.ValueNonFormat.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�L������"))
    End Sub

    Private Sub mtxBUSYO_NAME_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxBUSYO_NAME.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtx, Not mtx.Text.IsNullOrWhiteSpace, String.Format(My.Resources.infoMsgRequireSelectOrInput, "������"))
    End Sub


#End Region

#Region "���[�J���֐�"

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean
        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    Me.Text = pub_APP_INFO.strTitle & "�i�ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.cmbBUSYO_KB.Enabled = True
                    Me.mtxBUSYO_NAME.Enabled = True
                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ގ��ǉ��j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.cmbBUSYO_KB.Enabled = True
                    'Me.mtxYUKO_YMD.Enabled = True
                    Me.mtxBUSYO_NAME.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrDataRow)

                    Me.Text = pub_APP_INFO.strTitle & "�i�ύX�j"
                    Me.lblTytle.Text = Me.Text
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    Me.mtxTEL.Enabled = True
                    Me.cmbBUSYO_KB.Enabled = True
                    'Me.mtxYUKO_YMD.Enabled = False
                    Me.mtxBUSYO_NAME.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = True
                    Me.lblEDIT_YMDHNS.Visible = True
                    Me.lbllblEDIT_SYAIN_ID.Visible = True
                    Me.lblEDIT_SYAIN_ID.Visible = True

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
    ''' <param name="row"></param>
    ''' <returns></returns>
    Private Function FunSetEntityValues(row As C1.Win.C1FlexGrid.Row) As Boolean
        Dim _model As New MODEL.VWM002_BUSYO
        Try

            '-----�R���g���[���ɒl���Z�b�g
            With row

                '�L������
                If .Item(NameOf(_model.YUKO_YMD)) = "9999/99/99" Or .Item(NameOf(_model.YUKO_YMD)) Is Nothing Then
                    Me.datYUKO_YMD.Text = ""
                    Me.datYUKO_YMD.Enabled = False
                    Me.chkYUKO_YMD.Checked = True
                Else
                    Me.datYUKO_YMD.Text = .Item(NameOf(_model.YUKO_YMD))
                    Me.datYUKO_YMD.Enabled = True
                    Me.chkYUKO_YMD.Checked = False
                End If

                '�����敪
                Me.cmbBUSYO_KB.SelectedValue = .Item(NameOf(_model.BUSYO_KB))

                '������
                Me.mtxBUSYO_NAME.Text = .Item(NameOf(_model.BUSYO_NAME))

                '�e�����敪
                Me.cmbOYA_BUSYO_KB.SelectedValue = .Item(NameOf(_model.OYA_BUSYO_KB))

                '�e����ID
                Me.cmbOYA_BUSYO.SelectedValue = .Item(NameOf(_model.OYA_BUSYO_ID))

                '����敪
                Me.cmbBUMON_KB.SelectedValue = .Item(NameOf(_model.BUMON_KB))

                'TEL
                Me.mtxTEL.Text = .Item(NameOf(_model.TEL))

                '������
                Me.cmbSYOZOKUCYO.SelectedValue = .Item(NameOf(_model.SYOZOKUCYO_ID))

                '�X�V����
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyy/MM/dd HH:mm:ss", Nothing)
                Me.lblEDIT_YMDHNS.Text = dt.ToString("yyyy/MM/dd HH:mm:ss")

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

#Region "�L�������̃`�F�b�N"

    Private Sub chkYUKO_YMD_CheckedChanged(sender As Object, e As EventArgs) Handles chkYUKO_YMD.CheckedChanged

        If Me.chkYUKO_YMD.Checked = True Then
            datYUKO_YMD.Enabled = False
        Else
            datYUKO_YMD.Enabled = True
        End If

    End Sub


#End Region

#End Region



End Class
