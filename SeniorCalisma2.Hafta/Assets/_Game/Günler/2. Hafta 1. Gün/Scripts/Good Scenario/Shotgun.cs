using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Fire()
    {
        Debug.Log("Senior Shotgun: BUM! (Geniş Alan)");
    }

    public void FireSpagetti()
    {
        Debug.Log("Spagetti Shotgun: BUM! (Geniş Alan)");
    }
}
