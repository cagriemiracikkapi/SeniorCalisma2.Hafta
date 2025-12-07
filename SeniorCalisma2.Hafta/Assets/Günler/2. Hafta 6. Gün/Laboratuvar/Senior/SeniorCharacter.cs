using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject tabanlı yetenek sistemini yöneten karakter sınıfı.
/// Tuş atamalarını ve yeteneklerin bekleme sürelerini yönetir.
/// Bu yapı, Open/Closed Prensibine uygun olarak yeni yeteneklerin
/// bu sınıfta hiçbir değişiklik yapmadan sisteme eklenebilmesini sağlar.
/// </summary>
public class SeniorCharacter : MonoBehaviour
{
    // Editörde ayarlanacak tuş ve yetenek eşleşmeleri.
    // AbilityRunner, her bir yeteneğin kendi bekleme süresini (cooldown) yönetmesini sağlar.
    [SerializeField]
    private List<AbilityRunner> abilities;

    // Performans için tuşlara göre yetenekleri bir Dictionary'de saklayalım.
    // Bu sayede Update içinde sürekli liste taramak yerine anında erişim sağlanır (O(1)).
    private readonly Dictionary<KeyCode, AbilityRunner> _abilityBindings =
        new Dictionary<KeyCode, AbilityRunner>();

    private void Awake()
    {
        InitializeAbilityBindings();
    }

    private void InitializeAbilityBindings()
    {
        foreach (var runner in abilities)
        {
            // Hata kontrolü: Yetenek veya tuş atanmamışsa uyarı ver.
            if (runner.abilityBase == null)
            {
                Debug.LogWarning($"Karakter üzerinde bir yetenek slotu boş bırakılmış!", this);
                continue;
            }

            // Ek hata kontrolü: Yeteneğe bir tuş atanmamışsa uyarı ver.
            if (runner.abilityBase.key == KeyCode.None)
            {
                // İkinci parametre olarak ScriptableObject'i vererek, uyarıya tıklandığında doğrudan o asset'in seçilmesini sağlarız.
                Debug.LogWarning(
                    $"'{runner.abilityBase.abilityName}' yeteneğine bir tuş atanmamış!",
                    runner.abilityBase
                );
                continue;
            }

            // Dictionary'ye ekle.
            _abilityBindings[runner.abilityBase.key] = runner;
        }
    }

    void Update()
    {
        // Her bir tuş atamasını kontrol et.
        foreach (var binding in _abilityBindings)
        {
            if (Input.GetKeyDown(binding.Key)) // Eğer atanan tuşa basıldıysa
            {
                binding.Value.TryActivate(gameObject);
            } // İlgili yeteneği çalıştırmayı dene (cooldown kontrolü içeride yapılır).
        }
    }
}
