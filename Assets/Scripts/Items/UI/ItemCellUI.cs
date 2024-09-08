using System.Collections;
using System.Collections.Generic;
using TheraBytes.BetterUi;
using UnityEngine;

[RequireComponent(typeof(BetterButton),typeof(BetterImage))]
public class ItemCellUI : MonoBehaviour
{
    private Item Item;
    private BetterTextMeshProUGUI Text;
    private BetterImage Image;
    private BetterButton Button;

    private void Awake()
    {
        Text = GetComponentInChildren<BetterTextMeshProUGUI>();
        Image = GetComponent<BetterImage>();
        Button = GetComponent<BetterButton>();
    }

    public void SetItem(Item item)
    {
        Item = item;

        UpdateText();
    }

    void UpdateText()
    {
        if(Item != null)
        {
            Text.text = Item.Name;
        }
        else
        {
            Text.text = string.Empty;
        }
    }

    public void ClearItem()
    {
        Item = null;

        UpdateText() ;
    }

    public void Select()
    {
        Button.Select();
    }
}
