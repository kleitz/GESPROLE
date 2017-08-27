Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Config
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VaquillonaIn = New System.Windows.Forms.NumericUpDown()
        Me.PrenadaIn = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AnestroIn = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SecarIn = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PartoPostServIn = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CalostroIn = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.VaquillonaIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrenadaIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnestroIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecarIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartoPostServIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalostroIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'VaquillonaIn
        '
        resources.ApplyResources(Me.VaquillonaIn, "VaquillonaIn")
        Me.VaquillonaIn.Name = "VaquillonaIn"
        '
        'PrenadaIn
        '
        resources.ApplyResources(Me.PrenadaIn, "PrenadaIn")
        Me.PrenadaIn.Name = "PrenadaIn"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'AnestroIn
        '
        resources.ApplyResources(Me.AnestroIn, "AnestroIn")
        Me.AnestroIn.Name = "AnestroIn"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'SecarIn
        '
        resources.ApplyResources(Me.SecarIn, "SecarIn")
        Me.SecarIn.Name = "SecarIn"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'PartoPostServIn
        '
        resources.ApplyResources(Me.PartoPostServIn, "PartoPostServIn")
        Me.PartoPostServIn.Name = "PartoPostServIn"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CalostroIn
        '
        resources.ApplyResources(Me.CalostroIn, "CalostroIn")
        Me.CalostroIn.Name = "CalostroIn"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CalostroIn)
        Me.GroupBox1.Controls.Add(Me.VaquillonaIn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PrenadaIn)
        Me.GroupBox1.Controls.Add(Me.PartoPostServIn)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.AnestroIn)
        Me.GroupBox1.Controls.Add(Me.SecarIn)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Config
        '
        Me.AcceptButton = Me.Button1
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Config"
        CType(Me.VaquillonaIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrenadaIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnestroIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecarIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartoPostServIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalostroIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents VaquillonaIn As NumericUpDown
    Friend WithEvents PrenadaIn As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents AnestroIn As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents SecarIn As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents PartoPostServIn As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CalostroIn As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
