using UnityEngine;

// DatabaseSaver.cs
// Sorumluluk: Sadece veriyi simüle edilmiş bir veritabanına kaydetmek.
// Bu sınıf, IDataSaver kontratını uygular.
public class DatabaseSaver : IDataSaver
{
    public void Save(object data)
    {
        // Gerçek bir uygulamada burada veritabanı bağlantısı ve SQL sorguları yer alır.
        Debug.Log($"[DatabaseSaver]: Veri başarıyla DB'ye kaydedildi. İçerik: {data}");
    }
}