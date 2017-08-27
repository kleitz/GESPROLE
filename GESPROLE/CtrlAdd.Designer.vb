Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtrlAdd
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtrlAdd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StartInFirst = New System.Windows.Forms.DateTimePicker()
        Me.EndInFirst = New System.Windows.Forms.DateTimePicker()
        Me.EndInSecond = New System.Windows.Forms.DateTimePicker()
        Me.StartInSecond = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.EndInThird = New System.Windows.Forms.DateTimePicker()
        Me.StartInThird = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.RPHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OrdeneOneHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProteinHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FatHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LactHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SomCelHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WaterHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BactHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoverBovinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'StartInFirst
        '
        Me.StartInFirst.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.StartInFirst, "StartInFirst")
        Me.StartInFirst.Name = "StartInFirst"
        Me.StartInFirst.ShowUpDown = True
        '
        'EndInFirst
        '
        Me.EndInFirst.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.EndInFirst, "EndInFirst")
        Me.EndInFirst.Name = "EndInFirst"
        Me.EndInFirst.ShowUpDown = True
        '
        'EndInSecond
        '
        resources.ApplyResources(Me.EndInSecond, "EndInSecond")
        Me.EndInSecond.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.EndInSecond.Name = "EndInSecond"
        Me.EndInSecond.ShowUpDown = True
        '
        'StartInSecond
        '
        resources.ApplyResources(Me.StartInSecond, "StartInSecond")
        Me.StartInSecond.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.StartInSecond.Name = "StartInSecond"
        Me.StartInSecond.ShowUpDown = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.EndInThird)
        Me.GroupBox1.Controls.Add(Me.StartInThird)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.EndInSecond)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.StartInSecond)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.EndInFirst)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.StartInFirst)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'EndInThird
        '
        resources.ApplyResources(Me.EndInThird, "EndInThird")
        Me.EndInThird.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.EndInThird.Name = "EndInThird"
        Me.EndInThird.ShowUpDown = True
        '
        'StartInThird
        '
        resources.ApplyResources(Me.StartInThird, "StartInThird")
        Me.StartInThird.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.StartInThird.Name = "StartInThird"
        Me.StartInThird.ShowUpDown = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RPHeader, Me.OrdeneOneHeader, Me.ProteinHeader, Me.FatHeader, Me.LactHeader, Me.SomCelHeader, Me.WaterHeader, Me.BactHeader})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'RPHeader
        '
        resources.ApplyResources(Me.RPHeader, "RPHeader")
        '
        'OrdeneOneHeader
        '
        resources.ApplyResources(Me.OrdeneOneHeader, "OrdeneOneHeader")
        '
        'ProteinHeader
        '
        resources.ApplyResources(Me.ProteinHeader, "ProteinHeader")
        '
        'FatHeader
        '
        resources.ApplyResources(Me.FatHeader, "FatHeader")
        '
        'LactHeader
        '
        resources.ApplyResources(Me.LactHeader, "LactHeader")
        '
        'SomCelHeader
        '
        resources.ApplyResources(Me.SomCelHeader, "SomCelHeader")
        '
        'WaterHeader
        '
        resources.ApplyResources(Me.WaterHeader, "WaterHeader")
        '
        'BactHeader
        '
        resources.ApplyResources(Me.BactHeader, "BactHeader")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarDatosToolStripMenuItem, Me.ToolStripMenuItem1, Me.RemoverBovinoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'EditarDatosToolStripMenuItem
        '
        Me.EditarDatosToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Report
        Me.EditarDatosToolStripMenuItem.Name = "EditarDatosToolStripMenuItem"
        resources.ApplyResources(Me.EditarDatosToolStripMenuItem, "EditarDatosToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'RemoverBovinoToolStripMenuItem
        '
        Me.RemoverBovinoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Delete
        Me.RemoverBovinoToolStripMenuItem.Name = "RemoverBovinoToolStripMenuItem"
        resources.ApplyResources(Me.RemoverBovinoToolStripMenuItem, "RemoverBovinoToolStripMenuItem")
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CtrlAdd
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CtrlAdd"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StartInFirst As System.Windows.Forms.DateTimePicker
    Friend WithEvents EndInFirst As System.Windows.Forms.DateTimePicker
    Friend WithEvents EndInSecond As System.Windows.Forms.DateTimePicker
    Friend WithEvents StartInSecond As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents EndInThird As DateTimePicker
    Friend WithEvents StartInThird As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents OKButton As Button
    Friend WithEvents RPHeader As ColumnHeader
    Friend WithEvents OrdeneOneHeader As ColumnHeader
    Friend WithEvents ProteinHeader As ColumnHeader
    Friend WithEvents FatHeader As ColumnHeader
    Friend WithEvents LactHeader As ColumnHeader
    Friend WithEvents SomCelHeader As ColumnHeader
    Friend WithEvents WaterHeader As ColumnHeader
    Friend WithEvents BactHeader As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditarDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents RemoverBovinoToolStripMenuItem As ToolStripMenuItem
End Class
