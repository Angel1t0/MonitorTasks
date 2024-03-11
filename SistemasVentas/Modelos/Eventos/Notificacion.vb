Public Class Notificacion
    Public Property ReminderID As Integer
    Public Property EventID As String
    Public Property Method As String ' Por ejemplo, "email" o "popup"
    Public Property Minutes As Integer ' Cuántos minutos antes del evento se debe enviar la notificación
    Public Property Status As String = "Activo" ' "Activa" o "Inactiva"
End Class
