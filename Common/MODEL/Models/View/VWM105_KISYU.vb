Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged


<AddINotifyPropertyChangedInterface>
Partial Public Class VWM105_KISYU
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <ComponentModel.DisplayName("部門区分")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("機種")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU As String

    <ComponentModel.DisplayName("機種名")>
    Public Property KISYU_NAME As String

    '共通項目------------------------------------
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("削除フラグ")>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
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
