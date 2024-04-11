<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionMensajes
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labelCantidadEventos = New System.Windows.Forms.Label()
        Me.PanelDataMensajes = New System.Windows.Forms.Panel()
        Me.dgvDataMensajes = New System.Windows.Forms.DataGridView()
        Me.PanelEditarNotificaciones = New System.Windows.Forms.Panel()
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
        Me.Panel1.SuspendLayout()
        Me.PanelDataMensajes.SuspendLayout()
        CType(Me.dgvDataMensajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEditarNotificaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.labelCantidadEventos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1159, 88)
        Me.Panel1.TabIndex = 109
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
        'PanelDataMensajes
        '
        Me.PanelDataMensajes.Controls.Add(Me.dgvDataMensajes)
        Me.PanelDataMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDataMensajes.Location = New System.Drawing.Point(0, 88)
        Me.PanelDataMensajes.Name = "PanelDataMensajes"
        Me.PanelDataMensajes.Size = New System.Drawing.Size(1159, 595)
        Me.PanelDataMensajes.TabIndex = 110
        '
        'dgvDataMensajes
        '
        Me.dgvDataMensajes.AllowUserToAddRows = False
        Me.dgvDataMensajes.AllowUserToDeleteRows = False
        Me.dgvDataMensajes.AllowUserToResizeRows = False
        Me.dgvDataMensajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDataMensajes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvDataMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataMensajes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataMensajes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(8)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataMensajes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDataMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataMensajes.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDataMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataMensajes.EnableHeadersVisualStyles = False
        Me.dgvDataMensajes.Location = New System.Drawing.Point(0, 0)
        Me.dgvDataMensajes.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataMensajes.Name = "dgvDataMensajes"
        Me.dgvDataMensajes.ReadOnly = True
        Me.dgvDataMensajes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataMensajes.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDataMensajes.RowHeadersVisible = False
        Me.dgvDataMensajes.RowHeadersWidth = 51
        Me.dgvDataMensajes.RowTemplate.Height = 40
        Me.dgvDataMensajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataMensajes.Size = New System.Drawing.Size(1159, 595)
        Me.dgvDataMensajes.TabIndex = 102
        '
        'PanelEditarNotificaciones
        '
        Me.PanelEditarNotificaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.PanelEditarNotificaciones.Controls.Add(Me.dateSilenciar)
        Me.PanelEditarNotificaciones.Controls.Add(Me.Label3)
        Me.PanelEditarNotificaciones.Controls.Add(Me.checkDesktop)
        Me.PanelEditarNotificaciones.Controls.Add(Me.checkGmail)
        Me.PanelEditarNotificaciones.Controls.Add(Me.checkWhatsapp)
        Me.PanelEditarNotificaciones.Controls.Add(Me.Label2)
        Me.PanelEditarNotificaciones.Controls.Add(Me.btnGuardarNotificaciones)
        Me.PanelEditarNotificaciones.Controls.Add(Me.btnCancelar)
        Me.PanelEditarNotificaciones.Controls.Add(Me.comboUsuariosANotificar)
        Me.PanelEditarNotificaciones.Controls.Add(Me.Label8)
        Me.PanelEditarNotificaciones.Controls.Add(Me.Label7)
        Me.PanelEditarNotificaciones.Location = New System.Drawing.Point(1118, 135)
        Me.PanelEditarNotificaciones.Name = "PanelEditarNotificaciones"
        Me.PanelEditarNotificaciones.Size = New System.Drawing.Size(547, 446)
        Me.PanelEditarNotificaciones.TabIndex = 103
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
        Me.Label3.Location = New System.Drawing.Point(111, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 20)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "Silenciar hasta"
        '
        'checkDesktop
        '
        Me.checkDesktop.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkDesktop.AutoSize = True
        Me.checkDesktop.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkDesktop.Location = New System.Drawing.Point(418, 204)
        Me.checkDesktop.Name = "checkDesktop"
        Me.checkDesktop.Size = New System.Drawing.Size(96, 24)
        Me.checkDesktop.TabIndex = 127
        Me.checkDesktop.Text = "Escritorio"
        Me.checkDesktop.UseVisualStyleBackColor = True
        '
        'checkGmail
        '
        Me.checkGmail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkGmail.AutoSize = True
        Me.checkGmail.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkGmail.Location = New System.Drawing.Point(343, 204)
        Me.checkGmail.Name = "checkGmail"
        Me.checkGmail.Size = New System.Drawing.Size(73, 24)
        Me.checkGmail.TabIndex = 126
        Me.checkGmail.Text = "Gmail"
        Me.checkGmail.UseVisualStyleBackColor = True
        '
        'checkWhatsapp
        '
        Me.checkWhatsapp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.checkWhatsapp.AutoSize = True
        Me.checkWhatsapp.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkWhatsapp.Location = New System.Drawing.Point(237, 203)
        Me.checkWhatsapp.Name = "checkWhatsapp"
        Me.checkWhatsapp.Size = New System.Drawing.Size(106, 24)
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
        Me.btnGuardarNotificaciones.Cursor = System.Windows.Forms.Cursors.Hand
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
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
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
        Me.comboUsuariosANotificar.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboUsuariosANotificar.FormattingEnabled = True
        Me.comboUsuariosANotificar.Items.AddRange(New Object() {"Todos"})
        Me.comboUsuariosANotificar.Location = New System.Drawing.Point(239, 130)
        Me.comboUsuariosANotificar.Name = "comboUsuariosANotificar"
        Me.comboUsuariosANotificar.Size = New System.Drawing.Size(221, 29)
        Me.comboUsuariosANotificar.TabIndex = 121
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(205, 20)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "Silenciar notificaciones por"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(77, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 20)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Usuarios a notificar"
        '
        'GestionMensajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1159, 683)
        Me.Controls.Add(Me.PanelDataMensajes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelEditarNotificaciones)
        Me.Name = "GestionMensajes"
        Me.Text = "GestionMensajes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelDataMensajes.ResumeLayout(False)
        CType(Me.dgvDataMensajes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEditarNotificaciones.ResumeLayout(False)
        Me.PanelEditarNotificaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents labelCantidadEventos As Label
    Friend WithEvents PanelDataMensajes As Panel
    Friend WithEvents dgvDataMensajes As DataGridView
    Friend WithEvents PanelEditarNotificaciones As Panel
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
