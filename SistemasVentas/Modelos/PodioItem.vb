Public Class PodioItem
    Public Property PodioItemID As Integer  ' ID único para la base de datos local
    Public Property EventID As String  ' Vincula con la tabla de eventos
    Public Property PodioAppID As Integer = 1350510  ' ID de la aplicación en Podio
    Public Property PodioAppItemID As Long  ' ID del item en Podio
    Public Property Title As String  ' Título del elemento
    Public Property Description As String  ' Descripción del elemento
    Public Property Company As String  ' Empresa solicitante
    Public Property Department As String  ' Departamento solicitante
    Public Property DepartmentPriority As Integer  ' Orden de prioridad del departamento
    Public Property SystemArea As String  ' Área de sistemas
    Public Property Categories As String  ' Categorías
    Public Property RequestorContacts As New List(Of Integer) ' ID de contacto del solicitante
    Public Property AuthorizerContacts As New List(Of Integer) ' ID de contacto del que autoriza
    Public Property AssignedToContacts As New List(Of Integer) ' ID de contacto del asignado
    Public Property SystemPriority As Integer  ' Orden de prioridad de sistemas
    Public Property Priority As String  ' Prioridad (texto)
    Public Property StartDate As DateTime  ' Fecha de inicio
    Public Property EndDate As DateTime  ' Fecha de entrega
    Public Property WorkPlan As String  ' Plan de trabajo o acción
    Public Property Status As String  ' Estatus
    Public Property Progress As Integer  ' Progreso (en porcentaje)
    Public Property SystemProject As String  ' Proyecto/Actividades de Sistemas
    Public Property GeneralProject As String  ' Proyecto general
    Public Property HoursAccumulated As Integer  ' Horas acumuladas
    Public Property ExtraHours As Integer  ' Horas extras
    Public Property ScrumDaily As Integer  ' Referencia a SCRUM Daily
    Public Property CreatedOn As DateTime  ' Fecha de creación
    Public Property LastModified As DateTime  ' Última modificación

    ' Crear un diccionario para almacenar las relaciones entre los nombres de las categorias y sus ID
    Public companyOptions As New Dictionary(Of String, Integer)()
    Public departmentOptions As New Dictionary(Of String, Integer)()
    Public systemAreaOptions As New Dictionary(Of String, Integer)()
    Public categoryOptions As New Dictionary(Of String, Integer)()
    Public priorityOptions As New Dictionary(Of String, Integer)()
    Public statusOptions As New Dictionary(Of String, Integer)()

    Public itemTitleToIdMap As New Dictionary(Of String, String)() ' Diccionario para mapear títulos a IDs de los proyectos de sistemas
    Public reversedItemTitleToIdMap As New Dictionary(Of String, String)()

    Public reversedCompanyOptions As New Dictionary(Of Integer, String)()
    Public reversedDepartmentOptions As New Dictionary(Of Integer, String)()
    Public reversedSystemAreaOptions As New Dictionary(Of Integer, String)()
    Public reversedCategoryOptions As New Dictionary(Of Integer, String)()
    Public reversedPriorityOptions As New Dictionary(Of Integer, String)()
    Public reversedStatusOptions As New Dictionary(Of Integer, String)()

    Public authorizerContactsDict As New Dictionary(Of String, Integer)() ' Diccionario para mapear correos de contactos a IDs
    Public requestorContactsDict As New Dictionary(Of String, Integer)() ' Diccionario para mapear correos de contactos a IDs

    Public Function ConvertTimeToSeconds(time As String) As Integer
        Dim timeParts As String() = time.Split(":")
        Dim hours As Integer = Integer.Parse(timeParts(0))
        Dim minutes As Integer = Integer.Parse(timeParts(1))
        Dim seconds As Integer = Integer.Parse(timeParts(2))
        Return hours * 3600 + minutes * 60 + seconds
    End Function

    Public Function ConvertSecondsToTime(seconds As Integer) As String
        Dim hours As Integer = seconds \ 3600
        Dim minutes As Integer = (seconds Mod 3600) \ 60
        Dim remainingSeconds As Integer = seconds Mod 60
        Return hours.ToString("00") & ":" & minutes.ToString("00") & ":" & remainingSeconds.ToString("00")
    End Function

    Public Sub InitializeOptions()
        ' Inicializar las opciones de las categorías
        companyOptions.Add("Todas", 15)
        companyOptions.Add("Incorporated Express SA de CV", 16)
        companyOptions.Add("FUNERA", 17)
        companyOptions.Add("OrderExpress Inc", 3)
        companyOptions.Add("OEPM", 11)
        companyOptions.Add("OECC", 14)
        companyOptions.Add("OE Financial Inc", 9)
        companyOptions.Add("LOFT SA de CV", 10)
        companyOptions.Add("JP Casa de Cambio Inc", 2)
        companyOptions.Add("J&P Financial Inc", 13)
        companyOptions.Add("JP SofiExpress", 12)
        companyOptions.Add("REALIZA", 18)

        departmentOptions.Add("Administracion", 1)
        departmentOptions.Add("Agencias", 6)
        departmentOptions.Add("Agentes", 15)
        departmentOptions.Add("Callcenter", 2)
        departmentOptions.Add("Cumplimiento MX", 18)
        departmentOptions.Add("Cumplimiento USA", 4)
        departmentOptions.Add("Cobranza", 3)
        departmentOptions.Add("Contabilidad", 11)
        departmentOptions.Add("Control Interno", 14)
        departmentOptions.Add("Correponsales o Proveedores", 20)
        departmentOptions.Add("Cheques", 10)
        departmentOptions.Add("DIRECCION", 21)
        departmentOptions.Add("Marketing", 7)
        departmentOptions.Add("Monitoreo", 17)
        departmentOptions.Add("Operaciones", 12)
        departmentOptions.Add("Publicidad", 16)
        departmentOptions.Add("Recursos Humanos", 13)
        departmentOptions.Add("Sistemas", 5)
        departmentOptions.Add("Supervision", 9)
        departmentOptions.Add("Tesoreria", 8)
        departmentOptions.Add("Ventas (Aociadas/Oficinas)", 19)

        systemAreaOptions.Add("Soporte", 2)
        systemAreaOptions.Add("Desarrollo", 1)
        systemAreaOptions.Add("Infraestructura", 3)
        systemAreaOptions.Add("Administracion/Direccion", 5)

        categoryOptions.Add("[ADMIN] Acuerdos de Confidencialidad Con Terceros", 72)
        categoryOptions.Add("[ADMIN] Auditorias", 56)
        categoryOptions.Add("[ADMIN] Manuales", 34)
        categoryOptions.Add("[ADMIN] Plan  de Contingencia", 25)
        categoryOptions.Add("[ADMIN] Podio", 27)
        categoryOptions.Add("[DESARROLLO] Actualizacion de Certificados", 59)
        categoryOptions.Add("[DESARROLLO] Correccion de Error", 65)
        categoryOptions.Add("[DESARROLLO] Desarrollo General", 1)
        categoryOptions.Add("[DESARROLLO] Entrega (Spring de Scrum - 15 Dias)", 13)
        categoryOptions.Add("[DESARROLLO] Error de Corresponsal", 5)
        categoryOptions.Add("[DESARROLLO] Integracion de Corresponsal", 28)
        categoryOptions.Add("[DESARROLLO] Importación Contable Mensual", 42)
        categoryOptions.Add("[DESARROLLO] Mantenimiento", 7)
        categoryOptions.Add("[DESARROLLO] Mejora en Sistemas/Modulo", 66)
        categoryOptions.Add("[DESARROLLO] Publicacion", 9)
        categoryOptions.Add("[DESARROLLO] Soporte en Produccion", 78)
        categoryOptions.Add("[SOPORTE] Actualizacion De Imagenes En Pantallas", 30)
        categoryOptions.Add("[SOPORTE] 1Password - Alta", 75)
        categoryOptions.Add("[SOPORTE] 1Password - Baja", 76)
        categoryOptions.Add("[SOPORTE] 1Password - Modificacion", 77)
        categoryOptions.Add("[SOPORTE] Alta de Corresponsal/Agente", 70)
        categoryOptions.Add("[SOPORTE] Acceso a Red Inalambrica", 60)
        categoryOptions.Add("[SOPORTE] Alta de Servicio o Producto", 6)
        categoryOptions.Add("[SOPORTE] Cambio de Contrasena", 35)
        categoryOptions.Add("[SOPORTE] Camaras", 20)
        categoryOptions.Add("[SOPORTE] Capacitaciones", 8)
        categoryOptions.Add("[SOPORTE] Correo Electrónico - Alta", 51)
        categoryOptions.Add("[SOPORTE] Correo Electrónico - Baja", 52)
        categoryOptions.Add("[SOPORTE] Correo Electrónico - Reasignacion", 53)
        categoryOptions.Add("[SOPORTE] Correo Electrónico - Suspension", 54)
        categoryOptions.Add("[SOPORTE] Equipo de Computo", 69)
        categoryOptions.Add("[SOPORTE] Error de Usuario", 4)
        categoryOptions.Add("[SOPORTE] Extensión Telefónica", 37)
        categoryOptions.Add("[SOPORTE] Google Suite", 26)
        categoryOptions.Add("[SOPORTE] Instalación y/o Configuración de Software", 44)
        categoryOptions.Add("[SOPORTE] Impresoras y/o Scanners", 67)
        categoryOptions.Add("[SOPORTE] Mantenimiento de Equipo", 68)
        categoryOptions.Add("[SOPORTE] Produccion", 21)
        categoryOptions.Add("[SOPORTE] Solicitud de Equipo", 62)
        categoryOptions.Add("[SOPORTE] Soporte General", 2)
        categoryOptions.Add("[SOPORTE] TeamViewer", 74)
        categoryOptions.Add("[SOPORTE] Usuarios - Alta", 12)
        categoryOptions.Add("[SOPORTE] Usuarios - Baja", 48)
        categoryOptions.Add("[SOPORTE] Usuario - Baja", 3)
        categoryOptions.Add("[SOPORTE] Usuarios - Modificación", 49)
        categoryOptions.Add("[INFRAESTRUCTURA] Acceso a Red WiFi", 61)
        categoryOptions.Add("[INFRAESTRUCTURA] Comunicaciones", 64)
        categoryOptions.Add("[INFRAESTRUCTURA] Conmutador", 63)
        categoryOptions.Add("[INFRAESTRUCTURA] Mantenimiento de Servidores y/o Redes", 10)
        categoryOptions.Add("[INFRAESTRUCTURA] Monitoreo", 43)
        categoryOptions.Add("[INFRAESTRUCTURA] Redes", 14)
        categoryOptions.Add("[INFRAESTRUCTURA] Redes - Monitoreo y Analisis de Logs", 16)
        categoryOptions.Add("[INFRAESTRUCTURA] Servidores", 41)
        categoryOptions.Add("[INFRAESTRUCTURA] Redes - VPN", 47)
        categoryOptions.Add("[INFRAESTRUCTURA] Reporte", 23)
        categoryOptions.Add("[INFRAESTRUCTURA] Solicitud de Equipo", 11)
        categoryOptions.Add("[INFRAESTRUCTURA] Servidores - Almacenamiento SAN", 50)
        categoryOptions.Add("[INFRAESTRUCTURA] Servidores - Based de Datos", 31)
        categoryOptions.Add("[INFRAESTRUCTURA] Servidores - Migracion de Sistema Operativo", 45)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad", 58)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Actividad Sospechosa", 39)
        categoryOptions.Add("[INFRAESTRUCTURA] Servidores - Backup y/o Replica", 29)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Actualización de Parches", 36)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Antivirus", 57)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Acceso", 18)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Antivirus", 17)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Firewalls", 38)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Incidente de Redes", 19)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Monitoreo", 24)
        categoryOptions.Add("[INFRAESTRUCTURA] Seguridad - Análisis de Vulnerabilidades", 40)
        categoryOptions.Add("[INFRAESTRUCTURA] SQL - Store Procedure", 46)
        categoryOptions.Add("[SEGURIDAD] Auditoria Interna", 73)

        priorityOptions.Add("Alta", 1)
        priorityOptions.Add("Normal", 2)
        priorityOptions.Add("Baja", 3)
        priorityOptions.Add("De Acuerdo a Fecha de Entrega", 4)

        statusOptions.Add("No comenzada / Pendiente", 5)
        statusOptions.Add("En Analisis De Requerimientos", 9)
        statusOptions.Add("En Desarrollo", 3)
        statusOptions.Add("En Pruebas", 10)
        statusOptions.Add("En Monitoreo", 14)
        statusOptions.Add("Finalizada", 4)
        statusOptions.Add("Aplazada", 1)
        statusOptions.Add("A la espera de otra persona", 7)
        statusOptions.Add("Pendiente Confirmar Actividad", 16)
        statusOptions.Add("Pendiente de Publicar", 11)
        statusOptions.Add("Permanente", 6)
        statusOptions.Add("Publicado", 12)
        statusOptions.Add("Suspendida", 8)
        statusOptions.Add("Trabajando", 15)

        reversedOptions()
    End Sub

    Public Sub reversedOptions()
        For Each kvp As KeyValuePair(Of String, Integer) In companyOptions
            reversedCompanyOptions.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In departmentOptions
            reversedDepartmentOptions.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In systemAreaOptions
            reversedSystemAreaOptions.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In categoryOptions
            reversedCategoryOptions.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In priorityOptions
            reversedPriorityOptions.Add(kvp.Value, kvp.Key)
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In statusOptions
            reversedStatusOptions.Add(kvp.Value, kvp.Key)
        Next
    End Sub

    Public Sub LoadOptionsIntoComboBox(comboBoxOptions As ComboBox, dictionary As Dictionary(Of String, Integer))
        comboBoxOptions.Items.Clear()
        For Each kvp As KeyValuePair(Of String, Integer) In dictionary
            comboBoxOptions.Items.Add(kvp.Key)
        Next
    End Sub

    Public Function GetSelectedOptionId(selectedCompanyName As String, dictionary As Dictionary(Of String, Integer)) As Integer
        If dictionary.ContainsKey(selectedCompanyName) Then
            Return dictionary(selectedCompanyName)
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function GetSelectedOptionName(selectedCompanyId As Integer, dictionary As Dictionary(Of Integer, String)) As String
        Dim optionName As String = ""
        If dictionary.TryGetValue(selectedCompanyId, optionName) Then
            Return optionName
        Else
            Throw New Exception("La opción no está en el diccionario.")
        End If
    End Function

    Public Function GetSystemProjectName(selectedName As String, dictionary As Dictionary(Of String, String)) As String
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

    Public Function ValidarCampos() As List(Of String)
        Dim errores As New List(Of String)

        If String.IsNullOrWhiteSpace(Company) Then
            errores.Add("El campo 'Empresa' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Department) Then
            errores.Add("El campo 'Departamento' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(SystemArea) Then
            errores.Add("El campo 'Area Sistemas' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Categories) Then
            errores.Add("El campo 'Categorias' es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(Priority) Then
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

        If RequestorContacts.Count = 0 Then
            errores.Add("El campo 'Solicitante' es obligatorio.")
        End If

        If AssignedToContacts.Count = 0 Then
            errores.Add("El campo 'Asignado a' es obligatorio.")
        End If

        Return errores
    End Function
End Class
