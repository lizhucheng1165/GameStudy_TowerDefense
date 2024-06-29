using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int positionX;
    int positionY;
    bool isSelected;
    TowerType towerType;
    GameObject towerToSpawn;
    GameObject[] towerPrefabs;

    void SpawnTower(TowerType towerType) { }
}
