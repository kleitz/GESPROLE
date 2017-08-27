Public Class Log
    Property Time As Date
    Property Username As String
    Property IP As String
    Property Action As String

    Sub New(ByVal NewTime As Date, ByVal NewUser As String, ByVal NewAction As String)
        Time = NewTime
        Username = NewUser
        IP = GetIPv4Address()
        Action = NewAction
    End Sub

    'Big shout out to EagleEyes from StackOverflow'
    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function

    Public Shared Sub InsertIntoDB(ByVal Log As Log)
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim MyConnString As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        Try
            Conn.ConnectionString = MyConnString
            Conn.Open()

            Cmd.Connection = Conn

            Cmd.CommandText = "INSERT INTO log VALUES (@time, @time, @user, @ip, @action)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@time", Log.Time) 'Inteligent VB.NET will choose either time or date when it needs any'
            Cmd.Parameters.AddWithValue("@user", Log.Username)
            Cmd.Parameters.AddWithValue("@ip", Log.IP)
            Cmd.Parameters.AddWithValue("@action", Log.Action)

            Cmd.ExecuteNonQuery()

            Conn.Close()
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try
    End Sub
End Class
