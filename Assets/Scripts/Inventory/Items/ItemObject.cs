using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [Header("Item Visuals")] 
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private float bobHeight = 0.25f;
    [SerializeField] private float bobSpeed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        BobAndRotateItem();
    }

    private void BobAndRotateItem()
    {
        // Spin Item
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        
        // Bob Item
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
