using UnityEngine;

public class SeniorUIManager2_5 : MonoBehaviour, IUIService2_5
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Kendini sisteme kaydettir
        ServiceLocator2_5.Register<IUIService2_5>(this);
        DontDestroyOnLoad(gameObject); // Sahne geçişinde yaşasın
    }

    void OnDestroy()
    {
        // Sahneden çıkarken kaydı sil (Temizlik)
        ServiceLocator2_5.Unregister<IUIService2_5>();
    }

    public void ShowMessage(string message)
    {
        Debug.Log($"🔊 Message: {message}");
    }
}
