Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

''' <summary>
''' M109_部品番号別工程マスタ
''' </summary>
<Table("M109_BUHIN_KOTEI", Schema:="dbo")>
Partial Public Class M109_BUHIN_KOTEI
    <Key>
    <Column(Order:=0, TypeName:="char")>
    <StringLength(1)>
    <ComponentModel.DisplayName("部門区分")>
    Public Property BUMON_KB As String

    <Key>
    <Column(Order:=1)>
    <ComponentModel.DisplayName("得意先CD")>
    Public Property TOKUI_CD As Integer

    <Key>
    <Column(Order:=2, TypeName:="nvarchar")>
    <StringLength(60)>
    <ComponentModel.DisplayName("部品番号")>
    Public Property BUHIN_BANGO As String

    <Key>
    <Column(Order:=3)>
    <ComponentModel.DisplayName("工順")>
    Public Property KOJYUN As Integer

    <Required>
    <ComponentModel.DisplayName("工程ID")>
    Public Property KOTEI_ID As Integer

    <Required>
    <ComponentModel.DisplayName("段取時間")>
    Public Property DANDORI_TIME As Decimal '6.2

    <Required>
    <ComponentModel.DisplayName("加工時間")>
    Public Property KAKO_TIME As Decimal '6.2

    <Required>
    <ComponentModel.DisplayName("リードタイム")>
    Public Property LEAD_TIME As Decimal '6.2

    <Required>
    <ComponentModel.DisplayName("工程計画" & vbCrLf & "優先順位")>'&レベル
    Public Property KOTEI_YUSEN_LEVEL As Integer

    '共通項目------------------------------------
    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property ADD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property ADD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="Char")>
    Public Property UPD_YMDHNS As String

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property UPD_SYAIN_ID As Integer

    <Required>
    <StringLength(14)>
    <Display(AutoGenerateField:=False)>
    <Column(TypeName:="char")>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("削除済")>
    <NotMapped>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return DEL_YMDHNS.Trim <> ""
        End Get
    End Property

    <Required>
    <Display(AutoGenerateField:=False)>
    Public Property DEL_SYAIN_ID As Integer
End Class