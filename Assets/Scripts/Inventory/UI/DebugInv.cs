using UnityEngine;

using TMPro;
using System.Text;


public class DebugInv : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryText;

    private void Start()
    {
        if(inventoryText != null)
            inventoryText.text = "";
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
}
