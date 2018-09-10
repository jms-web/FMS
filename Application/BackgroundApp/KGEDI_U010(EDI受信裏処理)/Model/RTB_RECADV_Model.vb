''' <summary>
''' RTB_RECADV(受領実績)モデル
''' </summary>
''' <remarks></remarks>
Public Class RTB_RECADV_Model

#Region "変数・定数"
    Public Const FieldsCount As Integer = 39
    Public Const SourceTableName As String = "RTB_RECADV"

#Region "フィールド桁数"
    Public Const ITEM_001_LEN As Integer = 4
    Public Const ITEM_002_LEN As Integer = 3
    Public Const ITEM_003_LEN As Integer = 1
    Public Const ITEM_004_LEN As Integer = 10
    Public Const ITEM_005_LEN As Integer = 5
    Public Const ITEM_006_LEN As Integer = 10
    Public Const ITEM_007_LEN As Integer = 5
    Public Const ITEM_008_LEN As Integer = 10
    Public Const ITEM_009_LEN As Integer = 5
    Public Const ITEM_010_LEN As Integer = 5
    Public Const ITEM_011_LEN As Integer = 10
    Public Const ITEM_012_LEN As Integer = 5
    Public Const ITEM_013_LEN As Integer = 5
    Public Const ITEM_014_LEN As Integer = 10
    Public Const ITEM_015_LEN As Integer = 5
    Public Const ITEM_016_LEN As Integer = 25
    Public Const ITEM_017_LEN As Integer = 25
    Public Const ITEM_018_LEN As Integer = 20
    Public Const ITEM_019_LEN As Integer = 12
    Public Const ITEM_020_LEN As Integer = 20
    Public Const ITEM_021_LEN As Integer = 12
    Public Const ITEM_022_LEN As Integer = 12
    Public Const ITEM_023_LEN As Integer = 30
    Public Const ITEM_024_LEN As Integer = 1
    Public Const ITEM_025_LEN As Integer = 8
    Public Const ITEM_026_LEN As Integer = 2
    Public Const ITEM_027_LEN As Integer = 8
    Public Const ITEM_028_LEN As Integer = 4
    Public Const ITEM_029_LEN As Integer = 13
    Public Const ITEM_030_LEN As Integer = 17
    Public Const ITEM_031_LEN As Integer = 8
    Public Const ITEM_032_LEN As Integer = 8
    Public Const ITEM_033_LEN As Integer = 8
    Public Const ITEM_034_LEN As Integer = 8
    Public Const ITEM_035_LEN As Integer = 3
    Public Const ITEM_036_LEN As Integer = 8
    Public Const ITEM_037_LEN As Integer = 14
    Public Const ITEM_038_LEN As Integer = 14
    Public Const ITEM_039_LEN As Integer = 27
#End Region

#Region "フィールド名"
    Public Const ITEM_000_1NM As String = "FILE_NM"
    Public Const ITEM_000_2NM As String = "RENBAN"
    Public Const ITEM_000_3NM As String = "RECV_YMDHNS"

    Public Const ITEM_001_NM As String = "JO_KB"
    Public Const ITEM_002_NM As String = "MSG_KB"
    Public Const ITEM_003_NM As String = "HENKOU_KB"
    Public Const ITEM_004_NM As String = "HACHU_TKS_CD"
    Public Const ITEM_005_NM As String = "HACHU_KOU_CD"
    Public Const ITEM_006_NM As String = "JUCHU_TKS_CD"
    Public Const ITEM_007_NM As String = "JUCHU_KOU_CD"
    Public Const ITEM_008_NM As String = "NOU_TKS_CD"
    Public Const ITEM_009_NM As String = "NOU_KOU_CD"
    Public Const ITEM_010_NM As String = "NOU_BA"
    Public Const ITEM_011_NM As String = "SYUKKA_TKS_CD"
    Public Const ITEM_012_NM As String = "SYUKKA_KOU_CD"
    Public Const ITEM_013_NM As String = "SYUKKA_BA"
    Public Const ITEM_014_NM As String = "HACHU_MOTO_TKS_CD"
    Public Const ITEM_015_NM As String = "HACHU_MOTO_KOU_CD"
    Public Const ITEM_016_NM As String = "BUHIN_NO"
    Public Const ITEM_017_NM As String = "BUHIN_KB"
    Public Const ITEM_018_NM As String = "NOU_TKS_NM"
    Public Const ITEM_019_NM As String = "NOU_KOU_NM"
    Public Const ITEM_020_NM As String = "SYUKKA_TKS_NM"
    Public Const ITEM_021_NM As String = "SYUKKA_KOU_NM"
    Public Const ITEM_022_NM As String = "SYUKKA_BA_NM"
    Public Const ITEM_023_NM As String = "HINMEI"
    Public Const ITEM_024_NM As String = "GYOUMU_KB"
    Public Const ITEM_025_NM As String = "NOU_SIJI_YMD"
    Public Const ITEM_026_NM As String = "BIN_NO"
    Public Const ITEM_027_NM As String = "NOUHIN_NO"
    Public Const ITEM_028_NM As String = "NOUHIN_MEISAI_NO"
    Public Const ITEM_029_NM As String = "NOU_SIJI_NO"
    Public Const ITEM_030_NM As String = "NOU_SIJI_MEISAI_NO"
    Public Const ITEM_031_NM As String = "NOU_SIJI_SU"
    Public Const ITEM_032_NM As String = "JURYO_YMD"
    Public Const ITEM_033_NM As String = "JURYO_SU"
    Public Const ITEM_034_NM As String = "MINOU_SU"
    Public Const ITEM_035_NM As String = "SU_TANI"
    Public Const ITEM_036_NM As String = "HAKKOU_YMD"
    Public Const ITEM_037_NM As String = "SYR_YMDHNS"
    Public Const ITEM_038_NM As String = "SYR_NO"
    Public Const ITEM_039_NM As String = "BRANK_SPACE"

