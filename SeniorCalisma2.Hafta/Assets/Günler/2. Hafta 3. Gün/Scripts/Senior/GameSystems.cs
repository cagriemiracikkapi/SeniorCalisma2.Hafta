// 2. DİNLEYİCİ (GameSystems.cs)
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSystems : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth; // Kimi dinleyeceğiz?

    [SerializeField]
    private TMP_Text uiText;

    // Abone olma işlemi (Genelde OnEnable'da yapılır)
    private void OnEnable()
    {
        if (playerHealth != null)
        {
            // += Operatörü: Frekansa bağlanmak
            playerHealth.OnPlayerDied += ShowGameOverUI;
            playerHealth.OnPlayerDied += PlayDeathSound;
            playerHealth.OnPlayerDied += UnlockAchievement;
        }
    }

    // Abonelikten çıkma (ÇOK ÖNEMLİ - Memory Leak ve Hata önler)
    private void OnDisable()
    {
        if (playerHealth != null)
        {
            // -= Operatörü: Frekansı kapatmak
            playerHealth.OnPlayerDied -= ShowGameOverUI;
            playerHealth.OnPlayerDied -= PlayDeathSound;
            playerHealth.OnPlayerDied -= UnlockAchievement;
        }
    }

    // --- Tepkiler ---

    void ShowGameOverUI()
    {
        uiText.text = "GAME OVER";
        Debug.Log("🖥️ UI: Game Over ekranı açıldı.");
        Debug.Log("🖥️ Çalışan obje: " + gameObject.name);
    }

    void PlayDeathSound()
    {
        Debug.Log("🎵 Audio: Hüzünlü müzik çalıyor.");
    }

    void UnlockAchievement()
    {
        Debug.Log("🏆 Achievement: 'İlk Kan' başarımı kazanıldı.");
    }
}
