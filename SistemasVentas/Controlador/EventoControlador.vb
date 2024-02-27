Imports System.Threading.Tasks
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data

Public Class EventoControlador
    Private _servicioGoogleCalendar As GoogleCalendarService
    Private _datosEvento As EventoData
    Public Property GoogleEventID As String = String.Empty
    Public Sub New()
        _servicioGoogleCalendar = New GoogleCalendarService()
        _datosEvento = New EventoData()
    End Sub

    Public Sub CrearEvento(evento As Evento)
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If GestionEventos.btnCrearEvento.Visible = True Then
            _datosEvento.InsertarEvento(evento)
        Else
            _datosEvento.ActualizarEvento(evento)
        End If
    End Sub

    Public Sub EliminarEvento(eventID As String)
        _datosEvento.EliminarEvento(eventID)
    End Sub

    Public Sub CrearRecurrencia(recurrencia As Recurrencia)
        Dim errores As List(Of String) = recurrencia.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If GestionEventos.btnCrearEvento.Visible = True Then
            _datosEvento.InsertarRecurrencia(recurrencia)
        Else
            _datosEvento.ActualizarRecurrencia(recurrencia)
        End If
    End Sub

    Public Sub InsertarAsistente(asistente As Asistente, isDuplicado As Boolean)
        Dim err As Boolean = isDuplicado
        If err Then
            MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _datosEvento.InsertarAsistente(asistente)
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
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()
        Dim eventoGoogle As [Event] = _servicioGoogleCalendar.ConvertirAModeloGoogleCalendar(evento)

        Dim calendarId As String = GestionEventos.CalendarioID
        Dim createdEvent As [Event] = service.Events.Insert(eventoGoogle, calendarId).Execute()
        GoogleEventID = createdEvent.Id
        Console.WriteLine($"Evento creado: {createdEvent.HtmlLink}")
    End Sub

    Public Async Sub AgregarInformacionEvento(evento As Evento, recurrencia As Recurrencia)
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()
        If GestionEventos.btnCrearEvento.Visible = True Then
            Await _servicioGoogleCalendar.ActualizarEventoGoogleAsync(service, GoogleEventID, recurrencia, evento)
        Else
            Await _servicioGoogleCalendar.ActualizarEventoGoogleAsync(service, GestionEventos.EventoID, recurrencia, evento)
        End If

    End Sub

    Public Async Function ObtenerEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()

        Dim eventosGoogle As IList(Of [Event]) = Await _servicioGoogleCalendar.ObtenerEventosGoogleAsync(service, GestionEventos.CalendarioID)
        Return eventosGoogle
    End Function

    Public Function ObtenerEventosLocales() As List(Of Evento)
        Dim eventosTable As DataTable = _datosEvento.MostrarEventos(GestionEventos.CalendarioID)
        Dim recurencias As List(Of Recurrencia) = _datosEvento.ObtenerTodasRecurrencias()
        Dim asistentes As List(Of Asistente) = _datosEvento.ObtenerTodosAsistentes()
        Dim notificaciones As List(Of Notificacion) = _datosEvento.ObtenerTodasNotificaciones()

        Return TransformarAEvento(eventosTable, recurencias, asistentes, notificaciones)
    End Function

    Public Async Function SincronizarEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()
        Dim eventosLocales As List(Of Evento) = ObtenerEventosLocales()
        Dim eventosGoogle As IList(Of [Event]) = Await ObtenerEventosAsync()

        Await _servicioGoogleCalendar.SincronizarEventosAsync(service, eventosGoogle, eventosLocales)
    End Function


    Public Function TransformarAEvento(eventosTable As DataTable, recurrencias As List(Of Recurrencia), asistentes As List(Of Asistente), notificaciones As List(Of Notificacion)) As List(Of Evento)
        Dim eventos As New List(Of Evento)
        For Each row As DataRow In eventosTable.Rows
            Dim evento As New Evento With {
                .EventID = row(0).ToString(),
                .Summary = row(1).ToString(),
                .Location = row(2).ToString(),
                .Description = row(3).ToString(),
                .StartDateTime = row(4).ToString(),
                .EndDateTime = row(5).ToString(),
                .Visibility = row(6).ToString(),
                .Transparency = row(7).ToString(),
                .LastModified = row(8).ToString()
            }
            evento.Recurrence = recurrencias.Where(Function(r) r.EventID.Equals(evento.EventID)).ToList()
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

    Public Function ObtenerCalendarios() As List(Of List(Of String))
        Return _datosEvento.ObtenerCalendarios()
    End Function

    Public Function ObtenerEventos(calendarioID As String) As DataTable
        Return _datosEvento.MostrarEventos(calendarioID)
    End Function

    Public Function ObtenerRecurrencia(eventID As String) As String
        Return _datosEvento.MostrarRecurrencias(eventID)
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
End Class
