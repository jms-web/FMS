Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM106_BUHIN
    <Key>
    <Column(Order:=0)>
    <StringLength(1)>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property TOKUI_ID As Integer

    <StringLength(50)>
    Public Property TORI_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(60)>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=3)>
    <StringLength(10)>
    Public Property SYANAI_CD As String

    <Key>
    <Column(Order:=4)>
    <StringLength(80)>
    Public Property BUHIN_NAME As String

    <Key>
    <Column(Order:=5)>
    <StringLength(2)>
    Public Property KEIYAKU_KB As String

    <StringLength(150)>
    Public Property KEIYAKU_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(20)>
    Public Property ZUBAN_C As String

    <Key>
    <Column(Order:=7)>
    <StringLength(20)>
    Public Property HINSYU_BANGO As String

    <Key>
    <Column(Order:=8)>
    <StringLength(2)>
    Public Property RIKUKAIKU_KB As String

    <StringLength(150)>
    Public Property RIKUKAIKU_KB_DISP As String

    <Key>
    <Column(Order:=9, TypeName:="money")>
    Public Property TANKA As Decimal

    <Key>
    <Column(Order:=10)>
    <StringLength(1)>
    Public Property TACHIAI_FLG As String

    <Key>
    <Column(Order:=11)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU_ID As Integer

    <StringLength(30)>
    Public Property KISYU_NAME As String

    <Key>
    <Column(Order:=12)>
    <StringLength(7)>
    Public Property COLOR_CD As String

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
