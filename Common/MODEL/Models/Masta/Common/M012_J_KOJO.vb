﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' M012_自社工場マスタ
''' </summary>
<Table("M012_J_KOJO", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M012_J_KOJO
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(3)>
    <ComponentModel.DisplayName("工場CD")>
    Public Property KOJO_ID As String

    <Required>
    <StringLength(30)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("工場名")>
    Public Property KOJO_NAME As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("郵便番号")>
    Public Property POST As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所1")>
    Public Property ADD1 As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所2")>
    Public Property ADD2 As String

    <Required>
    <StringLength(100)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所3")>
    Public Property ADD3 As String

    <Required>
    <Phone>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String

    <Required>
    <Phone>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("FAX")>
    Public Property FAX As String

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("追加日時")>
    Public Property ADD_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("追加社員ID")>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
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

    <ComponentModel.DisplayName("削除フラグ")>
    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
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