Public Class Mensaje
    Public Property MessageID As Integer
    Public Property EventID As String
    Public Property AttendeeID As Integer
    Public Property Title As String
    Public Property Description As String
    Public Property StartDateTime As DateTime
    Public Property EndDateTime As DateTime
    Public Property EmailSent As Boolean
    Public Property WhatsAppSent As Boolean
    Public Property DesktopSent As Boolean
    Public Property SentTime As DateTime
    Public Property Status As String
    Public Property MessageType As String
    Public Property RRULE As String = String.Empty

End Class
