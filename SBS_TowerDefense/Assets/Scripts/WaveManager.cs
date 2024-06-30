using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    private float spawnRate = 5f;
    private float countdown = 3f;
    [SerializeField] private Transform spawnPoint;
    private int waveIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = spawnRate;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {

        waveIndex++;
        for (int i = 0; i < waveIndex; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        GameManager.instance.IncreaseEnemyCount();
    }
}
