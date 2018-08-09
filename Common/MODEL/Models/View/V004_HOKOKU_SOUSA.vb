Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(V004_HOKOKU_SOUSA), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V004_HOKOKU_SOUSA
    Inherits ModelBase

    Public Property SYONIN_HOKOKUSYO_ID As Integer
    Public Property HOKOKUSYO_NO As String
    Public Property ADD_YMDHNS As String
    Public Property SYONIN_JUN As Integer
    Public Property SOUSA_KB As String
    Public Property SOUSA_NAME As String
    Public Property SYAIN_ID As Integer
    Public Property SYAIN_NAME As String
    Public Property SYONIN_HANTEI_KB As String
    Public Property SYONIN_HANTEI_NAME As String
    Public Property RIYU As String

    Public Property HENKOU_KENSU As Integer

    Public Property MODOSI_SAKI_SYAIN_ID As Integer
    Public Property MODOSI_SAKI_SYAIN_NAME As String

End Class