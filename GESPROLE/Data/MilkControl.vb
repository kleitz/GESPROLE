Public Class MilkControl

    Property ID As Integer
    Property RP As Integer
    Property Time As Date
    Property Fat As Integer
    Property SomCel As Integer
    Property Lactose As Integer
    Property Proteins As Integer
    Property Water As Integer
    Property Bacteria As Integer

    Property Milkings As Collection

    Sub New(ByVal NewID As Integer, ByVal NewRP As Integer, ByVal NewTime As Date, ByVal NewFat As Integer, ByVal NewSomCel As Integer, ByVal NewLactose As Integer, ByVal NewProteins As Integer, ByVal NewWater As Integer, ByVal NewBacteria As Integer)
        ID = NewID
        RP = NewRP
        Time = NewTime
        Fat = NewFat
        SomCel = NewSomCel
        Lactose = NewLactose
        Proteins = NewProteins
        Water = NewWater
        Bacteria = NewBacteria

        Milkings = New Collection
    End Sub

    Sub AddMilking(ByVal NewStart As Date, ByVal NewFinish As Date, ByVal NewQty As Integer)
        Dim CurrentMilking As New Milking(NewStart, NewFinish, NewQty)
        Milkings.Add(CurrentMilking, Convert.ToString(Milkings.Count + 1))
    End Sub

    Sub ReplaceMilking(ByVal Number As Integer, ByVal Milking As Milking)
        Milkings.Remove(Convert.ToString(Number))
        Milkings.Add(Milking, Convert.ToString(Number))
    End Sub

    Sub RemoveMilking(ByVal Number As Integer)
        Milkings.Remove(Convert.ToString(Number))
    End Sub

    Sub EditMilking(ByVal Number As Integer, ByVal NewStart As Date, ByVal NewFinish As Date, ByVal NewQty As Integer)
        If NewStart <> Nothing Then
            CType(Milkings(Number), Milking).Start = NewStart
        End If
        If NewFinish <> Nothing Then
            CType(Milkings(Number), Milking).Finish = NewFinish
        End If
        If NewQty <> 0 Then
            CType(Milkings(Number), Milking).Qty = NewQty
        End If
    End Sub

    'Database code'

    Public Shared Function NewCtrlIndex() As Integer

        Dim RetVal As New Integer
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
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

            Cmd.CommandText = "SELECT ID FROM control ORDER BY ID DESC LIMIT 1"
            Cmd.Prepare()

            Reader = Cmd.ExecuteReader

            If Reader.Read Then
                RetVal = Reader.GetInt32("ID") + 1
            End If

            Conn.Close()
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

        Return RetVal
    End Function

    Public Shared Function GetList() As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT ID, Fecha, AVG(Grasas) AS Grasas, AVG(Lactosa) AS Lactosa, AVG(Agua_Leche) AS Agua_Leche, AVG(Recuento_Bacteriano) AS Recuento_Bacteriano, AVG(Proteinas) AS Proteinas, AVG(Celulas_Somaticas) AS Celulas_Somaticas FROM control GROUP BY ID ORDER BY ID DESC"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString, CommandText)

            Do While Reader.Read
                RetVal.Add(New MilkControl(Reader.GetInt32("ID"),
                                           Nothing,
                                           Reader.GetDateTime("Fecha"),
                                           Reader.GetInt32("Grasas"),
                                           Reader.GetInt32("Celulas_Somaticas"),
                                           Reader.GetInt32("Lactosa"),
                                           Reader.GetInt32("Proteinas"),
                                           Reader.GetInt32("Agua_Leche"),
                                           Reader.GetInt32("Recuento_Bacteriano")))
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetListForCow(ByVal RP As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT * FROM control WHERE RP_Bovino=@rp ORDER BY ID DESC"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

            Do While Reader.Read
                RetVal.Add(New MilkControl(Reader.GetInt32("ID"),
                                           RP,
                                           Reader.GetDateTime("Fecha"),
                                           Reader.GetInt32("Grasas"),
                                           Reader.GetInt32("Celulas_Somaticas"),
                                           Reader.GetInt32("Lactosa"),
                                           Reader.GetInt32("Proteinas"),
                                           Reader.GetInt32("Agua_Leche"),
                                           Reader.GetInt32("Recuento_Bacteriano")))

                CType(RetVal(RetVal.Count), MilkControl).Milkings = Milking.GetFromDB(Reader.GetInt32("ID"),
                                                                                      RP,
                                                                                      Reader.GetDateTime("Fecha"))
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetEstablishment(ByVal ID As Integer) As String
        Dim RetVal As String
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT RP_Bovino FROM control WHERE ID=@id LIMIT 1"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@id", ID))

            If Reader.Read Then
                RetVal = Cow.GetEstablishment(Reader.GetInt32("RP_Bovino"))
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Sub InsertIntoDB(ByVal ID As Integer, ByVal Control As MilkControl)
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

            Cmd.CommandText = "INSERT INTO control VALUES (@id, @fat, @lact, @smb, @bact, @prot, @som, @date, @rp)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)
            Cmd.Parameters.AddWithValue("@fat", Control.Fat)
            Cmd.Parameters.AddWithValue("@lact", Control.Lactose)
            Cmd.Parameters.AddWithValue("@smb", Control.Water)
            Cmd.Parameters.AddWithValue("@bact", Control.Bacteria)
            Cmd.Parameters.AddWithValue("@prot", Control.Proteins)
            Cmd.Parameters.AddWithValue("@som", Control.SomCel)
            Cmd.Parameters.AddWithValue("@date", Control.Time)
            Cmd.Parameters.AddWithValue("@rp", Control.RP)

            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "INSERT INTO ordene VALUES (@id, @rp, @timeon, @timeoff, @qty)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(1), Milking).Start)
            Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(1), Milking).Finish)
            Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(1), Milking).Qty)

            Cmd.ExecuteNonQuery()

            If Control.Milkings.Count > 1 Then
                Cmd.CommandText = "INSERT INTO ordene VALUES (@id, @rp, @timeon, @timeoff, @qty)"
                Cmd.Prepare()

                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@rp", Control.RP)
                Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(2), Milking).Start)
                Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(2), Milking).Finish)
                Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(2), Milking).Qty)

                Cmd.ExecuteNonQuery()
            End If

            If Control.Milkings.Count > 2 Then
                Cmd.CommandText = "INSERT INTO ordene VALUES (@id, @rp, @timeon, @timeoff, @qty)"
                Cmd.Prepare()

                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@rp", Control.RP)
                Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(3), Milking).Start)
                Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(3), Milking).Finish)
                Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(3), Milking).Qty)

                Cmd.ExecuteNonQuery()
            End If

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra control para el bovino de RP " & Control.RP))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub UpdateInDB(ByVal Control As MilkControl) 'Gets the right data but does not edit... TODO: FIX!'
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

            Cmd.CommandText = "UPDATE control SET Fecha=@date, Grasas=@fat, Lactosa=@lact, Agua_Leche=@smb, Recuento_Bacteriano=@bact, Proteinas=@prot, Celulas_Somaticas=@som WHERE ID=@id AND RP_Bovino=@rp"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", Control.ID)
            Cmd.Parameters.AddWithValue("@fat", Control.Fat)
            Cmd.Parameters.AddWithValue("@lact", Control.Lactose)
            Cmd.Parameters.AddWithValue("@smb", Control.Water)
            Cmd.Parameters.AddWithValue("@bact", Control.Bacteria)
            Cmd.Parameters.AddWithValue("@prot", Control.Proteins)
            Cmd.Parameters.AddWithValue("@som", Control.SomCel)
            Cmd.Parameters.AddWithValue("@date", Control.Time)
            Cmd.Parameters.AddWithValue("@rp", Control.RP)

            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "UPDATE ordene SET Hora_Fin=@timeoff, Cantidad=@qty WHERE ID_Control=@id AND RP_Bovino=@rp AND Hora_Inicio=@timeon"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(1), Milking).Start.Hour & ":" & CType(Control.Milkings(1), Milking).Start.Minute & ":" & CType(Control.Milkings(1), Milking).Start.Second)
            Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(1), Milking).Finish)
            Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(1), Milking).Qty)

            Console.WriteLine("RP: " & Control.RP & ControlChars.NewLine & "ID: " & Control.ID & ControlChars.NewLine & "Hora_Inicio: " & CType(Control.Milkings(1), Milking).Start)

            Cmd.ExecuteNonQuery()

            If Control.Milkings.Count > 1 Then
                'Testing'
                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@id", Control.ID)
                Cmd.Parameters.AddWithValue("@rp", Control.RP)
                'Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(2), Milking).Start)
                Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(2), Milking).Start.Hour & ":" & CType(Control.Milkings(2), Milking).Start.Minute & ":" & CType(Control.Milkings(2), Milking).Start.Second)
                Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(2), Milking).Finish)
                Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(2), Milking).Qty)

                Console.WriteLine("RP: " & Control.RP & ControlChars.NewLine & "ID: " & Control.ID & ControlChars.NewLine & "Hora_Inicio: " & CType(Control.Milkings(2), Milking).Start)

                Cmd.ExecuteNonQuery()
            End If

            If Control.Milkings.Count > 2 Then
                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@id", Control.ID)
                Cmd.Parameters.AddWithValue("@rp", Control.RP)
                Cmd.Parameters.AddWithValue("@timeon", CType(Control.Milkings(3), Milking).Start.Hour & ":" & CType(Control.Milkings(3), Milking).Start.Minute & ":" & CType(Control.Milkings(3), Milking).Start.Second)
                Cmd.Parameters.AddWithValue("@timeoff", CType(Control.Milkings(3), Milking).Finish)
                Cmd.Parameters.AddWithValue("@qty", CType(Control.Milkings(3), Milking).Qty)

                Cmd.ExecuteNonQuery()
            End If

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se actualiza control del " & Control.Time & " para el bovino de RP " & Control.RP))
        Catch e As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine("Caught in MilkControl.UpdateInDB()")
            Console.WriteLine(e.Message)
            Console.WriteLine(e.ErrorCode)
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

            Cmd.CommandText = "DELETE FROM ordene WHERE ID_Control=@id"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@id", ID)

            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "SET foreign_key_checks = 0"
            Cmd.Prepare()

            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "DELETE FROM control WHERE ID=@id"
            Cmd.Prepare()

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina control con ID " & ID))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Function GetFromDB(ByVal ID As Integer) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT * FROM control WHERE ID=@id"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@id", ID))

            Do While Reader.Read
                RetVal.Add(New MilkControl(Reader.GetInt32("ID"),
                                           Reader.GetInt32("RP_Bovino"),
                                           Reader.GetDateTime("Fecha"),
                                           Reader.GetInt32("Grasas"),
                                           Reader.GetInt32("Celulas_Somaticas"),
                                           Reader.GetInt32("Lactosa"),
                                           Reader.GetInt32("Proteinas"),
                                           Reader.GetInt32("Agua_Leche"),
                                           Reader.GetInt32("Recuento_Bacteriano")))

                CType(RetVal(RetVal.Count), MilkControl).Milkings = Milking.GetFromDB(Reader.GetInt32("ID"),
                                                                                      Reader.GetInt32("RP_Bovino"),
                                                                                      Reader.GetDateTime("Fecha"))
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetAvgs(ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT AVG(Grasas) AS 'Grasas', AVG(Lactosa) AS 'Lactosa', AVG(Agua_Leche) AS 'Agua_Leche', AVG(Recuento_Bacteriano) AS 'Recuento_Bacteriano', AVG(Proteinas) AS 'Proteinas', AVG(Celulas_Somaticas) AS 'Celulas_Somaticas' FROM control"
        Else
            CommandText = "SELECT AVG(Grasas) AS 'Grasas', AVG(Lactosa) AS 'Lactosa', AVG(Agua_Leche) AS 'Agua_Leche', AVG(Recuento_Bacteriano) AS 'Recuento_Bacteriano', AVG(Proteinas) AS 'Proteinas', AVG(Celulas_Somaticas) AS 'Celulas_Somaticas' FROM control WHERE RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@yard)"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", My.Settings.Establishment))

            Do While Reader.Read
                RetVal.Add(Reader.GetInt32("Grasas"))
                RetVal.Add(Reader.GetInt32("Lactosa"))
                RetVal.Add(Reader.GetInt32("Agua_Leche"))
                RetVal.Add(Reader.GetInt32("Recuento_Bacteriano"))
                RetVal.Add(Reader.GetInt32("Proteinas"))
                RetVal.Add(Reader.GetInt32("Celulas_Somaticas"))
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetProdAvg(ByVal RP As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT AVG(Cantidad) AS 'Produccion' FROM ordene WHERE RP_Bovino=@rp"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

            Do While Reader.Read
                RetVal = Reader.GetInt32("Produccion")
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetProdAvg() As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT AVG(Cantidad) AS 'Produccion' FROM ordene"
        Else
            CommandText = "SELECT AVG(Cantidad) AS 'Produccion' FROM ordene WHERE RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@tambo)"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            Do While Reader.Read
                RetVal = Reader.GetInt32("Produccion")
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetProdAvg(ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT AVG(Cantidad) AS 'Produccion' FROM ordene"
        Else
            CommandText = "SELECT AVG(Cantidad) AS 'Produccion' FROM ordene WHERE RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@tambo)"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            Do While Reader.Read
                RetVal = Reader.GetInt32("Produccion")
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetProdForYear(ByVal Year As Integer, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT SUM(Cantidad) AS 'Produccion' FROM ordene WHERE ID_Control IN (SELECT ID FROM control WHERE YEAR(Fecha)=@year)"
        Else
            CommandText = "SELECT SUM(Cantidad) AS 'Produccion' FROM ordene WHERE ID_Control IN (SELECT ID FROM control WHERE YEAR(Fecha)=@year GROUP BY ID HAVING RP_Bovino IN (SELECT RP FROM bovino WHERE Nom_Tambo=@yard))"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@year", Year),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", My.Settings.Establishment))

            Do While Reader.Read
                RetVal = Reader.GetInt32("Produccion")
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Class Milking

        Property Start As Date
        Property Finish As Date
        Property Qty As Integer

        Sub New(ByVal NewStart As Date, ByVal NewFinish As Date, ByVal NewQty As Integer)
            Start = NewStart
            Finish = NewFinish
            Qty = NewQty
        End Sub

        Public Shared Function GetFromDB(ByVal IDControl As Integer, ByVal RP As Integer, ByVal NewDate As Date) As Collection
            Dim RetVal As New Collection
            Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
            Dim MyConnString As String
            Dim CommandText As String

            MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

            CommandText = "SELECT * FROM ordene WHERE ID_Control=@id AND RP_Bovino=@rp ORDER BY Hora_Inicio ASC"

            Try
                Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@id", IDControl),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

                Do While Reader.Read
                    Dim StartTime As Date = NewDate + Reader.GetTimeSpan("Hora_Inicio")
                    Dim FinishTime As Date = NewDate + Reader.GetTimeSpan("Hora_Fin")
                    RetVal.Add(New Milking(StartTime, FinishTime, Reader.GetInt32("Cantidad")))
                Loop
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try

            Return RetVal
        End Function

    End Class

End Class
