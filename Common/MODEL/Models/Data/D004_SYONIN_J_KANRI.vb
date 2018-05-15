Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' D004_承認実績管理
''' </summary>
<Table(NameOf(D004_SYONIN_J_KANRI), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D004_SYONIN_J_KANRI
    Inherits NotifyChangedBase


    Public Sub New()
        Call clear()
    End Sub

    Public Sub clear()
        SYONIN_HOKOKUSYO_ID = 0
        HOKOKU_NO = ""
        SYONIN_JUN = 0
        SYAIN_ID = 0
        SYONIN_YMDHNS = ""
        SYONIN_HANTEI_KB = ""
        SASIMODOSI_FG = False
        RIYU = ""
        COMMENT = ""
        MAIL_SEND_FG = False
        ADD_YMDHNS = ""
        ADD_SYAIN_ID = 0
        UPD_YMDHNS = ""
        UPD_SYAIN_ID = 0
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
    <Column(Order:=2)>
    <DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <Required>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(14)>
    <ComponentModel.DisplayName("承認日時")>
    Public Property SYONIN_YMDHNS As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("承認判定区分")>
    Public Property SYONIN_HANTEI_KB As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(SASIMODOSI_FG), TypeName:="char")>
    <ComponentModel.DisplayName("差戻フラグ")>
    Public Property _SASIMODOSI_FG As String

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

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("理由")>
    Public Property RIYU As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("コメント")>
    Public Property COMMENT As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(MAIL_SEND_FG), TypeName:="char")>
    <ComponentModel.DisplayName("メール送信フラグ")>
    Public Property _MAIL_SEND_FG As String

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


    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <DoNotNotify>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

End Class