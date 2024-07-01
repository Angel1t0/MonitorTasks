Public Class Evento
    Public Property EventoID As String
    Public Property CalendarioID As String
    Public Property UserID As String
    Public Property Titulo As String = String.Empty ' Valor por defecto vacío
    Public Property Ubicacion As String = String.Empty
    Public Property Descripcion As String = String.Empty
    Public Property FechaInicio As DateTime = DateTime.Now ' Valor por defecto
    Public Property FechaFin As DateTime? = New DateTime(DateTime.Now.Year, 12, 31) ' Valor por defecto
    Public Property RRULE As String = String.Empty
    Public Property Asistentes As List(Of Asistente)
    Public Property Recordatorios As List(Of Notificacion)
    Public Property Mensaje As Mensaje
    Public Property ListaMensajes As List(Of Mensaje)
    Public Property Visibilidad As String = "default"
    Public Property Transparencia As String = "opaque"
    Public Property UltimaModificacion As DateTime = DateTime.Now ' Valor por defecto
    Public Property Status As String = "Activo"
    Public Property TelefonoCreador As String = String.Empty

    Public Sub New()
        Asistentes = New List(Of Asistente)
        Recordatorios = New List(Of Notificacion)
    End Sub

    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)

        If String.IsNullOrWhiteSpace(Titulo) Then
            errores.Add("El campo 'Summary' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Descripcion) Then
            errores.Add("El campo 'Description' es obligatorio.")
        End If

        If FechaInicio = DateTime.MinValue Then
            errores.Add("El campo 'StartDateTime' es obligatorio.")
        End If

        If FechaFin = DateTime.MinValue Then
            errores.Add("El campo 'EndDateTime' es obligatorio.")
        End If

        If FechaInicio > FechaFin Then
            errores.Add("La fecha de inicio no puede ser mayor a la fecha de fin.")
        End If
        Return errores
    End Function
End Class
