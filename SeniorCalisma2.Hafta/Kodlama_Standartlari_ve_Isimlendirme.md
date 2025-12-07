# C# ve Unity İsimlendirme Standartları (Naming Conventions)

Bu kılavuz, profesyonel (Senior) bir oyun geliştirme sürecinde kodun okunabilirliğini, bakımını ve ekip içi uyumu sağlamak amacıyla derlenmiştir. Microsoft'un resmi C# standartları ve Unity topluluğunun genel kabulleri esas alınmıştır.

## 1. Temel Prensipler

*   **İngilizce Kullanımı:** Kod içerisindeki her şey (değişkenler, fonksiyonlar, yorum satırları) **mutlaka İngilizce** olmalıdır.
    *   ❌ `kapiAcikMi`, `OyuncuHizi`
    *   ✅ `isDoorOpen`, `PlayerSpeed`
*   **Açıklayıcı Olun:** Kısaltmalardan kaçının. Değişken adı ne işe yaradığını anlatmalıdır.
    *   ❌ `t`, `dm`, `p`
    *   ✅ `time`, `damageMultiplier`, `player`

---

## 2. Yazım Stilleri (Casing)

### PascalCase
Kelimelerin baş harfleri büyüktür.
> `SeniorPlayer`, `FireWeapon`, `GameManager`

### camelCase
İlk kelimenin baş harfi küçüktür, sonrakiler büyüktür.
> `playerHealth`, `currentWeapon`, `spawnPoint`

### SCREAMING_SNAKE_CASE vs PascalCase (Sabitler / Constants)
Burada iki farklı ekol vardır. Proje başında birini seçip sadık kalmak önemlidir.

1.  **SCREAMING_SNAKE_CASE (Oyun Geliştirme Kültürü):**
    Sabitlerin kod içinde "Ben değişmem!" diye bağırmasını sağlar. C/C++ kökenli bir alışkanlıktır ve oyun sektöründe çok yaygındır.
    > `MAX_HEALTH`, `DEFAULT_SPEED`

2.  **PascalCase (Microsoft Resmi .NET Standardı):**
    Microsoft'un önerdiği modern yöntemdir. Sabitleri diğer Property'ler gibi yazar.
    > `MaxHealth`, `DefaultSpeed`

*Tavsiye: Unity projelerinde karışıklığı önlemek için SnakeCase kullanımı hala popülerdir, ancak saf C# projelerinde PascalCase tercih edilir.*

---

## 3. Kod Elemanları İçin Kurallar

### A. Sınıflar (Classes) ve Dosya İsimleri
Her zaman **PascalCase** kullanılır. Sınıf adı ile dosya adı birebir aynı olmalıdır.
*   `class PlayerController` -> `PlayerController.cs`
*   `class EnemyAI` -> `EnemyAI.cs`

### B. Arayüzler (Interfaces)
Her zaman **PascalCase** kullanılır ve ismin başına büyük **'I'** harfi getirilir.
*   `IWeapon`
*   `IDamagable`
*   `IInteractable`

### C. Metotlar (Methods / Functions)
Her zaman **PascalCase** kullanılır. İsim bir **fiil** ile başlamalıdır.
*   `Fire()`
*   `CalculateDamage()`
*   `GetPlayerPosition()`
*   ❌ `damage()`, `player_pos()`

### D. Değişkenler (Variables & Fields) - **EN ÖNEMLİ KISIM**

#### 1. Private Fields (Özel Alanlar)
Sınıfın içinde kullanılan, dışarıya kapalı değişkenler **`_` (alt çizgi)** ile başlar ve **camelCase** devam eder. Bu, "Senior" kodun imzasıdır.
```csharp
private float _currentHealth;
private IWeapon _activeWeapon;
```

#### 2. Serialized Fields (Inspector Değişkenleri)
Unity Inspector'da görünmesi istenen ama kod güvenliği için `private` tutulan değişkenler de **`_`** ile başlar.
```csharp
[SerializeField] private float _moveSpeed;
[SerializeField] private GameObject _bulletPrefab;
```
*Not: Bazı ekipler Inspector değişkenlerinde `_` kullanmaz (`private float moveSpeed;`), ancak `_` kullanımı private olduğunu kod içinde ayırt etmeyi çok kolaylaştırır.*

