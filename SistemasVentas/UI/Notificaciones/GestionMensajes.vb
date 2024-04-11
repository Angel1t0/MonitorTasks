Public Class GestionMensajes
    Private _eventoControlador As EventoControlador
    Private _calendarID As String

    Private Property eventID As String
    Private Property userID As Integer

    Public Sub New(calendarioID)
        InitializeComponent()
        _eventoControlador = New EventoControlador()
        _calendarID = calendarioID
    End Sub

    Private Sub CargarEventosEnDataGridView()
        dgvDataMensajes.DataSource = _eventoControlador.ObtenerEventosConNotificacionesActivas(_calendarID)
        labelCantidadEventos.Text = $"Eventos con notificaciones activas: {dgvDataMensajes.Rows.Count}"
    End Sub

    Private Sub GestionMensajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEventosEnDataGridView()
    End Sub

    Private Sub dgvDataMensajes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataMensajes.CellDoubleClick
        PanelDataMensajes.Visible = False
        Panel1.Visible = False
        AbrirPanelEditarNotificaciones()
        PrepararActualizarNotificaciones()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        PanelEditarNotificaciones.Visible = False
        PanelDataMensajes.Visible = True
        Panel1.Visible = True
    End Sub

    Private Sub AbrirPanelEditarNotificaciones()
        PanelEditarNotificaciones.Visible = True
        PanelEditarNotificaciones.BringToFront()
        CentrarPanel(PanelEditarNotificaciones)
    End Sub

    Private Sub CentrarPanel(panel As Panel)
        panel.Location = New Point((Me.Width - panel.Width) / 2, (Me.Height - panel.Height) / 2)
    End Sub

    Private Sub PrepararActualizarNotificaciones()
        Me.eventID = dgvDataMensajes.SelectedCells.Item(0).Value.ToString()
        CargarListaInvitados(eventID)
    End Sub

    Private Sub CargarListaInvitados(eventID As String)
        comboUsuariosANotificar.Items.Clear()
        Dim listaAsistentes As List(Of Asistente) = _eventoControlador.ObtenerAsistentesInvitados(eventID)

        ' Si hay más de un invitado, agrega la opción "Todos"
        If listaAsistentes.Count > 1 Then
            comboUsuariosANotificar.Items.Add("Todos")
        End If

        For Each asistente In listaAsistentes
            comboUsuariosANotificar.Items.Add(asistente.Email)
        Next
    End Sub

    Private Sub comboUsuariosANotificar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboUsuariosANotificar.SelectedIndexChanged
        Dim selectedItem As String = comboUsuariosANotificar.SelectedItem.ToString()
        If selectedItem.Equals("Todos") Then
            Return
        End If

        userID = _eventoControlador.BuscarUserID(selectedItem)
        Dim datosNotificacion As Mensaje = _eventoControlador.ObtenerDatosNotificacion(eventID, userID)
        cargarDatosNotificacion(datosNotificacion)
    End Sub

    Private Sub cargarDatosNotificacion(datosNotificacion As Mensaje)
        checkGmail.Checked = False
        checkWhatsapp.Checked = False
        checkDesktop.Checked = False
        dateSilenciar.Value = Date.Now

        checkGmail.Checked = datosNotificacion.EmailSent
        checkWhatsapp.Checked = datosNotificacion.WhatsAppSent
        checkDesktop.Checked = datosNotificacion.DesktopSent
        dateSilenciar.Value = datosNotificacion.SentTime
    End Sub

    Private Sub btnGuardarNotificaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarNotificaciones.Click
        Dim mensaje As Mensaje = New Mensaje()
        mensaje.EventID = eventID
        mensaje.UserID = userID
        mensaje.EmailSent = checkGmail.Checked
        mensaje.WhatsAppSent = checkWhatsapp.Checked
        mensaje.DesktopSent = checkDesktop.Checked
        mensaje.SentTime = dateSilenciar.Value

        If comboUsuariosANotificar.SelectedItem.ToString().Equals("Todos") Then
            _eventoControlador.ActualizarMensaje(mensaje, True)
        Else
            _eventoControlador.ActualizarMensaje(mensaje, False)
        End If

        CargarEventosEnDataGridView()
        PanelEditarNotificaciones.Visible = False
        PanelDataMensajes.Visible = True
        Panel1.Visible = True
    End Sub

End Class