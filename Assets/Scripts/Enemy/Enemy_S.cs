using UnityEngine;

public class Enemy_S : MonoBehaviour
{
    public float speed = 10f;

    public float health = 100;

    public int moneyGiven = 50;

    private bool isDead = false;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {

        isDead = true;

        PlayerStats_S.money += moneyGiven;

        WaveSpawner_S.enemiesAlive--;

        Destroy(gameObject);
    }

}
