<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionReportes
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVolverDash = New FontAwesome.Sharp.IconPictureBox()
        Me.panelFiltros = New SistemasVentas.ControlPanel()
        Me.dateLimiteFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.checkIntervalo = New System.Windows.Forms.CheckBox()
        Me.txtLimite = New SistemasVentas.ControlTextBox()
        Me.btnCancelarReporte = New System.Windows.Forms.Button()
        Me.btnListoFiltros = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dateLimiteInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.panelCorreo = New SistemasVentas.ControlPanel()
        Me.btnCancelarBuscarCorreo = New System.Windows.Forms.Button()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New SistemasVentas.ControlTextBox()
        Me.btnBuscar = New FontAwesome.Sharp.IconButton()
        CType(Me.btnVolverDash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFiltros.SuspendLayout()
        Me.panelCorreo.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportViewer1.IsDocumentMapWidthFixed = True
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SistemasVentas.TareasPendientes.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.PromptAreaCollapsed = True
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1159, 683)
        Me.ReportViewer1.TabIndex = 0
        '
        'btnVolverDash
        '
        Me.btnVolverDash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolverDash.BackColor = System.Drawing.Color.Transparent
        Me.btnVolverDash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolverDash.ForeColor = System.Drawing.Color.Red
        Me.btnVolverDash.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolverDash.IconColor = System.Drawing.Color.Red
        Me.btnVolverDash.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolverDash.IconSize = 57
        Me.btnVolverDash.Location = New System.Drawing.Point(1086, 12)
        Me.btnVolverDash.Name = "btnVolverDash"
        Me.btnVolverDash.Size = New System.Drawing.Size(61, 57)
        Me.btnVolverDash.TabIndex = 2
        Me.btnVolverDash.TabStop = False
        '
        'panelFiltros
        '
        Me.panelFiltros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelFiltros.BackColor = System.Drawing.Color.White
        Me.panelFiltros.BorderRadius = 8
        Me.panelFiltros.Controls.Add(Me.dateLimiteFinal)
        Me.panelFiltros.Controls.Add(Me.Label1)
        Me.panelFiltros.Controls.Add(Me.checkIntervalo)
        Me.panelFiltros.Controls.Add(Me.txtLimite)
        Me.panelFiltros.Controls.Add(Me.btnCancelarReporte)
        Me.panelFiltros.Controls.Add(Me.btnListoFiltros)
        Me.panelFiltros.Controls.Add(Me.Label13)
        Me.panelFiltros.Controls.Add(Me.dateLimiteInicio)
        Me.panelFiltros.Controls.Add(Me.Label10)
        Me.panelFiltros.Controls.Add(Me.Label21)
        Me.panelFiltros.Location = New System.Drawing.Point(594, 118)
        Me.panelFiltros.Name = "panelFiltros"
        Me.panelFiltros.Size = New System.Drawing.Size(553, 400)
        Me.panelFiltros.TabIndex = 122
        Me.panelFiltros.Visible = False
        '
        'dateLimiteFinal
        '
        Me.dateLimiteFinal.Enabled = False
        Me.dateLimiteFinal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateLimiteFinal.Location = New System.Drawing.Point(298, 260)
        Me.dateLimiteFinal.Name = "dateLimiteFinal"
        Me.dateLimiteFinal.Size = New System.Drawing.Size(219, 26)
        Me.dateLimiteFinal.TabIndex = 126
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(296, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Hasta"
        '
        'checkIntervalo
        '
        Me.checkIntervalo.AutoSize = True
        Me.checkIntervalo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkIntervalo.Location = New System.Drawing.Point(201, 178)
        Me.checkIntervalo.Name = "checkIntervalo"
        Me.checkIntervalo.Size = New System.Drawing.Size(178, 24)
        Me.checkIntervalo.TabIndex = 124
        Me.checkIntervalo.Text = "Intervalo de Fechas"
        Me.checkIntervalo.UseVisualStyleBackColor = True
        '
        'txtLimite
        '
        Me.txtLimite.BackColor = System.Drawing.Color.LightGray
        Me.txtLimite.BorderColor = System.Drawing.Color.Transparent
        Me.txtLimite.BorderFocusColor = System.Drawing.Color.HotPink
        Me.txtLimite.BorderRadius = 5
        Me.txtLimite.BorderSize = 2
        Me.txtLimite.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimite.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtLimite.Location = New System.Drawing.Point(239, 112)
        Me.txtLimite.Multiline = False
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.txtLimite.PasswordChar = False
        Me.txtLimite.PlaceholderColor = System.Drawing.Color.White
        Me.txtLimite.PlaceholderText = "Vacío sin limite"
        Me.txtLimite.Size = New System.Drawing.Size(222, 35)
        Me.txtLimite.TabIndex = 123
        Me.txtLimite.Texts = "Vacío sin limite"
        Me.txtLimite.UnderlinedStyle = False
        '
        'btnCancelarReporte
        '
        Me.btnCancelarReporte.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarReporte.FlatAppearance.BorderSize = 0
        Me.btnCancelarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarReporte.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarReporte.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarReporte.Location = New System.Drawing.Point(160, 325)
        Me.btnCancelarReporte.Name = "btnCancelarReporte"
        Me.btnCancelarReporte.Size = New System.Drawing.Size(106, 45)
        Me.btnCancelarReporte.TabIndex = 122
        Me.btnCancelarReporte.Text = "Cancelar"
        Me.btnCancelarReporte.UseVisualStyleBackColor = False
        '
        'btnListoFiltros
        '
        Me.btnListoFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnListoFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListoFiltros.FlatAppearance.BorderSize = 0
        Me.btnListoFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListoFiltros.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListoFiltros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnListoFiltros.Location = New System.Drawing.Point(287, 325)
        Me.btnListoFiltros.Name = "btnListoFiltros"
        Me.btnListoFiltros.Size = New System.Drawing.Size(106, 45)
        Me.btnListoFiltros.TabIndex = 121
        Me.btnListoFiltros.Text = "Listo"
        Me.btnListoFiltros.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(32, 224)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 20)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Desde"
        '
        'dateLimiteInicio
        '
        Me.dateLimiteInicio.Enabled = False
        Me.dateLimiteInicio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateLimiteInicio.Location = New System.Drawing.Point(36, 260)
        Me.dateLimiteInicio.Name = "dateLimiteInicio"
        Me.dateLimiteInicio.Size = New System.Drawing.Size(219, 26)
        Me.dateLimiteInicio.TabIndex = 115
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(102, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 20)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Límite de Items"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(242, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 23)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "Filtros"
        '
        'panelCorreo
        '
        Me.panelCorreo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelCorreo.BackColor = System.Drawing.Color.White
        Me.panelCorreo.BorderRadius = 8
        Me.panelCorreo.Controls.Add(Me.btnCancelarBuscarCorreo)
        Me.panelCorreo.Controls.Add(Me.cbUsuarios)
        Me.panelCorreo.Controls.Add(Me.Label2)
        Me.panelCorreo.Controls.Add(Me.txtEmail)
        Me.panelCorreo.Controls.Add(Me.btnBuscar)
        Me.panelCorreo.Location = New System.Drawing.Point(80, 121)
        Me.panelCorreo.Name = "panelCorreo"
        Me.panelCorreo.Size = New System.Drawing.Size(372, 248)
        Me.panelCorreo.TabIndex = 123
        Me.panelCorreo.Visible = False
        '
        'btnCancelarBuscarCorreo
        '
        Me.btnCancelarBuscarCorreo.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelarBuscarCorreo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarBuscarCorreo.FlatAppearance.BorderSize = 0
        Me.btnCancelarBuscarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelarBuscarCorreo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarBuscarCorreo.ForeColor = System.Drawing.Color.Gray
        Me.btnCancelarBuscarCorreo.Location = New System.Drawing.Point(61, 165)
        Me.btnCancelarBuscarCorreo.Name = "btnCancelarBuscarCorreo"
        Me.btnCancelarBuscarCorreo.Size = New System.Drawing.Size(106, 42)
        Me.btnCancelarBuscarCorreo.TabIndex = 152
        Me.btnCancelarBuscarCorreo.Text = "Cancelar"
        Me.btnCancelarBuscarCorreo.UseVisualStyleBackColor = False
        '
        'cbUsuarios
        '
        Me.cbUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(41, 114)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(290, 24)
        Me.cbUsuarios.TabIndex = 151
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(44, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 16)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Escribir correo de usuario a buscar"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.txtEmail.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtEmail.BorderFocusColor = System.Drawing.Color.Black
        Me.txtEmail.BorderRadius = 8
        Me.txtEmail.BorderSize = 1
        Me.txtEmail.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(41, 72)
        Me.txtEmail.Multiline = False
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Padding = New System.Windows.Forms.Padding(7)
        Me.txtEmail.PasswordChar = False
        Me.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtEmail.PlaceholderText = ""
        Me.txtEmail.Size = New System.Drawing.Size(290, 36)
        Me.txtEmail.TabIndex = 149
        Me.txtEmail.Texts = ""
        Me.txtEmail.UnderlinedStyle = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnBuscar.IconColor = System.Drawing.Color.Black
        Me.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnBuscar.IconSize = 16
        Me.btnBuscar.Location = New System.Drawing.Point(173, 165)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(143, 42)
        Me.btnBuscar.TabIndex = 148
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'GestionReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1159, 683)
        Me.Controls.Add(Me.panelCorreo)
        Me.Controls.Add(Me.panelFiltros)
        Me.Controls.Add(Me.btnVolverDash)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "GestionReportes"
        Me.Text = "GestionReportes"
        CType(Me.btnVolverDash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFiltros.ResumeLayout(False)
        Me.panelFiltros.PerformLayout()
        Me.panelCorreo.ResumeLayout(False)
        Me.panelCorreo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnVolverDash As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents panelFiltros As ControlPanel
    Friend WithEvents btnCancelarReporte As Button
    Friend WithEvents btnListoFiltros As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents dateLimiteInicio As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtLimite As ControlTextBox
    Friend WithEvents checkIntervalo As CheckBox
    Friend WithEvents dateLimiteFinal As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents panelCorreo As ControlPanel
    Friend WithEvents cbUsuarios As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As ControlTextBox
    Friend WithEvents btnBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCancelarBuscarCorreo As Button
End Class
