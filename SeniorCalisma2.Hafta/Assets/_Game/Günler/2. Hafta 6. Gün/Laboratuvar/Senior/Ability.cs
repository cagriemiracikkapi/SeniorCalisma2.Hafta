using UnityEngine;

// 1. SOYUT YETENEK (Şablon)
// ScriptableObject olduğu için sahneye koyulmaz, proje dosyasında Asset olarak yaşar.
public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldownTime;
    public KeyCode key;

    // Yeteneğin ne yapacağını 'user' (kullanan) parametresiyle belirleriz.
    public abstract void Activate(GameObject user);
}
