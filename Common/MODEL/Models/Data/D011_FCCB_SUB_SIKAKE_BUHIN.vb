﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(D011_FCCB_SUB_SIKAKE_BUHIN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D011_FCCB_SUB_SIKAKE_BUHIN
    Inherits ModelBase

    'Public Shadows Sub Clear()

    'End Sub

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
    Public Property BUHIN_NAME As String

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
    Public Property YOTEI_YMD As String

    <Required>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("完了予定日")>
    Public Property dtYOTEI_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(YOTEI_YMD), Nothing, DateTime.ParseExact(YOTEI_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            YOTEI_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    Public Property CLOSE_YMD As String

    <Required>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("完了日")>
    Public Property dtCLOSE_YMD As Date
        Get
            Return If(String.IsNullOrWhiteSpace(CLOSE_YMD), Nothing, DateTime.ParseExact(CLOSE_YMD, "yyyyMMdd", Nothing))
        End Get
        Set(value As Date)
            CLOSE_YMD = value.ToString("yyyyMMdd")
        End Set
    End Property

#End Region

End Class