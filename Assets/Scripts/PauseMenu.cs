using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (!pauseMenuUI.activeSelf)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
