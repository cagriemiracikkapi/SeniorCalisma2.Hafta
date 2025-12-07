// PlayerHealth.cs (KÖTÜ ÖRNEK)
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerHealth_Bad : MonoBehaviour
{
    // HATA: Player sınıfı diğer HER ŞEYİ tanımak zorunda kalıyor.
    public UIManager _uiManager;

    public PlayerHealth_Bad(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    public AudioManagerEvent audioManager;
    public AchievementManager achievementManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }

    void Die()
    {
        // HATA: Biri silinirse burası NullReferenceException verir.
        _uiManager.ShowGameOverUI();
        audioManager.PlayDeathSound();
        achievementManager.UnlockAchievement();
        Debug.Log("Öldüm...");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
