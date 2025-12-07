using UnityEngine;

public class Laser : MonoBehaviour, IWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Fire()
    {
        Debug.Log("Senior Laser: BUM! (İnce Çizgi)");
    }
}
