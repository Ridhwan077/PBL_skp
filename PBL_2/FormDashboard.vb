Public Class FormDashboard

    Private _namaUser As String
    Private _roleUser As String
    Private _periodeAktif As String


    Public Sub New(nama As String, role As String, periode As String)
        ' Method ini wajib ada untuk inisialisasi desain
        InitializeComponent()

        ' Simpan data ke variabel
        _namaUser = nama
        _roleUser = role
        _periodeAktif = periode

        ' Jalankan pengaturan tampilan
        AturTampilan()
    End Sub

    Private Sub AturTampilan()
        ' 1. UBAH TEKS HEADER
        lblWelcome.Text = "Selamat datang, " & _namaUser
        lblUserInfo.Text = "Role: " & _roleUser & " | Periode aktif: " & _periodeAktif

        ' 2. MATIKAN SEMUA TOMBOL DULU (Default)
        btnIsiPenilaian.Enabled = False
        btnVerifikasi.Enabled = False
        btnRekap.Enabled = False
        btnMasterData.Enabled = False
        btnLihatNilai.Enabled = False

        ' 3. NYALAKAN SESUAI ROLE
        Select Case _roleUser
            Case "Admin"
                ' Admin: Bisa segalanya (Master Data, Rekap, dan SEKARANG bisa Isi Penilaian)
                btnMasterData.Enabled = True
                btnRekap.Enabled = True
                btnIsiPenilaian.Enabled = True ' <--- Admin juga bisa ngisi

            Case "Dosen", "Tendik"
                ' Dosen: Hanya bisa isi penilaian
                btnIsiPenilaian.Enabled = True
                btnLihatNilai.Enabled = True

            Case "KPS", "Kaprodi"
                ' KPS: Bisa Verifikasi, Lihat nilai, dan bisa Isi Penilaian
                btnLihatNilai.Enabled = True
                btnVerifikasi.Enabled = True
                btnIsiPenilaian.Enabled = True ' <--- KPS juga bisa ngisi

            Case "Kajur"
                ' Kajur: Hanya validasi nilai di rekap & monitoring
                btnRekap.Enabled = True
                btnLihatNilai.Enabled = True

            Case Else
                MessageBox.Show("Role tidak dikenali.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim tanya = MessageBox.Show("Yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanya = DialogResult.Yes Then
            Dim formLogin As New FormLogin()
            formLogin.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub btnIsiPenilaian_Click(sender As Object, e As EventArgs) Handles btnIsiPenilaian.Click
        Dim formNilai As New FormPenilaianPerilakuDosen(_roleUser, _namaUser)
        formNilai.ShowDialog()
    End Sub

    Private Sub btnVerifikasi_Click(sender As Object, e As EventArgs) Handles btnVerifikasi.Click
        FormVerifikasiPenilaian.Show()
        Me.Close()
    End Sub

    Private Sub pnlButtons_Paint(sender As Object, e As PaintEventArgs) Handles pnlButtons.Paint

    End Sub

    Private Sub btnRekap_Click(sender As Object, e As EventArgs) Handles btnRekap.Click
        Dim frm As New FormRekap()
        frm.ShowDialog()
    End Sub
End Class