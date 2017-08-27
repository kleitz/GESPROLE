Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Semen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Semen))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Search = New System.Windows.Forms.Button()
        Me.IDIn = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.QtyIn = New System.Windows.Forms.NumericUpDown()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.IDHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BullHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.IDIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QtyIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.OKButton)
        Me.GroupBox1.Controls.Add(Me.Search)
        Me.GroupBox1.Controls.Add(Me.IDIn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.QtyIn)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.Info.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.Info.SetToolTip(Me.DateTimePicker1, resources.GetString("DateTimePicker1.ToolTip"))
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.Info.SetToolTip(Me.OKButton, resources.GetString("OKButton.ToolTip"))
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Search
        '
        resources.ApplyResources(Me.Search, "Search")
        Me.Search.Name = "Search"
        Me.Info.SetToolTip(Me.Search, resources.GetString("Search.ToolTip"))
        Me.Search.UseVisualStyleBackColor = True
        '
        'IDIn
        '
        resources.ApplyResources(Me.IDIn, "IDIn")
        Me.IDIn.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.IDIn.Name = "IDIn"
        Me.Info.SetToolTip(Me.IDIn, resources.GetString("IDIn.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.Info.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.Info.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'QtyIn
        '
        resources.ApplyResources(Me.QtyIn, "QtyIn")
        Me.QtyIn.Name = "QtyIn"
        Me.Info.SetToolTip(Me.QtyIn, resources.GetString("QtyIn.ToolTip"))
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDHeader, Me.BullHeader, Me.DateHeader})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Name = "ListView1"
        Me.Info.SetToolTip(Me.ListView1, resources.GetString("ListView1.ToolTip"))
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'IDHeader
        '
        resources.ApplyResources(Me.IDHeader, "IDHeader")
        '
        'BullHeader
        '
        resources.ApplyResources(Me.BullHeader, "BullHeader")
        '
        'DateHeader
        '
        resources.ApplyResources(Me.DateHeader, "DateHeader")
        '
        'Semen
        '
        Me.AcceptButton = Me.OKButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Semen"
        Me.Info.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.IDIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QtyIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents IDIn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents QtyIn As System.Windows.Forms.NumericUpDown
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BullHeader As ColumnHeader
    Friend WithEvents DateHeader As ColumnHeader
    Friend WithEvents Info As ToolTip
    Friend WithEvents IDHeader As ColumnHeader
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
