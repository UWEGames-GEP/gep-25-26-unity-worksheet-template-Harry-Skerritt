using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlotUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuantity;

    private void Start()
    {
        if (slotImage == null)
        {
            Debug.LogError("InventorySlotUI: Slot image is null");
        }

        if (itemName == null)
        {
            Debug.LogError("InventorySlotUI: Item name is null");
        }

        if (itemQuantity == null)
        {
            Debug.LogError("InventorySlotUI: Item quantity is null");
        }
    }

    public void SetImage(Sprite sprite)
    {
        if (slotImage == null) return;
        
        slotImage.sprite = sprite;
    }

    public void SetName(string name)
    {
        if (itemName == null) return;
        
        itemName.text = name;
    }

    public void SetQuantity(int quantity)
    {
        if (itemQuantity == null) return;
        
        itemQuantity.text = $"x{quantity.ToString()}";
    }
}