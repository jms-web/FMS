﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M016_承認担当者マスタ
''' </summary>
<Table("M016_SYONIN_TANTO", Schema:="dbo")>
Partial Public Class M016_SYONIN_TANTO
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=2)>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

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