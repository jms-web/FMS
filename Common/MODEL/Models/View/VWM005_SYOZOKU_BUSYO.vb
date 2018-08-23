Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class VWM005_SYOZOKU_BUSYO


    Public Property SYAIN_ID As Integer
    Public Property SIMEI As String
    Public Property SIMEI_KANA As String
    Public Property SYAIN_KB As String
    Public Property SYAIN_KB_DISP As String
    Public Property YAKUSYOKU_KB As String
    Public Property YAKUSYOKU_KB_DISP As String
    Public Property DAIKO_KB As String
    Public Property DAIKO_KB_DISP As String
    Public Property TAISYA_YMD As String
    Public Property BUSYO_ID As Integer
    Public Property SYOZOKU_YUKO_YMD As String
    Public Property BUSYO_KB As String
    Public Property BUSYOKB_DISP As String
    Public Property BUSYO_YUKO_YMD As String
    Public Property BUSYO_NAME As String
    Public Property KENMU_FLG As String
    Public Property KENMU_FLG_DISP As String
    '<Column(NameOf(KENMU_FLG), TypeName:="char")>
    '<Display(AutoGenerateField:=False)>
    'Public Property _KENMU_FLG As String


    '<NotMapped>
    'Public Property KENMU_FLG As Boolean
    '    Get
    '        Return IIf(_KENMU_FLG = "0", False, True)
    '    End Get
    '    Set(value As Boolean)
    '        _KENMU_FLG = IIf(value, "1", "0")
    '        'OnPropertyChanged(NameOf(CLOSE_FG))
    '    End Set
    'End Property

    Public Property ADD_YMDHNS As String
    Public Property ADD_SYAIN_ID As Integer
    Public Property UPD_YMDHNS As String
    Public Property UPD_SYAIN_ID As Integer
    Public Property DEL_YMDHNS As String
    Public Property DEL_SYAIN_ID As Integer
    Public Property DEL_FLG As String

End Class
