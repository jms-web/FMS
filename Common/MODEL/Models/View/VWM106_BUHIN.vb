Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM106_BUHIN
    Inherits ModelBase
    Implements IDisposable

    <Key>
    <Column(Order:=0)>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("得意先コード")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property TOKUI_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("取引先名")>
    Public Property TORI_NAME As String

    <Key>
    <Column(Order:=2)>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=3)>
    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String






    <Key>
    <Column(Order:=4)>
    <StringLength(80)>
    <ComponentModel.DisplayName("部品名")>
    Public Property BUHIN_NAME As String

    <Key>
    <Column(Order:=5)>
    <StringLength(2)>
    <ComponentModel.DisplayName("契約区分")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KEIYAKU_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("契約区分")>
    Public Property KEIYAKU_KB_DISP As String

    <Key>
    <Column(Order:=6)>
    <StringLength(20)>
    <ComponentModel.DisplayName("図番C")>
    Public Property ZUBAN_C As String

    <Key>
    <Column(Order:=7)>
    <StringLength(20)>
    <ComponentModel.DisplayName("品種番号")>
    Public Property HINSYU_BANGO As String

    <Key>
    <Column(Order:=8)>
    <StringLength(2)>
    <ComponentModel.DisplayName("陸海空区分")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property RIKUKAIKU_KB As String

    <StringLength(150)>
    <ComponentModel.DisplayName("陸海空区分")>
    Public Property RIKUKAIKU_KB_DISP As String

    <Key>
    <Column(Order:=9, TypeName:="money")>
    <ComponentModel.DisplayName("単価")>
    Public Property TANKA As Decimal

    <Key>
    <Column(Order:=10)>
    <StringLength(1)>
    <ComponentModel.DisplayName("立会検査フラグ")>
    Public Property TACHIAI_FLG As String

    <Key>
    <Column(Order:=11)>
    <ComponentModel.DisplayName("機種ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("機種名")>
    Public Property KISYU_NAME As String

    <Key>
    <Column(Order:=12)>
    <StringLength(7)>
    <ComponentModel.DisplayName("色CD")>
    Public Property COLOR_CD As String



    <Key>
    <Column(Order:=13)>
    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <Key>
    <Column(Order:=14)>
    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <Key>
    <Column(Order:=15)>
    <StringLength(14)>
    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <Key>
    <Column(Order:=16)>
    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <Key>
    <Column(Order:=17)>
    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <Key>
    <Column(Order:=18)>
    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <DoNotNotify>
    <ComponentModel.DisplayName("削除フラグ")>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

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