#### 3. Public Fields & Properties (Genel Alanlar)
Dışarıdan erişilmesi gereken özellikler **PascalCase** yazılır. (Genelde Property kullanılır).
```csharp
public float MaxHealth { get; private set; }
public bool IsDead => _currentHealth <= 0;
```

#### 4. Local Variables (Yerel Değişkenler)
Metot içinde tanımlanan geçici değişkenler **camelCase** yazılır (alt çizgi YOK).
```csharp
void CalculateDamage()
{
    float totalDamage = _baseDamage * _multiplier; // totalDamage yereldir
    // ...
}
```

### E. Boolean (Mantıksal) Değişkenler
Her zaman bir soru/durum belirtmelidir. Genelde `is`, `has`, `can` gibi ön ekler alır.
*   `isDead`, `isRunning`
*   `hasKey`
*   `canAttack`
*   ❌ `dead`, `running`, `key` (Bunlar durum mu yoksa nesne mi belirsizdir)

---

## 4. Özet Kod Örneği

```csharp
using UnityEngine;

// Sınıf ismi: PascalCase
public class SeniorGuard : MonoBehaviour, IDamagable // Interface: I...
{
    // Sabitler: SCREAMING_SNAKE_CASE
    private const float MAX_PATROL_DISTANCE = 50f;

    // Public Property: PascalCase
    public int Health { get; private set; }

    // Serialized Private Field: _camelCase
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private Transform _patrolPoint;

    // Private Field: _camelCase
    private bool _isAlerted; // Bool: is/has/can...

    // Metot: PascalCase ve Fiil
    public void TakeDamage(int damageAmount) // Parametre: camelCase
    {
        // Yerel Değişken: camelCase
        int finalHealth = Health - damageAmount;
        
        if (finalHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Guard died.");
    }
}
```

## 5. Unity Proje Düzeni ve İsimlendirme (Unity Best Practices)
Düzenli bir proje, debugging süresini yarıya indirir. İşte endüstri standartları:

### A. Klasör Yapısı (Directory Structure)
Ana dizin daima temiz olmalıdır. Asla `Assets` kök dizinine dosya atmayın.

