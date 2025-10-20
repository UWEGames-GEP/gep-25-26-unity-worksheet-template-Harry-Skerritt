using UnityEngine;
using System.Collections.Generic;

public enum InventoryType
{
    Player
}

public class InventoryManager : MonoBehaviour
{
    // Game Manager
    [Header("Game Manager")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string playStateName = "state_Play";

    // Inventory Data Struct
    private Dictionary<InventoryType, Inventory> inventories = new Dictionary<InventoryType, Inventory>();
    
    // UI
    private InventoryNotification inventoryNotification;


    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        if(inventoryNotification == null)
        {
            inventoryNotification = FindObjectOfType<InventoryNotification>();
        }

        inventories[InventoryType.Player] = new PlayerInventory();
        
    }
    
    public void AddItemToInventory(string itemName, InventoryType targetInventory)
    {
        if (gameManager.GetCurrentState() != playStateName)
        {
            Debug.LogWarning("InventoryManager: Cannot add item when paused!");
            return;
        }

        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot add '{itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.AddItem(itemName);

        // UI
        if (targetInventory == InventoryType.Player && inventoryNotification != null)
        {
            inventoryNotification.ShowMessage(itemName); // Todo: pass quantity once added!
        }
    }

    public void RemoveItemFromInventory(string itemName, InventoryType targetInventory)
    {
        if (gameManager.GetCurrentState() != playStateName)
        {
            Debug.LogWarning("InventoryManager: Cannot remove item when paused!");
            return;
        }

        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"Cannot remove '{itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.RemoveItem(itemName);
    }
}
