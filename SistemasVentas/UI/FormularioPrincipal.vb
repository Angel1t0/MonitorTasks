Imports System.IO
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports Microsoft.Win32
Public Class FormularioPrincipal
    ' Aqui se declaran los campos que vamos a utilizar para el manejo de los botones del menu
    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form

    Public Property _CalendarioID As String
    Public Property _UsuarioID As String

    Public Sub New()
        InitializeComponent()
        leftBorderBtn = New Panel()
        leftBorderBtn.Size = New Size(7, 60)
        PanelMenu.Controls.Add(leftBorderBtn)

        'Form'
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
    End Sub

    Private Sub FormularioPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Minimizar el formulario apenas se inicie
        WindowState = FormWindowState.Minimized

        ' Iniciar el servicio de recurrencia de mensajes
        Dim gestionRecurrenciaMensajes As New GestionRecurrenciaMensajes(_CalendarioID)
        Dim podioService As New ServicioPodio
        gestionRecurrenciaMensajes.Iniciar()

        ' Obtener la ruta absoluta del icono del notifyIcon
        Dim appPath As String = Application.StartupPath
        Dim iconPath As String = Path.Combine(appPath, "archivos", "iconoNotify.ico")

        ' Configurar NotifyIcon
        notifyIcon.Icon = New Drawing.Icon(iconPath) ' Agregar el icono del notifyIcon
        notifyIcon.Text = "MWT"
        notifyIcon.Visible = True

        ' Configurar ContextMenuStrip
        Dim contextMenu As New ContextMenuStrip()
        contextMenu.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        contextMenu.Items.Add("Crear Actividad", Nothing, AddressOf CrearItem)
        contextMenu.Items.Add("Ver Dashboard", Nothing, AddressOf VerDashboard)
        contextMenu.Items.Add("Ver Notificaciones", Nothing, AddressOf VerNotificaciones)
        contextMenu.Items.Add("Salir", Nothing, AddressOf Salir)

        notifyIcon.ContextMenuStrip = contextMenu

        ' Manejador para restaurar la aplicación al hacer doble clic
        AddHandler notifyIcon.DoubleClick, AddressOf NotifyIcon1_DoubleClick
    End Sub

    ' Métodos para el NotifyIcon y las opciones del menú
    Private Sub CrearItem(sender As Object, e As EventArgs) Handles BtnEventos.Click
        RestoreFromTray()
        ActivateButton(BtnEventos, Color.FromArgb(34, 209, 98))
        OpenChildForm(New GestionEventos With {.CalendarioID = _CalendarioID, .UsuarioID = _UsuarioID})
    End Sub

    Private Sub VerDashboard(sender As Object, e As EventArgs) Handles BtnDash.Click
        RestoreFromTray()
        ActivateButton(BtnDash, Color.FromArgb(231, 197, 90))
        OpenChildForm(New GestionDashboard)
    End Sub

    Private Sub VerNotificaciones(sender As Object, e As EventArgs) Handles BtnNotificaciones.Click
        RestoreFromTray()
        ActivateButton(BtnNotificaciones, Color.FromArgb(193, 110, 153))
        OpenChildForm(New GestionMensajes(_CalendarioID))
    End Sub

    Private Sub Salir(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Application.Exit()
    End Sub

    ' Restaurar la aplicación desde el tray
    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles notifyIcon.DoubleClick
        RestoreFromTray()
    End Sub

    ' Método para restaurar el formulario desde el área de notificaciones
    Private Sub RestoreFromTray()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1430, 800)
        Me.ShowInTaskbar = True
        notifyIcon.Visible = False
    End Sub

    ' Evento de minimización del formulario
    Private Sub FormularioPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            notifyIcon.Visible = True
        End If
    End Sub

    ' Este metodo se encarga de resaltar el boton que se ha seleccionado
    Private Sub ActivateButton(senderBtn As Object, customColor As Color)
        If senderBtn IsNot Nothing Then
            DisableButton()
            ' Boton
            currentBtn = CType(senderBtn, IconButton)
            currentBtn.BackColor = Color.FromArgb(28, 25, 34)
            currentBtn.ForeColor = customColor
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            currentBtn.IconColor = customColor
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
            currentBtn.ImageAlign = ContentAlignment.MiddleRight
            ' Borde izquierdo del boton
            leftBorderBtn.BackColor = customColor
            leftBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            leftBorderBtn.Visible = True
            leftBorderBtn.BringToFront()
            ' Icono de la ventana
            IconFormActual.IconChar = currentBtn.IconChar
            IconFormActual.IconColor = customColor
            LbTituloForm.Text = currentBtn.Text
        End If
    End Sub

    ' Este metodo se encarga de desactivar el boton que se ha seleccionado
    Private Sub DisableButton()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.FromArgb(35, 35, 48)
            currentBtn.ForeColor = Color.Gainsboro
            currentBtn.TextAlign = ContentAlignment.MiddleLeft
            currentBtn.IconColor = Color.Gainsboro
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft
        End If
    End Sub

    ' Este metodo se encarga de abrir un formulario en el panel principal
    Private Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelEscritorio.Controls.Add(childForm)
        PanelEscritorio.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        LbTituloForm.Text = currentBtn.Text
    End Sub

    ' Events
    Private Sub BtnDash_Click(sender As Object, e As EventArgs) Handles BtnDash.Click
        ActivateButton(sender, Color.FromArgb(231, 197, 90))
        OpenChildForm(New GestionDashboard)
    End Sub
    Private Sub BtnUsuarios_Click(sender As Object, e As EventArgs) Handles BtnUsuarios.Click
        ActivateButton(sender, Color.FromArgb(118, 193, 201))
        OpenChildForm(New FormularioGestionUsuarios)
    End Sub
    Private Sub BtnEventos_Click(sender As Object, e As EventArgs) Handles BtnEventos.Click
        ActivateButton(sender, Color.FromArgb(34, 209, 98))
        OpenChildForm(New GestionEventos With {.CalendarioID = _CalendarioID, .UsuarioID = _UsuarioID})
    End Sub
    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click
        ActivateButton(sender, Color.FromArgb(211, 130, 101))
        OpenChildForm(New GestionImportar With {.CalendarioID = _CalendarioID, .UsuarioID = _UsuarioID})
    End Sub
    Private Sub BtnNotificaciones_Click(sender As Object, e As EventArgs) Handles BtnNotificaciones.Click
        ActivateButton(sender, Color.FromArgb(193, 110, 153))
        OpenChildForm(New GestionMensajes(_CalendarioID))
    End Sub
    Private Sub BtnArranque_Click(sender As Object, e As EventArgs) Handles BtnArranque.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        If VerificarArranque() Then
            ' La aplicación está en el inicio de Windows, ofrecer opción para removerla
            Dim result As DialogResult = MessageBox.Show("La aplicación está configurada para iniciarse con Windows. ¿Desea removerla del arranque?", "Remover del inicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                RemoverArranque()
            End If
        Else
            ' La aplicación no está en el inicio de Windows, ofrecer opción para agregarla
            Dim result As DialogResult = MessageBox.Show("La aplicación no está configurada para iniciarse con Windows. ¿Desea agregarla al arranque?", "Agregar al inicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                AgregarArranque()
            End If

        End If
    End Sub
    Private Sub BtnCerrarSesion_Click(sender As Object, e As EventArgs) Handles BtnCerrarSesion.Click
        ActivateButton(sender, Color.FromArgb(157, 173, 173))
        ' Cerrar Sesión
        Dim credentials As String = ""
        Dim filePath As String = Path.Combine(Application.StartupPath, "credenciales_user.txt")
        File.WriteAllText(filePath, credentials)
        Application.Restart()
    End Sub

    Private Sub LbLogo_Click(sender As Object, e As EventArgs) Handles LbLogo.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        Reset()
    End Sub

    ' Al presionar el logo cierra el formulario actual
    Private Sub Reset()
        DisableButton()
        leftBorderBtn.Visible = False
        IconFormActual.IconChar = IconChar.Home
        IconFormActual.IconColor = Color.Coral
        LbTituloForm.Text = "Inicio"
    End Sub

    ' Añadir registro para el inicio de windows
    Public Sub AgregarArranque()
        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue("MonitorTasks", Application.ExecutablePath)
            MessageBox.Show("La aplicación se ha configurado para iniciarse con Windows.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar la aplicación al inicio de Windows: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub RemoverArranque()
        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.DeleteValue("MonitorTasks", False)
            MessageBox.Show("La aplicación ya no se iniciará con Windows.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al intentar remover la aplicación del inicio de Windows: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function VerificarArranque() As Boolean
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Dim value As Object = key.GetValue("MonitorTasks")
        If value IsNot Nothing Then
            Return True
        End If
        Return False
    End Function

    ' Mover el formulario
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTitulo.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    'Close-Maximize-Minimize'
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Application.Exit()
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles BtnMaximizar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles BtnMinimizar.Click
        WindowState = FormWindowState.Minimized
    End Sub
    'Remove transparent border in maximized state'
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            FormBorderStyle = FormBorderStyle.None
        Else
            FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub
End Class