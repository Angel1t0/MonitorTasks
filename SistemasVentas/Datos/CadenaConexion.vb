Imports System.Data.SqlClient
Module CadenaConexion
    Private sqlCadena As String = "Data Source=SISTEMASRESIDEN;Initial Catalog=BaseSistemasVentas;Integrated Security=True"

    Public Function CrearConexionSQL() As SqlConnection
        Return New SqlConnection(sqlCadena)
    End Function
End Module
