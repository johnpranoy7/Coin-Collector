using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
    }

    public void loadLevelSelectionMenu()
    {
        Debug.Log("Loading SelectLevel Menu");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("SelectLevel"));
    }

    public void showAboutPage()
    {
        Debug.Log("Loading AboutPage");
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoadScene("AboutGame"));
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
