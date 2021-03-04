Imports JMS_COMMON.ClsPubMethod
Imports MODEL

Module mdlG0020

#Region "定数・変数"

    ''' <summary>
    ''' 一覧画面
    ''' </summary>
    Public frmLIST As FrmG0020_List

    ''' <summary>
    ''' 起動モード
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

        ''' <summary>
        ''' 分析集計(のための検索)画面を表示
        ''' </summary>
        _3_分析集計 = 3

    End Enum

    Public Enum ENM_SAVE_MODE
        _1_保存 = 1
        _2_承認申請 = 2
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
        _0_新規作成 = 0
        _1_申請 = 1
        _2_更新保存 = 2
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
        _9_取消 = 9
    End Enum

    Public Enum ENM_FCCB_STAGE
        _10_起草入力 = 10
        _20_処置事項調査等 = 20
        _30_変更審議 = 30
        _40_処置確認 = 40
        _41_処置確認_統括 = 41
        _50_処置事項完了 = 50
        _60_処置事項完了確認 = 60
        _61_処置事項完了確認_統括 = 61
        _999_Closed = 999

    End Enum

#End Region

#Region "Model"

    Public _D009 As New D009_FCCB_J
    Public _D004_SYONIN_J_KANRI As New D004_SYONIN_J_KANRI
    Public _R001_HOKOKU_SOUSA As New R001_HOKOKU_SOUSA
    Public _R002_HOKOKU_TENSO As New R002_HOKOKU_TENSO

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

                    'Call FunGetCodeDataTable(DB, "不適合区分", tblFUTEKIGO_KB)
                    'Call FunGetCodeDataTable(DB, "承認担当", tblTANTO_SYONIN)
                    'Call FunGetCodeDataTable(DB, "承認担当一覧", tblTANTO_SYONINList)
                    'Call FunGetCodeDataTable(DB, "原因分析区分", tblGENIN_BUNSEKI_KB)

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

                Parameter.Init(cmds(1))

                '-----一覧画面表示
                frmLIST = New FrmG0020_List
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

    Public Function FunGetV002Model(ByVal strHOKOKU_NO As String) As V002_NCR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V002_NCR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V002_NCR_J
            Dim t As Type = GetType(V002_NCR_J)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                 Reflection.BindingFlags.Public Or
                 Reflection.BindingFlags.Instance Or
                 Reflection.BindingFlags.Static)

            With dsList.Tables(0).Rows(0)
                For Each p As Reflection.PropertyInfo In properties
                    If IsAutoGenerateField(t, p.Name) = True Then
                        If p.PropertyType Is GetType(String) Then
                            _model(p.Name) = .Item(p.Name).ToString.Trim
                        Else
                            _model(p.Name) = .Item(p.Name)
                        End If

                    End If
                Next p
            End With
            Return _model
        End If
    End Function

    Public Function IsMatchRevision(strRevisionName As String, intSYONIN_HOKOKUSYO_ID As Integer, strHOKOKU_NO As String) As Boolean
        Try
            Dim sbSQL As New System.Text.StringBuilder
            Dim intRET As Integer

            sbSQL.Append($"SELECT")
            sbSQL.Append($" COUNT(HOKOKU_NO)")
            sbSQL.Append($" FROM {NameOf(V003_SYONIN_J_KANRI)}")
            sbSQL.Append($" WHERE SYONIN_HOKOKUSYO_ID ={intSYONIN_HOKOKUSYO_ID}")
            sbSQL.Append($" AND HOKOKU_NO='{strHOKOKU_NO}'")
            Select Case strRevisionName
                Case "P"
                    sbSQL.Append($" AND SYONIN_JUN=10")
                    sbSQL.Append($" AND ADD_YMDHNS>='202002130000'")
                Case Else

            End Select
            Using DB = DBOpen()
                intRET = DB.ExecuteScalar(sbSQL.ToString, conblnNonMsg).ToVal
            End Using

            Return intRET > 0
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function FunGetV003Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String) As List(Of V003_SYONIN_J_KANRI)

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V003_SYONIN_J_KANRI) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID = " & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Dim t As Type = GetType(V003_SYONIN_J_KANRI)
            Dim properties As Reflection.PropertyInfo() = t.GetProperties(
                         Reflection.BindingFlags.Public Or
                         Reflection.BindingFlags.Instance Or
                         Reflection.BindingFlags.Static)

            Dim entities As New List(Of V003_SYONIN_J_KANRI)
            For Each row As DataRow In dsList.Tables(0).Rows
                With row
                    Dim _model As New V003_SYONIN_J_KANRI
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
                                    If row.Item(p.Name).ToString.IsNulOrWS = False Then
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

    Public Function FunGetV004Model(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, ByVal intSYONIN_JUN As Integer) As V004_HOKOKU_SOUSA

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V004_HOKOKU_SOUSA) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & strHOKOKU_NO & "'")
        sbSQL.Append(" AND SYONIN_JUN=" & intSYONIN_JUN & "")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V004_HOKOKU_SOUSA
            Dim t As Type = GetType(V004_HOKOKU_SOUSA)
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

    Public Function FunGetV005Model(ByVal strHOKOKU_NO As String) As V005_CAR_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" *")
        sbSQL.Append(" FROM " & NameOf(V005_CAR_J) & " ")
        sbSQL.Append(" WHERE HOKOKU_NO='" & strHOKOKU_NO & "'")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else

            Dim _model As New V005_CAR_J

            With dsList.Tables(0).Rows(0)
                _model.HOKOKU_NO = .Item(NameOf(_model.HOKOKU_NO)).ToString.Trim
                _model.BUMON_KB = .Item(NameOf(_model.BUMON_KB)).ToString.Trim
                _model.BUMON_NAME = .Item(NameOf(_model.BUMON_NAME)).ToString.Trim
                _model.KISYU_ID = .Item(NameOf(_model.KISYU_ID))
                _model.KISYU_NAME = .Item(NameOf(_model.KISYU_NAME)).ToString.Trim
                _model.CLOSE_FG = CBool(Val(.Item(NameOf(_model.CLOSE_FG))))
                _model.SETUMON_1 = .Item(NameOf(_model.SETUMON_1)).ToString.Trim
                _model.SETUMON_2 = .Item(NameOf(_model.SETUMON_2)).ToString.Trim
                _model.SETUMON_3 = .Item(NameOf(_model.SETUMON_3)).ToString.Trim
                _model.SETUMON_4 = .Item(NameOf(_model.SETUMON_4)).ToString.Trim
                _model.SETUMON_5 = .Item(NameOf(_model.SETUMON_5)).ToString.Trim
                _model.SETUMON_6 = .Item(NameOf(_model.SETUMON_6)).ToString.Trim
                _model.SETUMON_7 = .Item(NameOf(_model.SETUMON_7)).ToString.Trim
                _model.SETUMON_8 = .Item(NameOf(_model.SETUMON_8)).ToString.Trim
                _model.SETUMON_9 = .Item(NameOf(_model.SETUMON_9)).ToString.Trim
                _model.SETUMON_10 = .Item(NameOf(_model.SETUMON_10)).ToString.Trim
                _model.SETUMON_11 = .Item(NameOf(_model.SETUMON_11)).ToString.Trim
                _model.SETUMON_12 = .Item(NameOf(_model.SETUMON_12)).ToString.Trim
                _model.SETUMON_13 = .Item(NameOf(_model.SETUMON_13)).ToString.Trim
                _model.SETUMON_14 = .Item(NameOf(_model.SETUMON_14)).ToString.Trim
                _model.SETUMON_15 = .Item(NameOf(_model.SETUMON_15)).ToString.Trim
                _model.SETUMON_16 = .Item(NameOf(_model.SETUMON_16)).ToString.Trim
                _model.SETUMON_17 = .Item(NameOf(_model.SETUMON_17)).ToString.Trim
                _model.SETUMON_18 = .Item(NameOf(_model.SETUMON_18)).ToString.Trim
                _model.SETUMON_19 = .Item(NameOf(_model.SETUMON_19)).ToString.Trim
                _model.SETUMON_20 = .Item(NameOf(_model.SETUMON_20)).ToString.Trim
                _model.SETUMON_21 = .Item(NameOf(_model.SETUMON_21)).ToString.Trim
                _model.SETUMON_22 = .Item(NameOf(_model.SETUMON_22)).ToString.Trim
                _model.SETUMON_23 = .Item(NameOf(_model.SETUMON_23)).ToString.Trim
                _model.SETUMON_24 = .Item(NameOf(_model.SETUMON_24)).ToString.Trim

                _model.KAITO_1 = .Item(NameOf(_model.KAITO_1)).ToString.Trim
                _model.KAITO_2 = .Item(NameOf(_model.KAITO_2)).ToString.Trim
                _model.KAITO_3 = .Item(NameOf(_model.KAITO_3)).ToString.Trim
                _model.KAITO_4 = .Item(NameOf(_model.KAITO_4)).ToString.Trim
                _model.KAITO_5 = .Item(NameOf(_model.KAITO_5)).ToString.Trim
                _model.KAITO_6 = .Item(NameOf(_model.KAITO_6)).ToString.Trim
                _model.KAITO_7 = .Item(NameOf(_model.KAITO_7)).ToString.Trim
                _model.KAITO_8 = .Item(NameOf(_model.KAITO_8)).ToString.Trim
                _model.KAITO_9 = .Item(NameOf(_model.KAITO_9)).ToString.Trim
                _model.KAITO_10 = .Item(NameOf(_model.KAITO_10)).ToString.Trim
                _model.KAITO_11 = .Item(NameOf(_model.KAITO_11)).ToString.Trim
                _model.KAITO_12 = .Item(NameOf(_model.KAITO_12)).ToString.Trim
                _model.KAITO_13 = .Item(NameOf(_model.KAITO_13)).ToString.Trim
                _model.KAITO_14 = .Item(NameOf(_model.KAITO_14)).ToString.Trim
                _model.KAITO_15 = .Item(NameOf(_model.KAITO_15)).ToString.Trim
                _model.KAITO_16 = .Item(NameOf(_model.KAITO_16)).ToString.Trim
                _model.KAITO_17 = .Item(NameOf(_model.KAITO_17)).ToString.Trim
                _model.KAITO_18 = .Item(NameOf(_model.KAITO_18)).ToString.Trim
                _model.KAITO_19 = .Item(NameOf(_model.KAITO_19)).ToString.Trim
                _model.KAITO_20 = .Item(NameOf(_model.KAITO_20)).ToString.Trim
                _model.KAITO_21 = .Item(NameOf(_model.KAITO_21)).ToString.Trim
                _model.KAITO_22 = .Item(NameOf(_model.KAITO_22)).ToString.Trim
                _model.KAITO_23 = .Item(NameOf(_model.KAITO_23)).ToString.Trim
                _model.KAITO_24 = .Item(NameOf(_model.KAITO_24)).ToString.Trim
                _model.KAITO_25 = .Item(NameOf(_model.KAITO_25)).ToString.Trim
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
                _model.KYOIKU_FILE_PATH = .Item(NameOf(_model.KYOIKU_FILE_PATH)).ToString.Trim
                _model.ZESEI_SYOCHI_YUKO_UMU = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU)).ToString.Trim
                _model.ZESEI_SYOCHI_YUKO_UMU_NAME = .Item(NameOf(_model.ZESEI_SYOCHI_YUKO_UMU_NAME)).ToString.Trim
                _model.SYOSAI_FILE_PATH = .Item(NameOf(_model.SYOSAI_FILE_PATH)).ToString.Trim
                _model.GOKI = .Item(NameOf(_model.GOKI)).ToString.Trim
                _model.LOT = .Item(NameOf(_model.LOT)).ToString.Trim
                _model.KENSA_TANTO_ID = .Item(NameOf(_model.KENSA_TANTO_ID))
                _model.KENSA_TANTO_NAME = .Item(NameOf(_model.KENSA_TANTO_NAME))
                _model.KENSA_TOROKU_YMDHNS = .Item(NameOf(_model.KENSA_TOROKU_YMDHNS))
                _model.KENSA_GL_SYAIN_ID = .Item(NameOf(_model.KENSA_GL_SYAIN_ID))
                _model.KENSA_GL_SYAIN_NAME = .Item(NameOf(_model.KENSA_GL_SYAIN_NAME))
                _model.KENSA_GL_YMDHNS = .Item(NameOf(_model.KENSA_GL_YMDHNS))
                _model.FILE_PATH1 = .Item(NameOf(_model.FILE_PATH1)).ToString.Trim
                _model.FILE_PATH2 = .Item(NameOf(_model.FILE_PATH2)).ToString.Trim
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
                _model.SYONIN_NAME70 = .Item(NameOf(_model.SYONIN_NAME70))
                _model.SYONIN_YMD70 = .Item(NameOf(_model.SYONIN_YMD70))
                _model.SYONIN_NAME90 = .Item(NameOf(_model.SYONIN_NAME90))
                _model.SYONIN_YMD90 = .Item(NameOf(_model.SYONIN_YMD90))
                _model.SYONIN_NAME100 = .Item(NameOf(_model.SYONIN_NAME100))
                _model.SYONIN_YMD100 = .Item(NameOf(_model.SYONIN_YMD100))
                _model.SYONIN_NAME120 = .Item(NameOf(_model.SYONIN_NAME120))
                _model.SYONIN_YMD120 = .Item(NameOf(_model.SYONIN_YMD120))
                _model.SYONIN_NAME130 = .Item(NameOf(_model.SYONIN_NAME130))
                _model.SYONIN_YMD130 = .Item(NameOf(_model.SYONIN_YMD130))

                _model.FUTEKIGO_HASSEI_YMD = .Item(NameOf(_model.FUTEKIGO_HASSEI_YMD))
                _model.SYOCHI_YOTEI_YMD = .Item(NameOf(_model.SYOCHI_YOTEI_YMD))
            End With

            Return _model
        End If
    End Function

    Public Function FunGetD009Model(ByVal FCCB_NO As String) As D009_FCCB_J

        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT")
        sbSQL.Append($" *")
        sbSQL.Append($" FROM {NameOf(D009_FCCB_J)}")
        sbSQL.Append($" WHERE {NameOf(D009_FCCB_J.FCCB_NO)}='{FCCB_NO}'")
        Using DB = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList IsNot Nothing AndAlso dsList.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Dim _Model As New ModelInfo(Of D009_FCCB_J)(srcDATA:=dsList.Tables(0))
            Return _Model.Entity
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
                Case Context.ENM_SYONIN_HOKOKUSYO_ID._3_CTS
                    drList = tblCTS.LazyLoad("CTS").AsEnumerable().Where(Function(r) Val(r.Field(Of Integer)("VALUE")) = intCurrentStageID).ToList
                Case Else
                    Return vbEmpty
            End Select

            Return drList(0)?.Item("DISP")
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return vbEmpty
        End Try
    End Function

    Private Function FunGetCurrentSYONIN_JUN(ByVal intSYONIN_HOKOKUSYO_ID As Integer, ByVal HOKOKU_NO As String) As Integer
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Remove(0, sbSQL.Length)
        sbSQL.Append("SELECT")
        sbSQL.Append(" SYONIN_JUN")
        sbSQL.Append(" FROM " & NameOf(V007_NCR_CAR) & " ")
        sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & intSYONIN_HOKOKUSYO_ID & "")
        sbSQL.Append(" AND HOKOKU_NO='" & HOKOKU_NO & "'")
        sbSQL.Append(" ORDER BY SYONIN_JUN DESC")
        Using DBa As ClsDbUtility = DBOpen()
            dsList = DBa.GetDataSet(sbSQL.ToString, conblnNonMsg)
        End Using

        If dsList.Tables(0).Rows.Count > 0 Then
            Return If(dsList.Tables(0).Rows(0).Item(0).ToString.ToVal = 0, 999, dsList.Tables(0).Rows(0).Item(0).ToString.ToVal)
        Else
            Return 0
        End If
    End Function

