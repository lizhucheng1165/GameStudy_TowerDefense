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

    protected override void Awake()
    {
        base.Awake();
        waveCount = 0;
        if (mode == DebugMode.DEBUGGING)
        {
            Money = 99999;
            waveInterval = 8.0f;
        }
        else
        {
            Money = 0;
            waveInterval = 60f;
        }
        enemyCount = 0;
        enemyTotalHealth = 0;
        //추후 변경
        currentGameState = GameState.PLAYING;

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
}
