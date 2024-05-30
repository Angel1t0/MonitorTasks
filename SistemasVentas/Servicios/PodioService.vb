Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports PodioAPI
Imports PodioAPI.Models
Imports PodioAPI.Utils.Authentication
Imports PodioAPI.Utils.ItemFields
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports HtmlAgilityPack
Imports Twilio.Rest.FlexApi.V1

Public Class PodioService
    Private httpClient As New HttpClient()
    Private _controlador As EventoControlador

    'Variable de entorno
    Dim podioClientID As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_ID")
    Dim podioClientSecret As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_SECRET")
    Dim podioAppID As String = Environment.GetEnvironmentVariable("PODIO_APP_ID")
    Dim podioAppToken As String = Environment.GetEnvironmentVariable("PODIO_APP_TOKEN")

    Public Sub New(controlador As EventoControlador)
        _controlador = controlador
    End Sub

    Public Sub New()

    End Sub

    Private Async Function Authenticate() As Threading.Tasks.Task
        Dim requestContent As New StringContent($"grant_type=app&app_id={podioAppID}&app_token={podioAppToken}&client_id={podioClientID}&client_secret={podioClientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded")
        Try
            Dim response = Await httpClient.PostAsync("https://api.podio.com/oauth/token", requestContent).ConfigureAwait(False)
            If response.IsSuccessStatusCode Then
                Dim content = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                Dim tokenObj = JObject.Parse(content)
                Dim accessToken = tokenObj("access_token").ToString()
                httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken)
            Else
                Dim errorContent = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                Console.WriteLine($"Authentication failed: {response.StatusCode}, {errorContent}")
                'Throw New Exception("Failed to authenticate with Podio API.")
            End If
        Catch ex As HttpRequestException
            Console.WriteLine($"HTTP Request Error: {ex.Message}")
            Throw
        Catch ex As Exception
            Console.WriteLine($"General Error: {ex.Message}")
            Throw
        End Try
    End Function


    Private Async Function EnsureAuthenticated() As Threading.Tasks.Task
        If httpClient.DefaultRequestHeaders.Authorization Is Nothing Then
            Await Authenticate().ConfigureAwait(False)
        End If
    End Function

    Public Async Function CreateItem(podioItem As PodioItem) As Task(Of Long)
        Try
            Await EnsureAuthenticated().ConfigureAwait(False)  ' Asegura autenticación

            ' Crea el objeto JSON para los campos
            Dim itemFields As New JObject()

            itemFields.Add("10086319", podioItem.Title) ' Título
            itemFields.Add("50907911", podioItem.Description) ' Descripción
            itemFields.Add("50907912", New JArray(podioItem.Company.Select(Function(company) New JObject From {{"value", Integer.Parse(company)}}))) ' Empresa
            itemFields.Add("191364514", New JObject From {{"value", Integer.Parse(podioItem.Department)}}) ' Departamento
            itemFields.Add("203943021", New JObject From {{"value", Integer.Parse(podioItem.SystemArea)}}) ' Área de sistemas
            itemFields.Add("57128977", New JObject From {{"value", Integer.Parse(podioItem.Categories)}}) ' Categoría
            itemFields.Add("50907913", New JArray(podioItem.RequestorContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Solicitante
            itemFields.Add("50907915", New JArray(podioItem.AssignedToContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Asignado a
            itemFields.Add("50907916", New JObject From {{"value", Integer.Parse(podioItem.Priority)}}) ' Prioridad
            itemFields.Add("50908150", New JObject From {{"value", Integer.Parse(podioItem.Status)}}) ' Estado


            ' Condiciones para saber si esta vacio o es nulo, ya que no acepta valores nulos
            If podioItem.DepartmentPriority <> Nothing Then
                itemFields.Add("191362674", New JObject From {{"value", podioItem.DepartmentPriority}}) ' Orden de prioridad por departamento
            End If

            If podioItem.AuthorizerContacts IsNot Nothing Then
                itemFields.Add("50907914", New JArray(podioItem.AuthorizerContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Autorizante
            End If

            If podioItem.SystemPriority <> Nothing Then
                itemFields.Add("189076789", New JObject From {{"value", podioItem.SystemPriority}}) ' Orden de prioridad de sistemas
            End If

            If podioItem.StartDate <> Nothing Then
                itemFields.Add("10086320", New JObject From {{"start", podioItem.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}}) ' Fecha de inicio
            End If

            If podioItem.EndDate <> Nothing Then
                itemFields.Add("50907917", New JObject From {{"start", podioItem.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}}) ' Fecha de fin
            End If

            If Not String.IsNullOrWhiteSpace(podioItem.WorkPlan) Then
                itemFields.Add("75115253", podioItem.WorkPlan) ' Plan de trabajo
            End If

            If podioItem.Progress <> Nothing Then
                itemFields.Add("50907918", New JObject From {{"value", podioItem.Progress}}) ' Progreso
            End If

            If podioItem.SystemProject IsNot Nothing Then
                itemFields.Add("50907910", New JArray(podioItem.SystemProject.Select(Function(project) New JObject From {{"value", Long.Parse(project)}}))) ' Proyecto de sistemas
            End If

            If podioItem.GeneralProject <> Nothing Then
                itemFields.Add("104722848", New JObject From {{"value", Long.Parse(podioItem.GeneralProject)}}) ' Proyecto general
            End If

            If podioItem.HoursAccumulated <> Nothing Then
                itemFields.Add("50907919", New JObject From {{"value", podioItem.HoursAccumulated}}) ' Horas acumuladas
            End If

            If podioItem.ExtraHours <> Nothing Then
                itemFields.Add("51007152", New JObject From {{"value", podioItem.ExtraHours}}) ' Horas extras
            End If

            ' Preparar el objeto JSON final para la solicitud
            Dim itemObject As New JObject From {{"fields", itemFields}}

            Try
                Dim content As New StringContent(itemObject.ToString(), Encoding.UTF8, "application/json")
                Dim response = Await httpClient.PostAsync($"https://api.podio.com/item/app/{podioItem.PodioAppID}/", content).ConfigureAwait(False)
                If response.IsSuccessStatusCode Then
                    Dim resultString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Dim result = JObject.Parse(resultString)
                    Dim itemId = result("item_id").Value(Of Long)()
                    Console.WriteLine("Item creado con ID: " & itemId)
                    Return itemId
                Else
                    Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Console.WriteLine("Error creando item: " & response.StatusCode & " " & errorDetails)
                    Throw New Exception("Failed to create item in Podio. Status: " & response.StatusCode)
                End If
            Catch ex As HttpRequestException
                Console.WriteLine("Error en la solicitud HTTP. Detalles: " & ex.Message)
            Catch ex As Exception
                If ex.Message.Contains("Valor demasiado grande o demasiado pequeño para Int32.") Or ex.Message.Contains("La operación aritmética ha provocado un desbordamiento.") Or ex.Message.Contains("is too large or small for an") Or ex.Message.Contains("Arithmetic operation resulted in an overflow.") Then
                    Return True
                Else
                    Console.WriteLine("Error general al intentar crear el ítem en Podio. Detalles: " & ex.Message)
                    Return False
                End If
            End Try
        Catch ex As Exception
            Console.WriteLine("Error general al intentar crear el ítem en Podio. Detalles: " & ex.Message)
        End Try
    End Function

    Public Async Function UpdatePodioItem(podioItem As PodioItem) As Threading.Tasks.Task
        Try
            Await EnsureAuthenticated().ConfigureAwait(False)  ' Asegura autenticación

            ' Crea el objeto JSON para los campos
            Dim itemFields As New JObject()

            itemFields.Add("10086319", podioItem.Title) ' Título
            itemFields.Add("50907911", podioItem.Description) ' Descripción
            itemFields.Add("50907912", New JArray(podioItem.Company.Select(Function(company) New JObject From {{"value", Integer.Parse(company)}}))) ' Empresa
            itemFields.Add("191364514", New JObject From {{"value", Integer.Parse(podioItem.Department)}}) ' Departamento
            itemFields.Add("203943021", New JObject From {{"value", Integer.Parse(podioItem.SystemArea)}}) ' Área de sistemas
            itemFields.Add("57128977", New JObject From {{"value", Integer.Parse(podioItem.Categories)}}) ' Categoría
            itemFields.Add("50907913", New JArray(podioItem.RequestorContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Solicitante
            itemFields.Add("50907915", New JArray(podioItem.AssignedToContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Asignado a
            itemFields.Add("50907916", New JObject From {{"value", Integer.Parse(podioItem.Priority)}}) ' Prioridad
            itemFields.Add("50908150", New JObject From {{"value", Integer.Parse(podioItem.Status)}}) ' Estado


            ' Condiciones para saber si esta vacio o es nulo, ya que no acepta valores nulos
            If podioItem.DepartmentPriority <> Nothing Then
                itemFields.Add("191362674", New JObject From {{"value", podioItem.DepartmentPriority}}) ' Orden de prioridad por departamento
            End If

            If podioItem.AuthorizerContacts.Count > 0 Then
                itemFields.Add("50907914", New JArray(podioItem.AuthorizerContacts.Select(Function(id) New JObject From {{"value", id}}))) ' Autorizante
            End If

            If podioItem.SystemPriority <> Nothing Then
                itemFields.Add("189076789", New JObject From {{"value", podioItem.SystemPriority}}) ' Orden de prioridad de sistemas
            End If

            If podioItem.StartDate <> Nothing Then
                itemFields.Add("10086320", New JObject From {{"start", podioItem.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}}) ' Fecha de inicio
            End If

            If podioItem.EndDate <> Nothing Then
                itemFields.Add("50907917", New JObject From {{"start", podioItem.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}}) ' Fecha de fin
            End If

            If podioItem.WorkPlan <> Nothing Then
                itemFields.Add("75115253", podioItem.WorkPlan) ' Plan de trabajo
            End If

            If podioItem.Progress <> Nothing Then
                itemFields.Add("50907918", New JObject From {{"value", podioItem.Progress}}) ' Progreso
            End If

            If podioItem.SystemProject IsNot Nothing Then
                itemFields.Add("50907910", New JArray(podioItem.SystemProject.Select(Function(project) New JObject From {{"value", Long.Parse(project)}}))) ' Proyecto de sistemas
            Else
                'Eliminar campo de proyecto de sistemas 50907910
                itemFields.Add("50907910", New JArray()) ' Proyecto de sistemas
            End If

            If podioItem.GeneralProject <> Nothing Then
                itemFields.Add("104722848", New JObject From {{"value", Long.Parse(podioItem.GeneralProject)}}) ' Proyecto general
            End If

            If podioItem.HoursAccumulated <> Nothing Then
                itemFields.Add("50907919", New JObject From {{"value", podioItem.HoursAccumulated}}) ' Horas acumuladas
            End If

            If podioItem.ExtraHours <> Nothing Then
                itemFields.Add("51007152", New JObject From {{"value", podioItem.ExtraHours}}) ' Horas extras
            End If

            ' Preparar el objeto JSON final para la solicitud
            Dim itemObject As New JObject From {{"fields", itemFields}}

            Try
                Dim content As New StringContent(itemObject.ToString(), Encoding.UTF8, "application/json")
                Dim response = Await httpClient.PutAsync($"https://api.podio.com/item/{podioItem.PodioAppItemID}", content).ConfigureAwait(False)
                If response.IsSuccessStatusCode Then
                    Console.WriteLine("Item actualizado correctamente")
                Else
                    Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Console.WriteLine("Error actualizando item: " & response.StatusCode & " " & errorDetails)
                    Throw New Exception("Failed to create item in Podio. Status: " & response.StatusCode)
                End If
            Catch ex As HttpRequestException
                Console.WriteLine("Error en la solicitud HTTP. Detalles: " & ex.Message)
            Catch ex As Exception
                Console.WriteLine("Error general al intentar actualizar el ítem en Podio. Detalles: " & ex.Message)
            End Try
        Catch ex As Exception
            Console.WriteLine("Error general al actualizar crear el ítem en Podio. Detalles: " & ex.Message)
        End Try
    End Function

    Public Async Function SearchAppByQuery(query As String, limit As Integer) As Task(Of JArray)
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim content As New StringContent(JsonConvert.SerializeObject(New With {Key .query = query, Key .limit = limit}), Encoding.UTF8, "application/json")
        Dim response = Await httpClient.PostAsync("https://api.podio.com/search/app/6552674", content).ConfigureAwait(False)

        If response.IsSuccessStatusCode Then
            Dim result = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Return JArray.Parse(result)
        Else
            Throw New Exception($"Error al buscar en la app: {response.StatusCode}")
        End If
    End Function

    Public Async Function DeletePodioItem(itemId As Long) As Threading.Tasks.Task
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim response = Await httpClient.DeleteAsync($"https://api.podio.com/item/{itemId}").ConfigureAwait(False)
        If response.IsSuccessStatusCode Then
            Console.WriteLine("Item eliminado correctamente")
        Else
            Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Console.WriteLine("Error eliminando item: " & response.StatusCode & " " & errorDetails)
            Throw New Exception("Failed to delete item in Podio. Status: " & response.StatusCode)
        End If
    End Function

    Public Async Function GetCommentsByItem(itemId As Long) As Task(Of JArray)
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim response = Await httpClient.GetAsync($"https://api.podio.com/comment/item/{itemId}/").ConfigureAwait(False)
        If response.IsSuccessStatusCode Then
            Dim result = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Return JArray.Parse(result)
        Else
            Throw New Exception($"Error al obtener comentarios del ítem: {response.StatusCode}")
        End If
    End Function

    Public Async Function AddCommentByItem(itemId As Long, comment As String) As Threading.Tasks.Task
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim commentObject As New JObject From {{"value", comment}}
        Dim content As New StringContent(commentObject.ToString(), Encoding.UTF8, "application/json")
        Dim response = Await httpClient.PostAsync($"https://api.podio.com/comment/item/{itemId}/", content).ConfigureAwait(False)
        If response.IsSuccessStatusCode Then
            Console.WriteLine("Comentario agregado correctamente")
        Else
            Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Console.WriteLine("Error agregando comentario: " & response.StatusCode & " " & errorDetails)
            Throw New Exception("Failed to add comment in Podio. Status: " & response.StatusCode)
        End If
    End Function

    Public Async Function ClonarPodioItem(podioAppItemID As Long) As Threading.Tasks.Task(Of Long)
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim response = Await httpClient.PostAsync($"https://api.podio.com/item/{podioAppItemID}/clone", Nothing).ConfigureAwait(False)
        If response.IsSuccessStatusCode Then
            Dim resultString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Dim result = JObject.Parse(resultString)
            Dim itemId = result("item_id").Value(Of Long)()
            Console.WriteLine("Item clonado con ID: " & itemId)
            Return itemId
        Else
            Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Console.WriteLine("Error clonando item: " & response.StatusCode & " " & errorDetails)
            Throw New Exception("Failed to clone item in Podio. Status: " & response.StatusCode)
        End If
    End Function

    ' El creador es el mismo administrador de las actividades de sistemas (tipo de usuario: app)
    Public Async Function ObtenerItemsByUser() As Task(Of JArray)
        Await EnsureAuthenticated().ConfigureAwait(False)
        Try
            Dim url As String = $"https://api.podio.com/item/app/{podioAppID}/filter/"
            Dim filterContent = New With {
                Key .sort_by = "created_on",
                Key .sort_desc = True,
                Key .filters = New With {
                    Key .created_by = New With {
                        Key .type = "app",
                        Key .id = Long.Parse(podioAppID)
                    }
                }
            }
            Dim jsonContent As String = JsonConvert.SerializeObject(filterContent)
            Console.WriteLine("JSON enviado: " & jsonContent) ' Log para verificar el contenido del JSON

            Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

            Dim response = Await httpClient.PostAsync(url, content).ConfigureAwait(False)

            If response.IsSuccessStatusCode Then
                Dim result = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                Dim jsonResult As JObject = JObject.Parse(result)
                Return jsonResult("items").Value(Of JArray)()
            Else
                Throw New Exception($"Error al obtener ítems desde Podio: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        Catch ex As Exception
            Console.WriteLine("Error general al intentar obtener los ítems en Podio. Detalles: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Async Function SincronizarItems(itemsPodio As JArray, itemsLocales As DataTable) As Threading.Tasks.Task
        ' Crear un diccionario para acceder rápidamente a los ítems locales por su PodioItemID
        Dim itemsLocalesDict As New Dictionary(Of Long, DataRow)
        For Each filaLocal As DataRow In itemsLocales.Rows
            ' Verificar si PodioAppItemID no es nulo
            If Not IsDBNull(filaLocal("PodioAppItemID")) AndAlso Not String.IsNullOrWhiteSpace(filaLocal("PodioAppItemID").ToString()) Then
                itemsLocalesDict.Add(CLng(filaLocal("PodioAppItemID")), filaLocal)
            End If
        Next

        ' Identificar y agregar ítems que están en Podio pero no en la base de datos local
        For Each itemPodio As JObject In itemsPodio
            Dim podioAppItemId As Long = itemPodio("item_id").Value(Of Long)()
            Dim fechaModificacionPodio As DateTime = itemPodio("last_event_on").Value(Of DateTime)()

            If Not itemsLocalesDict.ContainsKey(podioAppItemId) Then
                ' Agregar ítem localmente (aquí se debe implementar la lógica)
                ' ...

            Else
                ' Actualizar ítem local si la fecha de modificación en Podio es más reciente
                Dim filaLocal As DataRow = itemsLocalesDict(podioAppItemId)
                Dim fechaModificacionLocal As DateTime = CDate(filaLocal("Última Modificación"))

                If fechaModificacionPodio > fechaModificacionLocal Then
                    ' Verificar si PodioAppItemID no es nulo antes de procesar
                    If Not IsDBNull(filaLocal("PodioAppItemID")) AndAlso Not String.IsNullOrWhiteSpace(filaLocal("PodioAppItemID").ToString()) Then
                        ' Al querer actualizar un item, debo obtener los datos de las otras tablas que me ayudan
                        Dim asistentesLocal As List(Of Asistente) = _controlador.ObtenerAsistentesInvitados(filaLocal("ID Evento"))
                        Dim autorizantesLocal As List(Of String) = _controlador.ObtenerAutorizantes(CInt(filaLocal("PodioItemID")))
                        Dim solicitantesLocal As List(Of String) = _controlador.ObtenerSolicitantes(CInt(filaLocal("PodioItemID")))
                        Dim proyectosSistemasLocal As Dictionary(Of String, String) = _controlador.ObtenerListaProyectosSistemas(CInt(filaLocal("PodioItemID")))

                        Dim item As New PodioItem()
                        item.PodioItemID = CInt(filaLocal("PodioItemID"))
                        item.PodioAppID = CInt(filaLocal("PodioAppID"))
                        item.EventID = filaLocal("ID Evento")
                        item.PodioAppItemID = podioAppItemId
                        item.Title = itemPodio("title").Value(Of String)()
                        Dim descripcionHtml As String = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "descripcion")("values")(0)("value").Value(Of String)()
                        item.Description = QuitarEtiquetasHtml(descripcionHtml)
                        item.Company = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "empresa")("values").Select(Function(v) v("value")("id").Value(Of Integer).ToString()).ToList()
                        item.Department = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "departamentoarea-solicitante")("values")(0)("value")("id").Value(Of Integer).ToString()
                        item.SystemArea = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "area-de-sistemas-solicitante")("values")(0)("value")("id").Value(Of Integer).ToString()
                        item.Categories = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "categorias")("values")(0)("value")("id").Value(Of Integer).ToString()
                        item.Priority = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "prioridad")("values")(0)("value")("id").Value(Of Integer).ToString()
                        item.Status = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "status")("values")(0)("value")("id").Value(Of Integer)().ToString()

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "orden-de-prioridad-del-dpto-solicitante") IsNot Nothing Then
                            item.DepartmentPriority = Integer.Parse(itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "orden-de-prioridad-del-dpto-solicitante")("values")(0)("value").Value(Of Double)())
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "orden-de-prioridad-2") IsNot Nothing Then
                            item.SystemPriority = Integer.Parse(itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "orden-de-prioridad-2")("values")(0)("value").Value(Of Double)())
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "inicio") IsNot Nothing Then
                            item.StartDate = DateTime.Parse(itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "inicio")("values")(0)("start").Value(Of String)())
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "finalizacion") IsNot Nothing Then
                            item.EndDate = DateTime.Parse(itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "finalizacion")("values")(0)("start").Value(Of String)())
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "plan-de-trabajo-sistemas") IsNot Nothing Then
                            Dim workPlanHtml As String = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "plan-de-trabajo-sistemas")("values")(0)("value").Value(Of String)()
                            item.WorkPlan = QuitarEtiquetasHtml(workPlanHtml)
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "barra-de-progreso") IsNot Nothing Then
                            item.Progress = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "barra-de-progreso")("values")(0)("value").Value(Of Integer)()
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "horas-acumuladas") IsNot Nothing Then
                            item.HoursAccumulated = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "horas-acumuladas")("values")(0)("value").Value(Of Integer)()
                        End If

                        If itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "horas-extras") IsNot Nothing Then
                            item.ExtraHours = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "horas-extras")("values")(0)("value").Value(Of Integer)()
                        End If

                        Dim evento As New Evento() With {
                            .EventID = item.EventID,
                            .Summary = item.Title,
                            .Description = item.Description,
                            .StartDateTime = item.StartDate,
                            .EndDateTime = item.EndDate,
                            .RRULE = filaLocal("Recurrencia")
                        }

                        ' Actualizar y comparar las empresas de cada item
                        _controlador.ActualizarYCompararEmpresas(item)

                        ' Actualizar asistentes
                        Dim asistentesPodio As List(Of Integer) = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "asignado-a")("values").Select(Function(v) v("value")("profile_id").Value(Of Integer)).ToList()
                        Dim asistenesParaAgregar = asistentesPodio.Except(asistentesLocal.Select(Function(a) _controlador.ObtenerPodioUserIDPorCorreo(a.Email))).ToList()
                        Dim asistentesParaEliminar = asistentesLocal.Select(Function(a) _controlador.ObtenerPodioUserIDPorCorreo(a.Email)).Except(asistentesPodio.Select(Function(a) a)).ToList()

                        For Each asistente In asistentesPodio
                            evento.Attendees.Add(New Asistente() With {
                                .EventID = filaLocal("ID Evento"),
                                .Email = _controlador.ObtenerCorreoPorProfileID(asistente),
                                .PodioItemID = item.PodioItemID
                            })
                        Next

                        Dim mensaje As New Mensaje()
                        For Each asistente As String In asistenesParaAgregar
                            mensaje.Attendees.Add(New Asistente() With {
                           .EventID = filaLocal("ID Evento"),
                           .Email = _controlador.ObtenerCorreoPorProfileID(asistente),
                           .PodioItemID = item.PodioItemID
                       })
                        Next

                        If mensaje.Attendees.Count > 0 Then
                            mensaje.EventID = filaLocal("ID Evento")
                            mensaje.Title = item.Title
                            mensaje.Description = item.Description
                            mensaje.RRULE = filaLocal("Recurrencia")
                            _controlador.InsertarAsistente(mensaje, item.PodioItemID)
                            evento.Attendees = mensaje.Attendees
                        End If

                        For Each asistente As String In asistentesParaEliminar
                            _controlador.EliminarAsistente(New Asistente() With {
                            .EventID = filaLocal("ID Evento"),
                            .Email = _controlador.ObtenerCorreoPorProfileID(asistente)})
                        Next


                        ' Actualizar y comparar solicitantes
                        Dim solicitantesPodio As List(Of Integer) = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "solicitante")("values").Select(Function(v) v("value")("profile_id").Value(Of Integer)).ToList()
                        Dim solicitantesParaAgregar = solicitantesPodio.Except(solicitantesLocal.Select(Function(s) _controlador.ObtenerPodioUserIDPorCorreo(s))).ToList()
                        Dim solicitantesParaEliminar = solicitantesLocal.Select(Function(s) _controlador.ObtenerPodioUserIDPorCorreo(s)).Except(solicitantesPodio.Select(Function(s) s)).ToList()

                        Dim podioItemAux As New PodioItem() With {
                       .PodioItemID = item.PodioItemID
                     }

                        For Each solicitante In solicitantesParaAgregar
                            podioItemAux.RequestorContacts.Add(solicitante)
                        Next
                        If podioItemAux.RequestorContacts.Count > 0 Then
                            _controlador.InsertarSolicitante(podioItemAux)
                        End If

                        For Each solicitante In solicitantesParaEliminar
                            _controlador.EliminarSolicitante(_controlador.ObtenerCorreoPorProfileID(solicitante), podioItemAux.PodioItemID)
                        Next

                        ' Actualizar y comparar autorizantes
                        Dim campoAutoriza = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "autoriza")
                        Dim autorizantesPodio As List(Of Integer) = If(campoAutoriza IsNot Nothing AndAlso campoAutoriza("values") IsNot Nothing,
                            campoAutoriza("values").Select(Function(v) v("value")("profile_id").Value(Of Integer)).ToList(),
                            New List(Of Integer))
                        Dim autorizantesParaAgregar = autorizantesPodio.Except(autorizantesLocal.Select(Function(a) _controlador.ObtenerPodioUserIDPorCorreo(a))).ToList()
                        Dim autorizantesParaEliminar = autorizantesLocal.Select(Function(a) _controlador.ObtenerPodioUserIDPorCorreo(a)).Except(autorizantesPodio.Select(Function(a) a)).ToList()

                        For Each autorizante In autorizantesParaAgregar
                            podioItemAux.AuthorizerContacts.Add(autorizante)
                        Next
                        If podioItemAux.AuthorizerContacts.Count > 0 Then
                            _controlador.InsertarAutorizante(podioItemAux)
                        End If

                        For Each autorizante In autorizantesParaEliminar
                            _controlador.EliminarAutorizante(_controlador.ObtenerCorreoPorProfileID(autorizante), podioItemAux.PodioItemID)
                        Next

                        ' Actualizar y comparar proyectos de sistemas
                        Dim campoProyectos = itemPodio("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "proyectos")
                        Dim proyectosSistemasPodio As Dictionary(Of String, String) = If(campoProyectos IsNot Nothing AndAlso campoProyectos("values") IsNot Nothing,
                            campoProyectos("values").ToDictionary(Function(v) v("value")("item_id").Value(Of String), Function(v) v("value")("title").Value(Of String)),
                            New Dictionary(Of String, String))
                        Dim proyectosSistemasParaAgregar = proyectosSistemasPodio.Except(proyectosSistemasLocal).ToDictionary(Function(p) p.Key, Function(p) p.Value)
                        Dim proyectosSistemasParaEliminar = proyectosSistemasLocal.Except(proyectosSistemasPodio).ToDictionary(Function(p) p.Key, Function(p) p.Value)

                        For Each proyecto In proyectosSistemasParaAgregar
                            _controlador.InsertarPodioProyectoSistemas(item.PodioItemID, proyecto.Key, proyecto.Value)
                        Next

                        For Each proyecto In proyectosSistemasParaEliminar
                            _controlador.EliminarProyectoSistemas(proyecto.Key, item.PodioItemID)
                        Next


                        ' Actualizar el item local
                        _controlador.CrearPodioItem(item)
                        _controlador.ActualizarEvento(evento)
                    End If
                End If
            End If

            ' Remover el ítem del diccionario local para identificar ítems que deben eliminarse
            itemsLocalesDict.Remove(podioAppItemId)
        Next

        ' Eliminar ítems que están en la base de datos local pero no en Podio
        For Each filaLocal As DataRow In itemsLocalesDict.Values
            _controlador.EliminarEvento(filaLocal("ID Evento"), CLng(filaLocal("PodioAppItemID")))
        Next
    End Function

    Public Function QuitarEtiquetasHtml(html As String) As String
        Dim doc As New HtmlDocument()
        doc.LoadHtml(html)
        Return doc.DocumentNode.InnerText
    End Function

    Public Async Function ObtenerTareasPendientes(limite As Integer, intervaloInicio As DateTime?, intervaloFin As DateTime?) As Task(Of DataTable)
        Await EnsureAuthenticated().ConfigureAwait(False)

        ' Crear el contenido de la solicitud con filtros condicionales
        Dim filters As New JObject()
        Dim createdOnFilter As New JObject()

        If intervaloInicio.HasValue Then
            createdOnFilter("from") = intervaloInicio.Value.ToString("yyyy-MM-ddTHH:mm:ss")
        End If
        If intervaloFin.HasValue Then
            createdOnFilter("to") = intervaloFin.Value.ToString("yyyy-MM-ddTHH:mm:ss")
        End If

        If createdOnFilter.Count > 0 Then
            filters("created_on") = createdOnFilter
        End If

        filters("limit") = limite
        filters("offset") = 0
        filters("sort_by") = "created_on"
        filters("sort_desc") = False

        Dim filterWrapper = New JObject()
        filterWrapper("filters") = filters

        Dim content As New StringContent(JsonConvert.SerializeObject(filters), Encoding.UTF8, "application/json")
        Dim viewId As String = Await ObtenerViewID("Todos Los Pendientes").ConfigureAwait(False)
        Dim response = Await httpClient.PostAsync($"https://api.podio.com/item/app/{podioAppID}/filter/{viewId}", content).ConfigureAwait(False)

        If response.IsSuccessStatusCode Then
            Dim result = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Dim jsonResult As JObject = JObject.Parse(result)
            Return ConvertToDataTable(jsonResult("items"))
        Else
            Throw New Exception($"Error al obtener ítems desde Podio: {response.StatusCode}")
        End If
    End Function

    Public Async Function ObtenerViewID(nombreVista As String) As Task(Of String)
        Await EnsureAuthenticated().ConfigureAwait(False)
        Dim url As String = $"https://api.podio.com/view/app/{podioAppID}/"

        Dim response = Await httpClient.GetAsync(url).ConfigureAwait(False)
        If response.IsSuccessStatusCode Then
            Dim result = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Dim jsonResult As JArray = JArray.Parse(result)

            For Each view In jsonResult
                If view("name").ToString() = nombreVista Then
                    Return view("view_id").ToString()
                End If
            Next

            Throw New Exception("Vista no encontrada")
        Else
            Throw New Exception($"Error al obtener vistas: {response.StatusCode}")
        End If
    End Function

    Private Function ConvertToDataTable(items As JArray) As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("Titulo")
        dt.Columns.Add("SystemArea")
        dt.Columns.Add("FechaInicio")
        dt.Columns.Add("Status")
        dt.Columns.Add("Avance")

        For Each item In items
            Dim row = dt.NewRow()
            row("Titulo") = item("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "titulo-de-tarea")("values")(0)("value").ToString()
            row("SystemArea") = item("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "area-de-sistemas-solicitante")("values")(0)("value").ToString()
            row("FechaInicio") = item("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "inicio")("values")(0)("start").ToString()
            row("Status") = item("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "status")("values")(0)("value")("id").ToString()
            row("Avance") = item("fields").FirstOrDefault(Function(f) f("external_id").ToString() = "barra-de-progreso")("values")(0)("value").ToString()

            dt.Rows.Add(row)
        Next

        Return dt
    End Function
End Class