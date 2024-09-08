using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : ScriptableObject
{
    public string Name;
    public TileBase[] TileGrowthStages;
}
