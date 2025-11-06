using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
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
