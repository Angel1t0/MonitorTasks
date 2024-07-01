Public Class ServicioDesktop
    Private _notifyIcon As NotifyIcon

    Public Sub New()
        _notifyIcon = New NotifyIcon()
    End Sub

    Public Sub EnviarNotificacionDesktop(mensaje As Mensaje)
        ' Asegurar que el título y la descripción tengan un valor predeterminado si están vacíos
        Dim titulo = If(String.IsNullOrWhiteSpace(mensaje.Titulo), "Sin título", mensaje.Titulo)
        Dim descripcion = If(String.IsNullOrWhiteSpace(mensaje.Descripcion), "Sin descripción", mensaje.Descripcion) & Environment.NewLine & mensaje.FechaInicio.Date.ToString("yyyy-MM-ddTHH") & Environment.NewLine & "Fecha de fin: " & mensaje.FechaFin.Date.ToString("yyyy-MM-ddTHH")
        _notifyIcon.Icon = SystemIcons.Information  ' Asigna un ícono

        _notifyIcon.Visible = True
        _notifyIcon.BalloonTipTitle = titulo
        _notifyIcon.BalloonTipText = descripcion
        _notifyIcon.ShowBalloonTip(3000)  ' Muestra la notificación por 3000 milisegundos
    End Sub
End Class
