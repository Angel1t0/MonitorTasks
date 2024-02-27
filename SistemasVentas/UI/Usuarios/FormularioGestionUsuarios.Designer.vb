<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormularioGestionUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormularioGestionUsuarios))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtBusca = New System.Windows.Forms.TextBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pbInsertarUsuario = New System.Windows.Forms.PictureBox()
        Me.dgvDataUsuario = New System.Windows.Forms.DataGridView()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbIcono = New System.Windows.Forms.Label()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbRol = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbInsertarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDataUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1134, 41)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 41)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "USUARIOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.White
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1070, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(64, 41)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "X"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtBusca)
        Me.Panel2.Controls.Add(Me.MenuStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1134, 51)
        Me.Panel2.TabIndex = 1
        '
        'txtBusca
        '
        Me.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusca.Location = New System.Drawing.Point(339, 16)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(500, 30)
        Me.txtBusca.TabIndex = 0
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AutoSize = False
        Me.MenuStrip2.BackgroundImage = CType(resources.GetObject("MenuStrip2.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Location = New System.Drawing.Point(300, 20)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(35, 22)
        Me.MenuStrip2.TabIndex = 2
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pbInsertarUsuario)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1005, 92)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(139, 592)
        Me.Panel3.TabIndex = 2
        '
        'pbInsertarUsuario
        '
        Me.pbInsertarUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbInsertarUsuario.Image = CType(resources.GetObject("pbInsertarUsuario.Image"), System.Drawing.Image)
        Me.pbInsertarUsuario.Location = New System.Drawing.Point(10, 10)
        Me.pbInsertarUsuario.Name = "pbInsertarUsuario"
        Me.pbInsertarUsuario.Size = New System.Drawing.Size(119, 572)
        Me.pbInsertarUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbInsertarUsuario.TabIndex = 0
        Me.pbInsertarUsuario.TabStop = False
        '
        'dgvDataUsuario
        '
        Me.dgvDataUsuario.AllowUserToAddRows = False
        Me.dgvDataUsuario.AllowUserToDeleteRows = False
        Me.dgvDataUsuario.AllowUserToResizeRows = False
        Me.dgvDataUsuario.BackgroundColor = System.Drawing.Color.White
        Me.dgvDataUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataUsuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataUsuario.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataUsuario.EnableHeadersVisualStyles = False
        Me.dgvDataUsuario.Location = New System.Drawing.Point(10, 92)
        Me.dgvDataUsuario.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataUsuario.Name = "dgvDataUsuario"
        Me.dgvDataUsuario.ReadOnly = True
        Me.dgvDataUsuario.RowHeadersVisible = False
        Me.dgvDataUsuario.RowHeadersWidth = 51
        Me.dgvDataUsuario.RowTemplate.Height = 30
        Me.dgvDataUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataUsuario.Size = New System.Drawing.Size(995, 592)
        Me.dgvDataUsuario.TabIndex = 3
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
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(266, 243)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1156, 600)
        Me.Panel4.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnActualizar)
        Me.Panel5.Controls.Add(Me.Panel9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.lbIcono)
        Me.Panel5.Controls.Add(Me.pbIcon)
        Me.Panel5.Controls.Add(Me.btnVolver)
        Me.Panel5.Controls.Add(Me.btnGuardar)
        Me.Panel5.Controls.Add(Me.cbRol)
        Me.Panel5.Controls.Add(Me.txtEmail)
        Me.Panel5.Controls.Add(Me.txtPass)
        Me.Panel5.Controls.Add(Me.txtUser)
        Me.Panel5.Controls.Add(Me.txtName)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Location = New System.Drawing.Point(103, 82)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(971, 473)
        Me.Panel5.TabIndex = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.FlatAppearance.BorderSize = 0
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.ForeColor = System.Drawing.Color.Black
        Me.btnActualizar.Location = New System.Drawing.Point(250, 316)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(182, 61)
        Me.btnActualizar.TabIndex = 18
        Me.btnActualizar.Text = "ACTUALIZAR"
        Me.btnActualizar.UseVisualStyleBackColor = False
        Me.btnActualizar.Visible = False
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Location = New System.Drawing.Point(249, 223)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(345, 2)
        Me.Panel9.TabIndex = 17
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(249, 176)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(345, 2)
        Me.Panel8.TabIndex = 16
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(249, 130)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(345, 2)
        Me.Panel7.TabIndex = 15
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(249, 88)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(345, 2)
        Me.Panel6.TabIndex = 14
        '
        'lbIcono
        '
        Me.lbIcono.BackColor = System.Drawing.Color.Gray
        Me.lbIcono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbIcono.ForeColor = System.Drawing.Color.White
        Me.lbIcono.Location = New System.Drawing.Point(691, 62)
        Me.lbIcono.Name = "lbIcono"
        Me.lbIcono.Size = New System.Drawing.Size(188, 220)
        Me.lbIcono.TabIndex = 13
        Me.lbIcono.Text = "Agregar Icono"
        Me.lbIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbIcon
        '
        Me.pbIcon.BackColor = System.Drawing.Color.White
        Me.pbIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbIcon.Location = New System.Drawing.Point(691, 62)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(188, 216)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbIcon.TabIndex = 12
        Me.pbIcon.TabStop = False
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.Transparent
        Me.btnVolver.FlatAppearance.BorderSize = 0
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(793, 368)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(99, 51)
        Me.btnVolver.TabIndex = 11
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Location = New System.Drawing.Point(428, 316)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(166, 61)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cbRol
        '
        Me.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRol.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbRol.FormattingEnabled = True
        Me.cbRol.Items.AddRange(New Object() {"Solo Ventas (No Maneja Dinero)", "Cajero (Manejar Dinero)", "Administrador (Control Total)"})
        Me.cbRol.Location = New System.Drawing.Point(249, 249)
        Me.cbRol.Name = "cbRol"
        Me.cbRol.Size = New System.Drawing.Size(345, 33)
        Me.cbRol.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Location = New System.Drawing.Point(249, 200)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(345, 23)
        Me.txtEmail.TabIndex = 8
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPass.Location = New System.Drawing.Point(249, 153)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(345, 23)
        Me.txtPass.TabIndex = 7
        '
        'txtUser
        '
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUser.Location = New System.Drawing.Point(249, 107)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(345, 23)
        Me.txtUser.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtName.Location = New System.Drawing.Point(250, 65)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(345, 23)
        Me.txtName.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 25)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Rol:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(162, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 25)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Correo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Contraseña:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre y apellido:"
        '
        'FormularioGestionUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1154, 684)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.dgvDataUsuario)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormularioGestionUsuarios"
        Me.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UsuariosOk"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pbInsertarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDataUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBusca As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pbInsertarUsuario As PictureBox
    Friend WithEvents dgvDataUsuario As DataGridView
    Friend WithEvents Eli As DataGridViewImageColumn
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbRol As ComboBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lbIcono As Label
    Friend WithEvents pbIcon As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents MenuStrip2 As MenuStrip
End Class
