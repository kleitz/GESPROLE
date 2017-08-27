Imports System.Windows.Forms.DataVisualization.Charting
Imports ComboDialog

Public Class Main
    Implements ProgressDialog.ProgressDialogInterface
    'Variables'
    Private Resz As New Resizer
    Private Stats As Stats
    Private Timer1 As Timer

    'Form events'

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Do While Establishment.GetEstabList.Count = 0
            Dim TmbAdd As New TamboData
            TmbAdd.Mode = TamboData.ADDITION
            If TmbAdd.ShowDialog(Me) = DialogResult.OK Then
                If Establishment.GetEstabList.Count = 0 Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0301"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Loop

        LoginInfo.Text = My.Computer.ResourceMgr.GetString("0067") & " " & My.Settings.LogName & " | Tambos by: " & Establishment.GetProducer

        For Each CurrentEstablishment As String In Establishment.GetEstabList
            Select_Tambo.Items.Add(CurrentEstablishment)
        Next

        If Notification.NewNotification() Then
            NotificationButton.Image = My.Resources.Resources.notiBlue
        End If

        'Prepare config'
        If Config.CheckConfig Then
            Config.SyncConfig()
        Else
            Config.PrepareConfig()
        End If

        Timer1 = New Timer
        Timer1.Interval = 300000
        AddHandler(Timer1.Tick), AddressOf Timer1_Tick
        Timer1.Start()

        Select Case My.Settings.Privileges
            Case 0
                Select_Tambo.SelectedItem = My.Settings.Establishment
            Case 1
                'Menu setup'
                ConfiguraciónToolStripMenuItem.Visible = True

                'ToolStrip Setup'
                ConfigButton.Visible = True

                Select_Tambo.SelectedItem = My.Settings.Establishment
            Case 2
                Select_Tambo.Enabled = True
                If Select_Tambo.Items.Count > 0 Then
                    Select_Tambo.SelectedIndex = 0
                End If

                'Menu setup'
                UsuariosToolStripMenuItem.Visible = True
                ConfiguraciónToolStripMenuItem.Visible = True
                RegistrarTamboToolStripMenuItem.Visible = True
                VerInformaciónDeEstablecimientoToolStripMenuItem.Text = My.Computer.ResourceMgr.GetString("0018")

                'ToolStrip Setup'
                ViewEstablishmentDataButton.ToolTipText = My.Computer.ResourceMgr.GetString("0018")

                NewEstablishmentButton.Visible = True
                CreateUserButton.Visible = True
                ToolStripSeparator5.Visible = True
                ConfigButton.Visible = True
        End Select

        Resz.FindAllControls(Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        If Notification.NewNotification() Then
            NotificationButton.Image = My.Resources.Resources.notiBlue
        End If
    End Sub

    Private Sub Select_Tambo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Select_Tambo.SelectedIndexChanged
        If Not Select_Tambo.SelectedItem.Equals(My.Computer.ResourceMgr.GetString("0066")) Then
            My.Settings.Establishment = Select_Tambo.SelectedItem
        Else
            My.Settings.Establishment = ""
        End If

        Dim ProgressDlg As New ProgressDialog
        ProgressDlg.ProgressDlgInterface = Me
        ProgressDlg.ShowDialog(Me)
    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Resz.ResizeAllControls(Me)
    End Sub

    Private Sub LoadStats()
        If Stats IsNot Nothing Then
            Stats.UpdateStats()
        Else
            Stats = New Stats
        End If

        SetText(Stats.Milking, EnOrdene)
        SetText(Stats.Dry, Secas)
        SetText(Stats.Vaquillonas, Vaquillonas)
        SetText(Stats.CowCount, Vacas)
        SetText(Stats.Production, Prod_Diaria)
        SetText(Stats.ProductionPerArea, Prod_Ha)
        SetText(Stats.Fat, Prom_Grasa)
        SetText(Stats.CelSom, Prom_Cel_Som)
        SetText(Stats.SMB, Prom_SMB)
        SetText(Stats.Bacteria, Prom_Rec_Bac)
        SetText(Stats.Lactose, Prom_Lact)
        SetText(Stats.Protein, Prom_Prot)
        SetText(Stats.AgeAvg, Prom_Edad)
        SetText(Stats.Babies, Recria)
        SetText(Stats.Preggos, Prenadas)
        SetText(Stats.Empties, Vacias)
        SetText(Stats.PreggoRate, Tasa_Prenadas)
        SetText(Stats.BirthRate, Tasa_Paricion)
        SetText(Stats.RepoRate, Tasa_Repo)

        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        'Populate charts'
        Dim Data As New Collection

        For Index As Integer = (Date.Today.Year - 6) To Date.Today.Year
            Dim Production As Integer = MilkControl.GetProdForYear(Index, Conn)
            If Production <> 0 Then
                Dim Number As New ChartData
                Number.Id = Index
                Number.Value = Production
                Data.Add(Number)
            End If
        Next

        ProdCurveChartPopulate(Data)

        Data.Clear()

        Dim Cnt As Integer = 0

        For Each Lote As Lot In Lot.GetFromDB(My.Settings.Establishment, Conn)
            Dim MakeSuperAdminAgain As Boolean = False
            If My.Settings.Establishment.Equals("") Then
                My.Settings.Establishment = Lot.GetEstablishment(Lote.Name, Conn)
                MakeSuperAdminAgain = True
            End If
            Dim Qty As Integer = Cow.GetList(Cow.COW, List.LOT, Lote, Today, Conn).Count
            If MakeSuperAdminAgain Then
                My.Settings.Establishment = ""
            End If
            Cnt += Qty
            If Qty <> 0 Then
                Dim Number As New ChartData
                Number.Name = Lote.Name
                Number.Value = Qty
                Data.Add(Number)
            End If
        Next

        Dim NoLot As New ChartData
        NoLot.Name = My.Computer.ResourceMgr.GetString("0090")
        NoLot.Value = Cow.GetFromDB(Cow.COW, Today, Conn).Count - Cnt
        If NoLot.Value <> 0 Then
            Data.Add(NoLot)
        End If

        RodeoDivChartPopulate(Data)
    End Sub

    'Delegates'

    Private Delegate Sub SetText_delegate(ByVal Text As String, ByRef Label As Control)

    Private Sub SetText(ByVal Text As String, ByRef Label As Control)
        If Label.InvokeRequired Then
            Invoke(New SetText_delegate(AddressOf SetText), Text, Label)
        Else
            If TypeOf Label Is TextBox Or TypeOf Label Is Label Or TypeOf Label Is GroupBox Then
                Label.Text = Text
            End If
        End If
    End Sub

    Private Delegate Sub ProdCurveChartPopulate_delegate(ByVal Data As Collection)

    Private Sub ProdCurveChartPopulate(ByVal Data As Collection)
        If Prod_Curve.InvokeRequired Then
            Invoke(New ProdCurveChartPopulate_delegate(AddressOf ProdCurveChartPopulate), Data)
        Else
            Prod_Curve.Series.Clear()
            Dim daSerie As New Series
            daSerie.Name = My.Computer.ResourceMgr.GetString("0091")
            daSerie.ChartType = SeriesChartType.Line

            For Each Thing As ChartData In Data
                daSerie.Points.AddXY(Thing.Id, Thing.Value)
            Next

            Prod_Curve.Series.Add(daSerie)
        End If
    End Sub

    Private Delegate Sub RodeoDivChartPopulate_delegate(ByVal Data As Collection)

    Private Sub RodeoDivChartPopulate(ByVal Data As Collection)
        If Distro.InvokeRequired Then
            Invoke(New ProdCurveChartPopulate_delegate(AddressOf RodeoDivChartPopulate), Data)
        Else
            Distro.Series.Clear()
            Dim daSerie As New Series
            daSerie.Name = My.Computer.ResourceMgr.GetString("0092")

            daSerie.ChartType = SeriesChartType.Pie

            For Each Thing As ChartData In Data
                daSerie.Points.AddXY(Thing.Name, Thing.Value)
            Next

            Distro.Series.Add(daSerie)
        End If
    End Sub

    'Tool Strip Menu Events'

    Private Sub RegistrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarToolStripMenuItem.Click, RegisterCowButton.Click
        Dim CowAddWin As New CowAdd
        CowAddWin.Mode = Cow.COW
        CowAddWin.ShowDialog(Me)
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem.Click, SearchCowButton.Click
        Dim CowSearchWin As New CowSearch
        CowSearchWin.Mode = Cow.COW
        CowSearchWin.ShowDialog(Me)
    End Sub

    Private Sub AbortoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbortoToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.ABORTO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub AnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnálisisToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.ANALISIS
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub EnfermedadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnfermedadToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.ENFERMEDAD
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub MedicaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicaciónToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.MEDICACION
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub MuerteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuerteToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.MUERTE
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub PartoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartoToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.PARTO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub RechazoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechazoToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.RECHAZO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub SecadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecadoToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.SECADO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub ServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServicioToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.SERVICIO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub TactoRectalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TactoRectalToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.TACTO
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub VentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaToolStripMenuItem.Click
        Dim EvtWin As New EvtAdd
        EvtWin.Mode = LifeEvent.VENTA
        EvtWin.ShowDialog(Me)
    End Sub

    Private Sub LoteoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoteoToolStripMenuItem.Click, LotButton.Click
        Dim LoteoWin As New Loteo
        LoteoWin.ShowDialog(Me)
    End Sub

    Private Sub SemenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SemenToolStripMenuItem.Click
        Dim SemenWin As New Semen
        SemenWin.ShowDialog(Me)
    End Sub

    Private Sub BuscarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem1.Click
        Dim BullSearchWin As New CowSearch
        BullSearchWin.Mode = Cow.BULL
        BullSearchWin.ShowDialog(Me)
    End Sub

    Private Sub RegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem.Click
        Dim BullAddWin As New CowAdd
        BullAddWin.Mode = Cow.BULL
        BullAddWin.ShowDialog(Me)
    End Sub

    Private Sub GenerarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarToolStripMenuItem.Click, MilkControlButton.Click
        Dim ControlWin As New CtrlAdd
        ControlWin.ShowDialog(Me)
    End Sub

    Private Sub VerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerToolStripMenuItem.Click
        ViewList(List.CONTROL)
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click, LogOutButton.Click
        Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0094"), My.Computer.ResourceMgr.GetString("0093"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Select Case Result
            Case DialogResult.OK
                Dim Logger As New Login
                Logger.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub GESPROLEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GESPROLEToolStripMenuItem.Click, InfoButton.Click
        Dim AcercaDe As New About
        AcercaDe.ShowDialog(Me)
    End Sub

    Private Sub RegistrarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem1.Click, CreateUserButton.Click
        If My.Settings.Privileges < 2 Then
            Dim UserAdd As New Users
            'Obtener datos de la base y mostrarlos, o sea, mostrar el nombre'
            UserAdd.Text = My.Computer.ResourceMgr.GetString("0096")
            UserAdd.UserNameTextBox.Text = My.Settings.LogName
            UserAdd.UserNameTextBox.Enabled = False
            UserAdd.Register.Text = My.Computer.ResourceMgr.GetString("0056")
            UserAdd.ShowDialog(Me)
        Else
            Dim UserAdd As New Users
            UserAdd.Text = My.Computer.ResourceMgr.GetString("0063")
            UserAdd.ShowDialog(Me)
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Dim ToEdit As String = InputBox(My.Computer.ResourceMgr.GetString("0095"))
        If ToEdit <> "" And Users.ExistsUser(ToEdit) Then
            Dim UserAdd As New Users
            'Obtener datos de la base y mostrarlos, o sea, mostrar el nombre'
            UserAdd.Text = My.Computer.ResourceMgr.GetString("0096")
            UserAdd.UserNameTextBox.Text = ToEdit
            UserAdd.UserNameTextBox.Enabled = False
            UserAdd.Register.Text = My.Computer.ResourceMgr.GetString("0056")
            UserAdd.ShowDialog(Me)
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0097"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim UserName As String = InputBox(My.Computer.ResourceMgr.GetString("0098"))
        'MsgBox("Adquiere la versión premium por solo $10000 para poder eliminar... Sin rebajas")
        If Users.ExistsUser(UserName) Then
            Users.DeleteFromDB(UserName)
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0097"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click, ConfigButton.Click
        Dim ConfigWin As New Config
        ConfigWin.ShowDialog(Me)
    End Sub

    Private Sub VacasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VacasToolStripMenuItem.Click
        ViewList(List.VACAS)
    End Sub

    Private Sub VacasLactandoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VacasLactandoToolStripMenuItem.Click
        ViewList(List.LACTANDO)
    End Sub

    Private Sub VacasSecasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VacasSecasToolStripMenuItem.Click
        ViewList(List.SECAS)
    End Sub

    Private Sub VaquillonasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VaquillonasToolStripMenuItem.Click
        ViewList(List.VAQUILLONAS)
    End Sub

    Private Sub ASecarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ASecarToolStripMenuItem.Click
        ViewList(List.A_SECAR)
    End Sub

    Private Sub AParirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AParirToolStripMenuItem.Click
        ViewList(List.A_PARIR)
    End Sub

    Private Sub ATactarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ATactarToolStripMenuItem.Click
        ViewList(List.A_TACTAR)
    End Sub

    Private Sub IdaACampoDeRecríaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdaACampoDeRecríaToolStripMenuItem.Click
        Dim RecriaWin As New Recria
        RecriaWin.ShowDialog(Me)
    End Sub

    Private Sub EventoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EventoToolStripMenuItem1.Click 'Bull event'
        Dim BullEvtWin As New BullEvt
        BullEvtWin.ShowDialog(Me)
    End Sub

    Private Sub RegistrarTamboToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTamboToolStripMenuItem.Click, NewEstablishmentButton.Click
        Dim TamboAdd As New TamboData
        TamboAdd.Mode = TamboData.ADDITION
        If TamboAdd.ShowDialog(Me) = DialogResult.OK Then
            Select_Tambo.Items.Clear()
            For Each CurrentEstablishment As String In Establishment.GetEstabList()
                Select_Tambo.Items.Add(CurrentEstablishment)
            Next
        End If
    End Sub

    Private Sub VerInformaciónDeEstablecimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerInformaciónDeEstablecimientoToolStripMenuItem.Click, ViewEstablishmentDataButton.Click
        If Select_Tambo.Items.Count > 0 Then
            Dim TamboAdd As New TamboData
            TamboAdd.Mode = TamboData.REVISION
            TamboAdd.ShowDialog(Me)
        End If
    End Sub

    Private Sub NotificationButton_Click(sender As Object, e As EventArgs) Handles NotificationButton.Click
        ViewList(List.NOTIFICATIONS)
    End Sub

    Private Sub ViewList(ShowMe As Integer)
        Dim TheList As New List
        TheList.ShowMe = ShowMe
        TheList.ShowDialog(Me)

        If ShowMe = List.NOTIFICATIONS Then
            If Notification.NewNotification() Then
                NotificationButton.Image = My.Resources.Resources.notiBlue
            Else
                NotificationButton.Image = My.Resources.Resources.notiBlack
            End If
        End If
    End Sub

    Public Sub ActionToPerform() Implements ProgressDialog.ProgressDialogInterface.ActionToPerform
        LoadStats()
    End Sub

    Private Class ChartData
        Property Id As Integer
        Property Name As String
        Property Value As Integer
    End Class
End Class
