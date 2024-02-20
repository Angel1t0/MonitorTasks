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
        _datosEvento.InsertarEvento(evento)
    End Sub

    Public Sub CrearRecurrencia(recurrencia As Recurrencia)
        Dim errores As List(Of String) = recurrencia.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _datosEvento.InsertarRecurrencia(recurrencia)
    End Sub

    Public Sub InsertarAsistente(asistente As Asistente, isDuplicado As Boolean)
        Dim err As Boolean = isDuplicado
        If err Then
            MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _datosEvento.InsertarAsistente(asistente)
    End Sub

    Public Sub InsertarNotificacion(notificacion As Notificacion)
        _datosEvento.InsertarNotificacion(notificacion)
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
        Await _servicioGoogleCalendar.ActualizarEventoGoogleAsync(service, GoogleEventID, recurrencia, evento)
    End Sub

    ' Método para mostrar eventos por el id del calendario sacado de la base de datos, aún en proceso
    Public Sub MostrarEventosPorCalendarioID(idCalendario As String)
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()
        Dim events As Events = service.Events.List(idCalendario).Execute()
        Console.WriteLine("Eventos:")
        If events.Items IsNot Nothing AndAlso events.Items.Count > 0 Then
            For Each eventItem As [Event] In events.Items
                Console.WriteLine(eventItem.Summary)
            Next
        Else
            Console.WriteLine("No se encontraron eventos.")
        End If
    End Sub

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

    Public Function ObtenerNombreAsistente(email As String) As String
        Return _datosEvento.ObtenerNombreInvitado(email)
    End Function

    Public Function ObtenerCorreosAsistentesExcepto(email As String) As List(Of String)
        Return _datosEvento.ObtenerCorreosUsuarioExcepto(email)
    End Function

    Public Function ObtenerCorreoUsuario() As String
        Return _datosEvento.ObtenerCorreoUsuario()
    End Function
End Class
