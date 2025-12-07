using UnityEngine;

// 3. SOMUT YETENEK 2 (IceSpike)
[CreateAssetMenu(fileName = "IceSpike", menuName = "Scriptable Objects/IceSpike")]
public class IceSpike : Ability
{
    public float freezeDuration;

    public override void Activate(GameObject user)
    {
        Debug.Log("❄️ Buz mızrağı fırlatıldı! (Scriptable Object üzerinden)");

        //throw new System.NotImplementedException(); // İmplementasyon burada yapılacak burada IceSpike yeteneğinin işlevselliği tanımlanacak. Şuan boş bırakıldı. Mesajı vermek için uygulandı.
    }
}
