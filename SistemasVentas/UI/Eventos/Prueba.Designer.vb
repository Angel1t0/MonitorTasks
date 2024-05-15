<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Prueba
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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnVolverAsistente = New FontAwesome.Sharp.IconPictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.panelDatosPodio = New SistemasVentas.ControlPanel()
        Me.panelSeleccionarEmpresas = New SistemasVentas.ControlPanel()
        Me.btnCancelarEmpresas = New System.Windows.Forms.Button()
        Me.btnEmpresas = New System.Windows.Forms.Button()
        Me.listEmpresas = New System.Windows.Forms.CheckedListBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtProyectoSistemas = New System.Windows.Forms.TextBox()
        Me.barraAvance = New System.Windows.Forms.NumericUpDown()
        Me.btnContinuarDatosPodio = New FontAwesome.Sharp.IconButton()
        Me.maskHorasExtras = New System.Windows.Forms.MaskedTextBox()
        Me.maskHorasAcumuladas = New System.Windows.Forms.MaskedTextBox()
        Me.numericOrdenSistemas = New System.Windows.Forms.NumericUpDown()
        Me.numericOrdenDpt = New System.Windows.Forms.NumericUpDown()
        Me.textPlanAccion = New SistemasVentas.ControlTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboCategorias = New System.Windows.Forms.ComboBox()
        Me.comboArea = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.comboPrioridad = New System.Windows.Forms.ComboBox()
        Me.comboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.comboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnVolverDatosBasicos = New FontAwesome.Sharp.IconPictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PanelDatosBasicos = New SistemasVentas.ControlPanel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnCrearEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnContinuarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtEventDescrip = New SistemasVentas.ControlTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboRecurrencia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEventUbicacion = New SistemasVentas.ControlTextBox()
        Me.txtEventName = New SistemasVentas.ControlTextBox()
        Me.panel = New System.Windows.Forms.Panel()
        Me.btnVolver = New FontAwesome.Sharp.IconPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.eventFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.eventFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.comboEventDispo = New System.Windows.Forms.ComboBox()
        Me.comboEventVisibilidad = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.PanelAsistentes = New SistemasVentas.ControlPanel()
        Me.pictureEliminarAsignados = New FontAwesome.Sharp.IconPictureBox()
        Me.pictureEliminarAutorizantes = New FontAwesome.Sharp.IconPictureBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.comboAsignados = New System.Windows.Forms.ComboBox()
        Me.comboAtorizantes = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.comboSolicitantes = New System.Windows.Forms.ComboBox()
        Me.comboAsignadoA = New System.Windows.Forms.ComboBox()
        Me.btnContinuar = New FontAwesome.Sharp.IconButton()
        Me.pictureEliminarSolicitante = New FontAwesome.Sharp.IconPictureBox()
        Me.comboAutoriza = New System.Windows.Forms.ComboBox()
        Me.comboSolicitante = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.IconPictureBox2 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.panelProyectosGenerales = New SistemasVentas.ControlPanel()
        Me.pictureEliminarGeneral = New FontAwesome.Sharp.IconPictureBox()
        Me.comboProyectoGeneral = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.comboProyectosGenerales = New System.Windows.Forms.ComboBox()
        Me.btnCancelarProyectoGeneral = New System.Windows.Forms.Button()
        Me.btnProyectosGenerales = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btnProyectosSistemas = New System.Windows.Forms.Button()
        Me.btnCancelarProyectosSistemas = New System.Windows.Forms.Button()
        Me.comboProyectosSistemas = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.comboProyectoSistemas = New System.Windows.Forms.ComboBox()
        Me.pictureEliminarSistemas = New FontAwesome.Sharp.IconPictureBox()
        Me.panelProyectosSistemas = New SistemasVentas.ControlPanel()
        Me.PanelNotificaciones.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminarNotificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.btnVolverAsistente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDatosPodio.SuspendLayout()
        Me.panelSeleccionarEmpresas.SuspendLayout()
        CType(Me.barraAvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericOrdenSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericOrdenDpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.btnVolverDatosBasicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosBasicos.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.panel.SuspendLayout()
        CType(Me.btnVolver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAsistentes.SuspendLayout()
        CType(Me.pictureEliminarAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEliminarAutorizantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEliminarSolicitante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosRecurrencia.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelProyectosGenerales.SuspendLayout()
        CType(Me.pictureEliminarGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEliminarSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelProyectosSistemas.SuspendLayout()
        Me.SuspendLayout()
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
        Me.PanelNotificaciones.Controls.Add(Me.Label28)
        Me.PanelNotificaciones.Controls.Add(Me.Panel3)
        Me.PanelNotificaciones.Controls.Add(Me.Label30)
        Me.PanelNotificaciones.Controls.Add(Me.Label32)
        Me.PanelNotificaciones.Location = New System.Drawing.Point(36, 36)
        Me.PanelNotificaciones.Name = "PanelNotificaciones"
        Me.PanelNotificaciones.Size = New System.Drawing.Size(488, 428)
        Me.PanelNotificaciones.TabIndex = 128
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
        Me.MenuStrip1.Size = New System.Drawing.Size(272, 44)
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
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(31, 251)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(211, 19)
        Me.Label28.TabIndex = 97
        Me.Label28.Text = "Tiempo Antes del Evento"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnVolverAsistente)
        Me.Panel3.Controls.Add(Me.Label29)
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
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(46, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(127, 19)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Notificaciones"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(31, 69)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(193, 19)
        Me.Label30.TabIndex = 84
        Me.Label30.Text = "Notificaciones Activas"
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
        'panelDatosPodio
        '
        Me.panelDatosPodio.BackColor = System.Drawing.Color.White
        Me.panelDatosPodio.BorderRadius = 12
        Me.panelDatosPodio.Controls.Add(Me.panelProyectosGenerales)
        Me.panelDatosPodio.Controls.Add(Me.panelProyectosSistemas)
        Me.panelDatosPodio.Controls.Add(Me.panelSeleccionarEmpresas)
        Me.panelDatosPodio.Controls.Add(Me.txtProyectoSistemas)
        Me.panelDatosPodio.Controls.Add(Me.barraAvance)
        Me.panelDatosPodio.Controls.Add(Me.btnContinuarDatosPodio)
        Me.panelDatosPodio.Controls.Add(Me.maskHorasExtras)
        Me.panelDatosPodio.Controls.Add(Me.maskHorasAcumuladas)
        Me.panelDatosPodio.Controls.Add(Me.numericOrdenSistemas)
        Me.panelDatosPodio.Controls.Add(Me.numericOrdenDpt)
        Me.panelDatosPodio.Controls.Add(Me.textPlanAccion)
        Me.panelDatosPodio.Controls.Add(Me.Label4)
        Me.panelDatosPodio.Controls.Add(Me.comboCategorias)
        Me.panelDatosPodio.Controls.Add(Me.comboArea)
        Me.panelDatosPodio.Controls.Add(Me.Label11)
        Me.panelDatosPodio.Controls.Add(Me.Label12)
        Me.panelDatosPodio.Controls.Add(Me.Label14)
        Me.panelDatosPodio.Controls.Add(Me.Label15)
        Me.panelDatosPodio.Controls.Add(Me.Label20)
        Me.panelDatosPodio.Controls.Add(Me.comboPrioridad)
        Me.panelDatosPodio.Controls.Add(Me.comboDepartamento)
        Me.panelDatosPodio.Controls.Add(Me.Label16)
        Me.panelDatosPodio.Controls.Add(Me.comboEmpresa)
        Me.panelDatosPodio.Controls.Add(Me.Label17)
        Me.panelDatosPodio.Controls.Add(Me.Panel5)
        Me.panelDatosPodio.Controls.Add(Me.Label19)
        Me.panelDatosPodio.Controls.Add(Me.Label23)
        Me.panelDatosPodio.Controls.Add(Me.Label24)
        Me.panelDatosPodio.Controls.Add(Me.Label25)
        Me.panelDatosPodio.Controls.Add(Me.comboStatus)
        Me.panelDatosPodio.Controls.Add(Me.Label27)
        Me.panelDatosPodio.Controls.Add(Me.Label31)
        Me.panelDatosPodio.Location = New System.Drawing.Point(531, 21)
        Me.panelDatosPodio.Name = "panelDatosPodio"
        Me.panelDatosPodio.Size = New System.Drawing.Size(877, 713)
        Me.panelDatosPodio.TabIndex = 127
        '
        'panelSeleccionarEmpresas
        '
        Me.panelSeleccionarEmpresas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelSeleccionarEmpresas.BackColor = System.Drawing.Color.White
        Me.panelSeleccionarEmpresas.BorderRadius = 8
        Me.panelSeleccionarEmpresas.Controls.Add(Me.btnCancelarEmpresas)
        Me.panelSeleccionarEmpresas.Controls.Add(Me.btnEmpresas)
        Me.panelSeleccionarEmpresas.Controls.Add(Me.listEmpresas)
        Me.panelSeleccionarEmpresas.Controls.Add(Me.Label41)
        Me.panelSeleccionarEmpresas.Location = New System.Drawing.Point(432, 71)
        Me.panelSeleccionarEmpresas.Name = "panelSeleccionarEmpresas"
        Me.panelSeleccionarEmpresas.Size = New System.Drawing.Size(373, 408)
        Me.panelSeleccionarEmpresas.TabIndex = 129
        '
        'btnCancelarEmpresas
        '
        Me.btnCancelarEmpresas.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarEmpresas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarEmpresas.FlatAppearance.BorderSize = 0
        Me.btnCancelarEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarEmpresas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEmpresas.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarEmpresas.Location = New System.Drawing.Point(68, 350)
        Me.btnCancelarEmpresas.Name = "btnCancelarEmpresas"
        Me.btnCancelarEmpresas.Size = New System.Drawing.Size(106, 35)
        Me.btnCancelarEmpresas.TabIndex = 122
        Me.btnCancelarEmpresas.Text = "Cancelar"
        Me.btnCancelarEmpresas.UseVisualStyleBackColor = False
        '
        'btnEmpresas
        '
        Me.btnEmpresas.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnEmpresas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmpresas.FlatAppearance.BorderSize = 0
        Me.btnEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmpresas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpresas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEmpresas.Location = New System.Drawing.Point(191, 349)
        Me.btnEmpresas.Name = "btnEmpresas"
        Me.btnEmpresas.Size = New System.Drawing.Size(106, 35)
        Me.btnEmpresas.TabIndex = 121
        Me.btnEmpresas.Text = "Listo"
        Me.btnEmpresas.UseVisualStyleBackColor = False
        '
        'listEmpresas
        '
        Me.listEmpresas.Enabled = False
        Me.listEmpresas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listEmpresas.FormattingEnabled = True
        Me.listEmpresas.Items.AddRange(New Object() {"Todas", "Incorporated Express SA de CV", "FUNERA", "OrderExpress Inc", "OEPM", "OECC", "OE Financial Inc", "LOFT SA de CV", "JP Casa de Cambio Inc", "J&P Financial Inc", "JP SofiExpress", "REALIZA"})
        Me.listEmpresas.Location = New System.Drawing.Point(49, 77)
        Me.listEmpresas.Name = "listEmpresas"
        Me.listEmpresas.Size = New System.Drawing.Size(275, 256)
        Me.listEmpresas.TabIndex = 116
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(101, 31)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(170, 20)
        Me.Label41.TabIndex = 113
        Me.Label41.Text = "Seleccionar empresas"
        '
        'txtProyectoSistemas
        '
        Me.txtProyectoSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.txtProyectoSistemas.Location = New System.Drawing.Point(34, 330)
        Me.txtProyectoSistemas.Name = "txtProyectoSistemas"
        Me.txtProyectoSistemas.Size = New System.Drawing.Size(249, 26)
        Me.txtProyectoSistemas.TabIndex = 143
        '
        'barraAvance
        '
        Me.barraAvance.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.barraAvance.Location = New System.Drawing.Point(103, 650)
        Me.barraAvance.Name = "barraAvance"
        Me.barraAvance.Size = New System.Drawing.Size(221, 26)
        Me.barraAvance.TabIndex = 142
        '
        'btnContinuarDatosPodio
        '
        Me.btnContinuarDatosPodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuarDatosPodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContinuarDatosPodio.FlatAppearance.BorderSize = 0
        Me.btnContinuarDatosPodio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinuarDatosPodio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuarDatosPodio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnContinuarDatosPodio.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnContinuarDatosPodio.IconColor = System.Drawing.Color.Black
        Me.btnContinuarDatosPodio.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnContinuarDatosPodio.IconSize = 16
        Me.btnContinuarDatosPodio.Location = New System.Drawing.Point(367, 637)
        Me.btnContinuarDatosPodio.Name = "btnContinuarDatosPodio"
        Me.btnContinuarDatosPodio.Size = New System.Drawing.Size(143, 42)
        Me.btnContinuarDatosPodio.TabIndex = 141
        Me.btnContinuarDatosPodio.Text = "Continuar"
        Me.btnContinuarDatosPodio.UseVisualStyleBackColor = False
        '
        'maskHorasExtras
        '
        Me.maskHorasExtras.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.maskHorasExtras.Location = New System.Drawing.Point(590, 581)
        Me.maskHorasExtras.Mask = "00:00:00"
        Me.maskHorasExtras.Name = "maskHorasExtras"
        Me.maskHorasExtras.Size = New System.Drawing.Size(251, 26)
        Me.maskHorasExtras.TabIndex = 139
        Me.maskHorasExtras.ValidatingType = GetType(Date)
        '
        'maskHorasAcumuladas
        '
        Me.maskHorasAcumuladas.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.maskHorasAcumuladas.Location = New System.Drawing.Point(311, 581)
        Me.maskHorasAcumuladas.Mask = "00:00:00"
        Me.maskHorasAcumuladas.Name = "maskHorasAcumuladas"
        Me.maskHorasAcumuladas.Size = New System.Drawing.Size(251, 26)
        Me.maskHorasAcumuladas.TabIndex = 138
        Me.maskHorasAcumuladas.ValidatingType = GetType(Date)
        '
        'numericOrdenSistemas
        '
        Me.numericOrdenSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.numericOrdenSistemas.Location = New System.Drawing.Point(34, 582)
        Me.numericOrdenSistemas.Name = "numericOrdenSistemas"
        Me.numericOrdenSistemas.Size = New System.Drawing.Size(250, 26)
        Me.numericOrdenSistemas.TabIndex = 135
        '
        'numericOrdenDpt
        '
        Me.numericOrdenDpt.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.numericOrdenDpt.Location = New System.Drawing.Point(592, 293)
        Me.numericOrdenDpt.Name = "numericOrdenDpt"
        Me.numericOrdenDpt.Size = New System.Drawing.Size(250, 26)
        Me.numericOrdenDpt.TabIndex = 134
        '
        'textPlanAccion
        '
        Me.textPlanAccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.textPlanAccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.textPlanAccion.BorderFocusColor = System.Drawing.Color.Black
        Me.textPlanAccion.BorderRadius = 8
        Me.textPlanAccion.BorderSize = 1
        Me.textPlanAccion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPlanAccion.Location = New System.Drawing.Point(32, 387)
        Me.textPlanAccion.Multiline = True
        Me.textPlanAccion.Name = "textPlanAccion"
        Me.textPlanAccion.Padding = New System.Windows.Forms.Padding(7)
        Me.textPlanAccion.PasswordChar = False
        Me.textPlanAccion.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.textPlanAccion.PlaceholderText = ""
        Me.textPlanAccion.Size = New System.Drawing.Size(810, 144)
        Me.textPlanAccion.TabIndex = 133
        Me.textPlanAccion.Texts = ""
        Me.textPlanAccion.UnderlinedStyle = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 355)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 18)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Plan de Trabajo / Acción"
        '
        'comboCategorias
        '
        Me.comboCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboCategorias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboCategorias.FormattingEnabled = True
        Me.comboCategorias.Items.AddRange(New Object() {"[ADMIN] Acuerdos de Confidencialidad Con Terceros", "[ADMIN] Auditorias", "[ADMIN] Manuales", "[ADMIN] Plan de Contingencia", "[ADMIN] Podio", "[DESARROLLO] Actualizacion de Certificados", "[DESARROLLO] Correccion de Error", "[DESARROLLO] Desarrollo General", "[DESARROLLO] Entrega (Spring de Scrum - 15 Dias)", "[DESARROLLO] Entrega (Spring de Scrum - 15 Dias)", "[DESARROLLO] Error de Corresponsal", "[DESARROLLO] Integracion de Corresponsal", "[DESARROLLO] Importación Contable Mensual", "[DESARROLLO] Mantenimiento", "[DESARROLLO] Mejora en Sistemas/Modulo", "[DESARROLLO] Publicacion", "[DESARROLLO] Soporte en Produccion", "[SOPORTE] Actualizacion De Imagenes En Pantallas", "[SOPORTE] 1Password - Alta", "[SOPORTE] 1Password - Baja", "[SOPORTE] 1Password - Modificacion", "[SOPORTE] Alta de Corresponsal/Agente", "[SOPORTE] Acceso a Red Inalambrica", "[SOPORTE] Alta de Servicio o Producto", "[SOPORTE] Cambio de Contrasena", "[SOPORTE] Camaras", "[SOPORTE] Capacitaciones", "[SOPORTE] Correo Electrónico - Alta", "[SOPORTE] Correo Electrónico - Baja", "[SOPORTE] Correo Electrónico - Reasignacion", "[SOPORTE] Correo Electrónico - Suspension", "[SOPORTE] Equipo de Computo", "[SOPORTE] Error de Usuario", "[SOPORTE] Extensión Telefónica", "[SOPORTE] Google Suite", "[SOPORTE] Instalación y/o Configuración de Software", "[SOPORTE] Impresoras y/o Scanners", "[SOPORTE] Mantenimiento de Equipo", "[SOPORTE] Produccion", "[SOPORTE] Solicitud de Equipo", "[SOPORTE] Soporte General", "[SOPORTE] TeamViewer", "[SOPORTE] Usuarios - Alta", "[SOPORTE] Usuarios - Baja", "[SOPORTE] Usuario - Baja", "[SOPORTE] Usuarios - Modificación", "[INFRAESTRUCTURA] Acceso a Red WiFi", "[INFRAESTRUCTURA] Comunicaciones", "[INFRAESTRUCTURA] Conmutador", "[INFRAESTRUCTURA] Mantenimiento de Servidores y/o Redes", "[INFRAESTRUCTURA] Monitoreo", "[INFRAESTRUCTURA] Monitoreo", "[INFRAESTRUCTURA] Redes", "[INFRAESTRUCTURA] Redes - Monitoreo y Analisis de Logs", "[INFRAESTRUCTURA] Servidores", "[INFRAESTRUCTURA] Redes - VPN", "[INFRAESTRUCTURA] Reporte", "[INFRAESTRUCTURA] Solicitud de Equipo", "[INFRAESTRUCTURA] Servidores", "[INFRAESTRUCTURA] Servidores - Almacenamiento SAN", "[INFRAESTRUCTURA] Servidores - Based de Datos", "[INFRAESTRUCTURA] Servidores - Migracion de Sistema Operativo", "[INFRAESTRUCTURA] Seguridad", "[INFRAESTRUCTURA] Seguridad - Actividad Sospechosa", "[INFRAESTRUCTURA] Servidores - Backup y/o Replica", "[INFRAESTRUCTURA] Seguridad - Actualización de Parches", "[INFRAESTRUCTURA] Seguridad - Antivirus", "[INFRAESTRUCTURA] Seguridad - Incidente de Acceso", "[INFRAESTRUCTURA] Seguridad - Incidente de Antivirus", "[INFRAESTRUCTURA] Seguridad - Incidente de Firewalls", "[INFRAESTRUCTURA] Seguridad - Incidente de Redes", "[INFRAESTRUCTURA] Seguridad - Monitoreo", "[INFRAESTRUCTURA] Seguridad - Análisis de Vulnerabilidades", "[INFRAESTRUCTURA] SQL - Store Procedure", "[SEGURIDAD] Auditoria Interna"})
        Me.comboCategorias.Location = New System.Drawing.Point(34, 195)
        Me.comboCategorias.Name = "comboCategorias"
        Me.comboCategorias.Size = New System.Drawing.Size(251, 28)
        Me.comboCategorias.TabIndex = 131
        '
        'comboArea
        '
        Me.comboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboArea.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboArea.FormattingEnabled = True
        Me.comboArea.Items.AddRange(New Object() {"Soporte", "Desarrollo", "Infraestructura", "Administracion/Direccion"})
        Me.comboArea.Location = New System.Drawing.Point(592, 104)
        Me.comboArea.Name = "comboArea"
        Me.comboArea.Size = New System.Drawing.Size(251, 28)
        Me.comboArea.TabIndex = 130
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(588, 552)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 18)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "Horas Extras"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(309, 552)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 18)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Horas Acumuladas"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(28, 552)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(227, 18)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "Orden de Prioridad (Sistemas)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(587, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(210, 18)
        Me.Label15.TabIndex = 122
        Me.Label15.Text = "Orden de Prioridad del Dpt."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(308, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(139, 18)
        Me.Label20.TabIndex = 119
        Me.Label20.Text = "Proyecto General"
        '
        'comboPrioridad
        '
        Me.comboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboPrioridad.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboPrioridad.FormattingEnabled = True
        Me.comboPrioridad.Items.AddRange(New Object() {"Alta", "Normal", "Baja", "De Acuerdo a Fecha de Entrega"})
        Me.comboPrioridad.Location = New System.Drawing.Point(313, 195)
        Me.comboPrioridad.Name = "comboPrioridad"
        Me.comboPrioridad.Size = New System.Drawing.Size(250, 28)
        Me.comboPrioridad.TabIndex = 118
        '
        'comboDepartamento
        '
        Me.comboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDepartamento.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDepartamento.FormattingEnabled = True
        Me.comboDepartamento.Items.AddRange(New Object() {"Administracion", "Agencias", "Agentes", "Callcenter", "Cumplimiento MX", "Cumplimiento USA", "Cobranza", "Contabilidad", "Control Interno", "Correponsales o Proveedores", "Cheques", "DIRECCION", "Marketing", "Monitoreo", "Operaciones", "Publicidad", "Recursos Humanos", "Sistemas", "Supervision", "Tesoreria", "Ventas (Aociadas/Oficinas)"})
        Me.comboDepartamento.Location = New System.Drawing.Point(313, 104)
        Me.comboDepartamento.Name = "comboDepartamento"
        Me.comboDepartamento.Size = New System.Drawing.Size(251, 28)
        Me.comboDepartamento.TabIndex = 117
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(29, 263)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(164, 18)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Proyecto de Sistemas"
        '
        'comboEmpresa
        '
        Me.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEmpresa.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEmpresa.FormattingEnabled = True
        Me.comboEmpresa.Items.AddRange(New Object() {"Todas", "Incorporated Express SA de CV", "FUNERA", "OrderExpress Inc", "OEPM", "OECC", "OE Financial Inc", "LOFT SA de CV", "JP Casa de Cambio Inc", "J&P Financial Inc", "JP SofiExpress", "REALIZA"})
        Me.comboEmpresa.Location = New System.Drawing.Point(34, 104)
        Me.comboEmpresa.Name = "comboEmpresa"
        Me.comboEmpresa.Size = New System.Drawing.Size(251, 28)
        Me.comboEmpresa.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(309, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 18)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "Prioridad"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnVolverDatosBasicos)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(877, 50)
        Me.Panel5.TabIndex = 0
        '
        'btnVolverDatosBasicos
        '
        Me.btnVolverDatosBasicos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolverDatosBasicos.BackColor = System.Drawing.Color.White
        Me.btnVolverDatosBasicos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolverDatosBasicos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverDatosBasicos.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolverDatosBasicos.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverDatosBasicos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolverDatosBasicos.Location = New System.Drawing.Point(811, 15)
        Me.btnVolverDatosBasicos.Name = "btnVolverDatosBasicos"
        Me.btnVolverDatosBasicos.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverDatosBasicos.TabIndex = 1
        Me.btnVolverDatosBasicos.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(46, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 19)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Datos Podio"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(31, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 18)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Empresa"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(311, 69)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(115, 18)
        Me.Label23.TabIndex = 85
        Me.Label23.Text = "Departamento"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(589, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 18)
        Me.Label24.TabIndex = 87
        Me.Label24.Text = "Area de Sistemas"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(32, 162)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 18)
        Me.Label25.TabIndex = 88
        Me.Label25.Text = "Categorias"
        '
        'comboStatus
        '
        Me.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboStatus.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Items.AddRange(New Object() {"No comenzada / Pendiente", "En Analisis De Requerimientos", "En Desarrollo", "En Pruebas", "En Monitoreo", "Finalizada", "Aplazada", "A la espera de otra persona", "Pendiente Confirmar Actividad", "Pendiente de Publicar", "Permanente", "Publicado", "Suspendida", "Trabajando"})
        Me.comboStatus.Location = New System.Drawing.Point(592, 195)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(250, 28)
        Me.comboStatus.TabIndex = 91
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(588, 160)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 18)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Estatus"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(31, 649)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 18)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "Avance"
        '
        'PanelDatosBasicos
        '
        Me.PanelDatosBasicos.BackColor = System.Drawing.Color.White
        Me.PanelDatosBasicos.BorderRadius = 12
        Me.PanelDatosBasicos.Controls.Add(Me.MenuStrip2)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventDescrip)
        Me.PanelDatosBasicos.Controls.Add(Me.Label1)
        Me.PanelDatosBasicos.Controls.Add(Me.comboRecurrencia)
        Me.PanelDatosBasicos.Controls.Add(Me.Label2)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventUbicacion)
        Me.PanelDatosBasicos.Controls.Add(Me.txtEventName)
        Me.PanelDatosBasicos.Controls.Add(Me.panel)
        Me.PanelDatosBasicos.Controls.Add(Me.Label5)
        Me.PanelDatosBasicos.Controls.Add(Me.Label6)
        Me.PanelDatosBasicos.Controls.Add(Me.Label7)
        Me.PanelDatosBasicos.Controls.Add(Me.Label8)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaInicio)
        Me.PanelDatosBasicos.Controls.Add(Me.eventFechaFinal)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventDispo)
        Me.PanelDatosBasicos.Controls.Add(Me.comboEventVisibilidad)
        Me.PanelDatosBasicos.Controls.Add(Me.Label9)
        Me.PanelDatosBasicos.Controls.Add(Me.Label39)
        Me.PanelDatosBasicos.Location = New System.Drawing.Point(898, 821)
        Me.PanelDatosBasicos.Name = "PanelDatosBasicos"
        Me.PanelDatosBasicos.Size = New System.Drawing.Size(600, 625)
        Me.PanelDatosBasicos.TabIndex = 126
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCrearEvento, Me.btnContinuarActualizar})
        Me.MenuStrip2.Location = New System.Drawing.Point(314, 554)
        Me.MenuStrip2.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(232, 44)
        Me.MenuStrip2.TabIndex = 116
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 345)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Descripción"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 19)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Recurrencia"
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
        Me.panel.Controls.Add(Me.Label3)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Datos Básicos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 19)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Titulo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(311, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 19)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Ubicación"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Incio Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 19)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Finalizar Fecha"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(310, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 19)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "Visibilidad"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(31, 566)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(125, 19)
        Me.Label39.TabIndex = 90
        Me.Label39.Text = "Disponibilidad"
        '
        'PanelAsistentes
        '
        Me.PanelAsistentes.BackColor = System.Drawing.Color.White
        Me.PanelAsistentes.BorderRadius = 12
        Me.PanelAsistentes.Controls.Add(Me.pictureEliminarAsignados)
        Me.PanelAsistentes.Controls.Add(Me.pictureEliminarAutorizantes)
        Me.PanelAsistentes.Controls.Add(Me.Label38)
        Me.PanelAsistentes.Controls.Add(Me.Label37)
        Me.PanelAsistentes.Controls.Add(Me.comboAsignados)
        Me.PanelAsistentes.Controls.Add(Me.comboAtorizantes)
        Me.PanelAsistentes.Controls.Add(Me.Label26)
        Me.PanelAsistentes.Controls.Add(Me.comboSolicitantes)
        Me.PanelAsistentes.Controls.Add(Me.comboAsignadoA)
        Me.PanelAsistentes.Controls.Add(Me.btnContinuar)
        Me.PanelAsistentes.Controls.Add(Me.pictureEliminarSolicitante)
        Me.PanelAsistentes.Controls.Add(Me.comboAutoriza)
        Me.PanelAsistentes.Controls.Add(Me.comboSolicitante)
        Me.PanelAsistentes.Controls.Add(Me.Panel4)
        Me.PanelAsistentes.Controls.Add(Me.Label34)
        Me.PanelAsistentes.Controls.Add(Me.Label35)
        Me.PanelAsistentes.Controls.Add(Me.Label36)
        Me.PanelAsistentes.Location = New System.Drawing.Point(411, 823)
        Me.PanelAsistentes.Name = "PanelAsistentes"
        Me.PanelAsistentes.Size = New System.Drawing.Size(473, 450)
        Me.PanelAsistentes.TabIndex = 123
        '
        'pictureEliminarAsignados
        '
        Me.pictureEliminarAsignados.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pictureEliminarAsignados.ForeColor = System.Drawing.Color.Red
        Me.pictureEliminarAsignados.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.pictureEliminarAsignados.IconColor = System.Drawing.Color.Red
        Me.pictureEliminarAsignados.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.pictureEliminarAsignados.Location = New System.Drawing.Point(422, 296)
        Me.pictureEliminarAsignados.Name = "pictureEliminarAsignados"
        Me.pictureEliminarAsignados.Size = New System.Drawing.Size(32, 32)
        Me.pictureEliminarAsignados.TabIndex = 130
        Me.pictureEliminarAsignados.TabStop = False
        '
        'pictureEliminarAutorizantes
        '
        Me.pictureEliminarAutorizantes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pictureEliminarAutorizantes.ForeColor = System.Drawing.Color.Red
        Me.pictureEliminarAutorizantes.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.pictureEliminarAutorizantes.IconColor = System.Drawing.Color.Red
        Me.pictureEliminarAutorizantes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.pictureEliminarAutorizantes.Location = New System.Drawing.Point(422, 193)
        Me.pictureEliminarAutorizantes.Name = "pictureEliminarAutorizantes"
        Me.pictureEliminarAutorizantes.Size = New System.Drawing.Size(32, 32)
        Me.pictureEliminarAutorizantes.TabIndex = 129
        Me.pictureEliminarAutorizantes.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(234, 263)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(148, 18)
        Me.Label38.TabIndex = 128
        Me.Label38.Text = "Usuarios Asignados"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(234, 163)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(174, 18)
        Me.Label37.TabIndex = 127
        Me.Label37.Text = "Usuarios que Autorizan"
        '
        'comboAsignados
        '
        Me.comboAsignados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAsignados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAsignados.FormattingEnabled = True
        Me.comboAsignados.Location = New System.Drawing.Point(237, 300)
        Me.comboAsignados.Name = "comboAsignados"
        Me.comboAsignados.Size = New System.Drawing.Size(179, 28)
        Me.comboAsignados.TabIndex = 126
        '
        'comboAtorizantes
        '
        Me.comboAtorizantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAtorizantes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAtorizantes.FormattingEnabled = True
        Me.comboAtorizantes.Location = New System.Drawing.Point(237, 197)
        Me.comboAtorizantes.Name = "comboAtorizantes"
        Me.comboAtorizantes.Size = New System.Drawing.Size(179, 28)
        Me.comboAtorizantes.TabIndex = 125
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(234, 69)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(155, 18)
        Me.Label26.TabIndex = 124
        Me.Label26.Text = "Usuarios Solicitantes"
        '
        'comboSolicitantes
        '
        Me.comboSolicitantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSolicitantes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboSolicitantes.FormattingEnabled = True
        Me.comboSolicitantes.Location = New System.Drawing.Point(237, 106)
        Me.comboSolicitantes.Name = "comboSolicitantes"
        Me.comboSolicitantes.Size = New System.Drawing.Size(179, 28)
        Me.comboSolicitantes.TabIndex = 123
        '
        'comboAsignadoA
        '
        Me.comboAsignadoA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboAsignadoA.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAsignadoA.FormattingEnabled = True
        Me.comboAsignadoA.Location = New System.Drawing.Point(31, 300)
        Me.comboAsignadoA.Name = "comboAsignadoA"
        Me.comboAsignadoA.Size = New System.Drawing.Size(179, 28)
        Me.comboAsignadoA.TabIndex = 122
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
        Me.btnContinuar.Location = New System.Drawing.Point(155, 374)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(163, 42)
        Me.btnContinuar.TabIndex = 114
        Me.btnContinuar.Text = "Continuar/Omitir"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'pictureEliminarSolicitante
        '
        Me.pictureEliminarSolicitante.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pictureEliminarSolicitante.ForeColor = System.Drawing.Color.Red
        Me.pictureEliminarSolicitante.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.pictureEliminarSolicitante.IconColor = System.Drawing.Color.Red
        Me.pictureEliminarSolicitante.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.pictureEliminarSolicitante.Location = New System.Drawing.Point(422, 106)
        Me.pictureEliminarSolicitante.Name = "pictureEliminarSolicitante"
        Me.pictureEliminarSolicitante.Size = New System.Drawing.Size(32, 32)
        Me.pictureEliminarSolicitante.TabIndex = 120
        Me.pictureEliminarSolicitante.TabStop = False
        '
        'comboAutoriza
        '
        Me.comboAutoriza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboAutoriza.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAutoriza.FormattingEnabled = True
        Me.comboAutoriza.Location = New System.Drawing.Point(30, 197)
        Me.comboAutoriza.Name = "comboAutoriza"
        Me.comboAutoriza.Size = New System.Drawing.Size(178, 28)
        Me.comboAutoriza.TabIndex = 119
        '
        'comboSolicitante
        '
        Me.comboSolicitante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboSolicitante.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboSolicitante.FormattingEnabled = True
        Me.comboSolicitante.Location = New System.Drawing.Point(30, 106)
        Me.comboSolicitante.Name = "comboSolicitante"
        Me.comboSolicitante.Size = New System.Drawing.Size(179, 28)
        Me.comboSolicitante.TabIndex = 117
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.IconPictureBox2)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(473, 50)
        Me.Panel4.TabIndex = 0
        '
        'IconPictureBox2
        '
        Me.IconPictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox2.BackColor = System.Drawing.Color.White
        Me.IconPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconPictureBox2.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox2.Location = New System.Drawing.Point(407, 15)
        Me.IconPictureBox2.Name = "IconPictureBox2"
        Me.IconPictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox2.TabIndex = 1
        Me.IconPictureBox2.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(46, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(107, 19)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Datos Podio"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(28, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(85, 18)
        Me.Label34.TabIndex = 84
        Me.Label34.Text = "Solicitante"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(28, 263)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(92, 18)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "Asignado a"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(28, 163)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(68, 18)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Autoriza"
        '
        'PanelDatosRecurrencia
        '
        Me.PanelDatosRecurrencia.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label10)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label21)
        Me.PanelDatosRecurrencia.Controls.Add(Me.Label22)
        Me.PanelDatosRecurrencia.Location = New System.Drawing.Point(32, 458)
        Me.PanelDatosRecurrencia.Name = "PanelDatosRecurrencia"
        Me.PanelDatosRecurrencia.Size = New System.Drawing.Size(373, 476)
        Me.PanelDatosRecurrencia.TabIndex = 121
        '
        'btnCancelarRecurrencia
        '
        Me.btnCancelarRecurrencia.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarRecurrencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarRecurrencia.FlatAppearance.BorderSize = 0
        Me.btnCancelarRecurrencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarRecurrencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarRecurrencia.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarRecurrencia.Location = New System.Drawing.Point(70, 418)
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
        Me.btnListoRecurrencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListoRecurrencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnListoRecurrencia.Location = New System.Drawing.Point(197, 418)
        Me.btnListoRecurrencia.Name = "btnListoRecurrencia"
        Me.btnListoRecurrencia.Size = New System.Drawing.Size(106, 35)
        Me.btnListoRecurrencia.TabIndex = 121
        Me.btnListoRecurrencia.Text = "Listo"
        Me.btnListoRecurrencia.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(26, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 20)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Finaliza"
        '
        'txtOcurrencias
        '
        Me.txtOcurrencias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcurrencias.Location = New System.Drawing.Point(152, 310)
        Me.txtOcurrencias.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txtOcurrencias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtOcurrencias.Name = "txtOcurrencias"
        Me.txtOcurrencias.Size = New System.Drawing.Size(79, 26)
        Me.txtOcurrencias.TabIndex = 119
        Me.txtOcurrencias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbtnFecha
        '
        Me.rbtnFecha.AutoSize = True
        Me.rbtnFecha.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFecha.Location = New System.Drawing.Point(30, 365)
        Me.rbtnFecha.Name = "rbtnFecha"
        Me.rbtnFecha.Size = New System.Drawing.Size(88, 24)
        Me.rbtnFecha.TabIndex = 118
        Me.rbtnFecha.Text = "Hasta el"
        Me.rbtnFecha.UseVisualStyleBackColor = True
        '
        'rbtnConteo
        '
        Me.rbtnConteo.AutoSize = True
        Me.rbtnConteo.Checked = True
        Me.rbtnConteo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnConteo.Location = New System.Drawing.Point(30, 310)
        Me.rbtnConteo.Name = "rbtnConteo"
        Me.rbtnConteo.Size = New System.Drawing.Size(116, 24)
        Me.rbtnConteo.TabIndex = 117
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
        Me.listDias.Location = New System.Drawing.Point(204, 84)
        Me.listDias.Name = "listDias"
        Me.listDias.Size = New System.Drawing.Size(139, 151)
        Me.listDias.TabIndex = 116
        '
        'dateRecuFinal
        '
        Me.dateRecuFinal.Enabled = False
        Me.dateRecuFinal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateRecuFinal.Location = New System.Drawing.Point(124, 363)
        Me.dateRecuFinal.Name = "dateRecuFinal"
        Me.dateRecuFinal.Size = New System.Drawing.Size(219, 26)
        Me.dateRecuFinal.TabIndex = 115
        '
        'comboFrecuencia
        '
        Me.comboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFrecuencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboFrecuencia.FormattingEnabled = True
        Me.comboFrecuencia.Items.AddRange(New Object() {"No repetir", "Diariamente", "Semanalmente", "Mensualmente", "Anualmente"})
        Me.comboFrecuencia.Location = New System.Drawing.Point(204, 32)
        Me.comboFrecuencia.Name = "comboFrecuencia"
        Me.comboFrecuencia.Size = New System.Drawing.Size(139, 28)
        Me.comboFrecuencia.TabIndex = 114
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(26, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 20)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Dias de la semana"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(26, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(171, 20)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "Frecuencia repeticion"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(244, 312)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 20)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Ocurrencias"
        '
        'panelProyectosGenerales
        '
        Me.panelProyectosGenerales.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelProyectosGenerales.BackColor = System.Drawing.Color.White
        Me.panelProyectosGenerales.BorderRadius = 8
        Me.panelProyectosGenerales.Controls.Add(Me.pictureEliminarGeneral)
        Me.panelProyectosGenerales.Controls.Add(Me.comboProyectoGeneral)
        Me.panelProyectosGenerales.Controls.Add(Me.Label43)
        Me.panelProyectosGenerales.Controls.Add(Me.comboProyectosGenerales)
        Me.panelProyectosGenerales.Controls.Add(Me.btnCancelarProyectoGeneral)
        Me.panelProyectosGenerales.Controls.Add(Me.btnProyectosGenerales)
        Me.panelProyectosGenerales.Controls.Add(Me.Label44)
        Me.panelProyectosGenerales.Location = New System.Drawing.Point(10, 224)
        Me.panelProyectosGenerales.Name = "panelProyectosGenerales"
        Me.panelProyectosGenerales.Size = New System.Drawing.Size(373, 307)
        Me.panelProyectosGenerales.TabIndex = 145
        '
        'pictureEliminarGeneral
        '
        Me.pictureEliminarGeneral.BackColor = System.Drawing.Color.Transparent
        Me.pictureEliminarGeneral.ForeColor = System.Drawing.Color.Red
        Me.pictureEliminarGeneral.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.pictureEliminarGeneral.IconColor = System.Drawing.Color.Red
        Me.pictureEliminarGeneral.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.pictureEliminarGeneral.Location = New System.Drawing.Point(297, 174)
        Me.pictureEliminarGeneral.Name = "pictureEliminarGeneral"
        Me.pictureEliminarGeneral.Size = New System.Drawing.Size(32, 32)
        Me.pictureEliminarGeneral.TabIndex = 126
        Me.pictureEliminarGeneral.TabStop = False
        '
        'comboProyectoGeneral
        '
        Me.comboProyectoGeneral.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboProyectoGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboProyectoGeneral.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboProyectoGeneral.FormattingEnabled = True
        Me.comboProyectoGeneral.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboProyectoGeneral.Location = New System.Drawing.Point(59, 80)
        Me.comboProyectoGeneral.Name = "comboProyectoGeneral"
        Me.comboProyectoGeneral.Size = New System.Drawing.Size(250, 28)
        Me.comboProyectoGeneral.TabIndex = 125
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label43.Location = New System.Drawing.Point(61, 121)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(249, 16)
        Me.Label43.TabIndex = 124
        Me.Label43.Text = "Escribe el nombre del proyecto a buscar"
        '
        'comboProyectosGenerales
        '
        Me.comboProyectosGenerales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboProyectosGenerales.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboProyectosGenerales.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboProyectosGenerales.FormattingEnabled = True
        Me.comboProyectosGenerales.Location = New System.Drawing.Point(43, 177)
        Me.comboProyectosGenerales.Name = "comboProyectosGenerales"
        Me.comboProyectosGenerales.Size = New System.Drawing.Size(250, 28)
        Me.comboProyectosGenerales.TabIndex = 123
        '
        'btnCancelarProyectoGeneral
        '
        Me.btnCancelarProyectoGeneral.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarProyectoGeneral.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarProyectoGeneral.FlatAppearance.BorderSize = 0
        Me.btnCancelarProyectoGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarProyectoGeneral.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarProyectoGeneral.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarProyectoGeneral.Location = New System.Drawing.Point(83, 239)
        Me.btnCancelarProyectoGeneral.Name = "btnCancelarProyectoGeneral"
        Me.btnCancelarProyectoGeneral.Size = New System.Drawing.Size(106, 35)
        Me.btnCancelarProyectoGeneral.TabIndex = 122
        Me.btnCancelarProyectoGeneral.Text = "Cancelar"
        Me.btnCancelarProyectoGeneral.UseVisualStyleBackColor = False
        '
        'btnProyectosGenerales
        '
        Me.btnProyectosGenerales.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnProyectosGenerales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProyectosGenerales.FlatAppearance.BorderSize = 0
        Me.btnProyectosGenerales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProyectosGenerales.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProyectosGenerales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnProyectosGenerales.Location = New System.Drawing.Point(206, 238)
        Me.btnProyectosGenerales.Name = "btnProyectosGenerales"
        Me.btnProyectosGenerales.Size = New System.Drawing.Size(106, 35)
        Me.btnProyectosGenerales.TabIndex = 121
        Me.btnProyectosGenerales.Text = "Listo"
        Me.btnProyectosGenerales.UseVisualStyleBackColor = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(75, 31)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(213, 20)
        Me.Label44.TabIndex = 113
        Me.Label44.Text = "Buscar proyectos generales"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(75, 31)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(223, 20)
        Me.Label40.TabIndex = 113
        Me.Label40.Text = "Buscar proyectos de sistemas"
        '
        'btnProyectosSistemas
        '
        Me.btnProyectosSistemas.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnProyectosSistemas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProyectosSistemas.FlatAppearance.BorderSize = 0
        Me.btnProyectosSistemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProyectosSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProyectosSistemas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnProyectosSistemas.Location = New System.Drawing.Point(206, 238)
        Me.btnProyectosSistemas.Name = "btnProyectosSistemas"
        Me.btnProyectosSistemas.Size = New System.Drawing.Size(106, 35)
        Me.btnProyectosSistemas.TabIndex = 121
        Me.btnProyectosSistemas.Text = "Listo"
        Me.btnProyectosSistemas.UseVisualStyleBackColor = False
        '
        'btnCancelarProyectosSistemas
        '
        Me.btnCancelarProyectosSistemas.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarProyectosSistemas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarProyectosSistemas.FlatAppearance.BorderSize = 0
        Me.btnCancelarProyectosSistemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarProyectosSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarProyectosSistemas.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarProyectosSistemas.Location = New System.Drawing.Point(83, 239)
        Me.btnCancelarProyectosSistemas.Name = "btnCancelarProyectosSistemas"
        Me.btnCancelarProyectosSistemas.Size = New System.Drawing.Size(106, 35)
        Me.btnCancelarProyectosSistemas.TabIndex = 122
        Me.btnCancelarProyectosSistemas.Text = "Cancelar"
        Me.btnCancelarProyectosSistemas.UseVisualStyleBackColor = False
        '
        'comboProyectosSistemas
        '
        Me.comboProyectosSistemas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboProyectosSistemas.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboProyectosSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboProyectosSistemas.FormattingEnabled = True
        Me.comboProyectosSistemas.Location = New System.Drawing.Point(43, 177)
        Me.comboProyectosSistemas.Name = "comboProyectosSistemas"
        Me.comboProyectosSistemas.Size = New System.Drawing.Size(250, 28)
        Me.comboProyectosSistemas.TabIndex = 123
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label42.Location = New System.Drawing.Point(61, 121)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(249, 16)
        Me.Label42.TabIndex = 124
        Me.Label42.Text = "Escribe el nombre del proyecto a buscar"
        '
        'comboProyectoSistemas
        '
        Me.comboProyectoSistemas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboProyectoSistemas.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboProyectoSistemas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboProyectoSistemas.FormattingEnabled = True
        Me.comboProyectoSistemas.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboProyectoSistemas.Location = New System.Drawing.Point(59, 80)
        Me.comboProyectoSistemas.Name = "comboProyectoSistemas"
        Me.comboProyectoSistemas.Size = New System.Drawing.Size(250, 28)
        Me.comboProyectoSistemas.TabIndex = 125
        '
        'pictureEliminarSistemas
        '
        Me.pictureEliminarSistemas.BackColor = System.Drawing.Color.Transparent
        Me.pictureEliminarSistemas.ForeColor = System.Drawing.Color.Red
        Me.pictureEliminarSistemas.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.pictureEliminarSistemas.IconColor = System.Drawing.Color.Red
        Me.pictureEliminarSistemas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.pictureEliminarSistemas.Location = New System.Drawing.Point(297, 174)
        Me.pictureEliminarSistemas.Name = "pictureEliminarSistemas"
        Me.pictureEliminarSistemas.Size = New System.Drawing.Size(32, 32)
        Me.pictureEliminarSistemas.TabIndex = 126
        Me.pictureEliminarSistemas.TabStop = False
        '
        'panelProyectosSistemas
        '
        Me.panelProyectosSistemas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelProyectosSistemas.BackColor = System.Drawing.Color.White
        Me.panelProyectosSistemas.BorderRadius = 8
        Me.panelProyectosSistemas.Controls.Add(Me.pictureEliminarSistemas)
        Me.panelProyectosSistemas.Controls.Add(Me.comboProyectoSistemas)
        Me.panelProyectosSistemas.Controls.Add(Me.Label42)
        Me.panelProyectosSistemas.Controls.Add(Me.comboProyectosSistemas)
        Me.panelProyectosSistemas.Controls.Add(Me.btnCancelarProyectosSistemas)
        Me.panelProyectosSistemas.Controls.Add(Me.btnProyectosSistemas)
        Me.panelProyectosSistemas.Controls.Add(Me.Label40)
        Me.panelProyectosSistemas.Location = New System.Drawing.Point(397, 138)
        Me.panelProyectosSistemas.Name = "panelProyectosSistemas"
        Me.panelProyectosSistemas.Size = New System.Drawing.Size(373, 307)
        Me.panelProyectosSistemas.TabIndex = 144
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1472, 1046)
        Me.Controls.Add(Me.PanelNotificaciones)
        Me.Controls.Add(Me.panelDatosPodio)
        Me.Controls.Add(Me.PanelDatosBasicos)
        Me.Controls.Add(Me.PanelAsistentes)
        Me.Controls.Add(Me.PanelDatosRecurrencia)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.PanelNotificaciones.ResumeLayout(False)
        Me.PanelNotificaciones.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminarNotificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.btnVolverAsistente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDatosPodio.ResumeLayout(False)
        Me.panelDatosPodio.PerformLayout()
        Me.panelSeleccionarEmpresas.ResumeLayout(False)
        Me.panelSeleccionarEmpresas.PerformLayout()
        CType(Me.barraAvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericOrdenSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericOrdenDpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.btnVolverDatosBasicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosBasicos.ResumeLayout(False)
        Me.PanelDatosBasicos.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        CType(Me.btnVolver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAsistentes.ResumeLayout(False)
        Me.PanelAsistentes.PerformLayout()
        CType(Me.pictureEliminarAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEliminarAutorizantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEliminarSolicitante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosRecurrencia.ResumeLayout(False)
        Me.PanelDatosRecurrencia.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelProyectosGenerales.ResumeLayout(False)
        Me.panelProyectosGenerales.PerformLayout()
        CType(Me.pictureEliminarGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEliminarSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelProyectosSistemas.ResumeLayout(False)
        Me.panelProyectosSistemas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelDatosRecurrencia As ControlPanel
    Friend WithEvents btnCancelarRecurrencia As Button
    Friend WithEvents btnListoRecurrencia As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtOcurrencias As NumericUpDown
    Friend WithEvents rbtnFecha As RadioButton
    Friend WithEvents rbtnConteo As RadioButton
    Friend WithEvents listDias As CheckedListBox
    Friend WithEvents dateRecuFinal As DateTimePicker
    Friend WithEvents comboFrecuencia As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents btnContinuar As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelAsistentes As ControlPanel
    Friend WithEvents comboSolicitante As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents IconPictureBox2 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents pictureEliminarSolicitante As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboAutoriza As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents comboSolicitantes As ComboBox
    Friend WithEvents comboAsignadoA As ComboBox
    Friend WithEvents pictureEliminarAsignados As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents pictureEliminarAutorizantes As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents comboAsignados As ComboBox
    Friend WithEvents comboAtorizantes As ComboBox
    Friend WithEvents PanelDatosBasicos As ControlPanel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnCrearEvento As ToolStripMenuItem
    Friend WithEvents btnContinuarActualizar As ToolStripMenuItem
    Friend WithEvents txtEventDescrip As ControlTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents comboRecurrencia As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEventUbicacion As ControlTextBox
    Friend WithEvents txtEventName As ControlTextBox
    Friend WithEvents panel As Panel
    Friend WithEvents btnVolver As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents eventFechaInicio As DateTimePicker
    Friend WithEvents eventFechaFinal As DateTimePicker
    Friend WithEvents comboEventDispo As ComboBox
    Friend WithEvents comboEventVisibilidad As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents panelDatosPodio As ControlPanel
    Friend WithEvents maskHorasExtras As MaskedTextBox
    Friend WithEvents maskHorasAcumuladas As MaskedTextBox
    Friend WithEvents numericOrdenSistemas As NumericUpDown
    Friend WithEvents numericOrdenDpt As NumericUpDown
    Friend WithEvents textPlanAccion As ControlTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents comboCategorias As ComboBox
    Friend WithEvents comboArea As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents comboPrioridad As ComboBox
    Friend WithEvents comboDepartamento As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents comboEmpresa As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnVolverDatosBasicos As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents btnContinuarDatosPodio As FontAwesome.Sharp.IconButton
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
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnVolverAsistente As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents barraAvance As NumericUpDown
    Friend WithEvents txtProyectoSistemas As TextBox
    Friend WithEvents panelSeleccionarEmpresas As ControlPanel
    Friend WithEvents btnCancelarEmpresas As Button
    Friend WithEvents btnEmpresas As Button
    Friend WithEvents listEmpresas As CheckedListBox
    Friend WithEvents Label41 As Label
    Friend WithEvents panelProyectosGenerales As ControlPanel
    Friend WithEvents pictureEliminarGeneral As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboProyectoGeneral As ComboBox
    Friend WithEvents Label43 As Label
    Friend WithEvents comboProyectosGenerales As ComboBox
    Friend WithEvents btnCancelarProyectoGeneral As Button
    Friend WithEvents btnProyectosGenerales As Button
    Friend WithEvents Label44 As Label
    Friend WithEvents panelProyectosSistemas As ControlPanel
    Friend WithEvents pictureEliminarSistemas As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboProyectoSistemas As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents comboProyectosSistemas As ComboBox
    Friend WithEvents btnCancelarProyectosSistemas As Button
    Friend WithEvents btnProyectosSistemas As Button
    Friend WithEvents Label40 As Label
End Class
