Imports KGEDI_COMMON.clsPubMethod


''' <summary>
''' JTB_RECVARG_JO(ファイル受信設定)データモデル
''' </summary>
''' <remarks></remarks>
Public Class JTB_RECVARG_JO_Model

    Public Const SourceTableName As String = "JTB_RECVARG_JO"

#Region "メンバ"

    ''' <summary>
    ''' ファイル受信設定ID
    ''' </summary>
    Public Property RECV_SETTING_ID As Integer
    Public Property RECV_SETTING_NM As String
    Public Property FILE_KB As String
    Public Property RECV_GROUP_NO As Integer
    Public Property EDICOM_PATH_NO As Integer
    Public Property BAT_NM As String
    Public Property RECV_YMDHNS As DateTime

    Public Property JUCHU_TKS_CD As String
    Public Property JUCHU_KOU_CD As String
    Public Property HACHU_TKS_CD As String
    Public Property HACHU_KOU_CD As String
    Public Property SYR_YM As String
    Public Property SYUKKA_TKS_CD As String
    Public Property SYUKKA_KOU_CD As String
    Public Property SYUKKA_BA As String
    Public Property NOU_TKS_CD As String
    Public Property NOU_KOU_CD As String
    Public Property UKEIRE As String
    Public Property DATE_FROM As String
    Public Property DATE_TO As String
    Public Property RECV_TERM As Integer
    Public Property RE_RECV_FLG As Boolean
    Public Property ENABLE_FLG As Boolean

    Public Property EDICOM_PATH As String

    ''' <summary>
    ''' 次回受信開始日時
    ''' </summary>
    Public Property NEXT_RECV_YMDHNS As DateTime

#End Region

#Region "コンストラクタ"
    Public Sub New()

    End Sub

#End Region

#Region "メソッド"

#End Region

End Class

''' <summary>
''' JTB_RECVARG_JO(ファイル受信設定)データリストモデル
''' </summary>
''' <remarks></remarks>
Public Class JTB_RECVARG_JO_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of Integer, JTB_RECVARG_JO_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of Integer, JTB_RECVARG_JO_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of Integer, JTB_RECVARG_JO_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of Integer, JTB_RECVARG_JO_Model))
            _Entities = value
        End Set
    End Property
#End Region

