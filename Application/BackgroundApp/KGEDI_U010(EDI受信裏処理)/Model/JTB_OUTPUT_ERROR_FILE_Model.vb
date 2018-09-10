''' <summary>
''' JTB_OUTPUT_ERROR_FILE(出力エラーファイル情報)データモデル
''' </summary>
''' <remarks></remarks>
Public Class JTB_OUTPUT_ERROR_FILE_Model

    Public Const SourceTableName As String = "JTB_OUTPUT_ERROR_FILE"

#Region "メンバ"
    Public Property FILE_ID As Integer
    Public Property FILE_NM As String
    Public Property SYR_YMDHNS As String


#End Region

#Region "メソッド"
    'UNDONE: CRUD系メソッドを作成

#End Region

End Class


Public Class JTB_OUTPUT_ERROR_FILE_Entities

#Region "メンバ"
    Private _Entities As Dictionary(Of Tuple(Of Integer, String), JTB_OUTPUT_ERROR_FILE_Model)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        _Entities = New Dictionary(Of Tuple(Of Integer, String), JTB_OUTPUT_ERROR_FILE_Model)
    End Sub

#End Region

#Region "プロパティ"
    Property prEntities As Dictionary(Of Tuple(Of Integer, String), JTB_OUTPUT_ERROR_FILE_Model)
        Get
            Return _Entities
        End Get
        Set(value As Dictionary(Of Tuple(Of Integer, String), JTB_OUTPUT_ERROR_FILE_Model))
            _Entities = value
        End Set
    End Property

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 最新の出力エラーファイル情報を読み込みます。
    ''' </summary>
    ''' <param name="DB">接続DB</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal DB As clsDbUtility)
        Dim dsList As New System.Data.DataSet
        Dim sbSQL As New System.Text.StringBuilder

        Try
            sbSQL.Append("SELECT * FROM " & JTB_OUTPUT_ERROR_FILE_Model.SourceTableName & " ")
            dsList = DB.GetDataSet(sbSQL.ToString, True)

            _Entities.Clear()

            With dsList.Tables(0)
                For intCNT = 0 To .Rows.Count - 1
                    Dim context As New JTB_OUTPUT_ERROR_FILE_Model
                    context.FILE_ID = .Rows(intCNT).Item("FILE_ID").ToString.TrimEnd
                    context.FILE_NM = .Rows(intCNT).Item("FILE_NM").ToString.TrimEnd
                    context.SYR_YMDHNS = .Rows(intCNT).Item("SYR_YMDHNS").ToString.TrimEnd


                    'リストに追加
                    Dim tpl As New Tuple(Of Integer, String)(context.FILE_ID, context.FILE_NM)
                    _Entities.Add(tpl, context)
                Next intCNT
            End With


        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            dsList.Dispose()
        End Try
    End Sub

    Public Function GetLASTIMP_YMDHNS(ByVal intFileID As Integer) As String
        Dim strYMDHNS As String
        Dim _entity As IEnumerable(Of KGEDI.JTB_OUTPUT_ERROR_FILE_Model)
        Try
            '2017.07.12 Mod 引数のファイル編成IDのみ抽出
            'strYMDHNS = Me.prEntities.Values.OrderByDescending(Function(p) p.SYR_YMDHNS).First.SYR_YMDHNS
            _entity = Me.prEntities.Values.Where(Function(p) p.FILE_ID = intFileID)
            If _entity.Count > 0 Then
                strYMDHNS = _entity.OrderByDescending(Function(p) p.SYR_YMDHNS).First.SYR_YMDHNS
            Else
                strYMDHNS = ""
            End If
            'Mod End

            Return strYMDHNS
        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return ""
        End Try

    End Function

    Public Function GetFILE_NMs(ByVal intFileID As Integer) As List(Of String)
        Dim list As New List(Of String)

        Try
            For Each entity As JTB_OUTPUT_ERROR_FILE_Model In Me.prEntities.Values.OrderBy(Function(p) p.FILE_NM)
                If entity.FILE_ID = intFileID Then
                    list.Add(entity.FILE_NM)
                End If
            Next

            Return list

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try

    End Function

    '2017.07.12 Add
    Public Function GetFILE_IDs(Optional ByVal strFileName As String = "") As List(Of Integer)
        Dim list As New List(Of Integer)

        Try
            For Each entity As JTB_OUTPUT_ERROR_FILE_Model In Me.prEntities.Values.OrderBy(Function(p) p.FILE_NM)
                If strFileName <> "" Then
                    If entity.FILE_NM = strFileName Then
                        If list.Contains(entity.FILE_ID) = False Then
                            list.Add(entity.FILE_ID)
                        End If
                    End If
                Else
                    If list.Contains(entity.FILE_ID) = False Then
                        list.Add(entity.FILE_ID)
                    End If
                End If
            Next

            Return list

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try

    End Function

#End Region



End Class
