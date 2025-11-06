using UnityEngine;

public class PlayerInventory : Inventory
{
    public override string OwnerName => "Player";
    
    public override void AddItem(Item item, int amountToRemove)
    {
        base.AddItem(item, amountToRemove);
    }
}
