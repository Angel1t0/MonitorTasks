<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionMensajes
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionMensajes))
        Me.PanelMensajes = New System.Windows.Forms.Panel()
        Me.PanelTablaMensajes = New System.Windows.Forms.Panel()
        Me.dgvDataMensajes = New System.Windows.Forms.DataGridView()
        Me.Eli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelMensajes.SuspendLayout()
        Me.PanelTablaMensajes.SuspendLayout()
        CType(Me.dgvDataMensajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMensajes
        '
        Me.PanelMensajes.Controls.Add(Me.PanelTablaMensajes)
        Me.PanelMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMensajes.Location = New System.Drawing.Point(0, 0)
        Me.PanelMensajes.Name = "PanelMensajes"
        Me.PanelMensajes.Size = New System.Drawing.Size(1159, 683)
        Me.PanelMensajes.TabIndex = 0
        '
        'PanelTablaMensajes
        '
        Me.PanelTablaMensajes.Controls.Add(Me.dgvDataMensajes)
        Me.PanelTablaMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTablaMensajes.Location = New System.Drawing.Point(0, 0)
        Me.PanelTablaMensajes.Name = "PanelTablaMensajes"
        Me.PanelTablaMensajes.Padding = New System.Windows.Forms.Padding(10)
        Me.PanelTablaMensajes.Size = New System.Drawing.Size(1159, 683)
        Me.PanelTablaMensajes.TabIndex = 107
        '
        'dgvDataMensajes
        '
        Me.dgvDataMensajes.AllowUserToAddRows = False
        Me.dgvDataMensajes.AllowUserToDeleteRows = False
        Me.dgvDataMensajes.AllowUserToResizeRows = False
        Me.dgvDataMensajes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvDataMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataMensajes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataMensajes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataMensajes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataMensajes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eli})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataMensajes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataMensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDataMensajes.Location = New System.Drawing.Point(10, 10)
        Me.dgvDataMensajes.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvDataMensajes.Name = "dgvDataMensajes"
        Me.dgvDataMensajes.ReadOnly = True
        Me.dgvDataMensajes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataMensajes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDataMensajes.RowHeadersVisible = False
        Me.dgvDataMensajes.RowHeadersWidth = 51
        Me.dgvDataMensajes.RowTemplate.Height = 30
        Me.dgvDataMensajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataMensajes.Size = New System.Drawing.Size(1139, 663)
        Me.dgvDataMensajes.TabIndex = 101
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
        'GestionMensajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 683)
        Me.Controls.Add(Me.PanelMensajes)
        Me.Name = "GestionMensajes"
        Me.Text = "GestionMensajes"
        Me.PanelMensajes.ResumeLayout(False)
        Me.PanelTablaMensajes.ResumeLayout(False)
        CType(Me.dgvDataMensajes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMensajes As Panel
    Friend WithEvents PanelTablaMensajes As Panel
    Friend WithEvents dgvDataMensajes As DataGridView
    Friend WithEvents Eli As DataGridViewImageColumn
End Class
