// 1. YAYINCI (PlayerHealth.cs)
using System; // Action için gerekli
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Olay Tanımı: Sadece "Action" tipinde bir değişken.
    // Dışarıdan abone olunabilir (public) ama tetikleme sadece buradan yapılır.
    public event Action OnPlayerDied;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("💀 Player: Ben öldüm! (Sinyal yayılıyor)");

        // Olayı Tetikle (Invoke)
        // "?." operatörü "Eğer dinleyen (abone) varsa çalıştır" demektir.
        OnPlayerDied?.Invoke();
    }
}
