Imports System

Public Class Normalization

    ''' <summary>
    ''' Normalisasi input Biner (Ya/Tidak).
    ''' </summary>
    ''' <param name="condition">True jika Ya/Terpenuhi, False jika Tidak.</param>
    ''' <returns>10.0 jika True, 1.0 jika False.</returns>
    Public Shared Function NormalizeBinary(ByVal condition As Boolean) As Double
        If condition Then
            Return 10.0
        Else
            Return 1.0
        End If
    End Function

    ''' <summary>
    ''' Normalisasi input Persentase (0-100).
    ''' </summary>
    ''' <param name="value">Nilai persentase (0-100).</param>
    ''' <returns>Nilai skala 1-10.</returns>
    Public Shared Function NormalizePercentage(ByVal value As Double) As Double
        ' Konversi: (Nilai / 100) * 10
        Dim score As Double = (value / 100.0) * 10.0
        Return Math.Min(Math.Max(score, 1.0), 10.0)
    End Function

    ''' <summary>
    ''' Normalisasi input Frekuensi (Target Minimum).
    ''' Semakin tinggi dari target, semakin baik (max 10).
    ''' </summary>
    ''' <param name="actual">Jumlah aktual.</param>
    ''' <param name="target">Target minimum.</param>
    ''' <returns>Nilai skala 1-10.</returns>
    Public Shared Function NormalizeFrequency(ByVal actual As Double, ByVal target As Double) As Double
        If target <= 0 Then Return 10.0 ' Hindari bagi nol

        ' Rumus: (Aktual / Target) * 10
        Dim score As Double = (actual / target) * 10.0
        Return Math.Min(Math.Max(score, 1.0), 10.0)
    End Function

    ''' <summary>
    ''' Normalisasi input Waktu (Target Maksimum).
    ''' Semakin cepat (kecil) dari target, semakin baik.
    ''' </summary>
    ''' <param name="actual">Waktu aktual.</param>
    ''' <param name="target">Target waktu maksimum.</param>
    ''' <returns>Nilai skala 1-10.</returns>
    Public Shared Function NormalizeTime(ByVal actual As Double, ByVal target As Double) As Double
        If actual <= 0 Then Return 10.0 ' Waktu 0 atau negatif dianggap sangat cepat (sempurna)

        ' Rumus: (Target / Aktual) * 10
        Dim score As Double = (target / actual) * 10.0
        Return Math.Min(Math.Max(score, 1.0), 10.0)
    End Function

    ''' <summary>
    ''' Normalisasi input KPS (Range 1-10).
    ''' Input sudah dalam skala 1-10, tidak perlu konversi.
    ''' </summary>
    ''' <param name="score">Nilai input KPS (1-10).</param>
    ''' <returns>Nilai skala 1-10.</returns>
    Public Shared Function NormalizeKPS(ByVal score As Double) As Double
        ' KPS sudah dalam skala 1-10, langsung return
        Return Math.Min(Math.Max(score, 1.0), 10.0)
    End Function

End Class
