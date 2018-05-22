Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' R002
''' </summary>
<Table(NameOf(R002_HOKOKU_TENSO), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class R002_HOKOKU_TENSO

    Public Sub New()
        Call clear()
    End Sub

    Public Sub clear()
        SYONIN_HOKOKUSYO_ID = 0
        HOKOKU_NO = ""
        SYONIN_JUN = 0
        RENBAN = 0
        TENSO_M_SYAIN_ID = 0
        TENSO_S_SYAIN_ID = 0
        RIYU = ""
        ADD_YMDHNS = ""
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

    <Required>
    <DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <Required>
    <DisplayName("連番")>
    Public Property RENBAN As Integer

    <Required>
    <DisplayName("転送元社員ID")>
    Public Property TENSO_M_SYAIN_ID As Integer

    <Required>
    <DisplayName("転送先社員ID")>
    Public Property TENSO_S_SYAIN_ID As Integer

    <DisplayName("理由")>
    Public Property RIYU As String

    <Key>
    <Column(Order:=2, TypeName:="char")>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

End Class