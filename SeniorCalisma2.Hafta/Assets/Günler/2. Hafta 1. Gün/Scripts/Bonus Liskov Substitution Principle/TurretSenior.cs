using UnityEngine;
// Kule (Turret) sadece saldırır, IMovable almaz.
// Böylece kodda yanlışlıkla Turret.Move() çağırma ihtimali kalmaz.
public class TurretSenior : MonoBehaviour, IAttackable
{
    void Start()
    {
       

    }
    public void Move() { Debug.Log("Kule yürüyor..."); }
    public void Attack() { Debug.Log("Kule ateş ediyor!"); }

}
