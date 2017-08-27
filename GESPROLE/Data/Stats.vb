Public Class Stats
    Property Milking As Integer
    Property Dry As Integer
    Property Vaquillonas As Integer
    Property CowCount As Integer
    Property Production As Integer
    Property ProductionPerArea As Double
    Property Fat As Integer
    Property CelSom As Integer
    Property SMB As Integer
    Property Bacteria As Integer
    Property Lactose As Integer
    Property Protein As Integer
    Property AgeAvg As Integer
    Property Babies As Integer
    Property Preggos As Integer
    Property Empties As Integer
    Property PreggoRate As Double
    Property BirthRate As Double
    Property RepoRate As Double

    Sub New()
        UpdateStats()
    End Sub

    Public Sub UpdateStats()
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        Milking = 0
        Dry = 0
        Vaquillonas = 0
        CowCount = 0
        Production = 0
        ProductionPerArea = 0
        Fat = 0
        CelSom = 0
        SMB = 0
        Bacteria = 0
        Lactose = 0
        Protein = 0
        AgeAvg = 0
        Babies = 0
        Preggos = 0
        Empties = 0
        PreggoRate = 0
        BirthRate = 0
        RepoRate = 0

        Try
            Dim AllCows As Collection = Cow.GetFromDB(Cow.COW, Today, Conn)

            For Each Cow As Cow In AllCows
                Dim State As String = Cow.GetCowsState(Cow.RP, Today, Conn)

                If State.Contains("LACTANDO") Then
                    Milking += 1
                ElseIf State.Contains("SECA") And LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Today, Conn) IsNot Nothing Then
                    Dry += 1
                End If

                If State.Contains("PREÑADA") Then
                    Preggos += 1
                ElseIf State.Contains("VACÍA") And LifeEvent.GetLastEvtOfType(Cow.RP, LifeEvent.PARTO, Today, Conn) IsNot Nothing Then
                    Empties += 1
                End If

                If State.Contains("TERNERO") Then
                    Babies += 1
                End If
            Next

            CowCount = Cow.GetList(Cow.COW, List.VACAS, Nothing, Today, Conn).Count
            Vaquillonas = AllCows.Count - CowCount - Babies

            If CowCount <> 0 Then
                PreggoRate = Preggos / CowCount
            End If

            Production = MilkControl.GetProdAvg(Conn)
            Dim EstabSize As Integer = Establishment.GetSize(Conn)
            If EstabSize <> 0 Then
                ProductionPerArea = Production / EstabSize
            End If

            Dim Avgs As Collection = MilkControl.GetAvgs(Conn)
            If Avgs.Count > 0 Then
                Fat = Avgs(1)
                CelSom = Avgs(6)
                SMB = Avgs(3)
                Bacteria = Avgs(4)
                Lactose = Avgs(2)
                Protein = Avgs(5)
            End If

            AgeAvg = Cow.GetAgeAvg(Conn)

            If LifeEvent.GetEvtCount(LifeEvent.PARTO, Conn) <> 0 Then
                RepoRate = (LifeEvent.GetEvtCount(LifeEvent.MUERTE, Conn) + LifeEvent.GetEvtCount(LifeEvent.VENTA, Conn) + LifeEvent.GetEvtCount(LifeEvent.RECHAZO, Conn)) / LifeEvent.GetEvtCount(LifeEvent.PARTO, Conn)
            End If
            If LifeEvent.GetEvtCount(LifeEvent.SERVICIO, Conn) <> 0 Then
                BirthRate = LifeEvent.GetEvtCount(LifeEvent.PARTO, Conn) / LifeEvent.GetEvtCount(LifeEvent.SERVICIO, Conn)
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.WriteLine(ex.Message)
        Finally
            Conn.Dispose()
        End Try

    End Sub
End Class
