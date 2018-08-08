'----------------------------------------
'�ύX����
'2007/06/01 ���[�U�[�R���g���[���Ƃ��č쐬�Adatetimepicker��textbox�̈��l�N���A�\�ɂ����maskedtextbox�ɒu������
'2007/09/01 �t�H���g�̓I�[�i�[�̂��̂��g�p
'2007/09/03 maskedtextbox�̈���t�H�[�J�X���S�I���ɂ���ׁAmaskedtextboxex�ɒu������
'2007/10/15 DisplayFormat�v���p�e�B�t��(yyyyMMdd,yyyyMM)
'2007/10/15 LOSTFOCUS���A�󗓈ȊO�̕s���l�Ȃ�ȑO�̒l�ɕ��A
'2007/10/24 Value�v���p�e�B�t��(yyyy/MM/dd�`��)
'2007/11/01 �p�������AText�v���p�e�B��""�Z�b�g����
'2008/01/15 2008/01/2�܂œ��͂����2008/01/02�ɗ\���ϊ������s��C��
'2017.09.11 DisplayFormat=yyyyMM���A�J�����_�[��N���\���ɌŒ�
'2017.10.17 MinDate MaxDate�v���p�e�B�t��
'----------------------------------------

Imports System.ComponentModel

<DefaultEvent("TxtChanged")>
Public Class DateTextBoxEx
    Inherits UserControl


#Region "�����o"
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Private Const _strMaxDate As String = "9998/12/31"
    Private Const _strMinDate As String = "1753/01/01"

    Private _blnNullable As Boolean = False

    'YYYYYMM�I��p
    Private intYear As Integer


    Private _oldValue As String

    Private _GotForcusedColor As Color '�t�H�[�J�X���̔w�i�F
    Private _BackColorDefault As Color '�t�H�[�J�X�r�������̔w�i�F

    Private _BackColorOrg As System.Drawing.Color
    Private _ReadOnly As Boolean
    Private _CursorOrg As Cursor
#End Region

#Region "�R���X�g���N�^"
    Public Sub New()
        InitializeComponent()

        Me._GotForcusedColor = clrControlGotFocusedColor
        Me._BackColorDefault = clrControlDefaultBackColor

    End Sub
#End Region

