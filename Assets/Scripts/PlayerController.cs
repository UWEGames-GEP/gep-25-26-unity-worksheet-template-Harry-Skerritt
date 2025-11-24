using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : ThirdPersonController
{
    private void OnPause(InputValue value)
    {
        if(value.isPressed)
        {
            FindAnyObjectByType<GameManager>().GetStateMachine().transitionEvent.Invoke(TransitionParam.PauseTrigger);
        }
    }

    private void OnInventory(InputValue value)
    {
        
        if (value.isPressed)
        {
            FindAnyObjectByType<GameManager>().GetStateMachine().transitionEvent.Invoke(TransitionParam.InventoryTrigger);
        }
    }

}
