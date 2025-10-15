using UnityEngine;
using System.Collections.Generic;

public enum InventoryType
{
    Player
}

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Dictionary<InventoryType, Inventory> inventories = new Dictionary<InventoryType, Inventory>();

    private void Awake()
    {
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
