Public Class ImageDialog
    Inherits System.Windows.Forms.Form

    Friend WithEvents picBox As PictureBox
    Friend WithEvents Timer As Timer
    Private img As Image
#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        If img IsNot Nothing Then img.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBox
        '
        Me.picBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picBox.Location = New System.Drawing.Point(0, 0)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(250, 186)
        Me.picBox.TabIndex = 10
        Me.picBox.TabStop = False
        '
        'Timer
        '
        Me.Timer.Interval = 2500
        '
        'ImageDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(250, 186)
        Me.ControlBox = False
        Me.Controls.Add(Me.picBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImageDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' ShowDialogメソッドのシャドウ（WaitDialogクラスでは、ShowDialogメソッドは使用不可）
    Public Shadows Function ShowDialog() As DialogResult
        Diagnostics.Debug.Assert(False,
     "WaitDialogクラスはShowDialogメソッドを利用できません。" + vbCrLf +
     "Showメソッドを使ってモードレス・ダイアログを構築してください。")
        Return DialogResult.Abort
    End Function

    ''' <summary>
    ''' picturebox dialogを表示
    ''' </summary>
    ''' <param name="filepath">表示するイメージファイルパス</param>
    ''' <param name="interval">表示時間(ﾐﾘ秒) 0の場合無期限表示のためCloseメソッドで任意のタイミングで閉じる必要あり</param>
    Public Shadows Sub Show(filepath As String, Optional interval As Integer = 2500)
        Try

            Me.DialogResult = DialogResult.OK

            img = Image.FromFile(filepath)
            'picBox.WaitOnLoad = False
            picBox.Image = img

            If interval > 0 Then
                Timer.Interval = interval
                Timer.Start()
            Else
            End If

            MyBase.Show()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ' Closeメソッドのシャドウ
    Public Shadows Sub Close()
        MyBase.Close()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Close()
    End Sub
End Class

