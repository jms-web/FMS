''' <summary>
''' シングルトン基底クラス
''' </summary>
''' <remarks></remarks>
Public MustInherit Class AbstractSingletonClass(Of T)

    ''' <summary>
    ''' シングルトンインスタンス
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _Instance As T = Nothing

    ''' <summary>
    ''' インスタンス生成排他ロックオブジェクト
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared ReadOnly _SyncLockCreateInstance As New Object

    ''' <summary>
    ''' コンストラクタ（Protected）
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()

    End Sub

    ''' <summary>
    ''' インスタンス取得
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As T

        SyncLock _SyncLockCreateInstance

            'インスタンス生成済みかチェックする
            If _Instance Is Nothing Then
                '無ければ生成する
                _Instance = CType(System.Activator.CreateInstance(GetType(T), True), T)
            End If

            '返す
            Return CType(_Instance, T)

        End SyncLock

    End Function

End Class
