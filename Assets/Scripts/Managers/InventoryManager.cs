using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [SerializeReference] private Inventory playerInventory;

    private void Awake()
    {
        playerInventory = new PlayerInventory();
    }
    
    public void AddItemToInventory(string itemName)
    {
        playerInventory.AddItem(itemName);

    }

    public void RemoveItemFromInventory(string itemName)
    {
        playerInventory.RemoveItem(itemName);
    }
}
