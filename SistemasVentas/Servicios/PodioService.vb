Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports PodioAPI
Imports PodioAPI.Models
Imports PodioAPI.Utils.Authentication
Imports PodioAPI.Utils.ItemFields
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

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

    Public Async Function CreateItem(podioItem As PodioItem) As Task(Of Integer)
        Await EnsureAuthenticated().ConfigureAwait(False)  ' Asegura autenticación

        ' Crea el objeto JSON para los campos
        Dim itemFields As New JArray From {
            New JObject From {
                {"field_id", 10086319}, ' Titulo
                {"value", podioItem.Title}
            },
            New JObject From {
                {"field_id", 50907911}, ' Descripcion
                {"value", podioItem.Description}
            },
            New JObject From {
                {"field_id", 50907912}, ' Empresa (categoría)
                {"value", podioItem.Company}
            },
            New JObject From {
                {"field_id", 191364514}, ' Departamento (categoría)
                {"value", podioItem.Department}
            },
            New JObject From {
                {"field_id", 203943021}, ' Área de sistemas (categoría)
                {"value", podioItem.SystemArea}
            },
            New JObject From {
                {"field_id", 57128977}, ' Category (categoría)
                {"value", podioItem.Categories}
            },
            New JObject From {
                {"field_id", 50907913}, ' Solicitante (contacto)
                {"values", New JArray(podioItem.RequestorContacts.Select(Function(id) New JObject From {{"value", id}}))}
            },
            New JObject From {
                {"field_id", 50907915}, ' Asignado a (contacto)
                {"values", New JArray(podioItem.AssignedToContacts.Select(Function(id) New JObject From {{"value", id}}))}
            },
            New JObject From {
                {"field_id", 50907916}, ' Prioridad (categoría)
                {"value", podioItem.Priority}
            },
            New JObject From {
                {"field_id", 50908150}, ' Status (categoría)
                {"value", podioItem.Status}
            }
        }

        ' Condiciones para saber si esta vacio o es nulo, ya que no acepta valores nulos
        If podioItem.DepartmentPriority <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 191362674}, ' Orden de prioridad por departamento (numeric)
            {"value", podioItem.DepartmentPriority}
        })
        End If

        If podioItem.AuthorizerContacts IsNot Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 50907914}, ' Autorizante (contacto)
            {"values", New JArray(podioItem.AuthorizerContacts.Select(Function(id) New JObject From {{"value", id}}))}
        })
        End If

        If podioItem.SystemPriority <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 189076789}, ' Orden de prioridad de Sistemas (numeric)
            {"value", podioItem.SystemPriority}
        })
        End If

        If podioItem.StartDate <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 10086320}, ' Fecha de inicio (date)
            {"start", podioItem.StartDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}
        })
        End If

        If podioItem.EndDate <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 50907917}, ' Fecha de fin (date)
            {"start", podioItem.EndDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}
        })
        End If

        If podioItem.WorkPlan <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 75115253}, ' Plan de trabajo (text)
            {"value", podioItem.WorkPlan}
        })
        End If

        If podioItem.Progress <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 50907918}, ' Progreso (barra de progreso)
            {"value", podioItem.Progress}
        })
        End If

        If podioItem.SystemProject <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 50907910}, ' Proyecto de Sistemas (referencia de app)
            {"value", podioItem.SystemProject}
        })
        End If

        If podioItem.GeneralProject <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 104722848}, ' Proyecto General (referencia de app)
            {"value", podioItem.GeneralProject}
        })
        End If

        If podioItem.HoursAccumulated <> Nothing Then
            itemFields.Add(New JObject From {
            {"field_id", 50907919}, ' Horas acumuladas (duración)
            {"value", podioItem.HoursAccumulated}
        })
        End If

        If podioItem.ExtraHours <> Nothing Then
            itemFields.Add(New JObject From {
                {"field_id", 51007152}, ' Horas extras (duración)
                {"value", podioItem.ExtraHours}
         })
        End If

        ' Prepara el objeto JSON final para la solicitud
        Dim itemObject As New JObject From {
        {"fields", itemFields}
    }
        Try
            Dim content As New StringContent(itemObject.ToString(), Encoding.UTF8, "application/json")
            Dim response = Await httpClient.PostAsync($"https://api.podio.com/item/app/{podioAppID}/", content).ConfigureAwait(False)
            If response.IsSuccessStatusCode Then
                Dim resultString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                Dim result = JObject.Parse(resultString)
                Dim itemId = result("item_id").Value(Of Integer)()
                Console.WriteLine("Item creado con ID: " & itemId)
                Return itemId
            Else
                Dim errorDetails = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                Console.WriteLine("Error creando item: " & response.StatusCode & " " & errorDetails)
                Throw New Exception("Failed to create item in Podio. Status: " & response.StatusCode)
            End If
        Catch ex As TaskCanceledException
            Console.WriteLine("La solicitud fue cancelada por timeout. Detalles: " & ex.Message)
        Catch ex As HttpRequestException
            Console.WriteLine("Error en la solicitud HTTP. Detalles: " & ex.Message)
        Catch ex As Exception
            Console.WriteLine("Error general al intentar crear el ítem en Podio. Detalles: " & ex.Message)
            Throw ' Rethrows the exception to higher level exception handling
        End Try
    End Function


    'Public Async Function CreateItem(podioItem As PodioItem) As Threading.Tasks.Task(Of Integer)
    '    Try
    '        ' Autenticar con la aplicación de Podio sincrónicamente
    '        Dim oAuth As PodioOAuth = _podioClient.AuthenticateWithApp(podioAppID, podioAppToken)

    '        ' Crear un nuevo item
    '        Dim item As New Item()

    '        ' Agregar campo de texto 'Titulo'
    '        Dim titleField As New TextItemField() With {
    '            .FieldId = 10086319,
    '            .Value = podioItem.Title
    '        }
    '        item.Fields.Add(titleField)

    '        ' Agregar campo de texto 'Descripcion'
    '        Dim descriptionField As New TextItemField() With {
    '            .FieldId = 50907911,
    '            .Value = podioItem.Description
    '        }
    '        item.Fields.Add(descriptionField)

    '        ' Campo 'Empresa' (categoría)
    '        Dim companyField As New CategoryItemField() With {
    '            .FieldId = 50907912
    '        }
    '        companyField.OptionIds = New List(Of Integer) From {podioItem.Company}
    '        item.Fields.Add(companyField)

    '        ' Campo 'Departamento' (categoría)
    '        Dim departmentField As New CategoryItemField() With {
    '            .FieldId = 191364514
    '        }
    '        departmentField.OptionIds = New List(Of Integer) From {podioItem.Department}
    '        item.Fields.Add(departmentField)

    '        ' Campo 'Orden de prioridad por departamenteo' (numeric)
    '        Dim departmentPriority As New NumericItemField() With {
    '            .FieldId = 191362674,
    '            .Value = podioItem.DepartmentPriority ' Aquí puede ser cualquier valor entre 0 y 100
    '        }
    '        item.Fields.Add(departmentPriority)

    '        ' Campo 'Área de sistemas' (categoría)
    '        Dim systemAreaField As New CategoryItemField() With {
    '            .FieldId = 203943021
    '        }
    '        systemAreaField.OptionIds = New List(Of String) From {podioItem.SystemArea}
    '        item.Fields.Add(systemAreaField)

    '        ' Campo 'Category' (categoría)
    '        Dim categoryField As New CategoryItemField() With {
    '            .FieldId = 57128977
    '        }
    '        categoryField.OptionIds = New List(Of String) From {podioItem.Categories}
    '        item.Fields.Add(categoryField)

    '        ' Campo 'Solicitante' (contacto)
    '        Dim requesterField As New ContactItemField() With {
    '            .FieldId = 50907913,
    '            .ContactIds = podioItem.RequestorContacts
    '        }
    '        item.Fields.Add(requesterField)

    '        ' Campo 'Autorizante' (contacto)
    '        Dim autorizerField As New ContactItemField() With {
    '            .FieldId = 50907914,
    '            .ContactIds = podioItem.AuthorizerContacts
    '        }
    '        item.Fields.Add(autorizerField)

    '        ' Campo 'Asignado a' (contacto)
    '        Dim assignedToField As New ContactItemField() With {
    '            .FieldId = 50907915,
    '            .ContactIds = podioItem.AssignedToContacts
    '        }
    '        item.Fields.Add(assignedToField)

    '        ' Campo 'Orden de prioridad de Sistemas' (numeric)
    '        Dim systemPriority As New NumericItemField() With {
    '            .FieldId = 189076789,
    '            .Value = podioItem.SystemPriority ' Aquí puede ser cualquier valor entre 0 y 100
    '        }
    '        item.Fields.Add(systemPriority)

    '        ' Campo 'Prioridad' (categoría)
    '        Dim priorityField As New CategoryItemField() With {
    '            .FieldId = 50907916
    '        }
    '        priorityField.OptionIds = New List(Of Integer) From {podioItem.Priority}
    '        item.Fields.Add(priorityField)

    '        ' Campo 'Fecha de inicio' (date)
    '        Dim startDateField As New DateItemField() With {
    '            .FieldId = 10086320
    '        }
    '        startDateField.Start = podioItem.StartDate
    '        item.Fields.Add(startDateField)

    '        ' Campo 'Fecha de fin' (date)
    '        Dim endDateField As New DateItemField() With {
    '            .FieldId = 50907917
    '        }
    '        endDateField.Start = podioItem.EndDate
    '        item.Fields.Add(endDateField)

    '        ' Campo 'Plan de trabajo' (text)
    '        Dim workPlanField As New TextItemField() With {
    '            .FieldId = 75115253,
    '            .Value = podioItem.WorkPlan
    '        }
    '        item.Fields.Add(workPlanField)

    '        ' Campo 'Status' (categoría)
    '        Dim statusField As New CategoryItemField() With {
    '            .FieldId = 50908150,
    '            .OptionIds = New List(Of Integer) From {podioItem.Status}
    '        }
    '        item.Fields.Add(statusField)

    '        ' Campo 'Progreso' (barra de progreso)
    '        Dim progressField As New ProgressItemField() With {
    '            .FieldId = 50907918,
    '            .Value = podioItem.Progress ' Aquí puede ser cualquier valor entre 0 y 100
    '        }
    '        item.Fields.Add(progressField)

    '        ' Campo 'Proyecto de Sistemas' (referencia de app)
    '        Dim systemProjectField As New AppItemField() With {
    '            .FieldId = 50907910,
    '            .ItemIds = New List(Of String) From {podioItem.SystemProject} ' Reemplaza con el ID del proyecto correcto
    '        }
    '        item.Fields.Add(systemProjectField)

    '        ' Campo 'Proyecto General' (referencia de app)
    '        Dim generalProjectField As New AppItemField() With {
    '            .FieldId = 104722848,
    '            .ItemIds = New List(Of String) From {podioItem.GeneralProject}
    '        }
    '        item.Fields.Add(generalProjectField)

    '        ' Campo 'Horas acumuladas' (duración)
    '        Dim hoursAccumulatedField As New DurationItemField() With {
    '            .FieldId = 50907919,
    '            .Value = TimeSpan.FromSeconds(podioItem.HoursAccumulated)  ' Valor en segundos
    '        }
    '        item.Fields.Add(hoursAccumulatedField)

    '        ' Campo 'Horas extras' (duración)
    '        Dim extraHoursField As New DurationItemField() With {
    '            .FieldId = 51007152,
    '            .Value = TimeSpan.FromSeconds(podioItem.ExtraHours) ' Valor en segundos
    '        }
    '        item.Fields.Add(extraHoursField)

    '        ' Crear el item en Podio de forma asincrónica
    '        Dim itemId As Integer = Await Threading.Tasks.Task.Run(Function() _podioClient.ItemService.AddNewItem(podioItem.PodioAppID, item))

    '        Return itemId
    '        Console.WriteLine("Item creado con ID: " & itemId)
    '    Catch webEx As System.Net.WebException
    '        Console.WriteLine("Error de red: " & webEx.Message)
    '        ' Considera reintentar la conexión aquí
    '    Catch nfEx As PodioAPI.Exceptions.PodioNotFoundException
    '        Console.WriteLine("No se encontró el recurso: " & nfEx.Message)
    '        ' Revisa los IDs y accesos aquí
    '    Catch ex As Exception
    '        Console.WriteLine("Error general: " & ex.Message)
    '    End Try
    'End Function

    ' Actualizar un item en podio
    Public Async Function UpdatePodioItem(podioItem As PodioItem) As Threading.Tasks.Task
        Try
            Dim podioAppID As String = Environment.GetEnvironmentVariable("PODIO_APP_ID")
            Dim podioAppToken As String = Environment.GetEnvironmentVariable("PODIO_APP_TOKEN")

            ' Autenticar con la aplicación de Podio
            Dim oAuth As PodioOAuth = _podioClient.AuthenticateWithApp(podioAppID, podioAppToken)

            ' Crear un item con los campos actualizados
            Dim item As New Item()

            ' Actualizar campo de texto 'Titulo'
            Dim titleField As New TextItemField() With {
            .FieldId = 10086319,
            .Value = podioItem.Title
        }
            item.Fields.Add(titleField)

            ' Actualizar campo de texto 'Descripcion'
            Dim descriptionField As New TextItemField() With {
            .FieldId = 50907911,
            .Value = podioItem.Description
        }
            item.Fields.Add(descriptionField)

            ' Actualizar campo 'Empresa' (categoría)
            Dim companyField As New CategoryItemField() With {
            .FieldId = 50907912,
            .OptionIds = New List(Of Integer) From {podioItem.Company}
        }
            item.Fields.Add(companyField)

            ' Actualizar campo 'Departamento' (categoría)
            Dim departmentField As New CategoryItemField() With {
            .FieldId = 191364514,
            .OptionIds = New List(Of Integer) From {podioItem.Department}
        }
            item.Fields.Add(departmentField)

            ' Actualizar campo 'Orden de prioridad por departamento' (numérico)
            Dim departmentPriorityField As New NumericItemField() With {
            .FieldId = 191362674,
            .Value = podioItem.DepartmentPriority
        }
            item.Fields.Add(departmentPriorityField)

            ' Actualizar campo 'Área de sistemas' (categoría)
            Dim systemAreaField As New CategoryItemField() With {
            .FieldId = 203943021,
            .OptionIds = New List(Of Integer) From {podioItem.SystemArea}
        }
            item.Fields.Add(systemAreaField)

            ' Campo 'Categorías' (categoría)
            Dim categoryField As New CategoryItemField() With {
            .FieldId = 57128977,
            .OptionIds = New List(Of Integer) From {podioItem.Categories}
        }
            item.Fields.Add(categoryField)

            ' Campo 'Solicitante' (contacto)
            Dim requesterField As New ContactItemField() With {
            .FieldId = 50907913,
            .ContactIds = podioItem.RequestorContacts
        }
            item.Fields.Add(requesterField)

            ' Campo 'Autorizante' (contacto)
            Dim autorizerField As New ContactItemField() With {
            .FieldId = 50907914,
            .ContactIds = podioItem.AuthorizerContacts
        }
            item.Fields.Add(autorizerField)

            ' Campo 'Asignado a' (contacto)
            Dim assignedToField As New ContactItemField() With {
            .FieldId = 50907915,
            .ContactIds = podioItem.AssignedToContacts
        }
            item.Fields.Add(assignedToField)

            ' Campo 'Status' (categoría)
            Dim statusField As New CategoryItemField() With {
            .FieldId = 50908150,
            .OptionIds = New List(Of Integer) From {podioItem.Status}
        }
            item.Fields.Add(statusField)

            ' Campo 'Progreso' (barra de progreso)
            Dim progressField As New ProgressItemField() With {
            .FieldId = 50907918,
            .Value = podioItem.Progress
        }
            item.Fields.Add(progressField)

            ' Campo 'Proyecto de sistemas' (referencia de app)
            Dim systemProjectField As New AppItemField() With {
            .FieldId = 50907910,
            .ItemIds = New List(Of Integer) From {podioItem.SystemProject}
        }
            item.Fields.Add(systemProjectField)

            ' Campo 'Proyecto general' (referencia de app)
            Dim generalProjectField As New AppItemField() With {
            .FieldId = 104722848,
            .ItemIds = New List(Of Integer) From {podioItem.GeneralProject}
        }
            item.Fields.Add(generalProjectField)

            ' Campo 'Horas acumuladas' (duración)
            Dim hoursAccumulatedField As New DurationItemField() With {
            .FieldId = 50907919,
            .Value = TimeSpan.FromSeconds(podioItem.HoursAccumulated)
        }
            item.Fields.Add(hoursAccumulatedField)

            ' Campo 'Horas extras' (duración)
            Dim extraHoursField As New DurationItemField() With {
            .FieldId = 51007152,
            .Value = TimeSpan.FromSeconds(podioItem.ExtraHours)
        }
            item.Fields.Add(extraHoursField)

            ' Actualizar el item en Podio
            Await Threading.Tasks.Task.Run(Function() _podioClient.ItemService.UpdateItem(item, podioItem.PodioAppID))

            Console.WriteLine($"Item actualizado con ID: {podioItem.PodioAppID}")
        Catch webEx As System.Net.WebException
            Console.WriteLine("Error de red: " & webEx.Message)
            ' Considera reintentar la conexión aquí
        Catch nfEx As PodioAPI.Exceptions.PodioNotFoundException
            Console.WriteLine("No se encontró el recurso: " & nfEx.Message)
            ' Revisa los IDs y accesos aquí
        Catch ex As Exception
            Console.WriteLine("Error general: " & ex.Message)
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

End Class