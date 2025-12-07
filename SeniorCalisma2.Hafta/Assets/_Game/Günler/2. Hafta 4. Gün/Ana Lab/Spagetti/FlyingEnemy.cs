using UnityEngine;

// Uçan Düşman - Sorun yok gibi
public class FlyingEnemy : EnemySpagetti
{
    void Update()
    {
        Fly();
    }

    public void Fly()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
