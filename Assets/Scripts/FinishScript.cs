using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject victoryPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Level Complete!");
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
