using UnityEngine;
using UnityEngine.UI;

public class MainCanvasCustomizer : MonoBehaviour
{
    public Text coinText;
    public GameObject pausePanel;
    public GameObject victoryPanel;

    void Update()
    {
        if (pausePanel.activeSelf || victoryPanel.activeSelf)
        {
            coinText.color = Color.white;
        }
        else
        {
            coinText.color = new Color(0.18f, 0.13f, 0.18f);
        }
    }
}
