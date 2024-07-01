Public Class Notificacion
    Public Property RecordatorioID As Integer
    Public Property EventoID As String
    Public Property Metodo As String ' Por ejemplo, "email" o "popup"
    Public Property Minutos As Integer ' Cuántos minutos antes del evento se debe enviar la notificación
    Public Property Status As String = "Activo" ' "Activa" o "Inactiva"
End Class
