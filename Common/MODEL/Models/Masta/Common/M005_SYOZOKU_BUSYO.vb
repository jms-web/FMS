Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M005_所属部署マスタ
''' </summary>
<Table("M005_SYOZOKU_BUSYO", Schema:="dbo")>
Partial Public Class M005_SYOZOKU_BUSYO
    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <Required>
    <Column(TypeName:="char")>
    <StringLength(8)>
    <ComponentModel.DisplayName("有効期限")>
    Public Property YUKO_YMD As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(KENMU_FLG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _KENMU_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("兼務フラグ")>
    Public Property KENMU_FLG As Boolean
        Get
            Return _KENMU_FLG <> "0"
        End Get
        Set(value As Boolean)
            If value Then
                _KENMU_FLG = "1"
            Else
                _KENMU_FLG = "0"
            End If
        End Set
    End Property


    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer
End Class
