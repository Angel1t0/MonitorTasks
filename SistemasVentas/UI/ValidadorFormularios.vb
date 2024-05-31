Imports System.Text.RegularExpressions

Module ValidadorFormularios

    ' --- FORMULARIO GESTION USUARIOS ---
    Public Function ValidarCorreo(correo As String) As Boolean
        Return Regex.IsMatch(correo, "[0-9a-zA-Z]([-.w]*[0-9a-zA-Z_+]) *@([0-9a-zA-Z][-w]*[0-9a-zA-Z].)+[a-zA-Z]{2,9}$")
    End Function

    Public Function ValidarEntradasUsuario(name As String, user As String, pass As String, login As String, cel As String) As Boolean
        If name = "" OrElse user = "" OrElse pass = "" Then
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

        ' comprobar si cel es menor a 10 digitos y si no son numeros
        If cel.Length < 10 OrElse Not IsNumeric(cel) Then
            MessageBox.Show("El campo de celular debe tener 10 digitos y ser numerico", "Celular", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    ' --- FORMULARIO LOGIN ---
    Public Function ValidarEntradasLogin(login As String, pass As String) As Boolean
        If login = "" OrElse pass = "" Then
            MessageBox.Show("Los campos de usuario y contraseña no pueden estar vacios", "Campos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function
End Module
