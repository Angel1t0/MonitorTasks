Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Calendar.v3
Imports System.IO
Imports System.Threading

Public Class AutenticadorServiciosGoogle
    Private ReadOnly Scopes As String() = {GmailService.Scope.GmailSend, CalendarService.Scope.Calendar} ' Permisos requeridos para los servicios de Gmail y Calendar
    Private ReadOnly ApplicationName As String = "Monitor task - Prueba"
    Private ReadOnly ClientSecretFileName As String = "client_secret_904108627701-bc7vsuctjhehlpou2tjof9g6c483s9n6.apps.googleusercontent.com.json"
    Private ReadOnly TokenDirectoryName As String = "token.json"
    Private credential As UserCredential ' Almacena las credenciales como propiedad de instancia

    ' Método que maneja la autenticación y devuelve credenciales de usuario, si no han sido ya obtenidas.
    Public Function AuthenticateGoogleServices() As UserCredential
        ' Obtén la ruta del directorio de inicio de la aplicación
        Dim appPath As String = Application.StartupPath
        ' Construye las rutas absolutas para los archivos de client secret y el directorio de tokens
        Dim clientSecretPath As String = Path.Combine(appPath, "Archivos", ClientSecretFileName)
        Dim tokenDirectoryPath As String = Path.Combine(appPath, "Archivos", TokenDirectoryName, "admin") ' Usamos "admin" como identificador único
        Dim fileDataStore = New FileDataStore(tokenDirectoryPath, True)

        Using stream As New FileStream(clientSecretPath, FileMode.Open, FileAccess.Read)
            Try
                ' Siempre autoriza, independientemente de si ya hay un token existente.
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "admin", ' Usamos "admin" como identificador
                CancellationToken.None,
                fileDataStore).Result

                Console.WriteLine("Credential file saved to: " & tokenDirectoryPath)
            Catch ex As AggregateException
                Console.WriteLine("Error al autenticar con Google Services: " & ex.InnerException.Message)
                Throw
            End Try
        End Using

        Return credential
    End Function


    ' Simplifica la obtención de los servicios reutilizando las credenciales autenticadas
    Public Function ObtenerServicioCalendar() As CalendarService
        Dim credential As UserCredential = AuthenticateGoogleServices()

        Return New CalendarService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })
    End Function

    Public Function ObtenerServicioGmail() As GmailService
        Dim credential As UserCredential = AuthenticateGoogleServices()

        Return New GmailService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })
    End Function
End Class
