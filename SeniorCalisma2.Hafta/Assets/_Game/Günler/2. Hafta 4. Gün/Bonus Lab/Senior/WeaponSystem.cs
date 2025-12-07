using UnityEngine;

// 3. Context (Kullanan Sınıf)
public class WeaponSystem : MonoBehaviour
{
    // Artık IWeaponStrategy[] yerine WeaponStrategyBase[] kullanıyoruz.
    // Çünkü ScriptableObject'ten türeyen bu sınıf Inspector'da serileştirilebilir.
    [SerializeField]
    private WeaponStrategyBase[] availableStrategies;

    [SerializeField]
    private Transform firePoint; // Mermi çıkış noktası

    private IWeaponStrategy currentStrategy;
    private int currentStrategyIndex = 0;

    void Start()
    {
        if (availableStrategies.Length > 0)
        {
            // Başlangıçta ilk stratejiyi ata
            SetWeaponStrategy(availableStrategies[currentStrategyIndex]);
        }
    }

    void Update()
    {
        // Test için silahı değiştirme (Q tuşu)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (availableStrategies.Length > 1)
            {
                currentStrategyIndex = (currentStrategyIndex + 1) % availableStrategies.Length;
                SetWeaponStrategy(availableStrategies[currentStrategyIndex]);
                // Strateji Base sınıfındaki weaponName'i kullanmak daha açıklayıcı olacaktır.
                Debug.Log(
                    $"Weapon Switched to: {(currentStrategy as WeaponStrategyBase)?.weaponName ?? "Unknown"}"
                );
            }
        }

        // Tetikleme (Space tuşu)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PullTrigger();
        }
    }

    // Stratejiyi atayan Dependency Injection metodu
    public void SetWeaponStrategy(IWeaponStrategy newStrategy)
    {
        currentStrategy = newStrategy;
    }

    public void PullTrigger()
    {
        // Strateji Interface'i üzerinden methodu çağırıyoruz.
        // WeaponSystem, Pistol mü Rocket mi olduğunu BİLMEK ZORUNDA DEĞİL.
        if (currentStrategy != null)
        {
            currentStrategy.Fire(firePoint);
        }
        else
        {
            Debug.LogWarning("No weapon strategy set!");
        }
    }
}