#End Region

#Region "メール送信"

    Public Function FunSendMailFCCB(strSubject As String, strBody As String, users As List(Of Integer), Optional blnSendSenior As Boolean = True) As Boolean
        Dim strSmtpServer As String
        Dim intSmtpPort As Integer
        Dim strFromAddress As String
        Dim ToAddressList As New List(Of String)
        Dim CCAddressList As New List(Of String)
        Dim BCCAddressList As New List(Of String)
        Dim strUserID As String
        Dim strPassword As String
        Dim blnSend As Boolean
        Dim strToSyainName As String
        'Dim strFromSyainName As String
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        Dim strMsg As String
        Try

            Using DB As ClsDbUtility = DBOpen()
                strSmtpServer = FunGetCodeMastaValue(DB, "メール設定", "SMTP_SERVER")
                intSmtpPort = Val(FunGetCodeMastaValue(DB, "メール設定", "SMTP_PORT"))
                strUserID = FunGetCodeMastaValue(DB, "メール設定", "SMTP_USER")
                strPassword = FunGetCodeMastaValue(DB, "メール設定", "SMTP_PASS")

                If FunGetCodeMastaValue(DB, "メール設定", "ENABLE").ToString.Trim.ToUpper = "FALSE" Then
                    MessageBox.Show("メール送信が無効に設定されているため、依頼メールは送信されませんでした。", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If

                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT")
                sbSQL.Append($" M4.SIMEI")
                sbSQL.Append($",M4.MAIL_ADDRESS")
                sbSQL.Append($",M5.BUSYO_ID")
                sbSQL.Append($",M2.BUSYO_NAME")
                sbSQL.Append($",ISNULL(OYA_M2.BUSYO_NAME,'') AS OYA_BUYSYO_NAME")
                sbSQL.Append($",ISNULL(GL.SIMEI,'') AS GL_SIMEI")
                sbSQL.Append($",ISNULL(GL.MAIL_ADDRESS,'') AS GL_ADDRESS")
                sbSQL.Append($",ISNULL(OYA_GL.SIMEI,'') AS OYA_GL_SIMEI")
                sbSQL.Append($",ISNULL(OYA_GL.MAIL_ADDRESS,'') AS OYA_GL_ADDRESS")
                sbSQL.Append($" FROM M004_SYAIN AS M4")
                sbSQL.Append($" LEFT JOIN dbo.M005_SYOZOKU_BUSYO AS M5 ON (M4.SYAIN_ID = M5.SYAIN_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS M2 ON (M2.BUSYO_ID = M5.BUSYO_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS GL ON (GL.SYAIN_ID = M2.SYOZOKUCYO_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M002_BUSYO AS OYA_M2 ON (OYA_M2.BUSYO_ID = M2.OYA_BUSYO_ID)")
                sbSQL.Append($" LEFT JOIN dbo.M004_SYAIN AS OYA_GL ON (OYA_GL.SYAIN_ID = OYA_M2.SYOZOKUCYO_ID)")
                sbSQL.Append($" WHERE M4.SYAIN_ID IN (")
                sbSQL.Append($" {users.First()}")
                If users.Count > 1 Then
                    For Each user In users.Skip(1)
                        sbSQL.Append($",{user}")
                    Next
                End If
                sbSQL.Append($" )")
                sbSQL.Append($" AND M5.KENMU_FLG='0'")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                With dsList.Tables(0)
                    If .Rows.Count > 0 Then
                        For Each row In .Rows

                            If Not row.Item("MAIL_ADDRESS").ToString.IsNulOrWS AndAlso Not ToAddressList.Contains(row.Item("MAIL_ADDRESS")) Then
                                ToAddressList.Add(row.Item("MAIL_ADDRESS"))
                            End If

                            '所属長にも送信
                            If row.Item("GL_ADDRESS").ToString.IsNulOrWS = False AndAlso row.Item("MAIL_ADDRESS").ToString <> row.Item("GL_ADDRESS").ToString _
                                AndAlso Not ToAddressList.Contains(row.Item("GL_ADDRESS")) Then
                                ToAddressList.Add(row.Item("GL_ADDRESS"))
                            End If

                            If blnSendSenior Then
                                '送信先が所属長宛てだった場合、所属長の上位の部署の所属長にも送信
                                If row.Item("OYA_GL_ADDRESS").ToString.IsNulOrWS = False AndAlso
                                row.Item("MAIL_ADDRESS").ToString = row.Item("GL_ADDRESS").ToString AndAlso
                                row.Item("MAIL_ADDRESS").ToString <> row.Item("OYA_GL_ADDRESS").ToString _
                                AndAlso Not ToAddressList.Contains(row.Item("OYA_GL_ADDRESS")) Then
                                    ToAddressList.Add(row.Item("OYA_GL_ADDRESS"))
                                End If
                            End If
                        Next
                        If (.Rows.Count > 1) Then
                            strToSyainName = $"{ .Rows(0).Item("SIMEI")}  他 { .Rows.Count}名"
                        Else
                            strToSyainName = .Rows(0).Item("SIMEI")
                        End If
                    Else
                        Return False
                    End If
                End With

                '---システム送信元アドレス取得
                strFromAddress = FunGetCodeMastaValue(DB, "メール設定", "FROM")

                '---申請元担当者のメールアドレス取得
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append("SELECT")
                sbSQL.Append(" SIMEI")
                sbSQL.Append(" ,MAIL_ADDRESS")
                sbSQL.Append(" FROM " & NameOf(M004_SYAIN) & " ")
                sbSQL.Append(" WHERE SYAIN_ID=" & pub_SYAIN_INFO.SYAIN_ID & "")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                '自身に申請メールを送る場合はCCに追加しない
                If dsList.Tables(0).Rows.Count > 0 AndAlso Not dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS").ToString.IsNulOrWS AndAlso Not ToAddressList.Contains(dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS")) Then
                    CCAddressList.Add(dsList.Tables(0).Rows(0).Item("MAIL_ADDRESS"))
                End If

                If ToAddressList.Count = 0 Then
                    MessageBox.Show("依頼先担当者のメールアドレスが設定されていないため、依頼メールを送信できません", "依頼メール送信", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                strMsg = $"【メール送信成功】TO:{strToSyainName}({ToAddressList(0)}) SUBJECT:{strSubject}"
                WL.WriteLogDat(strMsg)

            End Using

            '#If DEBUG Then
            '            Return True
            '#End If

            ''認証なし フジワラ
            blnSend = ClsMailSend.FunSendMail(strSmtpServer:=strSmtpServer,
                           intSmtpPort:=intSmtpPort,
                           FromAddress:=strFromAddress,
                           ToAddress:=ToAddressList,
                           CCAddress:=CCAddressList,
                           BCCAddress:=BCCAddressList,
                           strSubject:=strSubject,
                           strBody:=strBody,
                           AttachmentList:=New List(Of String),
                           strFromName:="FCCB管理",
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
            strMsg = String.Format("【メール送信失敗】TO:{0}({1}) SUBJECT:{2}" & vbCrLf & Err.Description, strToSyainName, ToAddressList(0), strSubject)
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

        sbSQL.Append("SELECT * FROM TV02_SYONIN_SYOZOKU_SYAIN('" & BUMON_KB.Trim & "')")
        If SYONIN_HOUKOKUSYO_ID > 0 Then
            sbSQL.Append(" WHERE SYONIN_HOKOKUSYO_ID=" & SYONIN_HOUKOKUSYO_ID & "")
            '承認順単独で検索されることはない
            sbSQL.Append(" AND SYONIN_JUN=" & SYONIN_JUN & "")
        End If
        sbSQL.Append(" ORDER BY SYONIN_HOKOKUSYO_ID,SYONIN_JUN,SYAIN_ID")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        'dt.Columns.Add("SYONIN_HOKOKUSYO_ID", GetType(Integer))
        'dt.Columns.Add("SYONIN_JUN", GetType(Integer))

        dt.PrimaryKey = {dt.Columns("VALUE")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        ''承認順未指定=報告書ID未指定 or 承認順=ST1 起草登録時はログインユーザーを追加
        'Select Case SYONIN_JUN
        '    Case 0, 10
        '        '#109 ログインユーザーを処置担当リストに追加
        '        Dim Trow2 As DataRow = dt.NewRow()
        '        If Not dt.Rows.Contains(pub_SYAIN_INFO.SYAIN_ID) Then
        '            Trow2("VALUE") = pub_SYAIN_INFO.SYAIN_ID
        '            Trow2("DISP") = pub_SYAIN_INFO.SYAIN_NAME
        '            dt.Rows.Add(Trow2)
        '        End If
        'End Select

        'システムユーザーログイン時はシステムユーザーを追加
        If pub_SYAIN_INFO.SYAIN_ID = 999999 Then
            Dim Trow3 As DataRow = dt.NewRow()
            If Not dt.Rows.Contains(pub_SYAIN_INFO.SYAIN_ID) Then
                Trow3("VALUE") = pub_SYAIN_INFO.SYAIN_ID
                Trow3("DISP") = pub_SYAIN_INFO.SYAIN_NAME
                dt.Rows.Add(Trow3)
            End If
        End If

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

    Public Function FunGetSYOZOKU_SYAIN(Optional BUMON_KB As String = "", Optional BUSYO_ID As Integer = 0, Optional GYOMU_GROUP_ID As Integer = 0) As DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet

        sbSQL.Append($"SELECT * FROM TV03_SYOZOKU_SYAIN('{BUMON_KB}')")
        sbSQL.Append(" WHERE 1=1")
        If GYOMU_GROUP_ID > 0 Then
            sbSQL.Append(" AND GYOMU_GROUP_ID=" & GYOMU_GROUP_ID & "")
        End If
        If BUSYO_ID > 0 Then
            sbSQL.Append(" AND BUSYO_ID=" & BUSYO_ID & "")
        End If
        sbSQL.Append(" ORDER BY SYAIN_ID, IS_LEADER DESC")
        Using DB As ClsDbUtility = DBOpen()
            dsList = DB.GetDataSet(sbSQL.ToString, False)
        End Using

        Dim dt As DataTableEx = New DataTableEx("System.Int32")
        dt.Columns.Add("BUMON_KB", GetType(String))
        dt.Columns.Add("BUSYO_ID", GetType(Integer))
        dt.Columns.Add("GYOMU_GROUP_ID", GetType(Integer))
        dt.Columns.Add("IS_LEADER", GetType(Boolean))

        dt.PrimaryKey = {dt.Columns("VALUE"), dt.Columns("GYOMU_GROUP_ID")} ', dt.Columns("SYONIN_JUN"), dt.Columns("SYONIN_HOKOKUSYO_ID")

        For Each row As DataRow In dsList.Tables(0).Rows
            Dim Trow As DataRow = dt.NewRow()
            If Not dt.Rows.Contains({row.Item("SYAIN_ID"), row.Item("GYOMU_GROUP_ID")}) Then
                Trow("VALUE") = row.Item("SYAIN_ID")
                Trow("DISP") = row.Item("SIMEI")
                Trow("BUMON_KB") = row.Item("BUMON_KB")
                Trow("BUSYO_ID") = row.Item("BUSYO_ID")
                Trow("GYOMU_GROUP_ID") = row.Item("GYOMU_GROUP_ID")
                Trow("IS_LEADER") = CBool(row.Item("IS_LEADER").ToString.ToVal)
                dt.Rows.Add(Trow)
            End If
        Next row

        Return dt
    End Function

#End Region

#Region "部門別不適合区分取得"

    Public Function FunGetFUTEKIGO_KB(BUMON_KB As String) As DataTableEx
        Dim dt As New DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Try

            If Not BUMON_KB.IsNulOrWS Then
                '通常
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME")
                sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{BUMON_KB}') ")
                sbSQL.Append($" ORDER BY FUTEKIGO_KB")
                Using DB As ClsDbUtility = DBOpen()
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                '主キー設定
                dt.PrimaryKey = {dt.Columns("VALUE")}

                For Each row In dsList.Tables(0).Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = row.Item("FUTEKIGO_KB_NAME").ToString.Trim
                    Trow("VALUE") = row.Item("FUTEKIGO_KB").ToString.Trim
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next
            Else
                '集計分析時、区分名で統合

                '主キー設定
                dt.PrimaryKey = {dt.Columns("DISP")}

                For iBUMON_KB As Integer = 1 To 3
                    sbSQL.Clear()
                    sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME")
                    sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{iBUMON_KB}') ")
                    sbSQL.Append($" ORDER BY FUTEKIGO_KB")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    For Each row In dsList.Tables(0).Rows
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("DISP") = row.Item("FUTEKIGO_KB_NAME").ToString.Trim
                        Trow("VALUE") = row.Item("FUTEKIGO_KB").ToString.Trim
                        Trow("DEL_FLG") = False
                        If Not dt.Rows.Contains(Trow("DISP")) Then
                            dt.Rows.Add(Trow)
                        End If
                    Next
                Next
            End If

            Return dt
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

#End Region

#Region "部門別不適合詳細区分取得"

    Public Function FunGetFUTEKIGO_S_KB(BUMON_KB As String, FUTEKIGO_KB As String) As DataTableEx
        Dim dt As New DataTableEx
        Dim sbSQL As New System.Text.StringBuilder
        Dim dsList As New DataSet
        Try

            If Not BUMON_KB.IsNulOrWS Then
                '通常
                sbSQL.Remove(0, sbSQL.Length)
                sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME,FUTEKIGO_S_KB,FUTEKIGO_S_KB_NAME")
                sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{BUMON_KB}') ")
                sbSQL.Append($" WHERE FUTEKIGO_KB='{FUTEKIGO_KB}'")
                sbSQL.Append($" ORDER BY FUTEKIGO_S_KB")
                Using DB As ClsDbUtility = DBOpen()
                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                End Using

                '主キー設定
                dt.PrimaryKey = {dt.Columns("VALUE")}

                For Each row In dsList.Tables(0).Rows
                    Dim Trow As DataRow = dt.NewRow()
                    Trow("DISP") = row.Item("FUTEKIGO_S_KB_NAME").ToString.Trim
                    Trow("VALUE") = row.Item("FUTEKIGO_S_KB").ToString.Trim
                    Trow("DEL_FLG") = False
                    dt.Rows.Add(Trow)
                Next
            Else
                '集計分析時、区分名で統合
                '主キー設定
                dt.PrimaryKey = {dt.Columns("DISP")}

                For iBUMON_KB As Integer = 1 To 3
                    sbSQL.Remove(0, sbSQL.Length)
                    sbSQL.Append($"SELECT DISTINCT FUTEKIGO_KB,FUTEKIGO_KB_NAME,FUTEKIGO_S_KB,FUTEKIGO_S_KB_NAME")
                    sbSQL.Append($" FROM TV05_FUTEKIGO_CODE('{iBUMON_KB}') ")
                    sbSQL.Append($" WHERE FUTEKIGO_KB_NAME='{FUTEKIGO_KB}'")
                    sbSQL.Append($" ORDER BY FUTEKIGO_S_KB")
                    Using DB As ClsDbUtility = DBOpen()
                        dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    End Using

                    For Each row In dsList.Tables(0).Rows
                        Dim Trow As DataRow = dt.NewRow()
                        Trow("DISP") = row.Item("FUTEKIGO_S_KB_NAME").ToString.Trim
                        Trow("VALUE") = row.Item("FUTEKIGO_S_KB").ToString.Trim
                        Trow("DEL_FLG") = False
                        If Not dt.Rows.Contains(Trow("DISP")) Then
                            dt.Rows.Add(Trow)
                        End If
                    Next
                Next
            End If

            Return dt
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

#End Region

#Region "報告書登録内容変更判定"

    Public Function FunChangedRecord(ByVal intHOKOKUSYO_ID As Integer, ByVal strHOKOKU_NO As String, strTargetYMDHNS As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try

            sbSQL.Append("SELECT * FROM " & NameOf(ST01_GET_HOKOKU_NO) & "")
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

    Public Function FunOpenWorkbook(filePath As String) As Boolean
        Dim workbookView As New SpreadsheetGear.Windows.Forms.WorkbookView
        Try
            workbookView.GetLock()
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
            workbookView.ReleaseLock()
        End Try
    End Function

    Public Function FunMakeReportFCCB(ByVal strFilePath As String, ByVal strHOKOKU_NO As String) As Boolean

        Dim spWorkbook As SpreadsheetGear.IWorkbook
        Dim spWorksheets As SpreadsheetGear.IWorksheets
        Dim spSheet1 As SpreadsheetGear.IWorksheet

        Try
            spWorkbook = SpreadsheetGear.Factory.GetWorkbook(strFilePath, System.Globalization.CultureInfo.CurrentCulture)

            spWorkbook.WorkbookSet.GetLock()
            spWorksheets = spWorkbook.Worksheets
            spSheet1 = spWorksheets.Item(0) 'sheet1

            ''---図形取得
            'Dim ssgShapes As SpreadsheetGear.Shapes.IShapes
            'Dim shapeLINE_SYOCHI_A1 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_A2 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_A3 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_B1 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_B2 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_B3 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_C1 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_C2 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_C3 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_C4 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SYOCHI_C5 As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_SEKKEI_TANTO As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeLINE_KOUKA_KAKUNIN As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeSCR_FUTEKIGO_YOUIN_T As SpreadsheetGear.Shapes.IShape = Nothing
            'Dim shapeSCR_FUTEKIGO_YOUIN_F As SpreadsheetGear.Shapes.IShape = Nothing

            'ssgShapes = spSheet1.Shapes
            'For Each shape As SpreadsheetGear.Shapes.IShape In ssgShapes
            '    Select Case shape.Name
            '        Case "LINE_SYOCHI_A1"
            '            shapeLINE_SYOCHI_A1 = shape
            '        Case "LINE_SYOCHI_A2"
            '            shapeLINE_SYOCHI_A2 = shape
            '        Case "LINE_SYOCHI_A3"
            '            shapeLINE_SYOCHI_A3 = shape
            '        Case "LINE_SYOCHI_B1"
            '            shapeLINE_SYOCHI_B1 = shape
            '        Case "LINE_SYOCHI_B2"
            '            shapeLINE_SYOCHI_B2 = shape
            '        Case "LINE_SYOCHI_B3"
            '            shapeLINE_SYOCHI_B3 = shape
            '        Case "LINE_SYOCHI_C1"
            '            shapeLINE_SYOCHI_C1 = shape
            '        Case "LINE_SYOCHI_C2"
            '            shapeLINE_SYOCHI_C2 = shape
            '        Case "LINE_SYOCHI_C3"
            '            shapeLINE_SYOCHI_C3 = shape
            '        Case "LINE_SYOCHI_C4"
            '            shapeLINE_SYOCHI_C4 = shape
            '        Case "LINE_SYOCHI_C5"
            '            shapeLINE_SYOCHI_C5 = shape
            '        Case "LINE_SEKKEI_TANTO"
            '            shapeLINE_SEKKEI_TANTO = shape
            '        Case "LINE_KOUKA_KAKUNIN"
            '            shapeLINE_KOUKA_KAKUNIN = shape
            '        Case "SCR_FUTEKIGO_YOUIN_T"
            '            shapeSCR_FUTEKIGO_YOUIN_T = shape
            '        Case "SCR_FUTEKIGO_YOUIN_F"
            '            shapeSCR_FUTEKIGO_YOUIN_F = shape
            '    End Select
            'Next shape
            ''---

            _D009 = FunGetD009Model(strHOKOKU_NO)

#Region "SEC1"

            spSheet1.Range(NameOf(_D009.FCCB_NO)).Value = _D009.FCCB_NO
            If Not _D009.ADD_YMDHNS.IsNulOrWS Then
                spSheet1.Range(NameOf(_D009.ADD_YMDHNS)).Value = CDate(_D009.ADD_YMDHNS).ToString("yyyy/MM/dd")
            End If

            spSheet1.Range("ADD_SYAIN_NAME").Value = Fun_GetUSER_NAME(_D009.ADD_SYAIN_ID)
            spSheet1.Range(NameOf(_D009.CM_TANTO)).Value = Fun_GetUSER_NAME(_D009.CM_TANTO)
            spSheet1.Range("KISYU_NAME").Value = tblKISYU.LazyLoad("機種").
                                                AsEnumerable.
                                                Where(Function(r) r.Field(Of Integer)("VALUE") = _D009.KISYU_ID).
                                                FirstOrDefault?.Item("DISP")

            spSheet1.Range(NameOf(_D009.BUHIN_BANGO)).Value = _D009.BUHIN_BANGO
            spSheet1.Range(NameOf(_D009.BUHIN_NAME)).Value = _D009.BUHIN_NAME
            spSheet1.Range(NameOf(_D009.INPUT_DOC_NO)).Value = _D009.INPUT_DOC_NO
            spSheet1.Range(NameOf(_D009.INPUT_NAIYO)).Value = _D009.INPUT_NAIYO
            spSheet1.Range(NameOf(_D009.SNO_APPLY_PERIOD_KISO)).Value = _D009.SNO_APPLY_PERIOD_KISO

#End Region

            Using DB As ClsDbUtility = DBOpen()
                Dim sbSQL As New System.Text.StringBuilder
                Dim dsList As DataSet
                Dim D010 As D010_FCCB_SUB_SYOCHI_KOMOKU
                Dim D011 As D011_FCCB_SUB_SIKAKE_BUHIN
                Dim D012 As D012_FCCB_SUB_SYOCHI_KAKUNIN

                If Not _D009.FILE_PATH.IsNulOrWS Then
                    Dim rootdir = FunConvPathString(FunGetCodeMastaValue(DB, "添付ファイル保存先", My.Application.Info.AssemblyName))
                    Dim path As String = rootdir & _D009.FILE_PATH
                    spSheet1.Hyperlinks.Add(spSheet1.Range(NameOf(_D009.FILE_PATH)), path, Nothing, path, "添付資料")
                End If

#Region "SEC2"

                Dim intRowIndex As Integer = 15
                sbSQL.Clear()
                sbSQL.Append($"SELECT")
                sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT GYOMU_GROUP_NAME FROM {NameOf(M003_GYOMU_GROUP)} AS M WHERE(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_GYOMU_GROUP_ID = M.GYOMU_GROUP_ID)),'') AS GYOMU_GROUP_NAME")
                sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT SIMEI FROM M004_SYAIN AS M WHERE(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_ID = M.SYAIN_ID)),'') AS TANTO_SYAIN_NAME")
                sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}<100 ")
                sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                For Each r As DataRow In dsList.Tables(0).Rows

                    If spSheet1.Range($"AE{intRowIndex + 1}").Value?.ToString = "na" Then
                        'ブランク行はスキップ
                        intRowIndex += 1
                    End If
                    spSheet1.Range($"C{intRowIndex + 1}").Value = r.Item(NameOf(D010.ITEM_NAME))
                    If Not r.Item("GYOMU_GROUP_NAME").ToString.IsNulOrWS Then
                        spSheet1.Range($"I{intRowIndex + 1}").Value = r.Item("GYOMU_GROUP_NAME")
                    End If
                    spSheet1.Range($"AE{intRowIndex + 1}").Value = r.Item(NameOf(D010.YOHI_KB))
                    spSheet1.Range($"L{intRowIndex + 1}").Value = r.Item("TANTO_SYAIN_NAME")
                    spSheet1.Range($"O{intRowIndex + 1}").Value = r.Item(NameOf(D010.NAIYO))
                    spSheet1.Range($"Y{intRowIndex + 1}").Value = If(r.Item(NameOf(D010.YOTEI_YMD)).ToString.IsNulOrWS, "", r.Item(NameOf(D010.YOTEI_YMD)))
                    spSheet1.Range($"AB{intRowIndex + 1}").Value = If(r.Item(NameOf(D010.CLOSE_YMD)).ToString.IsNulOrWS, "", r.Item(NameOf(D010.CLOSE_YMD)))

                    intRowIndex += 1
                Next

