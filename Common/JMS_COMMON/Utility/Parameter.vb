Imports System.Collections.Generic

Public Class Parameter
    ''' <summary>
    ''' 社員ＩＤ（システム上のＩＤ）
    ''' </summary>
    Private Shared mSyainId As Integer
    ''' <summary>
    ''' 社員ＩＤ（システム上のＩＤ）
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property PrSyainId As Integer
        Set(value As Integer)
            mSyainId = value
        End Set
        Get
            Return mSyainId
        End Get
    End Property


#Region "コンストラクタ等"
    ''' <summary>
    ''' 唯一のインスタンス
    ''' </summary>
    ''' <remarks>これをすることにより、自分で自分自身を生成し、モジュールのように扱える</remarks>
    Private Shared mSelf As Parameter = New Parameter

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>外部からのインスタンス作成は不可</remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' インスタンスの取得
    ''' </summary>
    ''' <returns>インスタンス</returns>
    ''' <remarks>唯一のインスタンスを取得する</remarks>
    Private Shared Function GetInstance() As Parameter
        If mSelf Is Nothing Then
            mSelf = New Parameter
        End If
        Return mSelf
    End Function

    ''' <summary>
    ''' インスタンスの削除
    ''' </summary>
    ''' <remarks>インスタンスを削除する</remarks>
    Private Shared Sub DeleteInstance()
        If Not mSelf Is Nothing Then
            mSelf = Nothing
        End If
    End Sub


    Public Shared Function Init(ByVal syainId As Integer) As Boolean
        mSyainId = syainId
    End Function
#End Region

End Class
