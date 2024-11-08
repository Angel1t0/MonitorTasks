﻿Imports System.Data.SqlClient

Public Class DatosEvento

    ' *** OBTENER ***
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

    Public Function ObtenerCorreosUsuarios() As List(Of String)
        Dim correos As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCorreosUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
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
                    asistente.EventoID = reader(1)
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
                    notificacion.RecordatorioID = reader(0)
                    notificacion.EventoID = reader(1)
                    notificacion.Metodo = reader(2)
                    notificacion.Minutos = reader(3)
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
                            .EventoID = eventID,
                            .CalendarioID = calendarID,
                            .UserID = reader("UserID").ToString(),
                            .Titulo = reader("Summary").ToString(),
                            .Ubicacion = reader("Location").ToString(),
                            .Descripcion = reader("Description").ToString(),
                            .FechaInicio = reader("StartDateTime"),
                            .FechaFin = reader("EndDateTime"),
                            .RRULE = reader("MessageRRULE").ToString(),
                            .Visibilidad = reader("Visibility").ToString(),
                            .Transparencia = reader("Transparency").ToString(),
                            .UltimaModificacion = reader("LastModified"),
                            .TelefonoCreador = reader("CreatorPhone").ToString()
                        }
                        eventoYMensajesData.Evento = evento
                        Dim mensaje As New Mensaje With {
                            .EventoID = eventID,
                            .MensajeID = reader("MessageID").ToString(),
                            .UserID = reader("MessageUserID").ToString(),
                            .Titulo = reader("Summary").ToString(),
                            .Descripcion = reader("Description").ToString(),
                            .FechaInicio = reader("StartDateTime"),
                            .FechaFin = reader("EndDateTime"),
                            .EmailSilenciado = reader("EmailSent"),
                            .WhatsAppSilenciado = reader("WhatsAppSent"),
                            .DesktopSilenciado = reader("DesktopSent"),
                            .FechaEnviado = reader("SentTime"),
                            .Status = reader("Status").ToString(),
                            .RRULE = reader("MessageRRULE").ToString(),
                            .PodioAppItemID = Long.Parse(reader("PodioAppItemID").ToString()),
                            .TipoMensaje = "Recordatorio"
                        }
                        mensaje.Destinatarios.Add(New Asistente() With {
                            .Email = reader("AttendeeEmail").ToString(),
                            .Telefono = reader("AttendeePhone").ToString()
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
                    mensaje.EventoID = eventID
                    mensaje.UserID = userID
                    mensaje.EmailSilenciado = reader("EmailSent")
                    mensaje.WhatsAppSilenciado = reader("WhatsAppSent")
                    mensaje.DesktopSilenciado = reader("DesktopSent")
                    mensaje.FechaEnviado = reader("SentTime")
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
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    Dim calendario As New Calendario With {
                        .CalendarID = reader("CalendarID").ToString(),
                        .UserID = reader("UsuarioID").ToString(),
                        .CalendarioNombre = reader("CalendarName").ToString(),
                        .PropietarioEmail = reader("OwnerEmail").ToString()
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

    Public Function ObtenerEventosConPodio(calendarioID As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosConPodio", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarioID)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar eventos con podio de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar eventos con podio.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerEventosCompartidos(email As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerEventosCompartidos", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", email)
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

    Public Function ObtenerPodioUserIDPorCorreo(correo As String) As Integer
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerPodioUserIDPorCorreo", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", correo)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el ID del usuario de Podio.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el ID del usuario de Podio.", ex)
        End Try
    End Function

    Public Function ObtenerSolicitantes(podioItemID As Integer) As List(Of String)
        Dim solicitantes As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerListaSolicitantes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    solicitantes.Add(reader(0))
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener solicitantes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener solicitantes.", ex)
        End Try
        Return solicitantes
    End Function

    Public Function ObtenerAutorizantes(podioItemID As Integer) As List(Of String)
        Dim autorizantes As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerListaAutorizantes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    autorizantes.Add(reader(0))
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener autorizantes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener autorizantes.", ex)
        End Try
        Return autorizantes
    End Function

    Public Function ObtenerUserIDPorProfileID(profileID As Integer) As Integer
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerUserIDPorProfileID", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioProfileID", profileID)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener el ID del usuario por ProfileID.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener el ID del usuario por ProfileID.", ex)
        End Try
    End Function

    Public Function ObtenerCorreoPorProfileID(profileID As Integer) As String
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCorreoPorProfileID", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioProfileID", profileID)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error al obtener el correo de usuario de Podio en la base de datos.", ex)
        End Try
    End Function

    Public Function ObtenerTareasPendientes() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerItemsPendientes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar tareas pendientes de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar tareas pendientes.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerTareasFinalizadas() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerItemsFinalizados", conexion)
                comando.CommandType = CommandType.StoredProcedure
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar tareas finalizadas de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar tareas finalizadas.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerTareasCreadas() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerItemsCreados", conexion)
                comando.CommandType = CommandType.StoredProcedure
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar tareas creadas de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar tareas creadas.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerTareasPorUsuario(email As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerItemsPorUsuario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", email)
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al mostrar tareas por usuario de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al mostrar tareas por usuario.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerCorreos() As List(Of String)
        Dim correos As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerCorreos", conexion)
                comando.CommandType = CommandType.StoredProcedure
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

    Public Function ObtenerCantidadItemsPorEstado() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerCantidadItemsPorEstado", conexion)
                comando.CommandType = CommandType.StoredProcedure
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener la cantidad de ítems por estado de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener la cantidad de ítems por estado.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerCantidadItemsPorSystemArea() As DataTable
        Dim dataTable As New DataTable()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("obtenerCantidadItemsPorSystemArea", conexion)
                comando.CommandType = CommandType.StoredProcedure
                Dim sqlAdaptador As New SqlDataAdapter(comando)

                conexion.Open()
                sqlAdaptador.Fill(dataTable)
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener la cantidad de ítems por SystemArea de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener la cantidad de ítems por SystemArea.", ex)
        End Try
        Return dataTable
    End Function

    Public Function ObtenerProyectosPorItem(podioItemID As Integer) As Dictionary(Of String, String)
        Dim proyectos As New Dictionary(Of String, String)()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Using comando As New SqlCommand("obtenerProyectosPorItem", conexion)
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.AddWithValue("@PodioItemID", podioItemID)

                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim id As Long = (reader("PodioProjectSystemID")).ToString()
                            Dim name As String = reader("Name").ToString()
                            proyectos.Add(id, name)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error al obtener proyectos de la base de datos.", ex)
        End Try
        Return proyectos
    End Function

    Public Function ObtenerListaEmpresas(podioItemID As Integer, status As String) As List(Of String)
        Dim empresas As New List(Of String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("obtenerListaEmpresas", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@Status", status)
                Dim reader As SqlDataReader = comando.ExecuteReader
                While (reader.Read())
                    empresas.Add(reader(0))
                End While
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al obtener empresas de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al obtener empresas.", ex)
        End Try
        Return empresas
    End Function

    Public Function ObtenerPodioUserIDYNombre() As Dictionary(Of String, Integer)
        Dim podioUsers As New Dictionary(Of String, Integer)()
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Using comando As New SqlCommand("obtenerPodioUserIDYNombre", conexion)
                    comando.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim name As String = reader("NombreApellidos").ToString()
                            Dim id As Integer = Integer.Parse(reader("PodioUserID"))
                            podioUsers.Add(name, id)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error al obtener usuarios de Podio de la base de datos.", ex)
        End Try
        Return podioUsers
    End Function

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
                    .EventoID = eventID,
                    .Email = If(reader.IsDBNull(0), String.Empty, reader.GetString(0)),
                    .Telefono = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
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
                    notificacion.RecordatorioID = reader(0)
                    notificacion.Metodo = reader(1)
                    notificacion.Minutos = reader(2)
                    listaNotificaciones.Add(notificacion)
                End While
            End Using
        Catch ex As Exception
        End Try
        Return listaNotificaciones
    End Function


    ' *** INSERTAR ***
    Public Sub InsertarCalendario(calendarioGoogle As Calendario)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarCalendario", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@CalendarID", calendarioGoogle.CalendarID)
                comando.Parameters.AddWithValue("@UsuarioID", Login.idUsuario)
                comando.Parameters.AddWithValue("@CalendarName", calendarioGoogle.CalendarioNombre)
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

    Public Sub InsertarEvento(evento As Evento)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", evento.EventoID)
                comando.Parameters.AddWithValue("@CalendarID", evento.CalendarioID)
                comando.Parameters.AddWithValue("@UserID", evento.UserID)
                comando.Parameters.AddWithValue("@Summary", evento.Titulo)
                comando.Parameters.AddWithValue("@Location", evento.Ubicacion)
                comando.Parameters.AddWithValue("@Description", evento.Descripcion)
                comando.Parameters.AddWithValue("@StartDateTime", evento.FechaInicio)
                comando.Parameters.AddWithValue("@EndDateTime", evento.FechaFin)
                comando.Parameters.AddWithValue("@RRULE", evento.RRULE)
                comando.Parameters.AddWithValue("@Visibility", evento.Visibilidad)
                comando.Parameters.AddWithValue("@Transparency", evento.Transparencia)
                comando.Parameters.AddWithValue("@LastModified", evento.UltimaModificacion)
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
                comando.Parameters.AddWithValue("@EventID", asistente.EventoID)
                comando.Parameters.AddWithValue("@Email", asistente.Email)
                comando.Parameters.AddWithValue("@DisplayName", asistente.Nombre)
                comando.Parameters.AddWithValue("@Status", asistente.Status)
                comando.Parameters.AddWithValue("@PodioItemID", asistente.PodioItemID)

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
                comando.Parameters.AddWithValue("@EventID", mensaje.EventoID)
                comando.Parameters.AddWithValue("@UserID", mensaje.UserID)
                comando.Parameters.AddWithValue("@EmailSent", mensaje.EmailSilenciado)
                comando.Parameters.AddWithValue("@WhatsAppSent", mensaje.WhatsAppSilenciado)
                comando.Parameters.AddWithValue("@DesktopSent", mensaje.DesktopSilenciado)
                comando.Parameters.AddWithValue("@SentTime", DateTime.Now)
                comando.Parameters.AddWithValue("@Status", mensaje.Status)
                comando.Parameters.AddWithValue("@MessageType", mensaje.TipoMensaje)
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
                comando.Parameters.AddWithValue("@EventID", notificacion.EventoID)
                comando.Parameters.AddWithValue("@Method", notificacion.Metodo)
                comando.Parameters.AddWithValue("@Minutes", notificacion.Minutos)
                comando.Parameters.AddWithValue("@Status", notificacion.Status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar la notificación en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar la notificación.", ex)
        End Try
    End Sub

    Public Function InsertarPodioItem(podioItem As PodioItem) As Integer
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarPodioItem", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", podioItem.EventoID)
                comando.Parameters.AddWithValue("@PodioAppID", podioItem.PodioAppID)
                comando.Parameters.AddWithValue("@PodioAppItemID", podioItem.PodioAppItemID)
                comando.Parameters.AddWithValue("@Title", podioItem.Titulo)
                comando.Parameters.AddWithValue("@Description", podioItem.Descripcion)
                comando.Parameters.AddWithValue("@Department", podioItem.ObtenerNombreSeleccionado((podioItem.Departamento), podioItem.departamentoOpcionesInvertidas))
                comando.Parameters.AddWithValue("@DepartmentPriority", podioItem.PrioridadDepartamento)
                comando.Parameters.AddWithValue("@SystemArea", podioItem.ObtenerNombreSeleccionado((podioItem.AreaSistemas), podioItem.areaSistemasOpcionesInvertidas))
                comando.Parameters.AddWithValue("@Categories", podioItem.ObtenerNombreSeleccionado((podioItem.Categorias), podioItem.categoriaOpcionesInvertidas))
                comando.Parameters.AddWithValue("@SystemPriority", podioItem.PrioridadSistemas)
                comando.Parameters.AddWithValue("@Priority", podioItem.ObtenerNombreSeleccionado((podioItem.Prioridad), podioItem.prioridadOpcionesInvertidas))
                comando.Parameters.AddWithValue("@StartDate", podioItem.FechaInicio)
                comando.Parameters.AddWithValue("@EndDate", podioItem.FechaFin)
                comando.Parameters.AddWithValue("@WorkPlan", podioItem.PlanTrabajo)
                comando.Parameters.AddWithValue("@Status", podioItem.ObtenerNombreSeleccionado((podioItem.Status), podioItem.statusOpcionesInvertidas))
                comando.Parameters.AddWithValue("@Progress", podioItem.Progreso)
                comando.Parameters.AddWithValue("@HoursAccumulated", podioItem.HorasAcumuladas)
                comando.Parameters.AddWithValue("@ExtraHours", podioItem.HorasExtras)
                comando.Parameters.AddWithValue("@ScrumDaily", podioItem.ScrumDaily)
                comando.Parameters.AddWithValue("@CreatedOn", DateTime.Now)
                comando.Parameters.AddWithValue("@LastModified", DateTime.Now)
                Return comando.ExecuteScalar()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el item de podio en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el item de podio.", ex)
        End Try
    End Function

    Public Sub InsertarSolicitante(podioItemID As Object, podioUserID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarPodioSolicitante", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@UserID", podioUserID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el solicitante en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el solicitante.", ex)
        End Try
    End Sub

    Public Sub InsertarAutorizante(podioItemID As Integer, podioUserID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarPodioAutorizante", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@UserID", podioUserID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el autorizante en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el autorizante.", ex)
        End Try
    End Sub

    Public Sub InsertarProyectoSistemas(podioItemID As Integer, podioProjectSystemID As String, name As String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarPodioProyectoSistemas", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@PodioProjectSystemID", Long.Parse(podioProjectSystemID))
                comando.Parameters.AddWithValue("@Name", name)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar el proyecto de sistemas en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar el proyecto de sistemas.", ex)
        End Try
    End Sub

    Public Sub InsertarPodioEmpresa(podioItem As PodioItem, podioItemCompanyID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("insertarPodioItemEmpresa", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItem.PodioItemID)
                comando.Parameters.AddWithValue("@PodioItemCompanyID", podioItemCompanyID)
                comando.Parameters.AddWithValue("@Name", podioItem.ObtenerNombreSeleccionado(podioItemCompanyID, podioItem.empresaOpcionesInvertidas))
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al insertar la empresa en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al insertar la empresa.", ex)
        End Try
    End Sub

    ' *** ACTUALIZAR ***
    Public Sub ActualizarEvento(evento As Evento)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarEvento", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", evento.EventoID)
                comando.Parameters.AddWithValue("@Summary", evento.Titulo)
                comando.Parameters.AddWithValue("@Location", evento.Ubicacion)
                comando.Parameters.AddWithValue("@Description", evento.Descripcion)
                comando.Parameters.AddWithValue("@StartDateTime", evento.FechaInicio)
                comando.Parameters.AddWithValue("@EndDateTime", evento.FechaFin)
                comando.Parameters.AddWithValue("@RRULE", evento.RRULE)
                comando.Parameters.AddWithValue("@Visibility", evento.Visibilidad)
                comando.Parameters.AddWithValue("@Transparency", evento.Transparencia)
                comando.Parameters.AddWithValue("@LastModified", evento.UltimaModificacion)
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
                comando.Parameters.AddWithValue("@EventID", mensaje.EventoID)
                comando.Parameters.AddWithValue("@UserID", mensaje.UserID)
                comando.Parameters.AddWithValue("@EmailSent", mensaje.EmailSilenciado)
                comando.Parameters.AddWithValue("@WhatsAppSent", mensaje.WhatsAppSilenciado)
                comando.Parameters.AddWithValue("@DesktopSent", mensaje.DesktopSilenciado)
                comando.Parameters.AddWithValue("@SentTime", mensaje.FechaEnviado)
                comando.Parameters.AddWithValue("@Status", mensaje.Status)
                comando.Parameters.AddWithValue("@MessageType", "Actualizacion")
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
                comando.Parameters.AddWithValue("@ReminderID", notificacion.RecordatorioID)
                comando.Parameters.AddWithValue("@Method", notificacion.Metodo)
                comando.Parameters.AddWithValue("@Minutes", notificacion.Minutos)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar la notificación en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar la notificación.", ex)
        End Try
    End Sub

    Public Sub ActualizarAsistente(asistenteGoogle As Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarAsistentes", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistenteGoogle.EventoID)
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

    Public Sub ActualizarPodioItemEmpresas(podioItem As PodioItem, podioItemCompanyID As Integer, status As String)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("editarPodioItemEmpresa", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItem.PodioItemID)
                comando.Parameters.AddWithValue("@PodioItemCompanyID", podioItemCompanyID)
                comando.Parameters.AddWithValue("@Status", status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar el estado de la empresa en el item de Podio en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar la empresa en el item de Podio.", ex)
        End Try
    End Sub

    Public Sub ActualizarFechaEnvio(messageID As Integer, sentTime As Date)
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

    Public Sub ActualizarPodioAppItemID(podioItemID As Integer, podioAppItemID As Long)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("actualizarPodioAppItemID", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioAppItemID", podioAppItemID)
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error al actualizar el AppItemID del item de Podio en la base de datos.", ex)
        End Try
    End Sub

    ' *** ELIMINAR ***
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

    Public Sub EliminarAsistente(asistente As Asistente)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                Dim comando As New SqlCommand("eliminarAsistente", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", asistente.EventoID)
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

    Public Sub EliminarSolicitante(correo As String, podioItemID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("eliminarPodioSolicitante", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", correo)
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el solicitante de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el solicitante.", ex)
        End Try
    End Sub

    Public Sub EliminarAutorizante(correo As String, podioItemID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("eliminarPodioAutorizante", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@Email", correo)
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el autorizante de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el autorizante.", ex)
        End Try
    End Sub

    Public Sub EliminarProyectoSistemas(proyectoID As String, podioItemID As Integer)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("eliminarPodioProyectoSistemas", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@PodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@PodioProjectSystemID", Long.Parse(proyectoID))
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al eliminar el proyecto de sistemas de la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al eliminar el proyecto de sistemas.", ex)
        End Try
    End Sub

    Public Sub ClonarEvento(eventID As String, podioItemID As Integer, podioAppItemID As Long, copyEventID As String, copyPodioAppItemID As Long)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("duplicarEventosYPodio", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@oldPodioItemID", podioItemID)
                comando.Parameters.AddWithValue("@oldPodioAppItemID", podioAppItemID)
                comando.Parameters.AddWithValue("@oldEventID", eventID)
                comando.Parameters.AddWithValue("@newPodioAppItemID", copyPodioAppItemID)
                comando.Parameters.AddWithValue("@newEventID", copyEventID)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error al clonar el evento en la base de datos.", ex)
        End Try
    End Sub

    Public Sub ActualizarStatusEvento(evento As Evento)
        Try
            Using conexion As SqlConnection = CrearConexionSQL()
                conexion.Open()
                Dim comando As New SqlCommand("actualizarStatusActividad", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@EventID", evento.EventoID)
                comando.Parameters.AddWithValue("@EndDateTime", evento.FechaFin)
                comando.Parameters.AddWithValue("@NowDateTime", DateTime.Now)
                comando.Parameters.AddWithValue("@RRULE", evento.RRULE)
                comando.Parameters.AddWithValue("@Status", evento.Status)
                comando.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw New ApplicationException("Error al actualizar el estado del evento en la base de datos.", ex)
        Catch ex As Exception
            Throw New ApplicationException("Error inesperado al actualizar el estado del evento.", ex)
        End Try
    End Sub
End Class
