using UnityEngine;

// 4. BAŞLATICI (Bootstrapper / Composition Root)
// Tüm bağlantıları kuran patron sınıf.
public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private SeniorJump _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSoundClip;

    void Awake()
    {
        // 1. Servisi oluştur (Pili al)
        // Performance: Bağımlılıkları (dependency) constructor üzerinden vererek
        // servisin içinde FindObjectOfType gibi yavaş işlemler yapmasını engelliyoruz.
        IAudioService audioService = new UnityAudioService(_audioSource, _jumpSoundClip);

        // 2. Bağımlılığı enjekte et (Pili arabaya tak)
        _player.Initialize(audioService);

        Debug.Log("🚀 Oyun Başlatıldı: Bağımlılıklar Enjekte Edildi.");
    }
}
