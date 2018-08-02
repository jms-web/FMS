'----------------------------------------
'�ύX����
'2007/09/03 MASKEDTEXTBOX�̌p���R���g���[���Ƃ��č쐬�A�t�H�[�J�X���ɑS�I��
'2007/09/15 MaxByteLength�v���p�e�B
'2007/10/01 PermitNumChars�v���p�e�B
'2007/11/01 SelectAllText�v���p�e�B
'----------------------------------------

Imports System.ComponentModel

<DefaultEvent("TextChanged")>
<DefaultProperty("DefaultProperty")>
Public Class MaskedTextBoxEx
    Inherits MaskedTextBox

    Private _GotForcusedColor As Color  '�t�H�[�J�X���̔w�i�F
    Private _BackColorDefault As Color '�t�H�[�J�X�r�������̔w�i�F

#Region "�@�R���X�g���N�^�@"
    Public Sub New()
        Call InitializeComponent()

        'Me.MaxByteLength = 65535
        Me.SelectAllText = True
        Me.ImeMode = Windows.Forms.ImeMode.Disable
        _watermarkColor = SystemColors.GrayText

        Me._GotForcusedColor = clrControlGotFocusedColor
        Me._BackColorDefault = clrControlDefaultBackColor
    End Sub
#End Region

#Region "�@�v���p�e�B�@"

#Region "InputRequired �v���p�e�B"
    Private _InputRequired As Boolean
    Public Property InputRequired As Boolean
        Get
            Return _InputRequired
        End Get
        Set(value As Boolean)
            _InputRequired = value
            If value Then
                Me.WatermarkText = "<�K�{>"
                Me.WatermarkColor = Color.Red
            Else
                Me.WatermarkText = _watermarkText
                Me.WatermarkColor = _foreColor
            End If
        End Set
    End Property

#End Region

#Region "�@WatermarkText�v���p�e�B"
    Private _watermarkText As String
    Private _hasWatermark As Boolean
    Private _watermarkColor As Color
    Private _foreColor As Color

    ''' <summary>
    ''' �e�L�X�g����̏ꍇ�ɕ\�����镶������擾�E�ݒ肵�܂��B
    ''' </summary>
    ''' <returns></returns>
    <Category("�\��")>
    <DefaultValue("")>
    <Description("�e�L�X�g����̏ꍇ�ɕ\�����镶����ł��B")>
    <RefreshProperties(RefreshProperties.Repaint)>
    Public Property WatermarkText As String
        Get
            Return _watermarkText
        End Get
        Set(value As String)
            _watermarkText = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property



    ''' <summary>
    ''' �e�L�X�g����̏ꍇ�ɕ\�����镶����̐F���擾�E�ݒ肵�܂��B
    ''' </summary>
    ''' <returns></returns>
    <Category("�\��")>
    <DefaultValue(GetType(Color), "GrayText")>
    <Description("�e�L�X�g����̏ꍇ�ɕ\�����镶����̐F�ł��B")>
    Public Property WatermarkColor As Color
        Get
            Return _watermarkColor
        End Get
        Set(value As Color)
            _watermarkColor = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property


#End Region

#Region "�@OldValue �v���p�e�B"
    Private _oldValue As String

    ''' <summary>
    ''' �ύX�O�̒l���擾���܂�
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property OldValue As String
        Get
            Return _oldValue
        End Get
    End Property
#End Region

#Region "�@MaxByteLength �v���p�e�B (Overridable)�@"
    '-----���͂܂��͓\��t���ł���ő啶���o�C�g�����擾�܂��͐ݒ肵�܂��B
    Private MaxByteLengthValue As Integer

    <Category("����"),
     DefaultValue(65535),
     Description("�G�f�B�b�g �R���g���[���ɓ��͂ł���ő啶���o�C�g�����w�肵�܂��B")>
    Public Property MaxByteLength() As Integer
        Get
            Return Me.MaxByteLengthValue
        End Get

        Set(ByVal value As Integer)
            If Me.MaxByteLengthValue <> value Then
                Me.MaxByteLengthValue = value
            End If
        End Set
    End Property

#End Region