#End Region

#End Region

#Region "メンバ"
    Public Property prITEM_001 As String
    Public Property prITEM_002 As String
    Public Property prITEM_003 As String
    Public Property prITEM_004 As String
    Public Property prITEM_005 As String
    Public Property prITEM_006 As String
    Public Property prITEM_007 As String
    Public Property prITEM_008 As String
    Public Property prITEM_009 As String
    Public Property prITEM_010 As String
    Public Property prITEM_011 As String
    Public Property prITEM_012 As String
    Public Property prITEM_013 As String
    Public Property prITEM_014 As String
    Public Property prITEM_015 As String
    Public Property prITEM_016 As String
    Public Property prITEM_017 As String
    Public Property prITEM_018 As String
    Public Property prITEM_019 As String
    Public Property prITEM_020 As String
    Public Property prITEM_021 As String
    Public Property prITEM_022 As String
    Public Property prITEM_023 As String
    Public Property prITEM_024 As String
    Public Property prITEM_025 As String
    Public Property prITEM_026 As String
    Public Property prITEM_027 As String
    Public Property prITEM_028 As String
    Public Property prITEM_029 As String
    Public Property prITEM_030 As String
    Public Property prITEM_031 As String
    Public Property prITEM_032 As String
    Public Property prITEM_033 As String
    Public Property prITEM_034 As String
    Public Property prITEM_035 As String
    Public Property prITEM_036 As String
    Public Property prITEM_037 As String
    Public Property prITEM_038 As String
    Public Property prITEM_039 As String
#End Region

