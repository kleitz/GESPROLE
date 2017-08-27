Public Class EvtAdd
    Property Mode As Integer
    Property RPs As Collection 'Set this from outside to define what cows this is working with'

    'Form events'

    Private Sub EvtAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If RPs IsNot Nothing Then
            RPLabel.Visible = False
            RPIn.Visible = False
            CowSearch.Visible = False
        End If

        Select Case Mode
            Case LifeEvent.ABORTO
                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label3.Text = My.Computer.ResourceMgr.GetString("0126")
                Label3.Tag = "CAUSA_ABORTO"

            Case LifeEvent.ANALISIS
                Label2.Visible = True
                ComboBox2.Visible = True
                Button2.Visible = True

                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label2.Text = My.Computer.ResourceMgr.GetString("0127")
                Label2.Tag = "TIPO_ANALISIS"
                Label3.Text = My.Computer.ResourceMgr.GetString("0128")
                Label3.Tag = "RESULTADO_ANALISIS"

            Case LifeEvent.ENFERMEDAD
                Label1.Visible = True
                ComboBox1.Visible = True
                Button1.Visible = True

                Label2.Visible = True
                ComboBox2.Visible = True
                Button2.Visible = True

                Label3.Visible = True
                ComboBox3.Visible = True

                Label4.Visible = True
                ComboBox4.Visible = True

                Label1.Text = My.Computer.ResourceMgr.GetString("0127")
                Label1.Tag = "ENFERMEDAD"
                Label2.Text = My.Computer.ResourceMgr.GetString("0131")
                Label2.Tag = "MEDICACION"

                Label3.Text = My.Computer.ResourceMgr.GetString("0129")
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0281"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0280"))
                ComboBox3.SelectedIndex = 0

                Label4.Text = My.Computer.ResourceMgr.GetString("0130")
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0272"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0273"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0274"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0275"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0276"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0277"))
                ComboBox4.Items.Add(My.Computer.ResourceMgr.GetString("0278"))
                ComboBox4.SelectedIndex = 0

                Noti.Visible = True

            Case LifeEvent.MEDICACION
                Label2.Visible = True
                ComboBox2.Visible = True
                Button2.Visible = True

                Label3.Visible = True
                ComboBox3.Visible = True

                Label2.Text = My.Computer.ResourceMgr.GetString("0131")
                Label2.Tag = "MEDICACION"

                Label3.Text = My.Computer.ResourceMgr.GetString("0130")
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0272"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0273"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0274"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0275"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0276"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0277"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0278"))
                ComboBox3.SelectedIndex = 0

            Case LifeEvent.MUERTE
                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label3.Text = My.Computer.ResourceMgr.GetString("0126")
                Label3.Tag = "CAUSA_MUERTE"

            Case LifeEvent.PARTO
                Label2.Visible = True
                ComboBox2.Visible = True

                Label3.Visible = True
                ComboBox3.Visible = True

                Label4.Visible = True
                ComboBox4.Visible = True
                Button4.Visible = True

                Label2.Text = My.Computer.ResourceMgr.GetString("0132")
                ComboBox2.Items.Add(My.Computer.ResourceMgr.GetString("0244").ToUpper)
                ComboBox2.Items.Add(My.Computer.ResourceMgr.GetString("0243").ToUpper)
                ComboBox2.SelectedIndex = 1

                Label3.Text = My.Computer.ResourceMgr.GetString("0133")
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0282"))
                ComboBox3.Items.Add(My.Computer.ResourceMgr.GetString("0249"))
                ComboBox3.SelectedIndex = 0

                Label4.Text = My.Computer.ResourceMgr.GetString("0127")
                Label4.Tag = "TIPO_PARTO"

            Case LifeEvent.RECHAZO
                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label3.Text = My.Computer.ResourceMgr.GetString("0126")
                Label3.Tag = "CAUSA_RECHAZO"

            Case LifeEvent.SECADO
                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label3.Text = My.Computer.ResourceMgr.GetString("0131")
                Label3.Tag = "MEDICACION"

            Case LifeEvent.SERVICIO
                Label2.Visible = True
                BullIDIn.Visible = True
                SearchBull.Visible = True
                Label3.Visible = True
                ComboBox3.Visible = True

                Label2.Text = My.Computer.ResourceMgr.GetString("0134")
                Label3.Text = My.Computer.ResourceMgr.GetString("0135")

                Dim LowerPrivileges As String = ""

                If Not My.Settings.Establishment.Equals("") Then
                    LowerPrivileges = My.Settings.Establishment
                    My.Settings.Establishment = ""
                End If

                For Each SemenSample As Cow.Semen In Cow.Semen.GetList()
                    ComboBox3.Items.Add(SemenSample.ID & " - " & Cow.GetFromDB(SemenSample.RP, Cow.BULL).Name & " - " & SemenSample.Time.ToString(My.Computer.ResourceMgr.GetString("0245")))
                Next

                If Not LowerPrivileges.Equals("") Then
                    My.Settings.Establishment = LowerPrivileges
                End If

                If ComboBox3.Items.Count > 0 Then
                    ComboBox3.SelectedIndex = 0
                End If

            Case LifeEvent.TACTO
                Label1.Visible = True
                ComboBox1.Visible = True
                Button1.Visible = True

                Label2.Visible = True
                ComboBox2.Visible = True
                Button2.Visible = True

                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label4.Visible = True
                ComboBox4.Visible = True
                Button4.Visible = True

                Label1.Text = My.Computer.ResourceMgr.GetString("0136")
                Label1.Tag = "DIAGNOSTICO_UTERO"
                Label2.Text = My.Computer.ResourceMgr.GetString("0137")
                Label2.Tag = "ENFERMEDAD_UTERO"
                Label3.Text = My.Computer.ResourceMgr.GetString("0138")
                Label3.Tag = "ENFERMEDAD_OVARIO"
                Label4.Text = My.Computer.ResourceMgr.GetString("0139")
                Label4.Tag = "MEDICACION_GENITAL"

            Case LifeEvent.VENTA
                Label3.Visible = True
                ComboBox3.Visible = True
                Button3.Visible = True

                Label3.Text = My.Computer.ResourceMgr.GetString("0140")
                Label3.Tag = "ESPECIFICACION_VENTA"

        End Select

        If ComboBox1.Visible And ComboBox1.Items.Count = 0 Then
            UpdateCombo(ComboBox1, Validation.GetFromDB(Label1.Tag))
        End If
        If ComboBox2.Visible And ComboBox2.Items.Count = 0 Then
            UpdateCombo(ComboBox2, Validation.GetFromDB(Label2.Tag))
        End If
        If ComboBox3.Visible And ComboBox3.Items.Count = 0 Then
            UpdateCombo(ComboBox3, Validation.GetFromDB(Label3.Tag))
        End If
        If ComboBox4.Visible And ComboBox4.Items.Count = 0 Then
            UpdateCombo(ComboBox4, Validation.GetFromDB(Label4.Tag))
        End If

        If My.Settings.Privileges < 1 Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
        End If
    End Sub

    'Control events'

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0108"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Select Case Result
            Case DialogResult.OK
                DialogResult = DialogResult.Cancel
            Case DialogResult.Cancel
                DialogResult = DialogResult.None
        End Select
    End Sub

    Private Sub CowSearch_Click(sender As Object, e As EventArgs) Handles CowSearch.Click
        Dim CowSearchWin As New CowSearch
        CowSearchWin.Mode = Cow.COW
        CowSearchWin.ModeTwo = GESPROLE.CowSearch.SELECTION
        CowSearchWin.WhenDoISearch = DateTimePicker1.Value
        If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
            RPIn.Value = CowSearchWin.ReturnValue
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Modifier As New List
        Modifier.ShowMe = List.MODIFY_DATA
        Modifier.Value = Label1.Tag
        If Modifier.ShowDialog(Me) = DialogResult.OK Then
            UpdateCombo(ComboBox1, Validation.GetFromDB(Label1.Tag))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Modifier As New List
        Modifier.ShowMe = List.MODIFY_DATA
        Modifier.Value = Label2.Tag
        If Modifier.ShowDialog(Me) = DialogResult.OK Then
            UpdateCombo(ComboBox2, Validation.GetFromDB(Label2.Tag))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Modifier As New List
        Modifier.ShowMe = List.MODIFY_DATA
        Modifier.Value = Label3.Tag
        If Modifier.ShowDialog(Me) = DialogResult.OK Then
            UpdateCombo(ComboBox3, Validation.GetFromDB(Label3.Tag))
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Modifier As New List
        Modifier.ShowMe = List.MODIFY_DATA
        Modifier.Value = Label4.Tag
        If Modifier.ShowDialog(Me) = DialogResult.OK Then
            UpdateCombo(ComboBox4, Validation.GetFromDB(Label4.Tag))
        End If
    End Sub

    'Update combo'

    Private Sub UpdateCombo(ByVal Combo As ComboBox, ByVal Items As Collection)
        Combo.Items.Clear()

        For Each Item As Validation In Items
            Combo.Items.Add(Item.Value)
        Next

        If Combo.Items.Count > 0 Then
            Combo.SelectedIndex = 0
        End If
    End Sub

    Private Sub SearchBull_Click(sender As Object, e As EventArgs) Handles SearchBull.Click
        If RPIn.Value <> 0 Then
            Dim MakeSuperAdminAgain As Boolean = False
            Dim CowSearchWin As New CowSearch
            CowSearchWin.Mode = Cow.BULL
            If My.Settings.Establishment.Equals("") Then
                My.Settings.Establishment = Cow.GetEstablishment(RPIn.Value)
                MakeSuperAdminAgain = True
            End If
            CowSearchWin.ModeTwo = GESPROLE.CowSearch.SELECTION
            CowSearchWin.WhenDoISearch = DateTimePicker1.Value
            If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
                BullIDIn.Value = CowSearchWin.ReturnValue
            End If
            If MakeSuperAdminAgain Then
                My.Settings.Establishment = ""
            End If
        ElseIf RPs IsNot Nothing Then
            Dim MakeSuperAdminAgain As Boolean = False
            Dim CowSearchWin As New CowSearch
            CowSearchWin.Mode = Cow.BULL
            If My.Settings.Establishment.Equals("") Then
                My.Settings.Establishment = Cow.GetEstablishment(RPs(1))
                MakeSuperAdminAgain = True
            End If
            CowSearchWin.ModeTwo = GESPROLE.CowSearch.SELECTION
            CowSearchWin.WhenDoISearch = DateTimePicker1.Value
            If CowSearchWin.ShowDialog(Me) = DialogResult.OK Then
                BullIDIn.Value = CowSearchWin.ReturnValue
            End If
            If MakeSuperAdminAgain Then
                My.Settings.Establishment = ""
            End If
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0279"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Accept_Button_Click(sender As Object, e As EventArgs) Handles Accept_Button.Click
        If RPIn.Value > 0 Or RPs IsNot Nothing Then
            Dim Value1 As String
            Dim Value2 As String
            Dim Value3 As String
            Dim Value4 As String

            If ComboBox1.Visible Then
                Try
                    Value1 = ComboBox1.SelectedItem.ToString()
                Catch ex As Exception

                End Try
            End If

            If ComboBox2.Visible Then
                Select Case Mode
                    Case LifeEvent.PARTO
                        If ComboBox2.SelectedItem.ToString.Equals(My.Computer.ResourceMgr.GetString("0243").ToUpper) Then
                            Value2 = "TRUE"
                        Else
                            Value2 = "FALSE"
                        End If
                    Case Else
                        Try
                            Value2 = ComboBox2.SelectedItem.ToString()
                        Catch ex As Exception

                        End Try
                End Select

            ElseIf Mode = LifeEvent.SERVICIO Then
                If BullIDIn.Value > 0 Then
                    If DateDiff(DateInterval.Day, Cow.GetFromDB(BullIDIn.Value, Cow.BULL).Birth, DateTimePicker1.Value) > 0 Then
                        Value2 = Convert.ToString(BullIDIn.Value)
                    Else
                        MessageBox.Show(My.Computer.ResourceMgr.GetString("0145"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                End If
            End If

            If ComboBox3.Visible Then
                Try
                    If Mode = LifeEvent.SERVICIO Then
                        If BullIDIn.Value = 0 Then
                            If DateDiff(DateInterval.Day, Date.ParseExact(ComboBox3.SelectedItem.ToString.Substring(ComboBox3.SelectedItem.ToString.LastIndexOf("-") + 1).Trim, "dd/MM/yyyy", Nothing), DateTimePicker1.Value) >= 0 Then
                                Value3 = ComboBox3.SelectedItem.ToString.Substring(0, ComboBox3.SelectedItem.ToString.IndexOf("-")).Trim
                            Else
                                MessageBox.Show(My.Computer.ResourceMgr.GetString("0146"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        End If
                    Else
                        Value3 = ComboBox3.SelectedItem.ToString()
                    End If
                Catch ex As Exception

                End Try
            End If

            If ComboBox4.Visible Then
                Try
                    Value4 = ComboBox4.SelectedItem.ToString()
                Catch ex As Exception

                End Try
            End If

            If Mode = LifeEvent.PARTO Then

                Dim RP As Integer 'Instantiate the RP of the cow to register the birth to'

                If RPIn.Value <> 0 Then 'Check where the RP is and put it in the right variable'
                    RP = RPIn.Value
                Else
                    RP = RPs(1)
                End If

                If ValidateEvent(RP) Then 'Validate event'
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                    If Value3.Equals(My.Computer.ResourceMgr.GetString("0282")) Then 'If the calf was born alive'
                        Dim CowAddWin As New CowAdd 'Instantiate window to register the calf'

                        'Determine sex of calf'
                        If Value2.Equals("TRUE") Then
                            CowAddWin.Mode = Cow.COW
                        Else
                            CowAddWin.Mode = Cow.BULL
                        End If

                        'Disable modification of unnecessary values'
                        CowAddWin.Background.Enabled = False
                        CowAddWin.Birth.Value = DateTimePicker1.Value
                        CowAddWin.Birth.Enabled = False

                        'Determine breed of calf'
                        Dim LastServ As LifeEvent = LifeEvent.GetLastEvtOfType(RPIn.Value, LifeEvent.SERVICIO, DateTimePicker1.Value)
                        Dim ThisCow As Cow = Cow.GetFromDB(RPIn.Value, Cow.COW)
                        If LastServ.Data2 IsNot Nothing Then
                            If ThisCow.Breed.Equals(Cow.GetFromDB(CInt(LastServ.Data2), Cow.BULL).Breed) Then
                                CowAddWin.Breed.SelectedItem = ThisCow.Breed
                            Else
                                CowAddWin.Breed.SelectedItem = "CRUZA"
                            End If
                        Else
                            If ThisCow.Breed.Equals(Cow.GetFromDB(Cow.Semen.GetFromDB(CInt(LastServ.Data3)).RP, Cow.BULL).Breed) Then
                                CowAddWin.Breed.SelectedItem = ThisCow.Breed
                            Else
                                CowAddWin.Breed.SelectedItem = "CRUZA"
                            End If
                        End If
                        CowAddWin.Breed.Enabled = False

                        'Determine the establishment'
                        Dim MakeSuperAdminAgain = False
                        If My.Settings.Establishment.Equals("") Then
                            My.Settings.Establishment = Cow.GetEstablishment(ThisCow.RP)
                            MakeSuperAdminAgain = True
                        End If

                        CowAddWin.Mom = RPIn.Value

                        If CowAddWin.ShowDialog(Me) = DialogResult.OK Then
                            LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, Mode, Value1, Value2, Value3, Value4)) 'Insert the event once the calf is on the db'
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                            If MakeSuperAdminAgain Then
                                My.Settings.Establishment = ""
                            End If
                            DialogResult = DialogResult.OK
                        End If
                    Else 'If the calf was born dead'
                        LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, Mode, Value1, Value2, Value3, Value4))
                        DialogResult = DialogResult.OK
                    End If
                End If

            ElseIf Mode = LifeEvent.SERVICIO And RPs IsNot Nothing And BullIDIn.Value = 0 Then

                If ComboBox3.Items.Count > RPs.Count Then
                    Dim SemenSample As Integer = ComboBox3.SelectedIndex
                    For Each RP As Integer In RPs
                        If ValidateEvent(RP) Then
                            LifeEvent.InsertIntoDB(New LifeEvent(RP, DateTimePicker1.Value, Mode, Value1, Value2, Value3, Value4))
                            Value3 = ComboBox3.Items(SemenSample).ToString().Substring(0, ComboBox3.Items(SemenSample).ToString().IndexOf("-")).Trim()
                        End If
                    Next
                    DialogResult = DialogResult.OK
                Else
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0148"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                If RPs IsNot Nothing Then 'In this case there might be an event insertion for more than one cow'
                    For Each RP As Integer In RPs
                        If ValidateEvent(RP) Then
                            LifeEvent.InsertIntoDB(New LifeEvent(RP, DateTimePicker1.Value, Mode, Value1, Value2, Value3, Value4))
                        End If
                    Next
                    DialogResult = DialogResult.OK
                Else 'If it is not the case'
                    If ValidateEvent(RPIn.Value) Then
                        Dim Valid As Boolean = LifeEvent.InsertIntoDB(New LifeEvent(RPIn.Value, DateTimePicker1.Value, Mode, Value1, Value2, Value3, Value4))

                        If Mode = LifeEvent.ENFERMEDAD And Noti.Checked And Valid Then
                            ScheduleNotification(Value2)
                        End If

                        DialogResult = DialogResult.OK
                    End If
                End If
            End If
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0279"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BullIDIn_ValueChanged(sender As Object, e As EventArgs) Handles BullIDIn.ValueChanged
        If BullIDIn.Value > 0 Then
            ComboBox3.Enabled = False
        Else
            ComboBox3.Enabled = True
        End If
    End Sub

    Private Function ValidateEvent(ByVal RP As Integer) As Boolean
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        Dim ThisCow As Cow = Cow.GetFromDB(RPIn.Value, Cow.COW, Conn)
        If DateDiff(DateInterval.Day, ThisCow.Birth, DateTimePicker1.Value) < 0 Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0144"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim CowState As String = Cow.GetCowsState(RP, DateTimePicker1.Value, Conn)

        If CowState.Equals(My.Computer.ResourceMgr.GetString("0249")) Or CowState.Equals(My.Computer.ResourceMgr.GetString("0250")) Or CowState.Equals(My.Computer.ResourceMgr.GetString("0251")) Then
            'If the cow is dead, rejected or was sold'
            Return False
        End If

        Dim IdaRecria As LifeEvent = LifeEvent.GetLastEvtOfType(RP, LifeEvent.IDA_RECRIA, DateTimePicker1.Value, Conn)
        If IdaRecria IsNot Nothing Then
            Dim ReturnDate As Date = Date.ParseExact(IdaRecria.Data3, "yyyy-MM-dd", Nothing)
            If ReturnDate.CompareTo(DateTimePicker1.Value) > 0 Then 'Through this a cow that is gone cannot receive any kind of events'
                MessageBox.Show(My.Computer.ResourceMgr.GetString("0309"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        Select Case Mode
            Case LifeEvent.ABORTO, LifeEvent.PARTO
                If Not CowState.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'Non preggo cows dont get abortions'
                    MessageBox.Show(RP & " - " & ThisCow.Name & " " & My.Computer.ResourceMgr.GetString("0302"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Not LifeEvent.ValidBirthOrAbortTest(New LifeEvent(RP, DateTimePicker1.Value, Mode, Nothing, Nothing, Nothing, Nothing)) Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0147"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

            Case LifeEvent.MUERTE, LifeEvent.RECHAZO, LifeEvent.VENTA
                If My.Settings.Privileges < 2 Then 'Without sufficient privileges you dont get to kill, reject or sell cows'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0303"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

            Case LifeEvent.SERVICIO
                If CowState.Contains(My.Computer.ResourceMgr.GetString("0258")) Then 'If the cow is in anestrum'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0304") & " " & My.Computer.ResourceMgr.GetString("0258") & " " & My.Computer.ResourceMgr.GetString("0307"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                ElseIf CowState.Contains(My.Computer.ResourceMgr.GetString("0254")) Then 'If the cow is preggo'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0305") & " " & My.Computer.ResourceMgr.GetString("0254") & " " & My.Computer.ResourceMgr.GetString("0307"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                ElseIf CowState.Contains(My.Computer.ResourceMgr.GetString("0252")) Then 'Calf'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0306") & " " & My.Computer.ResourceMgr.GetString("0252") & " " & My.Computer.ResourceMgr.GetString("0307"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Not LifeEvent.ValidServTest(New LifeEvent(RP, DateTimePicker1.Value, Mode, Nothing, Nothing, Nothing, Nothing)) Then 'Checks if there is a birth registered already in the next 12 months... Should technically work...'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0147"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Establishment.GetRemainingCapacity(Cow.GetEstablishment(RP), DateTimePicker1.Value) <= 0 Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0263"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

            Case LifeEvent.SECADO
                If Not CowState.Contains(My.Computer.ResourceMgr.GetString("0256")) Then 'If cow is not milking'
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0308") & " " & My.Computer.ResourceMgr.GetString("0256"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Sub ScheduleNotification(ByVal Medicine As String)
        Dim Time As Integer = 0

        Do While Time = 0
            Dim Result As String = ""
            Result = InputBox(My.Computer.ResourceMgr.GetString("0149"))
            If Result.Equals("") Then
                Time = -1
            Else
                Try
                    Time = Result

                    Dim Cow As Cow = Cow.GetFromDB(RPIn.Value, Cow.COW)
                    Dim Noti As New Notification(Now, My.Computer.ResourceMgr.GetString("0150") & " " & Cow.RP & " - " & Cow.Name & " " & My.Computer.ResourceMgr.GetString("0151") & " " & Medicine, Time)
                    Noti.Establishment = Cow.GetEstablishment(RPIn.Value)
                    Notification.InsertIntoDB(Noti)
                Catch ex As Exception
                End Try
            End If
        Loop
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        RPIn.Value = 0

        If BullIDIn.Visible Then
            BullIDIn.Value = 0
        End If
    End Sub
End Class