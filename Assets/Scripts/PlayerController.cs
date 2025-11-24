using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : ThirdPersonController
{
    private void OnPause(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("Pause Triggered");
        }
    }

    private void OnInventory(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Inventory Triggered");
        }
    }

}
