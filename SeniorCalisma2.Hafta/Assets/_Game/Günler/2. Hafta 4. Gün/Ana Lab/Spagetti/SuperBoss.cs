using UnityEngine;

// SORUN BURADA: Hem uçan hem ateş eden düşman?
// C#'ta "public class SuperBoss : FlyingEnemy, ShootingEnemy" YAPILAMAZ!
// Mecburen kodları kopyala yapıştır yapacağız:
public class SuperBoss : EnemySpagetti
{
    void Start() { }

    void Update()
    {
        Fly();
        Shoot();
    }

    // FlyingEnemy'den kopyalandı (DRY Prensibi İhlali)
    public void Fly()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }

    // ShootingEnemy'den kopyalandı (DRY Prensibi İhlali)
    public void Shoot()
    {
        Debug.Log("Pew Pew!");
    }

    public override void Attack()
    {
        Debug.Log("SuperBoss Attack!");
    }
}
