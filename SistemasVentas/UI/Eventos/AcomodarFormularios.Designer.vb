<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcomodarFormularios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcomodarFormularios))
        Me.PanelDatosBasicos = New System.Windows.Forms.Panel()
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
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnGuardarEvento = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEliminarAsistentes = New System.Windows.Forms.Button()
        Me.comboListaInvitados = New System.Windows.Forms.ComboBox()
        Me.labelAsistente = New System.Windows.Forms.Label()
        Me.comboInvitados = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAgregarAsistentes = New FontAwesome.Sharp.IconButton()
        Me.btnContinuar = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEnviarAPI = New FontAwesome.Sharp.IconButton()
        Me.Label15 = New System.Windows.Forms.Label()
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
        Me.btnVolverEvento = New System.Windows.Forms.Button()
        Me.btnVolverAsistente = New System.Windows.Forms.Button()
        Me.PanelDatosBasicos.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelDatosBasicos
        '
        Me.PanelDatosBasicos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelDatosBasicos.Controls.Add(Me.btnGuardarEvento)
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
        Me.PanelDatosBasicos.Location = New System.Drawing.Point(45, 24)
        Me.PanelDatosBasicos.Name = "PanelDatosBasicos"
        Me.PanelDatosBasicos.Size = New System.Drawing.Size(985, 533)
        Me.PanelDatosBasicos.TabIndex = 0
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
        'btnGuardarEvento
        '
        Me.btnGuardarEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnGuardarEvento.FlatAppearance.BorderSize = 0
        Me.btnGuardarEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarEvento.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnGuardarEvento.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnGuardarEvento.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnGuardarEvento.IconColor = System.Drawing.Color.Black
        Me.btnGuardarEvento.IconSize = 16
        Me.btnGuardarEvento.Location = New System.Drawing.Point(416, 446)
        Me.btnGuardarEvento.Name = "btnGuardarEvento"
        Me.btnGuardarEvento.Rotation = 0R
        Me.btnGuardarEvento.Size = New System.Drawing.Size(111, 42)
        Me.btnGuardarEvento.TabIndex = 111
        Me.btnGuardarEvento.Text = "Guardar"
        Me.btnGuardarEvento.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnVolverEvento)
        Me.Panel1.Controls.Add(Me.btnContinuar)
        Me.Panel1.Controls.Add(Me.btnAgregarAsistentes)
        Me.Panel1.Controls.Add(Me.btnEliminarAsistentes)
        Me.Panel1.Controls.Add(Me.comboListaInvitados)
        Me.Panel1.Controls.Add(Me.labelAsistente)
        Me.Panel1.Controls.Add(Me.comboInvitados)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(1118, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 428)
        Me.Panel1.TabIndex = 1
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnVolverAsistente)
        Me.Panel2.Controls.Add(Me.btnActualizarNotificacion)
        Me.Panel2.Controls.Add(Me.btnEliminarNotificaciones)
        Me.Panel2.Controls.Add(Me.comboListaNotificaciones)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.numericUpCantidad)
        Me.Panel2.Controls.Add(Me.comboUnidades)
        Me.Panel2.Controls.Add(Me.btnAgregarRecordatorio)
        Me.Panel2.Controls.Add(Me.comboMetodoRecordar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.btnEnviarAPI)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Location = New System.Drawing.Point(493, 588)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 428)
        Me.Panel2.TabIndex = 2
        '
        'btnEnviarAPI
        '
        Me.btnEnviarAPI.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnEnviarAPI.FlatAppearance.BorderSize = 0
        Me.btnEnviarAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviarAPI.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnEnviarAPI.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarAPI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEnviarAPI.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnEnviarAPI.IconColor = System.Drawing.Color.Black
        Me.btnEnviarAPI.IconSize = 16
        Me.btnEnviarAPI.Location = New System.Drawing.Point(106, 332)
        Me.btnEnviarAPI.Name = "btnEnviarAPI"
        Me.btnEnviarAPI.Rotation = 0R
        Me.btnEnviarAPI.Size = New System.Drawing.Size(163, 42)
        Me.btnEnviarAPI.TabIndex = 113
        Me.btnEnviarAPI.Text = "Finalizar"
        Me.btnEnviarAPI.UseVisualStyleBackColor = False
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
        'AcomodarFormularios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1752, 1028)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelDatosBasicos)
        Me.Name = "AcomodarFormularios"
        Me.Text = "AcomodarFormularios"
        Me.PanelDatosBasicos.ResumeLayout(False)
        Me.PanelDatosBasicos.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDatosBasicos As Panel
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
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnGuardarEvento As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEliminarAsistentes As Button
    Friend WithEvents comboListaInvitados As ComboBox
    Friend WithEvents labelAsistente As Label
    Friend WithEvents comboInvitados As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnAgregarAsistentes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnContinuar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnEnviarAPI As FontAwesome.Sharp.IconButton
    Friend WithEvents Label15 As Label
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
    Friend WithEvents btnVolverEvento As Button
    Friend WithEvents btnVolverAsistente As Button
End Class
