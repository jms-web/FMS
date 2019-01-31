Imports System.ComponentModel

<DefaultEvent("TextChanged")>
<DefaultProperty("DefaultProperty")>
Public Class MaskedTextBoxEx
    Inherits MaskedTextBox
    'Implements IReadOnly

#Region "�萔�E�ϐ�"

    Private _ActiveBackColor As Color
    Private _BackColorOrg As Color
    Private _ForeColor As Color
    Private _HasWatermark As Boolean
    Private _InputRequired As Boolean
    Private _InvalidBackColor As Color
    Private _OldValue As String
    Private _WatermarkColor As Color
    Private _WatermarkText As String

    Private chrPermitNumChars As Char() = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "."c, "-"c}

#End Region

#Region "�R���X�g���N�^"

    Public Sub New()
        Call InitializeComponent()


        _WatermarkColor = SystemColors.GrayText
        _BackColorOrg = BackColor
        GotFocusedColor = clrControlGotFocusedColor
        _ActiveBackColor = clrControlDefaultBackColor
        _InvalidBackColor = clrDisableControlGotFocusedColor

    End Sub

#End Region

#Region "�v���p�e�B"

#Region "   BackColor"

    <Bindable(True), Category("Appearance")>
    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If value <> Color.Transparent Then MyBase.BackColor = value
        End Set
    End Property

#End Region

#Region "   ForeColor"

    Public Overrides Property ForeColor As Color
        Get
            If DesignMode Then
                Return _ForeColor
            Else
                Return MyBase.ForeColor
            End If
        End Get
        Set(value As Color)
            _ForeColor = value
            If _HasWatermark Then
            Else
                MyBase.ForeColor = value
            End If
        End Set
    End Property

#End Region

#Region "   GotFocusedColor"

    <Bindable(True), Category("Appearance"), DefaultValue(GetType(Color), "190, 180, 255")>
    Property GotFocusedColor As Color

#End Region

#Region "   InputRequired"

    Public Property InputRequired As Boolean
        Get
            Return _InputRequired
        End Get
        Set(value As Boolean)
            _InputRequired = value
            If value Then
                WatermarkText = "<�K�{>"
                WatermarkColor = Color.Red
            Else
                WatermarkText = _WatermarkText
                WatermarkColor = _ForeColor
            End If
        End Set
    End Property

#End Region

#Region "   MaxByteLength"

    <Category("����"),
     DefaultValue(1000),
     Description("�G�f�B�b�g �R���g���[���ɓ��͂ł���ő啶���o�C�g�����w�肵�܂��B0�̏ꍇ�͎���������")>
    Public Property MaxByteLength As Integer

#End Region

#Region "   OldValue"

    ''' <summary>
    ''' �ύX�O�̒l���擾���܂�
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False)>
    Public ReadOnly Property OldValue As String
        Get
            Return _OldValue
        End Get
    End Property

#End Region

#Region "   PermitNumChars"

    <Category("����"),
     DefaultValue(False),
     Description("�0123456789.-��̂ݓ��͉B(Mask��C���ɓK�p)")>
    Public Property PermitNumChars As Boolean

#End Region

