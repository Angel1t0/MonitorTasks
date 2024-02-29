<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.panelRecuperar = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lbVolver = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtRecuperacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvRevisar = New System.Windows.Forms.DataGridView()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNoVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lbOlvidar = New System.Windows.Forms.Label()
        Me.panelLogin = New System.Windows.Forms.Panel()
        Me.panelRecuperar.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvRevisar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.panelLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelRecuperar
        '
        Me.panelRecuperar.Controls.Add(Me.Panel7)
        Me.panelRecuperar.Controls.Add(Me.Panel10)
        Me.panelRecuperar.Location = New System.Drawing.Point(714, 153)
        Me.panelRecuperar.Name = "panelRecuperar"
        Me.panelRecuperar.Size = New System.Drawing.Size(540, 405)
        Me.panelRecuperar.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lbVolver)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.btnEnviar)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Controls.Add(Me.txtRecuperacion)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Location = New System.Drawing.Point(26, 100)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(486, 304)
        Me.Panel7.TabIndex = 1
        '
        'lbVolver
        '
        Me.lbVolver.AutoSize = True
        Me.lbVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbVolver.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbVolver.ForeColor = System.Drawing.Color.DimGray
        Me.lbVolver.Location = New System.Drawing.Point(390, 251)
        Me.lbVolver.Name = "lbVolver"
        Me.lbVolver.Size = New System.Drawing.Size(67, 18)
        Me.lbVolver.TabIndex = 9
        Me.lbVolver.Text = "VOLVER"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(29, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Con el que registraste tu cuenta."
        '
        'btnEnviar
        '
        Me.btnEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.FlatAppearance.BorderSize = 0
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Location = New System.Drawing.Point(32, 163)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(422, 60)
        Me.btnEnviar.TabIndex = 7
        Me.btnEnviar.Text = "ENVIAR"
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Location = New System.Drawing.Point(32, 109)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(423, 1)
        Me.Panel8.TabIndex = 6
        '
        'txtRecuperacion
        '
        Me.txtRecuperacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRecuperacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecuperacion.Location = New System.Drawing.Point(32, 76)
        Me.txtRecuperacion.Name = "txtRecuperacion"
        Me.txtRecuperacion.Size = New System.Drawing.Size(423, 23)
        Me.txtRecuperacion.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(29, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "CORREO"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(540, 95)
        Me.Panel10.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(40, 20, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(540, 95)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RECUPERACIÓN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvRevisar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(540, 95)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(40, 20, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(540, 95)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INICIO DE SESIÓN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvRevisar
        '
        Me.dgvRevisar.AllowUserToAddRows = False
        Me.dgvRevisar.AllowUserToDeleteRows = False
        Me.dgvRevisar.AllowUserToResizeRows = False
        Me.dgvRevisar.BackgroundColor = System.Drawing.Color.White
        Me.dgvRevisar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRevisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRevisar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRevisar.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRevisar.EnableHeadersVisualStyles = False
        Me.dgvRevisar.Location = New System.Drawing.Point(308, 10)
        Me.dgvRevisar.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvRevisar.Name = "dgvRevisar"
        Me.dgvRevisar.ReadOnly = True
        Me.dgvRevisar.RowHeadersVisible = False
        Me.dgvRevisar.RowHeadersWidth = 51
        Me.dgvRevisar.RowTemplate.Height = 30
        Me.dgvRevisar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRevisar.Size = New System.Drawing.Size(197, 203)
        Me.dgvRevisar.TabIndex = 4
        Me.dgvRevisar.Visible = False
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lbOlvidar)
        Me.Panel3.Controls.Add(Me.btnLogin)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.txtPass)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.txtLogin)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Location = New System.Drawing.Point(26, 121)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(486, 409)
        Me.Panel3.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnVer, Me.btnNoVer})
        Me.MenuStrip1.Location = New System.Drawing.Point(407, 172)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(40, 28)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnVer
        '
        Me.btnVer.AutoSize = False
        Me.btnVer.BackColor = System.Drawing.Color.Transparent
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(32, 24)
        '
        'btnNoVer
        '
        Me.btnNoVer.AutoSize = False
        Me.btnNoVer.BackColor = System.Drawing.Color.Transparent
        Me.btnNoVer.Image = CType(resources.GetObject("btnNoVer.Image"), System.Drawing.Image)
        Me.btnNoVer.Name = "btnNoVer"
        Me.btnNoVer.Size = New System.Drawing.Size(32, 24)
        Me.btnNoVer.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(24, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "USUARIO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(27, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CONTRASEÑA"
        '
        'txtLogin
        '
        Me.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLogin.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.Location = New System.Drawing.Point(28, 91)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(423, 23)
        Me.txtLogin.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(28, 115)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(421, 1)
        Me.Panel4.TabIndex = 4
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(32, 185)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(366, 23)
        Me.txtPass.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(32, 209)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(421, 1)
        Me.Panel5.TabIndex = 6
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(32, 317)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(422, 60)
        Me.btnLogin.TabIndex = 7
        Me.btnLogin.Text = "INGRESAR"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lbOlvidar
        '
        Me.lbOlvidar.AutoSize = True
        Me.lbOlvidar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbOlvidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOlvidar.ForeColor = System.Drawing.Color.MediumBlue
        Me.lbOlvidar.Location = New System.Drawing.Point(283, 257)
        Me.lbOlvidar.Name = "lbOlvidar"
        Me.lbOlvidar.Size = New System.Drawing.Size(162, 16)
        Me.lbOlvidar.TabIndex = 8
        Me.lbOlvidar.Text = "¿Olvidaste la contraseña?"
        '
        'panelLogin
        '
        Me.panelLogin.Controls.Add(Me.Panel3)
        Me.panelLogin.Controls.Add(Me.Panel2)
        Me.panelLogin.Location = New System.Drawing.Point(56, 12)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(540, 556)
        Me.panelLogin.TabIndex = 0
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1327, 643)
        Me.Controls.Add(Me.panelRecuperar)
        Me.Controls.Add(Me.panelLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.panelRecuperar.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvRevisar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.panelLogin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelRecuperar As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtRecuperacion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbVolver As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvRevisar As DataGridView
    Friend WithEvents Eli As DataGridViewImageColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbOlvidar As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnVer As ToolStripMenuItem
    Friend WithEvents btnNoVer As ToolStripMenuItem
    Friend WithEvents panelLogin As Panel
End Class