#End Region

#Region "SEC3"

                sbSQL.Clear()
                sbSQL.Append($"SELECT")
                sbSQL.Append($"  {NameOf(D010.FCCB_NO)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_NO)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_GROUP_NAME)}")
                sbSQL.Append($" ,{NameOf(D010.ITEM_NAME)}")
                sbSQL.Append($" ,{NameOf(D010.TANTO_GYOMU_GROUP_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT GYOMU_GROUP_NAME FROM {NameOf(M003_GYOMU_GROUP)} AS M WHERE(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_GYOMU_GROUP_ID = M.GYOMU_GROUP_ID)),'') AS GYOMU_GROUP_NAME")
                sbSQL.Append($" ,{NameOf(D010.YOHI_KB)}")
                sbSQL.Append($" ,{NameOf(D010.TANTO_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT SIMEI FROM M004_SYAIN AS M WHERE(D010_FCCB_SUB_SYOCHI_KOMOKU.TANTO_ID = M.SYAIN_ID)),'') AS TANTO_SYAIN_NAME")
                sbSQL.Append($" ,{NameOf(D010.NAIYO)}")
                sbSQL.Append($" ,{NameOf(D010.GOKI)}")
                sbSQL.Append($" ,IIF({NameOf(D010.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.YOTEI_YMD)}")
                sbSQL.Append($" ,IIF({NameOf(D010.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D010.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D010.CLOSE_YMD)}")
                sbSQL.Append($" FROM {NameOf(D010_FCCB_SUB_SYOCHI_KOMOKU)} ")
                sbSQL.Append($" WHERE {NameOf(D010.ITEM_NO)}>100 ")
                sbSQL.Append($" AND {NameOf(D010.FCCB_NO)}='{_D009.FCCB_NO}' ")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                intRowIndex = 53
                For Each r As DataRow In dsList.Tables(0).Rows
                    If spSheet1.Range($"B{intRowIndex + 1}").Value?.ToString.IsNulOrWS Then
                        'ブランク行はスキップ
                        intRowIndex += 1
                    End If
                    spSheet1.Range($"AE{intRowIndex + 1}").Value = r.Item(NameOf(D010.YOHI_KB))
                    spSheet1.Range($"I{intRowIndex + 1}").Value = r.Item("TANTO_SYAIN_NAME")
                    spSheet1.Range($"L{intRowIndex + 1}").Value = r.Item(NameOf(D010.NAIYO))
                    spSheet1.Range($"U{intRowIndex + 1}").Value = r.Item(NameOf(D010.GOKI))
                    spSheet1.Range($"Y{intRowIndex + 1}").Value = r.Item(NameOf(D010.YOTEI_YMD))
                    spSheet1.Range($"AB{intRowIndex + 1}").Value = r.Item(NameOf(D010.CLOSE_YMD))

                    intRowIndex += 1
                Next

