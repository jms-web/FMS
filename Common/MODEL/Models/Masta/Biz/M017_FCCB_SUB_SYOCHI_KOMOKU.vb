Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports PropertyChanged

''' <summary>
''' M017_FCCB_SUB_SYOCHI_KOMOKU
''' </summary>
<Table("M017_FCCB_SUB_SYOCHI_KOMOKU", Schema:="dbo")>
<AddINotifyPropertyChangedInterface>
Partial Public Class M017_FCCB_SUB_SYOCHI_KOMOKU
    Inherits ModelBase

    <Key>
    Public Property ITEM_NO As Integer
    <Required>
    Public Property ITEM_GROUP_NAME As String
    <Required>
    Public Property ITEM_NAME As String
    <Required>
    Public Property TANTO_GYOMU_GROUP_ID As Integer
End Class