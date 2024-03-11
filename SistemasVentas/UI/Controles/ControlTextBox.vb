Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

<DefaultEvent("_TextChanged")>
Partial Public Class ControlTextBox
    Inherits UserControl

    ' Default Event
    Public Event _TextChanged As EventHandler

    ' Fields
    Private _borderColor As Color = Color.MediumBlue
    Private _borderSize As Integer = 2
    Private _underlinedStyle As Boolean = False
    Private _borderFocusColor As Color = Color.HotPink
    Private _isFocused As Boolean = False

    Private _borderRadius As Integer = 0
    Private _placeholderColor As Color = Color.DarkGray
    Private _placeholderText As String = ""
    Private _isPlaceholder As Boolean = False
    Private _isPasswordChar As Boolean = False

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Properties
    <Category("Personalizado")>
    Public Property BorderColor As Color
        Get
            Return Me._borderColor
        End Get
        Set(ByVal value As Color)
            Me._borderColor = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Personalizado")>
    Public Property BorderSize As Integer
        Get
            Return Me._borderSize
        End Get
        Set(ByVal value As Integer)
            Me._borderSize = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Personalizado")>
    Public Property UnderlinedStyle As Boolean
        Get
            Return Me._underlinedStyle
        End Get
        Set(ByVal value As Boolean)
            Me._underlinedStyle = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Personalizado")>
    Public Property PasswordChar As Boolean
        Get
            Return Me.TextBox1.UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            Me.TextBox1.UseSystemPasswordChar = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Property Multiline As Boolean
        Get
            Return Me.TextBox1.Multiline
        End Get
        Set(ByVal value As Boolean)
            Me.TextBox1.Multiline = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
            TextBox1.BackColor = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
            TextBox1.ForeColor = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            TextBox1.Font = value
            If Me.DesignMode Then
                UpdateControlHeight()
            End If
        End Set
    End Property

    <Category("Personalizado")>
    Public Property Texts As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox1.Text = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Property BorderFocusColor As Color
        Get
            Return Me._borderFocusColor
        End Get
        Set(ByVal value As Color)
            Me._borderFocusColor = value
        End Set
    End Property

    <Category("Personalizado")>
    Public Property BorderRadius As Integer
        Get
            Return Me._borderRadius
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                Me._borderRadius = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Category("Personalizado")>
    Public Property PlaceholderColor As Color
        Get
            Return Me._placeholderColor
        End Get
        Set(ByVal value As Color)
            Me._placeholderColor = value
            If _isPlaceholder Then
                TextBox1.ForeColor = value
            End If
        End Set
    End Property

    <Category("Personalizado")>
    Public Property PlaceholderText As String
        Get
            Return Me._placeholderText
        End Get
        Set(ByVal value As String)
            Me._placeholderText = value
            Me.TextBox1.Text = value
            SetPlaceholder()
        End Set
    End Property

    ' Overriden methods
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim graph As Graphics = e.Graphics

        If BorderRadius > 1 Then ' Rounded TextBox
            ' -Fields
            Dim rectBorderSmooth As Rectangle = Me.ClientRectangle
            Dim rectBorder As Rectangle = Rectangle.Inflate(rectBorderSmooth, -_borderSize, -_borderSize)
            Dim smoothSize As Integer = If(_borderSize > 0, _borderSize, 1)

            Using pathBorderSmooth As GraphicsPath = GetFigurePath(rectBorderSmooth, _borderRadius)
                Using pathBorder As GraphicsPath = GetFigurePath(rectBorder, _borderRadius - _borderSize)
                    Using penBorderSmooth As New Pen(Me.Parent.BackColor, smoothSize)
                        Using penBorder As New Pen(_borderColor, _borderSize)
                            ' -Drawing
                            Me.Region = New Region(pathBorderSmooth) ' Set the rounded region of UserControl
                            If _borderRadius > 15 Then
                                SetTextBoxRoundedRegion() ' Set the rounded region of TextBox component
                            End If
                            graph.SmoothingMode = SmoothingMode.AntiAlias
                            penBorder.Alignment = PenAlignment.Center
                            If _isFocused Then
                                penBorder.Color = _borderFocusColor
                            End If

                            If _underlinedStyle Then ' Line Style
                                ' Draw border smoothing
                                graph.DrawPath(penBorderSmooth, pathBorderSmooth)
                                ' Draw border
                                graph.SmoothingMode = SmoothingMode.None
                                graph.DrawLine(penBorder, 0, Me.Height - 1, Me.Width, Me.Height - 1)
                            Else ' Normal Style
                                ' Draw border smoothing
                                graph.DrawPath(penBorderSmooth, pathBorderSmooth)
                                ' Draw border
                                graph.DrawPath(penBorder, pathBorder)
                            End If
                        End Using
                    End Using
                End Using
            End Using
        Else ' Square/Normal TextBox
            ' Draw border
            Using penBorder As New Pen(_borderColor, _borderSize)
                Me.Region = New Region(Me.ClientRectangle)
                penBorder.Alignment = PenAlignment.Inset
                If _isFocused Then
                    penBorder.Color = _borderFocusColor
                End If

                If UnderlinedStyle Then ' Line Style
                    graph.DrawLine(penBorder, 0, Me.Height - 1, Me.Width, Me.Height - 1)
                Else ' Normal Style
                    graph.DrawRectangle(penBorder, 0, 0, Me.Width - 0.5F, Me.Height - 0.5F)
                End If
            End Using
        End If
    End Sub

    Private Sub SetPlaceholder()
        If String.IsNullOrEmpty(TextBox1.Text) And _placeholderText <> "" Then
            _isPlaceholder = True
            TextBox1.Text = _placeholderText
            TextBox1.ForeColor = _placeholderColor
            If _isPasswordChar Then
                TextBox1.UseSystemPasswordChar = False
            End If
        End If
    End Sub

    Private Sub RemovePlaceholder()
        If _isPlaceholder And _placeholderText <> "" Then
            _isPlaceholder = False
            TextBox1.Text = ""
            TextBox1.ForeColor = Me.ForeColor
            If _isPasswordChar Then
                TextBox1.UseSystemPasswordChar = True
            End If
        End If
    End Sub

    Private Function GetFigurePath(ByVal rect As Rectangle, ByVal radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim curveSize As Single = radius * 2.0F

        path.StartFigure()
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90)
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90)
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90)
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub SetTextBoxRoundedRegion()
        Dim pathTxt As GraphicsPath
        If Multiline Then
            pathTxt = GetFigurePath(TextBox1.ClientRectangle, BorderRadius - BorderSize)
            TextBox1.Region = New Region(pathTxt)
        Else
            pathTxt = GetFigurePath(TextBox1.ClientRectangle, BorderSize * 2)
            TextBox1.Region = New Region(pathTxt)
        End If
        pathTxt.Dispose()
    End Sub

    Private Sub UpdateControlHeight()
        If TextBox1.Multiline = False Then
            Dim txtHeight As Integer = TextRenderer.MeasureText("Text", TextBox1.Font).Height + 1
            TextBox1.Multiline = True
            TextBox1.MinimumSize = New Size(0, txtHeight)
            TextBox1.Multiline = False

            Me.Height = TextBox1.Height + Me.Padding.Top + Me.Padding.Bottom
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        If (Me.DesignMode) Then
            UpdateControlHeight()
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        UpdateControlHeight()
    End Sub

    ' Change border color in focus mode
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        _isFocused = True
        Me.Invalidate()
        RemovePlaceholder()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        _isFocused = False
        Me.Invalidate()
        SetPlaceholder()
    End Sub

    ' Events
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent _TextChanged(sender, e)
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Me.OnClick(e)
    End Sub

    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        Me.OnMouseEnter(e)
    End Sub

    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        Me.OnMouseLeave(e)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Me.OnKeyPress(e)
    End Sub
End Class
