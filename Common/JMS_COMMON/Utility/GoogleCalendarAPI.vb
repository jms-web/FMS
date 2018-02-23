Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Collections.Generic
Imports System.Linq

Namespace API

    Public NotInheritable Class NationHolidays
        Const CON_GOOGLE_CALENDAR_API_LEY As String = "AIzaSyCWC2h7DuJ_jlHpblKMdINZZFN1laaKs-s"

        Shared _Holidays As List(Of NationalHoliday)

        Shared Function GetList(ByVal intYear As Integer) As List(Of NationalHoliday)

            _Holidays = GetNationalHolidays(intYear, CON_GOOGLE_CALENDAR_API_LEY)

            Return _Holidays
        End Function

        Shared Function GetList(ByVal intYear As Integer, ByVal intMonth As Integer) As List(Of NationalHoliday)
            Try
                _Holidays = GetNationalHolidays(intYear, CON_GOOGLE_CALENDAR_API_LEY)
                Dim qry As List(Of NationalHoliday) = _Holidays.Where(Function(d) d.Date.Month = intMonth).ToList

                Return qry
            Catch ex As Exception
                EM.ErrorSyori(ex, False, conblnNonMsg)
                Return Nothing
            End Try
        End Function

        Shared Function GetDays() As List(Of Date)
            Dim list As New List(Of Date)
            For Each holiday As NationalHoliday In _Holidays
                list.Add(holiday.Date)
            Next

            Return list
        End Function

        ''' <summary>
        ''' Googleカレンダーから指定した年の祝日を取得する
        ''' </summary>
        ''' <param name="year">祝日を取得する年（西暦）。</param>
        ''' <param name="apiKey">Google API key。</param>
        ''' <param name="calendarId">使用するカレンダーのID。</param>
        ''' <returns>指定された年の祝日を表す配列。</returns>
        Shared Function GetNationalHolidays(ByVal year As Integer,
                ByVal apiKey As String, ByVal calendarId As String) As List(Of NationalHoliday)
            'URLを作成する
            Const googleUrl As String = "https://www.googleapis.com/calendar/v3/calendars/"
            Const methodString As String = "events"
            Const maxResults As Integer = 100
            'クエリーを作成する
            Dim query As String = String.Format("key={0}&" &
                "timeMin={1}-01-01T00:00:00Z&" &
                "timeMax={2}-01-01T00:00:00Z&" &
                "maxResults={3}",
                apiKey, year, year + 1, maxResults)
            'つなげて完成
            Dim url As String = googleUrl & calendarId & "/" & methodString & "?" & query

            'サーバーからデータを受信する
            Dim req As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            Dim res As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
            Dim st As Stream = res.GetResponseStream()
            Dim sr As New StreamReader(st)
            'すべてのデータを受信する
            Dim jsonString As String = sr.ReadToEnd()
            '後始末
            sr.Close()
            st.Close()
            res.Close()

            '受信したデータを解析する
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim jsonDic As Dictionary(Of String, Object) =
                serializer.Deserialize(Of Dictionary(Of String, Object))(jsonString)
            If Not jsonDic.ContainsKey("items") Then
                'itemsがなかったら失敗したと判断する
                'Return New NationalHoliday(-1) {}
                Return New List(Of NationalHoliday)
            End If
            Dim items As System.Collections.ArrayList =
                DirectCast(jsonDic("items"), System.Collections.ArrayList)

            '見つかった祝日の名前と日付を取得する
            'Dim holidays As NationalHoliday() = New NationalHoliday(items.Count - 1) {}
            'For i As Integer = 0 To items.Count - 1
            '    Dim item As Dictionary(Of String, Object) =
            '        DirectCast(items(i), Dictionary(Of String, Object))
            '    Dim title As String = DirectCast(item("summary"), String)
            '    Dim startTime As String = DirectCast(DirectCast(item("start"),
            '            Dictionary(Of String, Object))("date"), String)
            '    holidays(i) = New NationalHoliday(title, startTime)
            'Next
            Dim holidays As New List(Of NationalHoliday)
            For i As Integer = 0 To items.Count - 1
                Dim item As Dictionary(Of String, Object) =
                    DirectCast(items(i), Dictionary(Of String, Object))

                Dim title As String = DirectCast(item("summary"), String).Split("/")(0).Trim

                Dim startTime As String = DirectCast(DirectCast(item("start"),
                        Dictionary(Of String, Object))("date"), String)
                holidays.Add(New NationalHoliday(title, startTime))
            Next

            Return holidays
        End Function

        ''' <summary>
        ''' Googleカレンダーから指定した年の日本の祝日を取得する
        ''' </summary>
        ''' <param name="year">祝日を取得する年（西暦）。</param>
        ''' <param name="apiKey">使用するカレンダーのID。</param>
        ''' <returns>指定された年の祝日を表す配列。</returns>
        Shared Function GetNationalHolidays(ByVal year As Integer,
                ByVal apiKey As String) As List(Of NationalHoliday)
            'mozilla.org版
            Const japaneseHolidaysId As String =
                "outid3el0qkcrsuf89fltf7a4qbacgt9@import.calendar.google.com"
            '公式版日本語
            'Const japaneseHolidaysId As String = _
            '    "ja.japanese%23holiday@group.v.calendar.google.com"
            Return GetNationalHolidays(year, apiKey, japaneseHolidaysId)
        End Function

        ''' <summary>
        ''' 祝日を表現したクラス
        ''' </summary>
        Public Class NationalHoliday
            Private _name As String
            ''' <summary>
            ''' 祝日の名前
            ''' </summary>
            Public ReadOnly Property Name() As String
                Get
                    Return Me._name
                End Get
            End Property

            Private _date As DateTime
            ''' <summary>
            ''' 祝日の日付
            ''' </summary>
            Public ReadOnly Property [Date]() As DateTime
                Get
                    Return Me._date
                End Get
            End Property

            ''' <summary>
            ''' NationalHolidayのコンストラクタ
            ''' </summary>
            ''' <param name="holidayName">祝日の名前</param>
            ''' <param name="holidayDate">祝日の日付（RFC3339形式の文字列）</param>
            Public Sub New(ByVal holidayName As String, ByVal holidayDate As String)
                Me._name = holidayName
                Me._date = XmlConvert.ToDateTime(holidayDate,
                    XmlDateTimeSerializationMode.Local)
                '.NET Framework 1.1以前では、次のようにする
                'Me._date = XmlConvert.ToDateTime(holidayDate)
            End Sub
        End Class
    End Class
End Namespace
