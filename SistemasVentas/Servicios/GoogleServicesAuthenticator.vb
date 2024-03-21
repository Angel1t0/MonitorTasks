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
    Public Function AuthenticateGoogleServices() As UserCredential
        If credential Is Nothing Then
            Using stream As New FileStream(ClientSecretPath, FileMode.Open, FileAccess.Read)
                Try
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        New FileDataStore(TokenPath, True)).Result

                    Console.WriteLine("Credential file saved to: " & TokenPath)
                Catch ex As Exception
                    Throw New ApplicationException("Error al autenticar con Google Services.", ex)
                End Try
            End Using
        End If
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