#Region "�@PermitNumChars �v���p�e�B (Overridable)�@"
    '-----�0123456789.-��̂ݓ��͉B(Mask��C���ɓK�p)
    Private PermitNumCharsValue As Boolean
    Private chrPermitNumChars As Char() = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "."c, "-"c}

    <Category("����"),
     DefaultValue(False),
     Description("�0123456789.-��̂ݓ��͉B(Mask��C���ɓK�p)")>
    Public Property PermitNumChars() As Boolean
        Get
            Return Me.PermitNumCharsValue
        End Get

        Set(ByVal value As Boolean)
            If Me.PermitNumCharsValue <> value Then
                Me.PermitNumCharsValue = value
            End If
        End Set
    End Property

#End Region

#Region "�@SelectAllText �v���p�e�B (Overridable)�@"
    '-----Focus���̑S�I����ݒ肵�܂��B
    Private SelectAllTextValue As Boolean

    <Category("����"),
     DefaultValue(True),
     Description("Focus���̑S�I����ݒ肵�܂��B")>
    Public Property SelectAllText() As Boolean
        Get
            Return Me.SelectAllTextValue
        End Get

        Set(ByVal value As Boolean)
            If Me.SelectAllTextValue <> value Then
                Me.SelectAllTextValue = value
            End If
        End Set
    End Property
#End Region

