// IScoreCalculator.cs
// Amacı: Skoru hesaplama ve işleme kontratını tanımlar.
// Bu interface, skor mantığının dış dünyaya nasıl sunulacağını belirler.
public interface IScoreCalculator
{
    // Gelen ham skoru hesaplar ve kaydetme servisine gönderir.
    void CalculateAndSave(int score);
}