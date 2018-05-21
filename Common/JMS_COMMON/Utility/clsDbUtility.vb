Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Diagnostics

Public Class ClsDbUtility
    'Inherits AbstractSingletonClass(Of ClsDbUtility)
    Implements IDisposable

    'ＤＢファクトリの作成
    Private DBFactory As DbProviderFactory
    Private Connection As DbConnection
    Private transaction As DbTransaction = Nothing
    Private cmd As DbCommand = Nothing
    Private blnSqlTime As Boolean = True
    Private intCommandTimeout As Integer
    Private Const CON_COMMAND_TIMEOUT As Integer = 60
    Private ProviderName As String

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                'マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            Call Me.Close()
            ' 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    ' 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    Protected Overrides Sub Finalize()
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        ' 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Sub New(strProviderName As String, strConnectionString As String)
        'Try
        '======================================
        'ＤＢファクトリの作成
        '======================================
        ProviderName = strProviderName
        DBFactory = DbProviderFactories.GetFactory(strProviderName)
        '======================================
        'ファクトリから接続オブジェクトを取得
        '======================================
        Connection = DBFactory.CreateConnection
        Connection.ConnectionString = strConnectionString
        CommandTimeout = CON_COMMAND_TIMEOUT
        Call DBOpen()

        'Catch sqlEx As System.Data.SqlClient.SqlException
        '    EM.ErrorSyori(sqlEx, False, False)
        'End Try
    End Sub

    Private Sub DBOpen()
        Connection.Open()
    End Sub

    Public Property SqlTime As Boolean
        Get
            Return blnSqlTime
        End Get
        Set(value As Boolean)
            blnSqlTime = value
        End Set
    End Property

    Public Property CommandTimeout As Integer
        Get
            Return intCommandTimeout
        End Get
        Set(value As Integer)
            intCommandTimeout = value
        End Set
    End Property

    Public ReadOnly Property DbTransaction As DbTransaction
        Get
            Return transaction
        End Get
    End Property

    Public Function ConnectCheck() As Boolean
        Dim ds As DataSet
        Try
            ds = Me.GetDataSet("SELECT SYSDATETIME()", True)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

            Return True
        Catch ex As Exception
            EM.ErrorSyori(ex, True, True)
            Return False
        End Try
    End Function

