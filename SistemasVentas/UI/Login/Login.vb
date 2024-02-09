Imports System.Net.Mail
Imports System.Net
Public Class Login

    ' --- MANEJADORES DE EVENTOS UI ---
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarPanelLogin(True)
        CentrarPanel(panelLogin)
        'MostrarUsuarioRegistrado()

        If dgvMostrarUsuario.Rows.Count = 0 Then
            Servidor.ShowDialog()
            Dispose()
        End If
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
        labelPass.Text = pass 'PRUEBA
        'CrearCorreo("decorreo29@gmail.com", "DbNusX6WmM", txtHTML.Text, "Recuperación de Contraseña", "angel01.am73@gmail.com", pass)
    End Sub

    Private Sub MostrarUsuarioRegistrado()
        Dim usuarioData As New UsuarioData()
        dgvMostrarUsuario.DataSource = usuarioData.mostrarUsuariosRegistrados()
    End Sub

    ' --- UTILIDADES ---
    Private Sub IniciarSesion()
        Hide()
        GestionVentas.ShowDialog()
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

    'FALTA DE CONFIGURAR'
    'Private Sub CrearCorreo(emisor As String, pass As String, mensaje As String, asunto As String, destinatario As String, ruta As String)
    '    txtHTML.Text = txtHTML.Text.Replace("@Password", ruta)
    '    Try
    '        Dim correo As New MailMessage()
    '        Dim servidor As New SmtpClient()

    '        correo.To.Clear()
    '        correo.Subject = asunto
    '        correo.To.Add(destinatario)
    '        correo.Body = mensaje
    '        correo.IsBodyHtml = True
    '        correo.From = New MailAddress(emisor)

    '        'CONFIGURAR SERVIDOR
    '        servidor.Credentials = New NetworkCredential(emisor, pass)
    '        servidor.Host = "smtp.gmail.com"
    '        servidor.Port = 587
    '        servidor.EnableSsl = True
    '        servidor.Send(correo)

    '        MessageBox.Show("Contraseña enviada, revisa tu correo", "Recuperación", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Catch ex As System.Net.Mail.SmtpException
    '        MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
    '    End Try
    'End Sub

End Class