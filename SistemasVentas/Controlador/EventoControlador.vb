Imports System.Diagnostics.Eventing.Reader
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Gmail.v1
Imports Newtonsoft.Json.Linq

' Esta clase maneja la gestion de eventos, mensajes y elementos de Podio
Public Class ControladorEvento
    Private _autenticadorServiciosGoogle As AutenticadorServiciosGoogle
    Private _servicioGoogleCalendar As ServicioGoogleCalendar
    Private _servicioGoogleGmail As ServicioGoogleGmail
    Private _servicioWhatsapp As ServicioWhatsapp
    Private _servicioDesktop As ServicioDesktop
    Private _servicioPodio As ServicioPodio
    Private _datosEvento As DatosEvento
    Public Property GoogleEventoID As String = String.Empty
    Public Property GoogleCalendarioID As String

    ' Función auxiliar para establecer el ID del calendario de Google
    Public Sub EstablecerCalendarioID(calendarID As String)
        GoogleCalendarioID = calendarID
        _servicioGoogleCalendar.CalendarioID = calendarID
    End Sub

    Public Sub New()
        _autenticadorServiciosGoogle = New AutenticadorServiciosGoogle()
        _servicioGoogleCalendar = New ServicioGoogleCalendar()
        _servicioGoogleGmail = New ServicioGoogleGmail()
        _servicioWhatsapp = New ServicioWhatsapp()
        _servicioDesktop = New ServicioDesktop()
        _datosEvento = New DatosEvento()
        _servicioPodio = New ServicioPodio(Me)
    End Sub

    'MÉTODOS DE GESTIÓN DE EVENTOS

    ' *** CREAR ***
    ' Crea o actualiza un evento basado en la visibilidad del botón en la interfaz
    Public Sub CrearEvento(evento As Evento, esVisible As Boolean)
        If esVisible = True Then
            _datosEvento.InsertarEvento(evento)
        Else
            _datosEvento.ActualizarEvento(evento)
        End If
    End Sub

    Public Function EnviarEventoAGoogleCalendar(evento As Evento) As String
        Dim service As CalendarService = _autenticadorServiciosGoogle.ObtenerServicioCalendar()
        Dim eventoGoogle As [Event] = _servicioGoogleCalendar.ConvertirAModeloGoogleCalendar(evento)

        Dim calendarioID As String = GoogleCalendarioID
        Dim eventoCreado As [Event] = service.Events.Insert(eventoGoogle, If(calendarioID Is Nothing, evento.CalendarioID, calendarioID)).Execute() ' Si no se especifica un calendario, se usa el predeterminado
        GoogleEventoID = eventoCreado.Id
        Return GoogleEventoID
        Console.WriteLine($"Evento creado: {eventoCreado.HtmlLink}")
    End Function

    Public Sub ClonarEvento(eventoID As String, podioItemID As Integer, podioAppItemID As Long)
        Try
            Dim copyPodioAppItemID As Long = _servicioPodio.ClonarPodioItem(podioAppItemID).Result
            Dim copyEventoID As String = _servicioGoogleCalendar.DuplicarEventoGoogle(eventoID)

            ' Condición para evitar error si copyPodioAppItemID regresa un null o copyEventID también
            If copyPodioAppItemID = 0 Or copyEventoID = "" Then
                MessageBox.Show("Error al clonar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            _datosEvento.ClonarEvento(eventoID, podioItemID, podioAppItemID, copyEventoID, copyPodioAppItemID)
        Catch ex As Exception
            MessageBox.Show("Error al clonar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Método para insertar una notificación asociada a un evento, no son los mensajes
    Public Sub InsertarNotificacion(notificacion As Notificacion)
        _datosEvento.InsertarNotificacion(notificacion)
    End Sub

    ' *** ACTUALIZAR ***
    ' Método para actualizar solo si se quieren sincronizar los items y eventos
    Public Async Sub ActualizarEvento(evento As Evento)
        _servicioGoogleCalendar.ActualizarEventoV2(evento)
    End Sub
    ' Método para actualizar al estar insertando un nuevo evento 
    Public Async Sub AgregarInformacionEvento(evento As Evento, userID As Integer)
        Dim service As CalendarService = _autenticadorServiciosGoogle.ObtenerServicioCalendar()
        EnviarMensaje(evento.Mensaje, userID)
        Await _servicioGoogleCalendar.ActualizarEventoGoogleAsync(service, GoogleEventoID, evento)
    End Sub
    Public Sub ActualizarNotificacion(notificacion As Notificacion)
        _datosEvento.ActualizarNotificacion(notificacion)
    End Sub

    ' *** ELIMINAR **
    ' Además de eliminar el evento, se eliminan los mensajes, notificaciones asociados e items de Podio
    Public Sub EliminarEvento(eventoID As String, podioAppItemID As Long)
        _servicioPodio.EliminarPodioItem(podioAppItemID)
        _servicioGoogleCalendar.EliminarEventoGoogle(eventoID)
        _datosEvento.EliminarEvento(eventoID)

    End Sub
    Public Sub EliminarNotificacion(recordatorioID As Integer)
        _datosEvento.EliminarNotificacion(recordatorioID)
    End Sub

    ' *** SINCRONIZACION ***
    ' Metodo para sincronizar eventos entre Google Calendar y la base de datos local
    Public Async Function SincronizarEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _autenticadorServiciosGoogle.ObtenerServicioCalendar()
        Dim eventosLocales As List(Of Evento) = ObtenerEventosLocales(GoogleCalendarioID)
        Dim eventosGoogle As IList(Of [Event]) = Await ObtenerEventosAsync()

        _servicioGoogleCalendar.SincronizarEventos(eventosGoogle, eventosLocales)
    End Function
    ' Método para sincronizar los calendarios de Google Calendar con la base de datos local
    Public Sub SincronizarCalendarios()
        Dim service As CalendarService = _autenticadorServiciosGoogle.ObtenerServicioCalendar()
        Dim calendariosGoogle As List(Of Calendario) = _servicioGoogleCalendar.ObtenerCalendariosGoogle(service)
        Dim calendariosLocales As List(Of Calendario) = _datosEvento.ObtenerCalendarios()

        _servicioGoogleCalendar.SincronizarCalendarios(calendariosGoogle, calendariosLocales)
    End Sub

    ' *** OBTENER ***
    Public Function ObtenerEventosLocales(calendarioID As String) As List(Of Evento)
        Dim eventosTable As DataTable = _datosEvento.MostrarEventos(calendarioID)
        Dim asistentes As List(Of Asistente) = _datosEvento.ObtenerTodosAsistentes()
        Dim notificaciones As List(Of Notificacion) = _datosEvento.ObtenerTodasNotificaciones()

        Return TransformarAEvento(eventosTable, asistentes, notificaciones)
    End Function
    Public Async Function ObtenerEventosAsync() As Task(Of IList(Of [Event]))
        Dim service As CalendarService = _autenticadorServiciosGoogle.ObtenerServicioCalendar()

        Dim eventosGoogle As IList(Of [Event]) = Await _servicioGoogleCalendar.ObtenerEventosGoogleAsync(service, GoogleCalendarioID)
        Return eventosGoogle
    End Function
    Public Function ObtenerCalendariosLocales() As List(Of Calendario)
        Return _datosEvento.ObtenerCalendarios()
    End Function
    Public Function ObtenerEventosConNotificacionesActivas(calendarioID As String) As DataTable
        Return _datosEvento.ObtenerEventosConNotificacionesActivas(calendarioID)
    End Function
    Public Function ObtenerDatosNotificacion(eventoID As String, userID As Integer) As Mensaje
        Return _datosEvento.ObtenerDatosNotificacion(eventoID, userID)
    End Function
    Public Function ObtenerEventosYMensajes(calendarioID As String) As List(Of EventoYMensajes)
        Return _datosEvento.ObtenerEventosYMensajes(calendarioID)
    End Function
    Public Function ObtenerEventosConPodio(calendarioID As String) As DataTable
        Return _datosEvento.ObtenerEventosConPodio(calendarioID)
    End Function

    Public Function ObtenerEventosCompartidos(email As String) As DataTable
        Return _datosEvento.ObtenerEventosCompartidos(email)
    End Function
    Public Function ObtenerAsistentesInvitados(eventoID As String) As List(Of Asistente)
        Return _datosEvento.MostrarAsistentesInvitados(eventoID)
    End Function
    Public Function ObtenerNotificacionesActivas(eventoID As String) As List(Of Notificacion)
        Return _datosEvento.MostrarNotificacionesActivas(eventoID)
    End Function
    Public Function ObtenerCorreosAsistentes() As List(Of String)
        Return _datosEvento.ObtenerCorreosUsuarios()
    End Function
    Public Function ObtenerCorreoUsuario() As String
        Return _datosEvento.ObtenerCorreoUsuario()
    End Function
    Public Function ObtenerTelefonoAsistente(email As String) As String
        Return _datosEvento.ObtenerTelefonoAsistente(email)
    End Function
    Public Function BuscarUserID(email As String) As Integer
        Return _datosEvento.BuscarUserID(email)
    End Function

    ' MÉTODOS DE GESTIÓN DE MENSAJES

    ' *** CREAR ***
    Public Sub CrearMensaje(mensaje As Mensaje)
        _datosEvento.InsertarMensaje(mensaje)
    End Sub

    ' *** ACTUALIZAR ***
    Public Sub ActualizarMensaje(mensaje As Mensaje, aplicarATodos As Boolean)
        _datosEvento.ActualizarMensaje(mensaje, aplicarATodos)
    End Sub
    Public Sub ActualizarFechaEnvio(mensajeID As Integer, fechaEnviado As DateTime)
        _datosEvento.ActualizarFechaEnvio(mensajeID, fechaEnviado)
    End Sub

    ' *** ENVIAR ***
    ' Método para enviar mensajes por correo, WhatsApp y notificaciones de escritorio
    Public Sub EnviarMensaje(mensaje As Mensaje, userID As Integer)
        If mensaje.Destinatarios.Count = 0 Then
            Return
        End If
        EnviarEmail(mensaje)
        EnviarWhatsApp(mensaje)
        EnviarNotificacionDesktop(mensaje, userID)
    End Sub

    Public Sub EnviarEmail(mensaje As Mensaje)
        Dim service As GmailService = _autenticadorServiciosGoogle.ObtenerServicioGmail()
        _servicioGoogleGmail.EnviarMensajeMail(service, mensaje)
    End Sub

    Public Sub EnviarWhatsApp(mensaje As Mensaje)
        _servicioWhatsapp.EnviarMensajeWhatsapp(mensaje, "WhatsApp")
    End Sub

    Public Sub EnviarNotificacionDesktop(mensaje As Mensaje, userID As Integer)
        If mensaje.UserID <> userID Then
            Return
        End If
        _servicioDesktop.EnviarNotificacionDesktop(mensaje)
    End Sub

    ' MÉTODOS DE GESTIÓN DE ITEMS DE PODIO

    ' *** CREAR ***
    Public Function CrearPodioItem(podioItem As PodioItem) As Integer
        Return _datosEvento.InsertarPodioItem(podioItem)
    End Function
    Public Function EnviarItemAPodio(podioItem As PodioItem) As Long
        Return _servicioPodio.CrearItem(podioItem).Result
    End Function
    Public Sub InsertarAsistente(mensaje As Mensaje, podioItemID As Integer)
        For Each attendee In mensaje.Destinatarios
            attendee.PodioItemID = podioItemID
            _datosEvento.InsertarAsistente(attendee)
            mensaje.UserID = _datosEvento.BuscarUserID(attendee.Email)
            ' Enviar mensaje a Podio
            CrearMensaje(mensaje)
        Next
    End Sub
    Public Sub InsertarSolicitante(podioItem As PodioItem)
        For Each solicitanteProfileID In podioItem.ContactosSolicitantes
            _datosEvento.InsertarSolicitante(podioItem.PodioItemID, _datosEvento.ObtenerUserIDPorProfileID(solicitanteProfileID))
        Next
    End Sub
    Public Sub InsertarAutorizante(podioItem As PodioItem)
        For Each autorizanteProfileID In podioItem.ContactosAutorizantes
            _datosEvento.InsertarAutorizante(podioItem.PodioItemID, _datosEvento.ObtenerUserIDPorProfileID(autorizanteProfileID))
        Next
    End Sub
    Public Sub InsertarPodioEmpresa(podioItem As PodioItem, empresa As Integer)
        _datosEvento.InsertarPodioEmpresa(podioItem, empresa)
    End Sub
    Public Sub InsertarPodioProyectoSistemas(podioItemID As Integer, podioProjectSystemID As String, name As String)
        _datosEvento.InsertarProyectoSistemas(podioItemID, podioProjectSystemID, name)
    End Sub

    ' *** ACTUALIZAR ***
    Public Sub ActualizarItemEnPodio(podioItem As PodioItem)
        _servicioPodio.ActualizarPodioItem(podioItem)

        ActualizarYCompararEmpresas(podioItem)
    End Sub
    Public Sub ActualizarPodioAppItemID(podioItemID As Integer, podioAppItemID As Long)
        _datosEvento.ActualizarPodioAppItemID(podioItemID, podioAppItemID)
    End Sub
    Public Sub ActualizarPodioItemEmpresas(podioItem As PodioItem, empresa As Integer, status As String)
        _datosEvento.ActualizarPodioItemEmpresas(podioItem, empresa, status)
    End Sub
    Public Sub ActualizarYCompararEmpresas(podioItem As PodioItem)
        ' Obtener empresas en BD
        Dim empresasActualesActivas As List(Of String) = _datosEvento.ObtenerListaEmpresas(podioItem.PodioItemID, "Activo")
        Dim empresasActualesEliminadas As List(Of String) = _datosEvento.ObtenerListaEmpresas(podioItem.PodioItemID, "Eliminado")
        Dim empresasNuevas As List(Of String) = podioItem.Empresa


        ' Salir de la función si no hay cambios en la lista de empresas nuevas
        If empresasActualesActivas.Count = empresasNuevas.Count Then
            Dim iguales As Boolean = True
            For Each empresa In empresasActualesActivas
                If empresasNuevas.Contains(empresa) = False Then
                    iguales = False
                    Exit For
                End If
            Next
            If iguales Then
                Return
            End If
        End If

        ' Insertar nuevas empresas que no están en la lista actual
        For Each empresa In empresasNuevas
            If empresasActualesActivas.Contains(empresa) = False And empresasActualesEliminadas.Contains(empresa) = False Then
                InsertarPodioEmpresa(podioItem, empresa)
            End If
        Next

        ' Marcar como eliminadas las empresas que no están en la nueva lista
        For Each empresa In empresasActualesActivas
            If empresasNuevas.Contains(empresa) = False Then
                ActualizarPodioItemEmpresas(podioItem, empresa, "Eliminado")
            End If
        Next

        ' Reactivar empresas que estaban eliminadas y ahora están seleccionadas de nuevo
        For Each empresa In empresasNuevas
            If empresasActualesActivas.Contains(empresa) = False And empresasActualesEliminadas.Contains(empresa) Then
                ActualizarPodioItemEmpresas(podioItem, empresa, "Activo")
            End If
        Next
    End Sub

    ' *** ELIMINAR ***
    Public Sub EliminarAsistente(asistente As Asistente)
        _datosEvento.EliminarAsistente(asistente)
    End Sub
    Public Sub EliminarSolicitante(correo As String, podioItemID As Integer)
        _datosEvento.EliminarSolicitante(correo, podioItemID)
    End Sub
    Public Sub EliminarAutorizante(correo As String, podioItemID As Integer)
        _datosEvento.EliminarAutorizante(correo, podioItemID)
    End Sub
    Public Sub EliminarProyectoSistemas(proyectoID As String, podioItemID As Integer)
        _datosEvento.EliminarProyectoSistemas(proyectoID, podioItemID)
    End Sub

    ' *** SINCRONIZACION ***
    ' Método para sincronizar los items de Podio con la base de datos local, solo se revisan los items creados desde el programa
    Public Async Function SincronizarItemsAsync(itemsLocales As DataTable, calendarioID As String) As Task
        Dim podioItems As JArray = Await _servicioPodio.ObtenerTodosLosItemsByUsuario().ConfigureAwait(False)

        Await _servicioPodio.SincronizarItems(podioItems, itemsLocales, calendarioID).ConfigureAwait(False)
    End Function

    ' *** OBTENER ***
    ' Metodo para buscar los proyectos de sistemas en Podio
    Public Async Function SearchItemPodio(query As String, limit As Integer) As Task(Of JArray)
        Return Await _servicioPodio.BuscarAppPorQuery(query, limit).ConfigureAwait(False)
    End Function
    Public Function ObtenerListaProyectosSistemas(podioItemID As Integer) As Dictionary(Of String, String)
        Return _datosEvento.ObtenerProyectosPorItem(podioItemID)
    End Function
    Public Function ObtenerListaEmpresasActivas(podioItemID As Integer) As List(Of String)
        Return _datosEvento.ObtenerListaEmpresas(podioItemID, "Activo")
    End Function
    Public Function ObtenerPodioUserIDPorCorreo(email As String) As Integer
        Return _datosEvento.ObtenerPodioUserIDPorCorreo(email)
    End Function
    Public Function ObtenerSolicitantes(podioItemID As Integer) As List(Of String)
        Return _datosEvento.ObtenerSolicitantes(podioItemID)
    End Function
    Public Function ObtenerAutorizantes(podioItemID As Integer) As List(Of String)
        Return _datosEvento.ObtenerAutorizantes(podioItemID)
    End Function
    Public Function ObtenerCorreoPorProfileID(profileID As Integer) As String
        Return _datosEvento.ObtenerCorreoPorProfileID(profileID)
    End Function
    Public Function ObtenerTareasPendientes() As DataTable
        Return _datosEvento.ObtenerTareasPendientes()
    End Function
    Public Function ObtenerTareasPendientesPodio(limite As Integer, intervaloInicio As DateTime, intervaloFin As DateTime) As DataTable
        Return _servicioPodio.ObtenerTareasPendientes(limite, intervaloInicio, intervaloFin).Result
    End Function
    Public Function ObtenerTareasFinalizadas() As DataTable
        Return _datosEvento.ObtenerTareasFinalizadas()
    End Function
    Public Function ObtenerTareasCreadas() As DataTable
        Return _datosEvento.ObtenerTareasCreadas()
    End Function
    Public Function ObtenerTareasPorUsuario(email As String) As DataTable
        Return _datosEvento.ObtenerTareasPorUsuario(email)
    End Function
    Public Function ObtenerCorreos() As List(Of String)
        Return _datosEvento.ObtenerCorreos()
    End Function
    Public Function ObtenerCantidadItemsPorEstado() As DataTable
        Return _datosEvento.ObtenerCantidadItemsPorEstado()
    End Function
    Public Function ObtenerCantidadItemsPorSystemArea() As DataTable
        Return _datosEvento.ObtenerCantidadItemsPorSystemArea()
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
    ' Método para transformar los datos de la tabla de eventos a objetos de tipo Evento
    Public Function TransformarAEvento(eventosTable As DataTable, asistentes As List(Of Asistente), notificaciones As List(Of Notificacion)) As List(Of Evento)
        Dim eventos As New List(Of Evento)
        For Each row As DataRow In eventosTable.Rows
            Dim evento As New Evento With {
                .EventoID = row(0).ToString(),
                .Titulo = row(1).ToString(),
                .Ubicacion = row(2).ToString(),
                .Descripcion = row(3).ToString(),
                .FechaInicio = row(4).ToString(),
                .FechaFin = row(5).ToString(),
                .RRULE = row(6).ToString(),
                .Visibilidad = row(7).ToString(),
                .Transparencia = row(8).ToString(),
                .UltimaModificacion = row(9).ToString(),
                .UserID = row(10).ToString()
            }
            evento.Asistentes = asistentes.Where(Function(a) a.EventoID.Equals(evento.EventoID)).ToList()
            evento.Recordatorios = notificaciones.Where(Function(n) n.EventoID.Equals(evento.EventoID)).ToList()
            eventos.Add(evento)
        Next
        Return eventos

    End Function

    Public Sub ActualizarStatusEvento(evento As Evento)
        _datosEvento.ActualizarStatusEvento(evento)
    End Sub

    Public Function ObtenerProfileIDyUserID(email As String) As Task(Of Tuple(Of Long, Long))
        Return _servicioPodio.ObtenerProfileIDyUserID(email)
    End Function
End Class
