
Imports Newtonsoft.Json.Linq

Public Class GestionEventos
    ' Controlador para manejar la lógica de negocio y la comunicación con Google Calendar.
    Private _controlador As New EventoControlador()

    ' Propiedades para almacenar información relevante del evento y el ID del calendario seleccionado.
    Public Property CalendarioID As String
    Public Property UsuarioID As String
    Public Property EventoID As String
    Public Property ReminderID As New List(Of Integer)
    Private _actualizarPanelRecurrencia As Boolean = True
    Private _inicializacionTerminada As Boolean = False

    ' Instancias de los modelos para manejar la información del evento y su recurrencia.
    Private evento As New Evento()
    Private asistente As New Asistente()
    Private recurrencia As New Recurrencia()
    Private mensaje As New Mensaje()
    Private podioItem As New PodioItem()

    Private Sub GestionEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim determinarRecurrencia As New DeterminarRecurrencia()
        'determinarRecurrencia.ParsearRRULE()
        CargarEventosEnDataGridView()
        PanelDatosBasicos.Visible = False
        panelDatosPodio.Visible = False
        PanelDatosRecurrencia.Visible = False
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        CargarAsistentes()
        podioItem.InitializeOptions()
        ConfigurarComponentes()
        _controlador.EstablecerCalendarioID(CalendarioID)
        Dim newItem As New PodioItem()
        With newItem
            .Title = "Prueba 10"
            .Description = "Esta es una prueba"
            .Company = "3"
            .Department = "5"
            .DepartmentPriority = 3
            .SystemArea = "1"
            .Categories = "7"
            .RequestorContacts = New List(Of Integer) From {3599090}
            .AuthorizerContacts = New List(Of Integer) From {3599090}
            .AssignedToContacts = New List(Of Integer) From {3599090}
            .SystemPriority = 2
            .Priority = "2"
            .StartDate = DateTime.Parse("2023-03-14")
            .EndDate = DateTime.Parse("2023-03-19")
            .WorkPlan = "Este es un plan de trabajo"
            .Status = "10"
            .Progress = 50
            .SystemProject = "2011085875"
            .HoursAccumulated = 576000
            .ExtraHours = 576000
        End With
        _controlador.EnviarItemAPodio(newItem)
    End Sub

    ' Manejadores de Eventos
    Private Sub CrearEvento(isVisible As Boolean)
        evento.EventID = EventoID
        mensaje.EventID = EventoID

        _controlador.CrearEvento(evento, isVisible)
    End Sub

    Private Sub CrearPodioItem()
        podioItem.EventID = EventoID
        podioItem.PodioAppItemID = _controlador.EnviarItemAPodio(podioItem)
        podioItem.PodioItemID = _controlador.CrearPodioItem(podioItem)

        _controlador.InsertarAsistente(mensaje)
        _controlador.InsertarSolicitante(podioItem)
        _controlador.InsertarAutorizante(podioItem)
    End Sub

    Private Sub ActualizarPodioItem()
        podioItem.EventID = EventoID
        _controlador.ActualizarItemEnPodio(podioItem)
        _controlador.CrearPodioItem(podioItem)
    End Sub

    Private Sub LlenarCamposEventos(messageType As String)
        evento.CalendarID = CalendarioID
        evento.UserID = UsuarioID
        evento.Summary = txtEventName.TextBox1.Text
        evento.Location = txtEventUbicacion.TextBox1.Text
        evento.Description = txtEventDescrip.TextBox1.Text
        evento.StartDateTime = eventFechaInicio.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        evento.EndDateTime = eventFechaFinal.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        evento.Visibility = FormatoComboVisibilidad()
        evento.Transparency = FormatoComboDisponibilidad()

        mensaje.Title = evento.Summary
        mensaje.Description = evento.Description
        mensaje.StartDateTime = evento.StartDateTime
        mensaje.EndDateTime = evento.EndDateTime
        mensaje.Status = "Activo"
        mensaje.MessageType = messageType

        podioItem.Title = evento.Summary
        podioItem.Description = evento.Description
        podioItem.StartDate = evento.StartDateTime
        podioItem.EndDate = evento.EndDateTime
    End Sub

    Private Sub LlenarCamposPodioItem()
        podioItem.Company = podioItem.GetSelectedOptionId(comboEmpresa.SelectedItem.ToString(), podioItem.companyOptions)
        podioItem.Department = podioItem.GetSelectedOptionId(comboDepartamento.SelectedItem.ToString(), podioItem.departmentOptions)
        podioItem.SystemArea = podioItem.GetSelectedOptionId(comboArea.SelectedItem.ToString(), podioItem.systemAreaOptions)
        podioItem.Categories = podioItem.GetSelectedOptionId(comboCategorias.SelectedItem.ToString(), podioItem.categoryOptions)
        podioItem.DepartmentPriority = numericOrdenDpt.Value
        podioItem.SystemPriority = numericOrdenSistemas.Value
        podioItem.Priority = podioItem.GetSelectedOptionId(comboPrioridad.SelectedItem.ToString(), podioItem.priorityOptions)
        podioItem.WorkPlan = textPlanAccion.TextBox1.Text
        podioItem.Status = podioItem.GetSelectedOptionId(comboStatus.SelectedItem.ToString(), podioItem.statusOptions)
        podioItem.Progress = barraAvance.Value
        podioItem.SystemProject = ObtenerIdSistemasProyecto()
        podioItem.GeneralProject = txtProyectoGeneral.Text.ToString()
        podioItem.HoursAccumulated = podioItem.ConvertTimeToSeconds(maskHorasAcumuladas.Text)
        podioItem.ExtraHours = podioItem.ConvertTimeToSeconds(maskHorasExtras.Text)
        podioItem.CreatedOn = DateTime.Now
        podioItem.LastModified = DateTime.Now
    End Sub

    Private Function CrearRecurrencia() As Boolean
        Dim listaFrecuencia As New List(Of String) From {"DONT REPEAT", "DAILY", "WEEKLY", "MONTHLY", "YEARLY"}
        Dim diasDeLaSemana As New List(Of String) From {"MO", "TU", "WE", "TH", "FR", "SA", "SU"}
        Dim indexFrecuencia As Integer = comboFrecuencia.SelectedIndex

        If indexFrecuencia = 0 Then
            evento.RRULE = ""
            mensaje.RRULE = ""
            Return True
        End If

        Dim diasSeleccionados As List(Of String) = listDias.CheckedItems.Cast(Of String)().ToList()
        Dim tipoFinalizacion As String = If(rbtnConteo.Checked, "Ocurrencias", "HastaFecha")
        Dim ocurrencias As Integer = If(rbtnConteo.Checked, txtOcurrencias.Value, 0)
        Dim hastaFecha As DateTime? = If(rbtnFecha.Checked, dateRecuFinal.Value, Nothing)
        Dim diasSeleccionadosFormateado As String = String.Join(",", diasSeleccionados.Select(Function(dia) diasDeLaSemana(listDias.Items.IndexOf(dia))))

        recurrencia.Frecuencia = listaFrecuencia(indexFrecuencia)
        recurrencia.DiasSeleccionados = diasSeleccionadosFormateado
        recurrencia.TipoFinalizacion = tipoFinalizacion
        recurrencia.NumeroOcurrencias = ocurrencias
        recurrencia.FechaFinal = hastaFecha

        Dim errores As List(Of String) = recurrencia.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        evento.RRULE = recurrencia.GenerarRRULE()
        mensaje.RRULE = evento.RRULE
        Return True
    End Function

    Private Sub CrearAsistente()
        Dim correoAsistente As String = comboAsignadoA.SelectedItem.ToString()
        Dim asistente As New Asistente() With {
            .EventID = EventoID,
            .Email = correoAsistente,
            .PhoneNumber = _controlador.ObtenerTelefonoAsistente(correoAsistente),
            .PodioItemID = podioItem.PodioItemID
        }
        Dim indice As Integer = comboAsignados.FindString(asistente.Email)
        If indice >= 0 Then
            MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        mensaje.EventID = EventoID
        evento.Attendees.Add(asistente)
        mensaje.Attendees.Add(asistente)
        podioItem.AssignedToContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(asistente.Email))
        MessageBox.Show("Asistente agregado correctamente")
    End Sub

    Private Sub CrearSolicitante()
        Dim correoSolicitante As String = comboSolicitante.SelectedItem.ToString()
        Dim indice As Integer = comboSolicitantes.FindString(correoSolicitante)
        If indice >= 0 Then
            MessageBox.Show("El solicitante ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        podioItem.RequestorContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(correoSolicitante))
    End Sub

    Private Sub CrearAutorizante()
        Dim correoAutorizante As String = comboAutoriza.SelectedItem.ToString()
        Dim indice As Integer = comboAutorizantes.FindString(correoAutorizante)
        If indice >= 0 Then
            MessageBox.Show("El autorizante ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        podioItem.AuthorizerContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(correoAutorizante))
    End Sub

    Public Sub AgregarListaInvitado()
        comboAsignados.Items.Clear()
        For Each invitado In evento.Attendees
            comboAsignados.Items.Add(invitado.Email)
        Next
        comboAsignados.SelectedIndex = 0
    End Sub

    Public Sub AgregarListaSolicitante()
        comboSolicitantes.Items.Clear()
        For Each solicitante In podioItem.RequestorContacts
            comboSolicitantes.Items.Add(solicitante)
        Next
        comboSolicitantes.SelectedIndex = 0
    End Sub
    Public Sub AgregarListaAutorizante()
        comboAutorizantes.Items.Clear()
        For Each autorizante In podioItem.AuthorizerContacts
            comboAutorizantes.Items.Add(autorizante)
        Next
        comboAutorizantes.SelectedIndex = 0
    End Sub

    Private Sub CrearRecordatorio()
        Dim unidad As String = comboUnidades.SelectedItem.ToString()
        Dim cantidad As Integer = numericUpCantidad.Value
        Dim minutos As Integer = _controlador.ConvertirUnidadATiempo(unidad, cantidad)

        Dim notificacion As New Notificacion() With {
            .EventID = EventoID,
            .Method = FormatoComboMetodoRecordar(),
            .Minutes = minutos
        }
        _controlador.InsertarNotificacion(notificacion)
        evento.Reminders.Add(notificacion)
        MessageBox.Show("Recordatorio agregado correctamente")
    End Sub

    Private Sub EditarRecordatorio()
        Dim unidad As String = comboUnidades.SelectedItem.ToString()
        Dim cantidad As Integer = numericUpCantidad.Value
        Dim minutos As Integer = _controlador.ConvertirUnidadATiempo(unidad, cantidad)
        Dim indexSeleccionado As Integer = comboListaNotificaciones.SelectedIndex

        If indexSeleccionado = -1 Then
            MessageBox.Show("No hay notificaciones para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim notificacion As New Notificacion() With {
            .ReminderID = ReminderID(indexSeleccionado),
            .Method = FormatoComboMetodoRecordar(),
            .Minutes = minutos
        }
        _controlador.ActualizarNotificacion(notificacion)

        MessageBox.Show("Recordatorio actualizado correctamente")
    End Sub

    Public Sub CargarEventosEnDataGridView()
        dgvDataEventos.DataSource = _controlador.ObtenerEventosConPodio(CalendarioID)
        labelCantidadEventos.Text = $"Cantidad de eventos: {dgvDataEventos.Rows.Count}"
        EstilizarTabla(dgvDataEventos)
        'dgvDataEventos.Columns(11).Visible = False
    End Sub

    Public Sub CargarListaInvitados(eventID As String)
        comboAsignados.Items.Clear()
        comboSolicitantes.Items.Clear()
        comboAutorizantes.Items.Clear()

        evento.Attendees.Clear()
        mensaje.Attendees.Clear()
        Dim listaAsistentes As List(Of Asistente) = _controlador.ObtenerAsistentesInvitados(eventID)
        For Each asistente In listaAsistentes
            comboAsignados.Items.Add(asistente.Email)
            evento.Attendees.Add(asistente)
            mensaje.Attendees.Add(asistente)
            podioItem.AssignedToContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(asistente.Email))
        Next
    End Sub

    'FALTA IMPLEMENTAR EL MÉTODO PARA CARGAR LOS SOLICITANTES Y AUTORIZANTES EN PREPARAR ACTUALIZAR

    Public Sub CargarListaNotificaciones(eventID As String)
        Dim listaNotificaciones As List(Of Notificacion) = _controlador.ObtenerNotificacionesActivas(eventID)
        comboListaNotificaciones.Items.Clear()
        evento.Reminders.Clear()
        ReminderID.Clear()
        For Each notificacion In listaNotificaciones
            Dim minutos As Integer = Integer.Parse(ConversionUnidadTiempo(notificacion.Minutes)(0))
            Dim unidad As String = ConversionUnidadTiempo(notificacion.Minutes)(1)
            Dim descripcionNotificacion As String = $"Método: {notificacion.Method} y en {minutos} {unidad}"
            comboListaNotificaciones.Items.Add(descripcionNotificacion)
            ReminderID.Add(notificacion.ReminderID)

            Dim recordatorio As New Notificacion() With {
                .ReminderID = notificacion.ReminderID,
                .Method = notificacion.Method,
                .Minutes = notificacion.Minutes
            }
            evento.Reminders.Add(recordatorio)
        Next
    End Sub

    Public Sub EliminarEvento(e)
        If e.ColumnIndex = 0 Then
            Dim respuesta = MessageBox.Show("¿Está seguro que desea eliminar el evento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.No Then
                Return
            End If
            Dim eventoID As String = dgvDataEventos.Rows(e.RowIndex).Cells(1).Value.ToString()
            _controlador.EliminarEvento(eventoID)

            MessageBox.Show("Evento eliminado correctamente")
            CargarEventosEnDataGridView()
        End If
    End Sub

    Public Sub EliminarAsistente()
        If comboAsignados.Text = "" Then
            MessageBox.Show("No hay asistentes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboAsignados.SelectedItem.ToString()

        If evento.Attendees.Count > 0 Then
            evento.Attendees.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase))
            mensaje.Attendees.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase))
            podioItem.AssignedToContacts.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
        End If
        comboAsignados.Items.Remove(correo)
        MessageBox.Show("Asistente eliminado correctamente")
    End Sub

    Public Sub EliminarSolicitante()
        If comboSolicitantes.Text = "" Then
            MessageBox.Show("No hay solicitantes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboSolicitantes.SelectedItem.ToString()
        podioItem.RequestorContacts.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
        comboSolicitantes.Items.Remove(correo)
        MessageBox.Show("Solicitante eliminado correctamente")
    End Sub

    Public Sub EliminarAutorizante()
        If comboAutorizantes.Text = "" Then
            MessageBox.Show("No hay autorizantes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboAutorizantes.SelectedItem.ToString()
        podioItem.AuthorizerContacts.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
        comboAutorizantes.Items.Remove(correo)
        MessageBox.Show("Autorizante eliminado correctamente")
    End Sub

    Public Sub EliminarNotificacion()
        If comboListaNotificaciones.Text = "" Then
            MessageBox.Show("No hay notificaciones para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim notificacionSeleccionadaIndex As Integer = comboListaNotificaciones.SelectedIndex
        _controlador.EliminarNotificacion(ReminderID(notificacionSeleccionadaIndex))
        If evento.Reminders.Count > 0 Then
            evento.Reminders.RemoveAt(notificacionSeleccionadaIndex)
        End If
        comboListaNotificaciones.Items.RemoveAt(notificacionSeleccionadaIndex)
        MessageBox.Show("Notificación eliminada correctamente")
    End Sub

    ' Manejadores de Eventos UI
    Private Async Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        Await _controlador.SincronizarEventosAsync()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnInsertarEvento_Click(sender As Object, e As EventArgs) Handles btnInsertarEvento.Click
        LimpiarCampos()

        panelEventos.Visible = False
        btnActualizarEvento.Visible = False
        btnContinuarActualizar.Visible = False

        Panel2.Parent.Controls.Remove(PanelDatosBasicos)
        Me.Controls.Add(PanelDatosBasicos)
        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)

        btnCrearEvento.Visible = True
        btnEnviarAPI.Visible = True
        _inicializacionTerminada = True
    End Sub

    Private Sub btnActualizarEvento_Click(sender As Object, e As EventArgs) Handles btnActualizarEvento.Click
        LlenarCamposEventos("Actualización")
        LlenarCamposPodioItem()
        DeterminarRecurrencia()
        CrearEvento(False)
        ActualizarPodioItem()

        evento.Message = mensaje
        _controlador.AgregarInformacionEvento(evento, UsuarioID)

        MessageBox.Show("Evento actualizado correctamente")
        CerrarVentanas()
        CargarEventosEnDataGridView()
    End Sub

    ' Métodos para crear asistentes, solicitantes, autorizantes
    Private Sub comboAsignadoA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAsignadoA.SelectedIndexChanged
        If Not _inicializacionTerminada Then
            Return
        End If
        CrearAsistente()
        AgregarListaInvitado()
    End Sub

    Private Sub comboAutoriza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAutoriza.SelectedIndexChanged
        If Not _inicializacionTerminada Then
            Return
        End If
        CrearAutorizante()
        AgregarListaAutorizante()
    End Sub

    Private Sub comboSolicitante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSolicitante.SelectedIndexChanged
        If Not _inicializacionTerminada Then
            Return
        End If
        CrearSolicitante()
        AgregarListaSolicitante()
    End Sub

    Private Sub pictureEliminarAsignados_Click(sender As Object, e As EventArgs) Handles pictureEliminarAsignados.Click
        EliminarAsistente()
    End Sub

    Private Sub pictureEliminarSolicitantes_Click(sender As Object, e As EventArgs) Handles pictureEliminarSolicitantes.Click
        EliminarSolicitante()
    End Sub

    Private Sub pictureEliminarAutorizantes_Click(sender As Object, e As EventArgs) Handles pictureEliminarAutorizantes.Click
        EliminarAutorizante()
    End Sub

    Private Sub btnAgregarRecordatorio_Click(sender As Object, e As EventArgs) Handles btnAgregarRecordatorio.Click
        CrearRecordatorio()
        CargarListaNotificaciones(EventoID)
    End Sub

    Private Sub btnActualizarNotificacion_Click(sender As Object, e As EventArgs) Handles btnActualizarNotificacion.Click
        EditarRecordatorio()
        CargarListaNotificaciones(EventoID)
    End Sub

    Private Sub btnEliminarNotificaciones_Click(sender As Object, e As EventArgs) Handles btnEliminarNotificaciones.Click
        EliminarNotificacion()
    End Sub

    Private Sub btnEnviarAPI_Click(sender As Object, e As EventArgs) Handles btnEnviarAPI.Click
        LlenarCamposPodioItem()
        evento.Message = mensaje
        CrearPodioItem()
        _controlador.AgregarInformacionEvento(evento, UsuarioID)

        MessageBox.Show("Evento creado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CerrarVentanas()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub comboFrecuencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFrecuencia.SelectedIndexChanged
        If comboFrecuencia.SelectedItem = "No repetir" Then
            listDias.Enabled = False
            rbtnConteo.Enabled = False
            rbtnFecha.Enabled = False
            txtOcurrencias.Enabled = False
            dateRecuFinal.Enabled = False
        ElseIf comboFrecuencia.SelectedItem = "Semanalmente" Or comboFrecuencia.SelectedItem = "Mensualmente" Then
            listDias.Enabled = True
            rbtnConteo.Enabled = True
            rbtnFecha.Enabled = True
            If rbtnConteo.Checked Then
                dateRecuFinal.Enabled = False
                txtOcurrencias.Enabled = True
            Else
                dateRecuFinal.Enabled = True
            End If
        Else
            listDias.Enabled = False
            rbtnConteo.Enabled = True
            rbtnFecha.Enabled = True
            If rbtnConteo.Checked Then
                dateRecuFinal.Enabled = False
                txtOcurrencias.Enabled = True
            Else
                dateRecuFinal.Enabled = True
            End If
        End If
    End Sub

    Private Sub rbtnConteo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnConteo.CheckedChanged
        If rbtnConteo.Checked Then
            rbtnFecha.Checked = False
            txtOcurrencias.Enabled = True
        Else
            txtOcurrencias.Enabled = False
        End If
    End Sub

    Private Sub rbtnFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFecha.CheckedChanged
        If rbtnFecha.Checked Then
            rbtnConteo.Checked = False
            dateRecuFinal.Enabled = True
        Else
            dateRecuFinal.Enabled = False
        End If
    End Sub

    Private Sub comboUnidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboUnidades.SelectedIndexChanged
        Select Case comboUnidades.SelectedItem.ToString()
            Case "Minutos"
                numericUpCantidad.Maximum = 40320
            Case "Horas"
                numericUpCantidad.Maximum = 672 ' 40320 minutos / 60
            Case "Días"
                numericUpCantidad.Maximum = 28
            Case "Semanas"
                numericUpCantidad.Maximum = 4
        End Select
    End Sub

    Private Sub dgvDataEventos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellDoubleClick
        LimpiarCampos()
        btnActualizarEvento.Visible = True
        btnContinuarActualizar.Visible = True
        btnCrearEvento.Visible = False
        btnEnviarAPI.Visible = False
        panelEventos.Visible = False

        Panel2.Parent.Controls.Remove(PanelDatosBasicos)
        Me.Controls.Add(PanelDatosBasicos)
        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)

        PrepararActualizarEvento()
    End Sub

    Private Sub dgvDataEventos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellClick
        EliminarEvento(e)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        PanelDatosBasicos.Visible = False
        panelEventos.Visible = True
    End Sub


    ' Métodos Auxiliares

    Private Sub CargarAsistentes()
        ' Aqui cargan los asignados, usuarios en general
        Dim listaCorreos As List(Of String) = _controlador.ObtenerCorreosAsistentesExcepto(_controlador.ObtenerCorreoUsuario)

        For Each correo As String In listaCorreos
            comboAsignadoA.Items.Add(correo)
            comboAutoriza.Items.Add(correo)
            comboSolicitante.Items.Add(correo)
        Next
    End Sub

    Private Sub ConfigurarComponentes()
        LoadOptionInComboBox()

        ' Configuración del ComboBox
        comboEventDispo.SelectedIndex = 0 ' Selecciona "Ocupado" por defecto
        comboEventVisibilidad.SelectedIndex = 0 ' Selecciona "Público" por defecto
        comboRecurrencia.SelectedIndex = 0 ' Selecciona "No repetir" por defecto
        comboFrecuencia.SelectedIndex = 0 ' Selecciona "No repetir" por defecto
        comboAsignadoA.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        comboAutoriza.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        comboSolicitante.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        comboMetodoRecordar.SelectedIndex = 0 ' Selecciona "Correo electrónico" por defecto
        comboUnidades.SelectedIndex = 0 ' Selecciona "Minutos" por defecto

        ' Configuración del DateTimePicker
        eventFechaInicio.Value = DateTime.Now
        ' Quiero que la fecha final sea a final de año, y si por ejemplo, hoy es 31 de diciembre, que la fecha final sea el 31 de diciembre del año siguiente.
        eventFechaFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)
        dateRecuFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)

        ' Configuración del NumericUpDown
        numericUpCantidad.Minimum = 1
        numericUpCantidad.Maximum = 40320 ' Máximo en minutos
        numericUpCantidad.Value = 1
    End Sub

    Private Function FormatoComboVisibilidad() As String
        ' Convierte el texto seleccionado en el ComboBox a un formato aceptado por Google Calendar
        Select Case comboEventVisibilidad.SelectedItem.ToString()
            Case "Default"
                Return "default"
            Case "Público"
                Return "public"
            Case "Privado"
                Return "private"
        End Select
        Return "default"
    End Function

    Private Function FormatoComboDisponibilidad() As String
        Select Case comboEventDispo.SelectedItem.ToString()
            Case "Ocupado"
                Return "opaque"
            Case "Disponible"
                Return "transparent"
        End Select
        Return "opaque"
    End Function

    Private Function FormatoComboMetodoRecordar() As String
        Select Case comboMetodoRecordar.SelectedItem.ToString()
            Case "Correo electrónico"
                Return "email"
            Case "Notificación"
                Return "popup"
        End Select
        Return "email"
    End Function

    Private Sub CentrarPanel(panel As Panel)
        panel.Location = New Point((Me.Width - panel.Width) / 2, (Me.Height - panel.Height) / 2)
    End Sub

    Private Sub EstilizarTabla(dgvData As DataGridView)
        dgvData.Columns(1).Visible = False ' Oculta el ID del evento
        dgvData.Columns(3).Visible = False ' Oculta la ubicacion
        dgvData.Columns(13).Visible = False ' Visibilidad
        dgvData.Columns(14).Visible = False ' Disponibilidad
        dgvData.Columns(16).Visible = False ' Id usuario
        dgvData.Columns(17).Visible = False ' podioItemID
        dgvData.Columns(18).Visible = False ' PodioAppID
        dgvData.Columns(19).Visible = False ' PodioAppItemID
        dgvData.Columns(23).Visible = False ' Fecha inicio podio
        dgvData.Columns(24).Visible = False ' Fecha fin podio
        dgvData.Columns(29).Visible = False ' Horas acumuladas
        dgvData.Columns(30).Visible = False ' Horas extras
        dgvData.Columns(31).Visible = False ' Scrum
        dgvData.Columns(32).Visible = False ' Fecha creación podio
        dgvData.Columns(33).Visible = False ' Fecha modificación podio

        dgvData.Columns(0).Width = 40
        dgvData.Columns(2).Width = 150 ' Titulo
        dgvData.Columns(4).Width = 200 ' Descripcion
        dgvData.Columns(5).Width = 200 ' Fecha inicio
        dgvData.Columns(6).Width = 200 ' Fecha fin
        dgvData.Columns(7).Width = 100 ' Empresa
        dgvData.Columns(8).Width = 100 ' Departamenteo
        dgvData.Columns(9).Width = 100 ' Recurrenccia
        dgvData.Columns(10).Width = 100 ' Area de sistemas
        dgvData.Columns(11).Width = 100 ' Categorias
        dgvData.Columns(12).Width = 100 ' Estatus
        dgvData.Columns(15).Width = 100 ' Ultima modificacion
        dgvData.Columns(20).Width = 100 ' Department prioridad
        dgvData.Columns(21).Width = 100 ' Prioridad sistemas
        dgvData.Columns(22).Width = 100 ' Prioridad
        dgvData.Columns(25).Width = 200 ' Plan de trabajo
        dgvData.Columns(26).Width = 100 ' Progreso
        dgvData.Columns(27).Width = 100 ' Proyecto sistemas
        dgvData.Columns(28).Width = 100 ' Proyecto general
        dgvData.EnableHeadersVisualStyles = False
    End Sub

    Private Sub PrepararActualizarEvento()
        EventoID = dgvDataEventos.SelectedCells.Item(1).Value.ToString()
        _controlador.GoogleEventID = EventoID

        'DATOS BÁSICOS
        txtEventName.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(2).Value), "", dgvDataEventos.SelectedCells.Item(2).Value)
        txtEventUbicacion.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(3).Value), "", dgvDataEventos.SelectedCells.Item(3).Value)
        txtEventDescrip.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(4).Value), "", dgvDataEventos.SelectedCells.Item(4).Value)
        eventFechaInicio.Value = dgvDataEventos.SelectedCells.Item(5).Value
        eventFechaFinal.Value = dgvDataEventos.SelectedCells.Item(6).Value
        comboEventVisibilidad.SelectedItem = dgvDataEventos.SelectedCells.Item(13).Value
        comboEventDispo.SelectedItem = dgvDataEventos.SelectedCells.Item(14).Value

        'DATOS PODIO
        podioItem.PodioItemID = dgvDataEventos.SelectedCells.Item(17).Value
        podioItem.PodioAppID = dgvDataEventos.SelectedCells.Item(18).Value
        comboEmpresa.SelectedItem = dgvDataEventos.SelectedCells.Item(7).Value
        comboDepartamento.SelectedItem = dgvDataEventos.SelectedCells.Item(8).Value
        comboArea.SelectedItem = dgvDataEventos.SelectedCells.Item(10).Value
        comboCategorias.SelectedItem = dgvDataEventos.SelectedCells.Item(11).Value
        comboStatus.SelectedItem = dgvDataEventos.SelectedCells.Item(12).Value
        numericOrdenDpt.Value = dgvDataEventos.SelectedCells.Item(20).Value
        numericOrdenSistemas.Value = dgvDataEventos.SelectedCells.Item(21).Value
        comboPrioridad.SelectedItem = dgvDataEventos.SelectedCells.Item(22).Value
        textPlanAccion.TextBox1.Text = dgvDataEventos.SelectedCells.Item(25).Value
        barraAvance.Value = dgvDataEventos.SelectedCells.Item(26).Value
        comboProyectoSistemas.SelectedItem = dgvDataEventos.SelectedCells.Item(27).Value
        txtProyectoGeneral.Text = dgvDataEventos.SelectedCells.Item(28).Value
        maskHorasAcumuladas.Text = dgvDataEventos.SelectedCells.Item(29).Value
        maskHorasExtras.Text = dgvDataEventos.SelectedCells.Item(30).Value


        'RECURRENCIA
        Dim rrule = dgvDataEventos.SelectedCells.Item(9).Value.ToString()
        CargarRecurrenciaDesdeRRULE(rrule)
        PrepararComboRecurrencia(rrule)

        'ASITENTES
        CargarListaInvitados(EventoID)

        'NOTIFICACIONES
        CargarListaNotificaciones(EventoID)
    End Sub

    Public Function ConversionUnidadTiempo(minutos As Integer) As List(Of String)
        Dim listaConversion As New List(Of String)
        Dim unidades As New List(Of String) From {"Minutos", "Horas", "Días", "Semanas"}

        If (minutos Mod 10080 = 0) Then
            listaConversion.Add((minutos / 10080).ToString())
            listaConversion.Add(unidades(3))
        ElseIf (minutos Mod 1440 = 0) Then
            listaConversion.Add((minutos / 1440).ToString())
            listaConversion.Add(unidades(2))
        ElseIf (minutos Mod 60 = 0) Then
            listaConversion.Add((minutos / 60).ToString())
            listaConversion.Add(unidades(1))
        Else
            listaConversion.Add(minutos.ToString())
            listaConversion.Add(unidades(0))
        End If
        Return listaConversion
    End Function

    Public Sub CargarRecurrenciaDesdeRRULE(rrule As String)
        If rrule = "" Then
            comboFrecuencia.SelectedIndex = 0
            Return
        End If
        Dim diasDeLaSemana As New List(Of String) From {"MO", "TU", "WE", "TH", "FR", "SA", "SU"}
        ' Dividir la cadena RRULE en sus componentes
        Dim partes As String() = rrule.Split(";"c)

        ' Crear un diccionario para mapear los componentes de RRULE
        Dim diccionarioRRULE As New Dictionary(Of String, String)
        For Each parte As String In partes
            Dim componente As String() = parte.Split("="c)
            If componente.Length = 2 Then
                diccionarioRRULE.Add(componente(0), componente(1))
            End If
        Next

        ' Extraer los componentes
        Dim frecuencia As String = diccionarioRRULE("RRULE:FREQ")
        Dim ocurrencias As Integer? = Nothing
        Dim hastaFecha As DateTime? = Nothing
        Dim diasSeleccionados As New List(Of String)

        If diccionarioRRULE.ContainsKey("COUNT") Then
            ocurrencias = Integer.Parse(diccionarioRRULE("COUNT"))
        ElseIf diccionarioRRULE.ContainsKey("UNTIL") Then
            hastaFecha = DateTime.ParseExact(diccionarioRRULE("UNTIL"), "yyyyMMddTHHmmssZ", System.Globalization.CultureInfo.InvariantCulture)
        End If

        If diccionarioRRULE.ContainsKey("BYDAY") Then
            diasSeleccionados.AddRange(diccionarioRRULE("BYDAY").Split(","c))
        End If

        ' A continuación, puedes rellenar los campos de tu formulario con estos valores.
        ' Por ejemplo:
        Select Case frecuencia.ToUpper()
            Case "DAILY"
                comboFrecuencia.SelectedIndex = 1
            Case "WEEKLY"
                comboFrecuencia.SelectedIndex = 2
            ' Asegúrate de marcar los días correspondientes en tu control de días (listDias).
            Case "MONTHLY"
                comboFrecuencia.SelectedIndex = 3
            Case "YEARLY"
                comboFrecuencia.SelectedIndex = 4
        End Select

        ' Establecer los valores de ocurrencias o hasta fecha según corresponda
        If ocurrencias.HasValue Then
            rbtnConteo.Checked = True
            txtOcurrencias.Value = ocurrencias.Value
        ElseIf hastaFecha.HasValue Then
            rbtnFecha.Checked = True
            dateRecuFinal.Value = hastaFecha.Value
        End If

        ' Marcar los días seleccionados en tu control de lista (asumiendo que tienes una lista o similar para seleccionar días)
        For Each dia In diasSeleccionados
            Dim indice As Integer = diasDeLaSemana.IndexOf(dia)
            If indice >= 0 Then
                listDias.SetItemChecked(indice, True)
            End If
        Next
    End Sub

    Private Sub comboListaNotificaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboListaNotificaciones.SelectedIndexChanged
        Dim selectedItem As String = comboListaNotificaciones.SelectedItem.ToString()

        ' Extrae el método y los minutos del texto seleccionado
        Dim metodo As String = selectedItem.Split("Método: ")(1).Split(" y en ")(1)
        Dim minutosTexto As String = selectedItem.Split(" y en ")(4)
        Dim unidadTexto As String = selectedItem.Split(" ").Last()

        Select Case metodo
            Case "email"
                comboMetodoRecordar.SelectedIndex = 1
            Case "popup"
                comboMetodoRecordar.SelectedIndex = 0
        End Select
        numericUpCantidad.Value = Integer.Parse(minutosTexto)

        Select Case unidadTexto
            Case "Minutos"
                comboUnidades.SelectedIndex = comboUnidades.FindStringExact("Minutos")
            Case "Horas"
                comboUnidades.SelectedIndex = comboUnidades.FindStringExact("Horas")
            Case "Días"
                comboUnidades.SelectedIndex = comboUnidades.FindStringExact("Días")
            Case "Semanas"
                comboUnidades.SelectedIndex = comboUnidades.FindStringExact("Semanas")
        End Select
    End Sub

    ' Boton para crear el evento, esta en el panel datos básicos
    Private Sub btnCrearEvento_Click(sender As Object, e As EventArgs) Handles btnCrearEvento.Click
        LlenarCamposEventos("Nuevo evento")
        DeterminarRecurrencia()
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _controlador.EnviarEventoAGoogleCalendar(evento)
        EventoID = _controlador.GoogleEventID
        CrearEvento(True)

        PanelDatosBasicos.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)

        'PanelAsistentes.Visible = True
        'PanelAsistentes.BringToFront()
        'CentrarPanel(PanelAsistentes)

        CargarEventosEnDataGridView()
    End Sub

    ' Boton para actualizar el evento, esta en el panel datos básicos
    Private Sub btnContinuarActualizar_Click(sender As Object, e As EventArgs) Handles btnContinuarActualizar.Click
        LlenarCamposEventos("Actualización")
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        PanelDatosBasicos.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)
    End Sub

    Private Sub btnContinuarDatosPodio_Click(sender As Object, e As EventArgs) Handles btnContinuarDatosPodio.Click
        'AQUI DEBERÍA IR UNA VALIDACION DE LOS CAMPOS DE PODIO
        panelDatosPodio.Visible = False
        Panel2.Parent.Controls.Remove(PanelAsistentes)
        Me.Controls.Add(PanelAsistentes)
        PanelAsistentes.Visible = True
        PanelAsistentes.BringToFront()
        CentrarPanel(PanelAsistentes)
    End Sub

    Private Sub btnVolverDatosBasicos_Click(sender As Object, e As EventArgs) Handles btnVolverDatosBasicos.Click
        panelDatosPodio.Visible = False

        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        PanelAsistentes.Visible = False

        Panel2.Parent.Controls.Remove(PanelNotificaciones)
        Me.Controls.Add(PanelNotificaciones)
        PanelNotificaciones.Visible = True
        PanelNotificaciones.BringToFront()
        CentrarPanel(PanelNotificaciones)
    End Sub

    Private Sub btnVolverDatosPodio_Click(sender As Object, e As EventArgs) Handles btnVolverDatosPodio.Click
        PanelAsistentes.Visible = False
        PanelAsistentes.SendToBack()
        panelDatosPodio.Visible = True
        CentrarPanel(panelDatosPodio)
    End Sub

    Private Sub btnVolverAsistente_Click(sender As Object, e As EventArgs) Handles btnVolverAsistente.Click
        PanelNotificaciones.Visible = False
        PanelNotificaciones.SendToBack()
        PanelAsistentes.Visible = True
        CentrarPanel(PanelAsistentes)
    End Sub

    Private Sub LimpiarCampos()
        txtEventName.TextBox1.Text = ""
        txtEventUbicacion.TextBox1.Text = ""
        txtEventDescrip.TextBox1.Text = ""
        eventFechaInicio.Value = DateTime.Now
        eventFechaFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)
        comboEventVisibilidad.SelectedIndex = 0
        comboEventDispo.SelectedIndex = 0
        comboFrecuencia.SelectedIndex = 0
        comboRecurrencia.SelectedIndex = 0
        listDias.ClearSelected()
        rbtnConteo.Checked = False
        rbtnFecha.Checked = False
        txtOcurrencias.Value = 1
        dateRecuFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)

        comboEmpresa.SelectedIndex = 0
        comboDepartamento.SelectedIndex = 0
        comboArea.SelectedIndex = 0
        comboCategorias.SelectedIndex = 0
        comboPrioridad.SelectedIndex = 0
        comboStatus.SelectedIndex = 0
        comboProyectoSistemas.SelectedIndex = 0
        txtProyectoGeneral.Text = ""
        numericOrdenSistemas.Value = 1
        numericOrdenDpt.Value = 1
        maskHorasAcumuladas.Text = "00:00:00"
        maskHorasExtras.Text = "00:00:00"
        barraAvance.Value = 0

        comboAsignadoA.SelectedIndex = 0
        comboAsignados.Items.Clear()
        comboAutoriza.SelectedIndex = 0
        comboAutorizantes.Items.Clear()
        comboSolicitante.SelectedIndex = 0
        comboSolicitantes.Items.Clear()

        comboMetodoRecordar.SelectedIndex = 0
        comboUnidades.SelectedIndex = 0
        numericUpCantidad.Value = 1
    End Sub
    Private Function DeterminarRecurrencia() As Boolean
        Dim indexSeleccionado As Integer = comboRecurrencia.SelectedIndex
        Select Case indexSeleccionado
            Case 0
                evento.RRULE = ""
                mensaje.RRULE = ""
                Return True
            Case 1
                evento.RRULE = "RRULE:FREQ=DAILY;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z"
                mensaje.RRULE = "RRULE:FREQ=DAILY;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z"
                Return True
            Case 2
                evento.RRULE = "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z"
                mensaje.RRULE = "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z"
                Return True
            Case 3
                Return CrearRecurrencia()
            Case Else
                evento.RRULE = ""
                mensaje.RRULE = ""
                Return True
        End Select
    End Function

    Private Sub PrepararComboRecurrencia(rrule As String)
        _actualizarPanelRecurrencia = False
        If rrule = "" Then
            comboRecurrencia.SelectedIndex = 0
        ElseIf rrule = "RRULE:FREQ=DAILY" Then
            comboRecurrencia.SelectedIndex = 1
        ElseIf rrule = "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR" Then
            comboRecurrencia.SelectedIndex = 2
        Else
            comboRecurrencia.SelectedIndex = 3
        End If
        _actualizarPanelRecurrencia = True
    End Sub

    ' CHECAR ESTO RECURRENCIA
    Private Sub comboRecurrencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboRecurrencia.SelectedIndexChanged
        If _actualizarPanelRecurrencia Then
            Dim indexSeleccionado As Integer = comboRecurrencia.SelectedIndex
            If indexSeleccionado = 3 Then
                PanelDatosRecurrencia.Visible = True
                PanelDatosRecurrencia.BringToFront()
                CentrarPanel(PanelDatosRecurrencia)

                PanelDatosBasicos.Visible = False
            End If
        End If
    End Sub

    Private Sub btnListoRecurrencia_Click(sender As Object, e As EventArgs) Handles btnListoRecurrencia.Click
        If Not DeterminarRecurrencia() Then
            Return
        End If
        PanelDatosRecurrencia.Visible = False
        PanelDatosBasicos.Visible = True
        CentrarPanel(PanelDatosBasicos)
    End Sub

    Private Sub btnCancelarRecurrencia_Click(sender As Object, e As EventArgs) Handles btnCancelarRecurrencia.Click
        PanelDatosRecurrencia.Visible = False
        PanelDatosBasicos.Visible = True
        CentrarPanel(PanelDatosBasicos)

        comboFrecuencia.SelectedIndex = 0
        listDias.ClearSelected()
        rbtnConteo.Checked = False
        rbtnFecha.Checked = False
        txtOcurrencias.Value = 1
        dateRecuFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)
    End Sub

    Private Sub CerrarVentanas()
        PanelDatosBasicos.Visible = False
        panelDatosPodio.Visible = False
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        panelEventos.Visible = True
    End Sub

    ' GESTION EVENTOS COMPARTIDOS
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Text = "Eventos Compartidos" Then
            ' Llama a la función que carga los eventos compartidos en dgvEventosCompartidos
            CargarEventosCompartidosEnDataGridView()
        ElseIf TabControl1.SelectedTab.Text = "Eventos Propios" Then
            ' Para recargar los eventos propios si es necesario
            CargarEventosEnDataGridView()
        End If
    End Sub

    Private Sub CargarEventosCompartidosEnDataGridView()
        dgvDataEventosCompartidos.DataSource = _controlador.ObtenerEventosCompartidos()
        labelCantidadEventos.Text = $"Cantidad de eventos: {dgvDataEventosCompartidos.Rows.Count}"
        'EstilizarTabla(dgvDataEventosCompartidos)
        dgvDataEventosCompartidos.Columns(12).Visible = False
        ComprobarStatusAsistentes()
    End Sub

    Private Sub ComprobarStatusAsistentes()
        ' Si el status del asistente es "needsAction" el color de fondo de esa fila se pondra en amarillo y tambien cambia el color al seleccionar la fila
        For Each row As DataGridViewRow In dgvDataEventosCompartidos.Rows
            If row.Cells(13).Value.ToString() = "needsAction" Then
                row.DefaultCellStyle.BackColor = Color.Yellow
                row.DefaultCellStyle.SelectionBackColor = Color.Yellow
            End If
        Next
    End Sub

    Private Async Sub dgvDataEventosCompartidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventosCompartidos.CellDoubleClick
        ' Si la celda no tiene el status "needsAction" no se le preguntará al usuario si desea confirmar su asistencia
        If dgvDataEventosCompartidos.SelectedCells.Item(13).Value.ToString() <> "needsAction" Then
            Return
        End If

        ' Si el usuario hace doble clic en una celda, se le preguntará si desea confirmar su asistencia
        Dim respuesta = MessageBox.Show("¿Confirmar asistencia?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then
            Return
        End If
        Dim asistente As New Asistente() With {
            .EventID = dgvDataEventosCompartidos.SelectedCells.Item(1).Value.ToString(),
            .Email = dgvDataEventosCompartidos.SelectedCells.Item(12).Value.ToString(),
            .Status = "accepted"
        }

        Await _controlador.ActualizarStatusAsistente(asistente)
        CargarEventosCompartidosEnDataGridView()
    End Sub

    Private Sub comboProyectoSistemas_TextChanged(sender As Object, e As EventArgs) Handles comboProyectoSistemas.TextChanged
        If Not _inicializacionTerminada Then
            Return
        End If
        ' Reiniciar el Timer cada vez que el usuario escribe algo.
        SearchTimer.Stop()
        SearchTimer.Start()
    End Sub

    ' Buscador de items en Podio
    Private Async Sub SearchTimer_Tick(sender As Object, e As EventArgs) Handles SearchTimer.Tick
        ' Detener el Timer para evitar múltiples ejecuciones.
        SearchTimer.Stop()

        ' Verificar longitud del texto para optimizar la búsqueda.
        If comboProyectoSistemas.Text.Length >= 4 Then
            Try
                Dim results As JArray = Await _controlador.SearchItemPodio(comboProyectoSistemas.Text, 5) ' Ajusta appId y límites según necesites.
                comboProyectoSistemas.Items.Clear()
                podioItem.itemTitleToIdMap.Clear() ' Limpiar el diccionario antes de llenarlo de nuevo

                For Each item As JObject In results
                    Dim title As String = item("title").ToString()
                    Dim itemId As String = item("id").ToString() ' Asegúrate de que "item_id" es el campo correcto
                    podioItem.itemTitleToIdMap.Add(title, itemId) ' Guardar la relación título-ID en el diccionario
                    comboProyectoSistemas.Items.Add(title)
                Next
                comboProyectoSistemas.DroppedDown = True ' Opcional: Muestra la lista desplegable.
            Catch ex As Exception
                MessageBox.Show("Error buscando items: " & ex.Message)
            End Try
        Else
            comboProyectoSistemas.Items.Clear()
        End If
    End Sub

    Private Function ObtenerIdSistemasProyecto() As String
        If comboProyectoSistemas.SelectedItem IsNot Nothing Then
            Dim selectedTitle As String = comboProyectoSistemas.SelectedItem.ToString()
            If podioItem.itemTitleToIdMap.ContainsKey(selectedTitle) Then
                Return podioItem.itemTitleToIdMap(selectedTitle)
            End If
        End If
    End Function

    Public Sub LoadOptionInComboBox()
        podioItem.LoadOptionsIntoComboBox(comboEmpresa, podioItem.companyOptions)
        podioItem.LoadOptionsIntoComboBox(comboDepartamento, podioItem.departmentOptions)
        podioItem.LoadOptionsIntoComboBox(comboArea, podioItem.systemAreaOptions)
        podioItem.LoadOptionsIntoComboBox(comboCategorias, podioItem.categoryOptions)
        podioItem.LoadOptionsIntoComboBox(comboPrioridad, podioItem.priorityOptions)
        podioItem.LoadOptionsIntoComboBox(comboStatus, podioItem.statusOptions)
    End Sub
End Class

