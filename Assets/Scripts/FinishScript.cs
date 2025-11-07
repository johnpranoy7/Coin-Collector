using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject uiPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Level Complete!");
            victoryPanel.SetActive(true);
            uiPanel.SetActive(false);  //Hide the in-game UI panel when victory panel is shown
            Time.timeScale = 0f;
        }
    }
}
