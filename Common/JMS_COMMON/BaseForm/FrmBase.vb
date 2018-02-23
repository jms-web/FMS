Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class FrmBase

#Region "�萔�E�ϐ�"
    Public _currentToolTipControl As Control = Nothing

    Public Enum ENM_TASKBAR_STATE
        _0_NoProgress = 0
        _1_Indeterminate = 1
        _2_Normal = 2
        _4_Error = 4
        _8_Paused = 8
    End Enum

#End Region

#Region "�C�x���g"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-----�����\���ʒu
        'Me.Top = 0
        'Me.Left = 0
        Me.StartPosition = FormStartPosition.CenterScreen

        ErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink
        'ErrorProvider.BlinkRate = 250

    End Sub

    Private Async Sub Frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        'Enable=False�̃R���g���[���ł�ToolTip��\���ɂ���
        Dim control As Control = GetChildAtPoint(e.Location)

        If control IsNot Nothing Then
            If control.Enabled = False Then
                ToolTip.Active = True

                If _currentToolTipControl Is Nothing Then
                    Dim toolTipString As String = ToolTip.GetToolTip(control)
                    '�\���ʒu(���Έʒu�w��) �E�゠����

                    Await FunDelayDispToolTip(toolTipString, control, control.Width - 25, -15)

                    _currentToolTipControl = control
                End If

            Else
                'Enable=True���͓��ɉ����\�����Ȃ�
                ToolTip.Active = False
            End If
        Else
            If _currentToolTipControl IsNot Nothing Then
                ToolTip.Hide(_currentToolTipControl)
            End If
            _currentToolTipControl = Nothing
            ToolTip.Active = False
        End If

    End Sub

#End Region

#Region "ToolTip�֘A"

    Delegate Sub Subdel(ByVal strMessage As String, ByVal ctrl As Control, intX As Integer, intY As Integer)
    Private del As New Subdel(AddressOf ShowToolTip)

    Private Sub ShowToolTip(ByVal strMessage As String, ByVal ctrl As Control, intX As Integer, intY As Integer)
        ToolTip.Show(strMessage, ctrl, intX, intY)
    End Sub

    Private Async Function FunDelayDispToolTip(ByVal strMessage As String, ByVal ctrl As Control, intX As Integer, intY As Integer) As Threading.Tasks.Task(Of String)
        Try

            Dim strRET As String = ""
            Await Threading.Tasks.Task.Run(Sub()
                                               Try
                                                   Threading.Thread.Sleep(ToolTip.InitialDelay)
                                                   Invoke(del, New Object() {strMessage, ctrl, intX, intY})
                                               Catch ex As InvalidOperationException
                                               End Try
                                           End Sub)
            Return strRET

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        End Try
    End Function

#End Region

#Region "���\�b�h"
    Public Sub SetTaskbarInfo(ByVal state As ENM_TASKBAR_STATE, Optional ByVal currentValue As Integer = 0)

        TaskbarManager.Instance.SetProgressState(state)
        If currentValue > 0 Then
            TaskbarManager.Instance.SetProgressValue(currentValue, 100)
        End If
    End Sub

    Public Sub SetTaskbarOverlayIcon(ByVal _icon As Icon)
        TaskbarManager.Instance.SetOverlayIcon(_icon, "")
    End Sub

    Private Sub taskberinfosumple()
        ' �{�^�����f�B�X�G�[�u����
        'Me.button1.Enabled = False

        ' �v���O���X�C���W�P�[�^�[��ΐF�ɂ���
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused)

        ' �i����\�����邽�߂̃f���Q�[�g���`����i�J�E���g�_�E�����ɌĂяo�����j
        Dim callUpdateProgress As Action(Of Object) _
          = Sub(o)
                Dim number As Integer = CInt(o)
                ' ���x���̕\�����X�V����
                'Me.label1.Text = number.ToString()
                ' �v���O���X�C���W�P�[�^�[�ɒl���Z�b�g����
                TaskbarManager.Instance.SetProgressValue(10 - number, 10)
            End Sub

        ' �ʃX���b�h�Ŏ��s����^�X�N���`���A�񓯊����s���J�n����
        Threading.Tasks.Task.Factory.StartNew(
          Sub()
              ' �ʃX���b�h�ōs�������̖{��
              For i As Integer = 10 To 0 Step -1
                  ' UI�X���b�h�Ői���\�����Ăяo��
                  Me.BeginInvoke(callUpdateProgress, i)
                  ' 1�b�ԑҋ@
                  System.Threading.Thread.Sleep(1000)
              Next
          End Sub) _
          .ContinueWith(
            Sub(t)
                ' �񓯊����s������������̏���
                ' �v���O���X�C���W�P�[�^�[��ʏ�\���ɖ߂�
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress)
                ' �{�^�����C�l�[�u���ɖ߂�
                'Me.button1.Enabled = True
            End Sub,
            Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext()
          )
        ' TaskScheduler.�` �́A�������̏�����UI�X���b�h�Ŏ��s���邽�߂̎w��
    End Sub
#End Region



End Class