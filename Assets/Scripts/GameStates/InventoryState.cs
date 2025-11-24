using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InventoryState : GameState
{
   public InventoryState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

   public override string stateID => "state_Inventory";

    public override void OnEnter()
    {
        Debug.Log($"{stateID} Enter");

        // UI
        gameManager.SetInventoryActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }

    public override void Update()
    {
        // Handle mouse in the inventory
        
    }

    public override void TransitionEvent(TransitionParam param)
    {
        if(param == TransitionParam.PauseTrigger || param == TransitionParam.InventoryTrigger)
        {
            stateMachine.ChangeState(gameManager.playState);
        }
    }

    public override void LateUpdate()
    {
        Time.timeScale = 0f;
        gameManager.LockPlayerCamera(true);
    }

    public override void OnExit()
    {
        Debug.Log($"{stateID} Exit");
        gameManager.SetInventoryActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
