using UnityEngine;

// Zombi hem yürür hem saldırır
public class ZombieSenior : MonoBehaviour, IMovable, IAttackable
{
    void Start()
    {

    }
    public void Move() { Debug.Log("Zombi yürüyor..."); }
    public void Attack() { Debug.Log("Zombi ısırıyor!"); }
}