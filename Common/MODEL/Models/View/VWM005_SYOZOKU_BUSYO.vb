Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM005_SYOZOKU_BUSYO
    Inherits ModelBase
    Implements IDisposable

    <ComponentModel.DisplayName("社員ID")>
    Public Property SYAIN_ID As Integer
    <ComponentModel.DisplayName("社員NO")>
    Public Property SYAIN_NO As String

    Public Property SIMEI As String
    Public Property SIMEI_KANA As String
    Public Property SYAIN_KB As String
    Public Property SYAIN_KB_DISP As String
    Public Property YAKUSYOKU_KB As String
    Public Property YAKUSYOKU_KB_DISP As String
    Public Property DAIKO_KB As String
    Public Property DAIKO_KB_DISP As String
    Public Property TAISYA_YMD As String

    Public Property BUMON_KB As String
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("部署ID")>
    Public Property BUSYO_ID As Integer
    Public Property SYOZOKU_YUKO_YMD As String
    Public Property BUSYO_KB As String
    Public Property BUSYOKB_DISP As String
    Public Property BUSYO_YUKO_YMD As String
    Public Property BUSYO_NAME As String
    Public Property KENMU_FLG As String
    Public Property KENMU_FLG_DISP As String
    '<Column(NameOf(KENMU_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _KENMU_FLG As String


    '<NotMapped>
    'Public Property KENMU_FLG As Boolean
    '    Get
    '        Return IIf(_KENMU_FLG = "0", False, True)
    '    End Get
    '    Set(value As Boolean)
    '        _KENMU_FLG = IIf(value, "1", "0")
    '        'OnPropertyChanged(NameOf(CLOSE_FG))
    '    End Set
    'End Property


    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    'Public Property DEL_FLG As String

    '<DoNotNotify>
    '<Column(NameOf(KENMU_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _KENMU_FLG As String


    '<NotMapped>
    '<ComponentModel.DisplayName("兼務フラグ")>
    'Public Property KENMU_FLG As Boolean
    '    Get
    '        Return IIf(_KENMU_FLG = "0", False, True)
    '    End Get
    '    Set(value As Boolean)
    '        _KENMU_FLG = IIf(value, "1", "0")
    '        'OnPropertyChanged(NameOf(CLOSE_FG))
    '    End Set
    'End Property

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
