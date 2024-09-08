using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemObject : MonoBehaviour
{
    public Item Data;
    public SpriteRenderer SpriteRend;

    public void Initialize(Item data)
    {
        Data = data;
        SpriteRend.sprite = data.ItemSprite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var pickedUp = PlayerInventoryManager.Instance.AddItem(Data);
        
        if(pickedUp == true)
        {
            Destroy(gameObject);
        }
    }
}
