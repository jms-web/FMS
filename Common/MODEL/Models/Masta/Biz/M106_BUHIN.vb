Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports System.Drawing

''' <summary>
''' M106_部品番号マスタ
''' </summary>
<Table("M106_BUHIN", Schema:="dbo")>
Partial Public Class M106_BUHIN
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

    <Required>
    <StringLength(1)>
    <Column("TACHIAI_FLG", TypeName:="Char")>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Public Property _TACHIAI_FLG As String

    <NotMapped>
    <ComponentModel.DisplayName("立会検査フラグ")>
    Public Property TACHIAI_FLG As Boolean
        Get
            Return _TACHIAI_FLG <> "0"
        End Get
        Set(value As Boolean)
            If value Then
                _TACHIAI_FLG = "1"
            Else
                _TACHIAI_FLG = "0"
            End If
        End Set
    End Property

    <Required>
    <ComponentModel.DisplayName("機種ID")>
    Public Property KISYU_ID As Integer

    <Required>
    <StringLength(7)>
    <Column(TypeName:="char")>
    <ComponentModel.DisplayName("色CD")>
    Public Property COLOR_CD As String

    <NotMapped>
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