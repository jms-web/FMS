Imports JMS_COMMON.ClsPubMethod
Imports MODEL

Namespace Context
    Public Module mdlConst

#Region "PGアセンブリコード"
        ''' <summary>
        ''' コードマスタ
        ''' </summary>
        Public Const CON_PG_M010 As String = "FMS_M010.exe"


#End Region

#Region "システムコード"

        ''' <summary>
        ''' 自社取引先CD
        ''' </summary>
        Public Const CON_MYCOMPANY_CODE As Integer = 99999

        ''' <summary>
        ''' 属性区分フラグ ビット演算
        ''' </summary>
        <Flags>
        Public Enum ENM_ZOKUSEI_KB
            _1_製品 = 1
            _2_得意先 = 2
            _4_仕入先 = 4
        End Enum

        ''' <summary>
        ''' 見積状況区分
        ''' </summary>
        Public Enum ENM_MITU_STATUS
            _0_見積 = 0
            _1_手配済 = 1
            _2_受入済 = 2
            _3_製造開始 = 3
            _4_完成 = 4
            _5_出荷 = 5
            _6_売上締 = 6
            _8_保留 = 8
            _9_見送 = 9
        End Enum

        ''' <summary>
        ''' 取引種別
        ''' </summary>
        Public Enum ENM_TORI_SYU
            _0_共用 = 0
            _1_得意先 = 1
            _2_仕入先 = 2
        End Enum

        ''' <summary>
        ''' 稼働区分
        ''' </summary>
        Public Enum ENM_KADO
            _0_非稼働 = 0
            _1_稼働 = 1
            _9_非表示 = 9
        End Enum

        ''' <summary>
        ''' 在庫種別
        ''' </summary>
        Public Enum ENM_ZAIKO_SYUBETU
            _0_材料在庫 = 0
            _1_購入品在庫 = 1
            _2_仕掛在庫 = 2
            _3_製品在庫 = 3
        End Enum

        ''' <summary>
        ''' 発注ステータス
        ''' </summary>
        Public Enum ENM_HACCYU_STATUS
            _0_未発注 = 0
            _1_発注済 = 1
            _2_入荷済 = 2
            _9_取消 = 9
        End Enum

        ''' <summary>
        ''' 構成区分
        ''' </summary>
        Public Enum ENM_KOSEI_KB
            _0_材料 = 0
            _1_購入品 = 1
            _2_製品 = 2
            _3_消耗品冶具 = 3
        End Enum
#End Region

#Region "共通"
        Public Enum ENM_BUMON_KB
            _0_経営部 = 0
            _1_業務管理部 = 1
            _2_航空機 = 2
            _3_複合材 = 3
            _4_LP = 4
        End Enum

#End Region

    End Module
End Namespace


Public Module mdlDBContext

#Region "データテーブル変数"

#Region "システム"
    ''' <summary>
    ''' メニューセクション
    ''' </summary>
    Public tblMenuSection As DataTableEx

    ''' <summary>
    ''' コードマスタ項目名
    ''' </summary>
    Public tblKOMO_NM As DataTableEx

    ''' <summary>
    ''' 担当
    ''' </summary>
    Public tblTANTO As DataTableEx

    ''' <summary>
    ''' 要否区分
    ''' </summary>
    Public tblYOHI_KB As DataTableEx
#End Region

#Region "共通"

    ''' <summary>
    ''' 部門
    ''' </summary>
    Public tblBUMON As DataTableEx

    ''' <summary>
    ''' 機種
    ''' </summary>
    Public tblKISYU As DataTableEx

    ''' <summary>
    ''' 部品番号
    ''' </summary>
    Public tblBUHIN As DataTableEx

    ''' <summary>
    ''' 社内CD
    ''' </summary>
    Public tblSYANAI_CD As DataTableEx

#End Region

#Region "不適合関連"

    ''' <summary>
    ''' 製品処置(NCR ステージ
    ''' </summary>
    Public tblNCR As DataTableEx

    ''' <summary>
    ''' 是正処置(CAR ステージ
    ''' </summary>
    Public tblCAR As DataTableEx

    ''' <summary>
    ''' 事前審査判定区分
    ''' </summary>
    Public tblJIZEN_SINSA_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' 再審委員会判定区分
    ''' </summary>
    Public tblSAISIN_IINKAI_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' 不適合区分
    ''' </summary>
    Public tblFUTEKIGO_KB As DataTableEx

    ''' <summary>
    ''' 不適合明細区分
    ''' </summary>
    Public tblFUTEKIGO_S_KB As DataTableEx

    ''' <summary>
    ''' 不適合状態区分
    ''' </summary>
    Public tblFUTEKIGO_STATUS_KB As DataTableEx

    ''' <summary>
    ''' 顧客判定指示区分
    ''' </summary>
    Public tblKOKYAKU_HANTEI_SIJI_KB As DataTableEx

    ''' <summary>
    ''' 顧客最終判定区分
    ''' </summary>
    Public tblKOKYAKU_SAISYU_HANTEI_KB As DataTableEx

    ''' <summary>
    ''' 根本要因区分
    ''' </summary>
    Public tblKONPON_YOIN_KB As DataTableEx

    ''' <summary>
    ''' 帰責工程区分
    ''' </summary>
    Public tblKISEKI_KOUTEI_KB As DataTableEx

    ''' <summary>
    ''' 検査結果区分 合格、不合格
    ''' </summary>
    Public tblKENSA_KEKKA_KB As DataTableEx

    ''' <summary>
    ''' 原因分析区分
    ''' </summary>
    Public tblGENIN_BUNSEKI_KB As DataTableEx

    ''' <summary>
    ''' 承認担当
    ''' </summary>
    Public tblTANTO_SYONIN As DataTableEx

#End Region

#End Region

#Region "データ取得関数"


#Region "部門情報"
    Public Function FunGetBUMON_INFO(ByVal intSyainID As Integer) As (BUMON_KB As String, BUMON_NAME As String)
        Dim dsList As New System.Data.DataSet

        Dim strSQL As String = <sql><![CDATA[
            SELECT
                  M004.SYAIN_ID
                , M004.SYAIN_NO
                , M005.BUSYO_ID
                , M002.BUMON_KB
                ,(SELECT ITEM_DISP FROM M001_SETTING AS M001 WHERE M001.ITEM_NAME='部門区分' AND M001.ITEM_VALUE=M002.BUMON_KB) AS BUMON_NAME
            FROM
                M004_SYAIN AS M004
                LEFT JOIN M005_SYOZOKU_BUSYO AS M005
                    ON M004.SYAIN_ID = M005.SYAIN_ID 
                LEFT JOIN M002_BUSYO AS M002
                    ON M005.BUSYO_ID = M002.BUSYO_ID 
            WHERE M005.KENMU_FLG = '0' AND M004.SYAIN_ID = {0}
            ]]></sql>.Value.Trim

        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(String.Format(strSQL, intSyainID), False)
        End Using
        With dsList.Tables(0)
            If .Rows.Count > 0 Then
                Return (.Rows(0).Item("BUMON_KB"), .Rows(0).Item("BUMON_NAME"))
            Else
                Return ("", "")
            End If
        End With
    End Function
#End Region

#End Region


#Region "データテーブル取得"

    ''' <summary>
    ''' コンボボックス等で使用するコードテーブルを取得する
    ''' </summary>
    ''' <param name="strKOMOKU">コードマスタの項目名または固有のデータセット分類名</param>
    ''' <param name="dt">コードテーブルをセットするデータテーブル</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunGetCodeDataTable(ByVal DB As ClsDbUtility, ByVal strKOMOKU As String, ByRef dt As DataTableEx, Optional ByVal strWhere As String = "", Optional ByVal blnIncludeDeleted As Boolean = True) As Boolean
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim intCNT As Integer

        Try
            dt = New DataTableEx

            Select Case strKOMOKU

#Region "               NCR"
                Case "NCR"
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM014_SYONIN_ROUT) & " ")
                    sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=1")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_JUN")

                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_JUN") & " " & .Rows(intCNT).Item("SYONIN_NAIYO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               CAR"
                Case "CAR"
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM014_SYONIN_ROUT) & " ")
                    sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=2")
                    If strWhere.IsNullOrWhiteSpace = False Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID, SYONIN_JUN")

                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("VALUE") = .Rows(intCNT).Item("SYONIN_JUN")
                            Trow("DISP") = .Rows(intCNT).Item("SYONIN_JUN") & " " & .Rows(intCNT).Item("SYONIN_NAIYO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               担当"
                Case "担当"

                    sbSQL.Append("SELECT * FROM " & NameOf(VWM004_SYAIN) & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYAIN_ID")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("SYOKUBAN", GetType(String))
                    dt.Columns.Add("SYAIN_NO", GetType(String))
                    dt.Columns.Add("SYAIN_KB", GetType(String))
                    dt.Columns.Add("YAKUSYOKU_KB", GetType(String))
                    dt.Columns.Add("DAIKO_KB", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYAIN_NO") = .Rows(intCNT).Item("SYAIN_NO")
                            Trow("SYAIN_KB") = .Rows(intCNT).Item("SYAIN_KB")
                            Trow("YAKUSYOKU_KB") = .Rows(intCNT).Item("YAKUSYOKU_KB")
                            Trow("DAIKO_KB") = .Rows(intCNT).Item("DAIKO_KB")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               承認担当"
                Case "承認担当"

                    sbSQL.Append("SELECT * FROM " & "V001_SYONIN_TANTO" & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
                    dt.Columns.Add("SYONIN_JUN", GetType(Integer))

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("SYONIN_HOKOKUSYO_ID"), dt.Columns("SYONIN_JUN"), dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                            
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               差戻し先"
                Case "差戻し先"
                    sbSQL.Append("SELECT * FROM " & "V003_SYONIN_J_KANRI" & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    'If blnIncludeDeleted = False Then
                    '    sbSQL.Append(" AND DEL_FLG='0'")
                    'End If

                    dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
                    dt.Columns.Add("SYONIN_JUN", GetType(Integer))

                    '主キー設定
                    'dt.PrimaryKey = {dt.Columns("SYONIN_HOKOKUSYO_ID"), dt.Columns("SYONIN_JUN"), dt.Columns("VALUE")}

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                            Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                            Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")

                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               機種"
                Case "機種"
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM105_KISYU) & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY KISYU_ID")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("KISYU", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            Trow("DISP") = .Rows(intCNT).Item("KISYU_NAME")
                            Trow("VALUE") = .Rows(intCNT).Item("KISYU_ID")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("KISYU") = .Rows(intCNT).Item("KISYU")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               社内CD"
                Case "社内CD"
                    '検索
                    sbSQL.Append("SELECT DISTINCT SYANAI_CD,BUHIN_BANGO,BUHIN_NAME,DEL_FLG FROM " & "VWM106_BUHIN" & " ")
                    sbSQL.Append("WHERE BUMON_KB='4'")
                    If strWhere <> "" Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY SYANAI_CD")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("BUHIN_BANGO", GetType(String))
                    dt.Columns.Add("BUHIN_NAME", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("VALUE") = .Rows(intCNT).Item("SYANAI_CD")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("BUHIN_BANGO") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               部品番号"
                Case "部品番号"
                    '検索
                    sbSQL.Append("SELECT DISTINCT BUHIN_BANGO,BUHIN_NAME,SYANAI_CD,DEL_FLG FROM " & "VWM106_BUHIN" & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY BUHIN_BANGO")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("BUHIN_NAME", GetType(String))
                    dt.Columns.Add("SYANAI_CD", GetType(String))

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            Dim Trow As DataRow = dt.NewRow()
                            '
                            Trow("DISP") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("VALUE") = .Rows(intCNT).Item("BUHIN_BANGO")
                            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                            Trow("BUHIN_NAME") = .Rows(intCNT).Item("BUHIN_NAME")
                            Trow("SYANAI_CD") = .Rows(intCNT).Item("SYANAI_CD")
                            dt.Rows.Add(Trow)
                        Next intCNT
                    End With
#End Region
#Region "               temp"
                    'Case "取引先略名"
                    '    '検索
                    '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")

                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" AND DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY TORI_CD")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}

                    '    dt.Columns.Add("SIIRE_GAICYU_KB", GetType(String))
                    '    dt.Columns.Add("SYOKUCHI_FLG", GetType(Boolean))
                    '    dt.Columns.Add("TORI_TANTO_NAME", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            '
                    '            Trow("DISP") = .Rows(intCNT).Item("TORI_R_NAME")
                    '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("SIIRE_GAICYU_KB") = .Rows(intCNT).Item("SIIRE_GAICYU_KB")
                    '            Trow("SYOKUCHI_FLG") = CBool(.Rows(intCNT).Item("SYOKUCHI_FLG"))
                    '            Trow("TORI_TANTO_NAME") = .Rows(intCNT).Item("TORI_TANTO_NAME")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "取引先CD"
                    '    '検索
                    '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" AND DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY TORI_CD")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}

                    '    dt.Columns.Add("TORI_SYU", GetType(String))
                    '    dt.Columns.Add("SIIRE_GAICYU_KB", GetType(String))
                    '    dt.Columns.Add("SYOKUCHI_FLG", GetType(Boolean))
                    '    dt.Columns.Add("TORI_TANTO_NAME", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            '
                    '            Trow("DISP") = .Rows(intCNT).Item("TORI_CD")
                    '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("TORI_SYU") = .Rows(intCNT).Item("TORI_SYU")
                    '            Trow("SIIRE_GAICYU_KB") = .Rows(intCNT).Item("SIIRE_GAICYU_KB")
                    '            Trow("SYOKUCHI_FLG") = CBool(.Rows(intCNT).Item("SYOKUCHI_FLG"))
                    '            Trow("TORI_TANTO_NAME") = .Rows(intCNT).Item("TORI_TANTO_NAME")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "発注先CD"
                    '    '検索
                    '    sbSQL.Append("SELECT * FROM " & NameOf(VWM02_TORIHIKI) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" AND DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY TORI_CD")
                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}

                    '    dt.Columns.Add("TORI_NAME", GetType(String))
                    '    dt.Columns.Add("TORI_CD", GetType(Integer))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("DISP") = .Rows(intCNT).Item("TORI_NAME")
                    '            Trow("VALUE") = .Rows(intCNT).Item("TORI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "職番"
                    '    '検索
                    '    sbSQL.Append("SELECT * FROM " & NameOf(VWM03_TANTO) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" AND DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY TANTO_CD")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}

                    '    dt.Columns.Add("TANTO_CD", GetType(Integer))
                    '    dt.Columns.Add("SYOKUBAN", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            '
                    '            Trow("DISP") = .Rows(intCNT).Item("SYOKUBAN")
                    '            Trow("VALUE") = .Rows(intCNT).Item("SYOKUBAN")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With



                    'Case "カレンダー"

                    '    '検索
                    '    sbSQL.Append("SELECT * FROM " & NameOf(M12_CALENDAR) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & " ")
                    '    End If
                    '    sbSQL.Append(" ORDER BY YYYYMMDD")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}

                    '    dt.Columns.Add("KADO_KBN", GetType(String))
                    '    dt.Columns.Add("H_KANRI_NO", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("DISP") = .Rows(intCNT).Item("YYYYMMDD").ToString
                    '            Trow("VALUE") = .Rows(intCNT).Item("YYYYMMDD").ToString
                    '            Trow("KADO_KBN") = .Rows(intCNT).Item("KADO_KBN").ToString
                    '            Trow("H_KANRI_NO") = .Rows(intCNT).Item("H_KANRI_NO").ToString
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With


                    'Case "属性"

                    '    sbSQL.Append("SELECT *")
                    '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    Else
                    '        sbSQL.Append("WHERE 0=0")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" And DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY DISP_ORDER")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}
                    '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                    '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                    '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                    '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                    '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                    '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                    '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "＊", "")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "属性名"

                    '    sbSQL.Append("SELECT *")
                    '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    Else
                    '        sbSQL.Append("WHERE 0=0")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" And DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY DISP_ORDER")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}
                    '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                    '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                    '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                    '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_NAME")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                    '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                    '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                    '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "＊", "")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "属性項目"

                    '    sbSQL.Append("SELECT *")
                    '    sbSQL.Append(" FROM " & NameOf(VWM16_ZOKUSEI_K) & " ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    Else
                    '        sbSQL.Append("WHERE 0=0")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" And DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY ZOKUSEI_CD, DISP_ORDER")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("ZOKUSEI_CD"), dt.Columns("VALUE")}
                    '    dt.Columns.Add("ZOKUSEI_CD", GetType(Integer))
                    '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    '    dt.Columns.Add("COMP_KEY", GetType(String))

                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_K_NAME")
                    '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_K_NAME")
                    '            Trow("COMP_KEY") = .Rows(intCNT).Item("ZOKUSEI_CD") & "," & .Rows(intCNT).Item("ZOKUSEI_K_CD")
                    '            Trow("ZOKUSEI_CD") = .Rows(intCNT).Item("ZOKUSEI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "属性CD"
                    '    sbSQL.Append("SELECT *")
                    '    sbSQL.Append(" FROM " & NameOf(VWM15_ZOKUSEI) & "() ")
                    '    If strWhere <> "" Then
                    '        sbSQL.Append("WHERE " & strWhere & "")
                    '    Else
                    '        sbSQL.Append("WHERE 0=0")
                    '    End If
                    '    If blnIncludeDeleted = False Then
                    '        sbSQL.Append(" And DEL_FLG='0'")
                    '    End If
                    '    sbSQL.Append(" ORDER BY ZOKUSEI_CD")

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("ZOKUSEI_CD")}
                    '    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    '    dt.Columns.Add("ZOKUSEI_FLG", GetType(Integer))
                    '    dt.Columns.Add("HISSU_FLG", GetType(Boolean))
                    '    dt.Columns.Add("DISPwithHISSU_FLG", GetType(String))


                    '    dsList = DB.GetDataSet(sbSQL.ToString, False)
                    '    With dsList.Tables(0)
                    '        For intCNT = 0 To .Rows.Count - 1
                    '            Dim Trow As DataRow = dt.NewRow()
                    '            Trow("DISP") = .Rows(intCNT).Item("ZOKUSEI_CD")
                    '            Trow("VALUE") = .Rows(intCNT).Item("ZOKUSEI_CD")
                    '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                    '            Trow("DISP_ORDER") = .Rows(intCNT).Item("DISP_ORDER")
                    '            Trow("ZOKUSEI_FLG") = .Rows(intCNT).Item("ZOKUSEI_FLG")
                    '            Trow("HISSU_FLG") = CBool(.Rows(intCNT).Item("HISSU_FLG"))
                    '            Trow("DISPwithHISSU_FLG") = .Rows(intCNT).Item("ZOKUSEI_NAME") & IIf(CBool(.Rows(intCNT).Item("HISSU_FLG")), "＊", "")
                    '            dt.Rows.Add(Trow)
                    '        Next intCNT
                    '    End With

                    'Case "NullTable"

                    '    '空のコードテーブルを作成し、後から項目を追加する際に使用する
                    '    '固有の項目で、コードマスタに登録するほどでもない場合に使う？

                    '    '列追加
                    '    'dataTable.Columns.Add("DISP", GetType(String))
                    '    'dataTable.Columns.Add("VALUE", GetType(String))

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}
                    'Case "BlankTable"

                    '    '主キー設定
                    '    dt.PrimaryKey = {dt.Columns("VALUE")}
                    '    Dim Trow1 As DataRow = dt.NewRow()
                    '    Trow1("VALUE") = " "
                    '    Trow1("DISP") = " "
                    '    dt.Rows.Add(Trow1)

#End Region
#Region "               項目名"
                Case "項目名"
                    '検索
                    sbSQL.Append("SELECT DISTINCT ITEM_NAME,DEL_YMDHNS FROM " & NameOf(M001_SETTING) & " ")
                    If strWhere <> "" Then
                        sbSQL.Append("WHERE " & strWhere)
                    Else
                        sbSQL.Append("WHERE 0=0")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND RTRIM(DEL_YMDHNS)=''")
                    End If
                    sbSQL.Append(" ORDER BY ITEM_NAME")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dsList =
                        DB.GetDataSet(sbSQL.ToString, False)

                    With dsList.Tables(0)
                        For intCNT = 0 To .Rows.Count - 1
                            If dt.Rows.Contains(.Rows(intCNT).Item("ITEM_NAME")) = False Then
                                Dim Trow As DataRow = dt.NewRow()
                                Trow("DISP") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("VALUE") = .Rows(intCNT).Item("ITEM_NAME").ToString
                                Trow("DEL_FLG") = IIf(.Rows(intCNT).Item("DEL_YMDHNS").ToString.Trim = "", False, True)
                                dt.Rows.Add(Trow)
                            End If
                        Next intCNT
                    End With
#End Region
#Region "               Else"
                Case Else

                    '検索
                    sbSQL.Append("SELECT * FROM " & NameOf(VWM001_SETTING) & " WHERE ITEM_NAME='" & strKOMOKU & "'")
                    If strWhere <> "" Then
                        sbSQL.Append(" AND " & strWhere & "")
                    End If
                    If blnIncludeDeleted = False Then
                        sbSQL.Append(" AND DEL_FLG='0'")
                    End If
                    sbSQL.Append(" ORDER BY DISP_ORDER,DEL_FLG")

                    '主キー設定
                    dt.PrimaryKey = {dt.Columns("VALUE")}

                    dt.Columns.Add("DISP_ORDER", GetType(Integer))
                    'dt.Columns.Add("DEF_FLG", GetType(Boolean))

                    dsList = DB.GetDataSet(sbSQL.ToString, True)

                    If dsList IsNot Nothing Then
                        For intCNT = 0 To dsList.Tables(0).Rows.Count - 1
                            With dsList.Tables(0).Rows(intCNT)
                                Dim Trow As DataRow = dt.NewRow()
                                'dataTableにレコードデータを追加
                                Trow("DISP") = .Item("ITEM_DISP")
                                Trow("VALUE") = .Item("ITEM_VALUE")
                                Trow("DEL_FLG") = CBool(.Item("DEL_FLG"))
                                Trow("DISP_ORDER") = Val(.Item("DISP_ORDER"))
                                Trow("DEF_FLG") = CBool(.Item("DEF_FLG"))
                                dt.Rows.Add(Trow)
                            End With
                        Next intCNT
                    Else
                        ' data null exception
                        'Throw New ArgumentNullException("", "")
                    End If
#End Region

            End Select

            'テーブルの変更をコミット
            dt.AcceptChanges()

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False

        Finally
            dsList.Dispose()
        End Try
    End Function
#End Region

End Module







