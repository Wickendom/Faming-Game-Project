using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Base Tile", menuName = "Tiles/Base Tile")]
public class TileSoBase : ScriptableObject
{
    public string TileName;
    public TileBase[] Tiles;

    public bool IsTillable;
    public bool IsPlantable;
    public bool IsBuildable;

    public TileBase GetFirstTile()
    {
        return Tiles.FirstOrDefault();
    }

    public TileBase GetRandomTile()
    {
        var index = Random.Range(0, Tiles.Length);

        return Tiles[index];
    }
}