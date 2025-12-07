using UnityEngine;

// 2. Abstract Base Class (ScriptableObject)
// Bu, Unity'nin serileştirebildiği bir yapıdır ve Interface'i uygular.
// Bütün stratejiler bu sınıftan türeyecek.
public abstract class WeaponStrategyBase : ScriptableObject, IWeaponStrategy
{
    [Header("Base Settings")]
    public string weaponName = "Unknown Weapon";
    public float fireRate = 0.5f;

    // Abstract Method: Çocuk sınıfların MUTLAKA doldurması gereken zorunlu görev.
    public abstract void Fire(Transform firePoint);
}