#Region "�v���p�e�B"
#Region "�@DisplayFormat �v���p�e�B (Overridable)�@"
    '-----�N�����\���t�H�[�}�b�g���w�肵�܂��B
    Public Enum EnumType As Byte
        yyyyMMdd = 0
        yyyyMM = 1
    End Enum

    Private _DisplayFormat As EnumType = EnumType.yyyyMMdd

    <Browsable(True),
         Category("CustomProperty"),
         DefaultValue(GetType(EnumType), "yyyyMMdd"),
         Description("�N�����\���t�H�[�}�b�g���w�肵�܂��B"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property DisplayFormat() As EnumType
        Get
            Return Me._DisplayFormat
        End Get

        Set(ByVal value As EnumType)
            If Me._DisplayFormat <> value Then
                Me._DisplayFormat = value

                If Me._DisplayFormat = EnumType.yyyyMMdd Then
                    Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                    Me.MaskedTextBox1.Mask = "0000/00/00"
                ElseIf Me._DisplayFormat = EnumType.yyyyMM Then
                    Me.DateTimePicker1.CustomFormat = "yyyy/MM"
                    Me.MaskedTextBox1.Mask = "0000/00"
                End If
            End If
        End Set
    End Property
#End Region

#Region "Text:�e�L�X�g�{�b�N�X�\���l���擾�E�ݒ�"
    <Browsable(True),
         Category("CustomProperty"),
         Description("�e�L�X�g�{�b�N�X�\���l���擾�E�ݒ�"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Text() As String
        Get
            Return Me.MaskedTextBox1.Text
        End Get

        Set(ByVal value As String)
            Dim intRET As Integer
            '���t�`�F�b�N
            intRET = FunDateLimit(value)
            If intRET = 0 Then
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = DateTime.Parse(value).ToString("yyyy/MM/dd")
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = DateTime.Parse(value).ToString("yyyy/MM")
                End If

            ElseIf intRET = -2 Then '���t������
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = "____/__/__"
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = "____/__"
                End If

            Else '�s�����t��
                Exit Property
            End If

        End Set
    End Property
#End Region

#Region "Value:�R���g���[���̌��ݒl���擾��ݒ�(yyyy/MM/dd�`��)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("�R���g���[���̌��ݒl���擾��ݒ�(yyyy/MM/dd�`��)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Value() As String
        Get
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                '�����͎�
                Return ""
            Else
                Return Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            End If
        End Get

        Set(ByVal value As String)
            '���t�`�F�b�N
            If FunDateLimit(value) <> 0 Then
                Exit Property
            End If

            Me.DateTimePicker1.Value = DateTime.Parse(value)
            Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        End Set
    End Property
#End Region

#Region "ValueDate:�R���g���[���̌��ݒl���擾(Date�`��)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("�R���g���[���̌��ݒl���擾��ݒ�(Date�`��)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public ReadOnly Property ValueDate As Date
        Get
            Return Me.DateTimePicker1.Value
        End Get
    End Property
#End Region

#Region "ValueNonFormat:�R���g���[���̌��ݒl���擾��ݒ�(yyyyMMdd�`��)"
    <Browsable(True),
         Category("CustomProperty"),
         Description("�R���g���[���̌��ݒl���擾��ݒ�(yyyyMMdd�`��)"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property ValueNonFormat() As String
        Get
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                Return ""
            Else
                Select Case Me.DisplayFormat
                    Case EnumType.yyyyMM
                        Return Me.DateTimePicker1.Value.ToString("yyyyMM")
                    Case EnumType.yyyyMMdd
                        Return Me.DateTimePicker1.Value.ToString("yyyyMMdd")
                    Case Else
                        Return ""
                End Select
            End If
        End Get

        Set(ByVal value As String)
            Dim dt As DateTime
            Select Case Me.DisplayFormat
                Case EnumType.yyyyMM
                    DateTime.TryParseExact(value, "yyyyMM", Nothing, Globalization.DateTimeStyles.None, dt)
                Case EnumType.yyyyMMdd
                    DateTime.TryParseExact(value, "yyyyMMdd", Nothing, Globalization.DateTimeStyles.None, dt)
                Case Else
                    Me.MaskedTextBox1.Text = ""
                    Exit Property
            End Select

            '���t�`�F�b�N
            If FunDateLimit(dt) <> 0 Then
                Me.MaskedTextBox1.Text = ""
                Exit Property
            End If

            Me.DateTimePicker1.Value = dt
            Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        End Set
    End Property
#End Region

#Region "BackColor:�e�L�X�g�{�b�N�XBACKCOLOR���擾�E�ݒ�"
    <Browsable(True),
         Category("CustomProperty"),
         Description("�e�L�X�g�{�b�N�XBACKCOLOR���擾�E�ݒ�"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property BackColor() As System.Drawing.Color
        Get
            Return Me.MaskedTextBox1.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            Me.MaskedTextBox1.BackColor = value
            _BackColorDefault = value
        End Set
    End Property
#End Region

#Region "MinDate:�ݒ�\�ȍŏ����t"
    <Browsable(True),
         Category("CustomProperty"),
         Description("DateTimePicker�w��\�ȍŏ����t���擾�E�ݒ�"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(_strMinDate)>
    Public Shadows Property MinDate() As Date
        Get
            Return Me.DateTimePicker1.MinDate
        End Get
        Set(ByVal value As Date)
            Me.DateTimePicker1.MinDate = value
        End Set
    End Property
#End Region

#Region "MaxDate:�ݒ�\�ȍő���t"
    <Browsable(True),
         Category("CustomProperty"),
         Description("DateTimePicker�w��\�ȍő���t���擾�E�ݒ�"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(_strMaxDate)>
    Public Shadows Property MaxDate() As Date
        Get
            Return Me.DateTimePicker1.MaxDate
        End Get
        Set(ByVal value As Date)
            Me.DateTimePicker1.MaxDate = value
        End Set
    End Property
#End Region

#Region "Nullable:�󗓂̋���"
    <Browsable(True),
         Category("CustomProperty"),
         Description("��̓��t�������邩���擾�E�ݒ�"),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <System.ComponentModel.DefaultValueAttribute(False)>
    Public Property Nullable() As Boolean
        Get
            Return _blnNullable
        End Get
        Set(ByVal value As Boolean)
            _blnNullable = value
        End Set
    End Property

#End Region

#Region "OldValue"

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

#End Region

#Region "���\�b�h"
#Region "InitializeComponent:�R���g���[���z�u"
    Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.MaskedTextBox1 = New JMS_COMMON.MaskedTextBoxEx()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DateTimePicker1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(81, 0)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(17, 24)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.TabStop = False
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.MaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaskedTextBox1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox1.GotFocusedColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaskedTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MaskedTextBox1.InputRequired = False
        Me.MaskedTextBox1.Location = New System.Drawing.Point(2, 3)
        Me.MaskedTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.MaskedTextBox1.Mask = "0000/00/00"
        Me.MaskedTextBox1.MaxByteLength = 10
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(79, 17)
        Me.MaskedTextBox1.TabIndex = 1
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        Me.MaskedTextBox1.WatermarkColor = System.Drawing.Color.Empty
        Me.MaskedTextBox1.WatermarkText = Nothing
        '
        'DateTextBoxEx
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.MinimumSize = New System.Drawing.Size(98, 24)
        Me.Name = "DateTextBoxEx"
        Me.Size = New System.Drawing.Size(98, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#End Region

#Region "�C�x���g"

#Region "���[�U�[�R���g���[����TEXT�l���ύX���̃C�x���g��ǉ�"
    Public Event TxtChanged(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "MaskedTextBox1_TextChanged:TEXT�l���ύX��"
    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        Dim strBUFF As String = ""

        '������t��
        If FunDateLimit(Me.MaskedTextBox1.Text) = 0 Then
            If Me.DateTimePicker1.Text <> Me.MaskedTextBox1.Text Then
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    strBUFF = Me.MaskedTextBox1.Text
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    strBUFF = Me.MaskedTextBox1.Text & "/" & Me.DateTimePicker1.Value.ToString("dd")
                End If

                If DateTime.Parse(strBUFF) <= Me.DateTimePicker1.MaxDate And DateTime.Parse(strBUFF) >= Me.DateTimePicker1.MinDate Then
                    Me.DateTimePicker1.Value = DateTime.Parse(strBUFF)
                Else
                    MessageBox.Show("���͂��ꂽ���t�͗L���͈͊O�̂��ߎg�p�o���܂���B", "���t���͔͈̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.MaskedTextBox1.Text = ""
                    Exit Sub
                End If
            End If

            '���[�U�[�R���g���[���̃C�x���g�N��
            RaiseEvent TxtChanged(Me, System.EventArgs.Empty)
        Else
            'MessageBox.Show("�s���ȓ��t�`�������͂���܂����B�B", "���t�`���G���[", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If _blnNullable = True Then
                'Me.MaskedTextBox1.Text = ""
                ''���[�U�[�R���g���[���̃C�x���g�N��
                'RaiseEvent TxtChanged(Me, System.EventArgs.Empty)
            End If
            Exit Sub
        End If
    End Sub
#End Region

#Region "���[�U�[�R���g���[����VALUE�l���ύX���̃C�x���g��ǉ�"
    Public Event DateValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "MaskedTextBox1_TextChanged:VALUE�l���ύX��"
    Private Sub DateTimePicker1_DateValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            If Me.MaskedTextBox1.Text <> Me.DateTimePicker1.Value.ToString("yyyy/MM/dd") Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            End If

        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            If Me.MaskedTextBox1.Text <> Me.DateTimePicker1.Value.ToString("yyyy/MM") Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")

                If intYear = Me.DateTimePicker1.Value.Year Then
                    SendKeys.SendWait("{ENTER}")
                Else
                    intYear = Me.DateTimePicker1.Value.Year
                End If
            End If
        End If

        '���[�U�[�R���g���[���̃C�x���g�N��
        RaiseEvent DateValueChanged(sender, System.EventArgs.Empty)
    End Sub
#End Region

#Region "DateTextBox_LOSTFOCUS"
    Private Sub DateTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Dim intRET As Integer
        Dim strBUFF As String = ""

        '���t�`�F�b�N
        intRET = FunDateLimit(Me.MaskedTextBox1.Text)

        '���t�l�ȊO��
        If intRET = -1 Or intRET = -2 Then
            If Me.MaskedTextBox1.Text.Replace("/", "").IsNullOrWhiteSpace = True Then
                '�����͎�
                Exit Sub
            Else
                '�ȑO�̒l�ɕ��A
                If Me.DisplayFormat = EnumType.yyyyMMdd Then
                    Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
                ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                    Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
                End If
                Exit Sub
            End If
        End If

        '���t�͈͊O��
        If intRET = 1 Then
            '�ȑO�̒l�ɕ��A
            If Me.DisplayFormat = EnumType.yyyyMMdd Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
            End If
            Exit Sub
        End If

        '������t��
        '�u�����N����0�l�߃t�H�[�}�b�g
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            strBUFF = DateTime.Parse(Me.MaskedTextBox1.Text).ToString("yyyy/MM/dd")
        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            strBUFF = DateTime.Parse(Me.MaskedTextBox1.Text).ToString("yyyy/MM")
        End If
        If Me.MaskedTextBox1.Text <> strBUFF Then
            Me.MaskedTextBox1.Text = strBUFF
        End If

    End Sub
#End Region

#Region "MaskedTextBox1_Load:�R���g���[����Load��"
    'Private Sub DateTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'Me.DateTimePicker1.Text = System.DateTime.Now.ToString("yyyy/MM/dd")
    'End Sub
#End Region

#Region "���[�U�[�R���g���[����TEXT�l���ύX���̃C�x���g��ǉ�"
    '2014.01.20 Add by funato 
    Public Event CloseUp(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "DateTimePicker1_CloseUp:�J�����_�[������t��I����"
    Private Sub DateTimePicker1_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.CloseUp
        Me.MaskedTextBox1.Text = Me.DateTimePicker1.Text
        Me.MaskedTextBox1.Focus()

        '���[�U�[�R���g���[���̃C�x���g�N��
        RaiseEvent CloseUp(sender, System.EventArgs.Empty)
    End Sub
#End Region

#Region "�J�����_�[�W�J��"
    '2017.09.11 Add by funato
    Private Sub DateTimePicker1_DropDown(sender As Object, e As EventArgs) Handles DateTimePicker1.DropDown
        Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        intYear = dtp.Value.Year
        If Me.DisplayFormat = EnumType.yyyyMM Then
            SendKeys.Send("^{UP}")
        End If
    End Sub

#End Region

#Region "OnEnter(Overrides)"
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        _oldValue = Me.Text
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
            MaskedTextBox1.BackColor = clrDisableControlGotFocusedColor
            'DateTimePicker1.Enabled = False
            'MaskedTextBox1.ReadOnly = True
        Else
            '�t�H�[�J�X���͔w�i�F�ύX
            MyBase.BackColor = _GotForcusedColor
            MaskedTextBox1.BackColor = _GotForcusedColor
            'DateTimePicker1.Enabled = True
            'MaskedTextBox1.ReadOnly = False
        End If

        MyBase.OnGotFocus(e) '���N���X�Ăяo��

    End Sub

    Private Sub MaskedTextBox1_Enter(sender As Object, e As EventArgs) Handles MaskedTextBox1.Enter
        Call OnGotFocus(e)
    End Sub

#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        If Me.Enabled = False Or Me.ReadOnly = True Then
            MyBase.BackColor = clrDisableControlGotFocusedColor
            MaskedTextBox1.BackColor = clrDisableControlGotFocusedColor
            'DateTimePicker1.Enabled = False
            'MaskedTextBox1.ReadOnly = True
        Else
            '�t�H�[�J�X���Ȃ��Ƃ��͔w�i�F�����ݒ�
            MyBase.BackColor = _BackColorDefault
            MaskedTextBox1.BackColor = _GotForcusedColor
            'DateTimePicker1.Enabled = True
            'MaskedTextBox1.ReadOnly = False
        End If
        MyBase.OnLostFocus(e) '���N���X�Ăяo��
    End Sub

    Private Sub MaskedTextBox1_Leave(sender As Object, e As EventArgs) Handles MaskedTextBox1.Leave
        Call OnLostFocus(e)
    End Sub

#End Region

    Public Property [ReadOnly] As Boolean
        Get
            Return _ReadOnly
        End Get

        Set(ByVal Value As Boolean)
            _ReadOnly = Value
            If Value Then
                Cursor = Cursors.Default
                BackColor = System.Drawing.SystemColors.Control
                MaskedTextBox1.ReadOnly = True
                DateTimePicker1.Enabled = False
                'SetStyle(ControlStyles.UserMouse, True)
                'SetStyle(ControlStyles.Selectable, False)
                'UpdateStyles()
                'RecreateHandle()
            Else
                Cursor = _CursorOrg
                BackColor = _BackColorOrg
                MaskedTextBox1.ReadOnly = False
                DateTimePicker1.Enabled = True
                'SetStyle(ControlStyles.UserMouse, False)
                'SetStyle(ControlStyles.Selectable, True)
                'UpdateStyles()
                'RecreateHandle()
            End If
        End Set
    End Property




#Region "Undo ���\�b�h"
    Public Overloads Sub Undo()
        Me.Text = Me.OldValue
    End Sub
#End Region

#End Region


#Region "�֐�"
    '���t�͈̓`�F�b�N
    ' 0:�͈͓��A1:�͈͊O�A-1:�s�����t�A-2:���t����
    Private Function FunDateLimit(ByVal strDATE As String) As Integer
        Dim dteBUFF As Date

        '�s�����t��
        If strDATE.Replace("/", "").IsNullOrWhiteSpace = True Then
            Return -2
        End If

        '�s�����t��
        If Me.DisplayFormat = EnumType.yyyyMMdd Then
            If strDATE.Replace(" ", "").Trim.Length <> 10 Then
                Return -1
            End If

        ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
            If strDATE.Replace(" ", "").Trim.Length <> 7 Then
                Return -1
            End If
        End If


        '�s�����t��
        If DateTime.TryParse(strDATE, dteBUFF) = False Then
            Return -1
        End If

        '���t�͈͊O��
        If dteBUFF.ToString("yyyy/MM/dd") < _strMinDate Then
            Return 1
        End If

        '���t�͈͊O��
        If dteBUFF.ToString("yyyy/MM/dd") > _strMaxDate Then
            Return 1
        End If

        Return 0

    End Function

    '���t�͈̓`�F�b�N
    ' 0:�͈͓��A1:�͈͊O
    Private Function FunDateLimit(ByVal dteDATE As Date) As Integer
        Dim intRET As Integer

        '���t�͈̓`�F�b�N
        intRET = FunDateLimit(dteDATE.ToString("yyyy/MM/dd"))
        Return intRET

    End Function

    Private Sub MaskedTextBox1_Validated(sender As Object, e As EventArgs) Handles MaskedTextBox1.Validated

        If FunDateLimit(Me.MaskedTextBox1.Text) = 0 Then
            If Me.DisplayFormat = EnumType.yyyyMMdd Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            ElseIf Me.DisplayFormat = EnumType.yyyyMM Then
                Me.MaskedTextBox1.Text = Me.DateTimePicker1.Value.ToString("yyyy/MM")
            End If
        Else
            If _blnNullable = True Then
                Me.MaskedTextBox1.Text = ""
            End If
        End If
    End Sub

    Friend WithEvents MaskedTextBox1 As MaskedTextBoxEx



#End Region


End Class
