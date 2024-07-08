using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/Create WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField]
    private int waveIndex;
    public int WaveIndex { get { return waveIndex; } }
    [SerializeField]
    private int enemySpawnMaxCount;
    public int EnemySpawnMaxCount { get { return enemySpawnMaxCount; } }
    [SerializeField]
    private EnemyType waveEnemyType;
    public EnemyType WaveEnemyType { get { return waveEnemyType; } }
    [SerializeField]
    private GameObject[] enemyPrefabs;
    public GameObject[] EnemyPreFabs { get { return enemyPrefabs; } }
}
