Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M103_工程マスタ
''' </summary>
<Table("M103_KOTEI", Schema:="dbo")>
Partial Public Class M103_KOTEI
    <Key>
    <ComponentModel.DisplayName("工程ID")>
    Public Property KOTEI_ID As Integer

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Required>
    <StringLength(30)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("工程名")>
    Public Property KOTEI_NAME As String

    <Required>
    <StringLength(15)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("工程略名")>
    Public Property KOTEI_R_NAME As String

    <Required>
    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("時間単位" & vbCrLf & "区分")>
    Public Property JIKAN_TANI_KB As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("同時加工" & vbCrLf & "区分")>
    Public Property DOJI_KAKO_KB As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(MENTE_KOTEI_FLG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _MENTE_KOTEI_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("メンテ工程" & vbCrLf & "フラグ")>
    Public Property MENTE_KOTEI_FLG As Boolean
        Get
            Return _MENTE_KOTEI_FLG <> "0"
        End Get
        Set(value As Boolean)
            If value Then
                _MENTE_KOTEI_FLG = "1"
            Else
                _MENTE_KOTEI_FLG = "0"
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