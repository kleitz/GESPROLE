Imports System.ComponentModel

Public Class List
    Public Property ShowMe As Integer
    Public Property Value As String 'Pass type attribute value corresponding to validation table or lot name'

    Private BackgroundWrkr As New BackgroundWorker

    Public Const CONTROL As Integer = 0
    Public Const VACAS As Integer = 1
    Public Const LACTANDO As Integer = 2
    Public Const SECAS As Integer = 3
    Public Const VAQUILLONAS As Integer = 4
    Public Const A_SECAR As Integer = 5
    Public Const A_PARIR As Integer = 6
    Public Const A_TACTAR As Integer = 7
    Public Const LOT As Integer = 8
    Public Const MODIFY_DATA As Integer = 9
    Public Const NOTIFICATIONS As Integer = 10

    Private Sub List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWrkr.WorkerSupportsCancellation = True

        AddHandler BackgroundWrkr.DoWork, AddressOf BackgroundWrkr_DoWork
        AddHandler BackgroundWrkr.RunWorkerCompleted, AddressOf BackgroundWrkr_RunWorkerCompleted

        Select Case ShowMe
            Case CONTROL
                Me.Text = My.Computer.ResourceMgr.GetString("0043")
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0175"))
                ListView1.Columns(0).Width = 80
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0184"))
                ListView1.Columns(1).Width = 80
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0187"))
                ListView1.Columns(2).Width = 120
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0204"))
                ListView1.Columns(3).Width = 120
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0185"))
                ListView1.Columns(4).Width = 75
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0186"))
                ListView1.Columns(5).Width = 75
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0189"))
                ListView1.Columns(6).Width = 120

                BackgroundWrkr.RunWorkerAsync()

                'Context menu setup'
                Dim EditControlOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0056"), My.Resources.Report)
                ContextMenuStrip1.Items.Add(EditControlOption)
                AddHandler(EditControlOption.Click), AddressOf EditControl
                If My.Settings.Privileges >= 1 Then
                    Dim RemoveControlOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0057"), My.Resources.Delete)
                    ContextMenuStrip1.Items.Add(RemoveControlOption)
                    AddHandler(RemoveControlOption.Click), AddressOf RemoveControl
                End If
            Case 1 To 8
                'Set list up'
                ListView1.Columns.Add("RP")
                ListView1.Columns(0).Width = 120
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0099"))
                ListView1.Columns(1).Width = 445

                'Populate list'
                BackgroundWrkr.RunWorkerAsync()

                Select Case ShowMe
                    Case VACAS
                        Me.Text = My.Computer.ResourceMgr.GetString("0047")
                    Case LACTANDO
                        Me.Text = My.Computer.ResourceMgr.GetString("0048")
                    Case SECAS
                        Me.Text = My.Computer.ResourceMgr.GetString("0049")
                    Case VAQUILLONAS
                        Me.Text = My.Computer.ResourceMgr.GetString("0050")
                    Case A_SECAR
                        Me.Text = My.Computer.ResourceMgr.GetString("0051")
                    Case A_PARIR
                        Me.Text = My.Computer.ResourceMgr.GetString("0052")
                    Case A_TACTAR
                        Me.Text = My.Computer.ResourceMgr.GetString("0053")
                    Case LOT
                        Me.Text = Value
                End Select

                'Context menu setup'
                Dim SeeDataOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0287"), My.Resources.View)
                ContextMenuStrip1.Items.Add(SeeDataOption)
                AddHandler(SeeDataOption.Click), AddressOf SeeData

                Dim EventOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0288"), My.Resources.Comment)
                ContextMenuStrip1.Items.Add(EventOption)
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0025"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0026"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0027"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0028"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0029"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0030"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0031"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0032"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0033"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0034"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0035"))
                EventOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0036"))

                For Each CurrentItem As ToolStripDropDownItem In EventOption.DropDownItems
                    AddHandler(CurrentItem.Click), AddressOf AddEvent
                Next

                If Not My.Settings.Establishment.Equals("") Then
                    ContextMenuStrip1.Items.Add(New ToolStripSeparator)

                    Dim EventForAllOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0289"), My.Resources.Comment)
                    ContextMenuStrip1.Items.Add(EventForAllOption)
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0026"))
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0028"))
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0029"))
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0033"))
                    If Not My.Settings.Establishment.Equals("") Then
                        EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0034"))
                    End If
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0035"))
                    EventForAllOption.DropDownItems.Add(My.Computer.ResourceMgr.GetString("0036"))

                    For Each CurrentItem As ToolStripDropDownItem In EventForAllOption.DropDownItems
                        AddHandler(CurrentItem.Click), AddressOf EventForAll
                    Next
                End If

            Case MODIFY_DATA
                Me.Text = My.Computer.ResourceMgr.GetString("0290")
                ListView1.Columns.Add("ID")
                ListView1.Columns(0).Width = 120
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0291"))
                ListView1.Columns(1).Width = 445

                Loading_Label.Text = My.Computer.ResourceMgr.GetString("0247")
                ReloadData(Validation.GetFromDB(Value))

                'Context menu setup'
                Dim AddValueOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0022"), My.Resources.Add)
                ContextMenuStrip1.Items.Add(AddValueOption)
                AddHandler(AddValueOption.Click), AddressOf AddValue
                ContextMenuStrip1.Items.Add(New ToolStripSeparator)
                Dim EditValueOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0056"), My.Resources.Report)
                ContextMenuStrip1.Items.Add(EditValueOption)
                AddHandler(EditValueOption.Click), AddressOf EditValue
                Dim RemoveValueOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0057"), My.Resources.Delete)
                ContextMenuStrip1.Items.Add(RemoveValueOption)
                AddHandler(RemoveValueOption.Click), AddressOf RemoveValue

            Case NOTIFICATIONS
                Me.Text = My.Computer.ResourceMgr.GetString("0292")
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0175"))
                ListView1.Columns(0).Width = 100
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0237"))
                ListView1.Columns(1).Width = 380
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0238"))
                ListView1.Columns(2).Width = 80

                Loading_Label.Text = My.Computer.ResourceMgr.GetString("0247")
                ReloadData(Notification.GetList())

                'Context menu setup'
                Dim MarkAsDoneOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0293"), My.Resources.Add)
                ContextMenuStrip1.Items.Add(MarkAsDoneOption)
                AddHandler(MarkAsDoneOption.Click), AddressOf MarkAsDone
                Dim ExtendOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0294"), My.Resources.Report)
                ContextMenuStrip1.Items.Add(ExtendOption)
                AddHandler(ExtendOption.Click), AddressOf Extend
                ContextMenuStrip1.Items.Add(New ToolStripSeparator)
                Dim RemoveValueOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0057"), My.Resources.Delete)
                ContextMenuStrip1.Items.Add(RemoveValueOption)
                AddHandler(RemoveValueOption.Click), AddressOf RemoveNotification
        End Select
    End Sub

    Private Sub BackgroundWrkr_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        If BackgroundWrkr.CancellationPending = True Then
            e.Cancel = True
        Else
            Select Case ShowMe
                Case CONTROL
                    ReloadData(MilkControl.GetList())
                Case 1 To 8
                    Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
                    Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

                    ReloadData(Cow.GetList(Cow.COW, ShowMe, GESPROLE.Lot.GetFromDB(Value, My.Settings.Establishment), Today, Conn))
            End Select
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

    Private Sub List_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If BackgroundWrkr.IsBusy Then
            BackgroundWrkr.CancelAsync()
        End If
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Select Case ShowMe
            Case CONTROL
                EditControl()
            Case 1 To 8
                SeeData()
            Case MODIFY_DATA
                EditValue()
        End Select
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Select Case e.Button
            Case MouseButtons.Right
                If ListView1.FocusedItem.Bounds.Contains(e.Location) Then
                    ContextMenuStrip1.Show(Cursor.Position)
                End If
        End Select
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        ' If looking at a control or a validation table it will allow deletion of values by pressing back
        Select Case e.KeyChar
            Case ControlChars.Back
                Select Case ShowMe
                    Case CONTROL
                        RemoveControl()
                    Case MODIFY_DATA
                        RemoveValue()
                End Select
        End Select
    End Sub

    'Rural ListView Adapter'
    Private Delegate Sub ReloadData_delegate(ByVal Items As Collection)

    Public Sub ReloadData(ByVal Items As Collection)
        If ListView1.InvokeRequired Then
            Invoke(New ReloadData_delegate(AddressOf ReloadData), Items)
        Else
            ListView1.Items.Clear()
            For Each Item As Object In Items
                If TypeOf Item Is Validation Then
                    Dim Validation As Validation = CType(Item, Validation)
                    ListView1.Items.Add(Validation.ID)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Validation.Value)
                ElseIf TypeOf Item Is Cow Then
                    Dim Cow As Cow = CType(Item, Cow)
                    ListView1.Items.Add(Cow.RP)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Cow.Name)
                ElseIf TypeOf Item Is MilkControl Then
                    Dim Control As MilkControl = CType(Item, MilkControl)
                    If MilkControl.GetEstablishment(Control.ID).Equals(My.Settings.Establishment) Or My.Settings.Establishment.Equals("") Then
                        ListView1.Items.Add(Control.Time.ToString(My.Computer.ResourceMgr.GetString("0245")))
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Proteins)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.SomCel)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Water)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Fat)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Lactose)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Bacteria)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.ID)
                    End If
                ElseIf TypeOf Item Is Notification Then
                    Dim Noti As Notification = CType(Item, Notification)
                    ListView1.SmallImageList = New ImageList
                    ListView1.SmallImageList.Images.Add(My.Resources.Tick)
                    ListView1.SmallImageList.Images.Add(My.Resources.Cross)
                    ListView1.Items.Add(Noti.Date_In.ToString(My.Computer.ResourceMgr.GetString("0245")), 1)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Noti.Msg)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Noti.Length)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Noti.ID)
                End If
            Next
        End If
    End Sub

    'Control option events'
    Private Sub EditControl()
        If ListView1.FocusedItem IsNot Nothing Then
            Dim ControlForm As New CtrlAdd
            ControlForm.Editing = True
            ControlForm.MilkControls = MilkControl.GetFromDB(ListView1.FocusedItem.SubItems(7).Text)
            If ControlForm.ShowDialog(Me) = DialogResult.OK Then
                ReloadData(MilkControl.GetList())
            End If
        End If
    End Sub

    Private Sub RemoveControl()
        If My.Settings.Privileges >= 1 And ListView1.FocusedItem IsNot Nothing Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0295") & " " & ListView1.FocusedItem.SubItems(0).Text & "?", My.Computer.ResourceMgr.GetString("0296"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Result = DialogResult.OK Then
                ListView1.Items.Remove(ListView1.FocusedItem)
                MilkControl.RemoveFromDB(ListView1.FocusedItem.SubItems(7).Text)
            End If
        End If
    End Sub

    'List option events'
    Private Sub SeeData()
        If ListView1.FocusedItem IsNot Nothing Then
            Dim CowDataForm As New CowData
            CowDataForm.Cow = Cow.GetFromDB(CInt(ListView1.FocusedItem.Text), Cow.COW)
            CowDataForm.ShowDialog(Me)
        End If
    End Sub

    Private Sub AddEvent(ByVal sender As Object, ByVal e As EventArgs)
        If ListView1.FocusedItem IsNot Nothing Then
            Dim EvtAddWin As New EvtAdd

            Dim Clicked As ToolStripItem = CType(sender, ToolStripItem)
            Select Case Clicked.Text
                Case My.Computer.ResourceMgr.GetString("0025")
                    EvtAddWin.Mode = LifeEvent.ABORTO
                Case My.Computer.ResourceMgr.GetString("0026")
                    EvtAddWin.Mode = LifeEvent.ANALISIS
                Case My.Computer.ResourceMgr.GetString("0027")
                    EvtAddWin.Mode = LifeEvent.ENFERMEDAD
                Case My.Computer.ResourceMgr.GetString("0028")
                    EvtAddWin.Dispose()
                    Dim RecriaWin As New Recria

                    RecriaWin.RPs = New Collection
                    Try
                        RecriaWin.RPs.Add(CInt(ListView1.FocusedItem.Text))
                        RecriaWin.ShowDialog(Me)
                    Catch ex As Exception
                        MessageBox.Show(My.Computer.ResourceMgr.GetString("0010"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Return
                Case My.Computer.ResourceMgr.GetString("0029")
                    EvtAddWin.Mode = LifeEvent.MEDICACION
                Case My.Computer.ResourceMgr.GetString("0030")
                    EvtAddWin.Mode = LifeEvent.MUERTE
                Case My.Computer.ResourceMgr.GetString("0031")
                    EvtAddWin.Mode = LifeEvent.PARTO
                Case My.Computer.ResourceMgr.GetString("0032")
                    EvtAddWin.Mode = LifeEvent.RECHAZO
                Case My.Computer.ResourceMgr.GetString("0033")
                    EvtAddWin.Mode = LifeEvent.SECADO
                Case My.Computer.ResourceMgr.GetString("0034")
                    EvtAddWin.Mode = LifeEvent.SERVICIO
                Case My.Computer.ResourceMgr.GetString("0035")
                    EvtAddWin.Mode = LifeEvent.TACTO
                Case My.Computer.ResourceMgr.GetString("0036")
                    EvtAddWin.Mode = LifeEvent.VENTA
            End Select

            EvtAddWin.RPs = New Collection
            EvtAddWin.RPs.Add(CInt(ListView1.FocusedItem.Text))

            EvtAddWin.ShowDialog(Me)
        End If
    End Sub

    Private Sub EventForAll(ByVal sender As Object, ByVal e As EventArgs)
        If ListView1.Items.Count > 0 Then
            Dim EvtAddWin As New EvtAdd

            Dim Clicked As ToolStripItem = CType(sender, ToolStripItem)
            Select Case Clicked.Text
                Case My.Computer.ResourceMgr.GetString("0026")
                    EvtAddWin.Mode = LifeEvent.ANALISIS
                Case My.Computer.ResourceMgr.GetString("0028")
                    EvtAddWin.Dispose()
                    Dim RecriaWin As New Recria

                    RecriaWin.RPs = New Collection
                    For Each CurrentItem As ListViewItem In ListView1.Items
                        Try
                            RecriaWin.RPs.Add(CInt(CurrentItem.Text))
                        Catch ex As Exception
                            MessageBox.Show(My.Computer.ResourceMgr.GetString("0010"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        End Try
                    Next

                    If ListView1.Items.Count = RecriaWin.RPs.Count Then
                        RecriaWin.ShowDialog(Me)
                    End If

                    Return
                Case My.Computer.ResourceMgr.GetString("0029")
                    EvtAddWin.Mode = LifeEvent.MEDICACION
                Case My.Computer.ResourceMgr.GetString("0033")
                    EvtAddWin.Mode = LifeEvent.SECADO
                Case My.Computer.ResourceMgr.GetString("0034")
                    EvtAddWin.Mode = LifeEvent.SERVICIO
                Case My.Computer.ResourceMgr.GetString("0035")
                    EvtAddWin.Mode = LifeEvent.TACTO
                Case My.Computer.ResourceMgr.GetString("0036")
                    EvtAddWin.Mode = LifeEvent.VENTA
            End Select

            EvtAddWin.RPs = New Collection
            For Each CurrentItem As ListViewItem In ListView1.Items
                Try
                    EvtAddWin.RPs.Add(CInt(CurrentItem.Text))
                Catch ex As Exception

                End Try
            Next

            EvtAddWin.ShowDialog(Me)
        End If
    End Sub

    'Validation (MODIFY_DATA) option events'
    Private Sub AddValue()
        Dim NewValue As String = InputBox(My.Computer.ResourceMgr.GetString("0297"))
        If Not NewValue.Equals("") Then
            Validation.InsertIntoDB(New Validation(0, Value, NewValue))

            ReloadData(Validation.GetFromDB(Value))
        End If
    End Sub

    Private Sub EditValue()
        If ListView1.FocusedItem IsNot Nothing Then
            Dim NewValue As String = InputBox(My.Computer.ResourceMgr.GetString("0297"))
            If Not NewValue.Equals("") Then
                Validation.UpdateInDB(New Validation(CInt(ListView1.FocusedItem.Text), Value, NewValue.ToUpper))

                ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text = NewValue.ToUpper
            End If
        End If
    End Sub

    Private Sub RemoveValue()
        If ListView1.FocusedItem IsNot Nothing Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0298") & " " & ListView1.FocusedItem.SubItems(1).Text & "?", My.Computer.ResourceMgr.GetString("0299"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Result = DialogResult.OK Then
                Validation.DeleteFromDB(CInt(ListView1.FocusedItem.Text))
                ListView1.Items.Remove(ListView1.FocusedItem)
            End If
        End If
    End Sub

    'Notification option events'
    Private Sub MarkAsDone(ByVal sender As Object, ByVal e As EventArgs)
        Dim Button As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        If ListView1.FocusedItem IsNot Nothing Then
            Notification.MarkAsDone(ListView1.FocusedItem.SubItems(3).Text)
            ListView1.FocusedItem.ImageIndex = 0
            Button.Text = My.Computer.ResourceMgr.GetString("0300")
            RemoveHandler(Button.Click), AddressOf MarkAsDone
            AddHandler(Button.Click), AddressOf Undo
        End If
    End Sub

    Private Sub Undo(ByVal sender As Object, ByVal e As EventArgs)
        Dim Button As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        If ListView1.FocusedItem IsNot Nothing Then
            Notification.MarkAsUnDone(ListView1.FocusedItem.SubItems(3).Text)
            ListView1.FocusedItem.ImageIndex = 1
            Button.Text = My.Computer.ResourceMgr.GetString("0293")
            RemoveHandler(Button.Click), AddressOf Undo
            AddHandler(Button.Click), AddressOf MarkAsDone
        End If
    End Sub

    Private Sub Extend()
        If ListView1.FocusedItem IsNot Nothing Then
            Try
                Dim Plus As Integer = InputBox(My.Computer.ResourceMgr.GetString("0149"))

                Notification.Extend(ListView1.FocusedItem.SubItems(3).Text, Plus)
                ListView1.FocusedItem.SubItems(2).Text = ListView1.FocusedItem.SubItems(2).Text + Plus
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RemoveNotification()
        If ListView1.FocusedItem IsNot Nothing Then
            Notification.RemoveFromDB(ListView1.FocusedItem.SubItems(3).Text)
        End If
    End Sub

End Class