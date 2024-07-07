using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tile : MonoBehaviour
{
    public int positionX;
    public int positionY;
    TowerType towerType;
    GameObject towerToSpawn;
    public GameObject[] towerPrefabs;
    Dictionary<TowerType, int> towerPrices;
    int selectedTowerPrice;

    Button button;
    public bool isSelected;
    public bool towerSpawned = false;
    private void Awake()
    {
        SetOnclick();
        SetTowerPriceDictionary();
    }

    private void SetTowerPriceDictionary()
    {
        towerPrices = new Dictionary<TowerType, int>
        {
            {TowerType.NOMAL, 5 },
            {TowerType.SNIPER, 50 }
        };
    }

    public void SpawnTower(TowerType towerType)
    {
        Vector3 spawnPoint = this.transform.position + Vector3.up * 0.7f;
        towerPrices.TryGetValue(towerType, out selectedTowerPrice);
        if (CheckTowerPurchase(selectedTowerPrice))
        {
            towerToSpawn = Instantiate(towerPrefabs[(int)towerType], spawnPoint, Quaternion.identity);
        }
    }

    public bool CheckTowerPurchase(int price)
    {

        if (price <= GameManager.Instance.Money)
        {
            GameManager.Instance.Money -= price;
            return true;
        }

        return false;
    }

    public void OnNomalSelected()
    {
        if (isSelected && !towerSpawned)
        {
            SpawnTower(TowerType.NOMAL);
            isSelected = false;
            towerSpawned = true;
        }
    }

    public void OnSlowSelected()
    {
        if (isSelected && !towerSpawned)
        {
            isSelected = false;
            towerSpawned = true;
        }
    }

    public void OnSniperSelected()
    {
        if (isSelected && !towerSpawned)
        {
            SpawnTower(TowerType.SNIPER);
            isSelected = false;
            towerSpawned = true;
        }
    }

    public void OnTileSelected()
    {
        if (!GameManager.Instance.CheckIfTileSelected())
        {
            isSelected = true;
        }
        GameManager.Instance.currentGameState = GameState.TILE_SELECTED;
    }

    public void SetOnclick()
    {
        isSelected = false;
        if (TryGetComponent<Button>(out button))
        {
            button.onClick.AddListener(OnTileSelected);
        }
    }

}
