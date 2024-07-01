Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Gmail.v1.Data
Imports System.Text

Public Class ServicioGoogleGmail
    Private ApplicationName As String = "Monitor task - Prueba"

    ' Método que maneja la autenticación y crea un servicio de Gmail.
    Public Function AuthenticateGmail() As GmailService
        Dim authenticator As New AutenticadorServiciosGoogle()
        Dim credential As UserCredential = authenticator.AuthenticateGoogleServices()

        ' Inicializar el servicio de Google Calendar
        Dim service = New GmailService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })

        Return service ' Devuelve el servicio autenticado para ser usado en otras partes de la aplicación.
    End Function

    Public Sub EnviarMensajeMail(service As GmailService, mensaje As Mensaje)
        Dim emailBody As New StringBuilder()
        Dim destinatarios As String = String.Join(",", mensaje.Destinatarios.Select(Function(a) a.Email).ToArray()) ' Concatenar los correos de los destinatarios
        destinatarios = destinatarios.Trim() ' No hay espacios después de las comas

        ' Crear el enlace de la actividad en Podio
        Dim linkActividad As String = $"https://podio.com/orderexpresscommx/sistemas/item/{mensaje.PodioAppItemID}"


        ' Crear el cuerpo del correo en HTML
        emailBody.AppendLine("To: " & destinatarios)
        emailBody.AppendLine("Subject: " & mensaje.TipoMensaje & " - " & mensaje.Titulo)
        emailBody.AppendLine("Content-Type: text/html; charset=utf-8")
        emailBody.AppendLine()
        emailBody.AppendLine("<!DOCTYPE html>")
        emailBody.AppendLine("<html lang='es'>")
        emailBody.AppendLine("<head>")
        emailBody.AppendLine("<meta charset='UTF-8'>")
        emailBody.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>")
        emailBody.AppendLine("<title>Correo Personalizado</title>")
        emailBody.AppendLine("<style>")
        emailBody.AppendLine("body { font-family: 'Arial', sans-serif; background-color: #fff; margin: 0; padding: 0; }")
        emailBody.AppendLine(".container { width: 100%; padding: 20px; background-color: #eee; margin: 20px auto; max-width: 600px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }")
        emailBody.AppendLine(".header { background-color: #16185e; color: white; text-align: center; padding: 10px 0; }")
        emailBody.AppendLine(".content { padding: 20px; line-height: 1.6; }")
        emailBody.AppendLine(".footer { background-color: #16185e; color: white; text-align: center; padding: 10px 0; font-size: 12px; }")
        emailBody.AppendLine(".button { display: inline-block; background-color: #cd206e; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; }")
        emailBody.AppendLine(".button:hover { background-color: #b71c59; }") ' Agregado para el hover
        emailBody.AppendLine("</style>")
        emailBody.AppendLine("</head>")
        emailBody.AppendLine("<body>")
        emailBody.AppendLine("<div class='container'>")
        emailBody.AppendLine("<div class='header'><h1>" & mensaje.Titulo & "</h1></div>")
        emailBody.AppendLine("<div class='content'>")
        emailBody.AppendLine("<p>" & mensaje.Descripcion & "</p>")
        emailBody.AppendLine("<p><strong>Fecha de inicio:</strong> " & mensaje.FechaInicio.ToString("yyyy-MM-ddTHH") & "</p>")
        emailBody.AppendLine("<p><strong>Fecha de fin:</strong> " & mensaje.FechaFin.ToString("yyyy-MM-ddTHH") & "</p>")
        emailBody.AppendLine("<a href='" & linkActividad & "' class='button'style='color: white !important; text-decoration: none;'>Ver Detalles</a>")
        emailBody.AppendLine("</div>")
        emailBody.AppendLine("<div class='footer'>Este es un mensaje automático. Por favor, no responda a este correo.</div>")
        emailBody.AppendLine("</div>")
        emailBody.AppendLine("</body>")
        emailBody.AppendLine("</html>")

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

    ' Función auxiliar para codificar en Base64URL para el envio de correos
    Private Function Base64UrlEncode(input As String) As String
        Dim inputBytes = Encoding.UTF8.GetBytes(input)
        Return Convert.ToBase64String(inputBytes).Replace("+"c, "-"c).Replace("/"c, "_"c).Replace("="c, "")
    End Function

End Class


