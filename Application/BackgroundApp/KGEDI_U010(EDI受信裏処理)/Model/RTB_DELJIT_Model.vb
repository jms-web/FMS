''' <summary>
''' RTB_DELJIT(納入指示データ)モデル
''' </summary>
''' <remarks></remarks>
Public Class RTB_DELJIT_Model

#Region "変数・定数"
    Public Const FieldsCount As Integer = 89
    Public Const SourceTableName As String = "RTB_DELJIT"

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
    Public Const ITEM_010_LEN As Integer = 10
    Public Const ITEM_011_LEN As Integer = 5
    Public Const ITEM_012_LEN As Integer = 5
    Public Const ITEM_013_LEN As Integer = 10
    Public Const ITEM_014_LEN As Integer = 5
    Public Const ITEM_015_LEN As Integer = 5
    Public Const ITEM_016_LEN As Integer = 25
    Public Const ITEM_017_LEN As Integer = 25
    Public Const ITEM_018_LEN As Integer = 20
    Public Const ITEM_019_LEN As Integer = 12
    Public Const ITEM_020_LEN As Integer = 20
    Public Const ITEM_021_LEN As Integer = 12
    Public Const ITEM_022_LEN As Integer = 20
    Public Const ITEM_023_LEN As Integer = 12
    Public Const ITEM_024_LEN As Integer = 12
    Public Const ITEM_025_LEN As Integer = 25
    Public Const ITEM_026_LEN As Integer = 10
    Public Const ITEM_027_LEN As Integer = 8
    Public Const ITEM_028_LEN As Integer = 3
    Public Const ITEM_029_LEN As Integer = 8
    Public Const ITEM_030_LEN As Integer = 8
    Public Const ITEM_031_LEN As Integer = 30
    Public Const ITEM_032_LEN As Integer = 35
    Public Const ITEM_033_LEN As Integer = 10
    Public Const ITEM_034_LEN As Integer = 12
    Public Const ITEM_035_LEN As Integer = 2
    Public Const ITEM_036_LEN As Integer = 2
    Public Const ITEM_037_LEN As Integer = 1
    Public Const ITEM_038_LEN As Integer = 1
    Public Const ITEM_039_LEN As Integer = 12
    Public Const ITEM_040_LEN As Integer = 1
    Public Const ITEM_041_LEN As Integer = 12
    Public Const ITEM_042_LEN As Integer = 12
    Public Const ITEM_043_LEN As Integer = 2
    Public Const ITEM_044_LEN As Integer = 10
    Public Const ITEM_045_LEN As Integer = 8
    Public Const ITEM_046_LEN As Integer = 4
    Public Const ITEM_047_LEN As Integer = 13
    Public Const ITEM_048_LEN As Integer = 17
    Public Const ITEM_049_LEN As Integer = 8
    Public Const ITEM_050_LEN As Integer = 1
    Public Const ITEM_051_LEN As Integer = 17
    Public Const ITEM_052_LEN As Integer = 1
    Public Const ITEM_053_LEN As Integer = 8
    Public Const ITEM_054_LEN As Integer = 2
    Public Const ITEM_055_LEN As Integer = 20
    Public Const ITEM_056_LEN As Integer = 20
    Public Const ITEM_057_LEN As Integer = 20
    Public Const ITEM_058_LEN As Integer = 5
    Public Const ITEM_059_LEN As Integer = 6
    Public Const ITEM_060_LEN As Integer = 12
    Public Const ITEM_061_LEN As Integer = 22
    Public Const ITEM_062_LEN As Integer = 2
    Public Const ITEM_063_LEN As Integer = 20
    Public Const ITEM_064_LEN As Integer = 20
    Public Const ITEM_065_LEN As Integer = 20
    Public Const ITEM_066_LEN As Integer = 20
    Public Const ITEM_067_LEN As Integer = 20
    Public Const ITEM_068_LEN As Integer = 2
    Public Const ITEM_069_LEN As Integer = 178
    Public Const ITEM_070_LEN As Integer = 16
    Public Const ITEM_071_LEN As Integer = 24
    Public Const ITEM_072_LEN As Integer = 16
    Public Const ITEM_073_LEN As Integer = 24
    Public Const ITEM_074_LEN As Integer = 16
    Public Const ITEM_075_LEN As Integer = 24
    Public Const ITEM_076_LEN As Integer = 16
    Public Const ITEM_077_LEN As Integer = 24
    Public Const ITEM_078_LEN As Integer = 16
    Public Const ITEM_079_LEN As Integer = 3
    Public Const ITEM_080_LEN As Integer = 100
    Public Const ITEM_081_LEN As Integer = 40
    Public Const ITEM_082_LEN As Integer = 40
    Public Const ITEM_083_LEN As Integer = 40
    Public Const ITEM_084_LEN As Integer = 40
    Public Const ITEM_085_LEN As Integer = 70
    Public Const ITEM_086_LEN As Integer = 8
    Public Const ITEM_087_LEN As Integer = 14
    Public Const ITEM_088_LEN As Integer = 14
    Public Const ITEM_089_LEN As Integer = 134

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
    Public Const ITEM_008_NM As String = "HACHU_MOTO_TKS_CD"
    Public Const ITEM_009_NM As String = "HACHU_MOTO_KOU_CD"
    Public Const ITEM_010_NM As String = "NOU_TKS_CD"
    Public Const ITEM_011_NM As String = "NOU_KOU_CD"
    Public Const ITEM_012_NM As String = "NOU_BA"
    Public Const ITEM_013_NM As String = "SYUKKA_TKS_CD"
    Public Const ITEM_014_NM As String = "SYUKKA_KOU_CD"
    Public Const ITEM_015_NM As String = "SYUKKA_BA"
    Public Const ITEM_016_NM As String = "BUHIN_NO"
    Public Const ITEM_017_NM As String = "BUHIN_KB"
    Public Const ITEM_018_NM As String = "HACHU_MOTO_TKS_NM"
    Public Const ITEM_019_NM As String = "HACHU_MOTO_KOU_NM"
    Public Const ITEM_020_NM As String = "NOU_TKS_NM"
    Public Const ITEM_021_NM As String = "NOU_KOU_NM"
    Public Const ITEM_022_NM As String = "SYUKKA_TKS_NM"
    Public Const ITEM_023_NM As String = "SYUKKA_KOU_NM"
    Public Const ITEM_024_NM As String = "SYUKKA_BA_NM"
    Public Const ITEM_025_NM As String = "HINBAN"
    Public Const ITEM_026_NM As String = "SEBN"
    Public Const ITEM_027_NM As String = "SYUYOU_SU"
    Public Const ITEM_028_NM As String = "SU_TANI"
    Public Const ITEM_029_NM As String = "NSGT_CD"
    Public Const ITEM_030_NM As String = "HOUSOUTANI_SU"
    Public Const ITEM_031_NM As String = "HINMEI"
    Public Const ITEM_032_NM As String = "BUHIN_CLR"
    Public Const ITEM_033_NM As String = "SUPLY_KOU"
    Public Const ITEM_034_NM As String = "TEHAI_TANTO"
    Public Const ITEM_035_NM As String = "GENPIN_SIZE"
    Public Const ITEM_036_NM As String = "HAKKOU_SIJI_KB"
    Public Const ITEM_037_NM As String = "GYOUMU_KB"
    Public Const ITEM_038_NM As String = "TEIKI_KB"
    Public Const ITEM_039_NM As String = "TEIKI_NM"
    Public Const ITEM_040_NM As String = "NOU_HOU_CD"
    Public Const ITEM_041_NM As String = "NOU_HOU_NM"
    Public Const ITEM_042_NM As String = "NOU_SIJI_YMD"
    Public Const ITEM_043_NM As String = "BIN_NO"
    Public Const ITEM_044_NM As String = "YUSOU_KB"
    Public Const ITEM_045_NM As String = "NOUHIN_NO"
    Public Const ITEM_046_NM As String = "NOUHIN_MEISAI_NO"
    Public Const ITEM_047_NM As String = "NOU_SIJI_NO"
    Public Const ITEM_048_NM As String = "NOU_SIJI_MEISAI_NO"
    Public Const ITEM_049_NM As String = "NOUNYU_SU"
    Public Const ITEM_050_NM As String = "HASU_KB"
    Public Const ITEM_051_NM As String = "KANBAN_KBNO"
    Public Const ITEM_052_NM As String = "UTIKIRI_KB"
    Public Const ITEM_053_NM As String = "UTIKIRI_ZANSU"
    Public Const ITEM_054_NM As String = "ATO_KOU_1_PTN_NO"
    Public Const ITEM_055_NM As String = "ATO_KOU_1_1"
    Public Const ITEM_056_NM As String = "ATO_KOU_1_2"
    Public Const ITEM_057_NM As String = "ATO_KOU_1_3"
    Public Const ITEM_058_NM As String = "ATO_KOU_1_4"
    Public Const ITEM_059_NM As String = "ATO_KOU_1_5"
    Public Const ITEM_060_NM As String = "ATO_KOU_1_6"
    Public Const ITEM_061_NM As String = "ATO_KOU_1_7"
    Public Const ITEM_062_NM As String = "ATO_KOU_2_PTN_NO"
    Public Const ITEM_063_NM As String = "ATO_KOU_2_1"
    Public Const ITEM_064_NM As String = "ATO_KOU_2_2"
    Public Const ITEM_065_NM As String = "ATO_KOU_2_3"
    Public Const ITEM_066_NM As String = "ATO_KOU_2_4"
    Public Const ITEM_067_NM As String = "ATO_KOU_2_5"
    Public Const ITEM_068_NM As String = "ATO_KOU_3_PTN_NO"
    Public Const ITEM_069_NM As String = "ATO_KOU_3_1"
    Public Const ITEM_070_NM As String = "ATO_KOU_3_2"
    Public Const ITEM_071_NM As String = "ATO_KOU_3_3"
    Public Const ITEM_072_NM As String = "ATO_KOU_3_4"
    Public Const ITEM_073_NM As String = "ATO_KOU_3_5"
    Public Const ITEM_074_NM As String = "ATO_KOU_3_6"
    Public Const ITEM_075_NM As String = "ATO_KOU_3_7"
    Public Const ITEM_076_NM As String = "ATO_KOU_3_8"
    Public Const ITEM_077_NM As String = "ATO_KOU_3_9"
    Public Const ITEM_078_NM As String = "ATO_KOU_3_10"

    Public Const ITEM_079_NM As String = "ATO_KOU_3_QR_DEGIT"
    Public Const ITEM_080_NM As String = "ATO_KOU_4"
    Public Const ITEM_081_NM As String = "NOU_MAKER_HEADER_1"
    Public Const ITEM_082_NM As String = "NOU_MAKER_HEADER_2"
    Public Const ITEM_083_NM As String = "NOU_MAKER_HEADER_3"
    Public Const ITEM_084_NM As String = "NOU_MAKER_HEADER_4"
    Public Const ITEM_085_NM As String = "NOU_MAKER_DETAIL"
    Public Const ITEM_086_NM As String = "HAKKOU_YMD"
    Public Const ITEM_087_NM As String = "SYR_YMDHNS"
    Public Const ITEM_088_NM As String = "SYR_NO"
    Public Const ITEM_089_NM As String = "BRANK_SPACE"


