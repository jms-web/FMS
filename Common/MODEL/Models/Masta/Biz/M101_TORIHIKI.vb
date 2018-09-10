Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' M101_取引先マスタ
''' </summary>
<Table("M101_TORIHIKI", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M101_TORIHIKI
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <ComponentModel.DisplayName("取引先ID")>
    Public Property TORI_ID As Integer

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("取引先名")>
    Public Property TORI_NAME As String

    <Required>
    <StringLength(1)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("取引区分")>
    Public Property TORI_KB As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("郵便番号")>
    Public Property POST As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所1")>
    Public Property ADD1 As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所2")>
    Public Property ADD2 As String

    <Required>
    <StringLength(50)>
    <Column(TypeName:="nvarchar")>
    <ComponentModel.DisplayName("住所3")>
    Public Property ADD3 As String

    <Required>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <Phone>
    <ComponentModel.DisplayName("TEL")>
    Public Property TEL As String
        Get
            Return $"{TEL_P1}-{TEL_P2}-{TEL_P3}"
        End Get
        Set(value As String)
            If value.Contains("-") Then
                TEL_P1 = value.Split("-")(0)
                TEL_P2 = value.Split("-")(1)
                TEL_P3 = value.Split("-")(2)
            End If
        End Set
    End Property

    <Display(AutoGenerateField:=False)>
    Public Property TEL_P1 As String

    <Display(AutoGenerateField:=False)>
    Public Property TEL_P2 As String

    <Display(AutoGenerateField:=False)>
    Public Property TEL_P3 As String


    <Required>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <Phone>
    <ComponentModel.DisplayName("FAX")>
    Public Property FAX As String
        Get
            Return $"{FAX_P1}-{FAX_P2}-{FAX_P3}"
        End Get
        Set(value As String)
            If value.Contains("-") Then
                FAX_P1 = value.Split("-")(0)
                FAX_P2 = value.Split("-")(1)
                FAX_P3 = value.Split("-")(2)
            End If
        End Set
    End Property

    <Display(AutoGenerateField:=False)>
    Public Property FAX_P1 As String

    <Display(AutoGenerateField:=False)>
    Public Property FAX_P2 As String

    <Display(AutoGenerateField:=False)>
    Public Property FAX_P3 As String



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