using UnityEngine;

// 2. SOMUT YETENEK 1 (Ateş Topu)
[CreateAssetMenu(fileName = "FireballAbility", menuName = "Scriptable Objects/FireballAbility")]
public class FireballAbility : Ability
{
    public float damage;

    public override void Activate(GameObject user)
    {
        Debug.Log("🔥 Ateş topu atıldı! (Scriptable Object üzerinden)");
        //throw new System.NotImplementedException(); İmplementasyon burada yapılacak burada Fireball yeteneğinin işlevselliği tanımlanacak. Şuan boş bırakıldı. Mesajı vermek için uygulandı.
    }
}
