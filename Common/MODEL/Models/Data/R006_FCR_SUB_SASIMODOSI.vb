Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' R005 不適合封じ込め調査書履歴
''' </summary>
<Table(NameOf(R006_FCR_J_SUB_SASIMODOSI), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class R006_FCR_J_SUB_SASIMODOSI
    Inherits ModelBase

    Public Shadows Sub Clear()
        SASIMODOSI_YMDHNS = ""
        HOKOKU_NO = ""

    End Sub

    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(14)>
    Public Property SASIMODOSI_YMDHNS As String

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=1, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <Key>
    <Column(Order:=2)>
    Public Property ROW_NO As Integer

    ''' <summary>
    ''' 機種
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property KISYU_ID As Integer

    ''' <summary>
    ''' 部品情報(部品番号、品名)
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property BUHIN_INFO As String

    ''' <summary>
    ''' 数量
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property SURYO As Integer

    ''' <summary>
    ''' 範囲FROM
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property RANGE_FROM As String

    ''' <summary>
    ''' 範囲TO
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property RANGE_TO As String

End Class