Imports System

Public Class DSTCalculator

    ' Struktur untuk menyimpan Basic Probability Assignment (BPA)
    Public Structure BPA
        Public AE As Double ' Above Expectation
        Public SE As Double ' Sesuai Expectation
        Public BE As Double ' Below Expectation

        Public Overrides Function ToString() As String
            Return $"{{AE:{AE:F2}, SE:{SE:F2}, BE:{BE:F2}}}"
        End Function
    End Structure

    ''' <summary>
    ''' Mengkonversi skor mentah (1-10) menjadi BPA.
    ''' </summary>
    Private Shared Function GetBPA(ByVal score As Double) As BPA
        Dim result As New BPA()

        If score <= 1.0 Then
            ' Range s <= 1.0
            result.BE = 1.0
            result.SE = 0.0
            result.AE = 0.0

        ElseIf score > 1.0 And score < 6.0 Then
            ' Range 1.0 < s < 6.0 (Transisi BE -> SE)
            ' m(BE) = (6.0 - s) / 5.0
            result.BE = (6.0 - score) / 5.0
            result.SE = 1.0 - result.BE
            result.AE = 0.0

        ElseIf score >= 6.0 And score < 8.0 Then
            ' Range 6.0 <= s < 8.0 (Zona SE dengan penurunan BE)
            ' m(SE) = (s - 6.0) / 2.0
            result.SE = (score - 6.0) / 2.0
            result.BE = 1.0 - result.SE
            result.AE = 0.0

        ElseIf score >= 8.0 Then
            ' Range s >= 8.0 (Zona AE)
            ' m(AE) = (s - 8.0) / 2.0
            Dim rawAE As Double = (score - 8.0) / 2.0
            If rawAE > 1.0 Then rawAE = 1.0
            
            result.AE = rawAE
            result.SE = 1.0 - result.AE
            result.BE = 0.0
        End If

        Return result
    End Function

    ''' <summary>
    ''' Menghitung keputusan akhir kinerja dosen berdasarkan tiga sumber penilaian.
    ''' </summary>
    Public Shared Function CalculateFinalDecision(ByVal selfScore As Double, ByVal adminScore As Double, ByVal kpsScore As Double) As String
        ' 1. Konversi Skor ke BPA (Internal)
        Dim mSelf As BPA = GetBPA(selfScore)
        Dim mAdmin As BPA = GetBPA(adminScore)
        Dim mKPS As BPA = GetBPA(kpsScore)

        Console.WriteLine($"[BPA] Self ({selfScore}) -> {mSelf}")
        Console.WriteLine($"[BPA] Admin ({adminScore}) -> {mAdmin}")
        Console.WriteLine($"[BPA] KPS ({kpsScore}) -> {mKPS}")

        ' 2. Fusi Tahap 1: Self (+) Admin
        Dim m12 As BPA = Fuse(mSelf, mAdmin)
        Console.WriteLine($"[Fusi 1] Self+Admin -> {m12}")

        ' 3. Fusi Tahap 2: Hasil 1 (+) KPS
        Dim mFinal As BPA = Fuse(m12, mKPS)
        Console.WriteLine($"[Fusi Final] +KPS -> {mFinal}")

        ' 4. Penentuan Keputusan (Highest Belief)
        If mFinal.AE > mFinal.SE And mFinal.AE > mFinal.BE Then
            Return "Di Atas Ekspektasi (AE)"
        ElseIf mFinal.SE >= mFinal.AE And mFinal.SE >= mFinal.BE Then
            Return "Sesuai Ekspektasi (SE)"
        Else
            Return "Di Bawah Ekspektasi (BE)"
        End If
    End Function

    ''' <summary>
    ''' Fungsi generik untuk menggabungkan dua BPA menggunakan Aturan Dempster.
    ''' </summary>
    Private Shared Function Fuse(ByVal m1 As BPA, ByVal m2 As BPA) As BPA
        ' Hitung massa untuk kategori yang sama (non-konflik)
        Dim ae_ae As Double = m1.AE * m2.AE
        Dim se_se As Double = m1.SE * m2.SE
        Dim be_be As Double = m1.BE * m2.BE

        ' Hitung Konflik (K) - hanya untuk pasangan yang disjoint dan bernilai
        Dim conflict As Double = 0.0
        
        ' Optimasi: hanya hitung jika kedua nilai > 0
        If m1.AE > 0 And m2.SE > 0 Then conflict += m1.AE * m2.SE
        If m1.AE > 0 And m2.BE > 0 Then conflict += m1.AE * m2.BE
        If m1.SE > 0 And m2.AE > 0 Then conflict += m1.SE * m2.AE
        If m1.SE > 0 And m2.BE > 0 Then conflict += m1.SE * m2.BE
        If m1.BE > 0 And m2.AE > 0 Then conflict += m1.BE * m2.AE
        If m1.BE > 0 And m2.SE > 0 Then conflict += m1.BE * m2.SE

        ' Tampilkan konflik untuk debugging
        Console.WriteLine($"  -> Konflik (K): {conflict:F4}")

        ' Warning untuk Konflik Tinggi
        If conflict >= 0.95 Then
            Console.WriteLine("  WARNING: Konflik sangat tinggi! Hasil mungkin tidak reliable.")
            
            ' --- OPSI 1: WEIGHTED AVERAGE FALLBACK (COMMENTED) ---
            ' Jika konflik terlalu tinggi, gunakan rata-rata sederhana
            ' Dim resultFallback As New BPA()
            ' resultFallback.AE = (m1.AE + m2.AE) / 2.0
            ' resultFallback.SE = (m1.SE + m2.SE) / 2.0
            ' resultFallback.BE = (m1.BE + m2.BE) / 2.0
            ' Return resultFallback
            
            ' --- OPSI 2: DISCOUNT EVIDENCE (COMMENTED) ---
            ' Kurangi keyakinan masing-masing evidence dengan discount factor 0.9 (90% confidence)
            ' Sisa 10% menjadi "uncertainty" dalam DST
            ' 
            ' Dim discountFactor As Double = 0.9
            ' m1.AE *= discountFactor : m1.SE *= discountFactor : m1.BE *= discountFactor
            ' m2.AE *= discountFactor : m2.SE *= discountFactor : m2.BE *= discountFactor
            ' 
            ' ' Setelah discount, hitung ulang kombinasi dengan nilai baru
            ' ae_ae = m1.AE * m2.AE
            ' se_se = m1.SE * m2.SE
            ' be_be = m1.BE * m2.BE
            ' 
            ' ' Hitung ulang konflik dengan nilai yang sudah di-discount
            ' conflict = 0.0
            ' If m1.AE > 0 And m2.SE > 0 Then conflict += m1.AE * m2.SE
            ' If m1.AE > 0 And m2.BE > 0 Then conflict += m1.AE * m2.BE
            ' If m1.SE > 0 And m2.AE > 0 Then conflict += m1.SE * m2.AE
            ' If m1.SE > 0 And m2.BE > 0 Then conflict += m1.SE * m2.BE
            ' If m1.BE > 0 And m2.AE > 0 Then conflict += m1.BE * m2.AE
            ' If m1.BE > 0 And m2.SE > 0 Then conflict += m1.BE * m2.SE
            ' 
            ' ' Lalu lanjutkan ke normalisasi seperti biasa dengan normFactor = 1/(1-K)
        End If

        ' Normalisasi dengan faktor 1/(1-K)
        Dim normFactor As Double = 1.0 / (1.0 - conflict)

        Dim result As New BPA()
        result.AE = ae_ae * normFactor
        result.SE = se_se * normFactor
        result.BE = be_be * normFactor

        Return result
    End Function

    Public Shared Sub Main()
        Try
            Console.WriteLine("=== Simulasi DST SKP (Skala 1-10) ===")
            Console.WriteLine(vbCrLf & "--- Input Nilai Penilaian ---")
            
            ' Input Self Assessment
            Console.Write("Masukkan nilai Self Assessment (1-10): ")
            Dim scoreSelf As Double = Double.Parse(Console.ReadLine())
            
            ' Input Admin Assessment
            Console.Write("Masukkan nilai Admin Assessment (1-10): ")
            Dim scoreAdmin As Double = Double.Parse(Console.ReadLine())
            
            ' Input KPS Assessment
            Console.Write("Masukkan nilai KPS (1-10): ")
            Dim scoreKPS As Double = Double.Parse(Console.ReadLine())
            
            Console.WriteLine(vbCrLf & "--- Hasil Input ---")
            Console.WriteLine($"Self Score: {scoreSelf:F1}")
            Console.WriteLine($"Admin Score: {scoreAdmin:F1}")
            Console.WriteLine($"KPS Score: {scoreKPS:F1}")

            ' Perhitungan DST
            Console.WriteLine(vbCrLf & "--- Tahap Perhitungan DST ---")
            Dim keputusan As String = CalculateFinalDecision(scoreSelf, scoreAdmin, scoreKPS)
            
            Console.WriteLine("================================")
            Console.WriteLine($"Keputusan Akhir: {keputusan}")
            Console.WriteLine("================================")
            
            ' Tahan layar agar tidak langsung tertutup
            Console.WriteLine(vbCrLf & "Tekan Enter untuk keluar...")
            Console.ReadLine()

        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
            Console.ReadLine()
        End Try
    End Sub

End Class