#Region "GetDataReader"
    ''' <summary>
    ''' DataReaderを取得する
    ''' </summary>
    ''' <param name="strSql">
    ''' Sql文
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Function GetDataReader(strSql As String, Optional ByVal blnNonMsg As Boolean = False) As DbDataReader
        '開始時間
        Dim starttime As Double = Microsoft.VisualBasic.Timer
        Try

            'テーブルの一行を取得
            Dim sqlCmd As DbCommand = Connection.CreateCommand()
            sqlCmd.CommandText = strSql

            If Me.CommandTimeout > 0 Then
                sqlCmd.CommandTimeout = CommandTimeout
            End If

            '   使用中のトランザクションがある場合、セットする
            If Not (transaction Is Nothing) Then
                sqlCmd.Transaction = transaction
            End If

            Return sqlCmd.ExecuteReader()

        Catch ex As Exception
            'Throw New MyException.clsSqlException(ex, strSql)
            EM.ErrorSyori(ex, True, blnNonMsg)
            Return Nothing
        Finally
            ''終了時間
            'Dim endtime As Double = Microsoft.VisualBasic.Timer
            'If pub_SystemInfo.strDebugMode = "1" And blnSqlTime = True Then
            '    Call Fun_blnLogWrite(PUBC_STRLOGKBN_OFF, PUBC_STRSTSKBN_NONE, PUBC_STRALTKBN_OFF, 503, "0", 0, _
            '                         GetCurrentMethod.DeclaringType.Name, GetCurrentMethod.Name, "SqlTime GetDataReader:" & (endtime - starttime).ToString("0.00000Second"), strSql)
            'End If
        End Try
    End Function
#End Region
#Region "GetDataSet"
    ''' <summary>
    ''' DataSetを取得する
    ''' </summary>
    ''' <param name="strSql">
    ''' Sql文
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Function GetDataSet(ByVal strSql As String, Optional ByVal blnNonMsg As Boolean = False, Optional ByRef ErrException As Exception = Nothing) As DataSet
        '開始時間
        Dim starttime As Double = Microsoft.VisualBasic.Timer
        Try

            Dim adapter As DbDataAdapter = DBFactory.CreateDataAdapter()
            Dim comm As DbCommand = DBFactory.CreateCommand()


            'タイムアウト
            If Me.CommandTimeout > 0 Then
                comm.CommandTimeout = CommandTimeout
            End If

            '   使用中のトランザクションがある場合、セットする
            If Not (transaction Is Nothing) Then
                comm.Transaction = transaction
            End If

            comm.Connection = Connection
            comm.CommandText = strSql

            Dim ds As New DataSet()
            adapter.SelectCommand = comm
            adapter.Fill(ds)
            Return ds
        Catch SQLex As SqlClient.SqlException
            'Throw New ClsExceptionEx(SQLex.Message, "SQL:[" & strSql & "]")
            ErrException = SQLex
            Return Nothing
        Catch ex As Exception
            'Throw New MyException.clsSqlException(ex, strSql)
            ErrException = ex
            'EM.ErrorSyori(ex, True, blnNonMsg)
            Return Nothing
        Finally
            ''終了時間
            'Dim endtime As Double = Microsoft.VisualBasic.Timer
            'If pub_SystemInfo.strDebugMode = "1" And blnSqlTime = True Then
            '    Call Fun_blnLogWrite(PUBC_STRLOGKBN_OFF, PUBC_STRSTSKBN_NONE, PUBC_STRALTKBN_OFF, 503, "0", 0, _
            '                         GetCurrentMethod.DeclaringType.Name, GetCurrentMethod.Name, "SqlTime GetDataSet:" & (endtime - starttime).ToString("0.00000Second"), strSql)
            'End If
        End Try
    End Function
#End Region

#Region "ExecuteNonQuery"
    ''' <summary>
    ''' データ更新する
    ''' </summary>
    ''' <param name="strSql">
    ''' Sql文
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Function ExecuteNonQuery(ByVal strSql As String, Optional ByVal blnNonMsg As Boolean = True, Optional ByRef ErrException As Exception = Nothing) As Integer

        '開始時間
        'Dim starttime As Double = Microsoft.VisualBasic.Timer

        Try

            Dim i As Integer
            Dim sqlCmd As DbCommand = Connection.CreateCommand()

            'タイムアウト
            If Me.CommandTimeout > 0 Then
                sqlCmd.CommandTimeout = CommandTimeout
            End If

            sqlCmd.Transaction = transaction
            sqlCmd.CommandText = strSql

            i = sqlCmd.ExecuteNonQuery()
            Return i
            'Catch ex As System.Data.SqlClient.SqlException
            '    'エラーログを出力

        Catch ex As Exception
            'Throw New MyException.clsSqlException(ex, strSql)
            'EM.ErrorSyori(ex, True, blnNonMsg)
            ErrException = ex

        Finally
            ''終了時間
            'Dim endtime As Double = Microsoft.VisualBasic.Timer
            'If pub_SystemInfo.strDebugMode = "1" And blnSqlTime = True Then
            '    Call Fun_blnLogWrite(PUBC_STRLOGKBN_OFF, PUBC_STRSTSKBN_NONE, PUBC_STRALTKBN_OFF, 503, "0", 0, _
            '                         GetCurrentMethod.DeclaringType.Name, GetCurrentMethod.Name, "SqlTime ExecuteNonQuery:" & (endtime - starttime).ToString("0.00000Second"), strSql)
            'End If

        End Try

    End Function
#End Region


#Region "ExecuteScalar"
    ''' <summary>
    ''' データ更新する
    ''' </summary>
    ''' <param name="strSql">
    ''' Sql文
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteScalar(ByVal strSql As String, Optional ByVal blnNonMsg As Boolean = True, Optional ByRef ErrException As Exception = Nothing) As String

        '開始時間
        'Dim starttime As Double = Microsoft.VisualBasic.Timer

        Try

            Dim strRET As String
            Dim sqlCmd As DbCommand = Connection.CreateCommand()

            'タイムアウト
            If Me.CommandTimeout > 0 Then
                sqlCmd.CommandTimeout = CommandTimeout
            End If

            sqlCmd.Transaction = transaction
            sqlCmd.CommandText = strSql

            strRET = sqlCmd.ExecuteScalar
            Return strRET
            'Catch ex As System.Data.SqlClient.SqlException
            '    'エラーログを出力

        Catch ex As Exception
            'Throw New MyException.clsSqlException(ex, strSql)
            'EM.ErrorSyori(ex, True, blnNonMsg)
            ErrException = ex

        Finally
            ''終了時間
            'Dim endtime As Double = Microsoft.VisualBasic.Timer
            'If pub_SystemInfo.strDebugMode = "1" And blnSqlTime = True Then
            '    Call Fun_blnLogWrite(PUBC_STRLOGKBN_OFF, PUBC_STRSTSKBN_NONE, PUBC_STRALTKBN_OFF, 503, "0", 0, _
            '                         GetCurrentMethod.DeclaringType.Name, GetCurrentMethod.Name, "SqlTime ExecuteNonQuery:" & (endtime - starttime).ToString("0.00000Second"), strSql)
            'End If

        End Try

    End Function
