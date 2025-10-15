using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private string itemName;
    public string ItemName => itemName;
    
}
