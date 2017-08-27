Public Class LifeEvent

    'Type constants'
    Public Const ABORTO As Integer = 0
    Public Const ANALISIS As Integer = 1
    Public Const ENFERMEDAD As Integer = 2
    Public Const IDA_RECRIA As Integer = 3
    Public Const MEDICACION As Integer = 4
    Public Const MUERTE As Integer = 5
    Public Const PARTO As Integer = 6
    Public Const RECHAZO As Integer = 7
    Public Const SECADO As Integer = 8
    Public Const SERVICIO As Integer = 9
    Public Const TACTO As Integer = 10
    Public Const VENTA As Integer = 11

    'State constants'
    Public Const VACIA As Integer = 0 ' Else '
    Public Const ANESTRO As Integer = 1 ' Last-event = PARTO AND Time < Defined in config '
    Public Const PRENADA As Integer = 2 'Last event = Servicio AND Time > Defined in config'
    Public Const SECA As Integer = 3 'Last event = Secado;'
    Public Const CALOSTRO As Integer = 4 ' Last event = PARTO AND Time < Defined in config '
    Public Const LACTANDO As Integer = 5 ' Last event = PARTO AND Time > Defined in config '

    Property RP As Integer
    Property Time As Date
    Property Type As Integer
    Property Data1 As String
    Property Data2 As String
    Property Data3 As String
    Property Data4 As String

    Sub New(ByVal NewRP As Integer, ByVal NewTime As Date, ByVal NewType As Integer, ByVal NewData1 As String, ByVal NewData2 As String, ByVal NewData3 As String, ByVal NewData4 As String)
        RP = NewRP
        Time = NewTime
        Type = NewType
        If NewData1 IsNot Nothing Then
            Data1 = NewData1
        End If
        If NewData2 IsNot Nothing Then
            Data2 = NewData2
        End If
        If NewData3 IsNot Nothing Then
            Data3 = NewData3
        End If
        If NewData4 IsNot Nothing Then
            Data4 = NewData4
        End If
    End Sub

    'Database'

    Public Shared Function InsertIntoDB(ByVal Evt As LifeEvent) As Boolean

        Dim RetVal As Boolean = True
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

            Cmd.CommandText = "INSERT INTO evento (RP_Bovino, Fecha, Tipo, Valor_1, Valor_2, Valor_3, Valor_4) VALUES (@rp, @date, @tipo, @value1, @value2, @value3, @value4)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@rp", Evt.RP)
            Cmd.Parameters.AddWithValue("@date", Evt.Time)
            Cmd.Parameters.AddWithValue("@tipo", Evt.Type)
            Try
                Cmd.Parameters.AddWithValue("@value1", Evt.Data1)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@value2", Evt.Data2)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@value3", Evt.Data3)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@value4", Evt.Data4)
            Catch ex As Exception

            End Try

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra evento a bovino con RP " & Evt.RP))
        Catch e As Exception
            Console.WriteLine(e.Message)
            If e.Message.Contains("Duplicate entry") Then
                MessageBox.Show("Dos eventos iguales el mismo día no son posibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetVal = False
            End If
        Finally
            Conn.Dispose()
        End Try

        Return RetVal
    End Function

    Public Shared Sub DeleteFromDB(ByVal Evt As LifeEvent)
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

            Cmd.CommandText = "DELETE FROM evento WHERE RP_Bovino=@rp AND Fecha=@date AND Tipo=@tipo"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@rp", Evt.RP)
            Cmd.Parameters.AddWithValue("@date", Evt.Time)
            Cmd.Parameters.AddWithValue("@tipo", Evt.Type)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina evento a bovino con RP " & Evt.RP))
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Function GetCowEvts(ByVal RP As Integer) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT * FROM evento WHERE RP_Bovino=@rp ORDER BY Fecha DESC"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

            Dim Value1 As String
            Dim Value2 As String
            Dim Value3 As String
            Dim Value4 As String

            Do While Reader.Read
                Value1 = Nothing
                Value2 = Nothing
                Value3 = Nothing
                Value4 = Nothing

                Try
                    Value1 = Reader.GetString("Valor_1")
                Catch ex As Exception

                End Try
                Try
                    Value2 = Reader.GetString("Valor_2")
                Catch ex As Exception

                End Try
                Try
                    Value3 = Reader.GetString("Valor_3")
                Catch ex As Exception

                End Try
                Try
                    Value4 = Reader.GetString("Valor_4")
                Catch ex As Exception

                End Try
                RetVal.Add(New LifeEvent(RP, Reader.GetDateTime("Fecha"), Reader.GetInt32("Tipo"), Value1, Value2, Value3, Value4))
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetCowEvts(ByVal RP As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT * FROM evento WHERE RP_Bovino=@rp ORDER BY Fecha DESC"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

            Dim Value1 As String
            Dim Value2 As String
            Dim Value3 As String
            Dim Value4 As String

            Do While Reader.Read
                Value1 = Nothing
                Value2 = Nothing
                Value3 = Nothing
                Value4 = Nothing

                Try
                    Value1 = Reader.GetString("Valor_1")
                Catch ex As Exception

                End Try
                Try
                    Value2 = Reader.GetString("Valor_2")
                Catch ex As Exception

                End Try
                Try
                    Value3 = Reader.GetString("Valor_3")
                Catch ex As Exception

                End Try
                Try
                    Value4 = Reader.GetString("Valor_4")
                Catch ex As Exception

                End Try
                RetVal.Add(New LifeEvent(RP, Reader.GetDateTime("Fecha"), Reader.GetInt32("Tipo"), Value1, Value2, Value3, Value4))
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetLastEvtOfType(ByVal RP As Integer, ByVal Type As Integer, ByVal Time As Date) As LifeEvent
        Dim RetVal As LifeEvent
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT * FROM evento WHERE RP_Bovino=@rp AND Tipo=@type AND Fecha<=@date ORDER BY Fecha DESC LIMIT 1"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@date", Time))

            If Reader.Read Then
                Dim Value1 As String
                Dim Value2 As String
                Dim Value3 As String
                Dim Value4 As String

                Try
                    Value1 = Reader.GetString("Valor_1")
                Catch ex As Exception

                End Try
                Try
                    Value2 = Reader.GetString("Valor_2")
                Catch ex As Exception

                End Try
                Try
                    Value3 = Reader.GetString("Valor_3")
                Catch ex As Exception

                End Try
                Try
                    Value4 = Reader.GetString("Valor_4")
                Catch ex As Exception

                End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                RetVal = New LifeEvent(RP, Reader.GetDateTime("Fecha"), Type, Value1, Value2, Value3, Value4)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetLastEvtOfType(ByVal RP As Integer, ByVal Type As Integer, ByVal Time As Date, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As LifeEvent
        Dim RetVal As LifeEvent
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT * FROM evento WHERE RP_Bovino=@rp AND Tipo=@type AND Fecha<=@date ORDER BY Fecha DESC LIMIT 1"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@date", Time))

            If Reader.Read Then
                Dim Value1 As String
                Dim Value2 As String
                Dim Value3 As String
                Dim Value4 As String

                Try
                    Value1 = Reader.GetString("Valor_1")
                Catch ex As Exception

                End Try
                Try
                    Value2 = Reader.GetString("Valor_2")
                Catch ex As Exception

                End Try
                Try
                    Value3 = Reader.GetString("Valor_3")
                Catch ex As Exception

                End Try
                Try
                    Value4 = Reader.GetString("Valor_4")
                Catch ex As Exception

                End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                RetVal = New LifeEvent(RP, Reader.GetDateTime("Fecha"), Type, Value1, Value2, Value3, Value4)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            End If

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetEvtCount(ByVal RP As Integer, ByVal Type As Integer) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT COUNT(*) FROM evento WHERE RP_Bovino=@rp AND Tipo=@type"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type))

            If Reader.Read Then
                RetVal = Reader.GetInt32("COUNT(*)")
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetEvtCount(ByVal RP As Integer, ByVal Type As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT COUNT(*) FROM evento WHERE RP_Bovino=@rp AND Tipo=@type"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type))

            If Reader.Read Then
                RetVal = Reader.GetInt32("COUNT(*)")
            End If

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetEvtCount(ByVal Type As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer = 0
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If Type = LifeEvent.PARTO Then
            If My.Settings.Establishment.Equals("") Then
                CommandText = "SELECT COUNT(*) FROM evento WHERE Tipo=@type AND Valor_3=@value"
            Else
                CommandText = "SELECT COUNT(*) FROM evento WHERE Tipo=@type AND Valor_3=@value AND RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@tambo)"
            End If
        Else
            If My.Settings.Establishment.Equals("") Then
                CommandText = "SELECT COUNT(*) FROM evento WHERE Tipo=@type"
            Else
                CommandText = "SELECT COUNT(*) FROM evento WHERE Tipo=@type AND RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@tambo)"
            End If
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", Type),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@value", "VIVA"),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            If Reader.Read Then
                RetVal = Reader.GetInt32("COUNT(*)")
            End If

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function ValidServTest(ByVal Serv As LifeEvent) As Boolean
        Dim RetVal As Boolean = True
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT COUNT(*) FROM evento WHERE RP_Bovino=@rp AND Tipo=@type AND Fecha BETWEEN @down AND @top"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", Serv.RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", PARTO),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@top", DateAdd(DateInterval.Year, 1, Serv.Time)),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@down", Serv.Time))

            If Reader.Read Then
                If Reader.GetInt32("COUNT(*)") > 0 Then
                    RetVal = False
                End If
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function ValidBirthOrAbortTest(ByVal Serv As LifeEvent) As Boolean
        Dim RetVal As Boolean = True
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT COUNT(*) FROM evento WHERE RP_Bovino=@rp AND Tipo IN (@type, @typetwo) AND Fecha BETWEEN @down AND @top"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", Serv.RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@type", PARTO),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@typetwo", ABORTO),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@top", DateAdd(DateInterval.Month, 4, Serv.Time)),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@down", DateAdd(DateInterval.Month, -4, Serv.Time)))

            If Reader.Read Then
                If Reader.GetInt32("COUNT(*)") > 0 Then
                    RetVal = False
                End If
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

End Class
