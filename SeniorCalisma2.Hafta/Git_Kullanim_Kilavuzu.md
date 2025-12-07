# Git Temel Kullanım Kılavuzu (Essential Cheat Sheet)

Bu döküman, günlük geliştirme sürecinde en sık ihtiyaç duyulan Git komutlarını ve kullanım senaryolarını özetler.

## 1. Durum Kontrolü (Neredeyim?)
Herhangi bir işlem yapmadan önce **her zaman** ilk bu komutu kullanın. "Hangi dosyalarda değişiklik var?" sorusunun cevabıdır.

*   **Komut:** `git status`

### Git Durum Harfleri ve Renkleri
`git status` veya editörünüzde dosyaların yanında gördüğünüz harflerin anlamları:

*   **A (Added):** Yeni oluşturulmuş ve sahneye eklenmiş dosya. (Yeşil)
*   **M (Modified):** Daha önce var olan ama üzerinde değişiklik yapılmış dosya.
    *   **Kırmızı M:** Değişiklik yapıldı ama henüz `add` denmedi.
    *   **Yeşil M:** Değişiklik yapıldı ve `add` ile sahneye alındı.
*   **D (Deleted):** Silinmiş dosya.
*   **U (Untracked):** Git'in henüz takibinde olmayan, yeni yaratılmış dosya. (Genelde Kırmızı görünür)
*   **Renk Kodları:**
    *   🔴 **Kırmızı:** "Ben değiştim ama henüz beni pakete koymadın."
    *   🟢 **Yeşil:** "Ben hazırım, commit edilmeyi bekliyorum."

## 2. Kaydetme Döngüsü (Save Game)
Yaptığınız işleri 2 aşamada kalıcı hale getirirsiniz:

### A. Sahneye Alma (Staging) - *Paketleme*
Değişiklikleri bir sonraki commit için hazırlar.
*   **Tüm dosyaları eklemek için:** `git add .`
*   **Tek dosya eklemek için:** `git add DosyaAdi.cs`

### B. Onaylama (Committing) - *Checkpoint Kaydetme*
Hazırlanan paketi bir mesajla tarihe kazır.
*   **Komut:** `git commit -m "Buraya ne yaptığını net bir şekilde yaz"`
    *   *Örnek:* `git commit -m "Bazooka atış mekaniği eklendi"`
    *   *İpucu:* Mesajlarınızda "güncelleme", "fix" gibi tek kelimelik ifadeler yerine, yapılan işi özetleyen emir kipli cümleler kurun.

## 3. Geçmişe Bakış (History)
Projede daha önce neler yapıldığını görmek için kullanılır.
*   **Detaylı Liste:** `git log` (Çıkmak için `q` tuşuna basın)
*   **Özet Liste:** `git log --oneline` (Sadece ID ve mesajı gösterir, daha temizdir)

## 4. Şubeler (Branching) - *Parallel Evrenler*
Ana projeyi (`main`) bozmadan yeni bir özellik denemek veya geliştirmek için **mutlaka** kullanılmalıdır.

*   **Yeni Branch Oluştur ve Geç:** `git checkout -b yeni-ozellik-ismi`
*   **Mevcut Branch'e Geç:** `git checkout branch-ismi`
*   **Branch'leri Listele:** `git branch`

### Branch Birleştirme (Merge)
İşiniz bittiğinde özellikleri ana projeye dahil etmek için:
1.  Ana dala dön: `git checkout main`
2.  Diğer dalı içine al: `git merge yeni-ozellik-ismi`

## 5. Geri Alma (Undo & Restore)
Kaydedilmemiş değişiklikleri çöpe atmak ve dosyanın son temiz haline dönmek için kullanılır.
*   **Komut:** `git restore DosyaAdi.cs`
    *   ⚠️ **Uyarı:** Bu işlem geri alınamaz, dosyadaki kaydedilmemiş işlerinizi siler.

## 6. Uzak Sunucu (Remote / GitHub)
Kodlarınızı yerel bilgisayarınızdan GitHub/GitLab gibi sunuculara göndermek için.
*   **Komut:** `git push origin main` (veya bulunduğunuz branch ismi)

---

## 🛡️ Unity İçin Özel Notlar
*   **Metadata (.meta) Dosyaları:** Unity'de her dosyanın bir `.meta` dosyası vardır. Bir scripti veya asset'i siliyorsanız/taşıyorsanız, `.meta` dosyasının da Git tarafından işlendiğinden emin olun.
*   **.gitignore:** `Library`, `Temp`, `Logs`, `Build` gibi klasörler asla Git'e atılmamalıdır. Projenin başında doğru bir `.gitignore` dosyası olduğundan emin olun.
