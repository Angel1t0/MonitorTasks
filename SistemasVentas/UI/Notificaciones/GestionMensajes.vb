' Clase para gestionar los mensajes y notificaciones en la aplicación
Public Class GestionMensajes
    Private _eventoControlador As ControladorEvento
    Private _calendarID As String

    Private Property eventID As String
    Private Property userID As Integer

    Public Sub New(calendarioID)
        InitializeComponent()
        _eventoControlador = New ControladorEvento()
        _calendarID = calendarioID
    End Sub

    ' Método para cargar los eventos con notificaciones activas en el DataGridView
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

    ' Evento para cancelar la edición de notificaciones, oculta el panel de edición y muestra el panel de datos
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        PanelEditarNotificaciones.Visible = False
        PanelDataMensajes.Visible = True
        Panel1.Visible = True
    End Sub

    ' Método para mostrar el panel de edición de notificaciones
    Private Sub AbrirPanelEditarNotificaciones()
        PanelEditarNotificaciones.Visible = True
        PanelEditarNotificaciones.BringToFront()
        CentrarPanel(PanelEditarNotificaciones)
    End Sub

    ' Método para centrar el panel en el formulario
    Private Sub CentrarPanel(panel As Panel)
        panel.Location = New Point((Me.Width - panel.Width) / 2, (Me.Height - panel.Height) / 2)
    End Sub

    ' Método para preparar la actualización de notificaciones, obtiene el ID del evento seleccionado y carga la lista de invitados
    Private Sub PrepararActualizarNotificaciones()
        Me.eventID = dgvDataMensajes.SelectedCells.Item(0).Value.ToString()
        CargarListaInvitados(eventID)
    End Sub

    ' Método para cargar la lista de invitados del evento en el ComboBox
    Private Sub CargarListaInvitados(eventID As String)
        comboUsuariosANotificar.Items.Clear()
        Dim listaAsistentes As List(Of Asistente) = _eventoControlador.ObtenerAsistentesInvitados(eventID)

        ' Si hay más de un invitado, agrega la opción "Todos"
        If listaAsistentes.Count > 1 Then
            comboUsuariosANotificar.Items.Add("Todos")
        End If

        ' Agrega los correos electrónicos de los asistentes al ComboBox
        For Each asistente In listaAsistentes
            comboUsuariosANotificar.Items.Add(asistente.Email)
        Next
    End Sub

    ' Evento que se ejecuta cuando se selecciona un usuario en el ComboBox
    Private Sub comboUsuariosANotificar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboUsuariosANotificar.SelectedIndexChanged
        Dim selectedItem As String = comboUsuariosANotificar.SelectedItem.ToString()
        If selectedItem.Equals("Todos") Then
            Return
        End If

        ' Obtiene el ID del usuario seleccionado y carga los datos de notificación
        userID = _eventoControlador.BuscarUserID(selectedItem)
        Dim datosNotificacion As Mensaje = _eventoControlador.ObtenerDatosNotificacion(eventID, userID)
        cargarDatosNotificacion(datosNotificacion)
    End Sub

    ' Método para cargar los datos de notificación en los controles correspondientes
    Private Sub cargarDatosNotificacion(datosNotificacion As Mensaje)
        checkGmail.Checked = False
        checkWhatsapp.Checked = False
        checkDesktop.Checked = False
        dateSilenciar.Value = Date.Now

        checkGmail.Checked = datosNotificacion.EmailSilenciado
        checkWhatsapp.Checked = datosNotificacion.WhatsAppSilenciado
        checkDesktop.Checked = datosNotificacion.DesktopSilenciado
        dateSilenciar.Value = datosNotificacion.FechaEnviado
    End Sub

    ' Evento que se ejecuta cuando se hace clic en el botón para guardar las notificaciones
    Private Sub btnGuardarNotificaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarNotificaciones.Click
        ' Verifica si se ha seleccionado un usuario
        If comboUsuariosANotificar.SelectedItem Is Nothing Then
            MessageBox.Show("Selecciona un usuario para guardar las notificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim mensaje As Mensaje = New Mensaje()
        mensaje.EventoID = eventID
        mensaje.UserID = userID
        mensaje.EmailSilenciado = checkGmail.Checked
        mensaje.WhatsAppSilenciado = checkWhatsapp.Checked
        mensaje.DesktopSilenciado = checkDesktop.Checked
        mensaje.FechaEnviado = dateSilenciar.Value

        ' Actualiza el mensaje en el controlador de eventos, considerando si es para todos los usuarios o solo uno
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
