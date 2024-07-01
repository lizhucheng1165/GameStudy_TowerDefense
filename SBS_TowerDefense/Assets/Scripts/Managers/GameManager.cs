using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int spawnCount { get; set; }
    public float spawnInterval{get; set;}
    int waveCount;
    int money;
    int enemyCount;
    int enemyTotalHealth;

    void InitalizeMainMap() { }
    void GameWin() { }
    void GameLose() { }

    
}
