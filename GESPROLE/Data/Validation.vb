Public Class Validation

    Property ID As Integer
    Property Type As String
    Property Value As String

    Sub New(ByVal NewID As Integer, ByVal NewType As String, ByVal NewValue As String)
        ID = NewID
        Type = NewType
        Value = NewValue
    End Sub

    Public Shared Sub InsertIntoDB(ByVal Validation As Validation)

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

            Cmd.CommandText = "INSERT INTO validacion (Valor, Tipo) VALUES (@valor, @tipo)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@valor", Validation.Value.ToUpper)
            Cmd.Parameters.AddWithValue("@tipo", Validation.Type)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra nuevo valor de " & Validation.Type))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Sub UpdateInDB(ByVal Validation As Validation)

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

            Cmd.CommandText = "UPDATE validacion SET Valor=@valor WHERE ID=@id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", Validation.ID)
            Cmd.Parameters.AddWithValue("@valor", Validation.Value.ToUpper)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se actualiza valor de " & Validation.Type & ", " & Validation.Value))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Sub DeleteFromDB(ByVal ID As Integer)

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

            Cmd.CommandText = "DELETE FROM validacion WHERE ID=@id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina valor con ID " & ID))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub


    Public Shared Function GetFromDB(ByVal Type As String) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT * FROM validacion WHERE Tipo=@type"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type))

            Do While Reader.Read
                RetVal.Add(New Validation(Reader.GetInt32("ID"),
                                          Reader.GetString("Tipo"),
                                          Reader.GetString("Valor")))
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

End Class
