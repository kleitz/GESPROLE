Imports System.ComponentModel
Imports ComboDialog

Public Class CtrlAdd
    Implements ComboDialog.ProgressDialog.ProgressDialogInterface
    Property MilkControls As Collection
    Property Estab As String
    Property Editing As Boolean

    Private Sub CtrlAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Today
        If MilkControls Is Nothing Then
            MilkControls = New Collection
            Dim MakeSuperAdminAgain As Boolean = False
            If My.Settings.Establishment.Equals("") Then
                Dim Establishments As Collection = Establishment.GetEstabList()
                Establishments.Remove(1) 'Remove TODOS entry'
                Dim EstabSelect As New ComboDialog.ComboDialog(My.Computer.ResourceMgr.GetString("0065"), Establishments)
                If EstabSelect.ShowDialog() = DialogResult.OK Then
                    MakeSuperAdminAgain = True
                    My.Settings.Establishment = EstabSelect.RetVal
                    Estab = EstabSelect.RetVal
                Else
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0283"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Editing = True
                    Me.Close()
                    Return
                End If
            End If

            Dim ProgressDlg As New ComboDialog.ProgressDialog
            ProgressDlg.ProgressDlgInterface = Me
            ProgressDlg.ShowDialog(Me)

            If MakeSuperAdminAgain Then
                My.Settings.Establishment = ""
            End If
        Else
            If Editing Then
                If CType(MilkControls(1), MilkControl).Milkings.Count = 2 Then
                    ListView1.Columns.Clear()

                    ListView1.Columns.Add("RP")
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0181"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40

                    CheckBox1.Checked = True
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0182"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40
                    EndInSecond.Enabled = CheckBox1.Checked

                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0184"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 50
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0185"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 70
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0186"))
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0187"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 80
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0188"))
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0189"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 80
                ElseIf CType(MilkControls(1), MilkControl).Milkings.Count = 3 Then
                    ListView1.Columns.Clear()

                    ListView1.Columns.Add("RP")
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0181"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40

                    CheckBox1.Checked = True
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0182"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40
                    EndInSecond.Enabled = CheckBox1.Checked
                    CheckBox2.Checked = True
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0183"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 40
                    EndInThird.Enabled = CheckBox2.Checked

                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0184"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 50
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0185"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 70
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0186"))
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0187"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 80
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0188"))
                    ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0189"))
                    ListView1.Columns(ListView1.Columns.Count - 1).Width = 80
                End If

                StartInFirst.Enabled = False
                StartInSecond.Enabled = False
                StartInThird.Enabled = False

                CheckBox1.Enabled = False
                CheckBox2.Enabled = False

                UpdateTimes(MilkControls)
            End If
        End If
        PopulateList(MilkControls)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not Editing Then
            StartInSecond.Enabled = CheckBox1.Checked
            EndInSecond.Enabled = CheckBox1.Checked

            If CheckBox1.Checked Then
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0182"))
                ListView1.Columns(ListView1.Columns.Count - 1).DisplayIndex = 2

                For Each Control As MilkControl In MilkControls
                    Control.AddMilking(Nothing, Nothing, 0)
                Next
            Else
                ListView1.Columns.RemoveAt(ListView1.Columns.Count - 1)
                For Each Control As MilkControl In MilkControls
                    Control.Milkings.Remove(2)
                Next
            End If

            If Not CheckBox1.Checked And CheckBox2.Checked Then
                CheckBox2.Checked = False
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Not Editing Then
            If CheckBox2.Checked Then
                If CheckBox1.Checked Then
                    StartInThird.Enabled = CheckBox2.Checked
                    EndInThird.Enabled = CheckBox2.Checked
                Else
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0191"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CheckBox2.Checked = False
                End If
            Else
                StartInThird.Enabled = CheckBox2.Checked
                EndInThird.Enabled = CheckBox2.Checked
            End If

            If CheckBox2.Checked Then
                ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0183"))
                ListView1.Columns(ListView1.Columns.Count - 1).DisplayIndex = 3
                For Each Control As MilkControl In MilkControls
                    Control.AddMilking(Nothing, Nothing, 0)
                Next
            Else
                ListView1.Columns.RemoveAt(ListView1.Columns.Count - 1)
                For Each Control As MilkControl In MilkControls
                    Control.Milkings.Remove(Control.Milkings.Count)
                Next
            End If
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick, EditarDatosToolStripMenuItem.Click
        Dim CtrlEditForm As New CtrlEdit(ListView1.FocusedItem.Index + 1, MilkControls)
        If CheckBox2.Checked Then
            CtrlEditForm.Mode = 3
        ElseIf CheckBox1.Checked Then
            CtrlEditForm.Mode = 2
        End If
        If CtrlEditForm.ShowDialog(Me) = DialogResult.OK Then
            PopulateList(CtrlEditForm.MilkControls)
        End If
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        ' If looking at a control or a validation table it will allow deletion of values by pressing back
        Select Case e.KeyChar
            Case ControlChars.Back
                Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0192") & " " & Cow.GetFromDB(ListView1.FocusedItem.Text, Cow.COW).Name & My.Computer.ResourceMgr.GetString("0193"), My.Computer.ResourceMgr.GetString("0284"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If Result = DialogResult.OK Then
                    ListView1.Items.Remove(ListView1.FocusedItem)
                End If
        End Select
    End Sub

    Private Sub RemoverBovinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoverBovinoToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing And Not Editing Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0192") & " " & Cow.GetFromDB(ListView1.FocusedItem.Text, Cow.COW).Name & My.Computer.ResourceMgr.GetString("0193"), My.Computer.ResourceMgr.GetString("0284"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Result = DialogResult.OK Then
                ListView1.Items.Remove(ListView1.FocusedItem)
                MilkControls.Remove(ListView1.FocusedItem.Index + 1) '+1 cause the equivalence is between a zero-based list and a 1 based list'
            End If
        ElseIf Editing Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0195"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PrepareCollection(ByVal Cows As Collection)
        If MilkControls IsNot Nothing Then
            MilkControls.Clear()
            For Each CurrentCow As Cow In Cows
                MilkControls.Add(New MilkControl(0, CurrentCow.RP, DateTimePicker1.Value, 0, 0, 0, 0, 0, 0))
                CType(MilkControls(MilkControls.Count), MilkControl).AddMilking(Nothing, Nothing, 0)
            Next
        End If

    End Sub

    Private Sub UpdateTimes(ByVal NewControls As Collection)
        DateTimePicker1.Value = CType(NewControls(1), MilkControl).Time
        DateTimePicker1.Enabled = False

        StartInFirst.Value = CType(CType(NewControls(1), MilkControl).Milkings(1), MilkControl.Milking).Start
        EndInFirst.Value = CType(CType(NewControls(1), MilkControl).Milkings(1), MilkControl.Milking).Finish
        If CheckBox1.Checked Then
            StartInSecond.Value = CType(CType(NewControls(1), MilkControl).Milkings(2), MilkControl.Milking).Start
            EndInSecond.Value = CType(CType(NewControls(1), MilkControl).Milkings(2), MilkControl.Milking).Finish
        End If
        If CheckBox2.Checked Then
            StartInThird.Value = CType(CType(NewControls(1), MilkControl).Milkings(3), MilkControl.Milking).Start
            EndInThird.Value = CType(CType(NewControls(1), MilkControl).Milkings(3), MilkControl.Milking).Finish
        End If
    End Sub

    Private Sub PopulateList(ByVal NewControls As Collection)
        ListView1.Items.Clear()

        For Each Control As MilkControl In NewControls
            ListView1.Items.Add(Control.RP)

            Try
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(CType(Control.Milkings(1), MilkControl.Milking).Qty)
                If CheckBox2.Checked Then
                    If Control.Milkings.Count = 1 Then
                        Control.AddMilking(Nothing, Nothing, 0)
                        Control.AddMilking(Nothing, Nothing, 0)
                    ElseIf Control.Milkings.Count = 2 Then
                        Control.AddMilking(Nothing, Nothing, 0)
                    End If

                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(CType(Control.Milkings(2), MilkControl.Milking).Qty)
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(CType(Control.Milkings(3), MilkControl.Milking).Qty)
                ElseIf CheckBox1.Checked Then
                    If Control.Milkings.Count = 1 Then
                        Control.AddMilking(Nothing, Nothing, 0)
                    End If

                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(CType(Control.Milkings(2), MilkControl.Milking).Qty)
                End If
            Catch ex As Exception

            End Try

            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Proteins)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Fat)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Lactose)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.SomCel)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Water)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Control.Bacteria)
        Next
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If Ready() Then
            UpdateMilkings()
            If Editing Then
                For Each Control As MilkControl In MilkControls
                    MilkControl.UpdateInDB(Control)
                Next
            Else
                Dim CtrlID As Integer = MilkControl.NewCtrlIndex()
                For Each Control As MilkControl In MilkControls
                    MilkControl.InsertIntoDB(CtrlID, Control)
                Next
            End If

            DialogResult = DialogResult.OK
        Else
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0169"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UpdateMilkings()
        For Each Control As MilkControl In MilkControls
            Control.EditMilking(1, StartInFirst.Value, EndInFirst.Value, 0)
            If CheckBox1.Checked Then
                Control.EditMilking(2, StartInSecond.Value, EndInSecond.Value, 0)
            End If
            If CheckBox2.Checked Then
                Control.EditMilking(3, StartInThird.Value, EndInThird.Value, 0)
            End If
        Next
    End Sub

    Private Function Ready()
        For Each Item As ListViewItem In ListView1.Items
            For Each SubItem As ListViewItem.ListViewSubItem In Item.SubItems
                If SubItem.Text.Equals("") Or SubItem.Text.Equals("0") Then
                    Return False
                End If
            Next
        Next
        If StartInFirst.Value.Equals(EndInFirst.Value) Then
            Return False
        End If
        If CheckBox1.Checked Then
            If StartInSecond.Value.Equals(EndInSecond.Value) Then
                Return False
            End If
        End If
        If CheckBox2.Checked Then
            If StartInThird.Value.Equals(EndInThird.Value) Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub ActionToPerform() Implements ProgressDialog.ProgressDialogInterface.ActionToPerform
        Dim Conn As New MySql.Data.MySqlClient.MySqlConnection
        Conn.ConnectionString = "server=" & My.Settings.IP & ";" _
            & "port=" & My.Settings.MySQLPort & ";" _
            & "uid=" & My.Settings.User & ";" _
            & "pwd=" & KryptUtils.Decrypt() & ";" _
            & "database=" & My.Settings.MySQLUser & ";"

        PrepareCollection(Cow.GetList(Cow.COW, List.LACTANDO, Nothing, DateTimePicker1.Value, Conn))
    End Sub

    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        Select Case e.KeyChar
            Case ControlChars.NewLine
                If MilkControls IsNot Nothing Then
                    Dim MakeSuperAdminAgain As Boolean = False
                    If My.Settings.Establishment.Equals("") Then
                        MakeSuperAdminAgain = True
                        My.Settings.Establishment = Estab
                    End If

                    Dim ProgressDlg As New ComboDialog.ProgressDialog
                    ProgressDlg.ProgressDlgInterface = Me
                    ProgressDlg.ShowDialog(Me)
                    PopulateList(MilkControls)

                    If MakeSuperAdminAgain Then
                        My.Settings.Establishment = ""
                    End If
                End If
        End Select
    End Sub

    Private Sub CtrlAdd_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Editing Then
            Return
        End If

        If Ready() And DialogResult <> DialogResult.OK Then
            Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0196"), My.Computer.ResourceMgr.GetString("0242"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            Select Case Result
                Case DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub
End Class