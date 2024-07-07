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

    Button button;
    public bool isSelected;
    public bool towerSpawned = false;
    private void Awake()
    {
        SetOnclick();
    }

    public void SpawnTower(TowerType towerType)
    {
        Vector3 spawnPoint = this.transform.position + Vector3.up * 0.7f;
        print(towerPrefabs[(int)towerType].GetComponent<Tower>().price);
        if (CheckTowerPurchase(towerPrefabs[(int)towerType]))
        {
            towerToSpawn = Instantiate(towerPrefabs[(int)towerType], spawnPoint, Quaternion.identity);
        }

    }

    public bool CheckTowerPurchase(GameObject towerToPurChase)
    {
        towerToPurChase.TryGetComponent<Tower>(out Tower test);
        if (towerToPurChase.TryGetComponent<Tower>(out Tower tower))
        {
            print("타워가없나?");
            if (tower.price <= GameManager.Instance.Money)
            {
                GameManager.Instance.Money -= tower.price;
                return true;
            }
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