#Region "メソッド"

    ''' <summary>
    ''' フィールド列幅の配列を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FieldWidths() As Integer()
        Dim intList As New List(Of Integer)

        Try
            With intList
                .Add(ITEM_001_LEN)
                .Add(ITEM_002_LEN)
                .Add(ITEM_003_LEN)
                .Add(ITEM_004_LEN)
                .Add(ITEM_005_LEN)
                .Add(ITEM_006_LEN)
                .Add(ITEM_007_LEN)
                .Add(ITEM_008_LEN)
                .Add(ITEM_009_LEN)
                .Add(ITEM_010_LEN)
                .Add(ITEM_011_LEN)
                .Add(ITEM_012_LEN)
                .Add(ITEM_013_LEN)
                .Add(ITEM_014_LEN)
                .Add(ITEM_015_LEN)
                .Add(ITEM_016_LEN)
                .Add(ITEM_017_LEN)
                .Add(ITEM_018_LEN)
                .Add(ITEM_019_LEN)
                .Add(ITEM_020_LEN)
                .Add(ITEM_021_LEN)
                .Add(ITEM_022_LEN)
                .Add(ITEM_023_LEN)
                .Add(ITEM_024_LEN)
                .Add(ITEM_025_LEN)
                .Add(ITEM_026_LEN)
                .Add(ITEM_027_LEN)
                .Add(ITEM_028_LEN)
                .Add(ITEM_029_LEN)
                .Add(ITEM_030_LEN)
                .Add(ITEM_031_LEN)
                .Add(ITEM_032_LEN)
                .Add(ITEM_033_LEN)
                .Add(ITEM_034_LEN)
                .Add(ITEM_035_LEN)
                .Add(ITEM_036_LEN)
                .Add(ITEM_037_LEN)
                .Add(ITEM_038_LEN)
                .Add(ITEM_039_LEN)

            End With

            Return intList.ToArray

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' フィールド列名の配列を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FieldNames() As String()
        Dim intList As New List(Of String)

        Try
            With intList
                .Add(ITEM_001_NM)
                .Add(ITEM_002_NM)
                .Add(ITEM_003_NM)
                .Add(ITEM_004_NM)
                .Add(ITEM_005_NM)
                .Add(ITEM_006_NM)
                .Add(ITEM_007_NM)
                .Add(ITEM_008_NM)
                .Add(ITEM_009_NM)
                .Add(ITEM_010_NM)
                .Add(ITEM_011_NM)
                .Add(ITEM_012_NM)
                .Add(ITEM_013_NM)
                .Add(ITEM_014_NM)
                .Add(ITEM_015_NM)
                .Add(ITEM_016_NM)
                .Add(ITEM_017_NM)
                .Add(ITEM_018_NM)
                .Add(ITEM_019_NM)
                .Add(ITEM_020_NM)
                .Add(ITEM_021_NM)
                .Add(ITEM_022_NM)
                .Add(ITEM_023_NM)
                .Add(ITEM_024_NM)
                .Add(ITEM_025_NM)
                .Add(ITEM_026_NM)
                .Add(ITEM_027_NM)
                .Add(ITEM_028_NM)
                .Add(ITEM_029_NM)
                .Add(ITEM_030_NM)
                .Add(ITEM_031_NM)
                .Add(ITEM_032_NM)
                .Add(ITEM_033_NM)
                .Add(ITEM_034_NM)
                .Add(ITEM_035_NM)
                .Add(ITEM_036_NM)
                .Add(ITEM_037_NM)
                .Add(ITEM_038_NM)
                .Add(ITEM_039_NM)

            End With

            Return intList.ToArray

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' データ配列をフィールド変数にセットする
    ''' </summary>
    ''' <param name="data">データ配列</param>
    ''' <remarks></remarks>
    Public Sub SetFields(ByVal data() As String)
        Try
            With Me
                .prITEM_001 = data(0)
                .prITEM_002 = data(1)
                .prITEM_003 = data(2)
                .prITEM_004 = data(3)
                .prITEM_005 = data(4)
                .prITEM_006 = data(5)
                .prITEM_007 = data(6)
                .prITEM_008 = data(7)
                .prITEM_009 = data(8)
                .prITEM_010 = data(9)
                .prITEM_011 = data(10)
                .prITEM_012 = data(11)
                .prITEM_013 = data(12)
                .prITEM_014 = data(13)
                .prITEM_015 = data(14)
                .prITEM_016 = data(15)
                .prITEM_017 = data(16)
                .prITEM_018 = data(17)
                .prITEM_019 = data(18)
                .prITEM_020 = data(19)
                .prITEM_021 = data(20)
                .prITEM_022 = data(21)
                .prITEM_023 = data(22)
                .prITEM_024 = data(23)
                .prITEM_025 = data(24)
                .prITEM_026 = data(25)
                .prITEM_027 = data(26)
                .prITEM_028 = data(27)
                .prITEM_029 = data(28)
                .prITEM_030 = data(29)
                .prITEM_031 = data(30)
                .prITEM_032 = data(31)
                .prITEM_033 = data(32)
                .prITEM_034 = data(33)
                .prITEM_035 = data(34)
                .prITEM_036 = data(35)
                .prITEM_037 = data(36)
                .prITEM_038 = data(37)
                .prITEM_039 = data(38)
            End With


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

End Class


Public Class RTB_RECADV_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of String, RTB_RECADV_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of String, RTB_RECADV_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of String, RTB_RECADV_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of String, RTB_RECADV_Model))
            _Entities = value
        End Set
    End Property

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 最新の受信データ編成情報を読み込みます。
    ''' </summary>
    ''' <param name="DB">接続DB</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal DB As clsDbUtility)
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally

        End Try
    End Sub

#End Region



End Class
