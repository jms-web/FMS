Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(D006_CAR_GENIN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D006_CAR_GENIN
    Inherits NotifyChangedBase


    Public Sub New()
        Call Clear()
    End Sub

    Public Sub Clear()

    End Sub


    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    <DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("連番")>
    Public Property RENBAN As Integer

    <Key>
    <Column(Order:=2, TypeName:="varchar")>
    <StringLength(2)>
    <DisplayName("原因分析区分")>
    Public Property GENIN_BUNSEKI_KB As String

    <Key>
    <Column(Order:=3, TypeName:="varchar")>
    <StringLength(2)>
    <DisplayName("原因分析詳細区分")>
    Public Property GENIN_BUNSEKI_S_KB As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(DAIHYO_FLG), TypeName:="char")>
    <ComponentModel.DisplayName("代表フラグ")>
    Public Property _DAIHYO_FLG As String

    <ComponentModel.DisplayName("代表フラグ")>
    <NotMapped>
    <DoNotNotify>
    Public Property DAIHYO_FLG As Boolean
        Get
            Return IIf(_DAIHYO_FLG = "0", False, True)
        End Get
        Set(value As Boolean)
            _DAIHYO_FLG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(DAIHYO_FLG))
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

End Class