using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void loadEasyLevel()
    {
        Debug.Log("Loading Easy Level");
        Time.timeScale = 1f;
        SceneManager.LoadScene("EasyLevel");
    }

    public void loadMediumLevel()
    {
        Debug.Log("Loading Medium Level");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MediumLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
