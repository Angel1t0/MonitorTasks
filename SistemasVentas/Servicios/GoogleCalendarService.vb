Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms.VisualStyles

' Clase para manejar la autenticación y creación del servicio de Google Calendar.
Public Class GoogleCalendarService
    Private _datosEvento As EventoData
    Public Sub New()
        _datosEvento = New EventoData()
    End Sub

    ' Scopes define el nivel de acceso que necesitas sobre la cuenta de Google del usuario.
    Private Scopes As String() = {CalendarService.Scope.Calendar}

    ' ApplicationName es el nombre de tu aplicación. Este nombre se muestra durante el proceso de autenticación.
    Private ApplicationName As String = "Monitor task - Prueba"

    ' Método que maneja la autenticación y crea un servicio de Google Calendar.
    Public Function Authenticate() As CalendarService
        Dim credential As UserCredential

        ' Carga el archivo de credenciales descargado de Google Cloud Console.
        Using stream As New FileStream("D:\angel\Downloads\client_secret_904108627701-bc7vsuctjhehlpou2tjof9g6c483s9n6.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read)
            ' El camino donde el token de acceso será guardado.
            Dim credPath As String = "D:\angel\Documentos\Residencias\SistemasVentas\SistemasVentas\Recursos\token.json"

            ' Solicita la autenticación del usuario. Si el token ya existe y es válido, no se solicitará autenticación.
            ' De lo contrario, abrirá una ventana del navegador para que el usuario inicie sesión en su cuenta de Google y autorice el acceso.
            Try
                ' Solicita la autenticación del usuario. Si el token ya existe, reutiliza ese token.
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    New FileDataStore(credPath, True)).Result

                Console.WriteLine("Credential file saved to: " & credPath)
            Catch ex As Exception
                Throw New ApplicationException("Error al autenticar con Google Calendar.", ex)
            End Try
        End Using

        ' Crea el servicio de Google Calendar usando las credenciales autenticadas.
        ' Este servicio es el que utilizarás para realizar llamadas a la API de Google Calendar.
        Dim service As New CalendarService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential, ' Inicializa el cliente HTTP con las credenciales autenticadas.
            .ApplicationName = ApplicationName ' Establece el nombre de la aplicación.
        })

        Return service ' Devuelve el servicio autenticado para ser usado en otras partes de tu aplicación.
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

    Public Async Function ActualizarEventoGoogleAsync(service As CalendarService, googleEventId As String, recurrencia As Recurrencia, evento As Evento) As Task
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

            ' Configurar la recurrencia
            If recurrencia IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(recurrencia.RRULE) Then
                eventoGoogle.Recurrence = New List(Of String) From {recurrencia.RRULE}
            End If

            eventoGoogle.Attendees = evento.Attendees.Select(Function(a) New EventAttendee() With {.Email = a.Email}).ToList()
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
            Dim updatedEvent As [Event] = Await service.Events.Update(eventoGoogle, "primary", googleEventId).ExecuteAsync()
        Catch ex As Exception
            Console.WriteLine($"Error al actualizar eventos: {ex.Message}")
        End Try
    End Function

    Public Async Function SincronizarEventosAsync(service As CalendarService, eventosGoogle As IList(Of [Event]), eventosLocales As List(Of Evento)) As Task
        Try
            ' Insertar o actualizar eventos basado en Google Calendar
            For Each eventoGoogle In eventosGoogle
                Dim eventoLocal As Evento = eventosLocales.FirstOrDefault(Function(e) e.EventID = eventoGoogle.Id)
                Dim eventoGoogleConvertido As Evento = ConvertirDeGoogleEventoAEventoLocal(eventoGoogle)
                If eventoLocal Is Nothing Then
                    ' Insertar nuevo evento
                    _datosEvento.InsertarEvento(eventoGoogleConvertido)

                    _datosEvento.InsertarRecurrencia(New Recurrencia With {.EventID = eventoGoogleConvertido.EventID, .RRULE = eventoGoogleConvertido.Recurrence.First().RRULE})

                    If eventoGoogle.Attendees IsNot Nothing Then
                        eventoGoogle.Attendees.ToList().ForEach(Sub(a) _datosEvento.InsertarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = a.Email}))
                    End If

                    If eventoGoogle.Reminders IsNot Nothing AndAlso eventoGoogle.Reminders.Overrides IsNot Nothing Then
                        eventoGoogle.Reminders.Overrides.ToList().ForEach(Sub(r) _datosEvento.InsertarNotificacion(New Notificacion With {.EventID = eventoGoogleConvertido.EventID, .Method = r.Method, .Minutes = r.Minutes}))
                    End If

                ElseIf eventoGoogle.Updated.HasValue AndAlso eventoGoogle.Updated.Value > eventoLocal.LastModified Then
                    ' Actualizar evento existente

                    _datosEvento.ActualizarEvento(eventoGoogleConvertido)
                    _datosEvento.ActualizarRecurrencia(New Recurrencia With {.EventID = eventoGoogleConvertido.EventID, .RRULE = eventoGoogleConvertido.Recurrence.First().RRULE})

                    If eventoGoogle.Attendees IsNot Nothing Then
                        eventoGoogle.Attendees.ToList().ForEach(Sub(a) _datosEvento.InsertarAsistente(New Asistente With {.EventID = eventoGoogleConvertido.EventID, .Email = a.Email}))
                    End If

                    If eventoGoogle.Reminders IsNot Nothing AndAlso eventoGoogle.Reminders.Overrides IsNot Nothing Then
                        Dim aux As Integer = 0
                        For Each r In eventoGoogle.Reminders.Overrides
                            _datosEvento.ActualizarNotificacion(New Notificacion With {
                                .ReminderID = eventoLocal.Reminders(aux).ReminderID,
                                .Method = r.Method,
                                .Minutes = r.Minutes
                            })
                            aux += 1
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

    End Function

    Public Function ConvertirDeGoogleEventoAEventoLocal(eventoGoogle As [Event]) As Evento
        Try
            Dim evento As New Evento With {
            .EventID = eventoGoogle.Id,
            .CalendarID = GestionEventos.CalendarioID,
            .Summary = eventoGoogle.Summary,
            .Location = eventoGoogle.Location,
            .Description = eventoGoogle.Description,
            .StartDateTime = If(eventoGoogle.Start.DateTime.HasValue, eventoGoogle.Start.DateTime.Value, DateTime.Parse(eventoGoogle.Start.Date)),
            .EndDateTime = If(eventoGoogle.End.DateTime.HasValue, eventoGoogle.End.DateTime.Value, DateTime.Parse(eventoGoogle.End.Date)),
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

            If eventoGoogle.Recurrence IsNot Nothing Then
                evento.Recurrence = eventoGoogle.Recurrence.Select(Function(r) New Recurrencia With {.RRULE = r}).ToList()
            Else
                ' Asignar un valor predeterminado de recurrencia
                Dim recurrenciaPredeterminada As New Recurrencia With {
                    .RRULE = "RRULE:FREQ=DAILY;COUNT=3"
                }
                evento.Recurrence = New List(Of Recurrencia) From {recurrenciaPredeterminada}
            End If

            If eventoGoogle.Attendees IsNot Nothing Then
                evento.Attendees = eventoGoogle.Attendees.Select(Function(a) New Asistente With {.Email = a.Email, .DisplayName = "Invitado"}).ToList()
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
        Dim request As EventsResource.ListRequest = service.Events.List(calendarId)

        request.ShowDeleted = False
        request.SingleEvents = False
        request.MaxResults = 50
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.Updated

        Dim events As Events = Await request.ExecuteAsync()

        ' Filtrar los eventos para excluir aquellos con el estado "cancelled"
        Dim eventosFiltrados As List(Of [Event]) = events.Items.Where(Function(e) e.Status <> "cancelled").ToList()

        Return eventosFiltrados
    End Function




    Public Async Function ConvertirEventosGoogle(service As CalendarService, calendarId As String) As Task(Of IList(Of [Event]))
        Dim request As EventsResource.ListRequest = service.Events.List(calendarId)
        Dim eventos As New List(Of Evento)

        request.TimeMin = DateTime.Now
        request.ShowDeleted = False
        request.SingleEvents = True
        request.MaxResults = 20
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime

        Try
            Dim recurrencia As New Recurrencia()
            Dim events As Events = Await request.ExecuteAsync()
            For Each e In events.Items
                Dim evento As New Evento With {
                    .EventID = e.Id,
                    .Summary = e.Summary,
                    .Location = e.Location,
                    .Description = e.Description,
                    .StartDateTime = e.Start.DateTime,
                    .EndDateTime = e.End.DateTime,
                    .Visibility = e.Visibility,
                    .Transparency = e.Transparency,
                    .LastModified = e.Updated
                }

                If e.Recurrence IsNot Nothing Then
                    evento.Recurrence = e.Recurrence.Select(Function(r) New Recurrencia With {.RRULE = r}).ToList()
                End If

                If e.Attendees IsNot Nothing Then
                    evento.Attendees = e.Attendees.Select(Function(a) New Asistente With {.Email = a.Email}).ToList()
                End If

                If e.Reminders IsNot Nothing AndAlso e.Reminders.Overrides IsNot Nothing Then
                    evento.Reminders = e.Reminders.Overrides.Select(Function(r) New Notificacion With {.Method = r.Method, .Minutes = r.Minutes}).ToList()
                End If

                eventos.Add(evento)
            Next

        Catch ex As Exception
            Console.WriteLine($"Error al obtener eventos: {ex.Message}")
        End Try

        Return eventos
    End Function

End Class