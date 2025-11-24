using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlotUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuantity;
    [SerializeField] private Button removeButton;
    
    private Item item;
    private int quantity;

    private void Start()
    {
        if (slotImage == null)
        {
            Debug.LogError("InventorySlotUI: Slot image is null");
        }

        if (itemName == null)
        {
            Debug.LogError("InventorySlotUI: Item name is null");
        }

        if (itemQuantity == null)
        {
            Debug.LogError("InventorySlotUI: Item quantity is null");
        }

        if (removeButton == null)
        {
            Debug.LogError("InventorySlotUI: Remove button is null");
        }
        else
        {
            removeButton.onClick.AddListener(RemoveItem);
        }
    }
    
    public void RemoveItem()
    {
        InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
        inventoryManager.RemoveItemFromInventory(item, InventoryType.Player, 1);
        quantity--;
        if (quantity == 0)
        {
            Destroy(this.gameObject);
        }
        else
        { 
            itemQuantity.text = $"x{(quantity).ToString()}";
        }
        
    }

    public void SetItem(Item item, int quantity)
    {
        this.item = item;
        slotImage.sprite = item.icon;
        itemName.text = item.name;
        this.quantity = quantity;
        itemQuantity.text = $"x{quantity.ToString()}";
    }
    
}