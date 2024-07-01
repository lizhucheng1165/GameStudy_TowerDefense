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
    public int waveIndex;
    private void Awake()
    {
        waveIndex = 0;
        GameManager.Instance.spawnInterval = 1.0f;
        spawnPoint = this.transform.position;
        //enemyPrefab = waveData[waveIndex].EnemyPreFabs[(int)waveData[waveIndex].WaveEnemyType];
        //InvokeRepeating("SpawnEnemy", 0.3f, 1.0f);
    }

    void Update()
    {
        enemyPrefab = waveData[waveIndex].EnemyPreFabs[(int)waveData[waveIndex].WaveEnemyType];

        if (GameManager.Instance.spawnCount >= waveData[waveIndex].EnemySpawnMaxCount)
        {
            CancelInvoke("SpawnEnemy");
            GameManager.Instance.spawnCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("��������");
            InvokeRepeating("SpawnEnemy", 0.3f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("���̺��ε��� ����");
            waveIndex++;
        }
    }
   
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        GameManager.Instance.spawnCount++;
    }
    
}
