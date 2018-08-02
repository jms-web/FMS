Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM002_BUSYO

    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("部門")>
    Public Property BUMON_KB_NAME As String

    <ComponentModel.DisplayName("有効期限")>
    Public Property YUKO_YMD As String

    <ComponentModel.DisplayName("部署区分")>
    Public Property BUSYO_KB As String

    <ComponentModel.DisplayName("部署区分名")>
    Public Property BUSYO_KB_NAME As String

    <ComponentModel.DisplayName("部署名")>
    Public Property BUSYO_NAME As String

    <ComponentModel.DisplayName("親部署ID")>
    Public Property OYA_BUSYO_ID As Integer

    <ComponentModel.DisplayName("親部署区分")>
    Public Property OYA_BUSYO_KB As String

    <ComponentModel.DisplayName("親部署名")>
    Public Property OYA_BUSYO_NAME As String

    <ComponentModel.DisplayName("所属長社員ID")>
    Public Property SYOZOKUCYO_ID As Integer

    <ComponentModel.DisplayName("所属長社員名")>
    Public Property SYOZOKUCYO_SYAIN_NAME As String

    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("追加社員ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("追加社員名")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("更新日時")>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新社員ID")>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("更新社員名")>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除日時")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除社員ID")>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("削除社員名")>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除フラグ")>
    Public Property DEL_FLG As String

End Class
