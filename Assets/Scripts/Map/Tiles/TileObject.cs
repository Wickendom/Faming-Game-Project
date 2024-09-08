using UnityEngine;
using UnityEngine.Tilemaps;

public class TileObject : Tile, ITileObject
{
    private readonly TileSoBase _tileData;
    private readonly Vector2Int _coords;

    public TileObject(Vector2Int tileCoords)
    {
        _coords = tileCoords;
    }

    public TileObject(Vector2Int tileCoords, TileSoBase tileData)
    {
        _coords = tileCoords;
        _tileData = tileData;
    }

    public virtual void Initialise()
    {
        
    }

    public TileSoBase GetTileData()
    {
        return _tileData;
    }

    public void OnPlayerInteraction()
    {
        throw new System.NotImplementedException();
    }
}