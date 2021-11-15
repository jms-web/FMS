Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' M004_社員マスタ
''' </summary>
<Table("M004_SYAIN", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M004_SYAIN
    Inherits ModelBase
    Implements IDisposable

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

    <ComponentModel.DisplayName("ICカードID")>
    Public Property IC_CARD_ID As String

    <ComponentModel.DisplayName("権限1")>
    Public Property AUTH1 As String

    <ComponentModel.DisplayName("権限2")>
    Public Property AUTH2 As String

    <ComponentModel.DisplayName("権限3")>
    Public Property AUTH3 As String

    <ComponentModel.DisplayName("権限4")>
    Public Property AUTH4 As String

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("追加社員ID")>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="Char")>
    <ComponentModel.DisplayName("更新日時")>
    Public Property UPD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("更新社員ID")>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("削除日時")>
    Public Property DEL_YMDHNS As String

    <DoNotNotify>
    <ComponentModel.DisplayName("削除フラグ")>
    <NotMapped>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    <ComponentModel.DisplayName("削除社員ID")>
    Public Property DEL_SYAIN_ID As Integer

#Region "IDisposable Support"

    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    ' TODO: 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        ' GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class