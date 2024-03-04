<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionEventos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEventos))
        Me.dgvDataEventos = New System.Windows.Forms.DataGridView()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.panelEventos = New System.Windows.Forms.Panel()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.pbInsertarEvento = New System.Windows.Forms.PictureBox()
        Me.PanelNotificaciones = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnEnviarAPI = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnActualizarEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVolverAsistente = New System.Windows.Forms.Button()
        Me.btnActualizarNotificacion = New System.Windows.Forms.Button()
        Me.btnEliminarNotificaciones = New System.Windows.Forms.Button()
        Me.comboListaNotificaciones = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numericUpCantidad = New System.Windows.Forms.NumericUpDown()
        Me.comboUnidades = New System.Windows.Forms.ComboBox()
        Me.btnAgregarRecordatorio = New System.Windows.Forms.Button()
        Me.comboMetodoRecordar = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PanelDatosBasicos = New System.Windows.Forms.Panel()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.txtOcurrencias = New System.Windows.Forms.NumericUpDown()
        Me.rbtnFecha = New System.Windows.Forms.RadioButton()
        Me.rbtnConteo = New System.Windows.Forms.RadioButton()
        Me.listDias = New System.Windows.Forms.CheckedListBox()
        Me.dateRecuFinal = New System.Windows.Forms.DateTimePicker()
        Me.comboFrecuencia = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.comboEventVisibilidad = New System.Windows.Forms.ComboBox()
        Me.comboEventDispo = New System.Windows.Forms.ComboBox()
        Me.eventFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.eventFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtEventDescrip = New System.Windows.Forms.TextBox()
        Me.txtEventUbicacion = New System.Windows.Forms.TextBox()
        Me.txtEventName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.l = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnCrearEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnContinuarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelAsistentes = New System.Windows.Forms.Panel()
        Me.btnVolverEvento = New System.Windows.Forms.Button()
        Me.btnContinuar = New FontAwesome.Sharp.IconButton()
        Me.btnAgregarAsistentes = New FontAwesome.Sharp.IconButton()
        Me.btnEliminarAsistentes = New System.Windows.Forms.Button()
        Me.comboListaInvitados = New System.Windows.Forms.ComboBox()
        Me.labelAsistente = New System.Windows.Forms.Label()
        Me.comboInvitados = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvDataEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelEventos.SuspendLayout()
        CType(Me.pbInsertarEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNotificaciones.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosBasicos.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelAsistentes.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDataEventos
        '
        Me.dgvDataEventos.AllowUserToAddRows = False
        Me.dgvDataEventos.AllowUserToDeleteRows = False
        Me.dgvDataEventos.AllowUserToResizeRows = False
        Me.dgvDataEventos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvDataEventos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataEventos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataEventos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataEventos.EnableHeadersVisualStyles = False
        Me.dgvDataEventos.Location = New System.Drawing.Point(0, 0)
        Me.dgvDataEventos.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataEventos.Name = "dgvDataEventos"
        Me.dgvDataEventos.ReadOnly = True
        Me.dgvDataEventos.RowHeadersVisible = False
        Me.dgvDataEventos.RowHeadersWidth = 51
        Me.dgvDataEventos.RowTemplate.Height = 30
        Me.dgvDataEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataEventos.Size = New System.Drawing.Size(927, 625)
        Me.dgvDataEventos.TabIndex = 101
        '
        'Eli
        '
        Me.Eli.HeaderText = ""
        Me.Eli.Image = CType(resources.GetObject("Eli.Image"), System.Drawing.Image)
        Me.Eli.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Eli.MinimumWidth = 6
        Me.Eli.Name = "Eli"
        Me.Eli.ReadOnly = True
        Me.Eli.Width = 125
        '
        'panelEventos
        '
        Me.panelEventos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.panelEventos.Controls.Add(Me.btnSincronizar)
        Me.panelEventos.Controls.Add(Me.dgvDataEventos)
        Me.panelEventos.Controls.Add(Me.pbInsertarEvento)
        Me.panelEventos.Location = New System.Drawing.Point(1, 1)
        Me.panelEventos.Name = "panelEventos"
        Me.panelEventos.Size = New System.Drawing.Size(1092, 625)
        Me.panelEventos.TabIndex = 9
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Location = New System.Drawing.Point(960, 516)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(106, 48)
        Me.btnSincronizar.TabIndex = 103
        Me.btnSincronizar.Text = "ACTUALIZAR"
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'pbInsertarEvento
        '
        Me.pbInsertarEvento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbInsertarEvento.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbInsertarEvento.Image = CType(resources.GetObject("pbInsertarEvento.Image"), System.Drawing.Image)
        Me.pbInsertarEvento.Location = New System.Drawing.Point(927, 0)
        Me.pbInsertarEvento.Name = "pbInsertarEvento"
        Me.pbInsertarEvento.Size = New System.Drawing.Size(165, 625)
        Me.pbInsertarEvento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbInsertarEvento.TabIndex = 0
        Me.pbInsertarEvento.TabStop = False
        '
        'PanelNotificaciones
        '
        Me.PanelNotificaciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelNotificaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelNotificaciones.Controls.Add(Me.MenuStrip2)
        Me.PanelNotificaciones.Controls.Add(Me.btnVolverAsistente)
        Me.PanelNotificaciones.Controls.Add(Me.btnActualizarNotificacion)
        Me.PanelNotificaciones.Controls.Add(Me.btnEliminarNotificaciones)
        Me.PanelNotificaciones.Controls.Add(Me.comboListaNotificaciones)
        Me.PanelNotificaciones.Controls.Add(Me.Label5)
        Me.PanelNotificaciones.Controls.Add(Me.numericUpCantidad)
        Me.PanelNotificaciones.Controls.Add(Me.comboUnidades)
        Me.PanelNotificaciones.Controls.Add(Me.btnAgregarRecordatorio)
        Me.PanelNotificaciones.Controls.Add(Me.comboMetodoRecordar)
        Me.PanelNotificaciones.Controls.Add(Me.Label1)
        Me.PanelNotificaciones.Controls.Add(Me.Label14)
        Me.PanelNotificaciones.Controls.Add(Me.Label15)
        Me.PanelNotificaciones.Location = New System.Drawing.Point(1061, 35)
        Me.PanelNotificaciones.Name = "PanelNotificaciones"
        Me.PanelNotificaciones.Size = New System.Drawing.Size(666, 428)
        Me.PanelNotificaciones.TabIndex = 113
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEnviarAPI, Me.btnActualizarEvento})
        Me.MenuStrip2.Location = New System.Drawing.Point(203, 332)
        Me.MenuStrip2.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(232, 46)
        Me.MenuStrip2.TabIndex = 127
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnEnviarAPI
        '
        Me.btnEnviarAPI.AutoSize = False
        Me.btnEnviarAPI.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnEnviarAPI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEnviarAPI.Name = "btnEnviarAPI"
        Me.btnEnviarAPI.Size = New System.Drawing.Size(112, 42)
        Me.btnEnviarAPI.Text = "Finalizar"
        '
        'btnActualizarEvento
        '
        Me.btnActualizarEvento.AutoSize = False
        Me.btnActualizarEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnActualizarEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnActualizarEvento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnActualizarEvento.Name = "btnActualizarEvento"
        Me.btnActualizarEvento.Size = New System.Drawing.Size(112, 42)
        Me.btnActualizarEvento.Text = "Actualizar"
        '
        'btnVolverAsistente
        '
        Me.btnVolverAsistente.BackColor = System.Drawing.Color.Transparent
        Me.btnVolverAsistente.FlatAppearance.BorderSize = 0
        Me.btnVolverAsistente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolverAsistente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolverAsistente.Location = New System.Drawing.Point(439, 332)
        Me.btnVolverAsistente.Name = "btnVolverAsistente"
        Me.btnVolverAsistente.Size = New System.Drawing.Size(121, 42)
        Me.btnVolverAsistente.TabIndex = 125
        Me.btnVolverAsistente.Text = "Volver"
        Me.btnVolverAsistente.UseVisualStyleBackColor = False
        '
        'btnActualizarNotificacion
        '
        Me.btnActualizarNotificacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarNotificacion.Location = New System.Drawing.Point(164, 247)
        Me.btnActualizarNotificacion.Name = "btnActualizarNotificacion"
        Me.btnActualizarNotificacion.Size = New System.Drawing.Size(190, 38)
        Me.btnActualizarNotificacion.TabIndex = 124
        Me.btnActualizarNotificacion.Text = "Actualizar recordatorio"
        Me.btnActualizarNotificacion.UseVisualStyleBackColor = True
        '
        'btnEliminarNotificaciones
        '
        Me.btnEliminarNotificaciones.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarNotificaciones.BackgroundImage = CType(resources.GetObject("btnEliminarNotificaciones.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminarNotificaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminarNotificaciones.FlatAppearance.BorderSize = 0
        Me.btnEliminarNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarNotificaciones.Location = New System.Drawing.Point(564, 101)
        Me.btnEliminarNotificaciones.Name = "btnEliminarNotificaciones"
        Me.btnEliminarNotificaciones.Size = New System.Drawing.Size(27, 27)
        Me.btnEliminarNotificaciones.TabIndex = 123
        Me.btnEliminarNotificaciones.UseVisualStyleBackColor = False
        '
        'comboListaNotificaciones
        '
        Me.comboListaNotificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaNotificaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboListaNotificaciones.FormattingEnabled = True
        Me.comboListaNotificaciones.Location = New System.Drawing.Point(292, 101)
        Me.comboListaNotificaciones.Name = "comboListaNotificaciones"
        Me.comboListaNotificaciones.Size = New System.Drawing.Size(266, 28)
        Me.comboListaNotificaciones.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 20)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Notificaciones activas"
        '
        'numericUpCantidad
        '
        Me.numericUpCantidad.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpCantidad.Location = New System.Drawing.Point(292, 201)
        Me.numericUpCantidad.Name = "numericUpCantidad"
        Me.numericUpCantidad.Size = New System.Drawing.Size(109, 26)
        Me.numericUpCantidad.TabIndex = 120
        '
        'comboUnidades
        '
        Me.comboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboUnidades.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboUnidades.FormattingEnabled = True
        Me.comboUnidades.Items.AddRange(New Object() {"Minutos", "Horas", "Días", "Semanas"})
        Me.comboUnidades.Location = New System.Drawing.Point(416, 199)
        Me.comboUnidades.Name = "comboUnidades"
        Me.comboUnidades.Size = New System.Drawing.Size(121, 28)
        Me.comboUnidades.TabIndex = 119
        '
        'btnAgregarRecordatorio
        '
        Me.btnAgregarRecordatorio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarRecordatorio.Location = New System.Drawing.Point(368, 247)
        Me.btnAgregarRecordatorio.Name = "btnAgregarRecordatorio"
        Me.btnAgregarRecordatorio.Size = New System.Drawing.Size(190, 38)
        Me.btnAgregarRecordatorio.TabIndex = 118
        Me.btnAgregarRecordatorio.Text = "Añadir recordatorio"
        Me.btnAgregarRecordatorio.UseVisualStyleBackColor = True
        '
        'comboMetodoRecordar
        '
        Me.comboMetodoRecordar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMetodoRecordar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboMetodoRecordar.FormattingEnabled = True
        Me.comboMetodoRecordar.Items.AddRange(New Object() {"Notificación", "Correo electrónico"})
        Me.comboMetodoRecordar.Location = New System.Drawing.Point(292, 148)
        Me.comboMetodoRecordar.Name = "comboMetodoRecordar"
        Me.comboMetodoRecordar.Size = New System.Drawing.Size(121, 28)
        Me.comboMetodoRecordar.TabIndex = 117
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 20)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Tiempo antes del evento"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(77, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(190, 20)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Metodo de recordatorio"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(258, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 19)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "NOTIFICACIONES"
        '
        'PanelDatosBasicos
        '
        Me.PanelDatosBasicos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelDatosBasicos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelDatosBasicos.Controls.Add(Me.btnVolver)
        Me.PanelDatosBasicos.Controls.Add(Me.txtOcurrencias)
        Me.PanelDatosBasicos.Controls.Add(Me.rbtnFecha)
        Me.PanelDatosBasicos.Controls.Add(Me.rbtnConteo)
        Me.PanelDatosBasicos.Controls.Add(Me.listDias)
        Me.PanelDatosBasicos.Controls.Add(Me.dateRecuFinal)
        Me.PanelDatosBasicos.Controls.Add(Me.comboFrecuencia)
        Me.PanelDatosBasicos.Controls.Add(Me.Label20)
        Me.PanelDatosBasicos.Controls.Add(Me.Label19)
        Me.PanelDatosBasicos.Controls.Add(Me.Label18)
        Me.PanelDatosBasicos.Controls.Add(Me.Label17)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventVisibilidad)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventDispo)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaFinal)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaInicio)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventDescrip)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventUbicacion)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventName)
        Me.PanelDatosBasicos.Controls.Add(Me.Label8)
        Me.PanelDatosBasicos.Controls.Add(Me.Label7)
        Me.PanelDatosBasicos.Controls.Add(Me.Label6)
        Me.PanelDatosBasicos.Controls.Add(Me.l)
        Me.PanelDatosBasicos.Controls.Add(Me.Label4)
        Me.PanelDatosBasicos.Controls.Add(Me.Label3)
        Me.PanelDatosBasicos.Controls.Add(Me.Label2)
        Me.PanelDatosBasicos.Controls.Add(Me.MenuStrip1)
        Me.PanelDatosBasicos.Location = New System.Drawing.Point(12, 629)
        Me.PanelDatosBasicos.Name = "PanelDatosBasicos"
        Me.PanelDatosBasicos.Size = New System.Drawing.Size(985, 533)
        Me.PanelDatosBasicos.TabIndex = 104
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.Transparent
        Me.btnVolver.FlatAppearance.BorderSize = 0
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(779, 446)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(121, 42)
        Me.btnVolver.TabIndex = 110
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'txtOcurrencias
        '
        Me.txtOcurrencias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcurrencias.Location = New System.Drawing.Point(547, 373)
        Me.txtOcurrencias.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txtOcurrencias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtOcurrencias.Name = "txtOcurrencias"
        Me.txtOcurrencias.Size = New System.Drawing.Size(102, 26)
        Me.txtOcurrencias.TabIndex = 109
        Me.txtOcurrencias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbtnFecha
        '
        Me.rbtnFecha.AutoSize = True
        Me.rbtnFecha.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFecha.Location = New System.Drawing.Point(773, 292)
        Me.rbtnFecha.Name = "rbtnFecha"
        Me.rbtnFecha.Size = New System.Drawing.Size(88, 24)
        Me.rbtnFecha.TabIndex = 108
        Me.rbtnFecha.Text = "Hasta el"
        Me.rbtnFecha.UseVisualStyleBackColor = True
        '
        'rbtnConteo
        '
        Me.rbtnConteo.AutoSize = True
        Me.rbtnConteo.Checked = True
        Me.rbtnConteo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnConteo.Location = New System.Drawing.Point(547, 292)
        Me.rbtnConteo.Name = "rbtnConteo"
        Me.rbtnConteo.Size = New System.Drawing.Size(116, 24)
        Me.rbtnConteo.TabIndex = 107
        Me.rbtnConteo.TabStop = True
        Me.rbtnConteo.Text = "Despues de"
        Me.rbtnConteo.UseVisualStyleBackColor = True
        '
        'listDias
        '
        Me.listDias.Enabled = False
        Me.listDias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listDias.FormattingEnabled = True
        Me.listDias.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"})
        Me.listDias.Location = New System.Drawing.Point(638, 119)
        Me.listDias.Name = "listDias"
        Me.listDias.Size = New System.Drawing.Size(107, 151)
        Me.listDias.TabIndex = 106
        '
        'dateRecuFinal
        '
        Me.dateRecuFinal.Enabled = False
        Me.dateRecuFinal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateRecuFinal.Location = New System.Drawing.Point(683, 373)
        Me.dateRecuFinal.Name = "dateRecuFinal"
        Me.dateRecuFinal.Size = New System.Drawing.Size(265, 26)
        Me.dateRecuFinal.TabIndex = 105
        '
        'comboFrecuencia
        '
        Me.comboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFrecuencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboFrecuencia.FormattingEnabled = True
        Me.comboFrecuencia.Items.AddRange(New Object() {"No repetir", "Diariamente", "Semanalmente", "Mensualmente", "Anualmente"})
        Me.comboFrecuencia.Location = New System.Drawing.Point(717, 41)
        Me.comboFrecuencia.Name = "comboFrecuencia"
        Me.comboFrecuencia.Size = New System.Drawing.Size(121, 28)
        Me.comboFrecuencia.TabIndex = 104
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(625, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(142, 20)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "Dias de la semana"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(760, 338)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(140, 20)
        Me.Label19.TabIndex = 102
        Me.Label19.Text = "Fecha finalizacion"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(538, 338)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(159, 20)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Conteo Ocurrencias"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(525, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(171, 20)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "Frecuencia repeticion"
        '
        'comboEventVisibilidad
        '
        Me.comboEventVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventVisibilidad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboEventVisibilidad.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventVisibilidad.FormattingEnabled = True
        Me.comboEventVisibilidad.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboEventVisibilidad.Location = New System.Drawing.Point(163, 315)
        Me.comboEventVisibilidad.Name = "comboEventVisibilidad"
        Me.comboEventVisibilidad.Size = New System.Drawing.Size(132, 28)
        Me.comboEventVisibilidad.TabIndex = 91
        '
        'comboEventDispo
        '
        Me.comboEventDispo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventDispo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventDispo.FormattingEnabled = True
        Me.comboEventDispo.Items.AddRange(New Object() {"Ocupado", "Disponible"})
        Me.comboEventDispo.Location = New System.Drawing.Point(163, 375)
        Me.comboEventDispo.Name = "comboEventDispo"
        Me.comboEventDispo.Size = New System.Drawing.Size(121, 28)
        Me.comboEventDispo.TabIndex = 97
        '
        'eventFechaFinal
        '
        Me.eventFechaFinal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaFinal.Location = New System.Drawing.Point(163, 258)
        Me.eventFechaFinal.Name = "eventFechaFinal"
        Me.eventFechaFinal.Size = New System.Drawing.Size(250, 26)
        Me.eventFechaFinal.TabIndex = 96
        '
        'eventFechaInicio
        '
        Me.eventFechaInicio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaInicio.Location = New System.Drawing.Point(163, 197)
        Me.eventFechaInicio.Name = "eventFechaInicio"
        Me.eventFechaInicio.Size = New System.Drawing.Size(250, 26)
        Me.eventFechaInicio.TabIndex = 95
        '
        'txtEventDescrip
        '
        Me.txtEventDescrip.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventDescrip.Location = New System.Drawing.Point(163, 145)
        Me.txtEventDescrip.Name = "txtEventDescrip"
        Me.txtEventDescrip.Size = New System.Drawing.Size(100, 26)
        Me.txtEventDescrip.TabIndex = 94
        '
        'txtEventUbicacion
        '
        Me.txtEventUbicacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventUbicacion.Location = New System.Drawing.Point(163, 90)
        Me.txtEventUbicacion.Name = "txtEventUbicacion"
        Me.txtEventUbicacion.Size = New System.Drawing.Size(100, 26)
        Me.txtEventUbicacion.TabIndex = 93
        '
        'txtEventName
        '
        Me.txtEventName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventName.Location = New System.Drawing.Point(163, 38)
        Me.txtEventName.Name = "txtEventName"
        Me.txtEventName.Size = New System.Drawing.Size(100, 26)
        Me.txtEventName.TabIndex = 92
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(42, 380)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Disponibilidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(71, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 20)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Visibilidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Finalizar Fecha"
        '
        'l
        '
        Me.l.AutoSize = True
        Me.l.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l.Location = New System.Drawing.Point(56, 201)
        Me.l.Name = "l"
        Me.l.Size = New System.Drawing.Size(96, 20)
        Me.l.TabIndex = 87
        Me.l.Text = "Incio Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Descripcion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Ubicacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Titulo"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCrearEvento, Me.btnContinuarActualizar})
        Me.MenuStrip1.Location = New System.Drawing.Point(385, 446)
        Me.MenuStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(232, 46)
        Me.MenuStrip1.TabIndex = 115
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnCrearEvento
        '
        Me.btnCrearEvento.AutoSize = False
        Me.btnCrearEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnCrearEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnCrearEvento.Name = "btnCrearEvento"
        Me.btnCrearEvento.Size = New System.Drawing.Size(112, 42)
        Me.btnCrearEvento.Text = "Guardar"
        '
        'btnContinuarActualizar
        '
        Me.btnContinuarActualizar.AutoSize = False
        Me.btnContinuarActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuarActualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnContinuarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnContinuarActualizar.Name = "btnContinuarActualizar"
        Me.btnContinuarActualizar.Size = New System.Drawing.Size(112, 42)
        Me.btnContinuarActualizar.Text = "Continuar"
        '
        'PanelAsistentes
        '
        Me.PanelAsistentes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelAsistentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelAsistentes.Controls.Add(Me.btnVolverEvento)
        Me.PanelAsistentes.Controls.Add(Me.btnContinuar)
        Me.PanelAsistentes.Controls.Add(Me.btnAgregarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.btnEliminarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.comboListaInvitados)
        Me.PanelAsistentes.Controls.Add(Me.labelAsistente)
        Me.PanelAsistentes.Controls.Add(Me.comboInvitados)
        Me.PanelAsistentes.Controls.Add(Me.Label12)
        Me.PanelAsistentes.Controls.Add(Me.Label11)
        Me.PanelAsistentes.Controls.Add(Me.Label10)
        Me.PanelAsistentes.Controls.Add(Me.Label9)
        Me.PanelAsistentes.Location = New System.Drawing.Point(1061, 490)
        Me.PanelAsistentes.Name = "PanelAsistentes"
        Me.PanelAsistentes.Size = New System.Drawing.Size(476, 428)
        Me.PanelAsistentes.TabIndex = 112
        '
        'btnVolverEvento
        '
        Me.btnVolverEvento.BackColor = System.Drawing.Color.Transparent
        Me.btnVolverEvento.FlatAppearance.BorderSize = 0
        Me.btnVolverEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolverEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolverEvento.Location = New System.Drawing.Point(298, 357)
        Me.btnVolverEvento.Name = "btnVolverEvento"
        Me.btnVolverEvento.Size = New System.Drawing.Size(121, 42)
        Me.btnVolverEvento.TabIndex = 115
        Me.btnVolverEvento.Text = "Volver"
        Me.btnVolverEvento.UseVisualStyleBackColor = False
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnContinuar.FlatAppearance.BorderSize = 0
        Me.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinuar.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnContinuar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuar.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnContinuar.IconColor = System.Drawing.Color.Black
        Me.btnContinuar.IconSize = 16
        Me.btnContinuar.Location = New System.Drawing.Point(58, 357)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Rotation = 0R
        Me.btnContinuar.Size = New System.Drawing.Size(145, 42)
        Me.btnContinuar.TabIndex = 114
        Me.btnContinuar.Text = "Continuar/Omitir"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'btnAgregarAsistentes
        '
        Me.btnAgregarAsistentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnAgregarAsistentes.FlatAppearance.BorderSize = 0
        Me.btnAgregarAsistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAsistentes.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnAgregarAsistentes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAsistentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnAgregarAsistentes.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnAgregarAsistentes.IconColor = System.Drawing.Color.Black
        Me.btnAgregarAsistentes.IconSize = 16
        Me.btnAgregarAsistentes.Location = New System.Drawing.Point(169, 257)
        Me.btnAgregarAsistentes.Name = "btnAgregarAsistentes"
        Me.btnAgregarAsistentes.Rotation = 0R
        Me.btnAgregarAsistentes.Size = New System.Drawing.Size(163, 42)
        Me.btnAgregarAsistentes.TabIndex = 113
        Me.btnAgregarAsistentes.Text = "Agregar Asistente"
        Me.btnAgregarAsistentes.UseVisualStyleBackColor = False
        '
        'btnEliminarAsistentes
        '
        Me.btnEliminarAsistentes.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsistentes.BackgroundImage = CType(resources.GetObject("btnEliminarAsistentes.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminarAsistentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminarAsistentes.FlatAppearance.BorderSize = 0
        Me.btnEliminarAsistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarAsistentes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarAsistentes.Location = New System.Drawing.Point(394, 191)
        Me.btnEliminarAsistentes.Name = "btnEliminarAsistentes"
        Me.btnEliminarAsistentes.Size = New System.Drawing.Size(27, 27)
        Me.btnEliminarAsistentes.TabIndex = 112
        Me.btnEliminarAsistentes.UseVisualStyleBackColor = False
        '
        'comboListaInvitados
        '
        Me.comboListaInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaInvitados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboListaInvitados.FormattingEnabled = True
        Me.comboListaInvitados.Location = New System.Drawing.Point(216, 191)
        Me.comboListaInvitados.Name = "comboListaInvitados"
        Me.comboListaInvitados.Size = New System.Drawing.Size(163, 28)
        Me.comboListaInvitados.TabIndex = 111
        '
        'labelAsistente
        '
        Me.labelAsistente.AutoSize = True
        Me.labelAsistente.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAsistente.Location = New System.Drawing.Point(245, 131)
        Me.labelAsistente.Name = "labelAsistente"
        Me.labelAsistente.Size = New System.Drawing.Size(104, 20)
        Me.labelAsistente.TabIndex = 109
        Me.labelAsistente.Text = "DisplayName"
        '
        'comboInvitados
        '
        Me.comboInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInvitados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboInvitados.FormattingEnabled = True
        Me.comboInvitados.Location = New System.Drawing.Point(216, 75)
        Me.comboInvitados.Name = "comboInvitados"
        Me.comboInvitados.Size = New System.Drawing.Size(163, 28)
        Me.comboInvitados.TabIndex = 108
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(115, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 20)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Invitados"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(56, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 20)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "Nombre asistente"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(146, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 20)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(182, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 19)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "ASISTENTES"
        '
        'GestionEventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1132, 628)
        Me.Controls.Add(Me.PanelDatosBasicos)
        Me.Controls.Add(Me.panelEventos)
        Me.Controls.Add(Me.PanelAsistentes)
        Me.Controls.Add(Me.PanelNotificaciones)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GestionEventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestionEventos"
        CType(Me.dgvDataEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelEventos.ResumeLayout(False)
        CType(Me.pbInsertarEvento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNotificaciones.ResumeLayout(False)
        Me.PanelNotificaciones.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosBasicos.ResumeLayout(False)
        Me.PanelDatosBasicos.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelAsistentes.ResumeLayout(False)
        Me.PanelAsistentes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDataEventos As DataGridView
    Friend WithEvents Eli As DataGridViewImageColumn
    Friend WithEvents panelEventos As Panel
    Friend WithEvents pbInsertarEvento As PictureBox
    Friend WithEvents btnSincronizar As Button
    Friend WithEvents PanelDatosBasicos As Panel
    Friend WithEvents btnVolver As Button
    Friend WithEvents txtOcurrencias As NumericUpDown
    Friend WithEvents rbtnFecha As RadioButton
    Friend WithEvents rbtnConteo As RadioButton
    Friend WithEvents listDias As CheckedListBox
    Friend WithEvents dateRecuFinal As DateTimePicker
    Friend WithEvents comboFrecuencia As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents comboEventVisibilidad As ComboBox
    Friend WithEvents comboEventDispo As ComboBox
    Friend WithEvents eventFechaFinal As DateTimePicker
    Friend WithEvents eventFechaInicio As DateTimePicker
    Friend WithEvents txtEventDescrip As TextBox
    Friend WithEvents txtEventUbicacion As TextBox
    Friend WithEvents txtEventName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents l As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelAsistentes As Panel
    Friend WithEvents btnVolverEvento As Button
    Friend WithEvents btnContinuar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAgregarAsistentes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEliminarAsistentes As Button
    Friend WithEvents comboListaInvitados As ComboBox
    Friend WithEvents labelAsistente As Label
    Friend WithEvents comboInvitados As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelNotificaciones As Panel
    Friend WithEvents btnVolverAsistente As Button
    Friend WithEvents btnActualizarNotificacion As Button
    Friend WithEvents btnEliminarNotificaciones As Button
    Friend WithEvents comboListaNotificaciones As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents numericUpCantidad As NumericUpDown
    Friend WithEvents comboUnidades As ComboBox
    Friend WithEvents btnAgregarRecordatorio As Button
    Friend WithEvents comboMetodoRecordar As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnCrearEvento As ToolStripMenuItem
    Friend WithEvents btnContinuarActualizar As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnEnviarAPI As ToolStripMenuItem
    Friend WithEvents btnActualizarEvento As ToolStripMenuItem
End Class
