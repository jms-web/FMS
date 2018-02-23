Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM001_SETTING
    <Key>
    <Column(Order:=0)>
    <StringLength(50)>
    Public Property ITEM_GROUP As String

    <Key>
    <Column(Order:=1)>
    <StringLength(50)>
    Public Property ITEM_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(50)>
    Public Property ITEM_VALUE As String

    <Key>
    <Column(Order:=3)>
    <StringLength(150)>
    Public Property ITEM_DISP As String

    <Key>
    <Column(Order:=4)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DISP_ORDER As Integer

    <Key>
    <Column(Order:=5)>
    <StringLength(1)>
    Public Property DEF_FLG As String

    <Key>
    <Column(Order:=6)>
    <StringLength(200)>
    Public Property BIKOU As String

    <Key>
    <Column(Order:=7)>
    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=8)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=9)>
    <StringLength(14)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=10)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=11)>
    <StringLength(14)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=12)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <Key>
    <Column(Order:=13)>
    <StringLength(1)>
    Public Property DEL_FLG As String
End Class