#End Region

#Region "ExecuteStoredProcedure"
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Sub ExecuteStoredProcedure(strExecName As String, Optional ByVal blnNonMsg As Boolean = False)
        '開始時間
        Dim starttime As Double = Microsoft.VisualBasic.Timer
        Try
            cmd.CommandType = CommandType.StoredProcedure

            'タイムアウト
            If Me.CommandTimeout > 0 Then
                cmd.CommandTimeout = CommandTimeout
            End If

            cmd.CommandText = strExecName
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            'Throw New MyException.clsSqlException(ex, strExecName)
            EM.ErrorSyori(ex, True, blnNonMsg)
        Finally
            ''終了時間
            'Dim endtime As Double = Microsoft.VisualBasic.Timer
            'If pub_SystemInfo.strDebugMode = "1" And blnSqlTime = True Then
            '    Call Fun_blnLogWrite(PUBC_STRLOGKBN_OFF, PUBC_STRSTSKBN_NONE, PUBC_STRALTKBN_OFF, 503, "0", 0, _
            '                         GetCurrentMethod.DeclaringType.Name, GetCurrentMethod.Name, "SqlTime ExecuteStoredProcedure:" & (endtime - starttime).ToString("0.00000Second"), strExecName)
            'End If
        End Try

    End Sub
#End Region

#Region "BeginTransaction"
    ''' <summary>
    ''' トランザクションを開始する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BeginTransaction()
        transaction = Connection.BeginTransaction()
    End Sub
#End Region
#Region "Commit"
    ''' <summary>
    ''' トランザクションをコミットする True:Commit False:Rollback
    ''' </summary>
    ''' <param name="blnCommit"></param>
    Public Sub Commit(blnCommit As Boolean)
        Using transaction
            If blnCommit = True Then
                transaction.Commit()
            Else
                transaction.Rollback()
            End If
        End Using
        transaction = Nothing
    End Sub
#End Region
#Region "Rollback"
    ''' <summary>
    ''' トランザクションをロールバックする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Rollback()

        Try
            transaction.Rollback()
        Catch ex As Exception
            Throw
        Finally
            transaction.Dispose()
            transaction = Nothing
        End Try
    End Sub
#End Region

