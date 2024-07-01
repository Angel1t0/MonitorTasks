Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types
Imports TwilioOEDll.CTwilioOE



Public Class ServicioWhatsapp

    Private _twilioOE As New TwilioOEDll.CTwilioOE() ' DLL de Twilio para enviar mensajes de WhatsApp y SMS

    Public Sub EnviarMensajeWhatsapp(ByVal Mensaje As Mensaje, ByVal TipoCanal As String) ' TipoCanal en este caso siempre será "WhatsApp"

        Dim PTwilioAccountSid As String = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")
        Dim PTwilioAuthToken As String = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")
        Dim PTwilioPhoneNumberwhatsappFrom As String = Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER")

        Dim mensajeWhatsApp As String

        Select Case Mensaje.TipoMensaje
            Case "Actualización"
                mensajeWhatsApp = "\nEsta es una *actualización* de la actividad: _" & Mensaje.Titulo & "_." & "\n\n" &
                          "_" & Mensaje.Descripcion & "_" & "\n\n" &
                          "Puede ver más detalles en el siguiente enlace: " &
                          "https://podio.com/orderexpresscommx/sistemas/item/" & Mensaje.PodioAppItemID
            Case "Nueva Actividad"
                mensajeWhatsApp = "\nEsta es una *nueva actividad*: _" & Mensaje.Titulo & "_." & "\n\n" &
                          "_" & Mensaje.Descripcion & "_" & "\n\n" &
                          "Puede ver más detalles en el siguiente enlace: " &
                          "https://podio.com/orderexpresscommx/sistemas/item/" & Mensaje.PodioAppItemID
            Case Else
                mensajeWhatsApp = "\nEste es un *recordatorio* de la actividad: _" & Mensaje.Titulo & "_." & "\n\n" &
                          "_" & Mensaje.Descripcion & "_." & "\n\n" &
                          "Puede ver más detalles en el siguiente enlace: " &
                          "https://podio.com/orderexpresscommx/sistemas/item/" & Mensaje.PodioAppItemID
        End Select

        Try
            For Each attendee In Mensaje.Destinatarios
                Dim TelefonoEnviar As String = attendee.Telefono

                If TipoCanal = "SMS" Then
                    _twilioOE.SendSMSTwilio(PTwilioAccountSid, PTwilioAuthToken, PTwilioPhoneNumberwhatsappFrom, mensajeWhatsApp, "52" & TelefonoEnviar)
                ElseIf TipoCanal = "WhatsApp" Then
                    _twilioOE.EnviarSMSWhatsApp(0, 0, 0, mensajeWhatsApp, "52" & TelefonoEnviar, TipoCanal, 0, "", PTwilioPhoneNumberwhatsappFrom, PTwilioAccountSid, PTwilioAuthToken, "")
                Else
                    _twilioOE.EnviarSMSWhatsApp(0, 0, 0, mensajeWhatsApp, "52" & TelefonoEnviar, TipoCanal, 0, "", PTwilioPhoneNumberwhatsappFrom, PTwilioAccountSid, PTwilioAuthToken, "")
                    _twilioOE.SendSMSTwilio(PTwilioAccountSid, PTwilioAuthToken, PTwilioPhoneNumberwhatsappFrom, mensajeWhatsApp, "52" & TelefonoEnviar)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Class
