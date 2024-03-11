Public Class Evento
    Public Property EventID As String
    Public Property CalendarID As String ' Valor por defecto vacío
    Public Property Summary As String = String.Empty ' Valor por defecto vacío
    Public Property Location As String = String.Empty ' Valor por defecto vacío, asumiendo que puede ser opcional
    Public Property Description As String = String.Empty ' Valor por defecto vacío, asumiendo que puede ser opcional
    Public Property StartDateTime As DateTime = DateTime.MinValue.ToString("yyyy-MM-ddTHH:mm:ssZ") ' Valor por defecto, necesitas decidir un valor razonable
    Public Property EndDateTime As DateTime? = DateTime.MinValue.ToString("yyyy-MM-ddTHH:mm:ssZ") ' Valor por defecto, necesitas decidir un valor razonable
    Public Property RRULE As String = String.Empty ' Valor por defecto vacío
    Public Property Attendees As List(Of Asistente) ' Valor por defecto vacío
    Public Property Reminders As List(Of Notificacion) ' Valor por defecto vacío
    Public Property Visibility As String = "default"
    Public Property Transparency As String = "opaque"
    Public Property LastModified As DateTime = DateTime.Now ' Valor por defecto
    Public Property Status As String = "Activo"

    Public Sub New()
        Attendees = New List(Of Asistente)
        Reminders = New List(Of Notificacion)
    End Sub

    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)

        If String.IsNullOrWhiteSpace(Summary) Then
            errores.Add("El campo 'Summary' es obligatorio.")
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

    Public Function HayAsistentesDuplicados(asistente As Asistente) As Boolean
        If Attendees.Any(Function(a) a.Email.Equals(asistente.Email, StringComparison.OrdinalIgnoreCase)) Then
            Return True
        End If
        Attendees.Add(asistente)
        Return False
    End Function
End Class
