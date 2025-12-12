<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterData
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        dgvDosen = New DataGridView()
        btnHapusDosen = New Button()
        btnResetDosen = New Button()
        btnSimpanDosen = New Button()
        cboUserLogin = New ComboBox()
        cboPeriodeDosen = New ComboBox()
        txtTelp = New TextBox()
        txtEmail = New TextBox()
        txtProgramStudi = New TextBox()
        txtNamaDosen = New TextBox()
        txtNIP = New TextBox()
        Label15 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblIDDosen = New Label()
        lblUserIdDosen = New Label()
        TabPage2 = New TabPage()
        dgvUser = New DataGridView()
        btnSimpanUser = New Button()
        btnResetUser = New Button()
        btnHapusUser = New Button()
        cboRole = New ComboBox()
        txtNamaLengkap = New TextBox()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        lblUserId = New Label()
        TabPage3 = New TabPage()
        btnHapusPertanyaan = New Button()
        btnResetPertanyaan = New Button()
        btnSimpanPertanyaan = New Button()
        dgvPertanyaan = New DataGridView()
        cboTipeInput = New ComboBox()
        cboTarget = New ComboBox()
        txtPertanyaan = New TextBox()
        txtAspek = New TextBox()
        lblIDPertanyaan = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(dgvDosen, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        CType(dgvUser, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        CType(dgvPertanyaan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'TabControl1
        '
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Margin = New Padding(2, 1, 2, 1)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1075, 580)
        TabControl1.TabIndex = 0
        '
        'TabPage1 - Data Dosen
        '
        TabPage1.BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        TabPage1.Controls.Add(dgvDosen)
        TabPage1.Controls.Add(btnHapusDosen)
        TabPage1.Controls.Add(btnResetDosen)
        TabPage1.Controls.Add(btnSimpanDosen)
        TabPage1.Controls.Add(cboUserLogin)
        TabPage1.Controls.Add(cboPeriodeDosen)
        TabPage1.Controls.Add(txtTelp)
        TabPage1.Controls.Add(txtEmail)
        TabPage1.Controls.Add(txtProgramStudi)
        TabPage1.Controls.Add(txtNamaDosen)
        TabPage1.Controls.Add(txtNIP)
        TabPage1.Controls.Add(Label15)
        TabPage1.Controls.Add(Label14)
        TabPage1.Controls.Add(Label13)
        TabPage1.Controls.Add(Label12)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(Label2)
        TabPage1.Controls.Add(Label1)
        TabPage1.Controls.Add(lblIDDosen)
        TabPage1.Controls.Add(lblUserIdDosen)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Margin = New Padding(2, 1, 2, 1)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(2, 1, 2, 1)
        TabPage1.Size = New Size(1067, 552)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Data Dosen"
        '
        'dgvDosen
        '
        dgvDosen.AllowUserToAddRows = False
        dgvDosen.AllowUserToDeleteRows = False
        dgvDosen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDosen.Dock = DockStyle.Right
        dgvDosen.Location = New Point(459, 1)
        dgvDosen.Margin = New Padding(2, 1, 2, 1)
        dgvDosen.Name = "dgvDosen"
        dgvDosen.ReadOnly = True
        dgvDosen.RowHeadersWidth = 82
        dgvDosen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDosen.Size = New Size(606, 550)
        dgvDosen.TabIndex = 10
        '
        'btnHapusDosen
        '
        btnHapusDosen.BackColor = Color.Salmon
        btnHapusDosen.Location = New Point(30, 493)
        btnHapusDosen.Margin = New Padding(2, 1, 2, 1)
        btnHapusDosen.Name = "btnHapusDosen"
        btnHapusDosen.Size = New Size(104, 39)
        btnHapusDosen.TabIndex = 9
        btnHapusDosen.Text = "Hapus"
        btnHapusDosen.UseVisualStyleBackColor = False
        '
        'btnResetDosen
        '
        btnResetDosen.BackColor = Color.Silver
        btnResetDosen.Location = New Point(167, 493)
        btnResetDosen.Margin = New Padding(2, 1, 2, 1)
        btnResetDosen.Name = "btnResetDosen"
        btnResetDosen.Size = New Size(104, 39)
        btnResetDosen.TabIndex = 8
        btnResetDosen.Text = "Reset"
        btnResetDosen.UseVisualStyleBackColor = False
        '
        'btnSimpanDosen
        '
        btnSimpanDosen.BackColor = Color.LightSkyBlue
        btnSimpanDosen.Location = New Point(307, 493)
        btnSimpanDosen.Margin = New Padding(2, 1, 2, 1)
        btnSimpanDosen.Name = "btnSimpanDosen"
        btnSimpanDosen.Size = New Size(104, 39)
        btnSimpanDosen.TabIndex = 7
        btnSimpanDosen.Text = "Simpan"
        btnSimpanDosen.UseVisualStyleBackColor = False
        '
        'cboUserLogin
        '
        cboUserLogin.DropDownStyle = ComboBoxStyle.DropDownList
        cboUserLogin.FormattingEnabled = True
        cboUserLogin.Location = New Point(176, 255)
        cboUserLogin.Name = "cboUserLogin"
        cboUserLogin.Size = New Size(180, 23)
        cboUserLogin.TabIndex = 6
        '
        'cboPeriodeDosen
        '
        cboPeriodeDosen.DropDownStyle = ComboBoxStyle.DropDownList
        cboPeriodeDosen.FormattingEnabled = True
        cboPeriodeDosen.Location = New Point(176, 215)
        cboPeriodeDosen.Name = "cboPeriodeDosen"
        cboPeriodeDosen.Size = New Size(180, 23)
        cboPeriodeDosen.TabIndex = 5
        '
        'txtTelp
        '
        txtTelp.Location = New Point(176, 175)
        txtTelp.Margin = New Padding(2, 1, 2, 1)
        txtTelp.Name = "txtTelp"
        txtTelp.Size = New Size(180, 23)
        txtTelp.TabIndex = 4
        '
        'txtEmail
        '
        txtEmail.Location = New Point(176, 149)
        txtEmail.Margin = New Padding(2, 1, 2, 1)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(180, 23)
        txtEmail.TabIndex = 3
        '
        'txtProgramStudi
        '
        txtProgramStudi.Location = New Point(176, 123)
        txtProgramStudi.Margin = New Padding(2, 1, 2, 1)
        txtProgramStudi.Name = "txtProgramStudi"
        txtProgramStudi.Size = New Size(180, 23)
        txtProgramStudi.TabIndex = 2
        '
        'txtNamaDosen
        '
        txtNamaDosen.Location = New Point(176, 78)
        txtNamaDosen.Margin = New Padding(2, 1, 2, 1)
        txtNamaDosen.Name = "txtNamaDosen"
        txtNamaDosen.Size = New Size(180, 23)
        txtNamaDosen.TabIndex = 1
        '
        'txtNIP
        '
        txtNIP.Location = New Point(176, 30)
        txtNIP.Margin = New Padding(2, 1, 2, 1)
        txtNIP.Name = "txtNIP"
        txtNIP.Size = New Size(180, 23)
        txtNIP.TabIndex = 0
        '
        'Label15 - User Login
        '
        Label15.AutoSize = True
        Label15.Location = New Point(30, 259)
        Label15.Name = "Label15"
        Label15.Size = New Size(101, 15)
        Label15.TabIndex = 16
        Label15.Text = "User Login/akun"
        '
        'Label14 - Periode
        '
        Label14.AutoSize = True
        Label14.Location = New Point(30, 219)
        Label14.Name = "Label14"
        Label14.Size = New Size(47, 15)
        Label14.TabIndex = 15
        Label14.Text = "Periode"
        '
        'Label13 - Telp
        '
        Label13.AutoSize = True
        Label13.Location = New Point(30, 179)
        Label13.Name = "Label13"
        Label13.Size = New Size(32, 15)
        Label13.TabIndex = 14
        Label13.Text = "Telp"
        '
        'Label12 - Email
        '
        Label12.AutoSize = True
        Label12.Location = New Point(30, 153)
        Label12.Name = "Label12"
        Label12.Size = New Size(36, 15)
        Label12.TabIndex = 13
        Label12.Text = "Email"
        '
        'Label3 - Prodi
        '
        Label3.AutoSize = True
        Label3.Location = New Point(30, 127)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 15)
        Label3.TabIndex = 3
        Label3.Text = "Program Studi"
        '
        'Label2 - Nama Dosen
        '
        Label2.AutoSize = True
        Label2.Location = New Point(30, 82)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 15)
        Label2.TabIndex = 2
        Label2.Text = "Nama Lengkap Dosen"
        '
        'Label1 - NIP
        '
        Label1.AutoSize = True
        Label1.Location = New Point(30, 33)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(26, 15)
        Label1.TabIndex = 0
        Label1.Text = "NIP"
        '
        'lblIDDosen
        '
        lblIDDosen.AutoSize = True
        lblIDDosen.Location = New Point(30, 300)
        lblIDDosen.Name = "lblIDDosen"
        lblIDDosen.Size = New Size(13, 15)
        lblIDDosen.TabIndex = 17
        lblIDDosen.Text = "0"
        lblIDDosen.Visible = False
        '
        'lblUserIdDosen
        '
        lblUserIdDosen.AutoSize = True
        lblUserIdDosen.Location = New Point(80, 300)
        lblUserIdDosen.Name = "lblUserIdDosen"
        lblUserIdDosen.Size = New Size(13, 15)
        lblUserIdDosen.TabIndex = 18
        lblUserIdDosen.Text = "0"
        lblUserIdDosen.Visible = False
        '
        'TabPage2 - Data User
        '
        TabPage2.BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        TabPage2.Controls.Add(dgvUser)
        TabPage2.Controls.Add(btnSimpanUser)
        TabPage2.Controls.Add(btnResetUser)
        TabPage2.Controls.Add(btnHapusUser)
        TabPage2.Controls.Add(cboRole)
        TabPage2.Controls.Add(txtNamaLengkap)
        TabPage2.Controls.Add(txtPassword)
        TabPage2.Controls.Add(txtUsername)
        TabPage2.Controls.Add(Label7)
        TabPage2.Controls.Add(Label6)
        TabPage2.Controls.Add(Label5)
        TabPage2.Controls.Add(Label4)
        TabPage2.Controls.Add(lblUserId)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Margin = New Padding(2, 1, 2, 1)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(2, 1, 2, 1)
        TabPage2.Size = New Size(1067, 552)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Data User"
        '
        'dgvUser
        '
        dgvUser.AllowUserToAddRows = False
        dgvUser.AllowUserToDeleteRows = False
        dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUser.Dock = DockStyle.Right
        dgvUser.Location = New Point(469, 1)
        dgvUser.Margin = New Padding(2, 1, 2, 1)
        dgvUser.Name = "dgvUser"
        dgvUser.ReadOnly = True
        dgvUser.RowHeadersWidth = 82
        dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUser.Size = New Size(596, 550)
        dgvUser.TabIndex = 13
        '
        'btnSimpanUser
        '
        btnSimpanUser.BackColor = Color.LightSkyBlue
        btnSimpanUser.Location = New Point(275, 488)
        btnSimpanUser.Margin = New Padding(2, 1, 2, 1)
        btnSimpanUser.Name = "btnSimpanUser"
        btnSimpanUser.Size = New Size(104, 39)
        btnSimpanUser.TabIndex = 12
        btnSimpanUser.Text = "Simpan"
        btnSimpanUser.UseVisualStyleBackColor = False
        '
        'btnResetUser
        '
        btnResetUser.BackColor = Color.Silver
        btnResetUser.Location = New Point(144, 488)
        btnResetUser.Margin = New Padding(2, 1, 2, 1)
        btnResetUser.Name = "btnResetUser"
        btnResetUser.Size = New Size(104, 39)
        btnResetUser.TabIndex = 11
        btnResetUser.Text = "Reset"
        btnResetUser.UseVisualStyleBackColor = False
        '
        'btnHapusUser
        '
        btnHapusUser.BackColor = Color.Salmon
        btnHapusUser.Location = New Point(18, 488)
        btnHapusUser.Margin = New Padding(2, 1, 2, 1)
        btnHapusUser.Name = "btnHapusUser"
        btnHapusUser.Size = New Size(104, 39)
        btnHapusUser.TabIndex = 10
        btnHapusUser.Text = "Hapus"
        btnHapusUser.UseVisualStyleBackColor = False
        '
        'cboRole
        '
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(164, 202)
        cboRole.Margin = New Padding(2, 1, 2, 1)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(194, 23)
        cboRole.TabIndex = 7
        '
        'txtNamaLengkap
        '
        txtNamaLengkap.Location = New Point(164, 144)
        txtNamaLengkap.Margin = New Padding(2, 1, 2, 1)
        txtNamaLengkap.Name = "txtNamaLengkap"
        txtNamaLengkap.Size = New Size(194, 23)
        txtNamaLengkap.TabIndex = 6
        '
        'txtPassword
        '
        txtPassword.Location = New Point(164, 80)
        txtPassword.Margin = New Padding(2, 1, 2, 1)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(194, 23)
        txtPassword.TabIndex = 5
        '
        'txtUsername
        '
        txtUsername.Location = New Point(164, 26)
        txtUsername.Margin = New Padding(2, 1, 2, 1)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(194, 23)
        txtUsername.TabIndex = 4
        '
        'Label7 - Role
        '
        Label7.AutoSize = True
        Label7.Location = New Point(29, 205)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(75, 15)
        Label7.TabIndex = 3
        Label7.Text = "Role/Jabatan"
        '
        'Label6 - Nama Lengkap
        '
        Label6.AutoSize = True
        Label6.Location = New Point(29, 147)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 15)
        Label6.TabIndex = 2
        Label6.Text = "Nama Lengkap"
        '
        'Label5 - Password
        '
        Label5.AutoSize = True
        Label5.Location = New Point(29, 83)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(57, 15)
        Label5.TabIndex = 1
        Label5.Text = "Password"
        '
        'Label4 - Username
        '
        Label4.AutoSize = True
        Label4.Location = New Point(29, 30)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 15)
        Label4.TabIndex = 0
        Label4.Text = "Username"
        '
        'lblUserId
        '
        lblUserId.AutoSize = True
        lblUserId.Location = New Point(29, 241)
        lblUserId.Name = "lblUserId"
        lblUserId.Size = New Size(13, 15)
        lblUserId.TabIndex = 14
        lblUserId.Text = "0"
        lblUserId.Visible = False
        '
        'TabPage3 - Data Pertanyaan
        '
        TabPage3.BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        TabPage3.Controls.Add(btnHapusPertanyaan)
        TabPage3.Controls.Add(btnResetPertanyaan)
        TabPage3.Controls.Add(btnSimpanPertanyaan)
        TabPage3.Controls.Add(dgvPertanyaan)
        TabPage3.Controls.Add(cboTipeInput)
        TabPage3.Controls.Add(cboTarget)
        TabPage3.Controls.Add(txtPertanyaan)
        TabPage3.Controls.Add(txtAspek)
        TabPage3.Controls.Add(lblIDPertanyaan)
        TabPage3.Controls.Add(Label11)
        TabPage3.Controls.Add(Label10)
        TabPage3.Controls.Add(Label9)
        TabPage3.Controls.Add(Label8)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Margin = New Padding(2, 1, 2, 1)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(1067, 552)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Data Pertanyaan"
        '
        'btnHapusPertanyaan
        '
        btnHapusPertanyaan.BackColor = Color.Salmon
        btnHapusPertanyaan.Location = New Point(26, 499)
        btnHapusPertanyaan.Margin = New Padding(2, 1, 2, 1)
        btnHapusPertanyaan.Name = "btnHapusPertanyaan"
        btnHapusPertanyaan.Size = New Size(104, 39)
        btnHapusPertanyaan.TabIndex = 15
        btnHapusPertanyaan.Text = "Hapus"
        btnHapusPertanyaan.UseVisualStyleBackColor = False
        '
        'btnResetPertanyaan
        '
        btnResetPertanyaan.BackColor = Color.Silver
        btnResetPertanyaan.Location = New Point(162, 499)
        btnResetPertanyaan.Margin = New Padding(2, 1, 2, 1)
        btnResetPertanyaan.Name = "btnResetPertanyaan"
        btnResetPertanyaan.Size = New Size(104, 39)
        btnResetPertanyaan.TabIndex = 14
        btnResetPertanyaan.Text = "Reset"
        btnResetPertanyaan.UseVisualStyleBackColor = False
        '
        'btnSimpanPertanyaan
        '
        btnSimpanPertanyaan.BackColor = Color.LightSkyBlue
        btnSimpanPertanyaan.Location = New Point(299, 499)
        btnSimpanPertanyaan.Margin = New Padding(2, 1, 2, 1)
        btnSimpanPertanyaan.Name = "btnSimpanPertanyaan"
        btnSimpanPertanyaan.Size = New Size(104, 39)
        btnSimpanPertanyaan.TabIndex = 13
        btnSimpanPertanyaan.Text = "Simpan"
        btnSimpanPertanyaan.UseVisualStyleBackColor = False
        '
        'dgvPertanyaan
        '
        dgvPertanyaan.AllowUserToAddRows = False
        dgvPertanyaan.AllowUserToDeleteRows = False
        dgvPertanyaan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPertanyaan.Dock = DockStyle.Right
        dgvPertanyaan.Location = New Point(495, 0)
        dgvPertanyaan.Margin = New Padding(2, 1, 2, 1)
        dgvPertanyaan.Name = "dgvPertanyaan"
        dgvPertanyaan.ReadOnly = True
        dgvPertanyaan.RowHeadersWidth = 82
        dgvPertanyaan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPertanyaan.Size = New Size(572, 552)
        dgvPertanyaan.TabIndex = 9
        '
        'cboTipeInput
        '
        cboTipeInput.DropDownStyle = ComboBoxStyle.DropDownList
        cboTipeInput.FormattingEnabled = True
        cboTipeInput.Location = New Point(156, 168)
        cboTipeInput.Margin = New Padding(2, 1, 2, 1)
        cboTipeInput.Name = "cboTipeInput"
        cboTipeInput.Size = New Size(251, 23)
        cboTipeInput.TabIndex = 8
        '
        'cboTarget
        '
        cboTarget.DropDownStyle = ComboBoxStyle.DropDownList
        cboTarget.FormattingEnabled = True
        cboTarget.Location = New Point(156, 128)
        cboTarget.Margin = New Padding(2, 1, 2, 1)
        cboTarget.Name = "cboTarget"
        cboTarget.Size = New Size(250, 23)
        cboTarget.TabIndex = 7
        '
        'txtPertanyaan
        '
        txtPertanyaan.Location = New Point(156, 68)
        txtPertanyaan.Margin = New Padding(2, 1, 2, 1)
        txtPertanyaan.Multiline = True
        txtPertanyaan.Name = "txtPertanyaan"
        txtPertanyaan.Size = New Size(250, 45)
        txtPertanyaan.TabIndex = 6
        '
        'txtAspek
        '
        txtAspek.Location = New Point(156, 27)
        txtAspek.Margin = New Padding(2, 1, 2, 1)
        txtAspek.Name = "txtAspek"
        txtAspek.Size = New Size(250, 23)
        txtAspek.TabIndex = 5
        '
        'lblIDPertanyaan
        '
        lblIDPertanyaan.AutoSize = True
        lblIDPertanyaan.Location = New Point(26, 210)
        lblIDPertanyaan.Margin = New Padding(2, 0, 2, 0)
        lblIDPertanyaan.Name = "lblIDPertanyaan"
        lblIDPertanyaan.Size = New Size(13, 15)
        lblIDPertanyaan.TabIndex = 4
        lblIDPertanyaan.Text = "0"
        lblIDPertanyaan.Visible = False
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New Point(26, 171)
        Label11.Margin = New Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(88, 15)
        Label11.TabIndex = 3
        Label11.Text = "Tipe Input/Skor"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New Point(26, 131)
        Label10.Margin = New Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(65, 15)
        Label10.TabIndex = 2
        Label10.Text = "Target Role"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New Point(26, 69)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(66, 15)
        Label9.TabIndex = 1
        Label9.Text = "Pertanyaan"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New Point(26, 30)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(90, 15)
        Label8.TabIndex = 0
        Label8.Text = "Aspek Penilaian"
        '
        'FormMasterData
        '
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        ClientSize = New Size(1075, 580)
        Controls.Add(TabControl1)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FormMasterData"
        Text = "FormMasterData"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        CType(dgvDosen, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(dgvUser, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        CType(dgvPertanyaan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage

    ' Data Dosen
    Friend WithEvents txtNamaDosen As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNIP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProgramStudi As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTelp As TextBox
    Friend WithEvents cboPeriodeDosen As ComboBox
    Friend WithEvents cboUserLogin As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents dgvDosen As DataGridView
    Friend WithEvents btnHapusDosen As Button
    Friend WithEvents btnResetDosen As Button
    Friend WithEvents btnSimpanDosen As Button
    Friend WithEvents lblIDDosen As Label
    Friend WithEvents lblUserIdDosen As Label

    ' Data User
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnHapusUser As Button
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents txtNamaLengkap As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents dgvUser As DataGridView
    Friend WithEvents btnSimpanUser As Button
    Friend WithEvents btnResetUser As Button
    Friend WithEvents lblUserId As Label

    ' Data Pertanyaan
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents lblIDPertanyaan As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPertanyaan As TextBox
    Friend WithEvents txtAspek As TextBox
    Friend WithEvents cboTipeInput As ComboBox
    Friend WithEvents cboTarget As ComboBox
    Friend WithEvents btnResetPertanyaan As Button
    Friend WithEvents btnSimpanPertanyaan As Button
    Friend WithEvents dgvPertanyaan As DataGridView
    Friend WithEvents btnHapusPertanyaan As Button
End Class
