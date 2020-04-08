Public Class ImageDialog
    Inherits System.Windows.Forms.Form

    Friend WithEvents picBox As PictureBox
    Friend WithEvents Timer As Timer
    Private img As Image
#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        If img IsNot Nothing Then img.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
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

    ' ShowDialog���\�b�h�̃V���h�E�iWaitDialog�N���X�ł́AShowDialog���\�b�h�͎g�p�s�j
    Public Shadows Function ShowDialog() As DialogResult
        Diagnostics.Debug.Assert(False,
     "WaitDialog�N���X��ShowDialog���\�b�h�𗘗p�ł��܂���B" + vbCrLf +
     "Show���\�b�h���g���ă��[�h���X�E�_�C�A���O���\�z���Ă��������B")
        Return DialogResult.Abort
    End Function

    ''' <summary>
    ''' picturebox dialog��\��
    ''' </summary>
    ''' <param name="filepath">�\������C���[�W�t�@�C���p�X</param>
    ''' <param name="interval">�\������(�ؕb) 0�̏ꍇ�������\���̂���Close���\�b�h�ŔC�ӂ̃^�C�~���O�ŕ���K�v����</param>
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

    ' Close���\�b�h�̃V���h�E
    Public Shadows Sub Close()
        MyBase.Close()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Close()
    End Sub
End Class

