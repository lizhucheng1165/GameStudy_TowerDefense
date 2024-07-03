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

    public void SpawnTower(TowerType towerType)
    {
        Vector3 spawnPoint = this.transform.position + Vector3.up;
        towerToSpawn = Instantiate(towerPrefabs[(int)towerType],spawnPoint, Quaternion.identity);
    }

    public void OnNomalSelected()
    {
        if (isSelected)
        {
            print("�븻 ����");
            SpawnTower(TowerType.NOMAL);
        }
    }

    public void OnSlowSelected()
    {
        if (isSelected)
        {
            print("���ο� ����");
        }
    }

    public void OnSniperSelected()
    {
        if (isSelected)
        {
            print("�������� ����");
        }
    }
}
