using System.Collections;
using myUIEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject uiPanel;


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
        pausePanelLogic();
        Debug.Log("displayPauseMenuFromEvent received");
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanelLogic();
        }
    }

    void pausePanelLogic()
    {
        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;

            uiPanel.SetActive(false); // Hide the in-game UI panel when paused
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;

            uiPanel.SetActive(true);
        }
    }

    public void Resume()
    {
        Debug.Log("START Resume Game");
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Debug.Log("Resume Game");
        uiPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Debug.Log("START Resume Game");
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;

        uiPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void loadBackMainMenu()
    {
        Debug.Log("Loading Mainmenu Page");
        StartCoroutine(WaitAndLoadScene("MainMenu"));
        Time.timeScale = 1f;
    }

    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
