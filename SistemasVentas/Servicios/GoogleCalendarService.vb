Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Services
Imports System.Threading.Tasks

' Clase para manejar la autenticación y creación del servicio de Google Calendar.
Public Class GoogleCalendarService
    Private _datosEvento As EventoData
    Public Property CalendarioID As String
    Public Sub New()
        _datosEvento = New EventoData()
    End Sub

    ' ApplicationName es el nombre de la aplicación. Este nombre se muestra durante el proceso de autenticación.
    Private ApplicationName As String = "Monitor task - Prueba"

    ' Método que maneja la autenticación y crea un servicio de Google Calendar.
    Public Function Authenticate() As CalendarService
        Dim authenticator As New GoogleServicesAuthenticator()
        Dim credential As UserCredential = authenticator.AuthenticateGoogleServices(Login.idUsuario)

        ' Inicializar el servicio de Google Calendar
        Dim service = New CalendarService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })

        Return service ' Devuelve el servicio autenticado para ser usado en otras partes de la aplicación.
    End Function

    Public Function ObtenerCalendariosGoogle(service As CalendarService) As List(Of Calendario)
        Dim listRequest = service.CalendarList.List()
        listRequest.MinAccessRole = CalendarListResource.ListRequest.MinAccessRoleEnum.Owner
        listRequest.ShowDeleted = False
        Dim CalendarList = listRequest.Execute()
        Dim calendarios As New List(Of Calendario)

        If calendarList.Items IsNot Nothing AndAlso calendarList.Items.Count > 0 Then
            For Each calendarListEntry In calendarList.Items
                calendarios.Add(New Calendario With {
                    .CalendarID = calendarListEntry.Id,
                    .CalendarName = calendarListEntry.Summary
                })
            Next
        Else
            Console.WriteLine("No se encontraron calendarios.")
        End If

        Return calendarios
    End Function

    Public Function ConvertirAModeloGoogleCalendar(evento As Evento) As [Event]

        Dim eventoGoogle As New [Event] With {
            .Summary = evento.Summary,
            .Location = evento.Location,
            .Description = evento.Description,
            .Start = New EventDateTime() With {.DateTime = evento.StartDateTime, .TimeZone = "America/Mexico_City"},
            .End = New EventDateTime() With {.DateTime = evento.EndDateTime, .TimeZone = "America/Mexico_City"},
            .Visibility = evento.Visibility,
            .Transparency = evento.Transparency
        }

        Return eventoGoogle
    End Function

    Public Async Function ActualizarEventoGoogleAsync(service As CalendarService, googleEventId As String, evento As Evento) As Task
        Try
            ' Obtener el evento existente
            Dim eventoGoogle As [Event] = Await service.Events.Get("primary", googleEventId).ExecuteAsync()

            ' Actualizar los campos del evento
            eventoGoogle.Summary = evento.Summary
            eventoGoogle.Location = evento.Location
            eventoGoogle.Description = evento.Description
            eventoGoogle.Start = New EventDateTime() With {.DateTime = evento.StartDateTime, .TimeZone = "America/Mexico_City"}
            eventoGoogle.End = New EventDateTime() With {.DateTime = evento.EndDateTime, .TimeZone = "America/Mexico_City"}
            eventoGoogle.Visibility = evento.Visibility
            eventoGoogle.Transparency = evento.Transparency

            If evento.RRULE = "" Then
                eventoGoogle.Recurrence = Nothing
            Else
                eventoGoogle.Recurrence = New List(Of String) From {evento.RRULE}
            End If

            eventoGoogle.Attendees = evento.Attendees.Select(Function(a) New EventAttendee() With {.Email = a.Email, .ResponseStatus = a.Status}).ToList()
            ' Configurar asistentes
            'If evento.Attendees IsNot Nothing AndAlso evento.Attendees.Count > 0 Then
            '    eventoGoogle.Attendees = evento.Attendees.Select(Function(a) New EventAttendee() With {.Email = a.Email}).ToList()
            'End If

            ' Configurar notificaciones
            If evento.Reminders IsNot Nothing Then
                eventoGoogle.Reminders = New [Event].RemindersData() With {
                    .UseDefault = False,
                    .Overrides = evento.Reminders.Select(Function(r) New EventReminder() With {.Method = r.Method, .Minutes = r.Minutes}).ToList()
                }
            End If

            ' Actualizar el evento en Google Calendar
            Dim updatedEvent As [Event] = Await service.Events.Update(eventoGoogle, CalendarioID, googleEventId).ExecuteAsync()
        Catch ex As Exception
            Console.WriteLine($"Error al actualizar eventos: {ex.Message}")
        End Try
    End Function

    ' Actualizar status de asistente mediante el eventID y el Email
    Public Async Function ActualizarAsistenteGoogleAsync(service As CalendarService, asistente As Asistente) As Task
        Try
            ' Obtener el evento existente
            Dim eventoGoogle As [Event] = Await service.Events.Get(CalendarioID, asistente.EventID).ExecuteAsync()

            ' Actualizar el estado de respuesta del asistente
            Dim asistenteGoogle As EventAttendee = eventoGoogle.Attendees.FirstOrDefault(Function(a) a.Email = asistente.Email)
            If asistenteGoogle IsNot Nothing Then
                asistenteGoogle.ResponseStatus = asistente.Status
            End If

            ' Actualizar el evento en Google Calendar
            Dim updatedEvent As [Event] = Await service.Events.Update(eventoGoogle, CalendarioID, asistente.EventID).ExecuteAsync()
        Catch ex As Exception
            Console.WriteLine($"Error al actualizar asistente: {ex.Message}")
        End Try
    End Function

    Public Sub SincronizarCalendarios(calendariosGoogle As List(Of Calendario), calendariosLocales As List(Of Calendario))
        Try
            ' Insertar calendarios basado en Google Calendar
            For Each calendarioGoogle In calendariosGoogle
                Dim calendarioLocal As Calendario = calendariosLocales.FirstOrDefault(Function(c) c.CalendarID = calendarioGoogle.CalendarID)
                If calendarioLocal Is Nothing Then
                    ' Insertar nuevo calendario
                    _datosEvento.InsertarCalendario(calendarioGoogle)
                End If
            Next
            ' Eliminar calendarios locales que ya no existen en Google
            For Each calendarioLocal In calendariosLocales
                If Not calendariosGoogle.Any(Function(c) c.CalendarID = calendarioLocal.CalendarID) Then
                    _datosEvento.EliminarCalendario(calendarioLocal.CalendarID)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine($"Error al sincronizar calendarios: {ex.Message}")
        End Try
    End Sub

    Public Sub SincronizarEventos(eventosGoogle As IList(Of [Event]), eventosLocales As List(Of Evento))
        Try
            ' Insertar o actualizar eventos basado en Google Calendar
            For Each eventoGoogle In eventosGoogle
                Dim eventoLocal As Evento = eventosLocales.FirstOrDefault(Function(e) e.EventID = eventoGoogle.Id)
                Dim eventoGoogleConvertido As Evento = ConvertirDeGoogleEventoAEventoLocal(eventoGoogle)
                Dim tolerancia As TimeSpan = TimeSpan.FromSeconds(1)

                If Login.idUsuario <> eventoGoogleConvertido.UserID Then
                    Continue For
                End If
                If eventoLocal Is Nothing Then
                    ' Insertar nuevo evento
                    _datosEvento.InsertarEvento(eventoGoogleConvertido)

                    ' Verificar si hay asistentes antes de intentar iterar
                    If eventoGoogle.Attendees IsNot Nothing Then
                        For Each asistenteGoogle In eventoGoogle.Attendees
                            _datosEvento.InsertarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistenteGoogle.Email, .Status = asistenteGoogle.ResponseStatus})
                            _datosEvento.InsertarMensaje(New Mensaje With {.EventID = eventoGoogleConvertido.EventID, .UserID = _datosEvento.BuscarUserID(asistenteGoogle.Email), .Title = eventoGoogleConvertido.Summary, .StartDateTime = eventoGoogleConvertido.StartDateTime, .EndDateTime = eventoGoogleConvertido.EndDateTime, .SentTime = eventoGoogleConvertido.StartDateTime, .MessageType = "Actualización", .RRULE = eventoGoogleConvertido.RRULE})
                        Next
                    End If

                    ' Verificar si hay recordatorios antes de intentar iterar
                    If eventoGoogle.Reminders IsNot Nothing AndAlso eventoGoogle.Reminders.Overrides IsNot Nothing Then
                        For Each recordatorioGoogle In eventoGoogle.Reminders.Overrides
                            _datosEvento.InsertarNotificacion(New Notificacion With {.EventID = eventoGoogleConvertido.EventID, .Method = recordatorioGoogle.Method, .Minutes = recordatorioGoogle.Minutes})
                        Next
                    End If
                ElseIf eventoGoogle.Updated.HasValue AndAlso (eventoGoogle.Updated.Value - eventoLocal.LastModified) > tolerancia Then
                    ' Actualizar evento existente
                    _datosEvento.ActualizarEvento(eventoGoogleConvertido)

                    ' Actualizar asistentes
                    ' Primero, manejar el caso donde el evento de Google no tiene asistentes
                    If eventoGoogle.Attendees Is Nothing Then
                        If eventoLocal.Attendees IsNot Nothing AndAlso eventoLocal.Attendees.Count > 0 Then
                            ' Eliminar todos los asistentes locales ya que el evento de Google ya no tiene asistentes
                            For Each asistenteLocal In eventoLocal.Attendees
                                _datosEvento.EliminarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistenteLocal.Email})
                            Next
                        End If
                        ' Si el evento de Google tiene asistentes
                    Else
                        'Dim googleAttendeesEmails = eventoGoogle.Attendees.Select(Function(a) a.Email.ToLower()).ToList()
                        Dim googleAttendees = eventoGoogle.Attendees.Select(Function(a) New Asistente With {.Email = a.Email, .Status = a.ResponseStatus}).ToList()

                        ' Si el evento local no tiene asistentes
                        If eventoLocal.Attendees Is Nothing OrElse eventoLocal.Attendees.Count = 0 Then
                            ' Agregar todos los asistentes de Google al evento local
                            For Each asistente In googleAttendees
                                _datosEvento.InsertarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistente.Email, .Status = asistente.Status})
                                _datosEvento.InsertarMensaje(New Mensaje With {.EventID = eventoGoogleConvertido.EventID, .UserID = _datosEvento.BuscarUserID(asistente.Email), .Title = eventoGoogleConvertido.Summary, .StartDateTime = eventoGoogleConvertido.StartDateTime, .EndDateTime = eventoGoogleConvertido.EndDateTime, .SentTime = eventoGoogleConvertido.StartDateTime, .MessageType = "Actualización", .RRULE = eventoGoogleConvertido.RRULE})
                            Next
                        Else
                            Dim localAttendeesEmails = eventoLocal.Attendees.Select(Function(a) a.Email.ToLower()).ToList()

                            ' Identificar y agregar nuevos asistentes
                            For Each asistente In googleAttendees.Where(Function(a) Not localAttendeesEmails.Contains(a.Email))
                                _datosEvento.InsertarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistente.Email, .Status = asistente.Status})
                                _datosEvento.InsertarMensaje(New Mensaje With {.EventID = eventoGoogleConvertido.EventID, .UserID = _datosEvento.BuscarUserID(asistente.Email), .Title = eventoGoogleConvertido.Summary, .StartDateTime = eventoGoogleConvertido.StartDateTime, .EndDateTime = eventoGoogleConvertido.EndDateTime, .SentTime = eventoGoogleConvertido.StartDateTime, .MessageType = "Actualización", .RRULE = eventoGoogleConvertido.RRULE})
                            Next

                            ' Identificar y eliminar asistentes que ya no están en Google
                            For Each asistenteLocal In eventoLocal.Attendees.Where(Function(a) Not googleAttendees.Any(Function(ga) ga.Email = a.Email))
                                _datosEvento.EliminarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistenteLocal.Email})
                            Next

                            ' Actualiza el estado de respuesta para los asistentes existentes
                            For Each asistenteGoogle In googleAttendees
                                Dim asistenteLocal = eventoLocal.Attendees.FirstOrDefault(Function(a) a.Email = asistenteGoogle.Email)
                                If asistenteLocal IsNot Nothing AndAlso asistenteLocal.Status <> asistenteGoogle.Status Then
                                    ' Actualiza el estado de respuesta en la base de datos
                                    _datosEvento.ActualizarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = asistenteLocal.Email, .Status = asistenteGoogle.Status})
                                End If
                            Next
                        End If
                    End If


                    ' Actualizar notificaciones
                    ' Limpiar y reconstruir notificaciones
                    ' Eliminar todas las notificaciones existentes para este evento
                    _datosEvento.EliminarTodasNotificacionesPorEvento(eventoGoogleConvertido.EventID)

                    ' Reconstruir notificaciones basadas en la información actual de Google
                    If eventoGoogle.Reminders IsNot Nothing AndAlso eventoGoogle.Reminders.Overrides IsNot Nothing Then
                        For Each recordatorioGoogle In eventoGoogle.Reminders.Overrides
                            _datosEvento.InsertarNotificacion(New Notificacion With {
                            .EventID = eventoGoogleConvertido.EventID,
                            .Method = recordatorioGoogle.Method,
                            .Minutes = recordatorioGoogle.Minutes
                        })
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            Console.WriteLine($"Error al sincronizar eventos: {ex.Message}")
        End Try

        Try
            For Each eventoLocal In eventosLocales
                If Not eventosGoogle.Any(Function(e) e.Id = eventoLocal.EventID) Then
                    ' Marcar como eliminado o eliminar
                    _datosEvento.EliminarEvento(eventoLocal.EventID)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine($"Error al sincronizar eventos: {ex.Message}")
        End Try

    End Sub

    Public Function ConvertirDeGoogleEventoAEventoLocal(eventoGoogle As [Event]) As Evento
        Try
            Dim evento As New Evento With {
            .EventID = eventoGoogle.Id,
            .CalendarID = CalendarioID,
            .UserID = _datosEvento.BuscarUserID(eventoGoogle.Creator.Email.ToString()),
            .Summary = If(eventoGoogle.Summary Is Nothing, "No Title", eventoGoogle.Summary),
            .Location = eventoGoogle.Location,
            .Description = eventoGoogle.Description,
            .StartDateTime = If(eventoGoogle.Start.DateTime.HasValue, eventoGoogle.Start.DateTime.Value, DateTime.Parse(eventoGoogle.Start.Date)),
            .EndDateTime = If(eventoGoogle.End.DateTime, DateTime.Parse(eventoGoogle.End.Date)),
            .RRULE = eventoGoogle.Recurrence?.FirstOrDefault(),
            .Visibility = eventoGoogle.Visibility,
            .Transparency = eventoGoogle.Transparency,
            .LastModified = eventoGoogle.Updated
            }

            If evento.Visibility Is Nothing Then
                evento.Visibility = "default" ' Valor predeterminado
            End If

            If evento.Transparency Is Nothing Then
                evento.Transparency = "opaque" ' Valor predeterminado
            End If

            If eventoGoogle.Attendees IsNot Nothing Then
                evento.Attendees = eventoGoogle.Attendees.Select(Function(a) New Asistente With {.Email = a.Email, .Status = a.ResponseStatus}).ToList()
            End If

            If eventoGoogle.Reminders IsNot Nothing AndAlso eventoGoogle.Reminders.Overrides IsNot Nothing Then
                evento.Reminders = eventoGoogle.Reminders.Overrides.Select(Function(r) New Notificacion With {.Method = r.Method, .Minutes = r.Minutes}).ToList()
            End If

            Return evento

        Catch ex As Exception
            Console.WriteLine($"Error al convertir evento de Google a evento local: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' Función para obtener los eventos de google en una lista de tipo [Event]
    Public Async Function ObtenerEventosGoogleAsync(service As CalendarService, calendarId As String) As Task(Of IList(Of [Event]))
        Try
            Dim request As EventsResource.ListRequest = service.Events.List(calendarId)


            request.ShowDeleted = False
            request.SingleEvents = False
            request.TimeMinDateTimeOffset = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, DateTimeKind.Utc) ' AQUI LA API SE COMPORTA DE ESTA FORMA, LA FECHA FINAL DE LA RECURRENCIA AFECTA LOS EVENTOS QUE SE OBTIENEN
            'request.TimeMaxDateTimeOffset = New DateTime(DateTime.Now.Year + 1, 12, 31, 23, 59, 59, DateTimeKind.Utc)
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.Updated

            Dim events As Events = Await request.ExecuteAsync()

            ' Filtrar los eventos para excluir aquellos con el estado "cancelled"
            Dim eventosFiltrados As List(Of [Event]) = events.Items.Where(Function(e) e.Status <> "cancelled").ToList()
            Return eventosFiltrados
        Catch ex As Exception
            Console.WriteLine($"Error al obtener eventos de Google: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Public Sub EliminarEventoGoogle(eventID As String)
        Try
            Dim service As CalendarService = Authenticate()
            service.Events.Delete(CalendarioID, eventID).ExecuteAsync()
        Catch ex As Exception
            Console.WriteLine($"Error al eliminar evento de Google: {ex.Message}")
        End Try
    End Sub
End Class