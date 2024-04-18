Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Calendar.v3
Imports System.IO
Imports System.Threading

Public Class GoogleServicesAuthenticator
    Private ReadOnly Scopes As String() = {GmailService.Scope.GmailSend, CalendarService.Scope.Calendar}
    Private ReadOnly ApplicationName As String = "Monitor task - Prueba"
    Private ReadOnly ClientSecretPath As String = "D:\angel\Downloads\client_secret_904108627701-bc7vsuctjhehlpou2tjof9g6c483s9n6.apps.googleusercontent.com.json"
    Private ReadOnly TokenPath As String = "D:\angel\Documentos\Residencias\SistemasVentas\SistemasVentas\Recursos\token.json"
    Private credential As UserCredential ' Almacena las credenciales como propiedad de instancia

    ' Método que maneja la autenticación y devuelve credenciales de usuario, si no han sido ya obtenidas.
    Public Function AuthenticateGoogleServices(userID As Integer) As UserCredential
        Dim tokenDirectoryPath As String = Path.Combine(TokenPath, userID.ToString())
        Dim fileDataStore = New FileDataStore(tokenDirectoryPath, True)

        Using stream As New FileStream(ClientSecretPath, FileMode.Open, FileAccess.Read)
            Try
                ' Siempre autoriza, independientemente de si ya hay un token existente.
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                userID.ToString(), ' Usamos ToString para asegurar que el user ID se maneja como un string
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
        Dim credential As UserCredential = AuthenticateGoogleServices(Login.idUsuario)

        Return New CalendarService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })
    End Function

    Public Function ObtenerServicioGmail() As GmailService
        Dim credential As UserCredential = AuthenticateGoogleServices(Login.idUsuario)

        Return New GmailService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })
    End Function
End Class
