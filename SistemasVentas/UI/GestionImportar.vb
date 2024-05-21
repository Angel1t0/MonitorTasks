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
                    Dim asistentesEmail As List(Of String) = row.Cells(18).Value.ToString().Split(",").ToList()
                    Dim solicitantesEmail As List(Of String) = row.Cells(19).Value.ToString().Split(",").ToList()
                    Dim autorizantesEmail As List(Of String) = row.Cells(20).Value.ToString().Split(",").ToList()
                    Dim empresas As List(Of String) = row.Cells(21).Value.ToString().Split(",").ToList()
                    Dim proyectosSistemas As List(Of String) = row.Cells(22).Value.ToString().Split(",").ToList()

                    ' Crear el evento
                    Dim evento As New Evento() With {
                    .CalendarID = CalendarioID,
                    .Summary = row.Cells(0).Value.ToString(),
                    .Location = row.Cells(1).Value.ToString(),
                    .Description = row.Cells(2).Value.ToString(),
                    .StartDateTime = DateTime.Parse(row.Cells(3).Value.ToString()),
                    .EndDateTime = DateTime.Parse(row.Cells(4).Value.ToString()),
                    .RRULE = "RRULE:" & row.Cells(5).Value.ToString()
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
                    podioItem.Department = podioItem.GetSelectedOptionId(row.Cells(7).Value.ToString(), podioItem.departmentOptions)
                    podioItem.DepartmentPriority = Integer.Parse(row.Cells(8).Value.ToString())
                    podioItem.SystemArea = podioItem.GetSelectedOptionId(row.Cells(9).Value.ToString(), podioItem.systemAreaOptions)
                    podioItem.Categories = podioItem.GetSelectedOptionId(row.Cells(10).Value.ToString(), podioItem.categoryOptions)
                    podioItem.SystemPriority = Integer.Parse(row.Cells(11).Value.ToString())
                    podioItem.Priority = podioItem.GetSelectedOptionId(row.Cells(12).Value.ToString(), podioItem.priorityOptions)
                    podioItem.StartDate = evento.StartDateTime
                    podioItem.EndDate = evento.EndDateTime
                    podioItem.WorkPlan = row.Cells(13).Value.ToString()
                    podioItem.Status = podioItem.GetSelectedOptionId(row.Cells(17).Value.ToString(), podioItem.statusOptions)
                    podioItem.Progress = Integer.Parse(row.Cells(14).Value.ToString())
                    podioItem.HoursAccumulated = Integer.Parse(row.Cells(15).Value.ToString())
                    podioItem.ExtraHours = Integer.Parse(row.Cells(16).Value.ToString())

                    Dim podioItemID As Integer = _controlador.CrearPodioItem(podioItem)
                    podioItem.PodioItemID = podioItemID

                    ' Creal el mensaje a enviar a cada asistente
                    For Each email As String In asistentesEmail
                        podioItem.AssignedToContacts.Add(_controlador.ObtenerPodioUserIDPorCorreo(email))
                        Dim mensaje As New Mensaje() With {
                        .EventID = eventoID,
                        .UserID = _controlador.BuscarUserID(email),
                        .MessageType = row.Cells(8).Value.ToString(),
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
End Class