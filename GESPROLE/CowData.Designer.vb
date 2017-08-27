Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CowData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CowData))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Data = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.State = New System.Windows.Forms.TextBox()
        Me.Pes = New System.Windows.Forms.NumericUpDown()
        Me.Raz = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Nac = New System.Windows.Forms.TextBox()
        Me.Nom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BackgroundLabel = New System.Windows.Forms.Label()
        Me.Background = New System.Windows.Forms.TextBox()
        Me.Papa = New System.Windows.Forms.TextBox()
        Me.Mama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Evt = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DateHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EvtHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ctrl = New System.Windows.Forms.TabPage()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TimeHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OrdeneOneHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OrdeneTwoHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OrdeneThreeHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProtHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FatHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LactHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SomCelHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WaterHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BactHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CtrlHistory = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarEventoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Loading_Label = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.Data.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Pes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Evt.SuspendLayout()
        Me.Ctrl.SuspendLayout()
        CType(Me.CtrlHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.Data)
        Me.TabControl1.Controls.Add(Me.Evt)
        Me.TabControl1.Controls.Add(Me.Ctrl)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'Data
        '
        resources.ApplyResources(Me.Data, "Data")
        Me.Data.Controls.Add(Me.GroupBox2)
        Me.Data.Controls.Add(Me.GroupBox1)
        Me.Data.Controls.Add(Me.PictureBox1)
        Me.Data.Name = "Data"
        Me.Data.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.State)
        Me.GroupBox2.Controls.Add(Me.Pes)
        Me.GroupBox2.Controls.Add(Me.Raz)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Nac)
        Me.GroupBox2.Controls.Add(Me.Nom)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'State
        '
        resources.ApplyResources(Me.State, "State")
        Me.State.BackColor = System.Drawing.Color.White
        Me.State.ForeColor = System.Drawing.SystemColors.WindowText
        Me.State.Name = "State"
        '
        'Pes
        '
        resources.ApplyResources(Me.Pes, "Pes")
        Me.Pes.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.Pes.Name = "Pes"
        '
        'Raz
        '
        resources.ApplyResources(Me.Raz, "Raz")
        Me.Raz.BackColor = System.Drawing.Color.White
        Me.Raz.Name = "Raz"
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
        'Nac
        '
        resources.ApplyResources(Me.Nac, "Nac")
        Me.Nac.BackColor = System.Drawing.Color.White
        Me.Nac.Name = "Nac"
        '
        'Nom
        '
        resources.ApplyResources(Me.Nom, "Nom")
        Me.Nom.BackColor = System.Drawing.Color.White
        Me.Nom.Name = "Nom"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.BackgroundLabel)
        Me.GroupBox1.Controls.Add(Me.Background)
        Me.GroupBox1.Controls.Add(Me.Papa)
        Me.GroupBox1.Controls.Add(Me.Mama)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'BackgroundLabel
        '
        resources.ApplyResources(Me.BackgroundLabel, "BackgroundLabel")
        Me.BackgroundLabel.Name = "BackgroundLabel"
        '
        'Background
        '
        resources.ApplyResources(Me.Background, "Background")
        Me.Background.BackColor = System.Drawing.Color.White
        Me.Background.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Background.Name = "Background"
        '
        'Papa
        '
        resources.ApplyResources(Me.Papa, "Papa")
        Me.Papa.BackColor = System.Drawing.Color.White
        Me.Papa.Name = "Papa"
        '
        'Mama
        '
        resources.ApplyResources(Me.Mama, "Mama")
        Me.Mama.BackColor = System.Drawing.Color.White
        Me.Mama.Name = "Mama"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.GESPROLE.My.Resources.Resources.Caravana3
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = ""
        '
        'Evt
        '
        resources.ApplyResources(Me.Evt, "Evt")
        Me.Evt.Controls.Add(Me.ListView1)
        Me.Evt.Name = "Evt"
        Me.Evt.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DateHeader, Me.EvtHeader})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DateHeader
        '
        resources.ApplyResources(Me.DateHeader, "DateHeader")
        '
        'EvtHeader
        '
        resources.ApplyResources(Me.EvtHeader, "EvtHeader")
        '
        'Ctrl
        '
        resources.ApplyResources(Me.Ctrl, "Ctrl")
        Me.Ctrl.Controls.Add(Me.ListView2)
        Me.Ctrl.Controls.Add(Me.CtrlHistory)
        Me.Ctrl.Name = "Ctrl"
        Me.Ctrl.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        resources.ApplyResources(Me.ListView2, "ListView2")
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TimeHeader, Me.OrdeneOneHeader, Me.OrdeneTwoHeader, Me.OrdeneThreeHeader, Me.ProtHeader, Me.FatHeader, Me.LactHeader, Me.SomCelHeader, Me.WaterHeader, Me.BactHeader})
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Name = "ListView2"
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'TimeHeader
        '
        resources.ApplyResources(Me.TimeHeader, "TimeHeader")
        '
        'OrdeneOneHeader
        '
        resources.ApplyResources(Me.OrdeneOneHeader, "OrdeneOneHeader")
        '
        'OrdeneTwoHeader
        '
        resources.ApplyResources(Me.OrdeneTwoHeader, "OrdeneTwoHeader")
        '
        'OrdeneThreeHeader
        '
        resources.ApplyResources(Me.OrdeneThreeHeader, "OrdeneThreeHeader")
        '
        'ProtHeader
        '
        resources.ApplyResources(Me.ProtHeader, "ProtHeader")
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
        'CtrlHistory
        '
        resources.ApplyResources(Me.CtrlHistory, "CtrlHistory")
        ChartArea1.Name = "ChartArea1"
        Me.CtrlHistory.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.CtrlHistory.Legends.Add(Legend1)
        Me.CtrlHistory.Name = "CtrlHistory"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.CtrlHistory.Series.Add(Series1)
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarEventoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'EliminarEventoToolStripMenuItem
        '
        resources.ApplyResources(Me.EliminarEventoToolStripMenuItem, "EliminarEventoToolStripMenuItem")
        Me.EliminarEventoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Delete
        Me.EliminarEventoToolStripMenuItem.Name = "EliminarEventoToolStripMenuItem"
        '
        'Loading_Label
        '
        resources.ApplyResources(Me.Loading_Label, "Loading_Label")
        Me.Loading_Label.Name = "Loading_Label"
        '
        'CowData
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Loading_Label)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CowData"
        Me.TabControl1.ResumeLayout(False)
        Me.Data.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Pes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Evt.ResumeLayout(False)
        Me.Ctrl.ResumeLayout(False)
        CType(Me.CtrlHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Data As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Raz As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Nac As System.Windows.Forms.TextBox
    Friend WithEvents Nom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Papa As System.Windows.Forms.TextBox
    Friend WithEvents Mama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Evt As System.Windows.Forms.TabPage
    Friend WithEvents Ctrl As System.Windows.Forms.TabPage
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents CtrlHistory As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents DateHeader As ColumnHeader
    Friend WithEvents EvtHeader As ColumnHeader
    Friend WithEvents OrdeneOneHeader As ColumnHeader
    Friend WithEvents ProtHeader As ColumnHeader
    Friend WithEvents SomCelHeader As ColumnHeader
    Friend WithEvents FatHeader As ColumnHeader
    Friend WithEvents LactHeader As ColumnHeader
    Friend WithEvents WaterHeader As ColumnHeader
    Friend WithEvents BactHeader As ColumnHeader
    Friend WithEvents Pes As NumericUpDown
    Friend WithEvents OrdeneTwoHeader As ColumnHeader
    Friend WithEvents OrdeneThreeHeader As ColumnHeader
    Friend WithEvents State As TextBox
    Friend WithEvents BackgroundLabel As Label
    Friend WithEvents Background As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EliminarEventoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimeHeader As ColumnHeader
    Friend WithEvents Loading_Label As Label
End Class
