Imports System.Data.SqlClient
Public Class UsuarioData
    Public Sub InsertarUsuario(usuario As Usuario)
        Try
            Using conexion As SqlConnection = CadenaConexion.CrearConexionSQL()
                Dim comando As New SqlCommand("insertarUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                ' Aquí asignamos los valores a los parámetros del procedimiento almacenado
                comando.Parameters.AddWithValue("@NombreApellidos", usuario.NombreApellidos)
                comando.Parameters.AddWithValue("@Login", usuario.Login)
                comando.Parameters.AddWithValue("@Pass", usuario.Pass)
                comando.Parameters.AddWithValue("@Icono", usuario.Icono)
                comando.Parameters.AddWithValue("@NombreIcono", usuario.NombreIcono)
                comando.Parameters.AddWithValue("@Correo", usuario.Correo)
                comando.Parameters.AddWithValue("@Rol", usuario.Rol)
                comando.Parameters.AddWithValue("@Estado", usuario.Estado)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            ' Loguear o manejar la excepción específica de SQL
            Throw New ApplicationException("Error al insertar el usuario en la base de datos.", ex)
        Catch ex As Exception
            ' Manejar cualquier otro tipo de excepción inesperada
            Throw New ApplicationException("Error inesperado al insertar el usuario.", ex)
        End Try
    End Sub

    Public Function MostrarUsuarios() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("Select IdUsuario As 'ID', NombreApellidos AS 'Nombre y Apellidos', Login AS 'Usuario', Pass AS 'Contraseña', Icono, NombreIcono AS 'Nombre Icono', Correo, Rol, Estado FROM Usuario2", conexion)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar usuarios de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar usuarios.", ex)
        End Try
        Return dataTable
    End Function

    Public Sub ActualizarUsuario(usuario As Usuario)
        Try
            Using conexion As SqlConnection = CadenaConexion.CrearConexionSQL()
                Dim comando As New SqlCommand("editarUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario)
                comando.Parameters.AddWithValue("@NombreApellidos", usuario.NombreApellidos)
                comando.Parameters.AddWithValue("@Login", usuario.Login)
                comando.Parameters.AddWithValue("@Pass", usuario.Pass)
                comando.Parameters.AddWithValue("@Icono", usuario.Icono)
                comando.Parameters.AddWithValue("@NombreIcono", usuario.NombreIcono)
                comando.Parameters.AddWithValue("@Correo", usuario.Correo)
                comando.Parameters.AddWithValue("@Rol", usuario.Rol)
                comando.Parameters.AddWithValue("@Estado", usuario.Estado)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            ' Loguear o manejar la excepción específica de SQL
            Throw New ApplicationException("Error al editar el usuario en la base de datos.", ex)
        Catch ex As Exception
            ' Manejar cualquier otro tipo de excepción inesperada
            Throw New ApplicationException("Error inesperado al editar el usuario.", ex)
        End Try
    End Sub

    Public Sub EliminarUsuario(idUsuario As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el usuario en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el usuario.", ex)
        End Try
    End Sub

    Public Function BuscarUsuarios(textoIngresado) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("buscarUsuarios", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@textoIngresado", textoIngresado)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al buscar usuarios de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al buscar usuarios.", ex)
        End Try
        Return dataTable
    End Function
End Class
