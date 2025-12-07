# Senior Gelişim Günlüğü: Git Entegrasyonu ve Unity Mimarisi

Bu döküman, Git kullanımı, Unity entegrasyonu ve Yazılım Mimarisi (OOP/Interface) üzerine yapılan çalışma oturumunun özetidir. İleride hatırlamak ve mülakatlara hazırlanmak için referans olarak hazırlanmıştır.

## 1. Versiyon Kontrolü: Git vs Unity Version Control
*   **Seçimimiz:** Git.
*   **Neden?** Endüstri standardıdır (%95 kullanım), CV için kritiktir, kod (text) yönetimi konusunda rakipsizdir.
*   **Hangi Araç?** Terminal veya VS Code Source Control (Görsel Arayüz). İkisi de aynı kapıya çıkar.

### Kritik Git Komutları (Senior Seviye)
*   **Durum Kontrolü:** `git status` (Her şeyin başı).
*   **Geçmişe Dönüş (Zararsız):** `git checkout -b <branch> <id>` (Geçmişten yeni bir paralel evren yaratmak).
*   **Hata Düzeltme (Revert):** `git revert <id>` (Hatalı işlemi geri alan *yeni* bir işlem yapmak).
*   **Cımbızla Alma (Cherry-Pick):** `git cherry-pick <id>` (Başka bir daldan sadece lazım olan tek bir özelliği çekip almak).
*   **Kara Kutu (Reflog):** `git reflog` (Silinen veya kaybolan her şeyi bulmak).

### Commit Standartları (Conventional Commits)
Profesyonel görünmek için rastgele mesajlar yerine bu standart kullanılır:
*   `feat:` Yeni özellik.
*   `fix:` Hata çözümü.
*   `docs:` Dökümantasyon.
*   `chore:` Temizlik, bakım.
*   `refactor:` Kod iyileştirmesi (Çıktı değişmez).

---

## 2. Unity ve Git İlişkisi
Unity projelerini Git ile yönetirken dikkat edilmesi gereken altın kurallar:

*   **Meta Dosyaları (.meta):** Her dosyanın (script, texture, folder) kimlik kartıdır (GUID). Asla silinmemeli, Git'e mutlaka atılmalıdır. Yoksa referanslar kopar.
*   **Asset Serialization:** Unity ayarlarında "Force Text" seçili olmalıdır. Böylece sahne (.unity) ve prefab dosyalarındaki değişiklikler Git tarafından okunabilir satırlar olarak algılanır.
*   **GameObject Versiyonlama:** Sahneye eklenen bir Küp veya Ses dosyası da Git için sadece bir metin değişikliğidir. `Save` + `Commit` yaparak her şey saklanabilir.

---

## 3. Yazılım Mimarisi: Spaghetti vs Senior (SOLID)
Bir kodun "Çalışması" yetmez, "Sürdürülebilir" olması gerekir.

### Kötü Senaryo (Spaghetti)
*   **Bağımlılık:** Doğrudan sınıflara (`Pistol`, `Shotgun`).
*   **Sorun:** Yeni bir silah (Lazer) eklendiğinde, `Player` scriptini açıp `if` blokları, değişkenler eklemek gerekir.
*   **İhlal:** OCP (Open for Extension, Closed for Modification) prensibi çiğnenir.

### İyi Senaryo (Senior / Interface)
*   **Bağımlılık:** Sözleşmeye / Arayüze (`IWeapon`).
*   **Çözüm:** `Player` scripti "Bana `IWeapon` verin de ne olursa olsun" der.
*   **Sonuç:** Oyuna 100 yeni silah da eklense, `Player` kodunun tek satırı bile değişmez.

### Kavramlar
*   **Interface (Sözleşme):** İçine kod yazılmaz, sadece kurallar (metod imzaları) yazılır. Class'lar bunu imzalarsa uymak zorundadır.
*   **Abstraction (Soyutlama):** Detaylarda boğulmak yerine genel kavramlarla (Silah, Araç, Düşman) çalışmak.

---

## 4. Mülakat Tüyoları
Bir mülakatta "Git biliyor musun?" dendiğinde verilecek Senior cevap:
> "Evet, aktif kullanıyorum. **Feature-branch** yapısıyla çalışırım. Commitlerimde **Conventional** standartlarına uyarım. Olası kriz anlarında **Revert, Cherry-pick veya Reflog** kullanarak süreci yönetebilirim. Ayrıca Unity'de **.meta dosyalarının** hayati önemine ve asset serialization yapısına hakimim."
