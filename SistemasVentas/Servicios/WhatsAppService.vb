Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types
Imports TwilioOEDll.CTwilioOE



Public Class WhatsAppService

    Private _twilioOE As New TwilioOEDll.CTwilioOE()

    'Public Sub EnviarMensajeWhatsapp(fromWhatsAppNumber As String, messageBody As Mensaje)
    '    Try
    '        Dim accountSid As String = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")
    '        Dim authToken As String = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")

    '        MessageBox.Show(accountSid & " " & authToken)

    '        TwilioClient.Init(accountSid, authToken)

    '        Dim message = MessageResource.Create(
    '            body:=messageBody.Title & Environment.NewLine & messageBody.Description & Environment.NewLine & "Fecha de inicio: " & messageBody.StartDateTime.ToString("yyyy-MM-ddTHH:mm:ss") & Environment.NewLine & "Fecha de fin: " & messageBody.EndDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
    '            from:=New PhoneNumber("whatsapp:+14155238886"),
    '            [to]:=New PhoneNumber("whatsapp:+5217151154099")
    '        )

    '        Console.WriteLine(message.Sid)
    '    Catch ex As Exception
    '        Console.WriteLine(ex.Message)
    '    End Try
    'End Sub

    Public Sub EnviarMensajeWhatsapp(ByVal Mensaje As Mensaje, ByVal TipoCanal As String)

        Dim PTwilioAccountSid As String = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")
        Dim PTwilioAuthToken As String = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")
        Dim PTwilioPhoneNumberwhatsappFrom As String = Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER")
        Dim description As String = "Este es un recordatorio del evento " & Mensaje.Title & ", " & Mensaje.Description
        Try
            For Each attendee In Mensaje.Attendees
                Dim TelefonoEnviar As String = attendee.PhoneNumber

                If TipoCanal = "SMS" Then
                    _twilioOE.SendSMSTwilio(PTwilioAccountSid, PTwilioAuthToken, PTwilioPhoneNumberwhatsappFrom, description, "52" & TelefonoEnviar)
                ElseIf TipoCanal = "WhatsApp" Then
                    _twilioOE.EnviarSMSWhatsApp(0, 0, 0, description, "52" & TelefonoEnviar, TipoCanal, 0, "", PTwilioPhoneNumberwhatsappFrom, PTwilioAccountSid, PTwilioAuthToken, "")
                Else
                    _twilioOE.EnviarSMSWhatsApp(0, 0, 0, description, "52" & TelefonoEnviar, TipoCanal, 0, "", PTwilioPhoneNumberwhatsappFrom, PTwilioAccountSid, PTwilioAuthToken, "")
                    _twilioOE.SendSMSTwilio(PTwilioAccountSid, PTwilioAuthToken, PTwilioPhoneNumberwhatsappFrom, description, "52" & TelefonoEnviar)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Class
