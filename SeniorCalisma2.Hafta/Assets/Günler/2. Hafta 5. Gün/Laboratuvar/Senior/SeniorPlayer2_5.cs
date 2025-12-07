using System;
using System.Collections.Generic;
using UnityEngine;

// 4. Kullanıcı (Ev Sahibi)
public class SeniorPlayer2_5 : MonoBehaviour
{
    private IUIService2_5 mes;
    private IAudioService2_5 audioS;

    void Start()
    {
        mes = ServiceLocator2_5.Get<IUIService2_5>();
        audioS = ServiceLocator2_5.Get<IAudioService2_5>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            try
            {
                mes.ShowMessage("Hello Player!");
                audioS.PlaySound("Attack");
            }
            catch (Exception e)
            {
                Debug.LogError("Null objeye erişmeye çalıştınız: " + e.Message);
            }
        }
    }
}
