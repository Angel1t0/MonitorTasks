Public Class Evento
    Public Property EventID As String
    Public Property CalendarID As String
    Public Property UserID As String
    Public Property Summary As String = String.Empty ' Valor por defecto vacío
    Public Property Location As String = String.Empty
    Public Property Description As String = String.Empty
    Public Property StartDateTime As DateTime = DateTime.Now ' Valor por defecto
    Public Property EndDateTime As DateTime? = New DateTime(DateTime.Now.Year, 12, 31) ' Valor por defecto
    Public Property RRULE As String = String.Empty
    Public Property Attendees As List(Of Asistente)
    Public Property Reminders As List(Of Notificacion)
    Public Property Message As Mensaje
    Public Property ListMessages As List(Of Mensaje)
    Public Property Visibility As String = "default"
    Public Property Transparency As String = "opaque"
    Public Property LastModified As DateTime = DateTime.Now ' Valor por defecto
    Public Property Status As String = "Activo"
    Public Property CreatorPhone As String = String.Empty

    Public Sub New()
        Attendees = New List(Of Asistente)
        Reminders = New List(Of Notificacion)
    End Sub

    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)

        If String.IsNullOrWhiteSpace(Summary) Then
            errores.Add("El campo 'Summary' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Description) Then
            errores.Add("El campo 'Description' es obligatorio.")
        End If

        If StartDateTime = DateTime.MinValue Then
            errores.Add("El campo 'StartDateTime' es obligatorio.")
        End If

        If EndDateTime = DateTime.MinValue Then
            errores.Add("El campo 'EndDateTime' es obligatorio.")
        End If

        If StartDateTime > EndDateTime Then
            errores.Add("La fecha de inicio no puede ser mayor a la fecha de fin.")
        End If
        Return errores
    End Function
End Class
