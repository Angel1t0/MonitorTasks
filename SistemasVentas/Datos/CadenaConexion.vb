Imports System.Data.SqlClient
Module CadenaConexion
    ' Cadena de conexión a la base de datos SQL Server
    'Private sqlCadena As String = "Data Source=SISTEMASRESIDEN;Initial Catalog=MWT_Task;Integrated Security=True"
    Private sqlCadena As String = "Data Source=10.100.100.80,9341;Initial Catalog=MWT_Task;Trusted_Connection=NO;Connect Timeout=300;user id=OperMWT;password=r6*YGM3xvhEsq7hTp9mYVUy-C36VBZ"

    Public Function CrearConexionSQL() As SqlConnection
        Return New SqlConnection(sqlCadena)
    End Function
End Module
