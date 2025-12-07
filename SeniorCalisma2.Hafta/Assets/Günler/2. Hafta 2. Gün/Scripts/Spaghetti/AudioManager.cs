using UnityEngine;

// Spagetti Audio Manager (Singleton)
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake() { Instance = this; }

    public void PlaySound(string clipName)
    {
        Debug.Log("Spagetti Ses Çalıyor: " + clipName);
    }
}
