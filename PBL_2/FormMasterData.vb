Imports MySql.Data.MySqlClient

Public Class FormMasterData

    '=====================================
    '  FIELD BANTU
    '=====================================
    Private SelectedDosenId As Integer = 0
    Private SelectedUserId As Integer = 0
    Private SelectedPertanyaanId As Integer = 0

    ' item untuk combobox user_login
    Private Class UserItem
        Public Property Id As Integer
        Public Property Username As String

        Public Overrides Function ToString() As String
            Return Username
        End Function
    End Class

    '=====================================
    '  FORM LOAD
    '=====================================
    Private Sub FormMasterData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' isi combo statis
            InitPeriodeDosen()
            InitRoleUser()
            InitTargetRole()
            InitTipeInput()

            ' isi data dari database
            LoadUsersGrid()
            LoadUserLoginCombo()
            LoadDosenGrid()
            LoadPertanyaanGrid()

            ResetFormDosen()
            ResetFormUser()
            ResetFormPertanyaan()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat master data:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=====================================
    '  INISIALISASI COMBO STATIS
    '=====================================
    Private Sub InitPeriodeDosen()
        cboPeriodeDosen.Items.Clear()
        cboPeriodeDosen.Items.Add("2024/2025 - Ganjil")
        cboPeriodeDosen.Items.Add("2024/2025 - Genap")
        cboPeriodeDosen.Items.Add("2025/2026 - Ganjil")
        cboPeriodeDosen.Items.Add("2025/2026 - Genap")
    End Sub

    Private Sub InitRoleUser()
        cboRole.Items.Clear()
        cboRole.Items.Add("Dosen")
        cboRole.Items.Add("Admin")
        cboRole.Items.Add("KPS")
        cboRole.Items.Add("Kepala Jurusan")
    End Sub

    Private Sub InitTargetRole()
        cboTarget.Items.Clear()
        cboTarget.Items.Add("Dosen")
        cboTarget.Items.Add("Admin")
        cboTarget.Items.Add("KPS")
        cboTarget.Items.Add("Kepala Jurusan")
    End Sub

    Private Sub InitTipeInput()
        cboTipeInput.Items.Clear()
        ' contoh tipe input:
        ' - angka_1_10 → skor 1–10
        ' - proaktif    → pilihan teks (Menyusun proposal, dll.)
        cboTipeInput.Items.Add("angka_1_10")
        cboTipeInput.Items.Add("proaktif")
    End Sub

    '=====================================
    '  LOAD DATA DOSEN
    '=====================================
    Private Sub LoadDosenGrid()
        Try
            Koneksi() ' gunakan modul Conn yang sudah ada

            Dim sql As String =
                "SELECT d.id, d.user_id, u.username AS user_username, " &
                "       d.nip, d.nama, d.prodi, d.email, d.telp, d.periode " &
                "FROM dosen d " &
                "LEFT JOIN users u ON d.user_id = u.id " &
                "ORDER BY d.nama"

            Using da As New MySqlDataAdapter(sql, Conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvDosen.DataSource = dt
            End Using

            If dgvDosen.Columns.Contains("user_id") Then
                dgvDosen.Columns("user_id").Visible = False
            End If
            If dgvDosen.Columns.Contains("id") Then
                dgvDosen.Columns("id").HeaderText = "ID"
                dgvDosen.Columns("id").Width = 50
            End If
            If dgvDosen.Columns.Contains("user_username") Then
                dgvDosen.Columns("user_username").HeaderText = "User Login"
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data dosen: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUserLoginCombo()
        Try
            Koneksi()

            Dim sql As String = "SELECT id, username FROM users ORDER BY username"

            Using cmd As New MySqlCommand(sql, Conn)
                Using rd = cmd.ExecuteReader()
                    cboUserLogin.Items.Clear()
                    While rd.Read()
                        Dim item As New UserItem With {
                            .Id = CInt(rd("id")),
                            .Username = rd("username").ToString()
                        }
                        cboUserLogin.Items.Add(item)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar user login: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=====================================
    '  LOAD DATA USER
    '=====================================
    Private Sub LoadUsersGrid()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT id, username, password, role " &
                "FROM users " &
                "ORDER BY id"

            Using da As New MySqlDataAdapter(sql, Conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvUser.DataSource = dt
            End Using

            If dgvUser.Columns.Contains("id") Then
                dgvUser.Columns("id").HeaderText = "ID"
                dgvUser.Columns("id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data user: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=====================================
    '  LOAD DATA PERTANYAAN
    '=====================================
    Private Sub LoadPertanyaanGrid()
        Try
            Koneksi()

            Dim sql As String =
                "SELECT id, aspek, pertanyaan, target_role, tipe_input " &
                "FROM ms_pertanyaan " &
                "ORDER BY id"

            Using da As New MySqlDataAdapter(sql, Conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvPertanyaan.DataSource = dt
            End Using

            If dgvPertanyaan.Columns.Contains("id") Then
                dgvPertanyaan.Columns("id").HeaderText = "ID"
                dgvPertanyaan.Columns("id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pertanyaan: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=====================================
    '  RESET FORM
    '=====================================
    Private Sub ResetFormDosen()
        SelectedDosenId = 0
        lblIDDosen.Text = "0"
        lblUserIdDosen.Text = "0"

        txtNIP.Text = ""
        txtNamaDosen.Text = ""
        txtProgramStudi.Text = ""
        txtEmail.Text = ""
        txtTelp.Text = ""
        cboPeriodeDosen.SelectedIndex = -1
        cboUserLogin.SelectedIndex = -1

        txtNIP.Focus()
    End Sub

    Private Sub ResetFormUser()
        SelectedUserId = 0
        lblUserId.Text = "0"

        txtUsername.Text = ""
        txtPassword.Text = ""
        txtNamaLengkap.Text = ""
        cboRole.SelectedIndex = -1
        txtUsername.Focus()
    End Sub

    Private Sub ResetFormPertanyaan()
        SelectedPertanyaanId = 0
        lblIDPertanyaan.Text = "0"

        txtAspek.Text = ""
        txtPertanyaan.Text = ""
        cboTarget.SelectedIndex = -1
        cboTipeInput.SelectedIndex = -1
        txtAspek.Focus()
    End Sub

    '=====================================
    '  EVENT BUTTON DATA DOSEN
    '=====================================
    Private Sub btnResetDosen_Click(sender As Object, e As EventArgs) Handles btnResetDosen.Click
        ResetFormDosen()
    End Sub

    Private Sub btnSimpanDosen_Click(sender As Object, e As EventArgs) Handles btnSimpanDosen.Click
        ' validasi
        If String.IsNullOrWhiteSpace(txtNIP.Text) Then
            MessageBox.Show("NIP wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIP.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtNamaDosen.Text) Then
            MessageBox.Show("Nama dosen wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNamaDosen.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtProgramStudi.Text) Then
            MessageBox.Show("Program studi wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgramStudi.Focus()
            Exit Sub
        End If
        If cboPeriodeDosen.SelectedIndex < 0 Then
            MessageBox.Show("Periode wajib dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriodeDosen.DroppedDown = True
            Exit Sub
        End If
        If cboUserLogin.SelectedIndex < 0 Then
            MessageBox.Show("User login wajib dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUserLogin.DroppedDown = True
            Exit Sub
        End If

        Dim userItem As UserItem = TryCast(cboUserLogin.SelectedItem, UserItem)
        Dim userId As Integer = If(userItem IsNot Nothing, userItem.Id, 0)

        Try
            Koneksi()

            If SelectedDosenId = 0 Then
                ' INSERT
                Dim sql As String =
                    "INSERT INTO dosen (user_id, nip, nama, prodi, email, telp, periode) " &
                    "VALUES (@uid, @nip, @nama, @prodi, @email, @telp, @periode)"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@uid", userId)
                    cmd.Parameters.AddWithValue("@nip", txtNIP.Text.Trim())
                    cmd.Parameters.AddWithValue("@nama", txtNamaDosen.Text.Trim())
                    cmd.Parameters.AddWithValue("@prodi", txtProgramStudi.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@telp", txtTelp.Text.Trim())
                    cmd.Parameters.AddWithValue("@periode", cboPeriodeDosen.SelectedItem.ToString())
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data dosen berhasil ditambahkan.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' UPDATE
                Dim sql As String =
                    "UPDATE dosen SET user_id=@uid, nip=@nip, nama=@nama, prodi=@prodi, " &
                    "email=@email, telp=@telp, periode=@periode " &
                    "WHERE id=@id"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@uid", userId)
                    cmd.Parameters.AddWithValue("@nip", txtNIP.Text.Trim())
                    cmd.Parameters.AddWithValue("@nama", txtNamaDosen.Text.Trim())
                    cmd.Parameters.AddWithValue("@prodi", txtProgramStudi.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@telp", txtTelp.Text.Trim())
                    cmd.Parameters.AddWithValue("@periode", cboPeriodeDosen.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@id", SelectedDosenId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data dosen berhasil diperbarui.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            LoadDosenGrid()
            ResetFormDosen()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data dosen:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapusDosen_Click(sender As Object, e As EventArgs) Handles btnHapusDosen.Click
        If SelectedDosenId = 0 Then
            MessageBox.Show("Pilih data dosen yang akan dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Yakin akan menghapus data dosen ini?",
                           "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Koneksi()

            Dim sql As String = "DELETE FROM dosen WHERE id=@id"
            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@id", SelectedDosenId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data dosen berhasil dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDosenGrid()
            ResetFormDosen()

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data dosen:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' klik row dgvDosen → isi form
    Private Sub dgvDosen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDosen.CellClick
        If e.RowIndex < 0 OrElse dgvDosen.CurrentRow Is Nothing Then Return

        Dim row As DataGridViewRow = dgvDosen.CurrentRow

        Try
            SelectedDosenId = Convert.ToInt32(row.Cells("id").Value)
            lblIDDosen.Text = SelectedDosenId.ToString()

            Dim userId As Integer = 0
            If Not IsDBNull(row.Cells("user_id").Value) Then
                userId = Convert.ToInt32(row.Cells("user_id").Value)
            End If
            lblUserIdDosen.Text = userId.ToString()

            txtNIP.Text = row.Cells("nip").Value.ToString()
            txtNamaDosen.Text = row.Cells("nama").Value.ToString()
            txtProgramStudi.Text = row.Cells("prodi").Value.ToString()
            txtEmail.Text = row.Cells("email").Value.ToString()
            txtTelp.Text = row.Cells("telp").Value.ToString()
            cboPeriodeDosen.SelectedItem = row.Cells("periode").Value.ToString()

            ' set combobox user_login sesuai user_id
            cboUserLogin.SelectedIndex = -1
            For i As Integer = 0 To cboUserLogin.Items.Count - 1
                Dim item As UserItem = TryCast(cboUserLogin.Items(i), UserItem)
                If item IsNot Nothing AndAlso item.Id = userId Then
                    cboUserLogin.SelectedIndex = i
                    Exit For
                End If
            Next

        Catch
            ' jika ada masalah convert, abaikan saja
        End Try
    End Sub

    '=====================================
    '  EVENT BUTTON DATA USER
    '=====================================
    Private Sub btnResetUser_Click(sender As Object, e As EventArgs) Handles btnResetUser.Click
        ResetFormUser()
    End Sub

    Private Sub btnSimpanUser_Click(sender As Object, e As EventArgs) Handles btnSimpanUser.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If
        If cboRole.SelectedIndex < 0 Then
            MessageBox.Show("Role wajib dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.DroppedDown = True
            Exit Sub
        End If

        Try
            Koneksi()

            If SelectedUserId = 0 Then
                ' INSERT
                Dim sql As String =
                    "INSERT INTO users (username, password, role) " &
                    "VALUES (@username, @password, @role)"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data user berhasil ditambahkan.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' UPDATE
                Dim sql As String =
                    "UPDATE users SET username=@username, password=@password, role=@role " &
                    "WHERE id=@id"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@id", SelectedUserId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data user berhasil diperbarui.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            LoadUsersGrid()
            LoadUserLoginCombo()   ' refresh combo user pada tab dosen
            ResetFormUser()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data user:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapusUser_Click(sender As Object, e As EventArgs) Handles btnHapusUser.Click
        If SelectedUserId = 0 Then
            MessageBox.Show("Pilih data user yang akan dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Yakin akan menghapus data user ini?" & Environment.NewLine &
                           "Pastikan tidak sedang dipakai sebagai user_id di tabel dosen.",
                           "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Koneksi()

            Dim sql As String = "DELETE FROM users WHERE id=@id"
            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@id", SelectedUserId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data user berhasil dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadUsersGrid()
            LoadUserLoginCombo()
            ResetFormUser()

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data user:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellClick
        If e.RowIndex < 0 OrElse dgvUser.CurrentRow Is Nothing Then Return

        Dim row As DataGridViewRow = dgvUser.CurrentRow

        Try
            SelectedUserId = Convert.ToInt32(row.Cells("id").Value)
            lblUserId.Text = SelectedUserId.ToString()

            txtUsername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            txtNamaLengkap.Text = "" ' jika ingin menyimpan nama lengkap di tabel lain, bisa diabaikan
            cboRole.SelectedItem = row.Cells("role").Value.ToString()

        Catch
        End Try
    End Sub

    '=====================================
    '  EVENT BUTTON DATA PERTANYAAN
    '=====================================
    Private Sub btnResetPertanyaan_Click(sender As Object, e As EventArgs) Handles btnResetPertanyaan.Click
        ResetFormPertanyaan()
    End Sub

    Private Sub btnSimpanPertanyaan_Click(sender As Object, e As EventArgs) Handles btnSimpanPertanyaan.Click
        If String.IsNullOrWhiteSpace(txtAspek.Text) Then
            MessageBox.Show("Aspek penilaian wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAspek.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPertanyaan.Text) Then
            MessageBox.Show("Pertanyaan wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPertanyaan.Focus()
            Exit Sub
        End If
        If cboTarget.SelectedIndex < 0 Then
            MessageBox.Show("Target role wajib dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTarget.DroppedDown = True
            Exit Sub
        End If
        If cboTipeInput.SelectedIndex < 0 Then
            MessageBox.Show("Tipe input/Skor wajib dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTipeInput.DroppedDown = True
            Exit Sub
        End If

        Try
            Koneksi()

            If SelectedPertanyaanId = 0 Then
                ' INSERT
                Dim sql As String =
                    "INSERT INTO ms_pertanyaan (aspek, pertanyaan, target_role, tipe_input) " &
                    "VALUES (@aspek, @pert, @target, @tipe)"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@aspek", txtAspek.Text.Trim())
                    cmd.Parameters.AddWithValue("@pert", txtPertanyaan.Text.Trim())
                    cmd.Parameters.AddWithValue("@target", cboTarget.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@tipe", cboTipeInput.SelectedItem.ToString())
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Pertanyaan berhasil ditambahkan.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' UPDATE
                Dim sql As String =
                    "UPDATE ms_pertanyaan SET aspek=@aspek, pertanyaan=@pert, " &
                    "target_role=@target, tipe_input=@tipe WHERE id=@id"

                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@aspek", txtAspek.Text.Trim())
                    cmd.Parameters.AddWithValue("@pert", txtPertanyaan.Text.Trim())
                    cmd.Parameters.AddWithValue("@target", cboTarget.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@tipe", cboTipeInput.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@id", SelectedPertanyaanId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Pertanyaan berhasil diperbarui.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            LoadPertanyaanGrid()
            ResetFormPertanyaan()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan pertanyaan:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapusPertanyaan_Click(sender As Object, e As EventArgs) Handles btnHapusPertanyaan.Click
        If SelectedPertanyaanId = 0 Then
            MessageBox.Show("Pilih data pertanyaan yang akan dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Yakin akan menghapus pertanyaan ini?",
                           "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Koneksi()

            Dim sql As String = "DELETE FROM ms_pertanyaan WHERE id=@id"
            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@id", SelectedPertanyaanId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Pertanyaan berhasil dihapus.",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadPertanyaanGrid()
            ResetFormPertanyaan()

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus pertanyaan:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPertanyaan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPertanyaan.CellClick
        If e.RowIndex < 0 OrElse dgvPertanyaan.CurrentRow Is Nothing Then Return

        Dim row As DataGridViewRow = dgvPertanyaan.CurrentRow

        Try
            SelectedPertanyaanId = Convert.ToInt32(row.Cells("id").Value)
            lblIDPertanyaan.Text = SelectedPertanyaanId.ToString()

            txtAspek.Text = row.Cells("aspek").Value.ToString()
            txtPertanyaan.Text = row.Cells("pertanyaan").Value.ToString()
            cboTarget.SelectedItem = row.Cells("target_role").Value.ToString()
            cboTipeInput.SelectedItem = row.Cells("tipe_input").Value.ToString()

        Catch
        End Try
    End Sub

End Class
