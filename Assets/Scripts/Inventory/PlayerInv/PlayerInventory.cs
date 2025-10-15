using UnityEngine;

public class PlayerInventory : Inventory
{
    public override string OwnerName => "Player";
    
    public override void AddItem(string itemName)
    {
        base.AddItem(itemName);
        
        Debug.Log("Player inventory updated!");
    }
}
