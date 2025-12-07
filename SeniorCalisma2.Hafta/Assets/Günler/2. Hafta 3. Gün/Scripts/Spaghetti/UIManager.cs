using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text uiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void ShowGameOverUI()
    {
        uiText.text = "GAME OVER";
        Debug.Log("🖥️ UI: Game Over ekranı açıldı.");
    }
}
