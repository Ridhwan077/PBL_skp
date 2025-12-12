<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlTop = New Panel()
        lblSubtitle = New Label()
        lblUserInfo = New Label()
        lblWelcome = New Label()
        pnlButtons = New Panel()
        btnLihatNilai = New Button()
        btnLogout = New Button()
        btnMasterData = New Button()
        btnRekap = New Button()
        btnVerifikasi = New Button()
        btnIsiPenilaian = New Button()
        btnProfile = New Button()
        pnlTop.SuspendLayout()
        pnlButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTop
        ' 
        pnlTop.BackColor = Color.FromArgb(CByte(109), CByte(148), CByte(197))
        pnlTop.Controls.Add(lblSubtitle)
        pnlTop.Controls.Add(lblUserInfo)
        pnlTop.Controls.Add(lblWelcome)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(0, 0)
        pnlTop.Margin = New Padding(3, 2, 3, 2)
        pnlTop.Name = "pnlTop"
        pnlTop.Padding = New Padding(21, 12, 21, 12)
        pnlTop.Size = New Size(795, 68)
        pnlTop.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSubtitle.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(230), CByte(237), CByte(247))
        lblSubtitle.Location = New Point(411, 36)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(364, 18)
        lblSubtitle.TabIndex = 3
        lblSubtitle.Text = "Kelola penilaian perilaku dosen dengan mudah dan terpusat"
        lblSubtitle.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.AutoSize = True
        lblUserInfo.Font = New Font("Segoe UI", 9F)
        lblUserInfo.ForeColor = Color.Gainsboro
        lblUserInfo.Location = New Point(23, 39)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(202, 15)
        lblUserInfo.TabIndex = 2
        lblUserInfo.Text = "Role: [Role]  |  Periode aktif: [Periode]"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.White
        lblWelcome.Location = New Point(21, 14)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(220, 25)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Selamat datang, [Nama]"
        ' 
        ' pnlButtons
        ' 
        pnlButtons.BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        pnlButtons.Controls.Add(btnProfile)
        pnlButtons.Controls.Add(btnLihatNilai)
        pnlButtons.Controls.Add(btnLogout)
        pnlButtons.Controls.Add(btnMasterData)
        pnlButtons.Controls.Add(btnRekap)
        pnlButtons.Controls.Add(btnVerifikasi)
        pnlButtons.Controls.Add(btnIsiPenilaian)
        pnlButtons.Dock = DockStyle.Fill
        pnlButtons.Location = New Point(0, 68)
        pnlButtons.Margin = New Padding(3, 2, 3, 2)
        pnlButtons.Name = "pnlButtons"
        pnlButtons.Padding = New Padding(35, 30, 35, 22)
        pnlButtons.Size = New Size(795, 307)
        pnlButtons.TabIndex = 1
        ' 
        ' btnLihatNilai
        ' 
        btnLihatNilai.BackColor = Color.White
        btnLihatNilai.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnLihatNilai.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnLihatNilai.FlatStyle = FlatStyle.Flat
        btnLihatNilai.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnLihatNilai.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnLihatNilai.Location = New Point(289, 128)
        btnLihatNilai.Margin = New Padding(3, 2, 3, 2)
        btnLihatNilai.Name = "btnLihatNilai"
        btnLihatNilai.Size = New Size(210, 60)
        btnLihatNilai.TabIndex = 5
        btnLihatNilai.Text = "Lihat Nilai"
        btnLihatNilai.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnLogout.BackColor = Color.White
        btnLogout.FlatAppearance.BorderColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(255), CByte(235), CByte(238))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 9F)
        btnLogout.ForeColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnLogout.Location = New Point(559, 239)
        btnLogout.Margin = New Padding(3, 2, 3, 2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(184, 30)
        btnLogout.TabIndex = 4
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnMasterData
        ' 
        btnMasterData.BackColor = Color.White
        btnMasterData.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnMasterData.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnMasterData.FlatStyle = FlatStyle.Flat
        btnMasterData.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnMasterData.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnMasterData.Location = New Point(53, 128)
        btnMasterData.Margin = New Padding(3, 2, 3, 2)
        btnMasterData.Name = "btnMasterData"
        btnMasterData.Size = New Size(210, 60)
        btnMasterData.TabIndex = 3
        btnMasterData.Text = "Master Data && Pengaturan (Admin)"
        btnMasterData.UseVisualStyleBackColor = False
        ' 
        ' btnRekap
        ' 
        btnRekap.BackColor = Color.White
        btnRekap.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnRekap.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnRekap.FlatStyle = FlatStyle.Flat
        btnRekap.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnRekap.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnRekap.Location = New Point(525, 45)
        btnRekap.Margin = New Padding(3, 2, 3, 2)
        btnRekap.Name = "btnRekap"
        btnRekap.Size = New Size(210, 60)
        btnRekap.TabIndex = 2
        btnRekap.Text = "Rekap && Monitoring "
        btnRekap.UseVisualStyleBackColor = False
        ' 
        ' btnVerifikasi
        ' 
        btnVerifikasi.BackColor = Color.White
        btnVerifikasi.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnVerifikasi.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnVerifikasi.FlatStyle = FlatStyle.Flat
        btnVerifikasi.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnVerifikasi.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnVerifikasi.Location = New Point(289, 45)
        btnVerifikasi.Margin = New Padding(3, 2, 3, 2)
        btnVerifikasi.Name = "btnVerifikasi"
        btnVerifikasi.Size = New Size(210, 60)
        btnVerifikasi.TabIndex = 1
        btnVerifikasi.Text = "Verifikasi Penilaian"
        btnVerifikasi.UseVisualStyleBackColor = False
        ' 
        ' btnIsiPenilaian
        ' 
        btnIsiPenilaian.BackColor = Color.White
        btnIsiPenilaian.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnIsiPenilaian.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnIsiPenilaian.FlatStyle = FlatStyle.Flat
        btnIsiPenilaian.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnIsiPenilaian.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnIsiPenilaian.Location = New Point(53, 45)
        btnIsiPenilaian.Margin = New Padding(3, 2, 3, 2)
        btnIsiPenilaian.Name = "btnIsiPenilaian"
        btnIsiPenilaian.Size = New Size(210, 60)
        btnIsiPenilaian.TabIndex = 0
        btnIsiPenilaian.Text = "Isi Penilaian Perilaku Dosen"
        btnIsiPenilaian.UseVisualStyleBackColor = False
        ' 
        ' btnProfile
        ' 
        btnProfile.BackColor = Color.White
        btnProfile.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(203), CByte(220), CByte(235))
        btnProfile.FlatStyle = FlatStyle.Flat
        btnProfile.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnProfile.ForeColor = Color.FromArgb(CByte(25), CByte(59), CByte(104))
        btnProfile.Location = New Point(525, 128)
        btnProfile.Margin = New Padding(3, 2, 3, 2)
        btnProfile.Name = "btnProfile"
        btnProfile.Size = New Size(210, 60)
        btnProfile.TabIndex = 6
        btnProfile.Text = "Edit Profile"
        btnProfile.UseVisualStyleBackColor = False
        ' 
        ' FormDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(238), CByte(230))
        ClientSize = New Size(795, 375)
        Controls.Add(pnlButtons)
        Controls.Add(pnlTop)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "FormDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard - Sistem Penilaian Perilaku Dosen"
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        pnlButtons.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnIsiPenilaian As System.Windows.Forms.Button
    Friend WithEvents btnVerifikasi As System.Windows.Forms.Button
    Friend WithEvents btnRekap As System.Windows.Forms.Button
    Friend WithEvents btnMasterData As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnLihatNilai As Button
    Friend WithEvents btnProfile As Button

End Class
