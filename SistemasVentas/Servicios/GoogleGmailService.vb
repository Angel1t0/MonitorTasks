

Imports System.IO
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Gmail.v1.Data
Imports System.Text
Imports System.Net.Mail

Public Class GoogleGmailService
    Private ApplicationName As String = "Monitor task - Prueba"

    ' Método que maneja la autenticación y crea un servicio de Gmail.
    Public Function AuthenticateGmail() As GmailService
        Dim authenticator As New GoogleServicesAuthenticator()
        Dim credential As UserCredential = authenticator.AuthenticateGoogleServices()

        ' Inicializar el servicio de Google Calendar
        Dim service = New GmailService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })

        Return service ' Devuelve el servicio autenticado para ser usado en otras partes de tu aplicación.
    End Function

    Public Sub EnviarMensajeMail(service As GmailService, mensaje As Mensaje)
        Dim emailBody As New StringBuilder()
        Dim destinatarios As String = String.Join(",", mensaje.Attendees).Trim() ' Asegúrate de que no hay espacios después de las comas

        emailBody.AppendLine("To: " & destinatarios)
        emailBody.AppendLine("Subject: " & mensaje.Title & " - " & mensaje.MessageType)
        emailBody.AppendLine("Content-Type: text/plain; charset=utf-8")
        emailBody.AppendLine()
        emailBody.AppendLine(mensaje.Description & Environment.NewLine & "Fecha de inicio: " & mensaje.StartDateTime.ToString("yyyy-MM-ddTHH:mm:ss") & Environment.NewLine & "Fecha de fin: " & mensaje.EndDateTime.ToString("yyyy-MM-ddTHH:mm:ss"))

        Dim rawMessage As String = Base64UrlEncode(emailBody.ToString())
        Dim message As New Message() With {
            .Raw = rawMessage
        }

        ' Intentar enviar el mensaje
        Try
            service.Users.Messages.Send(message, "me").ExecuteAsync().Wait()
            Console.WriteLine("Correo enviado correctamente.")
        Catch ex As Exception
            Console.WriteLine("Error al enviar el correo: " & ex.Message)
        End Try
    End Sub

    ' Función auxiliar para codificar en Base64URL
    Private Function Base64UrlEncode(input As String) As String
        Dim inputBytes = Encoding.UTF8.GetBytes(input)
        Return Convert.ToBase64String(inputBytes).Replace("+"c, "-"c).Replace("/"c, "_"c).Replace("="c, "")
    End Function

End Class


