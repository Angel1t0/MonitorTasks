Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization


Public Class DeterminarRecurrencia
    Public Function ParsearRRULE(mensaje As Mensaje) As List(Of Occurrence)
        Dim listaOcurriencias As New List(Of Occurrence)
        Try
            Dim calendarEvent = New CalendarEvent With {
                .Start = New CalDateTime(mensaje.FechaInicio),
                .End = New CalDateTime(mensaje.FechaFin)
            }

            If Not String.IsNullOrEmpty(mensaje.RRULE) Then
                Dim rrule As String = mensaje.RRULE.Substring(6)
                Dim recurrencePattern = New RecurrencePattern(rrule)
                calendarEvent.RecurrenceRules.Add(recurrencePattern)
            End If

            Dim ocurrencias = calendarEvent.GetOccurrences(mensaje.FechaInicio, mensaje.FechaFin)

            For Each ocurrencia In ocurrencias
                ' Aquí tendrías que programar el envío del correo para cada fecha de ocurrencia
                Dim fechaDeEnvio = ocurrencia.Period.StartTime.AsSystemLocal
                listaOcurriencias.Add(ocurrencia)
            Next
        Catch ex As Exception
            Console.WriteLine("Error al parsear la recurrencia: " & ex.Message)
        End Try
        Return listaOcurriencias
    End Function
End Class
