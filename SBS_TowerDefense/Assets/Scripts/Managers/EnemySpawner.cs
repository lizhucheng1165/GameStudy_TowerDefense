using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnPoint;
    [SerializeField]
    private GameObject enemyPrefab;
    public WaveData[] waveData;
    private int waveIndex;
    public int WaveIndex
    {
        get { return waveIndex; }
        set
        {
            if (waveIndex < 4)
            {
                waveIndex = value;
            }
        }
    }
    public float waveElapsedTime;
    private void Awake()
    {
        WaveIndex = 0;
        GameManager.Instance.spawnInterval = 1.0f;
        spawnPoint = this.transform.position;
        waveElapsedTime = 0;
        StartSpawnCurrentWave();
    }

    void Update()
    {
        enemyPrefab = GetWavePrefab();

        if (GameManager.Instance.spawnCount >= waveData[WaveIndex].EnemySpawnMaxCount)
        {
            StopSpawning();
        }
        if (UpdateElapsedTime())
        {
            StartSpawnCurrentWave();
        }
    }
   
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        GameManager.Instance.spawnCount++;
    }
    private void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
        GameManager.Instance.spawnCount = 0;
        AddWaveIndex();
    }

    private void StartSpawnCurrentWave()
    {
        InvokeRepeating("SpawnEnemy", 0.3f, GameManager.Instance.spawnInterval);
    }

    private bool UpdateElapsedTime()
    {
        if (waveElapsedTime >= GameManager.Instance.waveInterval)
        {
            waveElapsedTime = 0;
            return true;
        }

        waveElapsedTime += Time.deltaTime;
        

        return false;
    }
    private void AddWaveIndex()
    {
        WaveIndex++;
    }

    private GameObject GetWavePrefab()
    {
        return waveData[WaveIndex].EnemyPreFabs[GetCurrentWaveEnemyTypeNumber()];
    }

    private int GetCurrentWaveEnemyTypeNumber()
    {
        if (waveData[WaveIndex].WaveEnemyType == EnemyType.MIXED)
        {
            return Random.Range(0, 3);
        }

        return (int)waveData[WaveIndex].WaveEnemyType;
    }
}
