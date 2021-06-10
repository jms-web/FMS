Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' 是正処置管理
''' </summary>
<Table(NameOf(D014_ZESEI_RYUSYUTU_J), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D014_ZESEI_RYUSYUTU_J
    Inherits ModelBase

    Public Shadows Sub Clear()

        ADD_SYAIN_ID = 0
        ADD_YMDHNS = ""
        UPD_SYAIN_ID = 0
        UPD_YMDHNS = ""
        DEL_SYAIN_ID = 0
        DEL_YMDHNS = ""

    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(10)>
    Public Property HOKOKU_NO As String

    <Required>
    <Column(TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    ''' <summary>
    ''' クローズフラグ
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(1)>
    <Column(NameOf(CLOSE_FG), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    Public Property _CLOSE_FG As String

    ''' <summary>
    ''' クローズフラグ
    ''' </summary>
    ''' <returns></returns>
    <NotMapped>
    <DoNotNotify>
    Public Property CLOSE_FG As Boolean
        Get
            Return (_CLOSE_FG = "1")
        End Get
        Set(value As Boolean)
            _CLOSE_FG = If(value, "1", "0")

        End Set
    End Property

    ''' <summary>
    ''' 文書区分
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(1)>
    Public Property INPUT_TYPE As String

    ''' <summary>
    ''' 文書番号
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    <ComponentModel.DisplayName("文書番号")>
    Public Property DOC_NO As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("回答希望日")>
    Public Property KAITOU_KIBOU_YMD As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("観察報告事項")>
    Public Property KANSATU_HOUKOKU As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("是正理由")>
    Public Property ZESEI_RIYU As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("是正コメント")>
    Public Property ZESEI_COMMENT As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("回答日")>
    Public Property KAITOU_YMD As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("不適合対象")>
    Public Property FUTEKIGO_TAISYOU As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(200)>
    <ComponentModel.DisplayName("調査範囲")>
    Public Property CHOUSA_HANI As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(FUTEKIGO_UMU), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("不適合有無")>
    Public Property _FUTEKIGO_UMU As String

    <ComponentModel.DisplayName("不適合有無")>
    <NotMapped>
    Public Property FUTEKIGO_UMU As Boolean
        Get
            Return (_FUTEKIGO_UMU = "1")
        End Get
        Set(value As Boolean)
            _FUTEKIGO_UMU = IIf(value, "1", "0")
            'OnPropertyChanged(NameOf(CLOSE_FG))
        End Set
    End Property

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("影響範囲")>
    Public Property EIKYOU_HANI As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("応急処置")>
    Public Property OUKYU_SYOCHI As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("応急処置予定日")>
    Public Property OUKYU_SYOCHI_YOTEI_YMD As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(JINTEKI_YOUIN_UMU), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("人的要因有無")>
    Public Property _JINTEKI_YOUIN_UMU As String

    <ComponentModel.DisplayName("人的要因有無")>
    <NotMapped>
    Public Property JINTEKI_YOUIN_UMU As Boolean
        Get
            Return (_JINTEKI_YOUIN_UMU = "1")
        End Get
        Set(value As Boolean)
            _JINTEKI_YOUIN_UMU = IIf(value, "1", "0")
        End Set
    End Property

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("発生原因")>
    Public Property HASSEI_GENIN As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("是正処置")>
    Public Property ZESEI_SYOCHI As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("是正処置予定日")>
    Public Property ZESEI_SYOCHI_YOTEI_YMD As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("是正処置実施日")>
    Public Property ZESEI_SYOCHI_YMD As String

    <Required>
    <StringLength(8)>
    <ComponentModel.DisplayName("応急処置実施日")>
    Public Property OUKYU_SYOCHI_YMD As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("応急処置結果")>
    Public Property OUKYU_SYOCHI_KEKKA As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("是正処置結果")>
    Public Property ZESEI_SYOCHI_KEKKA As String

    <Required>
    <StringLength(1)>
    <Column(NameOf(ZESEI_SYOCHI_HANTEI), TypeName:="char")>
    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("是正処置有効性判定")>
    Public Property _ZESEI_SYOCHI_HANTEI As String

    <ComponentModel.DisplayName("是正処置有効性判定")>
    <NotMapped>
    Public Property ZESEI_SYOCHI_HANTEI As Boolean
        Get
            Return (_ZESEI_SYOCHI_HANTEI = "1")
        End Get
        Set(value As Boolean)
            _ZESEI_SYOCHI_HANTEI = IIf(value, "1", "0")
        End Set
    End Property

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("是正処置レビュー詳細資料")>
    Public Property ZESEI_SYOCHI_NG_DOC_NO As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料")>
    Public Property FILE_PATH1 As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料")>
    Public Property FILE_PATH2 As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料")>
    Public Property FILE_PATH3 As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料")>
    Public Property FILE_PATH4 As String

    <Required>
    <StringLength(200)>
    <ComponentModel.DisplayName("添付資料")>
    Public Property FILE_PATH5 As String

    <Required>
    <StringLength(400)>
    <ComponentModel.DisplayName("フリースペース")>
    Public Property COMMENT1 As String

    <Required>
    <StringLength(400)>
    <ComponentModel.DisplayName("フリースペース")>
    Public Property COMMENT2 As String

    <Required>
    <StringLength(400)>
    <ComponentModel.DisplayName("フリースペース")>
    Public Property COMMENT3 As String

    <Required>
    <StringLength(400)>
    <ComponentModel.DisplayName("フリースペース")>
    Public Property COMMENT4 As String

    <Required>
    <StringLength(400)>
    <ComponentModel.DisplayName("フリースペース")>
    Public Property COMMENT5 As String

    ''共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property ADD_YMDHNS As String

    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
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

    <Required>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property UPD_YMDHNS As String

    <Required>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(DEL_YMDHNS)
        End Get
    End Property

    <Required>
    Public Property DEL_SYAIN_ID As Integer

End Class