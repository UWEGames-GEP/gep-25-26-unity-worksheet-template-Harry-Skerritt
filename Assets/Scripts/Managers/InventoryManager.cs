using UnityEngine;
using System.Collections.Generic;

public enum InventoryType
{
    Player
}

public class InventoryManager : MonoBehaviour
{
    private Dictionary<InventoryType, Inventory> inventories = new Dictionary<InventoryType, Inventory>();
    [SerializeField] private InventoryNotification inventoryNotification;

    private void Awake()
    {
        inventoryNotification = FindObjectOfType<InventoryNotification>();
        
        inventories[InventoryType.Player] = new PlayerInventory();
        
    }
    
    public void AddItemToInventory(string itemName, InventoryType targetInventory)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot add '{itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.AddItem(itemName);
        if (targetInventory == InventoryType.Player && inventoryNotification != null)
        {
            inventoryNotification.ShowMessage(itemName); // Todo: pass quantity once added!
        }
    }

    public void RemoveItemFromInventory(string itemName, InventoryType targetInventory)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot remove '{itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.RemoveItem(itemName);
    }
}
