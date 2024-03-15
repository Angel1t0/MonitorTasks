Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization


Public Class DeterminarRecurrencia
    Public Sub ParsearRRULE(mensaje As Mensaje)
        Dim rrule As String = mensaje.RRULE.Substring(6)
        Dim calendarEvent = New CalendarEvent With {
            .RecurrenceRules = {New RecurrencePattern(rrule)}
        }

        Dim occurrences = calendarEvent.GetOccurrences(mensaje.StartDateTime, mensaje.EndDateTime)
        Dim listaOcurriencias As New List(Of Occurrence)
        For Each occurrence In occurrences
            ' Aquí tendrías que programar el envío del correo para cada fecha de ocurrencia
            Dim fechaDeEnvio = occurrence.Period.StartTime.AsSystemLocal
            listaOcurriencias.Add(occurrence)
            Console.WriteLine($"Enviar correo el {fechaDeEnvio}")
        Next
    End Sub
End Class
