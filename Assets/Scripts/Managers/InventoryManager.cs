using UnityEngine;
using System.Collections.Generic;

public enum InventoryType
{
    Player
}

public class InventoryManager : MonoBehaviour
{
    [Header("World Refs")]
    public GameObject worldItem;
    
    [Header("Audio")]
    public AudioSource itemSoundSource;
    public AudioClip itemPickupSound;
    
    private Dictionary<InventoryType, Inventory> inventories = new Dictionary<InventoryType, Inventory>();
    private InventoryNotification inventoryNotification;

    private void Awake()
    {
        inventoryNotification = FindFirstObjectByType<InventoryNotification>();
        
        inventories[InventoryType.Player] = new PlayerInventory();

        if (worldItem == null)
        {
            worldItem = GameObject.FindGameObjectWithTag("InventoryItemSpawn");
        }

        if (itemSoundSource == null)
        {
            Debug.LogWarning("InventoryManager: No sound source found");
        }

        if (itemPickupSound == null)
        {
            Debug.LogWarning("InventoryManager: No sound clips found");
        }
        
    }
    
    public void AddItemToInventory(Item item, InventoryType targetInventory, int amountToAdd = 1)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"InventoryManager: Cannot add '{item.itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.AddItem(item, amountToAdd);
        itemSoundSource.PlayOneShot(itemPickupSound);
        if (targetInventory == InventoryType.Player && inventoryNotification != null)
        {
            inventoryNotification.ShowMessage(item.itemName, amountToAdd);
        }
        
        FindAnyObjectByType<InventoryUI>().UpdateUI(inventory);
    }

    public void RemoveItemFromInventory(Item item, InventoryType targetInventory, int amountToRemove = 1)
    {
        if (!inventories.TryGetValue(targetInventory, out Inventory inventory))
        {
            Debug.LogWarning($"InventoryManager: Cannot remove '{item.itemName}': No inventory found for '{targetInventory}'");
            return;
        }
        
        inventory.RemoveItem(item, amountToRemove);
        if (targetInventory == InventoryType.Player && inventoryNotification != null)
        {
            inventoryNotification.ShowMessage(item.itemName, amountToRemove, false);
        }
        FindAnyObjectByType<InventoryUI>().UpdateUI(inventory);

        if (worldItem != null)
        {
            Instantiate(item.prefab, worldItem.transform.position, worldItem.transform.rotation);
        }
    }
}
