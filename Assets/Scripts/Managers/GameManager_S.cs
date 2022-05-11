using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_S : MonoBehaviour
{
    private static bool gameIsOver;
    public GameObject gameOverPanel;
    public GameObject completedLevelPanel;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    private void Start()
    {
        gameIsOver = false;
    }
    private void Update()
    {
        if (gameIsOver) return;
        if (PlayerStats_S.lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverPanel.SetActive(true);
        PlayerPrefs.SetInt("recentlyDied", 1);
    }


    public void WinLevel()
    {
        gameIsOver = true;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        completedLevelPanel.SetActive(true);
    }
}
