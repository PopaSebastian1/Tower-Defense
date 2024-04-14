using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        GameType.instance.SetHardMode(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartHardGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        GameType.instance.SetHardMode(true);
    }
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
