Public Class Notification

    Property ID As Integer
    Property Date_In As Date
    Property Msg As String
    Property Length As Integer
    Property Establishment As String

    Sub New(ByVal NewDate_In As Date, ByVal NewMsg As String, ByVal NewLength As Integer)
        Date_In = NewDate_In
        Msg = NewMsg
        Length = NewLength
    End Sub

    Sub New(ByVal NewID As Integer, ByVal NewDate_In As Date, ByVal NewMsg As String, ByVal NewLength As Integer)
        ID = NewID
        Date_In = NewDate_In
        Msg = NewMsg
        Length = NewLength
    End Sub

    ' Database Code '

    Public Shared Function NewNotification() As Boolean
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String = ""

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT COUNT(*) 
	                    FROM notificacion 
	                    WHERE Fecha_Entrada <= CURDATE() 
		                    AND CURDATE() <= DATE_ADD(Fecha_Entrada, INTERVAL Duracion DAY) 
		                    AND IFNULL(LOCATE(CAST(CURDATE() AS CHAR), Lista_Listos), 0) = 0"
        Else
            CommandText = "SELECT COUNT(*) 
	                    FROM notificacion 
	                    WHERE Fecha_Entrada <= CURDATE() 
		                    AND CURDATE() <= DATE_ADD(Fecha_Entrada, INTERVAL Duracion DAY) 
		                    AND IFNULL(LOCATE(CAST(CURDATE() AS CHAR), Lista_Listos), 0) = 0
                            AND Establecimiento = @tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            If Reader.Read Then
                If Reader.GetInt32("COUNT(*)") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function GetList() As Collection
        Dim Notifications As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String = ""

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT ID, Mensaje, Fecha_Entrada, Duracion, Establecimiento 
	                    FROM notificacion 
	                    WHERE Fecha_Entrada <= CURDATE() 
		                    AND CURDATE() <= DATE_ADD(Fecha_Entrada, INTERVAL Duracion DAY) 
		                    AND IFNULL(LOCATE(CAST(CURDATE() AS CHAR), Lista_Listos), 0) = 0"
        Else
            CommandText = "SELECT ID, Mensaje, Fecha_Entrada, Duracion 
	                    FROM notificacion 
	                    WHERE Fecha_Entrada <= CURDATE() 
		                    AND CURDATE() <= DATE_ADD(Fecha_Entrada, INTERVAL Duracion DAY) 
		                    AND IFNULL(LOCATE(CAST(CURDATE() AS CHAR), Lista_Listos), 0) = 0
                            AND Establecimiento = @tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            While Reader.Read
                Dim CurrentNotification As New Notification(Reader.GetInt32("ID"), Reader.GetDateTime("Fecha_Entrada"), Reader.GetString("Mensaje"), Reader.GetInt32("Duracion"))
                If My.Settings.Establishment.Equals("") Then
                    CurrentNotification.Establishment = Reader.GetString("Establecimiento")
                End If
                Notifications.Add(CurrentNotification)
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Return Notifications
    End Function

    Public Shared Sub InsertIntoDB(ByVal Noti As Notification)
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

            Cmd.CommandText = "INSERT INTO notificacion (Fecha_Entrada, Mensaje, Duracion, Establecimiento) 
	                            VALUES (@datein, @msg, @lgth, @tambo)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@datein", Noti.Date_In)
            Cmd.Parameters.AddWithValue("@msg", Noti.Msg.ToUpper)
            Cmd.Parameters.AddWithValue("@lgth", Noti.Length)
            Cmd.Parameters.AddWithValue("@tambo", Noti.Establishment)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se ingresa nueva notificacion"))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub Extend(ByVal ID As Integer, ByVal Plus As Integer)
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

            Cmd.CommandText = "UPDATE notificacion 
	                            SET Duracion = Duracion + @extra
	                            WHERE ID = @id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)
            Cmd.Parameters.AddWithValue("@extra", Plus)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se extiende la notificacion " & ID))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub MarkAsDone(ByVal ID As Integer)
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

            Cmd.CommandText = "UPDATE notificacion 
	                            SET Lista_Listos = IFNULL(CONCAT(Lista_Listos, CONCAT(CAST(CURDATE() AS CHAR), ', ')), CONCAT(CAST(CURDATE() AS CHAR), ', '))
	                            WHERE ID = @id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se marca como hecha la notificacion " & ID))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub MarkAsUnDone(ByVal ID As Integer)
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

            Cmd.CommandText = "UPDATE notificacion 
	                            SET Lista_Listos = REPLACE(Lista_Listos, CONCAT(CAST(CURDATE() AS CHAR), ', '), '')
	                            WHERE ID = @id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se marca como deshecha la notificacion " & ID))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub RemoveFromDB(ByVal ID As Integer)
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

            Cmd.CommandText = "DELETE FROM notificacion WHERE ID = @id"
            Cmd.Prepare()


            Cmd.Parameters.AddWithValue("@id", ID)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina la notificacion " & ID))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

End Class
