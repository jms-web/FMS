Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM105_KISYU

    <Key>
    Public Property KISYU_ID As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(30)>
    <ComponentModel.DisplayName("ã@éÌñº")>
    Public Property KISYU_NAME As String

    'ã§í çÄñ⁄------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <StringLength(1)>
    Public Property DEL_FLG As String







End Class
