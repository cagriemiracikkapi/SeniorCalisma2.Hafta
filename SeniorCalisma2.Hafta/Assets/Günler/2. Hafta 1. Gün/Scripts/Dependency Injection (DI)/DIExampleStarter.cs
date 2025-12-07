using UnityEngine;

// DIExampleStarter.cs
// Unity'de tüm bağımlılıkları bir araya getiren (kompozisyon) sınıf.
public class DIExampleStarter : MonoBehaviour
{
    // Ana servislerimizi interface tipinde tutuyoruz.
    private IScoreCalculator _scoreCalculator;

    void Start()
    {
        // 1. Somut Bağımlılığı Yarat (Hangi kaydetme yöntemini kullanacağımıza karar veriyoruz)
        IDataSaver databaseSaver = new DatabaseSaver();
        // Not: Yarın dosya kaydetme istersek: IDataSaver fileSaver = new FileSaver(); deriz.

        // 2. Yapıcı Metot Enjeksiyonu: 
        // Hesaplayıcıyı yaratırken, ona *hangi kaydetme servisini* kullanması gerektiğini veriyoruz.
        _scoreCalculator = new DefaultScoreCalculator(databaseSaver);

        Debug.Log("[DI Starter]: Servisler hazırlandı. Boşluk tuşuna basın.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int baseScore = Random.Range(100, 500);
            Debug.Log($"\n[DI Starter]: Yeni ham skor alınıyor: {baseScore}");

            // Hesaplama ve kaydetme zincirini başlat.
            _scoreCalculator.CalculateAndSave(baseScore);
        }
    }
}