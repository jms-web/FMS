Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M009_画面権限マスタ
''' </summary>
<Table("M009_GAMEN_KENGEN", Schema:="dbo")>
Partial Public Class M009_GAMEN_KENGEN
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("業務グループID")>
    Public Property GYOMU_GROUP_ID As Integer

    <Key>
    <Column(Order:=1, TypeName:="varchar")>
    <ComponentModel.DisplayName("画面ID")>
    <StringLength(6)>
    Public Property GAMEN_ID As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("権限区分")>
    Public Property KENGEN_KB As String

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