#End Region

#End Region

#Region "メンバ"

    Public Property prITEM_000_1 As String
    Public Property prITEM_000_2 As String
    Public Property prITEM_000_3 As String

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
    Public Property prITEM_040 As String
    Public Property prITEM_041 As String
    Public Property prITEM_042 As String
    Public Property prITEM_043 As String
    Public Property prITEM_044 As String
    Public Property prITEM_045 As String
    Public Property prITEM_046 As String
    Public Property prITEM_047 As String
    Public Property prITEM_048 As String
    Public Property prITEM_049 As String
    Public Property prITEM_050 As String
    Public Property prITEM_051 As String
    Public Property prITEM_052 As String
    Public Property prITEM_053 As String
    Public Property prITEM_054 As String
    Public Property prITEM_055 As String
    Public Property prITEM_056 As String
    Public Property prITEM_057 As String
    Public Property prITEM_058 As String
    Public Property prITEM_059 As String
    Public Property prITEM_060 As String
    Public Property prITEM_061 As String
    Public Property prITEM_062 As String
    Public Property prITEM_063 As String
    Public Property prITEM_064 As String
    Public Property prITEM_065 As String
    Public Property prITEM_066 As String
    Public Property prITEM_067 As String
    Public Property prITEM_068 As String
    Public Property prITEM_069 As String
    Public Property prITEM_070 As String
    Public Property prITEM_071 As String
    Public Property prITEM_072 As String
    Public Property prITEM_073 As String
    Public Property prITEM_074 As String
    Public Property prITEM_075 As String
    Public Property prITEM_076 As String
    Public Property prITEM_077 As String
    Public Property prITEM_078 As String
    Public Property prITEM_079 As String
    Public Property prITEM_080 As String
    Public Property prITEM_081 As String
    Public Property prITEM_082 As String
    Public Property prITEM_083 As String
    Public Property prITEM_084 As String
    Public Property prITEM_085 As String
    Public Property prITEM_086 As String
    Public Property prITEM_087 As String
    Public Property prITEM_088 As String
    Public Property prITEM_089 As String
    
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
                .Add(ITEM_040_LEN)
                .Add(ITEM_041_LEN)
                .Add(ITEM_042_LEN)
                .Add(ITEM_043_LEN)
                .Add(ITEM_044_LEN)
                .Add(ITEM_045_LEN)
                .Add(ITEM_046_LEN)
                .Add(ITEM_047_LEN)
                .Add(ITEM_048_LEN)
                .Add(ITEM_049_LEN)
                .Add(ITEM_050_LEN)
                .Add(ITEM_051_LEN)
                .Add(ITEM_052_LEN)
                .Add(ITEM_053_LEN)
                .Add(ITEM_054_LEN)
                .Add(ITEM_055_LEN)
                .Add(ITEM_056_LEN)
                .Add(ITEM_057_LEN)
                .Add(ITEM_058_LEN)
                .Add(ITEM_059_LEN)
                .Add(ITEM_060_LEN)
                .Add(ITEM_061_LEN)
                .Add(ITEM_062_LEN)
                .Add(ITEM_063_LEN)
                .Add(ITEM_064_LEN)
                .Add(ITEM_065_LEN)
                .Add(ITEM_066_LEN)
                .Add(ITEM_067_LEN)
                .Add(ITEM_068_LEN)
                .Add(ITEM_069_LEN)
                .Add(ITEM_070_LEN)
                .Add(ITEM_071_LEN)
                .Add(ITEM_072_LEN)
                .Add(ITEM_073_LEN)
                .Add(ITEM_074_LEN)
                .Add(ITEM_075_LEN)
                .Add(ITEM_076_LEN)
                .Add(ITEM_077_LEN)
                .Add(ITEM_078_LEN)
                .Add(ITEM_079_LEN)
                .Add(ITEM_080_LEN)
                .Add(ITEM_081_LEN)
                .Add(ITEM_082_LEN)
                .Add(ITEM_083_LEN)
                .Add(ITEM_084_LEN)
                .Add(ITEM_085_LEN)
                .Add(ITEM_086_LEN)
                .Add(ITEM_087_LEN)
                .Add(ITEM_088_LEN)
                .Add(ITEM_089_LEN)
            End With

            Return intList.ToArray

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    Public Shared Function REC_LEN() As Integer
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
                .Add(ITEM_040_LEN)
                .Add(ITEM_041_LEN)
                .Add(ITEM_042_LEN)
                .Add(ITEM_043_LEN)
                .Add(ITEM_044_LEN)
                .Add(ITEM_045_LEN)
                .Add(ITEM_046_LEN)
                .Add(ITEM_047_LEN)
                .Add(ITEM_048_LEN)
                .Add(ITEM_049_LEN)
                .Add(ITEM_050_LEN)
                .Add(ITEM_051_LEN)
                .Add(ITEM_052_LEN)
                .Add(ITEM_053_LEN)
                .Add(ITEM_054_LEN)
                .Add(ITEM_055_LEN)
                .Add(ITEM_056_LEN)
                .Add(ITEM_057_LEN)
                .Add(ITEM_058_LEN)
                .Add(ITEM_059_LEN)
                .Add(ITEM_060_LEN)
                .Add(ITEM_061_LEN)
                .Add(ITEM_062_LEN)
                .Add(ITEM_063_LEN)
                .Add(ITEM_064_LEN)
                .Add(ITEM_065_LEN)
                .Add(ITEM_066_LEN)
                .Add(ITEM_067_LEN)
                .Add(ITEM_068_LEN)
                .Add(ITEM_069_LEN)
                .Add(ITEM_070_LEN)
                .Add(ITEM_071_LEN)
                .Add(ITEM_072_LEN)
                .Add(ITEM_073_LEN)
                .Add(ITEM_074_LEN)
                .Add(ITEM_075_LEN)
                .Add(ITEM_076_LEN)
                .Add(ITEM_077_LEN)
                .Add(ITEM_078_LEN)
                .Add(ITEM_079_LEN)
                .Add(ITEM_080_LEN)
                .Add(ITEM_081_LEN)
                .Add(ITEM_082_LEN)
                .Add(ITEM_083_LEN)
                .Add(ITEM_084_LEN)
                .Add(ITEM_085_LEN)
                .Add(ITEM_086_LEN)
                .Add(ITEM_087_LEN)
                .Add(ITEM_088_LEN)
                .Add(ITEM_089_LEN)
            End With

            Return intList.Sum

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
                .Add(ITEM_040_NM)
                .Add(ITEM_041_NM)
                .Add(ITEM_042_NM)
                .Add(ITEM_043_NM)
                .Add(ITEM_044_NM)
                .Add(ITEM_045_NM)
                .Add(ITEM_046_NM)
                .Add(ITEM_047_NM)
                .Add(ITEM_048_NM)
                .Add(ITEM_049_NM)
                .Add(ITEM_050_NM)
                .Add(ITEM_051_NM)
                .Add(ITEM_052_NM)
                .Add(ITEM_053_NM)
                .Add(ITEM_054_NM)
                .Add(ITEM_055_NM)
                .Add(ITEM_056_NM)
                .Add(ITEM_057_NM)
                .Add(ITEM_058_NM)
                .Add(ITEM_059_NM)
                .Add(ITEM_060_NM)
                .Add(ITEM_061_NM)
                .Add(ITEM_062_NM)
                .Add(ITEM_063_NM)
                .Add(ITEM_064_NM)
                .Add(ITEM_065_NM)
                .Add(ITEM_066_NM)
                .Add(ITEM_067_NM)
                .Add(ITEM_068_NM)
                .Add(ITEM_069_NM)
                .Add(ITEM_070_NM)
                .Add(ITEM_071_NM)
                .Add(ITEM_072_NM)
                .Add(ITEM_073_NM)
                .Add(ITEM_074_NM)
                .Add(ITEM_075_NM)
                .Add(ITEM_076_NM)
                .Add(ITEM_077_NM)
                .Add(ITEM_078_NM)
                .Add(ITEM_079_NM)
                .Add(ITEM_080_NM)
                .Add(ITEM_081_NM)
                .Add(ITEM_082_NM)
                .Add(ITEM_083_NM)
                .Add(ITEM_084_NM)
                .Add(ITEM_085_NM)
                .Add(ITEM_086_NM)
                .Add(ITEM_087_NM)
                .Add(ITEM_088_NM)
                .Add(ITEM_089_NM)

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
                .prITEM_040 = data(39)
                .prITEM_041 = data(40)
                .prITEM_042 = data(41)
                .prITEM_043 = data(42)
                .prITEM_044 = data(43)
                .prITEM_045 = data(44)
                .prITEM_046 = data(45)
                .prITEM_047 = data(46)
                .prITEM_048 = data(47)
                .prITEM_049 = data(48)
                .prITEM_050 = data(49)
                .prITEM_051 = data(50)
                .prITEM_052 = data(51)
                .prITEM_053 = data(52)
                .prITEM_054 = data(53)
                .prITEM_055 = data(54)
                .prITEM_056 = data(55)
                .prITEM_057 = data(56)
                .prITEM_058 = data(57)
                .prITEM_059 = data(58)
                .prITEM_060 = data(59)
                .prITEM_061 = data(60)
                .prITEM_062 = data(61)
                .prITEM_063 = data(62)
                .prITEM_064 = data(63)
                .prITEM_065 = data(64)
                .prITEM_066 = data(65)
                .prITEM_067 = data(66)
                .prITEM_068 = data(67)
                .prITEM_069 = data(68)
                .prITEM_070 = data(69)
                .prITEM_071 = data(70)
                .prITEM_072 = data(71)
                .prITEM_073 = data(72)
                .prITEM_074 = data(73)
                .prITEM_075 = data(74)
                .prITEM_076 = data(75)
                .prITEM_077 = data(76)
                .prITEM_078 = data(77)
                .prITEM_079 = data(78)
                .prITEM_080 = data(79)
                .prITEM_081 = data(80)
                .prITEM_082 = data(81)
                .prITEM_083 = data(82)
                .prITEM_084 = data(83)
                .prITEM_085 = data(84)
                .prITEM_086 = data(85)
                .prITEM_087 = data(86)
                .prITEM_088 = data(87)
                .prITEM_089 = data(88)

            End With


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        End Try
    End Sub

#End Region

End Class


Public Class RTB_DELJIT_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of String, RTB_DELJIT_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of String, RTB_DELJIT_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of String, RTB_DELJIT_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of String, RTB_DELJIT_Model))
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
