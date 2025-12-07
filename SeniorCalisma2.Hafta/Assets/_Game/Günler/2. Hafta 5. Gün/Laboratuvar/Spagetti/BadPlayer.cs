using UnityEngine;

public class BadPlayer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Sıkı Bağlılık (Tightly Coupled)
            // Eğer BadAudioManager sahnede yoksa oyun ÇÖKER.
            BadAudioManager.Instance.PlaySound("Jump");
        }
    }
}