*   `Assets/`
    *   `_Game/` (Kendi yazdığınız kodlar ve assetler buraya. Asset Store paketlerinden ayrışmak için başına `_` konur.)
        *   `Animations/`
            *   `Characters/`
            *   `UI/`
        *   `Audio/`
            *   `Music/`
            *   `SFX/`
        *   `Materials/`
        *   `Prefabs/`
            *   `Environment/`
            *   `Projectiles/`
            *   `UI/`
        *   `Scripts/` (Kodlar burada kategorize edilir)
            *   `Core/` (GameManager, InputManager gibi temel sistemler)
            *   `Player/`
            *   `Enemies/`
            *   `Helpers/` (Extensionlar, statik classlar)
        *   `Scenes/`
            *   `Levels/`
            *   `Menus/`
            *   `Sandboxes/` (Test sahneleri)
        *   `Textures/`
    *   `ThirdParty/` (Asset Store'dan indirilen paketler buraya taşınır, karışıklık önlenir.)

---

### B. Asset İsimlendirme (Prefix/Suffix)
Dosya türünü isminden anlamak için son ek (Suffix) veya ön ek (Prefix) kullanılır. **Suffix** kullanımı (arama yaparken `MainChar_Mat` yazmak kolay olduğundan) daha yaygındır.

*   **Materials:** `_Mat` (Örn: `Player_Red_Mat`, `Wood_Floor_Mat`)
*   **Textures:** `_Tex` (Örn: `Wood_Diff_Tex`, `Wood_Normal_Tex`)
*   **Prefabs:** Sonek gerekmez ama veya `_Prefab` kullanılabilir. Önemli olan PascalCase olmasıdır. (Örn: `EnemyOrc`, `BulletRocket`)
*   **Scenes:** Genelde anlaşılır isimler yeterlidir. (Örn: `MainMenu`, `Level01_Forest`)
*   **Animations:** `_Anim` (Örn: `Run_Anim`, `Idle_Anim`)
*   **Animators:** `_Controller` (Örn: `Player_Controller`)

---

### C. Hierarchy (Sahne) Düzeni
Sahne hiyerarşisi, oyunun iskeletidir. Dağınıklık performans kaybına ve kafa karışıklığına yol açar.

#### 1. Ayırıcılar (Separators)
Kod içermeyen boş objelerle hiyerarşiyi gruplayın. **Standart format:** 3 çizgi, boşluk, BÜYÜK HARFLERLE İSİM, boşluk, 3 çizgi.
> Örnek: `--- SYSTEMS ---`, `--- ENVIRONMENT ---`, `--- LIGHTS ---`
> Editor scriptleri ile bu objelerin Inspector'da "Reset" konumunda (0,0,0) olduğundan emin olun.

#### 2. Ebeveynleme (Parenting) ve Kategori Örnekleri
Her başlığın altında nelerin bulunması gerektiğine dair endüstri standartları:

*   `--- SYSTEMS ---`: Oyunun beyni. Fiziksel olarak görünmeyen "Manager"lar.
    *   *Örnekler:* `GameManager`, `AudioManager`, `InputManager`, `ObjectPool`, `SaveSystem`.
*   `--- ENVIRONMENT ---`: Bölüm tasarımları. (Hepsi tek parça taşınabilmeli).
    *   *Örnekler:* `Lights_Group` (Işıklar), `World_Geometry` (Zemin, duvarlar), `Props` (Kutular, variller).
*   `--- DYNAMIC ---` veya `--- GAMEPLAY ---`: Hareket eden, yaşayan her şey.
    *   *Örnekler:* `Player`, `Enemies_Container` (Tüm düşmanlar burada), `Collectibles` (Altınlar).
*   `--- UI ---`: Kullanıcı arayüzü.
    *   *Örnekler:* `Main_Canvas`, `Debug_Canvas`.

> **💡 İpucu: Neden GameManager (Pascal) ama Player_Hero (Snake)?**
> *   **PascalCase (Soyut Yöneticiler):** Sahnede fiziksel olarak görünmeyen, oyunun beyni olan sistemler (`GameManager`, `AudioManager`). Bunlar direkt script ismini taşır.
> *   **Snake_Case (Somut Varlıklar):** Sahnede görünen, eti kemiği olan varlıklar (`Player_Hero`, `Enemy_Orc`, `Wall_North`). Üzerlerinde script olsa bile (`PlayerController`), bunlar birer "Varlık" olduğu için Snake_Case kullanılır.

**İdeal Bir Sahne Hiyerarşisi:**
```text
▼ --- SYSTEMS --- (DontDestroyOnLoad Adayları)
    ▶ GameManager
    ▶ AudioManager
    ▶ NetworkManager
▼ --- ENVIRONMENT ---
    ▼ Lights_Group
        ▶ Directional Light
    ▼ Level_01_Geometry
        ▶ Floor_Main
        ▶ Walls_Container
▼ --- DYNAMIC ---
    ▶ Player_Hero
    ▼ Enemies_Pool
        ▶ Orc_Warrior_01
        ▶ Orc_Archer_01
▼ --- UI ---
    ▼ Main_Canvas
        ▶ HUD_Panel
        ▶ Pause_Menu
```

### D. Arama İpuçları (Search Tricks)
Doğru isimlendirme yaparsanız, Unity'nin arama özelliklerini %100 verimle kullanabilirsiniz.

*   `MainChar_Mat` (Bitişik): İsminde bu bloğu **kesintisiz** içerenleri bulur. (`MainChar_Alive_Mat` dosyasını BULMAZ).
*   `MainChar Mat` (Ayrı): İçinde hem "MainChar" hem "Mat" geçenleri bulur. Sıra önemli değildir. (`MainChar_Alive_Mat` dosyasını BULUR).
*   `t:Material` (Type Filtresi): Sadece materyalleri gösterir.
    *   Örnek: `MainChar t:Material` -> İsmi MainChar olan tüm materyalleri listeler.
    *   Örnek: `t:Script Senior` -> İsmi Senior olan tüm scriptleri listeler.

