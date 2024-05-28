Imports Microsoft.Reporting.WinForms
Imports Windows.Phone.Notification.Management

Public Class GestionReportes
    Private _controlador As EventoControlador
    Private _tipoReporte As TipoReporte
    Private _IsPodio As Boolean
    Private limite As Integer = 0
    Private intervaloInicio As DateTime
    Private intervaloFin As DateTime
    Private emailUsers As New List(Of String)

    Public Enum TipoReporte
        TareasPendientes
        TareasFinalizadas
        TareasCreadas
        TareasPorUsuario
    End Enum
    Private Sub GestionReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
        Select Case _tipoReporte
            Case TipoReporte.TareasPendientes
                LlenarReporteTareasPendientes()
            Case TipoReporte.TareasFinalizadas
                LlenarReporteTareasFinalizadas()
            Case TipoReporte.TareasCreadas
                LlenarReporteTareasCreadas()
            Case TipoReporte.TareasPorUsuario
                ObtenerCorreo()
        End Select
        Me.ReportViewer1.RefreshReport()
    End Sub


    Public Sub New(tipoReporte As TipoReporte, isPodio As Boolean)
        _controlador = New EventoControlador()
        _tipoReporte = tipoReporte
        _IsPodio = isPodio
    End Sub

    Private Sub LlenarReporteTareasPendientes()
        Try
            If _IsPodio Then
                AbrirPanelFiltros()
            Else
                Dim dt As DataTable = _controlador.ObtenerTareasPendientes()
                Dim reportDataSource As New ReportDataSource("DataSetPendientes", dt)

                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
                ReportViewer1.LocalReport.ReportPath = "..\..\UI\Reportes\TareasPendientes.rdlc"
                ReportViewer1.RefreshReport()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LlenarReporteTareasFinalizadas()
        Try
            Dim dt As DataTable = _controlador.ObtenerTareasFinalizadas()
            Dim reportDataSource As New ReportDataSource("DataSetFinalizados", dt)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
            ReportViewer1.LocalReport.ReportPath = "..\..\UI\Reportes\TareasFinalizadas.rdlc"
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LlenarReporteTareasCreadas()
        Try
            Dim dt As DataTable = _controlador.ObtenerTareasCreadas()
            Dim reportDataSource As New ReportDataSource("DataSetCreados", dt)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
            ReportViewer1.LocalReport.ReportPath = "..\..\UI\Reportes\TareasCreadas.rdlc"
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LlenarReporteTareasPorUsuario(correo)
        Try
            Dim dt As DataTable = _controlador.ObtenerTareasPorUsuario(correo)
            Dim reportDataSource As New ReportDataSource("DataSetPorUsuario", dt)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
            ReportViewer1.LocalReport.ReportPath = "..\..\UI\Reportes\TareasPorUsuario.rdlc"
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCorreo()
        emailUsers = _controlador.ObtenerCorreos()

        panelCorreo.Visible = True
        panelCorreo.BringToFront()
        panelCorreo.Location = New Point((Me.Width - panelCorreo.Width) / 2, (Me.Height - panelCorreo.Height) / 2)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        panelCorreo.Visible = False
        panelCorreo.SendToBack()

        Dim correo As String = txtEmail.TextBox1.Text.Trim()
        LlenarReporteTareasPorUsuario(correo)
    End Sub

    Private Sub cbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuarios.SelectedIndexChanged
        Try
            If cbUsuarios.SelectedItem IsNot Nothing Then
                Dim selectedUser As String = cbUsuarios.SelectedItem.ToString()
                Dim text As String = txtEmail.TextBox1.Text
                Dim words As String() = text.Split(" "c)
                words(words.Length - 1) = selectedUser
                text = String.Join(" ", words)
                txtEmail.TextBox1.Text = text
                txtEmail.TextBox1.SelectionStart = text.Length
                cbUsuarios.DroppedDown = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmail__TextChanged(sender As Object, e As EventArgs) Handles txtEmail._TextChanged
        Dim text As String = txtEmail.TextBox1.Text
        Dim lastWord As String = text.Split(" "c).LastOrDefault()

        If Not String.IsNullOrEmpty(lastWord) Then
            Dim searchName As String = lastWord.ToLower()
            Dim matchingUsers = emailUsers.Where(Function(name) name.ToLower().Contains(searchName)).ToList()

            If matchingUsers.Any() Then
                cbUsuarios.Items.Clear()
                cbUsuarios.Items.AddRange(matchingUsers.ToArray())
                cbUsuarios.DroppedDown = True
            Else
                cbUsuarios.DroppedDown = False
            End If
        Else
            cbUsuarios.DroppedDown = False
        End If
    End Sub


    Private Sub btnCancelarBuscarCorreo_Click(sender As Object, e As EventArgs) Handles btnCancelarBuscarCorreo.Click
        Me.Close()
    End Sub

    Private Sub ObtenerTareasPendientesPodio()
        Try
            Dim dt As DataTable = _controlador.ObtenerTareasPendientesPodio(limite, intervaloInicio, intervaloFin)
            Dim reportDataSource As New ReportDataSource("DataSetPendientes", dt)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
            ReportViewer1.LocalReport.ReportPath = "..\..\UI\Reportes\TareasPendientes.rdlc"
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AbrirPanelFiltros()
        panelFiltros.Visible = True
        panelFiltros.BringToFront()
        'Centrar panel
        panelFiltros.Location = New Point((Me.Width - panelFiltros.Width) / 2, (Me.Height - panelFiltros.Height) / 2)
    End Sub

    Private Sub btnVolverDash_Click(sender As Object, e As EventArgs) Handles btnVolverDash.Click
        ' Terminar el formulario actual
        Me.Close()
    End Sub

    Private Sub btnListoFiltros_Click(sender As Object, e As EventArgs) Handles btnListoFiltros.Click
        panelFiltros.Visible = False
        panelFiltros.SendToBack()
        limite = Integer.Parse(txtLimite.TextBox1.Text)
        If checkIntervalo.Checked Then
            intervaloInicio = dateLimiteInicio.Value
            intervaloFin = dateLimiteFinal.Value
        End If

        Select Case _tipoReporte
            Case TipoReporte.TareasPendientes
                ObtenerTareasPendientesPodio()
            Case TipoReporte.TareasFinalizadas
                'LlenarReporteTareasFinalizadas()
            Case TipoReporte.TareasCreadas
                'LlenarReporteTareasCreadas()
            Case TipoReporte.TareasPorUsuario
                'LlenarReporteTareasPorUsuario()
        End Select
    End Sub
End Class