using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance { get; private set; }

    void Awake()
    {
        // Eğer zaten bir Kral varsa, ben sahteyim, beni yok et.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Kral benim.
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
