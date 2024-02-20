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

    ' Manejadores de Eventos UI
    Private Sub btnSeleccionarCalendario_Click_1(sender As Object, e As EventArgs) Handles btnSeleccionarCalendario.Click
        SeleccionarCalendario()
        guardarCalendarioID(_controlador.ObtenerCalendarios()(0))
        panelEventos.Visible = True
        CentrarPanel(panelEventos)
    End Sub

    Private Sub btnCrearEvento_Click(sender As Object, e As EventArgs) Handles btnCrearEvento.Click
        LlenarCamposEventos()
        _controlador.EnviarEventoAGoogleCalendar(evento)
        EventoID = _controlador.GoogleEventID
        CrearEvento()
        CrearRecurrencia()
    End Sub

    Private Sub btnAgregarAsistentes_Click(sender As Object, e As EventArgs) Handles btnAgregarAsistentes.Click
        CrearAsistente()
        MessageBox.Show("Asistente agregado correctamente")
    End Sub

    Private Sub btnAgregarRecordatorio_Click(sender As Object, e As EventArgs) Handles btnAgregarRecordatorio.Click
        CrearRecordatorio()
        MessageBox.Show("Recordatorio agregado correctamente")
    End Sub

    Private Sub btnEnviarAPI_Click(sender As Object, e As EventArgs) Handles btnEnviarAPI.Click
        _controlador.AgregarInformacionEvento(evento, recurrencia)
        MessageBox.Show("Evento creado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub comboFrecuencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFrecuencia.SelectedIndexChanged
        If comboFrecuencia.SelectedItem = "Semanalmente" Or comboFrecuencia.SelectedItem = "Mensualmente" Then
            listDias.Enabled = True
        Else
            listDias.Enabled = False
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

    ' Lógica de creación y configuración de eventos
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

    Private Sub CrearRecurrencia()
        Dim listaFrecuencia As New List(Of String) From {"DAILY", "WEEKLY", "MONTHLY", "YEARLY"}
        Dim diasDeLaSemana As New List(Of String) From {"MO", "TU", "WE", "TH", "FR", "SA", "SU"}
        Dim indexFrecuencia As Integer = comboFrecuencia.SelectedIndex

        Dim diasSeleccionados As List(Of String) = listDias.CheckedItems.Cast(Of String)().ToList()
        Dim tipoFinalizacion As String = If(rbtnConteo.Checked, "Ocurrencias", "HastaFecha")
        Dim ocurrencias As Integer = If(rbtnConteo.Checked, txtOcurrencias.Value, 0)
        Dim hastaFecha As DateTime? = If(rbtnFecha.Checked, dateRecuFinal.Value, Nothing)
        Dim diasSeleccionadosFormateado As String = String.Join(",", diasSeleccionados.Select(Function(dia) diasDeLaSemana(listDias.Items.IndexOf(dia))))

        recurrencia.EventID = EventoID
        MessageBox.Show(recurrencia.EventID)
        recurrencia.Frecuencia = listaFrecuencia(indexFrecuencia)
        recurrencia.DiasSeleccionados = diasSeleccionados
        recurrencia.TipoFinalizacion = tipoFinalizacion
        recurrencia.NumeroOcurrencias = ocurrencias
        recurrencia.FechaFinal = hastaFecha
        recurrencia.RRULE = recurrencia.GenerarRRULE()

        _controlador.CrearRecurrencia(recurrencia)
    End Sub

    Private Sub CrearAsistente()
        Dim asistente As New Asistente() With {
            .EventID = EventoID,
            .Email = comboInvitados.Text,
            .DisplayName = labelAsistente.Text
        }
        _controlador.InsertarAsistente(asistente, evento.HayAsistentesDuplicados(asistente))
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

    Private Async Sub CargarEventosEnDataGridViewAsync()
        Dim service As CalendarService = _servicioGoogleCalendar.Authenticate()
        Dim eventos As IList(Of Evento) = Await _servicioGoogleCalendar.ObtenerEventosAsync(service, "primary")
        Dim dataTable As DataTable = ConvertirEventosADataTable(eventos)

        ' Asegúrate de actualizar el DataGridView en el hilo de la UI
        dgvDataEventos.Invoke(Sub() dgvDataEventos.DataSource = dataTable)
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

    Private Sub SeleccionarCalendario()
        VisibilidadPanelCalendario(False)
        CargarEventosEnDataGridViewAsync()
        guardarCalendarioID(CargarCalendarios())
        labelCalendarioID.Text = CalendarioID
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
            Case "Libre"
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

    Private Sub dgvDataEventos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellDoubleClick

    End Sub

    Private Sub pbInsertarEvento_Click_1(sender As Object, e As EventArgs) Handles pbInsertarEvento.Click
        panelCrearEvento.Visible = True
        CentrarPanel(panelCrearEvento)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        panelCrearEvento.Visible = False
    End Sub
End Class

