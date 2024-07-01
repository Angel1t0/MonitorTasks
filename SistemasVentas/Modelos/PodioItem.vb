Public Class PodioItem
    Public Property PodioItemID As Integer ' ID único para la base de datos local
    Public Property EventoID As String ' Vincula con la tabla de eventos
    Public Property PodioAppID As Integer = 1350510  ' ID de la aplicación en Podio
    Public Property PodioAppItemID As Long = 0 ' ID del item en Podio
    Public Property Titulo As String ' Título del elemento
    Public Property Descripcion As String ' Descripción del elemento
    Public Property Empresa As New List(Of String) ' Empresa solicitante
    Public Property Departamento As String  ' Departamento solicitante
    Public Property PrioridadDepartamento As Integer  ' Orden de prioridad del departamento
    Public Property AreaSistemas As String  ' Área de sistemas
    Public Property Categorias As String  ' Categorías
    Public Property ContactosSolicitantes As New List(Of Integer) ' ID de contacto del solicitante
    Public Property ContactosAutorizantes As New List(Of Integer) ' ID de contacto del que autoriza
    Public Property ContactosAsigandoA As New List(Of Integer) ' ID de contacto del asignado
    Public Property PrioridadSistemas As Integer  ' Orden de prioridad de sistemas
    Public Property Prioridad As String  ' Prioridad (texto)
    Public Property FechaInicio As DateTime  ' Fecha de inicio
    Public Property FechaFin As DateTime  ' Fecha de entrega
    Public Property PlanTrabajo As String = ""  ' Plan de trabajo o acción
    Public Property Status As String  ' Estatus
    Public Property Progreso As Integer ' Progreso (en porcentaje)
    Public Property ProyectoSistemas As New List(Of String)  ' Proyecto/Actividades de Sistemas
    Public Property ProyectoGeneral As String  ' Proyecto general
    Public Property HorasAcumuladas As Integer  ' Horas acumuladas
    Public Property HorasExtras As Integer  ' Horas extras
    Public Property ScrumDaily As Integer  ' Referencia a SCRUM Daily
    Public Property FechaCreacion As DateTime  ' Fecha de creación
    Public Property UltimaModificacion As DateTime  ' Última modificación

    ' Crear un diccionario para almacenar las relaciones entre los nombres de las categorias y sus ID
    Public empresaOpciones As New Dictionary(Of String, Integer)()
    Public departamentoOpciones As New Dictionary(Of String, Integer)()
    Public areaSistemasOpciones As New Dictionary(Of String, Integer)()
    Public categoriaOpciones As New Dictionary(Of String, Integer)()
    Public prioridadOpciones As New Dictionary(Of String, Integer)()
    Public statusOpciones As New Dictionary(Of String, Integer)()

    Public temporaryMapTituloAID As New Dictionary(Of String, String)() ' Diccionario temporal para mapear títulos a IDs de los proyectos de sistemas
    Public mapTituloAID As New Dictionary(Of String, String)() ' Diccionario para mapear títulos a IDs de los proyectos de sistemas
    Public InvertidosMapTituloAID As New Dictionary(Of String, String)()

    Public empresaOpcionesInvertidas As New Dictionary(Of Integer, String)()
    Public departamentoOpcionesInvertidas As New Dictionary(Of Integer, String)()
    Public areaSistemasOpcionesInvertidas As New Dictionary(Of Integer, String)()
    Public categoriaOpcionesInvertidas As New Dictionary(Of Integer, String)()
    Public prioridadOpcionesInvertidas As New Dictionary(Of Integer, String)()
    Public statusOpcionesInvertidas As New Dictionary(Of Integer, String)()

    Public contactoAutorizantesDict As New Dictionary(Of String, Integer)() ' Diccionario para mapear correos de contactos a IDs
    Public contactoSolicitantesDict As New Dictionary(Of String, Integer)() ' Diccionario para mapear correos de contactos a IDs

    Public Sub New()
        InicializarOpciones()
    End Sub

    Public Function ConvertirTiempoASegundos(time As String) As Integer
        Dim timeParts As String() = time.Split(":")
        Dim hours As Integer = Integer.Parse(timeParts(0))
        Dim minutes As Integer = Integer.Parse(timeParts(1))
        Dim seconds As Integer = Integer.Parse(timeParts(2))
        Return hours * 3600 + minutes * 60 + seconds
    End Function

    Public Function ConvertirSegundosATiempo(seconds As Integer) As String
        Dim hours As Integer = seconds \ 3600
        Dim minutes As Integer = (seconds Mod 3600) \ 60
        Dim remainingSeconds As Integer = seconds Mod 60
        Return hours.ToString("00") & ":" & minutes.ToString("00") & ":" & remainingSeconds.ToString("00")
    End Function

    Public Sub InicializarOpciones()
        ' Inicializar las opciones de las categorias en sus diccionarios
        empresaOpciones.Add("Todas", 15)
        empresaOpciones.Add("Incorporated Express SA de CV", 16)
        empresaOpciones.Add("FUNERA", 17)
        empresaOpciones.Add("OrderExpress Inc", 3)
        empresaOpciones.Add("OEPM", 11)
        empresaOpciones.Add("OECC", 14)
        empresaOpciones.Add("OE Financial Inc", 9)
        empresaOpciones.Add("LOFT SA de CV", 10)
        empresaOpciones.Add("JP Casa de Cambio Inc", 2)
        empresaOpciones.Add("J&P Financial Inc", 13)
        empresaOpciones.Add("JP SofiExpress", 12)
        empresaOpciones.Add("REALIZA", 18)

        departamentoOpciones.Add("Administracion", 1)
        departamentoOpciones.Add("Agencias", 6)
        departamentoOpciones.Add("Agentes", 15)
        departamentoOpciones.Add("Callcenter", 2)
        departamentoOpciones.Add("Cumplimiento MX", 18)
        departamentoOpciones.Add("Cumplimiento USA", 4)
        departamentoOpciones.Add("Cobranza", 3)
        departamentoOpciones.Add("Contabilidad", 11)
        departamentoOpciones.Add("Control Interno", 14)
        departamentoOpciones.Add("Correponsales o Proveedores", 20)
        departamentoOpciones.Add("Cheques", 10)
        departamentoOpciones.Add("DIRECCION", 21)
        departamentoOpciones.Add("Marketing", 7)
        departamentoOpciones.Add("Monitoreo", 17)
        departamentoOpciones.Add("Operaciones", 12)
        departamentoOpciones.Add("Publicidad", 16)
        departamentoOpciones.Add("Recursos Humanos", 13)
        departamentoOpciones.Add("Sistemas", 5)
        departamentoOpciones.Add("Supervision", 9)
        departamentoOpciones.Add("Tesoreria", 8)
        departamentoOpciones.Add("Ventas (Aociadas/Oficinas)", 19)

        areaSistemasOpciones.Add("Soporte", 2)
        areaSistemasOpciones.Add("Desarrollo", 1)
        areaSistemasOpciones.Add("Infraestructura", 3)
        areaSistemasOpciones.Add("Administracion/Direccion", 5)

        categoriaOpciones.Add("[ADMIN] Acuerdos de Confidencialidad Con Terceros", 72)
        categoriaOpciones.Add("[ADMIN] Auditorias", 56)
        categoriaOpciones.Add("[ADMIN] Manuales", 34)
        categoriaOpciones.Add("[ADMIN] Plan  de Contingencia", 25)
        categoriaOpciones.Add("[ADMIN] Podio", 27)
        categoriaOpciones.Add("[DESARROLLO] Actualizacion de Certificados", 59)
        categoriaOpciones.Add("[DESARROLLO] Correccion de Error", 65)
        categoriaOpciones.Add("[DESARROLLO] Desarrollo General", 1)
        categoriaOpciones.Add("[DESARROLLO] Entrega (Spring de Scrum - 15 Dias)", 13)
        categoriaOpciones.Add("[DESARROLLO] Error de Corresponsal", 5)
        categoriaOpciones.Add("[DESARROLLO] Integracion de Corresponsal", 28)
        categoriaOpciones.Add("[DESARROLLO] Importación Contable Mensual", 42)
        categoriaOpciones.Add("[DESARROLLO] Mantenimiento", 7)
        categoriaOpciones.Add("[DESARROLLO] Mejora en Sistemas/Modulo", 66)
        categoriaOpciones.Add("[DESARROLLO] Publicacion", 9)
        categoriaOpciones.Add("[DESARROLLO] Soporte en Produccion", 78)
        categoriaOpciones.Add("[SOPORTE] Actualizacion De Imagenes En Pantallas", 30)
        categoriaOpciones.Add("[SOPORTE] 1Password - Alta", 75)
        categoriaOpciones.Add("[SOPORTE] 1Password - Baja", 76)
        categoriaOpciones.Add("[SOPORTE] 1Password - Modificacion", 77)
        categoriaOpciones.Add("[SOPORTE] Alta de Corresponsal/Agente", 70)
        categoriaOpciones.Add("[SOPORTE] Acceso a Red Inalambrica", 60)
        categoriaOpciones.Add("[SOPORTE] Alta de Servicio o Producto", 6)
        categoriaOpciones.Add("[SOPORTE] Cambio de Contrasena", 35)
        categoriaOpciones.Add("[SOPORTE] Camaras", 20)
        categoriaOpciones.Add("[SOPORTE] Capacitaciones", 8)
        categoriaOpciones.Add("[SOPORTE] Correo Electrónico - Alta", 51)
        categoriaOpciones.Add("[SOPORTE] Correo Electrónico - Baja", 52)
        categoriaOpciones.Add("[SOPORTE] Correo Electrónico - Reasignacion", 53)
        categoriaOpciones.Add("[SOPORTE] Correo Electrónico - Suspension", 54)
        categoriaOpciones.Add("[SOPORTE] Equipo de Computo", 69)
        categoriaOpciones.Add("[SOPORTE] Error de Usuario", 4)
        categoriaOpciones.Add("[SOPORTE] Extensión Telefónica", 37)
        categoriaOpciones.Add("[SOPORTE] Google Suite", 26)
        categoriaOpciones.Add("[SOPORTE] Instalación y/o Configuración de Software", 44)
        categoriaOpciones.Add("[SOPORTE] Impresoras y/o Scanners", 67)
        categoriaOpciones.Add("[SOPORTE] Mantenimiento de Equipo", 68)
        categoriaOpciones.Add("[SOPORTE] Produccion", 21)
        categoriaOpciones.Add("[SOPORTE] Solicitud de Equipo", 62)
        categoriaOpciones.Add("[SOPORTE] Soporte General", 2)
        categoriaOpciones.Add("[SOPORTE] TeamViewer", 74)
        categoriaOpciones.Add("[SOPORTE] Usuarios - Alta", 12)
        categoriaOpciones.Add("[SOPORTE] Usuarios - Baja", 48)
        categoriaOpciones.Add("[SOPORTE] Usuario - Baja", 3)
        categoriaOpciones.Add("[SOPORTE] Usuarios - Modificación", 49)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Acceso a Red WiFi", 61)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Comunicaciones", 64)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Conmutador", 63)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Mantenimiento de Servidores y/o Redes", 10)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Monitoreo", 43)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Redes", 14)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Redes - Monitoreo y Analisis de Logs", 16)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Servidores", 41)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Redes - VPN", 47)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Reporte", 23)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Solicitud de Equipo", 11)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Servidores - Almacenamiento SAN", 50)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Servidores - Based de Datos", 31)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Servidores - Migracion de Sistema Operativo", 45)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad", 58)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Actividad Sospechosa", 39)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Servidores - Backup y/o Replica", 29)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Actualización de Parches", 36)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Antivirus", 57)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Acceso", 18)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Antivirus", 17)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Firewalls", 38)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Redes", 19)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Monitoreo", 24)
        categoriaOpciones.Add("[INFRAESTRUCTURA] Seguridad - Análisis de Vulnerabilidades", 40)
        categoriaOpciones.Add("[INFRAESTRUCTURA] SQL - Store Procedure", 46)
        categoriaOpciones.Add("[SEGURIDAD] Auditoria Interna", 73)

        prioridadOpciones.Add("Alta", 1)
        prioridadOpciones.Add("Normal", 2)
        prioridadOpciones.Add("Baja", 3)
        prioridadOpciones.Add("De Acuerdo a Fecha de Entrega", 4)

        statusOpciones.Add("No comenzada / Pendiente", 5)
        statusOpciones.Add("En Analisis De Requerimientos", 9)
        statusOpciones.Add("En Desarrollo", 3)
        statusOpciones.Add("En Pruebas", 10)
        statusOpciones.Add("En Monitoreo", 14)
        statusOpciones.Add("Finalizada", 4)
        statusOpciones.Add("Aplazada", 1)
        statusOpciones.Add("A la espera de otra persona", 7)
        statusOpciones.Add("Pendiente Confirmar Actividad", 16)
        statusOpciones.Add("Pendiente de Publicar", 11)
        statusOpciones.Add("Permanente", 6)
        statusOpciones.Add("Publicado", 12)
        statusOpciones.Add("Suspendida", 8)
        statusOpciones.Add("Trabajando", 15)

        InvertirOpciones()
    End Sub

    Public Sub InvertirOpciones()
        ' Invertir las opciones de las categorias en sus diccionarios
        For Each kvp As KeyValuePair(Of String, Integer) In empresaOpciones
            empresaOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In departamentoOpciones
            departamentoOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In areaSistemasOpciones
            areaSistemasOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In categoriaOpciones
            categoriaOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In prioridadOpciones
            prioridadOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In statusOpciones
            statusOpcionesInvertidas.Add(kvp.Value, kvp.Key)
        Next
    End Sub

    Public Sub CargarOpcionesComboBox(comboBoxOptions As ComboBox, dictionary As Dictionary(Of String, Integer))
        ' Cargar las opciones de las categorias en un ComboBox
        comboBoxOptions.Items.Clear()
        For Each kvp As KeyValuePair(Of String, Integer) In dictionary
            comboBoxOptions.Items.Add(kvp.Key)
        Next
    End Sub

    Public Function ObtenerIDSeleccionado(selectedName As String, dictionary As Dictionary(Of String, Integer)) As Integer
        If dictionary.ContainsKey(selectedName) Then
            Return dictionary(selectedName)
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function ObtenerNombreSeleccionado(selectedId As Integer, dictionary As Dictionary(Of Integer, String)) As String
        Dim optionName As String = ""
        If dictionary.TryGetValue(selectedId, optionName) Then
            Return optionName
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function ObtenerProyectoSistemasNombre(selectedName As String, dictionary As Dictionary(Of String, String)) As String
        If selectedName = "" Then
            Return ""
        End If
        Dim systemProjectName As String = ""
        If dictionary.TryGetValue(selectedName, systemProjectName) Then
            Return systemProjectName
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function ObtenerProyectoSistemasID(selectedName As String, dictionary As Dictionary(Of String, String)) As String
        If selectedName = "" Then
            Return ""
        End If
        Dim systemProjectId As String = ""
        If dictionary.TryGetValue(selectedName, systemProjectId) Then
            Return systemProjectId
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)

        If Empresa.Count = 0 Then
            errores.Add("El campo 'Empresa' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Departamento) Then
            errores.Add("El campo 'Departamento' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(AreaSistemas) Then
            errores.Add("El campo 'Area Sistemas' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Categorias) Then
            errores.Add("El campo 'Categorias' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Prioridad) Then
            errores.Add("El campo 'Prioridad' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Status) Then
            errores.Add("El campo 'Status' es obligatorio.")
        End If

        'If Not String.IsNullOrWhiteSpace(SystemProject) Then
        '    If Not reversedItemTitleToIdMap.ContainsKey(SystemProject) Then
        '        errores.Add("El campo 'Proyecto/Actividades de Sistemas' no es válido, vuelva a buscar su proyecto")
        '    End If
        'End If

        Return errores
    End Function

    Public Function ValidarCamposUsuarios() As List(Of String)
        Dim errores As New List(Of String)

        If ContactosSolicitantes.Count = 0 Then
            errores.Add("El campo 'Solicitante' es obligatorio.")
        End If

        If ContactosAsigandoA.Count = 0 Then
            errores.Add("El campo 'Asignado a' es obligatorio.")
        End If

        Return errores
    End Function
End Class