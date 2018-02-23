Imports System.ComponentModel

Public Class MultiColumnCombobox
    Inherits ComboBox

    Private _item As New MyCollection(Me)

#Region "�R���X�g���N�^"
    Public Sub New()
        Call InitializeComponent()

        Me.SuspendLayout()
        Me.ResumeLayout(False)
    End Sub
#End Region


    ''' <summary>
    ''' �h���b�v�_�E�����X�g�̗��ݒ肵�܂��B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("�h���b�v�_�E�����X�g�̗�̃J�X�^�}�C�Y")>
    <Description("�h���b�v�_�E�����X�g�̗��ݒ肵�܂�")>
    Public Property DropDownColumns() As MyCollection
        Get
            Return _item
        End Get
        Set(ByVal value As MyCollection)
            _item = value
        End Set
    End Property

    ''' <summary>
    ''' �h���b�v�_�E�����X�g�̗�R���N�V�������ύX���ꂽ�ꍇ�B
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub OnCollectionChanged()

        '��̕��̍��v���h���b�v�_�E�������̕��ɐݒ�B
        If DropDownColumns.Count > 0 Then
            MyBase.DropDownWidth = DropDownColumns(0).Width

            For i As Integer = 1 To DropDownColumns.Count - 1
                MyBase.DropDownWidth += DropDownColumns(i).Width
            Next
        End If
    End Sub

    ''' <summary>
    ''' �h���b�v�_�E�����X�g�̗�R���N�V�����̐ݒ�B
    ''' </summary>
    ''' <remarks></remarks>
    <Runtime.InteropServices.ComVisible(False)>
    Public Class MyCollection
        Inherits System.Collections.ObjectModel.Collection(Of DropDownColumn)

        Private _parent As MultiColumnCombobox

        Friend Sub New(ByVal parent As MultiColumnCombobox)
            _parent = parent
        End Sub

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As DropDownColumn)

            '��̕��̏����l
            If item.Width = Nothing Then
                item.Width = _parent.Width
            End If

            MyBase.InsertItem(index, item)
            _parent.OnCollectionChanged()

        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            MyBase.RemoveItem(index)
            _parent.OnCollectionChanged()
        End Sub

        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As DropDownColumn)
            MyBase.SetItem(index, item)
            _parent.OnCollectionChanged()
        End Sub
    End Class

    ''' <summary>
    ''' ���ݑI������Ă���s�̃����o�[�̒l���擾���܂��B
    ''' </summary>
    ''' <param name="member">�����o�[</param>
    ''' <value></value>
    ''' <returns>�I������Ă���l</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectMemberValue(ByVal member As String) As Object
        Get
            '�f�[�^�\�[�X���Ȃ��ꍇ��Nothing��Ԃ��B
            If MyBase.DataSource Is Nothing Then
                Return Nothing
            End If

            '�f�[�^�\�[�X���f�[�^�e�[�u���łȂ��ꍇ��Nothing��Ԃ��B
            If MyBase.DataSource.GetType IsNot GetType(DataTable) Then
                Return Nothing
            End If

            'DataTable���擾
            Dim dt As DataTable = CType(Me.DataSource, DataTable)

            '�����o�[���f�[�^�e�[�u���̗�łȂ��ꍇ��Nothing��Ԃ��B
            If dt.Columns.IndexOf(member) = -1 Then
                Return Nothing
            End If

            '�����o�[���f�[�^�e�[�u���̗�̏ꍇ�l��Ԃ��B
            Return dt.Rows(Me.SelectedIndex).Item(member)

        End Get
    End Property

    ''' <summary>
    ''' �`�揈��
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        '�I������Ă���A�C�e���̃n�C���C�g
        e.DrawBackground()
        e.DrawFocusRectangle()

        '�f�[�^�\�[�X���Ȃ��ꍇ�͏��O�B
        If MyBase.DataSource Is Nothing Then
            Exit Sub
        End If

        '�f�[�^�\�[�X���f�[�^�e�[�u���łȂ��ꍇ�͏��O
        If MyBase.DataSource.GetType IsNot GetType(DataTable) Then
            Exit Sub
        End If

        '�f�[�^�e�[�u���̎擾
        Dim dt As DataTable = CType(MyBase.DataSource, DataTable)

        '�A�C�e���̕`����W�̎擾
        Dim x As Integer = e.Bounds.X
        Dim y As Integer = e.Bounds.Y
        Dim width As Integer = e.Bounds.X
        Dim height As Integer = e.Bounds.Height
        Dim top As Integer = e.Bounds.Top
        Dim bottom As Integer = e.Bounds.Bottom

        '�F�̎擾
        Dim grayPen As New Pen(Brushes.Gray)
        Dim brsh As New SolidBrush(e.ForeColor)

        '������̕\���`��
        Dim sf As New StringFormat With {
            .Trimming = StringTrimming.EllipsisWord
        }

        Try
            For i As Integer = 0 To Me.DropDownColumns.Count - 1

                '��̕��̎擾
                width = Me.DropDownColumns(i).Width

                '��̋��E���̕`��
                e.Graphics.DrawLine(grayPen, x + width, top, x + width, bottom)

                '��̃����o�[�̎擾
                Dim columnIndex As String = Me.DropDownColumns(i).Member

                '��̃����o�[���Ȃ��ꍇ�܂��̓f�[�^�e�[�u���̗�łȂ��ꍇ�͏��O
                If columnIndex Is Nothing OrElse columnIndex = String.Empty _
                    OrElse dt.Columns.IndexOf(columnIndex) = -1 Then
                    x += width
                    Continue For
                End If

                '��ɕ\������l���擾
                Dim text As String = dt.Rows(e.Index)(columnIndex).ToString
                '�`��̈�
                Dim rectF As New RectangleF(CSng(x), CSng(y), CSng(width), CSng(height))
                '�l�̕`��
                e.Graphics.DrawString(text, e.Font, brsh, rectF, sf)

                '���̗�̍��W
                x += width

            Next
        Finally
            '���\�[�X�̉��
            grayPen.Dispose()
            brsh.Dispose()
            sf.Dispose()
        End Try

    End Sub

End Class

''' <summary>
''' �h���b�v�_�E�����X�g�ɕ\��������̒�`
''' </summary>
''' <remarks></remarks>
Public Class DropDownColumn

    ''' <summary>
    ''' ��̃v���p�e�B
    ''' </summary>
    ''' <remarks></remarks>
    Private _member As String

    ''' <summary>
    ''' ��̃v���p�e�B��ݒ�܂��͎擾���܂��B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("��̃v���p�e�B")>
    Public Property Member As String
        Get
            Return _member
        End Get
        Set(ByVal value As String)
            _member = value
        End Set
    End Property

    ''' <summary>
    ''' ��̕�
    ''' </summary>
    ''' <remarks></remarks>
    Private _width As Integer = Nothing

    ''' <summary>
    ''' ��̕���ݒ�܂��͎擾���܂��B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("��̕�")>
    Public Property Width As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '�C���X�^���X�̏�����
    End Sub

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <param name="paramMember">�\�������</param>
    ''' <param name="paramWidth">��</param>
    ''' <remarks>�h���b�v�_�E�����X�g�ɕ\��������̒�`</remarks>
    Public Sub New(ByVal paramMember As String, ByVal paramWidth As Integer)
        Member = paramMember
        Width = paramWidth
    End Sub
End Class
