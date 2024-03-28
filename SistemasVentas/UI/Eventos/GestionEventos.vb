
Public Class GestionEventos
    ' Controlador para manejar la lógica de negocio y la comunicación con Google Calendar.
    Private _controlador As New EventoControlador()
    Private _servicioGoogleCalendar As New GoogleCalendarService()

    ' Propiedades para almacenar información relevante del evento y el ID del calendario seleccionado.
    Public Property CalendarioID As String
    Public Property UsuarioID As String
    Public Property EventoID As String
    Public Property ReminderID As New List(Of Integer)
    Public Property AsistenteID As Integer
    Private _actualizarPanelRecurrencia As Boolean = True

    ' Instancias de los modelos para manejar la información del evento y su recurrencia.
    Private evento As New Evento()
    Private recurrencia As New Recurrencia()
    Private mensaje As New Mensaje()

    Private Sub GestionEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim determinarRecurrencia As New DeterminarRecurrencia()
        'determinarRecurrencia.ParsearRRULE()
        CargarEventosEnDataGridView()
        PanelDatosBasicos.Visible = False
        PanelDatosRecurrencia.Visible = False
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        CargarAsistentes()
        ConfigurarComponentes()
        _controlador.GoogleCalendarID = CalendarioID
        _servicioGoogleCalendar.CalendarioID = CalendarioID
    End Sub

    ' Manejadores de Eventos
    Private Sub CrearEvento(isVisible As Boolean)
        evento.EventID = EventoID
        mensaje.EventID = EventoID

        _controlador.CrearEvento(evento, isVisible)
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
        Dim asistente As New Asistente() With {
            .EventID = EventoID,
            .Email = comboInvitados.Text,
            .DisplayName = labelAsistente.Text
        }
        Dim indice As Integer = comboListaInvitados.FindString(asistente.Email)
        If indice >= 0 Then
            MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _controlador.InsertarAsistente(asistente, mensaje)
        evento.Attendees.Add(asistente)
        MessageBox.Show("Asistente agregado correctamente")
    End Sub

    Public Sub AgregarListaInvitado()
        comboListaInvitados.Items.Clear()
        For Each invitado In evento.Attendees
            comboListaInvitados.Items.Add(invitado.Email)
        Next
        comboListaInvitados.SelectedIndex = 0
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
        dgvDataEventos.DataSource = _controlador.ObtenerEventos(CalendarioID)
        labelCantidadEventos.Text = $"Cantidad de eventos: {dgvDataEventos.Rows.Count}"
        EstilizarTabla()
    End Sub

    Public Sub CargarListaInvitados(eventID As String)
        comboListaInvitados.Items.Clear()
        evento.Attendees.Clear()
        mensaje.Attendees.Clear()
        Dim listaInvitados As List(Of String) = _controlador.ObtenerAsistentesInvitados(eventID)
        For Each invitado In listaInvitados
            Dim asistente As New Asistente() With {
                .Email = invitado
            }
            comboListaInvitados.Items.Add(invitado)
            evento.Attendees.Add(asistente)
            mensaje.Attendees.Add(asistente)
        Next
    End Sub

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
        If comboListaInvitados.Text = "" Then
            MessageBox.Show("No hay asistentes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboListaInvitados.SelectedItem.ToString()
        Dim asistente As New Asistente() With {
            .EventID = EventoID,
            .Email = correo
        }
        _controlador.EliminarAsistente(asistente)
        If evento.Attendees.Count > 0 Then
            evento.Attendees.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase))
            mensaje.Attendees.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase))
        End If
        comboListaInvitados.Items.Remove(correo)
        MessageBox.Show("Asistente eliminado correctamente")
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
        PanelDatosBasicos.Visible = True
        panelEventos.Visible = False
        btnActualizarEvento.Visible = False
        btnContinuarActualizar.Visible = False
        btnCrearEvento.Visible = True
        btnEnviarAPI.Visible = True
        CentrarPanel(PanelDatosBasicos)
    End Sub

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
        PanelAsistentes.Visible = True
        PanelAsistentes.BringToFront()
        CentrarPanel(PanelAsistentes)

        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnActualizarEvento_Click(sender As Object, e As EventArgs) Handles btnActualizarEvento.Click
        LlenarCamposEventos("Actualización")
        DeterminarRecurrencia()
        CrearEvento(False)

        evento.Message = mensaje
        _controlador.AgregarInformacionEvento(evento, UsuarioID)
        MessageBox.Show("Evento actualizado correctamente")
        CerrarVentanas()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnAgregarAsistentes_Click(sender As Object, e As EventArgs) Handles btnAgregarAsistentes.Click
        mensaje.EventID = EventoID
        CrearAsistente()
        AgregarListaInvitado()
    End Sub

    Private Sub btnEliminarAsistentes_Click(sender As Object, e As EventArgs) Handles btnEliminarAsistentes.Click
        EliminarAsistente()
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
        evento.Message = mensaje
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

    Private Sub comboInvitados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboInvitados.SelectedIndexChanged
        labelAsistente.Text = _controlador.ObtenerNombreAsistente(comboInvitados.SelectedItem.ToString())
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
        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        panelEventos.Visible = False
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
        Dim listaCorreos As List(Of String) = _controlador.ObtenerCorreosAsistentesExcepto(_controlador.ObtenerCorreoUsuario)

        For Each correo As String In listaCorreos
            comboInvitados.Items.Add(correo)
        Next
    End Sub

    Private Sub ConfigurarComponentes()
        ' Configuración del ComboBox
        comboEventDispo.SelectedIndex = 0 ' Selecciona "Ocupado" por defecto
        comboEventVisibilidad.SelectedIndex = 0 ' Selecciona "Público" por defecto
        comboRecurrencia.SelectedIndex = 0 ' Selecciona "No repetir" por defecto
        comboFrecuencia.SelectedIndex = 0 ' Selecciona "No repetir" por defecto
        comboInvitados.SelectedIndex = 0 ' Selecciona el primer correo por defecto
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

    Private Function ConvertirEventosADataTable(eventos As IList(Of Evento)) As DataTable
        Dim dataTable As New DataTable()

        ' Definir las columnas del DataTable
        With dataTable.Columns
            .Add("ID", GetType(String))
            .Add("Resumen", GetType(String))
            .Add("Ubicación", GetType(String))
            .Add("Descripción", GetType(String))
            .Add("Inicio", GetType(DateTime))
            .Add("Fin", GetType(DateTime))
            .Add("Visibilidad", GetType(String))
            .Add("Transparencia", GetType(String))
            .Add("Última Modificación", GetType(DateTime))
        End With

        ' Llenar el DataTable con los eventos
        For Each evento In eventos
            dataTable.Rows.Add(evento.EventID, evento.Summary, evento.Location,
                           evento.Description, evento.StartDateTime, evento.EndDateTime,
                           evento.Visibility, evento.Transparency, evento.LastModified)
        Next

        Return dataTable
    End Function

    Private Sub EstilizarTabla()
        dgvDataEventos.Columns(0).Width = 40
        dgvDataEventos.Columns(1).Visible = False
        dgvDataEventos.Columns(9).Visible = False
        dgvDataEventos.Columns(2).Width = 150
        dgvDataEventos.Columns(3).Width = 150
        dgvDataEventos.Columns(4).Width = 200
        dgvDataEventos.Columns(5).Width = 200
        dgvDataEventos.Columns(6).Width = 200
        dgvDataEventos.Columns(7).Width = 100
        dgvDataEventos.Columns(8).Width = 100
        dgvDataEventos.Columns(10).Width = 150

        dgvDataEventos.EnableHeadersVisualStyles = False
    End Sub

    Private Sub PrepararActualizarEvento()
        EventoID = dgvDataEventos.SelectedCells.Item(1).Value.ToString()
        _controlador.GoogleEventID = EventoID

        txtEventName.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(2).Value), "", dgvDataEventos.SelectedCells.Item(2).Value)
        txtEventUbicacion.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(3).Value), "", dgvDataEventos.SelectedCells.Item(3).Value)
        txtEventDescrip.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(4).Value), "", dgvDataEventos.SelectedCells.Item(4).Value)
        eventFechaInicio.Value = dgvDataEventos.SelectedCells.Item(5).Value
        eventFechaFinal.Value = dgvDataEventos.SelectedCells.Item(6).Value
        comboEventVisibilidad.SelectedItem = dgvDataEventos.SelectedCells.Item(8).Value
        comboEventDispo.SelectedItem = dgvDataEventos.SelectedCells.Item(9).Value

        'RECURRENCIA
        Dim rrule = dgvDataEventos.SelectedCells.Item(7).Value.ToString()
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

    ' Nuevos
    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        PanelAsistentes.Visible = False
        PanelNotificaciones.BringToFront()
        PanelNotificaciones.Visible = True

        CentrarPanel(PanelNotificaciones)
    End Sub

    Private Sub btnVolverEvento_Click(sender As Object, e As EventArgs) Handles btnVolverEvento.Click
        PanelAsistentes.Visible = False
        PanelAsistentes.SendToBack()
        PanelDatosBasicos.Visible = True
        CentrarPanel(PanelDatosBasicos)
    End Sub

    Private Sub btnVolverAsistente_Click(sender As Object, e As EventArgs) Handles btnVolverAsistente.Click
        PanelNotificaciones.Visible = False
        PanelNotificaciones.SendToBack()
        PanelAsistentes.Visible = True
        CentrarPanel(PanelAsistentes)
    End Sub

    Private Sub btnContinuarActualizar_Click(sender As Object, e As EventArgs) Handles btnContinuarActualizar.Click
        LlenarCamposEventos("Actualización")
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        PanelDatosBasicos.Visible = False
        PanelAsistentes.Visible = True
        PanelAsistentes.BringToFront()
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
        comboInvitados.SelectedIndex = 0
        comboListaInvitados.Items.Clear()
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
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        panelEventos.Visible = True
    End Sub
End Class

