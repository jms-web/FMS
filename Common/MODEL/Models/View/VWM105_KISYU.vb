Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged


<AddINotifyPropertyChangedInterface>
Partial Public Class VWM105_KISYU
    Inherits ModelBase

    <ComponentModel.DisplayName("ã@éÌID")>
    Public Property KISYU_ID As Integer

    <ComponentModel.DisplayName("ïîñÂãÊï™")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("ïîñÂãÊï™")>
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("ã@éÌ")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property KISYU As String

    <ComponentModel.DisplayName("ã@éÌñº")>
    Public Property KISYU_NAME As String

    'ã§í çÄñ⁄------------------------------------
    <ComponentModel.DisplayName("í«â¡ì˙éû")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("í«â¡íSìñID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("í«â¡íSìñé“")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <ComponentModel.DisplayName("çXêVì˙éû")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("çXêVíSìñID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("çXêVíSìñé“")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <ComponentModel.DisplayName("çÌèúì˙éû")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("çÌèúíSìñID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("çÌèúíSìñé“")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <Display(AutoGenerateField:=False)>
    <ComponentModel.DisplayName("çÌèúÉtÉâÉO")>
    Public ReadOnly Property DEL_FLG As Boolean
        Get
            Return Not String.IsNullOrEmpty(DEL_YMDHNS)
        End Get
    End Property
End Class
