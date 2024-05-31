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
                comando.Parameters.AddWithValue("@Correo", usuario.Correo)
                comando.Parameters.AddWithValue("@Telefono", usuario.Telefono)
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
                Dim comando As New SqlCommand("Select IdUsuario As 'ID', NombreApellidos AS 'Nombre y Apellidos', Login AS 'Usuario', Pass AS 'Contraseña', Correo, Telefono, Estado FROM Usuario2 WHERE Estado <> 'Eliminado'", conexion)
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
                comando.Parameters.AddWithValue("@Correo", usuario.Correo)
                comando.Parameters.AddWithValue("Telefono", usuario.Telefono)
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

    ' --- LOGIN ---
    Public Function ValidarLogin(login As String, pass As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("validarLogin", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Login", login)
                comando.Parameters.AddWithValue("@Pass", pass)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al validar el usuario de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al inicio de sesión.", ex)
        End Try
        Return dataTable
    End Function

    Public Function buscarCorreo(correo As String) As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("buscarUsuarioCorreo", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Correo", correo)
                conexion.Open()
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error en la conexion de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado.", ex)
        End Try
    End Function
End Class
