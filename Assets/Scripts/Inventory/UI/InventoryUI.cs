using UnityEngine;

using TMPro;
using System.Text;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI inventoryText;

    private void Start()
    {
        if (inventoryText != null)
            inventoryText.text = "";

        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    public void UpdateUI(Inventory inventory)
    {
        if (inventory == null) return;

        StringBuilder sb = new StringBuilder();

        foreach (var slot in inventory.GetItems)
        {
            if (slot.item != null && slot.quantity > 0)
            {
                sb.AppendLine($"{slot.quantity}x {slot.item.itemName}");
            }
        }

        inventoryText.text = sb.ToString();
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
