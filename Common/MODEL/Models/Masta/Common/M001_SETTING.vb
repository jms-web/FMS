Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' M001_システム設定値マスタ
''' </summary>
<Table("M001_SETTING", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M001_SETTING
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("項目名")>
    Public Property ITEM_NAME As String

    <Key>
    <Column(Order:=1, TypeName:="nvarchar")>
    <StringLength(50)>
    <ComponentModel.DisplayName("項目値")>
    Public Property ITEM_VALUE As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("項目グループ")>
    Public Property ITEM_GROUP As String

    <Required>
    <StringLength(150)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("表示値")>
    Public Property ITEM_DISP As String

    <Required>
    <ComponentModel.DisplayName("表示順")>
    Public Property DISP_ORDER As Integer

    '<DoNotNotify>
    '<Required>
    '<StringLength(1)>
    '<Column(NameOf(DEF_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _DEF_FLG As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("既定値")>
    Public Property DEF_FLG_ As Boolean
        Get
            Return DEF_FLG <> "0"
        End Get
        Set(value As Boolean)
            DEF_FLG = IIf(value, "1", "0")
        End Set
    End Property
    Public Property DEF_FLG As String

    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("備考")>
    Public Property BIKOU As String

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
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
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
                '  マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    '  上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        '  上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class