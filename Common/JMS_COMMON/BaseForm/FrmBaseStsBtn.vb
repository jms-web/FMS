Imports JMS_COMMON.ClsPubMethod

Public Class FrmBaseStsBtn

#Region "�ϐ��E�萔"
    Public cmdFunc() As System.Windows.Forms.Button '�{�^���z��
#End Region

#Region "�v���p�e�B"

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

    Private Sub frmBaseStsBtn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�A�N�Z���g�J���[�擾 
        'Dim lngColor As Long
        'Dim blnRET As Boolean
        'Call Util.DwmGetColorizationColor(lngColor, blnRET)
        'Dim clrAccent As Color = Util.mdlDWM.GetColorFromInt64(lngColor)
        'Me.BackColor = clrAccent

        '-----�{�^���z��
        '�{�^���z��̍쐬
        Me.cmdFunc = New System.Windows.Forms.Button(11) {}

        '�{�^���z��ɉ�ʂɒu�����{�^������
        Me.cmdFunc(0) = Me.cmdFunc1
        Me.cmdFunc(1) = Me.cmdFunc2
        Me.cmdFunc(2) = Me.cmdFunc3
        Me.cmdFunc(3) = Me.cmdFunc4
        Me.cmdFunc(4) = Me.cmdFunc5
        Me.cmdFunc(5) = Me.cmdFunc6
        Me.cmdFunc(6) = Me.cmdFunc7
        Me.cmdFunc(7) = Me.cmdFunc8
        Me.cmdFunc(8) = Me.cmdFunc9
        Me.cmdFunc(9) = Me.cmdFunc10
        Me.cmdFunc(10) = Me.cmdFunc11
        Me.cmdFunc(11) = Me.cmdFunc12

        AddHandler cmdFunc1.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc2.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc3.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc4.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc5.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc6.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc7.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc8.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc9.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc10.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc11.MouseMove, AddressOf cmdFunc_MouseMove
        AddHandler cmdFunc12.MouseMove, AddressOf cmdFunc_MouseMove

    End Sub

    Private Sub frmBaseStsBtn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = e.KeyCode


        '�������ꂽ�L�[�R�[�h�擾
        KeyCode = e.KeyCode

        'F1�`F12
        If KeyCode >= Windows.Forms.Keys.F1 And KeyCode <= Windows.Forms.Keys.F12 Then
            'F10���Ɉُ퓮�삷��̂ŃS�~����
            e.Handled = True
            '�Y���{�^��CLICK�C�x���g����
            cmdFunc(KeyCode - 112).PerformClick()
        End If

        'ENTER�L�[
        If KeyCode = Windows.Forms.Keys.Return Then
            'System.Windows.Forms.SendKeys.Send("{TAB}")
        End If

    End Sub

    Overridable Sub FrmBaseStsBtn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Visible = False Then Exit Sub

        If Me.DesignMode = True Then Exit Sub

        ''===================================
        ''   �{�^���ʒu�A�T�C�Y�ݒ�
        ''===================================
        Call SetButtonSize(Me.Width, cmdFunc)

    End Sub

    Protected Friend Sub cmdFunc_MouseMove(sender As Object, e As MouseEventArgs)
        Dim control As Control = GetChildAtPoint(e.Location)
        If control IsNot Nothing Then
            MyBase.ToolTip.Active = Not control.Enabled
        End If
    End Sub

#End Region

End Class