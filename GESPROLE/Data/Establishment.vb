Public Class Establishment

    Property Name As String
    Property Mail As String
    Property Address As String
    Property Size As Integer
    Property Capacity As Integer

    Sub New(ByVal NewName As String, ByVal NewMail As String, ByVal NewAddress As String, ByVal NewSize As Integer, ByVal NewCapacity As Integer)
        Name = NewName
        Mail = NewMail
        Address = NewAddress
        Size = NewSize
        Capacity = NewCapacity
    End Sub

    Public Shared Function GetProducer() As String
        Dim Name As String = ""
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT Nombre_Productor FROM tambo LIMIT 1"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString, CommandText)

            If Reader.Read Then
                Name = Reader.GetString("Nombre_Productor")
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

        Return Name
    End Function

    Public Shared Sub InsertIntoDB(ByVal Tambo As Establishment, ByVal Producer As String)
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

            Cmd.CommandText = "INSERT INTO tambo VALUES (@name, @mail, @addr, @hect, @cap, @prod)"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@name", Tambo.Name.ToUpper)
            Cmd.Parameters.AddWithValue("@mail", Tambo.Mail)
            Cmd.Parameters.AddWithValue("@addr", Tambo.Address.ToUpper)
            Cmd.Parameters.AddWithValue("@hect", Tambo.Size)
            Cmd.Parameters.AddWithValue("@cap", Tambo.Capacity)
            Cmd.Parameters.AddWithValue("@prod", Producer.ToUpper)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se registra establecimiento llamado " & Tambo.Name))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
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

    Public Shared Sub UpdateInDB(ByVal Tambo As Establishment)
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

            Cmd.CommandText = "UPDATE tambo SET Email=@mail, Direccion=@addr, Hectareas=@hect, Capacidad=@cap WHERE Nombre=@name"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@name", Tambo.Name.ToUpper)
            Cmd.Parameters.AddWithValue("@mail", Tambo.Mail)
            Cmd.Parameters.AddWithValue("@addr", Tambo.Address.ToUpper)
            Cmd.Parameters.AddWithValue("@hect", Tambo.Size)
            Cmd.Parameters.AddWithValue("@cap", Tambo.Capacity)

            Cmd.ExecuteNonQuery()

            Conn.Close()

            Log.InsertIntoDB(New Log(Now, My.Settings.LogName, "Se actualiza establecimiento " & Tambo.Name))
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
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

    Public Shared Function GetEstablishment(ByVal Name As String) As Establishment
        Dim RetVal As Establishment
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT * FROM tambo WHERE Nombre=@name"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@name", Name))

            If Reader.Read Then
                RetVal = New Establishment(Reader.GetString("Nombre"),
                                           Reader.GetString("Email"),
                                           Reader.GetString("Direccion"),
                                           Reader.GetInt32("Hectareas"),
                                           Reader.GetInt32("Capacidad"))
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return RetVal
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function

    Public Shared Function GetEstabList() As Collection
        Dim Establishments As New Collection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT Nombre FROM tambo"

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString, CommandText)

            Do While Reader.Read
                If Establishments.Count = 0 Then
                    'Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.Language)
                    'Dim ResourceManager As ResourceManager = ResourceManager.CreateFileBasedResourceManager("resource", System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\"), Nothing)
                    Establishments.Add(My.Computer.ResourceMgr.GetString("0066"))
                End If
                Establishments.Add(Reader.GetString("Nombre"))
            Loop
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

        Return Establishments
    End Function

    Public Shared Function GetRemainingCapacity(ByVal Establishment As String, ByVal Time As Date) As Integer
        Dim RetVal As Integer = 0
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        CommandText = "SELECT Capacidad FROM tambo WHERE Nombre=@yard"

        Try
            Conn.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Conn,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@yard", Establishment))

            If Reader.Read Then
                RetVal = Reader.GetInt32("Capacidad")

                Dim Cows As Collection = Cow.GetFromDB(Cow.COW, Time)

                RetVal -= Cows.Count

                For Each Cow As Cow In Cows
                    If Cow.GetCowsState(Cow.RP, Time, Conn).Equals("PREÑADA") Then
                        RetVal -= 1
                    End If
                Next
            End If

            Reader.Close()
            Conn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        Finally
            Conn.Dispose()
        End Try

        Return RetVal
    End Function

    Public Shared Function GetCowCount(ByVal Establishment As String, ByVal Time As Date) As Integer
        Dim RetVal As Integer = 0
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String
        Dim CommandText As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        If Establishment.Equals("") Then
            CommandText = "SELECT COUNT(*) FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale) AND evento.Fecha <= @time) And bovino.Sexo=@gender AND bovino.Nacimiento <= @time"
        Else
            CommandText = "SELECT COUNT(*) FROM bovino WHERE RP Not IN (SELECT bovino.RP FROM bovino, evento WHERE bovino.RP=evento.RP_Bovino And evento.Tipo IN (@death,@reject,@sale) AND evento.Fecha <= @time) And bovino.Sexo=@gender AND bovino.Nacimiento <= @time AND Nom_Tambo=@tambo"
        End If

        Try
            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(MyConnString,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", Establishment),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@time", Time),
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@gender", Cow.COW))

            If Reader.Read Then
                RetVal = Reader.GetInt32("COUNT(*)")
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

        Return RetVal
    End Function

    Public Shared Function GetSize(ByRef Connection As MySql.Data.MySqlClient.MySqlConnection) As Integer
        Dim RetVal As Integer = 0
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim CommandText As String

        If Not My.Settings.Establishment.Equals("") Then
            CommandText = "SELECT SUM(Hectareas) FROM tambo WHERE Nombre=@tambo"
        Else
            CommandText = "SELECT SUM(Hectareas) FROM tambo"
        End If

        Try
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            Connection.Open()

            Reader = MySql.Data.MySqlClient.MySqlHelper.ExecuteReader(Connection,
                                                                      CommandText,
                                                                      New MySql.Data.MySqlClient.MySqlParameter("@tambo", My.Settings.Establishment))

            If Reader.Read Then
                RetVal = Reader.GetInt32("SUM(Hectareas)")
            End If

            Reader.Close()
            Connection.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        End Try

        Return RetVal
    End Function

End Class
