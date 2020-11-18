Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

''' <summary>
''' D007_不適合封じ込め調査書情報
''' </summary>
<Table(NameOf(V013_FCCB_ICHIRAN), Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class V013_FCCB_ICHIRAN
    Inherits ModelBase

    Public Shadows Sub Clear()



    End Sub

    ''' <summary>
    ''' 報告書No
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Column(TypeName:="varchar")>
    <StringLength(10)>
    Public Property FCCB_NO As String

    <Required>
    Public Property BUMON_KB As String
    <Required>
    Public Property BUMON_NAME As String
    <Required>
    Public Property SYONIN_JUN As Integer
    <Required>
    Public Property SYONIN_NAIYO As String
    <Required>
    Public Property SYONIN_HOKOKUSYO_ID As Integer
    <Required>
    Public Property SYONIN_HOKOKUSYO_NAME As String
    <Required>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String
    <Required>
    Public Property GEN_TANTO_ID As Integer
    <Required>
    Public Property GEN_TANTO_NAME As String
    <Required>
    Public Property SYONIN_YMDHNS As String
    <Required>
    Public Property TAIRYU_NISSU As Integer
    <Required>
    Public Property TAIRYU_FG As String
    <Required>
    Public Property KISYU_ID As Integer
    <Required>
    Public Property KISYU_NAME As String
    <Required>
    Public Property BUHIN_BANGO As String
    <Required>
    Public Property BUHIN_NAME As String
    <Required>
    Public Property SYANAI_CD As String
    <Required>
    Public Property INPUT_DOC_NO As String
    <Required>
    Public Property SNO_APPLY_PERIOD_KISO As String
    <Required>
    Public Property CM_TANTO_NAME As String
    <Required>
    Public Property KISO_YMD As String
    <Required>
    Public Property KISO_TANTO_ID As Integer
    <Required>
    Public Property KISO_TANTO_NAME As String
    <Required>
    Public Property CLOSE_FG As String
    <Required>
    Public Property DEL_YMDHNS As String

End Class