using UnityEngine;

[System.Serializable]
public class AbilityRunner
{
    public Ability abilityBase; // Hangi yetenek? (Statik Veri)
    private float cooldownTimer; // Ne zaman hazır olacak? (Dinamik Veri)

    public void TryActivate(GameObject user)
    {
        if (Time.time >= cooldownTimer)
        {
            abilityBase.Activate(user);
            cooldownTimer = Time.time + abilityBase.cooldownTime;
        }
        else
        {
            Debug.Log($"⏳ {abilityBase.abilityName} beklemede! {cooldownTimer - Time.time:F1}s");
        }
    }
}
