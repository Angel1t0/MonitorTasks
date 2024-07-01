Public Class Mensaje
    Public Property MensajeID As Integer
    Public Property EventoID As String
    Public Property PodioAppItemID As Long = 0 ' ID del item en Podio
    Public Property UserID As Integer
    Public Property Titulo As String
    Public Property Descripcion As String
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime
    Public Property EmailSilenciado As Boolean = 0
    Public Property WhatsAppSilenciado As Boolean = 0
    Public Property DesktopSilenciado As Boolean = 0
    Public Property FechaEnviado As DateTime
    Public Property Status As String = "Activo"
    Public Property TipoMensaje As String = "Recordatorio"
    Public Property RRULE As String = String.Empty
    Public Property Destinatarios As New List(Of Asistente)
    Public Property Creador As String
End Class
