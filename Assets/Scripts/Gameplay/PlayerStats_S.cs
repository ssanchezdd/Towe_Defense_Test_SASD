using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_S : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;
    public int startingLives = 20;
    public static int lives;
    private void Start()
    {
        lives = startingLives;
        money = startMoney;
    }
}
