Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Drawing
Imports PropertyChanged

''' <summary>
''' M106_部品番号マスタ
''' </summary>
<Table("M106_BUHIN", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M106_BUHIN
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
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(80)>
    <ComponentModel.DisplayName("部品名")>
    Public Property BUHIN_NAME As String

    <Column(TypeName:="char")>
    <Required>
    <StringLength(2)>
    <ComponentModel.DisplayName("契約区分")>
    Public Property KEIYAKU_KB As String

    <Column(TypeName:="varchar")>
    <Required>
    <StringLength(20)>
    <ComponentModel.DisplayName("図番C")>
    Public Property ZUBAN_C As String

    <Required>
    <StringLength(20)>
    <Column(TypeName:="varchar")>
    <ComponentModel.DisplayName("品種番号")>
    Public Property HINSYU_BANGO As String

    <Column(TypeName:="char")>
    <Required>
    <StringLength(2)>
    <ComponentModel.DisplayName("陸海空区分")>
    Public Property RIKUKAIKU_KB As String

    <Required>
    <Column(TypeName:="money")>
    <ComponentModel.DisplayName("単価")>
    Public Property TANKA As Decimal

    <DoNotNotify>
    <Required>
    <StringLength(1)>
    <Column("TACHIAI_FLG", TypeName:="Char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _TACHIAI_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("立会検査フラグ")>
    Public Property TACHIAI_FLG As Boolean
        Get
            Return _TACHIAI_FLG <> "0"
        End Get
        Set(value As Boolean)
            _TACHIAI_FLG = IIf(value, "1", "0")
        End Set
    End Property

    <Required>
    <StringLength(7)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("色CD")>
    Public Property COLOR_CD As String

    <NotMapped>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("色")>
    Public Property COLOR As Color
        Get
            Return ColorTranslator.FromHtml(COLOR_CD)
        End Get

        Set(value As Color)
            COLOR_CD = ColorTranslator.ToHtml(value)
        End Set
    End Property

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
    <Display(AutoGenerateField:=False)>
    <DoNotNotify>
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