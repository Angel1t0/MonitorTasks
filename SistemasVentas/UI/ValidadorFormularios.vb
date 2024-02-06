Imports System.Text.RegularExpressions

Module ValidadorFormularios
    Public Function ValidarCorreo(correo As String) As Boolean
        Return Regex.IsMatch(correo, "[0-9a-zA-Z]([-.w]*[0-9a-zA-Z_+]) *@([0-9a-zA-Z][-w]*[0-9a-zA-Z].)+[a-zA-Z]{2,9}$")
    End Function

    Public Function ValidarEntradasUsuario(name As String, user As String, pass As String, login As String, rol As String, icono As Label) As Boolean
        If name = "" OrElse user = "" OrElse pass = "" OrElse rol = "" Then
            MessageBox.Show("Los campos de texto no pueden estar vacios", "Campos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not ValidarCorreo(login) Then
            MessageBox.Show("Error en el formato de correo", "Validación de correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If pass.Length <= 5 Then
            MessageBox.Show("La contraseña debe ser igual o mayor a 6 caracteres", "Cantidad de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If icono.Visible = True Then
            MessageBox.Show("Elije un icono", "Icono", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function
End Module
