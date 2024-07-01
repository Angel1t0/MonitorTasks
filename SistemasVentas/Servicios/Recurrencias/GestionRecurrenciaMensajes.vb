Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports System.Threading.Tasks
Imports System.Timers

Public Class GestionRecurrenciaMensajes
    Private WithEvents _timer As Timer
    Private _eventoControlador As ControladorEvento
    Private _calendarioID As String
    Private _determinarRecurrencia As DeterminarRecurrencia

    Public Sub New(calendarID As String)
        _timer = New Timer With {
            .Interval = 1800000, ' Revisar cada 30 minutos si es hora de mandar una notificación
            .AutoReset = True
            }

        AddHandler _timer.Elapsed, AddressOf OnTimedEvent

        _eventoControlador = New ControladorEvento()
        _calendarioID = calendarID
        _determinarRecurrencia = New DeterminarRecurrencia()
    End Sub

    Public Sub Iniciar()
        _timer.Start()
    End Sub
    Public Sub Detener()
        _timer.Stop()
    End Sub
    Private Sub OnTimedEvent(sender As Object, e As ElapsedEventArgs)
        ' Aquí es donde llamarías a la función que verifica si es hora de enviar el correo.
        VerificarYEnviarCorreos()
    End Sub

    Private Sub VerificarYEnviarCorreos()
        ' 1. Obtener la lista de eventos y mensajes
        ' 2. Para cada evento, verificar si corresponde enviar algún mensaje basado en su recurrencia
        ' 3. Si es así, enviar el mensaje
        Try
            _eventoControlador.SincronizarItemsAsync(_eventoControlador.ObtenerEventosConPodio(_calendarioID), _calendarioID)
            Dim eventosYMensajesData As List(Of EventoYMensajes) = _eventoControlador.ObtenerEventosYMensajes(_calendarioID)
            If eventosYMensajesData.Count = 0 Then
                Return
            End If
            Dim horaActual As DateTime = DateTime.Now
            For Each eventoYMensajes In eventosYMensajesData
                Dim listaOcurriencias As List(Of Occurrence) = _determinarRecurrencia.ParsearRRULE(eventoYMensajes.Mensaje)
                If eventoYMensajes.Mensaje.FechaEnviado.Date = Nothing Then
                    eventoYMensajes.Mensaje.FechaEnviado = eventoYMensajes.Mensaje.FechaInicio
                End If
                For Each ocurrencia In listaOcurriencias
                    If ocurrencia.Period.StartTime.AsSystemLocal.Date <= horaActual.Date And
                        eventoYMensajes.Mensaje.FechaEnviado.Date < ocurrencia.Period.StartTime.AsSystemLocal.Date Then

                        eventoYMensajes.Mensaje.FechaEnviado = ocurrencia.Period.StartTime.AsSystemLocal

                        ' Actualizar la fecha de envío en la base de datos para evitar enviar el correo más de una vez
                        _eventoControlador.ActualizarFechaEnvio(eventoYMensajes.Mensaje.MensajeID, eventoYMensajes.Mensaje.FechaEnviado)

                        ' Aquí es donde se llaman a las funciones para enviar el correo, WhatsApp y notificación de escritorio
                        If eventoYMensajes.Mensaje.EmailSilenciado = False Then
                            _eventoControlador.EnviarEmail(eventoYMensajes.Mensaje)
                        End If
                        If eventoYMensajes.Mensaje.WhatsAppSilenciado = False Then
                            _eventoControlador.EnviarWhatsApp(eventoYMensajes.Mensaje)
                            Console.WriteLine("Notificación de Whatsapp enviada")
                        End If
                        If eventoYMensajes.Mensaje.DesktopSilenciado = False Then
                            _eventoControlador.EnviarNotificacionDesktop(eventoYMensajes.Mensaje, eventoYMensajes.Evento.UserID)
                            Console.WriteLine("Notificación de escritorio enviada")
                        End If

                    End If
                Next
            Next
        Catch ex As Exception
            Console.WriteLine("Error al verificar y enviar correos: " & ex.Message)
        End Try
    End Sub

End Class
