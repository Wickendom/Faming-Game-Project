using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryData Data;

    public Action<Item, int> OnItemAdded;

    [SerializeField]
    private Item[] InventorySlots;

    public void Initialise(InventoryData data)
    {
        Data = data;
        InventorySlots = new Item[Data.AmountOfSlots];
    }

    public Item[] GetItems()
    {
        return InventorySlots;
    }

    public Item GetItem(int index)
    {
        return InventorySlots[index];
    }

    public bool AddItem(Item item)
    {
        var slotIndex = FindNextFreeSlot();

        if(slotIndex != -1)
        {
            InventorySlots[slotIndex] = item;
            OnItemAdded?.Invoke(item,slotIndex);
            return true;
        }
        else
        {
            Debug.Log("No free slot to store item");
            return false;
        }
    }

    private int FindNextFreeSlot()
    {
        for (int i = 0; i < InventorySlots.Length - 1; i++)
        {
            if (InventorySlots[i] == null)
            {
                return i;
            }
        }

        return -1;
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < InventorySlots.Length && InventorySlots[index] != null)
        {
            Debug.Log($"{InventorySlots[index].Name} removed from inventory.");
            InventorySlots[index] = null;
        }
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (InventorySlots[i] == item)
            {
                Debug.Log($"{item.Name} removed from inventory.");
                InventorySlots[i] = null;
                break;
            }
        }
    }
}
