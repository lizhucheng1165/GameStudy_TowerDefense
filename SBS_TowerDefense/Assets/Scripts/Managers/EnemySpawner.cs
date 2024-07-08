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
    private float maintenanceTime;
    public int WaveIndex
    {
        get { return waveIndex; }
        set
        {
            if (waveIndex < 4)
            {
                waveIndex = value;
            }
            else
            {
                print("waveIndex가 너무 큽니다");
            }
        }
    }
    public float waveElapsedTime;
    private void Awake()
    {
        WaveIndex = 0;
        GameManager.Instance.spawnInterval = 1.0f;
        if (GameManager.Instance.mode == DebugMode.DEBUGGING)
        {
            GameManager.Instance.waveInterval = 5.0f;
        }
        else
        {
            GameManager.Instance.waveInterval = 60f;
        }
        spawnPoint = this.transform.position;
        waveElapsedTime = 0;
        maintenanceTime = 5.0f;
    }
    private void Start()
    {
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
        GameManager.Instance.EnemyCount++;
    }
    private void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
        GameManager.Instance.spawnCount = 0;
        AddWaveIndex();
    }

    private void StartSpawnCurrentWave()
    {
        InvokeRepeating("SpawnEnemy", maintenanceTime, GameManager.Instance.spawnInterval);
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
            //추후 Enemy추가시 수정
            return Random.Range(0, 3);
        }

        return (int)waveData[WaveIndex].WaveEnemyType;
    }
}
