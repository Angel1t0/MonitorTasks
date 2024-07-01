<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionDashboard
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.panelDash = New System.Windows.Forms.Panel()
        Me.ControlPanel4 = New MonitorTasks.ControlPanel()
        Me.btnUsuarioPodio = New System.Windows.Forms.Button()
        Me.btnUsuarioBD = New System.Windows.Forms.Button()
        Me.btnFinalizadaPodio = New System.Windows.Forms.Button()
        Me.btnFinalizadaBD = New System.Windows.Forms.Button()
        Me.btnCreadaPodio = New System.Windows.Forms.Button()
        Me.btnCreadaBD = New System.Windows.Forms.Button()
        Me.btnPendientePodio = New System.Windows.Forms.Button()
        Me.btnPendienteBD = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ControlPanel3 = New MonitorTasks.ControlPanel()
        Me.chartItemsPorArea = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ControlPanel2 = New MonitorTasks.ControlPanel()
        Me.chartItemPorStatus = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ControlPanel1 = New MonitorTasks.ControlPanel()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelDash.SuspendLayout()
        Me.ControlPanel4.SuspendLayout()
        Me.ControlPanel3.SuspendLayout()
        CType(Me.chartItemsPorArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel2.SuspendLayout()
        CType(Me.chartItemPorStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel1.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelDash
        '
        Me.panelDash.Controls.Add(Me.ControlPanel4)
        Me.panelDash.Controls.Add(Me.ControlPanel3)
        Me.panelDash.Controls.Add(Me.ControlPanel2)
        Me.panelDash.Controls.Add(Me.ControlPanel1)
        Me.panelDash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelDash.Location = New System.Drawing.Point(0, 0)
        Me.panelDash.Name = "panelDash"
        Me.panelDash.Size = New System.Drawing.Size(1159, 683)
        Me.panelDash.TabIndex = 0
        '
        'ControlPanel4
        '
        Me.ControlPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ControlPanel4.BorderRadius = 5
        Me.ControlPanel4.Controls.Add(Me.btnUsuarioPodio)
        Me.ControlPanel4.Controls.Add(Me.btnUsuarioBD)
        Me.ControlPanel4.Controls.Add(Me.btnFinalizadaPodio)
        Me.ControlPanel4.Controls.Add(Me.btnFinalizadaBD)
        Me.ControlPanel4.Controls.Add(Me.btnCreadaPodio)
        Me.ControlPanel4.Controls.Add(Me.btnCreadaBD)
        Me.ControlPanel4.Controls.Add(Me.btnPendientePodio)
        Me.ControlPanel4.Controls.Add(Me.btnPendienteBD)
        Me.ControlPanel4.Controls.Add(Me.Label9)
        Me.ControlPanel4.Controls.Add(Me.Label8)
        Me.ControlPanel4.Controls.Add(Me.Label7)
        Me.ControlPanel4.Controls.Add(Me.Label5)
        Me.ControlPanel4.Controls.Add(Me.Label6)
        Me.ControlPanel4.Location = New System.Drawing.Point(523, 412)
        Me.ControlPanel4.Name = "ControlPanel4"
        Me.ControlPanel4.Size = New System.Drawing.Size(624, 257)
        Me.ControlPanel4.TabIndex = 8
        '
        'btnUsuarioPodio
        '
        Me.btnUsuarioPodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btnUsuarioPodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsuarioPodio.Enabled = False
        Me.btnUsuarioPodio.FlatAppearance.BorderSize = 0
        Me.btnUsuarioPodio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuarioPodio.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsuarioPodio.Location = New System.Drawing.Point(441, 198)
        Me.btnUsuarioPodio.Name = "btnUsuarioPodio"
        Me.btnUsuarioPodio.Size = New System.Drawing.Size(120, 33)
        Me.btnUsuarioPodio.TabIndex = 13
        Me.btnUsuarioPodio.Text = "Podio"
        Me.btnUsuarioPodio.UseVisualStyleBackColor = False
        '
        'btnUsuarioBD
        '
        Me.btnUsuarioBD.BackColor = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnUsuarioBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsuarioBD.FlatAppearance.BorderSize = 0
        Me.btnUsuarioBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuarioBD.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsuarioBD.Location = New System.Drawing.Point(306, 198)
        Me.btnUsuarioBD.Name = "btnUsuarioBD"
        Me.btnUsuarioBD.Size = New System.Drawing.Size(120, 33)
        Me.btnUsuarioBD.TabIndex = 12
        Me.btnUsuarioBD.Text = "Base de Datos"
        Me.btnUsuarioBD.UseVisualStyleBackColor = False
        '
        'btnFinalizadaPodio
        '
        Me.btnFinalizadaPodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btnFinalizadaPodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFinalizadaPodio.Enabled = False
        Me.btnFinalizadaPodio.FlatAppearance.BorderSize = 0
        Me.btnFinalizadaPodio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizadaPodio.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizadaPodio.Location = New System.Drawing.Point(441, 155)
        Me.btnFinalizadaPodio.Name = "btnFinalizadaPodio"
        Me.btnFinalizadaPodio.Size = New System.Drawing.Size(120, 33)
        Me.btnFinalizadaPodio.TabIndex = 11
        Me.btnFinalizadaPodio.Text = "Podio"
        Me.btnFinalizadaPodio.UseVisualStyleBackColor = False
        '
        'btnFinalizadaBD
        '
        Me.btnFinalizadaBD.BackColor = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnFinalizadaBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFinalizadaBD.FlatAppearance.BorderSize = 0
        Me.btnFinalizadaBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizadaBD.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizadaBD.Location = New System.Drawing.Point(306, 155)
        Me.btnFinalizadaBD.Name = "btnFinalizadaBD"
        Me.btnFinalizadaBD.Size = New System.Drawing.Size(120, 33)
        Me.btnFinalizadaBD.TabIndex = 10
        Me.btnFinalizadaBD.Text = "Base de Datos"
        Me.btnFinalizadaBD.UseVisualStyleBackColor = False
        '
        'btnCreadaPodio
        '
        Me.btnCreadaPodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btnCreadaPodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreadaPodio.Enabled = False
        Me.btnCreadaPodio.FlatAppearance.BorderSize = 0
        Me.btnCreadaPodio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreadaPodio.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreadaPodio.Location = New System.Drawing.Point(441, 113)
        Me.btnCreadaPodio.Name = "btnCreadaPodio"
        Me.btnCreadaPodio.Size = New System.Drawing.Size(120, 33)
        Me.btnCreadaPodio.TabIndex = 9
        Me.btnCreadaPodio.Text = "Podio"
        Me.btnCreadaPodio.UseVisualStyleBackColor = False
        '
        'btnCreadaBD
        '
        Me.btnCreadaBD.BackColor = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnCreadaBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreadaBD.FlatAppearance.BorderSize = 0
        Me.btnCreadaBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreadaBD.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreadaBD.Location = New System.Drawing.Point(306, 113)
        Me.btnCreadaBD.Name = "btnCreadaBD"
        Me.btnCreadaBD.Size = New System.Drawing.Size(120, 33)
        Me.btnCreadaBD.TabIndex = 8
        Me.btnCreadaBD.Text = "Base de Datos"
        Me.btnCreadaBD.UseVisualStyleBackColor = False
        '
        'btnPendientePodio
        '
        Me.btnPendientePodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.btnPendientePodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPendientePodio.Enabled = False
        Me.btnPendientePodio.FlatAppearance.BorderSize = 0
        Me.btnPendientePodio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendientePodio.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendientePodio.Location = New System.Drawing.Point(441, 70)
        Me.btnPendientePodio.Name = "btnPendientePodio"
        Me.btnPendientePodio.Size = New System.Drawing.Size(120, 33)
        Me.btnPendientePodio.TabIndex = 7
        Me.btnPendientePodio.Text = "Podio"
        Me.btnPendientePodio.UseVisualStyleBackColor = False
        '
        'btnPendienteBD
        '
        Me.btnPendienteBD.BackColor = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnPendienteBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPendienteBD.FlatAppearance.BorderSize = 0
        Me.btnPendienteBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendienteBD.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendienteBD.Location = New System.Drawing.Point(306, 70)
        Me.btnPendienteBD.Name = "btnPendienteBD"
        Me.btnPendienteBD.Size = New System.Drawing.Size(120, 33)
        Me.btnPendienteBD.TabIndex = 6
        Me.btnPendienteBD.Text = "Base de Datos"
        Me.btnPendienteBD.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkOrchid
        Me.Label9.Location = New System.Drawing.Point(90, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 21)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "- Tareas por Usuarios"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.Label8.Location = New System.Drawing.Point(90, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 21)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "- Tareas Finalizadas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label7.Location = New System.Drawing.Point(90, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 21)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "- Tareas Creadas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Coral
        Me.Label5.Location = New System.Drawing.Point(90, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "- Tareas Pendientes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(18, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(211, 27)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Generar Reportes"
        '
        'ControlPanel3
        '
        Me.ControlPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ControlPanel3.BorderRadius = 5
        Me.ControlPanel3.Controls.Add(Me.chartItemsPorArea)
        Me.ControlPanel3.Controls.Add(Me.Label3)
        Me.ControlPanel3.Location = New System.Drawing.Point(523, 13)
        Me.ControlPanel3.Name = "ControlPanel3"
        Me.ControlPanel3.Size = New System.Drawing.Size(624, 383)
        Me.ControlPanel3.TabIndex = 7
        '
        'chartItemsPorArea
        '
        Me.chartItemsPorArea.BackColor = System.Drawing.Color.Transparent
        Me.chartItemsPorArea.BackSecondaryColor = System.Drawing.Color.Transparent
        Me.chartItemsPorArea.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.White
        ChartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.chartItemsPorArea.ChartAreas.Add(ChartArea1)
        Me.chartItemsPorArea.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Name = "Legend1"
        Legend1.TitleForeColor = System.Drawing.Color.White
        Me.chartItemsPorArea.Legends.Add(Legend1)
        Me.chartItemsPorArea.Location = New System.Drawing.Point(0, 95)
        Me.chartItemsPorArea.Name = "chartItemsPorArea"
        Me.chartItemsPorArea.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Me.chartItemsPorArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Series1.ChartArea = "ChartArea1"
        Series1.IsValueShownAsLabel = True
        Series1.LabelForeColor = System.Drawing.Color.White
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartItemsPorArea.Series.Add(Series1)
        Me.chartItemsPorArea.Size = New System.Drawing.Size(624, 288)
        Me.chartItemsPorArea.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(18, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 27)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Actividades por Área"
        '
        'ControlPanel2
        '
        Me.ControlPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ControlPanel2.BorderRadius = 5
        Me.ControlPanel2.Controls.Add(Me.chartItemPorStatus)
        Me.ControlPanel2.Controls.Add(Me.Label4)
        Me.ControlPanel2.Location = New System.Drawing.Point(12, 225)
        Me.ControlPanel2.Name = "ControlPanel2"
        Me.ControlPanel2.Size = New System.Drawing.Size(496, 444)
        Me.ControlPanel2.TabIndex = 6
        '
        'chartItemPorStatus
        '
        Me.chartItemPorStatus.BackColor = System.Drawing.Color.Transparent
        Me.chartItemPorStatus.BackSecondaryColor = System.Drawing.Color.Transparent
        Me.chartItemPorStatus.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.chartItemPorStatus.ChartAreas.Add(ChartArea2)
        Me.chartItemPorStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.ForeColor = System.Drawing.Color.White
        Legend2.Name = "Legend1"
        Me.chartItemPorStatus.Legends.Add(Legend2)
        Me.chartItemPorStatus.Location = New System.Drawing.Point(0, 93)
        Me.chartItemPorStatus.Name = "chartItemPorStatus"
        Me.chartItemPorStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chartItemPorStatus.Series.Add(Series2)
        Me.chartItemPorStatus.Size = New System.Drawing.Size(496, 351)
        Me.chartItemPorStatus.TabIndex = 1
        Me.chartItemPorStatus.Text = "Chart1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(18, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(277, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Actividades por Estatus"
        '
        'ControlPanel1
        '
        Me.ControlPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ControlPanel1.BorderRadius = 5
        Me.ControlPanel1.Controls.Add(Me.IconPictureBox1)
        Me.ControlPanel1.Controls.Add(Me.Label2)
        Me.ControlPanel1.Controls.Add(Me.Label1)
        Me.ControlPanel1.Location = New System.Drawing.Point(12, 13)
        Me.ControlPanel1.Name = "ControlPanel1"
        Me.ControlPanel1.Size = New System.Drawing.Size(496, 197)
        Me.ControlPanel1.TabIndex = 5
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.IconPictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.IconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bullseye
        Me.IconPictureBox1.IconColor = System.Drawing.SystemColors.ControlLight
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox1.IconSize = 151
        Me.IconPictureBox1.Location = New System.Drawing.Point(345, 0)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(151, 197)
        Me.IconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.IconPictureBox1.TabIndex = 2
        Me.IconPictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(46, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 37)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No. Actividades"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total de Actividades"
        '
        'GestionDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1159, 683)
        Me.Controls.Add(Me.panelDash)
        Me.Name = "GestionDashboard"
        Me.Text = "GestionDashboard"
        Me.panelDash.ResumeLayout(False)
        Me.ControlPanel4.ResumeLayout(False)
        Me.ControlPanel4.PerformLayout()
        Me.ControlPanel3.ResumeLayout(False)
        Me.ControlPanel3.PerformLayout()
        CType(Me.chartItemsPorArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel2.ResumeLayout(False)
        Me.ControlPanel2.PerformLayout()
        CType(Me.chartItemPorStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel1.ResumeLayout(False)
        Me.ControlPanel1.PerformLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelDash As Panel
    Friend WithEvents ControlPanel4 As ControlPanel
    Friend WithEvents btnUsuarioPodio As Button
    Friend WithEvents btnUsuarioBD As Button
    Friend WithEvents btnFinalizadaPodio As Button
    Friend WithEvents btnFinalizadaBD As Button
    Friend WithEvents btnCreadaPodio As Button
    Friend WithEvents btnCreadaBD As Button
    Friend WithEvents btnPendientePodio As Button
    Friend WithEvents btnPendienteBD As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ControlPanel3 As ControlPanel
    Friend WithEvents chartItemsPorArea As DataVisualization.Charting.Chart
    Friend WithEvents Label3 As Label
    Friend WithEvents ControlPanel2 As ControlPanel
    Friend WithEvents chartItemPorStatus As DataVisualization.Charting.Chart
    Friend WithEvents Label4 As Label
    Friend WithEvents ControlPanel1 As ControlPanel
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
