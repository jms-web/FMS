Imports System.ComponentModel


<DefaultProperty("DefaultProperty")>
Public Class GroupBoxEx
    Inherits GroupBox

    Private _GotForcusedColor As Color = Color.FromArgb(190, 180, 255) '�t�H�[�J�X���̔w�i�F
    Private _BackColorDefault As Color = Color.White '�t�H�[�J�X�r�������̔w�i�F

#Region "�v���p�e�B "
#Region "GotFocusedColor"
    '********************************************************************************
    '  �v���p�e�B��     �F  GotFocusedColor
    '  ����             �F  �J�[�\�����������Ă��鎞�̐F
    '  ���ӎ���         �F  ���ɖ���
    '  �쐬���^�쐬��   �F  08/03/09 seki
    '********************************************************************************
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
    '********************************************************************************
    '  �v���p�e�B��     �F  BackColor
    '  ����             �F  �o�b�N�J���[
    '  ���ӎ���         �F  ���ɖ���
    '  �쐬���^�쐬��   �F  08/03/09 seki
    '********************************************************************************
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
#End Region

#Region "�C�x���g�֘A"
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
        '�t�H�[�J�X���͔w�i�F�ύX
        MyBase.BackColor = _GotForcusedColor
        MyBase.OnGotFocus(e) '���N���X�Ăяo��

    End Sub
#End Region
#Region "OnLostFocus(ByVal e As EventArgs)"
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        '�t�H�[�J�X���Ȃ��Ƃ��͔w�i�F�����ݒ�
        MyBase.BackColor = _BackColorDefault
        MyBase.OnLostFocus(e) '���N���X�Ăяo��

    End Sub
#End Region
#End Region

#Region "�֐�"

#End Region


End Class
