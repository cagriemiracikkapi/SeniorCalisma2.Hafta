using UnityEngine;

public class TurretSpaghetti : Enemy
{
    // HATA: Turret bir Enemy'dir ama yürüyemez.
    // Miras aldığı metodu boşa çıkarmak veya hata fırlatmak LSP ihlalidir.
    void Start()
    {

        Move();
    }
    public override void Move()
    {
        throw new System.Exception("Ben kuleyim, yürüyemem!");
    }
}