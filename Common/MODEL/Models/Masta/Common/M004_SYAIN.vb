Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M004_社員マスタ
''' </summary>
<Table("M004_SYAIN", Schema:="dbo")>
Partial Public Class M004_SYAIN
    <Key>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Required>
    <StringLength(8)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("社員NO")>
    Public Property SYAIN_NO As String

    <Required>
    <StringLength(30)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("氏名")>
    Public Property SIMEI As String

    <Required>
    <StringLength(60)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("氏名カナ")>
    Public Property SIMEI_KANA As String

    <Required>
    <StringLength(2)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("社員区分")>
    Public Property SYAIN_KB As String

    <Required>
    <StringLength(2)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("役職区分")>
    Public Property YAKUSYOKU_KB As String

    <Required>
    <StringLength(2)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("承認代行区分")>
    Public Property DAIKO_KB As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("生年月日")>
    Public Property BIRTH_YMD As String

    <Required>
    <Phone>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Required>
    <EmailAddress>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("メールアドレス")>
    Public Property MAIL_ADDRESS As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("入社年月日")>
    Public Property NYUSYA_YMD As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("退社年月日")>
    Public Property TAISYA_YMD As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("パスワード")>
    Public Property PASS As String

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