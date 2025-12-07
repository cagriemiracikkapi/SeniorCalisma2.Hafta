// GameManager.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq; // LINQ kullanımı için eklendi.

public class GameManager : MonoBehaviour
{
    // Bu yöntem, Inspector'da atama yapabilmek için en esnek ve doğru yöntemlerden biridir.
    // Kapsüllemeyi korumak için liste private ve [SerializeField] olarak işaretlenmiş. Bu çok iyi bir pratik.
    [SerializeField] private List<GameObject> enemyObjects;

    private readonly List<IMovable> _movingEnemies = new List<IMovable>();

    void Awake()
    {
        // Reliability: Inspector'dan atanan ana listenin null olma ihtimaline karşı koruma.
        if (enemyObjects == null) return;

        foreach (var obj in enemyObjects)
        {
            // Reliability: Listeye Inspector'dan yanlışlıkla null bir eleman atanmış olabilir.
            if (obj == null)
            {
                Debug.LogWarning("enemyObjects listesinde null bir eleman var. Atlandı.");
                continue;
            }

            // Objede IMovable arayüzünü uygulayan bir component var mı diye bak.
            IMovable movable = obj.GetComponent<IMovable>();

            if (movable != null)
            {
                _movingEnemies.Add(movable);
            }
            else
            {
                // Bu loglama, geliştirme aşamasında hayat kurtarır. Çok doğru bir yaklaşım.
                Debug.LogError($"{obj.name} objesinde IMovable component'i bulunamadı. Hareket listesine eklenmedi.");
            }
        }
    }

    void Start()
    {
        // Reliability: Oyun sırasında bir düşman yok edilirse listedeki referansı null olur.
        // Bu kontrol, NullReferenceException'ı engeller.
        foreach (var enemy in _movingEnemies)
        {
            // UnityEngine.Object için null kontrolü bu şekilde yapılmalıdır.
            // 'enemy as Object' cast işlemi, Unity'nin özel null kontrol mekanizmasını (yok edilmiş objeler için) tetikler.
            if (enemy as Object != null)
            {
                enemy.Move();
            }
        }
    }
}