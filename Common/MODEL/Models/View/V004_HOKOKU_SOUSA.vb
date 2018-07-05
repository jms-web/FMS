Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(V004_HOKOKU_SOUSA), Schema:="dbo")>
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
        HENKOU_KENSU = 0
        MODOSI_SAKI_SYAIN_ID = 0
        MODOSI_SAKI_SYAIN_NAME = ""
    End Sub

    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(V004_HOKOKU_SOUSA).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(V004_HOKOKU_SOUSA).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

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