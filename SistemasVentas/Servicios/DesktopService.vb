Public Class DesktopService
    Private _notifyIcon As NotifyIcon

    Public Sub New()
        _notifyIcon = New NotifyIcon()
        _notifyIcon.Icon = SystemIcons.Information  ' Asigna un ícono
        _notifyIcon.Visible = True
    End Sub

    Public Sub EnviarNotificacionDesktop(mensaje As Mensaje)
        ' Asegurar que el título y la descripción tengan un valor predeterminado si están vacíos
        Dim titulo = If(String.IsNullOrWhiteSpace(mensaje.Title), "Sin título", mensaje.Title)
        Dim descripcion = If(String.IsNullOrWhiteSpace(mensaje.Description), "Sin descripción", mensaje.Description) & Environment.NewLine & mensaje.StartDateTime.Date.ToString("yyyy-MM-ddTHH") & Environment.NewLine & "Fecha de fin: " & mensaje.EndDateTime.Date.ToString("yyyy-MM-ddTHH")

        _notifyIcon.BalloonTipTitle = titulo
        _notifyIcon.BalloonTipText = descripcion
        _notifyIcon.ShowBalloonTip(3000)  ' Muestra la notificación por 3000 milisegundos
    End Sub
End Class
