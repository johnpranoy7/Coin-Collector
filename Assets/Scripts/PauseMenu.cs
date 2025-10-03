using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
    }

    public void Resume()
    {
        Debug.Log("START Resume Game");
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Debug.Log("Resume Game");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
