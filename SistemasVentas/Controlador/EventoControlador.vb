Imports System.Threading.Tasks
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Gmail.v1

Public Class EventoControlador
    Private _googleServicesAuthenticator As GoogleServicesAuthenticator
    Private _servicioGoogleCalendar As GoogleCalendarService
    Private _servicioGoogleGmail As GoogleGmailService
    Private _datosEvento As EventoData
    Public Property GoogleEventID As String = String.Empty
    Public Property GoogleCalendarID As String

    Public Sub New()
        _googleServicesAuthenticator = New GoogleServicesAuthenticator()
        _servicioGoogleCalendar = New GoogleCalendarService()
        _servicioGoogleGmail = New GoogleGmailService()
        _datosEvento = New EventoData()
    End Sub

    Public Sub CrearEvento(evento As Evento, isVisible As Boolean)
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If isVisible = True Then
            _datosEvento.InsertarEvento(evento)

        Else
            ' FALTA IMPLEMENTAR CUANDO SE ACTUALIZA UN EVENTO Y CAMBIAN LOS CAMPOS DE TITULO, DESCRIPCIÓN, ETC. PARA EL MENSAJE
            _datosEvento.ActualizarEvento(evento)
        End If
    End Sub

    Public Sub CrearMensaje(mensaje As Mensaje)
        For Each attendee In mensaje.Attendees
            mensaje.AttendeeID = BuscarUserID(attendee)
            _datosEvento.InsertarMensaje(mensaje)
        Next
        EnviarEmail(mensaje)
    End Sub

    Public Sub ActualizarMensaje(mensaje As Mensaje)
        For Each attendee In mensaje.Attendees
            mensaje.AttendeeID = BuscarUserID(attendee)
            _datosEvento.ActualizarMensaje(mensaje)
        Next
        EnviarEmail(mensaje)
    End Sub

    Public Function CrearRecurrencia(recurrencia As Recurrencia) As Boolean
        Dim errores As List(Of String) = recurrencia.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Public Sub EliminarEvento(eventID As String)
        _datosEvento.EliminarEvento(eventID)
        _servicioGoogleCalendar.EliminarEventoGoogle(eventID)
    End Sub

    Public Sub InsertarAsistente(asistente As Asistente, gestionEventos As GestionEventos)
        gestionEventos.AsistenteID = _datosEvento.InsertarAsistente(asistente)
    End Sub

    Public Sub EliminarAsistente(asistente As Asistente)
        _datosEvento.EliminarAsistente(asistente)
    End Sub

    Public Sub InsertarNotificacion(notificacion As Notificacion)
        _datosEvento.InsertarNotificacion(notificacion)
    End Sub

    Public Sub ActualizarNotificacion(notificacion As Notificacion)
        _datosEvento.ActualizarNotificacion(notificacion)
    End Sub

    Public Sub EliminarNotificacion(reminderID As Integer)
        _datosEvento.EliminarNotificacion(reminderID)
    End Sub

    Public Sub EnviarEventoAGoogleCalendar(evento As Evento)
        Dim service As CalendarService = _googleServicesAuthenticator.ObtenerServicioCalendar()
        Dim eventoGoogle As [Event] = _servicioGoogleCalendar.ConvertirAModeloGoogleCalendar(evento)

        Dim calendarId As String = GoogleCalendarID
        Dim createdEvent As [Event] = service.Events.Insert(eventoGoogle, calendarId).Execute()
        GoogleEventID = createdEvent.Id
        Console.WriteLine($"Evento creado: {createdEvent.HtmlLink}")
    End Sub

    Public Async Sub AgregarInformacionEvento(evento As Evento, IsNew As Boolean)
        Dim service As CalendarService = _googleServicesAuthenticator.ObtenerServicioCalendar()
        If IsNew And evento.Attendees.Count > 0 Then
            CrearMensaje(evento.Message)
        ElseIf Not IsNew And evento.Attendees.Count > 0 Then
            ActualizarMensaje(evento.Message)
        End If
        Await _servicioGoogleCalendar.ActualizarEventoGoogleAsync(service, GoogleEventID, evento)
    End Sub

    Public Sub EnviarEmail(mensaje As Mensaje)
        Dim service As GmailService = _googleServicesAuthenticator.ObtenerServicioGmail()
        _servicioGoogleGmail.EnviarMensajeMail(service, mensaje)
    End Sub

    Public Async Function ObtenerEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _googleServicesAuthenticator.ObtenerServicioCalendar()

        Dim eventosGoogle As IList(Of [Event]) = Await _servicioGoogleCalendar.ObtenerEventosGoogleAsync(service, GoogleCalendarID)
        Return eventosGoogle
    End Function

    Public Function ObtenerEventosLocales() As List(Of Evento)
        Dim eventosTable As DataTable = _datosEvento.MostrarEventos(GoogleCalendarID)
        Dim asistentes As List(Of Asistente) = _datosEvento.ObtenerTodosAsistentes()
        Dim notificaciones As List(Of Notificacion) = _datosEvento.ObtenerTodasNotificaciones()

        Return TransformarAEvento(eventosTable, asistentes, notificaciones)
    End Function

    Public Async Function SincronizarEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _googleServicesAuthenticator.ObtenerServicioCalendar()
        Dim eventosLocales As List(Of Evento) = ObtenerEventosLocales()
        Dim eventosGoogle As IList(Of [Event]) = Await ObtenerEventosAsync()

        _servicioGoogleCalendar.SincronizarEventos(eventosGoogle, eventosLocales)
    End Function


    Public Function TransformarAEvento(eventosTable As DataTable, asistentes As List(Of Asistente), notificaciones As List(Of Notificacion)) As List(Of Evento)
        Dim eventos As New List(Of Evento)
        For Each row As DataRow In eventosTable.Rows
            Dim evento As New Evento With {
                .EventID = row(0).ToString(),
                .Summary = row(1).ToString(),
                .Location = row(2).ToString(),
                .Description = row(3).ToString(),
                .StartDateTime = row(4).ToString(),
                .EndDateTime = row(5).ToString(),
                .RRULE = row(6).ToString(),
                .Visibility = row(7).ToString(),
                .Transparency = row(8).ToString(),
                .LastModified = row(9).ToString()
            }
            evento.Attendees = asistentes.Where(Function(a) a.EventID.Equals(evento.EventID)).ToList()
            evento.Reminders = notificaciones.Where(Function(n) n.EventID.Equals(evento.EventID)).ToList()
            eventos.Add(evento)
        Next
        Return eventos

    End Function

    ' MÉTODOS AUXILIARES
    Public Function ConvertirUnidadATiempo(unidad As String, cantidad As Integer) As Integer
        Select Case unidad
            Case "Minutos"
                Return cantidad
            Case "Horas"
                Return cantidad * 60 ' 1 hora = 60 minutos
            Case "Días"
                Return cantidad * 1440 ' 1 día = 24 horas * 60 minutos
            Case "Semanas"
                Return cantidad * 10080 ' 1 semana = 7 días * 24 horas * 60 minutos
            Case Else
                Throw New ArgumentException("Unidad de tiempo no soportada.")
        End Select
    End Function

    Public Function ObtenerCalendarios(idUsuario As String) As List(Of List(Of String))
        Return _datosEvento.ObtenerCalendarios(idUsuario)
    End Function

    Public Function ObtenerEventos(calendarioID As String) As DataTable
        Return _datosEvento.MostrarEventos(calendarioID)
    End Function

    Public Function ObtenerNombreAsistente(email As String) As String
        Return _datosEvento.ObtenerNombreInvitado(email)
    End Function

    Public Function ObtenerAsistentesInvitados(eventID As String) As List(Of String)
        Return _datosEvento.MostrarAsistentesInvitados(eventID)
    End Function

    Public Function ObtenerNotificacionesActivas(eventID As String) As List(Of Notificacion)
        Return _datosEvento.MostrarNotificacionesActivas(eventID)
    End Function
    Public Function ObtenerCorreosAsistentesExcepto(email As String) As List(Of String)
        Return _datosEvento.ObtenerCorreosUsuarioExcepto(email)
    End Function

    Public Function ObtenerCorreoUsuario() As String
        Return _datosEvento.ObtenerCorreoUsuario()
    End Function

    Public Function BuscarUserID(invitado As String) As Integer
        Return _datosEvento.BuscarUserID(invitado)
    End Function
End Class
