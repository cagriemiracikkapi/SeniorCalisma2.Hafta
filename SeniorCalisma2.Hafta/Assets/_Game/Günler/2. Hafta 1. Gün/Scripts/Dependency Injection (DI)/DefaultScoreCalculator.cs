using UnityEngine;

// DefaultScoreCalculator.cs
// Sorumluluk: Sadece skor hesaplama/işleme mantığını yürütmek.
public class DefaultScoreCalculator : IScoreCalculator
{
    // Bağımlılık: Sınıf, IDataSaver kontratına bağımlıdır.
    private readonly IDataSaver _dataSaver;

    // YAPIYICI METOT ENJEKSİYONU (CONSTRUCTOR INJECTION)
    // Sınıf, ihtiyacı olan IDataSaver nesnesini new'lenirken dışarıdan almak ZORUNDADIR.
    public DefaultScoreCalculator(IDataSaver dataSaver)
    {
        // Gelen bağımlılığı iç alana atar.
        _dataSaver = dataSaver;
    }

    public void CalculateAndSave(int score)
    {
        // 1. Hesaplama Mantığı (Bu sınıfın ana SRP'si)
        var finalScore = score * 1.5f;
        var processedData = $"Oyun Skoru: {score} -> Bonuslu Skor: {finalScore}";

        // 2. Devretme (Delegation) Mantığı
        // Kaydetme işini dışarıdan gelen (enjekte edilen) servise devreder.
        _dataSaver.Save(processedData);
        Debug.Log("[ScoreCalculator]: Hesaplama tamamlandı ve kaydetme servisine devredildi.");
    }
}