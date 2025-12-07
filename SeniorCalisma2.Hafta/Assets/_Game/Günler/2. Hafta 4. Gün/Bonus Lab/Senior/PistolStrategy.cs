using UnityEngine;

// 2. Somut Stratejiler
[CreateAssetMenu(fileName = "PistolStrategy", menuName = "Senior/WeaponStrategies/Pistol")]
public class PistolStrategy : WeaponStrategyBase, IWeaponStrategy
{
    public override void Fire(Transform firePoint)
    {
        Debug.Log("Pew! (Tabanca)");
    }
}
