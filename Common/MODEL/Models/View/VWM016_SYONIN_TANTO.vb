Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM016_SYONIN_TANTO
    Inherits ModelBase

    <ComponentModel.DisplayName("³”F•ñ‘ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <ComponentModel.DisplayName("•ñ‘—ª–¼")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String

    <ComponentModel.DisplayName("³”F‡")>
    Public Property SYONIN_JUN As Integer

    <ComponentModel.DisplayName("³”F“à—e–¼")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("ŽÐˆõID")>
    Public Property SYAIN_ID As Integer

    <ComponentModel.DisplayName("ŽÐˆõNO")>
    Public Property SYAIN_NO As String

    <ComponentModel.DisplayName("ŽÐˆõ–¼")>
    Public Property SYAIN_NAME As String

    <ComponentModel.DisplayName("•”–å‹æ•ª")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("•”–å‹æ•ª")>
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("’Ç‰Á“úŽž")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("’Ç‰Á’S“–ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("’Ç‰Á’S“–ŽÒ")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

End Class