using UnityEngine;

// Kötü Singleton Örneği
public class BadAudioManager : MonoBehaviour
{
    // Global erişim noktası - TEHLİKELİ
    public static BadAudioManager Instance;

    void Awake()
    {
        // Eğer sahnede başka bir tane varsa kendini yok etmeli (fakat bu basit haliyle yetersiz)
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // Bu açılırsa sahne geçişinde sorunlar başlar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string clipName)
    {
        Debug.Log("Playing sound (Bad Way): " + clipName);
    }
}
