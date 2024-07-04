using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    Button button;
    public Tile[] tiles;
    public TowerType towerType;
    private void Awake()
    {
        if (TryGetComponent<Button>(out button))
        {
            foreach (Tile tile in tiles)
            {
                AddEvents(tile);
            }
        }

        button.onClick.AddListener(ResetTileSelection);
    }

    public void AddEvents(Tile tile)
    {
        switch (towerType)
        {
            case TowerType.NOMAL:
                button.onClick.AddListener(tile.OnNomalSelected);
                break;
            case TowerType.SNIPER:
                button.onClick.AddListener(tile.OnSniperSelected);
                break;
            case TowerType.SLOW:
                button.onClick.AddListener(tile.OnSlowSelected);
                break;
        }
    }

    public void ResetTileSelection()
    {
        GameManager.Instance.currentGameState = GameState.PLAYING;
        foreach (Tile tile in tiles)
        {
            tile.isSelected = false;
        }
    }
}
