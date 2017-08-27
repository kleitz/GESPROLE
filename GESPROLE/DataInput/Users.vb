Public Class Users
    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0

        If My.Settings.Privileges < 2 Then
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            Register.Text = My.Computer.ResourceMgr.GetString("0240")
        End If

        Try
            Dim Establishments As Collection = Establishment.GetEstabList()
            Establishments.Remove(1) 'Remove TODOS entry'
            For Each Establishment As String In Establishments
                ComboBox2.Items.Add(Establishment)
            Next
            ComboBox2.SelectedIndex = 0
        Catch ex As Exception

        End Try

        If UserNameTextBox.Text.Length > 0 Then
            GetFromDB(UserNameTextBox.Text)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 2 Then
            ComboBox2.Enabled = False
        Else
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        If UserNameTextBox.Text.Length = 0 Or PasswordTextBox.Text.Length = 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0008"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If UserNameTextBox.Enabled Then
            InsertIntoDB()
        Else
            UpdateInDB()
        End If

        DialogResult = DialogResult.OK
    End Sub

    'Database'

    Public Sub InsertIntoDB()

        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim MyConnString As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";" _
            & "charset=utf8mb4;"

        Try
            Conn.ConnectionString = MyConnString
            Conn.Open()

            Cmd.Connection = Conn

            Do While Not Login.Login(UserNameTextBox.Text, PasswordTextBox.Text)
                If ExistsUser(UserNameTextBox.Text) Then
                    Cmd.CommandText = "UPDATE usuario SET Pass=@pass, Privilegios=@priv, Establecimiento=@estab, Sal=@salt WHERE Username=@user;"
                Else
                    Cmd.CommandText = "INSERT INTO usuario VALUES (@user, @pass, @priv, @estab, @salt)"
                End If

                Cmd.Prepare()

                Dim Salt As Byte() = KryptUtils.GenerateSalt()

                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@user", UserNameTextBox.Text)
                Cmd.Parameters.AddWithValue("@pass", KryptUtils.HashPassword(PasswordTextBox.Text, Salt, 78659))
                Cmd.Parameters.AddWithValue("@priv", ComboBox1.SelectedIndex)
                If ComboBox1.SelectedIndex < 2 Then
                    Cmd.Parameters.AddWithValue("@estab", ComboBox2.SelectedItem.ToString)
                Else
                    Cmd.Parameters.AddWithValue("@estab", "")
                End If
                Cmd.Parameters.AddWithValue("@salt", Salt)

                Try
                    Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            Loop

            Conn.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Sub UpdateInDB()

        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Reader As MySql.Data.MySqlClient.MySqlDataReader
        Dim MyConnString As String

        MyConnString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";" _
            & "charset=utf8mb4;"

        Try
            Conn.ConnectionString = MyConnString
            Conn.Open()

            Cmd.Connection = Conn

            Do While Not Login.Login(UserNameTextBox.Text, PasswordTextBox.Text)
                Cmd.CommandText = "SELECT Sal FROM usuario WHERE Username=@user"
                Cmd.Prepare()

                Cmd.Parameters.Clear()

                Cmd.Parameters.AddWithValue("@user", UserNameTextBox.Text)

                Reader = Cmd.ExecuteReader

                If Reader.Read Then
                    Dim Salt(32) As Byte
                    Reader.GetBytes(Reader.GetOrdinal("Sal"), 0, Salt, 0, 33)
                    Reader.Close()

                    Cmd.CommandText = "UPDATE usuario SET Pass=@pass, Privilegios=@priv, Establecimiento=@estab WHERE Username=@user;"
                    Cmd.Prepare()

                    Cmd.Parameters.AddWithValue("@pass", KryptUtils.HashPassword(PasswordTextBox.Text, Salt, 78659))
                    Cmd.Parameters.AddWithValue("@priv", ComboBox1.SelectedIndex)
                    If ComboBox1.SelectedIndex < 2 Then
                        Cmd.Parameters.AddWithValue("@estab", ComboBox2.SelectedItem.ToString)
                    Else
                        Cmd.Parameters.AddWithValue("@estab", "")
                    End If
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                Else
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0286"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Loop

            Conn.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Sub DeleteFromDB(ByVal UserName As String)

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

            Cmd.CommandText = "DELETE FROM usuario WHERE Username=@user"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@user", UserName)

            Cmd.ExecuteNonQuery()

            Conn.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            Conn.Dispose()
        End Try

    End Sub

    Public Shared Function ExistsUser(ByVal User As String) As Boolean

        Dim RetVal As Boolean = False
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

            Cmd.CommandText = "SELECT COUNT(*) FROM usuario WHERE Username=@user"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@user", User)

            Reader = Cmd.ExecuteReader

            If Reader.Read Then
                If Reader.GetInt32("COUNT(*)") > 0 Then
                    RetVal = True
                End If
            End If

            Conn.Close()
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try

        Return RetVal
    End Function

    Public Sub GetFromDB(ByVal Username As String)

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

            Cmd.CommandText = "SELECT * FROM usuario WHERE Username=@user"
            Cmd.Prepare()

            Cmd.Parameters.AddWithValue("@user", Username)

            Reader = Cmd.ExecuteReader

            Do While Reader.Read
                ComboBox1.SelectedIndex = Reader.GetInt32("Privilegios")
                Try
                    ComboBox2.SelectedItem = Reader.GetString("Establecimiento")
                Catch ex As Exception

                End Try
            Loop

            Conn.Close()
        Catch e As Exception

        Finally
            Conn.Dispose()
        End Try
    End Sub

End Class