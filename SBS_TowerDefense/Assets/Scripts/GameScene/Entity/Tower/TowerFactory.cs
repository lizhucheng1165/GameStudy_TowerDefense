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

        Tower spawnTower = PrefabUtility.InstantiatePrefab(findTower) as Tower;
        spawnTower.transform.position = tile.transform.position + Vector3.up;
        spawnTower.transform.SetParent(tile.transform, true);
        spawnTower.GetComponent<Renderer>().material.color = GameInstance.Instance.ratingColorConfig.ratingColors[spawnTower.rating];
        return spawnTower;
    }

    private List<Tower> getTowersOfRating(int rating)
    {
        List<Tower> towers = new List<Tower>();
        foreach (Tower tower in GameInstance.Instance.towerConfig.towers)
        {
            if (tower.towerId > 0 && tower.rating == rating)
                towers.Add(tower);
        }

        return towers;
    }

    public Tower SpawnRandomTowerOfRating(Tile tile, int rating)
    {
        List<Tower> towers = getTowersOfRating(rating);
        if (towers.Count == 1)
            return SpawnTower(tile, towers[0].towerId);

        return SpawnTower(tile, towers[Random.Range(0, towers.Count)].towerId);
    }


}
