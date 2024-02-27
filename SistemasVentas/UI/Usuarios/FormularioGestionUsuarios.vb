Imports System.Data.SqlClient
Public Class FormularioGestionUsuarios
    Private rutaArchivo As String

    ' --- Manejadores de Eventos de UI ---
    Private Sub FormularioGestionUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OcultarPanelUsuario()
        MostrarUsuarios()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        OcultarPanelUsuario()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarUsuario()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ActualizarUsuario()
    End Sub

    Private Sub dgvDataUsuario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataUsuario.CellDoubleClick
        PrepararActualizarUsuario()
    End Sub

    Private Sub dgvDataUsuario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataUsuario.CellClick
        If Not e.ColumnIndex = dgvDataUsuario.Columns.Item("Eli").Index Then
            Return
        End If
        EliminarUsuario()
    End Sub

    Private Sub pbInsertarUsuario_Click(sender As Object, e As EventArgs) Handles pbInsertarUsuario.Click
        PrepararNuevoUsuario()
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        BuscarUsuario()
    End Sub

    Private Sub lbIcono_Click(sender As Object, e As EventArgs) Handles lbIcono.Click
        SeleccionarImagen()
    End Sub

    Private Sub pbIcon_Click(sender As Object, e As EventArgs) Handles pbIcon.Click
        SeleccionarImagen()
    End Sub

    ' --- Operaciones CRUD ---
    Private Sub MostrarUsuarios()
        Dim usuarioData As New UsuarioData()
        dgvDataUsuario.DataSource = usuarioData.MostrarUsuarios()
        EstilizarTabla()
    End Sub

    Private Sub GuardarUsuario()
        If Not ValidarEntradasUsuario(txtName.Text, txtUser.Text, txtPass.Text, txtEmail.Text, cbRol.Text, lbIcono) Then
            Return
        End If

        Dim imagenBytes As Byte() = ConvertirImagenABytes(pbIcon.Image)
        Dim ms As New IO.MemoryStream
        pbIcon.Image.Save(ms, pbIcon.Image.RawFormat)

        Dim usuario As New Usuario With {
            .NombreApellidos = txtName.Text,
            .Login = txtUser.Text,
            .Pass = txtPass.Text,
            .Icono = imagenBytes,
            .NombreIcono = IO.Path.GetFileName(rutaArchivo),
            .Correo = txtEmail.Text,
            .Rol = cbRol.Text,
            .Estado = "Activo"
        }

        Dim usuarioData As New UsuarioData()
        usuarioData.InsertarUsuario(usuario)

        MostrarUsuarios()
        OcultarPanelUsuario()
    End Sub

    Private Sub ActualizarUsuario()
        If Not ValidarEntradasUsuario(txtName.Text, txtUser.Text, txtPass.Text, txtEmail.Text, cbRol.Text, lbIcono) Then
            Return
        End If

        Dim nombreIcono As String = IO.Path.GetFileName(rutaArchivo)
        If nombreIcono Is Nothing Then
            nombreIcono = dgvDataUsuario.SelectedCells.Item(6).Value
        End If

        Dim usuario As New Usuario With {
            .IdUsuario = dgvDataUsuario.SelectedCells.Item(1).Value,
            .NombreApellidos = txtName.Text,
            .Login = txtUser.Text,
            .Pass = txtPass.Text,
            .Icono = ConvertirImagenABytes(pbIcon.Image),
            .NombreIcono = nombreIcono,
            .Correo = txtEmail.Text,
            .Rol = cbRol.Text,
            .Estado = "Activo"
        }

        Dim usuarioData As New UsuarioData()
        usuarioData.ActualizarUsuario(usuario)

        OcultarPanelUsuario()
        MostrarUsuarios()
    End Sub

    Private Sub EliminarUsuario()
        Dim advertencia As DialogResult
        advertencia = MessageBox.Show("¿Estás seguro de eliminar a " & dgvDataUsuario.SelectedCells.Item(2).Value & "?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Dim idUsuario = dgvDataUsuario.SelectedCells.Item(1).Value
        If advertencia = DialogResult.OK Then
            Dim usuarioData As New UsuarioData()
            usuarioData.EliminarUsuario(idUsuario)
            MostrarUsuarios()
        End If
    End Sub

    Private Sub BuscarUsuario()
        Dim usuarioData As New UsuarioData()
        dgvDataUsuario.DataSource = usuarioData.BuscarUsuarios(txtBusca.Text)
    End Sub

    ' --- Utilidades ---
    Private Sub PrepararActualizarUsuario()
        Try
            txtPass.Enabled = True
            txtName.Text = dgvDataUsuario.SelectedCells.Item(2).Value
            txtUser.Text = dgvDataUsuario.SelectedCells.Item(3).Value
            txtPass.Text = dgvDataUsuario.SelectedCells.Item(4).Value
            txtEmail.Text = dgvDataUsuario.SelectedCells.Item(7).Value
            cbRol.Text = dgvDataUsuario.SelectedCells.Item(8).Value


            Dim imagenBytes As Byte() = dgvDataUsuario.SelectedCells.Item(5).Value
            If imagenBytes IsNot Nothing Then
                Using ms As New IO.MemoryStream(imagenBytes)
                    Dim imagen As Image = Image.FromStream(ms)
                    pbIcon.Image = imagen
                    pbIcon.SizeMode = PictureBoxSizeMode.Zoom
                    lbIcono.Visible = False
                End Using
            End If

            btnGuardar.Visible = False
            btnActualizar.Visible = True
            Panel4.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrepararNuevoUsuario()
        txtName.Text = ""
        txtUser.Text = ""
        txtPass.Text = ""
        txtEmail.Text = ""
        cbRol.Text = "Solo Ventas (No Maneja Dinero)"
        lbIcono.Visible = True
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        Panel4.Visible = True
    End Sub

    Private Sub OcultarPanelUsuario()
        Panel4.Visible = False
    End Sub

    'Convertir la imagen del PictureBox del icono a un array de bytes
    Private Function ConvertirImagenABytes(imagen As Image) As Byte()
        Using ms As New IO.MemoryStream()
            imagen.Save(ms, Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub EstilizarTabla()
        Try
            dgvDataUsuario.Columns(0).Width = 40
            dgvDataUsuario.Columns(2).Width = 200
            dgvDataUsuario.Columns(7).Width = 150
            dgvDataUsuario.Columns(1).Visible = False
            dgvDataUsuario.Columns(4).Visible = False
            dgvDataUsuario.Columns(5).Visible = False
            dgvDataUsuario.Columns(6).Visible = False
            dgvDataUsuario.Columns(8).Visible = False

            dgvDataUsuario.EnableHeadersVisualStyles = False
            Dim styleCabeceras As New DataGridViewCellStyle()
            styleCabeceras.BackColor = Color.White
            styleCabeceras.ForeColor = Color.Black
            styleCabeceras.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            dgvDataUsuario.ColumnHeadersDefaultCellStyle = styleCabeceras
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SeleccionarImagen()
        Using OpenFileDialog As New OpenFileDialog()
            ' Configurar filtros y opciones
            OpenFileDialog.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            OpenFileDialog.Title = "Seleccionar Imagen"

            ' Mostrar el cuadro de diálogo
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                ' Aquí obtienes la ruta del archivo seleccionado
                rutaArchivo = OpenFileDialog.FileName

                ' Cargar la imagen seleccionada en un PictureBox (por ejemplo, pbImagenUsuario)
                pbIcon.Image = Image.FromFile(rutaArchivo)
                lbIcono.Visible = False
            End If
        End Using
    End Sub
End Class