Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Public Class WhatsAppService


    Public Sub EnviarMensajeWhatsapp(fromWhatsAppNumber As String, messageBody As Mensaje)
        Try
            Dim accountSid As String = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")
            Dim authToken As String = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")

            MessageBox.Show(accountSid & " " & authToken)

            TwilioClient.Init(accountSid, authToken)

            Dim message = MessageResource.Create(
                body:=messageBody.Title & Environment.NewLine & messageBody.Description & Environment.NewLine & "Fecha de inicio: " & messageBody.StartDateTime.ToString("yyyy-MM-ddTHH:mm:ss") & Environment.NewLine & "Fecha de fin: " & messageBody.EndDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                from:=New PhoneNumber("whatsapp:+14155238886"),
                [to]:=New PhoneNumber("whatsapp:+5217151154099")
            )

            Console.WriteLine(message.Sid)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Class
