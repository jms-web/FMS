Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M006_稼働カレンダーマスタ
''' </summary>
<Table("M006_CALENDAR", Schema:="dbo")>
Partial Public Class M006_CALENDAR
    <Key>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("年月日")>
    Public Property YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("稼働区分")>
    Public Property KADO_KB As String

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
