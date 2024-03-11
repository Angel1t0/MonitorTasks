<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormularioPrincipal
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
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.BtnConfiguracion = New FontAwesome.Sharp.IconButton()
        Me.BtnNotificaciones = New FontAwesome.Sharp.IconButton()
        Me.BtnImportar = New FontAwesome.Sharp.IconButton()
        Me.BtnEventos = New FontAwesome.Sharp.IconButton()
        Me.BtnTareas = New FontAwesome.Sharp.IconButton()
        Me.BtnUsuarios = New FontAwesome.Sharp.IconButton()
        Me.BtnDash = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LbLogo = New System.Windows.Forms.Label()
        Me.PanelTitulo = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New FontAwesome.Sharp.IconPictureBox()
        Me.BtnMaximizar = New FontAwesome.Sharp.IconPictureBox()
        Me.BtnMinimizar = New FontAwesome.Sharp.IconPictureBox()
        Me.LbTituloForm = New System.Windows.Forms.Label()
        Me.IconFormActual = New FontAwesome.Sharp.IconPictureBox()
        Me.PanelEscritorio = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMaximizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMinimizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconFormActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEscritorio.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.BtnConfiguracion)
        Me.PanelMenu.Controls.Add(Me.BtnNotificaciones)
        Me.PanelMenu.Controls.Add(Me.BtnImportar)
        Me.PanelMenu.Controls.Add(Me.BtnEventos)
        Me.PanelMenu.Controls.Add(Me.BtnTareas)
        Me.PanelMenu.Controls.Add(Me.BtnUsuarios)
        Me.PanelMenu.Controls.Add(Me.BtnDash)
        Me.PanelMenu.Controls.Add(Me.Panel2)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(262, 735)
        Me.PanelMenu.TabIndex = 0
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnConfiguracion.FlatAppearance.BorderSize = 0
        Me.BtnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConfiguracion.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnConfiguracion.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Wrench
        Me.BtnConfiguracion.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnConfiguracion.IconSize = 32
        Me.BtnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfiguracion.Location = New System.Drawing.Point(0, 485)
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnConfiguracion.Rotation = 0R
        Me.BtnConfiguracion.Size = New System.Drawing.Size(262, 60)
        Me.BtnConfiguracion.TabIndex = 8
        Me.BtnConfiguracion.Text = "Configuraciones"
        Me.BtnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfiguracion.UseVisualStyleBackColor = True
        '
        'BtnNotificaciones
        '
        Me.BtnNotificaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnNotificaciones.FlatAppearance.BorderSize = 0
        Me.BtnNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNotificaciones.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnNotificaciones.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNotificaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnNotificaciones.IconChar = FontAwesome.Sharp.IconChar.Bell
        Me.BtnNotificaciones.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnNotificaciones.IconSize = 32
        Me.BtnNotificaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNotificaciones.Location = New System.Drawing.Point(0, 425)
        Me.BtnNotificaciones.Name = "BtnNotificaciones"
        Me.BtnNotificaciones.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnNotificaciones.Rotation = 0R
        Me.BtnNotificaciones.Size = New System.Drawing.Size(262, 60)
        Me.BtnNotificaciones.TabIndex = 7
        Me.BtnNotificaciones.Text = "Notificaciones"
        Me.BtnNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNotificaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNotificaciones.UseVisualStyleBackColor = True
        '
        'BtnImportar
        '
        Me.BtnImportar.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnImportar.FlatAppearance.BorderSize = 0
        Me.BtnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportar.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnImportar.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImportar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnImportar.IconChar = FontAwesome.Sharp.IconChar.Upload
        Me.BtnImportar.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnImportar.IconSize = 32
        Me.BtnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImportar.Location = New System.Drawing.Point(0, 365)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnImportar.Rotation = 0R
        Me.BtnImportar.Size = New System.Drawing.Size(262, 60)
        Me.BtnImportar.TabIndex = 6
        Me.BtnImportar.Text = "Importación"
        Me.BtnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImportar.UseVisualStyleBackColor = True
        '
        'BtnEventos
        '
        Me.BtnEventos.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnEventos.FlatAppearance.BorderSize = 0
        Me.BtnEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEventos.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnEventos.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEventos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnEventos.IconChar = FontAwesome.Sharp.IconChar.Calendar
        Me.BtnEventos.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnEventos.IconSize = 32
        Me.BtnEventos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEventos.Location = New System.Drawing.Point(0, 305)
        Me.BtnEventos.Name = "BtnEventos"
        Me.BtnEventos.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnEventos.Rotation = 0R
        Me.BtnEventos.Size = New System.Drawing.Size(262, 60)
        Me.BtnEventos.TabIndex = 5
        Me.BtnEventos.Text = "Calendario de Eventos"
        Me.BtnEventos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEventos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEventos.UseVisualStyleBackColor = True
        '
        'BtnTareas
        '
        Me.BtnTareas.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnTareas.FlatAppearance.BorderSize = 0
        Me.BtnTareas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTareas.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnTareas.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTareas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnTareas.IconChar = FontAwesome.Sharp.IconChar.ListAlt
        Me.BtnTareas.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnTareas.IconSize = 32
        Me.BtnTareas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTareas.Location = New System.Drawing.Point(0, 245)
        Me.BtnTareas.Name = "BtnTareas"
        Me.BtnTareas.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnTareas.Rotation = 0R
        Me.BtnTareas.Size = New System.Drawing.Size(262, 60)
        Me.BtnTareas.TabIndex = 4
        Me.BtnTareas.Text = "Tareas"
        Me.BtnTareas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTareas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnTareas.UseVisualStyleBackColor = True
        '
        'BtnUsuarios
        '
        Me.BtnUsuarios.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnUsuarios.FlatAppearance.BorderSize = 0
        Me.BtnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUsuarios.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnUsuarios.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users
        Me.BtnUsuarios.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnUsuarios.IconSize = 32
        Me.BtnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUsuarios.Location = New System.Drawing.Point(0, 185)
        Me.BtnUsuarios.Name = "BtnUsuarios"
        Me.BtnUsuarios.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnUsuarios.Rotation = 0R
        Me.BtnUsuarios.Size = New System.Drawing.Size(262, 60)
        Me.BtnUsuarios.TabIndex = 3
        Me.BtnUsuarios.Text = "Usuarios"
        Me.BtnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUsuarios.UseVisualStyleBackColor = True
        '
        'BtnDash
        '
        Me.BtnDash.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnDash.FlatAppearance.BorderSize = 0
        Me.BtnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDash.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.BtnDash.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnDash.IconChar = FontAwesome.Sharp.IconChar.ChartLine
        Me.BtnDash.IconColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BtnDash.IconSize = 32
        Me.BtnDash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDash.Location = New System.Drawing.Point(0, 125)
        Me.BtnDash.Name = "BtnDash"
        Me.BtnDash.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BtnDash.Rotation = 0R
        Me.BtnDash.Size = New System.Drawing.Size(262, 60)
        Me.BtnDash.TabIndex = 2
        Me.BtnDash.Text = "Dashboard"
        Me.BtnDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDash.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.LbLogo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 125)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(27, 82)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(209, 2)
        Me.Panel3.TabIndex = 1
        '
        'LbLogo
        '
        Me.LbLogo.AutoSize = True
        Me.LbLogo.Font = New System.Drawing.Font("HelveticaNowText Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbLogo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.LbLogo.Location = New System.Drawing.Point(21, 45)
        Me.LbLogo.Name = "LbLogo"
        Me.LbLogo.Size = New System.Drawing.Size(221, 34)
        Me.LbLogo.TabIndex = 0
        Me.LbLogo.Text = "Monitor Work Time"
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelTitulo.Controls.Add(Me.BtnCerrar)
        Me.PanelTitulo.Controls.Add(Me.BtnMaximizar)
        Me.PanelTitulo.Controls.Add(Me.BtnMinimizar)
        Me.PanelTitulo.Controls.Add(Me.LbTituloForm)
        Me.PanelTitulo.Controls.Add(Me.IconFormActual)
        Me.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitulo.Location = New System.Drawing.Point(262, 0)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(1150, 60)
        Me.PanelTitulo.TabIndex = 1
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.BtnCerrar.IconColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnCerrar.IconSize = 30
        Me.BtnCerrar.Location = New System.Drawing.Point(1106, 15)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(30, 30)
        Me.BtnCerrar.TabIndex = 4
        Me.BtnCerrar.TabStop = False
        '
        'BtnMaximizar
        '
        Me.BtnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMaximizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMaximizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.BtnMaximizar.IconColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnMaximizar.IconSize = 30
        Me.BtnMaximizar.Location = New System.Drawing.Point(1056, 15)
        Me.BtnMaximizar.Name = "BtnMaximizar"
        Me.BtnMaximizar.Size = New System.Drawing.Size(30, 30)
        Me.BtnMaximizar.TabIndex = 3
        Me.BtnMaximizar.TabStop = False
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMinimizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMinimizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.BtnMinimizar.IconColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BtnMinimizar.IconSize = 30
        Me.BtnMinimizar.Location = New System.Drawing.Point(1005, 15)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Size = New System.Drawing.Size(30, 30)
        Me.BtnMinimizar.TabIndex = 2
        Me.BtnMinimizar.TabStop = False
        '
        'LbTituloForm
        '
        Me.LbTituloForm.AutoSize = True
        Me.LbTituloForm.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTituloForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.LbTituloForm.Location = New System.Drawing.Point(62, 20)
        Me.LbTituloForm.Name = "LbTituloForm"
        Me.LbTituloForm.Size = New System.Drawing.Size(53, 21)
        Me.LbTituloForm.TabIndex = 1
        Me.LbTituloForm.Text = "Inicio"
        '
        'IconFormActual
        '
        Me.IconFormActual.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.IconFormActual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.IconFormActual.IconChar = FontAwesome.Sharp.IconChar.Home
        Me.IconFormActual.IconColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.IconFormActual.Location = New System.Drawing.Point(26, 14)
        Me.IconFormActual.Name = "IconFormActual"
        Me.IconFormActual.Size = New System.Drawing.Size(32, 32)
        Me.IconFormActual.TabIndex = 0
        Me.IconFormActual.TabStop = False
        '
        'PanelEscritorio
        '
        Me.PanelEscritorio.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelEscritorio.Controls.Add(Me.Panel1)
        Me.PanelEscritorio.Controls.Add(Me.Label1)
        Me.PanelEscritorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEscritorio.Location = New System.Drawing.Point(262, 60)
        Me.PanelEscritorio.Name = "PanelEscritorio"
        Me.PanelEscritorio.Size = New System.Drawing.Size(1150, 675)
        Me.PanelEscritorio.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(400, 341)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 2)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HelveticaNowText Light", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(389, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 62)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Monitor Work Time"
        '
        'FormularioPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1412, 735)
        Me.Controls.Add(Me.PanelEscritorio)
        Me.Controls.Add(Me.PanelTitulo)
        Me.Controls.Add(Me.PanelMenu)
        Me.MinimumSize = New System.Drawing.Size(1100, 600)
        Me.Name = "FormularioPrincipal"
        Me.Text = "FormularioPrincipal"
        Me.PanelMenu.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMaximizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMinimizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconFormActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEscritorio.ResumeLayout(False)
        Me.PanelEscritorio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMenu As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LbLogo As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnDash As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnConfiguracion As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnNotificaciones As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnImportar As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnEventos As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnTareas As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnUsuarios As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents IconFormActual As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents LbTituloForm As Label
    Friend WithEvents PanelEscritorio As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCerrar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents BtnMaximizar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents BtnMinimizar As FontAwesome.Sharp.IconPictureBox
End Class
