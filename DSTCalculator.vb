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
    ''' Mengkonversi skor mentah (1-100) menjadi BPA.
    ''' </summary>
    Private Shared Function GetBPA(ByVal score As Double) As BPA
        Dim result As New BPA()

        If score <= 10.0 Then
            ' Range s <= 10.0
            result.BE = 1.0
            result.SE = 0.0
            result.AE = 0.0

        ElseIf score > 10.0 And score < 60.0 Then
            ' Range 10.0 < s < 60.0 (Transisi BE -> SE)
            ' m(BE) = (60.0 - s) / 50.0
            result.BE = (60.0 - score) / 50.0
            result.SE = 1.0 - result.BE
            result.AE = 0.0

        ElseIf score >= 60.0 And score < 80.0 Then
            ' Range 60.0 <= s < 80.0 (Zona SE dengan penurunan BE)
            ' m(SE) = (s - 60.0) / 20.0
            result.SE = (score - 60.0) / 20.0
            result.BE = 1.0 - result.SE
            result.AE = 0.0

        ElseIf score >= 80.0 Then
            ' Range s >= 80.0 (Zona AE)
            ' m(AE) = (s - 80.0) / 20.0
            Dim rawAE As Double = (score - 80.0) / 20.0
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
        Dim ae_ae As Double = m1.AE * m2.AE
        Dim se_se As Double = m1.SE * m2.SE
        Dim be_be As Double = m1.BE * m2.BE

        ' Hitung Konflik (K)
        Dim conflict As Double = 0.0
        conflict += m1.AE * m2.SE
        conflict += m1.AE * m2.BE
        conflict += m1.SE * m2.AE
        conflict += m1.SE * m2.BE
        conflict += m1.BE * m2.AE
        conflict += m1.BE * m2.SE

        If conflict >= 1.0 Then
            Throw New Exception("Konflik total terjadi!")
        End If

        Dim normFactor As Double = 1.0 / (1.0 - conflict)

        Dim result As New BPA()
        result.AE = ae_ae * normFactor
        result.SE = se_se * normFactor
        result.BE = be_be * normFactor

        Return result
    End Function

    Public Shared Sub Main()
        Try
            Console.WriteLine("=== Simulasi DST SKP (Skala 1-100) ===")
            
            ' 1. Contoh Penggunaan Normalisasi
            Console.WriteLine("\n--- Tahap 1: Normalisasi Input ---")
            
            ' Kasus: Self Assessment (Binary Yes -> 100)
            ' Anggap rata-rata akhir 82 (setara 8.2 dulu)
            Dim scoreSelf As Double = 82.0 
            Console.WriteLine($"Input Self (Rata-rata) -> Score: {scoreSelf}")

            ' Kasus: Admin (74%) -> 74.0
            Dim rawAdminPct As Double = 74.0 
            Dim scoreAdmin As Double = Normalization.NormalizePercentage(rawAdminPct)
            Console.WriteLine($"Input Admin (74%) -> Score: {scoreAdmin}")

            ' Kasus: KPS (Input 9.0 -> 90.0)
            Dim rawKPS As Double = 9.0
            Dim scoreKPS As Double = Normalization.NormalizeKPS(rawKPS)
            Console.WriteLine($"Input KPS (9.0) -> Score: {scoreKPS}")

            ' 2. Perhitungan DST
            Console.WriteLine("\n--- Tahap 2: Perhitungan DST ---")
            Dim keputusan As String = CalculateFinalDecision(scoreSelf, scoreAdmin, scoreKPS)
            
            Console.WriteLine("--------------------------------")
            Console.WriteLine($"Keputusan Akhir: {keputusan}")
            Console.WriteLine("--------------------------------")

        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        End Try
    End Sub

End Class
