Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V006_CAR_GENIN
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <ComponentModel.DisplayName("連番")>
    Public Property RENBAN As Integer

    <ComponentModel.DisplayName("原因分析区分")>
    Public Property GENIN_BUNSEKI_KB As String

    <ComponentModel.DisplayName("操作区分名")>
    Public Property SOUSA_NAME As Integer

    <ComponentModel.DisplayName("原因分析詳細区分")>
    Public Property GENIN_BUNSEKI_S_KB As Integer

    <ComponentModel.DisplayName("原因分析区分名")>
    Public Property GENIN_BUNSEKI_NAME As String

    <ComponentModel.DisplayName("代表フラグ")>
    Public Property DAIHYO_FG As String

    <ComponentModel.DisplayName("追加社員ID")>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("追加社員名")>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String


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
