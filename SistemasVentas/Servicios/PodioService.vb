Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports PodioAPI
Imports PodioAPI.Models
Imports PodioAPI.Utils.Authentication
Imports PodioAPI.Utils.ItemFields
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Twilio.Rest.FlexApi.V1

Public Class PodioService
    Private _podioClient As Podio
    Private httpClient As New HttpClient()
    'Variable de entorno
    Dim podioClientID As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_ID")
    Dim podioClientSecret As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_SECRET")
    Dim podioAppID As String = Environment.GetEnvironmentVariable("PODIO_APP_ID")
    Dim podioAppToken As String = Environment.GetEnvironmentVariable("PODIO_APP_TOKEN")

    Public Sub New()
        _podioClient = New Podio(podioClientID, podioClientSecret)
        'Authenticate() ' Llamada al método de autenticación en el constructor para establecer el token inicial.
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
            itemFields.Add("50907912", New JObject From {{"value", Integer.Parse(podioItem.Company)}}) ' Empresa
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

            If podioItem.WorkPlan <> Nothing Then
                itemFields.Add("75115253", podioItem.WorkPlan) ' Plan de trabajo
            End If

            If podioItem.Progress <> Nothing Then
                itemFields.Add("50907918", New JObject From {{"value", podioItem.Progress}}) ' Progreso
            End If


            If podioItem.SystemProject <> Nothing Then
                itemFields.Add("50907910", New JObject From {{"value", Long.Parse(podioItem.SystemProject)}}) ' Proyecto de sistemas
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
            itemFields.Add("50907912", New JObject From {{"value", Integer.Parse(podioItem.Company)}}) ' Empresa
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
                itemFields.Add("50907910", New JObject From {{"value", Long.Parse(podioItem.SystemProject)}}) ' Proyecto de sistemas
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
        Await EnsureAuthenticated()
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
End Class