#Region "メソッド"

    ''' <summary>
    ''' 最新のファイル受信設定情報を読み込みます。
    ''' </summary>
    ''' <param name="DB">接続DB</param>
    ''' <remarks></remarks>
    Public Sub Load(ByRef DB As clsDbUtility, Optional ByVal strWhere As String = "")
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim dtBUFF As DateTime
        Dim dtNow As DateTime = DateTime.Now
        Try
            sbSQL.Append("SELECT ")
            sbSQL.Append("RECV_SETTING_ID, ")
            sbSQL.Append("RECV_SETTING_NM, ")
            sbSQL.Append("FILE_KB, ")
            sbSQL.Append("RECV_GROUP_NO, ")
            sbSQL.Append("EDICOM_PATH_NO, ")
            sbSQL.Append("(select DISP from MTB_CODE M where M.KOMO_NM = 'EDICOM_PATH' AND M.VALUE = R.EDICOM_PATH_NO) AS EDICOM_PATH, ")
            sbSQL.Append("BAT_NM, ")
            sbSQL.Append("RECV_YMDHNS, ")

            sbSQL.Append("JUCHU_TKS_CD, ")
            sbSQL.Append("JUCHU_KOU_CD, ")
            sbSQL.Append("HACHU_TKS_CD, ")
            sbSQL.Append("HACHU_KOU_CD, ")
            sbSQL.Append("SYR_YM, ")
            sbSQL.Append("SYUKKA_TKS_CD, ")
            sbSQL.Append("SYUKKA_KOU_CD, ")
            sbSQL.Append("SYUKKA_BA, ")
            sbSQL.Append("NOU_TKS_CD, ")
            sbSQL.Append("NOU_KOU_CD, ")
            sbSQL.Append("UKEIRE, ")
            sbSQL.Append("DATE_FROM, ")
            sbSQL.Append("DATE_TO, ")
            sbSQL.Append("RECV_TERM, ")
            sbSQL.Append("RE_RECV_FLG, ")
            sbSQL.Append("ENABLE_FLG ")
            sbSQL.Append("FROM " & JTB_RECVARG_JO_Model.SourceTableName & " R ")
            If strWhere <> "" Then
                sbSQL.Append(strWhere)
            End If
            dsList = DB.GetDataSet(sbSQL.ToString, False)

            _Entities.Clear()
            With dsList.Tables(0)
                For intCNT = 0 To .Rows.Count - 1
                    Dim context As New JTB_RECVARG_JO_Model
                    context.RECV_SETTING_ID = .Rows(intCNT).Item("RECV_SETTING_ID").ToString.TrimEnd
                    context.RECV_SETTING_NM = .Rows(intCNT).Item("RECV_SETTING_NM").ToString.TrimEnd
                    context.FILE_KB = .Rows(intCNT).Item("FILE_KB").ToString.TrimEnd
                    context.RECV_GROUP_NO = Val(.Rows(intCNT).Item("RECV_GROUP_NO").ToString.TrimEnd)
                    context.EDICOM_PATH_NO = .Rows(intCNT).Item("EDICOM_PATH_NO").ToString.TrimEnd
                    context.BAT_NM = .Rows(intCNT).Item("BAT_NM").ToString.TrimEnd

                    context.JUCHU_TKS_CD = .Rows(intCNT).Item("JUCHU_TKS_CD").ToString.TrimEnd
                    context.JUCHU_KOU_CD = .Rows(intCNT).Item("JUCHU_KOU_CD").ToString.TrimEnd
                    context.HACHU_TKS_CD = .Rows(intCNT).Item("HACHU_TKS_CD").ToString.TrimEnd
                    context.HACHU_KOU_CD = .Rows(intCNT).Item("HACHU_KOU_CD").ToString.TrimEnd
                    context.SYR_YM = .Rows(intCNT).Item("SYR_YM").ToString.TrimEnd
                    context.SYUKKA_TKS_CD = .Rows(intCNT).Item("SYUKKA_TKS_CD").ToString.TrimEnd
                    context.SYUKKA_KOU_CD = .Rows(intCNT).Item("SYUKKA_KOU_CD").ToString.TrimEnd
                    context.SYUKKA_BA = .Rows(intCNT).Item("SYUKKA_BA").ToString.TrimEnd
                    context.NOU_TKS_CD = .Rows(intCNT).Item("NOU_TKS_CD").ToString.TrimEnd
                    context.NOU_KOU_CD = .Rows(intCNT).Item("NOU_KOU_CD").ToString.TrimEnd
                    context.UKEIRE = .Rows(intCNT).Item("UKEIRE").ToString.TrimEnd
                    context.DATE_FROM = .Rows(intCNT).Item("DATE_FROM").ToString.TrimEnd
                    context.DATE_TO = .Rows(intCNT).Item("DATE_TO").ToString.TrimEnd

                    context.RECV_TERM = Val(.Rows(intCNT).Item("RECV_TERM").ToString.TrimEnd)
                    If Val(.Rows(intCNT).Item("RE_RECV_FLG").ToString.TrimEnd) = 0 Then
                        context.RE_RECV_FLG = False
                    Else
                        context.RE_RECV_FLG = True
                    End If
                    If Val(.Rows(intCNT).Item("ENABLE_FLG").ToString.TrimEnd) = 0 Then
                        context.ENABLE_FLG = False
                    Else
                        context.ENABLE_FLG = True
                    End If
                    context.EDICOM_PATH = FunConvPathString(.Rows(intCNT).Item("EDICOM_PATH").ToString.TrimEnd)

                    If DateTime.TryParseExact(.Rows(intCNT).Item("RECV_YMDHNS").ToString.TrimEnd, "yyyyMMddHHmmss", Nothing, Nothing, dtBUFF) = True Then
                        context.RECV_YMDHNS = dtBUFF
                    Else
                        context.RECV_YMDHNS = Nothing
                    End If
                    If IsNothing(context.RECV_YMDHNS) = False Then
                        context.NEXT_RECV_YMDHNS = context.RECV_YMDHNS.AddMinutes(context.RECV_TERM)
                    Else
                        '未受信の場合
                        context.NEXT_RECV_YMDHNS = Nothing
                    End If

                    '有効な受信設定のみリストに追加する

                    If context.ENABLE_FLG = True Then
                        _Entities.Add(context.RECV_SETTING_ID, context)
                    End If

                    '全てリストに追加
                    '_Entities.Clear()
                    '_Entities.Add(context.RECV_SETTING_ID, context)
                Next intCNT
            End With

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' 通信グループのリストを取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRECV_GROUP_List() As List(Of Integer)
        Dim list As New List(Of Integer)
        Try
            For Each entity As JTB_RECVARG_JO_Model In _Entities.Values.OrderBy(Function(p) p.RECV_GROUP_NO)
                If list.Contains(entity.RECV_GROUP_NO) = False Then
                    list.Add(entity.RECV_GROUP_NO)
                End If
            Next entity

            Return list
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 通信グループ内の最終受信日時を取得
    ''' </summary>
    ''' <param name="intGroupNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLastRECV_YMDHNS(ByVal intGroupNo As Integer) As Nullable(Of DateTime)
        Dim strBUFF As String = ""
        Dim dtBUFF As DateTime
        Try
            strBUFF = _Entities.Values.
                Where(Function(p) p.RECV_GROUP_NO = intGroupNo).
                OrderByDescending(Function(p) p.RECV_YMDHNS).
                First.RECV_YMDHNS.ToString("yyyyMMddHHmmss")

            DateTime.TryParseExact(strBUFF, "yyyyMMddHHmmss", Nothing, Nothing, dtBUFF)

            Return dtBUFF
        Catch ex As InvalidOperationException
            '通信グループの全ての設定が未受信の場合…ラムダ式内でNull値の比較処理の実行エラー
            Return Nothing
        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' 通信グループ単位の受信設定エンティティリストを取得
    ''' </summary>
    ''' <param name="intGroupNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEntitiesByGroupNo(ByVal intGroupNo As Integer) As List(Of JTB_RECVARG_JO_Model)
        Dim list As New List(Of JTB_RECVARG_JO_Model)

        Try

            list = _Entities.Values.Where(Function(p) p.RECV_GROUP_NO = intGroupNo).
                OrderBy(Function(p) p.NEXT_RECV_YMDHNS).ToList  '次回取得開始日時の昇順

            Return list
        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            Return Nothing
        End Try
    End Function

#End Region



End Class
