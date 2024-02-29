Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports log4net

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
                comando.Parameters.AddWithValue("@RRULE", evento.RRULE)
                comando.Parameters.AddWithValue("@Visibility", evento.Visibility)
                comando.Parameters.AddWithValue("@Transparency", evento.Transparency)
                comando.Parameters.AddWithValue("@LastModified", evento.LastModified)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el evento en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el evento.", ex)
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
                comando.Parameters.AddWithValue("@Status", asistente.Status)
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
                comando.Parameters.AddWithValue("@Status", notificacion.Status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar la notificación en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar la notificación.", ex)
        End Try
    End Sub

    Public Function MostrarEventos(calendarioID As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosPorCalendario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarioID)
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


    Public Function MostrarAsistentesInvitados(eventID As String) As List(Of String)
        Dim asistentes As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerListaInvitados", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    asistentes.Add(reader(0))
                End While
                Return asistentes
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar asistentes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar asistentes.", ex)
        End Try
    End Function

    Public Function MostrarNotificacionesActivas(eventID As String) As List(Of Notificacion)
        Dim listaNotificaciones As New List(Of Notificacion)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerNotificacionesActivas", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim notificacion As New Notificacion()
                    notificacion.ReminderID = reader(0)
                    notificacion.Method = reader(1)
                    notificacion.Minutes = reader(2)
                    listaNotificaciones.Add(notificacion)
                End While
            End Using
        Catch ex As Exception
        End Try
        Return listaNotificaciones
    End Function

    Public Sub EliminarAsistente(asistente As Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarAsistente", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistente.EventID)
                comando.Parameters.AddWithValue("@Email", asistente.Email)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el asistente de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el asistente.", ex)
        End Try
    End Sub

    Public Sub EliminarNotificacion(reminderID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarNotificacion", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@ReminderID", reminderID)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar la notificacion de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar la notificacion.", ex)
        End Try
    End Sub

    Public Sub ActualizarEvento(evento As Evento)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", evento.EventID)
                comando.Parameters.AddWithValue("@Summary", evento.Summary)
                comando.Parameters.AddWithValue("@Location", evento.Location)
                comando.Parameters.AddWithValue("@Description", evento.Description)
                comando.Parameters.AddWithValue("@StartDateTime", evento.StartDateTime)
                comando.Parameters.AddWithValue("@EndDateTime", evento.EndDateTime)
                comando.Parameters.AddWithValue("@RRULE", evento.RRULE)
                comando.Parameters.AddWithValue("@Visibility", evento.Visibility)
                comando.Parameters.AddWithValue("@Transparency", evento.Transparency)
                comando.Parameters.AddWithValue("@LastModified", evento.LastModified)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar el evento en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar el evento.", ex)
        End Try
    End Sub

    Public Sub ActualizarNotificacion(notificacion As Notificacion)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarNotificaciones", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@ReminderID", notificacion.ReminderID)
                comando.Parameters.AddWithValue("@Method", notificacion.Method)
                comando.Parameters.AddWithValue("@Minutes", notificacion.Minutes)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar la notificación en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar la notificación.", ex)
        End Try
    End Sub

    Public Sub EliminarEvento(eventID As String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                comando.Parameters.AddWithValue("@LastModified", DateTime.Now)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el evento de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el evento.", ex)
        End Try
    End Sub

    Public Function ObtenerTodosAsistentes() As List(Of Asistente)
        Dim asistentes As New List(Of Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("SELECT * FROM Asistentes", conexion)
                'comando.CommandType = CommandType.StoredProcedure
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim asistente As New Asistente()
                    asistente.EventID = reader(1)
                    asistente.Email = reader(2)
                    asistentes.Add(asistente)
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener asistentes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener asistentes.", ex)
        End Try
        Return asistentes
    End Function

    Public Function ObtenerTodasNotificaciones() As List(Of Notificacion)
        Dim notificaciones As New List(Of Notificacion)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("SELECT * FROM Recordatorios", conexion)
                'comando.CommandType = CommandType.StoredProcedure
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim notificacion As New Notificacion()
                    notificacion.ReminderID = reader(0)
                    notificacion.EventID = reader(1)
                    notificacion.Method = reader(2)
                    notificacion.Minutes = reader(3)
                    notificaciones.Add(notificacion)
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener notificaciones de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener notificaciones.", ex)
        End Try
        Return notificaciones
    End Function

    Public Function ObtenerReminderID(eventID As String, method As String, minutes As Integer) As List(Of Integer)
        Dim listaReminderID As New List(Of Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerReminderID", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                comando.Parameters.AddWithValue("@Method", method)
                comando.Parameters.AddWithValue("@Minutes", minutes)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    listaReminderID.Add(reader(0))
                End While
                Return listaReminderID
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el ID del recordatorio.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el ID del recordatorio.", ex)
        End Try
    End Function
End Class
