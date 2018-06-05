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

    <Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(D006_CAR_GENIN).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(D006_CAR_GENIN).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

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
    <Column(NameOf(DAIHYO_FG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("代表フラグ")>
    Public Property _DAIHYO_FG As String

    <ComponentModel.DisplayName("代表フラグ")>
    <NotMapped>
    <DoNotNotify>
    Public Property DAIHYO_FG As Boolean
        Get
            Return IIf(_DAIHYO_FG = "0", False, True)
        End Get
        Set(value As Boolean)
            _DAIHYO_FG = IIf(value, "1", "0")
            OnPropertyChanged(NameOf(DAIHYO_FG))
        End Set
    End Property

    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
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
    Public Property ADD_SYAIN_ID As Integer

End Class