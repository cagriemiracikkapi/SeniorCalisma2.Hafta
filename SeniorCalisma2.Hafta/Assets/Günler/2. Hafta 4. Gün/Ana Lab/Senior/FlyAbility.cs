// --- Capabilities (Yetenekler) ---

using UnityEngine;

// 1. Sadece bir işi yapan küçük bileşenler
public class FlyAbility : MonoBehaviour
{
    [SerializeField]
    private float flySpeed = 5f;

    public void PerformFly()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }
}
