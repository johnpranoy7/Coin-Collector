using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void loadEasyLevel()
    {
        Debug.Log("Loading Easy Level");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("EasyLevel"));
    }

    public void loadMediumLevel()
    {
        Debug.Log("Loading Medium Level");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("MediumLevel"));
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
