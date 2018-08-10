Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' M006_稼働カレンダーマスタ
''' </summary>
<Table("M006_CALENDAR", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M006_CALENDAR
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("年月日")>
    Public Property YMD As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("稼働区分")>
    Public Property KADO_KB As String

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

    '<Required>
    '<StringLength(14)>
    '<Display(AutoGenerateField:=False)>
    '<Column(TypeName:="char")>
    'Public Property DEL_YMDHNS As String

    '<ComponentModel.DisplayName("削除済")>
    '<NotMapped>
    'Public ReadOnly Property DEL_FLG As Boolean
    '    Get
    '        Return DEL_YMDHNS.Trim <> ""
    '    End Get
    'End Property

    '<Required>
    '<Display(AutoGenerateField:=False)>
    'Public Property DEL_SYAIN_ID As Integer
End Class
