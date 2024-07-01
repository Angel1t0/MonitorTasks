
Imports Newtonsoft.Json.Linq

Public Class GestionEventos
    ' Controlador para manejar la lógica de negocio y la comunicación con Google Calendar.
    Private _controlador As New ControladorEvento()

    ' Propiedades para almacenar información relevante del evento y el ID del calendario seleccionado.
    Public Property CalendarioID As String
    Public Property UsuarioID As String
    Public Property EventoID As String
    Public Property ReminderID As New List(Of Integer)

    Private _actualizarPanelRecurrencia As Boolean = True
    Private _inicializacionTerminada As Boolean = False ' Bandera para evitar que se ejecuten eventos al cargar el formulario

    ' Instancias de los modelos para manejar la información del evento y su recurrencia.
    Private evento As Evento
    Private asistente As Asistente
    Private recurrencia As Recurrencia
    Private mensaje As Mensaje
    Private podioItem As PodioItem

    ' *** INICIALIZACIÓN Y CARGA ***
    Private Sub GestionEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim determinarRecurrencia As New DeterminarRecurrencia()
        'determinarRecurrencia.ParsearRRULE()
        ComprobarTabPageParaCargarEventos()
        ConfigurarTabControlComentarios()
        PanelDatosBasicos.Visible = False
        panelDatosPodio.Visible = False
        PanelDatosRecurrencia.Visible = False
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        CargarAsistentes()
        _controlador.EstablecerCalendarioID(CalendarioID)
    End Sub

    Private Sub InicializarObjetos()
        evento = New Evento()
        asistente = New Asistente()
        recurrencia = New Recurrencia()
        mensaje = New Mensaje()
        podioItem = New PodioItem()

        ConfigurarComponentes()
    End Sub

    ' *** MANEJO DE EVENTOS ***
    ' Boton para crear el evento, esta en el panel datos básicos
    Private Sub btnCrearEvento_Click(sender As Object, e As EventArgs) Handles btnCrearEvento.Click
        LlenarCamposEventos("Nueva Actividad") ' Llenar los campos como nuevo evento
        DeterminarRecurrencia() ' Asignar la recurrencia al evento
        Dim errores As List(Of String) = evento.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        _controlador.EnviarEventoAGoogleCalendar(evento) ' Primero enviar el evento a Google Calendar
        EventoID = _controlador.GoogleEventoID ' Obtener el ID del evento creado
        CrearEvento(True) ' True para insertar el evento en la base de datos

        ' Ocultar panel de datos básicos y mostrar el de podio
        PanelDatosBasicos.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)

        ComprobarTabPageParaCargarEventos()
        _inicializacionTerminada = True
    End Sub

    ' Metodo al presionar el boton de insertar item/evento
    Private Sub btnInsertarEvento_Click(sender As Object, e As EventArgs) Handles btnInsertarEvento.Click
        ' Ocultar el tab ya que solo es para cuando se actualiza y mover el panel a panel2
        TabControl2.Visible = False
        TabControl2.Parent.Controls.Remove(PanelDatosBasicos)
        Me.Controls.Add(PanelDatosBasicos)
        CentrarPanel(PanelDatosBasicos)

        LimpiarCampos()

        ' Se oculta el panel del datagridview y se muestra el panel de datos básicos
        panelEventos.Visible = False
        btnActualizarEvento.Visible = False
        btnContinuarActualizar.Visible = False

        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)

        btnCrearEvento.Visible = True
        btnEnviarAPI.Visible = True
        _inicializacionTerminada = True
    End Sub

    ' Boton para actualizar el evento en la base de datos, y en google calendar 
    Private Sub btnActualizarEvento_Click(sender As Object, e As EventArgs) Handles btnActualizarEvento.Click
        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)

        LlenarCamposEventos("Actualizacion")
        LlenarCamposPodioItem()
        DeterminarRecurrencia()

        ActualizarPodioItem()
        CrearEvento(False) ' False para la condición y actualizar el evento en la base de datos

        mensaje.PodioAppItemID = podioItem.PodioAppItemID
        evento.Mensaje = mensaje
        _controlador.AgregarInformacionEvento(evento, UsuarioID) ' Actualizar la información del evento en Google Calendar

        MessageBox.Show("Evento actualizado correctamente")
        CerrarVentanas()
        ComprobarTabPageParaCargarEventos()
    End Sub

    ' Metodo para terminar de agregar la informacion al evento del google Calendar
    Private Sub btnEnviarAPI_Click(sender As Object, e As EventArgs) Handles btnEnviarAPI.Click
        LlenarCamposPodioItem() ' Llenar los campos del objecto podio item
        CrearPodioItem() ' Metodo para insertar todo lo relacionado a podio a la plataforma y base de datos
        mensaje.PodioAppItemID = podioItem.PodioAppItemID
        evento.Mensaje = mensaje
        _controlador.AgregarInformacionEvento(evento, UsuarioID) ' Agregar la información faltante del evento a Google Calendar

        MessageBox.Show("Evento creado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CerrarVentanas()
        ComprobarTabPageParaCargarEventos()
        _inicializacionTerminada = False
    End Sub

    ' Sincronizar los items de podio y los eventos de google calendar
    Private Async Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        Await _controlador.SincronizarItemsAsync(_controlador.ObtenerEventosConPodio(CalendarioID), CalendarioID)
        'Await _controlador.SincronizarEventosAsync()
        ComprobarTabPageParaCargarEventos()
    End Sub

    ' Botón que se encuentra en el panel de datos básicos
    Private Sub btnContinuarActualizar_Click(sender As Object, e As EventArgs) Handles btnContinuarActualizar.Click
        LlenarCamposEventos("Actualizacion")
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

    ' Boton para actualizar el evento, esta en el panel datos básicos
    Private Sub btnContinuarDatosPodio_Click(sender As Object, e As EventArgs) Handles btnContinuarDatosPodio.Click
        LlenarCamposPodioItem()
        Dim errores As List(Of String) = podioItem.ValidarCampos()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        panelDatosPodio.Visible = False
        Panel2.Parent.Controls.Remove(PanelAsistentes)
        Me.Controls.Add(PanelAsistentes)
        PanelAsistentes.Visible = True
        PanelAsistentes.BringToFront()
        CentrarPanel(PanelAsistentes)
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Dim errores As List(Of String) = podioItem.ValidarCamposUsuarios()
        If errores.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        PanelAsistentes.Visible = False

        Panel2.Parent.Controls.Remove(PanelNotificaciones)
        Me.Controls.Add(PanelNotificaciones)
        PanelNotificaciones.Visible = True
        PanelNotificaciones.BringToFront()
        CentrarPanel(PanelNotificaciones)
    End Sub

    Private Sub btnVolverDatosBasicos_Click(sender As Object, e As EventArgs) Handles btnVolverDatosBasicos.Click
        panelDatosPodio.Visible = False

        PanelDatosBasicos.Visible = True
        PanelDatosBasicos.BringToFront()
        CentrarPanel(PanelDatosBasicos)
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

    ' Metodo para editar y obtener las notificaciones que puedes establecer en un evento de Google Calendar
    Private Sub btnActualizarNotificacion_Click(sender As Object, e As EventArgs) Handles btnActualizarNotificacion.Click
        EditarRecordatorio()
        CargarListaNotificaciones(EventoID)
    End Sub

    Private Sub btnEliminarNotificaciones_Click(sender As Object, e As EventArgs) Handles btnEliminarNotificaciones.Click
        EliminarNotificacion()
    End Sub

    ' Guardar los campos del panel para escoger una recurrencia personalizada
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
    End Sub

    Private Sub comboSolicitante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSolicitante.SelectedIndexChanged
        If Not _inicializacionTerminada Then
            Return
        End If
        CrearSolicitante()
    End Sub

    ' Métodos para eliminar asistentes, solicitantes, autorizantes
    Private Sub pictureEliminarAsignados_Click(sender As Object, e As EventArgs) Handles pictureEliminarAsignados.Click
        EliminarAsistente()
    End Sub

    Private Sub pictureEliminarSolicitantes_Click(sender As Object, e As EventArgs) Handles pictureEliminarSolicitantes.Click
        EliminarSolicitante()
    End Sub

    Private Sub pictureEliminarAutorizantes_Click(sender As Object, e As EventArgs) Handles pictureEliminarAutorizantes.Click
        EliminarAutorizante()
    End Sub

    ' Método para crear el recordatorio del evento en el calendario de google
    Private Sub btnAgregarRecordatorio_Click(sender As Object, e As EventArgs) Handles btnAgregarRecordatorio.Click
        CrearRecordatorio()
        CargarListaNotificaciones(EventoID)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        PanelDatosBasicos.Visible = False
        TabControl2.Visible = False
        panelEventos.Visible = True
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

    ' Permite editar el evento/item al hacer doble clic sobre el item en el DataGridView
    Private Sub dgvDataEventos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellDoubleClick
        TabControl2.Visible = True
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

        PrepararActualizarEvento() ' Preparar los campos para actualizar el evento con la información de la fila seleccionada
        _inicializacionTerminada = True
    End Sub

    ' Si se selecciona la primer columna de un item en el datagridview, se elimina el evento, item y todo lo relacionado
    Private Sub dgvDataEventos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellClick
        EliminarEvento(e)
        ClonarEvento(e)
    End Sub

    ' Evento para abrir la URL de la actividad al hacer clic en la celda correspondiente
    Private Sub dgvDataEventos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataEventos.CellContentClick
        If e.ColumnIndex = dgvDataEventos.Columns(32).Index AndAlso e.RowIndex >= 0 Then ' Columna de la URL de la actividad
            Dim url As String = dgvDataEventos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            Process.Start(New ProcessStartInfo("cmd", $"/c start {url}") With {.CreateNoWindow = True})
        End If
    End Sub

    ' Método auxiliar para rellenar los campos del recordatorio de un evento de acuerdo al recordatorio seleccionado
    Private Sub comboListaNotificaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboListaNotificaciones.SelectedIndexChanged
        Dim selectedItem As String = comboListaNotificaciones.SelectedItem.ToString()

        ' Extrae el método y los minutos del recordatorio seleccionado
        Dim metodo As String = selectedItem.Split("Método: ")(1).Split(" y en ")(1)
        Dim minutosTexto As String = selectedItem.Split(" y en ")(4)
        Dim unidadTexto As String = selectedItem.Split(" ").Last()

        ' Dependiendo de los valores, rellena los campos de acuerdo al recordatorio seleccionado
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

    ' Método auxiliar para buscar los proyectos de sistemas (items) en podio
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

                podioItem.temporaryMapTituloAID.Clear() ' Limpiar el diccionario temporal

                For Each item As JObject In results
                    Dim title As String = item("title").ToString()
                    Dim itemId As String = item("id").ToString() ' Asegúrate de que "item_id" es el campo correcto
                    podioItem.temporaryMapTituloAID.Add(title, itemId) ' Guardar la relación título-ID en el diccionario
                    comboProyectoSistemas.Items.Add(title)
                Next
                comboProyectoSistemas.DroppedDown = True
            Catch ex As Exception
                MessageBox.Show("Error buscando items: " & ex.Message)
            End Try
        Else
            comboProyectoSistemas.Items.Clear()
        End If
    End Sub

    Private Sub comboSeleccionarSistemas_Click(sender As Object, e As EventArgs) Handles comboSeleccionarSistemas.Click
        ' Al querer seleccionar un sistema, se muestra el panel de proyectos de sistemas
        panelDatosPodio.Visible = False
        Panel2.Parent.Controls.Remove(panelProyectosSistemas)
        Me.Controls.Add(panelProyectosSistemas)
        panelProyectosSistemas.Visible = True
        panelProyectosSistemas.BringToFront()
        CentrarPanel(panelProyectosSistemas)
    End Sub

    Private Sub btnCancelarProyectosSistemas_Click(sender As Object, e As EventArgs) Handles btnCancelarProyectosSistemas.Click
        ' Al cancelar la selección de proyectos de sistemas, se oculta el panel y se muestra el panel de datos de podio
        panelProyectosSistemas.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)
    End Sub

    Private Sub comboEmpresa_Click(sender As Object, e As EventArgs) Handles comboEmpresa.Click
        ' Al querer seleccionar una empresa, se muestra el panel de selección de empresas
        panelDatosPodio.Visible = False
        Panel2.Parent.Controls.Remove(panelSeleccionarEmpresas)
        Me.Controls.Add(panelSeleccionarEmpresas)
        panelSeleccionarEmpresas.Visible = True
        panelSeleccionarEmpresas.BringToFront()
        CentrarPanel(panelSeleccionarEmpresas)
    End Sub

    Private Sub btnCancelarEmpresas_Click(sender As Object, e As EventArgs) Handles btnCancelarEmpresas.Click
        panelSeleccionarEmpresas.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)

        listEmpresas.ClearSelected()
    End Sub

    Private Sub btnProyectosSistemas_Click(sender As Object, e As EventArgs) Handles btnProyectosSistemas.Click
        panelProyectosSistemas.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)

        ' Agregar los proyectos a la lista de proyectos de sistemas
        If mensaje.TipoMensaje.Contains("Actualizacion") Then
            For Each proyecto In comboProyectosSistemas.Items
                _controlador.InsertarPodioProyectoSistemas(podioItem.PodioItemID, ObtenerIdSistemasProyecto(proyecto), proyecto)
            Next
        End If

        ' Agrega cuantos proyectos de sistemas se han seleccionado
        If podioItem.ProyectoSistemas.Count = 0 Then
            comboSeleccionarSistemas.SelectedItem = ""
        ElseIf podioItem.ProyectoSistemas.Count = 1 Then
            comboSeleccionarSistemas.Text = comboProyectosSistemas.Items(0)
        Else
            comboSeleccionarSistemas.Text = comboProyectosSistemas.Items(0) & " (" & comboProyectosSistemas.Items.Count & ")"
        End If
    End Sub

    Private Sub btnEmpresas_Click(sender As Object, e As EventArgs) Handles btnEmpresas.Click
        panelSeleccionarEmpresas.Visible = False
        Panel2.Parent.Controls.Remove(panelDatosPodio)
        Me.Controls.Add(panelDatosPodio)
        panelDatosPodio.Visible = True
        panelDatosPodio.BringToFront()
        CentrarPanel(panelDatosPodio)
        GuardarListaEmpresas()
    End Sub

    Private Sub comboRecurrencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboRecurrencia.SelectedIndexChanged
        If _actualizarPanelRecurrencia Then
            Dim indexSeleccionado As Integer = comboRecurrencia.SelectedIndex
            ' Si se elige una recurrencia personalizada, se muestra el panel de recurrencia
            If indexSeleccionado = 3 Then
                PanelDatosRecurrencia.Visible = True
                PanelDatosRecurrencia.BringToFront()
                CentrarPanel(PanelDatosRecurrencia)

                PanelDatosBasicos.Visible = False
            End If
        End If
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedTab.Text = "Actualizar Actividad" Then
            ' Manejar que cada que cambie de pestaña se oculten los paneles, pero cuando regrese a esta pestaña, vuelva a aparece el panel que estaba antes de cambiar de pestaña
            PanelDatosBasicos.Visible = True
            panelDatosPodio.Visible = False
            PanelAsistentes.Visible = False
            PanelNotificaciones.Visible = False
            PanelDatosRecurrencia.Visible = False
            panelSeleccionarEmpresas.Visible = False
            panelProyectosSistemas.Visible = False

            ' Ocultar Formulario de comentarios
            TabControl2.TabPages(1).Controls.Clear()
        Else
            ' Abrir el formulario de comentarios
            PanelDatosBasicos.Visible = False
            panelDatosPodio.Visible = False
            PanelAsistentes.Visible = False
            PanelNotificaciones.Visible = False
            PanelDatosRecurrencia.Visible = False
            panelSeleccionarEmpresas.Visible = False
            panelProyectosSistemas.Visible = False

            Dim formularioComentarios As New GestionComentarios(podioItem.PodioAppItemID)
            formularioComentarios.TopLevel = False
            formularioComentarios.FormBorderStyle = FormBorderStyle.None
            formularioComentarios.Dock = DockStyle.Fill
            TabControl2.TabPages(1).Controls.Add(formularioComentarios)
            formularioComentarios.Show()
        End If
    End Sub

    Private Sub pictureEliminarSistemas_Click(sender As Object, e As EventArgs) Handles pictureEliminarSistemas.Click
        If comboProyectosSistemas.Text = "" Then
            MessageBox.Show("No hay proyectos para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim proyecto As String = comboProyectosSistemas.SelectedItem.ToString()

        If mensaje.TipoMensaje.Contains("Actualizacion") Then
            _controlador.EliminarProyectoSistemas(ObtenerIdSistemasProyecto(proyecto), podioItem.PodioItemID)
        End If

        podioItem.ProyectoSistemas.Remove(ObtenerIdSistemasProyecto(proyecto))
        comboProyectosSistemas.Items.Remove(proyecto)
        MessageBox.Show("Proyecto eliminado correctamente")
    End Sub

    Private Sub comboProyectoSistemas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboProyectoSistemas.SelectedIndexChanged
        If comboProyectoSistemas.Text = "" Then
            Return
        End If
        Dim proyecto As String = comboProyectoSistemas.SelectedItem.ToString()
        If Not comboProyectosSistemas.Items.Contains(proyecto) Then
            podioItem.mapTituloAID.Add(proyecto, ObtenerIdSistemasProyecto(proyecto)) ' Guardar la relación título-ID en el diccionario
            podioItem.InvertidosMapTituloAID.Add(ObtenerIdSistemasProyecto(proyecto), proyecto)

            comboProyectosSistemas.Items.Add(proyecto)
            podioItem.ProyectoSistemas.Add(ObtenerIdSistemasProyecto(proyecto))
            comboProyectosSistemas.SelectedIndex = 0
        End If
    End Sub


    ' *** METODOS PARA CREAR Y ACTUALIZAR EVENTOS ***
    Private Sub CrearEvento(isVisible As Boolean)
        evento.EventoID = EventoID
        mensaje.EventoID = EventoID

        _controlador.CrearEvento(evento, isVisible)
    End Sub

    Public Sub ClonarEvento(e)
        If e.ColumnIndex = 1 Then
            Dim respuesta = MessageBox.Show("¿Desea clonar la tarea?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.No Then
                Return
            End If
            Dim eventoID As String = dgvDataEventos.Rows(e.RowIndex).Cells(2).Value.ToString()
            Dim podioItemID As Integer = dgvDataEventos.Rows(e.RowIndex).Cells(17).Value
            Dim podioAppItemID As Long
            If Not Long.TryParse(dgvDataEventos.Rows(e.RowIndex).Cells(19).Value.ToString(), podioAppItemID) Then
                Console.WriteLine("No se pudo obtener el podioAppItemID")
            End If
            _controlador.ClonarEvento(eventoID, podioItemID, podioAppItemID)
            ComprobarTabPageParaCargarEventos()
        End If
    End Sub

    Private Sub CrearPodioItem()
        podioItem.EventoID = EventoID
        podioItem.PodioAppItemID = _controlador.EnviarItemAPodio(podioItem) ' Insertar el item en Podio y obtener el ID
        podioItem.PodioItemID = _controlador.CrearPodioItem(podioItem) ' Insertar el item en la base de datos con el ID de Podio

        _controlador.InsertarAsistente(mensaje, podioItem.PodioItemID)
        _controlador.InsertarSolicitante(podioItem)
        _controlador.InsertarAutorizante(podioItem)

        For Each empresa In podioItem.Empresa
            _controlador.InsertarPodioEmpresa(podioItem, empresa)
        Next

        For Each proyectoID In podioItem.ProyectoSistemas
            _controlador.InsertarPodioProyectoSistemas(podioItem.PodioItemID, proyectoID, podioItem.ObtenerProyectoSistemasNombre(proyectoID, podioItem.InvertidosMapTituloAID))
        Next
    End Sub

    ' Metodo para llenar los campos con los datos de la fila seleccionada
    Private Sub PrepararActualizarEvento()
        _inicializacionTerminada = False

        Try
            EventoID = dgvDataEventos.SelectedCells.Item(2).Value.ToString()
            _controlador.GoogleEventoID = EventoID

            'DATOS BÁSICOS
            txtEventName.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(3).Value), "", dgvDataEventos.SelectedCells.Item(3).Value)
            txtEventUbicacion.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(4).Value), "", dgvDataEventos.SelectedCells.Item(4).Value)
            txtEventDescrip.TextBox1.Text = If(IsDBNull(dgvDataEventos.SelectedCells.Item(5).Value), "", dgvDataEventos.SelectedCells.Item(5).Value)
            eventFechaInicio.Value = If(IsDBNull(dgvDataEventos.SelectedCells.Item(6).Value), DateTime.Now, dgvDataEventos.SelectedCells.Item(6).Value)
            eventFechaFinal.Value = If(IsDBNull(dgvDataEventos.SelectedCells.Item(7).Value), DateTime.Now, dgvDataEventos.SelectedCells.Item(7).Value)
            comboEventVisibilidad.SelectedItem = dgvDataEventos.SelectedCells.Item(13).Value
            comboEventDispo.SelectedItem = dgvDataEventos.SelectedCells.Item(14).Value

            'DATOS PODIO
            podioItem.PodioItemID = dgvDataEventos.SelectedCells.Item(17).Value
            podioItem.PodioAppID = dgvDataEventos.SelectedCells.Item(18).Value
            podioItem.PodioAppItemID = Long.Parse(dgvDataEventos.SelectedCells.Item(19).Value)

            comboDepartamento.SelectedItem = dgvDataEventos.SelectedCells.Item(8).Value
            comboArea.SelectedItem = dgvDataEventos.SelectedCells.Item(10).Value
            comboCategorias.SelectedItem = dgvDataEventos.SelectedCells.Item(11).Value
            comboStatus.SelectedItem = dgvDataEventos.SelectedCells.Item(12).Value
            numericOrdenDpt.Value = dgvDataEventos.SelectedCells.Item(20).Value
            numericOrdenSistemas.Value = dgvDataEventos.SelectedCells.Item(21).Value
            comboPrioridad.SelectedItem = dgvDataEventos.SelectedCells.Item(22).Value
            textPlanAccion.TextBox1.Text = dgvDataEventos.SelectedCells.Item(25).Value
            barraAvance.Value = dgvDataEventos.SelectedCells.Item(26).Value
            maskHorasAcumuladas.Text = podioItem.ConvertirSegundosATiempo(dgvDataEventos.SelectedCells.Item(27).Value)
            maskHorasExtras.Text = podioItem.ConvertirSegundosATiempo(dgvDataEventos.SelectedCells.Item(28).Value)

            ' DATOS PODIO - EMPRESAS
            CargarListaEmpresas()

            ' DATOS PODIO - PROYECTOS SISTEMAS
            CargarListaProyectosSistemas()

            'RECURRENCIA
            Dim rrule = dgvDataEventos.SelectedCells.Item(9).Value.ToString()
            CargarRecurrenciaDesdeRRULE(rrule)
            PrepararComboRecurrencia(rrule)

            'ASITENTES
            CargarListaInvitados(EventoID)

            'SOLICITANTES
            CargarListaSolicitantes(podioItem.PodioItemID)

            'AUTORIZANTES
            CargarListaAutorizantes(podioItem.PodioItemID)

            'NOTIFICACIONES
            CargarListaNotificaciones(EventoID)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos del evento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarPodioItem()
        podioItem.EventoID = EventoID
        _controlador.ActualizarItemEnPodio(podioItem) ' Actualizar el item en Podio
        _controlador.CrearPodioItem(podioItem)
    End Sub

    Private Sub LlenarCamposEventos(messageType As String)
        ' Asignar los valores de los campos a las propiedades de los modelos
        evento.CalendarioID = CalendarioID
        evento.UserID = If(messageType = "Actualizacion", dgvDataEventos.SelectedCells.Item(16).Value, UsuarioID)
        evento.Titulo = txtEventName.TextBox1.Text
        evento.Ubicacion = txtEventUbicacion.TextBox1.Text
        evento.Descripcion = txtEventDescrip.TextBox1.Text
        evento.FechaInicio = eventFechaInicio.Value.ToString("yyyy-MM-ddTHH:mm")
        evento.FechaFin = eventFechaFinal.Value.ToString("yyyy-MM-ddTHH:mm")
        evento.Visibilidad = FormatoComboVisibilidad()
        evento.Transparencia = FormatoComboDisponibilidad()

        mensaje.Titulo = evento.Titulo
        mensaje.Descripcion = evento.Descripcion
        mensaje.FechaInicio = evento.FechaInicio
        mensaje.FechaFin = evento.FechaFin
        mensaje.Status = "Activo"
        mensaje.TipoMensaje = messageType

        ' Asignar propiedades en común entre los modelos de evento y podio Item
        podioItem.Titulo = evento.Titulo
        podioItem.Descripcion = evento.Descripcion
        podioItem.FechaInicio = evento.FechaInicio
        podioItem.FechaFin = evento.FechaFin
    End Sub

    Private Sub LlenarCamposPodioItem()
        ' Llenar las propiedades del podio item con los valores de los campos
        podioItem.Departamento = podioItem.ObtenerIDSeleccionado(comboDepartamento.SelectedItem.ToString(), podioItem.departamentoOpciones)
        podioItem.AreaSistemas = podioItem.ObtenerIDSeleccionado(comboArea.SelectedItem.ToString(), podioItem.areaSistemasOpciones)
        podioItem.Categorias = podioItem.ObtenerIDSeleccionado(comboCategorias.SelectedItem.ToString(), podioItem.categoriaOpciones)
        podioItem.PrioridadDepartamento = numericOrdenDpt.Value
        podioItem.PrioridadSistemas = numericOrdenSistemas.Value
        podioItem.Prioridad = podioItem.ObtenerIDSeleccionado(comboPrioridad.SelectedItem.ToString(), podioItem.prioridadOpciones)
        podioItem.PlanTrabajo = textPlanAccion.TextBox1.Text
        podioItem.Status = podioItem.ObtenerIDSeleccionado(comboStatus.SelectedItem.ToString(), podioItem.statusOpciones)
        podioItem.Progreso = barraAvance.Value
        podioItem.ProyectoGeneral = txtProyectoGeneral.Text.ToString()
        podioItem.HorasAcumuladas = podioItem.ConvertirTiempoASegundos(maskHorasAcumuladas.Text)
        podioItem.HorasExtras = podioItem.ConvertirTiempoASegundos(maskHorasExtras.Text)
        podioItem.FechaCreacion = DateTime.Now
        podioItem.UltimaModificacion = DateTime.Now
    End Sub

    Private Function CrearRecurrencia() As Boolean
        ' Crear la recurrencia de acuerdo a los campos seleccionados en la personlizacion de la recurrencia
        Dim listaFrecuencia As New List(Of String) From {"DONT REPEAT", "DAILY", "WEEKLY", "MONTHLY", "YEARLY"} ' Frecuencias permitidas
        Dim diasDeLaSemana As New List(Of String) From {"MO", "TU", "WE", "TH", "FR", "SA", "SU"} ' Días de la semana permitidos
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
        evento.RRULE = recurrencia.GenerarRRULE() ' De acuerdo a las propiedades de la recurrencia, generar la RRULE
        mensaje.RRULE = evento.RRULE
        Return True
    End Function

    Private Sub CrearAsistente()
        Dim correoAsistente As String = comboAsignadoA.SelectedItem.ToString()
        Dim asistente As New Asistente() With {
            .EventoID = EventoID,
            .Email = correoAsistente,
            .Telefono = _controlador.ObtenerTelefonoAsistente(correoAsistente)
        }
        Dim indice As Integer = comboAsignados.FindString(asistente.Email)
        If indice >= 0 Then
            MessageBox.Show("El asistente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        mensaje.EventoID = EventoID ' Asociar el mensaje con el evento
        evento.Asistentes.Add(asistente)
        mensaje.Destinatarios.Add(asistente)
        podioItem.ContactosAsigandoA.Add(_controlador.ObtenerPodioUserIDPorCorreo(asistente.Email))
        MessageBox.Show("Asistente agregado correctamente")
    End Sub

    Private Sub CrearSolicitante()
        Dim correoSolicitante As String = comboSolicitante.SelectedItem.ToString()
        Dim indice As Integer = comboSolicitantes.FindString(correoSolicitante)
        If indice >= 0 Then
            MessageBox.Show("El solicitante ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        comboSolicitantes.Items.Add(correoSolicitante)
        comboSolicitantes.SelectedIndex = comboSolicitantes.Items.Count - 1
        podioItem.ContactosSolicitantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(correoSolicitante))
    End Sub

    Private Sub CrearAutorizante()
        Dim correoAutorizante As String = comboAutoriza.SelectedItem.ToString()
        Dim indice As Integer = comboAutorizantes.FindString(correoAutorizante)
        If indice >= 0 Then
            MessageBox.Show("El autorizante ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        comboAutorizantes.Items.Add(correoAutorizante)
        comboAutorizantes.SelectedIndex = comboAutorizantes.Items.Count - 1
        podioItem.ContactosAutorizantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(correoAutorizante))
    End Sub

    Public Sub AgregarListaInvitado()
        ' Agregar a combo para ver los asistentes agregados y poder eliminarlos
        comboAsignados.Items.Clear()
        For Each invitado In evento.Asistentes
            comboAsignados.Items.Add(invitado.Email)
        Next
        comboAsignados.SelectedIndex = 0
    End Sub

    Private Sub CrearRecordatorio()
        ' Crear un recordatorio para el evento en el calendario de google
        Dim unidad As String = comboUnidades.SelectedItem.ToString()
        Dim cantidad As Integer = numericUpCantidad.Value
        Dim minutos As Integer = _controlador.ConvertirUnidadATiempo(unidad, cantidad)

        Dim notificacion As New Notificacion() With {
            .EventoID = EventoID,
            .Metodo = FormatoComboMetodoRecordar(),
            .Minutos = minutos
        }
        _controlador.InsertarNotificacion(notificacion)
        evento.Recordatorios.Add(notificacion)
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
            .RecordatorioID = ReminderID(indexSeleccionado),
            .Metodo = FormatoComboMetodoRecordar(),
            .Minutos = minutos
        }
        _controlador.ActualizarNotificacion(notificacion)

        MessageBox.Show("Recordatorio actualizado correctamente")
    End Sub

    ' *** METODOS PARA ELIMINAR ***
    Public Sub EliminarEvento(e)
        If e.ColumnIndex = 0 Then
            Dim respuesta = MessageBox.Show("¿Está seguro que desea eliminar el item y evento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.No Then
                Return
            End If
            Dim eventoID As String = dgvDataEventos.Rows(e.RowIndex).Cells(2).Value.ToString()
            Dim podioAppItemID As Long
            If Not Long.TryParse(dgvDataEventos.Rows(e.RowIndex).Cells(19).Value.ToString(), podioAppItemID) Then
                Console.WriteLine("No se pudo obtener el podioAppItemID")
            End If
            _controlador.EliminarEvento(eventoID, podioAppItemID) ' Eliminar el evento, item en Podio y todo lo relacionado

            MessageBox.Show("Evento eliminado correctamente")
            ComprobarTabPageParaCargarEventos()
        End If
    End Sub

    Public Sub EliminarAsistente()
        ' Los asistentes se eliminan de uno en uno en su panel correspondiente
        If comboAsignados.Text = "" Then
            MessageBox.Show("No hay asistentes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboAsignados.SelectedItem.ToString()

        If evento.Asistentes.Count > 0 Then
            If mensaje.TipoMensaje = "Actualizacion" Then
                _controlador.EliminarAsistente(evento.Asistentes.FirstOrDefault(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase)))
            End If
            evento.Asistentes.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase)) ' Removemos de los objetos actuales
            mensaje.Destinatarios.RemoveAll(Function(a) a.Email.Equals(correo, StringComparison.OrdinalIgnoreCase))
            podioItem.ContactosAsigandoA.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
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

        If mensaje.TipoMensaje.Contains("Actualizacion") Then
            _controlador.EliminarSolicitante(correo, podioItem.PodioItemID)
        End If

        podioItem.ContactosSolicitantes.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
        comboSolicitantes.Items.Remove(correo)
        MessageBox.Show("Solicitante eliminado correctamente")
    End Sub

    Public Sub EliminarAutorizante()
        If comboAutorizantes.Text = "" Then
            MessageBox.Show("No hay autorizantes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim correo As String = comboAutorizantes.SelectedItem.ToString()

        If mensaje.TipoMensaje = "Actualizacion" Then
            _controlador.EliminarAutorizante(correo, podioItem.PodioItemID)
        End If

        podioItem.ContactosAutorizantes.Remove(_controlador.ObtenerPodioUserIDPorCorreo(correo))
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
        If evento.Recordatorios.Count > 0 Then
            evento.Recordatorios.RemoveAt(notificacionSeleccionadaIndex)
        End If
        comboListaNotificaciones.Items.RemoveAt(notificacionSeleccionadaIndex)
        MessageBox.Show("Notificación eliminada correctamente")
    End Sub

    ' *** METODOS PARA CARGAR DATOS ***
    Public Sub CargarEventosEnDataGridView(table As DataTable)
        dgvDataEventos.DataSource = table
        labelCantidadEventos.Text = $"Cantidad de actividades: {dgvDataEventos.Rows.Count}"
        EstilizarTabla(dgvDataEventos)
    End Sub

    Public Sub CargarListaInvitados(eventID As String)
        ' Obtener los asistentes/asignados y agregarlos a las propiedades de los modelos
        comboAsignados.Items.Clear()
        comboSolicitantes.Items.Clear()
        comboAutorizantes.Items.Clear()

        evento.Asistentes.Clear()
        mensaje.Destinatarios.Clear()
        Dim listaAsistentes As List(Of Asistente) = _controlador.ObtenerAsistentesInvitados(eventID)
        For Each asistente In listaAsistentes ' Añadir a los modelos y combos
            comboAsignados.Items.Add(asistente.Email)
            evento.Asistentes.Add(asistente)
            mensaje.Destinatarios.Add(asistente)
            podioItem.ContactosAsigandoA.Add(_controlador.ObtenerPodioUserIDPorCorreo(asistente.Email))
        Next
        If comboAsignados.Items.Count > 0 Then
            comboAsignados.SelectedIndex = 0
        End If
    End Sub

    Public Sub CargarListaSolicitantes(podioItemID As Integer)
        comboSolicitantes.Items.Clear()
        podioItem.ContactosSolicitantes.Clear()
        Dim listaSolicitantes As List(Of String) = _controlador.ObtenerSolicitantes(podioItemID)
        For Each solicitante In listaSolicitantes
            comboSolicitantes.Items.Add(solicitante)
            podioItem.ContactosSolicitantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(solicitante))
        Next
        If comboSolicitantes.Items.Count > 0 Then
            comboSolicitantes.SelectedIndex = 0
        End If
    End Sub

    Public Sub CargarListaAutorizantes(podioItemID As Integer)
        comboAutorizantes.Items.Clear()
        podioItem.ContactosAutorizantes.Clear()
        Dim listaAutorizantes As List(Of String) = _controlador.ObtenerAutorizantes(podioItemID)
        For Each autorizante In listaAutorizantes
            comboAutorizantes.Items.Add(autorizante)
            podioItem.ContactosAutorizantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(autorizante))
        Next
        If comboAutorizantes.Items.Count > 0 Then
            comboAutorizantes.SelectedIndex = 0
        End If
    End Sub

    Public Sub CargarListaNotificaciones(eventID As String)
        Dim listaNotificaciones As List(Of Notificacion) = _controlador.ObtenerNotificacionesActivas(eventID)
        comboListaNotificaciones.Items.Clear()
        evento.Recordatorios.Clear()
        ReminderID.Clear()
        For Each notificacion In listaNotificaciones
            Dim minutos As Integer = Integer.Parse(ConversionUnidadTiempo(notificacion.Minutos)(0))
            Dim unidad As String = ConversionUnidadTiempo(notificacion.Minutos)(1)
            Dim descripcionNotificacion As String = $"Método: {notificacion.Metodo} y en {minutos} {unidad}"
            comboListaNotificaciones.Items.Add(descripcionNotificacion)
            ReminderID.Add(notificacion.RecordatorioID)

            Dim recordatorio As New Notificacion() With {
                .RecordatorioID = notificacion.RecordatorioID,
                .Metodo = notificacion.Metodo,
                .Minutos = notificacion.Minutos
            }
            evento.Recordatorios.Add(recordatorio)
        Next
    End Sub

    ' Destransformar la RRULE a los campos de recurrencia
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

    Private Sub PrepararComboRecurrencia(rrule As String)
        ' Agregar preselección de recurrencia en el combo
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

    Private Sub CargarAsistentes()
        ' Aqui cargan los asignados, usuarios en general
        Dim listaCorreos As List(Of String) = _controlador.ObtenerCorreosAsistentes()

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
        'comboAsignadoA.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        'comboAutoriza.SelectedIndex = 0 ' Selecciona el primer correo por defecto
        'comboSolicitante.SelectedIndex = 0 ' Selecciona el primer correo por defecto
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

    Private Sub CargarListaEmpresas()
        Dim listaEmpresas As List(Of String) = _controlador.ObtenerListaEmpresasActivas(podioItem.PodioItemID)
        For Each empresaID In listaEmpresas
            Dim nombreEmpresa As String = podioItem.ObtenerNombreSeleccionado(empresaID, podioItem.empresaOpcionesInvertidas)
            Dim index As Integer = listEmpresas.Items.IndexOf(nombreEmpresa)
            If index <> -1 Then
                listEmpresas.SetItemChecked(index, True) ' Marcar las empresas que ya estén asociadas al evento
            End If
            podioItem.Empresa.Add(empresaID) ' Agregar a la lista de empresas asociadas al evento
        Next

        If listEmpresas.CheckedItems.Count = 0 Then
            comboEmpresa.Text = ""
        ElseIf listEmpresas.CheckedItems.Count = 1 Then
            comboEmpresa.Text = listEmpresas.CheckedItems.Item(0)
        Else
            comboEmpresa.Text = listEmpresas.CheckedItems.Item(0) & " (" & listEmpresas.CheckedItems.Count & ")"
        End If

    End Sub

    Private Sub GuardarListaEmpresas()
        Dim empresas As List(Of String) = listEmpresas.CheckedItems.Cast(Of String)().ToList()
        For Each empresa In empresas
            podioItem.Empresa.Add(podioItem.ObtenerIDSeleccionado(empresa, podioItem.empresaOpciones).ToString()) ' Agregar el ID de la empresa de acuerdo a los nombres de empresa seleccionados
        Next
        If empresas.Count = 0 Then
            comboEmpresa.Text = ""
        ElseIf empresas.Count = 1 Then
            comboEmpresa.Text = empresas(0)
        Else
            comboEmpresa.Text = empresas(0) & " (" & empresas.Count & ")"
        End If
    End Sub

    Private Sub CargarListaProyectosSistemas()
        Dim diccionarioProyectosSistemas As Dictionary(Of String, String) = _controlador.ObtenerListaProyectosSistemas(podioItem.PodioItemID) ' Obtener los proyectos y sus IDs

        If Not IsDBNull(diccionarioProyectosSistemas) Then
            podioItem.mapTituloAID = diccionarioProyectosSistemas
            ' Agregar el id y nombre de los proyectos a los diccionarios
            For Each value In diccionarioProyectosSistemas
                podioItem.InvertidosMapTituloAID.Add(value.Value, value.Key)
                podioItem.ProyectoSistemas.Add(value.Key)
                comboProyectosSistemas.Items.Add(value.Value)
            Next
        End If

        If comboProyectosSistemas.Items.Count > 0 Then
            comboProyectosSistemas.SelectedIndex = 0
            If podioItem.ProyectoSistemas.Count = 1 Then
                comboSeleccionarSistemas.Text = comboProyectosSistemas.Items(0)
            Else
                comboSeleccionarSistemas.Text = comboProyectosSistemas.Items(0) & " (" & comboProyectosSistemas.Items.Count & ")"
            End If
        End If
    End Sub

    ' *** METODOS AUXILIARES ***
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
        ' Convierte el texto seleccionado en el ComboBox a un formato aceptado por Google Calendar
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
        dgvData.Columns(2).Visible = False ' Oculta el ID del evento
        dgvData.Columns(4).Visible = False ' Oculta la ubicacion
        dgvData.Columns(13).Visible = False ' Visibilidad
        dgvData.Columns(14).Visible = False ' Disponibilidad
        dgvData.Columns(16).Visible = False ' Id usuario
        dgvData.Columns(17).Visible = False ' podioItemID
        dgvData.Columns(18).Visible = False ' PodioAppID
        dgvData.Columns(19).Visible = False ' PodioAppItemID
        dgvData.Columns(23).Visible = False ' Fecha inicio podio
        dgvData.Columns(24).Visible = False ' Fecha fin podio
        dgvData.Columns(27).Visible = False ' Horas acumuladas
        dgvData.Columns(28).Visible = False ' Horas extras
        dgvData.Columns(29).Visible = False ' Scrum
        dgvData.Columns(30).Visible = False ' Fecha creación podio
        dgvData.Columns(31).Visible = False ' Fecha modificación podio


        dgvData.Columns(12).DisplayIndex = 6 ' Invitados
        dgvData.Columns(32).DisplayIndex = 7 ' URL Podio
        dgvData.Columns(10).DisplayIndex = 9 ' Area de sistemas
        dgvData.Columns(25).DisplayIndex = 10 ' Plan de trabajo
        dgvData.Columns(11).DisplayIndex = 10 ' Categorias

        'dgvData.Columns(9).Width = 100 ' Recurrenccia
        'dgvData.Columns(10).Width = 100 ' Area de sistemas
        'dgvData.Columns(11).Width = 100 ' Categorias
        'dgvData.Columns(12).Width = 100 ' Estatus
        'dgvData.Columns(15).Width = 100 ' Ultima modificacion
        'dgvData.Columns(20).Width = 100 ' Department prioridad
        'dgvData.Columns(21).Width = 100 ' Prioridad sistemas
        'dgvData.Columns(22).Width = 100 ' Prioridad
        'dgvData.Columns(25).Width = 200 ' Plan de trabajo
        'dgvData.Columns(26).Width = 100 ' Progreso
        'dgvData.Columns(28).Width = 100 ' Proyecto sistemas
        'dgvData.Columns(30).Width = 100 ' Proyecto general
        AjustarAnchoColumnas()
        dgvData.EnableHeadersVisualStyles = False
    End Sub

    Private Sub AjustarAnchoColumnas()
        ' Autoajustar columnas según el contenido de las celdas
        dgvDataEventos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        ' Autoajustar columnas según el encabezado
        dgvDataEventos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)

        ' Establecer un ancho fijo para una columna específica
        dgvDataEventos.Columns(0).Width = 40 ' Icono eliminar
        dgvDataEventos.Columns(1).Width = 40 'Icono clonar
        dgvDataEventos.Columns(3).Width = 150 ' Titulo
        dgvDataEventos.Columns(5).Width = 200 ' Descripcion
        dgvDataEventos.Columns(6).Width = 100 ' Fecha inicio
        dgvDataEventos.Columns(7).Width = 100 ' Fecha fin
        dgvDataEventos.Columns(8).Width = 100 ' Departamento
        dgvDataEventos.Columns(32).Width = 80 ' Area de sistemas

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

    Private Sub LimpiarCampos()
        ' Inicializar modelos y limpiar campos
        InicializarObjetos()

        txtEventName.TextBox1.Text = ""
        txtEventUbicacion.TextBox1.Text = ""
        txtEventDescrip.TextBox1.Text = ""
        eventFechaInicio.Value = DateTime.Now
        eventFechaFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)
        comboEventVisibilidad.SelectedIndex = 0
        comboEventDispo.SelectedIndex = 0
        comboFrecuencia.SelectedIndex = 0
        comboRecurrencia.SelectedIndex = 0
        DesmarcarTodosLosElementos(listDias)
        rbtnConteo.Checked = False
        rbtnFecha.Checked = False
        txtOcurrencias.Value = 1
        dateRecuFinal.Value = New DateTime(DateTime.Now.Year, 12, 31)

        comboEmpresa.Text = ""
        comboSeleccionarSistemas.Text = ""
        DesmarcarTodosLosElementos(listEmpresas)
        comboDepartamento.SelectedIndex = 0
        comboArea.SelectedIndex = 0
        comboCategorias.SelectedIndex = 0
        comboPrioridad.SelectedIndex = 0
        comboStatus.SelectedIndex = 0
        txtProyectoGeneral.Text = ""
        numericOrdenSistemas.Value = 0
        numericOrdenDpt.Value = 0
        maskHorasAcumuladas.Text = "00:00:00"
        maskHorasExtras.Text = "00:00:00"
        barraAvance.Value = 0
        comboProyectoSistemas.Items.Clear()
        comboProyectoSistemas.Text = ""
        comboProyectosSistemas.Items.Clear()
        comboProyectosSistemas.Text = ""
        podioItem.mapTituloAID.Clear()
        podioItem.InvertidosMapTituloAID.Clear()

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

    Private Sub DesmarcarTodosLosElementos(checkedListBox As CheckedListBox)
        For i As Integer = 0 To checkedListBox.Items.Count - 1
            checkedListBox.SetItemChecked(i, False)
        Next
    End Sub

    Private Function DeterminarRecurrencia() As Boolean
        Dim indexSeleccionado As Integer = comboRecurrencia.SelectedIndex
        Select Case indexSeleccionado
            Case 0
                evento.RRULE = ""
                mensaje.RRULE = ""
                Return True
            Case 1
                evento.RRULE = "RRULE:FREQ=DAILY;UNTIL=" & DateTime.Now.Year.ToString() & "1231T120000Z" ' Hasta el 31 de diciembre del año actual
                mensaje.RRULE = "RRULE:FREQ=DAILY;UNTIL=" & DateTime.Now.Year.ToString() & "1231T120000Z"
                Return True
            Case 2
                evento.RRULE = "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T120000Z" ' Hasta el 31 de diciembre del año actual
                mensaje.RRULE = "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T120000Z"
                Return True
            Case 3
                Return CrearRecurrencia()
            Case Else
                evento.RRULE = ""
                mensaje.RRULE = ""
                Return True
        End Select
    End Function

    Private Sub CerrarVentanas()
        PanelDatosBasicos.Visible = False
        panelDatosPodio.Visible = False
        PanelAsistentes.Visible = False
        PanelNotificaciones.Visible = False
        panelEventos.Visible = True
    End Sub

    Private Function ObtenerIdSistemasProyecto(title As String) As String
        ' Obtener el ID del proyecto de sistemas de acuerdo al título
        If podioItem.temporaryMapTituloAID.ContainsKey(title) Then
            Return podioItem.temporaryMapTituloAID(title)
        Else
            Return ""
        End If
    End Function

    Public Sub LoadOptionInComboBox()
        podioItem.CargarOpcionesComboBox(comboEmpresa, podioItem.empresaOpciones)
        podioItem.CargarOpcionesComboBox(comboDepartamento, podioItem.departamentoOpciones)
        podioItem.CargarOpcionesComboBox(comboArea, podioItem.areaSistemasOpciones)
        podioItem.CargarOpcionesComboBox(comboCategorias, podioItem.categoriaOpciones)
        podioItem.CargarOpcionesComboBox(comboPrioridad, podioItem.prioridadOpciones)
        podioItem.CargarOpcionesComboBox(comboStatus, podioItem.statusOpciones)
    End Sub

    Private Sub ConfigurarTabControlComentarios() ' TabControl2
        Panel2.Parent.Controls.Remove(TabControl2)
        Me.Controls.Add(TabControl2)
        TabControl2.Dock = DockStyle.Fill

        ' Añadir los paneles necesarios para insertar y editar items
        Panel2.Parent.Controls.Remove(PanelDatosBasicos)
        TabControl2.TabPages(0).Controls.Add(PanelDatosBasicos)
        TabControl2.TabPages(0).Controls.Add(PanelDatosRecurrencia)
        TabControl2.TabPages(0).Controls.Add(panelDatosPodio)
        TabControl2.TabPages(0).Controls.Add(panelSeleccionarEmpresas)
        TabControl2.TabPages(0).Controls.Add(panelProyectosSistemas)
        TabControl2.TabPages(0).Controls.Add(PanelAsistentes)
        TabControl2.TabPages(0).Controls.Add(PanelNotificaciones)


        ' Ocultar por el momento hasta que se inserte o actualice un evento/item
        TabControl2.Visible = False
    End Sub

    ' GESTION EVENTOS COMPARTIDOS
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ComprobarTabPageParaCargarEventos()
    End Sub

    Private Sub ComprobarTabPageParaCargarEventos()
        If TabControl1.SelectedTab.Text = "Actividades Generales" Then
            'Para recargar los eventos propios si es necesario
            CargarEventosEnDataGridView(_controlador.ObtenerEventosConPodio(CalendarioID))
        ElseIf TabControl1.SelectedTab.Text = "Actividades Asignadas" Then
            ' Llama a la función que carga los eventos compartidos en dgvEventosCompartidos
            Dim email As String = _controlador.ObtenerCorreoUsuario()
            CargarEventosEnDataGridView(_controlador.ObtenerEventosCompartidos(email))
        End If
    End Sub
End Class