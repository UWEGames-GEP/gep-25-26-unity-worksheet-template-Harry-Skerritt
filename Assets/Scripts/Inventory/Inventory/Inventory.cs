using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public abstract class Inventory
{
    protected List<InventorySlot> items = new List<InventorySlot>();

    public virtual void AddItem(Item item, int amountToAdd)
    {
        InventorySlot existingSlot = items.Find(slot => slot.item == item);

        if (existingSlot != null)
        {
            // Slot exists
            int remaining = item.stackSize - existingSlot.quantity;
            int toAdd = Mathf.Min(amountToAdd, remaining);
            existingSlot.quantity += toAdd;
            
            int leftToAdd = amountToAdd - toAdd;
            if (leftToAdd > 0)
            {
                items.Add(new InventorySlot(item, toAdd));
            }
            
            Debug.Log($"Added {amountToAdd}x '{item.itemName}' to {GetType().Name}!");
        }
        else
        {
            // Slot doesnt exist
            items.Add(new InventorySlot(item, amountToAdd));
            Debug.Log($"Added new slot of {amountToAdd}x '{item.itemName}' to {GetType().Name}!");
        }
    }

    public virtual void RemoveItem(Item item, int amountToRemove)
    {
        InventorySlot existingSlot = items.Find(slot => slot.item == item);

        if (existingSlot == null)
        {
            Debug.LogWarning($"Could not find '{item.itemName}' in {GetType().Name}!");
            return;
        }
        
        existingSlot.quantity -= amountToRemove;
        Debug.Log($"Removed {amountToRemove}x '{item.itemName}' from {GetType().Name}!");
        if (existingSlot.quantity <= 0)
        {
            items.Remove(existingSlot);
        }
    }
    
    public abstract string OwnerName { get; }
    
}
