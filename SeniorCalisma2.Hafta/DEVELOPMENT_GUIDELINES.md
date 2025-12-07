# PROJE GELİŞTİRME KILAVUZU VE SENIOR MÜHENDİSLİK PROTOKOLÜ

Bu belge, bu projenin geliştirme süreçlerinde **kabul edilmiş standartları** ve yapay zeka asistanı (Antigravity) ile çalışma protokolünü tanımlar. Amacımız sadece "çalışan kod" yazmak değil, ölçeklenebilir, güvenli ve "Senior" kalitesinde mühendislik çıktıları üretmektir.

---

## 1. ÇALIŞMA PROTOKOLÜ (MINDSET)

Bu projede "Junior Developer" gibi sadece syntax yazılmaz. Her satır kod, bir "Software Architect" vizyonuyla ele alınır.

### A. Sorgulayıcı Kodlama (The "Why")
*   Bir kodun **nasıl** çalıştığı kadar **neden** o şekilde yazıldığı da dökümante edilir.
*   Mimari kararlar (Interface, Abstract Class, Design Patterns) verilirken **SOLID** prensiplerinden hangisine hizmet ettiği (Örn: Open/Closed) açıklanır.
*   "Bu kod çalışıyor" yeterli değildir; "Bu kod 10.000 kullanıcıda da çalışır mı?" sorusu sorulur.

### B. Alternatif Analizi (Trade-off Analysis)
*   Sunulan çözümün tek doğru yol olmadığı bilinir.
*   **Plan A (Önerilen) vs Plan B** karşılaştırması yapılır.
*   Örnek: "Singleton pattern hızlıdır ancak Unit Test yazmayı zorlaştırır. Bu yüzden Dependency Injection tercih ettik."

---

## 2. PRODUCTION-READY CODE REVIEW KURALLARI

Yazılan her kod, canlı ortamda (Production) çalışacakmış gibi incelenir. Aşağıdaki kriterler "kırmızı çizgi"dir:

### 🛡️ Güvenlik (Security)
*   **Injection:** SQL, Command veya Code Injection riskleri taranır. Parametreli sorgular zorunludur.
*   **IDOR (Insecure Direct Object References):** ID tabanlı erişimlerde "Bu kullanıcı gerçekten bu veriyi görmeye yetkili mi?" kontrolü aranır.
*   **Sensitive Data:** Şifreler, API Key'ler asla kod içine gömülmez (Hardcoded). Environment Variable veya Vault kullanılır.

### 🚀 Performans (Performance)
*   **N+1 Problemi:** Döngü içinde veritabanı veya API çağrısı yapılması yasaktır. Batch (toplu) işlemler kullanılır.
*   **Indexing:** Sorgu yapılan sütunların indeksli olup olmadığı kontrol edilir.
*   **Memory Management (Unity Özel):** `Update()` içinde `GetComponent`, `Find` veya `new` (allocation) komutları kullanılmaz.

### 🧱 Güvenilirlik (Reliability)
*   **Transaction Yönetimi:** Birbirine bağlı işlemlerden biri hata verirse, tüm işlemlerin geri alınması (Rollback) garanti edilir (ACID).
*   **Error Handling:** `try-catch` blokları boş bırakılmaz (Swallowing Exception). Hata sadece loglanmaz, yönetilir (Retry mekanizmaları, Fallback senaryoları).
*   **Null Safety:** "Null Reference Exception" en büyük düşmandır. Guard Clause veya Optional Pattern kullanılır.

---

## 3. OTOMATİK İNCELEME TALİMATI (PROMPT)

Bu proje için AI Asistanından (Antigravity) kod istenirken şu kural varsayılan olarak kabul edilmiştir:

> *"Bu kodu production ortamı için 'Senior Backend Engineer' gözüyle incele. Security (IDOR, Injection), Performance (N+1, Indexing), ve Reliability (Transaction, Error Handling) açısından eksikleri bul ve düzeltilmiş halini yaz."*

---

*Son Güncelleme: 07.12.2025*
