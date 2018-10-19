Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(V004_HOKOKU_SOUSA), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V004_HOKOKU_SOUSA
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("承認報告書ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("承認順")>
    Public Property SYONIN_JUN As Integer

    <ComponentModel.DisplayName("ステージ")>
    Public Property SYONIN_NAIYO As Integer

    <ComponentModel.DisplayName("操作区分")>
    Public Property SOUSA_KB As String

    <ComponentModel.DisplayName("操作区分名")>
    Public Property SOUSA_NAME As String

    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer

    <ComponentModel.DisplayName("社員名")>
    Public Property SYAIN_NAME As String

    <ComponentModel.DisplayName("承認判定区分")>
    Public Property SYONIN_HANTEI_KB As String

    <ComponentModel.DisplayName("承認判定区分名")>
    Public Property SYONIN_HANTEI_NAME As String

    <ComponentModel.DisplayName("理由")>
    Public Property RIYU As String

    <ComponentModel.DisplayName("差戻日時")>
    Public Property SASIMODOSI_YMDHNS As String

    <ComponentModel.DisplayName("変更件数")>
    Public Property HENKOU_KENSU As Integer

    <ComponentModel.DisplayName("差戻先社員ID")>
    Public Property MODOSI_SAKI_SYAIN_ID As Integer

    <ComponentModel.DisplayName("差戻先社員名")>
    Public Property MODOSI_SAKI_SYAIN_NAME As String

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