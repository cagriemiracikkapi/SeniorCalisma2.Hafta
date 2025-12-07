using UnityEngine;

public class AttackAbility : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    public void PerformShoot()
    {
        Debug.Log("Bang! (Mermi mantığı buraya)");
        //Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
