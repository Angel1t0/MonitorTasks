Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
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
        Dim gestionRecurrenciaMensajes As New GestionRecurrenciaMensajes(_CalendarioID)
        gestionRecurrenciaMensajes.Iniciar()
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
    End Sub
    Private Sub BtnUsuarios_Click(sender As Object, e As EventArgs) Handles BtnUsuarios.Click
        ActivateButton(sender, Color.FromArgb(118, 193, 201))
        OpenChildForm(New FormularioGestionUsuarios)
    End Sub
    Private Sub BtnTareas_Click(sender As Object, e As EventArgs) Handles BtnTareas.Click
        ActivateButton(sender, Color.FromArgb(223, 73, 110))
    End Sub
    Private Sub BtnEventos_Click(sender As Object, e As EventArgs) Handles BtnEventos.Click
        ActivateButton(sender, Color.FromArgb(34, 209, 98))
        OpenChildForm(New GestionEventos With {.CalendarioID = _CalendarioID, .UsuarioID = _UsuarioID})
    End Sub
    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click
        ActivateButton(sender, Color.FromArgb(211, 130, 101))
    End Sub
    Private Sub BtnNotificaciones_Click(sender As Object, e As EventArgs) Handles BtnNotificaciones.Click
        ActivateButton(sender, Color.FromArgb(193, 110, 153))
        OpenChildForm(New GestionMensajes(_CalendarioID))
    End Sub
    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click
        ActivateButton(sender, Color.FromArgb(157, 173, 173))
    End Sub

    Private Sub LbLogo_Click(sender As Object, e As EventArgs) Handles LbLogo.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        Reset()
    End Sub

    Private Sub Reset()
        DisableButton()
        leftBorderBtn.Visible = False
        IconFormActual.IconChar = IconChar.Home
        IconFormActual.IconColor = Color.Coral
        LbTituloForm.Text = "Inicio"
    End Sub

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