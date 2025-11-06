using System.Collections;
using myUIEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;


    private void OnEnable()
    {
        MobileHandler.showPauseMenuEvent.AddListener(displayPauseMenuFromEvent);
        Debug.Log("showPauseMenuEvent listener added");
    }

    private void OnDisable()
    {
        MobileHandler.showPauseMenuEvent.RemoveListener(displayPauseMenuFromEvent);
        Debug.Log("showPauseMenuEvent listener removed");
    }

    private void displayPauseMenuFromEvent() 
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
        Debug.Log("displayPauseMenuFromEvent received");
    }

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

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Debug.Log("START Resume Game");
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void loadBackMainMenu()
    {
        Debug.Log("Loading Mainmenu Page");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
