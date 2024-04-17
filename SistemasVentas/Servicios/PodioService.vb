Imports PodioAPI
Imports PodioAPI.Models
Imports PodioAPI.Utils.Authentication
Imports PodioAPI.Utils.ItemFields
Imports System.Threading.Tasks

Public Class PodioService
    Private _podioClient As Podio
    'Variable de entorno
    Dim podioClientID As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_ID")
    Dim podioClientSecret As String = Environment.GetEnvironmentVariable("PODIO_CLIENT_SECRET")

    Public Sub New()
        _podioClient = New Podio(podioClientID, podioClientSecret)
    End Sub

    Public Async Function CreateItem() As Threading.Tasks.Task
        Try
            Dim podioAppID As String = Environment.GetEnvironmentVariable("PODIO_APP_ID")
            Dim podioAppToken As String = Environment.GetEnvironmentVariable("PODIO_APP_TOKEN")
            ' Autenticar con la aplicación de Podio sincrónicamente
            Dim oAuth As PodioOAuth = _podioClient.AuthenticateWithApp(podioAppID, podioAppToken)

            ' Crear un nuevo item
            Dim item As New Item()

            ' Agregar campo de texto 'Titulo'
            Dim titleField As New TextItemField() With {
                .FieldId = 10086319, ' Reemplaza 123 con el FieldId real
                .Value = "Título del ítem"
            }
            item.Fields.Add(titleField)

            ' Agregar campo de texto 'Descripcion'
            Dim descriptionField As New TextItemField() With {
                .FieldId = 50907911, ' Reemplaza 456 con el FieldId real
                .Value = "Esta es una descripción"
            }
            item.Fields.Add(descriptionField)

            ' Agregar campo 'Empresa' (categoría)
            Dim companyField As New CategoryItemField() With {
                .FieldId = 50907912 ' Reemplaza 789 con el FieldId real
            }
            companyField.OptionIds = New List(Of Integer) From {3} ' Reemplaza 101 con el OptionId real
            item.Fields.Add(companyField)

            ' Agregar campo 'Departamento' (categoría)
            Dim departmentField As New CategoryItemField() With {
                .FieldId = 191364514 ' Reemplaza 234 con el FieldId real
            }
            departmentField.OptionIds = New List(Of Integer) From {5} ' Reemplaza 102 con el OptionId real
            item.Fields.Add(departmentField)

            ' Agregar campo 'Area de sistemas' (categoría)
            Dim systemAreaField As New CategoryItemField() With {
                .FieldId = 203943021 ' Reemplaza 345 con el FieldId real
            }
            systemAreaField.OptionIds = New List(Of Integer) From {2} ' Reemplaza 103 con el OptionId real
            item.Fields.Add(systemAreaField)

            ' Agregar campo 'Categorias' (categoría)
            Dim categoriesField As New CategoryItemField() With {
                .FieldId = 57128977 ' Reemplaza 567 con el FieldId real
            }
            categoriesField.OptionIds = New List(Of Integer) From {1} ' Reemplaza 104 con el OptionId real
            item.Fields.Add(categoriesField)

            ' Agregar campo 'Solicitante' (contacto)
            Dim requesterField As New ContactItemField() With {
                .FieldId = 50907913 ' Reemplaza 678 con el FieldId real
            }
            requesterField.ContactIds = New List(Of Integer) From {187722589} ' Reemplaza 201 con el ContactId real
            item.Fields.Add(requesterField)

            ' Agregar campo 'Asignado a' (contacto)
            Dim assignedToField As New ContactItemField() With {
                .FieldId = 50907915 ' Reemplaza 890 con el FieldId real
            }
            assignedToField.ContactIds = New List(Of Integer) From {187722589} ' Reemplaza 202 con el ContactId real
            item.Fields.Add(assignedToField)

            ' Agregar campo 'Status' (categoría)
            Dim statusField As New CategoryItemField() With {
                .FieldId = 50908150 ' Reemplaza 901 con el FieldId real
            }
            statusField.OptionIds = New List(Of Integer) From {5} ' Reemplaza 301 con el OptionId real
            item.Fields.Add(statusField)
            ' ID de la app en Podio
            Dim appId As Integer = 1350510

            ' Crear el item en Podio de forma asincrónica
            Dim itemId As Integer = Await Threading.Tasks.Task.Run(Function() _podioClient.ItemService.AddNewItem(appId, item))

            Console.WriteLine("Item creado con ID: " & itemId)
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
End Class
