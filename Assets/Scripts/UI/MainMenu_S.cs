using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_S : MonoBehaviour
{
    public string levelToLoad = "Level01";

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
