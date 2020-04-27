Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(D011_FCCB_SUB_SIKAKE_BUHIN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D011_FCCB_SUB_SIKAKE_BUHIN
    Inherits ModelBase

    Public Shadows Sub Clear()

    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property FCCB_NO As String


    <Key>
    <Column(Order:=1)>
    Public Property ITEM_NO As Integer


#Region "仕掛品状況"

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property BUHIN_HINBAN As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property MEMO1 As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    Public Property MEMO2 As String

    <Required>
    Public Property SURYO As Integer
#End Region

#Region "処置"
    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    Public Property SYOCHI_NAIYO As String

    <ComponentModel.DisplayName("担当部署")>
    <Required>
    Public Property TANTO_GYOMU_GROUP_ID As Integer

    <Required>
    Public Property TANTO_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("完了予定日")>
    Public Property YOTEI_YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("完了日")>
    Public Property CLOSE_YMD As String

#End Region

End Class