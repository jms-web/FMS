Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged


<AddINotifyPropertyChangedInterface>
Partial Public Class VWM017_FUTEKIGO_CODE
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=1)>
    <StringLength(50)>
    <ComponentModel.DisplayName("項目名")>
    Public Property ITEM_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(50)>
    <ComponentModel.DisplayName("項目値")>
    Public Property ITEM_VALUE As String

    <Key>
    <Column(Order:=3)>
    <StringLength(150)>
    <ComponentModel.DisplayName("項目表示")>
    Public Property ITEM_DISP As String

    <Key>
    <Column(Order:=4)>
    <ComponentModel.DisplayName("表示順")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DISP_ORDER As Integer

    <Key>
    <Column(Order:=5)>
    <StringLength(1)>
    <ComponentModel.DisplayName("既定値フラグ")>
    Public Property DEF_FLG As String

    <Key>
    <Column(Order:=6)>
    <StringLength(200)>
    <ComponentModel.DisplayName("備考")>
    Public Property BIKOU As String

    <Key>
    <Column(Order:=7)>
    <StringLength(2)>
    <ComponentModel.DisplayName("製品区分")>
    Public Property SEIHIN_KB As String

    <Key>
    <Column(Order:=8)>
    <ComponentModel.DisplayName("製品区分名")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SEIHIN_KB_DISP As String

    <Key>
    <Column(Order:=9)>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=10)>
    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
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

    <StringLength(30)>
    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=13)>
    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=14)>
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
