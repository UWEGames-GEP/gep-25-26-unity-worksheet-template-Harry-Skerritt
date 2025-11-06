using UnityEngine;

public class PlayerItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            Debug.Log($"Collied with item {collisionItem.GetItemName()}");
            inventoryManager.AddItemToInventory(collisionItem.GetItem(), InventoryType.Player);
            Destroy(collisionItem.gameObject);
        }
    }
}
