using UnityEngine;

public class PlayerItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake()
    {
        if (inventoryManager == null)
        {
            inventoryManager = FindFirstObjectByType<InventoryManager>();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            inventoryManager.AddItemToInventory(collisionItem.GetItem(), InventoryType.Player, collisionItem.GetAmount());
            Destroy(collisionItem.gameObject);
        }
    }
}
