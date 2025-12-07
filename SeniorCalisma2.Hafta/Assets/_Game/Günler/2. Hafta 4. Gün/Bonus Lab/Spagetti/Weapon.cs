using UnityEngine;

public class WeaponSpaghetti : MonoBehaviour
{
    // Yeni silah tipleri buraya eklenmek zorunda.
    enum WeaponType
    {
        Pistol,
        Rocket,
        Laser, // Yeni eklendiğinde Fire() metodu da değişmek ZORUNDA!
    }

    private WeaponType currentWeapon = WeaponType.Pistol;

    void Start()
    {
        // Silahı test etmek için Rocket'e alalım

        // Bir kere ateş edelim ki konsolda görelim.
        Fire();
    }

    // Normalde bu metot Update içinde çağrılmaz, sadece test için burada.
    public void Fire()
    {
        // ❌ OCP İHLALİ: Yeni silah eklediğinde bu switch-case'i açıp değiştirmek zorundasın!
        switch (currentWeapon)
        {
            case WeaponType.Pistol:
                Debug.Log("Pistol: STANDART mermi attı.");
                break;
            case WeaponType.Rocket:
                Debug.Log("Rocket: YAVAŞ ama BÜYÜK hasar veren roket fırlattı.");
                break;
            // Laser eklenirse buraya Case eklemek ZORUNDASIN.
            default:
                Debug.Log("Bilinmeyen silah: " + currentWeapon.ToString());
                break;
        }
    }
}
