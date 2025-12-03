Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient


Public Class FormRegistrasiDosen

    Private Function IsValidEmail(email As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(
        email,
        "^[\w\.-]+@[\w\.-]+\.\w+$"
    )
    End Function



    Private Sub pnlRight_Paint(sender As Object, e As PaintEventArgs) Handles pnlSide.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = Me.pnlSide.ClientRectangle

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

    Private Sub pnlForm_Paint(sender As Object, e As PaintEventArgs) Handles pnlForm.Paint

    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If Not IsValidEmail(txtEmail.Text) Then
            MsgBox("Format email tidak valid!")
            Exit Sub
        End If

        If txtPassword.Text.Length < 8 Then
            MsgBox("Password minimal 8 karakter!", vbExclamation, "Peringatan")
            Exit Sub
        End If

        If txtPassword.Text <> txtKonfirmasi.Text Then
            MsgBox("Password dan konfirmasi tidak cocok!")
            Exit Sub
        End If


        If txtNIP.Text = "" Or txtNama.Text = "" Or cboProdi.Text = "" Then
            MsgBox("Harap isi semua data!", vbExclamation, "Peringatan")
            Exit Sub
        End If

        Koneksi()

        Try
            ' 1. Simpan ke tabel users
            Dim cmdUser As New MySqlCommand("
            INSERT INTO users (username, password, role)
            VALUES (@u, @p, 'Dosen');
            SELECT LAST_INSERT_ID();", Conn)

            cmdUser.Parameters.AddWithValue("@u", txtNIP.Text)
            cmdUser.Parameters.AddWithValue("@p", txtPassword.Text)

            Dim userId As Integer = Convert.ToInt32(cmdUser.ExecuteScalar())

            ' 2. Simpan ke tabel dosen
            Dim cmdDosen As New MySqlCommand("
            INSERT INTO dosen (user_id, nip, nama, prodi, email, telp)
            VALUES (@uid, @nip, @nama, @prodi, @email, @telp)", Conn)

            cmdDosen.Parameters.AddWithValue("@uid", userId)
            cmdDosen.Parameters.AddWithValue("@nip", txtNIP.Text)
            cmdDosen.Parameters.AddWithValue("@nama", txtNama.Text)
            cmdDosen.Parameters.AddWithValue("@prodi", cboProdi.Text)
            cmdDosen.Parameters.AddWithValue("@email", txtEmail.Text)
            cmdDosen.Parameters.AddWithValue("@telp", txtNoHP.Text)

            cmdDosen.ExecuteNonQuery()

            MsgBox("Registrasi berhasil! Silakan login.")

            Me.Close()
            FormLogin.Show()


        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message)
        Catch ex As MySqlException
            MsgBox("Error MySQL: " & ex.Message, vbCritical)
        End Try


    End Sub

    Private Sub cboProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdi.SelectedIndexChanged

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNIP.Clear()
        txtNama.Clear()
        cboProdi.SelectedIndex = -1
        txtEmail.Clear()
        txtNoHP.Clear()
        txtPassword.Clear()
        txtKonfirmasi.Clear()

        txtNIP.Focus()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        FormLogin.Show()
        Me.Close()
    End Sub

    Private Sub lblWelcomeTitle_Click(sender As Object, e As EventArgs) Handles lblWelcomeTitle.Click

    End Sub
End Class


