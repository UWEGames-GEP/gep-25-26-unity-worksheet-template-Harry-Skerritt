using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>();

    
    public void AddItemToInventory(string itemName)
    {
        items.Add(itemName);
        Debug.Log($"Added '{itemName}' to inventory!");

    }

    public void RemoveItemFromInventory(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log($"Removed '{itemName}' from inventory!");
            return;
        }

        Debug.LogWarning($"Could not find '{itemName}' in inventory!");
    }
}
