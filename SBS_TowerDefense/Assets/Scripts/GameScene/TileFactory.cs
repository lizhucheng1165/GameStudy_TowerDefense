using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TileFactory
{
    private Tile tile;

    public TileFactory(Tile tilePrefab)
    {
        this.tile = tilePrefab;
    }

    public Tile createTile(float positionX, float positionZ)
    {
        tile.transform.position = new Vector3(positionX, 0, positionZ);
        return PrefabUtility.InstantiatePrefab(tile).GetComponent<Tile>();
    }
}
