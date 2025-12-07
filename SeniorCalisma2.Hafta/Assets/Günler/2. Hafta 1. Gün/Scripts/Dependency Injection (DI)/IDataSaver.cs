// IDataSaver.cs
// Amacı: Veri kaydetme işleminin kontratını tanımlar.
// Bu interface, somut kaydetme yönteminden (DB, File, API) bağımsızdır.
public interface IDataSaver
{
    // Veriyi alır ve kaydeder. Data türü burada object olarak bırakıldı.
    void Save(object data);
}