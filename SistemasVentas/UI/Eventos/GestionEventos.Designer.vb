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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEventos))
        Me.dgvDataEventos = New System.Windows.Forms.DataGridView()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.panelEventos = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labelCantidadEventos = New System.Windows.Forms.Label()
        Me.btnInsertarEvento = New FontAwesome.Sharp.IconButton()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.PanelNotificaciones = New SistemasVentas.ControlPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnEnviarAPI = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnActualizarEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnActualizarNotificacion = New System.Windows.Forms.Button()
        Me.btnAgregarRecordatorio = New System.Windows.Forms.Button()
        Me.comboUnidades = New System.Windows.Forms.ComboBox()
        Me.numericUpCantidad = New System.Windows.Forms.NumericUpDown()
        Me.comboMetodoRecordar = New System.Windows.Forms.ComboBox()
        Me.btnEliminarNotificaciones = New FontAwesome.Sharp.IconPictureBox()
        Me.comboListaNotificaciones = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnVolverAsistente = New FontAwesome.Sharp.IconPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.PanelAsistentes = New SistemasVentas.ControlPanel()
        Me.btnAgregarAsistentes = New FontAwesome.Sharp.IconButton()
        Me.btnContinuar = New FontAwesome.Sharp.IconButton()
        Me.btnEliminarAsistentes = New FontAwesome.Sharp.IconPictureBox()
        Me.comboListaInvitados = New System.Windows.Forms.ComboBox()
        Me.labelAsistente = New System.Windows.Forms.Label()
        Me.comboInvitados = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnVolverEvento = New FontAwesome.Sharp.IconPictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.PanelDatosBasicos = New SistemasVentas.ControlPanel()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.btnCrearEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnContinuarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtEventDescrip = New SistemasVentas.ControlTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.comboRecurrencia = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEventUbicacion = New SistemasVentas.ControlTextBox()
        Me.txtEventName = New SistemasVentas.ControlTextBox()
        Me.panel = New System.Windows.Forms.Panel()
        Me.btnVolver = New FontAwesome.Sharp.IconPictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.eventFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.eventFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.comboEventDispo = New System.Windows.Forms.ComboBox()
        Me.comboEventVisibilidad = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PanelDatosRecurrencia = New SistemasVentas.ControlPanel()
        Me.btnCancelarRecurrencia = New System.Windows.Forms.Button()
        Me.btnListoRecurrencia = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOcurrencias = New System.Windows.Forms.NumericUpDown()
        Me.rbtnFecha = New System.Windows.Forms.RadioButton()
        Me.rbtnConteo = New System.Windows.Forms.RadioButton()
        Me.listDias = New System.Windows.Forms.CheckedListBox()
        Me.dateRecuFinal = New System.Windows.Forms.DateTimePicker()
        Me.comboFrecuencia = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.dgvDataEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelEventos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelNotificaciones.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminarNotificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.btnVolverAsistente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAsistentes.SuspendLayout()
        CType(Me.btnEliminarAsistentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.btnVolverEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosBasicos.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.panel.SuspendLayout()
        CType(Me.btnVolver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosRecurrencia.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDataEventos
        '
        Me.dgvDataEventos.AllowUserToAddRows = False
        Me.dgvDataEventos.AllowUserToDeleteRows = False
        Me.dgvDataEventos.AllowUserToResizeRows = False
        Me.dgvDataEventos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvDataEventos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataEventos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataEventos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataEventos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataEventos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataEventos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataEventos.Location = New System.Drawing.Point(10, 10)
        Me.dgvDataEventos.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataEventos.Name = "dgvDataEventos"
        Me.dgvDataEventos.ReadOnly = True
        Me.dgvDataEventos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataEventos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDataEventos.RowHeadersVisible = False
        Me.dgvDataEventos.RowHeadersWidth = 51
        Me.dgvDataEventos.RowTemplate.Height = 40
        Me.dgvDataEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataEventos.Size = New System.Drawing.Size(1139, 575)
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
        Me.Eli.Width = 6
        '
        'panelEventos
        '
        Me.panelEventos.AutoSize = True
        Me.panelEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.panelEventos.Controls.Add(Me.Panel2)
        Me.panelEventos.Controls.Add(Me.Panel1)
        Me.panelEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelEventos.Location = New System.Drawing.Point(0, 0)
        Me.panelEventos.Name = "panelEventos"
        Me.panelEventos.Size = New System.Drawing.Size(1159, 683)
        Me.panelEventos.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvDataEventos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 88)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(1159, 595)
        Me.Panel2.TabIndex = 106
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.labelCantidadEventos)
        Me.Panel1.Controls.Add(Me.btnInsertarEvento)
        Me.Panel1.Controls.Add(Me.btnSincronizar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1159, 88)
        Me.Panel1.TabIndex = 105
        '
        'labelCantidadEventos
        '
        Me.labelCantidadEventos.AutoSize = True
        Me.labelCantidadEventos.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCantidadEventos.Location = New System.Drawing.Point(26, 32)
        Me.labelCantidadEventos.Name = "labelCantidadEventos"
        Me.labelCantidadEventos.Size = New System.Drawing.Size(19, 21)
        Me.labelCantidadEventos.TabIndex = 108
        Me.labelCantidadEventos.Text = "0"
        '
        'btnInsertarEvento
        '
        Me.btnInsertarEvento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnInsertarEvento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInsertarEvento.FlatAppearance.BorderSize = 0
        Me.btnInsertarEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsertarEvento.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertarEvento.ForeColor = System.Drawing.Color.White
        Me.btnInsertarEvento.IconChar = FontAwesome.Sharp.IconChar.Add
        Me.btnInsertarEvento.IconColor = System.Drawing.Color.White
        Me.btnInsertarEvento.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnInsertarEvento.IconSize = 16
        Me.btnInsertarEvento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertarEvento.Location = New System.Drawing.Point(926, 23)
        Me.btnInsertarEvento.Name = "btnInsertarEvento"
        Me.btnInsertarEvento.Padding = New System.Windows.Forms.Padding(18, 1, 18, 0)
        Me.btnInsertarEvento.Size = New System.Drawing.Size(177, 40)
        Me.btnInsertarEvento.TabIndex = 106
        Me.btnInsertarEvento.Text = "Nuevo Evento"
        Me.btnInsertarEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInsertarEvento.UseVisualStyleBackColor = False
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSincronizar.BackColor = System.Drawing.Color.Transparent
        Me.btnSincronizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSincronizar.FlatAppearance.BorderSize = 0
        Me.btnSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSincronizar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnSincronizar.Location = New System.Drawing.Point(793, 23)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(106, 40)
        Me.btnSincronizar.TabIndex = 103
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.UseVisualStyleBackColor = False
        '
        'PanelNotificaciones
        '
        Me.PanelNotificaciones.BackColor = System.Drawing.Color.White
        Me.PanelNotificaciones.BorderRadius = 12
        Me.PanelNotificaciones.Controls.Add(Me.MenuStrip1)
        Me.PanelNotificaciones.Controls.Add(Me.btnActualizarNotificacion)
        Me.PanelNotificaciones.Controls.Add(Me.btnAgregarRecordatorio)
        Me.PanelNotificaciones.Controls.Add(Me.comboUnidades)
        Me.PanelNotificaciones.Controls.Add(Me.numericUpCantidad)
        Me.PanelNotificaciones.Controls.Add(Me.comboMetodoRecordar)
        Me.PanelNotificaciones.Controls.Add(Me.btnEliminarNotificaciones)
        Me.PanelNotificaciones.Controls.Add(Me.comboListaNotificaciones)
        Me.PanelNotificaciones.Controls.Add(Me.Label2)
        Me.PanelNotificaciones.Controls.Add(Me.Panel3)
        Me.PanelNotificaciones.Controls.Add(Me.Label4)
        Me.PanelNotificaciones.Controls.Add(Me.Label32)
        Me.PanelNotificaciones.Location = New System.Drawing.Point(1174, 38)
        Me.PanelNotificaciones.Name = "PanelNotificaciones"
        Me.PanelNotificaciones.Size = New System.Drawing.Size(488, 428)
        Me.PanelNotificaciones.TabIndex = 125
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEnviarAPI, Me.btnActualizarEvento})
        Me.MenuStrip1.Location = New System.Drawing.Point(159, 366)
        Me.MenuStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(274, 44)
        Me.MenuStrip1.TabIndex = 130
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnEnviarAPI
        '
        Me.btnEnviarAPI.AutoSize = False
        Me.btnEnviarAPI.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnEnviarAPI.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarAPI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEnviarAPI.Name = "btnEnviarAPI"
        Me.btnEnviarAPI.Size = New System.Drawing.Size(152, 40)
        Me.btnEnviarAPI.Text = "Finalizar"
        '
        'btnActualizarEvento
        '
        Me.btnActualizarEvento.AutoSize = False
        Me.btnActualizarEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnActualizarEvento.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.btnActualizarEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnActualizarEvento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnActualizarEvento.Name = "btnActualizarEvento"
        Me.btnActualizarEvento.Size = New System.Drawing.Size(112, 40)
        Me.btnActualizarEvento.Text = "Actualizar"
        '
        'btnActualizarNotificacion
        '
        Me.btnActualizarNotificacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizarNotificacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarNotificacion.Location = New System.Drawing.Point(50, 300)
        Me.btnActualizarNotificacion.Name = "btnActualizarNotificacion"
        Me.btnActualizarNotificacion.Size = New System.Drawing.Size(190, 38)
        Me.btnActualizarNotificacion.TabIndex = 129
        Me.btnActualizarNotificacion.Text = "Actualizar recordatorio"
        Me.btnActualizarNotificacion.UseVisualStyleBackColor = True
        '
        'btnAgregarRecordatorio
        '
        Me.btnAgregarRecordatorio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarRecordatorio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarRecordatorio.Location = New System.Drawing.Point(254, 300)
        Me.btnAgregarRecordatorio.Name = "btnAgregarRecordatorio"
        Me.btnAgregarRecordatorio.Size = New System.Drawing.Size(190, 38)
        Me.btnAgregarRecordatorio.TabIndex = 128
        Me.btnAgregarRecordatorio.Text = "Añadir recordatorio"
        Me.btnAgregarRecordatorio.UseVisualStyleBackColor = True
        '
        'comboUnidades
        '
        Me.comboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboUnidades.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboUnidades.FormattingEnabled = True
        Me.comboUnidades.Items.AddRange(New Object() {"Minutos", "Horas", "Días", "Semanas"})
        Me.comboUnidades.Location = New System.Drawing.Point(356, 246)
        Me.comboUnidades.Name = "comboUnidades"
        Me.comboUnidades.Size = New System.Drawing.Size(101, 29)
        Me.comboUnidades.TabIndex = 127
        '
        'numericUpCantidad
        '
        Me.numericUpCantidad.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpCantidad.Location = New System.Drawing.Point(263, 247)
        Me.numericUpCantidad.Name = "numericUpCantidad"
        Me.numericUpCantidad.Size = New System.Drawing.Size(82, 30)
        Me.numericUpCantidad.TabIndex = 126
        '
        'comboMetodoRecordar
        '
        Me.comboMetodoRecordar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMetodoRecordar.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboMetodoRecordar.FormattingEnabled = True
        Me.comboMetodoRecordar.Items.AddRange(New Object() {"Notificación", "Correo electrónico"})
        Me.comboMetodoRecordar.Location = New System.Drawing.Point(35, 197)
        Me.comboMetodoRecordar.Name = "comboMetodoRecordar"
        Me.comboMetodoRecordar.Size = New System.Drawing.Size(188, 29)
        Me.comboMetodoRecordar.TabIndex = 125
        '
        'btnEliminarNotificaciones
        '
        Me.btnEliminarNotificaciones.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarNotificaciones.ForeColor = System.Drawing.Color.Red
        Me.btnEliminarNotificaciones.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnEliminarNotificaciones.IconColor = System.Drawing.Color.Red
        Me.btnEliminarNotificaciones.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnEliminarNotificaciones.Location = New System.Drawing.Point(344, 104)
        Me.btnEliminarNotificaciones.Name = "btnEliminarNotificaciones"
        Me.btnEliminarNotificaciones.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarNotificaciones.TabIndex = 124
        Me.btnEliminarNotificaciones.TabStop = False
        '
        'comboListaNotificaciones
        '
        Me.comboListaNotificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaNotificaciones.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboListaNotificaciones.FormattingEnabled = True
        Me.comboListaNotificaciones.Location = New System.Drawing.Point(35, 104)
        Me.comboListaNotificaciones.Name = "comboListaNotificaciones"
        Me.comboListaNotificaciones.Size = New System.Drawing.Size(296, 29)
        Me.comboListaNotificaciones.TabIndex = 123
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 19)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Tiempo Antes del Evento"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnVolverAsistente)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(488, 50)
        Me.Panel3.TabIndex = 0
        '
        'btnVolverAsistente
        '
        Me.btnVolverAsistente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolverAsistente.BackColor = System.Drawing.Color.White
        Me.btnVolverAsistente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolverAsistente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverAsistente.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolverAsistente.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverAsistente.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolverAsistente.IconSize = 35
        Me.btnVolverAsistente.Location = New System.Drawing.Point(417, 9)
        Me.btnVolverAsistente.Name = "btnVolverAsistente"
        Me.btnVolverAsistente.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverAsistente.TabIndex = 1
        Me.btnVolverAsistente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Notificaciones"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 19)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Notificaciones Activas"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(31, 163)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(209, 19)
        Me.Label32.TabIndex = 87
        Me.Label32.Text = "Método de Recordatorio"
        '
        'PanelAsistentes
        '
        Me.PanelAsistentes.BackColor = System.Drawing.Color.White
        Me.PanelAsistentes.BorderRadius = 12
        Me.PanelAsistentes.Controls.Add(Me.btnAgregarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.btnContinuar)
        Me.PanelAsistentes.Controls.Add(Me.btnEliminarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.comboListaInvitados)
        Me.PanelAsistentes.Controls.Add(Me.labelAsistente)
        Me.PanelAsistentes.Controls.Add(Me.comboInvitados)
        Me.PanelAsistentes.Controls.Add(Me.Panel4)
        Me.PanelAsistentes.Controls.Add(Me.Label34)
        Me.PanelAsistentes.Controls.Add(Me.Label35)
        Me.PanelAsistentes.Controls.Add(Me.Label36)
        Me.PanelAsistentes.Location = New System.Drawing.Point(1172, 521)
        Me.PanelAsistentes.Name = "PanelAsistentes"
        Me.PanelAsistentes.Size = New System.Drawing.Size(424, 356)
        Me.PanelAsistentes.TabIndex = 124
        '
        'btnAgregarAsistentes
        '
        Me.btnAgregarAsistentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnAgregarAsistentes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarAsistentes.FlatAppearance.BorderSize = 0
        Me.btnAgregarAsistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAsistentes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAsistentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnAgregarAsistentes.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnAgregarAsistentes.IconColor = System.Drawing.Color.Black
        Me.btnAgregarAsistentes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnAgregarAsistentes.IconSize = 16
        Me.btnAgregarAsistentes.Location = New System.Drawing.Point(128, 211)
        Me.btnAgregarAsistentes.Name = "btnAgregarAsistentes"
        Me.btnAgregarAsistentes.Size = New System.Drawing.Size(163, 40)
        Me.btnAgregarAsistentes.TabIndex = 121
        Me.btnAgregarAsistentes.Text = "Agregar Asistente"
        Me.btnAgregarAsistentes.UseVisualStyleBackColor = False
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContinuar.FlatAppearance.BorderSize = 0
        Me.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinuar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuar.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnContinuar.IconColor = System.Drawing.Color.Black
        Me.btnContinuar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnContinuar.IconSize = 16
        Me.btnContinuar.Location = New System.Drawing.Point(128, 292)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(163, 42)
        Me.btnContinuar.TabIndex = 114
        Me.btnContinuar.Text = "Continuar/Omitir"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'btnEliminarAsistentes
        '
        Me.btnEliminarAsistentes.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsistentes.ForeColor = System.Drawing.Color.Red
        Me.btnEliminarAsistentes.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnEliminarAsistentes.IconColor = System.Drawing.Color.Red
        Me.btnEliminarAsistentes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnEliminarAsistentes.Location = New System.Drawing.Point(300, 159)
        Me.btnEliminarAsistentes.Name = "btnEliminarAsistentes"
        Me.btnEliminarAsistentes.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarAsistentes.TabIndex = 120
        Me.btnEliminarAsistentes.TabStop = False
        '
        'comboListaInvitados
        '
        Me.comboListaInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaInvitados.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboListaInvitados.FormattingEnabled = True
        Me.comboListaInvitados.Location = New System.Drawing.Point(113, 159)
        Me.comboListaInvitados.Name = "comboListaInvitados"
        Me.comboListaInvitados.Size = New System.Drawing.Size(178, 29)
        Me.comboListaInvitados.TabIndex = 119
        '
        'labelAsistente
        '
        Me.labelAsistente.AutoSize = True
        Me.labelAsistente.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAsistente.Location = New System.Drawing.Point(259, 109)
        Me.labelAsistente.Name = "labelAsistente"
        Me.labelAsistente.Size = New System.Drawing.Size(119, 21)
        Me.labelAsistente.TabIndex = 118
        Me.labelAsistente.Text = "DisplayName"
        '
        'comboInvitados
        '
        Me.comboInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInvitados.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboInvitados.FormattingEnabled = True
        Me.comboInvitados.Location = New System.Drawing.Point(32, 106)
        Me.comboInvitados.Name = "comboInvitados"
        Me.comboInvitados.Size = New System.Drawing.Size(179, 29)
        Me.comboInvitados.TabIndex = 117
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnVolverEvento)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 50)
        Me.Panel4.TabIndex = 0
        '
        'btnVolverEvento
        '
        Me.btnVolverEvento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolverEvento.BackColor = System.Drawing.Color.White
        Me.btnVolverEvento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolverEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverEvento.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolverEvento.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverEvento.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolverEvento.IconSize = 35
        Me.btnVolverEvento.Location = New System.Drawing.Point(354, 9)
        Me.btnVolverEvento.Name = "btnVolverEvento"
        Me.btnVolverEvento.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverEvento.TabIndex = 1
        Me.btnVolverEvento.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(46, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(83, 19)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Invitados"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(28, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 19)
        Me.Label34.TabIndex = 84
        Me.Label34.Text = "Email"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(260, 69)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(154, 19)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "Nombre Asistente"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(28, 163)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(83, 19)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Invitados"
        '
        'PanelDatosBasicos
        '
        Me.PanelDatosBasicos.BackColor = System.Drawing.Color.White
        Me.PanelDatosBasicos.BorderRadius = 12
        Me.PanelDatosBasicos.Controls.Add(Me.MenuStrip3)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventDescrip)
        Me.PanelDatosBasicos.Controls.Add(Me.Label23)
        Me.PanelDatosBasicos.Controls.Add(Me.comboRecurrencia)
        Me.PanelDatosBasicos.Controls.Add(Me.Label24)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventUbicacion)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventName)
        Me.PanelDatosBasicos.Controls.Add(Me.panel)
        Me.PanelDatosBasicos.Controls.Add(Me.Label26)
        Me.PanelDatosBasicos.Controls.Add(Me.Label27)
        Me.PanelDatosBasicos.Controls.Add(Me.Label28)
        Me.PanelDatosBasicos.Controls.Add(Me.Label29)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaInicio)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaFinal)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventDispo)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventVisibilidad)
        Me.PanelDatosBasicos.Controls.Add(Me.Label30)
        Me.PanelDatosBasicos.Controls.Add(Me.Label31)
        Me.PanelDatosBasicos.Location = New System.Drawing.Point(30, 688)
        Me.PanelDatosBasicos.Name = "PanelDatosBasicos"
        Me.PanelDatosBasicos.Size = New System.Drawing.Size(600, 625)
        Me.PanelDatosBasicos.TabIndex = 121
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCrearEvento, Me.btnContinuarActualizar})
        Me.MenuStrip3.Location = New System.Drawing.Point(314, 554)
        Me.MenuStrip3.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(234, 44)
        Me.MenuStrip3.TabIndex = 116
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'btnCrearEvento
        '
        Me.btnCrearEvento.AutoSize = False
        Me.btnCrearEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnCrearEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnCrearEvento.Name = "btnCrearEvento"
        Me.btnCrearEvento.Size = New System.Drawing.Size(112, 40)
        Me.btnCrearEvento.Text = "Guardar"
        '
        'btnContinuarActualizar
        '
        Me.btnContinuarActualizar.AutoSize = False
        Me.btnContinuarActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuarActualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnContinuarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnContinuarActualizar.Name = "btnContinuarActualizar"
        Me.btnContinuarActualizar.Size = New System.Drawing.Size(112, 40)
        Me.btnContinuarActualizar.Text = "Continuar"
        '
        'txtEventDescrip
        '
        Me.txtEventDescrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.txtEventDescrip.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtEventDescrip.BorderFocusColor = System.Drawing.Color.Black
        Me.txtEventDescrip.BorderRadius = 8
        Me.txtEventDescrip.BorderSize = 1
        Me.txtEventDescrip.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventDescrip.Location = New System.Drawing.Point(34, 380)
        Me.txtEventDescrip.Multiline = True
        Me.txtEventDescrip.Name = "txtEventDescrip"
        Me.txtEventDescrip.Padding = New System.Windows.Forms.Padding(7)
        Me.txtEventDescrip.PasswordChar = False
        Me.txtEventDescrip.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtEventDescrip.PlaceholderText = ""
        Me.txtEventDescrip.Size = New System.Drawing.Size(530, 144)
        Me.txtEventDescrip.TabIndex = 107
        Me.txtEventDescrip.Texts = ""
        Me.txtEventDescrip.UnderlinedStyle = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(31, 345)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 19)
        Me.Label23.TabIndex = 106
        Me.Label23.Text = "Descripción"
        '
        'comboRecurrencia
        '
        Me.comboRecurrencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRecurrencia.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboRecurrencia.FormattingEnabled = True
        Me.comboRecurrencia.Items.AddRange(New Object() {"No repetir", "Todos los días", "Todos los días hábiles (lunes a viernes)", "Personalizar"})
        Me.comboRecurrencia.Location = New System.Drawing.Point(34, 285)
        Me.comboRecurrencia.Name = "comboRecurrencia"
        Me.comboRecurrencia.Size = New System.Drawing.Size(251, 29)
        Me.comboRecurrencia.TabIndex = 105
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(31, 252)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 19)
        Me.Label24.TabIndex = 97
        Me.Label24.Text = "Recurrencia"
        '
        'txtEventUbicacion
        '
        Me.txtEventUbicacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.txtEventUbicacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtEventUbicacion.BorderFocusColor = System.Drawing.Color.Black
        Me.txtEventUbicacion.BorderRadius = 8
        Me.txtEventUbicacion.BorderSize = 1
        Me.txtEventUbicacion.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventUbicacion.Location = New System.Drawing.Point(314, 99)
        Me.txtEventUbicacion.Multiline = False
        Me.txtEventUbicacion.Name = "txtEventUbicacion"
        Me.txtEventUbicacion.Padding = New System.Windows.Forms.Padding(7)
        Me.txtEventUbicacion.PasswordChar = False
        Me.txtEventUbicacion.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtEventUbicacion.PlaceholderText = ""
        Me.txtEventUbicacion.Size = New System.Drawing.Size(250, 36)
        Me.txtEventUbicacion.TabIndex = 86
        Me.txtEventUbicacion.Texts = ""
        Me.txtEventUbicacion.UnderlinedStyle = False
        '
        'txtEventName
        '
        Me.txtEventName.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.txtEventName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtEventName.BorderFocusColor = System.Drawing.Color.Black
        Me.txtEventName.BorderRadius = 8
        Me.txtEventName.BorderSize = 1
        Me.txtEventName.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventName.Location = New System.Drawing.Point(35, 99)
        Me.txtEventName.Multiline = False
        Me.txtEventName.Name = "txtEventName"
        Me.txtEventName.Padding = New System.Windows.Forms.Padding(7)
        Me.txtEventName.PasswordChar = False
        Me.txtEventName.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtEventName.PlaceholderText = ""
        Me.txtEventName.Size = New System.Drawing.Size(250, 36)
        Me.txtEventName.TabIndex = 85
        Me.txtEventName.Texts = ""
        Me.txtEventName.UnderlinedStyle = False
        '
        'panel
        '
        Me.panel.Controls.Add(Me.btnVolver)
        Me.panel.Controls.Add(Me.Label25)
        Me.panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel.Location = New System.Drawing.Point(0, 0)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(600, 50)
        Me.panel.TabIndex = 0
        '
        'btnVolver
        '
        Me.btnVolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolver.BackColor = System.Drawing.Color.White
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolver.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolver.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolver.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolver.IconSize = 35
        Me.btnVolver.Location = New System.Drawing.Point(530, 9)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(32, 32)
        Me.btnVolver.TabIndex = 1
        Me.btnVolver.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(46, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(123, 19)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Datos Básicos"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(31, 69)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(49, 19)
        Me.Label26.TabIndex = 84
        Me.Label26.Text = "Titulo"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(311, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(92, 19)
        Me.Label27.TabIndex = 85
        Me.Label27.Text = "Ubicación"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(31, 163)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(106, 19)
        Me.Label28.TabIndex = 87
        Me.Label28.Text = "Incio Fecha"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(311, 163)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(130, 19)
        Me.Label29.TabIndex = 88
        Me.Label29.Text = "Finalizar Fecha"
        '
        'eventFechaInicio
        '
        Me.eventFechaInicio.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaInicio.Location = New System.Drawing.Point(35, 194)
        Me.eventFechaInicio.Name = "eventFechaInicio"
        Me.eventFechaInicio.Size = New System.Drawing.Size(250, 28)
        Me.eventFechaInicio.TabIndex = 95
        '
        'eventFechaFinal
        '
        Me.eventFechaFinal.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaFinal.Location = New System.Drawing.Point(314, 194)
        Me.eventFechaFinal.Name = "eventFechaFinal"
        Me.eventFechaFinal.Size = New System.Drawing.Size(250, 28)
        Me.eventFechaFinal.TabIndex = 96
        '
        'comboEventDispo
        '
        Me.comboEventDispo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventDispo.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventDispo.FormattingEnabled = True
        Me.comboEventDispo.Items.AddRange(New Object() {"Ocupado", "Disponible"})
        Me.comboEventDispo.Location = New System.Drawing.Point(174, 562)
        Me.comboEventDispo.Name = "comboEventDispo"
        Me.comboEventDispo.Size = New System.Drawing.Size(111, 29)
        Me.comboEventDispo.TabIndex = 97
        '
        'comboEventVisibilidad
        '
        Me.comboEventVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventVisibilidad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboEventVisibilidad.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventVisibilidad.FormattingEnabled = True
        Me.comboEventVisibilidad.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboEventVisibilidad.Location = New System.Drawing.Point(314, 285)
        Me.comboEventVisibilidad.Name = "comboEventVisibilidad"
        Me.comboEventVisibilidad.Size = New System.Drawing.Size(250, 29)
        Me.comboEventVisibilidad.TabIndex = 91
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(310, 250)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(93, 19)
        Me.Label30.TabIndex = 89
        Me.Label30.Text = "Visibilidad"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(31, 566)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(125, 19)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "Disponibilidad"
        '
        'PanelDatosRecurrencia
        '
        Me.PanelDatosRecurrencia.BackColor = System.Drawing.Color.White
        Me.PanelDatosRecurrencia.BorderRadius = 8
        Me.PanelDatosRecurrencia.Controls.Add(Me.btnCancelarRecurrencia)
        Me.PanelDatosRecurrencia.Controls.Add(Me.btnListoRecurrencia)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label13)
        Me.PanelDatosRecurrencia.Controls.Add(Me.txtOcurrencias)
        Me.PanelDatosRecurrencia.Controls.Add(Me.rbtnFecha)
        Me.PanelDatosRecurrencia.Controls.Add(Me.rbtnConteo)
        Me.PanelDatosRecurrencia.Controls.Add(Me.listDias)
        Me.PanelDatosRecurrencia.Controls.Add(Me.dateRecuFinal)
        Me.PanelDatosRecurrencia.Controls.Add(Me.comboFrecuencia)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label16)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label21)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label22)
        Me.PanelDatosRecurrencia.Location = New System.Drawing.Point(636, 687)
        Me.PanelDatosRecurrencia.Name = "PanelDatosRecurrencia"
        Me.PanelDatosRecurrencia.Size = New System.Drawing.Size(408, 476)
        Me.PanelDatosRecurrencia.TabIndex = 120
        '
        'btnCancelarRecurrencia
        '
        Me.btnCancelarRecurrencia.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarRecurrencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarRecurrencia.FlatAppearance.BorderSize = 0
        Me.btnCancelarRecurrencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarRecurrencia.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.btnCancelarRecurrencia.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarRecurrencia.Location = New System.Drawing.Point(70, 427)
        Me.btnCancelarRecurrencia.Name = "btnCancelarRecurrencia"
        Me.btnCancelarRecurrencia.Size = New System.Drawing.Size(106, 35)
        Me.btnCancelarRecurrencia.TabIndex = 122
        Me.btnCancelarRecurrencia.Text = "Cancelar"
        Me.btnCancelarRecurrencia.UseVisualStyleBackColor = False
        '
        'btnListoRecurrencia
        '
        Me.btnListoRecurrencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnListoRecurrencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListoRecurrencia.FlatAppearance.BorderSize = 0
        Me.btnListoRecurrencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListoRecurrencia.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.btnListoRecurrencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnListoRecurrencia.Location = New System.Drawing.Point(213, 427)
        Me.btnListoRecurrencia.Name = "btnListoRecurrencia"
        Me.btnListoRecurrencia.Size = New System.Drawing.Size(106, 35)
        Me.btnListoRecurrencia.TabIndex = 121
        Me.btnListoRecurrencia.Text = "Listo"
        Me.btnListoRecurrencia.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(26, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 21)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Finaliza"
        '
        'txtOcurrencias
        '
        Me.txtOcurrencias.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcurrencias.Location = New System.Drawing.Point(166, 307)
        Me.txtOcurrencias.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txtOcurrencias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtOcurrencias.Name = "txtOcurrencias"
        Me.txtOcurrencias.Size = New System.Drawing.Size(79, 28)
        Me.txtOcurrencias.TabIndex = 119
        Me.txtOcurrencias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbtnFecha
        '
        Me.rbtnFecha.AutoSize = True
        Me.rbtnFecha.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFecha.Location = New System.Drawing.Point(30, 365)
        Me.rbtnFecha.Name = "rbtnFecha"
        Me.rbtnFecha.Size = New System.Drawing.Size(100, 25)
        Me.rbtnFecha.TabIndex = 118
        Me.rbtnFecha.Text = "Hasta el"
        Me.rbtnFecha.UseVisualStyleBackColor = True
        '
        'rbtnConteo
        '
        Me.rbtnConteo.AutoSize = True
        Me.rbtnConteo.Checked = True
        Me.rbtnConteo.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnConteo.Location = New System.Drawing.Point(30, 310)
        Me.rbtnConteo.Name = "rbtnConteo"
        Me.rbtnConteo.Size = New System.Drawing.Size(130, 25)
        Me.rbtnConteo.TabIndex = 117
        Me.rbtnConteo.TabStop = True
        Me.rbtnConteo.Text = "Despues de"
        Me.rbtnConteo.UseVisualStyleBackColor = True
        '
        'listDias
        '
        Me.listDias.Enabled = False
        Me.listDias.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listDias.FormattingEnabled = True
        Me.listDias.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"})
        Me.listDias.Location = New System.Drawing.Point(237, 83)
        Me.listDias.Name = "listDias"
        Me.listDias.Size = New System.Drawing.Size(139, 142)
        Me.listDias.TabIndex = 116
        '
        'dateRecuFinal
        '
        Me.dateRecuFinal.Enabled = False
        Me.dateRecuFinal.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateRecuFinal.Location = New System.Drawing.Point(157, 361)
        Me.dateRecuFinal.Name = "dateRecuFinal"
        Me.dateRecuFinal.Size = New System.Drawing.Size(219, 28)
        Me.dateRecuFinal.TabIndex = 115
        '
        'comboFrecuencia
        '
        Me.comboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFrecuencia.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboFrecuencia.FormattingEnabled = True
        Me.comboFrecuencia.Items.AddRange(New Object() {"No repetir", "Diariamente", "Semanalmente", "Mensualmente", "Anualmente"})
        Me.comboFrecuencia.Location = New System.Drawing.Point(237, 32)
        Me.comboFrecuencia.Name = "comboFrecuencia"
        Me.comboFrecuencia.Size = New System.Drawing.Size(139, 29)
        Me.comboFrecuencia.TabIndex = 114
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(26, 148)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(165, 21)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Dias de la semana"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(26, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(191, 21)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "Frecuencia repeticion"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(266, 310)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 21)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Ocurrencias"
        '
        'GestionEventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1159, 683)
        Me.Controls.Add(Me.PanelNotificaciones)
        Me.Controls.Add(Me.PanelAsistentes)
        Me.Controls.Add(Me.PanelDatosBasicos)
        Me.Controls.Add(Me.PanelDatosRecurrencia)
        Me.Controls.Add(Me.panelEventos)
        Me.Name = "GestionEventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestionEventos"
        CType(Me.dgvDataEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelEventos.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelNotificaciones.ResumeLayout(False)
        Me.PanelNotificaciones.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminarNotificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.btnVolverAsistente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAsistentes.ResumeLayout(False)
        Me.PanelAsistentes.PerformLayout()
        CType(Me.btnEliminarAsistentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.btnVolverEvento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosBasicos.ResumeLayout(False)
        Me.PanelDatosBasicos.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        CType(Me.btnVolver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosRecurrencia.ResumeLayout(False)
        Me.PanelDatosRecurrencia.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDataEventos As DataGridView
    Friend WithEvents Eli As DataGridViewImageColumn
    Friend WithEvents panelEventos As Panel
    Friend WithEvents btnSincronizar As Button
    Friend WithEvents PanelDatosRecurrencia As ControlPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents txtOcurrencias As NumericUpDown
    Friend WithEvents rbtnFecha As RadioButton
    Friend WithEvents rbtnConteo As RadioButton
    Friend WithEvents listDias As CheckedListBox
    Friend WithEvents dateRecuFinal As DateTimePicker
    Friend WithEvents comboFrecuencia As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents btnCancelarRecurrencia As Button
    Friend WithEvents btnListoRecurrencia As Button
    Friend WithEvents PanelDatosBasicos As ControlPanel
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents btnCrearEvento As ToolStripMenuItem
    Friend WithEvents btnContinuarActualizar As ToolStripMenuItem
    Friend WithEvents txtEventDescrip As ControlTextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents comboRecurrencia As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtEventUbicacion As ControlTextBox
    Friend WithEvents txtEventName As ControlTextBox
    Friend WithEvents panel As Panel
    Friend WithEvents btnVolver As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents eventFechaInicio As DateTimePicker
    Friend WithEvents eventFechaFinal As DateTimePicker
    Friend WithEvents comboEventDispo As ComboBox
    Friend WithEvents comboEventVisibilidad As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents PanelAsistentes As ControlPanel
    Friend WithEvents btnAgregarAsistentes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnContinuar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEliminarAsistentes As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboListaInvitados As ComboBox
    Friend WithEvents labelAsistente As Label
    Friend WithEvents comboInvitados As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnVolverEvento As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents PanelNotificaciones As ControlPanel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnEnviarAPI As ToolStripMenuItem
    Friend WithEvents btnActualizarEvento As ToolStripMenuItem
    Friend WithEvents btnActualizarNotificacion As Button
    Friend WithEvents btnAgregarRecordatorio As Button
    Friend WithEvents comboUnidades As ComboBox
    Friend WithEvents numericUpCantidad As NumericUpDown
    Friend WithEvents comboMetodoRecordar As ComboBox
    Friend WithEvents btnEliminarNotificaciones As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboListaNotificaciones As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnVolverAsistente As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnInsertarEvento As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents labelCantidadEventos As Label
End Class
