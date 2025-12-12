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
        ' Sembunyikan semua tombol menu dulu
        btnIsiPenilaian.Visible = False
        btnVerifikasi.Visible = False
        btnRekap.Visible = False
        btnMasterData.Visible = False
        btnLihatNilai.Visible = False

        Dim roleNorm As String = ""
        If Not String.IsNullOrWhiteSpace(CurrentUserRole) Then
            roleNorm = CurrentUserRole.Trim().ToLower()
        End If

        Select Case roleNorm
            Case "dosen"
                ' Dosen: isi penilaian + lihat nilai
                btnIsiPenilaian.Visible = True
                btnLihatNilai.Visible = True
                btnProfile.Visible = True

            Case "admin"
                ' Admin: boleh isi penilaian (misal bantu input) + master data
                btnIsiPenilaian.Visible = True
                btnMasterData.Visible = True

            Case "kps"
                ' KPS: boleh isi penilaian + verifikasi + rekap
                btnIsiPenilaian.Visible = True
                'btnVerifikasi.Visible = True
                btnRekap.Visible = True

            Case "pimpinan", "kajur"
                ' Pimpinan / Kajur: verifikasi + rekap
                btnVerifikasi.Visible = True
                btnRekap.Visible = True

            Case Else
                ' Role lain: tidak ada akses menu
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

    ' --- Isi Penilaian Perilaku Dosen (ROLE: DOSEN/ADMIN/KPS) ---
    Private Sub btnIsiPenilaian_Click(sender As Object, e As EventArgs) Handles btnIsiPenilaian.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        ' izinkan: dosen, admin, kps
        If Not (roleNorm = "dosen" OrElse
                roleNorm = "admin" OrElse
                roleNorm = "kps") Then

            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormPenilaianPerilakuDosen()
        f.ShowDialog()
    End Sub

    ' --- Verifikasi Penilaian (ROLE: PIMPINAN / KPS / KAJUR) ---
    Private Sub btnVerifikasi_Click(sender As Object, e As EventArgs) Handles btnVerifikasi.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

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
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "kps" AndAlso roleNorm <> "pimpinan" AndAlso roleNorm <> "kajur" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormRekap()
        f.ShowDialog()
    End Sub

    ' --- Master Data & Pengaturan (ROLE: ADMIN) ---
    Private Sub btnMasterData_Click(sender As Object, e As EventArgs) Handles btnMasterData.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        If roleNorm <> "admin" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormMasterData()
        f.ShowDialog()
    End Sub

    ' --- Lihat Nilai (ROLE: DOSEN) ---
    Private Sub btnLihatNilai_Click(sender As Object, e As EventArgs) Handles btnLihatNilai.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm = CurrentUserRole.Trim.ToLower

        If roleNorm <> "dosen" Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormLihatNilai
        f.ShowDialog()
    End Sub

    ' --- Profile User (ROLE: DOSEN) ---
    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If
        Dim roleNorm = CurrentUserRole.Trim.ToLower
        If roleNorm <> "dosen" Then
            ShowAccessDenied()
            Exit Sub
        End If
        Dim f As New FormProfilDosen()
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
