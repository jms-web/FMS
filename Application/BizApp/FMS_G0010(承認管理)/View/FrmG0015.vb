Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �]�����
''' </summary>
Public Class FrmG0015

#Region "�ϐ��E�萔"

#End Region

#Region "�v���p�e�B"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrCurrentStage As Integer
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
            Me.Text = "�]���o�^"
            Me.lblTytle.Text = Me.Text

            '-----�ʒu�E�T�C�Y
            Me.Height = 300
            Me.Width = 800
            Me.MinimumSize = New Size(800, 300)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            '-----�e�R���g���[���̃f�[�^�\�[�X��ݒ�
            Dim tbl As DataTable = tblTANTO_SYONIN.AsEnumerable.
                                    Where(Function(r) r.Field(Of Integer)("SYONIN_HOKOKUSYO_ID") = 1 _
                                    And r.Field(Of Integer)("SYONIN_JUN") = PrCurrentStage _
                                    And r.Field(Of String)("VALUE") <> pub_SYAIN_INFO.SYAIN_ID).
                                    CopyToDataTable
            Me.cmbTENSO_SAKI.SetDataSource(tbl, False)

            '�o�C���f�B���O
            Call FunSetBinding()

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
                    blnRET = FunSAVE()

                    If blnRET Then
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

#Region "�X�V"
    Private Function FunSAVE() As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            '-----���̓`�F�b�N
            If FunCheckInput() = False Then
                Return False
            End If

            'SPEC: 2.(3).D.�@.���R�[�h�X�V
            Using DB As ClsDbUtility = DBOpen()
                Dim intRET As Integer
                Dim sqlEx As New Exception
                Dim blnErr As Boolean

                Try
                    '-----�g�����U�N�V����
                    DB.BeginTransaction()

                    '-----UPDATE
                    sbSQL.Append("UPDATE " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " SET")
                    sbSQL.Append(" " & NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID) & "=" & _D004_SYONIN_J_KANRI.SYAIN_ID & "")
                    sbSQL.Append(" ," & NameOf(_D004_SYONIN_J_KANRI.RIYU) & "='" & _D004_SYONIN_J_KANRI.RIYU & "'")
                    sbSQL.Append(" WHERE " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_HOKOKUSYO_ID) & "=" & PrSYONIN_HOKOKUSYO_ID & "")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.HOKOKU_NO) & "='" & _D003_NCR_J.HOKOKU_NO & "'")
                    sbSQL.Append(" AND " & NameOf(_D004_SYONIN_J_KANRI.SYONIN_JUN) & "=" & PrCurrentStage & "")

                    '-----SQL���s
                    intRET = DB.ExecuteNonQuery(sbSQL.ToString, conblnNonMsg, sqlEx)
                    If intRET <> 1 Then
                        '-----�G���[���O�o��
                        Dim strErrMsg As String = My.Resources.ErrLogSqlExecutionFailure & sbSQL.ToString & "|" & sqlEx.Message
                        WL.WriteLogDat(strErrMsg)
                        blnErr = True
                        Return False
                    End If

                Finally
                    '-----�g�����U�N�V����
                    DB.Commit(Not blnErr)
                End Try
            End Using


            Return True
        Catch ex As Exception
            Throw
            Return False
        Finally

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

    Private Sub CmbMODOSI_SAKI_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTENSO_SAKI.Validating
        Dim cmb As ComboboxEx = DirectCast(sender, ComboboxEx)

        If cmb.SelectedValue Is Nothing And cmb.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(cmb, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�]����"))
            ErrorProvider.SetIconAlignment(cmb, ErrorIconAlignment.MiddleLeft)
        Else
            ErrorProvider.ClearError(cmb)
        End If
    End Sub

    Private Sub MtxMODOSI_RIYU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtxTENSO_RIYU.Validating
        Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)

        If mtx.Text.IsNullOrWhiteSpace = True Then
            'e.Cancel = True
            ErrorProvider.SetError(mtx, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�]�����R"))
            ErrorProvider.SetIconAlignment(mtx, ErrorIconAlignment.MiddleLeft)
        Else
            ErrorProvider.ClearError(mtx)
        End If
    End Sub
#End Region

#Region "���̓`�F�b�N"
    Public Function FunCheckInput() As Boolean
        Try

            '���߂���
            If cmbTENSO_SAKI.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireSelectOrInput, "�]����"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbTENSO_SAKI.Focus()
                Return False
            End If

            '���R
            If Me.mtxTENSO_RIYU.Text.IsNullOrWhiteSpace Then
                MessageBox.Show(String.Format(My.Resources.infoMsgRequireInput, "�]�����R"), My.Resources.infoTitleInputCheck, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mtxTENSO_RIYU.Focus()
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
    Private Function FunSetBinding() As Boolean
        cmbTENSO_SAKI.DataBindings.Add(New Binding(NameOf(cmbTENSO_SAKI.SelectedValue), _D003_NCR_J, NameOf(_D004_SYONIN_J_KANRI.SYAIN_ID)))
        mtxTENSO_RIYU.DataBindings.Add(New Binding(NameOf(mtxTENSO_RIYU.Text), _D003_NCR_J, NameOf(_D004_SYONIN_J_KANRI.RIYU)))
    End Function
#End Region


End Class
