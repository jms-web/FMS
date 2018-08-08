Imports JMS_COMMON.ClsPubMethod

Public Class FrmM0001

#Region "Form�C�x���g"
    'FORM_LOAD
    Private Sub FrmMBCM002MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim strBUFF As String
        Dim lngCNT As Long
        'Dim lngCNTWK As Long

        'Dim intRET As Integer

        Dim strRIREKI_NAME As String
        Dim encRIREKI As System.Text.Encoding
        Dim strLINES() As String

        Try
            '-----�ʒu
            If Not Me.Owner Is Nothing Then '�L��
                '-----�ʒu
                Me.Top = Me.Owner.Top + (Me.Owner.Height - Me.Height) / 2
                Me.Left = Me.Owner.Left + (Me.Owner.Width - Me.Width) / 2

            Else '����
                Me.Top = 0
                Me.Left = 0
            End If


            '-----�_�C�A���OWINDOW
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.ControlBox = False


            '-----�^�C�g��
            Using DB As ClsDbUtility = DBOpen()
                lblTytle.Text = FunGetCodeMastaValue(DB, "PG_TITLE", Me.GetType.ToString)
            End Using


            '-----����\��
            strRIREKI_NAME = FunGetRootPath() & "\INI\" & CON_TXT_UPDATE_HISTORY
            encRIREKI = System.Text.Encoding.GetEncoding(932) 'Shift JIS
            '�Ǎ�
            strLINES = System.IO.File.ReadAllLines(strRIREKI_NAME, encRIREKI)
            '�\��
            Me.lstRIREKI.Items.AddRange(strLINES)
            '�t�H�[�J�X
            Me.lstRIREKI.SelectedIndex = strLINES.GetLength(0) - 1
            For lngCNT = strLINES.GetLength(0) - 1 To 0 Step -1
                If strLINES(lngCNT).Contains("��") = True Then
                    Me.lstRIREKI.SelectedIndex = lngCNT
                    Exit For
                End If
            Next lngCNT

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

    'FORM_Activated
    Private Sub FrmMBCM002MENU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim i As Integer

        Try
            '-----�ʒu
            If Not Me.Owner Is Nothing Then '�L��
                Me.Opacity = 1

            Else '����
                If Me.Opacity = 1 Then
                    Exit Sub
                End If

                '���X�Ɍ����
                For i = 0 To 10
                    '�t�H�[���̕s�����x��ύX����
                    Me.Opacity = 0.1 * i
                    '�ꎞ��~
                    System.Threading.Thread.Sleep(50)
                Next
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

#Region "FUNCTION�{�^���֘A"

#Region "�{�^���N���b�N�C�x���g"
    Private Sub CmdFunc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFunc1.Click, cmdFunc2.Click, cmdFunc3.Click, cmdFunc4.Click, cmdFunc5.Click, cmdFunc6.Click, cmdFunc7.Click, cmdFunc8.Click, cmdFunc9.Click, cmdFunc10.Click, cmdFunc11.Click, cmdFunc12.Click
        Dim intFUNC As Integer
        Dim intCNT As Integer

        Try
            '�{�^���s��/�{�^��INDEX�擾
            For intCNT = 0 To Me.cmdFunc.Length - 1
                Me.cmdFunc(intCNT).Enabled = False
                If cmdFunc(intCNT) Is sender Then intFUNC = intCNT + 1
            Next

            '�{�^��INDEX���̏���
            Select Case intFUNC
                Case 1 '�m�F
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

#End Region


End Class
