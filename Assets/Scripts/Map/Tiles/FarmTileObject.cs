using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTileObject : TileObject, IFarmTileObject
{
    private readonly FarmTile _data;

    public bool isWatered;
    public PlantObject currentPlant;

    public FarmTileObject(Vector2Int tileCoords)
        : base(tileCoords)
    {

    }

    public FarmTileObject(Vector2Int tileCoords, FarmTile data)
        : base(tileCoords)
    {
        _data = data;
    }

    FarmTileObject IFarmTileObject.GetTileData()
    {
        throw new System.NotImplementedException();
    }

    TileSoBase ITileObject.GetTileData()
    {
        throw new System.NotImplementedException();
    }

    void ITileObject.OnPlayerInteraction()
    {
        throw new System.NotImplementedException();
    }
}
