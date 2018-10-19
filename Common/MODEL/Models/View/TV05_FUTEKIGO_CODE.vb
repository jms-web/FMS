Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged


<AddINotifyPropertyChangedInterface>
Public Class TV05_FUTEKIGO_CODE
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <StringLength(1)>
    <ComponentModel.DisplayName("製品区分")>
    Public Property SEIHIN_KB As String

    <Key>
    <Column(Order:=1)>
    <StringLength(150)>
    <ComponentModel.DisplayName("製品区分名")>
    Public Property SEIHIN_KB_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(2)>
    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB As String

    <Key>
    <Column(Order:=3)>
    <StringLength(150)>
    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB_NAME As String

    <Key>
    <Column(Order:=4)>
    <StringLength(2)>
    <ComponentModel.DisplayName("不適合詳細区分")>
    Public Property FUTEKIGO_S_KB As String

    <Key>
    <Column(Order:=5)>
    <StringLength(150)>
    <ComponentModel.DisplayName("不適合詳細区分名")>
    Public Property FUTEKIGO_S_KB_NAME As String

    <Key>
    <Column(Order:=6)>
    <ComponentModel.DisplayName("表示順")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DISP_ORDER As Integer

    '<Key>
    '<Column(Order:=7)>
    '<ComponentModel.DisplayName("備考")>
    '<DatabaseGenerated(DatabaseGeneratedOption.None)>
    'Public Property BIKOU As String

    <Key>
    <Column(Order:=8)>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=9)>
    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <Key>
    <Column(Order:=10)>
    <StringLength(30)>
    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <Column(Order:=11)>
    <StringLength(14)>
    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=12)>
    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(13)>
    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=14)>
    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=15)>
    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

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
