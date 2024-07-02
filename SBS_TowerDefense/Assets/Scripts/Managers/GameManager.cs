using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int spawnCount { get; set; }
    public int currentEnemyCount { get; set; }
    public float spawnInterval{get; set;}
    public float waveInterval { get; set; }
    public int waveCount { get; set; }
    public int money { get; set; }
    public int enemyCount { get; set; }
    public int enemyTotalHealth { get; set; }

    protected override void Awake()
    {
        base.Awake();
        waveCount = 0;
        money = 0;
        enemyCount = 0;
        enemyTotalHealth = 0;
        //추후 변경
        waveInterval = 8.0f;

    }

    void InitalizeMainMap() { }
    void GameWin() { }
    void GameLose() { }
}
