Imports System.Data.SqlClient
Public Class FormularioGestionUsuarios
    Private rutaArchivo As String
    Private usuarioData As New UsuarioData()
    Private controlador As New ControladorEvento()

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

    ' --- Operaciones CRUD ---
    Private Sub MostrarUsuarios()
        dgvDataUsuario.DataSource = usuarioData.MostrarUsuarios()
        EstilizarTabla()
    End Sub

    Private Sub GuardarUsuario()
        If Not ValidarEntradasUsuario(txtName.Text, txtUser.Text, txtPass.Text, txtEmail.Text, txtTelefono.Text, comboRol.SelectedItem.ToString()) Then
            Return
        End If

        Dim tupleUserIDyProfileID = ObtenerUserIDyProfileID()
        If tupleUserIDyProfileID.Item1 = 0 Then
            MessageBox.Show("Revisar Sintaxis y existencia de Correo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim usuario As New Usuario With {
            .NombreApellidos = txtName.Text,
            .Login = txtUser.Text,
            .Pass = txtPass.Text,
            .Correo = txtEmail.Text,
            .Telefono = txtTelefono.Text,
            .Estado = "Activo",
            .Rol = comboRol.SelectedItem.ToString(),
            .PodioUserID = tupleUserIDyProfileID.Item1,
            .PodioProfileID = tupleUserIDyProfileID.Item2
        }

        If comboJefe.SelectedIndex = -1 Then
            usuario.JefeDirectoID = Nothing
        Else
            If comboJefe.SelectedItem.ToString() = "Soy Jefe de Departamento" Then
                usuario.JefeDirectoID = 0
            Else
                usuario.JefeDirectoID = usuarioData.BuscarUserIDPorCorreo(comboJefe.SelectedItem.ToString())
            End If
        End If

        usuarioData.InsertarUsuario(usuario)

        MostrarUsuarios()
        OcultarPanelUsuario()
    End Sub

    Private Sub ActualizarUsuario()
        If Not ValidarEntradasUsuario(txtName.Text, txtUser.Text, txtPass.Text, txtEmail.Text, txtTelefono.Text, comboJefe.SelectedItem.ToString()) Then
            Return
        End If

        Dim tupleUserIDyProfileID = ObtenerUserIDyProfileID()
        If tupleUserIDyProfileID.Item1 = 0 Then
            MessageBox.Show("Revisar Sintaxis y existencia de Correo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim usuario As New Usuario With {
            .IdUsuario = dgvDataUsuario.SelectedCells.Item(1).Value,
            .NombreApellidos = txtName.Text,
            .Login = txtUser.Text,
            .Pass = txtPass.Text,
            .Correo = txtEmail.Text,
            .Telefono = txtTelefono.Text,
            .Estado = "Activo",
            .Rol = comboRol.SelectedItem.ToString(),
            .PodioUserID = tupleUserIDyProfileID.Item1,
            .PodioProfileID = tupleUserIDyProfileID.Item2
        }
        If comboJefe.SelectedIndex = -1 Or comboJefe.SelectedItem.ToString() = "Soy Jefe de Departamento" Then
            usuario.JefeDirectoID = 0
        Else
            usuario.JefeDirectoID = usuarioData.BuscarUserIDPorCorreo(comboJefe.SelectedItem.ToString())
        End If

        usuarioData.ActualizarUsuario(usuario)

        OcultarPanelUsuario()
        MostrarUsuarios()
    End Sub

    Private Sub EliminarUsuario()
        Dim advertencia As DialogResult
        advertencia = MessageBox.Show("¿Estás seguro de eliminar a " & dgvDataUsuario.SelectedCells.Item(2).Value & "?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        Dim idUsuario = dgvDataUsuario.SelectedCells.Item(1).Value
        If advertencia = DialogResult.OK Then
            usuarioData.EliminarUsuario(idUsuario)
            MostrarUsuarios()
        End If
    End Sub

    ' --- Utilidades ---
    Private Sub PrepararActualizarUsuario()
        Try
            comboJefe.Items.Clear()
            txtPass.Enabled = True
            txtName.Text = dgvDataUsuario.SelectedCells.Item(2).Value
            txtUser.Text = dgvDataUsuario.SelectedCells.Item(3).Value
            txtPass.Text = dgvDataUsuario.SelectedCells.Item(4).Value
            txtEmail.Text = dgvDataUsuario.SelectedCells.Item(5).Value
            txtTelefono.Text = dgvDataUsuario.SelectedCells.Item(6).Value
            comboRol.SelectedItem = dgvDataUsuario.SelectedCells.Item(8).Value

            ' Agregar correos de jefe a comboBox
            comboJefe.Items.Add("Soy Jefe de Departamento")
            For Each correo As String In usuarioData.ObtenerCorreosJefes()
                comboJefe.Items.Add(correo)
            Next

            ' Seleccionar al jefe del usuario si existe
            If dgvDataUsuario.SelectedCells.Item(9).Value = 0 Then
                If comboRol.SelectedItem.ToString() = "Administrador" Then
                    comboJefe.SelectedItem = "Soy Jefe de Departamento"
                Else
                    comboJefe.SelectedIndex = -1
                End If
            Else
                    comboJefe.SelectedItem = (usuarioData.BuscarCorreoPorUserID(dgvDataUsuario.SelectedCells.Item(9).Value))
            End If


            btnGuardar.Visible = False
            btnActualizar.Visible = True
            Panel4.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrepararNuevoUsuario()
        ' Limpiar los campos y mostrar el panel
        comboJefe.Items.Clear()
        txtName.Text = ""
        txtUser.Text = ""
        txtPass.Text = ""
        txtEmail.Text = ""
        txtTelefono.Text = ""
        comboRol.Text = ""
        comboRol.SelectedIndex = 0

        ' Agregar correos de jefe a comboBox
        comboJefe.Items.Add("Soy Jefe de Departamento")
        For Each correo As String In usuarioData.ObtenerCorreosJefes()
            comboJefe.Items.Add(correo)
        Next

        btnActualizar.Visible = False
        btnGuardar.Visible = True
        Panel4.Visible = True
    End Sub

    Private Sub OcultarPanelUsuario()
        Panel4.Visible = False
    End Sub

    Private Sub EstilizarTabla()
        ' Agregamos un tamaño a las columnas y ocultamos las que no se deben mostrar
        Try
            dgvDataUsuario.Columns(0).Width = 40
            dgvDataUsuario.Columns(2).Width = 200
            dgvDataUsuario.Columns(5).Width = 150
            dgvDataUsuario.Columns(6).Width = 100
            dgvDataUsuario.Columns(1).Visible = False
            dgvDataUsuario.Columns(3).Visible = False
            dgvDataUsuario.Columns(4).Visible = False
            dgvDataUsuario.Columns(7).Visible = False

            ' Establecemos un estilo para las cabeceras
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

    Private Sub LimpiarCombos()
        comboJefe.Items.Clear()
        comboJefe.SelectedIndex = -1
    End Sub

    Private Sub comboRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboRol.SelectedIndexChanged
        If comboRol.SelectedItem.ToString() = "Jefe de Departamento" Then
            comboJefe.Enabled = False
            comboJefe.SelectedIndex = -1
            Label8.Enabled = False
        Else
            comboJefe.Enabled = True
            Label8.Enabled = True
        End If
    End Sub

    Private Function ObtenerUserIDyProfileID() As Tuple(Of Long, Long)
        Dim userID As Long = 0
        Dim profileID As Long = 0
        Try
            Dim tuple = controlador.ObtenerProfileIDyUserID(txtEmail.Text)
            userID = tuple.Result.Item1
            profileID = tuple.Result.Item2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tuple.Create(userID, profileID)
    End Function
End Class