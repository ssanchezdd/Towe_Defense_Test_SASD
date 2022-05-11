using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel_S : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }
}
