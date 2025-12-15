Partial Public Class FormDashboard

    ' ====================================
    '  CONSTRUCTOR
    ' ====================================

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ====================================
    '  HELPER: DAFTAR SEMUA TOMBOL MENU
    ' ====================================

    Private ReadOnly Property MenuButtons As Button()
        Get
            Return New Button() {
                btnIsiPenilaian,
                btnVerifikasi,
                btnRekap,
                btnMasterData,
                btnLihatNilai,
                btnProfile
            }
        End Get
    End Property

    ' ====================================
    '  FORM LOAD
    ' ====================================

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' DEBUG: bisa kamu matikan kalau sudah yakin
        'MessageBox.Show($"DEBUG: {CurrentUsername} / {CurrentUserRole}")

        lblWelcome.Text = $"Selamat datang, {CurrentUsername}"
        lblUserInfo.Text = $"Role: {CurrentUserRole} | Periode aktif: {CurrentPeriode}"

        SetupRoleAccess()
    End Sub

    ' Kalau panel menu di-resize (atau form di-resize) → tata ulang posisi tombol
    Private Sub pnlButtons_Resize(sender As Object, e As EventArgs) Handles pnlButtons.Resize
        RefreshMenuLayout()
    End Sub

    ' ====================================
    '  ROLE-BASED ACCESS
    ' ====================================

    Private Sub SetupRoleAccess()
        ' Sembunyikan semua tombol dulu
        For Each btn In MenuButtons
            btn.Visible = False
        Next

        Dim role As String = If(CurrentUserRole, "").Trim().ToLower()

        Select Case role
            Case "dosen"
                btnIsiPenilaian.Visible = True
                btnLihatNilai.Visible = True
                btnProfile.Visible = True

            Case "admin"
                btnVerifikasi.Visible = True
                btnRekap.Visible = True
                btnMasterData.Visible = True
                btnLihatNilai.Visible = True
                btnProfile.Visible = True

            Case "kps"
                btnVerifikasi.Visible = True
                btnRekap.Visible = True
                btnLihatNilai.Visible = True
                btnProfile.Visible = True

            Case "pimpinan", "kajur"
                btnVerifikasi.Visible = True
                btnRekap.Visible = True
                btnLihatNilai.Visible = True

            Case Else
                ' fallback: minimal lihat nilai + profile
                btnLihatNilai.Visible = True
                btnProfile.Visible = True
        End Select

        ' Setelah visible di-set → rapikan tata letak
        RefreshMenuLayout()
    End Sub

    ' ====================================
    '  LAYOUT MENU DINAMIS (GRID 3 KOLOM)
    ' ====================================

    Private Sub RefreshMenuLayout()
        ' Panel tempat semua button berada
        Dim host As Control = pnlButtons   ' ganti jika nama panel lain

        If host Is Nothing Then Return

        ' Ambil hanya tombol yang Visible
        Dim visibleButtons As New List(Of Button)()
        For Each btn In MenuButtons
            If btn.Visible Then
                visibleButtons.Add(btn)
            End If
        Next

        If visibleButtons.Count = 0 Then Return

        ' Setting grid
        Dim cols As Integer = 3                ' maksimal 3 kolom
        Dim btnW As Integer = visibleButtons(0).Width
        Dim btnH As Integer = visibleButtons(0).Height
        Dim hGap As Integer = 40               ' jarak horizontal antar tombol
        Dim vGap As Integer = 25               ' jarak vertikal antar baris

        Dim colsUsed As Integer = Math.Min(cols, visibleButtons.Count)
        Dim rows As Integer = CInt(Math.Ceiling(visibleButtons.Count / CDbl(cols)))

        Dim totalW As Integer = colsUsed * btnW + (colsUsed - 1) * hGap
        Dim totalH As Integer = rows * btnH + (rows - 1) * vGap

        ' Posisi awal supaya grid berada di tengah panel
        Dim startX As Integer = (host.ClientSize.Width - totalW) \ 2
        Dim startY As Integer = (host.ClientSize.Height - totalH) \ 2

        ' Atur posisi setiap tombol visible ke layout grid
        For i As Integer = 0 To visibleButtons.Count - 1
            Dim r As Integer = i \ cols
            Dim c As Integer = i Mod cols

            visibleButtons(i).Left = startX + c * (btnW + hGap)
            visibleButtons(i).Top = startY + r * (btnH + vGap)
        Next
    End Sub

    ' ====================================
    '  UTIL
    ' ====================================

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

        If Not (roleNorm = "dosen" OrElse roleNorm = "admin" OrElse roleNorm = "kps") Then
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

        If roleNorm <> "kps" AndAlso roleNorm <> "pimpinan" AndAlso roleNorm <> "kajur" AndAlso roleNorm <> "admin" Then
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

        If roleNorm <> "kps" AndAlso roleNorm <> "pimpinan" AndAlso roleNorm <> "kajur" AndAlso roleNorm <> "admin" Then
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

    ' --- Lihat Nilai (ROLE: DOSEN, KPS, PIMPINAN, KAJUR) ---
    Private Sub btnLihatNilai_Click(sender As Object, e As EventArgs) Handles btnLihatNilai.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

        ' Kalau mau yang lain juga bisa lihat, tambahkan di sini
        If Not (roleNorm = "dosen" OrElse roleNorm = "kps" OrElse roleNorm = "pimpinan" OrElse roleNorm = "kajur" OrElse roleNorm = "admin") Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim f As New FormLihatNilai()
        f.ShowDialog()
    End Sub

    ' --- Profile User (ROLE: DOSEN) ---
    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        If String.IsNullOrWhiteSpace(CurrentUserRole) Then
            ShowAccessDenied()
            Exit Sub
        End If

        Dim roleNorm As String = CurrentUserRole.Trim().ToLower()

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
