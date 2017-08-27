Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Loteo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loteo))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.NameHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LactHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProdHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BirthHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StateHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerListadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameIn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LactFrom = New System.Windows.Forms.NumericUpDown()
        Me.LactTo = New System.Windows.Forms.NumericUpDown()
        Me.ProdTo = New System.Windows.Forms.NumericUpDown()
        Me.ProdFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BirthTo = New System.Windows.Forms.NumericUpDown()
        Me.BirthFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Pregnant = New System.Windows.Forms.RadioButton()
        Me.Empty = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.Repr = New System.Windows.Forms.CheckBox()
        Me.Birth = New System.Windows.Forms.CheckBox()
        Me.Prod = New System.Windows.Forms.CheckBox()
        Me.Lact = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.LactFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LactTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BirthTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BirthFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameHeader, Me.LactHeader, Me.ProdHeader, Me.BirthHeader, Me.StateHeader})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'NameHeader
        '
        resources.ApplyResources(Me.NameHeader, "NameHeader")
        '
        'LactHeader
        '
        resources.ApplyResources(Me.LactHeader, "LactHeader")
        '
        'ProdHeader
        '
        resources.ApplyResources(Me.ProdHeader, "ProdHeader")
        '
        'BirthHeader
        '
        resources.ApplyResources(Me.BirthHeader, "BirthHeader")
        '
        'StateHeader
        '
        resources.ApplyResources(Me.StateHeader, "StateHeader")
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerListadoToolStripMenuItem, Me.ToolStripMenuItem1, Me.EditarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'VerListadoToolStripMenuItem
        '
        resources.ApplyResources(Me.VerListadoToolStripMenuItem, "VerListadoToolStripMenuItem")
        Me.VerListadoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.View
        Me.VerListadoToolStripMenuItem.Name = "VerListadoToolStripMenuItem"
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'EditarToolStripMenuItem
        '
        resources.ApplyResources(Me.EditarToolStripMenuItem, "EditarToolStripMenuItem")
        Me.EditarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Report
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        '
        'EliminarToolStripMenuItem
        '
        resources.ApplyResources(Me.EliminarToolStripMenuItem, "EliminarToolStripMenuItem")
        Me.EliminarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Delete
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'NameIn
        '
        resources.ApplyResources(Me.NameIn, "NameIn")
        Me.NameIn.Name = "NameIn"
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
        'LactFrom
        '
        resources.ApplyResources(Me.LactFrom, "LactFrom")
        Me.LactFrom.Name = "LactFrom"
        '
        'LactTo
        '
        resources.ApplyResources(Me.LactTo, "LactTo")
        Me.LactTo.Name = "LactTo"
        '
        'ProdTo
        '
        resources.ApplyResources(Me.ProdTo, "ProdTo")
        Me.ProdTo.Name = "ProdTo"
        '
        'ProdFrom
        '
        resources.ApplyResources(Me.ProdFrom, "ProdFrom")
        Me.ProdFrom.Name = "ProdFrom"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'BirthTo
        '
        resources.ApplyResources(Me.BirthTo, "BirthTo")
        Me.BirthTo.Name = "BirthTo"
        '
        'BirthFrom
        '
        resources.ApplyResources(Me.BirthFrom, "BirthFrom")
        Me.BirthFrom.Name = "BirthFrom"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
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
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Pregnant
        '
        resources.ApplyResources(Me.Pregnant, "Pregnant")
        Me.Pregnant.Name = "Pregnant"
        Me.Pregnant.TabStop = True
        Me.Pregnant.UseVisualStyleBackColor = True
        '
        'Empty
        '
        resources.ApplyResources(Me.Empty, "Empty")
        Me.Empty.Name = "Empty"
        Me.Empty.TabStop = True
        Me.Empty.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.ClearButton)
        Me.GroupBox1.Controls.Add(Me.Repr)
        Me.GroupBox1.Controls.Add(Me.Birth)
        Me.GroupBox1.Controls.Add(Me.Prod)
        Me.GroupBox1.Controls.Add(Me.Lact)
        Me.GroupBox1.Controls.Add(Me.NameIn)
        Me.GroupBox1.Controls.Add(Me.Empty)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Pregnant)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LactFrom)
        Me.GroupBox1.Controls.Add(Me.BirthTo)
        Me.GroupBox1.Controls.Add(Me.LactTo)
        Me.GroupBox1.Controls.Add(Me.BirthFrom)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ProdFrom)
        Me.GroupBox1.Controls.Add(Me.ProdTo)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'ClearButton
        '
        resources.ApplyResources(Me.ClearButton, "ClearButton")
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'Repr
        '
        resources.ApplyResources(Me.Repr, "Repr")
        Me.Repr.Checked = True
        Me.Repr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Repr.Name = "Repr"
        Me.Repr.UseVisualStyleBackColor = True
        '
        'Birth
        '
        resources.ApplyResources(Me.Birth, "Birth")
        Me.Birth.Checked = True
        Me.Birth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Birth.Name = "Birth"
        Me.Birth.UseVisualStyleBackColor = True
        '
        'Prod
        '
        resources.ApplyResources(Me.Prod, "Prod")
        Me.Prod.Checked = True
        Me.Prod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Prod.Name = "Prod"
        Me.Prod.UseVisualStyleBackColor = True
        '
        'Lact
        '
        resources.ApplyResources(Me.Lact, "Lact")
        Me.Lact.Checked = True
        Me.Lact.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Lact.Name = "Lact"
        Me.Lact.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Loteo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Loteo"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.LactFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LactTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BirthTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BirthFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NameIn As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LactFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents LactTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProdTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProdFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BirthTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents BirthFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Pregnant As System.Windows.Forms.RadioButton
    Friend WithEvents Empty As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents NameHeader As ColumnHeader
    Friend WithEvents LactHeader As ColumnHeader
    Friend WithEvents ProdHeader As ColumnHeader
    Friend WithEvents BirthHeader As ColumnHeader
    Friend WithEvents StateHeader As ColumnHeader
    Friend WithEvents Repr As CheckBox
    Friend WithEvents Birth As CheckBox
    Friend WithEvents Prod As CheckBox
    Friend WithEvents Lact As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents VerListadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearButton As Button
End Class
