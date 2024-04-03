<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioSeleccionarCalendario
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
        Me.panelCalendarios = New System.Windows.Forms.Panel()
        Me.PanelTitulo = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New FontAwesome.Sharp.IconPictureBox()
        Me.BtnMaximizar = New FontAwesome.Sharp.IconPictureBox()
        Me.BtnMinimizar = New FontAwesome.Sharp.IconPictureBox()
        Me.BtnSeleccionarCalendario = New System.Windows.Forms.Button()
        Me.ComboCalendario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.panelCalendarios.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMaximizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMinimizar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelCalendarios
        '
        Me.panelCalendarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.panelCalendarios.Controls.Add(Me.btnSincronizar)
        Me.panelCalendarios.Controls.Add(Me.PanelTitulo)
        Me.panelCalendarios.Controls.Add(Me.BtnSeleccionarCalendario)
        Me.panelCalendarios.Controls.Add(Me.ComboCalendario)
        Me.panelCalendarios.Controls.Add(Me.Label1)
        Me.panelCalendarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCalendarios.Location = New System.Drawing.Point(0, 0)
        Me.panelCalendarios.Name = "panelCalendarios"
        Me.panelCalendarios.Size = New System.Drawing.Size(466, 450)
        Me.panelCalendarios.TabIndex = 93
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.PanelTitulo.Controls.Add(Me.BtnCerrar)
        Me.PanelTitulo.Controls.Add(Me.BtnMaximizar)
        Me.PanelTitulo.Controls.Add(Me.BtnMinimizar)
        Me.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(466, 46)
        Me.PanelTitulo.TabIndex = 46
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnCerrar.IconChar = FontAwesome.Sharp.IconChar.TimesRectangle
        Me.BtnCerrar.IconColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnCerrar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.BtnCerrar.IconSize = 30
        Me.BtnCerrar.Location = New System.Drawing.Point(420, 8)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(30, 30)
        Me.BtnCerrar.TabIndex = 7
        Me.BtnCerrar.TabStop = False
        '
        'BtnMaximizar
        '
        Me.BtnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMaximizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnMaximizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.BtnMaximizar.IconColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMaximizar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.BtnMaximizar.IconSize = 30
        Me.BtnMaximizar.Location = New System.Drawing.Point(370, 8)
        Me.BtnMaximizar.Name = "BtnMaximizar"
        Me.BtnMaximizar.Size = New System.Drawing.Size(30, 30)
        Me.BtnMaximizar.TabIndex = 6
        Me.BtnMaximizar.TabStop = False
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMinimizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnMinimizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.BtnMinimizar.IconColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnMinimizar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.BtnMinimizar.IconSize = 30
        Me.BtnMinimizar.Location = New System.Drawing.Point(319, 8)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Size = New System.Drawing.Size(30, 30)
        Me.BtnMinimizar.TabIndex = 5
        Me.BtnMinimizar.TabStop = False
        '
        'BtnSeleccionarCalendario
        '
        Me.BtnSeleccionarCalendario.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnSeleccionarCalendario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSeleccionarCalendario.FlatAppearance.BorderSize = 0
        Me.BtnSeleccionarCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSeleccionarCalendario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnSeleccionarCalendario.Location = New System.Drawing.Point(177, 263)
        Me.BtnSeleccionarCalendario.Name = "BtnSeleccionarCalendario"
        Me.BtnSeleccionarCalendario.Size = New System.Drawing.Size(113, 55)
        Me.BtnSeleccionarCalendario.TabIndex = 45
        Me.BtnSeleccionarCalendario.Text = "Seleccionar"
        Me.BtnSeleccionarCalendario.UseVisualStyleBackColor = False
        '
        'ComboCalendario
        '
        Me.ComboCalendario.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ComboCalendario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCalendario.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCalendario.FormattingEnabled = True
        Me.ComboCalendario.Location = New System.Drawing.Point(54, 189)
        Me.ComboCalendario.Name = "ComboCalendario"
        Me.ComboCalendario.Size = New System.Drawing.Size(277, 31)
        Me.ComboCalendario.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar Calendario"
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSincronizar.BackColor = System.Drawing.Color.Transparent
        Me.btnSincronizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSincronizar.FlatAppearance.BorderSize = 0
        Me.btnSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSincronizar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnSincronizar.Location = New System.Drawing.Point(337, 173)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(113, 55)
        Me.btnSincronizar.TabIndex = 104
        Me.btnSincronizar.Text = "Sincronizar de Calendar"
        Me.btnSincronizar.UseVisualStyleBackColor = False
        '
        'FormularioSeleccionarCalendario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 450)
        Me.Controls.Add(Me.panelCalendarios)
        Me.Name = "FormularioSeleccionarCalendario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormularioSeleccionarCalendario"
        Me.panelCalendarios.ResumeLayout(False)
        Me.panelCalendarios.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMaximizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMinimizar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelCalendarios As Panel
    Friend WithEvents BtnSeleccionarCalendario As Button
    Friend WithEvents ComboCalendario As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents BtnCerrar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents BtnMaximizar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents BtnMinimizar As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents btnSincronizar As Button
End Class
