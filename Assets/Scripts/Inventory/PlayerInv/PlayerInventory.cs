using UnityEngine;

public class PlayerInventory : Inventory
{
    public override string OwnerName => "Player";
    
    public override void AddItem(Item item)
    {
        base.AddItem(item);
        
        Debug.Log("Player inventory updated!");
    }
}
