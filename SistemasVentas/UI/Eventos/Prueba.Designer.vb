<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prueba
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Prueba))
        Me.panelCrearEvento = New System.Windows.Forms.Panel()
        Me.btnActualizarNotificacion = New System.Windows.Forms.Button()
        Me.btnEliminarNotificaciones = New System.Windows.Forms.Button()
        Me.comboListaNotificaciones = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEliminarAsistentes = New System.Windows.Forms.Button()
        Me.comboListaInvitados = New System.Windows.Forms.ComboBox()
        Me.labelEventoID = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.txtOcurrencias = New System.Windows.Forms.NumericUpDown()
        Me.btnEnviarAPI = New System.Windows.Forms.Button()
        Me.numericUpCantidad = New System.Windows.Forms.NumericUpDown()
        Me.comboUnidades = New System.Windows.Forms.ComboBox()
        Me.rbtnFecha = New System.Windows.Forms.RadioButton()
        Me.rbtnConteo = New System.Windows.Forms.RadioButton()
        Me.comboEventVisibilidad = New System.Windows.Forms.ComboBox()
        Me.btnAgregarRecordatorio = New System.Windows.Forms.Button()
        Me.btnAgregarAsistentes = New System.Windows.Forms.Button()
        Me.OwnEmail = New System.Windows.Forms.Label()
        Me.comboMetodoRecordar = New System.Windows.Forms.ComboBox()
        Me.labelAsistente = New System.Windows.Forms.Label()
        Me.comboInvitados = New System.Windows.Forms.ComboBox()
        Me.comboEventDispo = New System.Windows.Forms.ComboBox()
        Me.eventFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.eventFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtEventDescrip = New System.Windows.Forms.TextBox()
        Me.txtEventUbicacion = New System.Windows.Forms.TextBox()
        Me.txtEventName = New System.Windows.Forms.TextBox()
        Me.listDias = New System.Windows.Forms.CheckedListBox()
        Me.dateRecuFinal = New System.Windows.Forms.DateTimePicker()
        Me.comboFrecuencia = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.l = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripMenu = New System.Windows.Forms.MenuStrip()
        Me.btnActualizarEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCrearEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelCrearEvento.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelCrearEvento
        '
        Me.panelCrearEvento.Controls.Add(Me.btnActualizarNotificacion)
        Me.panelCrearEvento.Controls.Add(Me.btnEliminarNotificaciones)
        Me.panelCrearEvento.Controls.Add(Me.comboListaNotificaciones)
        Me.panelCrearEvento.Controls.Add(Me.Label5)
        Me.panelCrearEvento.Controls.Add(Me.btnEliminarAsistentes)
        Me.panelCrearEvento.Controls.Add(Me.comboListaInvitados)
        Me.panelCrearEvento.Controls.Add(Me.labelEventoID)
        Me.panelCrearEvento.Controls.Add(Me.btnVolver)
        Me.panelCrearEvento.Controls.Add(Me.txtOcurrencias)
        Me.panelCrearEvento.Controls.Add(Me.btnEnviarAPI)
        Me.panelCrearEvento.Controls.Add(Me.numericUpCantidad)
        Me.panelCrearEvento.Controls.Add(Me.comboUnidades)
        Me.panelCrearEvento.Controls.Add(Me.rbtnFecha)
        Me.panelCrearEvento.Controls.Add(Me.rbtnConteo)
        Me.panelCrearEvento.Controls.Add(Me.comboEventVisibilidad)
        Me.panelCrearEvento.Controls.Add(Me.btnAgregarRecordatorio)
        Me.panelCrearEvento.Controls.Add(Me.btnAgregarAsistentes)
        Me.panelCrearEvento.Controls.Add(Me.OwnEmail)
        Me.panelCrearEvento.Controls.Add(Me.comboMetodoRecordar)
        Me.panelCrearEvento.Controls.Add(Me.labelAsistente)
        Me.panelCrearEvento.Controls.Add(Me.comboInvitados)
        Me.panelCrearEvento.Controls.Add(Me.comboEventDispo)
        Me.panelCrearEvento.Controls.Add(Me.eventFechaFinal)
        Me.panelCrearEvento.Controls.Add(Me.eventFechaInicio)
        Me.panelCrearEvento.Controls.Add(Me.txtEventDescrip)
        Me.panelCrearEvento.Controls.Add(Me.txtEventUbicacion)
        Me.panelCrearEvento.Controls.Add(Me.txtEventName)
        Me.panelCrearEvento.Controls.Add(Me.listDias)
        Me.panelCrearEvento.Controls.Add(Me.dateRecuFinal)
        Me.panelCrearEvento.Controls.Add(Me.comboFrecuencia)
        Me.panelCrearEvento.Controls.Add(Me.Label20)
        Me.panelCrearEvento.Controls.Add(Me.Label19)
        Me.panelCrearEvento.Controls.Add(Me.Label18)
        Me.panelCrearEvento.Controls.Add(Me.Label17)
        Me.panelCrearEvento.Controls.Add(Me.Label16)
        Me.panelCrearEvento.Controls.Add(Me.Label15)
        Me.panelCrearEvento.Controls.Add(Me.Label14)
        Me.panelCrearEvento.Controls.Add(Me.Label13)
        Me.panelCrearEvento.Controls.Add(Me.Label12)
        Me.panelCrearEvento.Controls.Add(Me.Label11)
        Me.panelCrearEvento.Controls.Add(Me.Label10)
        Me.panelCrearEvento.Controls.Add(Me.Label9)
        Me.panelCrearEvento.Controls.Add(Me.Label8)
        Me.panelCrearEvento.Controls.Add(Me.Label7)
        Me.panelCrearEvento.Controls.Add(Me.Label6)
        Me.panelCrearEvento.Controls.Add(Me.l)
        Me.panelCrearEvento.Controls.Add(Me.Label4)
        Me.panelCrearEvento.Controls.Add(Me.Label3)
        Me.panelCrearEvento.Controls.Add(Me.Label2)
        Me.panelCrearEvento.Controls.Add(Me.ToolStripMenu)
        Me.panelCrearEvento.Location = New System.Drawing.Point(157, 68)
        Me.panelCrearEvento.Name = "panelCrearEvento"
        Me.panelCrearEvento.Size = New System.Drawing.Size(1158, 606)
        Me.panelCrearEvento.TabIndex = 9
        '
        'btnActualizarNotificacion
        '
        Me.btnActualizarNotificacion.Location = New System.Drawing.Point(791, 503)
        Me.btnActualizarNotificacion.Name = "btnActualizarNotificacion"
        Me.btnActualizarNotificacion.Size = New System.Drawing.Size(158, 23)
        Me.btnActualizarNotificacion.TabIndex = 108
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
        Me.btnEliminarNotificaciones.Location = New System.Drawing.Point(1095, 363)
        Me.btnEliminarNotificaciones.Name = "btnEliminarNotificaciones"
        Me.btnEliminarNotificaciones.Size = New System.Drawing.Size(27, 27)
        Me.btnEliminarNotificaciones.TabIndex = 107
        Me.btnEliminarNotificaciones.UseVisualStyleBackColor = False
        '
        'comboListaNotificaciones
        '
        Me.comboListaNotificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaNotificaciones.FormattingEnabled = True
        Me.comboListaNotificaciones.Location = New System.Drawing.Point(823, 365)
        Me.comboListaNotificaciones.Name = "comboListaNotificaciones"
        Me.comboListaNotificaciones.Size = New System.Drawing.Size(266, 24)
        Me.comboListaNotificaciones.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(688, 368)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Notificaciones activas"
        '
        'btnEliminarAsistentes
        '
        Me.btnEliminarAsistentes.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsistentes.BackgroundImage = CType(resources.GetObject("btnEliminarAsistentes.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminarAsistentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminarAsistentes.FlatAppearance.BorderSize = 0
        Me.btnEliminarAsistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarAsistentes.Location = New System.Drawing.Point(1071, 211)
        Me.btnEliminarAsistentes.Name = "btnEliminarAsistentes"
        Me.btnEliminarAsistentes.Size = New System.Drawing.Size(27, 27)
        Me.btnEliminarAsistentes.TabIndex = 103
        Me.btnEliminarAsistentes.UseVisualStyleBackColor = False
        '
        'comboListaInvitados
        '
        Me.comboListaInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaInvitados.FormattingEnabled = True
        Me.comboListaInvitados.Location = New System.Drawing.Point(944, 213)
        Me.comboListaInvitados.Name = "comboListaInvitados"
        Me.comboListaInvitados.Size = New System.Drawing.Size(121, 24)
        Me.comboListaInvitados.TabIndex = 102
        '
        'labelEventoID
        '
        Me.labelEventoID.AutoSize = True
        Me.labelEventoID.Location = New System.Drawing.Point(212, 52)
        Me.labelEventoID.Name = "labelEventoID"
        Me.labelEventoID.Size = New System.Drawing.Size(48, 16)
        Me.labelEventoID.TabIndex = 101
        Me.labelEventoID.Text = "Label5"
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.Transparent
        Me.btnVolver.FlatAppearance.BorderSize = 0
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(853, 532)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(121, 57)
        Me.btnVolver.TabIndex = 100
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'txtOcurrencias
        '
        Me.txtOcurrencias.Location = New System.Drawing.Point(440, 329)
        Me.txtOcurrencias.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txtOcurrencias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtOcurrencias.Name = "txtOcurrencias"
        Me.txtOcurrencias.Size = New System.Drawing.Size(102, 22)
        Me.txtOcurrencias.TabIndex = 99
        Me.txtOcurrencias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnEnviarAPI
        '
        Me.btnEnviarAPI.Location = New System.Drawing.Point(434, 478)
        Me.btnEnviarAPI.Name = "btnEnviarAPI"
        Me.btnEnviarAPI.Size = New System.Drawing.Size(75, 48)
        Me.btnEnviarAPI.TabIndex = 98
        Me.btnEnviarAPI.Text = "ENVIAR"
        Me.btnEnviarAPI.UseVisualStyleBackColor = True
        '
        'numericUpCantidad
        '
        Me.numericUpCantidad.Location = New System.Drawing.Point(887, 462)
        Me.numericUpCantidad.Name = "numericUpCantidad"
        Me.numericUpCantidad.Size = New System.Drawing.Size(109, 22)
        Me.numericUpCantidad.TabIndex = 97
        '
        'comboUnidades
        '
        Me.comboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboUnidades.FormattingEnabled = True
        Me.comboUnidades.Items.AddRange(New Object() {"Minutos", "Horas", "Días", "Semanas"})
        Me.comboUnidades.Location = New System.Drawing.Point(1008, 459)
        Me.comboUnidades.Name = "comboUnidades"
        Me.comboUnidades.Size = New System.Drawing.Size(121, 24)
        Me.comboUnidades.TabIndex = 96
        '
        'rbtnFecha
        '
        Me.rbtnFecha.AutoSize = True
        Me.rbtnFecha.Location = New System.Drawing.Point(666, 253)
        Me.rbtnFecha.Name = "rbtnFecha"
        Me.rbtnFecha.Size = New System.Drawing.Size(78, 20)
        Me.rbtnFecha.TabIndex = 94
        Me.rbtnFecha.Text = "Hasta el"
        Me.rbtnFecha.UseVisualStyleBackColor = True
        '
        'rbtnConteo
        '
        Me.rbtnConteo.AutoSize = True
        Me.rbtnConteo.Checked = True
        Me.rbtnConteo.Location = New System.Drawing.Point(440, 253)
        Me.rbtnConteo.Name = "rbtnConteo"
        Me.rbtnConteo.Size = New System.Drawing.Size(102, 20)
        Me.rbtnConteo.TabIndex = 93
        Me.rbtnConteo.TabStop = True
        Me.rbtnConteo.Text = "Despues de"
        Me.rbtnConteo.UseVisualStyleBackColor = True
        '
        'comboEventVisibilidad
        '
        Me.comboEventVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventVisibilidad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboEventVisibilidad.FormattingEnabled = True
        Me.comboEventVisibilidad.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboEventVisibilidad.Location = New System.Drawing.Point(160, 390)
        Me.comboEventVisibilidad.Name = "comboEventVisibilidad"
        Me.comboEventVisibilidad.Size = New System.Drawing.Size(132, 24)
        Me.comboEventVisibilidad.TabIndex = 64
        '
        'btnAgregarRecordatorio
        '
        Me.btnAgregarRecordatorio.Location = New System.Drawing.Point(969, 503)
        Me.btnAgregarRecordatorio.Name = "btnAgregarRecordatorio"
        Me.btnAgregarRecordatorio.Size = New System.Drawing.Size(163, 23)
        Me.btnAgregarRecordatorio.TabIndex = 91
        Me.btnAgregarRecordatorio.Text = "Añadir recordatorio"
        Me.btnAgregarRecordatorio.UseVisualStyleBackColor = True
        '
        'btnAgregarAsistentes
        '
        Me.btnAgregarAsistentes.Location = New System.Drawing.Point(920, 270)
        Me.btnAgregarAsistentes.Name = "btnAgregarAsistentes"
        Me.btnAgregarAsistentes.Size = New System.Drawing.Size(163, 23)
        Me.btnAgregarAsistentes.TabIndex = 90
        Me.btnAgregarAsistentes.Text = "Añadir asistentes"
        Me.btnAgregarAsistentes.UseVisualStyleBackColor = True
        '
        'OwnEmail
        '
        Me.OwnEmail.AutoSize = True
        Me.OwnEmail.Location = New System.Drawing.Point(941, 52)
        Me.OwnEmail.Name = "OwnEmail"
        Me.OwnEmail.Size = New System.Drawing.Size(79, 16)
        Me.OwnEmail.TabIndex = 87
        Me.OwnEmail.Text = "OwnerEmail"
        '
        'comboMetodoRecordar
        '
        Me.comboMetodoRecordar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMetodoRecordar.FormattingEnabled = True
        Me.comboMetodoRecordar.Items.AddRange(New Object() {"Notificación", "Correo electrónico"})
        Me.comboMetodoRecordar.Location = New System.Drawing.Point(1008, 407)
        Me.comboMetodoRecordar.Name = "comboMetodoRecordar"
        Me.comboMetodoRecordar.Size = New System.Drawing.Size(121, 24)
        Me.comboMetodoRecordar.TabIndex = 86
        '
        'labelAsistente
        '
        Me.labelAsistente.AutoSize = True
        Me.labelAsistente.Location = New System.Drawing.Point(993, 176)
        Me.labelAsistente.Name = "labelAsistente"
        Me.labelAsistente.Size = New System.Drawing.Size(90, 16)
        Me.labelAsistente.TabIndex = 85
        Me.labelAsistente.Text = "DisplayName"
        '
        'comboInvitados
        '
        Me.comboInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInvitados.FormattingEnabled = True
        Me.comboInvitados.Location = New System.Drawing.Point(944, 131)
        Me.comboInvitados.Name = "comboInvitados"
        Me.comboInvitados.Size = New System.Drawing.Size(121, 24)
        Me.comboInvitados.TabIndex = 84
        '
        'comboEventDispo
        '
        Me.comboEventDispo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventDispo.FormattingEnabled = True
        Me.comboEventDispo.Items.AddRange(New Object() {"Ocupado", "Disponible"})
        Me.comboEventDispo.Location = New System.Drawing.Point(163, 450)
        Me.comboEventDispo.Name = "comboEventDispo"
        Me.comboEventDispo.Size = New System.Drawing.Size(121, 24)
        Me.comboEventDispo.TabIndex = 83
        '
        'eventFechaFinal
        '
        Me.eventFechaFinal.Location = New System.Drawing.Point(167, 334)
        Me.eventFechaFinal.Name = "eventFechaFinal"
        Me.eventFechaFinal.Size = New System.Drawing.Size(200, 22)
        Me.eventFechaFinal.TabIndex = 82
        '
        'eventFechaInicio
        '
        Me.eventFechaInicio.Location = New System.Drawing.Point(160, 277)
        Me.eventFechaInicio.Name = "eventFechaInicio"
        Me.eventFechaInicio.Size = New System.Drawing.Size(200, 22)
        Me.eventFechaInicio.TabIndex = 81
        '
        'txtEventDescrip
        '
        Me.txtEventDescrip.Location = New System.Drawing.Point(160, 220)
        Me.txtEventDescrip.Name = "txtEventDescrip"
        Me.txtEventDescrip.Size = New System.Drawing.Size(100, 22)
        Me.txtEventDescrip.TabIndex = 80
        '
        'txtEventUbicacion
        '
        Me.txtEventUbicacion.Location = New System.Drawing.Point(136, 172)
        Me.txtEventUbicacion.Name = "txtEventUbicacion"
        Me.txtEventUbicacion.Size = New System.Drawing.Size(100, 22)
        Me.txtEventUbicacion.TabIndex = 79
        '
        'txtEventName
        '
        Me.txtEventName.Location = New System.Drawing.Point(136, 110)
        Me.txtEventName.Name = "txtEventName"
        Me.txtEventName.Size = New System.Drawing.Size(100, 22)
        Me.txtEventName.TabIndex = 78
        '
        'listDias
        '
        Me.listDias.Enabled = False
        Me.listDias.FormattingEnabled = True
        Me.listDias.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"})
        Me.listDias.Location = New System.Drawing.Point(455, 135)
        Me.listDias.Name = "listDias"
        Me.listDias.Size = New System.Drawing.Size(187, 89)
        Me.listDias.TabIndex = 77
        '
        'dateRecuFinal
        '
        Me.dateRecuFinal.Enabled = False
        Me.dateRecuFinal.Location = New System.Drawing.Point(576, 326)
        Me.dateRecuFinal.Name = "dateRecuFinal"
        Me.dateRecuFinal.Size = New System.Drawing.Size(265, 22)
        Me.dateRecuFinal.TabIndex = 76
        '
        'comboFrecuencia
        '
        Me.comboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFrecuencia.FormattingEnabled = True
        Me.comboFrecuencia.Items.AddRange(New Object() {"No repetir", "Diariamente", "Semanalmente", "Mensualmente", "Anualmente"})
        Me.comboFrecuencia.Location = New System.Drawing.Point(537, 79)
        Me.comboFrecuencia.Name = "comboFrecuencia"
        Me.comboFrecuencia.Size = New System.Drawing.Size(121, 24)
        Me.comboFrecuencia.TabIndex = 75
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(493, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 16)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "Dias de la semana"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(654, 293)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 16)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "Fecha finalizacion"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(431, 294)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(122, 16)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "ConteoOcurrencias"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(394, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 16)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Frecuencia repeticion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(473, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 16)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "RECURRENCIAS"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(725, 462)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(156, 16)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Tiempo antes del evento"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(871, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(148, 16)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Metodo de recordatorio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(874, 334)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 16)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "RECORDATORIOS"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(873, 219)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 16)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Invitados"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(874, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 16)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Nombre asistente"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(871, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(868, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "ASISTENTES"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 453)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 16)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Disponibilidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 398)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Visibilidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(63, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Finalizar Fecha"
        '
        'l
        '
        Me.l.AutoSize = True
        Me.l.Location = New System.Drawing.Point(60, 277)
        Me.l.Name = "l"
        Me.l.Size = New System.Drawing.Size(76, 16)
        Me.l.TabIndex = 58
        Me.l.Text = "Incio Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Descripcion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Ubicacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Titulo"
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnActualizarEvento, Me.btnCrearEvento})
        Me.ToolStripMenu.Location = New System.Drawing.Point(434, 398)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(253, 28)
        Me.ToolStripMenu.TabIndex = 104
        Me.ToolStripMenu.Text = "Actualizar evento"
        '
        'btnActualizarEvento
        '
        Me.btnActualizarEvento.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizarEvento.Name = "btnActualizarEvento"
        Me.btnActualizarEvento.Size = New System.Drawing.Size(138, 24)
        Me.btnActualizarEvento.Text = "Actualizar evento"
        '
        'btnCrearEvento
        '
        Me.btnCrearEvento.BackColor = System.Drawing.Color.LightGray
        Me.btnCrearEvento.Name = "btnCrearEvento"
        Me.btnCrearEvento.Size = New System.Drawing.Size(107, 24)
        Me.btnCrearEvento.Text = "Crear evento"
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 742)
        Me.Controls.Add(Me.panelCrearEvento)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.panelCrearEvento.ResumeLayout(False)
        Me.panelCrearEvento.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelCrearEvento As Panel
    Friend WithEvents btnActualizarNotificacion As Button
    Friend WithEvents btnEliminarNotificaciones As Button
    Friend WithEvents comboListaNotificaciones As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnEliminarAsistentes As Button
    Friend WithEvents comboListaInvitados As ComboBox
    Friend WithEvents labelEventoID As Label
    Friend WithEvents btnVolver As Button
    Friend WithEvents txtOcurrencias As NumericUpDown
    Friend WithEvents btnEnviarAPI As Button
    Friend WithEvents numericUpCantidad As NumericUpDown
    Friend WithEvents comboUnidades As ComboBox
    Friend WithEvents rbtnFecha As RadioButton
    Friend WithEvents rbtnConteo As RadioButton
    Friend WithEvents comboEventVisibilidad As ComboBox
    Friend WithEvents btnAgregarRecordatorio As Button
    Friend WithEvents btnAgregarAsistentes As Button
    Friend WithEvents OwnEmail As Label
    Friend WithEvents comboMetodoRecordar As ComboBox
    Friend WithEvents labelAsistente As Label
    Friend WithEvents comboInvitados As ComboBox
    Friend WithEvents comboEventDispo As ComboBox
    Friend WithEvents eventFechaFinal As DateTimePicker
    Friend WithEvents eventFechaInicio As DateTimePicker
    Friend WithEvents txtEventDescrip As TextBox
    Friend WithEvents txtEventUbicacion As TextBox
    Friend WithEvents txtEventName As TextBox
    Friend WithEvents listDias As CheckedListBox
    Friend WithEvents dateRecuFinal As DateTimePicker
    Friend WithEvents comboFrecuencia As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents l As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripMenu As MenuStrip
    Friend WithEvents btnActualizarEvento As ToolStripMenuItem
    Friend WithEvents btnCrearEvento As ToolStripMenuItem
End Class