#Region "Close"
    ''' <summary>
    ''' コネクションをクローズする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()

        Try
            If (Not transaction Is Nothing) Then
                Rollback()
            End If
        Catch ex As Exception
            Throw
        Finally
            If (Not Connection Is Nothing) Then
                Connection.Close()
                Connection.Dispose()
                Connection = Nothing
            End If
            If (Not transaction Is Nothing) Then
                transaction.Dispose()
                transaction = Nothing
            End If
            If (Not cmd Is Nothing) Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Sub
#End Region

#Region "DBCommand"
    Public Function DbCommand() As DbCommand
        If IsNothing(cmd) = True Then
            cmd = Connection.CreateCommand
            cmd.Connection = Connection
        End If
        Return cmd
    End Function


#End Region

#Region "ストアド実行"
    ''' <summary>
    ''' ストアド実行処理
    ''' </summary>
    ''' <param name="clsDb">ＤＢコネクション</param>
    ''' <param name="strFuncName">呼び出しストアド名</param>
    ''' <param name="lstParam">パラメータのリスト</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>ストアド実行</remarks>
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Function Fun_blnExecStored(ByVal strFuncName As String, ByVal lstParam As List(Of System.Data.Common.DbParameter)) As Boolean
        Dim i As Integer
        Dim command As System.Data.Common.DbCommand
        Dim dr As System.Data.Common.DbDataReader = Nothing
        Dim objParam As System.Data.Common.DbParameter
        Dim objParamRet As System.Data.Common.DbParameter

        Try
            ' ストアドをコール
            command = Me.DbCommand

            ' トランザクションをセット
            If Me.transaction IsNot Nothing Then
                command.Transaction = Me.transaction
            End If

            With command
                ' コマンドの種類をストアドに変更
                .CommandType = CommandType.StoredProcedure

                ' 実行するストアドプロシージャ名を指定
                command.CommandText = strFuncName

                ' コマンドのタイムアウト設定(ひとまず２０分に指定)
                .CommandTimeout = 1200

                ' ストアドプロシージャのパラメータを設定
                ' commandオブジェクトのパラメータを初期化する
                .Parameters.Clear()

                ' ストアドプロシージャのパラメータに値を設定する
                If lstParam IsNot Nothing AndAlso lstParam.Count > 0 Then
                    For i = 0 To lstParam.Count - 1
                        objParam = command.CreateParameter

                        With objParam
                            .ParameterName = lstParam(i).ParameterName
                            .DbType = lstParam(i).DbType
                            .Value = lstParam(i).Value
                            .Direction = lstParam(i).Direction
                            .Size = lstParam(i).Size
                        End With
                        .Parameters.Add(objParam)
                    Next i
                End If

                ' 戻り値
                objParamRet = command.CreateParameter
                With objParamRet
                    .ParameterName = "ReturnValue"
                    .DbType = DbType.Int32
                    .Direction = ParameterDirection.ReturnValue
                End With
                .Parameters.Add(objParamRet)

                ' ストアドプロシージャの結果を取得する
                dr = .ExecuteReader
                dr.Close()

                ' 戻り値
                If .Parameters("ReturnValue").Value <> 0 Then
                    Exit Try
                End If
            End With

            Return True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' ストアド実行処理(レコードセット取得型)
    ''' </summary>
    ''' <param name="clsDb">ＤＢコネクション</param>
    ''' <param name="strFuncName">呼び出しストアド名</param>
    ''' <param name="lstParam">パラメータのリスト</param>
    ''' <param name="objDbData">レコードセット</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>ストアドを実行して、レコードセットを取得する</remarks>
    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL クエリのセキュリティ脆弱性を確認")>
    Public Function Fun_bExecStored(ByVal strFuncName As String,
                                    ByVal lstParam As List(Of System.Data.Common.DbParameter),
                                    ByRef objRETDataSet As DataSet) As Boolean
        Dim i As Integer
        Dim command As System.Data.Common.DbCommand
        Dim objParam As System.Data.Common.DbParameter
        Dim objParamRet As System.Data.Common.DbParameter
        Dim objDataAdapter As SqlClient.SqlDataAdapter = Nothing
        Dim objDataSet As System.Data.DataSet = Nothing

        Dim ds As DataSet = New DataSet()

        Fun_bExecStored = False

        Try
            ' ストアドをコール
            command = Me.DbCommand

            ' トランザクションをセット
            If Me.transaction IsNot Nothing Then
                command.Transaction = Me.transaction
            End If

            With command
                ' コマンドの種類をストアドに変更
                .CommandType = CommandType.StoredProcedure

                ' 実行するストアドプロシージャ名を指定
                command.CommandText = strFuncName

                ' コマンドのタイムアウト設定(ひとまず２０分に指定)
                .CommandTimeout = 1200

                ' ストアドプロシージャのパラメータを設定
                ' commandオブジェクトのパラメータを初期化する
                .Parameters.Clear()

                ' ストアドプロシージャのパラメータに値を設定する
                If lstParam IsNot Nothing AndAlso lstParam.Count > 0 Then
                    For i = 0 To lstParam.Count - 1
                        objParam = command.CreateParameter

                        With objParam
                            .ParameterName = lstParam(i).ParameterName
                            .DbType = lstParam(i).DbType
                            .Value = lstParam(i).Value
                            .Direction = lstParam(i).Direction
                            .Size = lstParam(i).Size
                        End With
                        .Parameters.Add(objParam)
                    Next i
                End If

                ' 戻り値
                objParamRet = command.CreateParameter
                With objParamRet
                    .ParameterName = "ReturnValue"
                    .DbType = DbType.Int32
                    .Direction = ParameterDirection.ReturnValue
                End With
                .Parameters.Add(objParamRet)

                ' ストアドプロシージャの結果を取得する
                objDataAdapter = New SqlClient.SqlDataAdapter(command)
                objDataSet = New System.Data.DataSet
                objDataAdapter.Fill(objDataSet)

                If objDataSet IsNot Nothing AndAlso objDataSet.Tables.Count > 0 Then
                    objRETDataSet = objDataSet
                End If

                ' 戻り値
                If .Parameters("ReturnValue").Value <> 0 Then
                    Exit Try
                End If
            End With

            Fun_bExecStored = True

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
        Finally
            If objDataSet IsNot Nothing Then
                objDataSet.Dispose()
            End If
            If objDataAdapter IsNot Nothing Then
                objDataAdapter.Dispose()
            End If
        End Try

    End Function

#End Region

#Region "システム日時取得"
    ''' <summary>
    ''' DBサーバのシステム日時を取得
    ''' </summary>
    ''' <returns></returns>
    Public Function GetSysDateTime() As DateTime
        Dim dt As DateTime
        Dim strSQL As String
        Try
            Select Case ProviderName
                Case "System.Data.SqlClient"
                    'SQLServer
                    strSQL = "SELECT REPLACE(CONVERT(NVARCHAR, GETDATE(), 112) + CONVERT(NVARCHAR, GETDATE(), 108),':','') AS 'SYSDATE'" '～SqlServer2008R2でもOK

                    'SqlServer2012～のみ
                    'strSQL = "SELECT FORMAT(GETDATE(), 'yyyyMMddHHmmss') AS 'SYSDATE'" 
                Case "Oracle.DataAccess.Client", "Oracle.ManagedDataAccess.Client"
                    strSQL = "SELECT TO_CHAR(SYSDATE,'yyyymmddhh24miss') SYSDATE FROM DUAL"
                Case Else
                    strSQL = ""
                    Return Nothing
            End Select

            Using DataRead As DbDataReader = Me.GetDataReader(strSQL)
                DataRead.Read()
                dt = DateTime.ParseExact(DataRead.Item("SYSDATE").ToString, "yyyyMMddHHmmss", Nothing)
            End Using

            Return dt

        Catch ex As Exception
            EM.ErrorSyori(ex, False, conblnNonMsg)
            Return Nothing
        End Try
    End Function
#End Region

End Class