#Region "   ReadOnly"

    <DefaultValue(False)>
    Protected Shadows Property [ReadOnly] As Boolean 'Implements IReadOnly.ReadOnly
        Get
            Return MyBase.ReadOnly
        End Get
        Set(value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                BackColor = _InvalidBackColor
            Else
                BackColor = _BackColorOrg
            End If
            SetStyle(ControlStyles.UserMouse, value)
            'SetStyle(ControlStyles.Selectable, value)
        End Set
    End Property

#End Region

#Region "   SelectAllText"

    <Category("����"),
     DefaultValue(True),
     Description("Focus���̑S�I����ݒ肵�܂��B")>
    Public Property SelectAllText As Boolean

#End Region

#Region "   ShowRemainingChars"

    <Bindable(True), Category("Appearance"), DefaultValue(False)>
    Public Property ShowRemainingChars As Boolean

#End Region

#Region "   WatermarkColor"

    ''' <summary>
    ''' �e�L�X�g����̏ꍇ�ɕ\�����镶����̐F���擾�E�ݒ肵�܂��B
    ''' </summary>
    ''' <returns></returns>
    <Category("�\��")>
    <DefaultValue(GetType(Color), "GrayText")>
    <Description("�e�L�X�g����̏ꍇ�ɕ\�����镶����̐F�ł��B")>
    Public Property WatermarkColor As Color
        Get
            Return _WatermarkColor
        End Get
        Set(value As Color)
            _WatermarkColor = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property

#End Region

#Region "   WatermarkText"

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
            Return _WatermarkText
        End Get
        Set(value As String)
            _WatermarkText = value
            Me.Invalidate() 'Call TrySetWatermark()
        End Set
    End Property

#End Region

#End Region

#Region "�C�x���g"

#Region "   OnChar"

    ''' <summary>
    ''' �����f�[�^�̃N���C�A���g�̈�ւ̑��M��
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overridable Sub OnChar(e As KeyPressEventArgs)
        '---���䕶���͏��O
        If Char.IsControl(e.KeyChar) Then Return

        '---���l�����̂ݓ��͉�
        If PermitNumChars AndAlso Not HasPermitChars(e.KeyChar, chrPermitNumChars) Then
            e.Handled = True
        End If

        '---���͂��ő啶���o�C�g���ɐ���
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
        Dim inputByteCount As Integer = sjisEncoding.GetByteCount(e.KeyChar.ToString())
        Dim selectedTextByteCount As Integer = sjisEncoding.GetByteCount(Me.SelectedText)

        If Me.MaxByteLength > 0 AndAlso textByteCount + inputByteCount - selectedTextByteCount > Me.MaxByteLength Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "   OnEnabledChanged"

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        If Enabled Then
            If [ReadOnly] Then
                MyBase.BackColor = _InvalidBackColor
            Else
                MyBase.BackColor = _ActiveBackColor
            End If
        Else
            MyBase.BackColor = _InvalidBackColor
        End If

        MyBase.OnEnabledChanged(e)
    End Sub

#End Region

#Region "   OnEnter"

    Protected Overrides Sub OnEnter(e As EventArgs)
        _OldValue = Me.Text

        If SelectAllText Then BeginInvoke(Sub() If Me IsNot Nothing Then SelectAll())

        MyBase.OnEnter(e)
    End Sub

#End Region

#Region "   OnGotFocus"

    Protected Overrides Sub OnGotFocus(e As EventArgs)


        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = GotFocusedColor
        End If

        MyBase.OnGotFocus(e)
    End Sub

#End Region

#Region "   OnKeyDown"

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)

        If e.KeyCode = Keys.Escape Or
            ((e.KeyCode = Windows.Forms.Keys.Z) And (e.Modifiers = Keys.Control)) Then

            Undo()
        End If

        MyBase.OnKeyDown(e)
    End Sub

#End Region

#Region "   OnLostFocus"

    Protected Overrides Sub OnLostFocus(e As EventArgs)

        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = _ActiveBackColor
        End If

        MyBase.OnLostFocus(e)
    End Sub

#End Region

#Region "   OnMouseDown"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Capture = False
        End If

        MyBase.OnMouseDown(e)
    End Sub

#End Region

#Region "   OnMouseHover"

    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.Focus()
        MyBase.OnMouseHover(e)
    End Sub

#End Region

#Region "   OnPaste"

    Protected Overridable Sub OnPaste(e As EventArgs)
        Dim inputText As String = ""
        Dim sjisEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim selectedTextByteCount As Integer

        Dim clipboardText As Object = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text)

        If clipboardText Is Nothing Then Return

        '---���l�����̂ݓ��͉�
        If PermitNumChars Then
            SelectedText = GetPermitedString(clipboardText, chrPermitNumChars)
            clipboardText = SelectedText
        End If

        If MaxLength = 0 Or MaxByteLength = 0 Then
            SelectedText = inputText
        Else
            '---�y�[�X�g���ő啶���o�C�g���ɐ���
            If MaxLength * 2 >= MaxByteLength Then

                inputText = clipboardText.ToString()
                Dim textByteCount As Integer = sjisEncoding.GetByteCount(Me.Text)
                Dim inputByteCount As Integer = sjisEncoding.GetByteCount(inputText)
                selectedTextByteCount = sjisEncoding.GetByteCount(SelectedText)
                Dim remainByteCount As Integer = MaxByteLength - (textByteCount - selectedTextByteCount)

                If remainByteCount <= 0 Or MaxByteLength - (textByteCount + inputByteCount) <= 0 Then Return

                If remainByteCount >= inputByteCount Then
                    SelectedText = inputText
                Else
                    textByteCount = sjisEncoding.GetByteCount(inputText)
                    If textByteCount > MaxByteLength Then
                        SelectedText = ClsPubMethod.MidB(inputText, 1, MaxByteLength)
                    Else
                        SelectedText = inputText.Substring(0, remainByteCount)
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "   OnReadOnlyChanged"

    Protected Overrides Sub OnReadOnlyChanged(e As EventArgs)

        If [ReadOnly] Then
            MyBase.BackColor = _InvalidBackColor
        Else
            MyBase.BackColor = _ActiveBackColor
        End If
        MyBase.OnReadOnlyChanged(e)
    End Sub

