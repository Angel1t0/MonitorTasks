Imports System.Runtime.InteropServices

Public Class Login
    Public Property idUsuario As String

    Public Sub New()
        InitializeComponent()
        'Form'
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
    End Sub

    ' --- MANEJADORES DE EVENTOS UI ---
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarPanelLogin(True)
        CentrarPanel(panelLogin)
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        CambiarVisibilidad(True)
    End Sub

    Private Sub btnNoVer_Click(sender As Object, e As EventArgs) Handles btnNoVer.Click
        CambiarVisibilidad(False)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ValidarLogin()
    End Sub

    Private Sub lbOlvidar_Click(sender As Object, e As EventArgs) Handles lbOlvidar.Click
        CentrarPanel(panelRecuperar)
        MostrarPanelLogin(False)
    End Sub

    Private Sub lbVolver_Click(sender As Object, e As EventArgs) Handles lbVolver.Click
        MostrarPanelLogin(True)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        RecuperarPass()
    End Sub

    ' --- OPERACIONES SQL ---
    Private Sub ValidarLogin()
        If Not ValidarEntradasLogin(txtLogin.Text, txtPass.Text) Then
            Return
        End If

        Dim usuarioData As New UsuarioData()
        dgvRevisar.DataSource = usuarioData.ValidarLogin(txtLogin.Text, txtPass.Text)

        If Not dgvRevisar.Rows.Count > 0 Then
            MessageBox.Show("Usuario o contraseña incorrecta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        IniciarSesion()
    End Sub

    Private Sub RecuperarPass()
        If Not ValidarEntradasLogin(txtRecuperacion.Text, "Pass") Then
            Return
        End If

        Dim usuarioData As New UsuarioData()
        Dim pass As String = usuarioData.buscarCorreo(txtRecuperacion.Text)
        If pass = Nothing Then
            MessageBox.Show("Correo no registrado", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'CrearCorreo("decorreo29@gmail.com", "DbNusX6WmM", txtHTML.Text, "Recuperación de Contraseña", "decorreo29@gmail.com", pass)
    End Sub

    ' --- UTILIDADES ---
    Private Sub IniciarSesion()
        idUsuario = dgvRevisar.SelectedCells.Item(1).Value
        ' Abrir formulario de selección de calendario y cerrar este formulario
        Dim seleccionarCalendario As New FormularioSeleccionarCalendario()
        seleccionarCalendario.UsuarioID = idUsuario
        seleccionarCalendario.Show()
        Me.Hide()
    End Sub

    Private Sub CentrarPanel(panel As Panel)
        panel.Location = New Point((Width - panel.Width) / 2, (Height - panel.Height) / 2)
    End Sub

    Private Sub MostrarPanelLogin(IsVisible As Boolean)
        panelLogin.Visible = IsVisible
        panelRecuperar.Visible = Not IsVisible
    End Sub

    Private Sub CambiarVisibilidad(isVisible As Boolean)
        txtPass.PasswordChar = If(isVisible, "", "*")
        btnNoVer.Visible = isVisible
        btnVer.Visible = Not isVisible
    End Sub

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