Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient


Public Class FormLogin
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Settings.RememberMe Then
                txtUsername.Text = My.Settings.LastUsername
                chkRemember.Checked = True
            End If
        Catch
        End Try
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If username = "" OrElse password = "" Then
            MessageBox.Show("Username dan Password harus diisi.",
                        "Validasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtPassword.Clear()
            txtPassword.Focus()
            Exit Sub
        End If

        Dim row As DataRow = GetUserInfo(username, password)

        If row Is Nothing Then
            MessageBox.Show("Username atau password salah.",
                        "Login Gagal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
            txtPassword.Clear()
            txtPassword.Focus()
            Exit Sub
        End If

        ' === Session diisi di sini ===
        CurrentUserId = CInt(row("id"))
        CurrentUsername = row("username").ToString()
        CurrentUserRole = row("role").ToString()
        If row.Table.Columns.Contains("periode") AndAlso Not IsDBNull(row("periode")) Then
            CurrentPeriode = row("periode").ToString()
        Else
            CurrentPeriode = ""   ' atau "Belum diatur"
        End If

        ApplyRememberMe(username)

        ' Buka dashboard
        Dim dash As New FormDashboard()
        Me.Hide()
        dash.Show()
    End Sub
    Private Sub ApplyRememberMe(username As String)
        Try
            If chkRemember.Checked Then
                My.Settings.LastUsername = username
                My.Settings.RememberMe = True
            Else
                My.Settings.LastUsername = ""
                My.Settings.RememberMe = False
            End If
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Private Sub OpenDashboardByRole(role As String)
        Dim nextForm As New FormDashboard()
        Me.Hide()
        nextForm.Show()
    End Sub

    Private Sub LnkSignupClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkSignup.LinkClicked

        ' Contoh: buka form registrasi dosen
        Dim frm As New FormRegistrasiDosen()
        frm.ShowDialog()
    End Sub

    Private Sub lnkForgot_Clicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkForgot.LinkClicked
        MessageBox.Show("Silakan hubungi admin untuk reset password.",
                        "Lupa Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub lnkSignup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSignup.LinkClicked
        Dim reg As New FormRegistrasiDosen
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub lblWelcomeTitle_Click(sender As Object, e As EventArgs) Handles lblWelcomeTitle.Click

    End Sub
End Class


