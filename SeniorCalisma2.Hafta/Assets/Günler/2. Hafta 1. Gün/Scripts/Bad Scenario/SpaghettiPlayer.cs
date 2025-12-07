using UnityEngine;

// --- INTERFACE KULLANMADAN ÇOKLU SİLAH KULLANIMI (TAVSİYE EDİLMEZ) ---
// BU YAKLAŞIMIN SORUNLARI:
// 1. OCP İhlali: Her yeni silah (Rifle vb.) eklendiğinde bu sınıfın değiştirilmesi gerekir.
// 2. Kod Tekrarı: Her silah için ayrı referans, ayrı GetComponent ve ayrı Fire çağrısı gerekir.
// 3. Kırılganlık: Eğer bir silah component'i GameObject'e eklenmezse NullReferenceException riski artar.

public class SpaghettiPlayer : MonoBehaviour
{
    // Her silah tipi için ayrı bir referans tutmak zorundayız.
    private Pistol _pistol;
    private Shotgun _shotgun;
    private Laser _laser;

    // Yeni bir silah (örn: Rifle) eklenirse, buraya yeni bir satır eklenmeli:
    // private Rifle _rifle;

    void Start()
    {
        // Her bir silah component'ini ayrı ayrı buluyoruz.
        _pistol = GetComponent<Pistol>();
        _shotgun = GetComponent<Shotgun>();
        _laser = GetComponent<Laser>();

        // Geliştiriciyi uyarmak için kontrol ekleyelim.
        // Bu kontroller, bir component'in eklenmeyi unutulması gibi durumları anında fark etmemizi sağlar.
        if (_pistol == null)
            Debug.LogWarning("Player üzerinde Pistol component'i bulunamadı!");
        if (_shotgun == null)
            Debug.LogWarning("Player üzerinde Shotgun component'i bulunamadı!");
        if (_laser == null)
            Debug.LogWarning("Player üzerinde Laser component'i bulunamadı!");

        // Yeni silah eklenirse, buraya yeni bir GetComponent çağrısı eklenmeli:
        // _rifle = GetComponent<Rifle>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Tüm mevcut silahları ateşle.
            Fire();
        }
    }

    void Fire()
    {
        // Her silahın varlığını kontrol edip ayrı ayrı ateşliyoruz.
        if (_pistol != null)
            _pistol.Fire();
        if (_shotgun != null)
            _shotgun.Fire();
        if (_laser != null)
            _laser.Fire();

        // Yeni silah eklenirse, buraya yeni bir Fire çağrısı eklenmeli:
        // if (_rifle != null) _rifle.Fire();
    }
}
