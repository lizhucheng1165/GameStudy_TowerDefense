using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public int positionX;
    public int positionY;
    public bool isSelected;
    TowerType towerType;
    GameObject towerToSpawn;
    public GameObject[] towerPrefabs;

    private void Update()
    {
        
    }
    public void SpawnTower(TowerType towerType)
    {
        Vector3 spawnPoint = this.transform.position + Vector3.up;
        towerToSpawn = Instantiate(towerPrefabs[(int)towerType],spawnPoint, Quaternion.identity);
    }

    public void OnClicked()
    {
        if (isSelected)
        {
            SpawnTower(TowerType.NOMAL);
        }
    }
}
