using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public GameObject MainMenu;
    public string MainSceneName;
    public GameObject Prelog;

    private void Awake()
    {
        Prelog.SetActive(false);
        MainMenu.SetActive(true);
        ////NameMenu.SetActive(false);
        //if (HighScore != null)
        //    HighScore.SetActive(false);
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        //NameMenu.SetActive(true);
        //HighScore.SetActive(false);
    }

    public void ConfirmName()
    {
        Cursor.visible = false;

        Prelog.SetActive(true);
        Invoke("LoadScenes", 5);
    }

    public void LoadScenes()
    {
        SceneManager.LoadSceneAsync(MainSceneName);
    }

    public void CheckHighScore()
    {
        MainMenu.SetActive(false);
        //NameMenu.SetActive(false);
        //HighScore.SetActive(true);
    }

    public void BackToMenu()
    {
        MainMenu.SetActive(true);
        //NameMenu.SetActive(false);
        //HighScore.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
