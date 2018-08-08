Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0051

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

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
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
            Me.Height = 360
            Me.MinimumSize = New Size(1280, 360)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) - 30 ' / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2


            '-----�e�R���g���[���̃f�[�^�\�[�X��ݒ�
            Me.cmbKOMO_NM.SetDataSource(tblKOMO_NM.ExcludeDeleted, False)

            '�C�x���g�n���h���ݒ�
            AddHandler cmbKOMO_NM.TextChanged, AddressOf CmbKOMO_NM_TextChanged

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
                        Case Else
                            Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                    End Select

                    If blnRET = True Then
                        '�v���p�e�B�ɑΏۃ��R�[�h�̃L�[��ݒ�
                        Me.PrPKeys = (Me.cmbKOMO_NM.Text.Trim, Me.mtxVALUE.Text.Trim)

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
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then '���ݎ�
                        MessageBox.Show("���ɓo�^�ς݂̃f�[�^�ł��B" & vbCrLf & "���̓f�[�^���m�F���ĉ������B", "���݃`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    '���ꍀ�ږ��̊���l������
                    If Me.chkDefaultVaue.Checked = True Then
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                        sbSQL.Append(" DEF_FLG='0'")
                        sbSQL.Append("WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                        sbSQL.Append(" AND ITEM_VALUE <>'" & Me.mtxVALUE.Text.Trim & "' ")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx.InnerException IsNot Nothing Then
                            '�G���[���O�o��
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----INSERT
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("INSERT INTO " & NameOf(MODEL.M001_SETTING) & " (")
                    sbSQL.Append("  ITEM_GROUP")
                    sbSQL.Append(" ,ITEM_NAME")
                    sbSQL.Append(" ,ITEM_VALUE")
                    sbSQL.Append(" ,ITEM_DISP")
                    sbSQL.Append(" ,DISP_ORDER")
                    sbSQL.Append(" ,DEF_FLG")
                    sbSQL.Append(" ,BIKOU")
                    sbSQL.Append(" ,ADD_YMDHNS")
                    sbSQL.Append(" ,ADD_SYAIN_ID")
                    sbSQL.Append(" ,UPD_YMDHNS")
                    sbSQL.Append(" ,UPD_SYAIN_ID")
                    sbSQL.Append(" ,DEL_YMDHNS")
                    sbSQL.Append(" ,DEL_SYAIN_ID")
                    sbSQL.Append(" ) VALUES ( ")
                    '���ڃO���[�v
                    sbSQL.Append(" '" & Me.mtxKOMO_GROUP.Text.Trim & "'")
                    '���ږ�
                    sbSQL.Append(" ,'" & Me.cmbKOMO_NM.Text.Trim & "'")
                    '���ڒl
                    sbSQL.Append(" ,'" & Me.mtxVALUE.Text.Trim & "'")
                    '�\���l
                    sbSQL.Append(" ,'" & Nz(Me.mtxDISP.Text.Trim, " ") & "'")
                    '�\����
                    sbSQL.Append(" ," & Me.cmbJYUN.SelectedValue & "")
                    '����l�t���O
                    sbSQL.Append(" ,'" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    '���l
                    sbSQL.Append(" ,'" & Nz(Me.mtxBIKOU.Text.Trim, " ") & "'")
                    '�ǉ�����
                    sbSQL.Append(" ,dbo.GetSysDateString()")
                    '�ǉ�����
                    sbSQL.Append(" ," & pub_SYAIN_INFO.SYAIN_ID & "")
                    '�ǉ��S����
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
                    sbSQL.Append("SELECT * FROM " & NameOf(MODEL.M001_SETTING) & " ")
                    sbSQL.Append("WHERE")
                    sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
                    sbSQL.Append(" AND UPD_YMDHNS ='" & PrDataRow.Item("UPD_YMDHNS").ToString & "' ")
                    dsList = DB.GetDataSet(sbSQL.ToString)
                    If dsList.Tables(0).Rows.Count = 0 Then '�񑶍ݎ�
                        MessageBox.Show(String.Format(My.Resources.infoSearchDataChange), My.Resources.infoTilteDuplicateCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If

                    '-----���ꍀ�ږ��̊���l������
                    If Me.chkDefaultVaue.Checked = True Then
                        sbSQL.Remove(0, sbSQL.Length)
                        sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                        sbSQL.Append(" DEF_FLG='0' ")
                        sbSQL.Append(" WHERE ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                        sbSQL.Append(" AND ITEM_VALUE <>'" & Me.mtxVALUE.Text.Trim & "' ")

                        intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                        If sqlEx IsNot Nothing Then
                            '�G���[���O
                            Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                            WL.WriteLogDat(strErrMsg)
                            blnErr = True
                            Return False
                        End If
                    End If

                    'TODO: �\�����ŏI�s�̕\�������ύX�o���Ȃ��s��̏C��

                    '-----UPDATE(�\����)
                    If PrDataRow.Item("DISP_ORDER") <> Me.cmbJYUN.SelectedValue Then
                        If FunUpdateDispOrder(DB, PrDataRow.Item("DISP_ORDER"), Me.cmbJYUN.SelectedValue) = False Then
                            blnErr = True
                            Return False
                        End If
                    End If

                    '-----UPDATE(�\�����ȊO)
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append("UPDATE " & NameOf(MODEL.M001_SETTING) & " SET")
                    sbSQL.Append(" ITEM_DISP ='" & Me.mtxDISP.Text.Trim & "'")
                    sbSQL.Append(" ,DEF_FLG ='" & IIf(Me.chkDefaultVaue.Checked = True, "1", "0") & "'")
                    sbSQL.Append(" ,BIKOU ='" & Me.mtxBIKOU.Text.Trim & "'")
                    sbSQL.Append(" ,UPD_SYAIN_ID = " & pub_SYAIN_INFO.SYAIN_ID)
                    sbSQL.Append(" ,UPD_YMDHNS = dbo.GetSysDateString()")
                    sbSQL.Append("WHERE")
                    sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                    sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")

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

    '���ږ��R���{�{�b�N�X�ύX���C�x���g
    Private Sub CmbKOMO_NM_TextChanged(sender As Object, e As EventArgs)
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intMaxOrder As Integer

        Try

            If cmbKOMO_NM.Text.IsNullOrWhiteSpace = False Then

                Me.cmbJYUN.DataSource = Nothing

                Using DB As ClsDbUtility = DBOpen()
                    sbSQL.Append("SELECT ITEM_VALUE")
                    sbSQL.Append(" FROM " & NameOf(MODEL.M001_SETTING) & "")
                    sbSQL.Append(" WHERE ITEM_NAME ='" & cmbKOMO_NM.Text & "'")
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                intMaxOrder = dsList.Tables(0).Rows.Count

                Dim intModeDiff As Integer
                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        intModeDiff = 1
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        intModeDiff = 0
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select

                Dim dt As New DataTableEx
                For i As Integer = 1 To intMaxOrder + intModeDiff
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = i
                    Trow("VALUE") = i
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next i

                Call cmbJYUN.SetDataSource(dt, False)

                Select Case PrMODE
                    Case ENM_DATA_OPERATION_MODE._1_ADD, ENM_DATA_OPERATION_MODE._2_ADDREF
                        cmbJYUN.SelectedValue = intMaxOrder + intModeDiff
                    Case ENM_DATA_OPERATION_MODE._3_UPDATE
                        cmbJYUN.SelectedValue = PrDataRow.Item("DISP_ORDER")
                    Case Else
                        Throw New ArgumentException(My.Resources.ErrMsgException, PrMODE.ToString)
                End Select
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
            'TODO: ���̓`�F�b�N�ʒm��Dialog����ErrorProvider�ɕύX

            '���ږ�
            If cmbKOMO_NM.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "���ږ�"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbKOMO_NM.Focus()
                Return False
            End If

            '���ڒl
            If Me.mtxVALUE.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "���ڒl"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxVALUE.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function
#End Region

#Region "���[�J���֐�"

#Region "�������[�h�ʉ�ʏ�����"
    Private Function FunInitializeControls(ByVal intMODE As Integer) As Boolean
        Try

            Select Case intMODE
                Case ENM_DATA_OPERATION_MODE._1_ADD
                    lblTytle.Text &= "�i�ǉ��j"
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.cmbKOMO_NM.Enabled = True
                    Me.mtxVALUE.Enabled = True
                    Me.mtxDISP.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._2_ADDREF
                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "�i�ގ��ǉ��j"
                    Me.cmdFunc1.Text = "�ǉ�(F1)"

                    Me.cmbKOMO_NM.Enabled = True
                    Me.mtxVALUE.Enabled = True
                    Me.mtxDISP.Enabled = True

                    Me.lbllblEDIT_YMDHNS.Visible = False
                    Me.lblEDIT_YMDHNS.Visible = False
                    Me.lbllblEDIT_SYAIN_ID.Visible = False
                    Me.lblEDIT_SYAIN_ID.Visible = False

                Case ENM_DATA_OPERATION_MODE._3_UPDATE
                    Call FunSetEntityValues(PrDataRow)

                    lblTytle.Text &= "�i�ύX�j"
                    Me.cmdFunc1.Text = "�ύX(F1)"

                    Me.mtxKOMO_GROUP.Enabled = False
                    Me.cmbKOMO_NM.Enabled = False
                    Me.mtxVALUE.Enabled = False
                    Me.mtxDISP.Enabled = True

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
        Dim _model As New MODEL.VWM001_SETTING
        Try

            '-----�R���g���[���ɒl���Z�b�g
            With row
                '���ڃO���[�v
                Me.mtxKOMO_GROUP.Text = .Item(NameOf(_model.ITEM_GROUP))
                '���ږ�
                Call FunSetComboboxValue(Me.cmbKOMO_NM, tblKOMO_NM, .Item(NameOf(_model.ITEM_NAME)))
                '���ڒl
                Me.mtxVALUE.Text = .Item(NameOf(_model.ITEM_VALUE)).ToString.Trim
                '�\���l
                Me.mtxDISP.Text = .Item(NameOf(_model.ITEM_DISP)).ToString.Trim
                '�\����
                Me.cmbJYUN.SelectedValue = .Item(NameOf(_model.DISP_ORDER))
                '����l�t���O
                Me.chkDefaultVaue.Checked = .Item(NameOf(_model.DEF_FLG))

                '���l
                Me.mtxBIKOU.Text = .Item(NameOf(_model.BIKOU)).ToString.Trim

                '�X�V����
                Dim dt As DateTime
                dt = DateTime.ParseExact(.Item(NameOf(_model.UPD_YMDHNS)).ToString, "yyyyMMddHHmmss", Nothing)
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

#Region "�\�����X�V"
    Private Function FunUpdateDispOrder(ByRef DB As ClsDbUtility, ByVal intBeforeValue As Integer, ByVal intAfterValue As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim intRET As Integer
        Dim dsList As New System.Data.DataSet
        Dim sqlEx As New Exception
        Try

            '-----���ꍀ�ږ����ɓ����\���������݂���ꍇ�AintTergetJyun�ȍ~�̕\������S�čX�V����
            If intBeforeValue < intAfterValue Then
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
                sbSQL.Append(" DISP_ORDER = DISP_ORDER-1 ")
                sbSQL.Append("WHERE")
                sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                sbSQL.Append(" AND DISP_ORDER >" & intBeforeValue & " ")
                sbSQL.Append(" AND DISP_ORDER <=" & intAfterValue & " ")
            Else
                '���̕\������菬���������ꍇ�A���̍��ڂ�1���ɂ��炷
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
                sbSQL.Append(" DISP_ORDER = DISP_ORDER+1 ")
                sbSQL.Append("WHERE")
                sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
                sbSQL.Append(" AND DISP_ORDER >=" & intAfterValue & " ")
                sbSQL.Append(" AND DISP_ORDER <" & intBeforeValue & " ")
            End If

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET = 0 Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            '-----UPDATE
            sbSQL.Remove(0, sbSQL.Length)
            sbSQL.Append("UPDATE " & nameof(model.M001_SETTING) & " SET")
            sbSQL.Append(" DISP_ORDER ='" & intAfterValue & "' ")
            sbSQL.Append("WHERE")
            sbSQL.Append(" ITEM_NAME ='" & Me.cmbKOMO_NM.Text.Trim & "' ")
            sbSQL.Append(" AND ITEM_VALUE ='" & Me.mtxVALUE.Text.Trim & "' ")
            sbSQL.Append(" AND DISP_ORDER =" & intBeforeValue & " ")

            intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
            If intRET <> 1 Then
                '�G���[���O
                Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                WL.WriteLogDat(strErrMsg)
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region


#End Region


End Class
