Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CowSearch
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CowSearch))
        Me.SearchBar = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NameRadio = New System.Windows.Forms.RadioButton()
        Me.RPRadio = New System.Windows.Forms.RadioButton()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.IDHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NameHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerFichaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchBar
        '
        resources.ApplyResources(Me.SearchBar, "SearchBar")
        Me.SearchBar.Name = "SearchBar"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.NameRadio)
        Me.GroupBox1.Controls.Add(Me.RPRadio)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'NameRadio
        '
        resources.ApplyResources(Me.NameRadio, "NameRadio")
        Me.NameRadio.Name = "NameRadio"
        Me.NameRadio.TabStop = True
        Me.NameRadio.UseVisualStyleBackColor = True
        '
        'RPRadio
        '
        resources.ApplyResources(Me.RPRadio, "RPRadio")
        Me.RPRadio.Name = "RPRadio"
        Me.RPRadio.TabStop = True
        Me.RPRadio.UseVisualStyleBackColor = True
        '
        'SearchButton
        '
        resources.ApplyResources(Me.SearchButton, "SearchButton")
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDHeader, Me.NameHeader})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'IDHeader
        '
        resources.ApplyResources(Me.IDHeader, "IDHeader")
        '
        'NameHeader
        '
        resources.ApplyResources(Me.NameHeader, "NameHeader")
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerFichaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'VerFichaToolStripMenuItem
        '
        resources.ApplyResources(Me.VerFichaToolStripMenuItem, "VerFichaToolStripMenuItem")
        Me.VerFichaToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.View
        Me.VerFichaToolStripMenuItem.Name = "VerFichaToolStripMenuItem"
        '
        'CowSearch
        '
        Me.AcceptButton = Me.SearchButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SearchBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CowSearch"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SearchBar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NameRadio As System.Windows.Forms.RadioButton
    Friend WithEvents RPRadio As System.Windows.Forms.RadioButton
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents IDHeader As ColumnHeader
    Friend WithEvents NameHeader As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents VerFichaToolStripMenuItem As ToolStripMenuItem
End Class
