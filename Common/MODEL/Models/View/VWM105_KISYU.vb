Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Partial Public Class VWM105_KISYU
    Inherits ModelBase

    <ComponentModel.DisplayName("�@��ID")>
    Public Property KISYU_ID As Integer

    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB_DISP As String

    ''' <summary>
    ''' ���g�p
    ''' </summary>
    ''' <returns></returns>
    <ComponentModel.DisplayName("�@��")>
    Public Property KISYU As String

    <ComponentModel.DisplayName("�@�햼")>
    Public Property KISYU_NAME As String

    '���ʍ���------------------------------------
    <ComponentModel.DisplayName("�ǉ�����")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("�ǉ��S��ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��S����")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�X�V����")>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("�X�V�S��ID")>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�X�V�S����")>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜����")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜�S��ID")>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�폜�S����")>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("�폜�t���O")>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
        End Get
    End Property
End Class
