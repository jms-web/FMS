''' <summary>
''' JTB_RECVFILE_JO(ファイル出力編成情報)データモデル
''' </summary>
''' <remarks></remarks>
Public Class JTB_RECVFILE_JO_Model
    Public Const SourceTableName As String = "JTB_RECVFILE_JO"

#Region "メンバ"
    Public Property FILE_ID As Integer
    Public Property FILE_KB As String
    Public Property FILE_NM As String
    Public Property OUTPUT_PATH As String
    Public Property FILE_NM_FORMAT As String
    Public Property FILE_FORMAT As String
    Public Property AUTOMAKE_FLG As String
    Public Property BACKUP_TERM As Integer
    Public Property RECV_TERM As Integer
    Public Property WHERE_EXPRESSION As String
    Public Property REF_OBJECT_NM As String
    Public Property LASTIMP_FILE_NM As String
    Public Property LASTIMP_YMDHNS As String


#End Region

#Region "メソッド"

#End Region

End Class


Public Class JTB_RECVFILE_JO_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of String, JTB_RECVFILE_JO_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of String, JTB_RECVFILE_JO_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of String, JTB_RECVFILE_JO_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of String, JTB_RECVFILE_JO_Model))
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
            sbSQL.Append("SELECT * FROM " & JTB_RECVFILE_JO_Model.SourceTableName & " ")
            dsList = DB.GetDataSet(sbSQL.ToString, True)

            If dsList IsNot Nothing Then
                With dsList.Tables(0)
                    For intCNT = 0 To .Rows.Count - 1
                        Dim context As New JTB_RECVFILE_JO_Model
                        context.FILE_ID = .Rows(intCNT).Item("FILE_ID").ToString.TrimEnd
                        context.FILE_KB = .Rows(intCNT).Item("FILE_KB").ToString.TrimEnd
                        context.FILE_NM = .Rows(intCNT).Item("FILE_NM").ToString.TrimEnd
                        context.OUTPUT_PATH = .Rows(intCNT).Item("OUTPUT_PATH").ToString.TrimEnd
                        If context.OUTPUT_PATH <> "" Then
                            If context.OUTPUT_PATH.LastIndexOf("\") <> context.OUTPUT_PATH.Length - 1 Then
                                'パスの最後に\を付ける
                                context.OUTPUT_PATH &= "\"
                            End If
                        End If

                        context.FILE_NM_FORMAT = .Rows(intCNT).Item("FILE_NM_FORMAT").ToString.TrimEnd
                        context.FILE_FORMAT = .Rows(intCNT).Item("FILE_FORMAT").ToString.TrimEnd
                        context.AUTOMAKE_FLG = .Rows(intCNT).Item("AUTOMAKE_FLG").ToString.TrimEnd
                        context.BACKUP_TERM = .Rows(intCNT).Item("BACKUP_TERM").ToString.TrimEnd
                        context.RECV_TERM = .Rows(intCNT).Item("RECV_TERM").ToString.TrimEnd
                        context.WHERE_EXPRESSION = .Rows(intCNT).Item("WHERE_EXPRESSION").ToString.TrimEnd
                        context.REF_OBJECT_NM = .Rows(intCNT).Item("REF_OBJECT_NM").ToString.TrimEnd
                        context.LASTIMP_FILE_NM = .Rows(intCNT).Item("LASTIMP_FILE_NM").ToString.TrimEnd
                        context.LASTIMP_YMDHNS = .Rows(intCNT).Item("LASTIMP_YMDHNS").ToString.TrimEnd


                        'リストに追加
                        _Entities.Add(context.FILE_ID, context)
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

#End Region



End Class
