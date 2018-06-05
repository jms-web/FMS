Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V003_SYONIN_J_KANRI
    Inherits NotifyChangedBase


    Public Sub New()
        'Call Clear()
    End Sub

    Public Sub Clear()
        SYONIN_HOKOKUSYO_ID = 0
        HOKOKU_NO = ""
        SYONIN_JUN = 0
        SYAIN_ID = 0
        SYAIN_NAME = ""
        SYONIN_YMDHNS = ""
        SYONIN_HANTEI_KB = ""
        SYONIN_HANTEI_NAME = ""
        SASIMODOSI_FG = False
        RIYU = ""
        COMMENT = ""
        MAIL_SEND_FG = False
        ADD_YMDHNS = ""
        ADD_SYAIN_ID = 0
        ADD_SYAIN_NAME = ""
        UPD_YMDHNS = ""
        UPD_SYAIN_ID = 0
        UPD_SYAIN_NAME = ""

    End Sub

    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(V003_SYONIN_J_KANRI).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(V003_SYONIN_J_KANRI).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    Public Property SYONIN_HOKOKUSYO_ID As Integer

    Public Property HOKOKU_NO As String
    Public Property SYONIN_JUN As Integer
    Public Property SYAIN_ID As Integer
    Public Property SYAIN_NAME As String
    Public Property SYONIN_YMDHNS As String
    Public Property SYONIN_HANTEI_KB As String
    Public Property SYONIN_HANTEI_NAME As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(SASIMODOSI_FG), TypeName:="char")>
    <ComponentModel.DisplayName("差戻フラグ")>
    Private Property _SASIMODOSI_FG As String

    <ComponentModel.DisplayName("差戻フラグ")>
    <NotMapped>
    <DoNotNotify>
    Public Property SASIMODOSI_FG As Boolean
        Get
            Return IIf(_SASIMODOSI_FG = "0", False, True)
        End Get
        Set(value As Boolean)
            _SASIMODOSI_FG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(SASIMODOSI_FG))
        End Set
    End Property

    Public Property RIYU As String
    Public Property COMMENT As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(MAIL_SEND_FG), TypeName:="char")>
    <ComponentModel.DisplayName("メール送信フラグ")>
    Private Property _MAIL_SEND_FG As String

    <ComponentModel.DisplayName("メール送信フラグ")>
    <NotMapped>
    <DoNotNotify>
    Public Property MAIL_SEND_FG As Boolean
        Get
            Return IIf(_MAIL_SEND_FG = "0", False, True)
        End Get
        Set(value As Boolean)
            _MAIL_SEND_FG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(MAIL_SEND_FG))
        End Set
    End Property
    Public Property ADD_YMDHNS As String
    Public Property ADD_SYAIN_ID As Integer
    Public Property ADD_SYAIN_NAME As String
    Public Property UPD_YMDHNS As String
    Public Property UPD_SYAIN_ID As Integer
    Public Property UPD_SYAIN_NAME As String


End Class