#End Region

#Region "SEC4"

                sbSQL.Clear()
                sbSQL.Append($"SELECT")
                sbSQL.Append($"  {NameOf(D011.FCCB_NO)}")
                sbSQL.Append($" ,{NameOf(D011.ITEM_NO)}")
                sbSQL.Append($" ,{NameOf(D011.BUHIN_HINBAN)}")
                sbSQL.Append($" ,{NameOf(D011.BUHIN_NAME)}")
                sbSQL.Append($" ,{NameOf(D011.MEMO1)}")
                sbSQL.Append($" ,{NameOf(D011.MEMO2)}")
                sbSQL.Append($" ,{NameOf(D011.SURYO)}")
                sbSQL.Append($" ,{NameOf(D011.SYOCHI_NAIYO)}")
                sbSQL.Append($" ,{NameOf(D011.TANTO_GYOMU_GROUP_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT GYOMU_GROUP_NAME FROM {NameOf(M003_GYOMU_GROUP)} AS M WHERE(D011_FCCB_SUB_SIKAKE_BUHIN.TANTO_GYOMU_GROUP_ID = M.GYOMU_GROUP_ID)),'') AS GYOMU_GROUP_NAME")
                sbSQL.Append($" ,{NameOf(D011.TANTO_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT SIMEI FROM M004_SYAIN AS M WHERE(D011_FCCB_SUB_SIKAKE_BUHIN.TANTO_ID = M.SYAIN_ID)),'') AS TANTO_SYAIN_NAME")
                sbSQL.Append($" ,IIF({NameOf(D011.YOTEI_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.YOTEI_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.YOTEI_YMD)}")
                sbSQL.Append($" ,IIF({NameOf(D011.CLOSE_YMD)}='','',FORMAT(CONVERT(DATETIME, {NameOf(D011.CLOSE_YMD)}),'yyyy/MM/dd')) AS {NameOf(D011.CLOSE_YMD)}")
                sbSQL.Append($" FROM {NameOf(D011_FCCB_SUB_SIKAKE_BUHIN)} ")
                sbSQL.Append($" WHERE {NameOf(D011.FCCB_NO)}='{_D009.FCCB_NO}' ")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                intRowIndex = 59
                Const SIKAKARIHIN_COUNT As Integer = 7
                Const SECTION_GAPS As Integer = 5
                For Each r As DataRow In dsList.Tables(0).Rows
                    spSheet1.Range($"C{intRowIndex + 1}").Value = r.Item(NameOf(D011.BUHIN_HINBAN))
                    spSheet1.Range($"K{intRowIndex + 1}").Value = r.Item(NameOf(D011.BUHIN_NAME))
                    spSheet1.Range($"R{intRowIndex + 1}").Value = r.Item(NameOf(D011.MEMO1))
                    spSheet1.Range($"X{intRowIndex + 1}").Value = r.Item(NameOf(D011.MEMO2))
                    spSheet1.Range($"X{intRowIndex + 1}").Value = If(r.Item(NameOf(D011.SURYO)) = 0, "", r.Item(NameOf(D011.SURYO)))

                    'Sec5パート
                    spSheet1.Range($"C{intRowIndex + 1 + SIKAKARIHIN_COUNT + SECTION_GAPS}").Value = r.Item(NameOf(D011.SYOCHI_NAIYO))
                    spSheet1.Range($"T{intRowIndex + 1 + SIKAKARIHIN_COUNT + SECTION_GAPS}").Value = r.Item("GYOMU_GROUP_NAME")
                    spSheet1.Range($"V{intRowIndex + 1 + SIKAKARIHIN_COUNT + SECTION_GAPS}").Value = r.Item("TANTO_SYAIN_NAME")
                    spSheet1.Range($"Y{intRowIndex + 1 + SIKAKARIHIN_COUNT + SECTION_GAPS}").Value = r.Item(NameOf(D011.YOTEI_YMD))
                    spSheet1.Range($"AB{intRowIndex + 1 + SIKAKARIHIN_COUNT + SECTION_GAPS}").Value = r.Item(NameOf(D011.CLOSE_YMD))

                    intRowIndex += 1
                Next

