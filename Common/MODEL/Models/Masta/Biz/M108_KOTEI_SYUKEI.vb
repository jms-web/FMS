Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports System.Drawing

''' <summary>
''' M108_管理工程集計マスタ
''' </summary>
<Table("M108_KOTEI_SYUKEI", Schema:="dbo")>
Partial Public Class M108_KOTEI_SYUKEI
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("工程集計区分")>
    Public Property KOTEI_SYUKEI_KB As String

    <Key>
    <Column(Order:=2, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("工程管理区分")>
    Public Property KOTEI_KANRI_KB As String

    <Key>
    <Column(Order:=3)>
    <ComponentModel.DisplayName("工程ID")>
    Public Property KOTEI_ID As Integer

    <Key>
    <Column(Order:=4, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("参照工程管理区分")>
    Public Property S_KOTEI_KANRI_KB As String

    <Key>
    <Column(Order:=5)>
    <ComponentModel.DisplayName("参照工程ID")>
    Public Property S_KOTEI_ID As Integer


    <Required>
    <ComponentModel.DisplayName("工数割合")>
    Public Property KOSU_WARIAI As Integer

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