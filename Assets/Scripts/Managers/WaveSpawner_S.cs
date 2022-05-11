using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner_S : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave_S[] waves;

    public Transform enemyPrefabTransform;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    private int waveIndex;

    public TextMeshProUGUI waveCountDownText;

    public GameManager_S gameManager_S;

    private void Start()
    {
        waveIndex = 0;
        this.enabled = true;
    }

    private void Update()
    {
        //check if player recentlyDied, 0 is no, 1 is yes
        if (PlayerPrefs.GetInt("recentlyDied") == 1)
        {
            waveIndex = 0;
            PlayerPrefs.SetInt("recentlyDied", 0);
        }
        if (enemiesAlive > 0) { return; }
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);

        waveCountDownText.text = Mathf.Round(countDown).ToString();

        if (waveIndex >= waves.Length && enemiesAlive <= 0)
        {
            gameManager_S.WinLevel();
            this.enabled = false;
        }
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");

        Wave_S wave = waves[waveIndex];
        for (int i = 0; i < wave.countOfWaves; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rateOfAppearance);
        }

        waveIndex++;
   
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }

}
