<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionComentarios
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
        Me.btnComentar = New FontAwesome.Sharp.IconButton()
        Me.txtComentario = New SistemasVentas.ControlTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefrescarComentarios = New FontAwesome.Sharp.IconButton()
        Me.rtbComentarios = New System.Windows.Forms.RichTextBox()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnComentar
        '
        Me.btnComentar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnComentar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnComentar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnComentar.FlatAppearance.BorderSize = 0
        Me.btnComentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComentar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComentar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnComentar.IconChar = FontAwesome.Sharp.IconChar.None
        Me.btnComentar.IconColor = System.Drawing.Color.Black
        Me.btnComentar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnComentar.IconSize = 16
        Me.btnComentar.Location = New System.Drawing.Point(534, 316)
        Me.btnComentar.Name = "btnComentar"
        Me.btnComentar.Size = New System.Drawing.Size(143, 42)
        Me.btnComentar.TabIndex = 142
        Me.btnComentar.Text = "Comentar"
        Me.btnComentar.UseVisualStyleBackColor = False
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtComentario.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.txtComentario.BorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtComentario.BorderFocusColor = System.Drawing.Color.Black
        Me.txtComentario.BorderRadius = 8
        Me.txtComentario.BorderSize = 1
        Me.txtComentario.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.Location = New System.Drawing.Point(447, 158)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Padding = New System.Windows.Forms.Padding(7)
        Me.txtComentario.PasswordChar = False
        Me.txtComentario.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtComentario.PlaceholderText = ""
        Me.txtComentario.Size = New System.Drawing.Size(290, 83)
        Me.txtComentario.TabIndex = 143
        Me.txtComentario.Texts = ""
        Me.txtComentario.UnderlinedStyle = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(594, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 16)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Agregar Comentario"
        '
        'btnRefrescarComentarios
        '
        Me.btnRefrescarComentarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRefrescarComentarios.BackColor = System.Drawing.Color.Transparent
        Me.btnRefrescarComentarios.Font = New System.Drawing.Font("Century Gothic", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefrescarComentarios.IconChar = FontAwesome.Sharp.IconChar.Retweet
        Me.btnRefrescarComentarios.IconColor = System.Drawing.Color.Black
        Me.btnRefrescarComentarios.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnRefrescarComentarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefrescarComentarios.Location = New System.Drawing.Point(412, 12)
        Me.btnRefrescarComentarios.Name = "btnRefrescarComentarios"
        Me.btnRefrescarComentarios.Size = New System.Drawing.Size(92, 61)
        Me.btnRefrescarComentarios.TabIndex = 145
        Me.btnRefrescarComentarios.Text = "Refrescar"
        Me.btnRefrescarComentarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefrescarComentarios.UseVisualStyleBackColor = False
        '
        'rtbComentarios
        '
        Me.rtbComentarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rtbComentarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.rtbComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbComentarios.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbComentarios.Location = New System.Drawing.Point(53, 12)
        Me.rtbComentarios.Name = "rtbComentarios"
        Me.rtbComentarios.ReadOnly = True
        Me.rtbComentarios.Size = New System.Drawing.Size(353, 426)
        Me.rtbComentarios.TabIndex = 146
        Me.rtbComentarios.Text = ""
        '
        'cbUsuarios
        '
        Me.cbUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(447, 247)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(290, 24)
        Me.cbUsuarios.TabIndex = 147
        '
        'GestionComentarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cbUsuarios)
        Me.Controls.Add(Me.rtbComentarios)
        Me.Controls.Add(Me.btnRefrescarComentarios)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.btnComentar)
        Me.Name = "GestionComentarios"
        Me.Text = "GestionComentarios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnComentar As FontAwesome.Sharp.IconButton
    Friend WithEvents txtComentario As ControlTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRefrescarComentarios As FontAwesome.Sharp.IconButton
    Friend WithEvents rtbComentarios As RichTextBox
    Friend WithEvents cbUsuarios As ComboBox
End Class
