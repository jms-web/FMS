Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class V001_SYONIN_TANTO
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(50)>
    Public Property SYONIN_HOKOKUSYO_NAME As String

    <Key>
    <Column(Order:=2)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    Public Property SYONIN_NAIYO As String

    <Key>
    <Column(Order:=4)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYAIN_ID As Integer

    <StringLength(30)>
    Public Property SIMEI As String

    <Key>
    <Column(Order:=5)>
    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=6)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=7)>
    <StringLength(1)>
    Public Property DEL_FLG As String
End Class
