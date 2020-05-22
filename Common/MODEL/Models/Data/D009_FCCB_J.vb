Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' FCCBメインテーブル
''' </summary>
<Table(NameOf(D009_FCCB_J), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class D009_FCCB_J
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
    Public Property FCCB_NO As String

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
    ''' 議長
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property CM_TANTO As Integer

    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    <ComponentModel.DisplayName("社内コード")>
    Public Property SYANAI_CD As String

    <Required>
    <Column(TypeName:="varchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String


    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部品名称")>
    Public Property BUHIN_NAME As String


    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("インプット文書など")>
    Public Property INPUT_DOC_NO As String


    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(500)>
    <ComponentModel.DisplayName("要求内容")>
    Public Property INPUT_NAIYO As String


    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("適用SNO_時期")>
    Public Property SNO_APPLY_PERIOD_KISO As String

    <Required>
    <Column(TypeName:="nvarchar")>
    <StringLength(100)>
    <ComponentModel.DisplayName("適用SNO_時期")>
    Public Property SNO_APPLY_PERIOD_HENKO_SINGI As String




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