<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AcomodarFormularios
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
        Me.PanelAsistentes = New MonitorTasks.ControlPanel()
        Me.btnAgregarAsistentes = New FontAwesome.Sharp.IconButton()
        Me.btnContinuar = New FontAwesome.Sharp.IconButton()
        Me.btnEliminarAsistentes = New FontAwesome.Sharp.IconPictureBox()
        Me.comboListaInvitados = New System.Windows.Forms.ComboBox()
        Me.labelAsistente = New System.Windows.Forms.Label()
        Me.comboInvitados = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnVolverEvento = New FontAwesome.Sharp.IconPictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.PanelAsistentes.SuspendLayout()
        CType(Me.btnEliminarAsistentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.btnVolverEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelAsistentes
        '
        Me.PanelAsistentes.BackColor = System.Drawing.Color.White
        Me.PanelAsistentes.BorderRadius = 12
        Me.PanelAsistentes.Controls.Add(Me.btnAgregarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.btnContinuar)
        Me.PanelAsistentes.Controls.Add(Me.btnEliminarAsistentes)
        Me.PanelAsistentes.Controls.Add(Me.comboListaInvitados)
        Me.PanelAsistentes.Controls.Add(Me.labelAsistente)
        Me.PanelAsistentes.Controls.Add(Me.comboInvitados)
        Me.PanelAsistentes.Controls.Add(Me.Panel4)
        Me.PanelAsistentes.Controls.Add(Me.Label34)
        Me.PanelAsistentes.Controls.Add(Me.Label35)
        Me.PanelAsistentes.Controls.Add(Me.Label36)
        Me.PanelAsistentes.Location = New System.Drawing.Point(664, 336)
        Me.PanelAsistentes.Name = "PanelAsistentes"
        Me.PanelAsistentes.Size = New System.Drawing.Size(424, 356)
        Me.PanelAsistentes.TabIndex = 125
        '
        'btnAgregarAsistentes
        '
        Me.btnAgregarAsistentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnAgregarAsistentes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarAsistentes.FlatAppearance.BorderSize = 0
        Me.btnAgregarAsistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAsistentes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAsistentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnAgregarAsistentes.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnAgregarAsistentes.IconColor = System.Drawing.Color.Black
        Me.btnAgregarAsistentes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnAgregarAsistentes.IconSize = 16
        Me.btnAgregarAsistentes.Location = New System.Drawing.Point(128, 211)
        Me.btnAgregarAsistentes.Name = "btnAgregarAsistentes"
        Me.btnAgregarAsistentes.Size = New System.Drawing.Size(163, 40)
        Me.btnAgregarAsistentes.TabIndex = 121
        Me.btnAgregarAsistentes.Text = "Agregar Asistente"
        Me.btnAgregarAsistentes.UseVisualStyleBackColor = False
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
        Me.btnContinuar.Location = New System.Drawing.Point(128, 292)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(163, 42)
        Me.btnContinuar.TabIndex = 114
        Me.btnContinuar.Text = "Continuar/Omitir"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'btnEliminarAsistentes
        '
        Me.btnEliminarAsistentes.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsistentes.ForeColor = System.Drawing.Color.Red
        Me.btnEliminarAsistentes.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnEliminarAsistentes.IconColor = System.Drawing.Color.Red
        Me.btnEliminarAsistentes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnEliminarAsistentes.Location = New System.Drawing.Point(300, 159)
        Me.btnEliminarAsistentes.Name = "btnEliminarAsistentes"
        Me.btnEliminarAsistentes.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarAsistentes.TabIndex = 120
        Me.btnEliminarAsistentes.TabStop = False
        '
        'comboListaInvitados
        '
        Me.comboListaInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboListaInvitados.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboListaInvitados.FormattingEnabled = True
        Me.comboListaInvitados.Location = New System.Drawing.Point(113, 159)
        Me.comboListaInvitados.Name = "comboListaInvitados"
        Me.comboListaInvitados.Size = New System.Drawing.Size(178, 29)
        Me.comboListaInvitados.TabIndex = 119
        '
        'labelAsistente
        '
        Me.labelAsistente.AutoSize = True
        Me.labelAsistente.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAsistente.Location = New System.Drawing.Point(259, 109)
        Me.labelAsistente.Name = "labelAsistente"
        Me.labelAsistente.Size = New System.Drawing.Size(119, 21)
        Me.labelAsistente.TabIndex = 118
        Me.labelAsistente.Text = "DisplayName"
        '
        'comboInvitados
        '
        Me.comboInvitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboInvitados.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboInvitados.FormattingEnabled = True
        Me.comboInvitados.Location = New System.Drawing.Point(32, 106)
        Me.comboInvitados.Name = "comboInvitados"
        Me.comboInvitados.Size = New System.Drawing.Size(179, 29)
        Me.comboInvitados.TabIndex = 117
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnVolverEvento)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 50)
        Me.Panel4.TabIndex = 0
        '
        'btnVolverEvento
        '
        Me.btnVolverEvento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVolverEvento.BackColor = System.Drawing.Color.White
        Me.btnVolverEvento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolverEvento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverEvento.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.btnVolverEvento.IconColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.btnVolverEvento.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVolverEvento.IconSize = 35
        Me.btnVolverEvento.Location = New System.Drawing.Point(354, 9)
        Me.btnVolverEvento.Name = "btnVolverEvento"
        Me.btnVolverEvento.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverEvento.TabIndex = 1
        Me.btnVolverEvento.TabStop = False
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
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(28, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 19)
        Me.Label34.TabIndex = 84
        Me.Label34.Text = "Email"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(260, 69)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(154, 19)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "Nombre Asistente"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(28, 163)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(83, 19)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Invitados"
        '
        'AcomodarFormularios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1752, 1028)
        Me.Controls.Add(Me.PanelAsistentes)
        Me.Name = "AcomodarFormularios"
        Me.Text = "AcomodarFormularios"
        Me.PanelAsistentes.ResumeLayout(False)
        Me.PanelAsistentes.PerformLayout()
        CType(Me.btnEliminarAsistentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.btnVolverEvento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelAsistentes As ControlPanel
    Friend WithEvents btnAgregarAsistentes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnContinuar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEliminarAsistentes As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents comboListaInvitados As ComboBox
    Friend WithEvents labelAsistente As Label
    Friend WithEvents comboInvitados As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnVolverEvento As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
End Class
