Public Class DSTCalculator

    ' -----------------------
    ' Struktur BPA
    ' -----------------------
    Public Structure BPA
        Public AE As Double ' Above Expectation
        Public SE As Double ' Sesuai Expectation
        Public BE As Double ' Below Expectation

        Public Overrides Function ToString() As String
            Return $"{{AE:{AE:F2}, SE:{SE:F2}, BE:{BE:F2}}}"
        End Function
    End Structure

    ' -----------------------
    ' Konversi skor 1–10 → BPA
    ' -----------------------
    Public Shared Function GetBPA(ByVal score As Double) As BPA
        Dim result As New BPA()

        If score <= 1.0 Then
            ' s <= 1
            result.BE = 1.0
            result.SE = 0.0
            result.AE = 0.0

        ElseIf score > 1.0 AndAlso score < 6.0 Then
            ' 1 < s < 6  (transisi BE → SE)
            result.BE = (6.0 - score) / 5.0
            result.SE = 1.0 - result.BE
            result.AE = 0.0

        ElseIf score >= 6.0 AndAlso score < 8.0 Then
            ' 6 ≤ s < 8  (zona SE)
            result.SE = (score - 6.0) / 2.0
            result.BE = 1.0 - result.SE
            result.AE = 0.0

        ElseIf score >= 8.0 Then
            ' s ≥ 8  (zona AE)
            Dim rawAE As Double = (score - 8.0) / 2.0
            If rawAE > 1.0 Then rawAE = 1.0

            result.AE = rawAE
            result.SE = 1.0 - result.AE
            result.BE = 0.0
        End If

        Return result
    End Function

    ' -----------------------
    ' Aturan Dempster + OPSI 2 (discount evidence) bila konflik tinggi
    ' -----------------------
    Public Shared Function Fuse(ByVal m1In As BPA, ByVal m2In As BPA) As BPA
        Dim m1 As BPA = m1In
        Dim m2 As BPA = m2In

        ' Hitung massa non konflik awal
        Dim ae_ae As Double = m1.AE * m2.AE
        Dim se_se As Double = m1.SE * m2.SE
        Dim be_be As Double = m1.BE * m2.BE

        ' Hitung konflik awal
        Dim conflict As Double = 0.0
        If m1.AE > 0 AndAlso m2.SE > 0 Then conflict += m1.AE * m2.SE
        If m1.AE > 0 AndAlso m2.BE > 0 Then conflict += m1.AE * m2.BE
        If m1.SE > 0 AndAlso m2.AE > 0 Then conflict += m1.SE * m2.AE
        If m1.SE > 0 AndAlso m2.BE > 0 Then conflict += m1.SE * m2.BE
        If m1.BE > 0 AndAlso m2.AE > 0 Then conflict += m1.BE * m2.AE
        If m1.BE > 0 AndAlso m2.SE > 0 Then conflict += m1.BE * m2.SE

        ' Jika konflik sangat tinggi (>= 0.95) → discount evidence (opsi 2)
        If conflict >= 0.95 Then
            Dim discountFactor As Double = 0.9

            ' Kurangi keyakinan masing-masing evidence
            m1.AE *= discountFactor : m1.SE *= discountFactor : m1.BE *= discountFactor
            m2.AE *= discountFactor : m2.SE *= discountFactor : m2.BE *= discountFactor

            ' Hitung ulang massa non konflik
            ae_ae = m1.AE * m2.AE
            se_se = m1.SE * m2.SE
            be_be = m1.BE * m2.BE

            ' Hitung ulang konflik
            conflict = 0.0
            If m1.AE > 0 AndAlso m2.SE > 0 Then conflict += m1.AE * m2.SE
            If m1.AE > 0 AndAlso m2.BE > 0 Then conflict += m1.AE * m2.BE
            If m1.SE > 0 AndAlso m2.AE > 0 Then conflict += m1.SE * m2.AE
            If m1.SE > 0 AndAlso m2.BE > 0 Then conflict += m1.SE * m2.BE
            If m1.BE > 0 AndAlso m2.AE > 0 Then conflict += m1.BE * m2.AE
            If m1.BE > 0 AndAlso m2.SE > 0 Then conflict += m1.BE * m2.SE
        End If

        Dim denom As Double = 1.0 - conflict
        If denom <= 0 Then
            ' Konflik 100% → fallback ke rata-rata BPA
            Dim fallback As New BPA()
            fallback.AE = (m1.AE + m2.AE) / 2.0
            fallback.SE = (m1.SE + m2.SE) / 2.0
            fallback.BE = (m1.BE + m2.BE) / 2.0
            Return fallback
        End If

        Dim normFactor As Double = 1.0 / denom

        Dim result As New BPA()
        result.AE = ae_ae * normFactor
        result.SE = se_se * normFactor
        result.BE = be_be * normFactor

        Return result
    End Function

    ' -----------------------
    ' 3 sumber: Self, Admin, KPS
    ' -----------------------
    Public Shared Function CalculateFinalDecision(selfScore As Double,
                                                  adminScore As Double,
                                                  kpsScore As Double) As BPA

        Dim mSelf As BPA = GetBPA(selfScore)
        Dim mAdmin As BPA = GetBPA(adminScore)
        Dim mKps As BPA = GetBPA(kpsScore)

        ' Fusi tahap 1: Self + Admin
        Dim m12 As BPA = Fuse(mSelf, mAdmin)
        ' Fusi tahap 2: hasil + KPS
        Dim mFinal As BPA = Fuse(m12, mKps)

        Return mFinal
    End Function

    ' Ambil label teks dari BPA
    Public Shared Function DecideLabel(mFinal As BPA) As String
        If mFinal.AE > mFinal.SE AndAlso mFinal.AE > mFinal.BE Then
            Return "Di Atas Ekspektasi (AE)"
        ElseIf mFinal.SE >= mFinal.AE AndAlso mFinal.SE >= mFinal.BE Then
            Return "Sesuai Ekspektasi (SE)"
        Else
            Return "Di Bawah Ekspektasi (BE)"
        End If
    End Function

End Class
