using UnityEngine;

// Ateş Eden Düşman - Sorun yok gibi
public class ShootingEnemy : EnemySpagetti
{
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log("Pew Pew!");
    }
}
