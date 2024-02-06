Imports System.Text.RegularExpressions

Module Validaciones
    Public Function ValidarCorreo(correo As String) As Boolean
        Return Regex.IsMatch(correo, "[0-9a-zA-Z]([-.w]*[0-9a-zA-Z_+]) *@([0-9a-zA-Z][-w]*[0-9a-zA-Z].)+[a-zA-Z]{2,9}$")
    End Function
End Module
