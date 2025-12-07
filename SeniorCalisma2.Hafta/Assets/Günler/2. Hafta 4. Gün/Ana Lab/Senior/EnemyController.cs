using UnityEngine;

// 2. Beyin (Controller) - Bağımlılıkları yönetir
// Bu sınıfın uçma veya ateş etme kodunu bilmesine gerek yoktur, sadece tetikler.
public class EnemyController : MonoBehaviour
{
    // Opsiyonel: Zorunlu bileşen kontrolü
    private FlyAbility _flyAbility;
    private AttackAbility _shootAbility;

    private void Awake()
    {
        // Bileşenleri kendi üzerimizde arıyoruz (Composition)
        _flyAbility = GetComponent<FlyAbility>();
        _shootAbility = GetComponent<AttackAbility>();
    }

    private void Update()
    {
        // Eğer uçma yeteneği takılıysa uç
        if (_flyAbility != null)
        {
            _flyAbility.PerformFly();
        }

        // Eğer ateş etme yeteneği takılıysa ve zamanı geldiyse ateş et
        if (_shootAbility != null && Input.GetKeyDown(KeyCode.Space))
        {
            _shootAbility.PerformShoot();
        }
    }
}
