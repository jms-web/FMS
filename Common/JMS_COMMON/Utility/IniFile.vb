'*******************************************************************************
'* ＩＮＩファイル操作用クラス
'*******************************************************************************
'* 使用例(生成) * 
'*   Dim m_cIni As New IniFile(ファイル名)
'*  取得
'*   m_cIni.GetIniString(セクション名, キー名, 取得失敗時の戻り値[省略可])
'*  書込
'*   m_cIni.SetIniString(セクション名, キー名, 書き込む値)
'*******************************************************************************

Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Collections.Generic

Public Class IniFile
    Implements IDisposable

    '* DEFINE
    Private Const BUFF_LEN As Integer = 256 '256文字

    '* API宣言
    '--- iniﾌｧｲﾙ読込み
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" _
        Alias "GetPrivateProfileString" (
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpReturnedString As StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpFileName As String) As UInt32

    '--- iniﾌｧｲﾙ書込み
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function WritePrivateProfileString _
      (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilename As String) As Boolean
    End Function

    '* メンバ変数
    Private m_strIniFileName As String

    '* メンバ関数

    '--- インスタンス作成
    '* 引数 : iniファイルのフルパス
    Public Sub New(ByVal strIniFileName As String)
        'メンバ変数にセット
        m_strIniFileName = strIniFileName
    End Sub


    '--- Get ini String情報
    Public Function GetIniString(
            ByVal lpszSection As String,
            ByVal lpszEntry As String,
            Optional ByVal lpszDefault As String = Nothing
        ) As String

        Dim sb As StringBuilder = New StringBuilder(BUFF_LEN)
        Dim ret As UInt32 = GetPrivateProfileString(lpszSection, lpszEntry, lpszDefault, sb, Convert.ToUInt32(sb.Capacity), m_strIniFileName)

        Return sb.ToString
    End Function

    '--- Set ini String情報
    Public Function SetIniString(
            ByVal lpszSection As String,
            ByVal lpszEntry As String,
            ByVal lpszString As String
        ) As Boolean

        Return WritePrivateProfileString(lpszSection, lpszEntry, lpszString, m_strIniFileName)
    End Function

    '--- Get ini section一覧
    Public Function GetSectionNames() As List(Of String)

        Dim sbbuf As New System.Text.StringBuilder
        sbbuf.Append(Strings.StrDup(4096, vbNullChar))
        Dim ret As Integer = GetPrivateProfileString(Nothing, Nothing, Nothing, sbbuf, sbbuf.Length, m_strIniFileName)
        Dim sections() As String = Left(sbbuf.ToString, ret).TrimEnd(vbNullChar).Split(vbNullChar)

        Dim lst As New List(Of String)
        lst.AddRange(sections)

        Return lst
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                'マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    ' 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        ' 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
