Public Class Mensaje
    Public Property MessageID As Integer
    Public Property EventID As String
    Public Property AttendeeID As Integer
    Public Property Title As String
    Public Property Description As String
    Public Property StartDateTime As DateTime
    Public Property EndDateTime As DateTime
    Public Property EmailSent As Boolean = 0
    Public Property WhatsAppSent As Boolean = 0
    Public Property DesktopSent As Boolean = 0
    Public Property SentTime As DateTime
    Public Property Status As String = "Activo"
    Public Property MessageType As String = "Recordatorio"
    Public Property RRULE As String = String.Empty
    Public Property Attendees As New List(Of Asistente)
    Public Property Creator As String
End Class
