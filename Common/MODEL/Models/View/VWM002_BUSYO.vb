Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM002_BUSYO

    <ComponentModel.DisplayName("ID")>
    Public Property BUSYO_ID As Integer

    <ComponentModel.DisplayName("åæª")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("å")>
    Public Property BUMON_KB_NAME As String

    <ComponentModel.DisplayName("LøúÀ")>
    Public Property YUKO_YMD As String

    <ComponentModel.DisplayName("æª")>
    Public Property BUSYO_KB As String

    <ComponentModel.DisplayName("æª¼")>
    Public Property BUSYO_KB_NAME As String

    <ComponentModel.DisplayName("¼")>
    Public Property BUSYO_NAME As String

    <ComponentModel.DisplayName("eID")>
    Public Property OYA_BUSYO_ID As Integer

    <ComponentModel.DisplayName("eæª")>
    Public Property OYA_BUSYO_KB As String

    <ComponentModel.DisplayName("e¼")>
    Public Property OYA_BUSYO_NAME As String

    <ComponentModel.DisplayName("®·ÐõID")>
    Public Property SYOZOKUCYO_ID As Integer

    <ComponentModel.DisplayName("®·Ðõ¼")>
    Public Property SYOZOKUCYO_SYAIN_NAME As String

    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <ComponentModel.DisplayName("ÇÁú")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("ÇÁÐõID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("ÇÁÐõ¼")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("XVú")>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("XVÐõID")>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("XVÐõ¼")>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("íú")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("íÐõID")>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("íÐõ¼")>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("ítO")>
    Public Property DEL_FLG As String

End Class
