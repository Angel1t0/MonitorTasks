<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEventosCompartidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEventosCompartidos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgvDataEventosCompartidos = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDataEventosCompartidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Eli
        '
        Me.Eli.HeaderText = ""
        Me.Eli.Image = CType(resources.GetObject("Eli.Image"), System.Drawing.Image)
        Me.Eli.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Eli.MinimumWidth = 6
        Me.Eli.Name = "Eli"
        Me.Eli.ReadOnly = True
        Me.Eli.Width = 6
        '
        'dgvDataEventosCompartidos
        '
        Me.dgvDataEventosCompartidos.AllowUserToAddRows = False
        Me.dgvDataEventosCompartidos.AllowUserToDeleteRows = False
        Me.dgvDataEventosCompartidos.AllowUserToResizeRows = False
        Me.dgvDataEventosCompartidos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvDataEventosCompartidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataEventosCompartidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataEventosCompartidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataEventosCompartidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataEventosCompartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataEventosCompartidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataEventosCompartidos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataEventosCompartidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataEventosCompartidos.Location = New System.Drawing.Point(0, 0)
        Me.dgvDataEventosCompartidos.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataEventosCompartidos.Name = "dgvDataEventosCompartidos"
        Me.dgvDataEventosCompartidos.ReadOnly = True
        Me.dgvDataEventosCompartidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataEventosCompartidos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDataEventosCompartidos.RowHeadersVisible = False
        Me.dgvDataEventosCompartidos.RowHeadersWidth = 51
        Me.dgvDataEventosCompartidos.RowTemplate.Height = 40
        Me.dgvDataEventosCompartidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataEventosCompartidos.Size = New System.Drawing.Size(1141, 548)
        Me.dgvDataEventosCompartidos.TabIndex = 102
        '
        'GestionEventosCompartidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 548)
        Me.Controls.Add(Me.dgvDataEventosCompartidos)
        Me.Name = "GestionEventosCompartidos"
        Me.Text = "GestionEventosCompartidos"
        CType(Me.dgvDataEventosCompartidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Eli As DataGridViewImageColumn
    Friend WithEvents dgvDataEventosCompartidos As DataGridView
End Class
