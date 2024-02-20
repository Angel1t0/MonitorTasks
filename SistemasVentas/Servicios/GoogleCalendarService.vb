Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

' Clase para manejar la autenticación y creación del servicio de Google Calendar.
Public Class GoogleCalendarService

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

            ' Configurar la recurrencia
            If recurrencia IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(recurrencia.RRULE) Then
                eventoGoogle.Recurrence = New List(Of String) From {recurrencia.RRULE}
            End If

            ' Configurar asistentes
            If evento.Attendees IsNot Nothing AndAlso evento.Attendees.Count > 0 Then
                eventoGoogle.Attendees = evento.Attendees.Select(Function(a) New EventAttendee() With {.Email = a.Email}).ToList()
            End If

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


    Public Async Function ObtenerEventosAsync(service As CalendarService, calendarId As String) As Task(Of IList(Of Evento))
        Dim request As EventsResource.ListRequest = service.Events.List(calendarId)
        Dim eventos As New List(Of Evento)

        request.TimeMin = DateTime.Now
        request.ShowDeleted = False
        request.SingleEvents = True
        request.MaxResults = 10
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime

        Try
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