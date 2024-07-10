using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { PLAYING, TILE_SELECTED, GAME_WON, GAME_LOSE}
public enum DebugMode { DEFALT, DEBUGGING}
public class GameManager : Singleton<GameManager>
{
    public GameState currentGameState;
    public DebugMode mode;
    public int spawnCount { get; set; }
    public int currentEnemyCount { get; set; }
    public float spawnInterval{get; set;}
    public float waveInterval { get; set; }
    public int waveCount { get; set; }
    private int money { get; set; }
    public int Money 
    {
        get 
        { 
            return money; 
        }
        set 
        {
            money = value;
            UIManager.Instance.SetMoneyUI();
        }
    }
    private int enemyCount;
    public int EnemyCount 
    {
        get 
        { 
            return enemyCount; 
        }
        set 
        {
            enemyCount = value;
            UIManager.Instance.SetEnemyCountText();
        }
    }
    public int enemyTotalHealth { get; set; }
    public Tile[] tiles;
    public bool isLastWave = false;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(InitalizeGameStatus());

    }
    IEnumerator InitalizeGameStatus()
    {
        yield return new WaitForEndOfFrame();
        waveCount = 0;
        if (mode == DebugMode.DEBUGGING)
        {
            Money = 99999;
        }
        else
        {
            Money = 50;
        }
        enemyCount = 0;
        enemyTotalHealth = 0;
        //추후 변경
        currentGameState = GameState.PLAYING;
        UIManager.Instance.SetUpTowerSpawnCancleUI();
    }

    private void Update()
    {
        HandleGameState();
    }
    void InitalizeMainMap() { }
    void GameWin() { }
    void GameLose() { }

    void HandleGameState()
    {
        switch (currentGameState)
        {
            case GameState.PLAYING:
                break;
            case GameState.TILE_SELECTED:
                break;
            case GameState.GAME_WON:
                break;
            case GameState.GAME_LOSE:
                break;

        }
    }

    public bool CheckIfTileSelected()
    {
        foreach (var tile in tiles)
        {
            if (tile.isSelected)
            {
                return true;
            }
        }
        return false;
    }

    public void SumAllEnemiesCurrentHealth()
    {
        foreach (Transform enemy in UIManager.Instance.enemyList)
        {
            if (enemy.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyTotalHealth += enemyComponent.currentHealth;
            }
        }
    }
}
