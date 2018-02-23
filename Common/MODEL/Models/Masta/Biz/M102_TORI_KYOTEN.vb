﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M102_取引先拠点マスタ
''' </summary>
<Table("M102_TORI_KYOTEN", Schema:="dbo")>
Partial Public Class M102_TORI_KYOTEN
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("取引先ID")>
    Public Property TORI_ID As Integer

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("取引先拠点ID")>
    Public Property KYOTEN_ID As Integer

    <Required>
    <StringLength(30)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("取引先拠点名")>
    Public Property KYOTEN_NAME As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("取引区分")>
    Public Property TORI_KB As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("郵便番号")>
    Public Property POSTAL_CODE As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所1")>
    Public Property ADD1 As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所2")>
    Public Property ADD2 As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所3")>
    Public Property ADD3 As String

    <Required>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <Phone>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Required>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <Phone>
    <ComponentModel.DisplayName("FAX")>
    Public Property FAX As String

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