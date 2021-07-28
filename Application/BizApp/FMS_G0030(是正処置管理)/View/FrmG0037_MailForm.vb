Imports JMS_COMMON.ClsPubMethod

''' <summary>
''' �C�����
''' </summary>
Public Class FrmG0037_MailForm

#Region "�v���p�e�B"

    Public Property PrSYONIN_HOKOKUSYO_ID As Integer

    Public Property PrHOKOKU_NO As String

    'Public Property PrCurrentStage As Integer

    'Public Property PrBUMON_KB As String

    'Public Property PrBUHIN_BANGO As String

    'Public Property PrKISYU_NAME As String

    'Public Property PrKISO_YMD As String

    Public Property PrSYORI_NAME As String

    Public Property PrToUsers As List(Of Integer)

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks>�R���X�g���N�^</remarks>
    Public Sub New()

        ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
        InitializeComponent()
        Me.Icon = My.Resources._icoAppForm32x32
        Me.ShowIcon = True

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
            lblTytle.Text = PrSYORI_NAME
            Me.Text = lblTytle.Text

            '-----�ʒu�E�T�C�Y
            Me.Height = 600
            Me.Width = 1000
            Me.MinimumSize = New Size(1000, 600)
            Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
            Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            '-----�_�C�A���O�E�B���h�E�ݒ�
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False

            Dim strBody As String = ""
            Dim strSubject As String = ""
            Select Case PrSYORI_NAME
                Case "���c�m�F�˗����[�����M"
                    strSubject = $"FCCB��c���W�̌� FCCB-NO:{PrHOKOKU_NO}"
                    strBody = "�e��
FCCB�L�^���ɋL�ڂ��ꂽ���e���m�F����ƁA���c���K�v��
���f���܂��̂ŁA���L�����ŁAFCCB��c�����{���܂��̂�
���Q�W�����肢�v���܂��B

�����F�@�@�@�N�@�@���@�@���@�@�@�F�@�@�`�@�@�F
�ꏊ�F��@�@��c��

FCCB�@�c��"

            End Select

            mtxTo.Text = GetUserNames(PrToUsers).Aggregate(Function(a, b) a & ", " & b)
            mtxTitle.Text = strSubject
            mtxBody.Text = strBody
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            Call FunInitFuncButtonEnabled()
        End Try
    End Sub

    ''' <summary>
    ''' ���[�U�[ID���X�g���疼�O���X�g���擾
    ''' </summary>
    ''' <param name="prToUsers"></param>
    ''' <returns></returns>
    Private Function GetUserNames(prToUsers As List(Of Integer)) As List(Of String)
        Dim strList As New List(Of String)
        Try
            If prToUsers IsNot Nothing AndAlso prToUsers.Count > 0 Then
                For Each userID As Integer In prToUsers
                    strList.Add(tblTANTO.AsEnumerable.
                                         Where(Function(r) r.Item("VALUE") = userID.ToString).
                                         Select(Function(r) r.Item("DISP")).
                                         FirstOrDefault)
                Next
            End If

            Return strList
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "FUNCTION�{�^���֘A"

#Region "FUNCTION�{�^��CLICK�C�x���g"

    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc9.Click, cmdFunc8.Click, cmdFunc7.Click, cmdFunc6.Click, cmdFunc5.Click, cmdFunc4.Click, cmdFunc3.Click, cmdFunc2.Click, cmdFunc12.Click, cmdFunc11.Click, cmdFunc10.Click, cmdFunc1.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer
        'Dim blnRET As Boolean

        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1  '�ǉ�
                    If FunCheckInput() Then
                        If FunSendJudgeRequestMail() Then
                            Dim imgDlg As New ImageDialog
                            imgDlg.Show("\\sv04\FMS\RESOURCE\sendmail_256.gif", 4200)
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        End If
                    End If

                Case 12 '�߂�
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
        Catch exDispose As ObjectDisposedException
            System.Console.WriteLine(exDispose.Message)
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

#Region "�R���g���[���C�x���g"

    Private Sub mtxBody_Validating(sender As Object, e As EventArgs) Handles mtxBody.Validating
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtxBody, Not mtxBody.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "�{��"))
    End Sub

    Private Sub mtxTitle_Validating(sender As Object, e As EventArgs) Handles mtxTitle.Validating
        IsValidated *= ErrorProvider.UpdateErrorInfo(mtxTitle, Not mtxTitle.Text.IsNulOrWS, String.Format(My.Resources.infoMsgRequireSelectOrInput, "����"))
    End Sub

#End Region

#Region "���̓`�F�b�N"

    Public Function FunCheckInput() As Boolean
        Try
            IsValidated = True
            IsCheckRequired = True

            Call mtxBody_Validating(mtxBody, Nothing)
            Call mtxTitle_Validating(mtxTitle, Nothing)

            Return IsValidated
        Catch ex As Exception
            Throw
        Finally
            IsCheckRequired = False
        End Try
    End Function

#End Region

#Region "���[�J���֐�"

    ''' <summary>
    ''' ���c�m�F�˗����[�����M
    ''' </summary>
    ''' <returns></returns>
    Private Function FunSendJudgeRequestMail(Optional toUserNAME As String = "", Optional fromUserNAME As String = "") As Boolean

        Try

            Dim strBody As String = mtxBody.Text.Replace(Environment.NewLine, "<br />") & <sql><![CDATA[
                <br />
                <a href = "http://sv04:8000/CLICKONCE_FMS.application" > �V�X�e���N��</a><br />
                <br />
                �����̃��[���͔z�M��p�ł��B(�ԐM�ł��܂���)<br />
                �ԐM����ꍇ�́A�e�S���҂̃��[���A�h���X���g�p���ĉ������B<br />
                ]]></sql>.Value.Trim

            If PrToUsers.Count = 0 Then
                MessageBox.Show("���M�҂�������Ȃ����߁A�˗����[���𑗐M�ł��܂���", "�˗����[�����M", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                If FunSendMailZESEI(mtxTitle.Text, strBody, PrToUsers, False) Then
                    Return True
                Else
                    MessageBox.Show("���[�����M�Ɏ��s���܂����B", "���[�����M���s", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

End Class