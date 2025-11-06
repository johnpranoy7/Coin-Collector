using UnityEngine;
using UnityEngine.UI;

public class MainCanvasCustomizer : MonoBehaviour
{
    public Text coinText;
    public GameObject pausePanel;

    void Update()
    {
        if (!pausePanel.activeSelf)
        {
            coinText.color = new Color(0.18f, 0.13f, 0.18f);
        }
        else
        {
            coinText.color = Color.white;
        }
    }
}
