Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M118_設備マスタ
''' </summary>
<Table("M118_SETUBI", Schema:="dbo")>
Partial Public Class M118_SETUBI
    <Key>
    <ComponentModel.DisplayName("設備ID")>
    Public Property SETUBI_ID As Integer

    <Required>
    <StringLength(80)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("設備名")>
    Public Property SETUBI_NAME As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(3)>
    <ComponentModel.DisplayName("設備記号")>
    Public Property SETUBI_KIGO As String

    <Required>
    <ComponentModel.DisplayName("管理部署ID")>
    Public Property K_BUSYO_ID As Integer

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
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