#End Region

#Region "SEC5"

                sbSQL.Clear()
                sbSQL.Append($"SELECT")
                sbSQL.Append($" {NameOf(D012.FCCB_NO)}")
                sbSQL.Append($" ,{NameOf(D012.GYOMU_GROUP_ID)}")
                sbSQL.Append($" ,{NameOf(D012.TANTO_ID)}")
                sbSQL.Append($" ,ISNULL((SELECT SIMEI FROM M004_SYAIN AS M WHERE(TANTO_ID = M.SYAIN_ID)),'') AS TANTO_SYAIN_NAME")
                sbSQL.Append($" ,IIF({NameOf(D012.ADD_YMDHNS)}='','',FORMAT(CONVERT(DATETIME, SUBSTRING({NameOf(D012.ADD_YMDHNS)},1,8)),'yyyy/MM/dd')) AS {NameOf(D012.ADD_YMDHNS)}")
                sbSQL.Append($" FROM {NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN)} ")
                sbSQL.Append($" WHERE {NameOf(D012.FCCB_NO)}='{_D009.FCCB_NO}' ")
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)

                spSheet1.Range(NameOf(_D009.SNO_APPLY_PERIOD_HENKO_SINGI)).Value = _D009.SNO_APPLY_PERIOD_HENKO_SINGI
                For Each r As DataRow In dsList.Tables(0).Rows
                    Dim NAMERange As String = ""

                    Select Case r.Item(NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN.GYOMU_GROUP_ID))
                        Case ENM_GYOMU_GROUP_ID._2_製造.Value
                            NAMERange = "SYOCHI_SEIZO_TANTO"

                        Case ENM_GYOMU_GROUP_ID._3_検査.Value
                            NAMERange = "SYOCHI_KENSA_TANTO"

                        Case ENM_GYOMU_GROUP_ID._4_品証.Value
                            NAMERange = "SYOCHI_HINSYO_TANTO"

                        Case ENM_GYOMU_GROUP_ID._5_設計.Value
                            NAMERange = "SYOCHI_SEKKEI_TANTO"

                        Case ENM_GYOMU_GROUP_ID._6_生技.Value
                            NAMERange = "SYOCHI_SEIGI_TANTO"

                        Case ENM_GYOMU_GROUP_ID._7_管理.Value
                            NAMERange = "SYOCHI_KANRI_TANTO"

                        Case ENM_GYOMU_GROUP_ID._8_営業.Value
                            NAMERange = "SYOCHI_EIGYO_TANTO"

                        Case ENM_GYOMU_GROUP_ID._9_購買.Value
                            NAMERange = "SYOCHI_KOBAI_TANTO"

                        Case ENM_GYOMU_GROUP_ID._91_QMS管理責任者.Value '統括責任者
                            NAMERange = "SYOCHI_GM_TANTO"

                        Case "92" 'FCCB完了確認 FCCB議長
                            NAMERange = "KAKUNIN_CM_TANTO"
                        Case "93" 'FCCB完了確認 統括責任者
                            NAMERange = "KAKUNIN_GM_TANTO"
                        Case Else
                            Throw New ArgumentException("想定外の業務グループIDです", r.Item(NameOf(D012_FCCB_SUB_SYOCHI_KAKUNIN.GYOMU_GROUP_ID)).ToString)
                    End Select

                    spSheet1.Range(NAMERange).Value = r.Item("TANTO_SYAIN_NAME")
                    spSheet1.Range(NAMERange & "_YMD").Value = r.Item("ADD_YMDHNS")

                Next

