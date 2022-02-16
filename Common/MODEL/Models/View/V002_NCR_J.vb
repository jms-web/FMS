Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V002_NCR_J
    Inherits ModelBase
    Implements IDisposable

    Public Shadows Sub Clear()
        ZESEI_SYOCHI_YOHI_KB = "0"
    End Sub

    <StringLength(10)>
    <ComponentModel.DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("部門名")>
    Public Property BUMON_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    '<StringLength(30)>
    '<ComponentModel.DisplayName("機種")>
    'Public Property KISYU As String

    <StringLength(30)>
    <ComponentModel.DisplayName("機種名")>
    Public Property KISYU_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String

    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("部品名称")>
    Public Property BUHIN_NAME As String

    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String

    <ComponentModel.DisplayName("数量")>
    Public Property SURYO As Integer

    <StringLength(10)>
    <ComponentModel.DisplayName("再発")>
    Public Property SAIHATU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("不適合状態区分")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("不適合状態区分名")>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("不適合状態内容")>
    Public Property FUTEKIGO_NAIYO As String

    <ComponentModel.DisplayName("不適合区分")>
    Public Property FUTEKIGO_KB As String

    <ComponentModel.DisplayName("不適合区分名")>
    Public Property FUTEKIGO_NAME As String

    <ComponentModel.DisplayName("不適合詳細区分")>
    Public Property FUTEKIGO_S_KB As String

    <ComponentModel.DisplayName("不適合詳細区分名")>
    Public Property FUTEKIGO_S_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("図面規格")>
    Public Property ZUMEN_KIKAKU As String

    <StringLength(500)>
    <ComponentModel.DisplayName("要求内容")>
    Public Property YOKYU_NAIYO As String

    <StringLength(500)>
    <ComponentModel.DisplayName("観察結果")>
    Public Property KANSATU_KEKKA As String

    <StringLength(1)>
    <ComponentModel.DisplayName("是正処置要否区分")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(100)>
    <ComponentModel.DisplayName("是正処置無理由")>
    Public Property ZESEI_NASI_RIYU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("事前審査判定区分")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <ComponentModel.DisplayName("事前審査社員ID")>
    Public Property JIZEN_SINSA_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("事前審査社員名")>
    Public Property JIZEN_SINSA_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("事前審査日")>
    Public Property JIZEN_SINSA_YMD As String

    <ComponentModel.DisplayName("再審委員確認社員ID")>
    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("再審委員確認社員名")>
    Public Property SAISIN_KAKUNIN_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員確認日")>
    Public Property SAISIN_KAKUNIN_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("再審委員会判定区分")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <ComponentModel.DisplayName("再審委員技術社員ID")>
    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("再審委員技術社員名")>
    Public Property SAISIN_GIJYUTU_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員技術確認日")>
    Public Property SAISIN_GIJYUTU_YMD As String

    <ComponentModel.DisplayName("再審委員品証社員ID")>
    Public Property SAISIN_HINSYO_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("再審委員品証社員名")>
    Public Property SAISIN_HINSYO_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("再審委員品証確認日")>
    Public Property SAISIN_HINSYO_YMD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("再審委員会資料No")>
    Public Property SAISIN_IINKAI_SIRYO_NO As String

    <StringLength(20)>
    <ComponentModel.DisplayName("ITAGNo")>
    Public Property ITAG_NO As String

    <ComponentModel.DisplayName("顧客再審申請担当ID")>
    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("顧客再審申請担当名")>
    Public Property KOKYAKU_SAISIN_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("顧客再審申請日")>
    Public Property KOKYAKU_SAISIN_YMD As String

    <StringLength(200)>
    <ComponentModel.DisplayName("顧客再審申請日")>
    Public Property KOKYAKU_SAISIN_FILEPATH1 As String

    <StringLength(200)>
    <ComponentModel.DisplayName("顧客再審申請日")>
    Public Property KOKYAKU_SAISIN_FILEPATH2 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("顧客判定指示区分")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("顧客判定指示区分名")>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("顧客判定指示日")>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("顧客最終判定区分")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("顧客最終判定区分名")>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("顧客最終判定日")>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("廃却年月日")>
    Public Property HAIKYAKU_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("廃却方法区分")>
    Public Property HAIKYAKU_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("廃却方法区分名")>
    Public Property HAIKYAKU_KB_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("廃却方法内容")>
    Public Property HAIKYAKU_HOUHOU As String

    <ComponentModel.DisplayName("廃却実施者ID")>
    Public Property HAIKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("廃却実施者名")>
    Public Property HAIKYAKU_TANTO_NAME As String

    <StringLength(10)>
    <ComponentModel.DisplayName("再加工指示文書No")>
    Public Property SAIKAKO_SIJI_NO As String

    <ComponentModel.DisplayName("再加工指示フラグ")>
    Public Property SAIKAKO_SIJI_FG As String

    <StringLength(8)>
    <ComponentModel.DisplayName("再加工作業完了日")>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("再加工検査年月日")>
    Public Property SAIKAKO_KENSA_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("検査結果区分")>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("検査結果区分名")>
    Public Property KENSA_KEKKA_NAME As String

    <ComponentModel.DisplayName("生技社員ID")>
    Public Property SEIGI_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("生技社員名")>
    Public Property SEIGI_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("生技確認年月日")>
    Public Property SEIGI_KAKUNIN_YMD As String

    <ComponentModel.DisplayName("製造社員ID")>
    Public Property SEIZO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("製造社員名")>
    Public Property SEIZO_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("製造確認年月日")>
    Public Property SEIZO_KAKUNIN_YMD As String

    <ComponentModel.DisplayName("検査社員ID")>
    Public Property KENSA_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("検査社員名")>
    Public Property KENSA_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("検査確認年月日")>
    Public Property KENSA_KAKUNIN_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("返却年月日")>
    Public Property HENKYAKU_YMD As String

    <StringLength(60)>
    <ComponentModel.DisplayName("返却先")>
    Public Property HENKYAKU_SAKI As String

    <ComponentModel.DisplayName("返却実施者ID")>
    Public Property HENKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("返却実施者名")>
    Public Property HENKYAKU_TANTO_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("返却実施備考")>
    Public Property HENKYAKU_BIKO As String

    <ComponentModel.DisplayName("転用先機種ID")>
    Public Property TENYO_KISYU_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("転用先機種")>
    Public Property TENYO_KISYU_NAME As String

    <StringLength(60)>
    <ComponentModel.DisplayName("転用先部品番号")>
    Public Property TENYO_BUHIN_BANGO As String

    <StringLength(5)>
    <ComponentModel.DisplayName("転用先号機")>
    Public Property TENYO_GOKI As String

    <ComponentModel.DisplayName("転用先LOT")>
    Public Property TENYO_LOT As String

    <StringLength(8)>
    <ComponentModel.DisplayName("転用年月日")>
    Public Property TENYO_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果a")>
    Public Property SYOCHI_KEKKA_A As String

    <StringLength(50)>
    <ComponentModel.DisplayName("処置結果a名")>
    Public Property SYOCHI_KEKKA_A_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果b")>
    Public Property SYOCHI_KEKKA_B As String

    <StringLength(50)>
    <ComponentModel.DisplayName("処置結果b名")>
    Public Property SYOCHI_KEKKA_B_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置結果c")>
    Public Property SYOCHI_KEKKA_C As String

    <StringLength(50)>
    <ComponentModel.DisplayName("処置結果c名")>
    Public Property SYOCHI_KEKKA_C_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置d有無区分")>
    Public Property SYOCHI_D_UMU_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("処置d有無区分名")>
    Public Property SYOCHI_D_UMU_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置d要否区分")>
    Public Property SYOCHI_D_YOHI_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("処置d要否区分名")>
    Public Property SYOCHI_D_YOHI_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("処置d処置記録")>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置e有無区分")>
    Public Property SYOCHI_E_UMU_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("処置e有無区分名")>
    Public Property SYOCHI_E_UMU_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("処置e要否区分")>
    Public Property SYOCHI_E_YOHI_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("処置e要否区分名")>
    Public Property SYOCHI_E_YOHI_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("処置e処置記録")>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String

    <StringLength(200)>
    <ComponentModel.DisplayName("ファイルパス")>
    Public Property FILE_PATH As String

    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス1")>
    Public Property G_FILE_PATH1 As String

    <StringLength(200)>
    <ComponentModel.DisplayName("画像ファイルパス2")>
    Public Property G_FILE_PATH2 As String

    <ComponentModel.DisplayName("発生工程GL確認担当")>
    Public Property HASSEI_KOTEI_GL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("封じ込め報告書起草担当")>
    Public Property FCR_KISO_TANTO_ID As Integer

    <StringLength(14)>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyyMMdd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    <ComponentModel.DisplayName("追加担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("追加担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("更新日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("更新担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("更新担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("発生工程GL年月日")>
    Public Property HASSEI_KOTEI_GL_YMD As String

    <StringLength(30)>
    <ComponentModel.DisplayName("発生工程GL確認担当者")>
    Public Property HASSEI_KOTEI_GL_SYAIN_NAME As String

    <ComponentModel.DisplayName("発生日")>
    Public Property HASSEI_YMD As String

    <ComponentModel.DisplayName("再不適合起草担当者")>
    Public Property SAI_FUTEKIGO_KISO_TANTO_ID As Integer

    ''' <summary>
    ''' 再加工 不合格数
    ''' </summary>
    ''' <returns></returns>
    Public Property SAI_KAKO_NG_SURYO As Integer

    ''' <summary>
    ''' 再加工コメント
    ''' </summary>
    ''' <returns></returns>
    Public Property SAI_KAKO_COMMENT As String

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