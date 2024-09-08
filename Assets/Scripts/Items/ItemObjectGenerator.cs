using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectGenerator : MonoBehaviour
{
    public static ItemObjectGenerator Instance;

    [SerializeField]
    private GameObject itemObjectPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void CreateItemObject(Item item, Vector3 spawnPosition)
    {
        var itemObject = Instantiate(itemObjectPrefab, spawnPosition, Quaternion.identity);
        itemObject.GetComponent<ItemObject>().Initialize(item);
    }
}