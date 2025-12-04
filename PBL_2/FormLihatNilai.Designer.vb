<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLihatNilai
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
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        lblStatus = New Label()
        lblNamaDosen = New Label()
        lblProgramStudi = New Label()
        lblNIP = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        cboPeriode = New ComboBox()
        Button1 = New Button()
        GroupBox2 = New GroupBox()
        lblPredikat = New Label()
        lblScore = New Label()
        Label8 = New Label()
        Label7 = New Label()
        pnlHeader.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(112), CByte(148), CByte(194))
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(2, 1, 2, 1)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(764, 94)
        pnlHeader.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 32)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(309, 32)
        Label1.TabIndex = 0
        Label1.Text = "LAPORAN KINERJA DOSEN"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblStatus)
        GroupBox1.Controls.Add(lblNamaDosen)
        GroupBox1.Controls.Add(lblProgramStudi)
        GroupBox1.Controls.Add(lblNIP)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(0, 155)
        GroupBox1.Margin = New Padding(2, 1, 2, 1)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(2, 1, 2, 1)
        GroupBox1.Size = New Size(765, 131)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Identitas"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(507, 75)
        lblStatus.Margin = New Padding(2, 0, 2, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(26, 15)
        lblStatus.TabIndex = 7
        lblStatus.Text = "Sah"
        ' 
        ' lblNamaDosen
        ' 
        lblNamaDosen.AutoSize = True
        lblNamaDosen.Location = New Point(507, 32)
        lblNamaDosen.Margin = New Padding(2, 0, 2, 0)
        lblNamaDosen.Name = "lblNamaDosen"
        lblNamaDosen.Size = New Size(73, 15)
        lblNamaDosen.TabIndex = 6
        lblNamaDosen.Text = "John Don.SP"
        ' 
        ' lblProgramStudi
        ' 
        lblProgramStudi.AutoSize = True
        lblProgramStudi.Location = New Point(164, 75)
        lblProgramStudi.Margin = New Padding(2, 0, 2, 0)
        lblProgramStudi.Name = "lblProgramStudi"
        lblProgramStudi.Size = New Size(16, 15)
        lblProgramStudi.TabIndex = 5
        lblProgramStudi.Text = "TI"
        ' 
        ' lblNIP
        ' 
        lblNIP.AutoSize = True
        lblNIP.Location = New Point(164, 32)
        lblNIP.Margin = New Padding(2, 0, 2, 0)
        lblNIP.Name = "lblNIP"
        lblNIP.Size = New Size(13, 15)
        lblNIP.TabIndex = 4
        lblNIP.Text = "0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(412, 75)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(69, 15)
        Label6.TabIndex = 3
        Label6.Text = "Status         :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(42, 75)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(101, 15)
        Label5.TabIndex = 2
        Label5.Text = "Program Studi     :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(412, 32)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 15)
        Label4.TabIndex = 1
        Label4.Text = "Nama         :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(42, 32)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 15)
        Label3.TabIndex = 0
        Label3.Text = "NIP                     :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(26, 113)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(53, 15)
        Label2.TabIndex = 2
        Label2.Text = "Periode :"
        ' 
        ' cboPeriode
        ' 
        cboPeriode.FormattingEnabled = True
        cboPeriode.Location = New Point(99, 109)
        cboPeriode.Margin = New Padding(2, 1, 2, 1)
        cboPeriode.Name = "cboPeriode"
        cboPeriode.Size = New Size(132, 23)
        cboPeriode.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.MediumSpringGreen
        Button1.Location = New Point(264, 105)
        Button1.Margin = New Padding(2, 1, 2, 1)
        Button1.Name = "Button1"
        Button1.Size = New Size(98, 26)
        Button1.TabIndex = 4
        Button1.Text = "LIHAT HASIL"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(lblPredikat)
        GroupBox2.Controls.Add(lblScore)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Location = New Point(0, 291)
        GroupBox2.Margin = New Padding(2, 1, 2, 1)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(2, 1, 2, 1)
        GroupBox2.Size = New Size(765, 98)
        GroupBox2.TabIndex = 8
        GroupBox2.TabStop = False
        GroupBox2.Text = "Hasil Akhir"
        ' 
        ' lblPredikat
        ' 
        lblPredikat.AutoSize = True
        lblPredikat.Location = New Point(502, 60)
        lblPredikat.Margin = New Padding(2, 0, 2, 0)
        lblPredikat.Name = "lblPredikat"
        lblPredikat.Size = New Size(101, 15)
        lblPredikat.TabIndex = 3
        lblPredikat.Text = "SESUAI EKSPETASI"
        ' 
        ' lblScore
        ' 
        lblScore.AutoSize = True
        lblScore.Location = New Point(146, 60)
        lblScore.Margin = New Padding(2, 0, 2, 0)
        lblScore.Name = "lblScore"
        lblScore.Size = New Size(34, 15)
        lblScore.TabIndex = 2
        lblScore.Text = "88.50"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(499, 39)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(105, 15)
        Label8.TabIndex = 1
        Label8.Text = "PREDIKAT KINERJA"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(112, 39)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(108, 15)
        Label7.TabIndex = 0
        Label7.Text = "NILAI AKHIR TOTAL"
        ' 
        ' FormLihatNilai
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(232), CByte(223), CByte(202))
        ClientSize = New Size(764, 390)
        Controls.Add(GroupBox2)
        Controls.Add(Button1)
        Controls.Add(cboPeriode)
        Controls.Add(Label2)
        Controls.Add(GroupBox1)
        Controls.Add(pnlHeader)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FormLihatNilai"
        Text = "FormLihatNilai"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPeriode As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblNamaDosen As Label
    Friend WithEvents lblProgramStudi As Label
    Friend WithEvents lblNIP As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblScore As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblPredikat As Label
End Class