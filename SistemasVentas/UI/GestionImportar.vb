Imports Newtonsoft.Json.Linq
Imports OfficeOpenXml
Imports System.IO

Public Class GestionImportar

    Private _controlador As New ControladorEvento()
    Public Property CalendarioID As String
    Public Property UsuarioID As String

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        ' Configurar OpenFileDialog
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "Excel Files|*.xlsx;*.xls",
            .Title = "Seleccionar archivo de Excel"
        }

        ' Mostrar el diálogo y obtener el archivo seleccionado
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim rutaArchivo As String = openFileDialog.FileName
            Dim datos As DataTable = LeerDatosDesdeExcel(rutaArchivo)
            dgvDataExcel.DataSource = datos
        End If
    End Sub

    Public Function LeerDatosDesdeExcel(rutaArchivo As String) As DataTable
        Dim dt As New DataTable()
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        Using package As New ExcelPackage(New FileInfo(rutaArchivo))
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)
            Dim start As ExcelCellAddress = worksheet.Dimension.Start
            Dim [end] As ExcelCellAddress = worksheet.Dimension.[End]

            ' Asumimos que la primera fila contiene los nombres de las columnas
            For col As Integer = start.Column To [end].Column
                dt.Columns.Add(worksheet.Cells(1, col).Text)
            Next

            ' Leer los datos
            For row As Integer = start.Row + 1 To [end].Row
                Dim dataRow As DataRow = dt.NewRow()
                For col As Integer = start.Column To [end].Column
                    dataRow(col - 1) = worksheet.Cells(row, col).Text
                Next
                dt.Rows.Add(dataRow)
            Next
        End Using
        Return dt
    End Function

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Dim currentRow As Integer = 1
        Try
            ' Validar que se haya importado un archivo
            If dgvDataExcel.Rows.Count = 0 Then
                MessageBox.Show("Primero importe un archivo de Excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            For Each row As DataGridViewRow In dgvDataExcel.Rows
                currentRow += 1
                If Not row.IsNewRow Then
                    ' Validar correos de asistentes
                    Dim asistentesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(18).Value?.ToString()), Nothing, row.Cells(18).Value.ToString().Trim().Split(",").ToList())
                    If asistentesEmail Is Nothing OrElse asistentesEmail.All(Function(email) String.IsNullOrWhiteSpace(email)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    ' Validar correos de solicitantes
                    Dim solicitantesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(19).Value?.ToString()), Nothing, row.Cells(19).Value.ToString().Trim().Split(",").ToList())
                    If solicitantesEmail Is Nothing OrElse solicitantesEmail.All(Function(email) String.IsNullOrWhiteSpace(email)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    ' Validar nombres de empresas
                    Dim empresas As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(21).Value?.ToString()), Nothing, row.Cells(21).Value.ToString().Trim().Split(",").ToList())
                    If empresas Is Nothing OrElse empresas.All(Function(empresa) String.IsNullOrWhiteSpace(empresa)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    If asistentesEmail Is Nothing OrElse solicitantesEmail Is Nothing OrElse empresas Is Nothing Then
                        MessageBox.Show("Algunos campos obligatorios no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    Dim autorizantesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(20).Value.ToString()), New List(Of String)(), row.Cells(20).Value.ToString().Trim().Split(",").ToList())
                    Dim proyectosSistemas As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(22).Value.ToString()), New List(Of String)(), row.Cells(22).Value.ToString().Trim().Split(",").ToList())

                    Dim fechaInicio As DateTime
                    If DateTime.TryParse(row.Cells(3).Value?.ToString(), fechaInicio) Then
                        ' Si solo se proporciona la fecha, establecer la hora a las 12:00 PM
                        If fechaInicio.TimeOfDay = TimeSpan.Zero Then
                            fechaInicio = fechaInicio.Date.AddHours(12)
                        End If
                    Else
                        ' Si la fecha no es válida, establecer la fecha actual a las 12:00 PM
                        fechaInicio = DateTime.Now.Date.AddHours(12)
                    End If

                    Dim fechaFin As DateTime
                    If DateTime.TryParse(row.Cells(4).Value?.ToString(), fechaFin) Then
                        ' Si solo se proporciona la fecha, establecer la hora a las 12:00 PM
                        If fechaFin.TimeOfDay = TimeSpan.Zero Then
                            fechaFin = fechaFin.Date.AddHours(12)
                        End If
                    Else
                        ' Si la fecha no es válida, establecer el fin de año actual a las 12:00 PM
                        fechaFin = New DateTime(DateTime.Now.Year, 12, 31, 12, 0, 0)
                    End If

                    ' Crear el evento
                    Dim evento As New Evento() With {
                    .CalendarioID = CalendarioID,
                    .Titulo = If(String.IsNullOrWhiteSpace(row.Cells(0).Value?.ToString()), "Sin titulo", row.Cells(0).Value.ToString()),
                    .Ubicacion = If(String.IsNullOrWhiteSpace(row.Cells(1).Value?.ToString()), "", row.Cells(1).Value.ToString().Trim()),
                    .Descripcion = If(String.IsNullOrWhiteSpace(row.Cells(2).Value?.ToString()), "Sin descripcion", row.Cells(2).Value.ToString()),
                    .FechaInicio = fechaInicio,
                    .FechaFin = fechaFin,
                    .RRULE = If(String.IsNullOrWhiteSpace(row.Cells(5).Value?.ToString()), "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T120000Z", "RRULE:" & row.Cells(5).Value.ToString())
                }

                    Dim eventoID As String = _controlador.EnviarEventoAGoogleCalendar(evento)
                    evento.EventoID = eventoID
                    evento.UserID = UsuarioID
                    _controlador.CrearEvento(evento, True)

                    ' Crear el item en Podio
                    Dim podioItem As New PodioItem()
                    podioItem.EventoID = eventoID
                    podioItem.Titulo = evento.Titulo
                    podioItem.Descripcion = evento.Descripcion

                    ' Validación para Department (obligatorio)
                    Dim departmentValue = row.Cells(7).Value?.ToString().Trim()
                    podioItem.Departamento = If(String.IsNullOrWhiteSpace(departmentValue), podioItem.ObtenerIDSeleccionado("Sistemas", podioItem.departamentoOpciones), podioItem.ObtenerIDSeleccionado(departmentValue, podioItem.departamentoOpciones))

                    ' Validación para DepartmentPriority (obligatorio)
                    Dim departmentPriorityValue = row.Cells(8).Value?.ToString().Trim()
                    podioItem.PrioridadDepartamento = If(String.IsNullOrWhiteSpace(departmentPriorityValue), 0, Integer.Parse(departmentPriorityValue))

                    ' Validación para SystemArea (obligatorio)
                    Dim systemAreaValue = row.Cells(9).Value?.ToString().Trim()
                    podioItem.AreaSistemas = If(String.IsNullOrWhiteSpace(systemAreaValue), podioItem.ObtenerIDSeleccionado("Desarrollo", podioItem.areaSistemasOpciones), podioItem.ObtenerIDSeleccionado(systemAreaValue, podioItem.areaSistemasOpciones))

                    ' Validación para Categories (obligatorio)
                    Dim categoryValue = row.Cells(10).Value?.ToString().Trim()
                    podioItem.Categorias = If(String.IsNullOrWhiteSpace(categoryValue), podioItem.ObtenerIDSeleccionado("[DESARROLLO] Desarrollo General", podioItem.categoriaOpciones), podioItem.ObtenerIDSeleccionado(categoryValue, podioItem.categoriaOpciones))

                    ' Validación para SystemPriority (obligatorio)
                    Dim systemPriorityValue = row.Cells(11).Value?.ToString().Trim()
                    podioItem.PrioridadSistemas = If(String.IsNullOrWhiteSpace(systemPriorityValue), 0, Integer.Parse(systemPriorityValue))

                    ' Validación para Priority (opcional)
                    Dim priorityValue = row.Cells(12).Value?.ToString().Trim()
                    podioItem.Prioridad = If(String.IsNullOrWhiteSpace(priorityValue), podioItem.ObtenerIDSeleccionado("De Acuerdo a Fecha de Entrega", podioItem.prioridadOpciones), podioItem.ObtenerIDSeleccionado(priorityValue, podioItem.prioridadOpciones))

                    ' StartDate y EndDate (obligatorios)
                    podioItem.FechaInicio = If(evento.FechaInicio = DateTime.MinValue, DateTime.Now, evento.FechaInicio)
                    podioItem.FechaFin = If(evento.FechaFin = DateTime.MinValue, DateTime.Now, evento.FechaFin)

                    ' Validación para WorkPlan (opcional)
                    Dim workPlanValue = row.Cells(13).Value?.ToString()
                    podioItem.PlanTrabajo = If(String.IsNullOrWhiteSpace(workPlanValue), "", workPlanValue)

                    ' Validación para Status (obligatorio)
                    Dim statusValue = row.Cells(17).Value?.ToString().Trim()
                    podioItem.Status = If(String.IsNullOrWhiteSpace(statusValue), podioItem.ObtenerIDSeleccionado("No comenzada / Pendiente", podioItem.statusOpciones), podioItem.ObtenerIDSeleccionado(statusValue, podioItem.statusOpciones))

                    ' Validación para Progress (opcional)
                    Dim progressValue = row.Cells(14).Value?.ToString().Trim()
                    podioItem.Progreso = If(String.IsNullOrWhiteSpace(progressValue), 0, Integer.Parse(progressValue))

                    ' Validación para HoursAccumulated (opcional)
                    Dim hoursAccumulatedValue = row.Cells(15).Value?.ToString().Trim()
                    podioItem.HorasAcumuladas = If(String.IsNullOrWhiteSpace(hoursAccumulatedValue), Nothing, Integer.Parse(hoursAccumulatedValue))

                    ' Validación para ExtraHours (opcional)
                    Dim extraHoursValue = row.Cells(16).Value?.ToString().Trim()
                    podioItem.HorasExtras = If(String.IsNullOrWhiteSpace(extraHoursValue), Nothing, Integer.Parse(extraHoursValue))


                    Dim podioItemID As Integer = _controlador.CrearPodioItem(podioItem)
                    podioItem.PodioItemID = podioItemID

                    Dim mensaje As New Mensaje()
                    ' Creal el mensaje a enviar a cada asistente
                    For Each email As String In asistentesEmail
                        podioItem.ContactosAsigandoA.Add(_controlador.ObtenerPodioUserIDPorCorreo(email.Trim()))

                        mensaje.EventoID = eventoID
                        mensaje.UserID = _controlador.BuscarUserID(email.Trim())
                        mensaje.TipoMensaje = If(String.IsNullOrWhiteSpace(row.Cells(6).Value?.ToString()), "Nueva Actividad", row.Cells(6).Value.ToString().Trim())
                        mensaje.RRULE = evento.RRULE

                        Dim asistente As New Asistente() With {
                        .EventoID = eventoID,
                        .Email = email.Trim(),
                        .Telefono = _controlador.ObtenerTelefonoAsistente(email.Trim()),
                        .PodioItemID = podioItem.PodioItemID
                        }

                        evento.Asistentes.Add(asistente)
                        mensaje.Destinatarios.Add(asistente)
                        _controlador.InsertarAsistente(mensaje, podioItemID)
                    Next

                    ' Crear a los solicitantes
                    For Each email As String In solicitantesEmail
                        podioItem.ContactosSolicitantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(email.Trim()))
                    Next
                    _controlador.InsertarSolicitante(podioItem)

                    ' Crear a los autorizantes
                    For Each email As String In autorizantesEmail
                        podioItem.ContactosAutorizantes.Add(_controlador.ObtenerPodioUserIDPorCorreo(email.Trim()))
                    Next
                    _controlador.InsertarAutorizante(podioItem)

                    ' Crear a las empresas
                    For Each empresa As String In empresas
                        Dim empresaID = podioItem.ObtenerIDSeleccionado(empresa.Trim(), podioItem.empresaOpciones).ToString()
                        podioItem.Empresa.Add(empresaID)
                        ' Insertar empresa en BD
                        _controlador.InsertarPodioEmpresa(podioItem, empresaID)
                    Next

                    For Each proyecto As String In proyectosSistemas
                        Dim proyectoID As JArray = SearchItemPodio(proyecto.Trim()).Result ' Buscar el proyecto en Podio y obtiene su ID
                        If proyectoID.Count > 0 Then
                            podioItem.ProyectoSistemas.Add(proyectoID(0)("id").ToString()) ' Agregar el proyecto a la lista de proyectos
                            _controlador.InsertarPodioProyectoSistemas(podioItemID, proyectoID(0)("id").ToString(), proyecto) ' Insertar el proyecto en la BD
                        End If
                    Next

                    ' Actualizar el evento con los asistentes
                    _controlador.ActualizarEvento(evento)

                    Dim podioAppItemID As Long = _controlador.EnviarItemAPodio(podioItem)
                    _controlador.ActualizarPodioAppItemID(podioItemID, podioAppItemID)

                    ' Enviar mensaje a todos los asignados
                    mensaje.PodioAppItemID = podioAppItemID
                    mensaje.Titulo = evento.Titulo
                    mensaje.Descripcion = evento.Descripcion
                    mensaje.FechaInicio = evento.FechaInicio
                    mensaje.FechaFin = evento.FechaFin

                    ' Enviar mensajes a los asistentes/asignados
                    _controlador.EnviarEmail(mensaje)
                    _controlador.EnviarWhatsApp(mensaje)
                End If
            Next
            MessageBox.Show("La importación se realizó con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ' Notificar en que fila o que parte provocó el error
            MessageBox.Show("Ocurrió un error en la fila: " & currentRow & " al procesar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Función para obtener el item de podio
    Public Async Function SearchItemPodio(proyecto As String) As Threading.Tasks.Task(Of JArray)
        Dim podioService As New ServicioPodio()
        Dim itemID As JArray = Await _controlador.SearchItemPodio(proyecto, 1).ConfigureAwait(False)
        Return itemID
    End Function

    Private Sub btnDescargarFormato_Click(sender As Object, e As EventArgs) Handles btnDescargarFormato.Click
        ' Configurar SaveFileDialog
        Dim saveFileDialog As New SaveFileDialog With {
            .Filter = "Excel Files|*.xlsx;*.xls",
            .Title = "Guardar archivo de Excel"
        }

        ' Mostrar el diálogo y obtener la ruta de guardado
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim rutaArchivo As String = saveFileDialog.FileName
            CrearFormatoExcel(rutaArchivo)
        End If
    End Sub

    ' Crear un formato de Excel de ejemplo con sus columnas y una fila de ejemplo
    Public Sub CrearFormatoExcel(rutaArchivo As String)
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn() {
            New DataColumn("Titulo", GetType(String)),
            New DataColumn("Ubicación", GetType(String)),
            New DataColumn("Descripción", GetType(String)),
            New DataColumn("Fecha de inicio", GetType(String)),
            New DataColumn("Fecha de fin", GetType(String)),
            New DataColumn("Recurrencia", GetType(String)),
            New DataColumn("Tipo de mensaje", GetType(String)),
            New DataColumn("Departamento", GetType(String)),
            New DataColumn("Prioridad de departamento", GetType(String)),
            New DataColumn("Área de sistemas", GetType(String)),
            New DataColumn("Categorías", GetType(String)),
            New DataColumn("Prioridad sistemas", GetType(String)),
            New DataColumn("Prioridad", GetType(String)),
            New DataColumn("Plan de trabajo", GetType(String)),
            New DataColumn("Progreso", GetType(String)),
            New DataColumn("Horas acumuladas", GetType(String)),
            New DataColumn("Horas extra", GetType(String)),
            New DataColumn("Status", GetType(String)),
            New DataColumn("Asignados Email", GetType(String)),
            New DataColumn("Solicitantes Email", GetType(String)),
            New DataColumn("Autorizantes Email", GetType(String)),
            New DataColumn("Empresas", GetType(String)),
            New DataColumn("Proyectos de sistemas", GetType(String))
        })

        ' Crear una fila de ejemplo
        Dim exampleRow As DataRow = dt.NewRow()
        exampleRow("Titulo") = "Actividad 1"
        exampleRow("Ubicación") = ""
        exampleRow("Descripción") = "Reunión para discutir el progreso del proyecto"
        exampleRow("Fecha de inicio") = "27/05/2024"
        exampleRow("Fecha de fin") = "31/12/2024"
        exampleRow("Recurrencia") = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z"
        exampleRow("Tipo de mensaje") = "Nueva Actividad"
        exampleRow("Departamento") = "Sistemas"
        exampleRow("Prioridad de departamento") = "1"
        exampleRow("Área de sistemas") = "Desarrollo"
        exampleRow("Categorías") = "[ADMIN] Podio"
        exampleRow("Prioridad sistemas") = "2"
        exampleRow("Prioridad") = "Baja"
        exampleRow("Plan de trabajo") = "Revisar tareas pendientes y asignar nuevas tareas"
        exampleRow("Progreso") = "50"
        exampleRow("Horas acumuladas") = "60"
        exampleRow("Horas extra") = ""
        exampleRow("Status") = "En Pruebas"
        exampleRow("Asignados Email") = "ejemplo@correo.com, correo2@order.com"
        exampleRow("Solicitantes Email") = "solicitante@correo.com"
        exampleRow("Autorizantes Email") = ""
        exampleRow("Empresas") = "Incorporated Express SA de CV, FUNERA"
        exampleRow("Proyectos de sistemas") = "Twilio"

        dt.Rows.Add(exampleRow)

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial ' Establecer la licencia para uso no comercial y poder usar la libreria EPPlus
        Using package As New ExcelPackage()
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Formato")
            worksheet.Cells("A1").LoadFromDataTable(dt, True)
            package.SaveAs(New FileInfo(rutaArchivo))
        End Using
        MessageBox.Show("El formato de Excel se ha guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class