#End Region

            End Using

            '-----ファイル保存
            spSheet1.SaveAs(filename:=strFilePath, fileFormat:=SpreadsheetGear.FileFormat.OpenXMLWorkbook)
            spWorkbook.WorkbookSet.ReleaseLock()

            ''-----Spire版 直接PDF発行するならこっち
            'Dim workbook As New Spire.Xls.Workbook
            'workbook.LoadFromFile(strFilePath)
            'Dim pdfFilePath As String
            'pdfFilePath = System.IO.Path.GetDirectoryName(strFilePath) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFilePath) & ".pdf"
            'workbook.SaveToFile(pdfFilePath, Spire.Xls.FileFormat.PDF)
            ''PDF表示
            'System.Diagnostics.Process.Start(pdfFilePath)

            'Call FunOpenWorkbook(strFilePath)
            Call OpenExcelPrintPreview(strFilePath)

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

#End Region

#Region "業務グループ権限確認"

    Public Function HasGYOMUGroupAuth(SYAIN_ID As Integer, GROUP_IDs As ENM_GYOMU_GROUP_ID()) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try
            Using DB As ClsDbUtility = DBOpen()
                For Each id In GROUP_IDs
                    sbSQL.Clear()
                    sbSQL.Append($"SELECT {NameOf(M011_SYAIN_GYOMU.SYAIN_ID)} FROM {NameOf(M011_SYAIN_GYOMU)}")
                    sbSQL.Append($" WHERE {NameOf(M011_SYAIN_GYOMU.SYAIN_ID)}={SYAIN_ID}")
                    sbSQL.Append($" AND {NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)}={id.Value}")

                    dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
                    If dsList.Tables(0).Rows.Count > 0 Then Return True
                Next
            End Using

            Return False
        Catch ex As Exception
            Throw
            Return False
        End Try
    End Function

    Public Function GetSYAIN_GYOMUGroups(SYAIN_ID As Integer) As List(Of ENM_GYOMU_GROUP_ID)
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim retlist As New List(Of ENM_GYOMU_GROUP_ID)
        Try
            sbSQL.Append($"SELECT {NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)} FROM {NameOf(M011_SYAIN_GYOMU)}")
            sbSQL.Append($" WHERE {NameOf(M011_SYAIN_GYOMU.SYAIN_ID)}={SYAIN_ID}")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            For Each row As DataRow In dsList.Tables(0).Rows
                retlist.Add(row.Item(NameOf(M011_SYAIN_GYOMU.GYOMU_GROUP_ID)))
            Next

            If retlist.Contains(ENM_GYOMU_GROUP_ID._43_品検) Then
                If Not retlist.Contains(ENM_GYOMU_GROUP_ID._3_検査) Then retlist.Add(ENM_GYOMU_GROUP_ID._3_検査)
                If Not retlist.Contains(ENM_GYOMU_GROUP_ID._4_品証) Then retlist.Add(ENM_GYOMU_GROUP_ID._4_品証)
            End If
            If retlist.Contains(ENM_GYOMU_GROUP_ID._3_検査) Or retlist.Contains(ENM_GYOMU_GROUP_ID._4_品証) Then
                If Not retlist.Contains(ENM_GYOMU_GROUP_ID._43_品検) Then retlist.Add(ENM_GYOMU_GROUP_ID._43_品検)
            End If

            Return retlist
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

