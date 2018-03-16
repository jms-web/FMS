Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' R001_承認履歴
''' </summary>
<Table("R001_SYONIN", Schema:="dbo")>
Partial Public Class R001_SYONIN
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Required>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("承認判定区分")>
    Public Property SYONIN_HANTEI_KB As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("理由")>
    Public Property RIYU As String

    ''共通項目------------------------------------
    '<Required>
    '<StringLength(14)>
    '<Display(AutoGenerateField:=False)>
    '<Column(TypeName:="char")>
    'Public Property ADD_YMDHNS As String

    '<Required>
    '<Display(AutoGenerateField:=False)>
    'Public Property ADD_SYAIN_ID As Integer

    '<Required>
    '<StringLength(14)>
    '<Display(AutoGenerateField:=False)>
    '<Column(TypeName:="char")>
    'Public Property UPD_YMDHNS As String

    '<Required>
    '<Display(AutoGenerateField:=False)>
    'Public Property UPD_SYAIN_ID As Integer

    '<Required>
    '<StringLength(14)>
    '<Display(AutoGenerateField:=False)>
    '<Column(TypeName:="char")>
    'Public Property DEL_YMDHNS As String

    '<ComponentModel.DisplayName("削除済")>
    '<NotMapped>
    'Public ReadOnly Property DEL_FLG As Boolean
    '    Get
    '        Return DEL_YMDHNS.Trim <> ""
    '    End Get
    'End Property

    '<Required>
    '<Display(AutoGenerateField:=False)>
    'Public Property DEL_SYAIN_ID As Integer
End Class