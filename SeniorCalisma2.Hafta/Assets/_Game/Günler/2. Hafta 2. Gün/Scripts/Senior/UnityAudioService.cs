using UnityEngine;
// 2. SERVİS (Concrete Implementation): Gerçek işi yapan sınıf.
public class UnityAudioService : IAudioService
{
    private readonly AudioSource _audioSource;
    private readonly AudioClip _jumpClip;

    // Dependency Injection: Gerekli bileşenleri constructor üzerinden alıyoruz.
    // Bu, sınıfı daha test edilebilir ve bağımsız hale getirir.
    public UnityAudioService(AudioSource audioSource, AudioClip jumpClip)
    {
        _audioSource = audioSource;
        _jumpClip = jumpClip;
    }

    public void PlayJumpSound()
    {
        // Reliability: Ses kaynağının veya klibin atanmamış olma ihtimaline karşı kontrol.
        // Bu, NullReferenceException'ı önler.
        if (_audioSource != null && _jumpClip != null)
        {
            // PlayOneShot, aynı anda birden fazla ses efekti çalmak için idealdir
            // ve diğer sesleri kesmez.
            _audioSource.PlayOneShot(_jumpClip);

            Debug.Log($"Unity Ses Çalıyor: Jump {_jumpClip}");
        }
    }
}
