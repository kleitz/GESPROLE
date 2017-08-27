Public Class Config

    Public Const Vaquillona As Integer = 0
    Public Const Prenada As Integer = 1
    Public Const Anestro As Integer = 2
    Public Const PartoPostServ As Integer = 3
    Public Const Secar As Integer = 4
    Public Const Calostro As Integer = 5

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VaquillonaIn.Value = DaysToMonths(My.Settings.Vaquillona)
        PrenadaIn.Value = My.Settings.Prenada
        AnestroIn.Value = My.Settings.Anestro
        PartoPostServIn.Value = DaysToMonths(My.Settings.PartoPostServ)
        SecarIn.Value = DaysToMonths(My.Settings.Secar)
        CalostroIn.Value = My.Settings.Calostro
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If VaquillonaIn.Value = 0 Or PrenadaIn.Value = 0 Or AnestroIn.Value = 0 Or PartoPostServIn.Value = 0 Or SecarIn.Value = 0 Or CalostroIn.Value = 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Update config on runtime'
        My.Settings.Vaquillona = MonthsToDays(VaquillonaIn.Value)
        My.Settings.Prenada = PrenadaIn.Value
        My.Settings.Anestro = AnestroIn.Value
        My.Settings.PartoPostServ = MonthsToDays(PartoPostServIn.Value)
        My.Settings.Secar = MonthsToDays(SecarIn.Value)
        My.Settings.Calostro = CalostroIn.Value

        'Update on db'
        UpdateConfig()

        DialogResult = DialogResult.OK
    End Sub

    'Database sync'

    Public Shared Function CheckConfig() As Boolean
        Dim ToReturn = False
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

            Cmd.CommandText = "SELECT COUNT(*) FROM politica"

            Cmd.Prepare()

            Reader = Cmd.ExecuteReader

            If Reader.Read Then
                If Reader.GetInt32("COUNT(*)") > 0 Then
                    ToReturn = True
                End If
            End If

            Conn.Close()
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

        Return ToReturn
    End Function

    Public Shared Sub PrepareConfig()
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

            For Index As Integer = 0 To 5
                Cmd.Parameters.Clear()

                Cmd.CommandText = "INSERT INTO politica VALUES (@id, @val)"
                Cmd.Prepare()

                Cmd.Parameters.AddWithValue("@id", Index)
                Select Case Index
                    Case Vaquillona
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Vaquillona)
                    Case Prenada
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Prenada)
                    Case Anestro
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Anestro)
                    Case PartoPostServ
                        Cmd.Parameters.AddWithValue("@val", My.Settings.PartoPostServ)
                    Case Secar
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Secar)
                    Case Calostro
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Calostro)
                End Select

                Cmd.ExecuteNonQuery()
            Next

            Conn.Close()
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

    Public Shared Sub SyncConfig()
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

            Cmd.CommandText = "SELECT * FROM politica"

            Cmd.Prepare()

            Reader = Cmd.ExecuteReader

            Do While Reader.Read
                Select Case Reader.GetInt32("Clave")
                    Case Vaquillona
                        My.Settings.Vaquillona = Reader.GetInt32("Valor")
                    Case Prenada
                        My.Settings.Prenada = Reader.GetInt32("Valor")
                    Case Anestro
                        My.Settings.Anestro = Reader.GetInt32("Valor")
                    Case PartoPostServ
                        My.Settings.PartoPostServ = Reader.GetInt32("Valor")
                    Case Secar
                        My.Settings.Secar = Reader.GetInt32("Valor")
                    Case Calostro
                        My.Settings.Calostro = Reader.GetInt32("Valor")
                End Select
            Loop

            Conn.Close()
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

    'Database i/o'

    Private Sub UpdateConfig()
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

            For Index As Integer = 0 To 5
                Cmd.Parameters.Clear()

                Cmd.CommandText = "UPDATE politica SET Valor=@val WHERE Clave=@id"
                Cmd.Prepare()

                Cmd.Parameters.AddWithValue("@id", Index)
                Select Case Index
                    Case Vaquillona
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Vaquillona)
                    Case Prenada
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Prenada)
                    Case Anestro
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Anestro)
                    Case PartoPostServ
                        Cmd.Parameters.AddWithValue("@val", My.Settings.PartoPostServ)
                    Case Secar
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Secar)
                    Case Calostro
                        Cmd.Parameters.AddWithValue("@val", My.Settings.Calostro)
                End Select

                Cmd.ExecuteNonQuery()
            Next

            Conn.Close()
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

    'Time period functions - Not precise, just aproximates that suffice for this purpose'

    Private Function DaysToMonths(ByVal Days As Integer) As Integer
        Return Math.Round(Days / 30)
    End Function

    Private Function MonthsToDays(ByVal Months As Integer) As Integer
        Return Months * 30
    End Function


End Class