#Region "報告書起草者判定"

    Public Function IsIssuedUser(SYAIN_ID As Integer, SYONIN_HOKOKUSYO_ID As Integer, HOKOKU_NO As String) As Boolean
        Dim dsList As New DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Try

            sbSQL.Append($"SELECT *")
            sbSQL.Append($" FROM {NameOf(V004_HOKOKU_SOUSA)}")
            sbSQL.Append($" WHERE (SELECT CASE {NameOf(V004_HOKOKU_SOUSA.SOUSA_KB)} WHEN '{ENM_SOUSA_KB._5_転送.Value}'")
            sbSQL.Append($"     THEN {NameOf(V004_HOKOKU_SOUSA.MODOSI_SAKI_SYAIN_ID)} ELSE {NameOf(V004_HOKOKU_SOUSA.SYAIN_ID)} END)={SYAIN_ID}")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.SYONIN_HOKOKUSYO_ID)}={SYONIN_HOKOKUSYO_ID}")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.HOKOKU_NO)}='{HOKOKU_NO}'")
            sbSQL.Append($" AND {NameOf(V004_HOKOKU_SOUSA.SYONIN_JUN)}=10")

            'sbSQL.Append($"SELECT {NameOf(V007_NCR_CAR.KISO_TANTO_ID)} FROM {NameOf(V007_NCR_CAR)}")
            'sbSQL.Append($" WHERE {NameOf(V007_NCR_CAR.KISO_TANTO_ID)}={SYAIN_ID}")
            'sbSQL.Append($" AND {NameOf(V007_NCR_CAR.SYONIN_HOKOKUSYO_ID)}={SYONIN_HOKOKUSYO_ID}")
            'sbSQL.Append($" AND {NameOf(V007_NCR_CAR.HOKOKU_NO)}='{HOKOKU_NO}'")

            Using DB As ClsDbUtility = DBOpen()
                dsList = DB.GetDataSet(sbSQL.ToString, conblnNonMsg)
            End Using

            Return dsList.Tables(0).Rows.Count > 0
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

    Public Sub ShowUnimplemented()
        MessageBox.Show("未実装", "未実装", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

End Module