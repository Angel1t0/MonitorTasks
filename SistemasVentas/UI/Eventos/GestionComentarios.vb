Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Class GestionComentarios
    Private _podioService As New PodioService()
    Private _data As New EventoData()
    Private podioUsers As New Dictionary(Of String, Integer)()
    Public Property _PodioAppItemID As Long
    Public Sub New(podioAppItemID As Long)
        InitializeComponent()
        _PodioAppItemID = podioAppItemID
    End Sub
    Private Sub GestionComentarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefrescarComentarios()
        podioUsers = GetUserNames()
    End Sub

    Private Sub ActualizarListaComentarios(comments As JArray)
        rtbComentarios.Clear()
        For Each comment As JObject In comments
            Dim name As String = comment("created_by")("name").ToString()
            Dim dateText As String = DateTime.Parse(comment("created_on").ToString()).ToString("yyyy-MM-dd")
            Dim value As String = comment("value").ToString()

            ' Añadir nombre en negrita
            rtbComentarios.SelectionFont = New Font(rtbComentarios.Font, FontStyle.Bold)
            rtbComentarios.AppendText($"{name} ({dateText}): ")

            ' Añadir comentario en texto normal
            rtbComentarios.SelectionFont = New Font(rtbComentarios.Font, FontStyle.Regular)
            rtbComentarios.AppendText($"{Environment.NewLine}{value}{Environment.NewLine}{Environment.NewLine}")
        Next
    End Sub

    Private Async Sub btnComentar_Click(sender As Object, e As EventArgs) Handles btnComentar.Click
        Try
            Dim comentario As String = txtComentario.TextBox1.Text
            If String.IsNullOrWhiteSpace(comentario) Then
                MessageBox.Show("Ingresa un comentario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Reemplazar los nombres de usuario con el formato requerido
            comentario = ReplaceUserNamesWithIds(comentario)

            Await _podioService.AddCommentByItem(_PodioAppItemID, comentario)
            txtComentario.TextBox1.Text = ""
            Dim comments = Await _podioService.GetCommentsByItem(_PodioAppItemID)
            ActualizarListaComentarios(comments)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefrescarComentarios_Click(sender As Object, e As EventArgs) Handles btnRefrescarComentarios.Click
        RefrescarComentarios()
    End Sub

    Private Async Sub RefrescarComentarios()
        Try
            Dim comments = Await _podioService.GetCommentsByItem(_PodioAppItemID)
            ActualizarListaComentarios(comments)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetUserNames() As Dictionary(Of String, Integer)
        ' Aquí deberías cargar los nombres de usuario desde la base de datos o una lista predefinida
        Return _data.ObtenerPodioUserIDYNombre()
    End Function

    Private Function ReplaceUserNamesWithIds(comment As String) As String
        Dim regex As New Regex("@([\w\s]+)", RegexOptions.Compiled)
        Return regex.Replace(comment, Function(match)
                                          Dim userName As String = match.Groups(1).Value.Trim()
                                          If podioUsers.ContainsKey(userName) Then
                                              Return $"@[{userName}](user:{podioUsers(userName)})"
                                          Else
                                              Return match.Value
                                          End If
                                      End Function)
    End Function


    Private Sub cbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuarios.SelectedIndexChanged
        Try
            If cbUsuarios.SelectedItem IsNot Nothing Then
                Dim selectedUser As String = cbUsuarios.SelectedItem.ToString()
                Dim text As String = txtComentario.TextBox1.Text
                Dim lastWord As String = text.Split(" "c).LastOrDefault(Function(w) w.StartsWith("@"))
                If Not String.IsNullOrEmpty(lastWord) Then
                    text = text.Substring(0, text.Length - lastWord.Length) & "@" & selectedUser
                    txtComentario.TextBox1.Text = text
                    txtComentario.TextBox1.SelectionStart = text.Length
                End If
                cbUsuarios.DroppedDown = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtComentario__TextChanged(sender As Object, e As EventArgs) Handles txtComentario._TextChanged
        Dim text As String = txtComentario.TextBox1.Text
        Dim lastWord As String = text.Split(" "c).LastOrDefault(Function(w) w.StartsWith("@"))
        If Not String.IsNullOrEmpty(lastWord) Then
            Dim searchName As String = lastWord.Substring(1).ToLower()
            Dim matchingUsers = podioUsers.Keys.Where(Function(name) name.ToLower().Contains(searchName)).ToList()
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
End Class