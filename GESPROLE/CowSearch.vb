Imports System.Text.RegularExpressions

Public Class CowSearch
    Property Mode As Boolean
    Property ModeTwo As Boolean

    Property WhenDoISearch As Date

    Public Const SELECTION As Boolean = True
    Public Const USUAL As Boolean = False

    Public ReturnValue As Integer

    Private Sub CowSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If WhenDoISearch.Equals(Date.MinValue) Then
            WhenDoISearch = Today
        End If

        If Mode = Cow.BULL Then
            RPRadio.Text = "ID"
            ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0268"))
            ListView1.Columns(ListView1.Columns.Count - 1).Width = 90
            ListView1.Columns.Add(My.Computer.ResourceMgr.GetString("0118"))
            PopulateList(Cow.GetFromDB(Cow.BULL, Today))
        Else
            PopulateList(Cow.GetFromDB(Cow.COW, Today))
        End If

        NameRadio.Checked = True

        If Mode = Cow.BULL And ModeTwo = USUAL Then
            ContextMenuStrip1.Items.RemoveAt(0)
        End If

        If ModeTwo = SELECTION Then
            ContextMenuStrip1.Items(0).Text = My.Computer.ResourceMgr.GetString("0141")
            ContextMenuStrip1.Items(0).Image = My.Resources.Test

            'SearchButton.Enabled = False
        ElseIf My.Settings.Privileges >= 1 Then
            If Mode = Cow.BULL Then
                Dim UpdateWeightOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0269"), My.Resources.Report)
                ContextMenuStrip1.Items.Add(UpdateWeightOption)
                AddHandler(UpdateWeightOption.Click), AddressOf UpdateWeight
            End If
            If ContextMenuStrip1.Items.Count > 0 Then
                ContextMenuStrip1.Items.Add(New ToolStripSeparator)
            End If
            Dim RemoveCowOption As New ToolStripMenuItem(My.Computer.ResourceMgr.GetString("0057"), My.Resources.Delete)
            ContextMenuStrip1.Items.Add(RemoveCowOption)
            AddHandler(RemoveCowOption.Click), AddressOf RemoveCow
        End If

    End Sub

    Private Sub PopulateList(ByVal Items As Collection) 'Random custom implementation of an adapter'
        ListView1.Items.Clear()

        Try
            For Each Cow As Cow In Items
                ListView1.Items.Add(Cow.RP)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Cow.Name)

                If Mode = Cow.BULL Then
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Cow.GetBullState(Cow.RP, WhenDoISearch))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Cow.Weight & "Kg")
                    If ListView1.Items(ListView1.Items.Count - 1).SubItems(ListView1.Items(ListView1.Items.Count - 1).SubItems.Count - 2).Text.Equals(My.Computer.ResourceMgr.GetString("0252")) And Mode = Cow.BULL And ModeTwo = SELECTION Then
                        ListView1.Items.RemoveAt(ListView1.Items.Count - 1)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If SearchBar.Text.Length > 0 Then
            If RPRadio.Checked Then
                If Regex.IsMatch(SearchBar.Text, "^[a-zA-Z_ ]*$") Then
                    Dim CowBull As String = "ID"
                    If Mode Then
                        CowBull = "RP"
                    End If

                    If My.Settings.Language.Contains("en") Then
                        MessageBox.Show(My.Computer.ResourceMgr.GetString("0270") & " " & CowBull, My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf My.Settings.Language.Contains("es") Then
                        MessageBox.Show(CowBull & " " & My.Computer.ResourceMgr.GetString("0270"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    Return
                End If

                If ModeTwo = SELECTION Then
                    PopulateList(InternalSearch(False, Cow.GetFromDB(Mode, Today), SearchBar.Text, 1))
                ElseIf ModeTwo = USUAL Then
                    Dim Cow As Cow = Cow.GetFromDB(CInt(SearchBar.Text), Mode)
                    Dim Cows As New Collection
                    Cows.Add(Cow)
                    PopulateList(Cows)
                End If

            ElseIf NameRadio.Checked Then
                If Not Regex.IsMatch(SearchBar.Text, "^[a-zA-Z_ ]*$") Then
                    MessageBox.Show(My.Computer.ResourceMgr.GetString("0262"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If ModeTwo = SELECTION Then
                    PopulateList(InternalSearch(True, Cow.GetFromDB(Mode, Today), SearchBar.Text, 1))
                ElseIf ModeTwo = USUAL Then
                    Dim Cows As Collection
                    Cows = Cow.SearchInDB(SearchBar.Text.ToUpper, Mode)
                    PopulateList(Cows)
                End If
            End If
        Else
            PopulateList(Cow.GetFromDB(Mode, Today))
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick, VerFichaToolStripMenuItem.Click
        Select Case ModeTwo
            Case SELECTION
                Try
                    ReturnValue = CInt(ListView1.FocusedItem.Text) 'Return 0 if cow is dead or sold or was rejected'
                    DialogResult = DialogResult.OK
                Catch ex As Exception
                    'Just in case, wont happen'
                End Try
            Case USUAL
                If Mode = Cow.COW Then
                    Dim CowDataForm As New CowData
                    CowDataForm.Cow = Cow.GetFromDB(CInt(ListView1.FocusedItem.Text), Mode)
                    CowDataForm.ShowDialog(Me)
                End If
        End Select
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Select Case e.KeyChar
            Case ControlChars.Back
                RemoveCow()
        End Select
    End Sub

    Private Sub RemoveCow()
        If My.Settings.Privileges >= 1 And ListView1.FocusedItem IsNot Nothing Then
            If ModeTwo = USUAL Then
                Dim Result As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0192") & " " & ListView1.FocusedItem.SubItems(1).Text & "?", My.Computer.ResourceMgr.GetString("0194"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                Select Case Result
                    Case DialogResult.OK
                        Cow.RemoveFromDB(ListView1.FocusedItem.Text)
                        ListView1.Items.Remove(ListView1.FocusedItem)
                End Select
            End If
        End If
    End Sub

    Private Sub UpdateWeight()
        Dim ToEdit As String = InputBox(My.Computer.ResourceMgr.GetString("0271"))
        If Not ToEdit.Equals("") And Regex.IsMatch(ToEdit, "^[0-9]+$") Then
            Dim DialogResult As DialogResult = MessageBox.Show(My.Computer.ResourceMgr.GetString("0227") & " " & ListView1.FocusedItem.Text & " - " & ListView1.FocusedItem.SubItems(1).Text & " " & My.Computer.ResourceMgr.GetString("0228") & " " & ToEdit & "Kg?", My.Computer.ResourceMgr.GetString("0230") & " " & My.Computer.ResourceMgr.GetString("0118"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If DialogResult = DialogResult.OK Then
                Cow.UpdateWeight(CInt(ListView1.FocusedItem.Text), CInt(ToEdit))
                ListView1.FocusedItem.SubItems(ListView1.FocusedItem.SubItems.Count - 1).Text = ToEdit & "Kg"
            End If
        ElseIf Not Regex.IsMatch(ToEdit, "^[0-9]+$") Then
            MessageBox.Show(My.Computer.ResourceMgr.GetString("0270") & " " & My.Computer.ResourceMgr.GetString("0118"), My.Computer.ResourceMgr.GetString("0239"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function InternalSearch(ByVal ByName As Boolean, ByVal Source As Collection, ByVal Query As String, ByVal Index As Integer) As Collection
        'First time I make a recursive search... Kinda worked :)'
        Dim RetVal As New Collection

        If Index <= Source.Count Then
            Dim Cow As Cow = Source(Index)
            Try
                If ByName And Cow.Name.Equals(Query.ToUpper) Then
                    RetVal.Add(Cow)
                ElseIf Not ByName Then
                    If Cow.RP = CInt(Query) Then
                        RetVal.Add(Cow)
                    End If
                End If
            Catch ex As Exception

            End Try

            If Index < Source.Count Then
                For Each Bicho As Cow In InternalSearch(ByName, Source, Query, Index + 1)
                    RetVal.Add(Bicho)
                Next
            End If
        End If

        Return RetVal
    End Function
End Class