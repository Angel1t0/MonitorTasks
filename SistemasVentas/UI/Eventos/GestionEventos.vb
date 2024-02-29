Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data

Public Class GestionEventos
    ' Controlador para manejar la lógica de negocio y la comunicación con Google Calendar.
    Private _controlador As New EventoControlador()
    Private _servicioGoogleCalendar As New GoogleCalendarService

    ' Propiedades para almacenar información relevante del evento y el ID del calendario seleccionado.
    Public Property CalendarioID As String
    Public Property EventoID As String
    Public Property ReminderID As New List(Of Integer)

    ' Instancias de los modelos para manejar la información del evento y su recurrencia.
    Private evento As New Evento()
    Private recurrencia As New Recurrencia()

    Private Sub GestionEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelCrearEvento.Visible = False
        panelEventos.Visible = False
        CentrarPanel(panelCalendarios)
        VisibilidadPanelCalendario(True)
        CargarCalendarios()
        CargarAsistentes()
        ConfigurarComponentes()
    End Sub

    ' Manejadores de Eventos
    Private Sub CrearEvento()
        evento.EventID = EventoID

        _controlador.CrearEvento(evento)
    End Sub

    Private Sub LlenarCamposEventos()
        evento.CalendarID = CalendarioID
        evento.Summary = txtEventName.Text
        evento.Location = txtEventUbicacion.Text
        evento.Description = txtEventDescrip.Text
        evento.StartDateTime = eventFechaInicio.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        evento.EndDateTime = eventFechaFinal.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        evento.Visibility = FormatoComboVisibilidad()
        evento.Transparency = FormatoComboDisponibilidad()
    End Sub

    Private Function CrearRecurrencia() As Boolean
        Dim listaFrecuencia As New List(Of String) From {"DONT REPEAT", "DAILY", "WEEKLY", "MONTHLY", "YEARLY"}
        Dim diasDeLaSemana As New List(Of String) From {"MO", "TU", "WE", "TH", "FR", "SA", "SU"}
        Dim indexFrecuencia As Integer = comboFrecuencia.SelectedIndex

        If indexFrecuencia = 0 Then
            evento.RRULE = ""
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
        MessageBox.Show(recurrencia.RRULE)
        evento.RRULE = recurrencia.GenerarRRULE()
        Return True
    End Function

    Private Sub CrearAsistente()
        Dim asistente As New Asistente() With {
            .EventID = EventoID,
            .Email = comboInvitados.Text,
            .DisplayName = labelAsistente.Text
        }
        If btnCrearEvento.Visible = True Then
            _controlador.InsertarAsistente(asistente, evento.HayAsistentesDuplicados(asistente))
        Else
            Dim indice As Integer = comboListaInvitados.FindString(asistente.Email)
            If indice >= 0 Then
                MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            _controlador.InsertarAsistente(asistente, False)
            evento.Attendees.Add(asistente)
            MessageBox.Show("Asistente agregado correctamente")
        End If

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
        EstilizarTabla()
    End Sub

    Public Sub CargarListaInvitados(eventID As String)
        comboListaInvitados.Items.Clear()
        evento.Attendees.Clear()
        Dim listaInvitados As List(Of String) = _controlador.ObtenerAsistentesInvitados(eventID)
        For Each invitado In listaInvitados
            Dim asistente As New Asistente() With {
                .Email = invitado
            }
            comboListaInvitados.Items.Add(invitado)
            evento.Attendees.Add(asistente)
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
    Private Async Sub btnSeleccionarCalendario_Click_1(sender As Object, e As EventArgs) Handles btnSeleccionarCalendario.Click
        SeleccionarCalendario()
        guardarCalendarioID(_controlador.ObtenerCalendarios()(0))
        panelEventos.Visible = True
        CentrarPanel(panelEventos)
        'Await _controlador.SincronizarEventosAsync()
    End Sub

    Private Async Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        Await _controlador.SincronizarEventosAsync()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnCrearEvento_Click(sender As Object, e As EventArgs) Handles btnCrearEvento.Click
        LlenarCamposEventos()
        If Not CrearRecurrencia() Then
            Return
        End If
        _controlador.EnviarEventoAGoogleCalendar(evento)
        EventoID = _controlador.GoogleEventID
        CrearEvento()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnActualizarEvento_Click(sender As Object, e As EventArgs) Handles btnActualizarEvento.Click
        LlenarCamposEventos()
        If Not CrearRecurrencia() Then
            Return
        End If
        CrearEvento()
        CargarEventosEnDataGridView()
    End Sub

    Private Sub btnAgregarAsistentes_Click(sender As Object, e As EventArgs) Handles btnAgregarAsistentes.Click
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
        _controlador.AgregarInformacionEvento(evento)

        MessageBox.Show("Evento creado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        btnActualizarEvento.Visible = True
        btnCrearEvento.Visible = False
        panelCrearEvento.Visible = True
        CentrarPanel(panelCrearEvento)
        PrepararActualizarEvento()
    End Sub

    Private Sub dgvDataEventos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellClick
        EliminarEvento(e)
    End Sub

    Private Sub pbInsertarEvento_Click_1(sender As Object, e As EventArgs) Handles pbInsertarEvento.Click
        panelCrearEvento.Visible = True
        btnActualizarEvento.Visible = False
        CentrarPanel(panelCrearEvento)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        panelCrearEvento.Visible = False
    End Sub


    ' Métodos Auxiliares

    Private Function CargarCalendarios() As List(Of String)
        Dim calendarios As List(Of List(Of String)) = _controlador.ObtenerCalendarios()

        AgregarCalendariosACombo(calendarios)
        labelUsuarioId.Text = Login.idUsuario
        Return calendarios(0)
    End Function

    Private Sub guardarCalendarioID(listCalendariosID As List(Of String))
        Dim indexSeleccionado = comboCalendario.SelectedIndex
        CalendarioID = listCalendariosID(indexSeleccionado)
    End Sub
    ' Lógica de creación y configuración de eventos

    Private Sub SeleccionarCalendario()
        VisibilidadPanelCalendario(False)
        guardarCalendarioID(CargarCalendarios())
        CargarEventosEnDataGridView()

    End Sub

    Private Sub CargarAsistentes()
        Dim listaCorreos As List(Of String) = _controlador.ObtenerCorreosAsistentesExcepto(_controlador.ObtenerCorreoUsuario)

        For Each correo As String In listaCorreos
            comboInvitados.Items.Add(correo)
        Next
    End Sub

    Private Sub ConfigurarComponentes()
        ' Configuración del ComboBox
        comboCalendario.SelectedIndex = 0 ' Selecciona "Minutos" por defecto
        comboEventDispo.SelectedIndex = 0 ' Selecciona "Ocupado" por defecto
        comboEventVisibilidad.SelectedIndex = 0 ' Selecciona "Público" por defecto
        comboFrecuencia.SelectedIndex = 0 ' Selecciona "Diariamente" por defecto
        comboInvitados.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        comboMetodoRecordar.SelectedIndex = 0 ' Selecciona "Correo electrónico" por defecto
        comboUnidades.SelectedIndex = 0 ' Selecciona "Minutos" por defecto

        ' Configuración del DateTimePicker
        eventFechaInicio.Value = DateTime.Now
        eventFechaFinal.Value = DateTime.Now
        dateRecuFinal.Value = DateTime.Now

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

    Private Sub AgregarCalendariosACombo(calendarios As List(Of List(Of String)))
        Dim calendariosName As List(Of String) = calendarios(1)
        For Each calendario In calendariosName
            comboCalendario.Items.Add(calendario)
        Next
    End Sub

    Private Sub CentrarPanel(panel As Panel)
        panel.Location = New Point((Width - panel.Width) / 2, (Height - panel.Height) / 2)
    End Sub

    Private Sub VisibilidadPanelCalendario(isVisible As Boolean)
        panelCalendarios.Visible = isVisible
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
        Dim styleCabeceras As New DataGridViewCellStyle()
        styleCabeceras.BackColor = Color.White
        styleCabeceras.ForeColor = Color.Black
        styleCabeceras.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
        dgvDataEventos.ColumnHeadersDefaultCellStyle = styleCabeceras
    End Sub

    Private Sub PrepararActualizarEvento()
        EventoID = dgvDataEventos.SelectedCells.Item(1).Value.ToString()

        txtEventName.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(2).Value), "", dgvDataEventos.SelectedCells.Item(2).Value)
        txtEventUbicacion.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(3).Value), "", dgvDataEventos.SelectedCells.Item(3).Value)
        txtEventDescrip.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(4).Value), "", dgvDataEventos.SelectedCells.Item(4).Value)
        eventFechaFinal.Value = dgvDataEventos.SelectedCells.Item(6).Value
        comboEventVisibilidad.SelectedItem = dgvDataEventos.SelectedCells.Item(8).Value
        comboEventDispo.SelectedItem = dgvDataEventos.SelectedCells.Item(9).Value

        'RECURRENCIA
        Dim rrule = dgvDataEventos.SelectedCells.Item(7).Value.ToString()
        CargarRecurrenciaDesdeRRULE(rrule)

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


End Class

