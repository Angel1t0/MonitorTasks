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
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.btnEnviarAPI = New FontAwesome.Sharp.IconButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dateSilenciar = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.checkDesktop = New System.Windows.Forms.CheckBox()
        Me.checkGmail = New System.Windows.Forms.CheckBox()
        Me.checkWhatsapp = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardarNotificaciones = New FontAwesome.Sharp.IconButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.comboUsuariosANotificar = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PanelDatosBasicos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelDatosBasicos
        '
        Me.PanelDatosBasicos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelDatosBasicos.Controls.Add(Me.dateSilenciar)
        Me.PanelDatosBasicos.Controls.Add(Me.Label3)
        Me.PanelDatosBasicos.Controls.Add(Me.checkDesktop)
        Me.PanelDatosBasicos.Controls.Add(Me.checkGmail)
        Me.PanelDatosBasicos.Controls.Add(Me.checkWhatsapp)
        Me.PanelDatosBasicos.Controls.Add(Me.Label2)
        Me.PanelDatosBasicos.Controls.Add(Me.btnGuardarNotificaciones)
        Me.PanelDatosBasicos.Controls.Add(Me.btnCancelar)
        Me.PanelDatosBasicos.Controls.Add(Me.comboUsuariosANotificar)
        Me.PanelDatosBasicos.Controls.Add(Me.Label8)
        Me.PanelDatosBasicos.Controls.Add(Me.Label7)
        Me.PanelDatosBasicos.Location = New System.Drawing.Point(476, 37)
        Me.PanelDatosBasicos.Name = "PanelDatosBasicos"
        Me.PanelDatosBasicos.Size = New System.Drawing.Size(547, 446)
        Me.PanelDatosBasicos.TabIndex = 0
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
        Me.btnContinuar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnContinuar.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnContinuar.IconColor = System.Drawing.Color.Black
        Me.btnContinuar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnContinuar.IconSize = 16
        Me.btnContinuar.Location = New System.Drawing.Point(58, 357)
        Me.btnContinuar.Name = "btnContinuar"
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
        Me.btnAgregarAsistentes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAsistentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnAgregarAsistentes.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnAgregarAsistentes.IconColor = System.Drawing.Color.Black
        Me.btnAgregarAsistentes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnAgregarAsistentes.IconSize = 16
        Me.btnAgregarAsistentes.Location = New System.Drawing.Point(169, 257)
        Me.btnAgregarAsistentes.Name = "btnAgregarAsistentes"
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
        Me.Panel2.Location = New System.Drawing.Point(1054, 588)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 428)
        Me.Panel2.TabIndex = 2
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
        'btnEnviarAPI
        '
        Me.btnEnviarAPI.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnEnviarAPI.FlatAppearance.BorderSize = 0
        Me.btnEnviarAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviarAPI.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarAPI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnEnviarAPI.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnEnviarAPI.IconColor = System.Drawing.Color.Black
        Me.btnEnviarAPI.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnEnviarAPI.IconSize = 16
        Me.btnEnviarAPI.Location = New System.Drawing.Point(106, 332)
        Me.btnEnviarAPI.Name = "btnEnviarAPI"
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
        'dateSilenciar
        '
        Me.dateSilenciar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dateSilenciar.Location = New System.Drawing.Point(239, 270)
        Me.dateSilenciar.Name = "dateSilenciar"
        Me.dateSilenciar.Size = New System.Drawing.Size(221, 22)
        Me.dateSilenciar.TabIndex = 129
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(113, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 20)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "Silenciar hasta"
        '
        'checkDesktop
        '
        Me.checkDesktop.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkDesktop.AutoSize = True
        Me.checkDesktop.Location = New System.Drawing.Point(409, 204)
        Me.checkDesktop.Name = "checkDesktop"
        Me.checkDesktop.Size = New System.Drawing.Size(85, 20)
        Me.checkDesktop.TabIndex = 127
        Me.checkDesktop.Text = "Escritorio"
        Me.checkDesktop.UseVisualStyleBackColor = True
        '
        'checkGmail
        '
        Me.checkGmail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkGmail.AutoSize = True
        Me.checkGmail.Location = New System.Drawing.Point(336, 204)
        Me.checkGmail.Name = "checkGmail"
        Me.checkGmail.Size = New System.Drawing.Size(64, 20)
        Me.checkGmail.TabIndex = 126
        Me.checkGmail.Text = "Gmail"
        Me.checkGmail.UseVisualStyleBackColor = True
        '
        'checkWhatsapp
        '
        Me.checkWhatsapp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkWhatsapp.AutoSize = True
        Me.checkWhatsapp.Location = New System.Drawing.Point(239, 203)
        Me.checkWhatsapp.Name = "checkWhatsapp"
        Me.checkWhatsapp.Size = New System.Drawing.Size(91, 20)
        Me.checkWhatsapp.TabIndex = 125
        Me.checkWhatsapp.Text = "Whatsapp"
        Me.checkWhatsapp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(168, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 19)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "EDITAR NOTIFICACIONES"
        '
        'btnGuardarNotificaciones
        '
        Me.btnGuardarNotificaciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardarNotificaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnGuardarNotificaciones.FlatAppearance.BorderSize = 0
        Me.btnGuardarNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarNotificaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarNotificaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnGuardarNotificaciones.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnGuardarNotificaciones.IconColor = System.Drawing.Color.Black
        Me.btnGuardarNotificaciones.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnGuardarNotificaciones.IconSize = 16
        Me.btnGuardarNotificaciones.Location = New System.Drawing.Point(275, 345)
        Me.btnGuardarNotificaciones.Name = "btnGuardarNotificaciones"
        Me.btnGuardarNotificaciones.Size = New System.Drawing.Size(111, 42)
        Me.btnGuardarNotificaciones.TabIndex = 123
        Me.btnGuardarNotificaciones.Text = "Guardar"
        Me.btnGuardarNotificaciones.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCancelar.Location = New System.Drawing.Point(160, 345)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(111, 42)
        Me.btnCancelar.TabIndex = 122
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'comboUsuariosANotificar
        '
        Me.comboUsuariosANotificar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.comboUsuariosANotificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboUsuariosANotificar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboUsuariosANotificar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboUsuariosANotificar.FormattingEnabled = True
        Me.comboUsuariosANotificar.Items.AddRange(New Object() {"Todos"})
        Me.comboUsuariosANotificar.Location = New System.Drawing.Point(239, 128)
        Me.comboUsuariosANotificar.Name = "comboUsuariosANotificar"
        Me.comboUsuariosANotificar.Size = New System.Drawing.Size(221, 28)
        Me.comboUsuariosANotificar.TabIndex = 121
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(52, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 20)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "Notificar por medio de"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(79, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 20)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Usuarios a notificar"
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numericUpCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDatosBasicos As Panel
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
    Friend WithEvents dateSilenciar As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents checkDesktop As CheckBox
    Friend WithEvents checkGmail As CheckBox
    Friend WithEvents checkWhatsapp As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGuardarNotificaciones As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCancelar As Button
    Friend WithEvents comboUsuariosANotificar As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
End Class
