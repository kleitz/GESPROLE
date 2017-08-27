Public Class Cow

    Property RP As Integer
    Property Name As String
    Property Breed As String
    Property Birth As Date
    Property Gender As Boolean
    Property Weight As Integer
    Property Background As String

    Property Mum As Integer

    Public Const COW As Boolean = True
    Public Const BULL As Boolean = False

    Sub New(ByVal NewRP As Integer, ByVal NewName As String, ByVal NewGender As Boolean, ByVal NewBreed As String, ByVal NewWeight As Integer, ByVal NewBrith As Date, ByVal NewBackground As String)
        RP = NewRP
        Name = NewName
        Breed = NewBreed
        Birth = NewBrith
        Gender = NewGender
        Weight = NewWeight
        Background = NewBackground
    End Sub

    Sub New(ByVal NewRP As Integer, ByVal NewName As String, ByVal NewGender As Boolean, ByVal NewBreed As String, ByVal NewWeight As Integer, ByVal NewBrith As Date, ByVal NewMum As Integer)
        RP = NewRP
        Name = NewName
        Breed = NewBreed
        Birth = NewBrith
        Gender = NewGender
        Weight = NewWeight
        Mum = NewMum
    End Sub

    Public Shared Sub InsertIntoDB(ByVal NewCow As Cow, ByVal Establishment As String)
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

            If NewCow.Mum <> 0 Then
                Cmd.CommandText = "INSERT INTO bovino (Nombre, Nacimiento, Sexo, Raza, Peso, RP_Madre, Nom_Tambo) VALUES (@name, @birth, @gender, @breed, @weight, @mum, @yard)"
                Cmd.Prepare()
                Cmd.Parameters.AddWithValue("@mum", NewCow.Mum)
            Else
                Cmd.CommandText = "INSERT INTO bovino (Nombre, Nacimiento, Sexo, Raza, Peso, Procedencia, Nom_Tambo) VALUES (@name, @birth, @gender, @breed, @weight, @background, @yard)"
                Cmd.Prepare()
                Cmd.Parameters.AddWithValue("@background", NewCow.Background.ToUpper)
            End If


            Cmd.Parameters.AddWithValue("@name", NewCow.Name.ToUpper)
            Cmd.Parameters.AddWithValue("@birth", NewCow.Birth)
            Cmd.Parameters.AddWithValue("@gender", NewCow.Gender)
            Cmd.Parameters.AddWithValue("@breed", NewCow.Breed.ToUpper)
            Cmd.Parameters.AddWithValue("@weight", NewCow.Weight)

            Cmd.Parameters.AddWithValue("@yard", Establishment.ToUpper)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra bovino " & NewCow.Name))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0011"))
                Case 1045
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0008") & ", " & My.Computer.ResourceMgr.GetString("0010"))
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub UpdateWeight(ByVal RP As Integer, ByVal NewWeight As Integer)
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

            Cmd.CommandText = "UPDATE bovino SET Peso=@weight WHERE RP=@rp"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@rp", RP)
            Cmd.Parameters.AddWithValue("@weight", NewWeight)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se actualiza bovino con RP " & RP))
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Sub RemoveFromDB(ByVal RP As Integer)
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

            Cmd.CommandText = "DELETE FROM bovino WHERE RP=@rp"
            Cmd.Prepare()


            Cmd.Parameters.AddWithValue("@rp", RP)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se elimina bovino con RP " & RP))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0011"))
                Case 1045
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0008") & ", " & My.Computer.ResourceMgr.GetString("0010"))
            End Select
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Shared Function GetFromDB(ByVal Gender As Boolean, ByVal Time As Date) As Collection 'Returns a collection of cows that havent died or been sold'
        Dim Cows As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String = ""

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT * FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale)) And bovino.Sexo=@gender AND Nacimiento <= @time"
        Else
            CommandText = "SELECT * FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale)) And bovino.Sexo=@gender AND Nacimiento <= @time AND Nom_Tambo=@tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@death", LifeEvent.MUERTE),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@reject", LifeEvent.RECHAZO),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@sale", LifeEvent.VENTA),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@time", Time),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Gender),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            While Reader.Read
                Dim CurrentCow As Cow
                Try
                    CurrentCow = New Cow(Reader.GetInt32("RP"),
                                         Reader.GetString("Nombre"),
                                         Reader.GetBoolean("Sexo"),
                                         Reader.GetString("Raza"),
                                         Reader.GetInt32("Peso"),
                                         Reader.GetDateTime("Nacimiento"),
                                         Reader.GetString("Procedencia"))
                Catch e As Exception
                    CurrentCow = New Cow(Reader.GetInt32("RP"),
                                         Reader.GetString("Nombre"),
                                         Reader.GetBoolean("Sexo"),
                                         Reader.GetString("Raza"),
                                         Reader.GetInt32("Peso"),
                                         Reader.GetDateTime("Nacimiento"),
                                         Reader.GetInt32("RP_Madre"))
                End Try
                Cows.Add(CurrentCow)
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Return Cows
    End Function

    Public Shared Function GetFromDB(ByVal Gender As Boolean, ByVal Time As Date, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim Cows As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String = ""

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT * FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale)) And bovino.Sexo=@gender AND Nacimiento <= @time"
        Else
            CommandText = "SELECT * FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale)) And bovino.Sexo=@gender AND Nacimiento <= @time AND Nom_Tambo=@tambo"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@death", LifeEvent.MUERTE),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@reject", LifeEvent.RECHAZO),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@sale", LifeEvent.VENTA),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@time", Time),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Gender),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            While Reader.Read
                Dim CurrentCow As Cow
                Try
                    CurrentCow = New Cow(Reader.GetInt32("RP"),
                                         Reader.GetString("Nombre"),
                                         Reader.GetBoolean("Sexo"),
                                         Reader.GetString("Raza"),
                                         Reader.GetInt32("Peso"),
                                         Reader.GetDateTime("Nacimiento"),
                                         Reader.GetString("Procedencia"))
                Catch e As Exception
                    CurrentCow = New Cow(Reader.GetInt32("RP"),
                                         Reader.GetString("Nombre"),
                                         Reader.GetBoolean("Sexo"),
                                         Reader.GetString("Raza"),
                                         Reader.GetInt32("Peso"),
                                         Reader.GetDateTime("Nacimiento"),
                                         Reader.GetInt32("RP_Madre"))
                End Try
                Cows.Add(CurrentCow)
            End While

            Reader.Close()
            Connection.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Return Cows
    End Function

    Public Shared Function GetFromDB(ByVal RP As Integer, ByVal Gender As Boolean) As Cow
        Dim Cow As Cow
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String = ""

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT * FROM bovino WHERE RP=@rp AND Sexo=@gender"
        Else
            CommandText = "SELECT * FROM bovino WHERE RP=@rp AND Sexo=@gender AND Nom_Tambo=@tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Gender),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            If Reader.Read Then
                Try
                    Cow = New Cow(Reader.GetInt32("RP"),
                                  Reader.GetString("Nombre"),
                                  Reader.GetBoolean("Sexo"),
                                  Reader.GetString("Raza"),
                                  Reader.GetInt32("Peso"),
                                  Reader.GetDateTime("Nacimiento"),
                                  Reader.GetString("Procedencia"))
                Catch e As Exception
                    Cow = New Cow(Reader.GetInt32("RP"),
                                  Reader.GetString("Nombre"),
                                  Reader.GetBoolean("Sexo"),
                                  Reader.GetString("Raza"),
                                  Reader.GetInt32("Peso"),
                                  Reader.GetDateTime("Nacimiento"),
                                  Reader.GetInt32("RP_Madre"))
                End Try
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return Cow
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetFromDB(ByVal RP As Integer, ByVal Gender As Boolean, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Cow
        Dim Cow As Cow
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String = ""

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT * FROM bovino WHERE RP=@rp AND Sexo=@gender"
        Else
            CommandText = "SELECT * FROM bovino WHERE RP=@rp AND Sexo=@gender AND Nom_Tambo=@tambo"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Gender),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            If Reader.Read Then
                Try
                    Cow = New Cow(Reader.GetInt32("RP"),
                                  Reader.GetString("Nombre"),
                                  Reader.GetBoolean("Sexo"),
                                  Reader.GetString("Raza"),
                                  Reader.GetInt32("Peso"),
                                  Reader.GetDateTime("Nacimiento"),
                                  Reader.GetString("Procedencia"))
                Catch e As Exception
                    Cow = New Cow(Reader.GetInt32("RP"),
                                  Reader.GetString("Nombre"),
                                  Reader.GetBoolean("Sexo"),
                                  Reader.GetString("Raza"),
                                  Reader.GetInt32("Peso"),
                                  Reader.GetDateTime("Nacimiento"),
                                  Reader.GetInt32("RP_Madre"))
                End Try
            End If

            Reader.Close()
            Connection.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return Cow
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function SearchInDB(ByVal Query As String, ByVal Gender As Boolean) As Collection
        Dim Cows As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT * FROM bovino WHERE Nombre LIKE @name AND Sexo=@gender"
        Else
            CommandText = "SELECT * FROM bovino WHERE Nombre LIKE @name AND Sexo=@gender AND Nom_Tambo=@tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@name", Query),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Gender),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            While Reader.Read
                Dim CurrentCow As Cow
                Try
                    CurrentCow = New Cow(Reader.GetInt32("RP"), Reader.GetString("Nombre"), Reader.GetBoolean("Sexo"), Reader.GetString("Raza"), Reader.GetInt32("Peso"), Reader.GetDateTime("Nacimiento"), Reader.GetString("Procedencia"))
                Catch e As Exception
                    CurrentCow = New Cow(Reader.GetInt32("RP"), Reader.GetString("Nombre"), Reader.GetBoolean("Sexo"), Reader.GetString("Raza"), Reader.GetInt32("Peso"), Reader.GetDateTime("Nacimiento"), Reader.GetInt32("RP_Madre"))
                End Try
                Cows.Add(CurrentCow)
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        End Try

        Return Cows
    End Function

    Public Shared Function GetList(ByVal Gender As Boolean, ByVal ListContent As Integer, ByVal NewLot As Lot, ByVal Time As Date, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Collection
        Dim Cows As New Collection

        Cows = GetFromDB(COW, Time, Connection)
        Dim Index As Integer = 1

        Select Case ListContent
            Case List.VACAS
                For Each Cow As Cow In Cows
                    If DateDiff(DateInterval.Day, Cow.Birth, Time) < My.Settings.Vaquillona Or LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection) Is Nothing Then
                        Cows.Remove(Index)
                        Index -= 1
                    End If
                    Index += 1
                Next
            Case List.LACTANDO
                For Each Cow As Cow In Cows
                    If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0256")) Or GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0252")) Or DateDiff(DateInterval.Day, Cow.Birth, Time) < My.Settings.Vaquillona Or LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection) Is Nothing Then
                        Cows.Remove(Index)
                        Index -= 1
                    End If
                    Index += 1
                Next
            Case List.SECAS
                For Each Cow As Cow In Cows
                    If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0255")) Or GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0252")) Or DateDiff(DateInterval.Day, Cow.Birth, Time) < My.Settings.Vaquillona Or LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection) Is Nothing Then
                        Cows.Remove(Index)
                        Index -= 1
                    End If
                    Index += 1
                Next
            Case List.VAQUILLONAS
                For Each Cow As Cow In Cows
                    If DateDiff(DateInterval.Day, Cow.Birth, Time) < My.Settings.Vaquillona Or LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection) IsNot Nothing Then
                        Cows.Remove(Index)
                        Index -= 1
                    End If
                    Index += 1
                Next
            Case List.A_SECAR
                For Each Cow As Cow In Cows
                    Dim DeletedCurrentIndex As Boolean = False

                    If LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection) Is Nothing And Not DeletedCurrentIndex Then
                        Cows.Remove(Index)
                        Index -= 1
                        DeletedCurrentIndex = True
                    Else
                        If DateDiff(DateInterval.Day, LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection).Time, Now) < My.Settings.Secar Or GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0255")) And Not DeletedCurrentIndex Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If

                        If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0256")) And Not DeletedCurrentIndex Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If
                    End If
                    Index += 1
                Next
            Case List.A_PARIR
                For Each Cow As Cow In Cows
                    Dim DeletedCurrentIndex As Boolean = False

                    If LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection) Is Nothing And Not DeletedCurrentIndex Then
                        Cows.Remove(Index)
                        Index -= 1
                        DeletedCurrentIndex = True
                    Else
                        If DateDiff(DateInterval.Day, LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection).Time, Now) < My.Settings.PartoPostServ And Not DeletedCurrentIndex Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If

                        If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0254")) And Not DeletedCurrentIndex Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If
                    End If
                    Index += 1
                Next
            Case List.A_TACTAR
                For Each Cow As Cow In Cows
                    If LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection) Is Nothing And LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.TACTO, Time, Connection) Is Nothing Then
                        Cows.Remove(Index)
                        Index -= 1
                    ElseIf LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.TACTO, Time, Connection) Is Nothing And DateDiff(DateInterval.Day, LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection).Time, Now) > My.Settings.Prenada Then
                        Cows.Remove(Index)
                        Index -= 1
                    ElseIf LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection) IsNot Nothing And LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.TACTO, Time, Connection) IsNot Nothing Then
                        If DateDiff(DateInterval.Day, LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.SERVICIO, Time, Connection).Time, LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.TACTO, Time, Connection).Time) >= 0 Then
                            Cows.Remove(Index)
                            Index -= 1
                        End If
                    End If
                    Index += 1
                Next
            Case List.LOT
                Dim DeletedCurrentIndex As Boolean = False

                For Each Cow As Cow In Cows
                    If NewLot.State <> 0 And Not DeletedCurrentIndex Then
                        Select Case NewLot.State
                            Case LifeEvent.PRENADA
                                If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0254")) Then
                                    Cows.Remove(Index)
                                    Index -= 1
                                    DeletedCurrentIndex = True
                                End If
                            Case LifeEvent.VACIA
                                If Not GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0253")) Then
                                    Cows.Remove(Index)
                                    Index -= 1
                                    DeletedCurrentIndex = True
                                End If
                        End Select
                    End If

                    If (NewLot.BirthsFrom <> 0 Or NewLot.BirthsTo <> 0) And Not DeletedCurrentIndex Then
                        Dim BirthCount As Integer = LifeEvent.GetEvtCount(Cow.RP, LifeEvent.PARTO, Connection)
                        If BirthCount < NewLot.BirthsFrom Or BirthCount > NewLot.BirthsTo Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If
                    End If

                    If (NewLot.ProductionFrom <> 0 Or NewLot.ProductionTo <> 0) And Not DeletedCurrentIndex Then
                        Dim ProductAvg As Integer = MilkControl.GetProdAvg(Cow.RP, Connection)
                        If ProductAvg < NewLot.ProductionFrom Or ProductAvg > NewLot.ProductionTo Then
                            Cows.Remove(Index)
                            Index -= 1
                            DeletedCurrentIndex = True
                        End If
                    End If

                    If (NewLot.LactFrom <> 0 Or NewLot.LactTo <> 0) And Not DeletedCurrentIndex Then
                        Dim LastBirth As LifeEvent = LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Time, Connection)
                        If GetCowsState(Cow.RP, Time, Connection).Contains(My.Computer.ResourceMgr.GetString("0256")) Then
                            If DateDiff(DateInterval.Day, LastBirth.Time.AddDays(My.Settings.Calostro), Now) < NewLot.LactFrom Or DateDiff(DateInterval.Day, LastBirth.Time.AddDays(My.Settings.Calostro), Now) > NewLot.LactTo Then
                                Cows.Remove(Index)
                                Index -= 1
                                DeletedCurrentIndex = True
                            End If
                        End If
                    End If

                    DeletedCurrentIndex = False
                    Index += 1
                Next
        End Select

        Return Cows
    End Function

    Public Shared Function GetEstablishment(ByVal RP As Integer) As String
        Dim RetVal As String
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT Nom_Tambo FROM bovino WHERE RP=@rp"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP))

            If Reader.Read Then
                RetVal = Reader.GetString("Nom_Tambo")
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Imposible establecer conexión con el servidor, contacte al administrador")
                Case 1045
                    MessageBox.Show("Usuario y/o contraseña inválidos, intente nuevamente")
            End Select
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetCowsState(ByVal RP As Integer, ByVal Time As Date, ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As String
        Dim RetVal As String = ""

        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.MUERTE, Time, Connection) IsNot Nothing Then
            Return My.Computer.ResourceMgr.GetString("0249")
        End If

        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.VENTA, Time, Connection) IsNot Nothing Then
            Return My.Computer.ResourceMgr.GetString("0250")
        End If

        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.RECHAZO, Time, Connection) IsNot Nothing Then
            Return My.Computer.ResourceMgr.GetString("0251")
        End If

        If DateDiff(DateInterval.Day, GetFromDB(RP, COW, Connection).Birth, Now) < My.Settings.Vaquillona Then
            RetVal = My.Computer.ResourceMgr.GetString("0252")
        Else
            Dim LastBirth As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.PARTO, Time, Connection)
            Dim LastServ As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.SERVICIO, Time, Connection)

            Dim LastTact As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.TACTO, Time, Connection)
            Try
                Do Until LastTact.Time.CompareTo(LastServ.Time) <= 0
                    If LastTact IsNot Nothing Then
                        If LastTact.Data1.Contains("VACIA") Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0253")) Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0254")) Then
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                    If LifeEvent.GetLastEvtOfType(RP, LifeEvent.TACTO, DateAdd(DateInterval.Day, -1, LastTact.Time), Connection) IsNot Nothing Then
                        LastTact = LifeEvent.GetLastEvtOfType(RP, LifeEvent.TACTO, DateAdd(DateInterval.Day, -1, LastTact.Time), Connection)
                    Else
                        Exit Do
                    End If
                Loop
            Catch ex As Exception

            End Try

            Dim LastAbort As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.ABORTO, Time, Connection)
            Dim LastDrying As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.SECADO, Time, Connection)

            If LastServ Is Nothing Then
                RetVal = My.Computer.ResourceMgr.GetString("0253")
            Else
                If LastTact Is Nothing Then 'Was never checked'

                    If LastBirth Is Nothing And LastAbort Is Nothing Then 'Hasnt aborted or given birth, ever'

                        If DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then 'Enough time has passed to consider pregnant'
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else 'Not quite...'
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    ElseIf LastAbort Is Nothing Then 'Hasnt aborted, like, ever...'

                        If DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    ElseIf LastBirth Is Nothing Then 'Hasnt given birth... yet...'

                        If DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    Else

                        If DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Or DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    End If

                Else 'LastTact exists'

                    If LastBirth Is Nothing And LastAbort Is Nothing Then 'Hasnt aborted or given birth, ever'

                        If LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'The result of the analysis was pregnancy'
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        ElseIf LastTact.Data1.Contains("VACIA") Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0253")) Then 'Result was not pregnant'
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        Else 'No result was pertinent to this matter'
                            If DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                                RetVal = My.Computer.ResourceMgr.GetString("0254")
                            Else
                                RetVal = My.Computer.ResourceMgr.GetString("0253")
                            End If
                        End If

                    ElseIf LastAbort Is Nothing Then

                        If DateDiff(DateInterval.Day, LastServ.Time, LastTact.Time) >= 0 And DateDiff(DateInterval.Day, LastTact.Time, LastBirth.Time) < 0 Then
                            If LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'The result of the analysis was pregnancy'
                                RetVal = My.Computer.ResourceMgr.GetString("0254")
                            ElseIf LastTact.Data1.Contains("VACIA") Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0253")) Then 'Result was not pregnant'
                                RetVal = My.Computer.ResourceMgr.GetString("0253")
                            Else 'No result was pertinent to this matter'
                                If DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0254")
                                Else
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                End If
                            End If
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    ElseIf LastBirth Is Nothing Then

                        If DateDiff(DateInterval.Day, LastServ.Time, LastTact.Time) >= 0 And DateDiff(DateInterval.Day, LastTact.Time, LastAbort.Time) < 0 Then
                            If LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'The result of the analysis was pregnancy'
                                RetVal = My.Computer.ResourceMgr.GetString("0254")
                            ElseIf LastTact.Data1.Contains("VACIA") Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0253")) Then 'Result was not pregnant'
                                RetVal = My.Computer.ResourceMgr.GetString("0253")
                            Else 'No result was pertinent to this matter'
                                If DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0254")
                                Else
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                End If
                            End If
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    Else

                        If DateDiff(DateInterval.Day, LastServ.Time, LastTact.Time) >= 0 And (DateDiff(DateInterval.Day, LastTact.Time, LastAbort.Time) < 0 And DateDiff(DateInterval.Day, LastTact.Time, LastBirth.Time) < 0) Then
                            If LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'The result of the analysis was pregnancy'
                                RetVal = My.Computer.ResourceMgr.GetString("0254")
                            ElseIf LastTact.Data1.Contains("VACIA") Or LastTact.Data1.Contains(My.Computer.ResourceMgr.GetString("0253")) Then 'Result was not pregnant'
                                RetVal = My.Computer.ResourceMgr.GetString("0253")
                            Else 'No result was pertinent to this matter'
                                If DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Or DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                                    RetVal = My.Computer.ResourceMgr.GetString("0254")
                                Else
                                    RetVal = My.Computer.ResourceMgr.GetString("0253")
                                End If
                            End If
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, LastAbort.Time) >= 0 Or DateDiff(DateInterval.Day, LastServ.Time, LastBirth.Time) >= 0 Then
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        ElseIf DateDiff(DateInterval.Day, LastServ.Time, Time) >= My.Settings.Prenada Then
                            RetVal = My.Computer.ResourceMgr.GetString("0254")
                        Else
                            RetVal = My.Computer.ResourceMgr.GetString("0253")
                        End If

                    End If
                End If
            End If

            If LastBirth Is Nothing Then
                RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0255")
            Else
                If DateDiff(DateInterval.Day, LastBirth.Time, Time) > My.Settings.Calostro Then
                    If LastDrying Is Nothing Then
                        RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0256")
                    Else
                        If DateDiff(DateInterval.Day, LastDrying.Time, LastBirth.Time) < 0 Then
                            RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0255")
                        Else
                            RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0256")
                        End If
                    End If
                Else
                    RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0257")
                End If
            End If

            If LastBirth IsNot Nothing Then
                If DateDiff(DateInterval.Day, LastBirth.Time, Time) < My.Settings.Anestro Then
                    RetVal = RetVal & " - " & My.Computer.ResourceMgr.GetString("0258")
                End If
            End If
        End If

        Return RetVal
    End Function

    Public Shared Function GetBullState(ByVal RP As Integer, ByVal Time As Date) As String
        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.MUERTE, Time) IsNot Nothing Then
            Return My.Computer.ResourceMgr.GetString("0259")
        End If
        If LifeEvent.GetLastEvtOfType(RP, LifeEvent.VENTA, Time) IsNot Nothing Then
            Return My.Computer.ResourceMgr.GetString("0260")
        End If
        If DateDiff(DateInterval.Day, GetFromDB(RP, BULL).Birth, Time) < 365 Then
            Return My.Computer.ResourceMgr.GetString("0252")
        Else
            Return My.Computer.ResourceMgr.GetString("0261")
        End If
    End Function

    Public Shared Function GetCowsDaddy(ByVal RP As Integer) As String
        Dim RetVal As String = ""
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT RP, Nombre 
                        FROM bovino 
                        WHERE RP=(SELECT CAST(Valor_2 AS SIGNED) 
		                          FROM evento 
		                          WHERE RP_Bovino=(SELECT RP_Madre 
						                           FROM bovino 
						                           WHERE RP=@rp) 
		                          AND Fecha<=(SELECT Nacimiento 
					                         FROM bovino WHERE RP=@rp) 
		                          AND Tipo=@serv 
		                          ORDER BY Fecha DESC 
		                          LIMIT 1)
          
                        UNION
		  
                        SELECT RP, Nombre 
                        FROM bovino 
                        WHERE RP=(SELECT RP_Bovino 
		                          FROM semen 
		                          WHERE ID=(SELECT CAST(Valor_3 AS SIGNED) 
					                        FROM evento 
					                        WHERE RP_Bovino=(SELECT RP_Madre 
									                         FROM bovino 
									                         WHERE RP=@rp) 
					                        AND Fecha<=(SELECT Nacimiento 
							                           FROM bovino WHERE RP=@rp) 
					                        AND Tipo=@serv 
					                        ORDER BY Fecha DESC 
					                        LIMIT 1))"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@rp", RP),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@serv", LifeEvent.SERVICIO))

            Do While Reader.Read
                RetVal = Reader.GetString("Nombre")
            Loop
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetAgeAvg(ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT ROUND(AVG(DATEDIFF(CURDATE(), Nacimiento))/365.242199) AS 'Edad' FROM bovino WHERE Sexo=@gender"
        Else
            CommandText = "SELECT ROUND(AVG(DATEDIFF(CURDATE(), Nacimiento))/365.242199) AS 'Edad' FROM bovino WHERE Sexo=@gender AND Nom_Tambo=@yard"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", COW),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", My.Settings.Establishment))

            If Reader.Read Then
                RetVal = Reader.GetInt32("Edad")
            End If

            Reader.Close()
            Connection.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return RetVal
    End Function

    Class Semen

        Property ID As Integer
        Property Time As Date
        Property RP As Integer

        Sub New(ByVal NewID As Integer, ByVal NewTime As Date, ByVal NewRP As Integer)
            ID = NewID
            Time = NewTime
            RP = NewRP
        End Sub

        Public Shared Sub InsertIntoDB(ByVal Sample As Semen)

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

                Cmd.CommandText = "INSERT INTO semen (Fecha, RP_Bovino) VALUES (@date, @rp)"
                Cmd.Prepare()

                Cmd.Parameters.AddWithValue("@date", Sample.Time)
                Cmd.Parameters.AddWithValue("@rp", Sample.RP)

                Cmd.ExecuteNonQuery()

                Conn.Close()

                Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se inserta muestra de semen del toro con RP " & Sample.RP))
            Catch e As Exception

            Finally
                Conn.Dispose()
            End Try

        End Sub

        Public Shared Function GetFromDB(ByVal ID As Integer) As Semen
            Dim RetVal As Semen
            Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
            Dim MyConnString As String
            Dim CommandText As String

            MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

            CommandText = "SELECT * FROM semen WHERE ID=@id"

            Try
                Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                          CommandText,
                                                                          New MySql.Data.MySqlClient.MySqlParameter("@id", ID))

                If Reader.Read Then
                    RetVal = New Semen(ID, Reader.GetDateTime("Fecha"), Reader.GetInt32("RP_Bovino"))
                End If
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
        End Function

        Public Shared Function GetList() As Collection
            Dim Semens As New Collection
            Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
            Dim MyConnString As String
            Dim CommandText As String

            MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

            CommandText = "SELECT * FROM semen WHERE ID NOT IN (SELECT IFNULL(CAST(Valor_3 AS SIGNED), '') FROM evento WHERE Tipo=@serv OR Tipo=NULL)"

            Try
                Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                          CommandText,
                                                                          New MySql.Data.MySqlClient.MySqlParameter("@serv", LifeEvent.SERVICIO),
                                                                          New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

                Do While Reader.Read
                    Semens.Add(New Semen(Reader.GetInt32("ID"), Reader.GetDateTime("Fecha"), Reader.GetInt32("RP_Bovino")))
                Loop
            Catch ex As MySql.Data.MySqlClient.MySqlException
                Console.WriteLine(ex.Message)
            End Try
            Return Semens
        End Function

    End Class

End Class
