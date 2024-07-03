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
        button = GetComponent<Button>();
        foreach (Tile tile in tiles)
        {
            AddEvents(tile);
        }

    }

    public void AddEvents(Tile tile)
    {
        switch (towerType)
        {
            case TowerType.NOMAL:
                button.onClick.AddListener(tile.OnNomalSelected);
                break;
            case TowerType.SLOW:
                button.onClick.AddListener(tile.OnSlowSelected);
                break;
            case TowerType.SNIPER:
                button.onClick.AddListener(tile.OnSniperSelected);
                break;
        }
    }
}
