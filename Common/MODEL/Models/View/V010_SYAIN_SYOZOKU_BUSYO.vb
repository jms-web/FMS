Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V010_SYAIN_SYOZOKU_BUSYO
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(8)>
    <ComponentModel.DisplayName("社員NO")>
    Public Property SYAIN_NO As String
    <Key>
    <Column(Order:=2)>
    <StringLength(30)>
    <ComponentModel.DisplayName("氏名")>
    Public Property SIMEI As String

    <Key>
    <Column(Order:=3)>
    <StringLength(60)>
    <ComponentModel.DisplayName("氏名カナ")>
    Public Property SIMEI_KANA As String

    <Key>
    <Column(Order:=4)>
    <StringLength(2)>
    <ComponentModel.DisplayName("社員区分")>
    Public Property SYAIN_KB As String

    <StringLength(150)>
    <Column(Order:=5)>
    <ComponentModel.DisplayName("社員区分")>
    Public Property SYAIN_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(2)>
    <ComponentModel.DisplayName("役職区分")>
    Public Property YAKUSYOKU_KB As String

    <StringLength(150)>
    <Column(Order:=7)>
    <ComponentModel.DisplayName("役職区分")>
    Public Property YAKUSYOKU_KB_DISP As String

    <Key>
    <Column(Order:=8)>
    <StringLength(2)>
    <ComponentModel.DisplayName("承認代行区分")>
    Public Property DAIKO_KB As String

    <Column(Order:=9)>
    <StringLength(150)>
    <ComponentModel.DisplayName("承認代行区分")>
    Public Property DAIKO_KB_DISP As String

    <Key>
    <Column(Order:=10)>
    <StringLength(8)>
    <ComponentModel.DisplayName("生年月日")>
    Public Property BIRTH_YMD As String

    <Key>
    <Column(Order:=11)>
    <StringLength(8000)>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Key>
    <Column(Order:=12)>
    <StringLength(8000)>
    <ComponentModel.DisplayName("メールアドレス")>
    Public Property MAIL_ADDRESS As String

    <Key>
    <Column(Order:=13)>
    <StringLength(8)>
    <ComponentModel.DisplayName("入社年月日")>
    Public Property NYUSYA_YMD As String

    <Key>
    <Column(Order:=14)>
    <StringLength(8)>
    <ComponentModel.DisplayName("退社年月日")>
    Public Property TAISYA_YMD As String

    <Key>
    <Column(Order:=15)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=15)>
    <ComponentModel.DisplayName("部門区分名")>
    Public Property BUMON_KB_DISP As String

    <Key>
    <Column(Order:=15)>
    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer

    <Key>
    <Column(Order:=16)>
    <StringLength(8)>
    <ComponentModel.DisplayName("有効期限")>
    Public Property YUKO_YMD As String

    <Key>
    <Column(Order:=17)>
    <StringLength(2)>
    <ComponentModel.DisplayName("部署区分")>
    Public Property BUSYO_KB As String

    <Key>
    <Column(Order:=18)>
    <StringLength(150)>
    <ComponentModel.DisplayName("部署区分名")>
    Public Property BUSYO_KB_DISP As String

    <Key>
    <Column(Order:=19)>
    <StringLength(30)>
    <ComponentModel.DisplayName("部署名")>
    Public Property BUSYO_NAME As String

    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    '<ComponentModel.DisplayName("追加担当者")>
    '<DatabaseGenerated(DatabaseGeneratedOption.None)>
    'Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    '<ComponentModel.DisplayName("更新担当者")>
    '<DatabaseGenerated(DatabaseGeneratedOption.None)>
    'Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    '<ComponentModel.DisplayName("削除担当者")>
    '<DatabaseGenerated(DatabaseGeneratedOption.None)>
    'Public Property DEL_SYAIN_NAME As String

    <DoNotNotify>
    <ComponentModel.DisplayName("削除フラグ")>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

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
