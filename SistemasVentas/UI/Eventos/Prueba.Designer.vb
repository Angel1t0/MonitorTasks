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
        Me.comboEventVisibilidad = New System.Windows.Forms.ComboBox()
        Me.comboEventDispo = New System.Windows.Forms.ComboBox()
        Me.eventFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.eventFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.l = New System.Windows.Forms.Label()
        Me.ControlPanel1 = New SistemasVentas.ControlPanel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlTextBox4 = New SistemasVentas.ControlTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ControlTextBox3 = New SistemasVentas.ControlTextBox()
        Me.ControlTextBox2 = New SistemasVentas.ControlTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.ControlPanel2 = New SistemasVentas.ControlPanel()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.IconPictureBox3 = New FontAwesome.Sharp.IconPictureBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.IconPictureBox2 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ControlPanel3 = New SistemasVentas.ControlPanel()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.IconPictureBox5 = New FontAwesome.Sharp.IconPictureBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.IconPictureBox4 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ControlPanel1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosRecurrencia.SuspendLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel2.SuspendLayout()
        CType(Me.IconPictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel3.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconPictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.IconPictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comboEventVisibilidad
        '
        Me.comboEventVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventVisibilidad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboEventVisibilidad.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventVisibilidad.FormattingEnabled = True
        Me.comboEventVisibilidad.Items.AddRange(New Object() {"Default", "Público", "Privado"})
        Me.comboEventVisibilidad.Location = New System.Drawing.Point(314, 285)
        Me.comboEventVisibilidad.Name = "comboEventVisibilidad"
        Me.comboEventVisibilidad.Size = New System.Drawing.Size(250, 28)
        Me.comboEventVisibilidad.TabIndex = 91
        '
        'comboEventDispo
        '
        Me.comboEventDispo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEventDispo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboEventDispo.FormattingEnabled = True
        Me.comboEventDispo.Items.AddRange(New Object() {"Ocupado", "Disponible"})
        Me.comboEventDispo.Location = New System.Drawing.Point(153, 562)
        Me.comboEventDispo.Name = "comboEventDispo"
        Me.comboEventDispo.Size = New System.Drawing.Size(132, 28)
        Me.comboEventDispo.TabIndex = 97
        '
        'eventFechaFinal
        '
        Me.eventFechaFinal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaFinal.Location = New System.Drawing.Point(314, 194)
        Me.eventFechaFinal.Name = "eventFechaFinal"
        Me.eventFechaFinal.Size = New System.Drawing.Size(250, 26)
        Me.eventFechaFinal.TabIndex = 96
        '
        'eventFechaInicio
        '
        Me.eventFechaInicio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eventFechaInicio.Location = New System.Drawing.Point(35, 194)
        Me.eventFechaInicio.Name = "eventFechaInicio"
        Me.eventFechaInicio.Size = New System.Drawing.Size(250, 26)
        Me.eventFechaInicio.TabIndex = 95
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 566)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 18)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Disponibilidad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(310, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 18)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Visibilidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(311, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 18)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Finalizar Fecha"
        '
        'l
        '
        Me.l.AutoSize = True
        Me.l.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l.Location = New System.Drawing.Point(31, 163)
        Me.l.Name = "l"
        Me.l.Size = New System.Drawing.Size(95, 18)
        Me.l.TabIndex = 87
        Me.l.Text = "Incio Fecha"
        '
        'ControlPanel1
        '
        Me.ControlPanel1.BackColor = System.Drawing.Color.White
        Me.ControlPanel1.BorderRadius = 12
        Me.ControlPanel1.Controls.Add(Me.MenuStrip2)
        Me.ControlPanel1.Controls.Add(Me.ControlTextBox4)
        Me.ControlPanel1.Controls.Add(Me.Label9)
        Me.ControlPanel1.Controls.Add(Me.ComboBox1)
        Me.ControlPanel1.Controls.Add(Me.Label5)
        Me.ControlPanel1.Controls.Add(Me.ControlTextBox3)
        Me.ControlPanel1.Controls.Add(Me.ControlTextBox2)
        Me.ControlPanel1.Controls.Add(Me.Panel1)
        Me.ControlPanel1.Controls.Add(Me.Label2)
        Me.ControlPanel1.Controls.Add(Me.Label3)
        Me.ControlPanel1.Controls.Add(Me.l)
        Me.ControlPanel1.Controls.Add(Me.Label6)
        Me.ControlPanel1.Controls.Add(Me.eventFechaInicio)
        Me.ControlPanel1.Controls.Add(Me.eventFechaFinal)
        Me.ControlPanel1.Controls.Add(Me.comboEventDispo)
        Me.ControlPanel1.Controls.Add(Me.comboEventVisibilidad)
        Me.ControlPanel1.Controls.Add(Me.Label7)
        Me.ControlPanel1.Controls.Add(Me.Label8)
        Me.ControlPanel1.Location = New System.Drawing.Point(627, 501)
        Me.ControlPanel1.Name = "ControlPanel1"
        Me.ControlPanel1.Size = New System.Drawing.Size(600, 625)
        Me.ControlPanel1.TabIndex = 106
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip2.Location = New System.Drawing.Point(314, 554)
        Me.MenuStrip2.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(232, 46)
        Me.MenuStrip2.TabIndex = 116
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.AutoSize = False
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(112, 42)
        Me.ToolStripMenuItem1.Text = "Guardar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.AutoSize = False
        Me.ToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(112, 42)
        Me.ToolStripMenuItem2.Text = "Continuar"
        '
        'ControlTextBox4
        '
        Me.ControlTextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ControlTextBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ControlTextBox4.BorderFocusColor = System.Drawing.Color.Black
        Me.ControlTextBox4.BorderRadius = 8
        Me.ControlTextBox4.BorderSize = 1
        Me.ControlTextBox4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlTextBox4.Location = New System.Drawing.Point(34, 380)
        Me.ControlTextBox4.Multiline = True
        Me.ControlTextBox4.Name = "ControlTextBox4"
        Me.ControlTextBox4.Padding = New System.Windows.Forms.Padding(7)
        Me.ControlTextBox4.PasswordChar = False
        Me.ControlTextBox4.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.ControlTextBox4.PlaceholderText = ""
        Me.ControlTextBox4.Size = New System.Drawing.Size(530, 144)
        Me.ControlTextBox4.TabIndex = 107
        Me.ControlTextBox4.Texts = ""
        Me.ControlTextBox4.UnderlinedStyle = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 345)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 18)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Descripción"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"No repetir", "Todos los días", "Todos los días hábiles (lunes a viernes)", "Personalizar"})
        Me.ComboBox1.Location = New System.Drawing.Point(34, 285)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(251, 28)
        Me.ComboBox1.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 18)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Recurrencia"
        '
        'ControlTextBox3
        '
        Me.ControlTextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ControlTextBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ControlTextBox3.BorderFocusColor = System.Drawing.Color.Black
        Me.ControlTextBox3.BorderRadius = 8
        Me.ControlTextBox3.BorderSize = 1
        Me.ControlTextBox3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlTextBox3.Location = New System.Drawing.Point(314, 99)
        Me.ControlTextBox3.Multiline = False
        Me.ControlTextBox3.Name = "ControlTextBox3"
        Me.ControlTextBox3.Padding = New System.Windows.Forms.Padding(7)
        Me.ControlTextBox3.PasswordChar = False
        Me.ControlTextBox3.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.ControlTextBox3.PlaceholderText = ""
        Me.ControlTextBox3.Size = New System.Drawing.Size(250, 35)
        Me.ControlTextBox3.TabIndex = 86
        Me.ControlTextBox3.Texts = ""
        Me.ControlTextBox3.UnderlinedStyle = False
        '
        'ControlTextBox2
        '
        Me.ControlTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ControlTextBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ControlTextBox2.BorderFocusColor = System.Drawing.Color.Black
        Me.ControlTextBox2.BorderRadius = 8
        Me.ControlTextBox2.BorderSize = 1
        Me.ControlTextBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlTextBox2.Location = New System.Drawing.Point(35, 99)
        Me.ControlTextBox2.Multiline = False
        Me.ControlTextBox2.Name = "ControlTextBox2"
        Me.ControlTextBox2.Padding = New System.Windows.Forms.Padding(7)
        Me.ControlTextBox2.PasswordChar = False
        Me.ControlTextBox2.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.ControlTextBox2.PlaceholderText = ""
        Me.ControlTextBox2.Size = New System.Drawing.Size(250, 35)
        Me.ControlTextBox2.TabIndex = 85
        Me.ControlTextBox2.Texts = ""
        Me.ControlTextBox2.UnderlinedStyle = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.IconPictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 50)
        Me.Panel1.TabIndex = 0
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox1.BackColor = System.Drawing.Color.White
        Me.IconPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconPictureBox1.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox1.Location = New System.Drawing.Point(534, 15)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox1.TabIndex = 1
        Me.IconPictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datos Básicos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 18)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Titulo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(311, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 18)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Ubicación"
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
        Me.PanelDatosRecurrencia.Location = New System.Drawing.Point(43, 617)
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
        'IconButton1
        '
        Me.IconButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.IconButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.IconButton1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconButton1.IconColor = System.Drawing.Color.Black
        Me.IconButton1.IconSize = 16
        Me.IconButton1.Location = New System.Drawing.Point(128, 292)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Rotation = 0R
        Me.IconButton1.Size = New System.Drawing.Size(163, 42)
        Me.IconButton1.TabIndex = 114
        Me.IconButton1.Text = "Continuar/Omitir"
        Me.IconButton1.UseVisualStyleBackColor = False
        '
        'ControlPanel2
        '
        Me.ControlPanel2.BackColor = System.Drawing.Color.White
        Me.ControlPanel2.BorderRadius = 12
        Me.ControlPanel2.Controls.Add(Me.IconButton3)
        Me.ControlPanel2.Controls.Add(Me.IconButton1)
        Me.ControlPanel2.Controls.Add(Me.IconPictureBox3)
        Me.ControlPanel2.Controls.Add(Me.ComboBox5)
        Me.ControlPanel2.Controls.Add(Me.Label26)
        Me.ControlPanel2.Controls.Add(Me.ComboBox4)
        Me.ControlPanel2.Controls.Add(Me.Panel4)
        Me.ControlPanel2.Controls.Add(Me.Label34)
        Me.ControlPanel2.Controls.Add(Me.Label35)
        Me.ControlPanel2.Controls.Add(Me.Label36)
        Me.ControlPanel2.Location = New System.Drawing.Point(246, 104)
        Me.ControlPanel2.Name = "ControlPanel2"
        Me.ControlPanel2.Size = New System.Drawing.Size(424, 356)
        Me.ControlPanel2.TabIndex = 123
        '
        'IconButton3
        '
        Me.IconButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.IconButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.IconButton3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconButton3.IconColor = System.Drawing.Color.Black
        Me.IconButton3.IconSize = 16
        Me.IconButton3.Location = New System.Drawing.Point(128, 218)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Rotation = 0R
        Me.IconButton3.Size = New System.Drawing.Size(163, 42)
        Me.IconButton3.TabIndex = 121
        Me.IconButton3.Text = "Agregar Asistente"
        Me.IconButton3.UseVisualStyleBackColor = False
        '
        'IconPictureBox3
        '
        Me.IconPictureBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconPictureBox3.ForeColor = System.Drawing.Color.Red
        Me.IconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconPictureBox3.IconColor = System.Drawing.Color.Red
        Me.IconPictureBox3.Location = New System.Drawing.Point(318, 159)
        Me.IconPictureBox3.Name = "IconPictureBox3"
        Me.IconPictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox3.TabIndex = 120
        Me.IconPictureBox3.TabStop = False
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(113, 159)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(178, 28)
        Me.ComboBox5.TabIndex = 119
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(259, 109)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 20)
        Me.Label26.TabIndex = 118
        Me.Label26.Text = "DisplayName"
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(30, 106)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(179, 28)
        Me.ComboBox4.TabIndex = 117
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.IconPictureBox2)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 50)
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
        Me.IconPictureBox2.Location = New System.Drawing.Point(358, 15)
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
        Me.Label33.Size = New System.Drawing.Size(83, 19)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Invitados"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(28, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 18)
        Me.Label34.TabIndex = 84
        Me.Label34.Text = "Email"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(260, 69)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(136, 18)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "Nombre Asistente"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(28, 163)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(73, 18)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Invitados"
        '
        'ControlPanel3
        '
        Me.ControlPanel3.BackColor = System.Drawing.Color.White
        Me.ControlPanel3.BorderRadius = 12
        Me.ControlPanel3.Controls.Add(Me.MenuStrip3)
        Me.ControlPanel3.Controls.Add(Me.Button1)
        Me.ControlPanel3.Controls.Add(Me.Button2)
        Me.ControlPanel3.Controls.Add(Me.ComboBox6)
        Me.ControlPanel3.Controls.Add(Me.NumericUpDown1)
        Me.ControlPanel3.Controls.Add(Me.ComboBox3)
        Me.ControlPanel3.Controls.Add(Me.IconPictureBox5)
        Me.ControlPanel3.Controls.Add(Me.ComboBox2)
        Me.ControlPanel3.Controls.Add(Me.Label28)
        Me.ControlPanel3.Controls.Add(Me.Panel3)
        Me.ControlPanel3.Controls.Add(Me.Label30)
        Me.ControlPanel3.Controls.Add(Me.Label32)
        Me.ControlPanel3.Location = New System.Drawing.Point(770, 67)
        Me.ControlPanel3.Name = "ControlPanel3"
        Me.ControlPanel3.Size = New System.Drawing.Size(488, 428)
        Me.ControlPanel3.TabIndex = 124
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.MenuStrip3.Location = New System.Drawing.Point(159, 366)
        Me.MenuStrip3.Margin = New System.Windows.Forms.Padding(3)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(232, 46)
        Me.MenuStrip3.TabIndex = 130
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.AutoSize = False
        Me.ToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ToolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(112, 42)
        Me.ToolStripMenuItem3.Text = "Finalizar"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.AutoSize = False
        Me.ToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ToolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(112, 42)
        Me.ToolStripMenuItem4.Text = "Actualizar"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(50, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(190, 38)
        Me.Button1.TabIndex = 129
        Me.Button1.Text = "Actualizar recordatorio"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(254, 300)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(190, 38)
        Me.Button2.TabIndex = 128
        Me.Button2.Text = "Añadir recordatorio"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox6
        '
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"Minutos", "Horas", "Días", "Semanas"})
        Me.ComboBox6.Location = New System.Drawing.Point(336, 246)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(121, 28)
        Me.ComboBox6.TabIndex = 127
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(221, 247)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(109, 26)
        Me.NumericUpDown1.TabIndex = 126
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Notificación", "Correo electrónico"})
        Me.ComboBox3.Location = New System.Drawing.Point(34, 199)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(188, 28)
        Me.ComboBox3.TabIndex = 125
        '
        'IconPictureBox5
        '
        Me.IconPictureBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconPictureBox5.ForeColor = System.Drawing.Color.Red
        Me.IconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconPictureBox5.IconColor = System.Drawing.Color.Red
        Me.IconPictureBox5.Location = New System.Drawing.Point(336, 104)
        Me.IconPictureBox5.Name = "IconPictureBox5"
        Me.IconPictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox5.TabIndex = 124
        Me.IconPictureBox5.TabStop = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(34, 104)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(296, 28)
        Me.ComboBox2.TabIndex = 123
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(31, 252)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(187, 18)
        Me.Label28.TabIndex = 97
        Me.Label28.Text = "Tiempo Antes del Evento"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.IconPictureBox4)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(488, 50)
        Me.Panel3.TabIndex = 0
        '
        'IconPictureBox4
        '
        Me.IconPictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox4.BackColor = System.Drawing.Color.White
        Me.IconPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconPictureBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconPictureBox4.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.IconPictureBox4.Location = New System.Drawing.Point(422, 15)
        Me.IconPictureBox4.Name = "IconPictureBox4"
        Me.IconPictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox4.TabIndex = 1
        Me.IconPictureBox4.TabStop = False
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
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(31, 69)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(171, 18)
        Me.Label30.TabIndex = 84
        Me.Label30.Text = "Notificaciones Activas"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(31, 163)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(191, 18)
        Me.Label32.TabIndex = 87
        Me.Label32.Text = "Método de Recordatorio"
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1472, 742)
        Me.Controls.Add(Me.ControlPanel3)
        Me.Controls.Add(Me.ControlPanel2)
        Me.Controls.Add(Me.ControlPanel1)
        Me.Controls.Add(Me.PanelDatosRecurrencia)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.ControlPanel1.ResumeLayout(False)
        Me.ControlPanel1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosRecurrencia.ResumeLayout(False)
        Me.PanelDatosRecurrencia.PerformLayout()
        CType(Me.txtOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel2.ResumeLayout(False)
        Me.ControlPanel2.PerformLayout()
        CType(Me.IconPictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel3.ResumeLayout(False)
        Me.ControlPanel3.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconPictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.IconPictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel1 As ControlPanel
    Friend WithEvents comboEventVisibilidad As ComboBox
    Friend WithEvents comboEventDispo As ComboBox
    Friend WithEvents eventFechaFinal As DateTimePicker
    Friend WithEvents eventFechaInicio As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents l As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ControlTextBox2 As ControlTextBox
    Friend WithEvents ControlTextBox3 As ControlTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ControlTextBox4 As ControlTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
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
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents ControlPanel2 As ControlPanel
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents IconPictureBox2 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents IconPictureBox3 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents ControlPanel3 As ControlPanel
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents IconPictureBox4 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents IconPictureBox5 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ComboBox2 As ComboBox
End Class
