Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M007_画面マスタ
''' </summary>
<Table("M007_GAMEN", Schema:="dbo")>
Partial Public Class M007_GAMEN
    <Key>
    <StringLength(6)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("画面ID")>
    Public Property GAMEN_ID As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("画面区分")>
    Public Property GAMEN_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("画面名")>
    Public Property GAMEN_NAME As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("プログラムファイル名")>
    Public Property PG_FILE_NAME As String

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
