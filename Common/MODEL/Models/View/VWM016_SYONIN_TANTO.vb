Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class VWM016_SYONIN_TANTO
    Inherits ModelBase

    <ComponentModel.DisplayName("���F�񍐏�ID")>
    Public Property SYONIN_HOKOKUSYO_ID As Integer

    <ComponentModel.DisplayName("�񍐏�����")>
    Public Property SYONIN_HOKOKUSYO_R_NAME As String

    <ComponentModel.DisplayName("���F��")>
    Public Property SYONIN_JUN As Integer

    <ComponentModel.DisplayName("���F���e��")>
    Public Property SYONIN_NAIYO As String

    <ComponentModel.DisplayName("�Ј�ID")>
    Public Property SYAIN_ID As Integer

    <ComponentModel.DisplayName("�Ј�NO")>
    Public Property SYAIN_NO As String

    <ComponentModel.DisplayName("�Ј���")>
    Public Property SYAIN_NAME As String

    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB As String

    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB_DISP As String

    <ComponentModel.DisplayName("�ǉ�����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <ComponentModel.DisplayName("�ǉ��S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�ǉ��S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

End Class