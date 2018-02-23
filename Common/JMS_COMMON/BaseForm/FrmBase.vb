Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class FrmBase

#Region "定数・変数"
    Public _currentToolTipControl As Control = Nothing

    Public Enum ENM_TASKBAR_STATE
        _0_NoProgress = 0
        _1_Indeterminate = 1
        _2_Normal = 2
        _4_Error = 4
        _8_Paused = 8
    End Enum

#End Region

#Region "イベント"
    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-----初期表示位置
        'Me.Top = 0
        'Me.Left = 0
        Me.StartPosition = FormStartPosition.CenterScreen

        ErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink
        'ErrorProvider.BlinkRate = 250

    End Sub

    Private Async Sub Frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        'Enable=FalseのコントロールでもToolTipを表示可にする
        Dim control As Control = GetChildAtPoint(e.Location)

        If control IsNot Nothing Then
            If control.Enabled = False Then
                ToolTip.Active = True

                If _currentToolTipControl Is Nothing Then
                    Dim toolTipString As String = ToolTip.GetToolTip(control)
                    '表示位置(相対位置指定) 右上あたり

                    Await FunDelayDispToolTip(toolTipString, control, control.Width - 25, -15)

                    _currentToolTipControl = control
                End If

            Else
                'Enable=True時は特に何も表示しない
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

#Region "ToolTip関連"

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

#Region "メソッド"
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
        ' ボタンをディスエーブルに
        'Me.button1.Enabled = False

        ' プログレスインジケーターを緑色にする
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused)

        ' 進捗を表示するためのデリゲートを定義する（カウントダウン中に呼び出される）
        Dim callUpdateProgress As Action(Of Object) _
          = Sub(o)
                Dim number As Integer = CInt(o)
                ' ラベルの表示を更新する
                'Me.label1.Text = number.ToString()
                ' プログレスインジケーターに値をセットする
                TaskbarManager.Instance.SetProgressValue(10 - number, 10)
            End Sub

        ' 別スレッドで実行するタスクを定義し、非同期実行を開始する
        Threading.Tasks.Task.Factory.StartNew(
          Sub()
              ' 別スレッドで行う処理の本体
              For i As Integer = 10 To 0 Step -1
                  ' UIスレッドで進捗表示を呼び出す
                  Me.BeginInvoke(callUpdateProgress, i)
                  ' 1秒間待機
                  System.Threading.Thread.Sleep(1000)
              Next
          End Sub) _
          .ContinueWith(
            Sub(t)
                ' 非同期実行が完了した後の処理
                ' プログレスインジケーターを通常表示に戻す
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress)
                ' ボタンをイネーブルに戻す
                'Me.button1.Enabled = True
            End Sub,
            Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext()
          )
        ' TaskScheduler.～ は、完了時の処理をUIスレッドで実行するための指定
    End Sub
#End Region



End Class