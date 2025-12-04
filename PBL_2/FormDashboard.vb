Partial Public Class FormDashboard

    ' ====================================
    '  CONSTRUCTOR
    ' ====================================

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ====================================
    '  FORM LOAD
    ' ====================================

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show($"DEBUG: {CurrentUsername} / {CurrentUserRole}")
        ' Selalu isi dari Session, jangan cek kosong
        lblWelcome.Text = $"Selamat datang, {CurrentUsername}"
        lblUserInfo.Text = $"Role: {CurrentUserRole} | Periode aktif: {CurrentPeriode}"

        SetupRoleAccess()
    End Sub

    ' ====================================
    '  ROLE-BASED ACCESS
    ' ====================================

    Private Sub SetupRoleAccess()
        ' Matikan semua tombol menu dulu
        btnIsiPenilaian.Enabled = False
        btnVerifikasi.Enabled = False
        btnRekap.Enabled = False
        btnMasterData.Enabled = False
        btnLihatNilai.Enabled = False

        Dim roleNorm As String = ""
        If CurrentUserRole IsNot Nothing Then
            roleNorm = CurrentUserRole.Trim().ToLower()
        End If

        Select Case roleNorm
            Case "dosen"
                ' Dosen: Isi Penilaian + Lihat Nilai
                btnIsiPenilaian.Enabled = True
                btnLihatNilai.Enabled = True

            Case "admin"
                ' Admin: Master Data & Pengaturan
                btnMasterData.Enabled = True

            Case "kps", "pimpinan", "kajur"
                ' Pimpinan/KPS/Kajur: Verifikasi + Rekap
                btnVerifikasi.Enabled = True
                btnRekap.Enabled = True

            Case Else
                ' Role lain: belum diberi akses menu apa pun
        End Select
    End Sub

    Private Sub ShowAccessDenied()
        MessageBox.Show("Anda tidak memiliki akses ke menu ini.",
                        "Akses Ditolak",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
    End Sub

    ' ====================================
    '  EVENT HANDLER TOMBOL MENU
    ' ====================================

    ' --- Isi Penilaian Perilaku Dosen (ROLE: DOSEN) ---
    Private Sub btnIsiPenilaian_Click(sender As Object, e As EventArgs) Handles btnIsiPenilaian.Click
        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "dosen" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormPenilaianPerilakuDosen()
        f.ShowDialog()
    End Sub

    ' --- Verifikasi Penilaian (ROLE: PIMPINAN / KPS / KAJUR) ---
    Private Sub btnVerifikasi_Click(sender As Object, e As EventArgs) Handles btnVerifikasi.Click
        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "kps" AndAlso roleNorm <> "pimpinan" AndAlso roleNorm <> "kajur" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormVerifikasiPenilaian()
        f.ShowDialog()
    End Sub

    ' --- Rekap & Monitoring (ROLE: PIMPINAN / KPS / KAJUR) ---
    Private Sub btnRekap_Click(sender As Object, e As EventArgs) Handles btnRekap.Click
        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "kps" AndAlso roleNorm <> "pimpinan" AndAlso roleNorm <> "kajur" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormRekapMonitoring()
        f.ShowDialog()
    End Sub

    ' --- Master Data & Pengaturan (ROLE: ADMIN) ---
    Private Sub btnMasterData_Click(sender As Object, e As EventArgs) Handles btnMasterData.Click
        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "admin" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormMasterDataPengaturan()
        f.ShowDialog()
    End Sub

    ' --- Lihat Nilai (ROLE: DOSEN) ---
    Private Sub btnLihatNilai_Click(sender As Object, e As EventArgs) Handles btnLihatNilai.Click
        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "dosen" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormLihatNilai()
        f.ShowDialog()
    End Sub

    ' --- LOGOUT ---
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Reset Session
        CurrentUserId = 0
        CurrentUsername = ""
        CurrentUserRole = ""

        ' Kembali ke FormLogin
        Dim login As New FormLogin()
        login.Show()
        Me.Close()
    End Sub

End Class
