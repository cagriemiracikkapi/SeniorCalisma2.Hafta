using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Fire()
    {
        Debug.Log("Senior Pistol: Bam! (Hızlı)");
    }

    // Update is called once per frame
}
