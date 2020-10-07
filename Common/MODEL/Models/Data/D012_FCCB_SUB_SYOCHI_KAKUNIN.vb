Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D012_FCCB_SUB_SYOCHI_KAKUNIN
''' </summary>
<Table(NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D012_FCCB_SUB_SYOCHI_KAKUNIN
    Inherits ModelBase

    'Public Shadows Sub Clear()

    'End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="varchar")>
    <StringLength(10)>
    Public Property FCCB_NO As String


    <Key>
    <Column(Order:=1)>
    Public Property GYOMU_GROUP_ID As Integer

    <Required>
    Public Property TANTO_ID As Integer


    <Required>
    Public Property KYOGI_YOHI_KAITO As String


    <Required>
    <Column(TypeName:="char")>
    <StringLength(14)>
    Public Property ADD_YMDHNS As String

    <Required>
    Public Property ADD_SYAIN_ID As Integer
End Class