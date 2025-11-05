using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
    }

    public void loadEasyLevel()
    {
        Debug.Log("Loading Easy Intro");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("EasyIntro"));
    }

    public void loadMediumLevel()
    {
        Debug.Log("Loading Medium Intro");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("MediumIntro"));
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
