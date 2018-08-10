Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V001_SYONIN_TANTO
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <ComponentModel.DisplayName("承認報告書ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(50)>
    <ComponentModel.DisplayName("報告書名")>
    Public Property SYONIN_HOKOKUSYO_NAME As String

    <Key>
    <Column(Order:=2)>
    <ComponentModel.DisplayName("承認順")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYONIN_JUN As Integer

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    <ComponentModel.DisplayName("承認内容名")>
    Public Property SYONIN_NAIYO As String

    <Key>
    <Column(Order:=4)>
    <ComponentModel.DisplayName("社員ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("氏名")>
    Public Property SIMEI As String

    <Key>
    <Column(Order:=5)>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=6)>
    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=7)>
    <StringLength(1)>
    <ComponentModel.DisplayName("削除フラグ")>
    Public Property DEL_FLG As String

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
