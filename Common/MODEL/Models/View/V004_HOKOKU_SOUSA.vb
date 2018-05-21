Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(V005_CAR_J), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V004_HOKOKU_SOUSA

    Public Sub New()
        Call Clear()
    End Sub

    Public Sub Clear()
        SYONIN_HOKOKUSYO_ID = 0
        HOKOKUSYO_NO = ""
        ADD_YMDHNS = ""
        SYONIN_JUN = 0
        SOUSA_KB = ""
        SOUSA_NAME = ""
        SYAIN_ID = 0
        SYAIN_NAME = ""
        SYONIN_HANTEI_KB = ""
        SYONIN_HANTEI_NAME = ""
        RIYU = ""

    End Sub

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
End Class