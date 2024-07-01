Imports System.Windows.Forms.DataVisualization.Charting

Public Class GestionDashboard
    Private currentChildForm As Form
    Private _controlador As ControladorEvento = New ControladorEvento()
    Private totalItems As Integer
    Public Enum TipoReporte
        TareasPendientes
        TareasFinalizadas
        TareasCreadas
        TareasPorUsuario
    End Enum

    Private Sub GestionDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGraficoCircular()
        LlenarGraficoBarras()

        Dim dt As DataTable = _controlador.ObtenerTareasCreadas()
        totalItems = dt.Rows.Count
        Label2.Text = totalItems.ToString()
    End Sub

    ' Método para abrir un formulario hijo en el panel principal
    Private Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        panelDash.Controls.Add(childForm)
        panelDash.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub btnPendienteBD_Click(sender As Object, e As EventArgs) Handles btnPendienteBD.Click
        OpenChildForm(New GestionReportes(TipoReporte.TareasPendientes, False))
    End Sub

    Private Sub btnPendientePodio_Click(sender As Object, e As EventArgs) Handles btnPendientePodio.Click
        OpenChildForm(New GestionReportes(TipoReporte.TareasPendientes, True))
    End Sub

    Private Sub btnCreadaBD_Click(sender As Object, e As EventArgs) Handles btnCreadaBD.Click
        OpenChildForm(New GestionReportes(TipoReporte.TareasCreadas, False))
    End Sub

    Private Sub btnFinalizadaBD_Click(sender As Object, e As EventArgs) Handles btnFinalizadaBD.Click
        OpenChildForm(New GestionReportes(TipoReporte.TareasFinalizadas, False))
    End Sub

    Private Sub btnUsuarioBD_Click(sender As Object, e As EventArgs) Handles btnUsuarioBD.Click
        OpenChildForm(New GestionReportes(TipoReporte.TareasPorUsuario, False))
    End Sub

    ' Método para llenar el gráfico circular con la cantidad de items por estado
    Private Sub LlenarGraficoCircular()
        Try
            Dim dt As DataTable = _controlador.ObtenerCantidadItemsPorEstado()

            ' Limpiar el gráfico antes de llenarlo
            chartItemPorStatus.Series.Clear()

            ' Añadir una serie al gráfico
            Dim series As New Series("Estados")
            series.ChartType = SeriesChartType.Pie
            series.Font = New Font("Century Gothic", 10)
            series.LabelForeColor = Color.White
            chartItemPorStatus.Series.Add(series)

            ' Llenar la serie con datos
            For Each row As DataRow In dt.Rows
                Dim point As New DataPoint()
                point.SetValueXY(row("Status").ToString(), Convert.ToInt32(row("Cantidad")))
                point.Label = row("Cantidad").ToString()
                point.LegendText = row("Status").ToString()
                point.Font = New Font("Century Gothic", 10)
                point.LabelForeColor = Color.White
                series.Points.Add(point)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LlenarGraficoBarras()
        Try
            Dim dt As DataTable = _controlador.ObtenerCantidadItemsPorSystemArea()

            ' Limpiar el gráfico antes de llenarlo
            chartItemsPorArea.Series.Clear()
            chartItemsPorArea.Legends.Clear()

            ' Añadir una serie al gráfico
            Dim series As New Series("SystemArea")
            series.ChartType = SeriesChartType.Bar
            series.Font = New Font("Century Gothic", 10)
            series.LabelForeColor = Color.White
            series.IsValueShownAsLabel = True ' Mostrar los valores encima de las barras
            chartItemsPorArea.Series.Add(series)

            ' Definir una paleta de colores
            Dim colors As Color() = {Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple, Color.Orange}

            ' Llenar la serie con datos
            Dim colorIndex As Integer = 0
            For Each row As DataRow In dt.Rows
                Dim point As New DataPoint()
                point.SetValueXY(row("SystemArea").ToString(), Convert.ToInt32(row("Cantidad")))
                point.Label = row("Cantidad").ToString() ' Mostrar la cantidad en la etiqueta
                point.Font = New Font("Century Gothic", 10)
                point.LabelForeColor = Color.White

                ' Asignar un color distinto a cada barra
                point.Color = colors(colorIndex Mod colors.Length)
                colorIndex += 1

                series.Points.Add(point)
            Next

            ' Configurar el área del gráfico
            chartItemsPorArea.ChartAreas(0).BackColor = Color.Transparent
            chartItemsPorArea.ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
            chartItemsPorArea.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Century Gothic", 10)
            chartItemsPorArea.ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
            chartItemsPorArea.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Century Gothic", 10)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class