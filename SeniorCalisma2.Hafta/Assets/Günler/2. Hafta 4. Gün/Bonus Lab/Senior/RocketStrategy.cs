using UnityEngine;

[CreateAssetMenu(fileName = "RocketStrategy", menuName = "Senior/WeaponStrategies/Rocket")]
public class RocketStrategy : WeaponStrategyBase
{
    public override void Fire(Transform firePoint)
    {
        Debug.Log("BOOM! (Roket)");
    }
}
