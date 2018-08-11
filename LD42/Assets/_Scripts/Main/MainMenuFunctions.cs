using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject NameMenu;
    public GameObject HighScore;
    public string MainSceneName;

    public InputField NameField;

    private void Awake()
    {
        MainMenu.SetActive(true);
        NameMenu.SetActive(false);
        HighScore.SetActive(false);
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        NameMenu.SetActive(true);
        HighScore.SetActive(false);
    }

    public void ConfirmName()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(MainSceneName);
    }

    public void CheckHighScore()
    {
        MainMenu.SetActive(false);
        NameMenu.SetActive(false);
        HighScore.SetActive(true);
    }

    public void BackToMenu()
    {
        MainMenu.SetActive(true);
        NameMenu.SetActive(false);
        HighScore.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
