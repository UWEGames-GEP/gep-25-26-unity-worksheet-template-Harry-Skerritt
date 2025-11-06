using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public abstract class Inventory
{
    [SerializeField] protected List<Item> items = new List<Item>();

    public virtual void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log($"Added '{item.itemName}' to {GetType().Name}!");
    }

    public virtual void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Removed '{item.itemName}' from {GetType().Name}!");
            return;
        }

        Debug.LogWarning($"Could not find '{item.itemName}' in {GetType().Name}!");
    }
    
    public abstract string OwnerName { get; }
    
}
