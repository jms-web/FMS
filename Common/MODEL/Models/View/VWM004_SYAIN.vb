Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM004_SYAIN
    <Key>
    <Column(Order:=0)>
    Public Property SYAIN_ID As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(8)>
    Public Property SYAIN_NO As String

    <Key>
    <Column(Order:=2)>
    <StringLength(30)>
    Public Property SIMEI As String

    <Key>
    <Column(Order:=3)>
    <StringLength(60)>
    Public Property SIMEI_KANA As String

    <Key>
    <Column(Order:=4)>
    <StringLength(2)>
    Public Property SYAIN_KB As String

    <StringLength(150)>
    Public Property SYAIN_KB_DISP As String

    <Key>
    <Column(Order:=5)>
    <StringLength(2)>
    Public Property YAKUSYOKU_KB As String

    <StringLength(150)>
    Public Property YAKUSYOKU_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(2)>
    Public Property DAIKO_KB As String

    <StringLength(150)>
    Public Property DAIKO_KB_DISP As String

    <Key>
    <Column(Order:=7)>
    <StringLength(8)>
    Public Property BIRTH_YMD As String

    <Key>
    <Column(Order:=8)>
    <StringLength(8000)>
    Public Property TEL As String

    <Key>
    <Column(Order:=9)>
    <StringLength(8000)>
    Public Property MAIL_ADDRESS As String

    <Key>
    <Column(Order:=10)>
    <StringLength(8)>
    Public Property NYUSYA_YMD As String

    <Key>
    <Column(Order:=11)>
    <StringLength(8)>
    Public Property TAISYA_YMD As String

    <Key>
    <Column(Order:=12)>
    <StringLength(8)>
    Public Property PASS As String

    <Key>
    <Column(Order:=13)>
    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=14)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=15)>
    <StringLength(14)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=16)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=17)>
    <StringLength(14)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=18)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    Public Property DEL_SYAIN_NAME As String

    <Key>
    <Column(Order:=19)>
    <StringLength(1)>
    Public Property DEL_FLG As String
End Class
