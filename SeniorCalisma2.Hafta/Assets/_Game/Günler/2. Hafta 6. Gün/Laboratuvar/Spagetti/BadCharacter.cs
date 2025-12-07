using UnityEngine;

public class BadCharacter : MonoBehaviour
{
    private enum SkillType
    {
        Fireball,
        Speed,
        Shield,
        Invisibility,
    } // Liste uzadıkça yönetilemez

    [SerializeField]
    private SkillType currentSkill;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // OCP İHLALİ: Her yeni yetenekte buraya yeni bir 'else if' eklemek zorundasın.
            if (currentSkill == SkillType.Fireball)
            {
                Debug.Log("🔥 Ateş topu atıldı! (Kodun içinden)");
            }
            else if (currentSkill == SkillType.Speed)
            {
                Debug.Log("⚡ Hızlanıldı! (Kodun içinden)");
            }
            // else if (currentSkill == SkillType.Shield) ...
        }
    }
}
