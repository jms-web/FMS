Imports JMS_COMMON.ClsPubMethod

Module mdlG0010

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0010

    ''' <summary>
    ''' 起動モード(0:通常,1:新規作成)
    ''' </summary>
    Public pub_intOPEN_MODE As Integer

    Public pub_PrSYONIN_HOKOKUSYO_ID As Integer
    Public pub_PrHOKOKU_NO As String

#Region "列挙型"
    ''' <summary>
    ''' 起動モード
    ''' </summary>
    Public Enum ENM_OPEN_MODE As Integer

        ''' <summary>
        ''' 通常モード…検索画面を表示
        ''' </summary>
        _0_通常 = 0

        ''' <summary>
        ''' 新規作成モード…新規登録画面を直接表示、登録後検索画面に戻らず
        ''' </summary>
        _1_新規作成 = 1

        ''' <summary>
        ''' メールリンク等で処置画面へ直接遷移
        ''' </summary>
        _2_処置画面起動 = 2
    End Enum

    Public Enum ENM_SAVE_MODE
        _1_保存 = 1
        _2_承認申請 = 2
    End Enum


    ''' <summary>
    ''' 検査結果区分
    ''' </summary>
    Public Enum ENM_KENSA_KEKKA_KB
        _0_合格 = 0
        _1_不合格 = 1
    End Enum

    ''' <summary>
    ''' NCRステージ
    ''' </summary>
    Public Enum ENM_NCR_STAGE
        _10_起草入力 = 10
        _20_起草確認製造GL = 20
        _30_起草確認検査 = 30
        _40_事前審査判定及びCAR要否判定 = 40
        _50_事前審査確認 = 50
        _60_再審審査判定_技術代表 = 60
        _61_再審審査判定_品証代表 = 61
        _70_顧客再審処置_I_tag = 70
        _80_処置実施 = 80
        _81_処置実施_生技 = 81
        _82_処置実施_製造 = 82
        _83_処置実施_検査 = 83
        _90_処置実施確認_管理T = 90
        _100_処置実施決裁_製造課長 = 100
        _110_abcde処置担当 = 110
        _120_abcde処置確認 = 120
        _999_Closed = 999
    End Enum

    ''' <summary>
    ''' NCRステージrev2
    ''' </summary>
    Public Enum ENM_NCR_STAGE2
        _1_起草入力 = 1
        _2_起草確認製造GL = 2
        _3_起草確認検査 = 3
        _4_事前審査判定及びCAR要否判定 = 4
        _5_事前審査確認 = 5
        _6_再審審査判定_技術代表 = 6
        _7_再審審査判定_品証代表 = 7
        _8_顧客再審処置_I_tag = 8
        _9_処置実施 = 9
        _10_処置実施_生技 = 10
        _11_処置実施_製造 = 11
        _12_処置実施_検査 = 12
        _13_処置実施確認_管理T = 13
        _14_処置実施決裁_製造課長 = 14
        _15_abcde処置担当 = 15
        _16_abcde処置確認 = 16
        _99_Closed = 99
    End Enum

    ''' <summary>
    ''' CARステージ
    ''' </summary>
    Public Enum ENM_CAR_STAGE
        _10_起草入力 = 10
        _20_起草確認_起草元GL = 20
        _30_起草確認_担当課長 = 30
        _40_起草確認_生産技術 = 40
        _50_起草確認_設計開発 = 50
        _60_起草確認_検査員 = 60
        _70_起草確認_品証課長 = 70
        _80_処置実施記録入力 = 80
        _90_処置実施確認 = 90
        _100_是正有効性記入 = 100
        _110_是正有効性確認_検査GL = 110
        _120_是正有効性確認_品証TL = 120
        _130_是正有効性確認_品証担当課長 = 130
        _999_Closed = 999
    End Enum

    ''' <summary>
    ''' CARステージrev2
    ''' </summary>
    Public Enum ENM_CAR_STAGE2
        _1_起草入力 = 1
        _2_起草確認_起草元GL = 2
        _3_起草確認_担当課長 = 3
        _4_起草確認_生産技術 = 4
        _5_起草確認_設計開発 = 5
        _6_起草確認_検査員 = 6
        _7_起草確認_品証課長 = 7
        _8_処置実施記録入力 = 8
        _9_処置実施確認 = 9
        _10_是正有効性記入 = 10
        _11_是正有効性確認_検査GL = 11
        _12_是正有効性確認_品証TL = 12
        _13_是正有効性確認_品証担当課長 = 13
        _99_Closed = 99
    End Enum

    '80 NCR処置実施 タブページ
    Public Enum ENM_NCR_STAGE80_TABPAGES
        _1_廃却実施記録 = 1
        _2_再加工指示_記録 = 2
        _3_返却実施記録 = 3
        _4_転用先記録 = 4
    End Enum

    ''' <summary>
    ''' 原因分析区分
    ''' </summary>
    Public Enum ENM_GENIN_BUNSEKI_KB
        _0_m_マネジメント = 0
        _1_S_ソフトウェア = 1
        _2_h_ハードウェア = 2
        _3_e_作業環境 = 3
        _4_L1_本人 = 4
        _5_L2_関係者_支援体制 = 5
        _11_材料 = 11
        _12_設備_治具 = 12
        _13_方法 = 13
    End Enum

    ''' <summary>
    ''' 根本要因区分
    ''' </summary>
    Public Enum ENM_KONPON_YOIN_KB
        _0_人 = 0
        _1_材料 = 1
        _2_設備治具 = 2
        _3_方法 = 3
    End Enum


    ''' <summary>
    ''' 承認判定区分
    ''' </summary>
    Public Enum ENM_SYONIN_HANTEI_KB
        _0_未承認 = 0
        _1_承認 = 1
        _9_差戻 = 9
    End Enum

    ''' <summary>
    ''' 報告書操作区分
    ''' </summary>
    Public Enum ENM_HOKOKUSYO_SOUSA_KB
        _0_起草 = 0
        _1_申請承認依頼 = 1
        _2_更新保存 = 2
    End Enum

    ''' <summary>
    ''' 事前審査判定区分
    ''' </summary>
    Public Enum ENM_JIZEN_SINSA_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_再審委員会送り = 2
        _3_顧客再審申請 = 3
        _4_廃却する = 4
        _5_返却する = 5
        _6_転用する = 6
        _7_再加工する = 7
    End Enum

    ''' <summary>
    ''' 再審委員会判定区分
    ''' </summary>
    Public Enum ENM_SAISIN_IINKAI_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_顧客再審申請 = 2
        _3_廃却する = 3
        _4_返却する = 4
        _5_転用する = 5
        _6_再加工する = 6
    End Enum

    ''' <summary>
    ''' 顧客最終判定区分
    ''' </summary>
    Public Enum ENM_KOKYAKU_SAISYU_HANTEI_KB
        _0_完成する = 0
        _1_そのまま使用可 = 1
        _2_顧客再審申請 = 2
        _3_廃却する = 3
        _4_返却する = 4
        _5_転用する = 5
        _6_再加工する = 6
    End Enum

    ''' <summary>
    ''' 不適合状態区分
    ''' </summary>
    Public Enum ENM_FUTEKIGO_JYOTAI_KB
        _0_最終製品 = 0
        _1_仕掛品 = 1
        _2_材料 = 2
        _3_返却品 = 3
    End Enum

    ''' <summary>
    ''' 要否区分
    ''' </summary>
    Public Enum ENM_YOHI_KB
        _0_否 = 0
        _1_要 = 1
    End Enum

    ''' <summary>
    ''' 履歴操作区分
    ''' </summary>
    Public Enum ENM_SOUSA_KB
        _0_新規作成 = 0
        _1_申請依頼 = 1
        _2_更新保存 = 2
        _3_承認差戻 = 3
        _4_メール送信 = 4
        _5_転送 = 5
    End Enum


