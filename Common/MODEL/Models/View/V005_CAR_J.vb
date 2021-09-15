Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D003_不適合製品処置報告書情報
''' </summary>
<Table(NameOf(V005_CAR_J), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V005_CAR_J
    Inherits ModelBase
    Implements IDisposable

    Public Shadows Sub Clear()
        HOKOKU_NO = ""
        BUMON_KB = ""
        BUMON_NAME = ""
        CLOSE_FG = False
        SETUMON_1 = ""
        KAITO_1 = ""
        SETUMON_2 = ""
        KAITO_2 = ""
        SETUMON_3 = ""
        KAITO_3 = ""
        SETUMON_4 = ""
        KAITO_4 = ""
        SETUMON_5 = ""
        KAITO_5 = 0
        SETUMON_6 = ""
        KAITO_6 = ""
        SETUMON_7 = ""
        KAITO_7 = ""
        SETUMON_8 = ""
        KAITO_8 = ""
        SETUMON_9 = ""
        KAITO_9 = ""
        SETUMON_10 = ""
        KAITO_10 = 0
        SETUMON_11 = ""
        KAITO_11 = ""
        SETUMON_12 = ""
        KAITO_12 = ""
        SETUMON_13 = ""
        KAITO_13 = ""
        SETUMON_14 = ""
        KAITO_14 = ""
        SETUMON_15 = ""
        KAITO_15 = ""
        SETUMON_16 = ""
        KAITO_16 = ""
        SETUMON_17 = ""
        KAITO_17 = 0
        SETUMON_18 = ""
        KAITO_18 = ""
        SETUMON_19 = ""
        KAITO_19 = ""
        SETUMON_20 = ""
        KAITO_20 = ""
        SETUMON_21 = ""
        KAITO_21 = ""
        SETUMON_22 = ""
        KAITO_22 = ""
        SETUMON_23 = ""
        KAITO_23 = ""
        SETUMON_24 = ""
        KAITO_24 = ""
        SETUMON_25 = ""
        KAITO_25 = ""
        KONPON_YOIN_KB1 = ""
        KONPON_YOIN_NAME1 = ""
        KONPON_YOIN_KB2 = ""
        KONPON_YOIN_NAME2 = ""
        KONPON_YOIN_SYAIN_ID = 0
        KONPON_YOIN_SYAIN_NAME = ""
        KISEKI_KOTEI_KB = ""
        KISEKI_KOTEI_NAME = ""
        SYOCHI_A_SYAIN_ID = 0
        SYOCHI_A_SYAIN_NAME = ""
        SYOCHI_A_YMDHNS = ""
        SYOCHI_B_SYAIN_ID = 0
        SYOCHI_B_SYAIN_NAME = ""
        SYOCHI_B_YMDHNS = ""
        SYOCHI_C_SYAIN_ID = 0
        SYOCHI_C_SYAIN_NAME = ""
        SYOCHI_C_YMDHNS = ""
        KYOIKU_FILE_PATH = ""
        ZESEI_SYOCHI_YUKO_UMU = ""
        ZESEI_SYOCHI_YUKO_UMU_NAME = ""
        SYOSAI_FILE_PATH = ""
        GOKI = ""
        LOT = ""
        KENSA_TANTO_ID = 0
        KENSA_TANTO_NAME = ""
        KENSA_TOROKU_YMDHNS = ""
        KENSA_GL_SYAIN_ID = 0
        KENSA_GL_SYAIN_NAME = ""
        KENSA_GL_YMDHNS = ""
        FILE_PATH1 = ""
        FILE_PATH2 = ""
        FUTEKIGO_HASSEI_YMD = ""

        ADD_SYAIN_ID = 0
        ADD_SYAIN_NAME = ""
        ADD_YMDHNS = ""
        UPD_SYAIN_ID = 0
        UPD_SYAIN_NAME = ""
        UPD_YMDHNS = ""
        DEL_SYAIN_ID = 0
        DEL_SYAIN_NAME = ""
        DEL_YMDHNS = ""

    End Sub

    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    Default Public Property Item(ByVal propertyName As String) As Object
        Get
            Return GetType(V005_CAR_J).GetProperty(propertyName).GetValue(Me)
        End Get
        Set(value As Object)
            GetType(V005_CAR_J).GetProperty(propertyName).SetValue(Me, value)
        End Set
    End Property

    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    <DisplayName("報告書No")>
    Public Property HOKOKU_NO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <DisplayName("部門区分名")>
    Public Property BUMON_NAME As String

    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <ComponentModel.DisplayName("機種")>
    Public Property KISYU As String

    <ComponentModel.DisplayName("機種名")>
    Public Property KISYU_NAME As String

    <DoNotNotify>
    <Required>
    <StringLength(1)>
    <Column(NameOf(CLOSE_FG), TypeName:="char")>
    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("クローズフラグ")>
    Public Property _CLOSE_FG As String

    <ComponentModel.DisplayName("クローズフラグ")>
    <NotMapped>
    <DoNotNotify>
    Public Property CLOSE_FG As Boolean
        Get
            Return (_CLOSE_FG = "1")
        End Get
        Set(value As Boolean)
            _CLOSE_FG = IIf(value, "1", "0")

        End Set
    End Property

#Region "設問内容と回答"

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容1")>
    Public Property SETUMON_1 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答1")>
    Public Property KAITO_1 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容2")>
    Public Property SETUMON_2 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答2")>
    Public Property KAITO_2 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容3")>
    Public Property SETUMON_3 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答3")>
    Public Property KAITO_3 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容4")>
    Public Property SETUMON_4 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答4")>
    Public Property KAITO_4 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容5")>
    Public Property SETUMON_5 As String

    <Required>
    <ComponentModel.DisplayName("設問回答5")>
    Public Property KAITO_5 As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容6")>
    Public Property SETUMON_6 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答6")>
    Public Property KAITO_6 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容7")>
    Public Property SETUMON_7 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答7")>
    Public Property KAITO_7 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容8")>
    Public Property SETUMON_8 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答8")>
    Public Property KAITO_8 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容9")>
    Public Property SETUMON_9 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答9")>
    Public Property KAITO_9 As String

    <Required>
    <ComponentModel.DisplayName("設問内容10")>
    Public Property SETUMON_10 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答10")>
    Public Property KAITO_10 As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容11")>
    Public Property SETUMON_11 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答11")>
    Public Property KAITO_11 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容12")>
    Public Property SETUMON_12 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答12")>
    Public Property KAITO_12 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容13")>
    Public Property SETUMON_13 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答13")>
    Public Property KAITO_13 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容14")>
    Public Property SETUMON_14 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答14")>
    Public Property KAITO_14 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容15")>
    Public Property SETUMON_15 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答15")>
    Public Property KAITO_15 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容16")>
    Public Property SETUMON_16 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答16")>
    Public Property KAITO_16 As String

    <Required>
    <ComponentModel.DisplayName("設問内容17")>
    Public Property SETUMON_17 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答17")>
    Public Property KAITO_17 As Integer

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容18")>
    Public Property SETUMON_18 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答18")>
    Public Property KAITO_18 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容19")>
    Public Property SETUMON_19 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答19")>
    Public Property KAITO_19 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容20")>
    Public Property SETUMON_20 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答20")>
    Public Property KAITO_20 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容21")>
    Public Property SETUMON_21 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答21")>
    Public Property KAITO_21 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容22")>
    Public Property SETUMON_22 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答22")>
    Public Property KAITO_22 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容23")>
    Public Property SETUMON_23 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答23")>
    Public Property KAITO_23 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容24")>
    Public Property SETUMON_24 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答24")>
    Public Property KAITO_24 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("設問内容25")>
    Public Property SETUMON_25 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(150)>
    <ComponentModel.DisplayName("設問回答25")>
    Public Property KAITO_25 As String

#End Region

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("根本要因区分1")>
    Public Property KONPON_YOIN_KB1 As String

    <ComponentModel.DisplayName("根本要因区分1名")>
    Public Property KONPON_YOIN_NAME1 As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("根本要因区分2")>
    Public Property KONPON_YOIN_NAME2 As String

    <ComponentModel.DisplayName("根本要因区分2名")>
    Public Property KONPON_YOIN_KB2 As String

    <ComponentModel.DisplayName("原因内容1")>
    Public Property GENIN_ETC1 As String

    <ComponentModel.DisplayName("原因内容2")>
    Public Property GENIN_ETC2 As String

    <Required>
    <ComponentModel.DisplayName("根本要因社員ID")>
    Public Property KONPON_YOIN_SYAIN_ID As Integer

    <ComponentModel.DisplayName("根本要因社員名")>
    Public Property KONPON_YOIN_SYAIN_NAME As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("帰責工程区分")>
    Public Property KISEKI_KOTEI_KB As String

    <ComponentModel.DisplayName("帰責工程区分名")>
    Public Property KISEKI_KOTEI_NAME As String

    <Required>
    <ComponentModel.DisplayName("処置実施A社員ID")>
    Public Property SYOCHI_A_SYAIN_ID As Integer

    <ComponentModel.DisplayName("処置実施A社員名")>
    Public Property SYOCHI_A_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("処置実施A日時")>
    Public Property SYOCHI_A_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("処置実施B社員ID")>
    Public Property SYOCHI_B_SYAIN_ID As Integer

    <ComponentModel.DisplayName("処置実施B社員名")>
    Public Property SYOCHI_B_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("処置実施B日時")>
    Public Property SYOCHI_B_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("処置実施C社員ID")>
    Public Property SYOCHI_C_SYAIN_ID As Integer

    <ComponentModel.DisplayName("処置実施C社員名")>
    Public Property SYOCHI_C_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("処置実施C日時")>
    Public Property SYOCHI_C_YMDHNS As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("教育記録ファイルパス")>
    Public Property KYOIKU_FILE_PATH As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(2)>
    <ComponentModel.DisplayName("是正処置有効性有無")>
    Public Property ZESEI_SYOCHI_YUKO_UMU As String

    <ComponentModel.DisplayName("是正処置有効性有無")>
    Public Property ZESEI_SYOCHI_YUKO_UMU_NAME As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("詳細資料Noファイルパス")>
    Public Property SYOSAI_FILE_PATH As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(5)>
    <ComponentModel.DisplayName("号機")>
    Public Property GOKI As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(15)>
    <ComponentModel.DisplayName("LOT")>
    Public Property LOT As String

    <Required>
    <ComponentModel.DisplayName("検査社員ID")>
    Public Property KENSA_TANTO_ID As Integer

    <ComponentModel.DisplayName("検査社員名")>
    Public Property KENSA_TANTO_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("検査社員登録日時")>
    Public Property KENSA_TOROKU_YMDHNS As String

    <Required>
    <ComponentModel.DisplayName("検査GL社員ID")>
    Public Property KENSA_GL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("検査GL社員名")>
    Public Property KENSA_GL_SYAIN_NAME As String

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("検査GL社員登録日時")>
    Public Property KENSA_GL_YMDHNS As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料1パス")>
    Public Property FILE_PATH1 As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料2パス")>
    Public Property FILE_PATH2 As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("不適合発生日")>
    Public Property FUTEKIGO_HASSEI_YMD As String

    <Required>
    <StringLength(8)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("次回製作予定日")>
    Public Property SYOCHI_YOTEI_YMD As String

    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("追加日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <DoNotNotify>
    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

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

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("削除日時")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除フラグ")>
    <ComponentModel.DataAnnotations.Display(AutoGenerateField:=False)>
    <NotMapped>
    <DoNotNotify>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
        End Get
    End Property

    <ComponentModel.DisplayName("削除担当ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("削除担当者")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <ComponentModel.DisplayName("CAR起草入力(10)")>
    Public Property SYONIN_NAME10 As String

    <ComponentModel.DisplayName("CAR起草入力承認日(10)")>
    Public Property SYONIN_YMD10 As String

    <ComponentModel.DisplayName("起草元GL（20）")>
    Public Property SYONIN_NAME20 As String

    <ComponentModel.DisplayName("起草元GL承認日（20）")>
    Public Property SYONIN_YMD20 As String

    <ComponentModel.DisplayName("担当課長（30）")>
    Public Property SYONIN_NAME30 As String

    <ComponentModel.DisplayName("担当課長承認日（30）")>
    Public Property SYONIN_YMD30 As String

    <ComponentModel.DisplayName("生技（40）")>
    Public Property SYONIN_NAME40 As String

    <ComponentModel.DisplayName("生技承認日（40）")>
    Public Property SYONIN_YMD40 As String

    <ComponentModel.DisplayName("設計（50）")>
    Public Property SYONIN_NAME50 As String

    <ComponentModel.DisplayName("設計承認日（50）")>
    Public Property SYONIN_YMD50 As String

    <ComponentModel.DisplayName("検査員（60）")>
    Public Property SYONIN_NAME60 As String

    <ComponentModel.DisplayName("検査員承認日（60）")>
    Public Property SYONIN_YMD60 As String

    <ComponentModel.DisplayName("品証課長（70）")>
    Public Property SYONIN_NAME70 As String

    <ComponentModel.DisplayName("品証課長承認日（70）")>
    Public Property SYONIN_YMD70 As String

    <ComponentModel.DisplayName("担当課長（90）")>
    Public Property SYONIN_NAME90 As String

    <ComponentModel.DisplayName("担当課長承認日（90）")>
    Public Property SYONIN_YMD90 As String

    <ComponentModel.DisplayName("検査員（100）")>
    Public Property SYONIN_NAME100 As String

    <ComponentModel.DisplayName("検査員承認日（100）")>
    Public Property SYONIN_YMD100 As String

    <ComponentModel.DisplayName("品証TL確認（120）")>
    Public Property SYONIN_NAME120 As String

    <ComponentModel.DisplayName("品証TL確認承認日（120）")>
    Public Property SYONIN_YMD120 As String

    <ComponentModel.DisplayName("品証TL確認（130）")>
    Public Property SYONIN_NAME130 As String

    <ComponentModel.DisplayName("品証TL確認承認日（130）")>
    Public Property SYONIN_YMD130 As String

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