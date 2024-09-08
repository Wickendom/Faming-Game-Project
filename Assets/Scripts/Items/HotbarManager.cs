using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Inventory))]
public class HotbarManager : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    
    [SerializeField] private List<ItemCellUI> Cells;

    private Inventory Inventory;

    private PlayerInputs Input = null;

    private int selectedCellIndex = 0;

    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
        Input = new PlayerInputs();
    }

    private void OnEnable()
    {
        EnableInput();
        Inventory.OnItemAdded += UpdateCell;
    }

    private void OnDisable()
    {
        DisableInput();
        Inventory.OnItemAdded -= UpdateCell;
    }

    // Start is called before the first frame update
    void Start()
    {
        Inventory.Initialise(_inventoryData);
        SetSelectedCell(0);
    }

    private void SetSelectedCell(int index)
    {
        Cells[index].Select();
    }

    // Update is called once per frame
    void Update()
    {
        var scrollValue = Input.Player.HotbarScroll.ReadValue<float>();

        if (scrollValue != 0)
        {
            OnScrollWheelMovement(scrollValue);
        }
    }

    private void EnableInput()
    {
        Input.Enable();
        Input.Player.Interact.performed += OnInteractPerformed;
    }

    private void DisableInput()
    {
        Input.Disable();
        Input.Player.Interact.performed -= OnInteractPerformed;
    }

    private void OnScrollWheelMovement(float scrollValue)
    {
        var scrollIncrement = (int)Mathf.Sign(scrollValue);
        var newIndex = selectedCellIndex + scrollIncrement;

        if(newIndex > Cells.Count -1)
        {
            newIndex = 0;
        }
        else if(newIndex < 0)
        {
            newIndex = Cells.Count - 1;
        }

        SetSelectedCell(newIndex);
        selectedCellIndex = newIndex;
    }

    public void OnInteractPerformed(InputAction.CallbackContext button)
    {
        var Item = Inventory.GetItem(selectedCellIndex);

        if(Item != null)
        {
            Item.Use();
        }
    }

    public void UpdateCell(Item item, int index)
    {
        Cells[index].SetItem(item);
    }
}
