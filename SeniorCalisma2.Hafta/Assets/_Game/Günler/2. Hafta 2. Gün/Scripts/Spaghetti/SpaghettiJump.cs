using UnityEngine;

// SORUN: Player, "AudioManager" sınıfına göbekten bağlı.
// AudioManager sahnede yoksa bu kod çalışmaz.
// Başka bir ses sistemine geçmek için bu kodu silip yeniden yazman gerekir.

public class SpaghettiJump : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TIGHT COUPLING (Sıkı Bağlılık)
            AudioManager.Instance.PlaySound("Jump");
            Debug.Log("Zıpladı!");
        }
    }
}