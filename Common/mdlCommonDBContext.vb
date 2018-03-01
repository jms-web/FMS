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

    End Module
End Namespace


Public Module mdlDBContext

#Region "データテーブル変数"

    ''' <summary>
    ''' メニューセクション
    ''' </summary>
    Public tblMenuSection As DataTableEx

    ''' <summary>
    ''' コードマスタ項目名
    ''' </summary>
    Public tblKOMO_NM As DataTableEx

    '''' <summary>
    '''' 職番
    '''' </summary>
    'Public tblSYOKUBAN As DataTableEx

    '''' <summary>
    '''' 見積状況区分
    '''' </summary>
    'Public tblMITU_KB As DataTableEx

    '''' <summary>
    '''' 製品区分
    '''' </summary>
    'Public tblSEIHIN_KB As DataTableEx

    '''' <summary>
    '''' 得意先
    '''' </summary>
    'Public tblTOKUI As DataTableEx

    '''' <summary>
    '''' 担当
    '''' </summary>
    'Public tblTANTO As DataTableEx

    '''' <summary>
    '''' 端数処理区分
    '''' </summary>
    'Public tblTAX_HASU_KB As DataTableEx

    '''' <summary>
    '''' 属性
    '''' </summary>
    'Public tblZOKUSEI As DataTableEx

    '''' <summary>
    '''' 属性項目
    '''' </summary>
    'Public tblZOKUSEI_K As DataTableEx

    '''' <summary>
    '''' 属性CD
    '''' </summary>
    'Public tblZOKUSEI_CD As DataTableEx

    '''' <summary>
    '''' 属性名
    '''' </summary>
    'Public tblZOKUSEI_NAME As DataTableEx
    '''' <summary>
    '''' 自支給区分
    '''' </summary>
    'Public tblZISI_KB As DataTableEx

    ''''' <summary>
    ''''' ありなし
    ''''' </summary>
    ''Public tblToF As DataTableEx

    '''' <summary>
    '''' 単位区分
    '''' </summary>
    'Public tblTANI_KBN As DataTableEx

    '''' <summary>
    '''' 仕入外注区分
    '''' </summary>
    'Public tblNAIGAI_KB As DataTableEx

    '''' <summary>
    '''' 取引種別
    '''' </summary>
    'Public tblTORI_SYU As DataTableEx

    '''' <summary>
    '''' 売税区分
    '''' </summary>
    'Public tblURI_KBN As DataTableEx

    '''' <summary>
    '''' 仕税区分
    '''' </summary>
    'Public tblSHI_KBN As DataTableEx

    '''' <summary>
    '''' 役職区分
    '''' </summary>
    'Public tblYAKU_KBN As DataTableEx

    '''' <summary>
    '''' 直間区分
    '''' </summary>
    'Public tblCYOKKAN_KBN As DataTableEx

    '''' <summary>
    '''' 部
    '''' </summary>
    'Public tblBU As DataTableEx

    '''' <summary>
    '''' 課
    '''' </summary>
    'Public tblKA As DataTableEx

    '''' <summary>
    '''' 機械名
    '''' </summary>
    'Public tblKIKAI_NAME As DataTableEx

    '''' <summary>
    '''' 機械メーカー
    '''' </summary>
    'Public tblKIKAI_MAKER As DataTableEx

    '''' <summary>
    '''' 追加工区分
    '''' </summary>
    'Public tblTUIKAKOU_KBN As DataTableEx

    '''' <summary>
    '''' 構成区分
    '''' </summary>
    'Public tblKOUSEI_KBN As DataTableEx

    '''' <summary>
    '''' 管理区分
    '''' </summary>
    'Public tblKANRI_KBN As DataTableEx

    '''' <summary>
    '''' 遊休区分
    '''' </summary>
    'Public tblYUKYU_KBN As DataTableEx

    '''' <summary>
    '''' 取引先略名
    '''' </summary>
    'Public tblTORI_SAKI As DataTableEx

    '''' <summary>
    '''' 取引先CD
    '''' </summary>
    'Public tblTORI_SAKI_CD As DataTableEx

    '''' <summary>
    '''' 製品品番
    '''' </summary>
    'Public tblHINBAN As DataTableEx

    '''' <summary>
    '''' 製品品名
    '''' </summary>
    'Public tblHINMEI As DataTableEx

    '''' <summary>
    '''' 発注先CD
    '''' </summary>
    'Public tblHACYU_CD As DataTableEx

    ''''' <summary>
    ''''' 品番
    ''''' </summary>
    ''Public tblHINBAN As DataTableEx



    '''' <summary>
    '''' 理由CD
    '''' </summary>
    'Public tblRIYU_CD As DataTableEx

    '''' <summary>
    '''' 材質
    '''' </summary>
    'Public tblZAISITU As DataTableEx

    '''' <summary>
    '''' 工程
    '''' </summary>
    'Public tblKOTEI As DataTableEx

    '''' <summary>
    '''' カレンダー
    '''' </summary>
    'Public tblCALENDAR As DataTableEx

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
            '初期化
            dt = New DataTableEx

            Select Case strKOMOKU

                'Case "担当"
                '    '検索
                '    sbSQL.Append("SELECT * FROM " & NameOf(VWM03_TANTO) & " ")
                '    If strWhere <> "" Then
                '        sbSQL.Append("WHERE " & strWhere & "")
                '    End If
                '    If blnIncludeDeleted = False Then
                '        sbSQL.Append(" AND DEL_FLG='0'")
                '    End If
                '    sbSQL.Append(" ORDER BY SYOKUBAN")

                '    '主キー設定
                '    dt.PrimaryKey = {dt.Columns("VALUE")}

                '    dt.Columns.Add("SYOKUBAN", GetType(String))
                '    dt.Columns.Add("TANTO_NAME", GetType(String))

                '    dsList = DB.GetDataSet(sbSQL.ToString, False)

                '    With dsList.Tables(0)
                '        For intCNT = 0 To .Rows.Count - 1
                '            Dim Trow As DataRow = dt.NewRow()
                '            '
                '            Trow("DISP") = .Rows(intCNT).Item("TANTO_NAME")
                '            Trow("VALUE") = .Rows(intCNT).Item("TANTO_CD")
                '            Trow("DEL_FLG") = CBool(.Rows(intCNT).Item("DEL_FLG"))
                '            Trow("SYOKUBAN") = .Rows(intCNT).Item("SYOKUBAN")
                '            Trow("TANTO_NAME") = .Rows(intCNT).Item("TANTO_NAME")
                '            dt.Rows.Add(Trow)
                '        Next intCNT
                '    End With

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

                    dsList = DB.GetDataSet(sbSQL.ToString, False)

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
                        'UNDONE: data null exception
                        'Throw New ArgumentNullException("", "")
                    End If

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







