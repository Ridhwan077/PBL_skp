Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging

Partial Public Class FormProfilDosen

    ' Satu sumber kebenaran untuk lokasi folder foto
    Private Const FOTO_DIR As String = "E:\Kulyeah\PNJ\PV\PBL_skp\foto_dosen"

    Private Sub FormProfilDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "PROFIL DOSEN"

        Try
            LoadProfilDosen()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat profil: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProfilDosen()
        Dim userId As Integer = CurrentUserId
        If userId <= 0 Then
            Throw New ApplicationException("User ID tidak valid di session.")
        End If

        Dim connStr As String =
            "server=127.0.0.1;user id=root;password=;database=skp_pv;"

        Using conn As New MySqlConnection(connStr)
            conn.Open()

            Dim sql As String =
                "SELECT nip, nama, prodi, foto_key " &
                "FROM dosen " &
                "WHERE user_id = @uid LIMIT 1"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@uid", userId)

                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        Dim nip As String = rd("nip").ToString()
                        Dim nama As String = rd("nama").ToString()
                        Dim prodi As String = rd("prodi").ToString()
                        Dim fotoKey As String = rd("foto_key").ToString()

                        lblNipValue.Text = nip
                        lblNamaValue.Text = nama
                        lblProdiValue.Text = prodi

                        If Not String.IsNullOrWhiteSpace(fotoKey) Then
                            ' >>> Pakai folder FOTO_DIR, bukan Application.StartupPath
                            Dim fotoPath As String = Path.Combine(FOTO_DIR, fotoKey & ".jpg")

                            If File.Exists(fotoPath) Then
                                Dim imgBytes() = File.ReadAllBytes(fotoPath)
                                Using ms As New MemoryStream(imgBytes)
                                    picFoto.Image = Image.FromStream(ms)
                                End Using
                            Else
                                picFoto.Image = Nothing
                            End If
                        Else
                            picFoto.Image = Nothing
                        End If
                    Else
                        Throw New ApplicationException("Data dosen untuk user ini tidak ditemukan.")
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnEditFoto_Click(sender As Object, e As EventArgs) Handles btnEditFoto.Click
        Dim userId As Integer = CurrentUserId
        If userId <= 0 Then
            MessageBox.Show("User ID tidak valid. Pastikan sudah login.")
            Exit Sub
        End If

        If ofdFoto.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim srcPath As String = ofdFoto.FileName

        Try
            ' 1) Generate key unik
            Dim fotoKey As String = Guid.NewGuid().ToString("N")

            ' 2) Pastikan folder foto ada
            If Not Directory.Exists(FOTO_DIR) Then
                Directory.CreateDirectory(FOTO_DIR)
            End If

            Dim destFileName As String = fotoKey & ".jpg"
            Dim destPath As String = Path.Combine(FOTO_DIR, destFileName)

            ' 3) Convert dan simpan sebagai JPEG
            Using imgSrc As Image = Image.FromFile(srcPath)
                imgSrc.Save(destPath, ImageFormat.Jpeg)
            End Using

            ' 4) URL yang bisa diakses browser (Alias /foto_dosen harus sudah dikonfigurasi)
            Dim fotoUrl As String = "http://localhost/foto_dosen/" & destFileName

            ' 5) Update tabel dosen
            Dim connStr As String = "server=127.0.0.1;user id=root;password=;database=skp_pv;"
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sql As String =
                    "UPDATE dosen " &
                    "SET foto_key = @foto_key, foto_url = @foto_url " &
                    "WHERE user_id = @uid"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@foto_key", fotoKey)
                    cmd.Parameters.AddWithValue("@foto_url", fotoUrl)
                    cmd.Parameters.AddWithValue("@uid", userId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' 6) Tampilkan di PictureBox (pakai folder yang sama)
            Dim imgBytes() As Byte = File.ReadAllBytes(destPath)
            Using ms As New MemoryStream(imgBytes)
                picFoto.Image = Image.FromStream(ms)
            End Using

            MessageBox.Show("Foto berhasil diperbarui.", "Informasi")

        Catch ex As Exception
            MessageBox.Show("Gagal mengubah foto: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

End Class
