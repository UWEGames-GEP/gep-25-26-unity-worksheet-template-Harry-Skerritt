using UnityEngine;

using TMPro;
using System.Text;


public class InventoryUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI inventoryHeader;
    [SerializeField] private GameObject slotHolder;
    
    [Header("Instanceables")]
    [SerializeField] private GameObject inventorySlotPrefab;

    private void Start()
    {
        if (inventoryPanel == null || inventoryHeader == null || slotHolder == null || inventorySlotPrefab == null)
        {
            Debug.LogError("One or more of the needed objects are not present in the inspector");
            return;
        }
        
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    public void UpdateUI(Inventory inventory)
    {
        if (inventory == null) return;

        // Set Header
        if (inventoryHeader != null)
        {
            inventoryHeader.text = $"{inventory.OwnerName} Inventory";
        }
        
        // Clear Slots
        foreach (Transform child in slotHolder.transform)
        {
            Debug.Log(child.name);
            Destroy(child.gameObject);
        }
        
        // Create new slots
        foreach (var slot in inventory.GetItems)
        {
            if (slot.item != null && slot.quantity > 0)
            {
                GameObject slotGo = Instantiate(inventorySlotPrefab, slotHolder.transform);
                slotGo.name = "Slot" + slot.item.name;
                InventorySlotUI slotUI = slotGo.GetComponent<InventorySlotUI>();
                if (slotUI == null)
                {
                    Debug.LogError("InventoryUI: slot prefab doesn't have InventorySlotUI script");
                }
                
                slotUI.SetItem(slot.item, slot.quantity);
            }
        }
    }

    public void ToggleUI()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void SetInventoryActive(bool active)
    {
        inventoryPanel.SetActive(active);
    }
}
