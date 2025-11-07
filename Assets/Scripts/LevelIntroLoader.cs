using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntroLoader : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
    }

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

    public void loadInstructionsToEasy()
    {
        Debug.Log("Loading Instructions Page");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("InstructionsToEasy"));
    }

    public void loadEasyIntro()
    {
        Debug.Log("Loading Easy Intro");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("EasyIntro"));
    }

    public void loadMediumIntro()
    {
        Debug.Log("Loading Medium Intro");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("MediumIntro"));
    }

    public void loadInstructionsToMenium()
    {
        Debug.Log("Loading Instructions Page");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("InstructionsToMedium"));
    }

    public void loadBackSelectLevel()
    {
        Debug.Log("Loading SelectLevel Page");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("SelectLevel"));
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
