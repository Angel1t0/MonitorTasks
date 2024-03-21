Public Class DesktopService
    Private _notifyIcon As NotifyIcon

    Public Sub New()
        _notifyIcon = New NotifyIcon()
        _notifyIcon.Icon = SystemIcons.Application  ' Asigna un ícono
        _notifyIcon.Visible = True
    End Sub

    Public Sub EnviarNotificacionDesktop(mensaje As Mensaje)
        _notifyIcon.BalloonTipTitle = mensaje.Title
        _notifyIcon.BalloonTipText = mensaje.Description
        _notifyIcon.ShowBalloonTip(3000)  ' Muestra la notificación por 3000 milisegundos
    End Sub
End Class
