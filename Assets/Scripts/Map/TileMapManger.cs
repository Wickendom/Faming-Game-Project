using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class TileMapManger : MonoBehaviour
{
    public static TileMapManger Instance;

    [SerializeField]
    private Tilemap GroundTileMap;
    [SerializeField]
    private Tilemap InteractableTileMap;

    private Dictionary<TileBase, TileSoBase> tiles;

    private Dictionary<Vector2Int, ITileObject> interactableTileDict;

    [SerializeField]
    private TileSoBase[] tileDatas;

    [SerializeField]
    private int tileMapWidth, tileMapHeight;
    
    [SerializeField]
    private GameObject EmptyTile;
    [SerializeField]
    private TileSoBase EmptyTileData;

    [SerializeField]
    private GameObject FarmTilePrefab; 

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        interactableTileDict = new Dictionary<Vector2Int, ITileObject>();
        tiles = new Dictionary<TileBase, TileSoBase>();

        foreach(var tileData in tileDatas)
        {
            foreach (var tile in tileData.Tiles)
            {
                tiles.Add(tile,tileData);
            }
        }

        Initialise();
    }

    private void Initialise()
    {

    }

    public void UpdateTile(Vector3Int tilePosition, TileBase tile)
    {
        InteractableTileMap.SetTile(tilePosition, tile);
        //interactableTileDict.TryGetValue((Vector2Int)tilePosition,out var tileObject);

        var farmTile = new FarmTileObject(new Vector2Int(tilePosition.x,tilePosition.y));
        interactableTileDict[(Vector2Int)tilePosition] = farmTile;
    }

    public ITileObject GetTileFromWorldPos(Vector3 worldPosition)
    {
        var tilePos = (Vector2Int)GetTilePosition(worldPosition);
        interactableTileDict.TryGetValue(tilePos, out var tileObject);
        
        return tileObject;
    }

    public Vector3Int GetTilePosition(Vector3 worldPos)
    {
        return InteractableTileMap.WorldToCell(worldPos);
    }

    public bool CheckTileIsTillable(Vector3Int worldPos)
    {
        var tile = GroundTileMap.GetTile(worldPos);
        Debug.Log(tiles[tile].IsTillable);

        if(tiles.TryGetValue(tile, out var data))
        {
            return data.IsTillable;
        }
        else
        {
            Debug.LogWarning($"{tile.name} data not found");
            return false;
        }
    }
}
