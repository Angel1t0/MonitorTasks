﻿Public Class Recurrencia
    Public Property Frecuencia As String
    Public Property DiasSeleccionados As String
    Public Property TipoFinalizacion As String ' "Ocurrencias" o "HastaFecha"
    Public Property NumeroOcurrencias As Integer? ' Nullable para permitir valores no asignados
    Public Property FechaFinal As DateTime?
    Public Property RRULE As String = String.Empty ' La regla de recurrencia generada

    Public Function GenerarRRULE() As String ' De acuerdo a los valores de las propiedades de la clase genera la regla de recurrencia
        Dim rrule As String = $"RRULE:FREQ={Frecuencia}"

        If TipoFinalizacion = "Ocurrencias" AndAlso NumeroOcurrencias.HasValue Then
            rrule &= $";COUNT={NumeroOcurrencias.Value}"
        ElseIf TipoFinalizacion = "HastaFecha" AndAlso FechaFinal.HasValue Then
            rrule &= $";UNTIL={FechaFinal.Value.ToString("yyyyMMddTHHmmssZ")}"
        End If

        If Frecuencia = "WEEKLY" Or Frecuencia = "MONTHLY" AndAlso DiasSeleccionados IsNot Nothing AndAlso DiasSeleccionados.Count > 0 Then
            Dim diasFormateados As String = String.Join(",", DiasSeleccionados)
            rrule &= $";BYDAY={diasFormateados}"
        End If

        ' Asigna el RRULE generado a la propiedad de la clase
        Me.RRULE = rrule

        Return rrule
    End Function


    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)()

        ' Validar la frecuencia
        If String.IsNullOrWhiteSpace(Frecuencia) Then
            errores.Add("La frecuencia de recurrencia es requerida.")
        ElseIf Frecuencia = "WEEKLY" Or Frecuencia = "MONTHLY" Then
            ' Asegurar que se hayan seleccionado días para frecuencias semanales o mensuales
            If DiasSeleccionados Is Nothing OrElse DiasSeleccionados.Count = 0 Then
                errores.Add("Debe seleccionar al menos un día para la recurrencia " & Frecuencia.ToLower() & ".")
            End If
        End If

        ' Validar la elección de finalización de la recurrencia
        Select Case TipoFinalizacion
            Case "Ocurrencias"
                If Not NumeroOcurrencias.HasValue OrElse NumeroOcurrencias.Value <= 0 Then
                    errores.Add("Debe especificar un número válido de ocurrencias.")
                End If
            Case "HastaFecha"
                If Not FechaFinal.HasValue Then
                    errores.Add("Debe especificar una fecha final válida para la recurrencia.")
                End If
        End Select

        Return errores
    End Function
End Class