#End Region

#Region "Model"
    Public _D003_NCR_J As New MODEL.D003_NCR_J
    Public _D004_SYONIN_J_KANRI As New MODEL.D004_SYONIN_J_KANRI
    Public _D005_CAR_J As New MODEL.D005_CAR_J
    Public _D006_CAR_GENIN_List As New List(Of MODEL.D006_CAR_GENIN)
    Public _R001_HOKOKU_SOUSA As New MODEL.R001_HOKOKU_SOUSA
    Public _R002_HOKOKU_TENSO As New MODEL.R002_HOKOKU_TENSO
    Public _R003_NCR_SASIMODOSI As New MODEL.R003_NCR_SASIMODOSI
    Public _R004_CAR_SASIMODOSI As New MODEL.R004_CAR_SASIMODOSI
#End Region

#End Region

#Region "MAIN"
    <STAThread()>
    Public Sub Main()
        Try
            '-----二重起動抑制
            Using objMutex = New System.Threading.Mutex(False, My.Application.Info.AssemblyName)
                If objMutex.WaitOne(0, False) = False Then
                    'MsgBox("既に起動されています", MsgBoxStyle.Information, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '----共通初期処理
                If FunINTSYR() = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetCommonInit)
                    Exit Sub
                End If

                '-----PG設定ファイル読込処理
                If FunGetPGIniFile(My.Application.Info.AssemblyName) = False Then
                    WL.WriteLogDat(My.Resources.ErrLogMsgSetPGInit)
                    Exit Sub
                End If

                '-----出力先設定ファイル読込処理
                If FunGetOutputIniFile() = False Then
                    MsgBox(My.Resources.ErrLogMsgSetOutput, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
                    Exit Sub
                End If

                '-----Visualスタイル有効
                Application.EnableVisualStyles()
                '-----GDIを使用
                Application.SetCompatibleTextRenderingDefault(False)

                '-----共通データ取得
                Using DB As ClsDbUtility = DBOpen()
                    Call FunGetCodeDataTable(DB, "NCR", tblNCR)
                    Call FunGetCodeDataTable(DB, "CAR", tblCAR)
                    Call FunGetCodeDataTable(DB, "担当", tblTANTO)
                    Call FunGetCodeDataTable(DB, "部門区分", tblBUMON, "DISP_ORDER < 10") '10以降は不適合SYSでは不要
                    Call FunGetCodeDataTable(DB, "機種", tblKISYU)
                    Call FunGetCodeDataTable(DB, "機種実績", tblKISYU_J)

                    Call FunGetCodeDataTable(DB, "不適合区分", tblFUTEKIGO_KB)
                    Call FunGetCodeDataTable(DB, "不適合状態区分", tblFUTEKIGO_STATUS_KB)
                    Call FunGetCodeDataTable(DB, "事前審査判定区分", tblJIZEN_SINSA_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "再審委員会判定区分", tblSAISIN_IINKAI_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "部品番号", tblBUHIN)
                    Call FunGetCodeDataTable(DB, "部品番号実績", tblBUHIN_J)
                    Call FunGetCodeDataTable(DB, "社内CD", tblSYANAI_CD)
                    Call FunGetCodeDataTable(DB, "社内CD実績", tblSYANAI_CD_J)

                    Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)
                    'Call FunGetCodeDataTable(DB, "承認担当一覧", tblTANTO_SYONINList)
                    Call FunGetCodeDataTable(DB, "顧客判定指示区分", tblKOKYAKU_HANTEI_SIJI_KB)
                    Call FunGetCodeDataTable(DB, "顧客最終判定区分", tblKOKYAKU_SAISYU_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "要否区分", tblYOHI_KB)
                    Call FunGetCodeDataTable(DB, "検査結果区分", tblKENSA_KEKKA_KB)
                    Call FunGetCodeDataTable(DB, "根本要因区分", tblKONPON_YOIN_KB)
                    Call FunGetCodeDataTable(DB, "帰責工程区分", tblKISEKI_KOUTEI_KB)

                    Call FunGetCodeDataTable(DB, "原因分析区分", tblGENIN_BUNSEKI_KB)

                    Call FunGetCodeDataTable(DB, "設問内容", tblSETUMON_NAIYO)
                    Call FunGetCodeDataTable(DB, "承認判定区分", tblSYONIN_HANTEI_KB)
                    Call FunGetCodeDataTable(DB, "廃却方法区分", tblHAIKYAKU_KB)

                End Using

                '起動時パラメータを取得
                Dim cmds() As String
                cmds = System.Environment.GetCommandLineArgs

                If cmds.Length = 5 Then
                    'メールリンク用
                    pub_PrHOKOKU_NO = Val(cmds(4))
                    pub_PrSYONIN_HOKOKUSYO_ID = Val(cmds(3))
                    pub_intOPEN_MODE = Val(cmds(2))
                ElseIf cmds.Length = 3 Then
                    pub_intOPEN_MODE = Val(cmds(2))
                Else
                    pub_intOPEN_MODE = ENM_OPEN_MODE._0_通常
                End If

                '-----一覧画面表示
                frmLIST = New FrmG0010
                Application.Run(frmLIST)
            End Using
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            MsgBox(My.Resources.ErrMsgInit, MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        Finally

        End Try
    End Sub
#End Region

#Region "共通関数"

#Region "値取得等"
    ''' <summary>
    ''' 引数の検索条件を一覧取得ストアドに渡して検索結果のテーブルデータを取得
    ''' </summary>
    ''' <param name="ParamModel"></param>
    ''' <returns></returns>

    Public Function FunGetV002Model(ByVal strHOKOKU_NO As String) As MODEL.V002_NCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V002_NCR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V002_NCR_J
            Dim t As Type = GetType(MODEL.V002_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        _model(p.Name) = .Item(p.Name)
                    End If
                Next p
            End With
            Return _model
        End If
    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As List(Of MODEL.V003_SYONIN_J_KANRI)

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID = " & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Dim t As Type = GetType(MODEL.V003_SYONIN_J_KANRI)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                         Reflection.BindingFlags.Public Or
                         Reflection.BindingFlags.Instance Or
                         Reflection.BindingFlags.Static)

            Dim entities As New List(Of MODEL.V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New MODEL.V003_SYONIN_J_KANRI
                    For Each p As Reflection.PropertyInfo In properties
                        If IsAutoGenerateField(t, p.Name) = True Then
                            Select Case p.PropertyType
                                Case GetType(Integer)
                                    _model(p.Name) = row.Item(p.Name)
                                Case GetType(Decimal)
                                    _model(p.Name) = CDec(row.Item(p.Name))
                                Case GetType(Boolean)
                                    _model(p.Name) = CBool(row.Item(p.Name))

                                Case GetType(Date), GetType(DateTime)
                                    If row.Item(p.Name).ToString.IsNullOrWhiteSpace = False Then
                                        Select Case row.Item(p.Name).ToString.Length
                                            Case 8 'yyyyMMdd
                                                _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMdd", Nothing)
                                            Case 14 'yyyyMMddHHmmss
                                                _model(p.Name) = DateTime.ParseExact(row.Item(p.Name), "yyyyMMddHHmmss", Nothing)
                                            Case Else
                                                'Err
                                                _model(p.Name) = Nothing
                                        End Select
                                    End If
                                Case Else
                                    _model(p.Name) = row.Item(p.Name).ToString.Trim
                            End Select
                        End If
                    Next p
                    entities.Add(_model)
                End With
            Next row

            Return entities
        End If
    End Function

    Public Function FunGetV004Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As MODEL.V004_HOKOKU_SOUSA

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V004_HOKOKU_SOUSA) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V004_HOKOKU_SOUSA
            Dim t As Type = GetType(MODEL.V004_HOKOKU_SOUSA)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static).Where(Function(p) p.Name <> "Item").ToArray

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        _model(p.Name) = .Item(p.Name)
                    End If
                Next p
            End With

            Return _model
        End If
    End Function

    Public Function FunGetV005Model(ByVal strHOKOKU_NO As String) As MODEL.V005_CAR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.V005_CAR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New MODEL.V005_CAR_J
            With dsList.Tables(0).Rows(0)
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO))
                _model.BUMON_KB = .Item(NameOf(_model.BUMON_KB))
                _model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME))
                _model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                '_model.KISYU = .Item(NameOf(_model.KISYU))
                _model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME))
                _model.CLOSE_FG = CBool(Val(.Item(NameOf(_model.CLOSE_FG))))
                _model.SETUMON_1 = .Item(NameOf(_model.SETUMON_1))
                _model.SETUMON_2 = .Item(NameOf(_model.SETUMON_2))
                _model.SETUMON_3 = .Item(NameOf(_model.SETUMON_3))
                _model.SETUMON_4 = .Item(NameOf(_model.SETUMON_4))
                _model.SETUMON_5 = .Item(NameOf(_model.SETUMON_5))
                _model.SETUMON_6 = .Item(NameOf(_model.SETUMON_6))
                _model.SETUMON_7 = .Item(NameOf(_model.SETUMON_7))
                _model.SETUMON_8 = .Item(NameOf(_model.SETUMON_8))
                _model.SETUMON_9 = .Item(NameOf(_model.SETUMON_9))
                _model.SETUMON_10 = .Item(NameOf(_model.SETUMON_10))
                _model.SETUMON_11 = .Item(NameOf(_model.SETUMON_11))
                _model.SETUMON_12 = .Item(NameOf(_model.SETUMON_12))
                _model.SETUMON_13 = .Item(NameOf(_model.SETUMON_13))
                _model.SETUMON_14 = .Item(NameOf(_model.SETUMON_14))
                _model.SETUMON_15 = .Item(NameOf(_model.SETUMON_15))
                _model.SETUMON_16 = .Item(NameOf(_model.SETUMON_16))
                _model.SETUMON_17 = .Item(NameOf(_model.SETUMON_17))
                _model.SETUMON_18 = .Item(NameOf(_model.SETUMON_18))
                _model.SETUMON_19 = .Item(NameOf(_model.SETUMON_19))
                _model.SETUMON_20 = .Item(NameOf(_model.SETUMON_20))
                _model.SETUMON_21 = .Item(NameOf(_model.SETUMON_21))
                _model.SETUMON_22 = .Item(NameOf(_model.SETUMON_22))
                _model.SETUMON_23 = .Item(NameOf(_model.SETUMON_23))

                _model.KAITO_1 = .Item(NameOf(_model.KAITO_1))
                _model.KAITO_2 = .Item(NameOf(_model.KAITO_2))
                _model.KAITO_3 = .Item(NameOf(_model.KAITO_3))
                _model.KAITO_4 = .Item(NameOf(_model.KAITO_4))
                _model.KAITO_5 = .Item(NameOf(_model.KAITO_5))
                _model.KAITO_6 = .Item(NameOf(_model.KAITO_6))
                _model.KAITO_7 = .Item(NameOf(_model.KAITO_7))
                _model.KAITO_8 = .Item(NameOf(_model.KAITO_8))
                _model.KAITO_9 = .Item(NameOf(_model.KAITO_9))
                _model.KAITO_10 = .Item(NameOf(_model.KAITO_10))
                _model.KAITO_11 = .Item(NameOf(_model.KAITO_11))
                _model.KAITO_12 = .Item(NameOf(_model.KAITO_12))
                _model.KAITO_13 = .Item(NameOf(_model.KAITO_13))
                _model.KAITO_14 = .Item(NameOf(_model.KAITO_14))
                _model.KAITO_15 = .Item(NameOf(_model.KAITO_15))
                _model.KAITO_16 = .Item(NameOf(_model.KAITO_16))
                _model.KAITO_17 = .Item(NameOf(_model.KAITO_17))
                _model.KAITO_18 = .Item(NameOf(_model.KAITO_18))
                _model.KAITO_19 = .Item(NameOf(_model.KAITO_19))
                _model.KAITO_20 = .Item(NameOf(_model.KAITO_20))
                _model.KAITO_21 = .Item(NameOf(_model.KAITO_21))
                _model.KAITO_22 = .Item(NameOf(_model.KAITO_22))
                _model.KAITO_23 = .Item(NameOf(_model.KAITO_23))
                _model.KAITO_24 = .Item(NameOf(_model.KAITO_24))
                _model.KAITO_25 = .Item(NameOf(_model.KAITO_25))
                _model.KONPON_YOIN_KB1 = .Item(NameOf(_model.KONPON_YOIN_KB1))
                _model.KONPON_YOIN_NAME1 = .Item(NameOf(_model.KONPON_YOIN_NAME1))
                _model.KONPON_YOIN_KB2 = .Item(NameOf(_model.KONPON_YOIN_KB2))
                _model.KONPON_YOIN_NAME2 = .Item(NameOf(_model.KONPON_YOIN_NAME2))
                _model.KONPON_YOIN_SYAIN_ID = .Item(NameOf(_model.KONPON_YOIN_SYAIN_ID))
                _model.KONPON_YOIN_SYAIN_NAME = .Item(NameOf(_model.KONPON_YOIN_SYAIN_NAME))
                _model.KISEKI_KOTEI_KB = .Item(NameOf(_model.KISEKI_KOTEI_KB))
                _model.KISEKI_KOTEI_NAME = .Item(NameOf(_model.KISEKI_KOTEI_NAME))
                _model.SYOCHI_A_SYAIN_ID = .Item(NameOf(_model.SYOCHI_A_SYAIN_ID))
                _model.SYOCHI_A_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_A_SYAIN_NAME))
                _model.SYOCHI_A_YMDHNS = .Item(NameOf(_model.SYOCHI_A_YMDHNS))
                _model.SYOCHI_B_SYAIN_ID = .Item(NameOf(_model.SYOCHI_B_SYAIN_ID))
                _model.SYOCHI_B_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_B_SYAIN_NAME))
                _model.SYOCHI_B_YMDHNS = .Item(NameOf(_model.SYOCHI_B_YMDHNS))
                _model.SYOCHI_C_SYAIN_ID = .Item(NameOf(_model.SYOCHI_C_SYAIN_ID))
                _model.SYOCHI_C_SYAIN_NAME = .Item(NameOf(_model.SYOCHI_C_SYAIN_NAME))
                _model.SYOCHI_C_YMDHNS = .Item(NameOf(_model.SYOCHI_C_YMDHNS))
                _model.KYOIKU_FILE_PATH = .Item(NameOf(_model.KYOIKU_FILE_PATH))
                _model.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU))
                _model.ZESEI_SYOCHI_YUKO_UMU_NAME = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU_NAME))
                _model.SYOSAI_FILE_PATH = .Item(NameOf(_model.SYOSAI_FILE_PATH))
                _model.GOKI = .Item(NameOf(_model.GOKI))
                _model.LOT = .Item(NameOf(_model.LOT))
                _model.KENSA_TANTO_ID = .Item(NameOf(_model.KENSA_TANTO_ID))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KENSA_TOROKU_YMDHNS = .Item(NameOf(_model.KENSA_TOROKU_YMDHNS))
                _model.KENSA_GL_SYAIN_ID = .Item(NameOf(_model.KENSA_GL_SYAIN_ID))
                _model.KENSA_GL_SYAIN_NAME = .Item(NameOf(_model.KENSA_GL_SYAIN_NAME))
                _model.KENSA_GL_YMDHNS = .Item(NameOf(_model.KENSA_GL_YMDHNS))
                _model.FILE_PATH1 = .Item(NameOf(_model.FILE_PATH1))
                _model.FILE_PATH2 = .Item(NameOf(_model.FILE_PATH2))
                _model.ADD_SYAIN_ID = .Item(NameOf(_model.ADD_SYAIN_ID))
                _model.ADD_SYAIN_NAME = .Item(NameOf(_model.ADD_SYAIN_NAME))
                _model.ADD_YMDHNS = .Item(NameOf(_model.ADD_YMDHNS))
                _model.UPD_SYAIN_ID = .Item(NameOf(_model.UPD_SYAIN_ID))
                _model.UPD_SYAIN_NAME = .Item(NameOf(_model.UPD_SYAIN_NAME))
                _model.UPD_YMDHNS = .Item(NameOf(_model.UPD_YMDHNS))
                _model.DEL_SYAIN_ID = .Item(NameOf(_model.DEL_SYAIN_ID))
                _model.DEL_SYAIN_NAME = .Item(NameOf(_model.DEL_SYAIN_NAME))
                _model.DEL_YMDHNS = .Item(NameOf(_model.DEL_YMDHNS))

                _model.SYONIN_NAME10 = .Item(NameOf(_model.SYONIN_NAME10))
                _model.SYONIN_YMD10 = .Item(NameOf(_model.SYONIN_YMD10))
                _model.SYONIN_NAME20 = .Item(NameOf(_model.SYONIN_NAME20))
                _model.SYONIN_YMD20 = .Item(NameOf(_model.SYONIN_YMD20))
                _model.SYONIN_NAME30 = .Item(NameOf(_model.SYONIN_NAME30))
                _model.SYONIN_YMD30 = .Item(NameOf(_model.SYONIN_YMD30))
                _model.SYONIN_NAME40 = .Item(NameOf(_model.SYONIN_NAME40))
                _model.SYONIN_YMD40 = .Item(NameOf(_model.SYONIN_YMD40))
                _model.SYONIN_NAME50 = .Item(NameOf(_model.SYONIN_NAME50))
                _model.SYONIN_YMD50 = .Item(NameOf(_model.SYONIN_YMD50))
                _model.SYONIN_NAME60 = .Item(NameOf(_model.SYONIN_NAME60))
                _model.SYONIN_YMD60 = .Item(NameOf(_model.SYONIN_YMD60))
                _model.SYONIN_NAME90 = .Item(NameOf(_model.SYONIN_NAME90))
                _model.SYONIN_YMD90 = .Item(NameOf(_model.SYONIN_YMD90))
                _model.SYONIN_NAME100 = .Item(NameOf(_model.SYONIN_NAME100))
                _model.SYONIN_YMD100 = .Item(NameOf(_model.SYONIN_YMD100))
                _model.SYONIN_NAME120 = .Item(NameOf(_model.SYONIN_NAME120))
                _model.SYONIN_YMD120 = .Item(NameOf(_model.SYONIN_YMD120))

                _model.FUTEKIGO_HASSEI_YMD = .Item(NameOf(_model.FUTEKIGO_HASSEI_YMD))
            End With

            Return _model
        End If
    End Function

    ''' <summary>
    ''' 現在のステージ名を取得
    ''' </summary>
    ''' <param name="intCurrentStageID"></param>
    ''' <returns></returns>
    Public Function FunGetStageName(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal intCurrentStageID As Integer) As String
        Try
            Dim drList As List(Of DataRow)

            Select Case intSYONIN_HOKOKUSYO_ID
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR
                    drList = tblNCR.AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._2_CAR
                    drList = tblCAR.AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Else
                    Return vbEmpty
            End Select

            Return drList(0)?.Item("DISP")

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    ''' <summary>
    ''' ログインユーザーが承認or申請したステージか判定
    ''' </summary>
    ''' <param name="intSYONIN_HOKOKUSYO_ID">承認報告書ID</param>
    ''' <param name="strHOKOKU_NO">報告書No</param>
    ''' <param name="intSYONIN_JUN">承認順No</param>
    ''' <returns></returns>
    Public Function FunblnOwnCreated(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As Boolean
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(MODEL.D004_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        sbSQL.Append(" AND SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        Return dsList.Tables(0).Rows.Count > 0

    End Function


    Private Function FunGetCurrentSYONIN_JUN(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal HOKOKU_NO As String) As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" SYONIN_JUN")
        sbSQL.Append(" FROM " & NameOf(MODEL.V007_NCR_CAR) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & HOKOKU_NO & "'")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return dsList.Tables(0).Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function
#End Region

#Region "メール送信"

    Public Function FunSendMailFutekigo(ByVal strSubject As String, ByVal strBody As String, ByVal ToSYAIN_ID As Integer) As Boolean
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim strToAddress As String
        Dim strCCAddress As String
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        'Dim strFromSyainName As String

        Dim strMsg As String
        Try

            Using DB As ClsDbUtility = DBOpen()
                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")

                '---申請先担当者のメールアドレス取得
                Dim sbSQL As New System.Text.StringBuilder
                Dim dsList As New DataSet
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & ToSYAIN_ID & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                If dsList.Tables(0).Rows.Count > 0 Then
                    strToAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
                    strToSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                Else
                    Return False
                End If

                '---申請元担当者のメールアドレス取得
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(MODEL.M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                If dsList.Tables(0).Rows.Count > 0 Then
                    strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")
                    'strFromSyainName = dsList.Tables(0).Rows(0).Item("SIMEI")
                    strCCAddress = dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")
                Else
                    Return False
                End If

                strMsg = String.Format("【メール送信成功】TO:{0}({1}) SUBJECT:{2}", strToSyainName, strToAddress, strSubject)
                WL.WriteLogDat(strMsg)

                'DEBUG:
                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    Return True
                End If

                '#If DEBUG Then
                '                Return True
                '#End If
            End Using


            ''認証なし フジワラ
            blnSend = ClsMailSend.FunSendMail(strSmtpServer,
                           intSmtpPort,
                           strFromAddress,
                           strToAddress,
                           CCAddress:=strCCAddress,
                           BCCAddress:="",
                           strSubject:=strSubject,
                           strBody:=strBody,
                           strAttachment:="",
                           strFromName:="不適合管理システム",
                           isHTML:=True)

            '認証あり JMS
            'blnSend = ClsMailSend.FunSendMailoverAUTH(strSmtpServer,
            '               intSmtpPort,
            '               strUserID,
            '               strPassword,
            '               strFromAddress,
            '               strToAddress,
            '               strFromAddress,
            '               "",
            '               strSubject,
            '               strBody,
            '               "",
            '               "不適合管理システム")

            Return blnSend
        Catch ex As Exception
            Throw
            strMsg = String.Format("【メール送信失敗】TO:{0}({1}) SUBJECT:{2}" & vbCrLf & Err.Description, strToSyainName, strToAddress, strSubject)
            WL.WriteLogDat(strMsg)
        End Try
    End Function

#End Region

#Region "承認所属社員取得"
    'TV02_SYONIN_SYOZOKU_SYAIN

    Public Function FunGetSYONIN_SYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional SYONIN_HOUKOKUSYO_ID As Integer = 0, ByVal Optional SYONIN_JUN As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV02_SYONIN_SYOZOKU_SYAIN('" & BUMON_KB & "')")
        If SYONIN_HOUKOKUSYO_ID > 0 Then
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & SYONIN_HOUKOKUSYO_ID & "")
            sbSQL.Append(" AND SYONIN_JUN=" & SYONIN_JUN & "")
        End If
        sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        'dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        'dt.Columns.Add("SYONIN_JUN", GetType(Integer))

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                If Not dt.Rows.Contains(.Rows(intCNT).Item("SYAIN_ID")) Then
                    Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                    'Trow("DEF_FLG") = False
                    'Trow("DEL_FLG") = False
                    'Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    'Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                    dt.Rows.Add(Trow)
                End If
            Next intCNT
        End With

        Return dt
    End Function

#End Region

#Region "所属社員取得"
    'TV03_SYONIN_SYAIN

    Public Function FunGetSYOZOKU_SYAIN(ByVal Optional BUMON_KB As String = "", ByVal Optional BUSYO_ID As Integer = 0) As DataTable
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim dt As DataTableEx

        dt = New DataTableEx("System.Int32")

        sbSQL.Append("SELECT * FROM TV03_SYOZOKU_SYAIN('" & BUMON_KB & "')")
        If BUSYO_ID > 0 Then
            sbSQL.Append(" WHERE BUSYO_ID=" & BUSYO_ID & "")
        End If
        sbSQL.Append(" ORDER BY SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        With dsList.Tables(0)
            For intCNT = 0 To .Rows.Count - 1
                Dim Trow As DataRow = dt.NewRow()
                If Not dt.Rows.Contains(.Rows(intCNT).Item("SYAIN_ID")) Then
                    Trow("VALUE") = .Rows(intCNT).Item("SYAIN_ID")
                    Trow("DISP") = .Rows(intCNT).Item("SIMEI")
                    'Trow("DEF_FLG") = False
                    'Trow("DEL_FLG") = False
                    'Trow("SYONIN_HOKOKUSYO_ID") = .Rows(intCNT).Item("SYONIN_HOKOKUSYO_ID")
                    'Trow("SYONIN_JUN") = .Rows(intCNT).Item("SYONIN_JUN")
                    dt.Rows.Add(Trow)
                End If
            Next intCNT
        End With

        Return dt
    End Function

#End Region

#Region "報告書登録内容変更判定"
    Public Function FunChangedRecord(ByVal intHOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, strTargetYMDHNS As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try

            sbSQL.Append("SELECT * FROM " & NameOf(MODEL.ST01_GET_HOKOKU_NO) & "")
            sbSQL.Append("")
            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

#End Region

#Region "レポート出力"

    Public Function FunMakeReportNCR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim ssgWorkbook As SpreadsheetGear.IWorkbook
        Dim ssgWorksheets As SpreadsheetGear.IWorksheets
        Dim ssgSheet1 As SpreadsheetGear.IWorksheet
        Dim ssgShapes As SpreadsheetGear.Shapes.IShapes

        Try

            Dim _V002_NCR_J As MODEL.V002_NCR_J = FunGetV002Model(strHOKOKU_NO)
            Dim _V003_SYONIN_J_KANRI_List As List(Of MODEL.V003_SYONIN_J_KANRI) = FunGetV003Model(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, strHOKOKU_NO)

            ssgWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)
            ssgWorkbook.WorkbookSet.GetLock()
            ssgWorksheets = ssgWorkbook.Worksheets
            ssgSheet1 = ssgWorksheets.Item(0) 'sheet1

            '---図形取得
            Dim shapeLINE_SAISIN_IINKAI As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_KOKYAKU_SAISIN As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_HAIKYAKU As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SAIKAKO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_HENKYAKU As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_TENYO As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_D As SpreadsheetGear.Shapes.IShape = Nothing
            Dim shapeLINE_SYOCHI_E As SpreadsheetGear.Shapes.IShape = Nothing

            ssgShapes = ssgSheet1.Shapes
            For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                Select Case shape.Name
                    Case "LINE_SAISIN_IINKAI"
                        shapeLINE_SAISIN_IINKAI = shape
                    Case "LINE_KOKYAKU_SAISIN"
                        shapeLINE_KOKYAKU_SAISIN = shape
                    Case "LINE_HAIKYAKU"
                        shapeLINE_HAIKYAKU = shape
                    Case "LINE_SAIKAKO"
                        shapeLINE_SAIKAKO = shape
                    Case "LINE_HENKYAKU"
                        shapeLINE_HENKYAKU = shape
                    Case "LINE_TENYO"
                        shapeLINE_TENYO = shape
                    Case "LINE_SYOCHI_D"
                        shapeLINE_SYOCHI_D = shape
                    Case "LINE_SYOCHI_E"
                        shapeLINE_SYOCHI_E = shape
                End Select
            Next shape
            '---

            Select Case _V002_NCR_J.JIZEN_SINSA_HANTEI_KB
                Case ENM_JIZEN_SINSA_HANTEI_KB._2_再審委員会送り
                    shapeLINE_SAISIN_IINKAI.Visible = False
                    If Not _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_HANTEI_KB) & _V002_NCR_J.SAISIN_IINKAI_HANTEI_KB).Value = "TRUE"
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_GIJYUTU_SYAIN_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_HINSYO_SYAIN_NAME
                    If Not _V002_NCR_J.SAISIN_HINSYO_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_HINSYO_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_HINSYO_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_IINKAI_SIRYO_NO)).Value = _V002_NCR_J.SAISIN_IINKAI_SIRYO_NO

                Case ENM_JIZEN_SINSA_HANTEI_KB._3_顧客再審申請
                    shapeLINE_KOKYAKU_SAISIN.Visible = False
                    ssgSheet1.Range(NameOf(_V002_NCR_J.ITAG_NO)).Value = _V002_NCR_J.ITAG_NO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISIN_TANTO_NAME)).Value = _V002_NCR_J.KOKYAKU_SAISIN_TANTO_NAME
                    If Not _V002_NCR_J.KOKYAKU_SAISIN_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_SAISIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME)).Value = _V002_NCR_J.KOKYAKU_HANTEI_SIJI_NAME
                    If Not _V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_HANTEI_SIJI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_NAME)).Value = _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_NAME
                    If Not _V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KOKYAKU_SAISYU_HANTEI_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case Else
                    shapeLINE_KOKYAKU_SAISIN.Visible = True
                    shapeLINE_SAISIN_IINKAI.Visible = True
            End Select

            Dim SYOCHI_KB As ENM_NCR_STAGE80_TABPAGES

            SYOCHI_KB = FunGetST08SubPageName(_V002_NCR_J)
            Select Case SYOCHI_KB
                Case ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                    If Not _V002_NCR_J.HAIKYAKU_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HAIKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_HOUHOU)).Value = $"(その他の内容：{_V002_NCR_J.HAIKYAKU_HOUHOU.PadRight(30)})"
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_KB_NAME)).Value = _V002_NCR_J.HAIKYAKU_KB_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HAIKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HAIKYAKU_TANTO_NAME
                Case ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                    If Not _V002_NCR_J.SAIKAKO_KENSA_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_KENSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_KENSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAIKAKO_SAGYO_KAN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SAIKAKO_SIJI_NO)).Value = _V002_NCR_J.SAIKAKO_SIJI_NO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KEKKA_NAME)).Value = _V002_NCR_J.KENSA_KEKKA_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_TANTO_NAME)).Value = _V002_NCR_J.SEIGI_TANTO_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_TANTO_NAME)).Value = _V002_NCR_J.SEIZO_TANTO_NAME
                    ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_TANTO_NAME)).Value = _V002_NCR_J.KENSA_TANTO_NAME
                    If Not _V002_NCR_J.SEIGI_KAKUNIN_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SEIGI_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SEIGI_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.SEIZO_KAKUNIN_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.SEIZO_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SEIZO_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If
                    If Not _V002_NCR_J.KENSA_KAKUNIN_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.KENSA_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.KENSA_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_BIKO)).Value = _V002_NCR_J.HENKYAKU_BIKO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_SAKI)).Value = _V002_NCR_J.HENKYAKU_SAKI
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_TANTO_NAME)).Value = _V002_NCR_J.HENKYAKU_TANTO_NAME
                    If Not _V002_NCR_J.HENKYAKU_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.HENKYAKU_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HENKYAKU_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_BUHIN_BANGO)).Value = _V002_NCR_J.TENYO_BUHIN_BANGO
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_GOKI)).Value = _V002_NCR_J.TENYO_GOKI
                    ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_KISYU_NAME)).Value = _V002_NCR_J.TENYO_KISYU_NAME
                    If Not _V002_NCR_J.TENYO_YMD.IsNullOrWhiteSpace Then
                        ssgSheet1.Range(NameOf(_V002_NCR_J.TENYO_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.TENYO_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    End If

                Case Else
            End Select
            shapeLINE_HAIKYAKU.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録)
            shapeLINE_SAIKAKO.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録)
            shapeLINE_HENKYAKU.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._3_返却実施記録)
            shapeLINE_TENYO.Visible = (SYOCHI_KB <> ENM_NCR_STAGE80_TABPAGES._4_転用先記録)


            If Not _V002_NCR_J.JIZEN_SINSA_HANTEI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_HANTEI_KB) & _V002_NCR_J.JIZEN_SINSA_HANTEI_KB).Value = "TRUE"
            End If
            If Not _V002_NCR_J.SAISIN_KAKUNIN_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.SAISIN_KAKUNIN_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If



            shapeLINE_SYOCHI_D.Visible = (_V002_NCR_J.SYOCHI_D_UMU_KB = "1")
            shapeLINE_SYOCHI_E.Visible = (_V002_NCR_J.SYOCHI_E_UMU_KB = "1")
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_BANGO)).Value = _V002_NCR_J.BUHIN_BANGO
            ssgSheet1.Range(NameOf(_V002_NCR_J.BUHIN_NAME)).Value = _V002_NCR_J.BUHIN_NAME
            If Not _V002_NCR_J.FUTEKIGO_JYOTAI_KB.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_JYOTAI_KB) & _V002_NCR_J.FUTEKIGO_JYOTAI_KB).Value = "TRUE"
            End If
            ssgSheet1.Range(NameOf(_V002_NCR_J.FUTEKIGO_NAIYO)).Value = _V002_NCR_J.FUTEKIGO_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.GOKI)).Value = _V002_NCR_J.GOKI

            ssgSheet1.Range(NameOf(_V002_NCR_J.HOKOKU_NO)).Value = _V002_NCR_J.HOKOKU_NO


            ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_SYAIN_NAME)).Value = _V002_NCR_J.JIZEN_SINSA_SYAIN_NAME
            If Not _V002_NCR_J.JIZEN_SINSA_YMD.IsNullOrWhiteSpace Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.JIZEN_SINSA_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.JIZEN_SINSA_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If _V002_NCR_J.ZESEI_SYOCHI_YOHI_KB = ENM_YOHI_KB._1_要 Then
                ssgSheet1.Range("CAR_HOKOKU_NO").Value = _V002_NCR_J.HOKOKU_NO
                ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME)).Value = _V002_NCR_J.HASSEI_KOTEI_GL_SYAIN_NAME
                If Not _V002_NCR_J.HASSEI_KOTEI_GL_YMD.IsNullOrWhiteSpace Then
                    ssgSheet1.Range(NameOf(_V002_NCR_J.HASSEI_KOTEI_GL_YMD)).Value = DateTime.ParseExact(_V002_NCR_J.HASSEI_KOTEI_GL_YMD, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                End If
            End If


            ssgSheet1.Range(NameOf(_V002_NCR_J.KANSATU_KEKKA)).Value = _V002_NCR_J.KANSATU_KEKKA
            ssgSheet1.Range(NameOf(_V002_NCR_J.KISYU_NAME)).Value = _V002_NCR_J.KISYU_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SAIHATU)).Value = _V002_NCR_J.SAIHATU


            ssgSheet1.Range(NameOf(_V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME)).Value = _V002_NCR_J.SAISIN_KAKUNIN_SYAIN_NAME

            ssgSheet1.Range(NameOf(_V002_NCR_J.SURYO)).Value = _V002_NCR_J.SURYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_D_SYOCHI_KIROKU

            Dim intCurrentStage As Integer = FunGetCurrentSYONIN_JUN(Context.ENM_SYONIN_HOKOKUSYO_ID._1_NCR, _V002_NCR_J.HOKOKU_NO)
            If intCurrentStage >= ENM_NCR_STAGE._110_abcde処置担当 Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_D_UMU_NAME
                'If _V002_NCR_J.SYOCHI_D_UMU_NAME = "有" Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_D_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_D_YOHI_NAME
                'End If
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_UMU_NAME)).Value = _V002_NCR_J.SYOCHI_E_UMU_NAME
                'If _V002_NCR_J.SYOCHI_E_UMU_NAME = "有" Then
                ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_YOHI_NAME)).Value = _V002_NCR_J.SYOCHI_E_YOHI_NAME
                'End If
            End If

            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU)).Value = _V002_NCR_J.SYOCHI_E_SYOCHI_KIROKU
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_A_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_A_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_B_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_B_NAME
            ssgSheet1.Range(NameOf(_V002_NCR_J.SYOCHI_KEKKA_C_NAME)).Value = _V002_NCR_J.SYOCHI_KEKKA_C_NAME


            ssgSheet1.Range(NameOf(_V002_NCR_J.YOKYU_NAIYO)).Value = _V002_NCR_J.YOKYU_NAIYO
            ssgSheet1.Range(NameOf(_V002_NCR_J.ZUMEN_KIKAKU)).Value = _V002_NCR_J.ZUMEN_KIKAKU

            Dim strYMDHNS As String

            ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._10_起草入力).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力).FirstOrDefault?.ADD_SYAIN_NAME
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._10_起草入力 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._10_起草入力).Value = "'" & DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._20_起草確認製造GL).Value = "'" & DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._20_起草確認製造GL).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._20_起草確認製造GL).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._30_起草確認検査).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._30_起草確認検査).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._30_起草確認検査).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._90_処置実施確認_管理T).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._90_処置実施確認_管理T).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._90_処置実施確認_管理T).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._100_処置実施決裁_製造課長).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._100_処置実施決裁_製造課長).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._100_処置実施決裁_製造課長).FirstOrDefault?.UPD_SYAIN_NAME
            End If
            strYMDHNS = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当 And r.SYONIN_HANTEI_KB = ENM_SYONIN_HANTEI_KB._1_承認).FirstOrDefault?.SYONIN_YMDHNS
            If Not strYMDHNS.IsNullOrWhiteSpace Then
                ssgSheet1.Range("SYONIN_YMD" & ENM_NCR_STAGE._110_abcde処置担当).Value = DateTime.ParseExact(strYMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyy/MM/dd")
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._110_abcde処置担当).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._110_abcde処置担当).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            If intCurrentStage > ENM_NCR_STAGE._120_abcde処置確認 Then
                ssgSheet1.Range("SYONIN_NAME" & ENM_NCR_STAGE._120_abcde処置確認).Value = _V003_SYONIN_J_KANRI_List.Where(Function(r) r.SYONIN_JUN = ENM_NCR_STAGE._120_abcde処置確認).FirstOrDefault?.UPD_SYAIN_NAME
            End If

            Dim strRootDir As String
            Using DB As ClsDbUtility = DBOpen()
                strRootDir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
            End Using

            '画像表示
            Dim top As Double
            Dim left As Double
            Dim width As Double
            Dim height As Double
            Dim aspectRatio As Double
            If Not _V002_NCR_J.G_FILE_PATH1.IsNullOrWhiteSpace Then
                Using img = Image.FromFile(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH1)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '何行目
                    top = windowInfo.RowToPoints(7.2)
                    '何列目
                    left = windowInfo.ColumnToPoints(9.2)

                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                    aspectRatio = img.Width / img.Height
                    width = height * aspectRatio 'windowInfo.ColumnToPoints(5.5) * Magnification 'img.Width * 72 / img.HorizontalResolution

                End Using
                ssgSheet1.Shapes.AddPicture(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH1, left, top, width, height)
            End If

            If Not _V002_NCR_J.G_FILE_PATH2.IsNullOrWhiteSpace Then
                Using img = Image.FromFile(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH2)
                    Dim windowInfo As SpreadsheetGear.IWorksheetWindowInfo = ssgSheet1.WindowInfo
                    '何行目
                    top = windowInfo.RowToPoints(7.2 + 9)
                    '何列目
                    left = windowInfo.ColumnToPoints(9.2)

                    height = windowInfo.RowToPoints(4) 'img.Height * 72 / img.VerticalResolution
                    aspectRatio = img.Width / img.Height
                    width = height * aspectRatio 'windowInfo.ColumnToPoints(5.5) * Magnification 'img.Width * 72 / img.HorizontalResolution
                End Using
                ssgSheet1.Shapes.AddPicture(strRootDir & _V002_NCR_J.HOKOKU_NO.Trim & "\" & _V002_NCR_J.G_FILE_PATH2, left, top, width, height)
            End If

            '-----ファイル保存
            ssgSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            ssgWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            '''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            Call FunOpenWorkbook(strFilePath)

            'Excel作業ファイルを削除
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally

            ssgSheet1 = Nothing
            ssgWorksheets = Nothing
            ssgWorkbook = Nothing
        End Try
    End Function

    Public Function FunMakeReportCAR(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            Dim _V005_CAR_J As MODEL.V005_CAR_J = FunGetV005Model(strHOKOKU_NO)

            spSheet1.Range(NameOf(_V005_CAR_J.GOKI)).Value = _V005_CAR_J.GOKI
            spSheet1.Range(NameOf(_V005_CAR_J.HOKOKU_NO)).Value = _V005_CAR_J.HOKOKU_NO
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_1)).Value = _V005_CAR_J.KAITO_1
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_2)).Value = _V005_CAR_J.KAITO_2
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_3)).Value = _V005_CAR_J.KAITO_3
            If Not _V005_CAR_J.KAITO_4.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_4)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_4.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_5)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_5)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_6)).Value = _V005_CAR_J.KAITO_6
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_7)).Value = _V005_CAR_J.KAITO_7
            If Not _V005_CAR_J.KAITO_8.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_8)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_8.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_9.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_9)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_9.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_10)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_10)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_11)).Value = _V005_CAR_J.KAITO_11
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_12)).Value = _V005_CAR_J.KAITO_12
            If Not _V005_CAR_J.KAITO_13.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_13)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_13.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.KAITO_14.IsNullOrWhiteSpace AndAlso CBool(_V005_CAR_J.KAITO_14) Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_YOU").Value = "TRUE"
            Else
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_14) & "_HI").Value = "TRUE"
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_15)).Value = _V005_CAR_J.KAITO_15
            If Not _V005_CAR_J.KAITO_16.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_16)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_16.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_17)).Value = Fun_GetUSER_NAME(_V005_CAR_J.KAITO_17)
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_18)).Value = _V005_CAR_J.KAITO_18
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_19)).Value = _V005_CAR_J.KAITO_19
            If Not _V005_CAR_J.KAITO_20.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KAITO_20)).Value = DateTime.ParseExact(_V005_CAR_J.KAITO_20.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If


            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_21)).Value = _V005_CAR_J.KAITO_21
            spSheet1.Range(NameOf(_V005_CAR_J.KAITO_22)).Value = _V005_CAR_J.KAITO_22

            '現状未使用のフィールド
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_24)).Value = _V005_CAR_J.KAITO_24
            'spSheet1.Range(NameOf(_V005_CAR_J.KAITO_25)).Value = _V005_CAR_J.KAITO_25

            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_SYAIN_NAME)).Value = _V005_CAR_J.KENSA_GL_SYAIN_NAME
            If Not _V005_CAR_J.KENSA_GL_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_GL_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_GL_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TANTO_NAME)).Value = _V005_CAR_J.KENSA_TANTO_NAME
            If Not _V005_CAR_J.KENSA_TOROKU_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.KENSA_TOROKU_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.KENSA_TOROKU_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.KISYU_NAME)).Value = _V005_CAR_J.KISYU_NAME
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_A_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_A_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_A_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_A_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_B_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_B_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_B_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_B_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_SYAIN_NAME)).Value = _V005_CAR_J.SYOCHI_C_SYAIN_NAME
            If Not _V005_CAR_J.SYOCHI_C_YMDHNS.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYOCHI_C_YMDHNS)).Value = DateTime.ParseExact(_V005_CAR_J.SYOCHI_B_YMDHNS.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If

            spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME10)).Value = _V005_CAR_J.SYONIN_NAME10
            If Not _V005_CAR_J.SYONIN_YMD10.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD10)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD10.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
            End If
            If Not _V005_CAR_J.SYONIN_YMD20.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD20)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD20.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME20)).Value = _V005_CAR_J.SYONIN_NAME20
            End If
            If Not _V005_CAR_J.SYONIN_YMD30.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD30)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD30.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME30)).Value = _V005_CAR_J.SYONIN_NAME30
            End If
            If Not _V005_CAR_J.SYONIN_YMD40.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD40)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD40.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME40)).Value = _V005_CAR_J.SYONIN_NAME40
            End If

            If CBool(Val(_V005_CAR_J.KAITO_23)) Then
                If Not _V005_CAR_J.SYONIN_YMD50.IsNullOrWhiteSpace Then
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD50)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD50.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                    spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME50)).Value = _V005_CAR_J.SYONIN_NAME50
                End If

                Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
                ssgShapes = spSheet1.Shapes
                For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
                    If shape.Name = "LINE_SEKKEI_TANTO" Then
                        shape.Visible = False
                        shape.PrintObject = False
                        Exit For
                    End If
                Next shape
            End If

            If Not _V005_CAR_J.SYONIN_YMD60.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD60)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD60.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME60)).Value = _V005_CAR_J.SYONIN_NAME60
            End If
            If Not _V005_CAR_J.SYONIN_YMD90.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD90)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD90.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME90)).Value = _V005_CAR_J.SYONIN_NAME90
            End If
            If Not _V005_CAR_J.SYONIN_YMD130.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD130)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD130.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME130)).Value = _V005_CAR_J.SYONIN_NAME130
            End If
            If Not _V005_CAR_J.SYONIN_YMD120.IsNullOrWhiteSpace Then
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_YMD120)).Value = DateTime.ParseExact(_V005_CAR_J.SYONIN_YMD120.Trim, "yyyyMMdd", Nothing).ToString("yyyy/MM/dd")
                spSheet1.Range(NameOf(_V005_CAR_J.SYONIN_NAME120)).Value = _V005_CAR_J.SYONIN_NAME120
            End If
            spSheet1.Range(NameOf(_V005_CAR_J.SYOSAI_FILE_PATH)).Value = _V005_CAR_J.SYOSAI_FILE_PATH
            spSheet1.Range(NameOf(_V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME)).Value = _V005_CAR_J.ZESEI_SYOCHI_YUKO_UMU_NAME

            '-----ファイル保存
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.Excel8)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            ''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            Call FunOpenWorkbook(strFilePath)

            'Excel作業ファイルを削除
            Try
                System.IO.File.Delete(strFilePath)
            Catch ex As UnauthorizedAccessException
            End Try

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        Finally
            spSheet1 = Nothing
            spWorksheets = Nothing
            spWorkbook = Nothing

        End Try
    End Function

    Private Function FunOpenWorkbook(filePath As String) As Boolean
        Dim workbookView As New SpreadsheetGear.Windows.Forms.WorkbookView
        Try
            WorkbookView.GetLock()
            Dim workbookSet As SpreadsheetGear.IWorkbookSet = SpreadsheetGear.Factory.GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            Dim workbook As SpreadsheetGear.IWorkbook = workbookSet.Workbooks.Open(filePath)
            Dim worksheet As SpreadsheetGear.IWorksheet = workbook.Worksheets(0)

            'worksheet.ProtectContents = True
            'worksheet.WindowInfo.DisplayGridlines = False
            'worksheet.WindowInfo.DisplayHeadings = False
            'worksheet.WindowInfo.DisplayOutline = False
            'worksheet.WindowInfo.DisplayZeros = False

            workbookView.ActiveWorkbook = workbook
            workbookView.PrintPreview()

            Return True

        Catch ex As Exception
            Throw
            Return False
        Finally
            WorkbookView.ReleaseLock()
        End Try
    End Function


    ''' <summary>
    ''' NCR ステージ80 処置判定
    ''' </summary>
    ''' <returns></returns>
    Private Function FunGetST08SubPageName(entity As MODEL.V002_NCR_J) As ENM_NCR_STAGE80_TABPAGES
        Select Case entity.KOKYAKU_SAISYU_HANTEI_KB
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._3_廃却する
                Return ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._4_返却する
                Return ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._5_転用する
                Return ENM_NCR_STAGE80_TABPAGES._4_転用先記録
            Case ENM_KOKYAKU_SAISYU_HANTEI_KB._6_再加工する
                Return ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
            Case Else
                Select Case entity.SAISIN_IINKAI_HANTEI_KB
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._3_廃却する
                        Return ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._4_返却する
                        Return ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._5_転用する
                        Return ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                    Case ENM_SAISIN_IINKAI_HANTEI_KB._6_再加工する
                        Return ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                    Case Else
                        Select Case entity.JIZEN_SINSA_HANTEI_KB
                            Case ENM_JIZEN_SINSA_HANTEI_KB._4_廃却する
                                Return ENM_NCR_STAGE80_TABPAGES._1_廃却実施記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._5_返却する
                                Return ENM_NCR_STAGE80_TABPAGES._3_返却実施記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._6_転用する
                                Return ENM_NCR_STAGE80_TABPAGES._4_転用先記録
                            Case ENM_JIZEN_SINSA_HANTEI_KB._7_再加工する
                                Return ENM_NCR_STAGE80_TABPAGES._2_再加工指示_記録
                            Case Else
                                'Err
                        End Select
                End Select
        End Select
    End Function
#End Region

#End Region





End Module
