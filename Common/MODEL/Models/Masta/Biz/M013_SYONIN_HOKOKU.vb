Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M013_承認報告書マスタ
''' </summary>
<Table("M013_SYONIN_HOKOKU", Schema:="dbo")>
Partial Public Class M013_SYONIN_HOKOKU
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("報告書名")>
    Public Property SYONIN_HOKOKUSYO_NAME As String

    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("ファイルパス")>
    Public Property FILE_PATH As String

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer
End Class