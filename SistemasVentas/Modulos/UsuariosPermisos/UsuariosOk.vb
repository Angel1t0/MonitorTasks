Imports System.Data.SqlClient
Public Class UsuariosOk
    Private rutaArchivo As String


    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Panel4.Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not ValidarCorreo(txtEmail.Text) Then
            MessageBox.Show("Error en el formato de correo", "Validación de correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmail.Focus()
            txtEmail.SelectAll()
            Return
        End If

        If txtName.Text = "" OrElse txtUser.Text = "" OrElse txtPass.Text = "" OrElse cbRol.Text = "" Then
            MessageBox.Show("Los campos de texto no pueden estar vacios", "Campos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtPass.Text.Count() <= 5 Then
            MessageBox.Show("La contraseña debe ser igual o mayor a 6 caracteres", "Cantidad de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPass.Focus()
            Return
        End If

        If lbIcono.Visible = True Then
            MessageBox.Show("Elije un icono", "Icono", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim imagenBytes As Byte() = ConvertirImagenABytes(pbIcon.Image)
            Dim nombreIcono As String = IO.Path.GetFileName(rutaArchivo)
            Using sqlConexion As SqlConnection = ObtenerConexion()
                sqlConexion.Open()
                Using sqlComando As New SqlCommand("insertarUsuario", sqlConexion)
                    sqlComando.CommandType = CommandType.StoredProcedure
                    sqlComando.Parameters.AddWithValue("@NombreApellidos", txtName.Text)
                    sqlComando.Parameters.AddWithValue("@Login", txtUser.Text)
                    sqlComando.Parameters.AddWithValue("@Pass", txtPass.Text)

                    Dim ms As New IO.MemoryStream
                    pbIcon.Image.Save(ms, pbIcon.Image.RawFormat)
                    sqlComando.Parameters.AddWithValue("@Icono", imagenBytes)

                    sqlComando.Parameters.AddWithValue("@NombreIcono", nombreIcono)
                    sqlComando.Parameters.AddWithValue("@Correo", txtEmail.Text)
                    sqlComando.Parameters.AddWithValue("@Rol", cbRol.Text)
                    sqlComando.Parameters.AddWithValue("@Estado", "Activo")

                    sqlComando.ExecuteNonQuery()
                    MostrarDatos()
                    Panel4.Visible = False
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Convertir la imagen del PictureBox a un array de bytes
    Private Function ConvertirImagenABytes(imagen As Image) As Byte()
        Using ms As New IO.MemoryStream()
            imagen.Save(ms, Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Public Sub MostrarDatos()
        Try
            Using sqlConexion As SqlConnection = ObtenerConexion()
                sqlConexion.Open()
                Using sqlComando As New SqlCommand("Select IdUsuario As 'ID', NombreApellidos AS 'Nombre y Apellidos', Login AS 'Usuario', Pass AS 'Contraseña', Icono, NombreIcono AS 'Nombre Icono', Correo, Rol, Estado FROM Usuario2", sqlConexion)

                    Dim dataTable As New DataTable()
                    Dim sqlAdaptador As New SqlDataAdapter(sqlComando)

                    sqlAdaptador.Fill(dataTable)
                    dgvData.DataSource = dataTable
                End Using
            End Using
            EstilizarTabla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub EstilizarTabla()
        Try
            dgvData.Columns(0).Width = 40
            dgvData.Columns(2).Width = 150
            dgvData.Columns(1).Visible = False
            dgvData.Columns(4).Visible = False
            dgvData.Columns(5).Visible = False
            dgvData.Columns(6).Visible = False
            dgvData.Columns(7).Visible = False
            dgvData.Columns(8).Visible = False

            dgvData.EnableHeadersVisualStyles = False
            Dim styleCabeceras As New DataGridViewCellStyle()
            styleCabeceras.BackColor = Color.White
            styleCabeceras.ForeColor = Color.Black
            styleCabeceras.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            dgvData.ColumnHeadersDefaultCellStyle = styleCabeceras
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lbIcono_Click(sender As Object, e As EventArgs) Handles lbIcono.Click
        SeleccionarImagen()
    End Sub

    Private Sub pbIcon_Click(sender As Object, e As EventArgs) Handles pbIcon.Click
        SeleccionarImagen()
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

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtName.Text = "" And cbRol.Text = "" Then
            MessageBox.Show("Los campos de texto no pueden estar vacios", "Campos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim imagenBytes As Byte() = ConvertirImagenABytes(pbIcon.Image)
            Dim nombreIcono As String = IO.Path.GetFileName(rutaArchivo)
            Dim ms As New IO.MemoryStream
            If nombreIcono Is Nothing Then
                nombreIcono = dgvData.SelectedCells.Item(6).Value
            End If
            pbIcon.Image.Save(ms, pbIcon.Image.RawFormat)
            Using sqlConexion As SqlConnection = ObtenerConexion()
                sqlConexion.Open()
                Using sqlComando As New SqlCommand("editarUsuario", sqlConexion)
                    sqlComando.CommandType = CommandType.StoredProcedure
                    sqlComando.Parameters.AddWithValue("@IdUsuario", dgvData.SelectedCells.Item(1).Value)
                    sqlComando.Parameters.AddWithValue("@NombreApellidos", txtName.Text)
                    sqlComando.Parameters.AddWithValue("@Login", txtUser.Text)
                    sqlComando.Parameters.AddWithValue("@Pass", txtPass.Text)

                    sqlComando.Parameters.AddWithValue("@Icono", imagenBytes)

                    sqlComando.Parameters.AddWithValue("@NombreIcono", nombreIcono)
                    sqlComando.Parameters.AddWithValue("@Correo", txtEmail.Text)
                    sqlComando.Parameters.AddWithValue("@Rol", cbRol.Text)
                    sqlComando.Parameters.AddWithValue("@Estado", "Activo")
                    sqlComando.ExecuteNonQuery()
                    Panel4.Visible = False
                    MostrarDatos()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        Try
            txtPass.Enabled = True
            txtName.Text = dgvData.SelectedCells.Item(2).Value
            txtUser.Text = dgvData.SelectedCells.Item(3).Value
            txtPass.Text = dgvData.SelectedCells.Item(4).Value
            txtEmail.Text = dgvData.SelectedCells.Item(7).Value
            cbRol.Text = dgvData.SelectedCells.Item(8).Value


            If txtUser.Text = "admin" Then
                txtUser.Enabled = False
                cbRol.Enabled = False
            End If

            Dim imagenBytes As Byte() = dgvData.SelectedCells.Item(5).Value
            If imagenBytes IsNot Nothing Then
                Using ms As New IO.MemoryStream(imagenBytes)
                    Dim imagen As Image = Image.FromStream(ms)
                    pbIcon.Image = imagen
                    pbIcon.SizeMode = PictureBoxSizeMode.Zoom
                    lbIcono.Visible = False
                End Using
            Else
                pbIcon.Image = Nothing
                lbIcono.Visible = True
            End If

            btnGuardar.Visible = False
            btnActualizar.Visible = True
            Panel4.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureInsertar_Click(sender As Object, e As EventArgs) Handles PictureInsertar.Click
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

    Private Sub UsuariosOk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        btnGuardar.Visible = True
        btnActualizar.Visible = False
        MostrarDatos()
    End Sub

    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        Try
            Using sqlConexion As SqlConnection = ObtenerConexion()
                sqlConexion.Open()
                Using sqlComando As New SqlCommand("buscarUsuarios", sqlConexion)
                    sqlComando.CommandType = CommandType.StoredProcedure
                    sqlComando.Parameters.AddWithValue("@textoIngresado", txtBusca.Text)
                    Dim dataTable As New DataTable()
                    Dim sqlAdaptador As New SqlDataAdapter(sqlComando)

                    sqlAdaptador.Fill(dataTable)
                    dgvData.DataSource = dataTable
                End Using
            End Using
            EstilizarTabla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellClick
        If e.ColumnIndex = dgvData.Columns.Item("Eli").Index Then
            Dim advertencia As DialogResult
            advertencia = MessageBox.Show("¿Estás seguro de eliminar a " & dgvData.SelectedCells.Item(2).Value & "?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            Dim idUsuario = dgvData.SelectedCells.Item(1).Value
            If advertencia = DialogResult.OK Then
                Try
                    Using sqlConexion As SqlConnection = ObtenerConexion()
                        sqlConexion.Open()
                        Using sqlComando As New SqlCommand("eliminarUsuario", sqlConexion)
                            sqlComando.CommandType = CommandType.StoredProcedure
                            sqlComando.Parameters.AddWithValue("@IdUsuario", idUsuario)
                            sqlComando.ExecuteNonQuery()
                            MostrarDatos()
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
End Class