#Region "�@ForeColor �v���p�e�B�@"
    Public Overrides Property ForeColor As Color
        Get
            If DesignMode Then
                Return _foreColor
            Else
                Return MyBase.ForeColor
            End If
        End Get
        Set(value As Color)
            _foreColor = value
            If _hasWatermark = False Then
                MyBase.ForeColor = value
            End If
        End Set
    End Property

    '<RefreshProperties(RefreshProperties.Repaint)>
    'Public Overrides Property Text As String
    '    Get
    '        Return IIf(_watermarkText.IsNullOrWhiteSpace, String.Empty, MyBase.Text)
    '    End Get
    '    Set(value As String)
    '        If value.IsNullOrWhiteSpace Then
    '            '�󕶎��񂪎w�肳�ꂽ
    '            Call TrySetWatermark() '�E�H�[�^�[�}�[�N�\�������݂�
    '        ElseIf _hasWatermark Then
    '            '�K�؂ȕ����񂪐ݒ肳�ꂽ�B�E�H�[�^�[�}�[�N�\���ݒ����
    '            Call ResetWatermark(value)
    '        Else
    '            '�e�L�X�g�㏑��
    '            MyBase.Text = value
    '        End If
    '    End Set
    'End Property

#End Region

#End Region

#Region "�@�C�x���g�@"

    Protected Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim mtx As MaskedTextBoxEx = DirectCast(sender, MaskedTextBoxEx)
            If mtx.CanUndo = True Then
                mtx.Undo()
            End If
        End If
    End Sub


    Private Sub Mtx_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Right Then
            DirectCast(sender, Control).Capture = False
        End If
    End Sub
#End Region

#Region "�@���\�b�h�@"

#Region "�@WndProc ���\�b�h (Overrides)�@"
    '-----���́E�y�[�X�g��WINDOWS���b�Z�[�W���擾
    <System.Diagnostics.DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CHAR As Integer = &H102
        Const WM_PASTE As Integer = &H302
        Const WM_PAINT As Integer = &HF
        'Const WM_CONTEXTMENU As Integer = &H7B

        Select Case m.Msg
            Case WM_CHAR
                Dim eKeyPress As New KeyPressEventArgs(Microsoft.VisualBasic.ChrW(m.WParam.ToInt32()))
                Me.OnChar(eKeyPress)

                If eKeyPress.Handled Then
                    Return
                End If

            Case WM_PASTE
                Me.OnPaste(New System.EventArgs())
                Return

            Case WM_PAINT

                If m.Msg = WM_PAINT And Me.Text.IsNullOrEmpty = True And WatermarkText.IsNullOrEmpty = False And _hasWatermark = False Then
                    Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                        '�e�L�X�g�{�b�N�X���̓K�؂ȍ��W�ɕ`��
                        Dim rect As Rectangle = Me.ClientRectangle
                        rect.Offset(0, 0)
                        TextRenderer.DrawText(g,
                                              _watermarkText,
                                              New Font(Me.Font.Name, Me.Font.Size, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte)),
                                              rect,
                                              _watermarkColor,
                                              TextFormatFlags.Top Or TextFormatFlags.Left)
                    End Using

                    _hasWatermark = True
                Else

                    _hasWatermark = False
                End If

                'New Font("Yu Gothic UI", Me.Font.Size, FontStyle.Italic, GraphicsUnit.Point, CType(128, Byte)),

                'CHECK:�E�N���b�N�����̏ꍇ�́A�R�����g�A�E�g����
                'Case WM_CONTEXTMENU
                '    Return
        End Select

        MyBase.WndProc(m)
    End Sub
#End Region

#Region "�@OnChar ���\�b�h (Overridable)�@"
    ' �����񂪃N���C�A���g�̈�ɑ��M���ꂽ���ɌĂяo����郁�\�b�h
    Protected Overridable Sub OnChar(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        '-----���l�����̂ݓ��͉�
        If Me.PermitNumChars = True Then
            If Not HasPermitChars(e.KeyChar, chrPermitNumChars) Then
                e.Handled = True
            End If
        End If

        '-----���͂��ő啶���o�C�g���ɐ���
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
        Dim inputByteCount As Integer = sjisEncoding.GetByteCount(e.KeyChar.ToString())
        Dim selectedTextByteCount As Integer = sjisEncoding.GetByteCount(Me.SelectedText)

        If textByteCount + inputByteCount - selectedTextByteCount > Me.MaxByteLength Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "�@OnPaste ���\�b�h (Overridable)�@"
    '�\��t���������ɌĂяo����郁�\�b�h
    Protected Overridable Sub OnPaste(ByVal e As System.EventArgs)
        Dim inputText As String = ""
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim selectedTextByteCount As Integer
        Try

            Dim clipboardText As Object = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text)

            If clipboardText Is Nothing Then
                Return
            End If

            '-----���l�����̂ݓ��͉�
            If Me.PermitNumChars = True Then
                Me.SelectedText = GetPermitedString(clipboardText, chrPermitNumChars)
                clipboardText = Me.SelectedText
            End If

            '-----�y�[�X�g���ő啶���o�C�g���ɐ���
            If Me.MaxLength * 2 >= Me.MaxByteLength Then

                inputText = clipboardText.ToString()
                Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
                Dim inputByteCount As Integer = sjisEncoding.GetByteCount(inputText)
                selectedTextByteCount = sjisEncoding.GetByteCount(Me.SelectedText)
                Dim remainByteCount As Integer = Me.MaxByteLength - (textByteCount - selectedTextByteCount)


                If remainByteCount <= 0 Or MaxByteLength - (textByteCount + inputByteCount) <= 0 Then
                    Return
                End If

                If remainByteCount >= inputByteCount Then
                    Me.SelectedText = inputText
                Else
                    textByteCount = sjisEncoding.GetByteCount(inputText)
                    If textByteCount > Me.MaxByteLength Then
                        Me.SelectedText = ClsPubMethod.MidB(inputText, 1, Me.MaxByteLength)
                    Else
                        Me.SelectedText = inputText.Substring(0, remainByteCount)
                    End If

                End If
            End If

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub
#End Region

#Region "�@HasPermitChars ���\�b�h�@"
    '-----�����ꂽ�������ǂ����������l��Ԃ�
    Private Shared Function HasPermitChars(ByVal chTarget As Char, ByVal chPermits As Char()) As Boolean
        For Each ch As Char In chPermits
            If chTarget = ch Then
                Return True
            End If
        Next ch
    End Function
#End Region

#Region "�@GetPermitedString ���\�b�h�@"
    '-----�����ꂽ����������A�����ĕԂ�
    Private Shared Function GetPermitedString(ByVal stTarget As String, ByVal chPermits As Char()) As String
        Dim stReturn As String = String.Empty

        For Each chTarget As Char In stTarget
            If HasPermitChars(chTarget, chPermits) Then
                stReturn &= chTarget
            End If
        Next chTarget

        Return stReturn
    End Function
#End Region

#Region "�@OnEnter ���\�b�h (Overrides)�@"
    '-----�t�H�[�J�X���ɑS�I��
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        _oldValue = Me.Text
        'If _hasWatermark Then
        '    '����
        '    Call ResetWatermark("")
        'End If

        If Me.SelectAllText = True Then
            BeginInvoke(New MethodInvokerForMaskedTextBox(AddressOf MaskedTextBoxSelectAll), Me)
        End If

        MyBase.OnEnter(e)
    End Sub
#End Region

#Region "GotFocusedColor"
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Property [GotFocusedColor]() As System.Drawing.Color
        Get
            Return _GotForcusedColor
        End Get
        Set(ByVal value As Color)
            _GotForcusedColor = value
        End Set
    End Property
#End Region
#Region "BackColor"
    <Bindable(True), Category("Appearance"), DefaultValue("")>
    Overrides Property [BackColor]() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
            _BackColorDefault = value
        End Set
    End Property
#End Region

#Region "OnKeyDown(ByVal e As KeyEventArgs)"
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.Enter     'Enter:Tab
                SendKeys.Send("{Tab}") 'Enter���������ہA���̍��ڂֈړ������Tab�𑗐M����
        End Select
    End Sub
#End Region
#Region "OnGotFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            '�t�H�[�J�X���͔w�i�F�ύX
            MyBase.BackColor = _GotForcusedColor
        End If

        MyBase.OnGotFocus(e) '���N���X�Ăяo��
    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)

        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        Else
            '�t�H�[�J�X���Ȃ��Ƃ��͔w�i�F�����ݒ�
            MyBase.BackColor = _BackColorDefault
        End If
        MyBase.OnLostFocus(e) '���N���X�Ăяo��

    End Sub
#End Region


    Protected Overrides Sub OnReadOnlyChanged(e As EventArgs)
        If Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        End If
        MyBase.OnReadOnlyChanged(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        If Me.Enabled = False Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
        End If

        MyBase.OnEnabledChanged(e)
    End Sub

    <Bindable(True), Category("Appearance"), DefaultValue(False)>
    Public Property ShowRemaining As Boolean

#Region "�@Change ���\�b�h(Overrides)"
    Protected Overrides Sub OnTextChanged(e As EventArgs)

        If ShowRemaining Then
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                '�e�L�X�g�{�b�N�X�O�Ɏc����͉\��������`��
                Dim rect As Rectangle = Me.ClientRectangle
                rect.Offset(50, 0)
                TextRenderer.DrawText(g,
                                         "�c�� " & (Me.MaxLength - Me.Text.ToString.GetByteLength) / 2 & "����",
                                          New Font(Me.Font.Name, Me.Font.Size, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte)),
                                          rect,
                                          Color.Black,
                                          Me.BackColor,
                                          TextFormatFlags.Right)
            End Using
        End If
        MyBase.OnTextChanged(e)
    End Sub

#End Region

#Region "�@OnLeave ���\�b�h (Overrides)�@"
    'Protected Overrides Sub OnLeave(ByVal e As EventArgs)
    '    MyBase.OnLeave(e)
    '    Call TrySetWatermark()
    'End Sub
#End Region

#Region "�@SelectAll ���\�b�h (Delegate)�@"
    Private Delegate Sub MethodInvokerForMaskedTextBox(ByVal pTarget As MaskedTextBox)
    Private Shared Sub MaskedTextBoxSelectAll(ByVal pTarget As MaskedTextBox)
        If pTarget IsNot Nothing Then pTarget.SelectAll()
    End Sub
#End Region

#Region "Undo ���\�b�h"

    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub
#End Region

#Region "WaterMark�֘A"
    Private Function TrySetWatermark() As Boolean
        If _watermarkText.IsNullOrWhiteSpace = False And
            MyBase.Text.IsNullOrWhiteSpace = True And
            MyBase.Focused = False Then

            '�E�H�[�^�[�}�[�N�ݒ�
            MyBase.ForeColor = WatermarkColor
            MyBase.Text = _watermarkText
            _hasWatermark = True

            Return True
        Else
            _hasWatermark = False
            Return False
        End If

    End Function

    Private Sub ResetWatermark(ByVal value As String)
        If value IsNot Nothing Then
            MyBase.Text = value
        End If
        MyBase.ForeColor = _foreColor
        _hasWatermark = False
    End Sub

#End Region

#End Region

End Class

