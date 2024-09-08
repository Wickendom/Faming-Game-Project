using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static PlayerInventoryManager Instance;

    public Inventory HotbarInventory;
    public Inventory BackpackInventory;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    public bool AddItem(Item item)
    {
        var addedToHotbar = HotbarInventory.AddItem(item);
        
        if(addedToHotbar == false)
        {
            var addedToBackpack = BackpackInventory.AddItem(item);
            return addedToBackpack;
        }

        return true;
    }
}
