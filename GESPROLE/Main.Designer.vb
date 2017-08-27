Imports System.Globalization
Imports System.Resources
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Prom_Edad = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Tasa_Repo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Prom_Prot = New System.Windows.Forms.TextBox()
        Me.Prod_Ha = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Tasa_Paricion = New System.Windows.Forms.TextBox()
        Me.Tasa_Prenadas = New System.Windows.Forms.TextBox()
        Me.Vacias = New System.Windows.Forms.TextBox()
        Me.Prenadas = New System.Windows.Forms.TextBox()
        Me.Recria = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Prom_Lact = New System.Windows.Forms.TextBox()
        Me.Prom_Rec_Bac = New System.Windows.Forms.TextBox()
        Me.Prom_SMB = New System.Windows.Forms.TextBox()
        Me.Prom_Cel_Som = New System.Windows.Forms.TextBox()
        Me.Prom_Grasa = New System.Windows.Forms.TextBox()
        Me.Prod_Diaria = New System.Windows.Forms.TextBox()
        Me.Vacas = New System.Windows.Forms.TextBox()
        Me.Vaquillonas = New System.Windows.Forms.TextBox()
        Me.Secas = New System.Windows.Forms.TextBox()
        Me.EnOrdene = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Select_Tambo = New System.Windows.Forms.ComboBox()
        Me.Distro = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Prod_Curve = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarTamboToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerInformaciónDeEstablecimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnimalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EventoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbortoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnálisisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnfermedadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdaACampoDeRecríaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedicaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MuerteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechazoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SecadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TactoRectalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoteoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TorosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EventoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SemenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlesLecherosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VacasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VacasLactandoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VacasSecasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VaquillonasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ASecarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AParirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ATactarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GESPROLEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.LoginInfo = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.LogOutButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewEstablishmentButton = New System.Windows.Forms.ToolStripButton()
        Me.ViewEstablishmentDataButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegisterCowButton = New System.Windows.Forms.ToolStripButton()
        Me.SearchCowButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LotButton = New System.Windows.Forms.ToolStripButton()
        Me.MilkControlButton = New System.Windows.Forms.ToolStripButton()
        Me.NotificationButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateUserButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfigButton = New System.Windows.Forms.ToolStripButton()
        Me.InfoButton = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Distro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prod_Curve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Prom_Edad)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Tasa_Repo)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Prom_Prot)
        Me.GroupBox1.Controls.Add(Me.Prod_Ha)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Tasa_Paricion)
        Me.GroupBox1.Controls.Add(Me.Tasa_Prenadas)
        Me.GroupBox1.Controls.Add(Me.Vacias)
        Me.GroupBox1.Controls.Add(Me.Prenadas)
        Me.GroupBox1.Controls.Add(Me.Recria)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Prom_Lact)
        Me.GroupBox1.Controls.Add(Me.Prom_Rec_Bac)
        Me.GroupBox1.Controls.Add(Me.Prom_SMB)
        Me.GroupBox1.Controls.Add(Me.Prom_Cel_Som)
        Me.GroupBox1.Controls.Add(Me.Prom_Grasa)
        Me.GroupBox1.Controls.Add(Me.Prod_Diaria)
        Me.GroupBox1.Controls.Add(Me.Vacas)
        Me.GroupBox1.Controls.Add(Me.Vaquillonas)
        Me.GroupBox1.Controls.Add(Me.Secas)
        Me.GroupBox1.Controls.Add(Me.EnOrdene)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Prom_Edad
        '
        Me.Prom_Edad.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Edad, "Prom_Edad")
        Me.Prom_Edad.Name = "Prom_Edad"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'Tasa_Repo
        '
        Me.Tasa_Repo.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Tasa_Repo, "Tasa_Repo")
        Me.Tasa_Repo.Name = "Tasa_Repo"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Prom_Prot
        '
        Me.Prom_Prot.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Prot, "Prom_Prot")
        Me.Prom_Prot.Name = "Prom_Prot"
        '
        'Prod_Ha
        '
        Me.Prod_Ha.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prod_Ha, "Prod_Ha")
        Me.Prod_Ha.Name = "Prod_Ha"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Tasa_Paricion
        '
        Me.Tasa_Paricion.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Tasa_Paricion, "Tasa_Paricion")
        Me.Tasa_Paricion.Name = "Tasa_Paricion"
        '
        'Tasa_Prenadas
        '
        Me.Tasa_Prenadas.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Tasa_Prenadas, "Tasa_Prenadas")
        Me.Tasa_Prenadas.Name = "Tasa_Prenadas"
        '
        'Vacias
        '
        Me.Vacias.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Vacias, "Vacias")
        Me.Vacias.Name = "Vacias"
        '
        'Prenadas
        '
        Me.Prenadas.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prenadas, "Prenadas")
        Me.Prenadas.Name = "Prenadas"
        '
        'Recria
        '
        Me.Recria.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Recria, "Recria")
        Me.Recria.Name = "Recria"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Prom_Lact
        '
        Me.Prom_Lact.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Lact, "Prom_Lact")
        Me.Prom_Lact.Name = "Prom_Lact"
        '
        'Prom_Rec_Bac
        '
        Me.Prom_Rec_Bac.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Rec_Bac, "Prom_Rec_Bac")
        Me.Prom_Rec_Bac.Name = "Prom_Rec_Bac"
        '
        'Prom_SMB
        '
        Me.Prom_SMB.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_SMB, "Prom_SMB")
        Me.Prom_SMB.Name = "Prom_SMB"
        '
        'Prom_Cel_Som
        '
        Me.Prom_Cel_Som.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Cel_Som, "Prom_Cel_Som")
        Me.Prom_Cel_Som.Name = "Prom_Cel_Som"
        '
        'Prom_Grasa
        '
        Me.Prom_Grasa.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prom_Grasa, "Prom_Grasa")
        Me.Prom_Grasa.Name = "Prom_Grasa"
        '
        'Prod_Diaria
        '
        Me.Prod_Diaria.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Prod_Diaria, "Prod_Diaria")
        Me.Prod_Diaria.Name = "Prod_Diaria"
        '
        'Vacas
        '
        Me.Vacas.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Vacas, "Vacas")
        Me.Vacas.Name = "Vacas"
        '
        'Vaquillonas
        '
        Me.Vaquillonas.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Vaquillonas, "Vaquillonas")
        Me.Vaquillonas.Name = "Vaquillonas"
        '
        'Secas
        '
        Me.Secas.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Secas, "Secas")
        Me.Secas.Name = "Secas"
        '
        'EnOrdene
        '
        Me.EnOrdene.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.EnOrdene, "EnOrdene")
        Me.EnOrdene.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnOrdene.Name = "EnOrdene"
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
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Select_Tambo)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Select_Tambo
        '
        Me.Select_Tambo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Select_Tambo, "Select_Tambo")
        Me.Select_Tambo.FormattingEnabled = True
        Me.Select_Tambo.Name = "Select_Tambo"
        '
        'Distro
        '
        Me.Distro.BackColor = System.Drawing.SystemColors.Control
        ChartArea1.BackColor = System.Drawing.SystemColors.Control
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Distro.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Name = "Legend1"
        Me.Distro.Legends.Add(Legend1)
        resources.ApplyResources(Me.Distro, "Distro")
        Me.Distro.Name = "Distro"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Distro.Series.Add(Series1)
        Me.Info.SetToolTip(Me.Distro, resources.GetString("Distro.ToolTip"))
        '
        'Prod_Curve
        '
        Me.Prod_Curve.BackColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea2.BackColor = System.Drawing.Color.White
        ChartArea2.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea2.Name = "ChartArea1"
        Me.Prod_Curve.ChartAreas.Add(ChartArea2)
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Name = "Legend1"
        Me.Prod_Curve.Legends.Add(Legend2)
        resources.ApplyResources(Me.Prod_Curve, "Prod_Curve")
        Me.Prod_Curve.Name = "Prod_Curve"
        Me.Info.SetToolTip(Me.Prod_Curve, resources.GetString("Prod_Curve.ToolTip"))
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.AnimalesToolStripMenuItem, Me.ControlesLecherosToolStripMenuItem, Me.ListadosToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarTamboToolStripMenuItem, Me.VerInformaciónDeEstablecimientoToolStripMenuItem, Me.ToolStripMenuItem2, Me.ConfiguraciónToolStripMenuItem, Me.CerrarSesiónToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        resources.ApplyResources(Me.ArchivoToolStripMenuItem, "ArchivoToolStripMenuItem")
        '
        'RegistrarTamboToolStripMenuItem
        '
        Me.RegistrarTamboToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Extract
        Me.RegistrarTamboToolStripMenuItem.Name = "RegistrarTamboToolStripMenuItem"
        resources.ApplyResources(Me.RegistrarTamboToolStripMenuItem, "RegistrarTamboToolStripMenuItem")
        '
        'VerInformaciónDeEstablecimientoToolStripMenuItem
        '
        Me.VerInformaciónDeEstablecimientoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.View
        Me.VerInformaciónDeEstablecimientoToolStripMenuItem.Name = "VerInformaciónDeEstablecimientoToolStripMenuItem"
        resources.ApplyResources(Me.VerInformaciónDeEstablecimientoToolStripMenuItem, "VerInformaciónDeEstablecimientoToolStripMenuItem")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Repair
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        resources.ApplyResources(Me.ConfiguraciónToolStripMenuItem, "ConfiguraciónToolStripMenuItem")
        '
        'CerrarSesiónToolStripMenuItem
        '
        Me.CerrarSesiónToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources._Exit
        Me.CerrarSesiónToolStripMenuItem.Name = "CerrarSesiónToolStripMenuItem"
        resources.ApplyResources(Me.CerrarSesiónToolStripMenuItem, "CerrarSesiónToolStripMenuItem")
        '
        'AnimalesToolStripMenuItem
        '
        Me.AnimalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.EventoToolStripMenuItem, Me.LoteoToolStripMenuItem, Me.ToolStripMenuItem3, Me.TorosToolStripMenuItem})
        Me.AnimalesToolStripMenuItem.Name = "AnimalesToolStripMenuItem"
        resources.ApplyResources(Me.AnimalesToolStripMenuItem, "AnimalesToolStripMenuItem")
        '
        'RegistrarToolStripMenuItem
        '
        Me.RegistrarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Add
        Me.RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem"
        resources.ApplyResources(Me.RegistrarToolStripMenuItem, "RegistrarToolStripMenuItem")
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Find
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        resources.ApplyResources(Me.BuscarToolStripMenuItem, "BuscarToolStripMenuItem")
        '
        'EventoToolStripMenuItem
        '
        Me.EventoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbortoToolStripMenuItem, Me.AnálisisToolStripMenuItem, Me.EnfermedadToolStripMenuItem, Me.IdaACampoDeRecríaToolStripMenuItem, Me.MedicaciónToolStripMenuItem, Me.MuerteToolStripMenuItem, Me.PartoToolStripMenuItem, Me.RechazoToolStripMenuItem, Me.SecadoToolStripMenuItem, Me.ServicioToolStripMenuItem, Me.TactoRectalToolStripMenuItem, Me.VentaToolStripMenuItem})
        Me.EventoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Comment
        Me.EventoToolStripMenuItem.Name = "EventoToolStripMenuItem"
        resources.ApplyResources(Me.EventoToolStripMenuItem, "EventoToolStripMenuItem")
        '
        'AbortoToolStripMenuItem
        '
        Me.AbortoToolStripMenuItem.Name = "AbortoToolStripMenuItem"
        resources.ApplyResources(Me.AbortoToolStripMenuItem, "AbortoToolStripMenuItem")
        '
        'AnálisisToolStripMenuItem
        '
        Me.AnálisisToolStripMenuItem.Name = "AnálisisToolStripMenuItem"
        resources.ApplyResources(Me.AnálisisToolStripMenuItem, "AnálisisToolStripMenuItem")
        '
        'EnfermedadToolStripMenuItem
        '
        Me.EnfermedadToolStripMenuItem.Name = "EnfermedadToolStripMenuItem"
        resources.ApplyResources(Me.EnfermedadToolStripMenuItem, "EnfermedadToolStripMenuItem")
        '
        'IdaACampoDeRecríaToolStripMenuItem
        '
        Me.IdaACampoDeRecríaToolStripMenuItem.Name = "IdaACampoDeRecríaToolStripMenuItem"
        resources.ApplyResources(Me.IdaACampoDeRecríaToolStripMenuItem, "IdaACampoDeRecríaToolStripMenuItem")
        '
        'MedicaciónToolStripMenuItem
        '
        Me.MedicaciónToolStripMenuItem.Name = "MedicaciónToolStripMenuItem"
        resources.ApplyResources(Me.MedicaciónToolStripMenuItem, "MedicaciónToolStripMenuItem")
        '
        'MuerteToolStripMenuItem
        '
        Me.MuerteToolStripMenuItem.Name = "MuerteToolStripMenuItem"
        resources.ApplyResources(Me.MuerteToolStripMenuItem, "MuerteToolStripMenuItem")
        '
        'PartoToolStripMenuItem
        '
        Me.PartoToolStripMenuItem.Name = "PartoToolStripMenuItem"
        resources.ApplyResources(Me.PartoToolStripMenuItem, "PartoToolStripMenuItem")
        '
        'RechazoToolStripMenuItem
        '
        Me.RechazoToolStripMenuItem.Name = "RechazoToolStripMenuItem"
        resources.ApplyResources(Me.RechazoToolStripMenuItem, "RechazoToolStripMenuItem")
        '
        'SecadoToolStripMenuItem
        '
        Me.SecadoToolStripMenuItem.Name = "SecadoToolStripMenuItem"
        resources.ApplyResources(Me.SecadoToolStripMenuItem, "SecadoToolStripMenuItem")
        '
        'ServicioToolStripMenuItem
        '
        Me.ServicioToolStripMenuItem.Name = "ServicioToolStripMenuItem"
        resources.ApplyResources(Me.ServicioToolStripMenuItem, "ServicioToolStripMenuItem")
        '
        'TactoRectalToolStripMenuItem
        '
        Me.TactoRectalToolStripMenuItem.Name = "TactoRectalToolStripMenuItem"
        resources.ApplyResources(Me.TactoRectalToolStripMenuItem, "TactoRectalToolStripMenuItem")
        '
        'VentaToolStripMenuItem
        '
        Me.VentaToolStripMenuItem.Name = "VentaToolStripMenuItem"
        resources.ApplyResources(Me.VentaToolStripMenuItem, "VentaToolStripMenuItem")
        '
        'LoteoToolStripMenuItem
        '
        Me.LoteoToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Test
        Me.LoteoToolStripMenuItem.Name = "LoteoToolStripMenuItem"
        resources.ApplyResources(Me.LoteoToolStripMenuItem, "LoteoToolStripMenuItem")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'TorosToolStripMenuItem
        '
        Me.TorosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroToolStripMenuItem, Me.BuscarToolStripMenuItem1, Me.EventoToolStripMenuItem1, Me.ToolStripMenuItem1, Me.SemenToolStripMenuItem})
        Me.TorosToolStripMenuItem.Name = "TorosToolStripMenuItem"
        resources.ApplyResources(Me.TorosToolStripMenuItem, "TorosToolStripMenuItem")
        '
        'RegistroToolStripMenuItem
        '
        Me.RegistroToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Add
        Me.RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem"
        resources.ApplyResources(Me.RegistroToolStripMenuItem, "RegistroToolStripMenuItem")
        '
        'BuscarToolStripMenuItem1
        '
        Me.BuscarToolStripMenuItem1.Image = Global.GESPROLE.My.Resources.Resources.Find
        Me.BuscarToolStripMenuItem1.Name = "BuscarToolStripMenuItem1"
        resources.ApplyResources(Me.BuscarToolStripMenuItem1, "BuscarToolStripMenuItem1")
        '
        'EventoToolStripMenuItem1
        '
        Me.EventoToolStripMenuItem1.Image = Global.GESPROLE.My.Resources.Resources.Comment
        Me.EventoToolStripMenuItem1.Name = "EventoToolStripMenuItem1"
        resources.ApplyResources(Me.EventoToolStripMenuItem1, "EventoToolStripMenuItem1")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'SemenToolStripMenuItem
        '
        Me.SemenToolStripMenuItem.Name = "SemenToolStripMenuItem"
        resources.ApplyResources(Me.SemenToolStripMenuItem, "SemenToolStripMenuItem")
        '
        'ControlesLecherosToolStripMenuItem
        '
        Me.ControlesLecherosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarToolStripMenuItem, Me.VerToolStripMenuItem})
        Me.ControlesLecherosToolStripMenuItem.Name = "ControlesLecherosToolStripMenuItem"
        resources.ApplyResources(Me.ControlesLecherosToolStripMenuItem, "ControlesLecherosToolStripMenuItem")
        '
        'GenerarToolStripMenuItem
        '
        Me.GenerarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Report
        Me.GenerarToolStripMenuItem.Name = "GenerarToolStripMenuItem"
        resources.ApplyResources(Me.GenerarToolStripMenuItem, "GenerarToolStripMenuItem")
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.View
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        resources.ApplyResources(Me.VerToolStripMenuItem, "VerToolStripMenuItem")
        '
        'ListadosToolStripMenuItem
        '
        Me.ListadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VacasToolStripMenuItem, Me.VacasLactandoToolStripMenuItem, Me.VacasSecasToolStripMenuItem, Me.VaquillonasToolStripMenuItem, Me.ASecarToolStripMenuItem, Me.AParirToolStripMenuItem, Me.ATactarToolStripMenuItem})
        Me.ListadosToolStripMenuItem.Name = "ListadosToolStripMenuItem"
        resources.ApplyResources(Me.ListadosToolStripMenuItem, "ListadosToolStripMenuItem")
        '
        'VacasToolStripMenuItem
        '
        Me.VacasToolStripMenuItem.Name = "VacasToolStripMenuItem"
        resources.ApplyResources(Me.VacasToolStripMenuItem, "VacasToolStripMenuItem")
        '
        'VacasLactandoToolStripMenuItem
        '
        Me.VacasLactandoToolStripMenuItem.Name = "VacasLactandoToolStripMenuItem"
        resources.ApplyResources(Me.VacasLactandoToolStripMenuItem, "VacasLactandoToolStripMenuItem")
        '
        'VacasSecasToolStripMenuItem
        '
        Me.VacasSecasToolStripMenuItem.Name = "VacasSecasToolStripMenuItem"
        resources.ApplyResources(Me.VacasSecasToolStripMenuItem, "VacasSecasToolStripMenuItem")
        '
        'VaquillonasToolStripMenuItem
        '
        Me.VaquillonasToolStripMenuItem.Name = "VaquillonasToolStripMenuItem"
        resources.ApplyResources(Me.VaquillonasToolStripMenuItem, "VaquillonasToolStripMenuItem")
        '
        'ASecarToolStripMenuItem
        '
        Me.ASecarToolStripMenuItem.Name = "ASecarToolStripMenuItem"
        resources.ApplyResources(Me.ASecarToolStripMenuItem, "ASecarToolStripMenuItem")
        '
        'AParirToolStripMenuItem
        '
        Me.AParirToolStripMenuItem.Name = "AParirToolStripMenuItem"
        resources.ApplyResources(Me.AParirToolStripMenuItem, "AParirToolStripMenuItem")
        '
        'ATactarToolStripMenuItem
        '
        Me.ATactarToolStripMenuItem.Name = "ATactarToolStripMenuItem"
        resources.ApplyResources(Me.ATactarToolStripMenuItem, "ATactarToolStripMenuItem")
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem1, Me.EditarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        resources.ApplyResources(Me.UsuariosToolStripMenuItem, "UsuariosToolStripMenuItem")
        '
        'RegistrarToolStripMenuItem1
        '
        Me.RegistrarToolStripMenuItem1.Image = Global.GESPROLE.My.Resources.Resources.Wizard
        Me.RegistrarToolStripMenuItem1.Name = "RegistrarToolStripMenuItem1"
        resources.ApplyResources(Me.RegistrarToolStripMenuItem1, "RegistrarToolStripMenuItem1")
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Report
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        resources.ApplyResources(Me.EditarToolStripMenuItem, "EditarToolStripMenuItem")
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Delete
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        resources.ApplyResources(Me.EliminarToolStripMenuItem, "EliminarToolStripMenuItem")
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GESPROLEToolStripMenuItem})
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        resources.ApplyResources(Me.AcercaDeToolStripMenuItem, "AcercaDeToolStripMenuItem")
        '
        'GESPROLEToolStripMenuItem
        '
        Me.GESPROLEToolStripMenuItem.Image = Global.GESPROLE.My.Resources.Resources.Info
        Me.GESPROLEToolStripMenuItem.Name = "GESPROLEToolStripMenuItem"
        resources.ApplyResources(Me.GESPROLEToolStripMenuItem, "GESPROLEToolStripMenuItem")
        '
        'Info
        '
        Me.Info.AutoPopDelay = 5000
        Me.Info.InitialDelay = 500
        Me.Info.ReshowDelay = 100
        '
        'LoginInfo
        '
        resources.ApplyResources(Me.LoginInfo, "LoginInfo")
        Me.LoginInfo.Name = "LoginInfo"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutButton, Me.ToolStripSeparator3, Me.NewEstablishmentButton, Me.ViewEstablishmentDataButton, Me.ToolStripSeparator4, Me.RegisterCowButton, Me.SearchCowButton, Me.ToolStripSeparator1, Me.LotButton, Me.MilkControlButton, Me.NotificationButton, Me.ToolStripSeparator2, Me.CreateUserButton, Me.ToolStripSeparator5, Me.ConfigButton, Me.InfoButton})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'LogOutButton
        '
        Me.LogOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LogOutButton.Image = Global.GESPROLE.My.Resources.Resources._Exit
        resources.ApplyResources(Me.LogOutButton, "LogOutButton")
        Me.LogOutButton.Name = "LogOutButton"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'NewEstablishmentButton
        '
        Me.NewEstablishmentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewEstablishmentButton.Image = Global.GESPROLE.My.Resources.Resources.Extract
        resources.ApplyResources(Me.NewEstablishmentButton, "NewEstablishmentButton")
        Me.NewEstablishmentButton.Name = "NewEstablishmentButton"
        '
        'ViewEstablishmentDataButton
        '
        Me.ViewEstablishmentDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ViewEstablishmentDataButton.Image = Global.GESPROLE.My.Resources.Resources.View
        resources.ApplyResources(Me.ViewEstablishmentDataButton, "ViewEstablishmentDataButton")
        Me.ViewEstablishmentDataButton.Name = "ViewEstablishmentDataButton"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'RegisterCowButton
        '
        Me.RegisterCowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RegisterCowButton.Image = Global.GESPROLE.My.Resources.Resources.Add
        resources.ApplyResources(Me.RegisterCowButton, "RegisterCowButton")
        Me.RegisterCowButton.Name = "RegisterCowButton"
        '
        'SearchCowButton
        '
        Me.SearchCowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SearchCowButton.Image = Global.GESPROLE.My.Resources.Resources.Find
        resources.ApplyResources(Me.SearchCowButton, "SearchCowButton")
        Me.SearchCowButton.Name = "SearchCowButton"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'LotButton
        '
        Me.LotButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LotButton.Image = Global.GESPROLE.My.Resources.Resources.Test
        resources.ApplyResources(Me.LotButton, "LotButton")
        Me.LotButton.Name = "LotButton"
        '
        'MilkControlButton
        '
        Me.MilkControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MilkControlButton.Image = Global.GESPROLE.My.Resources.Resources.Report
        resources.ApplyResources(Me.MilkControlButton, "MilkControlButton")
        Me.MilkControlButton.Name = "MilkControlButton"
        '
        'NotificationButton
        '
        Me.NotificationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NotificationButton.Image = Global.GESPROLE.My.Resources.Resources.notiBlack
        resources.ApplyResources(Me.NotificationButton, "NotificationButton")
        Me.NotificationButton.Name = "NotificationButton"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'CreateUserButton
        '
        Me.CreateUserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CreateUserButton.Image = Global.GESPROLE.My.Resources.Resources.Wizard
        resources.ApplyResources(Me.CreateUserButton, "CreateUserButton")
        Me.CreateUserButton.Name = "CreateUserButton"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'ConfigButton
        '
        Me.ConfigButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConfigButton.Image = Global.GESPROLE.My.Resources.Resources.Repair
        resources.ApplyResources(Me.ConfigButton, "ConfigButton")
        Me.ConfigButton.Name = "ConfigButton"
        '
        'InfoButton
        '
        Me.InfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InfoButton.Image = Global.GESPROLE.My.Resources.Resources.Info
        resources.ApplyResources(Me.InfoButton, "InfoButton")
        Me.InfoButton.Name = "InfoButton"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GESPROLE.My.Resources.Resources.Cow
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LoginInfo)
        Me.Controls.Add(Me.Prod_Curve)
        Me.Controls.Add(Me.Distro)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Distro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prod_Curve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tasa_Paricion As System.Windows.Forms.TextBox
    Friend WithEvents Tasa_Prenadas As System.Windows.Forms.TextBox
    Friend WithEvents Vacias As System.Windows.Forms.TextBox
    Friend WithEvents Prenadas As System.Windows.Forms.TextBox
    Friend WithEvents Recria As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Prom_Lact As System.Windows.Forms.TextBox
    Friend WithEvents Prom_Rec_Bac As System.Windows.Forms.TextBox
    Friend WithEvents Prom_SMB As System.Windows.Forms.TextBox
    Friend WithEvents Prom_Cel_Som As System.Windows.Forms.TextBox
    Friend WithEvents Prom_Grasa As System.Windows.Forms.TextBox
    Friend WithEvents Prod_Diaria As System.Windows.Forms.TextBox
    Friend WithEvents Vacas As System.Windows.Forms.TextBox
    Friend WithEvents Vaquillonas As System.Windows.Forms.TextBox
    Friend WithEvents Secas As System.Windows.Forms.TextBox
    Friend WithEvents EnOrdene As System.Windows.Forms.TextBox
    Friend WithEvents Prom_Edad As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tasa_Repo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Prom_Prot As System.Windows.Forms.TextBox
    Friend WithEvents Prod_Ha As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Select_Tambo As System.Windows.Forms.ComboBox
    Friend WithEvents Distro As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Prod_Curve As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnimalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbortoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnálisisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnfermedadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MuerteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechazoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServicioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TactoRectalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoteoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TorosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SemenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlesLecherosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacasLactandoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacasSecasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VaquillonasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ASecarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AParirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ATactarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GESPROLEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IdaACampoDeRecríaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Info As ToolTip
    Friend WithEvents EventoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RegistrarTamboToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerInformaciónDeEstablecimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoginInfo As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents MedicaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterCowButton As ToolStripButton
    Friend WithEvents SearchCowButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MilkControlButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents InfoButton As ToolStripButton
    Friend WithEvents LogOutButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents NewEstablishmentButton As ToolStripButton
    Friend WithEvents ViewEstablishmentDataButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents CreateUserButton As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ConfigButton As ToolStripButton
    Friend WithEvents LotButton As ToolStripButton
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents NotificationButton As ToolStripButton
End Class