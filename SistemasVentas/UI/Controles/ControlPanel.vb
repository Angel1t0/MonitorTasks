Imports System.Drawing.Drawing2D

Public Class ControlPanel
    Inherits Panel

    Private _borderRadius As Integer = 8

    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate() ' Esto hará que el Panel se redibuje
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim graphicsPath As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim arcSize As Integer = _borderRadius * 2
        graphicsPath.AddArc(New Rectangle(rect.Left, rect.Top, arcSize, arcSize), 180, 90)
        graphicsPath.AddArc(New Rectangle(rect.Right - arcSize, rect.Top, arcSize, arcSize), 270, 90)
        graphicsPath.AddArc(New Rectangle(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize), 0, 90)
        graphicsPath.AddArc(New Rectangle(rect.Left, rect.Bottom - arcSize, arcSize, arcSize), 90, 90)
        graphicsPath.CloseFigure()

        Me.Region = New Region(graphicsPath) ' Establece la región del Panel al path redondeado
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.DrawPath(New Pen(Me.ForeColor, 1.0F), graphicsPath) ' Dibuja el borde redondeado
    End Sub
End Class