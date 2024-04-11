Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports Google.Apis.Calendar.v3
Imports log4net

Public Class EventoData
    'Public Function ObtenerCalendarios(idUsuario As String) As List(Of List(Of String))
    '    Dim calendarios As New List(Of List(Of String))
    '    Dim calendariosName As New List(Of String)
    '    Dim calendariosID As New List(Of String)
    '    Try
    '        Using conexion As SqlConnection = CrearConexionSQL()
    '            conexion.Open()
    '            Dim comando As New SqlCommand("mostrarCalendariosID", conexion)
    '            comando.CommandType = CommandType.StoredProcedure
    '            comando.Parameters.AddWithValue("@UsuarioID", idUsuario)
    '            Dim reader As SqlDataReader = comando.ExecuteReader
    '            While (reader.Read())
    '                calendariosID.Add(reader(0))
    '                calendariosName.Add(reader(1))
    '            End While
    '            calendarios.Add(calendariosID)
    '            calendarios.Add(calendariosName)
    '        End Using
    '    Catch ex As SqlException
    '        Throw New ApplicationException("Error al mostrar usuarios de la base de datos.", ex)
    '    Catch ex As Exception
    '        Throw New ApplicationException("Error inesperado al mostrar usuarios.", ex)
    '    End Try
    '    Return calendarios
    'End Function

    Public Function ObtenerCalendarioID() As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand($"SELECT CalendarID FROM Calendarios WHERE UsuarioID = {Login.idUsuario}", conexion)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el ID del calendario.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el ID del calendario.", ex)
        End Try
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
                comando.Parameters.AddWithValue("@UserID", evento.UserID)
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

    Public Function InsertarAsistente(asistente As Asistente) As Integer
        Dim attendeeId As Integer = 0
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarAsistente", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistente.EventID)
                comando.Parameters.AddWithValue("@Email", asistente.Email)
                comando.Parameters.AddWithValue("@DisplayName", asistente.DisplayName)
                comando.Parameters.AddWithValue("@Status", asistente.Status)

                ' Ejecuta el comando y captura el AttendeeID generado
                Dim result As Object = comando.ExecuteScalar()
                If result IsNot Nothing Then
                    attendeeId = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el asistente en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el asistente.", ex)
        End Try
        Return attendeeId
    End Function

    Public Sub InsertarMensaje(mensaje As Mensaje)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarMensaje", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", mensaje.EventID)
                comando.Parameters.AddWithValue("@UserID", mensaje.UserID)
                comando.Parameters.AddWithValue("@EmailSent", mensaje.EmailSent)
                comando.Parameters.AddWithValue("@WhatsAppSent", mensaje.WhatsAppSent)
                comando.Parameters.AddWithValue("@DesktopSent", mensaje.DesktopSent)
                comando.Parameters.AddWithValue("@SentTime", DateTime.Now)
                comando.Parameters.AddWithValue("@Status", mensaje.Status)
                comando.Parameters.AddWithValue("@MessageType", mensaje.MessageType)
                comando.Parameters.AddWithValue("@RRULE", mensaje.RRULE)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el mensaje en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el mensaje.", ex)
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


    Public Function MostrarAsistentesInvitados(eventID As String) As List(Of Asistente)
        Dim asistentes As New List(Of Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerListaInvitados", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While reader.Read()
                    Dim asistente As New Asistente() With {
                    .Email = If(reader.IsDBNull(0), String.Empty, reader.GetString(0)),
                    .PhoneNumber = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                }
                    asistentes.Add(asistente)
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

    Public Sub ActualizarMensaje(mensaje As Mensaje, aplicarATodos As Boolean)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarMensaje", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", mensaje.EventID)
                comando.Parameters.AddWithValue("@UserID", mensaje.UserID)
                comando.Parameters.AddWithValue("@EmailSent", mensaje.EmailSent)
                comando.Parameters.AddWithValue("@WhatsAppSent", mensaje.WhatsAppSent)
                comando.Parameters.AddWithValue("@DesktopSent", mensaje.DesktopSent)
                comando.Parameters.AddWithValue("@SentTime", mensaje.SentTime)
                comando.Parameters.AddWithValue("@Status", mensaje.Status)
                comando.Parameters.AddWithValue("@MessageType", "Actualización")
                comando.Parameters.AddWithValue("@AplicarATodos", aplicarATodos)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar el mensaje en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar el mensaje.", ex)
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
                Dim comando As New SqlCommand("SELECT * FROM Asistentes WHERE Status <> 'Eliminado'", conexion)
                'comando.CommandType = CommandType.StoredProcedure
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim asistente As New Asistente()
                    asistente.EventID = reader(1)
                    asistente.Email = reader(2)
                    asistente.Status = reader(4)
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

    Public Sub EliminarTodasNotificacionesPorEvento(eventID As String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarNotificacionesEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar todas las notificaciones de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar todas las notificaciones.", ex)
        End Try
    End Sub

    Public Function BuscarUserID(correo As String) As Integer
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("buscarUserIDPorCorreo", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", correo)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al buscar el ID del usuario.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al buscar el ID del usuario.", ex)
        End Try
    End Function

    Public Function ObtenerEventosYMensajes(calendarID As String) As List(Of EventoYMensajes)
        Dim eventoYMensajes As New List(Of EventoYMensajes)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Console.WriteLine("Conectado a la base de datos")
                conexion.Open()
                Dim comando As New SqlCommand("obtenerEventosYMensajes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    If Not IsDBNull(reader("MessageID")) Then
                        Dim eventoYMensajesData As New EventoYMensajes()

                        Dim eventID As String = reader("EventID").ToString()
                        Dim evento As New Evento With {
                            .EventID = eventID,
                            .CalendarID = calendarID,
                            .UserID = reader("UserID").ToString(),
                            .Summary = reader("Summary").ToString(),
                            .Location = reader("Location").ToString(),
                            .Description = reader("Description").ToString(),
                            .StartDateTime = reader("StartDateTime"),
                            .EndDateTime = reader("EndDateTime"),
                            .RRULE = reader("MessageRRULE").ToString(),
                            .Visibility = reader("Visibility").ToString(),
                            .Transparency = reader("Transparency").ToString(),
                            .LastModified = reader("LastModified"),
                            .CreatorPhone = reader("CreatorPhone").ToString()
                        }
                        eventoYMensajesData.Evento = evento
                        Dim mensaje As New Mensaje With {
                            .EventID = eventID,
                            .MessageID = reader("MessageID").ToString(),
                            .UserID = reader("MessageUserID").ToString(),
                            .Title = reader("Summary").ToString(),
                            .Description = reader("Description").ToString(),
                            .StartDateTime = reader("StartDateTime"),
                            .EndDateTime = reader("EndDateTime"),
                            .EmailSent = reader("EmailSent"),
                            .WhatsAppSent = reader("WhatsAppSent"),
                            .DesktopSent = reader("DesktopSent"),
                            .SentTime = reader("SentTime"),
                            .Status = reader("Status").ToString(),
                            .RRULE = reader("MessageRRULE").ToString()
                        }
                        mensaje.Attendees.Add(New Asistente() With {
                            .Email = reader("AttendeeEmail").ToString(),
                            .PhoneNumber = reader("AttendeePhone").ToString()
                        })

                        eventoYMensajesData.Mensaje = mensaje

                        eventoYMensajes.Add(eventoYMensajesData)
                    End If
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener eventos y mensajes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener eventos y mensajes.", ex)
        End Try
        Return eventoYMensajes
    End Function

    Friend Sub ActualizarFechaEnvio(messageID As Integer, sentTime As Date)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("actualizarFechaEnvio", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@MessageID", messageID)
                comando.Parameters.AddWithValue("@SentTime", sentTime)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar la fecha de envío en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar la fecha de envío.", ex)
        End Try
    End Sub

    Public Function ObtenerEventosConNotificacionesActivas(calendarioID As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosConNotificacionesActivas", conexion)
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

    Public Function ObtenerDatosNotificacion(eventID As String, userID As Integer) As Mensaje
        Dim mensaje As New Mensaje()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerDatosNotificacion", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", eventID)
                comando.Parameters.AddWithValue("@UserID", userID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    mensaje.EventID = eventID
                    mensaje.UserID = userID
                    mensaje.EmailSent = reader("EmailSent")
                    mensaje.WhatsAppSent = reader("WhatsAppSent")
                    mensaje.DesktopSent = reader("DesktopSent")
                    mensaje.SentTime = reader("SentTime")
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener datos de la notificación de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener datos de la notificación.", ex)
        End Try
        Return mensaje
    End Function

    Public Function ObtenerCalendarios() As List(Of Calendario)
        Dim calendarios As New List(Of Calendario)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCalendarios", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@UserID", Login.idUsuario)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim calendario As New Calendario With {
                        .CalendarID = reader("CalendarID").ToString(),
                        .UserID = reader("UsuarioID").ToString(),
                        .CalendarName = reader("CalendarName").ToString(),
                        .OwnerEmail = reader("OwnerEmail").ToString()
                    }
                    calendarios.Add(calendario)
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener calendarios de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener calendarios.", ex)
        End Try
        Return calendarios
    End Function

    Public Sub InsertarCalendario(calendarioGoogle As Calendario)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarCalendario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarioGoogle.CalendarID)
                comando.Parameters.AddWithValue("@UsuarioID", Login.idUsuario)
                comando.Parameters.AddWithValue("@CalendarName", calendarioGoogle.CalendarName)
                comando.Parameters.AddWithValue("@OwnerEmail", ObtenerCorreoUsuario())
                comando.Parameters.AddWithValue("@Status", calendarioGoogle.Status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el calendario en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el calendario.", ex)
        End Try
    End Sub

    Public Sub EliminarCalendario(calendarioID As String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarCalendario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarioID)
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el calendario de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el calendario.", ex)
        End Try
    End Sub

    Public Sub ActualizarAsistente(asistenteGoogle As Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarAsistentes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistenteGoogle.EventID)
                comando.Parameters.AddWithValue("@Email", asistenteGoogle.Email)
                comando.Parameters.AddWithValue("@Status", asistenteGoogle.Status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar el asistente en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar el asistente.", ex)
        End Try
    End Sub

    ' GESTION EVENTOS COMPARTIDOS
    Public Function ObtenerEventosCompartidos() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosCompartidos", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", ObtenerCorreoUsuario())
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar eventos compartidos de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar eventos compartidos.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerTelefonoAsistente(email As String) As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerTelefonoAsistente", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", email)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el teléfono del asistente.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el teléfono del asistente.", ex)
        End Try
    End Function
End Class
