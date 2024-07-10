using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerFactory
{
    private List<Tower> towers;

    public TowerFactory()
    {
        towers = GameInstance.Instance.towerConfig.towers;
    }

    public Tower SpawnTower(Tile tile, int towerId)
    {
        Tower findTower = null;
        foreach (Tower tower in towers)
        {
            if (tower.towerId == towerId)
                findTower = tower;
        }

        if (findTower == null)
            return null;

        findTower.transform.position = tile.transform.position + Vector3.up;
        Tower spawnTower = PrefabUtility.InstantiatePrefab(findTower) as Tower;
        spawnTower.transform.SetParent(tile.transform, true);
        return spawnTower;
    }

}
