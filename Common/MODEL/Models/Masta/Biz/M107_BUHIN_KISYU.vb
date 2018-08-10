Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' M107_部品機種マスタ
''' </summary>
<Table("M107_BUHIN_KISYU", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M107_BUHIN_KISYU
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("得意先ID")>
    Public Property TOKUI_ID As Integer

    <Key>
    <Column(Order:=2, TypeName:="varchar")>
    <Required>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

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
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
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