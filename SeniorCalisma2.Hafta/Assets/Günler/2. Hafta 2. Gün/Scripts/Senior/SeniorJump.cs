using UnityEngine;

// 3. TÜKETİCİ (Consumer): Player
public class SeniorJump : MonoBehaviour
{
    // Bağımlılığı Interface olarak tutuyoruz.
    private IAudioService _audioService;

    // INJECTION NOKTASI (Method Injection)
    // MonoBehaviour'larda Constructor kullanamadığımız için "Initialize" kullanırız.
    public void Initialize(IAudioService audioService)
    {
        _audioService = audioService;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Null Check: Servis atanmamışsa hata vermesin.
            _audioService?.PlayJumpSound();
            Debug.Log("Senior Zıpladı!");
        }
    }
}