Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader

Public Class EventoData
    Public Function ObtenerCalendarios() As List(Of List(Of String))
        Dim calendarios As New List(Of List(Of String))
        Dim calendariosName As New List(Of String)
        Dim calendariosID As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("mostrarCalendariosID", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@UsuarioID", Login.idUsuario)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    calendariosID.Add(reader(0))
                    calendariosName.Add(reader(1))
                End While
                calendarios.Add(calendariosID)
                calendarios.Add(calendariosName)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar usuarios de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar usuarios.", ex)
        End Try
        Return calendarios
    End Function

    Public Function ObtenerCorreoUsuario() As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCorreoUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@UsuarioID", Login.idUsuario)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el correo del usuario.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el correo del usuario.", ex)
        End Try
    End Function

    Public Function ObtenerCorreosUsuarioExcepto(correo As String) As List(Of String)
        Dim correos As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCorreosUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CorreoExceptuado", correo)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    correos.Add(reader(0))
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener correos de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener correos.", ex)
        End Try
        Return correos
    End Function

    Public Function ObtenerNombreInvitado(correo As String) As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerNombreInvitado", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Correo", correo)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el nombre del invitado.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el nombre del invitado.", ex)
        End Try
    End Function

    Public Sub InsertarEvento(evento As Evento)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", evento.EventID)
                comando.Parameters.AddWithValue("@CalendarID", evento.CalendarID)
                comando.Parameters.AddWithValue("@Summary", evento.Summary)
                comando.Parameters.AddWithValue("@Location", evento.Location)
                comando.Parameters.AddWithValue("@Description", evento.Description)
                comando.Parameters.AddWithValue("@StartDateTime", evento.StartDateTime)
                comando.Parameters.AddWithValue("@EndDateTime", evento.EndDateTime)
                comando.Parameters.AddWithValue("@Visibility", evento.Visibility)
                comando.Parameters.AddWithValue("@Transparency", evento.Transparency)
                comando.Parameters.AddWithValue("@LastModified", DateTime.Now)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el evento en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el evento.", ex)
        End Try
    End Sub

    Public Sub InsertarRecurrencia(recurrencia As Recurrencia)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("insertarRecurrencia", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", recurrencia.EventID)
                comando.Parameters.AddWithValue("@RRULE", recurrencia.RRULE)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar la recurrencia en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar la recurrencia.", ex)
        End Try
    End Sub

    Public Sub InsertarAsistente(asistente As Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarAsistente", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistente.EventID)
                comando.Parameters.AddWithValue("@Email", asistente.Email)
                comando.Parameters.AddWithValue("@DisplayName", asistente.DisplayName)
                comando.Parameters.AddWithValue("@ResponseStatus", asistente.ResponseStatus)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el asistente en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el asistente.", ex)
        End Try
    End Sub

    Public Sub InsertarNotificacion(notificacion As Notificacion)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarNotificacion", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", notificacion.EventID)
                comando.Parameters.AddWithValue("@Method", notificacion.Method)
                comando.Parameters.AddWithValue("@Minutes", notificacion.Minutes)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar la notificación en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar la notificación.", ex)
        End Try
    End Sub

    Public Function MostrarEventos() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosPorCalendario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalenderID", GestionEventos.CalendarioID)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar eventos de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar eventos.", ex)
        End Try
        Return dataTable
    End Function
End Class
