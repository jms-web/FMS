Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM014_SYONIN_ROUT
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("承認内容名")>
    Public Property SYONIN_NAIYO As String

    <Required>
    <ComponentModel.DisplayName("警告通知滞留日数")>
    Public Property KEIKOKU_TAIRYU_NISSU As Integer


    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String


    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <StringLength(1)>
    Public Property DEL_FLG As String

End Class