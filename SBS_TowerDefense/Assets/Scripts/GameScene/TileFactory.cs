using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory
{
    [SerializeField] private Tile tile;

    public TileFactory(Tile tilePrefab)
    {
        this.tile = tilePrefab;
    }

    public Tile createTile(float positionX, float positionZ)
    {
        tile.transform.position = new Vector3(positionX, 0, positionZ);
        return MonoBehaviour.Instantiate<Tile>(tile, tile.transform);
    }
}
