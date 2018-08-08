Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' R001_報告書操作履歴
''' </summary>
<Table(NameOf(R001_HOKOKU_SOUSA), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class R001_HOKOKU_SOUSA
    Inherits ModelBase

    Public Shadows Sub Clear()
        SYONIN_HOKOKUSYO_ID = 0
        HOKOKU_NO = ""
        ADD_YMDHNS = ""
        SYONIN_JUN = 0
        SYAIN_ID = 0
        SOUSA_KB = ""
        SYONIN_HANTEI_KB = ""
        RIYU = ""
    End Sub

    <Key>
    <Column(Order:=0)>
    <DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=1, TypeName:="char")>
    <StringLength(10)>
    <DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Key>
    <Column(Order:=2, TypeName:="char")>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <Required>
    <DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("操作区分")>
    Public Property SOUSA_KB As String

    <Required>
    <DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("承認判定区分")>
    Public Property SYONIN_HANTEI_KB As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("理由")>
    Public Property RIYU As String

End Class