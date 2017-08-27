Public Class Lot

    Property Name As String
    Property State As Integer
    Property BirthsFrom As Integer
    Property BirthsTo As Integer
    Property LactFrom As Integer
    Property LactTo As Integer
    Property ProductionFrom As Integer
    Property ProductionTo As Integer

    Sub New(ByVal NewName As String, ByVal NewState As String, ByVal NewBirthsFrom As Integer, ByVal NewBirthsTo As Integer, ByVal NewLactFrom As Integer, ByVal NewLactTo As Integer, ByVal NewProductionFrom As Integer, ByVal NewProductionTo As Integer)
        Name = NewName
        If NewState IsNot Nothing Then
            State = NewState
        End If
        If NewBirthsFrom <> Nothing And NewBirthsTo <> Nothing Then
            BirthsFrom = NewBirthsFrom
            BirthsTo = NewBirthsTo
        End If
        If NewLactFrom <> Nothing And NewLactTo <> Nothing Then
            LactFrom = NewLactFrom
            LactTo = NewLactTo
        End If
        If NewProductionFrom <> Nothing And NewProductionTo <> Nothing Then
            ProductionFrom = NewProductionFrom
            ProductionTo = NewProductionTo
        End If
    End Sub

    Public Shared Sub InsertIntoDB(ByVal Lote As Lot)

        Dim Estab As String

        If My.Settings.Establishment.Equals("") Then
            Dim Establishments As Collection = Establishment.GetEstabList()
            Establishments.Remove(1) 'Remove TODOS entry'
            Dim EstabSelect As New ComboDialog.ComboDialog("Seleccionar establecimiento", Establishments)
            If EstabSelect.ShowDialog() = DialogResult.OK Then
                Estab = EstabSelect.RetVal
            Else
                MessageBox.Show("Se necesita un establecimiento al que asignar el lote...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            Estab = My.Settings.Establishment
        End If

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

            Cmd.CommandText = "INSERT INTO lote VALUES (@name, @state, @qtyfrom, @qtyto, @daysfrom, @daysto, @prodfrom, @prodto, @yard)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@name", Lote.Name)
            Try
                Cmd.Parameters.AddWithValue("@state", Lote.State)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@qtyfrom", Lote.BirthsFrom)
                Cmd.Parameters.AddWithValue("@qtyto", Lote.BirthsTo)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@daysfrom", Lote.LactFrom)
                Cmd.Parameters.AddWithValue("@daysto", Lote.LactTo)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@prodfrom", Lote.ProductionFrom)
                Cmd.Parameters.AddWithValue("@prodto", Lote.ProductionTo)
            Catch ex As Exception

            End Try
            Cmd.Parameters.AddWithValue("@yard", Estab)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra lote con nombre " & Lote.Name))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Sub UpdateInDB(ByVal Lote As Lot)
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

            Cmd.CommandText = "UPDATE lote SET Estado_Repro=@state, Cantidad_Desde=@qtyfrom, Cantidad_Hasta=@qtyto, Dias_Desde=@daysfrom, Dias_Hasta=@daysto, Produccion_Desde=@prodfrom, Produccion_Hasta=@prodto WHERE Nombre=@name"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@name", Lote.Name)
            Try
                Cmd.Parameters.AddWithValue("@state", Lote.State)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@qtyfrom", Lote.BirthsFrom)
                Cmd.Parameters.AddWithValue("@qtyto", Lote.BirthsTo)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@daysfrom", Lote.LactFrom)
                Cmd.Parameters.AddWithValue("@daysto", Lote.LactTo)
            Catch ex As Exception

            End Try
            Try
                Cmd.Parameters.AddWithValue("@prodfrom", Lote.ProductionFrom)
                Cmd.Parameters.AddWithValue("@prodto", Lote.ProductionTo)
            Catch ex As Exception

            End Try

            If My.Settings.Establishment.Equals("") Then
                Cmd.Parameters.AddWithValue("@yard", GetEstablishment(Lote.Name, Conn))
            Else
                Cmd.Parameters.AddWithValue("@yard", My.Settings.Establishment)
            End If

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se actualiza lote con nombre " & Lote.Name))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Sub DeleteFromDB(ByVal Lote As String)

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

            Cmd.CommandText = "DELETE FROM lote WHERE Nombre=@name"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@name", Lote)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina lote con nombre " & Lote))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Function GetFromDB(ByVal Establishment As String) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If Establishment.Equals("") Then
            CommandText = "SELECT * FROM lote"
        Else
            CommandText = "SELECT * FROM lote WHERE Nom_Tambo=@yard"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", Establishment))

            Do While Reader.Read
                Dim State As Integer
                Dim BirthsFrom As Integer
                Dim BirthsTo As Integer
                Dim LactFrom As Integer
                Dim LactTo As Integer
                Dim ProductionFrom As Integer
                Dim ProductionTo As Integer

                Try
                    State = Reader.GetInt32("Estado_Repro")
                Catch ex As Exception

                End Try

                Try
                    BirthsFrom = Reader.GetInt32("Cantidad_Desde")
                    BirthsTo = Reader.GetInt32("Cantidad_Hasta")
                Catch ex As Exception

                End Try

                Try
                    LactFrom = Reader.GetInt32("Dias_Desde")
                    LactTo = Reader.GetInt32("Dias_Hasta")
                Catch ex As Exception

                End Try

                Try
                    ProductionFrom = Reader.GetInt32("Produccion_Desde")
                    ProductionTo = Reader.GetInt32("Produccion_Hasta")
                Catch ex As Exception

                End Try

                RetVal.Add(New Lot(Reader.GetString("Nombre"), State, BirthsFrom, BirthsTo, LactFrom, LactTo, ProductionFrom, ProductionTo))
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetFromDB(ByVal Establishment As String, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim RetVal As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If Establishment.Equals("") Then
            CommandText = "SELECT * FROM lote"
        Else
            CommandText = "SELECT * FROM lote WHERE Nom_Tambo=@yard"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", Establishment))

            Do While Reader.Read
                Dim State As Integer
                Dim BirthsFrom As Integer
                Dim BirthsTo As Integer
                Dim LactFrom As Integer
                Dim LactTo As Integer
                Dim ProductionFrom As Integer
                Dim ProductionTo As Integer

                Try
                    State = Reader.GetInt32("Estado_Repro")
                Catch ex As Exception

                End Try

                Try
                    BirthsFrom = Reader.GetInt32("Cantidad_Desde")
                    BirthsTo = Reader.GetInt32("Cantidad_Hasta")
                Catch ex As Exception

                End Try

                Try
                    LactFrom = Reader.GetInt32("Dias_Desde")
                    LactTo = Reader.GetInt32("Dias_Hasta")
                Catch ex As Exception

                End Try

                Try
                    ProductionFrom = Reader.GetInt32("Produccion_Desde")
                    ProductionTo = Reader.GetInt32("Produccion_Hasta")
                Catch ex As Exception

                End Try

                RetVal.Add(New Lot(Reader.GetString("Nombre"), State, BirthsFrom, BirthsTo, LactFrom, LactTo, ProductionFrom, ProductionTo))
            Loop

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetFromDB(ByVal Name As String, ByVal Establishment As String) As Lot
        Dim RetVal As Lot
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If Establishment.Equals("") Then
            CommandText = "SELECT * FROM lote WHERE Nombre=@name"
        Else
            CommandText = "SELECT * FROM lote WHERE Nombre=@name AND Nom_Tambo=@yard"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@name", Name),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", Establishment))

            If Reader.Read Then
                Dim State As Integer
                Dim BirthsFrom As Integer
                Dim BirthsTo As Integer
                Dim LactFrom As Integer
                Dim LactTo As Integer
                Dim ProductionFrom As Integer
                Dim ProductionTo As Integer

                Try
                    State = Reader.GetInt32("Estado_Repro")
                Catch ex As Exception

                End Try

                Try
                    BirthsFrom = Reader.GetInt32("Cantidad_Desde")
                    BirthsTo = Reader.GetInt32("Cantidad_Hasta")
                Catch ex As Exception

                End Try

                Try
                    LactFrom = Reader.GetInt32("Dias_Desde")
                    LactTo = Reader.GetInt32("Dias_Hasta")
                Catch ex As Exception

                End Try

                Try
                    ProductionFrom = Reader.GetInt32("Produccion_Desde")
                    ProductionTo = Reader.GetInt32("Produccion_Hasta")
                Catch ex As Exception

                End Try

                RetVal = New Lot(Reader.GetString("Nombre"), State, BirthsFrom, BirthsTo, LactFrom, LactTo, ProductionFrom, ProductionTo)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetEstablishment(ByVal Name As String, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As String
        Dim RetVal As String
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        CommandText = "SELECT Nom_Tambo FROM lote WHERE Nombre=@name"

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@name", Name))

            If Reader.Read Then
                RetVal = Reader.GetString("Nom_Tambo")
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

End Class
