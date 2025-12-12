Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProfilDosen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        grpIdentitas = New GroupBox()
        lblProdiValue = New Label()
        lblNamaValue = New Label()
        lblNipValue = New Label()
        lblProdi = New Label()
        lblNama = New Label()
        lblNip = New Label()
        picFoto = New PictureBox()
        btnTutup = New Button()
        btnEditFoto = New Button()
        ofdFoto = New OpenFileDialog()
        pnlHeader.SuspendLayout()
        grpIdentitas.SuspendLayout()
        CType(picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(112), CByte(148), CByte(194))
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(640, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold)
        lblTitle.Location = New Point(24, 24)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(177, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "PROFIL DOSEN"
        ' 
        ' grpIdentitas
        ' 
        grpIdentitas.Controls.Add(lblProdiValue)
        grpIdentitas.Controls.Add(lblNamaValue)
        grpIdentitas.Controls.Add(lblNipValue)
        grpIdentitas.Controls.Add(lblProdi)
        grpIdentitas.Controls.Add(lblNama)
        grpIdentitas.Controls.Add(lblNip)
        grpIdentitas.Location = New Point(24, 100)
        grpIdentitas.Name = "grpIdentitas"
        grpIdentitas.Size = New Size(360, 170)
        grpIdentitas.TabIndex = 1
        grpIdentitas.TabStop = False
        grpIdentitas.Text = "Identitas Dosen"
        ' 
        ' lblProdiValue
        ' 
        lblProdiValue.AutoSize = True
        lblProdiValue.Location = New Point(137, 116)
        lblProdiValue.Name = "lblProdiValue"
        lblProdiValue.Size = New Size(16, 15)
        lblProdiValue.TabIndex = 5
        lblProdiValue.Text = "TI"
        ' 
        ' lblNamaValue
        ' 
        lblNamaValue.AutoSize = True
        lblNamaValue.Location = New Point(137, 79)
        lblNamaValue.Name = "lblNamaValue"
        lblNamaValue.Size = New Size(75, 15)
        lblNamaValue.TabIndex = 4
        lblNamaValue.Text = "Nama Dosen"
        ' 
        ' lblNipValue
        ' 
        lblNipValue.AutoSize = True
        lblNipValue.Location = New Point(137, 42)
        lblNipValue.Name = "lblNipValue"
        lblNipValue.Size = New Size(35, 15)
        lblNipValue.TabIndex = 3
        lblNipValue.Text = "NIP..."
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Location = New Point(24, 116)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New Size(89, 15)
        lblProdi.TabIndex = 2
        lblProdi.Text = "Program Studi :"
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(24, 79)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(45, 15)
        lblNama.TabIndex = 1
        lblNama.Text = "Nama :"
        ' 
        ' lblNip
        ' 
        lblNip.AutoSize = True
        lblNip.Location = New Point(24, 42)
        lblNip.Name = "lblNip"
        lblNip.Size = New Size(32, 15)
        lblNip.TabIndex = 0
        lblNip.Text = "NIP :"
        ' 
        ' picFoto
        ' 
        picFoto.BorderStyle = BorderStyle.FixedSingle
        picFoto.Location = New Point(420, 100)
        picFoto.Name = "picFoto"
        picFoto.Size = New Size(180, 180)
        picFoto.SizeMode = PictureBoxSizeMode.Zoom
        picFoto.TabIndex = 2
        picFoto.TabStop = False
        ' 
        ' btnTutup
        ' 
        btnTutup.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnTutup.Location = New Point(520, 304)
        btnTutup.Name = "btnTutup"
        btnTutup.Size = New Size(80, 30)
        btnTutup.TabIndex = 3
        btnTutup.Text = "Tutup"
        btnTutup.UseVisualStyleBackColor = True
        ' 
        ' btnEditFoto
        ' 
        btnEditFoto.Location = New Point(420, 304)
        btnEditFoto.Name = "btnEditFoto"
        btnEditFoto.Size = New Size(90, 30)
        btnEditFoto.TabIndex = 4
        btnEditFoto.Text = "Ganti Foto..."
        btnEditFoto.UseVisualStyleBackColor = True
        ' 
        ' ofdFoto
        ' 
        ofdFoto.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*"
        ' 
        ' FormProfilDosen
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        ClientSize = New Size(640, 350)
        Controls.Add(btnEditFoto)
        Controls.Add(btnTutup)
        Controls.Add(picFoto)
        Controls.Add(grpIdentitas)
        Controls.Add(pnlHeader)
        Name = "FormProfilDosen"
        Text = "Profil Dosen"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        grpIdentitas.ResumeLayout(False)
        grpIdentitas.PerformLayout()
        CType(picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents grpIdentitas As GroupBox
    Friend WithEvents lblProdiValue As Label
    Friend WithEvents lblNamaValue As Label
    Friend WithEvents lblNipValue As Label
    Friend WithEvents lblProdi As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNip As Label
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents btnTutup As Button
    Friend WithEvents btnEditFoto As Button
    Friend WithEvents ofdFoto As OpenFileDialog

End Class
