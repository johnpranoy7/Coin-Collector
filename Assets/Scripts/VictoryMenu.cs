using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject uiPanel;

    void Update()
    {
      Cursor.visible = true;
    }

    public void backtoMainMenu()
    {
        Debug.Log("Loading MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);

        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;

        uiPanel.SetActive(true);
    }

    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
