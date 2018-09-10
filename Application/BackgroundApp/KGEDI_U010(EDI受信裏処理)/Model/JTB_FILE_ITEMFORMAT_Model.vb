''' <summary>
''' JTB_FILE_ITEMFORMAT(ファイル出力編成項目情報)データモデル
''' </summary>
''' <remarks></remarks>
Public Class JTB_FILE_ITEMFORMAT_Model
    Public Const SourceTableName As String = "JTB_FILE_ITEMFORMAT"

#Region "メンバ"
    Public Property FILE_ID As Integer
    Public Property ITEM_RENBAN As Integer
    Public Property ITEM_NM As String
    Public Property ITEM_LEN As String
    Public Property ITEM_FORMAT As String
    Public Property HISSU_FLG As String

#End Region

#Region "メソッド"

#End Region

End Class


Public Class JTB_FILE_ITEMFORMAT_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of Integer(), JTB_FILE_ITEMFORMAT_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of Integer(), JTB_FILE_ITEMFORMAT_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of Integer(), JTB_FILE_ITEMFORMAT_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of Integer(), JTB_FILE_ITEMFORMAT_Model))
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
    Public Sub Load(ByVal DB As clsDbUtility)
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            sbSQL.Append("SELECT * FROM " & JTB_FILE_ITEMFORMAT_Model.SourceTableName & " ")
            dsList = DB.GetDataSet(sbSQL.ToString, False)
            If dsList IsNot Nothing Then
                _Entities.Clear()
                With dsList.Tables(0)
                    For intCNT = 0 To .Rows.Count - 1
                        Dim context As New JTB_FILE_ITEMFORMAT_Model
                        context.FILE_ID = .Rows(intCNT).Item("FILE_ID").ToString.TrimEnd
                        context.ITEM_RENBAN = .Rows(intCNT).Item("ITEM_RENBAN").ToString.TrimEnd
                        context.ITEM_NM = .Rows(intCNT).Item("ITEM_NM").ToString.TrimEnd
                        context.ITEM_LEN = .Rows(intCNT).Item("ITEM_LEN").ToString.TrimEnd
                        context.ITEM_FORMAT = .Rows(intCNT).Item("ITEM_FORMAT").ToString.TrimEnd
                        context.HISSU_FLG = .Rows(intCNT).Item("HISSU_FLG").ToString.TrimEnd

                        'リストに追加
                        _Entities.Add({context.FILE_ID, context.ITEM_RENBAN}, context)
                    Next intCNT
                End With
            Else
                'UNDONE: エラーメール テーブルが存在しない場合

            End If
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

    Public Function ToList(ByVal DB As clsDbUtility, ByVal FILE_ID As Integer) As List(Of JTB_FILE_ITEMFORMAT_Model)
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder
        Dim list As New List(Of JTB_FILE_ITEMFORMAT_Model)
        Try
            sbSQL.Append("SELECT * FROM JTB_FILE_ITEMFORMAT ")
            sbSQL.Append(" WHERE FILE_ID ='" & FILE_ID & "'")
            sbSQL.Append(" ORDER BY ITEM_RENBAN ")
            dsList = DB.GetDataSet(sbSQL.ToString, False)

            Using dsList
                With dsList.Tables(0)
                    For intCNT = 0 To .Rows.Count - 1
                        Dim context As New JTB_FILE_ITEMFORMAT_Model
                        context.FILE_ID = .Rows(intCNT).Item("FILE_ID").ToString.TrimEnd
                        context.ITEM_RENBAN = .Rows(intCNT).Item("ITEM_RENBAN").ToString.TrimEnd
                        context.ITEM_NM = .Rows(intCNT).Item("ITEM_NM").ToString.TrimEnd
                        context.ITEM_LEN = .Rows(intCNT).Item("ITEM_LEN").ToString.TrimEnd
                        context.ITEM_FORMAT = .Rows(intCNT).Item("ITEM_FORMAT").ToString.TrimEnd
                        context.HISSU_FLG = .Rows(intCNT).Item("HISSU_FLG").ToString.TrimEnd

                        'リストに追加
                        list.Add(context)
                    Next intCNT
                End With
            End Using

            Return list

        Catch ex As Exception
            EM.ErrorSyori(ex, False, True)
            Return Nothing
        End Try
    End Function


#End Region



End Class
