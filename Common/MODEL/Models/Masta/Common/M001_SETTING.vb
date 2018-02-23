Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M001_システム設定値マスタ
''' </summary>
<Table("M001_SETTING", Schema:="dbo")>
Partial Public Class M001_SETTING
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

    <Required>
    <StringLength(1)>
    <Column(NameOf(DEF_FLG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _DEF_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("既定値")>
    Public Property DEF_FLG As Boolean
        Get
            Return _DEF_FLG <> "0"
        End Get
        Set(value As Boolean)
            If value Then
                _DEF_FLG = "1"
            Else
                _DEF_FLG = "0"
            End If
        End Set
    End Property

    <Required>
    <StringLength(200)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("備考")>
    Public Property BIKOU As String

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return String.IsNullOrWhiteSpace(DEL_YMDHNS) = False
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
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