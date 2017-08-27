Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting

Public Class CowData
    Public Property Cow As Cow
    Private BackgroundWrkr As New BackgroundWorker

    Private Sub CowData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWrkr.WorkerSupportsCancellation = True

        AddHandler BackgroundWrkr.DoWork, AddressOf BackgroundWrkr_DoWork
        AddHandler BackgroundWrkr.RunWorkerCompleted, AddressOf BackgroundWrkr_RunWorkerCompleted

        BackgroundWrkr.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWrkr_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        If BackgroundWrkr.CancellationPending = True Then
            e.Cancel = True
        Else
            Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
            Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

            MakeEarring(Cow.RP)

            Try
                SetText(Cow.GetFromDB(Cow.Mum, Cow.COW, Conn).Name, Mama)
                SetText(Cow.GetCowsDaddy(Cow.RP), Papa)
            Catch ex As Exception
                ToggleVisibility(False, Label1)
                ToggleVisibility(False, Mama)
                ToggleVisibility(False, Label2)
                ToggleVisibility(False, Papa)

                SetText(My.Computer.ResourceMgr.GetString("0197"), GroupBox1)

                ToggleVisibility(True, BackgroundLabel)
                ToggleVisibility(True, Background)
                SetText(Cow.Background, Background)
            End Try

            SetText(Cow.Name, Nom)
            SetText(Cow.Birth.ToString(My.Computer.ResourceMgr.GetString("0245")), Nac)
            SetValue(Cow.Weight, Pes)
            SetText(Cow.Breed, Raz)

            SetText(Cow.GetCowsState(Cow.RP, Today, Conn), State)

            PopulateListOne(Cow.RP, Conn)
            PopulateListTwo(Cow.RP, Conn)
            PopulateChart()

            Conn.Dispose()
        End If
    End Sub

    Private Sub BackgroundWrkr_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            Loading_Label.Text = My.Computer.ResourceMgr.GetString("0248")
        ElseIf e.Error IsNot Nothing Then
            Loading_Label.Text = My.Computer.ResourceMgr.GetString("0239") & ": " & e.Error.Message
        Else
            Loading_Label.Text = My.Computer.ResourceMgr.GetString("0247")
        End If
    End Sub

    Private Sub CowData_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If BackgroundWrkr.IsBusy Then
            BackgroundWrkr.CancelAsync()
        End If
    End Sub

    ' Delegates '

    Private Delegate Sub MakeEarring_delegate(ByVal RP As Integer)

    Private Sub MakeEarring(ByVal RP As Integer)
        If PictureBox1.InvokeRequired Then
            Invoke(New MakeEarring_delegate(AddressOf MakeEarring), RP)
        Else
            Dim RPToShow As String = ""

            Try
                If Convert.ToString(RP).Length >= 4 Then
                    RPToShow = Convert.ToString(RP)
                Else
                    Dim GoodToGo As Boolean = True
                    While GoodToGo
                        RPToShow = RPToShow & "0"
                        If (RPToShow & Convert.ToString(RP)).Length = 4 Then
                            RPToShow = RPToShow & Convert.ToString(RP)
                            GoodToGo = False
                        End If
                    End While
                End If

                Dim Indent As Integer
                Dim DaFont As New Font("Poplar Std", 264)
                Select Case RPToShow.Length
                    Case 4
                        Indent = PictureBox1.Width * 10 / 8
                    Case 5
                        Indent = PictureBox1.Width - 20
                    Case 6
                        Indent = PictureBox1.Width - 80
                    Case 7
                        Indent = 0
                    Case Else
                        Indent = 0
                        Dim Aux As Integer = DaFont.Size
                        DaFont = New Font("Poplar Std", Aux - 25 * (RPToShow.Length - 7))
                End Select

                Dim gr As Graphics = Graphics.FromImage(PictureBox1.Image)

                gr.DrawString(RPToShow,
                        DaFont,
                         New SolidBrush(Color.Black),
                           PictureBox1.Location.X + Indent, PictureBox1.Location.Y + (PictureBox1.Height * 5))
                gr.Dispose()

                PictureBox1.Refresh()
            Catch ex As Exception
                Return
            End Try
        End If
    End Sub

    Private Delegate Sub ToggleVisibility_delegate(ByVal Visible As Boolean, ByRef Label As Control)

    Private Sub ToggleVisibility(ByVal Visible As Boolean, ByRef Label As Control)
        If Label.InvokeRequired Then
            Invoke(New ToggleVisibility_delegate(AddressOf ToggleVisibility), Visible, Label)
        Else
            Label.Visible = Visible
        End If
    End Sub

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

    Private Delegate Sub SetValue_delegate(ByVal Value As Integer, ByRef NumUpDown As Control)

    Private Sub SetValue(ByVal Value As Integer, ByRef NumUpDown As Control)
        If NumUpDown.InvokeRequired Then
            Invoke(New SetValue_delegate(AddressOf SetValue), Value, NumUpDown)
        Else
            If TypeOf NumUpDown Is NumericUpDown Then
                Dim DaRealThing As NumericUpDown = CType(NumUpDown, NumericUpDown)
                DaRealThing.Value = Value
            End If
        End If
    End Sub

    Private Delegate Sub PopulateListOne_delegate(ByVal RP As Integer, ByRef Conn As MySql.Data.MySqlClient.MySqlConnection)

    Private Sub PopulateListOne(ByVal RP As Integer, ByRef Conn As MySql.Data.MySqlClient.MySqlConnection)
        If ListView1.InvokeRequired Then
            Invoke(New PopulateListOne_delegate(AddressOf PopulateListOne), RP, Conn)
        Else
            For Each CurrentEvent As LifeEvent In LifeEvent.GetCowEvts(RP, Conn)
                ListView1.Items.Add(CurrentEvent.Time)

                Dim EvtDescription As String = ""

                Select Case CurrentEvent.Type
                    Case LifeEvent.ABORTO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0205") & " " & CurrentEvent.Data3
                    Case LifeEvent.ANALISIS
                        EvtDescription = My.Computer.ResourceMgr.GetString("0206") & " " & CurrentEvent.Data2 & " " & My.Computer.ResourceMgr.GetString("0207") & ": " & CurrentEvent.Data3
                    Case LifeEvent.ENFERMEDAD
                        EvtDescription = My.Computer.ResourceMgr.GetString("0208") & " " & CurrentEvent.Data1 & " " & My.Computer.ResourceMgr.GetString("0209") & " " & CurrentEvent.Data3 & ". " & My.Computer.ResourceMgr.GetString("0212") & " " & CurrentEvent.Data2 & " " & My.Computer.ResourceMgr.GetString("0213") & " " & CurrentEvent.Data4
                    Case LifeEvent.IDA_RECRIA
                        EvtDescription = My.Computer.ResourceMgr.GetString("0210") & " " & CurrentEvent.Data2 & " " & My.Computer.ResourceMgr.GetString("0211") & " " & Date.ParseExact(CurrentEvent.Data3, "yyyy-MM-dd", Nothing).ToString(My.Computer.ResourceMgr.GetString("0245"))
                    Case LifeEvent.MEDICACION
                        EvtDescription = My.Computer.ResourceMgr.GetString("0212") & " " & CurrentEvent.Data2 & " " & My.Computer.ResourceMgr.GetString("0213") & " " & CurrentEvent.Data3
                    Case LifeEvent.MUERTE
                        EvtDescription = My.Computer.ResourceMgr.GetString("0214") & " " & CurrentEvent.Data3
                    Case LifeEvent.PARTO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0215") & " "
                        If CurrentEvent.Data2.Equals("TRUE") Then
                            EvtDescription = EvtDescription & My.Computer.ResourceMgr.GetString("0243").ToUpper
                        Else
                            EvtDescription = EvtDescription & My.Computer.ResourceMgr.GetString("0244").ToUpper
                        End If
                        EvtDescription = EvtDescription & " " & CurrentEvent.Data3 & " " & My.Computer.ResourceMgr.GetString("0216") & " " & CurrentEvent.Data4
                    Case LifeEvent.RECHAZO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0217") & " " & CurrentEvent.Data3
                    Case LifeEvent.SECADO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0218") & " " & CurrentEvent.Data3
                    Case LifeEvent.SERVICIO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0219") & " "
                        If CurrentEvent.Data2 IsNot Nothing Then
                            EvtDescription = EvtDescription & " " & My.Computer.ResourceMgr.GetString("0220") & " " & CurrentEvent.Data2 & " - " & Cow.GetFromDB(CInt(CurrentEvent.Data2), Cow.BULL, Conn).Name
                        Else
                            EvtDescription = EvtDescription & " " & My.Computer.ResourceMgr.GetString("0221") & " " & CurrentEvent.Data3
                        End If
                    Case LifeEvent.TACTO
                        EvtDescription = My.Computer.ResourceMgr.GetString("0222") & " " & CurrentEvent.Data1
                    Case LifeEvent.VENTA
                        EvtDescription = My.Computer.ResourceMgr.GetString("0223") & " " & CurrentEvent.Data3
                End Select

                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(EvtDescription)
                ListView1.Items(ListView1.Items.Count - 1).Tag = CurrentEvent.Type
            Next
        End If
    End Sub

    Private Delegate Sub PopulateListTwo_delegate(ByVal RP As Integer, ByRef Conn As MySql.Data.MySqlClient.MySqlConnection)

    Private Sub PopulateListTwo(ByVal RP As Integer, ByRef Conn As MySql.Data.MySqlClient.MySqlConnection)
        If ListView2.InvokeRequired Then
            Invoke(New PopulateListTwo_delegate(AddressOf PopulateListTwo), RP, Conn)
        Else
            For Each CurrentControl As MilkControl In MilkControl.GetListForCow(RP, Conn)
                ListView2.Items.Add(CurrentControl.Time)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CType(CurrentControl.Milkings(1), MilkControl.Milking).Qty)
                If CurrentControl.Milkings.Count > 1 Then
                    ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CType(CurrentControl.Milkings(2), MilkControl.Milking).Qty)
                Else
                    ListView2.Items(ListView2.Items.Count - 1).SubItems.Add("-")
                End If
                If CurrentControl.Milkings.Count > 2 Then
                    ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CType(CurrentControl.Milkings(3), MilkControl.Milking).Qty)
                Else
                    ListView2.Items(ListView2.Items.Count - 1).SubItems.Add("-")
                End If
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.Proteins)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.SomCel)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.Fat)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.Lactose)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.Water)
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CurrentControl.Bacteria)
            Next
        End If
    End Sub

    Private Delegate Sub PopulateChart_delegate()

    Private Sub PopulateChart()
        If CtrlHistory.InvokeRequired Then
            Invoke(New PopulateChart_delegate(AddressOf PopulateChart))
        Else
            CtrlHistory.Series.Clear()

            Dim ProteinSeries As New Series
            ProteinSeries.Name = My.Computer.ResourceMgr.GetString("0184")
            ProteinSeries.ChartType = SeriesChartType.Column

            Dim SomCelSeries As New Series
            SomCelSeries.Name = My.Computer.ResourceMgr.GetString("0187")
            SomCelSeries.ChartType = SeriesChartType.Column

            Dim FatSeries As New Series
            FatSeries.Name = My.Computer.ResourceMgr.GetString("0185")
            FatSeries.ChartType = SeriesChartType.Column

            Dim LactoseSeries As New Series
            LactoseSeries.Name = My.Computer.ResourceMgr.GetString("0186")
            LactoseSeries.ChartType = SeriesChartType.Column

            Dim WaterSeries As New Series
            WaterSeries.Name = My.Computer.ResourceMgr.GetString("0204")
            WaterSeries.ChartType = SeriesChartType.Column

            Dim BacteriaSeries As New Series
            BacteriaSeries.Name = My.Computer.ResourceMgr.GetString("0189")
            BacteriaSeries.ChartType = SeriesChartType.Column

            For Index As Integer = 4 To 0 Step -1
                Try
                    ProteinSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(4).Text)
                    SomCelSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(5).Text)
                    FatSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(6).Text)
                    LactoseSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(7).Text)
                    WaterSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(8).Text)
                    BacteriaSeries.Points.AddXY(ListView2.Items(Index).Text, ListView2.Items(Index).SubItems(9).Text)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Next

            CtrlHistory.Series.Add(ProteinSeries)
            CtrlHistory.Series.Add(SomCelSeries)
            CtrlHistory.Series.Add(FatSeries)
            CtrlHistory.Series.Add(LactoseSeries)
            CtrlHistory.Series.Add(WaterSeries)
            CtrlHistory.Series.Add(BacteriaSeries)
        End If
    End Sub

    ' End delegates '

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Select Case e.KeyChar
            Case ControlChars.Back
                RemoveEvt()
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        If My.Settings.Privileges >= 1 Then
            Select Case e.Button
                Case MouseButtons.Right
                    If ListView1.FocusedItem.Bounds.Contains(e.Location) Then
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                        ContextMenuStrip1.Show(Cursor.Position)
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
                    End If
            End Select
        End If
    End Sub

    Private Sub RemoveEvt() Handles EliminarEventoToolStripMenuItem.Click
        If My.Settings.Privileges >= 1 And ListView1.FocusedItem IsNot Nothing Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0224") & " " & ListView1.FocusedItem.SubItems(1).Text & " " & My.Computer.ResourceMgr.GetString("0225") & " " & ListView1.FocusedItem.SubItems(0).Text & "?", My.Computer.ResourceMgr.GetString("0226"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Result = DialogResult.OK Then
                LifeEvent.DeleteFromDB(New LifeEvent(Cow.RP, ListView1.FocusedItem.Text, ListView1.FocusedItem.Tag, Nothing, Nothing, Nothing, Nothing))
                ListView1.Items.Remove(ListView1.FocusedItem)
            End If
        End If
    End Sub

    Private Sub Pes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Pes.KeyPress
        If Pes.Value = 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Select Case e.KeyChar
            Case ControlChars.NewLine
                Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0227") & " " & Cow.Name & " " & My.Computer.ResourceMgr.GetString("0228") & " " & Pes.Value & "Kg?", My.Computer.ResourceMgr.GetString("0230"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If Result = DialogResult.OK Then
                    Cow.UpdateWeight(Cow.RP, Pes.Value)
                End If
        End Select
    End Sub
End Class