using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public int positionX;
    public int positionY;
    bool isSelected;
    TowerType towerType;
    GameObject towerToSpawn;
    public GameObject[] towerPrefabs;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnTower(TowerType.NOMAL);
        //}
    }
    public void SpawnTower(TowerType towerType)
    {
        Vector3 spawnPoint = this.transform.position + Vector3.up;
        towerToSpawn = Instantiate(towerPrefabs[(int)towerType],spawnPoint, Quaternion.identity);
    }

    public void OnClicked()
    {
        SpawnTower(TowerType.NOMAL);
    }
}
