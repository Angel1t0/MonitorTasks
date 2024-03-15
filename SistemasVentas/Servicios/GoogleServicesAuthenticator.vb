Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Calendar.v3
Imports System.IO
Imports System.Threading
Imports System.Security.Cryptography.X509Certificates

Public Class GoogleServicesAuthenticator
    Private ReadOnly Scopes As String() = {GmailService.Scope.GmailSend, CalendarService.Scope.Calendar}
    Private ReadOnly ApplicationName As String = "Monitor task - Prueba"
    Private ReadOnly ClientSecretPath As String = "D:\angel\Downloads\client_secret_904108627701-bc7vsuctjhehlpou2tjof9g6c483s9n6.apps.googleusercontent.com.json"
    Private ReadOnly TokenPath As String = "D:\angel\Documentos\Residencias\SistemasVentas\SistemasVentas\Recursos\token.json"

    ' Método que maneja la autenticación y devuelve credenciales de usuario.
    Public Function AuthenticateGoogleServices() As UserCredential
        Dim credential As UserCredential

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

        Return credential
    End Function

    Public Function ObtenerServicioCalendar() As CalendarService
        Dim authenticator As New GoogleServicesAuthenticator()
        Dim credential As UserCredential = authenticator.AuthenticateGoogleServices()

        ' Inicializar el servicio de Google Calendar
        Dim calendarService As New CalendarService(New BaseClientService.Initializer() With {
        .HttpClientInitializer = credential,
        .ApplicationName = authenticator.ApplicationName
        })

        Return calendarService ' Devuelve el servicio autenticado para ser usado en otras partes de tu aplicación.
    End Function

    Public Function ObtenerServicioGmail() As GmailService
        Dim authenticator As New GoogleServicesAuthenticator()
        Dim credential As UserCredential = authenticator.AuthenticateGoogleServices()

        ' Inicializar el servicio de Google Calendar
        Dim gmailService As New GmailService(New BaseClientService.Initializer() With {
        .HttpClientInitializer = credential,
        .ApplicationName = authenticator.ApplicationName
        })

        Return gmailService ' Devuelve el servicio autenticado para ser usado en otras partes de tu aplicación.
    End Function

End Class
