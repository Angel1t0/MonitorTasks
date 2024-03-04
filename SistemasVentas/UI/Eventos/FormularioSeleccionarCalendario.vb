Imports System.Runtime.InteropServices

Public Class FormularioSeleccionarCalendario
    Private _controlador As New EventoControlador()
    Public Property CalendarioID As String
    Public Property UsuarioID As String = Login.idUsuario

    Private Function CargarCalendarios() As List(Of String)
        Dim calendarios As List(Of List(Of String)) = _controlador.ObtenerCalendarios(UsuarioID)

        AgregarCalendariosACombo(calendarios)
        Return calendarios(0)
    End Function

    Private Sub guardarCalendarioID(listCalendariosID As List(Of String))
        Dim indexSeleccionado = ComboCalendario.SelectedIndex
        CalendarioID = listCalendariosID(indexSeleccionado)
    End Sub

    Private Sub SeleccionarCalendario()
        guardarCalendarioID(CargarCalendarios())
    End Sub

    Private Sub AgregarCalendariosACombo(calendarios As List(Of List(Of String)))
        Dim calendariosName As List(Of String) = calendarios(1)
        For Each calendario In calendariosName
            ComboCalendario.Items.Add(calendario)
        Next
    End Sub

    Private Sub BtnSeleccionarCalendario_Click_1(sender As Object, e As EventArgs) Handles BtnSeleccionarCalendario.Click
        SeleccionarCalendario()
        guardarCalendarioID(_controlador.ObtenerCalendarios(UsuarioID)(0))
        ' Mostrar formulario de gestión de eventos y cerrar este formulario
        Dim formularioPrincipal As New FormularioPrincipal()
        formularioPrincipal._CalendarioID = CalendarioID
        formularioPrincipal.Show()
        Me.Close()
    End Sub

    'Form'
    Public Sub New()
        InitializeComponent()
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
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

    Private Sub FormularioSeleccionarCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCalendarios()
        If ComboCalendario.Items.Count = 0 Then
            BtnSeleccionarCalendario.Enabled = False
            Return
        End If
        ComboCalendario.SelectedIndex = 0
    End Sub
End Class