using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform bossPrefab;
    private float spawnRate = 5f;
    private float countdown = 3f;
    public static int maxEnemies = 12;
    [SerializeField] private Transform spawnPoint;
    private int waveIndex = 0;
    private int maxWaves = 5;
    public static int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f && waveIndex < maxWaves) {
            StartCoroutine(SpawnWave());
            countdown = spawnRate;
        }
        countdown -= Time.deltaTime;
        if(waveIndex == maxWaves && enemyCount == 0)
        {
            GameManager.EndGame(true);
        }
        if(enemyCount >= maxEnemies)
        {
            GameManager.EndGame(false);
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        if(waveIndex < maxWaves)
        {   
            for (int i = 0; i < waveIndex; i++) 
            {
                SpawnNormalEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (waveIndex == maxWaves)
        {
            for (int i = 0; i < waveIndex; i++) 
            {
                SpawnNormalEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            SpawnBossEnemy();
        }
    }

    void SpawnNormalEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        IncreaseEnemyCount();
    }

    void SpawnBossEnemy()
    {
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Boss enemy spawned");
        IncreaseEnemyCount();
    }

    public static void IncreaseEnemyCount() {
        enemyCount++;
    }

    public static void DecreaseEnemyCount()
    {
        enemyCount--;
    }
}
