Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Partial Public Class VWM105_KISYU
    Inherits ModelBase

    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB_DISP As String

    ''' <summary>
    ''' 未使用
    ''' </summary>
    ''' <returns></returns>
    <ComponentModel.DisplayName("機種")>
    Public Property KISYU As String

    <ComponentModel.DisplayName("機種名")>
    Public Property KISYU_NAME As String

    '共通項目------------------------------------
    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("追加担当ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("追加担当者")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("更新日時")>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新担当ID")>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("更新担当者")>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除日時")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除担当ID")>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("削除担当者")>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除フラグ")>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
        End Get
    End Property
End Class
