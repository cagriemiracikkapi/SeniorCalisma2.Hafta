using System;
using System.Collections.Generic;
using UnityEngine;

// 3. Servis Sağlayıcı (Musluk)
public class SeniorAudioManager2_5 : MonoBehaviour, IAudioService2_5
{
    void Awake()
    {
        // Kendini sisteme kaydettir
        ServiceLocator2_5.Register<IAudioService2_5>(this);
        DontDestroyOnLoad(gameObject); // Sahne geçişinde yaşasın
    }

    void OnDestroy()
    {
        // Sahneden çıkarken kaydı sil (Temizlik)
        ServiceLocator2_5.Unregister<IAudioService2_5>();
    }

    public void PlaySound(string clipName)
    {
        Debug.Log($"🔊 Senior Audio Playing: {clipName}");
    }
}
