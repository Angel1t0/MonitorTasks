Imports Newtonsoft.Json.Linq
Imports OfficeOpenXml
Imports System.IO

Public Class GestionImportar

    Private _controlador As New EventoControlador()
    Public Property CalendarioID As String
    Public Property UsuarioID As String
    Private Sub GestionImportar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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
        Try
            ' Validar que se haya importado un archivo
            If dgvDataExcel.Rows.Count = 0 Then
                MessageBox.Show("Primero importe un archivo de Excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            For Each row As DataGridViewRow In dgvDataExcel.Rows
                If Not row.IsNewRow Then
                    ' Validar correos de asistentes
                    Dim asistentesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(18).Value?.ToString()), Nothing, row.Cells(18).Value.ToString().Split(",").ToList())
                    If asistentesEmail Is Nothing OrElse asistentesEmail.All(Function(email) String.IsNullOrWhiteSpace(email)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    ' Validar correos de solicitantes
                    Dim solicitantesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(19).Value?.ToString()), Nothing, row.Cells(19).Value.ToString().Split(",").ToList())
                    If solicitantesEmail Is Nothing OrElse solicitantesEmail.All(Function(email) String.IsNullOrWhiteSpace(email)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    ' Validar nombres de empresas
                    Dim empresas As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(21).Value?.ToString()), Nothing, row.Cells(21).Value.ToString().Split(",").ToList())
                    If empresas Is Nothing OrElse empresas.All(Function(empresa) String.IsNullOrWhiteSpace(empresa)) Then
                        Continue For ' Saltar al siguiente registro si está vacío
                    End If

                    Dim autorizantesEmail As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(20).Value.ToString()), New List(Of String)(), row.Cells(20).Value.ToString().Split(",").ToList())
                    Dim proyectosSistemas As List(Of String) = If(String.IsNullOrWhiteSpace(row.Cells(22).Value.ToString()), New List(Of String)(), row.Cells(22).Value.ToString().Split(",").ToList())

                    ' Crear el evento
                    Dim evento As New Evento() With {
                    .CalendarID = CalendarioID,
                    .Summary = If(String.IsNullOrWhiteSpace(row.Cells(0).Value?.ToString()), "Sin titulo", row.Cells(0).Value.ToString()),
                    .Location = If(String.IsNullOrWhiteSpace(row.Cells(1).Value?.ToString()), "", row.Cells(1).Value.ToString()),
                    .Description = If(String.IsNullOrWhiteSpace(row.Cells(2).Value?.ToString()), "Sin descripcion", row.Cells(2).Value.ToString()),
                    .StartDateTime = If(DateTime.TryParse(row.Cells(3).Value?.ToString(), Nothing), DateTime.Parse(row.Cells(3).Value.ToString()), DateTime.Now),
                    .EndDateTime = If(DateTime.TryParse(row.Cells(4).Value?.ToString(), Nothing), DateTime.Parse(row.Cells(4).Value.ToString()), New DateTime(DateTime.Now.Year, 12, 31)),
                    .RRULE = If(String.IsNullOrWhiteSpace(row.Cells(5).Value?.ToString()), "RRULE:FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;UNTIL=" & DateTime.Now.Year.ToString() & "1231T000000Z", "RRULE:" & row.Cells(5).Value.ToString())
                }

                    Dim eventoID As String = _controlador.EnviarEventoAGoogleCalendar(evento)
                    evento.EventID = eventoID
                    evento.UserID = UsuarioID
                    _controlador.CrearEvento(evento, True)

                    ' Crear el item en Podio
                    Dim podioItem As New PodioItem()
                    podioItem.EventID = eventoID
                    podioItem.Title = evento.Summary
                    podioItem.Description = evento.Description

                    ' Validación para Department (obligatorio)
                    Dim departmentValue = row.Cells(7).Value?.ToString()
                    podioItem.Department = If(String.IsNullOrWhiteSpace(departmentValue), podioItem.GetSelectedOptionId("Sistemas", podioItem.departmentOptions), podioItem.GetSelectedOptionId(departmentValue, podioItem.departmentOptions))

                    ' Validación para DepartmentPriority (obligatorio)
                    Dim departmentPriorityValue = row.Cells(8).Value?.ToString()
                    podioItem.DepartmentPriority = If(String.IsNullOrWhiteSpace(departmentPriorityValue), 0, Integer.Parse(departmentPriorityValue))

                    ' Validación para SystemArea (obligatorio)
                    Dim systemAreaValue = row.Cells(9).Value?.ToString()
                    podioItem.SystemArea = If(String.IsNullOrWhiteSpace(systemAreaValue), podioItem.GetSelectedOptionId("Desarrollo", podioItem.systemAreaOptions), podioItem.GetSelectedOptionId(systemAreaValue, podioItem.systemAreaOptions))

                    ' Validación para Categories (obligatorio)
                    Dim categoryValue = row.Cells(10).Value?.ToString()
                    podioItem.Categories = If(String.IsNullOrWhiteSpace(categoryValue), podioItem.GetSelectedOptionId("[DESARROLLO] Desarrollo General", podioItem.categoryOptions), podioItem.GetSelectedOptionId(categoryValue, podioItem.categoryOptions))

                    ' Validación para SystemPriority (obligatorio)
                    Dim systemPriorityValue = row.Cells(11).Value?.ToString()
                    podioItem.SystemPriority = If(String.IsNullOrWhiteSpace(systemPriorityValue), 0, Integer.Parse(systemPriorityValue))

                    ' Validación para Priority (opcional)
                    Dim priorityValue = row.Cells(12).Value?.ToString()
                    podioItem.Priority = If(String.IsNullOrWhiteSpace(priorityValue), Nothing, podioItem.GetSelectedOptionId(priorityValue, podioItem.priorityOptions))

                    ' StartDate y EndDate (obligatorios)
                    podioItem.StartDate = If(evento.StartDateTime = DateTime.MinValue, DateTime.Now, evento.StartDateTime)
                    podioItem.EndDate = If(evento.EndDateTime = DateTime.MinValue, DateTime.Now.AddHours(1), evento.EndDateTime)

                    ' Validación para WorkPlan (opcional)
                    Dim workPlanValue = row.Cells(13).Value?.ToString()
                    podioItem.WorkPlan = If(String.IsNullOrWhiteSpace(workPlanValue), Nothing, workPlanValue)

                    ' Validación para Status (obligatorio)
                    Dim statusValue = row.Cells(17).Value?.ToString()
                    podioItem.Status = If(String.IsNullOrWhiteSpace(statusValue), podioItem.GetSelectedOptionId("No comenzada / Pendiente", podioItem.statusOptions), podioItem.GetSelectedOptionId(statusValue, podioItem.statusOptions))

                    ' Validación para Progress (opcional)
                    Dim progressValue = row.Cells(14).Value?.ToString()
                    podioItem.Progress = If(String.IsNullOrWhiteSpace(progressValue), Nothing, Integer.Parse(progressValue))

                    ' Validación para HoursAccumulated (opcional)
                    Dim hoursAccumulatedValue = row.Cells(15).Value?.ToString()
                    podioItem.HoursAccumulated = If(String.IsNullOrWhiteSpace(hoursAccumulatedValue), Nothing, Integer.Parse(hoursAccumulatedValue))

                    ' Validación para ExtraHours (opcional)
                    Dim extraHoursValue = row.Cells(16).Value?.ToString()
                    podioItem.ExtraHours = If(String.IsNullOrWhiteSpace(extraHoursValue), Nothing, Integer.Parse(extraHoursValue))


                    Dim podioItemID As Integer = _controlador.CrearPodioItem(podioItem)
                    podioItem.PodioItemID = podioItemID

                    ' Creal el mensaje a enviar a cada asistente
                    For Each email As String In asistentesEmail
                        podioItem.AssignedToContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(email))
                        Dim mensaje As New Mensaje() With {
                        .EventID = eventoID,
                        .UserID = _controlador.BuscarUserID(email),
                        .MessageType = If(String.IsNullOrWhiteSpace(row.Cells(6).Value?.ToString()), "Nuevo Evento", row.Cells(6).Value.ToString()),
                        .RRULE = evento.RRULE
                        }

                        Dim asistente As New Asistente() With {
                        .EventID = eventoID,
                        .Email = email.Trim(),
                        .PodioItemID = podioItem.PodioItemID
                        }

                        mensaje.Attendees.Add(asistente)
                        _controlador.InsertarAsistente(mensaje, podioItemID)
                    Next

                    ' Crear a los solicitantes
                    For Each email As String In solicitantesEmail
                        podioItem.RequestorContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(email))
                    Next
                    _controlador.InsertarSolicitante(podioItem)

                    ' Crear a los autorizantes
                    For Each email As String In autorizantesEmail
                        podioItem.AuthorizerContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(email))
                    Next
                    _controlador.InsertarAutorizante(podioItem)

                    ' Crear a las empresas
                    For Each empresa As String In empresas
                        Dim empresaID = podioItem.GetSelectedOptionId(empresa, podioItem.companyOptions).ToString()
                        podioItem.Company.Add(empresaID)
                        ' Insertar empresa en BD
                        _controlador.InsertarPodioEmpresa(podioItem, empresaID)
                    Next

                    For Each proyecto As String In proyectosSistemas
                        Dim proyectoID As JArray = SearchItemPodio(proyecto).Result
                        If proyectoID.Count > 0 Then
                            podioItem.SystemProject.Add(proyectoID(0)("id").ToString())
                            _controlador.InsertarPodioProyectoSistemas(podioItemID, proyectoID(0)("id").ToString(), proyecto)
                        End If
                    Next

                    Dim podioAppItemID As Long = _controlador.EnviarItemAPodio(podioItem)
                    _controlador.ActualizarPodioAppItemID(podioItemID, podioAppItemID)

                    ' Aquí puedes llamar a los métodos para crear el evento en Google Calendar,
                    ' crear el ítem en Podio y luego insertar los datos en la base de datos.
                End If
            Next
            MessageBox.Show("La importación se realizó con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al procesar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Función para obtener el item de podio
    Public Async Function SearchItemPodio(proyecto As String) As Threading.Tasks.Task(Of JArray)
        Dim podioService As New PodioService()
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
        exampleRow("Tipo de mensaje") = "Nuevo Evento"
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

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        Using package As New ExcelPackage()
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Formato")
            worksheet.Cells("A1").LoadFromDataTable(dt, True)
            package.SaveAs(New FileInfo(rutaArchivo))
        End Using
        MessageBox.Show("El formato de Excel se ha guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class