Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient


Public Class FormLogin

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Biar halus
        Me.DoubleBuffered = True
    End Sub

    Private Sub pnlLeft_Paint(sender As Object, e As PaintEventArgs) Handles pnlLeft.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = Me.pnlLeft.ClientRectangle

        ' Gradient utama: biru → biru muda (#6d94c5 → #cbdceb)
        Using lg As New LinearGradientBrush(
            rect,
            Color.FromArgb(109, 148, 197),   ' #6d94c5
            Color.FromArgb(203, 220, 235),   ' #cbdceb
            LinearGradientMode.ForwardDiagonal
        )
            g.FillRectangle(lg, rect)
        End Using

        ' Wave / blob dengan cream (#e8dfca) transparan
        Dim path As New GraphicsPath()
        Dim w As Integer = rect.Width
        Dim h As Integer = rect.Height

        path.AddBezier(New Point(0, h \ 3),
                       New Point(w \ 3, h \ 5),
                       New Point(2 * w \ 3, h \ 2),
                       New Point(w, h \ 3))

        path.AddBezier(New Point(w, h \ 3),
                       New Point(2 * w \ 3, 4 * h \ 5),
                       New Point(w \ 3, h),
                       New Point(0, 2 * h \ 3))

        path.CloseFigure()

        Using brush As New SolidBrush(Color.FromArgb(90, 232, 223, 202)) ' alpha + #e8dfca
            g.FillPath(brush, path)
        End Using
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        Dim userRole As String = GetRole(username, password)


        If userRole IsNot Nothing Then
            Dim namaAsli As String = txtUsername.Text
            Dim periode As String = "2024/2025"
            Dim dash As New FormDashboard(namaAsli, userRole, periode)
            dash.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username atau password salah")
        End If
    End Sub

    Private Sub lnkSignup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSignup.LinkClicked
        Dim reg As New FormRegistrasiDosen
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub lblWelcomeTitle_Click(sender As Object, e As EventArgs) Handles lblWelcomeTitle.Click

    End Sub
End Class


