Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


''' <summary>
''' M002_部署マスタ
''' </summary>
<Table("M002_BUSYO", Schema:="dbo")>
Partial Public Class M002_BUSYO
    Inherits ModelBase

    <Key>
    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("有効期限")>
    Public Property YUKO_YMD As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("部署区分")>
    Public Property BUSYO_KB As String

    <Required>
    <StringLength(30)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("部署名")>
    Public Property BUSYO_NAME As String

    <Required>
    <ComponentModel.DisplayName("親部署ID")>
    Public Property OYA_BUSYO_ID As Integer

    <Required>
    <ComponentModel.DisplayName("所属長社員ID")>
    Public Property SYOZOKUCYO_ID As Integer

    <Required>
    <Phone>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    Public Property DEL_SYAIN_ID As Integer
End Class