using UnityEngine;
using System.Collections.Generic;

public enum InventoryType
{
    Player
}

public class InventoryManager : MonoBehaviour
{
    private Dictionary<InventoryType, Inventory> inventories = new Dictionary<InventoryType, Inventory>();
    private InventoryNotification inventoryNotification;

    private void Awake()
    {
        inventoryNotification = FindObjectOfType<InventoryNotification>();
        
        inventories[InventoryType.Player] = new PlayerInventory();
        
    }
    
    public void AddItemToInventory(Item item, InventoryType targetInventory, int amountToAdd = 1)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot add '{item.itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.AddItem(item, amountToAdd);
        if (targetInventory == InventoryType.Player && inventoryNotification != null)
        {
            inventoryNotification.ShowMessage(item.itemName, amountToAdd);
        }
    }

    public void RemoveItemFromInventory(Item item, InventoryType targetInventory, int amountToRemove = 1)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot remove '{item.itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.RemoveItem(item, amountToRemove);
    }
}
