Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V007_NCR_CAR
    Inherits ModelBase
    Implements IDisposable

    Public Property HOKOKU_NO As String

    Public Property SYONIN_JUN As Integer

    Public Property SYONIN_NAIYO As String

    Public Property SYONIN_HOKOKUSYO_ID As Integer

    Public Property SYONIN_HOKOKUSYO_NAME As String

    Public Property SYONIN_HOKOKUSYO_R_NAME As String

    Public Property GEN_TANTO_ID As Integer

    Public Property GEN_TANTO_NAME As String

    Public Property SYONIN_YMDHNS As String

    Public Property TAIRYU_NISSU As Integer

    Public Property TOTAL_TAIRYU_NISSU As Integer

    Public Property TAIRYU_FG As Integer

    Public Property KISYU_ID As Integer

    Public Property KISYU_NAME As String

    Public Property BUHIN_BANGO As String

    Public Property BUHIN_NAME As String

    Public Property GOKI As String

    Public Property SYANAI_CD As String

    Public Property FUTEKIGO_KB As String

    Public Property FUTEKIGO_NAME As String

    Public Property FUTEKIGO_S_KB As String

    Public Property FUTEKIGO_S_NAME As String

    Public Property FUTEKIGO_JYOTAI_KB As String

    Public Property FUTEKIGO_JYOTAI_NAME As String

    Public Property JIZEN_SINSA_HANTEI_KB As String

    Public Property JIZEN_SINSA_HANTEI_NAME As String

    Public Property ZESEI_SYOCHI_YOHI_KB As String

    Public Property ZESEI_SYOCHI_YOHI_NAME As String

    Public Property SAISIN_IINKAI_HANTEI_KB As String

    Public Property SAISIN_IINKAI_HANTEI_NAME As String

    Public Property KENSA_KEKKA_KB As String

    Public Property KENSA_KEKKA_NAME As String

    Public Property KONPON_YOIN_KB1 As String

    Public Property KONPON_YOIN_NAME1 As String

    Public Property KONPON_YOIN_KB2 As String

    Public Property KONPON_YOIN_NAME2 As String

    Public Property KISEKI_KOTEI_KB As String

    Public Property KISEKI_KOTEI_NAME As String

    Public Property SYOCHI_YOTEI_YMD As String

    Public Property KISO_YMD As String

    Public Property KISO_TANTO_ID As Integer

    Public Property KISO_TANTO_NAME As String

    Public Property CLOSE_FG As String

    Public Property SASIMOTO_SYONIN_JUN As Integer

    Public Property SASIMOTO_SYONIN_NAIYO As String

    Public Property RIYU As String

    Public Property YOKYU_NAIYO As String

    Public Property KANSATU_KEKKA As String

    Public Property BUMON_KB As String

    Public Property BUMON_NAME As String

    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    Public Property DEL_YMDHNS As String

    Public Property HASSEI_YMD As String

    Public Property SURYO As Integer

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