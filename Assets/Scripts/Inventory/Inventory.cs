using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public abstract class Inventory
{
    [SerializeField] protected List<string> items = new List<string>();

    public virtual void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log($"Added '{itemName}' to {GetType().Name}!");
    }

    public virtual void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log($"Removed '{itemName}' from {GetType().Name}!");
            return;
        }

        Debug.LogWarning($"Could not find '{itemName}' in {GetType().Name}!");
    }
    
    public abstract string OwnerName { get; }
    
}
