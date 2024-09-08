using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Hoe", menuName = "Item/Tool/Hoe")]
public class Hoe : Tool
{
    public int Range;
    public TileBase TilledTile;

    public override void Use()
    {
        var pos = Player.Instance.GetFacingTilePosition();
        TileMapManger.Instance.UpdateTile(new Vector3Int((int)pos.x,(int)pos.y,(int)pos.z),TilledTile);
    }
}