#End Region

#Region "   OnTextChanged"

    Protected Overrides Sub OnTextChanged(e As EventArgs)

        Me.Refresh()
        MyBase.OnTextChanged(e)
        If ShowRemainingChars Then
            Using g As Graphics = Graphics.FromHwnd(Handle)
                '�e�L�X�g�{�b�N�X���Ɏc����͉\��������`��
                TextRenderer.DrawText(g,
                                      "�c�� " & (MaxLength - (Text.ToString.Length)).ToString("000") & "����",
                                      New Font(Font.Name, Font.Size, FontStyle.Bold, GraphicsUnit.Point, CType(128, Byte)),
                                      ClientRectangle,
                                      SystemColors.GrayText,
                                      Color.Transparent,
                                      TextFormatFlags.Bottom Or TextFormatFlags.Right)
            End Using
        End If
    End Sub

#End Region

#Region "   ProcessDialogKey"

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        'Return�L�[��������Ă��邩���ׂ�
        'Alt��Ctrl�L�[��������Ă��鎞�́A�{���̓����������
        If ((keyData And Keys.KeyCode) = Keys.Return) AndAlso
            ((keyData And (Keys.Alt Or Keys.Control)) = Keys.None) Then
            'Tab�L�[�����������Ɠ��������������
            'Shift�L�[��������Ă��鎞�́A�t���ɂ���
            'Me.ProcessDialogKey(Keys.Tab)
            'If (keyData And Keys.KeyCode) = (Keys.Enter Or Keys.Shift) Then
            If keyData = (Keys.Enter Or Keys.Shift) Then
                Me.ProcessDialogKey((Keys.Tab Or Keys.Shift))
            Else
                Me.ProcessDialogKey(Keys.Tab)
            End If

            '�{���̏����͂����Ȃ�
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

#End Region

#Region "   WndProc"

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

                If m.Msg = WM_PAINT And Me.Text.IsNullOrEmpty = True And WatermarkText.IsNullOrEmpty = False And _HasWatermark = False Then
                    Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                        '�e�L�X�g�{�b�N�X���̓K�؂ȍ��W�ɕ`��
                        Dim rect As Rectangle = Me.ClientRectangle
                        rect.Offset(1, 1)
                        TextRenderer.DrawText(g,
                                              _WatermarkText,
                                              New Font(Me.Font.Name, Me.Font.Size, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte)),
                                              rect,
                                              _WatermarkColor,
                                              TextFormatFlags.Top Or TextFormatFlags.Left)
                    End Using

                    _HasWatermark = True
                Else

                    _HasWatermark = False
                End If


                'CHECK: �E�N���b�N�����̏ꍇ�́A�R�����g�A�E�g����
                'Case WM_CONTEXTMENU
                '    Return
        End Select

        MyBase.WndProc(m)
    End Sub

#End Region

#Region "Onvalidating"
    Protected Overrides Sub OnValidating(e As CancelEventArgs)
        Me.Text = Me.Text.Trim
        MyBase.OnValidating(e)
    End Sub
#End Region

#End Region

#Region "���\�b�h"

#Region "Undo"

    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub

#End Region

#End Region

#Region "���[�J���֐�"

#Region "   TrySetWatermark"

    Private Function TrySetWatermark() As Boolean
        If _WatermarkText.IsNulOrWS = False And
            MyBase.Text.IsNulOrWS = True And
            MyBase.Focused = False Then

            '�E�H�[�^�[�}�[�N�ݒ�
            MyBase.ForeColor = WatermarkColor
            MyBase.Text = _WatermarkText
            _HasWatermark = True

            Return True
        Else
            _HasWatermark = False
            Return False
        End If

    End Function

#End Region

#Region "   ResetWatermark"

    Private Sub ResetWatermark(ByVal value As String)
        If value IsNot Nothing Then
            MyBase.Text = value
        End If
        MyBase.ForeColor = _ForeColor
        _HasWatermark = False
    End Sub

#End Region

#Region "   GetPermitedString"

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

#Region "   HasPermitChars"

    '-----�����ꂽ�������ǂ����������l��Ԃ�
    Private Shared Function HasPermitChars(ByVal chTarget As Char, ByVal chPermits As Char()) As Boolean
        For Each ch As Char In chPermits
            If chTarget = ch Then
                Return True
            End If
        Next ch
    End Function

#End Region

#End Region

End Class